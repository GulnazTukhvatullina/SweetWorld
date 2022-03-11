using SweetWorld.Services;
using SweetWorld.SQLite;
using SweetWorld.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("MaterialIcons-Regular.ttf", Alias = "Font")]
namespace SweetWorld
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "SweetWorld.db";
        public static TablesRepository database;
        public static TablesRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new TablesRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new AuthorizationPage());
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
