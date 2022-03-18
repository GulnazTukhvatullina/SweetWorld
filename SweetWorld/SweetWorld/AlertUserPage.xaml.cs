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
        }

        protected override void OnAppearing()
        {
            alertsList.ItemsSource = App.Database.GetAcceptedNoAcceptedRequestId(IdUser);
            base.OnAppearing();
        }
    }
}