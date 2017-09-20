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
    public partial class RespondPage : ContentPage
    {
        public RespondPage(RespondPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = new RespondPageViewModel();
        }
    }
}