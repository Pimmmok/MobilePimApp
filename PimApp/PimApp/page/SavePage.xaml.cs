using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PimApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SavePage : ContentPage
    {
        public SavePage()
        {
            InitializeComponent();
        }

        private void Save(object sender, EventArgs e)
        {
            var akt = (Akt)BindingContext;
            if (string.IsNullOrEmpty(akt.Name_Org) || string.IsNullOrEmpty(akt.Model_Counter) || string.IsNullOrEmpty(akt.Number_Counter) || string.IsNullOrEmpty(akt.Energy_Values))
            {
                DisplayAlert(Resource.DisplayAlertHeader, Resource.NonValue, "ОK");
                return;
            }

            App.Database.Save(akt);
            DisplayAlert(Resource.DisplayAlertHeader, Resource.SaveOk, "ОK");
            this.Navigation.PopAsync();
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}