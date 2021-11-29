using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PimApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InstructionPage : ContentPage
    {
        public InstructionPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}