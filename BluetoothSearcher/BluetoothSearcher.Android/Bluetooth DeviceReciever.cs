using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Bluetooth;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BluetoothSearcher.Models;

namespace BluetoothSearcher.Droid
{
    [BroadcastReceiver(Enabled = true, Exported = true)]
    public class BluetoothDeviceReciever : BroadcastReceiver
    {
        public delegate void DeviceFoundDelegate(IDeviceDetails device);
        public event DeviceFoundDelegate FoundDevice;


        public static BluetoothAdapter Adapter => BluetoothAdapter.DefaultAdapter;
        public bool ScanningStatus = false;


        public override void OnReceive(Context context, Intent intent)
        {
            var action = intent.Action;

            // Found a device
            switch (action)
            {
                case BluetoothDevice.ActionFound:
                    // Get the device
                    var device = (BluetoothDevice)intent.GetParcelableExtra(BluetoothDevice.ExtraDevice);

                    // Only update the adapter with items which are not bonded
                    if (device.BondState != Bond.Bonded)
                    {
                        FoundDevice?.Invoke(new DeviceInfo(device.Name, device.Address));
                    }
                    break;
                default:
                    break;
            }
        }
    }
}