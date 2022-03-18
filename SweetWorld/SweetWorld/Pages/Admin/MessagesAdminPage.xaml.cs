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
        public int IdUser { get; set; }
        public MessagesAdminPage()
        {
            InitializeComponent();
            IdUser = Convert.ToInt32(App.Current.Properties["IdUser"]);
            var list = new List<IEnumerable<Request>>
            {
                App.Database.GetRequests(),
                App.Database.GetRequestsToday(),
                App.Database.GetRequestsWeek()
            };
            TheCarousel.ItemsSource = list;
            this.BindingContext = this;
        }

        public void UpdateMessage()
        {
            var list = new List<IEnumerable<Request>>
            {
                App.Database.GetRequests(),
                App.Database.GetRequestsToday(),
                App.Database.GetRequestsWeek()
            };
            TheCarousel.ItemsSource = list;
        }

        private async void messagesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Request selectedRequest = (Request)e.SelectedItem;
            if (await DisplayAlert("Уведомление", $"Пользователь {selectedRequest.NameUser} хочет заказать {selectedRequest.NameAssortment} {selectedRequest.Date.ToString("dd.MM.yyyy")}. Он оставил вам номер телефона {selectedRequest.Phone}. Вы хотите принять заказ от {selectedRequest.NameUser}?", "Принять", "Отклонить"))
            {
                AcceptedNoAcceptedRequest accept = new AcceptedNoAcceptedRequest()
                {
                    Event = "приняли",
                    IdAssortment = selectedRequest.IdAssortment,
                     NameAssortment = selectedRequest.NameAssortment,
                     IdUser = selectedRequest.IdUser,
                     NameUser = selectedRequest.NameUser,
                     Phone = selectedRequest.Phone,
                     Date = selectedRequest.Date,
                     Email = selectedRequest.Email,
                     Count = selectedRequest.Count,
                     Summa = selectedRequest.Summa
                };
                App.Database.SaveAcceptedRequest(accept);
            }
            else
            {
                AcceptedNoAcceptedRequest accept = new AcceptedNoAcceptedRequest()
                {
                    Event = "отклонили",
                    IdAssortment = selectedRequest.IdAssortment,
                    NameAssortment = selectedRequest.NameAssortment,
                    IdUser = selectedRequest.IdUser,
                    NameUser = selectedRequest.NameUser,
                    Phone = selectedRequest.Phone,
                    Date = selectedRequest.Date,
                    Email = selectedRequest.Email,
                    Count = selectedRequest.Count,
                    Summa = selectedRequest.Summa
                };
                App.Database.SaveAcceptedRequest(accept);
            }
            
            App.Database.DeleteRequest(selectedRequest.Id);
            UpdateMessage();
        }
    }
}