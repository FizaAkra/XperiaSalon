using System;
using Xamarin.Forms.Xaml;
using XperiaApp.Services;
using XperiaApp.Views;
using XperiaApp.LoginSystem;
using SQLite;
using System.IO;
using Xamarin.Forms;
using Firebase.Storage;
using Firebase.Database;

namespace XperiaApp
{
    public partial class App : Application
    {
        public static string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "dbXperiaApp.db3");
       public static SQLiteConnection db = new SQLiteConnection(dbPath);

        public static FirebaseStorage FirebaseStorage =new FirebaseStorage("gs://xperiaapp-eaa01.appspot.com");
        public static FirebaseClient firebaseDatabase = new FirebaseClient("https://xperiaapp-eaa01-default-rtdb.firebaseio.com/");
        public App()
        {
            InitializeComponent();
            Device.SetFlags(new[] {"MediaElement_Experimental", "brush_Experimental" });

            DependencyService.Register<MockDataStore>();
            MainPage = new HomePage();
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
