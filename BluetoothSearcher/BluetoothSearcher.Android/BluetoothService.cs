using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Android.Bluetooth;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BluetoothSearcher.Models;
using Xamarin.Forms;
using BluetoothSearcher.Droid;
using System.Threading.Tasks;
using Android.Support.V4.Content;

[assembly: Dependency(typeof(BluetoothService))]
namespace BluetoothSearcher.Droid
{
    class DeviceInfo : IDeviceDetails
    {
        private string _name = "";
        private string _mac = "";

        public DeviceInfo(string name, string Mac)
        {
            _name = name;
            _mac = Mac;
        }
        public string Name { get { return _name; } }
        public string MAC { get { return _mac; } }

    }
   
    class BluetoothService :Service, IBluetoothService
    {
        #region Private Members
        ObservableCollection<IDeviceDetails> foundDevices = new ObservableCollection<IDeviceDetails>();
        private List<IDeviceDetails> pairedDevices = new List<IDeviceDetails>();
       
        private BluetoothDeviceReciever reciever;
        #endregion

        #region Properties
        public bool IsScanning => throw new NotImplementedException();

        public ObservableCollection<IDeviceDetails> FoundDevices { get => foundDevices; set => foundDevices = value; }
        #endregion
        public List<IDeviceDetails> PairedDevices
        {
            get
            {
                if (BluetoothAdapter.DefaultAdapter != null && BluetoothAdapter.DefaultAdapter.IsEnabled)
                {
                    foreach (var pairedDevice in BluetoothAdapter.DefaultAdapter.BondedDevices)
                    {
                        pairedDevices.Add(new DeviceInfo(pairedDevice.Name, pairedDevice.Address));

                    }
                }
                return pairedDevices;
            }
        }

        public BluetoothService() :
            base()
        {
            foundDevices.Add(new DeviceInfo("Example Name", "Example MAC"));
            reciever = new BluetoothDeviceReciever();
            reciever.FoundDevice += Reciever_FoundDevice;
            var mainActivity = MainActivity.GetInstance();
            mainActivity.RegisterReceiver(reciever, new IntentFilter(BluetoothDevice.ActionFound));
        }

        private void Reciever_FoundDevice(IDeviceDetails device)
        {
            if(!foundDevices.Any(item => item.Name == device.Name))
            {
                foundDevices.Add(device);
            }

        }

        public void StartScan()
        {
            if (!BluetoothAdapter.DefaultAdapter.IsDiscovering) BluetoothAdapter.DefaultAdapter.StartDiscovery();
        }
        public void StopScan()
        {
            BluetoothAdapter.DefaultAdapter.CancelDiscovery();
        }

        public void Init()
        { 
           
        }

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
    }
}