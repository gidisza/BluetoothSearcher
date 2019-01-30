using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BluetoothSearcher.Models
{
    public interface IBluetoothService
    {
        void StartScan();
        ObservableCollection<IDeviceDetails> FoundDevices { get; } 
        bool IsScanning { get; }
        List<IDeviceDetails> PairedDevices { get; }
        void Init();
    }
    public interface IDeviceDetails
    {
        string Name { get; }
        string MAC { get; }
    }
}
