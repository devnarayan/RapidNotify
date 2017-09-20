using RapidNotifyApp.Models;
using RapidNotifyApp.Services;
using RapidNotifyApp.ViewModels;
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

namespace RapidNotifyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThanksPage : ContentPage
    {
        public ThanksPage()
        {
            InitializeComponent();
            BindingContext = new ThanksPageViewModel();
        }

        private void btnHome_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new NotificationPage());
        }
    }

   
}
