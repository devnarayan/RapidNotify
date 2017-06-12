
namespace RapidNotify.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            LoadApplication(new RapidNotify.App());
        }
    }
}