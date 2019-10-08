
namespace AwgTestFramework
{
    internal interface IPiCmds
    {

        #region shared by all

        uint DefaultVisaTimeout { get; set; }

        #endregion shared by all

        #region CapturePlayback

        #region CPLayback:CAPture:FILE
        //jmanning 09/22/2014
        /// <summary>
        /// Using CPLayback:CAPture:FILE imports waveform/signal from specified file to captured signal list
        /// </summary>
        /// <param name="sigName">Desired signal to import to captured signal list</param>
        /// <param name="fileType">SIQ|CIQ</param>
        /// <param name="filePath1">file path which contains signal</param>
        /// <param name="filePath2">file path which contains signal</param>
        void AwgCapturePlaybackFile(string sigName, string fileType, string filePath1, string filePath2);
        #endregion CPLayback:CAPture:FILE

        #region CPLayback:COMPile
        //jmanning 09/22/2014
        /// <summary>
        /// Using CPLayback:COMPile to resamples and upconverts selected signals to specified carrier frequency
        /// </summary>
        void AwgCompilePlaybackFiles();
        #endregion CPLayback:COMPile

        #region CPLayback:CLISt:SIGNal:SCOMPile
        //jmanning 09/22/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:SCOMPile selects/deselects a signal from the captured signal list to be compiled.
        /// </summary>
        /// <param name="sigName">Desired signal to import to captured signal list</param>
        /// <param name="boolCompile">boolean compile select state</param>
        /// 
        void SelectAwgCompilePlaybackFile(string sigName, bool boolCompile);
        #endregion CPLayback:CLISt:SIGNal:SCOMPile

        #region CPLayback:CLISt:SIGNal:SCOMPile?
        //jmanning 09/22/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:SCOMPile selects/deselects a signal from the captured signal list to be compiled.
        /// </summary>
        /// <param name="sigName">Desired signal to import to captured signal list</param>
        /// <returns>Compile Select Status as a boolean</returns>
        string GetCompileSelectStatusPlaybackFile(string sigName);
        #endregion CPLayback:CLISt:SIGNal:SCOMPile?

        #region CPLayback:COMPile:CFRequency
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:COMPile:CFRequency sets the carrier frequency for the compiled signals.
        /// </summary>
        /// <param name="freqValue">Desired carrier frequency setting in Hz</param>
        /// 
        void SetAwgCompileCarFrequency(string freqValue);
        #endregion CPLayback:COMPile:CFRequency

        #region CPLayback:COMPile:CFRequency?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:COMPile:CFRequency? gets the carrier frequency for the compiled signals.
        /// </summary>
        string GetAwgCompileCarFrequency();
        #endregion CPLayback:COMPile:CFRequency?
        #region CPLAYBACK:COMPILE:SRATE
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:COMPile:SRATE sets the output sampling rate for the compiled signals.
        /// </summary>
        /// <param name="sampleRate">Desired sample rate in samples/s</param>
        /// 
        void SetAwgCompileSampleRate(string sampleRate);
        #endregion CPLAYBACK:COMPILE:SRATE

        #region CPLAYBACK:COMPILE:SRATE?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:COMPile:SRATE? gets the output sampling rate for the compiled signals.
        /// </summary>
        /// <returns>Desired sample rate in samples/s</returns>
        /// 
        string GetAwgCompileSampleRate();
        #endregion CPLAYBACK:COMPILE:SRATE?

        #region CPLayback:COMPile:SRATe:AUTO
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:COMPile:SRATe:AUTO command sets if the system will calculate output sampling rate automatically when compiling the selected signals.
        /// </summary>
        /// <param name="autoCalcState">Auto calculate sampe rate state</param>
        /// 
        void SetAwgCompileSampleRateAuto(bool autoCalcState);
        #endregion CPLayback:COMPile:SRATe:AUTO

        #region CPLayback:COMPile:SRATe:AUTO?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:COMPile:SRATe:AUTO? query gets status  of if the system will calculate output sampling rate automatically when compiling the selected signals.
        /// </summary>
        /// <return>Auto calculate sampe rate state</return>
        /// 
        string GetAwgCompileSampleRateAuto();
        #endregion CPLayback:COMPile:SRATe:AUTO?

        #region CPLayback:CLISt:NAME?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:NAME? query gets the name of a signal from the captured signal list in the position specified by the index value.  Index value is 1-based.
        /// </summary>
        /// <param name="listIndex">index position of signal in captured list</param>
        /// <return>Signal name from the captured signal list at index specified</return>
        /// 
        string GetAwgCompileSignalName(string listIndex);
        #endregion CPLayback:CLISt:NAME?

        #region CPLayback:CLISt:SIGNal:DELete
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:DELete command removes the specified signal from the captured signal list. ALL clears the captured signal list.
        /// </summary>
        /// <param name="signalName">Signal name to delete. "ALL" deletes whole list</param>
        /// 
        void DeleteAwgCompileSignal(string signalName);
        #endregion CPLayback:CLISt:SIGNal:DELete

        #region CPLayback:CLISt:SIZE?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIZE? query gets the Number of signals in the captured signal list.
        /// </summary>
        /// <return>Number of signals in the captured signal list</return>
        /// 
        string GetAwgCompileSignalsSize();
        #endregion CPLayback:CLISt:SIZE?

        #region CPLayback:CLISt:SIGNal:OTIMe
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:OTIMe command sets the off time for the specified signal in the captured signal list.
        /// </summary>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <param name="offTime">time in seconds</param>
        /// 
        void SetAwgCompileSignalOffTime(string signalName, string offTime);
        #endregion CPLayback:CLISt:SIGNal:OTIMe

        #region CPLayback:CLISt:SIGNal:OTIMe?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:OTIMe? query gets the off time for the specified signal in the captured signal list.
        /// </summary>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <returns> off time in seconds</returns>
        /// 
        string GetAwgCompileSignalOffTime(string signalName);
        #endregion CPLayback:CLISt:SIGNal:OTIMe?

        #region CPLayback:CLISt:SIGNal:WCOunt?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:WCOunt? query gets the number of waveform contained in a signal in the captured signal list.
        /// </summary>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <returns> the number of waveform contained in specified signal</returns>
        /// 
        string GetAwgCompileSignalWfmCount(string signalName);
        #endregion CPLayback:CLISt:SIGNal:WCOunt?
        #region CPLayback:CLISt:SIGNal:WAVeform:NAME?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:WAVeform:NAME? query gets the name of a waveform segment of a signal in the captured signal list.
        /// </summary>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <param name="wfmIndex">index of segment|waveform in specified signal</param>
        /// <returns> the name of waveform contained in specified signal's index</returns>
        /// 
        string GetAwgCompileSignalWfmName(string signalName, string wfmIndex);
        #endregion CPLayback:CLISt:SIGNal:WAVeform:NAME?

        #region CPLayback:CLISt:SIGNal:WAVeform:FOFFset
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:WAVeform:FOFFset sets the frequency offset of a waveform segment of a signal in the captured signal list.
        /// </summary>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <param name="wfmIndex">index of segment|waveform in specified signal</param>
        /// <param name="freqValue">Desired frequency offset setting in Hz</param>
        /// 
        void SetAwgCompileWfmFreqOffset(string signalName, string wfmIndex, string freqValue);
        #endregion CPLayback:CLISt:SIGNal:WAVeform:FOFFset

        #region CPLayback:CLISt:[SIGNal:]WAVeform:FOFFset?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:WAVeform:FOFFset? gets the frequency offset value of a waveform segment fro specified signal in the captured signal list.
        /// </summary>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <param name="wfmIndex">index of segment|waveform in specified signal</param>
        /// <returns>Specified waveform frequency offset value</returns>
        /// 
        string GetAwgCompileWfmFreqOffset(string signalName, string wfmIndex);
        #endregion CPLayback:CLISt:[SIGNal:]WAVeform:FOFFset?

        #region CPLayback:CLISt:[SIGNal:]WAVeform:SRATe
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:WAVeform:SRATe sets the sample rate of a waveform segment of a signal in the captured signal list.
        /// </summary>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <param name="wfmIndex">index of segment|waveform in specified signal</param>
        /// <param name="sampleRate">Desired sample rate in samples/s</param>
        /// 
        void SetAwgCompileWfmSampleRate(string signalName, string wfmIndex, string sampleRate);
        #endregion CPLayback:CLISt:SIGNal:WAVeform:SRATe

        #region CPLayback:CLISt:SIGNal:WAVeform:SRATe?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:WAVeform:SRATe? gets the sample rate value of a waveform segment for specified signal in the captured signal list.
        /// </summary>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <param name="wfmIndex">index of segment|waveform in specified signal</param>
        /// <returns>Specified waveform sample rate value</returns>
        /// 
        string GetAwgCompileWfmSampleRate(string signalName, string wfmIndex);
        #endregion CPLayback:CLISt:SIGNal:WAVeform:SRATe?

        #region CPLAYBACK:COMPILE:LSEQuence
        //Keerthi 06/01/2015
        /// <summary>
        /// Using CPLAYBACK:COMPILE:LSEQuence sets the Loop Sequence in captureplayback to ON/OFF
        /// </summary>
        /// <param name="setValue">name of signal in captured signals list</param>
         void SelectLoopSequence(string setValue);

        #endregion CPLAYBACK:COMPILE:LSEQuence

        #region CPLAYBACK:COMPILE:LSEQuence?
         //Keerthi 06/01/2015
         /// <summary>
         /// Using CPLAYBACK:COMPILE:LSEQuence? Gets the Loop Sequence in captureplayback to ON/OFF
         /// </summary>
         /// <returns>Loop sequence is ON/OFF</returns>
         string GetLoopSequence();

        #endregion CPLAYBACK:COMPILE:LSEQuence?

        #endregion CapturePlayback

        #region Calibration

        #region Published

        #region *CAL?

        // Unkown 01/01/01 Adjusting timeout to 37 minutes
        //glennj 6/11/2013
        /// <summary>
        /// Sends a *CAL? query and returns the response
        /// </summary>
        /// <returns>The AWG's response to the *CAL? query</returns>
        string AwgCalRunAndQuery();

        #endregion *CAL?

        #region CALibration:ABORt

        //glennj 6/11/2013
        /// <summary>
        /// Using CAL:ABOR, abort running of calibration.
        /// </summary>
        void AwgCalAbort();

        #endregion CALibration:ABORt

        #region CALibration[:ALL]

        //glennj 6/11/2013
        /// <summary>
        /// Using CAL:ALL, start self calibration<para>
        /// Note, this takes 37 minutes or a really long time :)</para>
        /// </summary>
        void AwgCalAll();

        //glennj 6/11/2013 Adjusting the timeout to 32 minutes
        /// <summary>
        /// Using CAL:ALL?, start self calibration<para>
        /// (Note, this takes 37 minutes or a really long time)</para><para>
        /// and returns a result</para>
        /// </summary>
        /// <returns>Calibration state</returns>
        string AwgCalAllReturnResults();

        #endregion CALibration[:ALL]

        #region CALibration:CATalog?

        //glennj 6/11/2013
        /// <summary>
        /// Returns a list depending on the passed parameters for the calibration catalog.
        /// </summary>
        /// <param name="optionalSubsystem">The optional subsystem being queried</param>
        /// <param name="optionalArea">The optional area being queried</param>
        /// <returns>Entire calibration catalog</returns>
        string GetAwgCalCatalog(string optionalSubsystem = "", string optionalArea = "");

        #endregion CALibration:CATalog?

        #region CALibration:LOG?

        //glennj 6/11/2013
        /// <summary>
        /// Using CAL:LOG? return the calibration log results.
        /// </summary>
        /// <returns>Calibration log results</returns>
        string GetAwgCalLog();

        #endregion CALibration:LOG?

        #region CALibration:LOG:CLEar

        //glennj 6/11/2013
        /// <summary>
        /// Using CAL:LOG:CLE, clear the calibration log.
        /// </summary>
        void ClearAwgCalLog();

        #endregion CALibration:LOG:CLEar

        #region CALibration:LOG:DETails

        //glennj 6/11/2013
        /// <summary>
        /// Using CAL:LOG:DET set amount of detail to be stored in the cal logs
        /// </summary>
        /// <param name="detailSetting">Desired value for the details flag in the cal logs</param>
        void SetAwgCalDetail(string detailSetting);

        //glennj 6/11/2013
        /// <summary>
        /// Using CAL:LOG:DET? return the setting for details to be stored in the cal logs
        /// </summary>
        /// <returns>Calibration log details flag value</returns>
        string GetAwgCalDetails();

        #endregion CALibration:LOG:DETails

        #region CALibration:LOG:FAILuresonly

        //glennj 6/11/2013
        /// <summary>
        /// Using CAL:LOG:FAIL set store only failures in the cal logs
        /// </summary>
        /// <param name="failuresOnlySetting">The desired value for the failures only flag</param>
        void SetAwgCalFailOnlyMode(string failuresOnlySetting);

        //glennj 6/11/2013
        /// <summary>
        /// Using CAL:LOG:FAIL? return the setting for store only failures mode in the cal logs
        /// </summary>
        /// <returns>Calibration Fail Only Flag</returns>
        string GetAwgCalFailOnlyMode();

        #endregion CALibration:LOG:FAILuresonly

        #region CALibration:RESTore

        //glennj 6/11/2013
        /// <summary>
        /// Using CAL:REST start a restore of the factory cal constants
        /// </summary>
        void RestoreAwgFactoryCal();

        #endregion CALibration:RESTore

        #region CALibration:RESult?

        //glennj 6/11/2013
        /// <summary>
        /// Using CAL:RES?, return the calibration result.<para>
        /// An optional Subsystem and/or area and/or test can be specified.</para>
        /// </summary>
        /// <param name="optionalSubsystem">The optional subsystem being queried</param>
        /// <param name="optionalArea">The optional area being queried</param>
        /// <param name="optionalProcedure">The optional procedure being queried</param>
        /// <returns>Calibration results</returns>
        string GetAwgCalResult(string optionalSubsystem = "", string optionalArea = "", string optionalProcedure = "");

        #endregion CALibration:RESult?

        #region CALibration:RESult:TEMPerature?

        //glennj 6/11/2013
        /// <summary>
        /// Using CAL:RES:TEMP? return the specified calibration procedure result's temperature<para>
        /// An optional Subsystem and/or area and/or test can be specified.</para>
        /// </summary>
        /// <param name="optionalSubsystem">The optional subsystem being queried</param>
        /// <param name="optionalArea">The optional area being queried</param>
        /// <param name="optionalProcedure">The optional procedure being queried</param>
        /// <returns>Returns temperture for each specified test</returns>
        string GetAwgCalResultTemperature(string optionalSubsystem = "", string optionalArea = "",
            string optionalProcedure = "");

        #endregion CALibration:RESult:TEMPerature?

        #region CALibration:RESult:TIME?

        //glennj 6/11/2013
        /// <summary>
        /// Using CAL:RES:TIME? return the specified calibration procedure result's time<para>
        /// An optional Subsystem and/or area and/or test can be specified.</para>
        /// </summary>
        /// <param name="optionalSubsystem">The optional subsystem being queried</param>
        /// <param name="optionalArea">The optional area being queried</param>
        /// <param name="optionalProcedure">The optional procedure being queried</param>
        /// <returns>Returns temperture for each specified test</returns>
        string GetAwgCalResultTime(string optionalSubsystem = "", string optionalArea = "",
            string optionalProcedure = "");

        #endregion CALibration:RESult:TIME?

        #region CALibration:RUNNing?

        //glennj 6/11/2013
        /// <summary>
        /// Returns whether a calibration procedure is running
        /// </summary>
        /// <returns>A string of colon separated "subsystem", "area:" and "procedure" if running or "" if not.</returns>
        string AwgCalRunning();

        #endregion CALibration:RUNNing?

        #region CALibration:STARt

        //glennj 6/11/2013
        /// <summary>
        /// Starts internal calibration using the CALibration:STARt command
        /// </summary>
        void AwgCalStart();

        #endregion CALibration:STARt

        #region CALibration:STATe:FACTory?

        //glennj 6/11/2013
        /// <summary>
        /// Using CAL:STAT:FACT? return the state of calibration of format<para>
        /// of S(C|U),D(),T()</para><para>
        /// Optional subsystem and areas</para>
        /// </summary>
        /// <param name="subsystem">optional subsystem</param>
        /// <param name="area">optional area, subsystem required if used</param>
        /// <returns></returns>
        string GetAwgCalFactoryState(string subsystem, string area);

