namespace AwgTestFramework
{
    interface IPiCmdsExtSource
    {
        #region shared by all
        uint DefaultVisaTimeout { get; set; }
        #endregion shared by all

        #region *CLS

        /// <summary>
        /// Clears error queue of the external source
        /// 
        /// *CLS
        /// </summary>
        void ExtSrcCLS();
        #endregion *CLS

        #region *ESR?

        /// <summary>
        /// Gets Standard Event Status Register
        /// basically means clearing it
        /// 
        /// *ESR?
        /// </summary>
        /// <returns>event status of the external source</returns>
        string GetExtSrcESRQuery();
        #endregion *ESR?

        #region *IDN?

        /// <summary>
        /// Gets the id of the external source
        /// 
        /// *IDN?
        /// </summary>
        /// <returns>Id of the external source</returns>
        string GetExtSrcIDNQuery();
        #endregion *IDN?

        #region *RST

        /// <summary>
        /// Resets the external source
        /// 
        /// *RST
        /// </summary>
        void ExtSrcRst();
        #endregion *RST

        #region *OPC?

        /// <summary>
        /// Waits for the external source to complete
        /// 
        /// *OPC?
        /// </summary>
        /// <param name="timeout">How long to wait for the OPC to return</param>
        /// <returns>OPC result</returns>
        string GetExtSrcOPCQuery(uint timeout = 15000);
        #endregion *OPC?

        #region *OPT?

        /// <summary>
        /// Gets the options that are enabled on the external source
        /// 
        /// *OPT?
        /// </summary>
        /// <returns>Options enabled on the ext source</returns>
        string GetExtSrcOptQuery();
        #endregion *OPT?

        #region ALLev?

        /// <summary>
        /// Gets all the events on the external source
        /// 
        /// ALLEv?
        /// </summary>
        /// <returns>Id of the external source</returns>
        string GetExtSrcALLEvQuery();
        #endregion ALLev?

        #region AWGControl:INTerleave:STATE

        /// <summary>
        /// Enables or disables the interleave states for channels on the external source
        /// 
        /// AWGControl:INTerleave:STATE
        /// </summary>
        /// <param name="state">interleave state ON|OFF</param>
        void SetExtSrcInterLeaveState(string state);
        #endregion AWGControl:INTerleave:STATE

        #region AWGControl:INTerleave:ZERoing

        /// <summary>
        /// Sets or removes the zeroing option for interleave mode on the external source
        /// 
        /// AWGControl:INTerleave:ZERoing
        /// </summary>
        /// <param name="state">sets state for interleaving mode zeroing option</param>
        /// <returns>System error code and message</returns>
        void SetExtSrcInterLeaveZeroing(string state);
        #endregion AWGControl:INTerleave:ZERoing

        #region AWGControl:RMODe

        /// <summary>
        /// Sets the run mode for the external source
        /// 
        /// AWGControl:RMODe 
        /// </summary>
        /// <param name="mode">run mode setting</param>
        void SetExtSrcRunMode(string mode);
        #endregion AWGControl:RMODe

        #region AWGControl:RMODe?

        /// <summary>
        /// Gets the run mode status from the external source
        /// 
        /// AWGControl:RMODe?
        /// </summary>
        /// <returns>run mode status</returns>
        string GetExtSrcRunModeQuery();
        #endregion AWGControl:RMODe?

        #region AWGControl:RRATe

        /// <summary>
        /// Sets the repeat rate the external source
        /// 
        /// AWGControl:RRATe
        /// </summary>
        /// <param name="setValue">repeat rate value</param>
        /// <returns>System error code and message</returns>
        void SetExtSrcRepRate(string setValue);
        #endregion AWGControl:RRATe

        #region AWGControl:RRATe?

        /// <summary>
        /// Gets the repeat rate the external source
        /// 
        /// AWGControl:RRATe?
        /// </summary>
        /// <returns>repeat rate value</returns>
        string GetExtSrcRepRate();
        #endregion AWGControl:RRATe?

        #region AWGControl:RUN:IMMediate

