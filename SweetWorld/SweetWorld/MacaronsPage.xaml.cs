﻿using SweetWorld.SQLite;
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
        public MacaronsPage(int idUser)
        {
            InitializeComponent();
            IdUser = idUser;
            
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
    }
}