        #endregion CALibration:STATe:FACTory?

        #region CALibration:STATe:USER?

        //glennj 8/1/2013
        /// <summary>
        /// Using CAL:STATe:USER? return the state of calibration of format<para>
        /// of S(C|U),D(),T()</para><para>
        /// Optional subsystem and areas</para>
        /// </summary>
        /// <param name="subsystem">optional subsystem</param>
        /// <param name="area">optional area, subsystem required if used</param>
        /// <returns>Returns formatted state</returns>
        string GetAwgCalUserState(string subsystem, string area);

        #endregion CALibration:STATe:USER?

        #region CALibration:STOP:STATe?

        //glennj 6/11/2013
        /// <summary>
        /// Queries and returns the calibration stop state.
        /// </summary>
        /// <returns>Calibration stop state. 0 indicates not stopped. 1 indicates stopped.</returns>
        string GetAwgCalStopState();

        #endregion CALibration:STOP:STATe?

        #endregion Published

        #region Non-Published

        #region CALibration:CONTrol:COUNt

        //glennj 6/11/2013
        /// <summary>
        /// Sets the calibration loop count value.
        /// </summary>
        /// <param name="numberOfLoops">Desired loop count value to be set</param>
        void AwgCalLoopCount(string numberOfLoops);

        //glennj 6/11/2013
        /// <summary>
        /// Queries and returns the calibration loop count value.
        /// </summary>
        string AwgCalLoopCountQuery();

        #endregion CALibration:CONTrol:COUNt

        #region CALibration:CONTrol:HALT

        //glennj 6/11/2013
        /// <summary>
        /// Sets the halt value to what is specified in the setValue variable.
        /// </summary>
        /// <param name="haltMode">Value used to set the boolean HALT variable.</param>
        void AwgCalHalt(string haltMode);

        //glennj 6/11/2013
        /// <summary>
        /// Queries and returns the calibration halt value.
        /// </summary>
        /// <returns>Calibration Halt Value.</returns>
        string AwgCalHaltQuery();

        #endregion CALibration:CONTrol:HALT

        #region CALibration:CONTrol:LOOP

        //glennj 6/11/2013
        /// <summary>
        /// Sets the mode of the calibration loop control
        /// </summary>
        /// <param name="loopMode">Loop mode to set.</param>
        void AwgCalLoop(string loopMode);

        //glennj 6/11/2013
        /// <summary>
        /// Queries and returns the value of the calibration loop control
        /// </summary>
        string AwgCalControlLoopQuery();

        #endregion CALibration:CONTrol:LOOP

        #region CALibration:DATA:FACTory?

        //glennj 06/10/2013
        /// <summary>
        /// Queries and returns the calibration factory data from specified area.
        /// </summary>
        /// <param name="requiredSubsystem"></param>
        /// <param name="optionalArea"></param>
        /// <param name="optionalProcedure"></param>
        /// <returns>Calibration factory data from specified area</returns>
        string AwgCalDataFactoryQuery(string requiredSubsystem, string optionalArea = "", string optionalProcedure = "");

        #endregion CALibration:DATA:FACTory?

        #region CALibration:DATA:USER

        //glennj 6/11/2013
        /// <summary>
        /// </summary>
        /// <param name="calConstantsAsXml"></param>
        /// <param name="requiredSubsystem"></param>
        /// <param name="optionalArea"></param>
        /// <param name="optionalProcedure"></param>
        void AwgCalDataUser(string calConstantsAsXml, string requiredSubsystem, string optionalArea = "",
            string optionalProcedure = "");

        //glennj 6/11/2013
        /// <summary>
        /// Queries and returns calibration user data
        /// </summary>
        /// <param name="requiredSubsystem"></param>
        /// <param name="optionalArea"></param>
        /// <param name="optionalProcedure"></param>
        /// <returns>Calibration user data from specified area</returns>
        string AwgCalDataUserQuery(string requiredSubsystem, string optionalArea = "", string optionalProcedure = "");

        #endregion CALibration:DATA:USER

        #region CALibration:LOOP?

        //glennj 6/11/2013
        /// <summary>
        /// Queries and returns the number of calibration loops completed.
        /// </summary>
        /// <returns>The number of calibrations loops completed</returns>
        string AwgCalLoopQuery();

        #endregion CALibration:LOOP?

        #region CALibration:SELect

        //glennj 6/11/2013
        /// <summary>
        /// Selects calibration procedures specified by the selection variable.
        /// </summary>
        /// <param name="requiredSubsystem">Valid subsystem name</param>
        /// <param name="optionalArea">Valid area name</param>
        /// <param name="optionalProcedure">Valid procedure name</param>
        void AwgCalSelect(string requiredSubsystem, string optionalArea = "", string optionalProcedure = "");

        #endregion CALibration:SELect

        #region CALibration:SELect:VERify?

        //glennj 6/11/2013
        /// <summary>
        /// Checks to see if a the test specified by the test variable is selected or unselected.
        /// </summary>
        /// <param name="requiredSubsystem">Valid subsystem name</param>
        /// <param name="requiredArea">Valid area name</param>
        /// <param name="requiredProcedure">Valid procedure name</param>
        /// <returns>Returns a 1 if the test is selected or a 0 if it is unselected</returns>
        string AwgCalSelectVerify(string requiredSubsystem, string requiredArea, string requiredProcedure);

        #endregion CALibration:SELect:VERify?

        #region CALibration:TYPE:CATalog?

        //glennj 6/11/2013
        /// <summary>
        /// Queries for calibration type catalog and returns the reponse.
        /// </summary>
        /// <returns>Calibration Type Catalog</returns>
        string AwgCalTypeCatalogQuery();

        #endregion CALibration:TYPE:CATalog?

        #region CALibration:TYPE

        //glennj 6/11/2013
        /// <summary>
        /// Sets the calibration type to calType variable.
        /// </summary>
        /// <param name="calType">Calibration type to set on the AWG</param>
        void AwgCalType(string calType);

        //glennj 6/11/2013
        /// <summary>
        /// Queries for the current calibration type.
        /// </summary>
        /// <returns>Calibration Type</returns>
        string AwgCalTypeQuery();

        #endregion CALibration:TYPE

        #region CALibration:UNSelect

        //glennj 6/11/2013
        /// <summary>
        /// Unselects calibration procedures specified by the selection variable.
        /// </summary>
        /// <param name="requiredSubsystem">Valid subsystem name</param>
        /// <param name="optionalArea">Valid area name</param>
        /// <param name="optionalProcedure">Valid procedure name</param>
        void AwgCalUnselect(string requiredSubsystem, string optionalArea = "", string optionalProcedure = "");

        #endregion CALibration:UNSelect

        #endregion Non-Published

        #endregion Calibration

        #region Clock

        #region PSR1

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:EREFerence:DIVider to set the divider rate of the external reference signal when the external reference is variable
        /// </summary>
        /// <param name="clockNumber"></param>
        /// <param name="setValue"></param>
        void SetAwgExternalReferenceClockDivider(string clockNumber, string setValue);

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:EREFerence:DIVider? to get the divider rate of the external reference signal when the external reference is variable
        /// </summary>
        /// <param name="clockNumber"></param>
        /// <returns></returns>
        string GetAwgExternalReferenceClockDivider(string clockNumber);

        //glennj 06/10/2013
        /// <summary>
        /// Using CLOCk:EREFerence:FREQuency to set external reference frequency being provided by the external clock
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Frequency being provided by the external reference</param>
        void SetAwgClockExternalReferenceFrequency(string clockNumber, string setValue);

        //glennj 06/10/2013
        /// <summary>
        /// Using CLOCk:EREFerence:FREQuency? to get expected frequency being provided by the external reference
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <returns>Frequency being provided by the external reference</returns>
        string GetAwgClockExternalReferenceFrequency(string clockNumber);

        //glennj 06/10/2013
        /// <summary>
        /// Uses CLOCk:EREFerence:FREQuency:DETect to tell the system to acquire the external reference and adjust the system to use it
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        void AwgClockExternalReferenceFrequencyDetect(string clockNumber);

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:EREFerence:MULTiplier to set the multiplier of the external reference signal when the external reference is variable
        /// </summary>
        /// <param name="clockNumber"></param>
        /// <param name="setValue"></param>
        void SetAwgExternalReferenceClockMultiplier(string clockNumber, string setValue);

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:EREFerence:MULTiplier? to get the multiplier of the external reference signal when the external reference is variable
        /// </summary>
        /// <param name="clockNumber"></param>
        /// <returns></returns>
        string GetAwgExternalReferenceClockMultiplier(string clockNumber);

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:JITTer to set whether low jitter is enabled on the system.
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Jitter boolean</param>
        void SetAwgClockJitter(string clockNumber, string setValue);

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:JITTer? to get low jitter is enabled on the system.
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <returns>Whether low jitter is enabled</returns>
        string GetAwgClockJitter(string clockNumber);

        //sforell 8/19/13 this Setter should not be here because the PI command is query form only
        ////glennj 06/07/2013
        ///// <summary>
        ///// Using CLOCk:OUTput:FREQuency to set the output frequency of the specified clock.
        ///// </summary>
        ///// <param name="clockNumber">Which clock</param>
        ///// <param name="setValue">Output frequency</param>
        //void SetAwgClockOutputFrequency(string clockNumber, string setValue);

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:OUTput:FREQuency? to get the output frequency of the specified clock.
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <returns>Output frequency</returns>
        string GetAwgClockOutputFrequency(string clockNumber);

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:OUTput:STATe to set the output state of the specified clock.
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Output state</param>
        void SetAwgClockOutputState(string clockNumber, string setValue);

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:OUTput:STATe? to get the output state of the specified clock.
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <returns>Output state</returns>
        string GetAwgClockOutputState(string clockNumber);

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:PHASe:ADJust to set the internal clock phase adjustment of the AWG
        /// </summary>
        /// <param name="clockNumber"></param>
        /// <param name="setValue"></param>
        void SetAwgClockPhaseAdjust(string clockNumber, string setValue);

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:PHASe:ADJust? to get the internal clock phase adjustment of the AWG
        /// </summary>
        /// <param name="clockNumber"></param>
        /// <returns></returns>
        string GetAwgClockPhaseAdjust(string clockNumber);

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:SOURce to set the source of the clock.
        /// </summary>
        /// <param name="clockNumber"></param>
        /// <param name="setValue"></param>
        void SetAwgClockSource(string clockNumber, string setValue);

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:SOURce? to get the source of the clock.
        /// </summary>
        /// <param name="clockNumber">One of the available clocks</param>
        string GetAwgClockSource(string clockNumber);

        //glennj 06/19/2013
        /// <summary>
        /// Using CLOCk:SOUT:STATe to set the state of the Sync Clock Out output
        /// </summary>
        /// <param name="clockNumber"></param>
        /// <param name="setValue"></param>
        void SetAwgClockSoutState(string clockNumber, string setValue);

        //glennj 06/19/2013
        /// <summary>
        /// Using CLOCk:SOUT:STATe? to get the state of the Sync Clock Out output
        /// </summary>
        /// <param name="clockNumber">One of the available clocks</param>
        string GetAwgClockSoutState(string clockNumber);

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:SRATe to set the sample rate for the given clock
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Sample Rate</param>
        void SetAwgClockSRate(string clockNumber, string setValue);

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:SRATe? to get the sample rate for the given clock
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <returns>Sample rate</returns>
        string GetAwgClockSRate(string clockNumber);

        #endregion PSR1

        #region PSR2

        //glennj 9/5/2013
        /// <summary>
        /// Using CLOCk:ECLock:DIVider to set the divider
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Divide by a power of 2</param>
        void SetAwgClockExternalDivider(string clockNumber, string setValue);

        //glennj 9/5/2013
        /// <summary>
        /// Using CLOCk:ECLock:DIVider? to get the divider setting
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <returns>The divider setting</returns>
        string GetAwgClockExternalDivider(string clockNumber);

        //glennj 06/10/2013
        /// <summary>
        /// Using CLOCk:ECLock:FREQuency to set expected frequency being provided by the external clock
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Frequency being provided by the external clock</param>
        void SetAwgClockExternalClockFrequency(string clockNumber, string setValue);

        //glennj 06/10/2013
        /// <summary>
        /// Using CLOCk:ECLock:FREQuency? to get expected frequency being provided by the external clock
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <returns>Frequency being provided by the external clock</returns>
        string GetAwgClockExternalClockFrequency(string clockNumber);

        //glennj 9/5/2013
        /// <summary>
        /// Using CLOCk:ECLock:FREQuency:ADJust to tell a specified clock to calibrate to the external clock
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        void AdjustAwgClockExternalClockFrequency(string clockNumber);

        //glennj 06/10/2013
        /// <summary>
        /// Using CLOCk:ECLock:FREQuency:DETect to tell the system to acquire the external clock and adjust the system to use it
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        void AwgClockExternalClockFrequencyAuto(string clockNumber);

        //glennj 06/07/2013
        /// <summary>
        /// Sets the multipler rate of the external clock
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Multipler rate of the external clock</param>
        void SetAwgClockExternalMultiplier(string clockNumber, string setValue);

        //glennj 06/07/2013
        /// <summary>
        /// Gets the multipler rate of the external clock.
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <returns>Multipler rate of the external clock</returns>
        string GetAwgClockExternalMultiplier(string clockNumber);

        #endregion PSR2

        #endregion Clock

        #region Control

        //glennj 7/17/2013
        /// <summary>
        /// Using AWGControl:CLOCk:DRATe, set the divider rate for the external clock<para>
        /// This is backward compatibile support only.  Use CLOCk:EREFerence:DIVider</para>
        /// </summary>
        /// <returns></returns>
        void SetAwgControlClockDividerRate(string clock, string value);

        // glennj 7/17/2013/2013
        /// <summary>
        /// Using AWGControl:CLOCk:DRATe?, get the divider rate for the external clock<para>
        /// This is backward compatibile support only.  Use CLOCk:EREFerence:DIVider?</para>
        /// </summary>
        /// <returns>"number of channels"</returns>
        string GetAwgControlClockDividerRate(string clock);

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:CLOCk:PHASe:ADJust, set the internal clock phase<para>
        /// This is backward compatibile support only.  Use CLOCk:PHASEe:ADJust</para>
        /// </summary>
        /// <returns></returns>
        void SetAwgControlClockPhaseAdjust(string value);

        // glennj 06/4/2013
        /// <summary>
        /// Using AWGControl:CLOCk:PHASe:ADJust?, get the internal clock phase<para>
        /// This is backward compatibile support only.  Use CLOCk:PHASEe:ADJust?</para>
        /// </summary>
        /// <returns>"number of channels"</returns>
        string GetAwgControlClockPhaseAdjust();

        // glennj 06/4/2013
        /// <summary>
        /// Returns the number of Channels
        /// </summary>
        /// <returns>"number of channels"</returns>
        string GetAwgControlConfCNum();

        #region AWGControl:DOUTput[n][:STATe]
        //jmanning 09/24/2014
        /// <summary>
        /// Using AWGControl:DOUTput[n][:STATe] enables the raw DAC waveform outputs for the specified channel.
        /// </summary>
        /// <param name="channel">specified output channel</param>
        /// <param name="boolState">Desired enabled state</param>
        void SetAwgControlDACState(string channel, string boolState);

