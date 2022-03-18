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
    public partial class AlertUserPage : ContentPage
    {
        public int IdUser { get; set; }
        public AlertUserPage()
        {
            InitializeComponent();
            IdUser = Convert.ToInt32(App.Current.Properties["IdUser"]);
            if (App.Database.GetReadyOrderCount(IdUser) != 0)
            {
                readyOrderList.IsVisible = true;
                readyOrderList.ItemsSource = App.Database.GetReadyOrderId(IdUser);
            }
        }

        protected override void OnAppearing()
        {
            alertsList.ItemsSource = App.Database.GetAcceptedNoAcceptedRequestId(IdUser);
            //readyOrderList.ItemsSource = App.Database.GetReadyOrderId(IdUser);
            base.OnAppearing();
        }
    }
}