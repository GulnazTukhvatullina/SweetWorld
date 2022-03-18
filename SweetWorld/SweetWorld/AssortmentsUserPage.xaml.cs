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
    public partial class AssortmentsUserPage : TabbedPage
    {
        public int IdUser { get; set; }
        public int count { get; set; }
        public AssortmentsUserPage()
        {
            InitializeComponent();
            IdUser = Convert.ToInt32(App.Current.Properties["IdUser"]);
            if (App.Database.GetCountAssortinBacket(IdUser) != 0)
            {
                count = App.Database.GetCountAssortinBacket(IdUser);
            }
            this.BindingContext = this;
        }

        private async void backet_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BacketPage(IdUser));
        }
    }
}