        //jmanning 09/24/2014
        /// <summary>
        /// Using AWGControl:DOUTput[n][:STATe]? return the enable state for raw DAC waveform output for the specified channel.
        /// </summary>
        /// <param name="channel">specified output channel</param>
        /// <returns>state for raw DAC waveform output usage</returns>
        string GetAwgControlDACState(string channel);
        #endregion AWGControl:DOUTput[n][:STATe]
        
        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:INTerleave:ADJustment:AMPLitude set the interleave amplitude adjustment as a percentage of the analog output voltage.
        /// </summary>
        /// <param name="setValue"></param>
        void SetAwgInterleaveAdjustmentAmplitude(string setValue);

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:INTerleave:ADJustment:AMPLitude? get the interleave amplitude adjustment as a percentage of the analog output voltage.
        /// </summary>
        /// <returns></returns>
        string GetAwgInterleaveAdjustmentAmplitude();

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:INTerleave:ADJustment:PHASe set the interleave adjustment phase
        /// </summary>
        /// <param name="setValue"></param>
        void SetAwgInterleaveAdjustmentPhase(string setValue);

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:INTerleave:ADJustment:PHASe? get the interleave adjustment phase
        /// </summary>
        /// <returns></returns>
        string GetAwgInterleaveAdjustmentPhase();

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:RMODe set the run mode of the %AWG
        /// </summary>
        /// <param name="setValue">Desired run mode</param>
        void SetAwgRMode(string setValue);

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:RMODe? return the run mode of the %AWG
        /// </summary>
        /// <returns>Run Mode</returns>
        string GetAwgRMode();

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:RSTate? returns the state of the %AWG
        /// </summary>
        /// <returns>State of the %AWG</returns>
        string GetAwgRState();

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:RUN:IMMediate initiate the output of a waveform
        /// </summary>
        void AwgRunImmediate();

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:SNAMe? get the %AWG's most recently saved setup location
        /// </summary>
        /// <returns>Most recently saved setup location</returns>
        string GetAwgSName();

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:SREStore, load a setup as from a file
        /// </summary>
        /// <param name="filename">Path of the setup file</param>
        /// <param name="msus">>Mass storage unit specifier</param>
        void AwgSRestore(string filename, string msus);

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:SSAVe, save an %AWG setup as a file
        /// </summary>
        /// <param name="filename">Path of the setup file</param>
        /// <param name="msus">Mass storage unit specifier</param>
        void AwgSSave(string filename, string msus);

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:STOP:IMMediate, stop the requested AWG's output
        /// </summary>
        void AwgStopImmediate();

        #endregion Control

        #region Diagnostics


        //glennj 6/12/2013
        /// <summary>
        /// Sets the active mode
        /// </summary>
        /// <param name="command">Active mode selection of cal, diag, or norm</param>
        void SetAwgDiagActiveMode(string command);

        //glennj 6/12/2013
        /// <summary>
        /// Gets the active mode of diag, cal, or norm
        /// </summary>
        /// <returns>Current active mode</returns>
        string GetAwgDiagActiveMode();

        //glennj 6/12/2013
        /// <summary>
        /// Aborts Diagnostics
        /// </summary>
        void AbortAwgDiag();

        //glennj 6/12/2013
        /// <summary>
        /// Sends No-Op string to PI for use in debugging CallMonitor sessions (and whatever else you can think of)
        /// </summary>
        /// <param name="comment">The text string you want to see in the CallMonitor log</param>
        void AwgDiagComment(string comment);


        //glennj 06/07/2013
        /// <summary>
        /// Get the Manufacturing Mode of an %AWG
        /// 
        /// DIAGnostic:MMODe?
        /// </summary>
        /// <returns></returns>
        string GetAwgDiagManufacturingMode();

        //glennj 6/12/2013
        /// <summary>
        /// Sets the value of the loop count for diagnostics.
        /// </summary>
        /// <param name="setValue">Value of the loop count</param>
        void SetAwgDiagControlCount(string setValue);

        //glennj 6/12/2013
        /// <summary>
        /// Compares the value of the loop count for diagnostics.
        /// </summary>
        /// <returns>Current Diagnostic loop count</returns>
        string GetAwgDiagControlCount();

        //glennj 6/12/2013
        /// <summary>
        /// Sets the diagnostic loop setting 
        /// </summary>
        /// <param name="setting">Diagnostic loop setting</param>
        void SetAwgDiagControlLoop(string setting);

        //glennj 6/12/2013
        /// <summary>
        /// Gets the diagnostic loop setting  
        /// </summary>
        /// <returns>Current Diagnostic loop setting</returns>
        string GetAwgDiagControlLoop();

        //glennj 6/12/2013
        /// <summary>
        /// Gets results of last executed diagnostic test
        /// </summary>
        /// <returns>Result of last executed diagnostic test</returns>
        string GetAwgDiagData();

        void GetAwgDiagDelayInMSec(string delayInMSec);

        //glennj 6/12/2013
        /// <summary>
        /// Sets the value of halt for diagnostics.
        /// </summary>
        /// <param name="setValue">Halt value (OFF|ON)</param>
        void SetAwgDiagHalt(string setValue);

        //glennj 6/12/2013
        /// <summary>
        /// Gets the value of halt for diagnostics.
        /// </summary>
        /// <returns>Current Diagnostic halt state</returns>
        string GetAwgDiagHalt();

        //glennj 6/12/2013
        /// <summary>
        /// Executes all of the NORMal diagnostic tests
        /// </summary>
        void AwgDiagImmediate();

        //glennj 6/12/2013
        /// <summary>
        /// Executes the selected tests and returns the results in the form of a numeric of values of 0 
        /// for no errors or  -330 for one or more tests failed.
        /// </summary>
        /// <returns>Results from the diagnostics</returns>
        string AwgDiagImmediateQuery();

        #region DIAGnostic:CATalog

        //glennj 9/10/2013
        /// <summary>
        /// Using DIAG:CAT? get the diagnostic catalog
        /// </summary>
        /// <returns>List of tests per subsystem and/or area</returns>
        string GetAwgDiagCatalog(string subsystem, string area);

        #endregion DIAGnostic:CATalog

        //glennj 6/12/2013
        /// <summary>
        /// Gets the diagnostic log
        /// </summary>
        /// <returns>Diagnostic log</returns>
        string GetAwgDiagLog();

        //glennj 6/12/2013
        /// <summary>
        /// Clears the diagnostic log
        /// </summary>
        /// <returns>Diagnostic log</returns>
        void ClearAwgDiagLog();

        //glennj 6/12/2013
        /// <summary>
        /// Changes the diagnostics log to more or less detailed
        /// </summary>
        /// <param name="setState">Log detail flag value</param>
        void SetAwgDiagLogDetails(string setState);

        //glennj 6/12/2013
        /// <summary>
        /// Gets the diagnostics log detail flag value
        /// </summary>
        /// <returns>Log detail flag value</returns>
        string GetAwgDiagLogDetails();

        //glennj 6/12/2013
        /// <summary>
        /// Changes the diagnostics log to enable or disable failure mode
        /// </summary>
        /// <param name="setValue">Log detail flag value</param>
        void SetwgDiagLogFailuresOnly(string setValue);

        //glennj 6/12/2013
        /// <summary>
        /// Gets the diagnostics log failure mode
        /// </summary>
        /// <returns>Diagnostics log failure mode</returns>
        string GetAwgDiagLogFailuresOnly();


        #region DIAGnostic:LOOPs?

        //glennj 3/18/2014
        /// <summary>
        /// Using DIAGnostic:LOOPs? get the current diagnostic loop
        /// </summary>
        /// <returns>Completed Diagnostic Loops</returns>
        string GetAwgDiagLoops();

        #endregion DIAGnostic:LOOPs?

        //glennj 6/12/2013
        /// <summary>
        /// Gets the results of one or more tests 
        /// </summary>
        /// <returns>Diagnostic result</returns>
        string GetAwgDiagResult(string optionalSubsystem, string optionalArea = "", string optionalTest = "");

        //glennj 6/12/2013
        /// <summary>
        /// Gets the highest temperature during specified diag test.
        /// </summary>
        /// <param name="optionalSubsystem"></param>
        /// <param name="optionalArea"></param>
        /// <param name="optionalTest"></param>
        /// <returns>Temperature during specified diag test</returns>
        string GetAwgDiagResultTemp(string optionalSubsystem = "", string optionalArea = "", string optionalTest = "");

        //glennj 6/12/2013
        /// <summary>
        /// Gets the time during specified diag test.
        /// </summary>
        /// <param name="optionalSubsystem"></param>
        /// <param name="optionalArea"></param>
        /// <param name="optionalTest"></param>
        /// <returns>Time during specified diag test</returns>
        string GetAwgDiagResultTime(string optionalSubsystem = "", string optionalArea = "", string optionalTest = "");

        //glennj 6/12/2013
        /// <summary>
        /// Verifies that Diagnostic tests are currently running on the AWG
        /// </summary>
        /// <returns>Running state of diagnostics</returns>
        string GetAwgDiagRunning();

        //glennj 3/12/2014
        /// <summary>
        /// Selects diagnostic tests specified by the parameter list.
        /// 
        /// DIAGnostic:SELect
        /// </summary>
        /// <param name="requiredSubsystem">Valid subsystem name</param>
        /// <param name="optionalArea">Valid area name</param>
        /// <param name="optionalTest">Valid test name</param>
        void AwgDiagSelect(string requiredSubsystem, string optionalArea = "", string optionalTest = "");

        //glennj 3/12/2014
        /// <summary>
        /// Unselects diagnostic tests specified by the parameter list.
        /// 
        /// DIAGnostic:SELect
        /// </summary>
        /// <param name="requiredSubsystem">Valid subsystem name</param>
        /// <param name="optionalArea">Valid area name</param>
        /// <param name="optionalTest">Valid test name</param>
        void AwgDiagUnselect(string requiredSubsystem, string optionalArea = "", string optionalTest = "");

        //glennj 6/12/2013


        //glennj 3/12/2014
        /// <summary>
        /// Returns selected state for a diagnostic test as specified by the parameter list.
        /// 
        /// DIAGnostic:SELect:VERify?
        /// </summary>
        /// <param name="requiredSubsystem">Valid subsystem name</param>
        /// <param name="requiredArea">Valid area name</param>
        /// <param name="requiredTest">Valid test name</param>
        string GetAwgDiagSelectVerify(string requiredSubsystem, string requiredArea, string requiredTest);

        //glennj 6/12/2013
        /// <summary>
        /// Runs the %AWG Diagnostic
        /// </summary>
        void StartAwgDiag();

        //glennj 6/12/2013
        /// <summary>
        /// Stops the %AWG diagnostics after current test is complete
        /// </summary>
        void StopAwgDiagStop();

        //glennj 6/12/2013
        /// <summary>
        /// Gets the diagnostic stop state from the AWG
        /// </summary>
        /// <returns>Diag stop state</returns>
        string GetAwgDiagStopState();

        //glennj 6/12/2013
        /// <summary>
        /// Sets the type or context of the diagnostic tests on the AWG
        /// </summary>
        /// <param name="type">Category of available tests</param>
        void SetAwgDiagType(string type);

        //glennj 6/12/2013
        /// <summary>
        /// Gets the type or context of the diagnostic tests.
        /// </summary>
        /// <returns>Diagnostic type</returns>
        string GetAwgDiagType();

        //glennj 6/12/2013
        /// <summary>
        /// Verifies there are diagnostic type categories available.
        /// </summary>
        /// <returns>Diagnostic category type</returns>
        string GetAwgDiagTypeCategory();

        //glennj 6/11/2013
        /// <summary>
        /// Runs a POST and returns result
        /// </summary>
        /// <returns>POST status indicator</returns>
        string AwgTstQuery();

        #endregion Diagnostics

        #region Display

        //glennj 6/20/2013
        /// <summary>
        /// Using DISPlay:PLOT:STATe Sets the plot display state for a particular %AWG
        /// </summary>
        /// <param name="state">The state to set the Display Plot to</param>
        void SetAwgDisplayState(string state);

        //glennj 06/20/2013
        /// <summary>
        /// Using DISPlay:PLOT:STATe? get the plot display state of this AWG
        /// </summary>
        /// <returns></returns>
        string GetAwgDisplayState();

        #endregion Display

        #region FGen

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:AMPLitude set the amplitude value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Function generator amplitude value</param>
        void SetAwgFGenChannelAmplitude(string channel, string setValue);

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:AMPLitude? get the amplitude value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <returns>Function generator amplitude value</returns>
        string GetAwgFGenChannelAmplitude(string channel);

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:FREQuency set the frequency for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Function generator low value</param>
        void SetAwgFGenChannelFrequency(string channel, string setValue);

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:FREQuency? get the frequency for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        string GetAwgFGenChannelFrequency(string channel);

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:DCLevel set the DC Level value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Function generator dclevel value</param>
        void SetAwgFGenChannelDCLevel(string channel, string setValue);

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:DCLevel? get the DC Level value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <returns>Function generator DC Level value</returns>
        string GetAwgFGenChannelDCLevel(string channel);

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:HIGH set the high value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Function generator high value</param>
        void SetAwgFGenChannelHigh(string channel, string setValue);

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:HIGH? get the high value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <returns>Function generator high value</returns>
        string GetAwgFGenChannelHigh(string channel);

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:LOW set the low value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Function generator low value</param>
        void SetAwgFGenChannelLow(string channel, string setValue);

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:LOW? get the low value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <returns>Function generator low value</returns>
        string GetAwgFGenChannelLow(string channel);

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:OFFset set the offset value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Function generator offset value</param>
        void SetAwgFGenChannelOffset(string channel, string setValue);

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:OFFset? get the offset value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <returns>Function generator offset value</returns>
        string GetAwgFGenChannelOffset(string channel);

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:PERiod? get the period value for the given channel<para>
        /// (Query Only)</para>
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <returns>Function generator period value</returns>
        string GetAwgFGenChannelPeriod(string channel);

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:PHASe set the phase value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Function generator phase value</param>
        void SetAwgFGenChannelPhase(string channel, string setValue);

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:PHASe? get the phase value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <returns>Function generator phase value</returns>
        string GetAwgFGenChannelPhase(string channel);

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:SYMMetry set the symmetry value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">symmetry value</param>
        void SetAwgFGenChannelSymmetry(string channel, string setValue);

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:SYMMetry? get the symmetry value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <returns>Function generator symmetry value</returns>
        string GetAwgFGenChannelSymmetry(string channel);

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:TYPE set the waveform type for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Waveform type</param>
        void SetAwgFGenChannelType(string channel, string setValue);

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:TYPE? get the waveform type for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <returns>Function generator waveform type</returns>
        string GetAwgFGenChannelType(string channel);

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:COUPle:AMPLitude set the coupling amplitude Value
        /// </summary>
        /// <param name="setValue">FGen couple state</param>
        void SetAwgFGenCoupleAmpl(string setValue);

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:COUPle:AMPLitude? get the state of the coupling amplitude<para>
        /// For the 70k, the use of a channel is not valid and is ignored.</para><para>
        /// It is here for consistency.</para>
        /// </summary>
        /// <returns>Function Generator coupling frequency value</returns>
        string GetAwgFGenCoupleAmpl(string logicalChannel = "1");

        #region Postponed

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:COUPle:FREQeuncy set the coupling frequency state
        /// </summary>
        /// <param name="setValue">FGen couple state</param>
        void SetAwgFGenCoupleFreq(string setValue);

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:COUPle:FREQeuncy? get the state of the coupling frequency
        /// </summary>
        /// <returns>Function Generator coupling frequency value</returns>
        string GetAwgFGenCoupleFreq(string logicalChannel = "1");

        #endregion Postponed

        #endregion FGen

        #region GPIBUSB

        // glennj 7/23/2013
        /// <summary>
        /// Using GPIBUsb:SETADDress set the address of the GPIB adapter device<para>
        /// Note: Set command differs from Query, uses SETADDress instead of ADDress@n</para>
        /// </summary>
        /// <param name="address">Address of the GPIB adapter device</param>
        void SetAwgGPIBUsbAddress(int address);

        // glennj 7/23/2013
        /// <summary>
        /// Using GPIBUsb:ADDress? get the address of the GPIB adapter device
        /// </summary>
        /// <returns>Address of the GPIB adapter device</returns>
        string GetAwgGPIBUsbAddress();

        // glennj 7/23/2013
        /// <summary>
        /// Using GPIBUsb:HWVersion set the hardware version of the GPIB adapter device
        /// </summary>
        /// <param name="hwVersion">Hardware version of the GPIB adapter device</param>
        void SetAwgGPIBUsbHwVersion(string hwVersion);

        // glennj 7/23/2013
        /// <summary>
        /// Using GPIBUsb:HWVersion? get the hardware version of the GPIB adapter device
        /// </summary>
        /// <returns>Hardware version of the GPIB adapter device</returns>
        string GetAwgGPIBUsbHwVersion();

        // glennj 7/23/2013
        /// <summary>
        /// Using GPIBUsb:SETID set the ID of the GPIB adapter device<para>
        /// Note: Set command differs from Query, uses SETID instead of ID@n</para>
        /// </summary>
        /// <param name="id">ID of the GPIB adapter device</param>
        void SetAwgGPIBUsbId(string id);

        // glennj 7/23/2013
        /// <summary>
        /// Using GPIBUsb:ID? get the ID of the GPIB adapter device
        /// 
        /// </summary>
        /// <returns>ID of the GPIB adapter device</returns>
        string GetAwgGPIBUsbId();

