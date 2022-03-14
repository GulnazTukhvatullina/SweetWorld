using SweetWorld.SQLite;
using System;
using System.Collections.Generic;
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
                ItemsSource = App.Database.GetAssortments();
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);
            var pet = item as Assortment;
            if (pet is null) return;
            await App.Current.MainPage.DisplayAlert("Вы выбрали", pet.Name, "ok");
        }
    }
}
