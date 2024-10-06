using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using Melanchall.DryWetMidi.Common;

namespace Bonsai.Midi
{
    /// <summary>
    /// Represents an operator that converts a sequence of 8-bit unsigned integer values
    /// to a sequence of 4-bit numbers.
    /// </summary>
    [Description("Converts a sequence of 8-bit unsigned integer values to a sequence of 4-bit numbers.")]
    public class ToFourBitNumber : Transform<byte, FourBitNumber>
    {
        /// <summary>
        /// Converts all 8-bit unsigned integer values in an observable sequence
        /// to 4-bit numbers.
        /// </summary>
        /// <param name="source">A sequence of 8-bit unsigned integer values.</param>
        /// <returns>A sequence of 4-bit numbers.</returns>
        public override IObservable<FourBitNumber> Process(IObservable<byte> source)
        {
            return source.Select(value => (FourBitNumber)value);
        }
    }
}
