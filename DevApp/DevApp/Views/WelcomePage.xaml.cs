using DevApp;
using RapidNotify.Models;
using RapidNotify.Services;
using RapidNotify.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RapidNotify.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
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
                await Navigation.PushAsync(new ThanksPage());

                //var response = JsonConvert.DeserializeObject<ResponseModel>(message);
                //if (response.Message == "Device Added Successfully.")
                //{
                //    await Navigation.PushAsync(new ThanksPage());
                //}
                //else
                //{
                //    lblMessage.Text = response.Message;
                //}
            }
        }
    }
}
