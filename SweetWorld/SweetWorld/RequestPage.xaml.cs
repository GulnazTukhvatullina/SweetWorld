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
    public partial class RequestPage : ContentPage
    {
        public User User { get; set; }
        public IEnumerable<Backet> Backet { get; set; }
        public RequestPage(int idUser, IEnumerable<Backet> backet, string summa)
        {
            InitializeComponent();
            User = App.Database.GetUser(idUser);
            lblSumma.Text = summa;
            Backet = backet;
            this.BindingContext = this;
        }

        private void getRequest_Clicked(object sender, EventArgs e)
        {
            foreach (var i in Backet)
            {
                Request req = new Request()
                {
                    IdUser = User.Id,
                    Date = date.Date,
                    Email = Email.Text,
                    Phone = Convert.ToInt64(phoneNumber.Text),
                     IdAssortment = i.IdAssortment,
                     Name = i.Name,
                     Count = i.Count,
                     Summa = i.Summa

                };
                App.Database.SaveRequest(req);
                App.Database.DeleteBacket(i.Id);
            }
           
        }
    }
}