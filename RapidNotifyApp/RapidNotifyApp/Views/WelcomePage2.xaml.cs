using RapidNotifyApp.Models;
using RapidNotifyApp.Services;
using RapidNotifyApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RapidNotifyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage2 : ContentPage
    {
        public WelcomePage2()
        {
            InitializeComponent();
            BindingContext = new WelcomeViewModel();
        }
        private async void btnRegister_Clicked(object sender, EventArgs e)
        {
            WelcomeService service = new WelcomeService();
            RegisterModel model = new RegisterModel();
            model.CustomerEmail = txtEmail.Text;
            model.DeviceToken = App.DeviceToken;  // Device token collected from android, iOS and Windows
            model.DeviceType = (int)App.DeviceType;
            string message = await service.WelcomeConnect(model);
            if (message != null)
            {
                //var response = JsonConvert.DeserializeObject<ResponseModel>(message);
                //if (response.Message == "Device Added Successfully.")
                //{
                 await Navigation.PushAsync(new ThankYouPage());
                //}
                //else
                //{
                //    lblMessage.Text = response.Message;
                //}
            }
        }
    }
}