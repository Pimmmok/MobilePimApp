using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using System.Linq;

namespace PimApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        private List<Akt> akts;

        public HistoryPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            akts = App.Database.GetList();
            akts.Reverse();
            aktList.ItemsSource = akts;
            MainSearchBar.Text = String.Empty;
            base.OnAppearing();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Akt selectedAkt = (Akt)e.SelectedItem;
            SelectedAktPage aktPage = new SelectedAktPage
            {
                BindingContext = selectedAkt
            };
            await Navigation.PushAsync(aktPage);
        }

        void OnBtnPressed(object sender, EventArgs e)
        {
            var keyword = MainSearchBar.Text.ToLower();
            aktList.ItemsSource = akts.Where(akt => akt.Name_Org.ToLower().Contains(keyword) || akt.Number_Counter.ToLower().Contains(keyword) || akt.Date_Akt.ToLower().Contains(keyword));
        }
    }
}