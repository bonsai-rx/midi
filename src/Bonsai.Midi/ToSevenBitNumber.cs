using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using Melanchall.DryWetMidi.Common;

namespace Bonsai.Midi
{
    /// <summary>
    /// Represents an operator that converts a sequence of 8-bit unsigned integer values
    /// to a sequence of 7-bit numbers.
    /// </summary>
    [Description("Converts a sequence of 8-bit unsigned integer values to a sequence of 7-bit numbers.")]
    public class ToSevenBitNumber : Transform<byte, SevenBitNumber>
    {
        /// <summary>
        /// Converts all 8-bit unsigned integer values in an observable sequence
        /// to 7-bit numbers.
        /// </summary>
        /// <param name="source">A sequence of 8-bit unsigned integer values.</param>
        /// <returns>A sequence of 7-bit numbers.</returns>
        public override IObservable<SevenBitNumber> Process(IObservable<byte> source)
        {
            return source.Select(value => (SevenBitNumber)value);
        }
    }
}
