namespace Bonsai.Midi
{
    /// <summary>
    /// Represents the channel, control number, and control value of a MIDI
    /// control change event.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ControlChangeDataFrame"/> structure
    /// with the specified channel, control number, and control value.
    /// </remarks>
    /// <param name="channel">The MIDI channel on which the control change event was raised.</param>
    /// <param name="controlNumber">The number of the MIDI controller that changed value.</param>
    /// <param name="controlValue">The new value of the MIDI controller.</param>
    public readonly struct ControlChangeDataFrame(int channel, int controlNumber, int controlValue)
    {

        /// <summary>
        /// Gets the MIDI channel on which the control change event was raised.
        /// </summary>
        public int Channel { get; } = channel;

        /// <summary>
        /// Gets the number of the MIDI controller that changed value.
        /// </summary>
        public int ControlNumber { get; } = controlNumber;

        /// <summary>
        /// Gets the new value of the MIDI controller.
        /// </summary>
        public int ControlValue { get; } = controlValue;
    }
}
