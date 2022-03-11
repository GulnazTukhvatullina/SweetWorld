using SweetWorld.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SweetWorld.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}