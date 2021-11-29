using System.IO;
using Xamarin.Forms;

namespace PimApp
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "akts.db";
        public static Akt_Repository database;
        public static Akt_Repository Database
        {
            get
            {
                if (database is null)
                {
                    database = new Akt_Repository(
                        Path.Combine(
                            System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
