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
    public partial class SelectedMakaronsPage : ContentPage
    {
        public Assortment Assort { get; set; }
        public int IdUser { get; set; }
        public SelectedMakaronsPage(Assortment assort,int idUser)
        {
            InitializeComponent();
            Assort = assort;
            IdUser = idUser;
            if (!Assort.IsFavourite)
            {
                like.BackgroundColor = Color.FromRgb(223, 165, 232);
            }
            else
            {
                like.BackgroundColor = Color.Wheat;
            }
            this.BindingContext = this;
        }

        private void like_Clicked(object sender, EventArgs e)
        {
            if (Assort.IsFavourite)
            {
                like.BackgroundColor = Color.FromRgb(223, 165, 232);
                Assort.IsFavourite = false;
                App.Database.SaveAssortment(Assort);
                int idFav = App.Database.GetFavouriteId(IdUser, Assort.Id);
                App.Database.DeleteFavourite(idFav);
            }
            else
            {
                Assort.IsFavourite = true;
                App.Database.SaveAssortment(Assort);

                like.BackgroundColor = Color.Wheat;
                Favourite fav = new Favourite()
                {
                    IdAssortment = Assort.Id,
                    IdUser = IdUser,
                    Description = Assort.Description,
                    Name = Assort.Name,
                    Price = Assort.Price,
                    Unit = Assort.Unit,
                    Mass = Assort.Mass,
                    PhotoPath = Assort.PhotoPath
                };
                App.Database.SaveFavourite(fav);
            }
        }
    }
}