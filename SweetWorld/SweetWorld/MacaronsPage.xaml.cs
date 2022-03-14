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
    public partial class MacaronsPage : ContentPage
    {
        public int IdUser { get; set; }
        public int Count { get; set; }
        public MacaronsPage(int idUser)
        {
            InitializeComponent();
            IdUser = idUser;
            if (App.Database.GetCountAssortinBacket(IdUser) != 0)
                count.Text = App.Database.GetCountAssortinBacket(IdUser).ToString();
            this.BindingContext = this;
        }

        protected override void OnAppearing()
        {
            makaronsList.ItemsSource = App.Database.GetAssortmentsType("Макаронс");
            base.OnAppearing();
        }

        private void like_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            ViewCell viewCell = button.Parent.Parent.Parent as ViewCell;
            
            Assortment ingredient = (Assortment)viewCell.BindingContext;
            if (ingredient.IsFavourite == false)
            {
                ingredient.IsFavourite = true;
                App.Database.SaveAssortment(ingredient);

                button.BackgroundColor = Color.Wheat;
                Favourite fav = new Favourite()
                {
                    IdAssortment = ingredient.Id,
                    IdUser = IdUser
                };
            }
            else
            {
                button.BackgroundColor = Color.FromRgb(223, 165, 232);
                ingredient.IsFavourite = false;
                App.Database.SaveAssortment(ingredient);
            }
        }

        private async void makaronsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Assortment selectedAssortment = (Assortment)e.SelectedItem;
            await Navigation.PushAsync(new SelectedMakaronsPage(selectedAssortment,IdUser,App.Database.GetCountAssortinBacket(IdUser)));
        }

        private async void backet_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BacketPage(IdUser));
        }


        //private void btnBacketCliked(object sender, EventArgs e)
        //{
        //    Backet bac;
        //    Button button = sender as Button;
        //    ViewCell viewCell = button.Parent.Parent.Parent.Parent as ViewCell;

        //    Assortment Assort = (Assortment)viewCell.BindingContext;
        //    if (App.Database.GetBacketUser(IdUser) == null)
        //    {
        //        bac = new Backet()
        //        {
        //            IdAssortment = Assort.Id,
        //            IdUser = IdUser,
        //            Description = Assort.Description,
        //            Name = Assort.Name,
        //            Price = Assort.Price,
        //            Unit = Assort.Unit,
        //            Mass = Assort.Mass,
        //            PhotoPath = Assort.PhotoPath,
        //            Count = 1,
        //            Summa = Assort.Price
        //        };
        //        App.Database.SaveBacket(bac);
        //    }
        //    else
        //    {
        //        if(App.Database.GetBacketId(IdUser, Assort.Id)!= null)
        //        {
        //            bac = App.Database.GetBacket((App.Database.GetBacketId(IdUser, Assort.Id)).Id);

        //            bac.Count = bac.Count + 1;
        //            bac.Summa = Assort.Price * bac.Count;
        //            App.Database.SaveBacket(bac);
        //        }
        //        else
        //        {
        //            bac = new Backet()
        //            {
        //                IdAssortment = Assort.Id,
        //                IdUser = IdUser,
        //                Description = Assort.Description,
        //                Name = Assort.Name,
        //                Price = Assort.Price,
        //                Unit = Assort.Unit,
        //                Mass = Assort.Mass,
        //                PhotoPath = Assort.PhotoPath,
        //                Count = 1,
        //                Summa = Assort.Price
        //            };
        //            App.Database.SaveBacket(bac);
        //        }

        //    }

        //    count.Text = App.Database.GetCountAssortinBacket(IdUser).ToString();

        //}
    }
}