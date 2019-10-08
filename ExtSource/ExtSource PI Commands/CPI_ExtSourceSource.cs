//==========================================================================
// CPI_ExtSourceSource.cs
//==========================================================================

namespace AwgTestFramework
{
    public partial class CPiExtSourceCmds
    {
        #region SOURce[n]:DAC:RESolution
        /// <summary>
        /// Sets the DAC resolution for the specified channel on the External Source
        /// 
        /// SOURce[n]::DAC:RESolution
        /// </summary>
        /// <param name="channel">channel to use as source</param>
        /// <param name="dacResolution">8 or 10 bit </param>
        public void SetExtSrcDacResolution(string channel, string dacResolution)
        {
            string commandLine = "SOURce" + channel + ":DAC:RESolution " + dacResolution;
            _mExtSourceVisaSession.Write(commandLine);
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
        public string GetExtSrcDacResolution(string channel)
        {
            string response;
            const string command = "SOURce[n]::DAC:RESolution?";
            _mExtSourceVisaSession.Query(command, out response);
            return response;
        }
        #endregion SOURce[n]:DAC:RESolution?

        #region SOURce[n]:FREQuency:CW
        /// <summary>
        /// Sets the sampling frequency value for the specified channel on the external source
        /// 
        /// SOURce[n]:FREQuency:CW
        /// </summary>
        /// <param name="channel">specified channel to use</param>
        /// <param name="freqValue">sampling frequency value</param>
        public void SetExtSrcFreq(string channel, string freqValue)
        {
            string commandLine = "SOURce" + channel + ":FREQuency:CW  " + freqValue;
            _mExtSourceVisaSession.Write(commandLine);
        }
        #endregion SOURce[n]:FREQuency:CW
        
        #region SOURce[n]:FUNCtion:USER
        /// <summary>
        /// Sets the waveform to waveform memory on the external source for specified channel
        /// 
        /// SOURce[n]:FUNCtion:USER
        /// </summary>
        /// <param name="filename">waveform filename</param>
        /// <param name="channel">channel to use as source</param>
        public void SetExtSrcFunctUser( string filename, string channel)
        {
            string commandLine = "SOURce" + channel + ":FUNCtion:USER " + '"' + filename + '"';
            _mExtSourceVisaSession.Write(commandLine);
        }
        #endregion SOURce[n]:FUNCtion:USER

        #region SOURce[n]:VOLTage:AMPLitude
        /// <summary>
        /// Sets the amplitude of the waveform associated with the channel on the external source
        /// 
        /// SOURce[n]:VOLTage:AMPLitude
        /// </summary>
        /// <param name="channel">specified channel to use</param>
        /// <param name="setValue">voltage amplitude value</param>
        public void SetExtSrcVoltAmpl( string channel, string setValue)
        {
            string commandLine = "SOURce" + channel + ":VOLTage:AMPLitude " + setValue;
            _mExtSourceVisaSession.Write(commandLine);
        }
        #endregion SOURce[n]:VOLTage:AMPLitude

        #region SOURce[n]:VOLTage:HIGH
        /// <summary>
        /// Sets the high voltage level of the waveform associated with the channel on the external source
        /// 
        /// SOURce[n]:VOLTage:HIGH
        /// </summary>
        /// <param name="channel">specified channel to use</param>
        /// <param name="setValue">voltage amplitude value</param>
        public void SetExtSrcVoltHigh( string channel, string setValue)
        {
            string commandLine = "SOURce" + channel + ":VOLTage:HIGH " + setValue;
            _mExtSourceVisaSession.Write(commandLine);
        }
        #endregion SOURce[n]:VOLTage:HIGH

        #region SOURce[n]:VOLTage:LOW
        /// <summary>
        /// Sets the low voltage level of the waveform associated with the channel on the external source
        /// 
        /// SOURce[n]:VOLTage:LOW
        /// </summary>
        /// <param name="channel">specified channel to use</param>
        /// <param name="setValue">voltage amplitude value</param>
        public void SetExtSrcVoltLow( string channel, string setValue)
        {
            string commandLine = "SOURce" + channel + ":VOLTage:LOW " + setValue;
            _mExtSourceVisaSession.Write(commandLine);
        }
        #endregion SOURce[n]:VOLTage:LOW

        #region SOURce[n]:WAVeform
        /// <summary>
        /// Sets the output waveform from the cuurrent waveform list on the external source for specified channel
        /// 
        /// SOURce[n]:WAVeform 
        /// </summary>
        /// <param name="waveform">waveform name</param>
        /// <param name="channel">channel to use as source</param>
        public void SetExtSrcWaveform(string waveform, string channel)
        {
            string commandLine = "SOURce" + channel + ":WAVeform " + '"' + waveform + '"';
            _mExtSourceVisaSession.Write(commandLine);
        }
        #endregion SOURce[n]:WAVeform
    }
}
