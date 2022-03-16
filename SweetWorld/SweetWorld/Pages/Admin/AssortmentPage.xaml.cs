using SweetWorld.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SweetWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssortmentPage : ContentPage
    {
        public AssortmentPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        protected override void OnAppearing()
        {
            assortmentList.ItemsSource = App.Database.GetAssortments();
            base.OnAppearing();
        }

        private async void AddAssortment(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddAssortment());
        }

        private async void Remove_Clicked(object sender, SelectedItemChangedEventArgs e)
        {
            var assortment = e.SelectedItem as Assortment;
            if (await DisplayAlert(" ", $"Вы хотите удалить {assortment.Name}?", "Удалить", "Отмена"))
            {
                App.Database.DeleteAssortment(assortment.Id);
                assortmentList.ItemsSource = App.Database.GetAssortments();
            }
        }
    }
}