        /// <summary>
        /// Initiates the output of a waveform or sequence on the external source
        /// 
        /// AWGControl:RUN:IMMediate
        /// </summary>
        void SetExtSrcRunImm();
        #endregion AWGControl:RUN:IMMediate

        #region AWGControl:SNAMe?

        /// <summary>
        /// Gets the filename of the current setup on the external source
        /// 
        /// AWGControl:SNAMe?
        /// </summary>
        /// <returns>filename including path of the setup file</returns>
        string GetExtSrcSetupNameQuery();
        #endregion AWGControl:SNAMe?

        #region AWGControl:STOP:IMMediate

        /// <summary>
        /// Stops the output of a waveform or sequence on the external source
        /// 
        /// AWGControl:STOP:IMMediate
        /// </summary>
        void SetExtSrcStopImm();
        #endregion AWGControl:STOP:IMMediate

        #region AWGControl:SREStore

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
        #endregion AWGControl:SREStore

        #region AWGControl:SSave

        /// <summary>
        /// Saves the external source's settings to a file
        /// 
        /// AWGControl:SSave
        /// </summary>
        /// <param name="filename">filename to save settings to</param>
        /// <param name="msus">mass storage unit specifier aka drive</param>
        void SaveExtSrcSettings(string filename, string msus);
        #endregion AWGControl:SSave

        #region EVENT?

        /// <summary>
        /// Gets the current event code the queue
        /// 
        /// EVENT?
        /// </summary>
        /// <returns>Event code</returns>
        string GetExtSrcEventQuery();
        #endregion EVENT?

        #region EVMsg?

        /// <summary>
        /// Gets the current event code and message on the queue
        /// 
        /// EVMsg?
        /// </summary>
        /// <returns>Event code and message</returns>
        string GetExtSrcEventMessageQuery();
        #endregion EVMsg?

        #region FACtory

        /// <summary>
        /// Resets external source to factory default setup
        /// 
        /// FACtory
        /// </summary>
        void SetExtSrcFactoryDefault();
        #endregion FACtory

        #region MMEMory:IMPort

        /// <summary>
        /// Imports a file on the external source as a waveform
        /// 
        /// MMEMory:IMPort
        /// </summary>
        /// <param name="wfmName">Waveform Name</param>
        /// <param name="fileName">Waveform File Name</param>
        /// <param name="wfmType">Waveform Type</param>
        void SetExtSrcMemImport(string wfmName, string fileName, string wfmType);
        #endregion MMEMory:IMPort

        #region MMEMory:DELete

        /// <summary>
        /// Deletes a file or directory from the external source's hard drive
        /// 
        /// MMEMory:DELete
        /// </summary>
        /// <param name="filename">filename to save settings to</param>
        /// <param name="msus">mass storage unit specifier aka drive</param>
        void DeleteExtSrcMemFile(string filename, string msus);
        #endregion MMEMory:DELete

        #region OUTput[n]:STATe

        /// <summary>
        /// Sets the output state for the specified channel on the external source
        /// 
        /// OUTput[n]:STATe
        /// </summary>
        /// <param name="channel">specified channel to use</param>
        /// <param name="state">ON or OFF value</param>
        void SetExtSrcOutputState(string channel, string state);
        #endregion OUTput[n]:STATe

        #region SOURce[n]:DAC:RESolution

        /// <summary>
        /// Sets the DAC resolution for the specified channel on the External Source
        /// 
        /// SOURce[n]::DAC:RESolution
        /// </summary>
        /// <param name="channel">channel to use as source</param>
        /// <param name="dacResolution">8 or 10 bit </param>
        void SetExtSrcDacResolution(string channel, string dacResolution);
        #endregion SOURce[n]:DAC:RESolution

        #region SOURce[n]:DAC:RESolution?

        /// <summary>
        /// Gets the DAC resolution for the specified channel on the External Source
        /// 
        /// SOURce[n]::DAC:RESolution?
        /// </summary>
        /// <param name="channel">channel to use as source</param>
        /// <returns>DAC resolution in bits</returns>
        string GetExtSrcDacResolution(string channel);
        #endregion SOURce[n]:DAC:RESolution?

