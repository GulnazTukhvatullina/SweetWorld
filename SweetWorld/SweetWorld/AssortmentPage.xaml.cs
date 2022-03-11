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
    }
}