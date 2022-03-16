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
    public partial class FavouritePage : ContentPage
    {
        public int IdUser { get; set; }
        public FavouritePage(int idUser)
        {
            InitializeComponent();
            IdUser = idUser;
            this.BindingContext = this;
        }

        protected override void OnAppearing()
        {
            favouritesList.ItemsSource = App.Database.GetFavouriteUser(IdUser);
            base.OnAppearing();
        }

        private void like_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            ViewCell viewCell = button.Parent.Parent.Parent.Parent as ViewCell;

            Favourite fav = (Favourite)viewCell.BindingContext;
            App.Database.DeleteFavourite(fav.Id);

            favouritesList.ItemsSource = App.Database.GetFavouriteUser(IdUser);
        }
    }
}