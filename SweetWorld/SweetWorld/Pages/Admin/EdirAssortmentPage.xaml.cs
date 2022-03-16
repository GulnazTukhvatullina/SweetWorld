using SweetWorld.SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SweetWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EdirAssortmentPage : ContentPage
    {
        public string pathName;
        public EdirAssortmentPage(Assortment assor)
        {
            InitializeComponent();
            pathName = assor.PhotoPath;
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private async void EditAssort(object sender, EventArgs e)
        {
            var assort = (Assortment)BindingContext;
            assort.PhotoPath = pathName;
            if (await DisplayAlert(" ", $"Вы хотите изменить {assort.Name}?", "Изменить", "Отмена"))
            {
                if (!String.IsNullOrEmpty(assort.Name))
                {
                    App.Database.SaveAssortment(assort);
                }
                await this.Navigation.PopAsync();
            }
        }

        private async void RemoveAssortment(object sender, EventArgs e)
        {
            var assort = (Assortment)BindingContext;
            if (await DisplayAlert(" ", $"Вы хотите удалить {assort.Name}?", "Удалить", "Отмена"))
            {
                App.Database.DeleteAssortment(assort.Id);
                await Navigation.PushAsync(new AssortmentPage());
            }
        }

        private async void GetPhotoAsync(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                pathName = photo.FullPath;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
            UpdateList();
        }

        private async void TakePhotoAsync(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = $"xamarin.{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.png"
                });

                var newFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), photo.FileName);
                using (var stream = await photo.OpenReadAsync())
                using (var newStream = File.OpenWrite(newFile))
                    await stream.CopyToAsync(newStream);

                Debug.WriteLine($"Путь фото {photo.FullPath}");

                pathName = photo.FullPath;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
            UpdateList();
        }

        private void UpdateList()
        {
            asssortmentPhoto.Source = pathName;
            this.BindingContext = this;
        }

    }
}