        // glennj 7/23/2013
        /// <summary>
        /// Using GPIBUsb:STATus set the status of the GPIB adapter device
        /// </summary>
        /// <param name="status">Status of the GPIB adapter device</param>
        void SetAwgGpibUsbStatus(string status);

        // glennj 7/23/2013
        /// <summary>
        /// Using GPIBUsb:STATus? get the status of the GPIB adapter device
        /// </summary>
        /// <returns>Status of the GPIB adapter device</returns>
        string GetAwgGpibUsbStatus();

        #endregion GPIBUSB

        #region Mass Memory

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:CATalog? gets the current contents and state of the mass storage media.
        /// </summary>
        /// <param name="msus">Mass storage unit specifier</param>
        /// <returns>List of contents of the given mass storage in the format of: File name, file type, file size </returns>
        string GetAwgMemoryCatalog(string msus);

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:CDIRectory set the current directory of the %AWG not including the msus.
        /// </summary>
        /// <param name="path">Current directory path</param>
        void SetAwgMemoryCDirectory(string path);

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:CDIRectory? get the current directory of the %AWG not including the msus.
        /// </summary>
        /// <returns>Current directory path</returns>
        string GetAwgMemoryCDirectory();

        //glennj 6/20/2013
        /// <summary>
        /// Using  MMEMory:DATA to write data onto the %AWG hard disk
        /// </summary>
        /// <param name="filePath">The path to write to</param>
        /// <param name="startPosition">The position to start writing at</param>
        /// <param name="blockData">The data to write</param>
        void SetAwgMemoryData(string filePath, string startPosition, string blockData);

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:DATA? tries to read data from the %AWG hard disk and store the information in the %AWG object
        /// </summary>
        /// <param name="filePath">The path to read from</param>
        /// <param name="startPosition">The position to start reading from</param>
        /// <param name="dataSize">The size to read</param>
        string GetAwgMemoryData(string filePath, string startPosition, string dataSize = "");

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:DATA:SIZE? gets the size in bytes of the given file
        /// </summary>
        /// <param name="filePath">Path of the file to be sized</param>
        /// <returns>Size of the file in bytes</returns>
        string GetAwgMemoryDataSize(string filePath);

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:DELete delete a file or directory from the %AWG's hard disk
        /// </summary>
        /// <param name="fileName">File or directory path to be deleted</param>
        /// <param name="msus">Mass storage unit specifier</param>
        void DeleteAwgMemory(string fileName, string msus);

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:IMPort imports a file
        /// </summary>
        /// <param name="wfmName">Desired waveform to import</param>
        /// <param name="wfmType">waveform type</param>
        /// <param name="fileName">file name</param>
        void ImportAwgMemory(string wfmName, string wfmType, string fileName);

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:IMPort:PARameter:NORMalize sets a normalization mode for import
        /// </summary>
        /// <param name="waveform">Desired waveform to import</param>
        void SetAwgMemoryImportNormalize(string waveform);

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:IMPort:PARameter:NORMalize? gets normalization mode for open
        /// </summary>
        /// <returns>Whether the imported waveform was actually normalized</returns>
        string GetAwgMemoryImportNormalize();

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:MDIRectory creates a new directory in the current path.
        /// </summary>
        /// <param name="directoryName"></param>
        void AwgMemoryMDirectory(string directoryName);


        //jmanning 9/04/2014
        /// <summary>
        /// Using MMEMory:MROPened[:WAVeforms]? gets the recently opened waveforms
        /// </summary>
        /// <returns>Names of waveforms recently opened</returns>
        string GetAwgMemoryRecentWaveformsOpened();


        //jmanning 9/04/2014
        /// <summary>
        /// Using MMEMory:MROPened:SEQuences? gets the recently opened sequences
        /// </summary>
        /// <returns>Names of sequences recently opened</returns>
        string GetAwgMemoryRecentSequencesOpened();

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:MSIS sets the mass storage device used by all the MEMMory commands.
        /// </summary>
        /// <param name="drive">Drive letter</param>
        void SetAwgMemoryDrive(string drive);

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:MSIS? gets the mass storage device used by all the MMEmory commands
        /// </summary>
        /// <returns>Drive letter</returns>
        string GetAwgMemoryMsis();

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:OPEN opens a waveform
        /// </summary>
        /// <param name="fileName">file name</param>
        void OpenAwgMemory(string fileName);

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:OPEN:PARameter:NORMalize sets a normalization mode for open
        /// </summary>
        /// <param name="waveform">Whether the opened waveform was actually normalized</param>
        void SetAwgMemoryOpenNormalize(string waveform);

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:OPEN:PARameter:NORMalize? gets the normalization mode for open
        /// </summary>
        /// <returns>Whether the imported waveform was actually normalized</returns>
        string GetAwgMemoryOpenNormalize();

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:OPEN:SASSet opens desired waveforms from an .AWG file or a native setup file into the arbitrary waveform generator’s assets.
        /// </summary>
        /// <param name="fileName">Path to the Setup file</param>
        /// <param name="desiredWfm">Optional names of a desired waveforms to open</param>
        void OpenAwgMemorySasset(string fileName, string desiredWfm);

        //shkv 11/21/2013
        /// <summary>
        /// Using MMEMory:OPEN opens desired waveforms from an .AWG file or a native setup file into the arbitrary waveform generator’s assets.
        /// </summary>
        /// <param name="fileName">Path to the Setup file</param>
        /// <param name="desiredWfm">Optional names of a desired waveforms to open</param>
        void OpenAwgMemory(string fileName, string desiredWfm);

        //glennj 8/8/2013
        /// <summary>
        /// Using MMEMory:OPEN:SASSetSEQuence: opens all or a desired sequence
        /// </summary>
        /// <param name="filePath">Path to the Setup file</param>
        /// <param name="desiredSequence">Optional names of a desired waveforms to open</param>
        void OpenAwgMemorySassetSequence(string filePath, string desiredSequence);

        /// <summary>
        /// Using MMEMory:OPEN:SASSet:SEQuence:MROPened? gets the most recently opened sequence name
        /// </summary>
        /// <returns>Name of sequence most recently opened</returns>
        string GetAwgMemoryMostRecentSequenceOpened();
        
        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:OPEN:SETup opens a setup file
        /// </summary>
        /// <param name="fileName">The name of the file to open</param>
        void OpenAwgMemorySetup(string fileName);

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:OPEN:TXT opens a text file.
        /// </summary>
        /// <param name="fileName">Path of the text file</param>
        /// <param name="bitDepth">OPTIONAL: The bit depth of the text file required for digital</param>
        void OpenAwgMemoryTxt(string fileName, string bitDepth);

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:SAVE:SETup saves the current state of the AWG as a setup file
        /// </summary>
        /// <param name="filepath">Path to save the setup file</param>
        /// <param name="wAssets">Flag for including assets with the setup file</param>
        void SaveAwgMemorySetup(string filepath, string wAssets);

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:SAVE:TXT saves the given asset as a TXT file
        /// </summary>
        /// <param name="assetName">Name of the asset to saved</param>
        /// <param name="filepath">New name and place to save the TXT file</param>
        /// <param name="fileType">Type of the text file to be saved</param>
        void SaveAwgMemoryTXT(string assetName, string filepath, string fileType);

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:SAVE:WFMX saves the given asset as a WFMX file
        /// </summary>
        /// <param name="assetName">Name of the file to saved</param>
        /// <param name="filepath">New name and place to save the WFMX file</param>
        void SaveAwgMemoryWFMX(string assetName, string filepath);


        //sforell 9/9/13 added interface definition
        /// <summary>
        /// Using MMEMory:SAVE:SEQX saves the given asset as a SEQX file
        /// </summary>
        /// <param name="assetName">Name of the file to saved</param>
        /// <param name="filepath">New name and place to save the SEQX file</param>
        void SaveAwgMemorySEQX(string assetName, string filepath);

        #endregion Mass Memory

        #region Output
        //jmanning 09/22/2014
        /// <summary>
        /// Using OUTPut[n]:FILTer sets the filter type of the of the selected signal path
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="filterType">Type of Filter [NONE|BPASs|LPASs]</param>
        void SetAwgOutputFilter(string outputIndex, string filterType);

        //jmanning 09/22/2014
        /// <summary>
        /// Using OUTPut[n]:FILTer? gets the filter type of the of the selected signal path
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <returns> Type of Filter [NONE|BPASs|LPASs]</returns>
        string GetAwgOutputFilter(string outputIndex);

        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:A1 sets the step value setting for a specified attenuator of a channel in units of steps.
        /// This is a blocking and unpublished command
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="filterStepValue">step increment value</param>
        void SetAwgOutputFilterAttenuatorA1Step(string outputIndex, string filterStepValue);

        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:A1? gets the step value setting for a specified attenuator of a channel in units of steps.
        /// This is a blocking and unpublished command
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <returns>step increment value</returns>
        string GetAwgOutputFilterAttenuatorA1Step(string outputIndex);

        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:A2 sets the step value setting for A2attenuator of a channel in units of steps.
        /// This is a blocking and unpublished command
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="filterStepValue">step increment value</param>
        void SetAwgOutputFilterAttenuatorA2Step(string outputIndex, string filterStepValue);

        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:A2? gets the step value setting for A2 attenuator of a channel in units of dB.
        /// This is a blocking and unpublished command
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <returns>step increment value</returns>
        string GetAwgOutputFilterAttenuatorA2Step(string outputIndex);

        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:A3 sets the step value setting for A3 attenuator of a channel in units of dB.
        /// This is a blocking and unpublished command
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="filterStepValue">step increment value</param>
        void SetAwgOutputFilterAttenuatorA3Step(string outputIndex, string filterStepValue);

        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:A3? gets the step value setting for A3 attenuator of a channel in units of dB.
        /// This is a blocking and unpublished command
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <returns>step increment value</returns>
        string GetAwgOutputFilterAttenuatorA3Step(string outputIndex);

        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:DAC sets the step value setting for Dac attenuator of a channel in units of dBm.
        /// This is a blocking and unpublished command
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="filterStepValue">step increment value</param>
        void SetAwgOutputFilterAttenuatorDACStep(string outputIndex, string filterStepValue);

        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:DAC? gets the step value setting for Dac attenuator of a channel in units of dBm.
        /// This is a blocking and unpublished command
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <returns>step increment value</returns>
        string GetAwgOutputFilterAttenuatorDACStep(string outputIndex);

        //shkv 1/8/2015 Added fix for 5168
        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:FILTer:BPASs:RANGe selects the band pass filter range
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="filterRange">Type of Filter Range</param>
        void SetAwgOutputFilterBandPassRangeR10to14GHz(string outputIndex, string filterRange);
        void SetAwgOutputFilterBandPassRangeR13to18GHz(string outputIndex, string filterRange);

        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:FILTer:BPASs:RANGe? gets the band pass filter range
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <returns>Type of Filter Path</returns>
        string GetAwgOutputFilterBandPassRange(string outputIndex);

        //jmanning 09/22/2014
        /// <summary>
        /// Using OUTPut[n]:MODE sets the signal path [DIRect|AC]
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="signalPath">Signal Path Type of Filter [DIRect|AC]</param>
        void SetAwgOutputMode(string outputIndex, string signalPath);

        //jmanning 09/22/2014
        /// <summary>
        /// Using OUTPut[n]:MODE? gets the signal path [DIRect|AC]
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <returns> Signal Path Type of Filter [DIRect|AC]</returns>
        string GetAwgOutputMode(string outputIndex);
        
        //glennj 7/11/2013
        /// <summary>
        /// Using OUTPut:OFF set whether or not the "All Outputs Off" has been enabled
        /// </summary>
        /// <param name="value">Output off state to be set to</param>
        void SetAwgOutputOff(string value);

        //glennj 7/11/2013
        /// <summary>
        /// Using OUTPut:OFF get the "All Outputs Off" state
        /// </summary>
        /// <returns>Output off state</returns>
        string GetAwgOutputOff();

        //glennj 7/11/2013
        /// <summary>
        /// Using OUTPut[n][:STATe] set the output state of the arbitrary waveform generator.
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="value"></param>
        void SetAwgOutputState(string channel, string value);

        //glennj 7/11/2013
        /// <summary>
        /// Using OUTPut[n][:STATe]? get the output state of the arbitrary waveform generator.
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <returns></returns>
        string GetAwgOutputState(string channel);

        //glennj 7/11/2013
        /// <summary>
        /// Using OUTPut[n]:SVALue[:ANAlog:][STATe] set the output data position of a waveform while the instrument is in the stop state
        /// </summary>
        /// <param name="channel">Which %AWG machine number</param>
        /// <param name="value">Output data position of a waveform</param>
        void SetAwgOutputStopAnalogState(string channel, string value);

        //glennj 7/11/2013
        /// <summary>
        /// Using OUTPut[n]:SVALue[:ANAlog:][STATe]? get the output data position of a waveform while the instrument is in the stop state
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <returns>Output data position of a waveform</returns>
        string GetAwgOutputStopAnalogState(string channel);

        //glennj 7/11/2013
        /// <summary>
        /// Using OUTPut[n]:STOP:MARKer[n]:STATe set the output data position of a marker while the instrument is in the stop state
        /// </summary>
        /// <param name="channel">Which channel number</param>
        /// <param name="marker">Which marker number</param>
        /// <param name="value">Output data position of a waveform</param>
        void SetAwgOutputStopMarkerState(string channel, string marker, string value);

        //glennj 7/11/2013
        /// <summary>
        /// Using OUTPut[n]:STOP:MARKer[n]:STATe? get the output data position of a marker while the instrument is in the stop state
        /// </summary>
        /// <param name="channel">Which channel number</param>
        /// <param name="marker">Which marker number</param>
        /// <returns>Output data position of a waveform</returns>
        string GetAwgOutputStopMarkerState(string channel, string marker);

        //glennj 7/11/2013
        /// <summary>
        /// Using OUTPut[n]:WVALue[:ANALog][:STATe set the output data position of a waveform while the instrument is in the waiting-for-trigger state
        /// </summary>
        /// <param name="channel">Which %AWG machine number</param>
        /// <param name="value">Output data position of a waveform</param>
        void SetAwgOutputWValueAnalogState(string channel, string value);

        //glennj 7/11/2013
        /// <summary>
        /// Using OUTPut[n]:WVALue[:ANALog][:STATe]? get the output data position of a waveform while the instrument is in the waiting-for-trigger state
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <returns>Output data position of a waveform</returns>
        string GetAwgOutputWValueAnalogState(string channel);

        //glennj 7/11/2013
        /// <summary>
        /// Using OUTPut[n]:WVALue[:ANALog][:STATe] set the output data position of a marker while the instrument is in the waiting-for-trigger state
        /// </summary>
        /// <param name="channel">Which channel number</param>
        /// <param name="marker">Which marker number</param>
        /// <param name="value">Output data position of a waveform</param>
        void SetAwgOutputTriggerMarkerState(string channel, string marker, string value);

        //glennj 7/11/2013
        /// <summary>
        /// Using OUTPut[n]:WVALue[:ANALog][:STATe]? get the output data position of a marker while the instrument is in the waiting-for-trigger state
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="marker">Which marker number</param>
        /// <returns>Output data position of a waveform</returns>
        string GetAwgOutputTriggerMarkerState(string channel, string marker);

        #endregion Output

        #region Instrument

        //glennj 06/20/2013
        /// <summary>
        /// Using INSTrument:COUPle:SOURce set the instrument couple source mode of this %AWG
        /// </summary>
        /// <param name="setValue">Desired mode</param>
        void SetAwgInstrumentCoupleSource(string setValue);

        //glennj 06/20/2013
        /// <summary>
        /// Using INSTrument:COUPle:SOURce? get the instrument couple source mode of this %AWG
        /// </summary>
        /// <returns>Run Mode</returns>
        string GetAwgInstrumentCoupleSource();

        //glennj 06/20/2013
        /// <summary>
        /// Using INSTrument:MODE set the %AWG instrument mode between AWG or FGen mode
        /// </summary>
        /// <param name="setValue">The desired instrument mode</param>
        void SetAwgInstrumentMode(string setValue);

        //glennj 06/20/2013
        /// <summary>
        /// Using INSTrument:MODE? get the current instrument mode of this %AWG
        /// </summary>
        /// <returns>Current instrument mode</returns>
        string GetAwgInstrumentMode();

        #endregion Instrument

        #region Sequence

        #region SLIST 

