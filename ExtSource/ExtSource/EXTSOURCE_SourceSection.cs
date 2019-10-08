//==========================================================================
// EXTSOURCE_SourceSection.cs
//==========================================================================

namespace AwgTestFramework
{
    public partial class EXTSOURCE
    {
        /// <summary>
        /// Property to contain the External Source response from SOURce[n]::DAC:RESolution?
        /// </summary>
        public string ExtSrcDacResolution { get; set; }
        
        /// <summary>
        /// Sets the DAC resolution for the specified channel on the External Source
        /// 
        /// SOURce[n]::DAC:RESolution
        /// </summary>
        /// <param name="channel">channel to use as source</param>
        /// <param name="dacResolution">8 or 10 bit </param>
        public void SetExtSrcDacResolution(string channel, string dacResolution)
        {
            _piex.SetExtSrcDacResolution(channel, dacResolution);
        }

        /// <summary>
        /// Gets the DAC resolution for the specified channel on the External Source
        /// 
        /// SOURce[n]::DAC:RESolution?
        /// </summary>
        /// <param name="channel">channel to use as source</param>
        /// <returns>DAC resolution in bits</returns>
        public void GetExtSrcDacResolution(string channel)
        {
            ExtSrcDacResolution = _piex.GetExtSrcDacResolution(channel);
        }

        /// <summary>
        /// Sets the waveform to waveform memory on the external source for specified channel
        /// 
        /// SOURce[n]:FUNCtion:USER
        /// </summary>
        /// <param name="filename">waveform filename</param>
        /// <param name="channel">channel to use as source</param>
        public void SetExtSrcFunctUser(string filename, string channel)
        {
            _piex.SetExtSrcFunctUser(filename, channel);
        }

        /// <summary>
        /// Sets the output waveform from the cuurrent waveform list on the external source for specified channel
        /// 
        /// SOURce[n]:WAVeform 
        /// </summary>
        /// <param name="waveform">waveform name</param>
        /// <param name="channel">channel to use as source</param>
        public void SetExtSrcWaveform(string waveform, string channel)
        {
            _piex.SetExtSrcWaveform(waveform, channel);
        }

        /// <summary>
        /// Sets the sampling frequency value for the specified channel on the external source
        /// 
        /// SOURce[n]:FREQuency:CW
        /// </summary>
        /// <param name="channel">specified channel to use</param>
        /// <param name="freqValue">sampling frequency value</param>
        public void SetExtSrcFreq(string channel, string freqValue)
        {
            _piex.SetExtSrcFreq(channel, freqValue);
        }

        /// <summary>
        /// Sets the amplitude of the waveform associated with the channel on the external source
        /// 
        /// SOURce[n]:VOLTage:AMPLitude
        /// </summary>
        /// <param name="channel">specified channel to use</param>
        /// <param name="setValue">voltage amplitude value</param>
        public void SetExtSrcVoltAmpl(string channel, string setValue)
        {
            _piex.SetExtSrcVoltAmpl(channel, setValue);
        }

        /// <summary>
        /// Sets the high voltage level of the waveform associated with the channel on the external source
        /// 
        /// SOURce[n]:VOLTage:HIGH
        /// </summary>
        /// <param name="channel">specified channel to use</param>
        /// <param name="setValue">voltage amplitude value</param>
        public void SetExtSrcVoltHigh(string channel, string setValue)
        {
            _piex.SetExtSrcVoltHigh(channel, setValue);
        }
        
        /// <summary>
        /// Sets the low voltage level of the waveform associated with the channel on the external source
        /// 
        /// SOURce[n]:VOLTage:LOW
        /// </summary>
        /// <param name="channel">specified channel to use</param>
        /// <param name="setValue">voltage amplitude value</param>
        public void SetExtSrcVoltLow(string channel, string setValue)
        {
            _piex.SetExtSrcVoltLow(channel, setValue);
        }
    }
}
