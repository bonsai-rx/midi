using System;
using System.Reactive;
using System.Reactive.Linq;
using Melanchall.DryWetMidi.Core;

namespace Bonsai.Midi
{
    static class ObservableExtensions
    {
        public static IObservable<TEvent> OfType<TEvent>(this IObservable<MidiEvent> source, MidiEventType eventType)
            where TEvent : MidiEvent
        {
            return Observable.Create<TEvent>(observer =>
            {
                var eventObserver = Observer.Create<MidiEvent>(
                    value =>
                    {
                        if (value.EventType == eventType)
                        {
                            observer.OnNext((TEvent)value);
                        }
                    },
                    observer.OnError,
                    observer.OnCompleted);
                return source.SubscribeSafe(eventObserver);
            });
        }
    }
}