        #region SLISt:NAME

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:NAME? get the name of the sequence of an element in the sequence list
        /// </summary>
        /// <param name="listIndex">Index of the sequence in the sequence list</param>
        /// <returns>The name of the waveform</returns>
        string GetAwgSlistName(string listIndex);

        #endregion SLISt:NAME

        #region SLISt:SEQuence:DELete

        //glennj 8/9/2013
        /// <summary>
        /// Using SLIST:SEQuence:DELete delete the sequence from the sequence list
        /// </summary>
        /// <param name="seqName">Name of the sequence to delete</param>
        /// <param name="addQuotes">strings need quotes, keywords such as ALL don't</param>
        void DeleteAwgSListSequence(string seqName, bool addQuotes);

        #endregion SLISt:SEQuence:DELete

        #region SLISt:SEQuence:EVENt:PJUMp:ENABle

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:EVENt:PJUMp:ENABle set the event pattern jump enable
        /// </summary>
        void SetAwgSequenceEventPatternJumpEnable(string seqName, string enableState);

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:EVENt:PJUMp:ENABle? get the event pattern jump enable
        /// </summary>
        /// <returns>event pattern jump enable</returns>
        string GetAwgSequenceEventPatternJumpEnable(string seqName);

        #endregion SLISt:SEQuence:EVENt:PJUMp:ENABle

        #region SLISt:SEQuence:EVENt:PJUMp:DEFine

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:EVENt:PJUMp:DEFine associate an event pattern<para>
        /// with the jumpe to step for Pattern Jump</para>
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="pattern"></param>
        /// <param name="jumpStep"></param>
        void SetAwgSequenceEventPatternJumpDefine(string seqName, string pattern, string jumpStep);

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:EVENt:PJUMp:DEFine? get the jump step associated to the specified pattern
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="pattern"></param>
        /// <returns>event pattern jump enable</returns>
        string GetAwgSequenceEventPatternJumpDefine(string seqName, string pattern);

        #endregion SLISt:SEQuence:EVENt:PJUMp:DEFine

        #region SLISt:SEQuence:EVENt:PJUMp:SIZE

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:EVENt:PJUMp:SIZE? get the maximum number of entries in the pattern jump table
        /// </summary>
        /// <returns>event pattern jump enable</returns>
        string GetAwgSequenceEventPatternJumpSize();

        #endregion SLISt:SEQuence:EVENt:PJUMp:SIZE

        #region SLISt:SEQuence:EVENt:JTIMing

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:EVENt:JTIMing sets how the sequencer<para>
        /// will respond to a logic event, pattern jump or a software</para><para>
        /// force jump.</para>
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="mode">of END or IMMediate</param>
        void SetAwgSequenceEventPatternJumpTiming(string seqName, string mode);

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:EVENt:JTIMing? get the mode for how the sequencer<para>
        /// will respond to a logic event, pattern jump or a software</para><para>
        /// force jump.</para>
        /// </summary>
        /// <param name="seqName"></param>
        /// <returns>event pattern jump enable</returns>
        string GetAwgSequenceEventPatternJumpTiming(string seqName);

        #endregion SLISt:SEQuence:EVENt:JTIMing

        #region SLISt:SEQuence:LENGth

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:LENGth? get the length of the named sequence.
        /// </summary>
        /// <returns>length of named sequence</returns>
        string GetAwgSequenceLength(string seqName);

        #endregion SLISt:SEQuence:LENGth

        #region SLISt:SEQuence:NEW

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:NEW create a new sequence of the given size and the given name
        /// </summary>
        /// <param name="seqName">Name of the new sequence</param>
        /// <param name="size">Save of the new sequence</param>
        /// <param name="tracks">optional specified number of 1-8</param>
        void CreateAwgSListSequenceNew(string seqName, string size, string tracks = "");

        #endregion SLISt:SEQuence:NEW

        #region SLISt:SEQuence:RFLag

        /// <summary>
        /// Using SLISt:SEQuence:STEP:RFlag set the enable flag repeat on or off
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="mode">ON|OFF|0|1</param>
        void SetAwgSequenceRepeatFlag(string seqName, string mode);

        /// <summary>
        /// Using SLISt:SEQuence:STEP:RFlag?  gets the enable flag repeat state on or off
        /// </summary>
        /// <param name="seqName"></param>
        /// <returns>state of enable flag repeat setting</returns>
        string GetAwgSequenceRepeatFlag(string seqName);

        #endregion SLISt:SEQuence:RFLag

        #region SLISt:SEQuence:STEP:EJUMp

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:EJUMp set the step or step action for the<para>
        /// sequencer's event jump operation.</para>
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="mode">NR1|NEXT|FIRSt|LAST|END</param>
        /// <param name="step">Step from 1 to 16383</param>
        void SetAwgSequenceStepEventJumpOperation(string seqName, string mode, string step);

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:EJUMp? get the step or step action for the<para>
        /// sequencer's event jump operation.</para>
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="step">Step from 1 to 16383</param>
        /// <returns>event jump operation mode</returns>
        string GetAwgSequenceStepEventJumpOperation(string seqName, string step);

        #endregion SLISt:SEQuence:STEP:EJUMp

        #region SLISt:SEQuence:STEP:EJINput

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:EJINput selects the event jump input
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="step">Step from 1 to 16383</param>
        /// <param name="mode">ATRigger|BTRigger|OFF</param>
        void SetAwgSequenceStepEventJumpInput(string seqName, string step, string mode);

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:EJINput? get the selected event jump input
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="step">Step from 1 to 16383</param>
        /// <returns>event jump operation mode</returns>
        string GetAwgSequenceStepEventJumpInput(string seqName, string step);

        #endregion SLISt:SEQuence:STEP:EJINput

        #region SLISt:SEQuence:STEP:GOTO

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP[n]:GOTO set the target step for the GOTO command<para>
        /// of the sequencer at the current step</para>
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="step">Step from 1 to 16383</param>
        /// <param name="mode">nr1|LAST|FIRSt|NEXT|END</param>
        void SetAwgSequenceStepGoto(string seqName, string step, string mode);

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:GOTO? get the target step for the GOTO command<para>
        /// of the sequencer at the current step</para>
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="step"></param>
        /// <returns>event jump operation mode</returns>
        string GetAwgSequenceStepGoto(string seqName, string step);

        #endregion SLISt:SEQuence:STEP:GOTO

        #region SLISt:SEQuence:STEP:MAX

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:MAX? get maximum number of steps allowed in a sequence
        /// </summary>
        /// <returns>maximum number of steps allowed as an nr1</returns>
        string GetAwgSequenceStepMax();

        #endregion SLISt:SEQuence:STEP:MAX

        #region SLISt:SEQuence:STEP:RCOunt

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:RCOunt set the repeat count
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="step">Step from 1 to 16383</param>
        /// <param name="mode">nr1|ONCE|INFinite</param>
        void SetAwgSequenceStepRepeatCount(string seqName, string step, string mode);

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:RCOunt? get the repeat count
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="step">Step from 1 to 16383</param>
        /// <returns>repeat mode or count</returns>
        string GetAwgSequenceStepRepeatCount(string seqName, string step);

        #endregion SLISt:SEQuence:STEP:RCOunt

        #region SLISt:SEQuence:STEP:RCOunt:MAX

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:RCOunt:MAX? get maximum number of repeat count allowed
        /// </summary>
        /// <returns>returns nr1 for max repeat counts</returns>
        string GetAwgSequenceStepRepeatCountMax();

        #endregion SLISt:SEQuence:STEP:RCOunt:MAX

        #region SLISt:SEQuence:STEP:TASSet

        //glennj 8/16/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:TASSet? get the waveform name at the specified step and track
        /// </summary>
        /// <returns>returns nr1 for max repeat counts</returns>
        string GetAwgSequenceStepTrackAsset(string seqName, string step, string track);

        #endregion SLISt:SEQuence:STEP:TASSet

        #region SLISt:SEQuence:STEP:TASSet:SEQuence

        // jmanning 04/09/2014-PASCAL PSR3
        /// <summary>
        /// Using SLISt:SEQuence:STEP:TASSet:SEQuence set a sequence to a step(as a subsequence) and of a sequence
        /// Note:  Applies to all tracks in the sequence
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="stepNumber"></param>
        /// <param name="subSeqName"></param>
        void SetAwgSequenceStepTrackAssetForSequence(string seqName, string stepNumber, string subSeqName);

        #endregion SLISt:SEQuence:STEP:TASSet:SEQuence

        #region SLISt:SEQuence:STEP:TASSet:TYPE

        // jmanning 04/09/2014-PASCAL PSR3
        /// <summary>
        /// Using SLISt:SEQuence:STEP[n]:TASSet[m]:TYPE? get the type of asset assigned to the specified step and track
        /// </summary>
        /// <returns>returns asset type (WAVeform|SEQuence)</returns>
        string GetAwgSequenceStepTrackAssetType(string seqName, string step, string track);

        #endregion SLISt:SEQuence:STEP:TASSet:TYPE

        #region SLISt:SEQuence:STEP:TASSet:WAVeform

        //glennj 8/16/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:TASSet:WAVeform set a wfm to a step and track of a sequence
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="stepNumber"></param>
        /// <param name="trackNumber"></param>
        /// <param name="wfmName"></param>
        void SetAwgSequenceStepTrackAssetForWaveform(string seqName, string stepNumber, string trackNumber,
            string wfmName);

        #endregion SLISt:SEQuence:STEP:TASSet:WAVeform

        #region SLISt:SEQuence:STEP[n]:TFLag[m]:[ALPHA]FLAG

        // jmanning 04/09/2014-PASCAL PSR3
        /// <summary>
        /// Using SLISt:SEQuence:STEP:TFLag[m]:[APLHA]FLAG set a flag value of the track in a specific sequence step for the specified flag
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="stepNumber"></param>
        /// <param name="trackNumber"></param>
        /// <param name="flagAlpha">four flags can be set (A|B|C|D)FLAG</param>
        /// <param name="flagSetting">flag settings are (NOCHANGE|HIGH|LOW|TOGGLE|PULSE)</param>
        void SetAwgSequenceStepTrackFlagValue(string seqName, string stepNumber, string trackNumber, string flagAlpha,
            string flagSetting);

        // jmanning 04/09/2014-PASCAL PSR3
        /// <summary>
        /// Using SLISt:SEQuence:STEP:TFLag[m]:[ALPHA]FLAG? gets value of flag for the track in a specific sequence step for the specified flag
        /// </summary>
        /// <returns>returns flag value (NOCHANGE|HIGH|LOW|TOGGLE|PULSE)</returns>
        string GetAwgSequenceStepTrackFlagValue(string seqName, string stepNumber, string trackNumber, string flagAlpha);

        #endregion SLISt:SEQuence:STEP[n]:TFLag[m]:[ALPHA]FLAG

        #region SLISt:SEQuence:STEP:TRACk:MAX

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:TRACk:MAX? get maximum number of tracks allowed in a sequence
        /// </summary>
        /// <returns>returns nr1 for max tracks</returns>
        string GetAwgSequenceStepTrackCountMax();

        #endregion SLISt:SEQuence:STEP:TRACk:MAX

        #region SLISt:SEQuence:STEP:WAVeform

        // obsolete and replaces by SLISt:SEQuence:STEP:TASSet commands and queries

        #endregion SLISt:SEQuence:STEP:WAVeform

        #region SLISt:SEQuence:STEP:WINPut

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP[n]:WINPut selects the mode to<para>
        /// listen for trigger signal</para>
        /// </summary>
        /// <param name="seqName">The named sequence</param>
        /// <param name="step">Step from 1 to 16383</param>
        /// <param name="mode">ATRigger|BTRigger|OFF</param>
        void SetAwgSequenceStepWaitInput(string seqName, string step, string mode);

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP[n]:WINPut? get the selected the name of<para>
        /// the waveform at the chosen step.</para>
        /// </summary>
        /// <param name="seqName">The named sequence</param>
        /// <param name="step">Step from 1 to 16383</param>
        /// <returns>wait input mode for a step of a sequence</returns>
        string GetAwgSequenceStepWaitInput(string seqName, string step);

        #endregion SLISt:SEQuence:STEP:WINPut

        #region SLISt:SEQuence:TRACks

        //glennj 8/15/2013
        /// <summary>
        /// Using SLISt:SEQuence:TRACks? get the number of tracks of the named sequence.
        /// </summary>
        /// <returns>timestamp of named sequence</returns>
        string GetAwgSequenceTracks(string seqName);

        #endregion SLISt:SEQuence:TRACks

        #region SLISt:SEQuence:TSTamp

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:TSTamp? get the timestamp of the named sequence.
        /// </summary>
        /// <returns>timestamp of named sequence</returns>
        string GetAwgSequenceTimestamp(string seqName);

        #endregion SLISt:SEQuence:TSTamp

        #region SLISt:SIZE

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SIZE? get the size of the sequence list.
        /// </summary>
        /// <returns>Size of the sequence list</returns>
        string GetAwgSlistSize();

        #endregion SLISt:SIZE

        #region SLISt:SEQuence:STEP:ADD

        //Keerthi 06/01/2015
        /// <summary>
        /// Using SLISt:SEQuence:STEP:ADD Add steps to the sequence
        /// </summary>
        /// <param name="addToSeqStep">Add how many steps to the sequence</param>
        /// <param name="addAtWhatStep">Add at what step</param>
        /// <param name="seqName">Name of the sequence</param>

        void AddStepToSlistSequence(string addToSeqStep, string addAtWhatStep, string seqName);

        #endregion SLISt:SEQuence:STEP:ADD

        #endregion SLIST

        #endregion Sequence

        #region Source

        #region SOURce[n]:CASSet

        //glennj 8/22//2013
        /// <summary>
        /// Using SOURce[n]:CASSet? get the asset assigned to a channel
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        string GetAwgSourceChannelAsset(string channel);

        #endregion SOURce[n]:CASSet

        #region SOURce[n]:CASSet:SEQuence

        //glennj 8/22/2013
        /// <summary>
        /// Using SOURce[n]:CASSet:SEQuence assign an asset of a track of a sequence to a channel
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="seqName"></param>
        /// <param name="trackNumber"></param>
        void SetAwgSourceChannelAssetSequence(string channel, string seqName, string trackNumber);

        #endregion SOURce[n]:CASSet:SEQuence

        #region SOURce[n]:CASSet:TYPE

        //glennj 8/22/2013
        /// <summary>
        /// Using SOURce:CASSet:TYPE?, get the type of the asset assigned to a channel
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        string GetAwgSourceChannelAssetType(string channel);

        #endregion SOURce[n]:CASSet:TYPE

        #region SOURce[n]:CASSet:WAVeform

        //glennj 8/22/2013
        /// <summary>
        /// Using SOURce:CASSet:WAVeform assign a waveform to a channel
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="wfmName"></param>
        void SetAwgSourceChannelAssetWaveform(string channel, string wfmName);

        #endregion SOURce[n]:CASSet:WAVeform

        #region PSR2

        #region SOURce[1]]:FREQuency

        //glennj 7/17/2013
        /// <summary>
        /// Using [SOURce[1]]:FREQuency set the sampling frequency for the desired clock channel
        /// </summary>
        /// <param name="clockNumber"></param>
        /// <param name="setValue"></param>
        void SetAwgSourceFrequency(string clockNumber, string setValue);

        //glennj 7/17/2013
        /// <summary>
        /// Using [SOURce[1]]:FREQuency get the sampling frequency for the desired clock channel
        /// </summary>
        /// 
        /// <param name="clockNumber"></param>
        /// <returns></returns>
        string GetAwgSourceFrequency(string clockNumber);

        #endregion SOURce[1]]:FREQuency

        #endregion PSR2

        #region SOURCE[n]:DAC:RESOLUTION

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURCE[n]:DAC:RESOLUTION set the DAC resolution on a specified channel
        /// </summary>
        /// <param name="channel">Channel desired to set DAC resolution for</param>
        /// <param name="resolution">Resolution of the DAC</param>
        void SetAwgSourceDacResolution(string channel, string resolution);

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURCE[n]:DAC:RESOLUTION? get the DAC resolution on a specified channel
        /// </summary>
        /// <param name="channel">Channel desired to read DAC resolution</param>
        /// <returns>DAC Resolution</returns>
        string GetAwgSourceDacResolution(string channel);

        #endregion SOURCE[n]:DAC:RESOLUTION

        #region SOURce[n]:POWer:AMPLitude
        //jmanning 09/24/2013
        /// <summary>
        /// Using SOURce[n]:POWer:AMPLitude set the Source Power Amplitude
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <param name="setValue">Source Amplitude</param>
        void SetAwgSourcePowerAmplitude(string channel, string setValue);

