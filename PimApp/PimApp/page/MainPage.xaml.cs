using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace PimApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : Xamarin.Forms.TabbedPage
    {
        private bool swipeEnable = true;

        public MainPage()
        {
            InitializeComponent();
            NavigationPage navigationPage = new NavigationPage(new AnalisPage())
            {
                Title = Resource.Title1
            };

            InstructionPage instructionPage = new InstructionPage
            {
                Title = Resource.Title2
            };

            NavigationPage navigationPage2 = new NavigationPage(new HistoryPage())
            {
                Title = Resource.Title3
            };

            this.CurrentPageChanged += PageChanged;
            Children.Add(navigationPage);
            Children.Add(navigationPage2);
            Children.Add(instructionPage);
        }


        public void GetSwipe(bool option)
        {
            this.On<Xamarin.Forms.PlatformConfiguration.Android>().SetIsSwipePagingEnabled(option);
        }

        protected void PageChanged(object sender, EventArgs e)
        {
            if (CurrentPage is InstructionPage)
            {
                swipeEnable = false;
                GetSwipe(swipeEnable);
            }
            else if (swipeEnable != true)
            {
                swipeEnable = true;
                GetSwipe(swipeEnable);
            }
        }
    }
}