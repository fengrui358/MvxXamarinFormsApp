using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvxXamarinFormsApp.Core.ViewModels;
using Plugin.DeviceInfo;

namespace MvxXamarinFormsApp.Core.Tests.DevicesInfoTests.ViewModels
{
    public class DevicesInfoTestViewModel : BaseViewModel
    {
        public string DeviceId { get; set; }

        public string GenerateAppId { get; set; }

        public string Model { get; set; }

        public string Version { get; set; }

        public string Platform { get; set; }

        public DevicesInfoTestViewModel()
        {
            DeviceId = CrossDeviceInfo.Current.Id;
            GenerateAppId = CrossDeviceInfo.Current.GenerateAppId(true, "prefix:", "-suffix");
            Model = CrossDeviceInfo.Current.Model;
            Version = CrossDeviceInfo.Current.Version;
            Platform = CrossDeviceInfo.Current.Platform.ToString();
        }
    }
}