        //jmanning 09/24/2013
        /// <summary>
        /// Using SOURce[n]:POWer:AMPLitude? get the Source Power Amplitude
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <returns>Source Power Amplitude</returns>
        string GetAwgSourcePowerAmplitude(string channel);
        #endregion SOURce[n]:POWer:AMPLitude

        #region SOURce[n]:FLAG[ALPHA]

        //jmanning 04/09/2014-NEW PSR3
        /// <summary>
        /// Using SOURce[n]:FLAG[ALPHA][:STAte] to set on or off status to specified flag
        /// </summary>
        /// <param name="sourceNum"></param>
        /// <param name="flagAlpha"></param>
        /// <param name="flagState"></param>
        void SetAwgSourceFlagState(string sourceNum, string flagAlpha, string flagState);

        //jmanning 04/09/2014-NEW PSR3
        /// <summary>
        /// Using SOURce[n]:FLAG[ALPHA][:STAte]? to get on or off status to specified flag
        /// </summary>
        /// <param name="sourceNum"></param>
        /// <param name="flagAlpha"></param>
        /// <returns>flagState</returns>
        string GetAwgSourceFlagState(string sourceNum, string flagAlpha);

        #endregion SOURce[n]:FLAG[ALPHA]

        #region SOURce:JUMP:FORCe

        //glennj 8/23/2013
        /// <summary>
        /// Using SOURce:JUMP:FORCE, force a running sequence to jump to First, Current, Last, End or a specified step
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="forceJumpType"></param>
        void ForceAwgSourceChannelJump(string channel, string forceJumpType);

        #endregion SOURce:JUMP:FORCe

        #region SOURce:JUMP:PATTern:FORCe

        //glennj 8/23/2013
        /// <summary>
        /// Using SOURce:JUMP:PATTern:FORCE, force a running sequence to jump to with a pattern match
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="forceJumpPattern"></param>
        void ForceAwgSourceChannelJumpPattern(string channel, string forceJumpPattern);

        #endregion SOURce:JUMP:PATTern:FORCe

        #region SOURCE[n]:MARKER[n]:DELAY

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURCE[n]:MARKER[n]:DELAY set the source marker delay on the given channel
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <param name="marker">Marker Channel</param>
        /// <param name="setValue">Delay value</param>
        void SetAwgSourceMarkerDelay(string channel, string marker, string setValue);

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURCE[n]:MARKER[n]:DELAY get the source marker delay on the given channel
        /// </summary>
        /// <param name="channel">Marker Channel</param>
        /// <param name="marker">Channel</param>
        /// <returns>Delay value</returns>
        string GetAwgSourceMarkerDelay(string channel, string marker);

        #endregion SOURCE[n]:MARKER[n]:DELAY

        #region SOURce[n]:MARKer[n]:VOLTage:LEVel:IMMediate:AMPLitude

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce[n]:MARKer[n]:VOLTage:LEVel:IMMediate:AMPLitude set the marker amplitude on a given channel
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <param name="marker">Marker</param>
        /// <param name="setValue">Amplitude</param>
        void SetAwgSourceMarkerAmplitude(string channel, string marker, string setValue);

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce[n]:MARKer[n]:VOLTage:LEVel:IMMediate:AMPLitude? get the marker amplitude on a given channel
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <param name="marker">Marker</param>
        /// <returns>Amplitude</returns>
        string GetAwgSourceMarkerAmplitude(string channel, string marker);

        #endregion SOURce[n]:MARKer[n]:VOLTage:LEVel:IMMediate:AMPLitude

        #region SOURce[n]:MARKer[n]:VOLTage:HIGH

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce[n]:MARKer[n]:VOLTage:HIGH set the high voltage marker threshold
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <param name="marker">Marker</param>
        /// <param name="setValue">High Voltage Threshold</param>
        void SetAwgSourceMarkerVoltageHigh(string channel, string marker, string setValue);

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce[n]:MARKer[n]:VOLTage:HIGH? get the high voltage marker threshold
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <param name="marker">Marker</param>
        /// <returns>High Voltage Threshold</returns>
        string GetAwgSourceMarkerVoltageHigh(string channel, string marker);

        #endregion SOURce[n]:MARKer[n]:VOLTage:HIGH

        #region SOURce[n]:MARKer[n]:VOLTage:LOW

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce[n]:MARKer[n]:VOLTage:LOW set the low voltage threshold for a marker
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <param name="marker">Marker</param>
        /// <param name="setValue">Channel</param>
        /// <returns>Low Voltage Threshold</returns>
        void SetAwgSourceMarkerVoltageLow(string channel, string marker, string setValue);

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce[n]:MARKer[n]:VOLTage:LOW? get the low voltage threshold for a marker
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <param name="marker">Marker</param>
        /// <returns>Low Voltage Threshold</returns>
        string GetAwgSourceMarkerVoltageLow(string channel, string marker);

        #endregion SOURce[n]:MARKer[n]:VOLTage:LOW

        #region SOURCE[n]:MARKER[n]:VOLTAGE:OFFSET

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURCE[n]:MARKER[n]:VOLTAGE:OFFSET set the Marker offset voltage on a given channel
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <param name="marker">Marker</param>
        /// <param name="setValue">Offset Voltage</param>
        void SetAwgSourceMarkerVoltageOffset(string channel, string marker, string setValue);

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURCE[n]:MARKER[n]:VOLTAGE:OFFSET? get the Marker offset voltage on a given channel
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <param name="marker">Marker</param>
        /// <returns>Offset Voltage</returns>
        string GetAwgSourceMarkerVoltageOffset(string channel, string marker);

        #endregion SOURCE[n]:MARKER[n]:VOLTAGE:OFFSET

        #region SOURce[n]:ROSCillator:MULTIPLIER

        // Added by Kavitha 02/04/2013 to include [SOURCE[1]]:ROSCillator:MULTiplier command
        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce[n]:ROSCillator:MULTIPLIER set the multiplier rate of the external reference oscillator
        /// </summary>
        /// <param name="clockNumber">clock number</param>
        /// <param name="setValue">Oscillator multiplier value</param>
        void SetAwgSourceReferenceOscillatorMultiplier(string clockNumber, string setValue);

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce[n]:ROSCillator:MULTIPLIER? get the multiplier rate of the external reference oscillator
        /// </summary>
        /// <param name="clockNumber">clock number</param>
        /// <returns>Oscillator multiplier value</returns>
        string GetAwgSourceReferenceOscillatorMultiplier(string clockNumber);

        #endregion SOURce[n]:ROSCillator:MULTIPLIER

        #region SOURce:RCCouple

        //glennj 9/3/2013
        /// <summary>
        /// Using SOURce:RCCouple set the Run Coupled Coupling mode
        /// </summary>
        /// <param name="setValue"></param>
        void SetAwgSourceRunCoupledMode(string setValue);

        //glennj 9/3/2013
        /// <summary>
        /// Using SOURce:RCCouple get the Run Coupled Coupling mode
        /// </summary>
        /// <returns></returns>
        string GetAwgSourceRunCoupledMode();

        #endregion SOURce:RCCouple

        #region SOURce:RMODe

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce:RMODe set the run mode
        /// </summary>
        /// <param name="channel">channel</param>
        /// <param name="setValue">Desired run mode</param>
        void SetAwgSourceRunMode(string channel, string setValue);

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce:RMODe? get the run mode
        /// </summary>
        /// <param name="channelNumber">Which clock</param>
        /// <returns>Current run mode for the given clock</returns>
        string GetAwgSourceRunMode(string channelNumber);

        #endregion SOURce:RMODe

        #region SOURC[n]:SCSTep?

        //glennj
        /// <summary>
        /// Using SOURce:SCSTep? get the Sequence Current STep.<para>
        /// Note, not real time</para>
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        string GetAwgSourceChannelCurrentStep(string channel);

        #endregion SOURC[n]:SCSTep?

        #region SOURce[n]:SKEW

        //glennj 7/17/2013
        /// <summary>
        /// Using [SOURce[n]]:SKEW set the skew for the waveform associated with a channel.
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Skew</param>
        void SetAwgSourceSkew(string channel, string setValue);

        //glennj 7/17/2013
        /// <summary>
        /// Using [SOURce[n]]:SKEW? set the skew for the waveform associated with a channel.
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <returns>Skew</returns>
        string GetAwgSourceSkew(string channel);

        #endregion SOURce[n]:SKEW

        #region SOURce[n]:TINPut

        //glennj 7/17/2013
        /// <summary>
        /// Using [SOURce[n]:]TINPut set the Trigger input for the given clock
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Desired run mode</param>
        void SetAwgSourceTriggerInput(string clockNumber, string setValue);

        //glennj 7/17/2013
        /// <summary>
        /// Using [SOURce[n]:]TINPut? get the Trigger input for the given clock
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <returns>Current Trigger input value for the given clock</returns>
        string GetAwgSourceTriggerInput(string clockNumber);

        #endregion SOURce[n]:TINPut

        #region SOURCE[n]:VOLTAGE:AMPLITUDE

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURCE[n]:VOLTAGE:AMPLITUDE set the Source Amplitude
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <param name="setValue">Source Amplitude</param>
        void SetAwgSourceVoltageAmplitude(string channel, string setValue);

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURCE[n]:VOLTAGE:AMPLITUDE? get the Source Amplitude
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <returns>Source Amplitude</returns>
        string GetAwgSourceVoltageAmplitude(string channel);

        #endregion

        #region SOURCE[n]:VOLTAGE:HIGH

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURCE[n]:VOLTAGE:HIGH set the waveform high for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Desired voltage</param>
        void SetAwgSourceVoltageHigh(string channel, string setValue);

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURCE[n]:VOLTAGE:HIGH set the waveform high for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <returns>Voltage high</returns>
        string GetAwgSourceVoltageHigh(string channel);

        #endregion SOURCE[n]:VOLTAGE:HIGH

        #region SOURCE[n]:VOLTAGE:LOW

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURCE[n]:VOLTAGE:LOW set the waveform low for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Desired voltage</param>
        void SetAwgSourceVoltageLow(string channel, string setValue);

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURCE[n]:VOLTAGE:LOW? get the waveform low for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <returns>Voltage Low</returns>
        string GetAwgSourceVoltageLow(string channel);

        #endregion SOURCE[n]:VOLTAGE:LOW

        #region SOURce[n]:WAVeform

        //glennj 7/17/2013
        /// <summary>
        /// Using [SOURce[n]]:WAVeform set the output waveform from the current waveform list to a channel
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <param name="waveform">Output waveform</param>
        void SetAwgSourceWaveform(string channel, string waveform);

        //glennj 7/17/2013
        /// <summary>
        /// Using [SOURce[n]]:WAVeform? get the output waveform from the current waveform list to a channel
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <returns>Current waveform loaded on the given channel</returns>
        string GetAwgSourceWaveform(string channel);

        #endregion SOURce[n]:WAVeform

        #endregion Source

        #region Status

        /// <summary>
        /// Clears all the errors in the error queue on this AWG
        /// 
        /// *CLS
        /// </summary>
        void AwgCLS();

        /// <summary>
        /// Sets the status of the Event Status Enable Register
        /// </summary>
        /// <param name="setValue"></param>
        void SetAwgESE(string setValue);

        // glennj 06/18/2013
        /// <summary>
        /// Queries and returns the value in the Event Status Enable Register
        /// </summary>
        /// <returns>Current value for Event Status Enable Register</returns>
        string GetAwgESE();

        /// <summary>
        /// Queries and returns the value in the Standard Event Status Register<para>
        /// </para><para>
        /// *ESR?</para>
        /// </summary>
        /// <returns>Current value for Standard Event Status Register</returns>
        string GetAwgESR();

        //glennj 06/06/2013
        /// <summary>
        /// Returns the implemented options
        /// </summary>
        /// <returns>Options implemented</returns>
        string GetAwgOption();

        //glennj 06/05/2013
        /// <summary>
        /// Sets the bits in the Service Request Enable Register
        /// </summary>
        /// <param name="setValue"></param>
        void SetAwgSRE(string setValue);

        //glennj 06/05/2013
        /// <summary>
        /// Gets the bits in the Service Request Enable Register<para>
        /// </para><para>
        /// *SRE?</para>
        /// </summary>
        /// <returns>Current value for Standard Event Status Register</returns>
        string GetAwgSRE();

        //glennj 06/05/2013
        /// <summary>
        /// Gets the contents of the Status Byte Register<para>
        /// </para><para>
        /// *STB?</para>
        /// </summary>
        /// <returns>Current value for Status Byte Register</returns>
        string GetAwgSTB();

        //glennj 06/05/2013
        /// <summary>
        /// Returns the contents of the Operation Condition register (OCR)
        /// </summary>
        /// <returns></returns>
        string GetAwgOperationConditionRegister();

        //glennj 06/05/2013
        /// <summary>
        /// Sets the the mask for the Operation Enable Register (OENR)
        /// </summary>
        /// <param name="setValue"></param>
        void SetAwgMaskOperationEnableRegister(string setValue);

        //glennj 06/05/2013
        /// <summary>
        /// Gets the the mask for the Operation Enable Register (OENR)
        /// </summary>
        /// <returns>Current value for OENR</returns>
        string GetAwgMaskOperationEnableRegister();

        //glennj 06/05/2013
        /// <summary>
        /// Queries and returns the contents of the Operation Event Register. (OEVR)
        /// </summary>
        /// <returns>Operation Event Register</returns>
        string GetAwgOperationEventRegister();

        //glennj 06/05/2013
        /// <summary>
        /// Sets the value in the Status Operation NTransition register
        /// </summary>
        /// <param name="setValue">The value to set</param>
        void SetAwgStatusOperationNTransitionRegister(string setValue);

        //glennj 06/05/2013
        /// <summary>
        /// Queries and returns the value in the Status Operation NTransition register
        /// </summary>
        /// <returns>Current value for Status Operation NTransition Register</returns>
        string GetAwgStatusOperationNTransitionRegister();

        //glennj 06/05/2013
        /// <summary>
        /// Sets the value in the Status Operation PTransition register
        /// </summary>
        /// <param name="setValue">The value to set</param>
        void SetAwgStatusOperationPTransitionRegister(string setValue);

        //glennj 06/05/2013
        /// <summary>
        /// Queries and returns the value in the Status Operation PTransition register
        /// </summary>
        /// <returns>Current value for Status Operation PTransition Register</returns>
        string GetAwgStatusOperationPTransitionRegister();

        //glennj 06/05/2013
        /// <summary>
        /// This command resets the OENR and QENR registers.
        /// </summary>
        void AwgResetOENRAndQENRRegisters();

        //glennj 06/06/2013
        /// <summary>
        /// Queries and returns the value in the Status Questionable Condition register
        /// 
        /// STATus:QUEStionable:CONDition?
        /// </summary>
        /// <returns>Current value for Status Questionable Condition Register</returns>
        string GetAwgStatusQuestionableConditionRegister();

        //PHunter 01/07/2013
        //glennj 06/06/2013
        /// <summary>
        /// Sets the value in the Status Questionable Enable register
        /// 
        /// STATus:QUEStionable:ENABle
        /// </summary>
        /// <param name="setValue">The value to set</param>
        void SetAwgStatusQuestionableEnableRegister(string setValue);

        //PHunter 01/07/2013
        //glennj 06/06/2013
        /// <summary>
        /// Queries and returns the value in the Status Questionable Enable register
        /// 
        /// STATus:QUEStionable:ENABle?
        /// </summary>
        /// <returns>Current value for Status Questionable Enable Register</returns>
        string GetAwgStatusQuestionableEnableRegister();

        //glennj 06/06/2013
        /// <summary>
        /// Queries and returns the value in the Status Questionable Event register (QEVR)
        /// 
        /// STATus:QUEStionable:EVENt?
        /// </summary>
        /// <returns>Current value for Status Questionable Event Register</returns>
        string GetAwgStatusQuestionableEventRegister();

        //PHunter 01/08/2013
        //glennj 06/06/2013
        /// <summary>
        /// Sets the value in the Status Questionable NTransition register
        /// 
        /// STATus:QUEStionable:NTRansition
        /// </summary>
        /// <param name="setValue">The value to set</param>
        void SetAwgStatusQuestionableNTransitionRegister(string setValue);

