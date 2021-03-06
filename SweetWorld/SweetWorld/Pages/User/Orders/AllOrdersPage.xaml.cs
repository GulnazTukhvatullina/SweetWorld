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
    public partial class AllOrdersPage : ContentPage
    {
        public AllOrdersPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            allOrdersList.ItemsSource = App.Database.GetReadyOrders();
            base.OnAppearing();
        }
    }
}