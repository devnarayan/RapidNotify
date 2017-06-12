
using RapidNotify.ViewModels;

using Xamarin.Forms;

namespace RapidNotify.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ItemDetailPage()
        {
            InitializeComponent();
        }

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        private async void btnRespond_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new RespondPage(new RespondPageViewModel()));
        }
    }
}
