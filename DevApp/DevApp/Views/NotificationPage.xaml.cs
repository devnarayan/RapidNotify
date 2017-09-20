using DevApp.Views;
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
    public partial class NotificationPage : ContentPage
    {
        public NotificationPage()
        {
            InitializeComponent();
            BindingContext = new NotificationPageViewModel();
        }

        private void btnNotification_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ItemsPage());
        }

        private void btnDisconect_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () => {
                var result = await this.DisplayAlert("Disconnect Device", "Would like to disconnect this device from notification? Your other connected device will not be affected.", "Yes", "No");
                if (result) await this.Navigation.PopAsync(); // or anything else
            });

        }
    }

    class NotificationPageViewModel : INotifyPropertyChanged
    {

        public NotificationPageViewModel()
        {
            IncreaseCountCommand = new Command(IncreaseCount);
        }

        int count;

        string countDisplay = "You clicked 0 times.";
        public string CountDisplay
        {
            get { return countDisplay; }
            set { countDisplay = value; OnPropertyChanged(); }
        }

        public ICommand IncreaseCountCommand { get; }

        void IncreaseCount() =>
            CountDisplay = $"You clicked {++count} times";


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
