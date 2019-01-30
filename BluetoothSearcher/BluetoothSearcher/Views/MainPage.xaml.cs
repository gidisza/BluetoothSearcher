using BluetoothSearcher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BluetoothSearcher.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private async void ViewCell_Tapped(object sender, EventArgs e)
        {
            
            await DisplayAlert("Device Name:",((IDeviceDetails)((ViewCell)sender).BindingContext).Name,"OK");
          
        }
    }
}