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
    public partial class ReadyOrdersAdminPage : ContentPage
    {
        public ReadyOrdersAdminPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            readyOrdersList.ItemsSource = App.Database.GetRequest();
            base.OnAppearing();
        }

        private void btnReady_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            ViewCell viewCell = button.Parent.Parent.Parent as ViewCell;

            AcceptedNoAcceptedRequest acceptedRequest = (AcceptedNoAcceptedRequest)viewCell.BindingContext;
            ReadyOrder readyOrder = new ReadyOrder() { 
                IdAssortment = acceptedRequest.IdAssortment,
                NameAssortment = acceptedRequest.NameAssortment,
                IdUser = acceptedRequest.IdUser,
                NameUser = acceptedRequest.NameUser,
                Phone = acceptedRequest.Phone,
                Email = acceptedRequest.Email,
                Date = acceptedRequest.Date,
                Count = acceptedRequest.Count,
                Summa = acceptedRequest.Summa
            };
            App.Database.DeleteAcceptedRequest(acceptedRequest.Id);
            App.Database.SaveReadyOrder(readyOrder);
            readyOrdersList.ItemsSource = App.Database.GetRequest();
        }
    }
}