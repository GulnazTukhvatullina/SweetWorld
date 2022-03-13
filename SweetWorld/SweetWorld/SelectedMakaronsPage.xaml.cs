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
        public int Count { get; set; }
        public SelectedMakaronsPage(Assortment assort,int idUser,int countAssort)
        {
            InitializeComponent();
            Assort = assort;
            IdUser = idUser;
            if (App.Database.GetBacketUser(IdUser) != null)
            {
                Count = countAssort;
                count.Text = Count.ToString();
            }
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

        private void backet_Clicked(object sender, EventArgs e)
        {

        }

        private void btnBacketCliked(object sender, EventArgs e)
        {
            Backet bac;
            if ( App.Database.GetBacketUser(IdUser)==null)
            {
                bac = new Backet()
                {
                    IdAssortment = Assort.Id,
                    IdUser = IdUser,
                    Description = Assort.Description,
                    Name = Assort.Name,
                    Price = Assort.Price,
                    Unit = Assort.Unit,
                    Mass = Assort.Mass,
                    PhotoPath = Assort.PhotoPath,
                    Count = 1,
                    Summa = Assort.Price
                };
                App.Database.SaveBacket(bac);
            }
            else
            {
                bac = App.Database.GetBacket(App.Database.GetBacketId(IdUser, Assort.Id).Id);

                bac.Count = bac.Count + 1;
                bac.Summa = Assort.Price * bac.Count;
                App.Database.SaveBacket(bac);
            }
            Count++;
            count.Text = Count.ToString();
          
        }
    }
}