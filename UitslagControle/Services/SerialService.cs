using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.SerialCommunication;
using Windows.Devices.Enumeration;

namespace UitslagControle.Services
{
    class SerialService
    {
        private async Task InitAsync()
        {
            throw new NotImplementedException();

            var filter = SerialDevice.GetDeviceSelector("COM1");
            var devices = await DeviceInformation.FindAllAsync(filter);

            if (devices.Any())
            {
                var deviceId = devices.First().Id;

                SerialDevice device = await SerialDevice.FromIdAsync(deviceId);
                device.BaudRate = 9600;
                device.Parity = SerialParity.None;
                device.StopBits = SerialStopBitCount.One;
                device.DataBits = 8;
                device.Handshake = SerialHandshake.None;

            }
        }
    }
}