        //PHunter 01/08/2013
        //glennj 06/06/2013
        /// <summary>
        /// Queries and returns the value in the Status Questionable NTransition register
        /// 
        /// STATus:QUEStionable:NTRansition?
        /// </summary>
        /// <returns>Current value for Status Questionable NTransition Register</returns>
        string GetAwgStatusQuestionableNTransitionRegister();

        //PHunter 01/08/2013
        //glennj 06/06/2013
        /// <summary>
        /// Sets the value in the Status Questionable PTransition register
        /// 
        /// STATus:QUEStionable:PTRansition
        /// </summary>
        /// <param name="setValue">The value to set</param>
        void SetAwgStatusQuestionablePTransitionRegister(string setValue);

        //PHunter 01/08/2013
        //glennj 06/06/2013
        /// <summary>
        /// Queries and returns the value in the Status Questionable PTransition register
        /// 
        /// STATus:QUEStionable:PTRansition?
        /// </summary>
        /// <returns>Current value for Status Questionable PTransition Register</returns>
        string GetAwgStatusQuestionablePTransitionRegister();


        #endregion Status

        #region System

        /// <summary>
        /// Get the string from *idn?
        /// </summary>
        /// <returns></returns>
        string GetAwgIDN();

        /// <summary>
        /// Looking for home.  Gets the current settings.
        /// </summary>
        /// <returns></returns>
        string GetAwgLRN();

        /// <summary>
        /// Sets the system date
        /// </summary>
        /// <param name="setValue"></param>
        void SetAwgSystemDate(string setValue);

        /// <summary>
        /// Using SYSTem:DATE?, get the system date
        /// </summary>
        string GetAwgSystemDate();


        //glennj 8/29/2013
        /// <summary>
        /// Using the SYSTem:ERRor:COUNt?, query the error queue count 
        /// </summary>
        /// <returns>Return the number of errors in the system error queue</returns>
        string GetAwgSystemErrorQueueCount();

        /// <summary>
        /// Set to enable the System Error Dialog
        /// </summary>
        /// <param name="setValue"></param>
        void SetAwgSystemErrorDialog(string setValue);

        string GetAwgSystemErrorDialog();

        /// <summary>
        /// Returns the any error from the system error queue.
        /// </summary>
        /// <returns></returns>
        string GetAwgSystemError();

        /// <summary>
        /// Sets the system time
        /// 
        /// SYSTem:TIME
        /// </summary>
        /// <param name="hour">System hour</param>
        /// <param name="minute">System minute</param>
        /// <param name="second">System second</param>
        void SetAwgSystemTime(string hour, string minute, string second);

        /// <summary>
        /// Gets the system time
        /// 
        /// SYSTem:TIME?
        /// </summary>
        /// <returns>Current system time</returns>
        string GetAwgSystemTime();

        /// <summary>
        /// Returns the SCPI version number to which the command conforms.
        /// 
        /// SYSTem:VERSion?
        /// </summary>
        /// <returns>SCPI version number</returns>
        string GetAwgSystemVersion();

        /// <summary>
        /// Roughly translates into *RST which puts<para>
        /// the instrument into a known state.</para>
        /// </summary>
        void AwgRST();

        #endregion System

        #region Sync

        // glennj 06/3/2013
        /// <summary>
        /// Returns a 1 by definition, unless of course it timesout.
        /// 
        /// *OPC?
        /// </summary>
        /// <returns>1</returns>
        string AwgOPCQuery();

        //glennj 06/04/2013
        /// <summary>
        /// Command form for the OPC.  Need to test SByte
        /// </summary>
        void AwgOPC();

        //glennj 06/07/2013
        /// <summary>
        /// Sends the WAI command
        /// </summary>
        void AwgWAI();

        #endregion Sync

        #region Trigger

        #region *TRG

        // glennj 7/23/2013
        /// <summary>
        /// Using *TRG create a trigger event
        /// </summary>
        void SetAwgTriggerEvent();

        #endregion *TRG

        #region TRIGger:IMMediate

        // glennj 7/23/2013
        /// <summary>
        /// Using TRIGger:IMMediate Force a trigger event
        /// </summary>
        /// <param name="triggerSelection"></param>
        void ForceAwgTriggerEvent(string triggerSelection);

        #endregion

        #region TRIGger:IMPedance

        // glennj 7/23/2013
        /// <summary>
        /// Using TRIGger:IMPedance set a trigger impedance
        /// </summary>
        /// <param name="triggerSelection">Selects trigger A or B</param>
        /// <param name="setValue"> Impedance value of 50 or 1000 Ohms</param>
        void SetAwgTriggerImpedance(string triggerSelection, string setValue);

        // glennj 7/23/2013
        /// <summary>
        /// Using TRIGger:IMPedance? get a trigger impedance
        /// </summary>
        /// <param name="triggerSelection">Selects trigger A or B</param>
        /// <returns>Trigger Impedance of 50 or 1000 Ohms</returns>
        string GetAwgTriggerImpedance(string triggerSelection);

        #endregion

        #region TRIGger:LEVel

        // glennj 7/23/2013
        /// <summary>
        /// Using TRIGger:LEVel set a trigger level
        /// </summary>
        /// <param name="triggerSelection">Selects Trigger A or B</param>
        /// <param name="setValue">Trigger Level</param>
        void SetAwgTriggerLevel(string triggerSelection, string setValue);

        // glennj 7/23/2013
        /// <summary>
        /// Using TRIGger:LEVel? get a trigger level
        /// </summary>
        /// <param name="triggerSelection">Selects Trigger A or B</param>
        /// <returns>Trigger Level</returns>
        string GetAwgTriggerLevel(string triggerSelection);

        #endregion TRIGger:LEVel

        #region TRIGger:MODE

        //glennj 07/23/2013
        /// <summary>
        /// Using TRIGger:MODE set the trigger mode
        /// </summary>
        /// <param name="setValue">The desired mode for the trigger</param>
        void SetAwgTriggerMode(string setValue);

        //glennj 07/23/2013
        /// <summary>
        /// Using TRIGger:MODE? get a trigger mode
        /// </summary>
        /// <return>The Trigger Mode</return>
        string GetAwgTriggerMode();

        #endregion

        #region TRIGger[:SEQuence]:INTerval

        // jmanning 04/08/2014
        /// <summary>
        /// Using TRIGger:SEQuence:INTerval to set the internal trigger inetrval
        /// </summary>
        /// <param name="setValue">Trigger Level</param>
        void SetAwgTriggerInterval(string setValue);

        // jmanning 04/08/2014
        /// <summary>
        /// Using TRIGger:SEQuence:INTerval? to get the internal trigger inetrval
        /// </summary>
        /// <returns>Internal Trigger Time Interval Value</returns>
        string GetAwgTriggerInterval();

        #endregion TRIGger[:SEQuence]:INTerval

        #region TRIGger:SLOPe

        // glennj 7/23/2013
        /// <summary>
        /// Using TRIGger:SLOPe set a trigger slope to setValue
        /// </summary>
        /// <param name="triggerSelection">Selects Trigger A or B</param>
        /// <param name="setValue">Trigger slope</param>
        void SetAwgTriggerSlope(string triggerSelection, string setValue);

        // glennj 7/23/2013
        /// <summary>
        /// Using TRIGger:SLOPe? get a Trigger slope
        /// </summary>
        /// <param name="triggerSelection">Selects trigger A or B</param>
        /// <returns>Trigger slope</returns>
        string GetAwgTriggerSlope(string triggerSelection);

        #endregion

        #region TRIGger:SOURce

        // glennj 7/23/2013
        /// <summary>
        /// Using TRIGger:SOURce set the trigger source
        /// </summary>
        /// <param name="setValue">Trigger source desired</param>
        void SetAwgTriggerSource(string setValue);

        // glennj 7/23/2013
        /// <summary>
        /// Using TRIGger:SOURce get a trigger source
        /// </summary>
        /// <returns>Trigger Source</returns>
        string GetAwgTriggerSource();

        #endregion

        #region TRIGger:WVALue

        // glennj 7/23/2013
        /// <summary>
        /// Using TRIGger:WVALue set a trigger wait on trigger value
        /// </summary>
        /// <param name="setValue"></param>
        void SetAwgTriggerWValue(string setValue);

        // glennj 7/23/2013
        /// <summary>
        ///  Using TRIGger:WVALue? get a trigger wait on trigger value
        /// </summary>
        /// <returns></returns>
        string GetAwgTriggerWValue();

        #endregion

        #region AWGControl:PJUMp:SEDGe
        //Keerthi 06/01/2015
        /// <summary>
        /// Using AWGControl:PJUMp:SEDGe Sets the Strobe edge to RISING/FALLING
        /// </summary>
        /// <param name="strobEdge"></param>
        void SetStrobEdge(string strobEdge);

        #endregion AWGControl:PJUMp:SEDGe

        #region AWGControl:PJUMp:SEDGe?
        //Keerthi 06/01/2015
        /// <summary>
        /// Using AWGControl:PJUMp:SEDGe? return the whether Rising or falling is selected
        /// </summary>
        /// <returns>RISING/FALLING</returns>
        string GetStrobEdge();

        #endregion AWGControl:PJUMp:SEDGe?

        #region AWGControl:PJUMp:JSTRobe
       //Keerthi 06/01/2015
        /// <summary>
        /// Using AWGControl:PJUMp:JSTRobe Sets the Jump on Strobe to ON/OFF
        /// </summary>
        /// <param name="setValue"></param>
       void SetJumpOnStrobe(string setValue);

        #endregion AWGControl:PJUMp:JSTRobe

        #region AWGControl:PJUMp:JSTRobe?
        //Keerthi 06/01/2015
        /// <summary>
        /// Using AWGControl:PJUMp:JSTRobe? return the whether Jump on strobe is ON/OFF
        /// </summary>
        /// <returns>ON/OFF</returns>
        string GetJumpOnStrobeStatus();

        #endregion AWGControl:PJUMp:JSTRobe?

        #endregion Trigger

        #region Waveform

        #region WLIST

        #region WLISt:LAST

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:LAST? return the last waveform names added to the waveform list.
        /// </summary>
        /// <returns>List of waveforms in the asset list</returns>
        string GetAwgWListLast();

        #endregion WLISt:LAST

        #region WLISt:LIST

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:LIST? return the names of the waveforms in the waveform list.<para>
        /// Note.  Limited usage due limit of return string sizes.</para><para>
        /// Not published.  Manufacturing usage only.</para>
        /// </summary>
        /// <returns>List of waveforms in the asset list</returns>
        string GetAwgWListList();

        #endregion WLISt:LAST

        #region WLISt:NAME

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:NAME? get the name of the waveform of an element in the waveform list
        /// </summary>
        /// <param name="listIndex">Index of the waveform in the waveform list</param>
        /// <returns>The name of the waveform</returns>
        string GetAwgWlistName(string listIndex);

        #endregion WLISt:NAME

        #region WLISt:SIZE

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:SIZE? get the size of the waveform list.
        /// </summary>
        /// <returns>Size of the waveform list</returns>
        string GetAwgWlistSize();

        #endregion WLISt:SIZE

        #region WLISt:WAVeform:DATA

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:WAVeform:DATA transfer waveform data from the external controller into the waveform list
        /// </summary>
        /// <param name="wfmName"></param>
        /// <param name="startIndex"></param>
        /// <param name="size"></param>
        /// <param name="blockData"></param>
        void SetAwgWListWaveformData(string wfmName, string startIndex, string size, string blockData);

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:WAVeform:DATA transfer waveform data from the external controller into the waveform list
        /// </summary>
        /// <param name="wfmName"></param>
        /// <param name="startIndex"></param>
        /// <param name="size"></param>
        /// <param name="blockData"></param>
        void SetAwgWListWaveformPieceData(string wfmName, string startIndex, string size, string blockData);

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:WAVeform:DATA? transfer waveform data from the waveform list into the external controller 
        /// </summary>
        /// <param name="wfmName"></param>
        /// <param name="startIndex"></param>
        /// <param name="size"></param>
        byte[] GetAwgWListWaveformData(string wfmName, string startIndex, string size);

        #endregion WLISt:WAVeform:DATA

        #region WLISt:WAVeform:DELete

        //glennj 7/25/2013
        /// <summary>
        /// Using WLIST:WAVeform:DELete delete the waveform from the waveform list
        /// </summary>
        /// <param name="wfmName">Name of the waveform to delete</param>
        void AwgWListWaveformDelete(string wfmName);

        #endregion WLISt:WAVeform:DELete

        #region WLISt:WAVeform:LMAXimum

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:WAVeform:LMAXimum? get the maximum sample points allowed for the waveform
        ///</summary>
        /// <returns>Max Sample Points of the waveform </returns>
        string GetAwgWlistMaxSamplePoints();

        #endregion WLISt:WAVeform:LMAXimum

        #region WLISt:WAVeform:LMINimum

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:WAVeform:LMINimum? get the minimum sample points allowed for the waveform
        /// </summary>
        /// <returns>Min Sample Points of the waveform </returns>
        string GetAwgWlistMinSamplePoints();

        #endregion WLISt:WAVeform:LMINimum

        #region WLISt:WAVeform:GRANularity

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:WAVeform:GRANularity? get the required granularity for a waveform
        /// </summary>
        /// <returns>Minimum granularity for a waveform </returns>
        string GetAwgWaveformGranularity();

        #endregion WLISt:WAVeform:GRANularity

        #region WLISt:WAVeform:LENGth

        //glennj 7/25/2013
        /// <summary>
        /// Using WLIST:WAVeform:LENGth? get the length of the given waveform
        /// </summary>
        /// <param name="wfmName">Name of the waveform to get the length of</param>
        /// <returns>The length of the waveform</returns>
        string GetAwgWListWaveformLength(string wfmName);

        #endregion WLISt:WAVeform:LENGth

        #region WLISt:WAVeform:MARKer:DATA

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:WAVeform:MARKer:DATA set the waveform marker data
        /// </summary>
        /// <returns>Minimum granularity for a waveform </returns>
        void SetAwgWaveformMarkerData(string wfmName, string startIndex, string size, string blockData);

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:WAVeform:MARKer:DATA? get the waveform marker data
        /// </summary>
        /// <returns>Minimum granularity for a waveform </returns>
        string GetAwgWaveformMarkerData(string wfmName, string startIndex, string size);

        #endregion WLISt:WAVeform:MARKer:DATA

        #region WLISt:WAVeform:NEW

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:WAVeform:NEW create a new waveform of the given size and the given name
        /// </summary>
        /// <param name="wfmName">Name of the new waveform</param>
        /// <param name="size">Save of the new waveform</param>
        void CreateAwgWListWaveformNew(string wfmName, string size);

        #endregion WLISt:WAVeform:NEW

        #region WLISt:WAVeform:NORMalize

        //glennj 7/25/2013
        /// <summary>
        /// Using WLIST:WAVeform:NORMalize normalizes a waveform that exists in the waveform list
        /// </summary>
        /// <param name="wfmName">Waveform to normalize</param>
        /// <param name="normType">Noramlization type</param>
        void AwgWListWaveformNormalize(string wfmName, string normType);

        #endregion WLISt:WAVeform:NORMalize

        #region WLISt:WAVeform:RESAmple

        //glennj 7/25/2013
        /// <summary>
        /// Using WLIST:WAVeform:RESAmple resamples a waveform that exists in the waveform list
        /// </summary>
        /// <param name="wfmName">Waveform to normalize</param>
        /// <param name="size">Number of points to resample to</param>
        void AwgWListWaveformResample(string wfmName, string size);

        #endregion WLISt:WAVeform:RESAmple

        #region WLISt:WAVeform:SHIFt

        //glennj 7/25/2013
        /// <summary>
        /// Using WLIST:WAVeform:SHIFt shift a waveform that exists in the waveform list
        /// </summary>
        /// <param name="wfmName">Waveform to normalize</param>
        /// <param name="phase">Number of degrees to shift</param>
        void AwgWListWaveformShift(string wfmName, string phase);

        #endregion WLISt:WAVeform:SHIFt

        #region WLISt:WAVeform:TSTamp

        //glennj 7/25/2013
        /// <summary>
        /// Using WLIST:WAVeform:TSTamp? get the timestamp of the given waveform
        /// </summary>
        /// <param name="wfmName">Name of the waveform to get the timestamp of</param>
        /// <returns>The timestamp of the waveform</returns>
        string GetAwgWListWaveformTimestamp(string wfmName);

        #endregion WLISt:WAVeform:TSTamp

        #region WLISt:WAVeform:TYPE

