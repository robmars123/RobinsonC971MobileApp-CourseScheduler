using RobinsonC971MobileApp.Services;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RobinsonC971MobileApp
{
    public partial class App : Application
    {
        private static Service db;
        public static Service AppDB
        {
            get
            {
                if (db == null)
                {
                    db = new Service(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "MyDB.db3"));
                }
                return db;
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
