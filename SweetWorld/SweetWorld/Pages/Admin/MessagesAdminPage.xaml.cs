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
    public partial class MessagesAdminPage : ContentPage
    {
        public MessagesAdminPage()
        {
            InitializeComponent();
            var list = new List<IEnumerable<Request>>
            {
                App.Database.GetRequests(),
                App.Database.GetRequestsToday(),
                App.Database.GetRequestsWeek()
            };
            TheCarousel.ItemsSource = list;
            this.BindingContext = this;
        }

        private void TheCarousel_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {

        }

        //protected override void OnAppearing()
        //{
        //    messagesList.ItemsSource = App.Database.GetRequests();
        //    base.OnAppearing();
        //}

        //private void messagesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{

        //}
    }
}