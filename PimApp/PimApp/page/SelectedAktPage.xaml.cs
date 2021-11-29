using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PimApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedAktPage : ContentPage
    {
        public SelectedAktPage()
        {
            InitializeComponent();
            listview.ItemSelected += DeselectItem;
        }

        protected override void OnAppearing()
        {
            var akt = (Akt)BindingContext;
            List<string> list = ConvertToList(akt.Results);
            listview.HeightRequest = 250;
            listview.ItemsSource = list;
            if (float.Parse(akt.Qvadro_Average) < 0.5)
            {
                entry.BackgroundColor = Color.Green;

            }
            else
            {
                entry.BackgroundColor = Color.Red;
            }

            base.OnAppearing();
        }

        private async void Delete(object sender, EventArgs e)
        {
            bool result = await DisplayAlert(Resource.Proverka, Resource.Confirm, Resource.Yes, Resource.No);
            if (result)
            {
                var akt = (Akt)BindingContext;
                App.Database.Delete(akt.Id);
                await this.Navigation.PopAsync();
            }
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private List<string> ConvertToList(string data)
        {
            string[] x = data.Split(new char[] { ';' });
            List<string> y = new List<string>();
            int i = 0;
            while (i < x.Length)
            {
                y.Add(x[i]);
                i++;
            }
            return y;
        }

        private void DeselectItem(object sender, EventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

    }
}