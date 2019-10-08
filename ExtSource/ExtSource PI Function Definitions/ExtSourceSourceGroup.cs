//==========================================================================
// ExtSourceSourceGroup.cs
//==========================================================================

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains helper functions that are called from the External Source Source PI step definitions
    /// 
    /// </summary>
    public class ExtSourceSourceGroup
    {
        #region SOURce[n]:DAC:RESolution
        /// <summary>
        /// Sets the DAC resolution for the specified channel on the External Source
        /// 
        /// SOURce[n]::DAC:RESolution
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <param name="channel">channel to use as source</param>
        /// <param name="dacResolution">8 or 10 bit </param>
        public void SetExtSrcDacResolution(IEXTSOURCE extSource, string channel, string dacResolution)
        {
            extSource.SetExtSrcDacResolution(channel, dacResolution);
        }
        #endregion SOURce[n]:DAC:RESolution

        #region SOURce[n]:DAC:RESolution?
        /// <summary>
        /// Gets the DAC resolution for the specified channel on the External Source
        /// 
        /// SOURce[n]::DAC:RESolution?
        /// </summary>
        /// <param name="channel">channel to use as source</param>
        /// <returns>DAC resolution in bits</returns>
        public void GetExtSrcDacResolution(IEXTSOURCE extSource, string channel)
        {
            extSource.GetExtSrcDacResolution(channel);
        }
        #endregion SOURce[n]:DAC:RESolution?
        
        #region SOURce[n]:FREQuency:CW
        /// <summary>
        /// Sets the sampling frequency value for the specified channel on the external source
        /// 
        /// SOURce[n]:FREQuency:CW
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <param name="channel">specified channel to use</param>
        /// <param name="freqValue">sampling frequency value</param>
        public void SetExtSrcFreq(IEXTSOURCE extSource, string channel, string freqValue)
        {
            extSource.SetExtSrcFreq(channel, freqValue);
        }
        #endregion SOURce[n]:FREQuency:CW

        #region SOURce[n]:FUNCtion:USER
        /// <summary>
        /// Sets the waveform to waveform memory on the external source for specified channel
        /// 
        /// SOURce[n]:FUNCtion:USER
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <param name="filename">waveform filename</param>
        /// <param name="channel">channel to use as source</param>
        public void SetExtSrcFunctUser(IEXTSOURCE extSource, string filename, string channel)
        {
            extSource.SetExtSrcFunctUser(filename, channel);
        }
        #endregion SOURce[n]:FUNCtion:USER

        #region SOURce[n]:VOLTage:AMPLitude
        /// <summary>
        /// Sets the amplitude of the waveform associated with the channel on the external source
        /// 
        /// SOURce[n]:VOLTage:AMPLitude
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <param name="channel">specified channel to use</param>
        /// <param name="setValue">voltage amplitude value</param>
        public void SetExtSrcVoltAmpl(IEXTSOURCE extSource, string channel, string setValue)
        {
            extSource.SetExtSrcVoltAmpl(channel, setValue);
        }
        #endregion SOURce[n]:VOLTage:AMPLitude

        #region SOURce[n]:VOLTage:HIGH
        /// <summary>
        /// Sets the high voltage level of the waveform associated with the channel on the external source
        /// 
        /// SOURce[n]:VOLTage:HIGH
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <param name="channel">specified channel to use</param>
        /// <param name="setValue">voltage amplitude value</param>
        public void SetExtSrcVoltHigh(IEXTSOURCE extSource, string channel, string setValue)
        {
            extSource.SetExtSrcVoltHigh(channel, setValue);
        }
        #endregion SOURce[n]:VOLTage:HIGH

        #region SOURce[n]:VOLTage:LOW
        /// <summary>
        /// Sets the low voltage level of the waveform associated with the channel on the external source
        /// 
        /// SOURce[n]:VOLTage:LOW
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <param name="channel">specified channel to use</param>
        /// <param name="setValue">voltage amplitude value</param>
        public void SetExtSrcVoltLow(IEXTSOURCE extSource, string channel, string setValue)
        {
            extSource.SetExtSrcVoltLow(channel, setValue);
        }
        #endregion SOURce[n]:VOLTage:LOW

        #region SOURce[n]:WAVeform
        /// <summary>
        /// Sets the output waveform from the cuurrent waveform list on the external source for specified channel
        /// 
        /// SOURce[n]:WAVeform 
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <param name="waveform">waveform name</param>
        /// <param name="channel">channel to use as source</param>
        public void SetExtSrcWaveform(IEXTSOURCE extSource, string waveform, string channel)
        {
            extSource.SetExtSrcWaveform(waveform, channel);
        }
        #endregion SOURce[n]:WAVeform
    }
}
