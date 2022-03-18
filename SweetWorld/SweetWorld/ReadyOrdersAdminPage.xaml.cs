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

        private void btnReady_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            ViewCell viewCell = button.Parent.Parent.Parent as ViewCell;

            AcceptedNoAcceptedRequest acceptedRequest = (AcceptedNoAcceptedRequest)viewCell.BindingContext;
            acceptedRequest.Event = "готов";
            App.Database.SaveAcceptedRequest(acceptedRequest);
        }
    }
}