        #region SOURce[n]:FUNCtion:USER

        /// <summary>
        /// Sets the waveform to waveform memory on the external source for specified channel
        /// 
        /// SOURce[n]:FUNCtion:USER
        /// </summary>
        /// <param name="filename">waveform filename</param>
        /// <param name="channel">channel to use as source</param>
        void SetExtSrcFunctUser(string filename, string channel);
        #endregion SOURce[n]:FUNCtion:USER

        #region SOURce[n]:WAVeform

        /// <summary>
        /// Sets the output waveform from the cuurrent waveform list on the external source for specified channel
        /// 
        /// SOURce[n]:WAVeform 
        /// </summary>
        /// <param name="waveform">waveform name</param>
        /// <param name="channel">channel to use as source</param>
        void SetExtSrcWaveform(string waveform, string channel);
        #endregion SOURce[n]:WAVeform

        #region SOURce[n]:FREQuency:CW

        /// <summary>
        /// Sets the sampling frequency value for the specified channel on the external source
        /// 
        /// SOURce[n]:FREQuency:CW
        /// </summary>
        /// <param name="channel">specified channel to use</param>
        /// <param name="freqValue">sampling frequency value</param>
        void SetExtSrcFreq(string channel, string freqValue);
        #endregion SOURce[n]:FREQuency:CW

        #region SOURce[n]:VOLTage:AMPLitude

        /// <summary>
        /// Sets the amplitude of the waveform associated with the channel on the external source
        /// 
        /// SOURce[n]:VOLTage:AMPLitude
        /// </summary>
        /// <param name="channel">specified channel to use</param>
        /// <param name="setValue">voltage amplitude value</param>
        void SetExtSrcVoltAmpl(string channel, string setValue);
        #endregion SOURce[n]:VOLTage:AMPLitude

        #region SOURce[n]:VOLTage:HIGH

        /// <summary>
        /// Sets the high voltage level of the waveform associated with the channel on the external source
        /// 
        /// SOURce[n]:VOLTage:HIGH
        /// </summary>
        /// <param name="channel">specified channel to use</param>
        /// <param name="setValue">voltage amplitude value</param>
        void SetExtSrcVoltHigh(string channel, string setValue);
        #endregion SOURce[n]:VOLTage:HIGH

        #region SOURce[n]:VOLTage:LOW

        /// <summary>
        /// Sets the low voltage level of the waveform associated with the channel on the external source
        /// 
        /// SOURce[n]:VOLTage:LOW
        /// </summary>
        /// <param name="channel">specified channel to use</param>
        /// <param name="setValue">voltage amplitude value</param>
        void SetExtSrcVoltLow(string channel, string setValue);
        #endregion SOURce[n]:VOLTage:LOW

        #region SYSTem:ERRor?

        /// <summary>
        /// Gets the system error code and message from the external source
        /// 
        /// SYSTem:ERRor?
        /// </summary>
        /// <returns>System error code and message</returns>
        string GetExtSrcSystemErrorQuery();
        #endregion SYSTem:ERRor?

        #region WLISt:SIZE?

        /// <summary>
        /// Gets the the size(number of waveforms) of the waveform list from the externl source
        /// 
        /// WLISt:SIZE?
        /// </summary>
        /// <returns>the size(number of waveforms) of the waveform list</returns>
        string GetExtSrcWfmListSize();
        #endregion WLISt:SIZE?

        #region WLISt:WAVeform:NEW

        /// <summary>
        /// Creates a new empty waveform in the waveform list of the current setup on the external source
        /// 
        /// WLISt:WAVeform:NEW
        /// </summary>
        /// <param name="wfmName">waveform name</param>
        /// <param name="wfmSize">waveform size(number of points)</param>
        /// <param name="wfmType">waveform type</param>
        void SetExtSrcWfmNew(string wfmName, string wfmSize, string wfmType);
        #endregion WLISt:WAVeform:NEW
    }
}
