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
        public SelectedMakaronsPage(Assortment assort,int idUser)
        {
            InitializeComponent();
            Assort = assort;
            IdUser = idUser;
            UpdatePage();
            UpdateFavourite();
            this.BindingContext = this;
        }

        public void UpdateFavourite()
        {
            if (App.Database.GetIsFavourite(IdUser, Assort.Id) == null)
            {
                like.BackgroundColor = Color.FromRgb(223, 165, 232);
            }
            else
            {
                like.BackgroundColor = Color.Wheat;
            }
        }

        public void UpdatePage()
        {
            if (App.Database.GetBacketUser(IdUser) != null)
            {
                if (App.Database.GetBacketId(IdUser, Assort.Id) != null)
                {
                    btnPlus.IsVisible = true;
                    btnMinus.IsVisible = true;
                    countLbl.IsVisible = true;
                    backet.IsVisible = false;
                    countLbl.Text = App.Database.GetBacketId(IdUser, Assort.Id).Count.ToString();
                }
                else
                {
                    btnPlus.IsVisible = false;
                    btnMinus.IsVisible = false;
                    countLbl.IsVisible = false;
                    backet.IsVisible = true;
                }

                if (App.Database.GetCountAssortinBacket(IdUser) != 0)
                {
                    Count = App.Database.GetCountAssortinBacket(IdUser);
                    count.Text = Count.ToString();
                }
            }
        }

        private void like_Clicked(object sender, EventArgs e)
        {
            if (App.Database.GetIsFavourite(IdUser, Assort.Id) != null)
            {
                like.BackgroundColor = Color.FromRgb(223, 165, 232);
                int idFav = App.Database.GetFavouriteId(IdUser, Assort.Id);
                App.Database.DeleteFavourite(idFav);
            }
            else
            {
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

        private async void backet_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BacketPage(IdUser));
        }

        private void btnBacketCliked(object sender, EventArgs e)
        {
            Backet bac;
            if ( App.Database.GetBacketUser(IdUser)==null || App.Database.GetBacketId(IdUser, Assort.Id) == null)
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
            Count++;       
            UpdatePage();
        }

        private void btnPlus_Clicked(object sender, EventArgs e)
        {
            Backet bac;
            bac = App.Database.GetBacket(App.Database.GetBacketId(IdUser, Assort.Id).Id);
            bac.Count = bac.Count + 1;
            bac.Summa = Assort.Price * bac.Count;
            App.Database.SaveBacket(bac);
            Count++;
            UpdatePage();
        }

        private void btnMinus_Clicked(object sender, EventArgs e)
        {
            Backet bac;
            bac = App.Database.GetBacket(App.Database.GetBacketId(IdUser, Assort.Id).Id);
            if (countLbl.Text == "1")
            {
                App.Database.DeleteBacket(bac.Id);
                btnPlus.IsVisible = false;
                btnMinus.IsVisible = false;
                countLbl.IsVisible = false;
                backet.IsVisible = true;
            }
            else
            {
                bac.Count = bac.Count - 1;
                bac.Summa = Assort.Price * bac.Count;
                App.Database.SaveBacket(bac);
                countLbl.Text = bac.Count.ToString();
            }
            Count--;
            UpdatePage();
        }

        private async void btnOk_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AssortmentsUserPage());
        }
    }
}