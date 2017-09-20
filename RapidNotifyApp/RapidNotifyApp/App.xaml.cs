using RapidNotifyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace RapidNotifyApp
{
    public partial class App : Application
    {
        public static string DeviceToken;
        public static TokenType DeviceType;
        public App()
        {
            InitializeComponent();

            MainPage = new RapidNotifyApp.MainPage();
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
