using System;
using System.ComponentModel;
using System.Reactive.Linq;
using Melanchall.DryWetMidi.Core;

namespace Bonsai.Midi
{
    /// <summary>
    /// Represents an operator that filters the MIDI event sequence for control change
    /// events and extracts the channel, control number, and control value of each event.
    /// </summary>
    [Description("Filters the MIDI event sequence for control change events and extracts the channel, control number, and control value of each event.")]
    public class ControlChange : Combinator<MidiEvent, ControlChangeDataFrame>
    {
        /// <summary>
        /// Filters an observable sequence of MIDI events and emits a notification with
        /// the channel, control number, and control value of each control change event.
        /// </summary>
        /// <param name="source">A sequence of <see cref="MidiEvent"/> messages.</param>
        /// <returns>
        /// A sequence of <see cref="ControlChangeDataFrame"/> values.
        /// </returns>
        public override IObservable<ControlChangeDataFrame> Process(IObservable<MidiEvent> source)
        {
            return source.OfType<ControlChangeEvent>(MidiEventType.ControlChange)
                .Select(inputEvent => new ControlChangeDataFrame(
                    inputEvent.Channel,
                    inputEvent.ControlNumber,
                    inputEvent.ControlValue
                ));
        }
    }
}
