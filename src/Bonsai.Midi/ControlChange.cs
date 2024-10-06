using System;
using System.ComponentModel;
using Melanchall.DryWetMidi.Core;

namespace Bonsai.Midi
{
    /// <summary>
    /// Represents an operator that filters the MIDI event sequence for control change events.
    /// </summary>
    [Description("Filters the MIDI event sequence for control change events.")]
    public class ControlChange : Combinator<MidiEvent, ControlChangeEvent>
    {
        /// <summary>
        /// Filters an observable sequence of MIDI events and emits a notification only
        /// when a new MIDI control change event is raised.
        /// </summary>
        /// <param name="source">A sequence of <see cref="MidiEvent"/> messages.</param>
        /// <returns>
        /// A sequence of <see cref="ControlChangeEvent"/> messages.
        /// </returns>
        public override IObservable<ControlChangeEvent> Process(IObservable<MidiEvent> source)
        {
            return source.OfType<ControlChangeEvent>(MidiEventType.ControlChange);
        }
    }
}
