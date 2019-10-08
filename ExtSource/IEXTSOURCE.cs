

// ReSharper disable CheckNamespace
namespace AwgTestFramework
// ReSharper restore CheckNamespace
{
    public interface IEXTSOURCE
    {
        /// <summary>
        /// Property to contain the External Source response from *ESR?
        /// </summary>
        string ExtSrcESR { get; set; }

        /// <summary>
        /// Property to contain the External Source response from *IDN?
        /// </summary>
        string ExtSrcIDResponse { get; set; }

        /// <summary>
        /// Property to contain the External Source response from *OPC?
        /// </summary>
        string ExtSrcOPC { get; set; }

        /// <summary>
        /// Property to contain the External Source response from *OPT?
        /// </summary>
        string ExtSrcOptions { get; set; }

        /// <summary>
        /// Property to contain the External Source response from ALLEv?
        /// </summary>
        string ExtSrcAllEvents { get; set; }
        
        /// <summary>
        /// Property to contain the External Source response from AWGControl:RMODe?
        /// </summary>
        string ExtSrcRunMode { get; set; }

        /// <summary>
        /// Property to contain the External Source response from AWGControl:RRATe?
        /// </summary>
        string ExtSrcRepRate { get; set; }

        /// <summary>
        /// Property to contain the External Source response from AWGControl:SNAMe?
        /// </summary>
        string ExtSrcSetupNam { get; set; }

        /// <summary>
        /// Property to contain the External Source response from EVENT?
        /// </summary>
        string ExtSrcEvent { get; set; }

        /// <summary>
        /// Property to contain the External Source response from EVMsg?
        /// </summary>
        string ExtSrcEventMessage { get; set; }

        /// <summary>
        /// Property to contain the External Source response from SOURce[n]::DAC:RESolution?
        /// </summary>
        string ExtSrcDacResolution { get; set; }

        /// <summary>
        /// Property to contain the External Source response from SYSTem:ERRor?
        /// </summary>
        string ExtSrcSystemError { get; set; }

        /// <summary>
        /// Property to contain the External Source response from WLISt:SIZE?
        /// </summary>
        string ExtSrcWfmListSize { get; set; }

        /// <summary>
        /// Clears error queue of the external source
        /// 
        /// *CLS
        /// </summary>
        void ExtSrcCLS();

        /// <summary>
        /// Gets Standard Event Status Register
        /// basically means clearing it
        /// 
        /// *ESR?
        /// </summary>
        /// <returns>event status of the external source</returns>
        void GetExtSrcESRQuery();

        /// <summary>
        /// Gets the id of the external source
        /// 
        /// *IDN?
        /// </summary>
        /// <returns>Id of the external source</returns>
        void GetExtSrcIDNQuery();

        /// <summary>
        /// Resets the external source
        /// 
        /// *RST
        /// </summary>
        void ExtSrcRst();

        /// <summary>
        /// Waits for the external source to complete
        /// 
        /// *OPC?
        /// </summary>
        /// <param name="timeout">How long to wait for the OPC to return</param>
        /// <returns>OPC result</returns>
        void GetExtSrcOPCQuery(uint timeout = 15000);

        /// <summary>
        /// Gets the options that are enabled on the external source
        /// 
        /// *OPT?
        /// </summary>
        /// <returns>Options enabled on the ext source</returns>
        void GetExtSrcOptQuery();

        /// <summary>
        /// Gets all the events on the external source
        /// 
        /// ALLEv?
        /// </summary>
        /// <returns>Id of the external source</returns>
        void GetExtSrcALLEvQuery();
        
        /// <summary>
        /// Enables or disables the interleave states for channels on the external source
        /// 
        /// use AWGControl:INTerleave:STATE
        /// </summary>
        /// <param name="state">interleave state ON|OFF</param>
        void SetExtSrcInterLeaveState(string state);

        /// <summary>
        /// Sets or removes the zeroing option for interleave mode on the external source
        /// 
        /// AWGControl:INTerleave:ZERoing
        /// </summary>
        /// <param name="state">sets state for interleaving mode zeroing option</param>
        /// <returns>System error code and message</returns>
        void SetExtSrcInterLeaveZeroing(string state);

        /// <summary>
        /// Sets the run mode for the external source
        /// 
        /// AWGControl:RMODe 
        /// </summary>
        /// <param name="mode">run mode setting</param>
        void SetExtSrcRunMode(string mode);

        /// <summary>
        /// Gets the run mode status from the external source
        /// 
        /// AWGControl:RMODe?
        /// </summary>
        /// <returns>run mode status</returns>
        void GetExtSrcRunModeQuery();

        /// <summary>
        /// Sets the repeat rate the external source
        /// 
        /// AWGControl:RRATe
        /// </summary>
        /// <param name="setValue">repeat rate value</param>
        void SetExtSrcRepRate(string setValue);

        /// <summary>
        /// Gets the repeat rate the external source
        /// 
        /// AWGControl:RRATe?
        /// </summary>
        /// <returns>repeat rate value</returns>
        void GetExtSrcRepRate();

        /// <summary>
        /// Initiates the output of a waveform or sequence on the external source
        /// 
        /// AWGControl:RUN:IMMediate
        /// </summary>
        void SetExtSrcRunImm();

        /// <summary>
        /// Gets the filename of the current setup on the external source
        /// 
        /// AWGControl:SNAMe?
        /// </summary>
        /// <returns>filename including path of the setup file</returns>
        void GetExtSrcSetupNameQuery();

        /// <summary>
        /// Stops the output of a waveform or sequence on the external source
        /// 
        /// AWGControl:STOP:IMMediate
        /// </summary>
        void SetExtSrcStopImm();

        /// <summary>
        /// Restores the AWG's settings from a speficied settings file for the external source
        /// 
        /// AWGControl:SREStore 
        /// </summary>
        /// <param name="filename">settings file to load</param>
        void SetExtSrcFileRestore(string filename);

        /// <summary>
        ///  Restores the AWG's settings from a speficied settings file and MSUS for the external source
        /// 
        /// AWGControl:SREStore
        /// </summary>
        /// <param name="filename">settings file to load</param>
        /// <param name="msus">mass storage unit specifier aka drive</param>
        void SetExtSrcFileWithMsusRestore(string filename, string msus);

        /// <summary>
        /// Saves the external source's settings to a file
        /// 
        /// AWGControl:SSave
        /// </summary>
        /// <param name="filename">filename to save settings to</param>
        /// <param name="msus">mass storage unit specifier aka drive</param>
        void SaveExtSrcSettings(string filename, string msus);

        /// <summary>
        /// Gets the current event code the queue
        /// 
        /// EVENT?
        /// </summary>
        /// <returns>Event code</returns>
        void GetExtSrcEventQuery();

        /// <summary>
        /// Gets the current event code and message on the queue
        /// 
        /// EVMsg?
        /// </summary>
        /// <returns>Event code and message</returns>
        void GetExtSrcEventMessageQuery();

        /// <summary>
        /// Resets external source to factory default setup
        /// 
        /// FACtory
        /// </summary>
        void SetExtSrcFactoryDefault();

        /// <summary>
        /// Imports a file on the external source as a waveform
        /// 
        /// MMEMory:IMPort
        /// </summary>
        /// <param name="wfmName">Waveform Name</param>
        /// <param name="fileName">Waveform File Name</param>
        /// <param name="wfmType">Waveform Type</param>
        void SetExtSrcMemImport(string wfmName, string fileName, string wfmType);

        /// <summary>
        /// Deletes a file or directory from the external source's hard drive
        /// 
        /// MMEMory:DELete
        /// </summary>
        /// <param name="filename">filename to save settings to</param>
        /// <param name="msus">mass storage unit specifier aka drive</param>
        void DeleteExtSrcMemFile(string filename, string msus);

        /// <summary>
        /// Sets the output state for the specified channel on the external source
        /// 
        /// OUTput[n]:STATe
        /// </summary>
        /// <param name="channel">specified channel to use</param>
        /// <param name="state">ON or OFF value</param>
        void SetExtSrcOutputState(string channel, string state);

        /// <summary>
        /// Sets the DAC resolution for the specified channel on the External Source
        /// 
        /// SOURce[n]::DAC:RESolution
        /// </summary>
        /// <param name="channel">channel to use as source</param>
        /// <param name="dacResolution">8 or 10 bit </param>
        void SetExtSrcDacResolution(string channel, string dacResolution);

        /// <summary>
        /// Gets the DAC resolution for the specified channel on the External Source
        /// 
        /// SOURce[n]::DAC:RESolution?
        /// </summary>
        /// <param name="channel">channel to use as source</param>
        /// <returns>DAC resolution in bits</returns>
        void GetExtSrcDacResolution(string channel);
        
        /// <summary>
        /// Sets the sampling frequency value for the specified channel on the external source
        /// 
        /// SOURce[n]:FREQuency:CW
        /// </summary>
        /// <param name="channel">specified channel to use</param>
        /// <param name="freqValue">sampling frequency value</param>
        void SetExtSrcFreq(string channel, string freqValue);
        
        /// <summary>
        /// Sets the waveform to waveform memory on the external source for specified channel
        /// 
        /// SOURce[n]:FUNCtion:USER
        /// </summary>
        /// <param name="filename">waveform filename</param>
        /// <param name="channel">channel to use as source</param>
        void SetExtSrcFunctUser(string filename, string channel);

        /// <summary>
        /// Sets the amplitude of the waveform associated with the channel on the external source
        /// 
        /// SOURce[n]:VOLTage:AMPLitude
        /// </summary>
        /// <param name="channel">specified channel to use</param>
        /// <param name="setValue">voltage amplitude value</param>
        void SetExtSrcVoltAmpl(string channel, string setValue);

        /// <summary>
        /// Sets the high voltage level of the waveform associated with the channel on the external source
        /// 
        /// SOURce[n]:VOLTage:HIGH
        /// </summary>
        /// <param name="channel">specified channel to use</param>
        /// <param name="setValue">voltage amplitude value</param>
        void SetExtSrcVoltHigh(string channel, string setValue);

        /// <summary>
        /// Sets the low voltage level of the waveform associated with the channel on the external source
        /// 
        /// SOURce[n]:VOLTage:LOW
        /// </summary>
        /// <param name="channel">specified channel to use</param>
        /// <param name="setValue">voltage amplitude value</param>
        void SetExtSrcVoltLow(string channel, string setValue);

        /// <summary>
        /// Sets the output waveform from the cuurrent waveform list on the external source for specified channel
        /// 
        /// SOURce[n]:WAVeform 
        /// </summary>
        /// <param name="waveform">waveform name</param>
        /// <param name="channel">channel to use as source</param>
        void SetExtSrcWaveform(string waveform, string channel);

        /// <summary>
        /// Gets the system error code and message from the external source
        /// 
        /// SYSTem:ERRor?
        /// </summary>
        /// <returns>System error code and message</returns>
        void GetExtSrcSystemErrorQuery();

        /// <summary>
        /// Gets the the size(number of waveforms) of the waveform list from the externl source
        /// 
        /// WLISt:SIZE?
        /// </summary>
        /// <returns>the size(number of waveforms) of the waveform list</returns>
        void GetExtSrcWfmListSize();

        /// <summary>
        /// Creates a new empty waveform in the waveform list of the current setup on the external source
        /// 
        /// WLISt:WAVeform:NEW
        /// </summary>
        /// <param name="wfmName">waveform name</param>
        /// <param name="wfmSize">waveform size(number of points)</param>
        /// <param name="wfmType">waveform type</param>
        void SetExtSrcWfmNew(string wfmName, string wfmSize, string wfmType);

    }
}
