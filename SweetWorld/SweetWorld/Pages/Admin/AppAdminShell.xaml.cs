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
    public partial class AppAdminShell : Shell
    {
        public AppAdminShell()
        {
            InitializeComponent();
        }

        private async void Assortment_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AssortmentPage());
            Shell.Current.FlyoutIsPresented = false;
        }

        private void exit_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new AuthorizationPage();
        }

        private async void messages_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MessagesAdminPage());
            Shell.Current.FlyoutIsPresented = false;
        }
    }
}