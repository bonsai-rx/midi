using System;
using System.Linq;
using MM = Melanchall.DryWetMidi.Multimedia;

namespace Bonsai.Midi
{
    static class MidiDeviceHelper
    {
        public static string[] GetDeviceNames()
        {
            var devices = MM.InputDevice.GetAll();
            return [..devices.Select(device => device.Name)];
        }

        public static MM.InputDevice GetDevice(string deviceName)
        {
            if (string.IsNullOrEmpty(deviceName))
            {
                var device = MM.InputDevice.GetAll().FirstOrDefault();
                return device ?? throw new InvalidOperationException("No MIDI input device is available.");
            }

            return MM.InputDevice.GetByName(deviceName);
        }
    }
}
