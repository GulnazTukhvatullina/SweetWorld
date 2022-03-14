using SweetWorld.SQLite;
using SweetWorld.ViewModels;
using SweetWorld.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SweetWorld
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public User Iuser { get; set; }
        public AppShell(User user)
        {
            InitializeComponent();
            Iuser = user;
            this.BindingContext = this;
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

        private void exit_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new AuthorizationPage();
        }

        private async void Assortment_Clicked(object sender, EventArgs e)
        {
            var ProjectsPage = new TypeAssortmentUserPage(Iuser.Id);
            NavigationPage.SetHasBackButton(ProjectsPage, false);
            await Navigation.PushAsync(new TypeAssortmentUserPage(Iuser.Id));
            Shell.Current.FlyoutIsPresented = false;
        }

        private async void Favourite_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FavouritePage(Iuser.Id));
            Shell.Current.FlyoutIsPresented = false;
        }
    }
}
