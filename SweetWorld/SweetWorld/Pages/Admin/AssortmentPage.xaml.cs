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

        private async void assortmentList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Assortment selectedAssort = (Assortment)e.SelectedItem;
            EdirAssortmentPage editAssortPage = new EdirAssortmentPage(selectedAssort);
            editAssortPage.BindingContext = selectedAssort;
            await Navigation.PushAsync(editAssortPage);
        }
    }
}