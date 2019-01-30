using System.Threading.Tasks;
using Xamarin.Forms;
using BluetoothSearcher.ViewModels;
namespace BluetoothSearcher.Views
{
    public partial class SplashContentPage : ContentPage
    {
        

    
        SplashContentPageViewModel pageViewModel; 
        public SplashContentPage()
        {
            

            
            NavigationPage.SetHasNavigationBar(this, false);
            
            InitializeComponent();
            //AbsoluteLayout.SetLayoutFlags(LogoImg, AbsoluteLayoutFlags.PositionProportional);
            //AbsoluteLayout.SetLayoutBounds(LogoImg, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            pageViewModel = (SplashContentPageViewModel)this.BindingContext;

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LogoImg.RotateTo(360, 3000, Easing.SinInOut);
            if (this.pageViewModel.GoHomeCommand.CanExecute())
            {
                this.pageViewModel.GoHomeCommand.Execute();
            }
            
        }
    }
}
