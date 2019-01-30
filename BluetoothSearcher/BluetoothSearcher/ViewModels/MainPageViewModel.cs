using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluetoothSearcher.Models;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace BluetoothSearcher.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand<string> ShowDeviceNameAlert { get; set; }
        IBluetoothService bluetoothService;
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Xamarin.Forms.DependencyService.Register<IBluetoothService>();

            bluetoothService =   (DependencyService.Get<IBluetoothService>());
            bluetoothService.Init();


            ShowDeviceNameAlert = new DelegateCommand<string>(alertDeviceName);
            Title = "Main Page";
        }
        public ObservableCollection<IDeviceDetails> DevicesList { get { return bluetoothService.FoundDevices; } }

        private DelegateCommand _startSearchDevicesCommand;
        public DelegateCommand StartSearchDevicesCommand
        {
            get
            {
                if (_startSearchDevicesCommand == null)
                {
                    _startSearchDevicesCommand = new DelegateCommand(async () =>
                    {
                        bluetoothService.StartScan();
                    });
                }

                return _startSearchDevicesCommand;
            }
        }
        void alertDeviceName(string name)
        {

        }
    }
}
