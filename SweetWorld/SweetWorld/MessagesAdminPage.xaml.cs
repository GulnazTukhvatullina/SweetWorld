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
    public partial class MessagesAdminPage : ContentPage
    {
        public MessagesAdminPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        protected override void OnAppearing()
        {
            messagesList.ItemsSource = App.Database.GetRequests();
            base.OnAppearing();
        }

        private void messagesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}