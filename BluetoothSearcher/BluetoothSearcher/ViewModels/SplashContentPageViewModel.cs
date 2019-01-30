using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BluetoothSearcher.ViewModels
{
    public class SplashContentPageViewModel : ViewModelBase
    {
        public string LogoImage => "logo.png";

        public string ImageSource { get; set; }
        public DelegateCommand GoHomeCommand { get; set; }
        public SplashContentPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            GoHomeCommand = new DelegateCommand(NavigateToHomeAction);
            ImageSource = "logo.png";
        }
        
        private async void NavigateToHomeAction()
        {
            await this.NavigationService.NavigateAsync("MainPage");

        }

    }
}
