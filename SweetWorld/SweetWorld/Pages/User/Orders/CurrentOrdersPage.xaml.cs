﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SweetWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrentOrdersPage : ContentPage
    {
        public CurrentOrdersPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            currentOrdersList.ItemsSource = App.Database.GetAcceptedRequests();
            base.OnAppearing();
        }
    }
}