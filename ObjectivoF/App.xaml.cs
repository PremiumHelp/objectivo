using Xamarin.Forms;

namespace ObjectivoF
{
    public partial class App : Application
    {
		public static string UserId = "";
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDI5MjBAMzEzNjJlMzMyZTMwTU1FNjB4N1UxNTFLRjhEOFQvbzAvMnB0NVlGS0NVRThGWUlraFRXWEtOOD0=");
            InitializeComponent();

            MainPage = new NavigationPage(new StartPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
