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
    public partial class PirozhCake : ContentPage
    {
        public int IdUser { get; set; }
        public PirozhCake()
        {
            InitializeComponent();
            IdUser = Convert.ToInt32(App.Current.Properties["IdUser"]);
            this.BindingContext = this;
        }

        protected override void OnAppearing()
        {
            pirozhList.ItemsSource = App.Database.GetAssortmentsType("Пирожные");
            base.OnAppearing();
        }

        private async void pirozhList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Assortment selectedAssortment = (Assortment)e.SelectedItem;
            await Navigation.PushAsync(new SelectedMakaronsPage(selectedAssortment, IdUser));
        }
    }
}