        //glennj 7/25/2013
        /// <summary>
        /// Using WLIST:WAVeform:TYPE? get the type of the given waveform
        /// </summary>
        /// <param name="wfmName">Name of the waveform to get the type of</param>
        /// <returns>The type of the waveform (Always REAL)</returns>
        string GetAwgWListWaveformType(string wfmName);

        #endregion WLISt:WAVeform:TYPE

        #region WLISt:WAVeform:SFORmat

        //Keerthi 06/01/2015
        /// <summary>
        /// Using WLISt:WAVeform:SFORmat Sets the Signal format to I/Q/REAL/UND
        /// </summary>
        /// <param name="wfmName"></param>
        /// <param name="signalFormat"></param>
        /// <param name="awg"></param>
        void SetSignalFormat(string signalFormat, string wfmName, IAWG awg);

        #endregion WLISt:WAVeform:SFORmat
  
        #region WLISt:WAVeform:SFORmat?

        //Keerthi 06/01/2015
        /// <summary>
        /// Using WLISt:WAVeform:SFORmat? Gets the Signal format I/Q/REAL/UND
        /// Compares the returned value to the expected value
        /// </summary>
        /// <param name="wfmName"></param>
        /// <returns>I/Q/REAL/UND</returns>
        string GetSignalFormat(string wfmName);
        
        #endregion WLISt:WAVeform:SFORmat?

        #region WLISt:WAVeform:SRATe
        //sdas2 6/3/2015
        /// <summary>
        /// Set the sampling rate of the particular waveform 
        /// 
        /// WLISt:WAVEform:SRATe
        /// </summary>
        /// <param name="wfmName">Waveform Name</param>
        /// <param name=sRate>specific Sampling Rate</param>

        void SetAwgSamplingRate(string wfmName, string sRate);

        //sdas2 6/3/2015
        /// <summary>
        /// Gets the sampling rate of the particular waveform 
        /// 
        /// WLISt:WAVEform:SRATe? (Query only)
        /// </summary>
        /// <param name="wfmName">Waveform Name</param>
        /// <return>Always return the Sampling rate of the Specific Waveform</return>

        string GetAwgWListWaveformSRATe(string wfmName);

        #endregion WLISt:WAVeform:SRATe

        #endregion WLIST

        #endregion Waveform

        #region SyncHub

        #region SYNChronize:ADJust[:STARt]

        /// <summary>
        /// Using SYNChronize:ADJust[:STARt]
        /// This command only performs a system sample rate calibration. It is an overlapped command. 
        /// This command may take up to 3 minutes to complete.
        /// </summary>
        void StartAwgSyncHubAdjust();

        #endregion SYNChronize:ADJust[:STARt]

        #region SYNChronize:CONFigure

        /// <summary>
        /// Using SYNChronize:CONFigure
        /// This command configures the ports in a Synchronization HUB system and forces 
        /// an initialization with the selected configuration. This is an overlapped command.
        /// </summary>
        /// <param name="setValue">Port Setting values, odd numbers between 3 and 15 are valid for system </param>
        void SetAwgSyncHubConfig(string setValue);

        /// <summary>
        /// Using SYNChronize:CONFigure?
        /// This command gets the configuration of the ports in a Synchronization HUB system and forces 
        /// an initialization with the selected configuration. This is an overlapped command.
        /// </summary>
        /// <returns>Port Setting values, odd numbers between 3 and 15 are valid for system </returns>
        string GetAwgSyncHubConfig();

        #endregion SYNChronize:CONFigure

        #region SYNChronize:DESKew:ABORt

        /// <summary>
        /// Using SYNChronize:DESKew:ABORt
        /// TThis command only cancels a system deskew calibration. It is an overlapped command. 
        /// This command may take up to 10 minutes to cancel.
        /// </summary>
        void SetAwgSyncHubDeskewAbort();

        #endregion SYNChronize:DESKew:ABORt

        #region SYNChronize:DESKew:[STARt]

        /// <summary>
        /// Using SYNChronize:DESKew:[STARt]
        /// This command only performs a system deskew calibration. It is an overlapped command. 
        /// This command may take up to 30 minutes to complete. 
        /// </summary>
        void SetAwgSyncHubDeskewStart();

        #endregion SYNChronize:DESKew:[STARt]

        #region SYNChronize:DESKew:STATe?

        /// <summary>
        /// Using SYNChronize:DESKew:STATe?
        /// This query only command retrieve the state of the system deskew calibration. 
        /// Valid only when SynchHub enabled and Master.
        /// </summary>
        /// <returns>0 for STOPPED and 1 for RUNNING</returns>
        string AwgSyncHubDeskewStateQuery();

        #endregion SYNChronize:DESKew:STATe?

        #region SYNChronize:ENABle

        /// <summary>
        /// Using SYNChronize:ENABle 
        /// This command enables this AWG to be part of a system to synchronize multiple AWGs. 
        /// This is an overlapped command.
        /// </summary>
        /// <param name="state">On or Off Settings</param>
        void SetAwgSyncHubEnable(string state);

        /// <summary>
        /// Using SYNChronize:ENABle?
        /// This query returns Sync Hub Enable State
        /// </summary>
        /// <returns>0 for OFF and 1 for ON</returns>
        string AwgSyncHubEnableQuery();

        #endregion SYNChronize:ENABle

        #region SYNChronize:PLAY:DISable?

        /// <summary>
        /// Using SYNChronize:PLAY:DISable?
        /// This query only command retrieves state of this AWG70000 with regard to which PI commands should be disabled
        /// when AWGSYNC01 is enabled and the play state is not idle. That is the system has started or is playing the selected waveforms and sequences.
        /// This is an unpublished command
        /// </summary>
        /// <returns>0 for OFF and 1 for ON</returns>
        string AwgSyncHubPlayDisableQuery();

        #endregion SYNChronize:PLAY:DISable?

        #region SYNChronize:SLAVe:DISable?

        /// <summary>
        /// Using SYNChronize:SLAVe:DISable?
        /// This query only command retrieves state of this AWG70000 with regard to which PI commands should be disabled
        /// when AWGSYNC01 is enabled and this AWG70000 is a slave.
        /// This is an unpublished command
        /// </summary>
        /// <returns>0 for not a slave and 1 for is a slave and mode is enabled</returns>
        string AwgSyncHubSlaveDisableQuery();

        #endregion SYNChronize:SLAVe:DISable?

        #region SYNChronize:TESTmode

        /// <summary>
        /// Using SYNChronize:TESTmode
        /// This command puts this AWG70000 in AWGSYNC01 test mode. 
        /// This will be key to testing the software without a HUB connected to the AWG70000. 
        /// This command requires the application starts in  manufacturing mode 
        /// This is an unpublished command
        /// </summary>
        /// <param name="state">On or Off Settings</param>
        void SetAwgSyncTestMode(string state);

        /// <summary>
        /// Using SYNChronize:TESTmode?
        /// This query only command retrieves the testmode state of this AWG70000 in the synchronized HUB system.
        /// This command requires the application starts in manufacturing mode 
        /// This is an unpublished command
        /// </summary>
        /// <returns>0 not in testmode, 1 in testmode</returns>
        string AwgSyncHubTestModeQuery();

        #endregion SYNChronize:TESTmode

        #region SYNChronize:TTYPe

        /// <summary>
        /// Using SYNChronize:TTYPe
        /// The command sets the test type for this AWG70000 in the synchronized system
        /// when AWGSYNC01 test mode is enabled. This command requires the application 
        /// starts in manufacturing mode.
        /// This is an unpublished command
        /// </summary>
        /// <param name="mode">MASTer or SLAVe</param>
        void SetAwgSyncTestType(string mode);

        /// <summary>
        /// Using SYNChronize:TTYPe?
        /// This command retrieves the the test type for this AWG70000 in the synchronized system when AWGSYNC01 test mode is enabled. 
        /// This command requires the application starts in  manufacturing mode.
        /// This is an unpublished command
        /// </summary>
        /// <returns>MASTer/SLAVe</returns>
        string AwgSyncHubTestTypeQuery();

        #endregion SYNChronize:TTYPe

        #region SYNChronize:TYPE?

        /// <summary>
        /// Using SYNChronize:TYPE?
        /// This query only command retrieves the type of this AWG70000 in the synchronized HUB system.
        /// The Synch Hub Type is not active until after Synch Hub Enable has completed.
        /// </summary>
        /// <returns>MASTer/SLAVe/UNKNown</returns>
        string AwgSyncHubTypeQuery();

        #endregion SYNChronize:TYPE?

        #endregion SyncHub


        #region MultiTone

        #region MTONE:RESEt
        //sdas2 9/1/2015
        /// <summary>
        /// Reset Multitone Module
        /// 
        /// </summary>
        void AwgMultiToneReset();

        #endregion

        #region MTONe:LOAD

        //dstockwe 2014/11/20
        /// <summary>
        /// Load MultiTone module
        /// </summary>
        void AwgMultiToneLoad();

        #endregion

        #region MTONe:TYPE[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone Type
        /// </summary>
        void SetMultiToneType(string setValue);

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone Type
        /// </summary>
        string GetMultiToneType();

        #endregion


        #region MTONe:COMPile

        //dstockwe 2014/11/20
        /// <summary>
        /// Compile MultiTone module
        /// </summary>
        void AwgMultiToneCompile();

        #endregion

        #region MTONe:COMPile:CANCel

        //dstockwe 2014/11/20
        /// <summary>
        /// Cancels an active compile in MultiTone module
        /// </summary>
        void AwgMultiToneCancelCompile();

        #endregion

        #region MTONe:COMPile:NAME[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone Name
        /// </summary>
        void SetMultiToneName(string setValue);

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone Name
        /// </summary>
        string GetMultiToneName();

        #endregion

        #region MTONe:COMPile:CHANnel[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone Assign to Channel
        /// </summary>
        void SetMultiToneChannel(string setValue);

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone Assign to Channel
        /// </summary>
        string GetMultiToneChannel();

        #endregion

        #region MTONe:COMPile:PLAY[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone Assign to Channel and Play
        /// </summary>
        void SetMultiToneChannelPlay(string setValue);

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone Assign to Channel and Play
        /// </summary>
        string GetMultiToneChannelPlay();

        #endregion

        #region MTONe:COMPile:SRATe[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone desired sampling rate
        /// </summary>
        void SetMultiToneSamplingRate(string setValue);

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone desired sampling rate
        /// </summary>
        string GetMultiToneSamplingRate();

        #endregion

        #region MTONe:COMPile:SRATe:AUTO[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone auto desired sampling rate
        /// </summary>
        void SetMultiToneAutoSamplingRate(string setValue);

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone auto desired sampling rate
        /// </summary>
        string GetMultiToneAutoSamplingRate();

        #endregion



        #region MTONe:TONes:STARt[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone start
        /// </summary>
        void SetMultiToneToneStart(string setValue);

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone start
        /// </summary>
        string GetMultiToneToneStart();

        #endregion

        #region MTONe:TONes:END[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone end
        /// </summary>
        void SetMultiToneToneEnd(string setValue);

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone end
        /// </summary>
        string GetMultiToneToneEnd();

        #endregion

        #region MTONe:TONes:SPACing[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone spacing
        /// </summary>
        void SetMultiToneToneSpacing(string setValue);

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone spacing
        /// </summary>
        string GetMultiToneToneSpacing();

        #endregion

        #region MTONe:TONes:NTONes[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone number of tones
        /// </summary>
        void SetMultiToneToneNTones(string setValue);

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone number of tones
        /// </summary>
        string GetMultiToneToneNTones();

        #endregion

        #region MTONe:TONes:PHASe[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone Phase
        /// </summary>
        void SetMultiToneTonePhase(string setValue);

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone Phase
        /// </summary>
        string GetMultiToneTonePhase();

        #endregion

        #region MTONe:TONes:PHASe:UDEFined[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone Phase User Defined
        /// </summary>
        void SetMultiToneTonePhaseUserDefined(string setValue);

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone Phase User Defined
        /// </summary>
        string GetMultiToneTonePhaseUserDefined();

        #endregion


        #region MTONe:TONes:NOTCh16[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone notch
        /// </summary>
        void SetMultiToneToneNotch(string setValue, string notchIndex = "1");

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone notch
        /// </summary>
        string GetMultiToneToneNotch(string notchIndex = "1");

        #endregion

        #region MTONe:TONes:NOTCh16:ADD

        //dstockwe 2014/11/20
        /// <summary>
        /// Add MultiTone tone notch
        /// </summary>
        void SetMultiToneToneNotchAdd(string setStartValue, string setEndValue, string notchIndex = "1");

        #endregion

        #region MTONe:TONes:NOTCh16:ENABle[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone notch enable
        /// </summary>
        void SetMultiToneToneNotchEnable(string setValue);

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone notch enable
        /// </summary>
        string GetMultiToneToneNotchEnable();

        #endregion

        #region MTONe:TONes:NOTCh16:STARt[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone notch start
        /// </summary>
        void SetMultiToneToneNotchStart(string setValue, string notchIndex = "1");

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone notch start
        /// </summary>
        string GetMultiToneToneNotchStart(string notchIndex = "1");

        #endregion

        #region MTONe:TONes:NOTCh16:END[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone notch end
        /// </summary>
        void SetMultiToneToneNotchEnd(string setValue, string notchIndex = "1");

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone notch end
        /// </summary>
        string GetMultiToneToneNotchEnd(string notchIndex = "1");

        #endregion

        #region MTONe:TONes:NOTCh16:DELete

        //dstockwe 2014/11/20
        /// <summary>
        /// Deletes specified notch(es)
        /// </summary>
        void DeleteMultiToneToneNotch(string setValue = "ALL", string notchIndex = "1");

        #endregion

        #region MTONe:TONes:NOTCh16:COUNT[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone notch
        /// </summary>
        string GetMultiToneToneNotchCount();

        #endregion


        #region MTONe:CHIRp:LOW[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone chirp low
        /// </summary>
        void SetMultiToneChirpLow(string setValue);

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone chirp low
        /// </summary>
        string GetMultiToneChirpLow();

        #endregion

        #region MTONe:CHIRp:HIGH[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone chirp high
        /// </summary>
        void SetMultiToneChirpHigh(string setValue);

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone chirp high
        /// </summary>
        string GetMultiToneChirpHigh();

        #endregion

        #region MTONe:CHIRp:SRATe[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone chirp sweep rate
        /// </summary>
        void SetMultiToneChirpSweepRate(string setValue);

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone chirp sweep rate
        /// </summary>
        string GetMultiToneChirpSweepRate();

        #endregion

        #region MTONe:CHIRp:STIMe[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone chirp sweep time
        /// </summary>
        void SetMultiToneChirpSweepTime(string setValue);

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone chirp sweep time
        /// </summary>
        string GetMultiToneChirpSweepTime();

        #endregion

        #region MTONe:CHIRp:FSWeep[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone chirp frequency sweep
        /// </summary>
        void SetMultiToneChirpFrequencySweep(string setValue);

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone chirp frequency sweep
        /// </summary>
        string GetMultiToneChirpFrequencySweep();

        #endregion

        #endregion MultiTone

        #region SXConnectivity

        //Sharmmila - 01/04/2015
        /// <summary>
        ///Establish the connection with the DUT
        /// </summary>
        /// <param name="dutIP">The DUT to which we need to connect to from SX</param>
        void ConnectivityConnectCommand(string dutIP);

        //Sharmila - 01/04/2015
        /// <summary>
        /// Query for the status of the DUT
        /// </summary>
        /// <param name="dutIP">The DUT whose status we want to query from SX</param>
        /// <returns>Whether DUT is connected to SX or not</returns>
        string ConnectivityStatusQuery(string dutIP);

        //Sharmila - 01/04/2015
        /// <summary>
        /// Set the DUT as the Active generator
        /// </summary>
        /// <param name="dutIP">The DUT which we need to set as active generator from SX</param>
        void ConnectivityActiveCommand(string dutIP);

        //Sharmila - 01/04/2015
        /// <summary>
        /// Get the active generator on SX
        /// </summary>
        /// <returns>The IP of the active DUT</returns>
        string ConnectivityActiveQuery();

        //Sharmila - 01/04/2015
        /// <summary>
        /// Terminate the connection to DUT from SX
        /// </summary>
        /// <param name="dutIP">The IP of the DUT which we need to disconnect from</param>
        void ConnectivityDisconnectCommand(string dutIP);

        #endregion SXConnectivity




       
    }
}
