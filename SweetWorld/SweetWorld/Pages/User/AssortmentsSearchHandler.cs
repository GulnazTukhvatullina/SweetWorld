using SweetWorld.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace SweetWorld
{
    public class AssortmentsSearchHandler : SearchHandler
    {
        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                ItemsSource = App.Database.GetAssortments().Where(assort => assort.Name.ToLower().Contains(newValue.ToLower()));
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);
            var assort = item as Assortment;
            if (assort is null) return;
            await App.Current.MainPage.Navigation.PushAsync(new SelectedMakaronsPage(assort, Convert.ToInt32(App.Current.Properties["IdUser"])));
        }
    }
}
