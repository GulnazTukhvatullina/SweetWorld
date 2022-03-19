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
            UpdateList();
            this.BindingContext = this;
        }

        private void like_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            ContentView viewCell = button.Parent.Parent.Parent.Parent as ContentView;
            
            Favourite fav = (Favourite)viewCell.BindingContext;
            App.Database.DeleteFavourite(fav.Id);

            UpdateList();          
        }

        public void UpdateList()
        {
            List<Favourite> list = new List<Favourite>();
            foreach (var i in App.Database.GetFavouriteUser(IdUser))
            {
                list.Add(i);

            };
            TheCarousel.ItemsSource = list;
        }

        private async void assortmentPhoto_Clicked(object sender, EventArgs e)
        {
            ImageButton button = sender as ImageButton;
            ContentView viewCell = button.Parent.Parent as ContentView;
            Favourite fav = (Favourite)viewCell.BindingContext;
            await Navigation.PushAsync(new SelectedMakaronsPage(App.Database.GetAssortment(fav.IdAssortment),IdUser));
        }
    }
}