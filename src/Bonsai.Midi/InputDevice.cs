using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;
using System;
using System.ComponentModel;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace Bonsai.Midi
{
    /// <summary>
    /// Represents an operator that emits all MIDI events from an input device.
    /// </summary>
    [Description("Emits all MIDI events from an input device.")]
    public class InputDevice : Source<MidiEvent>
    {
        /// <summary>
        /// Gets or sets the index of the MIDI input device to connect to.
        /// </summary>
        public int? Index { get; set; }

        /// <summary>
        /// Generates an observable sequence of all MIDI events from the specified
        /// input device.
        /// </summary>
        /// <returns>A sequence of <see cref="MidiEvent"/> objects.</returns>
        public override IObservable<MidiEvent> Generate()
        {
            return Observable.Create<MidiEvent>(observer =>
            {
                var device = Melanchall.DryWetMidi.Multimedia.InputDevice.GetByIndex(Index.GetValueOrDefault());
                void EventReceivedHandler(object sender, MidiEventReceivedEventArgs e)
                {
                    observer.OnNext(e.Event);
                }
                device.EventReceived += EventReceivedHandler;
                device.StartEventsListening();
                return Disposable.Create(() =>
                {
                    device.StopEventsListening();
                    device.EventReceived -= EventReceivedHandler;
                    device.Dispose();
                });
            });
        }
    }
}
