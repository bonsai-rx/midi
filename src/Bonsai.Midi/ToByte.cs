using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using Melanchall.DryWetMidi.Common;

namespace Bonsai.Midi
{
    /// <summary>
    /// Represents an operator that converts a sequence of 7 or 4-bit numbers to
    /// a sequence of 8-bit unsigned integer values.
    /// </summary>
    [Description("Converts a sequence of 7 or 4-bit numbers to a sequence of 8-bit unsigned integer values.")]
    public class ToByte : Transform<SevenBitNumber, byte>
    {
        /// <summary>
        /// Converts all 7-bit values in an observable sequence to 8-bit
        /// unsigned integers.
        /// </summary>
        /// <param name="source">A sequence of 7-bit number values.</param>
        /// <returns>A sequence of 8-bit unsigned integers.</returns>
        public override IObservable<byte> Process(IObservable<SevenBitNumber> source)
        {
            return source.Select(value => (byte)value);
        }

        /// <summary>
        /// Converts all 4-bit values in an observable sequence to 8-bit
        /// unsigned integers.
        /// </summary>
        /// <param name="source">A sequence of 4-bit number values.</param>
        /// <returns>A sequence of 8-bit unsigned integers.</returns>
        public IObservable<byte> Process(IObservable<FourBitNumber> source)
        {
            return source.Select(value => (byte)value);
        }
    }
}
