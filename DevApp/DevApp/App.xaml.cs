using DevApp.Views;
using RapidNotify.Models;
using RapidNotify.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DevApp
{
	public partial class App : Application
	{
        public static string DeviceToken;
        public static TokenType DeviceType;
        public App()
		{
			InitializeComponent();

			SetMainPage();
		}

		public static void SetMainPage()
		{
            Current.MainPage = new NavigationPage(new WelcomePage());
        }
	}
}
