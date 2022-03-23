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
    public partial class CakesPage : ContentPage
    {
        public int IdUser { get; set; }
        public CakesPage()
        {
            InitializeComponent();
            IdUser = Convert.ToInt32(App.Current.Properties["IdUser"]);
            this.BindingContext = this;
        }

        protected override void OnAppearing()
        {
            cakesList.ItemsSource = App.Database.GetAssortmentsType("Торты");
            base.OnAppearing();
        }

        private async void cakesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Assortment selectedAssortment = (Assortment)e.SelectedItem;
            await Navigation.PushAsync(new SelectedMakaronsPage(selectedAssortment, IdUser));
        }
    }
}