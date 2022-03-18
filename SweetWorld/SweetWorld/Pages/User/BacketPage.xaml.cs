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
    public partial class BacketPage : ContentPage
    {
        public int IdUser { get; set; }
        public int Count { get; set; }
        public BacketPage(int idUser)
        {
            InitializeComponent();
            IdUser = idUser;
            Count = App.Database.GetCountAssortinBacket(IdUser);
            count.Text = Count.ToString();
            lblSumma.Text = App.Database.GetBacketSum(IdUser).ToString();
            this.BindingContext = this;
        }

        protected override void OnAppearing()
        {
            backetsList.ItemsSource = App.Database.GetBacketsUser(IdUser);
            base.OnAppearing();
        }

        private void btnPlus_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            ViewCell viewCell = button.Parent.Parent.Parent as ViewCell;

            Backet bac = (Backet)viewCell.BindingContext;
            bac.Count = bac.Count + 1;
            bac.Summa = bac.Price * bac.Count;
            App.Database.SaveBacket(bac);
            Count++;
            UpdateList();
        }

        private void btnMinus_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            ViewCell viewCell = button.Parent.Parent.Parent as ViewCell;

            Backet bac = (Backet)viewCell.BindingContext;
           
            if (bac.Count == 1)
            {
                App.Database.DeleteBacket(bac.Id);
            }
            else
            {
                bac.Count = bac.Count - 1;
                bac.Summa = bac.Price * bac.Count;
                App.Database.SaveBacket(bac);
            }
            Count--;
            UpdateList();
        }

        private async void getRequest_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RequestPage(IdUser, App.Database.GetBacketsUser(IdUser), lblSumma.Text));
        }

        public void UpdateList()
        {
            count.Text = Count.ToString();
            backetsList.ItemsSource = App.Database.GetBacketsUser(IdUser);
            lblSumma.Text = App.Database.GetBacketSum(IdUser).ToString();
        }
    }
}