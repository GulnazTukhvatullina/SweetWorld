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
    public partial class TypeAssortmentUserPage : ContentPage
    {
        public int IdUser { get; set; }
        public TypeAssortmentUserPage(int idUser)
        {
            InitializeComponent();
            IdUser = idUser;
            this.BindingContext = this;
        }

        private void Macaron_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MacaronsPage(IdUser));
        }
        private void Cake_Clicked(object sender, EventArgs e)
        {

        }
        private void Pirozh_Clicked(object sender, EventArgs e)
        {

        }
    }
}