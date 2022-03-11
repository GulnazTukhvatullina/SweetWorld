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
    public partial class AddAssortment : ContentPage
    {
        public string pathName;
        public AddAssortment()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        private async void AddAssort(object sender, EventArgs e)
        {
            Assortment cat = new Assortment()
            {
                Name = name.Text,
                Description = description.Text,
                Mass = pickerMass.Text,
                PhotoPath = pathName,
                Price = Convert.ToInt32(price.Text),
                Type = typeAssortment.SelectedItem.ToString(),
                Unit = pickerUnit.SelectedItem.ToString()
                
            };
            if (!String.IsNullOrEmpty(cat.Name))
            {
                App.Database.SaveAssortment(cat);
            }
            await this.Navigation.PopAsync();
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

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}