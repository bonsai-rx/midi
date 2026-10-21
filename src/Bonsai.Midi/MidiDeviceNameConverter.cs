using System;
using System.ComponentModel;
using MM = Melanchall.DryWetMidi.Multimedia;

namespace Bonsai.Midi
{
    class MidiDeviceNameConverter : TypeConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            try
            {
                return new StandardValuesCollection(MidiDeviceHelper.GetDeviceNames());
            }
            catch (Exception)
            {
                return new StandardValuesCollection(Array.Empty<string>());
            }
        }
    }
}
