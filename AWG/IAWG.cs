
// ReSharper disable CheckNamespace
namespace AwgTestFramework
// ReSharper restore CheckNamespace
{
    public interface IAWG
    {
        /// <summary>
        /// Using SOURce[n]:CASSet? get the asset assigned to a channel
        /// </summary>
        /// <param name="logicalChannel"></param>
        void GetSourceChannelAsset(string logicalChannel);

        /// <summary>
        /// Given a logical channel, return the channel assigned asset
        /// </summary>
        /// <param name="logicalChannel"></param>
        string SourceChannelAssignedAsset(string logicalChannel);

        /// <summary>
        /// Using SOURce[n]:CASSet:SEQuence assign an asset of a track of a sequence to a channel
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <param name="sequenceName"></param>
        /// <param name="trackNumber"></param>
        void SetSourceChannelAssetSequence(string logicalChannel, string sequenceName, string trackNumber);

        /// <summary>
        /// Using SOURce:CASSet:TYPE?, get the type of the asset assigned to a channel
        /// </summary>
        /// <param name="logicalChannel"></param>
        void GetSourceChannelAssetType(string logicalChannel);

        /// <summary>
        /// Given a logical channel, return the type of the asset assigned to a channel
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        string SourceChannelAssignedAssetType(string logicalChannel);

        /// <summary>
        /// Using SOURce:CASSet:WAVeform assign a waveform to a channel
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="wfmName"></param>
        void SetSourceChannelAssetWaveform(string channel, string wfmName);

        /// <summary>
        /// Set the DAC resolution on a specified channel
        /// </summary>
        /// <param name="logicalChannel">Channel desired to set DAC resolution for</param>
        /// <param name="resolution">Resolution of the DAC</param>
        void SetSourceDacResolution(string logicalChannel, string resolution);

        /// <summary>
        /// Update the property containing the DAC resolution on a specified channel
        /// </summary>
        /// <param name="logicalChannel">Channel desired to read DAC resolution</param>
        void GetSourceDacResolution(string logicalChannel);

        /// <summary>
        /// Given a logical channel, return the DAC resolution
        /// </summary>
        /// <param name="logicalChannel"></param>
        string SourceDacResolution(string logicalChannel);

        /// <summary>
        /// Using [SOURce[n]]:FREQuency set the sampling frequency for the desired clock
        /// </summary>
        /// <param name="logicalClock"></param>
        /// <param name="setValue"></param>
        void SetSourceFrequency(string logicalClock, string setValue);

        /// <summary>
        /// Using [SOURce[n]]:FREQuency get the sampling frequency for the desired clock
        /// </summary>
        /// 
        /// <param name="logicalClock"></param>
        void GetSourceFrequency(string logicalClock);

        /// <summary>
        /// Given a logical clock, return the clock sample rate
        /// </summary>
        /// <param name="logicalClock"></param>
        /// <returns></returns>
        string SourceFrequency(string logicalClock);

        /// <summary>
        /// Using SOURce:JUMP:FORCE, force a running sequence to jump to First, Current, Last, End or a specified step
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="forceJumpType"></param>
        void ForceSourceChannelJump(string channel, string forceJumpType);

        /// <summary>
        /// Using SOURce:JUMP:PATTern:FORCE, force a running sequence to jump to with a pattern match
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="forceJumpPattern"></param>
        void ForceSourceChannelJumpPattern(string channel, string forceJumpPattern);

        /// <summary>
        /// Set the source marker delay on the given channel
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <param name="marker">Marker</param>
        /// <param name="setValue">Delay value</param>
        void SetSourceMarkerDelay(string channel, string marker, string setValue);

        /// <summary>
        /// Update the copy of the source marker delay for the given channel and marker
        /// </summary>
        /// <param name="logicalChannel">Channel</param>
        /// <param name="logicalMarker">Marker Channel</param>
        void GetSourceMarkerDelay(string logicalChannel, string logicalMarker);

        /// <summary>
        /// Returns the awg's copy of the source marker delay for the given channel and marker
        /// </summary>
        /// <param name="logicalChannel">Which channel number</param>
        /// <param name="logicalMarker">Which marker number</param>
        /// <returns>Delay</returns>
        string SourceMarkerDelay(string logicalChannel, string logicalMarker);

        /// <summary>
        /// Using SOURce[c]:MARKer[m]:VOLTage:LEVel:IMMediate:AMPLitude set the marker amplitude on a given channel
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <param name="marker">Marker</param>
        /// <param name="setValue">Amplitude</param>
        void SetSourceMarkerAmplitude(string channel, string marker, string setValue);

        /// <summary>
        /// Update the copy per channel per marker for amplitude
        /// </summary>
        /// <param name="logicalChannel">Channel</param>
        /// <param name="logicalMarker">Marker Channel</param>
        void GetSourceMarkerAmplitude(string logicalChannel, string logicalMarker);

        /// <summary>
        /// Returns the awg's copy of the source marker amplitude for the given channel and marker
        /// </summary>
        /// <param name="logicalChannel">Which channel number</param>
        /// <param name="logicalMarker">Which marker number</param>
        /// <returns>Amplitude</returns>
        string SourceMarkerAmplitude(string logicalChannel, string logicalMarker);

        /// <summary>
        /// Set the high voltage marker threshold
        /// </summary>
        /// <param name="logicalChannel">Channel</param>
        /// <param name="logicalMarker">Marker</param>
        /// <param name="setValue">Voltage Threshold</param>
        void SetSourceMarkerVoltageHigh(string logicalChannel, string logicalMarker, string setValue);

        /// <summary>
        /// Update the copy for the high voltage marker threshold
        /// </summary>
        /// <param name="logicalChannel">Channel</param>
        /// <param name="logicalMarker">Marker</param>
        void GetSourceMarkerVoltageHigh(string logicalChannel, string logicalMarker);

        /// <summary>
        /// Returns the awg's copy of the source marker high threshold for the given channel and marker
        /// </summary>
        /// <param name="logicalChannel">Which channel number</param>
        /// <param name="logicalMarker">Which marker number</param>
        /// <returns>High threshold</returns>
        string SourceMarkerHigh(string logicalChannel, string logicalMarker);

        /// <summary>
        /// Set the low voltage threshold for a marker
        /// </summary>
        /// <param name="logicalChannel">Channel</param>
        /// <param name="logicalMarker">Marker</param>
        /// <param name="setValue">Voltage Threshold</param>
        void SetSourceMarkerVoltageLow(string logicalChannel, string logicalMarker, string setValue);

        /// <summary>
        /// Update the copy for the low voltage threshold for a marker
        /// </summary>
        /// <param name="logicalChannel">Channel</param>
        /// <param name="logicalMarker">Marker</param>
        void GetSourceMarkerVoltageLow(string logicalChannel, string logicalMarker);

        /// <summary>
        /// Returns the awg's copy of the source marker Low threshold for the given channel and marker
        /// </summary>
        /// <param name="logicalChannel">Which channel number</param>
        /// <param name="logicalMarker">Which marker number</param>
        /// <returns>Low threshold</returns>
        string SourceMarkerLow(string logicalChannel, string logicalMarker);

        /// <summary>
        /// Set the Marker offset voltage on a given channel
        /// </summary>
        /// <param name="logicalChannel">Channel</param>
        /// <param name="logicalMarker">Marker</param>
        /// <param name="setValue">Offset Voltage</param>
        void SetSourceMarkerVoltageOffset(string logicalChannel, string logicalMarker, string setValue);

        /// <summary>
        /// Update the copy for the Marker offset voltage on a given channel
        /// </summary>
        /// <param name="logicalChannel">Channel</param>
        /// <param name="logicalMarker">Marker</param>
        void GetSourceMarkerVoltageOffset(string logicalChannel, string logicalMarker);

        /// <summary>
        /// Returns the awg's copy of the source marker offset voltage for the given channel and marker
        /// </summary>
        /// <param name="logicalChannel">Which channel number</param>
        /// <param name="logicalMarker">Which marker number</param>
        /// <returns>Low threshold</returns>
        string SourceMarkerOffset(string logicalChannel, string logicalMarker);

        /// <summary>
        /// Contains response of SOURce:RCCouple?
        /// </summary>
        string SourceRunCoupledMode { get; set; }

        /// <summary>
        /// Used for the property for OUTPut:OFF (GetOutputOff())
        /// </summary>
        string OutputOffState { get; set; }

        string IdString { get; set; }
        string Lrn { get; set; }
        string SystemTimeSnapShot { get; set; }

        uint DefaultVisaTimeout { get; set; }

        /// <summary>
        /// Contains response to Using SYSTem:DATE?
        /// </summary>
        string SystemDateCurrent { get; set; }

        /// <summary>
        /// Contains response from SYSTem:ERRor:COUNt?
        /// </summary>
        string SystemErrorQueueCount { get; set; }

        /// <summary>
        /// Contains response from SYSTem:ERRor:DIALog?
        /// </summary>
        string SystemErrorDialogMode { get; set; }

        /// <summary>
        /// Contains response to SYSTem:ERRor?
        /// </summary>
        string SystemError { get; set; }

        /// <summary>
        /// Returns the SCPI version number to which the command conforms to.<para>
        /// SYSTem:VERSion?</para>
        /// </summary>
        string ScpiVersion { get; }

        /// <summary>
        /// Property to contain the response from CPLayback:CLISt:SIGNal:SCOMPile?
        /// </summary>
        string CompileSelectStatusPlaybackFile { get; set; }

        /// <summary>
        /// Property to contain the response from CPLayback:COMPile:CFRequency?
        /// </summary>
        string CompileCarrierFrequency { get; set; }

        /// <summary>
        /// Property to contain the response from CPLayback:COMPile:SRATE?
        /// </summary>
        string CompileSampleRate { get; set; }

        /// <summary>
        /// Property to contain the response from CPLayback:COMPile:SRATe:AUTO?
        /// </summary>
        string CompileSampleRateAutoState { get; set; }

        /// <summary>
        /// Property to contain the response from CPLayback:CLISt:NAME?
        /// </summary>
        string CompileSignalName { get; set; }

        /// <summary>
        /// Property to contain the response from CPLayback:CLISt:SIZE?
        /// </summary>
        string CompileSignalsSize { get; set; }

        /// <summary>
        /// Property to contain the response from CPLayback:CLISt:SIGNal:OTIMe?
        /// </summary>
        string CompileSignalOffTime { get; set; }

        /// <summary>
        /// Property to contain the response from CPLayback:CLISt:SIGNal:WCOunt?
        /// </summary>
        string CompileSignalWfmCount { get; set; }

        /// <summary>
        /// Property to contain the response from CPLayback:CLISt:SIGNal:WAVeform:NAME?
        /// </summary>
        string CompileSignalWfmName { get; set; }

        /// <summary>
        /// Property to contain the response from CCPLayback:CLISt:SIGNal:WAVeform:FOFFset?
        /// </summary>
        string CompileWfmFreqOffset { get; set; }

        /// <summary>
        /// Property to contain the response from CPLayback:CLISt:SIGNal:WAVeform:SRATe?
        /// </summary>
        string CompileWfmSampleRate { get; set; }

        /// Contains response of AWGControl:CLOCk1:DRATe?
        /// </summary>
        string ControlClock1DividerRate { get; set; }

        /// <summary>
        /// Contains response of AWGControl:CLOCk2:DRATe?
        /// </summary>
        string ControlClock2DividerRate { get; set; }

        /// <summary>
        /// Contains response of AWGControl:CLOCk:PHASe:ADJust?
        /// </summary>
        string ControlClockPhaseAdjust { get; set; }

        /// <summary>
        /// Contains response of AWGControl:CONFigure:CNUMber?
        /// </summary>
        string ControlConfigureChannelNumber { get; set; }

        /// <summary>
        /// Contains response of AWGControl:DOUTput[n][:STATe]?
        /// </summary>
        string ControlDACState { get; set; }

        /// <summary>
        /// Contains response of AWGControl:INTerleave:ADJustment:AMPLitude?
        /// </summary>
        string ControlInterleaveAdjustmentAmplitude { get; set; }

        /// <summary>
        /// Contains response of AWGControl:INTerleave:ADJustment:PHASe?
        /// </summary>
        string ControlInterleaveAdjustmentPhase { get; set; }

        /// <summary>
        /// Contains response of AWGControl:RMODe?
        /// </summary>
        string ControlRunMode { get; set; }

        /// <summary>
        /// Contains response of AWGControl:RSTate?
        /// </summary>
        string ControlRunState { get; set; }

        /// <summary>
        /// Contains response of AWGControl:SNAMe?
        /// </summary>
        string ControlSavedSetupLocation { get; set; }

        /// <summary>
        /// Each AWG object has a logical identifier and is assigned when an AWG object is created
        /// </summary>
        string LogicalAWGNumber { get; set; }

        /// <summary>
        /// The Signal Source family is found in the *IDN? response TEKTRONIX,AWG70002A,PQ00012,FV:2.0.0211<para>
        ///                                                                   ^^^</para><para>
        /// Currently one of two types, AWG or HSG</para>
        /// </summary>
        string FamilyType { get; }

        /// <summary>
        /// The model number is found in the *IDN? response TEKTRONIX,AWG70002A,PQ00012,FV:2.0.0211<para>
        ///                                                              ^^^^^</para><para>
        /// Currently one of two types, AWG or HSG</para>
        /// </summary>
        string ModelNumber { get; }

        /// <summary>
        /// The class letter is found in the *IDN? response TEKTRONIX,AWG70002A,PQ00012,FV:2.0.0211<para>
        ///                                                                   ^</para>
        /// </summary>
        string ClassLetter { get; }

        /// <summary>
        /// The serial number is found in the *IDN? response TEKTRONIX,AWG70002A,PQ00012,FV:2.0.0211<para>
        ///                                                                      ^^^^^^^</para>
        /// </summary>
        string SerialNumber { get; }

        /// <summary>
        /// The Application version is found in the *IDN? response TEKTRONIX,AWG70002A,PQ00012,FV:2.0.0211<para>
        ///                                                                                    ^^^^^^^^^^^</para>
        /// </summary>
        string AppVersion { get; }

        string AppVersionMajor { get; }
        string AppVersionMinor { get; }
        string AppVersionVersion { get; }

        /// <summary>
        /// A two digit number of 70 or 50 representing the 70k and 50k AWG family types
        /// </summary>
        string Family { get; }

        /// <summary>
        /// A re-constructed string containing the family type, (e.g. AWG), model number and class letter
        /// </summary>
        string ModelString { get; }

        /// <summary>
        /// Used to store a response from a AWGVisaSession.Read or Query
        /// </summary>
        string ReadResponse { get; set; }

        /// <summary>
        /// AWG specific timer duration place holder.
        /// </summary>
        double TimerDuration { get; set; }

        /// <summary>
        /// AWG specific time placeholder for when plotting is off.<para>
        /// This is used in testing for the test framework.</para><para>
        /// Testframe needs a location for placeholders for times for comparisons.</para>
        /// </summary>
        double TimerPlotOff { get; set; }

        /// <summary>
        /// AWG specific time placeholder for when plotting is on.<para>
        /// This is used in testing for the test framework.</para><para>
        /// Testframe needs a location for placeholders for times for comparisons.</para>
        /// </summary>
        double TimerPlotOn { get; set; }

        string VisaSessionErrorDescription { get; }
        uint SessionTimeout { get; set; }

        /// <summary>
        /// Attribute that is updated from the UpdateMemoryDataSize()
        /// </summary>
        string MassMemoryDataSize { get; set; }

        /// <summary>
        /// Attribute that is updated by using UpdateMemoryData()
        /// </summary>
        string MassMemoryBlockData { get; set; }

        /// <summary>
        /// Attribute that is updated by using UpdateMemoryCatalog()
        /// </summary>
        string MassMemoryCatalog { get; set; }

        /// <summary>
        /// Attribute that is updated by using UpdateMemoryCDirectory()
        /// </summary>
        string MassMemoryCurrentDirectory { get; set; }

        /// <summary>
        /// Attribute that is updated by using UpdateMemoryDrive()
        /// </summary>
        string MassMemoryCurrentDrive { get; set; }

        /// <summary>
        /// Attribute that is updated by using UpdateMemoryImportNormalize()
        /// </summary>
        string MassMemoryImportParameterNormalize { get; set; }

        /// <summary>
        /// Attribute that is updated by using UpdateMemoryOpenNormalize()
        /// </summary>
        string MassMemoryOpenParameterNormalize { get; set; }

        /// <summary>
        /// Attribute that is updated by using UpdateMemoryRecentSequencesOpened()
        /// </summary>
        string MassMemoryRecentlyOpenedSequences { get; set; }

        /// <summary>
        /// Attribute that is updated by using UpdateMemoryRecentWaveformsOpened()
        /// </summary>
        string MassMemoryRecentlyOpenedWaveforms { get; set; }

        /// <summary>
        /// Attribute that is updated by using UpdateMemoryMostRecentSequenceOpened()
        /// </summary>
        string MassMemoryMostRecentlyOpenedSequence { get; set; }


        /// <summary>
        /// Property results for DISPlay:PLOT:STATe?
        /// </summary>
        string DisplayPlotState { get; set; }

        /// <summary>
        /// Property to contain the response from CAL:CAT?
        /// </summary>
        string CalibrationCatalog { get; set; }

        /// <summary>
        /// Property to contain update from CAL:DATA:FACT?
        /// </summary>
        string CalibrationDataFactory { get; set; }

        /// <summary>
        /// Property to contain update from CAL:DATA:USER?
        /// </summary>
        string CalibrationDataUser { get; set; }

        /// <summary>
        /// Property to contain the response from *CAL? and CAL:ALL?
        /// </summary>
        string CalibrationState { get; set; }

        /// <summary>
        /// Property to contain the response from CAL:TYPE?
        /// </summary>
        string CalibrationType { get; set; }

        /// <summary>
        /// Property to contain the response from CAL:TYPE:CAT?
        /// </summary>
        string CalibrationTypeCatalog { get; set; }

        /// <summary>
        /// Property to contain the response from CAL:STAT:FACT?
        /// </summary>
        string CalStateFactory { get; set; }

        /// <summary>
        /// Property to contain the response from CAL:STAT:USER?
        /// </summary>
        string CalStateUser { get; set; }
        /// <summary>
        /// Contains the response from the query CALibration:STOP:STATe?
        /// </summary>
        string CalibrationStopState { get; set; }
        /// <summary>
        /// Contains the response from the query CALibration:Control:HALT?
        /// </summary>
        string CalibrationHalt { get; set; }
        /// <summary>
        /// Contains the response from the query CALibration:LOG?
        /// Not to be confused with CALibration:RESults?
        /// </summary>
        string CalibrationLog { get; set; }
        string CalibrationLoopState { get; set; }
        string CalibrationLoopCount { get; set; }
        string CalibrationLoopsCompleted { get; set; }
        /// <summary>
        /// Contains the calibration status for a procedure from the query CALibration:RESults? xpath
        /// Not to be confused with CALibration:LOG?
        /// </summary>
        string CalibrationResult { get; set; }
        string CalibrationResultTemp { get; set; }
        string CalibrationResultTime { get; set; }
        string CalibrationFailOnlyFlag { get; set; }
        string CalibrationDetailsFlag { get; set; }
        string DiagResult { get; set; }
        string DiagnosticTestName { get; set; }
        string DiagnositcData { get; set; }
        string DiagnosticHalt { get; set; }
        string DiagImmediateResult { get; set; }
        string DiagLog { get; set; }
        string DiagLogDetail { get; set; }
        string DiagLogFail { get; set; }
        string DiagLoopState { get; set; }
        string DiagLoopCount { get; set; }
        string DiagLoops { get; set; }
        string DiagPostResult { get; set; }
        string DiagTemp { get; set; }
        string DiagTime { get; set; }

        /// <summary>
        /// Using DIAGnostic:RUNNing? to update property
        /// </summary>
        string DiagRunningState { get; set; }

        /// <summary>
        /// Results of the last *TST?
        /// </summary>
        string DiagTstResult { get; set; }

        string DiagStopState { get; set; }
        string DiagnosticActiveMode { get; set; }
        string DiagnosticType { get; set; }
        string DiagnosticTypeCatalog { get; set; }
        string DiagnosticCatalogOfSubsystems { get; set; }
        string DiagnosticCatalogOfAreas { get; set; }
        string DiagnosticCatalogOfTests { get; set; }
        string DiagnosticSubsystemSelected { get; set; }
        string DiagnosticAreaSelected { get; set; }
        string DiagnosticTestSelected { get; set; }
        string DiagnosticTestXpath { get; set; }

        
        
        /// <summary>
        /// Property for WLISt:LAST?
        /// </summary>
        string WaveformListLast { get; set; }

        /// <summary>
        /// Property for WLISt:LIST?
        /// </summary>
        string WaveformListList { get; set; }

        /// <summary>
        /// Property for WLISt:NAME?
        /// </summary>
        string WaveformListName { get; set; }

        /// <summary>
        /// Property for WLISt:SIZE?
        /// </summary>
        string WaveformListSize { get; set; }

        /// <summary>
        /// Property for WLISt:WAVeform:DATA?<para>
        /// Please note that this should contain minimal string sizes</para>
        /// </summary>
        byte[] WaveformListData { get; set; }

        /// <summary>
        /// Property for WLISt:WAVeform:GRANularity?
        /// </summary>
        string WaveformListGranularity { get; set; }

        /// <summary>
        /// Property for WLISt:WAVeform:LMAXimum?
        /// </summary>
        string WaveformListMaxSamplepoints { get; set; }

        /// <summary>
        /// Property for WLISt:WAVeform:LMINimum?
        /// </summary>
        string WaveformListMinSamplepoints { get; set; }

        /// <summary>
        /// Property for WLISt:WAVeform:LENGth?
        /// </summary>
        string WaveformListLength { get; set; }

        /// <summary>
        /// Property for WLISt:WAVeform:MARKer:DATA?<para>
        /// Please note that this should contain minimal string sizes</para>
        /// </summary>
        string WaveformListMarkerData { get; set; }

        /// <summary>
        /// Property for WLIST:WAVeform:TSTamp?
        /// </summary>
        string WaveformListTimestamp { get; set; }

        /// <summary>
        /// Property for WLIST:WAVeform:TYPE?
        /// </summary>
        string WaveformListType { get; set; }

        string InstrumentMode { get; set; }
        string InstrumentCoupleSource { get; set; }
        string GPIBUsbStatus { get; set; }
        string GPIBUsbHwversion { get; set; }
        string GPIBUsbId { get; set; }
        string GPIBUsbAddress { get; set; }
        string EventStatusEnableReg { get; set; }

        /// <summary>
        /// Operation Enable Register (OENR)
        /// </summary>
        string OperationEnableReg { get; set; }

        /// <summary>
        /// Operation Event Register (OEVR)
        /// </summary>
        string OperationEventReg { get; set; }

        /// <summary>
        /// Implemented options
        /// </summary>
        string OptionsImplemented { get; set; }

        /// <summary>
        /// Service Request Enable register
        /// </summary>
        string ServiceEnableReg { get; set; }

        string StandardEventStatusReg { get; set; }

        /// <summary>
        /// Status Byte register (SBR)
        /// </summary>
        string StatusByteReg { get; set; }

        /// <summary>
        /// Operation Condition register (OCR)
        /// </summary>
        string StatusOperationConditionReg { get; set; }

        /// <summary>
        /// Negative Operation Transition Register
        /// </summary>
        string StatusOperationNtransitionReg { get; set; }

        /// <summary>
        /// Positive Operation Transition Register
        /// </summary>
        string StatusOperationPtransitionReg { get; set; }

        /// <summary>
        /// Questionable Condition Register (QCR)
        /// </summary>
        string StatusQuestionableConditionReg { get; set; }

        /// <summary>
        /// Enable mask for the Questionable Enable Register (QENR)
        /// </summary>
        string StatusQuestionableEnableReg { get; set; }

        /// <summary>
        /// Questionable Event Register (QEVR)
        /// </summary>
        string StatusQuestionableEventReg { get; set; }

        /// <summary>
        /// Negative transition filter value of the Questionable Transition Register (QTR)
        /// </summary>
        string StatusQuestionableNtransitionReg { get; set; }

        /// <summary>
        /// Positive transition filter value of the Questionable Transition Register (QTR)
        /// </summary>
        string StatusQuestionablePtransitionReg { get; set; }

        /// <summary>
        /// Property for response from SLISt:NAME?
        /// </summary>
        string SequenceNameOfElement { get; set; }

        /// <summary>
        /// Property for response from SLISt:SEQuence:EVENt:PJUMp:ENABle?
        /// </summary>
        string SequenceEventPatternJumpEnable { get; set; }

        /// <summary>
        /// Property for response from SLISt:SEQuence:EVENt:PJUMp:DEFine?
        /// </summary>
        string SequenceEventPatternJumpDefine { get; set; }

        /// <summary>
        /// Property for response from SLISt:SEQuence:EVENt:PJUMp:SIZE?
        /// </summary>
        string SequenceEventPatternJumpSize { get; set; }

        /// <summary>
        /// Property for response from SLISt:SEQuence:EVENt:JTIMing?
        /// </summary>
        string SequenceEventPatternJumpTiming { get; set; }

        /// <summary>
        /// Property for response from SLISt:SEQuence:LENGth?
        /// </summary>
        string SequenceLength { get; set; }

        /// <summary>
        /// Using SLISt:SEQuence:STEP:RFlag?  gets the enable flag repeat state on or off
        /// </summary>
        string SequenceRepeatFlag { get; set; }

        /// <summary>
        /// Property for response from SLISt:SEQuence:STEP:EJUMp?
        /// </summary>
        string SequenceStepEventJumpOpertation { get; set; }

        /// <summary>
        /// Property for response from SLISt:SEQuence:STEP:EJINput?
        /// </summary>
        string SequenceStepEventJumpInput { get; set; }

        /// <summary>
        /// Property for response from SLISt:SEQuence:STEP:GOTO?
        /// </summary>
        string SequenceStepGoto { get; set; }

        /// <summary>
        /// Property for response from SLISt:SEQuence:STEP:MAX?
        /// </summary>
        string SequenceStepMax { get; set; }

        /// <summary>
        /// Property for response from SLISt:SEQuence:STEP:RCOunt?
        /// </summary>
        string SequenceStepRepeatCount { get; set; }

        /// <summary>
        /// Property for response from SLISt:SEQuence:STEP:RCOunt:MAX?
        /// </summary>
        string SequenceStepRepeatCountMax { get; set; }

        /// <summary>
        /// Property for response from SLISt:SEQuence:STEP:TASSet?
        /// </summary>
        string SequenceStepTrackAsset { get; set; }

        /// <summary>
        /// Property for response from SLISt:SEQuence:STEP[n]:TASSet[m]:TYPE?
        /// </summary>
        string SequenceStepTrackAssetType { get; set; }
        
        /// <summary>
        /// Property for response from SLISt:SEQuence:STEP:TRACk:MAX?
        /// </summary>
        string SequenceStepTrackCountMax { get; set; }
        
        /// <summary>
        /// Property for response from SLISt:SEQuence:STEP:TFLag[m]:[ALPHA]FLAG? 
        /// </summary>
        string SequenceStepTrackFlagValue { get; set; }

        /// <summary>
        /// Property for response from SLISt:SEQuence:STEP[n]:WAVeform[m]?
        /// </summary>
        string SequenceStepWaveformName { get; set; }

        /// <summary>
        /// Property for response from SLISt:SEQuence:STEP[n]:WINPut?
        /// </summary>
        string SequenceStepWaitInput { get; set; }

        /// <summary>
        /// Property for response from SLISt:SEQuence:TRACks?
        /// </summary>
        string SequenceNumberOfTracks { get; set; }

        /// <summary>
        /// Property for response from SLISt:SEQuence:TSTamp?
        /// </summary>
        string SequenceTimestamp { get; set; }

        /// <summary>
        /// Property for response from SLISt:SIZE?
        /// </summary>
        string SequenceListSize { get; set; }

        /// <summary>
        /// Property for Impedance for Trigger A<para>
        /// Update occurs with Get action</para>
        /// </summary>
        string TriggerImpedanceA { get; set; }

        /// <summary>
        /// Property for Impedance for Trigger B<para>
        /// Update occurs with Get action</para>
        /// </summary>
        string TriggerImpedanceB { get; set; }

        /// <summary>
        /// Property for Level for Trigger A<para>
        /// Update occurs with Get Action</para>
        /// </summary>
        string TriggerLevelA { get; set; }

        /// <summary>
        /// Property for Level for Trigger B<para>
        /// Update occurs with Get Action</para>
        /// </summary>
        string TriggerLevelB { get; set; }

        /// <summary>
        /// Property for the trigger mode of the AWG.<para>
        /// Today it is only one trigger mode for the instrument</para>
        /// </summary>
        string TriggerMode { get; set; }

        /// <summary>
        /// Property for interval for Internal Trigger<para>
        /// Update occurs with Get Action</para>
        /// </summary>
        string TriggerInterval { get; set; }

        /// <summary>
        /// Property for Trigger A Slope<para>
        /// Updated with a get action</para>
        /// </summary>
        string TriggerSlopeA { get; set; }

        /// <summary>
        /// Property for Trigger B Slope<para>
        /// Updated with a get action</para>
        /// </summary>
        string TriggerSlopeB { get; set; }

        /// <summary>
        /// Property updated with TRIGger:SOURce?
        /// </summary>
        string TriggerSource { get; set; }

        /// <summary>
        /// Property updated with TRIGger:WVALue?
        /// </summary>
        string TriggerWaitForValue { get; set; }

        /// <summary>
        /// Using SOURce:RCCouple set the Run Coupled Coupling mode
        /// </summary>
        /// <param name="setValue"></param>
        void SetSourceRunCoupledMode(string setValue);

        /// <summary>
        /// Using SOURce:RCCouple get the Run Coupled Coupling mode
        /// </summary>
        void GetSourceRunCoupledMode();

        /// <summary>
        /// Using SOURce:RMODe set the run mode
        /// </summary>
        /// <param name="logicalChannel">channel</param>
        /// <param name="setValue">Desired run mode</param>
        void SetSourceRunMode(string logicalChannel, string setValue);

        /// <summary>
        /// Updates the copy for the run mode for a given channel
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        void GetSourceRunMode(string logicalChannel);

        /// <summary>
        /// Return the copy of the run mode for the given channel
        /// </summary>
        /// <param name="logicalChannel">Depending on the awg, a number between 1 and 4</param>
        /// <returns>A copy of the Run mode for the given channel</returns>
        string SourceRunMode(string logicalChannel);

        /// <summary>
        /// Using set the multiplier rate of the external reference oscillator
        /// </summary>
        /// <param name="logicalClock">clock number</param>
        /// <param name="setValue">Oscillator multiplier value</param>
        void SetSourceReferenceOscillatorMultiplier(string logicalClock, string setValue);

        /// <summary>
        /// Update the copy of the multiplier rate of the external reference oscillator
        /// </summary>
        /// <param name="logicalClock">clock number</param>
        void GetSourceReferenceOscillatorMultiplier(string logicalClock);

        /// <summary>
        /// Given a logical clock, return the multiplier rate of the external reference oscillator
        /// </summary>
        /// <param name="logicalClock"></param>
        /// <returns></returns>
        string SourceReferenceMultiplier(string logicalClock);

        /// <summary>
        /// Using SOURce:SCSTep? get the Sequence Current STep.<para>
        /// Note, not real time</para>
        /// </summary>
        /// <param name="logicalChannel"></param>
        void GetSourceChannelCurrentStep(string logicalChannel);

        /// <summary>
        /// Return the copy of the current step for the given channel
        /// </summary>
        /// <param name="logicalChannel">Depending on the awg, a number between 1 and 4</param>
        /// <returns>A copy of the current step for the given channel</returns>
        string SourceSequenceCurrentStep(string logicalChannel);

        /// <summary>
        /// Set the skew for the waveform associated with a channel.
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        /// <param name="setValue">Skew</param>
        void SetSourceSkew(string logicalChannel, string setValue);

        /// <summary>
        /// Update the copy for the skew for the waveform associated with a channel.
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        void GetSourceSkew(string logicalChannel);

        /// <summary>
        /// Return the copy of the source skew for the given channel
        /// </summary>
        /// <param name="logicalChannel">Depending on the awg, a number between 1 and 4</param>
        /// <returns>A copy of the source skew for the given channel</returns>
        string SourceSkew(string logicalChannel);

        /// <summary>
        /// Set the Trigger input Source for the given clock
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Desired run mode</param>
        void SetSourceTriggerInput(string clockNumber, string setValue);

        /// <summary>
        /// Update the copy for the Source Trigger Input for a given channel
        /// </summary>
        /// <param name="logicalChannel">Depending on the awg a number between 1 and 4</param>
        void GetSourceTriggerInput(string logicalChannel);

        /// <summary>
        /// Return the copy of the trigger input for the given channel
        /// </summary>
        /// <param name="logicalChannel">Depending on the awg, a number between 1 and 4</param>
        /// <returns>A copy of the source skew for the given channel</returns>
        string SourceTriggerInput(string logicalChannel);

        /// <summary>
        /// Set a Source Voltage Amplitude
        /// </summary>
        /// <param name="logicalChannel">Channel</param>
        /// <param name="setValue">Source Amplitude</param>
        void SetSourceAnalogVoltageAmplitude(string logicalChannel, string setValue);

        /// <summary>
        /// Update the copy for a Source Voltage Amplitude
        /// </summary>
        /// <param name="logicalChannel">Channel</param>
        void GetSourceAnalogVoltageAmplitude(string logicalChannel);

        /// <summary>
        /// Given a logical channel, return the copy for a Source Voltage Amplitude
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        string SourceAnalogVoltageAmplitude(string logicalChannel);

        /// <summary>
        /// Set a Source Power Amplitude
        /// </summary>
        /// <param name="logicalChannel">Channel</param>
        /// <param name="setValue">Source Power Amplitude</param>
        void SetSourcePowerAmplitude(string logicalChannel, string setValue);

        /// <summary>
        /// Update the copy for a Source Power Amplitude
        /// </summary>
        /// <param name="logicalChannel">Channel</param>
        void GetSourcePowerAmplitude(string logicalChannel);

        /// <summary>
        /// Given a logical channel, return the copy for a Source power Amplitude
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        string SourcePowerAmplitude(string logicalChannel);

        /// <summary>
        /// Set the waveform voltage high for the given channel
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        /// <param name="setValue">Desired voltage</param>
        void SetSourceAnalogVoltageHigh(string logicalChannel, string setValue);

        /// <summary>
        /// Update the copy for the waveform voltage high for the given channel
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        void GetSourceAnalogVoltageHigh(string logicalChannel);

        /// <summary>
        /// Given a logical channel, return the copy for a Source Voltage High
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        string SourceAnalogVoltageHigh(string logicalChannel);

        /// <summary>
        /// Set the waveform voltage low for the given channel
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        /// <param name="setValue">Desired voltage</param>
        void SetSourceAnalogVoltageLow(string logicalChannel, string setValue);

        /// <summary>
        /// Update the copy for the waveform voltage low for the given channel
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        void GetSourceAnalogVoltageLow(string logicalChannel);

        /// <summary>
        /// Given a logical channel, return the copy for a Source Voltage Low
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        string SourceAnalogVoltageLow(string logicalChannel);

        /// <summary>
        /// Assigns the waveform from the current waveform list to a channel
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <param name="waveform">Name of waveform</param>
        void SetSourceWaveform(string channel, string waveform);

        /// <summary>
        /// Using [SOURce[n]]:WAVeform? get the output waveform from the current waveform list to a channel
        /// </summary>
        /// <param name="logicalChannel">Depending on AWG a number between 1 and 4</param>
        void GetSourceWaveform(string logicalChannel);

        /// <summary>
        /// Given a logical channel, return the copy for a assigned waveform name
        /// </summary>
        /// <param name="logicalChannel">Depending on AWG a number between 1 and 4</param>
        /// <returns></returns>
        string SourceWaveformAssignedName(string logicalChannel);

        /// <summary>
        /// Property for response from OUTPut[n]:ATTenuator:A1?
        /// </summary>
        string OutputFilterAttnA1Step { get; set; }

        /// <summary>
        /// Property for response from OUTPut[n]:ATTenuator:A2?
        /// </summary>
        string OutputFilterAttnA2Step { get; set; }

        /// <summary>
        /// Property for response from OUTPut[n]:ATTenuator:A3?
        /// </summary>
        string OutputFilterAttnA3Step { get; set; }

        /// <summary>
        /// Property for response from OUTPut[n]:ATTenuator:DAC?
        /// </summary>
        string OutputFilterAttnDACStep { get; set; }
 
        /// <summary>
        /// Property for response from OUTPut[n]:FILTer?
        /// </summary>
        string OutputFilterType { get; set; }

        /// <summary>
        /// Property for response from OUTPut[n]:FILTer:BPASs:RANGe?
        /// </summary>
        string OutputFilterBandPassRange { get; set; }

        /// <summary>
        /// Property for response from OUTPut[n]:MODE?
        /// </summary>
        string OutputModeType { get; set; }

        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:A1 sets the step value setting for A1 attenuator of a channel in units of dB.
        /// This is a blocking and unpublished command
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="filterStepValue">step increment value</param>
        void SetOutputFilterAttenuatorA1Step(string outputIndex, string filterStepValue);

        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:A1? gets the step value setting for A1 attenuator of a channel in units of dB.
        /// This is a blocking and unpublished command
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <returns>step increment value</returns>
        void GetOutputFilterAttenuatorA1Step(string outputIndex);

        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:A2 sets the step value setting for A2 attenuator of a channel in units of dB.
        /// This is a blocking and unpublished command
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="filterStepValue">step increment value</param>
        void SetOutputFilterAttenuatorA2Step(string outputIndex, string filterStepValue);

        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:A2? gets the step value setting for A2 attenuator of a channel in units of dB.
        /// This is a blocking and unpublished command
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <returns>step increment value</returns>
        void GetOutputFilterAttenuatorA2Step(string outputIndex);

        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:A3 sets the step value setting for A3 attenuator of a channel in units of dB.
        /// This is a blocking and unpublished command
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="filterStepValue">step increment value</param>
        void SetOutputFilterAttenuatorA3Step(string outputIndex, string filterStepValue);

        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:A3? gets the step value setting for A1 attenuator of a channel in units of dB.
        /// This is a blocking and unpublished command
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <returns>step increment value</returns>
        void GetOutputFilterAttenuatorA3Step(string outputIndex);
        
        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:DAC sets the step value setting for DAC attenuator of a channel in units of dB.
        /// This is a blocking and unpublished command
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="filterStepValue">step increment value</param>
        void SetOutputFilterAttenuatorDACStep(string outputIndex, string filterStepValue);

        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:DAC? gets the step value setting for DAC attenuator of a channel in units of dB.
        /// This is a blocking and unpublished command
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <returns>step increment value</returns>
        void GetOutputFilterAttenuatorDACStep(string outputIndex);

        //jmanning 09/22/2014
        /// <summary>
        /// Using OUTPut[n]:FILTer sets the filter type of the of the selected signal path
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="filterType">Type of Filter [NONE|BPASs|LPASs]</param>
        void SetOutputFilter(string outputIndex, string filterType);

        //jmanning 09/22/2014
        /// <summary>
        /// Using OUTPut[n]:FILTer? gets the filter type of the of the selected signal path
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <returns> Type of Filter [NONE|BPASs|LPASs]</returns>
        void GetOutputFilter(string outputIndex);
      
        //shkv 1/8/2015 Added fix for 5168
        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:FILTer:BPASs:RANGe sets the band pass filter range
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="filterRange">Type of Filter range</param>
        void SetOutputFilterBandPassRangeR13to18GHz(string outputIndex, string filterRange);
        void SetOutputFilterBandPassRangeR10to14GHz(string outputIndex, string filterRange);
        
        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:FILTer:BPASs:RANGe? gets the band pass filter range
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <returns>Type of Filter range</returns>
        void GetOutputFilterBandPassRange(string outputIndex);

        //jmanning 09/22/2014
        /// <summary>
        /// Using OUTPut[n]:MODE sets the signal path [DIRect|AC]
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="signalPath">Signal Path Type of Filter [DIRect|AC]</param>
        void SetOutputMode(string outputIndex, string signalPath);

        //jmanning 09/22/2014
        /// <summary>
        /// Using OUTPut[n]:MODE? gets the signal path [DIRect|AC]
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <returns> Signal Path Type of Filter [DIRect|AC]</returns>
        void GetOutputMode(string outputIndex);
        
        /// <summary>
        /// Using OUTPut:OFF set whether or not the "All Outputs Off" has been enabled
        /// </summary>
        /// <param name="value">Output off state to be set to</param>
        void SetOutputOff(string value);

        /// <summary>
        /// Forces this awg to updates it's copy of the output off mode
        /// </summary>
        void GetOutputOff();

        /// <summary>
        /// Set the output state.
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="value"></param>
        void SetOutputState(string channel, string value);

        /// <summary>
        /// Forces this awg to updates it's copy of the output state
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        void GetOutputState(string logicalChannel);

        /// <summary>
        /// Given a logical channel, return the channel output state
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        string OutputChannelState(string logicalChannel);

        /// <summary>
        /// Set the output data position of a waveform when in the stop state
        /// </summary>
        /// <param name="channel">Which %AWG machine number</param>
        /// <param name="value">Output data position of a waveform</param>
        void SetOutputStopAnalogState(string channel, string value);

        /// <summary>
        /// Forces this awg to updates it's copy of the output Stop Value Analog State
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        void GetOutputStopAnalogState(string logicalChannel);

        /// <summary>
        /// Given a logical channel, return the copy of the channel output stop value state
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        string OutputStopAnalogState(string logicalChannel);

        /// <summary>
        /// Set the output data position of a marker when the instrument is in the stop state
        /// </summary>
        /// <param name="channel">Which channel number</param>
        /// <param name="marker">Which marker number</param>
        /// <param name="value">Output data position of a waveform</param>
        void SetOutputStopMarkerState(string channel, string marker, string value);

        /// <summary>
        /// Forces this awg to updates it's copy of the output Stop Value Marker State
        /// </summary>
        /// <param name="logicalChannel">Which channel number</param>
        /// <param name="logicalMarker">Which marker number</param>
        void GetOutputStopMarkerState(string logicalChannel, string logicalMarker);

        /// <summary>
        /// Returns the awg's copy of the output Stop Value Marker State per channel
        /// </summary>
        /// <param name="logicalChannel">Which channel number</param>
        /// <param name="logicalMarker">Which marker number</param>
        /// <returns>Output data position of a waveform</returns>
        string OutputStopMarkerState(string logicalChannel, string logicalMarker);

        /// <summary>
        /// Set the output data position of channel while the instrument is in the waiting-for-trigger state
        /// </summary>
        /// <param name="logicalChannel">Which %AWG machine number</param>
        /// <param name="value">Output data position of a waveform</param>
        void SetOutputWaitForValueAnalogState(string logicalChannel, string value);

        /// <summary>
        /// Forces the awg to updates it's copy of the output Wait Value Analog State
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        void GetOutputWValueAnalogState(string logicalChannel);

        /// <summary>
        /// Given a logical channel, return the copy of the analog output wait value state for a channel
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        string OutputWaitAnalogState(string logicalChannel);

        /// <summary>
        /// Set the output data position of a marker while the instrument is in the waiting-for-trigger state
        /// </summary>
        /// <param name="channel">Which channel number</param>
        /// <param name="marker">Which marker number</param>
        /// <param name="value">Output data position of a waveform</param>
        void SetOutputWaitForTriggerMarkerState(string channel, string marker, string value);

        /// <summary>
        /// Forces this awg to updates it's copy of the output Wait for trigger Value Marker State
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        /// <param name="logicalMarker">Which marker number</param>
        void GetOutputTriggerMarkerState(string logicalChannel, string logicalMarker);

        /// <summary>
        /// Returns the awg's copy of the output Wait Value Marker State per channel
        /// </summary>
        /// <param name="logicalChannel">Which channel number</param>
        /// <param name="logicalMarker">Which marker number</param>
        /// <returns>Output data position of a waveform</returns>
        string OutputWaitMarkerState(string logicalChannel, string logicalMarker);

        /// <summary>
        /// Set the amplitude value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Function generator amplitude value</param>
        void SetFGenChannelAmplitude(string channel, string setValue);

        /// <summary>
        /// Force to update it's local copy of the amplitude value for the given channel
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        void GetFGenChannelAmplitude(string logicalChannel);

        /// <summary>
        /// Given a logical channel, return the channel amplitude
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        string FGenChannelAmplitude(string logicalChannel);

        /// <summary>
        /// Set the DC Level value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Function generator dclevel value</param>
        void SetFGenChannelDCLevel(string channel, string setValue);

        /// <summary>
        /// Force to update it's local ocpy of the DC Level value for the given channel
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        void GetFGenChannelDCLevel(string logicalChannel);

        /// <summary>
        /// Given a logical channel, return the channel DC level
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        string FGenChannelDcLevel(string logicalChannel);

        /// <summary>
        /// Set the frequency for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Function generator low value</param>
        void SetFGenChannelFrequency(string channel, string setValue);

        /// <summary>
        /// Force to update it's local copy of the frequency for the given channel
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        void GetFGenChannelFrequency(string logicalChannel);

        /// <summary>
        /// Given a logical channel, return the channel waveform type
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        string FGenChannelFrequency(string logicalChannel);

        /// <summary>
        /// Set the high value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Function generator high value</param>
        void SetFGenChannelHigh(string channel, string setValue);

        /// <summary>
        /// Force to update it's local copy of the high value for the given channel
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        void GetFGenChannelHigh(string logicalChannel);

        /// <summary>
        /// Given a logical channel, return the channel high
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        string FGenChannelHigh(string logicalChannel);

        /// <summary>
        /// Using FGEN:CHANnel:LOW set the low value for the given channel
        /// </summary>
        /// <param name="setValue">Function generator low value</param>
        /// <param name="channel">Which channel</param>
        void SetFGenChannelLow(string channel, string setValue);

        /// <summary>
        /// Force to update it's local copy of the low value for the given channel
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        void GetFGenChannelLow(string logicalChannel);

        /// <summary>
        /// Given a logical channel, return the channel low
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        string FGenChannelLow(string logicalChannel);

        /// <summary>
        /// Set the offset value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Function generator offset value</param>
        void SetFGenChannelOffset(string channel, string setValue);

        /// <summary>
        /// Force to update it's local copy of the offset value for the given channel
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        /// <returns>Function generator offset value</returns>
        void GetFGenChannelOffset(string logicalChannel);

        /// <summary>
        /// Given a logical channel, return the channel offset
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        string FGenChannelOffset(string logicalChannel);

        /// <summary>
        /// Force to update it's local copy of the period value for the given channel<para>
        /// (Query Only)</para>
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        void GetFGenChannelPeriod(string logicalChannel);

        /// <summary>
        /// Given a logical channel, return the channel period
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        string FGenChannelPeriod(string logicalChannel);

        /// <summary>
        /// Set the phase value for the given channel
        /// </summary>
        /// <param name="setValue">Function generator phase value</param>
        /// <param name="channel">Which channel</param>
        void SetFGenChannelPhase(string channel, string setValue);

        /// <summary>
        /// Force to update it's local copy of the phase value for the given channel
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        void GetFGenChannelPhase(string logicalChannel);

        /// <summary>
        /// Return the channel phase
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        string FGenChannelPhase(string logicalChannel);

        /// <summary>
        /// Set the symmetry value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">symmetry value</param>
        void SetFGenChannelSymmetry(string channel, string setValue);

        /// <summary>
        /// Force to update it's local copy of the symmetry value for the given channel
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        void GetFGenChannelSymmetry(string logicalChannel);

        /// <summary>
        /// Given a logical channel, return the channel symmetry
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        string FGenChannelSymmetry(string logicalChannel);

        /// <summary>
        /// Set the waveform type for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Waveform type</param>
        void SetFGenChannelType(string channel, string setValue);

        /// <summary>
        /// Force to update it's local copy of the waveform type for the given channel
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        void GetFGenChannelType(string logicalChannel);

        /// <summary>
        /// Given a logical channel, return the channel waveform type
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        string FGenChannelType(string logicalChannel);

        /// <summary>
        /// Using FGEN:COUPle:AMPLitude set the coupling amplitude Value
        /// </summary>
        /// <param name="setValue">FGen couple state</param>
        void SetFGenCoupleAmpl(string setValue);

        /// <summary>
        /// Force to update it's local copy of the state of the coupling amplitude
        /// </summary>
        void GetFGenCoupleAmpl(string logicalChannel = "1");

        /// <summary>
        /// Given a logical channel, return the channel waveform type
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        string FGenCoupleAmplitude(string logicalChannel = "1");

        /// <summary>
        /// Sets the coupling frequency state
        /// </summary>
        /// <param name="setValue">FGen couple state</param>
        void SetFGenCoupleFreq(string setValue);

        /// <summary>
        /// Force to update it's local copy of the state of the coupling frequency
        /// </summary>
        void GetFGenCoupleFreq(string logicalChannel = "1");

        /// <summary>
        /// Given a logical channel, return the couple frequency
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        string FGenCoupleFrequency(string logicalChannel = "1");

        void IdentifyYourself() // aka "IDN?"
            ;

        void LrnQuery();

        /// <summary>
        /// Returns the implemented options
        /// </summary>
        /// <returns>Options implemented</returns>
        string GetOPT();

        void Reset();

        /// <summary>
        /// Given a date string, set the AWG
        /// </summary>
        /// <param name="setValue"></param>
        void SystemDate(string setValue);

        /// <summary>
        /// Update the property that contains response of Using SYSTem:DATE?
        /// </summary>
        void SystemDateQuery();

        void SetSystemErrorDialog(string setValue);
        void GetSystemErrorDialog();

        /// <summary>
        /// Using the SYSTem:ERRor:COUNt?, query the error queue count 
        /// </summary>
        /// <returns>Return the number of errors in the system error queue</returns>
        void GetSystemErrorQueueCount();

        /// <summary>
        /// Sets the system time
        /// 
        /// SYSTem:TIME
        /// </summary>
        /// <param name="hour">System hour</param>
        /// <param name="minute">System minute</param>
        /// <param name="second">System second</param>
        void SystemTime(string hour, string minute, string second);

        /// <summary>
        /// Saves a snapshot in AWG's copy of the system time
        /// 
        /// SYSTem:TIME?
        /// </summary>
        void GetSystemTime();

        /// <summary>
        /// Get the current date string from the AWG and<para>
        /// update the local copy</para>
        /// </summary>
        void SystemDateUpdate();

        /// <summary>
        /// Updates the SystemError property from SYSTem:ERRor:NEXT? and<para>
        /// returns the string</para>
        /// </summary>
        /// <returns></returns>
        string SystemErrorQueue();

        void SystemVersionUpdate();

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
        void CapturePlaybackFile(string sigName, string fileType, string filePath1, string filePath2);
        #endregion CPLayback:CAPture:FILE

        #region CPLayback:COMPile
        //jmanning 09/22/2014
        /// <summary>
        /// Using CPLayback:COMPile to resamples and upconverts selected signals to specified carrier frequency
        /// </summary>
        void CompilePlaybackFiles();
        #endregion CPLayback:COMPile

        #region CPLayback:CLISt:SIGNal:SCOMPile
        //jmanning 09/22/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:SCOMPile selects/deselects a signal from the captured signal list to be compiled.
        /// </summary>
        /// <param name="sigName">Desired signal to import to captured signal list</param>
        /// <param name="boolCompile">boolean compile select state</param>
        /// 
        void SelectCompilePlaybackFile(string sigName, bool boolCompile);
        #endregion CPLayback:CLISt:SIGNal:SCOMPile

        #region CPLayback:CLISt:SIGNal:SCOMPile?
        //jmanning 09/22/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:SCOMPile selects/deselects a signal from the captured signal list to be compiled.
        /// </summary>
        /// <param name="sigName">Desired signal to import to captured signal list</param>
        /// <returns>Compile Select Status as a boolean</returns>
        void GetCompileSelectStatusPlaybackFile(string sigName);
        #endregion CPLayback:CLISt:SIGNal:SCOMPile?

        #region CPLayback:COMPile:CFRequency
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:COMPile:CFRequency sets the carrier frequency for the compiled signals.
        /// </summary>
        /// <param name="freqValue">Desired carrier frequency setting in Hz</param>
        /// 
        void SetCompileCarFrequency(string freqValue);
        #endregion CPLayback:COMPile:CFRequency

        #region CPLayback:COMPile:CFRequency?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:COMPile:CFRequency? gets the carrier frequency for the compiled signals.
        /// </summary>
        void GetCompileCarFrequency();
        #endregion CPLayback:COMPile:CFRequency?

        #region CPLAYBACK:COMPILE:SRATE
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:COMPile:SRATE sets the output sampling rate for the compiled signals.
        /// </summary>
        /// <param name="sampleRate">Desired sample rate in samples/s</param>
        /// 
        void SetCompileSampleRate(string sampleRate);
        #endregion CPLAYBACK:COMPILE:SRATE

        #region CPLAYBACK:COMPILE:SRATE?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:COMPile:SRATE? gets the output sampling rate for the compiled signals.
        /// </summary>
        /// <returns>Desired sample rate in samples/s</returns>
        /// 
        void GetCompileSampleRate();
        #endregion CPLAYBACK:COMPILE:SRATE?

        #region CPLayback:COMPile:SRATe:AUTO
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:COMPile:SRATe:AUTO command sets if the system will calculate output sampling rate automatically when compiling the selected signals.
        /// </summary>
        /// <param name="autoCalcState">Auto calculate sampe rate state</param>
        /// 
        void SetCompileSampleRateAuto(bool autoCalcState);
        #endregion CPLayback:COMPile:SRATe:AUTO

        #region CPLayback:COMPile:SRATe:AUTO?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:COMPile:SRATe:AUTO? query gets status  of if the system will calculate output sampling rate automatically when compiling the selected signals.
        /// </summary>
        /// <return>Auto calculate sampe rate state</return>
        /// 
        void GetCompileSampleRateAuto();
        #endregion CPLayback:COMPile:SRATe:AUTO?

        #region CPLayback:CLISt:NAME?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:NAME? query gets the name of a signal from the captured signal list in the position specified by the index value.  Index value is 1-based.
        /// </summary>
        /// <param name="listIndex">index position of signal in captured list</param>
        /// <return>Signal name from the captured signal list at index specified</return>
        /// 
        void GetCompileSignalName(string listIndex);
        #endregion CPLayback:CLISt:NAME?

        #region CPLayback:CLISt:SIGNal:DELete
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:DELete command removes the specified signal from the captured signal list. ALL clears the captured signal list.
        /// </summary>
        /// <param name="signalName">Signal name to delete. "ALL" deletes whole list</param>
        /// 
        void DeleteCompileSignal(string signalName);
        #endregion CPLayback:CLISt:SIGNal:DELete

        #region CPLayback:CLISt:SIZE?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIZE? query gets the Number of signals in the captured signal list.
        /// </summary>
        /// <return>Number of signals in the captured signal list</return>
        /// 
        void GetCompileSignalsSize();
        #endregion CPLayback:CLISt:SIZE?

        #region CPLayback:CLISt:SIGNal:OTIMe
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:OTIMe command sets the off time for the specified signal in the captured signal list.
        /// </summary>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <param name="offTime">time in seconds</param>
        /// 
        void SetCompileSignalOffTime(string signalName, string offTime);
        #endregion CPLayback:CLISt:SIGNal:OTIMe

        #region CPLayback:CLISt:SIGNal:OTIMe?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:OTIMe? query gets the off time for the specified signal in the captured signal list.
        /// </summary>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <returns> off time in seconds</returns>
        /// 
        void GetCompileSignalOffTime(string signalName);
        #endregion CPLayback:CLISt:SIGNal:OTIMe?

        #region CPLayback:CLISt:SIGNal:WCOunt?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:WCOunt? query gets the number of waveform contained in a signal in the captured signal list.
        /// </summary>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <returns> the number of waveform contained in specified signal</returns>
        /// 
        void GetCompileSignalWfmCount(string signalName);
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
        void GetCompileSignalWfmName(string signalName, string wfmIndex);
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
        void SetCompileWfmFreqOffset(string signalName, string wfmIndex, string freqValue);
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
        void GetCompileWfmFreqOffset(string signalName, string wfmIndex);
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
        void SetCompileWfmSampleRate(string signalName, string wfmIndex, string sampleRate);
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
        void GetCompileWfmSampleRate(string signalName, string wfmIndex);
        #endregion CPLayback:CLISt:SIGNal:WAVeform:SRATe?
        #endregion CapturePlayback

        /// <summary>
        /// Using AWGControl:CLOCk:DRATe, set the divider rate for the external clock<para>
        /// This is backward compatibile support only.  Use CLOCk:EREFerence:DIVider</para>
        /// </summary>
        void SetControlClockDividerRate(string clock, string value);

        /// <summary>
        /// Using AWGControl:CLOCk:DRATe?, get the divider rate for the external clock<para>
        /// This is backward compatibile support only.  Use CLOCk:EREFerence:DIVider?</para>
        /// </summary>
        void GetControlClockDividerRate(string clockNumber);

        /// <summary>
        /// Using AWGControl:CLOCk:PHASe:ADJust, set the internal clock phase<para>
        /// This is backward compatibile support only.  Use CLOCk:PHASEe:ADJust</para>
        /// </summary>
        void SetControlClockPhaseAdjust(string value);

        /// <summary>
        /// Using AWGControl:CLOCk:PHASe:ADJust?, update the property ControlClockPhaseAdjust<para>
        /// This is backward compatibile support only.  Use CLOCk:PHASEe:ADJust?</para>
        /// </summary>
        void GetControlClockPhaseAdjust();

        /// <summary>
        /// Forces to update the property number_of_channels
        /// </summary>  
        void FindNumberOfChannels();

        /// <summary>
        /// Return the number of channels that the AWG<para>
        /// thinks it has.  This would initially have been </para><para>
        /// updated when the AWG object was created.</para>
        /// </summary>
        /// <returns></returns>
        string GetNumberOfChannels();

        #region AWGControl:DOUTput[n][:STATe]
        //jmanning 09/24/2014
        /// <summary>
        /// Using AWGControl:DOUTput[n][:STATe] enables the raw DAC waveform outputs for the specified channel.
        /// </summary>
        /// <param name="channel">specified output channel</param>
        /// <param name="boolState">Desired enabled state</param>
        void SetControlDACState(string channel, string boolState);

        //jmanning 09/24/2014
        /// <summary>
        /// Using AWGControl:DOUTput[n][:STATe]? return the enable state for raw DAC waveform output for the specified channel.
        /// </summary>
        /// <param name="channel">specified output channel</param>
        /// <returns>state for raw DAC waveform output usage</returns>
        void GetControlDACState(string channel);
        #endregion AWGControl:DOUTput[n][:STATe]

        /// <summary>
        /// Using AWGControl:INTerleave:ADJustment:AMPLitude set the interleave amplitude adjustment as a percentage of the analog output voltage.
        /// </summary>
        /// <param name="setValue"></param>
        void SetInterleaveAdjustmentAmplitude(string setValue);

        /// <summary>
        /// Using AWGControl:INTerleave:ADJustment:AMPLitude? updates the property<para>
        /// ControlInterleaveAdjustmentAmplitude</para>
        /// </summary>
        void GetInterleaveAdjustmentAmplitude();

        /// <summary>
        /// Using AWGControl:INTerleave:ADJustment:PHASe set the interleave adjustment phase
        /// </summary>
        /// <param name="setValue"></param>
        void SetInterleaveAdjustmentPhase(string setValue);

        /// <summary>
        /// Using AWGControl:INTerleave:ADJustment:PHASe? updates the property ControlInterleaveAdjustmentPhase
        /// </summary>
        void GetInterleaveAdjustmentPhase();

        /// <summary>
        /// Using AWGControl:RMODe set the run mode of the %AWG
        /// </summary>
        /// <param name="setValue">Desired run mode</param>
        void SetRunMode(string setValue);

        /// <summary>
        /// Using AWGControl:RMODe? update property ControlRunMode
        /// </summary>
        void GetRunMode();

        /// <summary>
        /// Using AWGControl:RSTate? updates the property ControlRunState
        /// </summary>
        void GetRunState();

        /// <summary>
        /// Using AWGControl:RUN:IMMediate initiate the output of a waveform
        /// </summary>
        void RunImmediate();

        /// <summary>
        /// Using AWGControl:SNAMe? get the %AWG's most recently saved setup location
        /// </summary>
        void GetSavedSetupLocation();

        /// <summary>
        /// Using AWGControl:SREStore, load a setup as from a file<para>
        /// Preferred command is MMEMory:OPEN:SETup</para>
        /// </summary>
        /// <param name="filename">Path of the setup file</param>
        /// <param name="msus">>Mass storage unit specifier</param>
        void SetupRestore(string filename, string msus);

        /// <summary>
        /// Using AWGControl:SSAVe, save an %AWG setup as a file<para>
        /// Perferred command is MMEMory:SAVE:SETup.</para>
        /// </summary>
        /// <param name="filename">Path of the setup file</param>
        /// <param name="msus">Mass storage unit specifier</param>
        void SetupSave(string filename, string msus);

        /// <summary>
        /// Using AWGControl:STOP:IMMediate, stop the requested AWG's output
        /// </summary>
        void StopImmediate();

        void UpdateVisaExtSession();
        void VisaSessionRead();
        void VisaSessionWrite(string command);
        string VisaSessionQuery(string commandLine);
        bool VisaSessionOpen(string awgConnection);
        void VisaSessionClose();
        string ErrorDescription();

        /// <summary>
        /// Updates the local copy the current contents and state of the mass storage media.
        /// </summary>
        /// <param name="msus">Mass storage unit specifier</param>
        void UpdateMemoryCatalog(string msus);

        /// <summary>
        /// Set the current directory of the current msus
        /// </summary>
        /// <param name="path">Current directory path</param>
        void SetMemoryCDirectory(string path);

        /// <summary>
        /// Update the local copy of the current directory
        /// </summary>
        void UpdateMemoryCDirectory();

        /// <summary>
        /// Write data onto the %AWG hard disk
        /// </summary>
        /// <param name="filePath">The path to write to</param>
        /// <param name="startPosition">The position to start writing at</param>
        /// <param name="blockOfData">The data to write</param>
        void SetMemoryData(string filePath, string startPosition, string blockOfData);

        /// <summary>
        /// Read data from the %AWG hard disk and store the information locally in block data
        /// </summary>
        /// <param name="filePath">The path to read from</param>
        /// <param name="startPosition">The position to start reading from</param>
        /// <param name="sizeOfData">The size to read</param>
        void UpdateMemoryData(string filePath, string startPosition, string sizeOfData = "");

        /// <summary>
        /// Updates local dataSize for the given file
        /// </summary>
        /// <param name="filePath">Path of the file to be sized</param>
        void UpdateMemoryDataSize(string filePath);

        /// <summary>
        /// Delete a file or directory from the %AWG's hard disk
        /// </summary>
        /// <param name="fileName">File or directory path to be deleted</param>
        /// <param name="msus">Mass storage unit specifier</param>
        void MemoryDelete(string fileName, string msus);

        /// <summary>
        /// Imports a file
        /// </summary>
        /// <param name="wfmName">Desired waveform to import</param>
        /// <param name="wfmType">waveform type</param>
        /// <param name="fileName">file name</param>
        void MemoryImport(string wfmName, string wfmType, string fileName);

        /// <summary>
        /// Sets the normalize type for import
        /// </summary>
        /// <param name="type">normalization type</param>
        void SetMemoryImportNormalize(string type);

        /// <summary>
        /// Update local copy of the import parameter normalize type
        /// </summary>
        void UpdateMemoryImportNormalize();

        /// <summary>
        /// Creates a new directory in the current path.
        /// </summary>
        /// <param name="directoryName"></param>
        void MemoryMDirectory(string directoryName);

        //jmanning 9/04/2014
        /// <summary>
        /// Updates the recently opened waveforms using MMEMory:MROPened[:WAVeforms]?
        /// </summary>
        /// <returns>Names of waveforms recently opened</returns>
        void UpdateMemoryRecentWaveformsOpened();

        //jmanning 9/04/2014
        /// <summary>
        /// Updates the recently opened sequences using MMEMory:MROPened:SEQuences?
        /// </summary>
        /// <returns>Names of sequences recently opened</returns>
        void UpdateMemoryRecentSequencesOpened();

        /// <summary>
        /// Sets the mass storage device used by all the MEMMory commands.
        /// </summary>
        /// <param name="drive">Drive letter</param>
        void SetMemoryDrive(string drive);

        /// <summary>
        /// Update the local copy of the current drive of the mass storage device used by all the MMEmory commands
        /// </summary>>
        void UpdateMemoryDrive();

        /// <summary>
        /// Opens a waveform
        /// </summary>
        /// <param name="fileName">file name</param>
        void MemoryOpen(string fileName);

        /// <summary>
        /// Sets a normalization type(mode) for open
        /// </summary>
        /// <param name="type">type of normalization</param>
        void SetMemoryOpenNormalize(string type);

        /// <summary>
        /// Update the local copy of the normalization mode for open
        /// </summary>
        void UpdateMemoryOpenNormalize();

        /// <summary>
        /// Opens desired waveforms from an .AWG file or a native setup file<para>
        /// into the arbitrary waveform generator’s assets.</para>
        /// </summary>
        /// <param name="fileName">Path to the Setup file</param>
        /// <param name="desiredWfm">Optional names of a desired waveforms to open</param>
        void OpenMemorySasset(string fileName, string desiredWfm);

        //shkv - added to support MMEMory:OPEN
        /// <summary>
        /// Opens desired waveforms from an .AWG file or a native setup file<para>
        /// into the arbitrary waveform generatorâ€™s assets.</para>
        /// </summary>
        /// <param name="fileName">Path to the Setup file</param>
        /// <param name="desiredWfm">Optional names of a desired waveforms to open</param>
        void OpenMemory(string fileName, string desiredWfm);

        /// <summary>
        /// Using MMEMory:OPEN:SASSetSEQuence: opens all or a desired sequence
        /// </summary>
        /// <param name="filePath">Path to the Setup file</param>
        /// <param name="desiredSequence">Optional names of a desired waveforms to open</param>
        void OpenMemorySassetSequence(string filePath, string desiredSequence);


        //jmanning 9/04/2014
        /// <summary>
        /// Updates the name of the most recently opened sequence using MMEMory:OPEN:SASSet:SEQuence:MROPened?
        /// </summary>
        /// <returns>Names of sequence most recently opened</returns>
        void UpdateMemoryMostRecentSequenceOpened();

        /// <summary>
        /// Using MMEMory:OPEN:SETup opens a setup file
        /// </summary>
        /// <param name="fileName">The name of the file to open</param>
        void MemoryOpenSetup(string fileName);

        /// <summary>
        /// Opens a text file.
        /// </summary>
        /// <param name="fileName">Path of the text file</param>
        /// <param name="bitDepth">OPTIONAL: The bit depth of the text file required for digital</param>
        void MemoryOpenTxt(string fileName, string bitDepth);

        /// <summary>
        /// Saves the current state of the AWG as a setup file
        /// </summary>
        /// <param name="filepath">Path to save the setup file</param>
        /// <param name="wAssets">Flag for including assets with the setup file</param>
        void MemorySaveSetup(string filepath, string wAssets);

        /// <summary>
        /// Saves the given asset as a TXT file
        /// </summary>
        /// <param name="assetName">Name of the asset to saved</param>
        /// <param name="filepath">New name and place to save the TXT file</param>
        /// <param name="fileType">Type of the text file to be saved</param>
        void MemorySaveTXT(string assetName, string filepath, string fileType);

        /// <summary>
        /// Using MMEMory:SAVE:WFMX saves the given asset as a WFMX file
        /// </summary>
        /// <param name="assetName">Name of the file to saved</param>
        /// <param name="filepath">New name and place to save the WFMX file</param>
        void MemorySaveWFMX(string assetName, string filepath);

        /// <summary>
        /// Using MMEMory:SAVE:WFMX saves the given asset as a WFMX file
        /// </summary>
        /// <param name="assetName">Name of the file to saved</param>
        /// <param name="filepath">New name and place to save the WFMX file</param>
        void MemorySaveSEQX(string assetName, string filepath);

        /// <summary>
        /// Sets the plot display state for this AWG
        /// </summary>
        /// <param name="state">The state to set the Display Plot to</param>
        void SetDisplayState(string state);

        /// <summary>
        /// Updates the copy of the plot display state of this AWG
        /// </summary>
        void GetDisplayState();

        /// <summary>
        /// Using CLOCk:ECLock:DIVider to set the divider
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Divide by a power of 2</param>
        void SetClockExternalDivider(string clockNumber, string setValue);

        /// <summary>
        /// Using CLOCk:ECLock:DIVider? to get the divider setting
        /// </summary>
        /// <param name="logicalClock">Which clock</param>
        void GetClockExternalDivider(string logicalClock);

        /// <summary>
        /// Return the updated external clock divider rate per clock
        /// </summary>
        /// <param name="logicalClock"></param>
        /// <returns></returns>
        string ClockExternalDivider(string logicalClock);

        /// <summary>
        /// Using CLOCk:ECLock:FREQuency to set expected frequency being<para>
        /// provided by the external clock</para>
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Frequency being provided by the external clock</param>
        void SetClockExternalClockFrequency(string clockNumber, string setValue);

        /// <summary>
        /// Using CLOCk:ECLock:FREQuency? to get expected frequency being provided by the external clock
        /// </summary>
        /// <param name="logicalClock">Which clock</param>
        void GetClockExternalClockFrequency(string logicalClock);

        /// <summary>
        /// Return the updated external clock frequency per clock
        /// </summary>
        /// <param name="logicalClock"></param>
        /// <returns></returns>
        string ClockExternalClockFrequency(string logicalClock);

        /// <summary>
        /// Using CLOCk:ECLock:FREQuency:ADJust to tell a specified<para>
        /// clock to calibrate to the external clock</para>
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        void AdjustClockExternalClockFrequency(string clockNumber);

        /// <summary>
        /// Using CLOCk:ECLock:FREQuency:DETect to tell the system to acquire the external clock and adjust the system to use it
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        void ClockExternalClockFrequencyAuto(string clockNumber);

        /// <summary>
        /// Using CLOCk:ECLock:MULTiplier it sets the multipler rate of the external clock
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Multipler rate of the external clock</param>
        void SetExternalClockMultiplier(string clockNumber, string setValue);

        /// <summary>
        /// Using CLOCk:ECLock:MULTiplier? it gets the multipler rate of the external clock
        /// </summary>
        /// <param name="logicalClock">Which clock</param>
        void GetExternalClockMultiplier(string logicalClock);

        /// <summary>
        /// Return the updated external clock divider rate per clock
        /// </summary>
        /// <param name="logicalClock"></param>
        /// <returns></returns>
        string ClockMultipler(string logicalClock = "1");

        /// <summary>
        /// Using CLOCk:EREFerence:DIVider to set the divider rate of the<para>
        /// external reference signal when the external reference is variable</para>
        /// </summary>
        /// <param name="clockNumber"></param>
        /// <param name="setValue"></param>
        void SetExternalReferenceClockDivider(string clockNumber, string setValue);

        /// <summary>
        /// Using CLOCk:EREFerence:DIVider? to get the divider rate of the<para>
        /// external reference signal when the external reference is</para><para>
        /// variable and makes local copy</para>
        /// </summary>
        /// <param name="logicalClock"></param>
        void GetExternalReferenceClockDivider(string logicalClock);

        /// <summary>
        /// Returns the updated divider rate of the external reference
        /// </summary>
        /// <param name="logicalClock"></param>
        /// <returns></returns>
        string ExternalReferenceClockDivider(string logicalClock);

        /// <summary>
        /// Sets expected frequency being provided by the external clock
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Frequency being provided by the external reference</param>
        void SetClockExternalReferenceFrequency(string clockNumber, string setValue);

        /// <summary>
        /// Updates the AWG object with expected frequency being provided by the external reference
        /// </summary>
        /// <param name="logicalClock">Which clock</param>
        void GetClockExternalReferenceFrequency(string logicalClock = "1");

        /// <summary>
        /// Returns the updated frequency of the external reference
        /// </summary>
        /// <param name="logicalClock"></param>
        /// <returns></returns>
        string ClockExternalReferenceFrequency(string logicalClock = "1");

        /// <summary>
        /// Using CLOCk:EREFerence:FREQuency:DETect tell the system to acquire the external reference and adjust the system to use it
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        void ForceClockExternalReferenceFrequencyDetect(string clockNumber);

        /// <summary>
        /// Using CLOCk:EREFerence:MULTiplier to set the multiplier of the external reference signal when the external reference is variable
        /// </summary>
        /// <param name="clockNumber"></param>
        /// <param name="setValue"></param>
        void SetExternalReferenceClockMultiplier(string clockNumber, string setValue);

        /// <summary>
        /// Gets the multiplier of the external reference signal when the external reference is variable
        /// </summary>
        /// <param name="logicalClock"></param>
        void GetExternalReferenceClockMultiplier(string logicalClock);

        string ExternalReferenceClockMultiplier(string logicalClock);

        /// <summary>
        /// Using CLOCk:JITTer to set whether low jitter is enabled on the system.
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Jitter boolean</param>
        void SetClockJitter(string clockNumber, string setValue);

        /// <summary>
        /// Using CLOCk:JITTer? to get whether low jitter is enabled on the system.
        /// </summary>
        /// <param name="logicalClock">Which clock</param>
        void GetClockJitter(string logicalClock);

        /// <summary>
        /// Return the updated clock jitter
        /// </summary>
        /// <param name="logicalClock"></param>
        /// <returns></returns>
        string ClockJitter(string logicalClock);

        /// <summary>
        /// Using CLOCk:OUTput:FREQuency? to get the output frequency of the specified clock.
        /// </summary>
        /// <param name="logicalClock">Which clock</param>
        void GetClockOutputFrequency(string logicalClock);

        string ClockOutputFrequency(string logicalClock);

        /// <summary>
        /// Using CLOCk:OUTput:STATe to set the output state of the specified clock.
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Output state</param>
        void SetClockOutputState(string clockNumber, string setValue);

        /// <summary>
        /// Using CLOCk:OUTput:STATe? to get the output state of the specified clock.
        /// </summary>
        /// <param name="logicalClock">Which clock</param>
        void GetClockOutputState(string logicalClock);

        string ClockOutputState(string logicalClock);

        /// <summary>
        /// Using CLOCk:PHASe:ADJust to set the internal clock phase adjustment of the AWG
        /// </summary>
        /// <param name="clockNumber"></param>
        /// <param name="setValue"></param>
        void SetClockPhaseAdjust(string clockNumber, string setValue);

        /// <summary>
        /// Using CLOCk:PHASe:ADJust? to get the internal clock phase adjustment of the AWG and<para> 
        /// update local copy and return a string version.</para>
        /// </summary>
        /// <param name="logicalClock"></param>
        void GetClockPhaseAdjust(string logicalClock);

        string ClockPhaseAdjust(string logicalClock);

        /// <summary>
        /// Using CLOCk:SOURce to set the source of the clock.
        /// </summary>
        /// <param name="clockNumber"></param>
        /// <param name="setValue"></param>
        void SetClockSource(string clockNumber, string setValue);

        /// <summary>
        /// Using CLOCk:SOURce? to get the source of the clock.
        /// </summary>
        /// <param name="logicalClock">One of the available clocks</param>
        void GetClockSource(string logicalClock);

        string ClockSource(string logicalClock);

        /// <summary>
        /// Using CLOCk:SOUT:STATe to set the state of the Sync Clock Out output
        /// </summary>
        /// <param name="clockNumber"></param>
        /// <param name="setValue"></param>
        void SetClockSoutState(string clockNumber, string setValue);

        /// <summary>
        /// Using CLOCk:SOUT:STATe? to get the state of the Sync Clock Out output
        /// </summary>
        /// <param name="logicalClock">One of the available clocks</param>
        void GetAwgClockSoutState(string logicalClock);

        string ClockSoutState(string logicalClock);

        /// <summary>
        /// Using CLOCk:SRATe to set the sample rate for the given clock
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Sample Rate</param>
        void SetClockSRate(string clockNumber, string setValue);

        /// <summary>
        /// Using CLOCk:SRATe? the sample rate for the given clock, makes a copy<para>
        /// and returns the string</para>
        /// </summary>
        /// <param name="logicalClock">Which clock</param>
        void GetClockSRate(string logicalClock);

        string ClockSampleRate(string logicalClock);

        /// <summary>
        /// Sends a *CAL? query and saves the response in calibration_state
        /// </summary>
        void CalRunSaveResults();

        /// <summary>
        /// Abort running of calibration.
        /// </summary>
        void CalAbort();

        /// <summary>
        /// Writes the CAL:ALL command
        /// </summary>
        void CalAll();

        /// <summary>
        /// Performs a calibration and saves results in local calibration_state
        /// </summary>
        void CalAllQuery();

        /// <summary>
        /// Sends a CAL:CAT? command and updates the object's local copy of the list
        /// </summary>
        void CalCatalogQuery(string optionalSubsystem = "", string optionalArea = "");

        /// <summary>
        /// Sets the halt value to what is specified in the setValue variable.
        /// </summary>
        /// <param name="setValue">Value used to set the boolean HALT variable.</param>
        void CalHalt(string setValue);

        /// <summary>
        /// Queries and updates the lcoal copy of cal_halt
        /// </summary>
        void CalHaltQuery();

        /// <summary>
        /// Sets the value of the calibration loop control
        /// </summary>
        /// <param name="setValue">Loop value desired to set.</param>
        void CalLoop(string setValue);

        /// <summary>
        /// Queries and updates the local copy of cal_loop_state
        /// </summary>
        void CalControlLoopQuery();

        /// <summary>
        /// Sets the calibration loop count value.
        /// </summary>
        /// <param name="setValue">Desired loop count value to be set</param>
        void CalLoopCount(string setValue);

        /// <summary>
        /// Queries and updates the local copy of loop count value.
        /// </summary>
        void CalLoopCountQuery();

        /// <summary>
        /// Queries, updates local copy and returns the calibration factory data from specified area.
        /// </summary>
        /// <param name="requiredSubsystem">The subsystem being queried</param>
        /// <param name="optionalArea">The area being queried (optional)</param>
        /// <param name="optionalProcedure"></param>
        void GetCalDataFactory(string requiredSubsystem, string optionalArea, string optionalProcedure);

        /// <summary>
        /// Writes a set of calibration constants to an area
        /// </summary>
        /// <param name="calConstantsAsXml">Valid xml formated string.  Ideally it is for the subsystem, area and procedure as specified</param>
        /// <param name="requiredSubsystem"></param>
        /// <param name="optionalArea"></param>
        /// <param name="optionalProcedure"></param>
        void CalDataUser(string calConstantsAsXml, string requiredSubsystem, string optionalArea = "", string optionalProcedure = "");

        /// <summary>
        /// Queries, updates local copy and returns the calibration user data from specified area.
        /// </summary>
        /// <param name="requiredSubsystem"></param>
        /// <param name="optionalArea"></param>
        /// <param name="optionalProcedure"></param>
        void CalDataUserQuery(string requiredSubsystem, string optionalArea, string optionalProcedure);

        /// <summary>
        /// Gets and returns the calibration log results.
        /// </summary>
        void GetCalLog();

        /// <summary>
        /// Sends the clear command to the calibration log.
        /// </summary>
        void CalLogClear();

        /// <summary>
        /// Writes the CAL:LOG:FAIL command with given setValue
        /// </summary>
        /// <param name="setValue">The desired value for the failures only flag</param>
        void CalSetForceFailure(string setValue);

        /// <summary>
        /// Queries and updates the local copy of the calibration Fail Only flag
        /// </summary>
        void CalFailOnlyQuery();

        /// <summary>
        /// Sets the detail flag to the setValue in the cal logs
        /// </summary>
        /// <param name="setValue">Desired value for the details flag in the cal logs</param>
        void CalSetDetail(string setValue);

        /// <summary>
        /// Gets and updates the local copy of detail flag for the cal logs
        /// </summary>
        void CalDetailsQuery();

        /// <summary>
        /// Queries and returns the number of calibration loops completed.
        /// </summary>
        void CalLoopQuery();

        /// <summary>
        /// Forces the AWG to update it's copy of cal result
        /// </summary>
        /// <param name="optionalSubsystem">The optional subsystem being queried</param>
        /// <param name="optionalArea">The optional area being queried</param>
        /// <param name="optionalProcedure">The optional procedure being queried</param>
        void CalResult(string optionalSubsystem = "", string optionalArea = "", string optionalProcedure = "");

        /// <summary>
        /// Forces the AWG to update it's copy of cal result temp
        /// 
        /// </summary>
        /// <param name="optionalSubsystem">The optional subsystem being queried</param>
        /// <param name="optionalArea">The optional area being queried</param>
        /// <param name="optionalProcedure">The optional procedure being queried</param>
        void CalResultTemperature(string optionalSubsystem = "", string optionalArea = "", string optionalProcedure = "");

        /// <summary>
        /// Gets the specified calibration procedure result's time
        /// </summary>
        /// <param name="optionalSubsystem">The optional subsystem being queried</param>
        /// <param name="optionalArea">The optional area being queried</param>
        /// <param name="optionalProcedure">The optional procedure being queried</param>
        void CalResultTime(string optionalSubsystem = "", string optionalArea = "", string optionalProcedure = "");

        /// <summary>
        /// Returns whether a calibration procedure is running
        /// </summary>
        /// <returns>A string of colon separated "subsystem", "area:" and "procedure" if running or "" if not.</returns>
        string CalRunning();

        /// <summary>
        /// Selects calibration procedures specified by the selection variable.
        /// </summary>
        /// <param name="requiredSubsystem">Valid subsystem name</param>
        /// <param name="optionalArea">Valid area name</param>
        /// <param name="optionalProcedure">Valid procedure name</param>
        void CalSelect(string requiredSubsystem, string optionalArea = "", string optionalProcedure = "");

        /// <summary>
        /// Checks to see if a the test specified by the test variable is selected or unselected.
        /// </summary>
        /// <param name="requiredSubsystem">Valid subsystem name</param>
        /// <param name="requiredArea">Valid area name</param>
        /// <param name="requiredProcedure">Valid procedure name</param>
        /// <returns>Returns a 1 if the test is selected or a 0 if it is unselected</returns>
        string CalSelectVerify(string requiredSubsystem, string requiredArea, string requiredProcedure);

        /// <summary>
        /// Starts internal calibration using the CALibration:STARt command
        /// </summary>
        void CalStart();

        /// <summary>
        /// Queries and updates local cal_state_factory with results
        /// </summary>
        /// <param name="subsystem">The subsystem being queried (optional)</param>
        /// <param name="area">The area being queried (optional)</param>
        void CalFactoryStateQuery(string subsystem, string area);

        /// <summary>
        /// Queries and updates the local cal stop state.
        /// </summary>
        void CalStopState();

        /// <summary>
        /// Sets the calibration type
        /// </summary>
        /// <param name="calType">Calibration type to set on the AWG</param>
        void CalType(string calType);

        /// <summary>
        /// Queries for the current calibration type and updates local copy<para>
        /// calibration_type</para>
        /// </summary>
        void CalTypeQuery();

        /// <summary>
        /// Using Cal:Type:Cat? Update the CalibrationTypeCatalog property
        /// </summary>
        void CalTypeCatalogQuery();

        /// <summary>
        /// Unselects calibration procedures specified by the selection variable.
        /// </summary>
        /// <param name="requiredSubsystem">Valid subsystem name</param>
        /// <param name="optionalArea">Valid area name</param>
        /// <param name="optionalProcedure">Valid procedure name</param>
        void CalUnselect(string requiredSubsystem, string optionalArea = "", string optionalProcedure = "");

        /// <summary>
        /// Gets the current user state of the calibration for the AWG.
        /// </summary>
        /// <param name="subsystem">The subsystem being queried (optional)</param>
        /// <param name="area">The area being queried (optional)</param>
        void CalUserStateQuery(string subsystem, string area);

        /// <summary>
        /// Sets the active mode
        /// </summary>
        /// <param name="command">Active mode selection of cal, diag, or norm</param>
        void DiagActiveMode(string command);

        /// <summary>
        /// Gets the active mode and updates the object's local copy diag_active_mode
        /// </summary>
        void DiagActiveModeQuery();

        /// <summary>
        /// Aborts Diagnostics
        /// </summary>
        void DiagAbort();

        /// <summary>
        /// Sends No-Op string to PI for use in debugging CallMonitor sessions (and whatever else you can think of)
        /// </summary>
        /// <param name="comment">The text string you want to see in the CallMonitor log</param>
        void DiagComment(string comment);

        void DiagDelayInMSec(string delayInMSec);

        string DiagManufacturingMode();

        /// <summary>
        /// Sets the value of the loop count for diagnostics.
        /// </summary>
        /// <param name="setValue">Value of the loop count</param>
        void DiagControlCount(string setValue);

        /// <summary>
        /// Forces the AWG to update it's local copy of the loop count
        /// </summary>
        void DiagControlCountQuery();

        /// <summary>
        /// Sets the diagnostic loop setting 
        /// </summary>
        /// <param name="setting">Diagnostic loop setting</param>
        void DiagControlLoop(string setting);

        /// <summary>
        /// Update the local copy of the diagnostic loop setting 
        /// </summary>
        void DiagControlLoopQuery();

        /// <summary>
        /// Gets results of last executed diagnostic test
        /// </summary>
        void DiagData();

        /// <summary>
        /// Sets the value of halt for diagnostics.
        /// </summary>
        /// <param name="setValue">Halt value (OFF|ON)</param>
        void DiagHalt(string setValue);

        /// <summary>
        /// Gets the value of halt for diagnostics.
        /// </summary>
        void DiagHaltQuery();

        /// <summary>
        /// Executes all of the NORMal diagnostic tests
        /// </summary>
        void DiagImmediate();

        /// <summary>
        /// Executes the selected tests and returns the results<para>
        /// in the form of a numeric of values of 0 for no errors </para><para>
        /// or -330 for one or more tests failed.</para><para>
        /// Results are saved in a local copy.</para>
        /// </summary>
        void DiagImmediateQuery();

        /// <summary>
        /// Using DIAG:CAT? get the diagnostic catalog
        /// </summary>
        void GetDiagCatalog(string subsystem = "", string area = "");

        /// <summary>
        /// Given a valid index (with in range), return the nth<para>
        /// subsystem, where n is the index</para>
        /// </summary>
        /// <param name="subsystemIndex"></param>
        void SelectDiagSubsystemFromPropertyList(string subsystemIndex);

        /// <summary>
        /// Given a valid index (with in range), assign the nth<para>
        /// area, where n is the index, to the selected area property</para>
        /// </summary>
        /// <param name="areaIndex"></param>
        void SelectDiagAreaFromPropertyList(string areaIndex);

        /// <summary>
        /// Given a valid index (with in range), assign the nth<para>
        /// test, where n is the index, to the selected test property</para>
        /// </summary>
        /// <param name="testIndex"></param>
        void SelectDiagTestFromPropertyList(string testIndex);

        /// <summary>
        /// Gets the diagnostic log and saves a local copy
        /// </summary>
        void DiagLogQuery();

        /// <summary>
        /// Clears the diagnostic log
        /// </summary>
        void DiagLogClear();

        /// <summary>
        /// Changes the diagnostics log to more or less detailed
        /// </summary>
        /// <param name="setValue">Log detail flag value</param>
        void DiagLogDetails(string setValue);

        /// <summary>
        /// Gets and saves the diagnostics log detail flag value locally
        /// </summary>
        void DiagLogDetailsQuery();

        /// <summary>
        /// Changes the diagnostics log to enable or disable failure mode
        /// </summary>
        /// <param name="setValue">Log detail flag value</param>
        void DiagLogFailuresOnly(string setValue);

        /// <summary>
        /// Gets the diagnostics log failure mode and saves a copy
        /// </summary>
        void DiagLogFailuresOnlyQuery();

        //glennj 3/18/2014
        /// <summary>
        /// Get the current completed loop counts
        /// </summary>
        void GetDiagLoops();

        /// <summary>
        /// Gets the results of one or more tests and saves it locally in diag_result
        /// </summary>
        /// <param name="optionalSubsystem"></param>
        /// <param name="optionalArea"></param>
        /// <param name="optionalTest"></param>
        void DiagResultQuery(string optionalSubsystem = "", string optionalArea = "", string optionalTest = "");

        /// <summary>
        /// Gets the highest temperature during specified diag test.
        /// </summary>
        /// <param name="path">Specified diagnostic test</param>
        void DiagResultTempQuery(string optionalSubsystem = "", string optionalArea = "", string optionalTest = "");

        /// <summary>
        /// Gets the time during specified diag test.
        /// </summary>
        /// <param name="path">Specified diagnostic test</param>
        void DiagResultTimeQuery(string optionalSubsystem = "", string optionalArea = "", string optionalTest = "");

        /// <summary>
        /// Verifies that Diagnostic tests are currently running on the AWG
        /// </summary>
        void GetDiagRunningState();

        /// <summary>
        /// Selects the specified test in the specified category context.
        /// </summary>
        /// <param name="requiredSubsystem"></param>
        /// <param name="optionalArea"></param>
        /// <param name="optionalTest"></param>
        void DiagSelect(string requiredSubsystem, string optionalArea = "", string optionalTest = "");

        /// <summary>
        /// Unselects the specified test in the specified category context.
        /// </summary>
        /// <param name="requiredSubsystem"></param>
        /// <param name="optionalArea"></param>
        /// <param name="optionalTest"></param>
        void DiagUnselect(string requiredSubsystem, string optionalArea = "", string optionalTest = "");

        /// <summary>
        /// Compares the specified test in the specified category context expecting a selected state.
        /// </summary>
        /// <param name="requiredSubsystem"></param>
        /// <param name="requiredlArea"></param>
        /// <param name="requiredTest"></param>
        /// <returns>String indicating if the test is selected</returns>
        string DiagSelectVerifyQuery(string requiredSubsystem, string requiredlArea, string requiredTest);

        /// <summary>
        /// Runs the %AWG Diagnostic
        /// </summary>
        void DiagStart();

        /// <summary>
        /// Stops the %AWG diagnostics after current test is complete
        /// </summary>
        void DiagStop();

        /// <summary>
        /// Gets the diagnostic stop state and saves in a local copy
        /// </summary>
        void DiagStopStateQuery();

        /// <summary>
        /// Sets the type or context of the diagnostic tests on the AWG
        /// </summary>
        /// <param name="type">Category of available tests</param>
        void DiagType(string type);

        /// <summary>
        /// Gets the type and updates the object's local copy of diagnostic_type
        /// </summary>
        void DiagTypeQuery();

        /// <summary>
        /// Gets the diagnostic type categories available.
        /// </summary>
        void DiagTypeCategory();

        /// <summary>
        /// Runs a POST and returns result
        /// </summary>
        void TstQuery();

        /// <summary>
        /// Using WLISt:LAST? to update WaveformListLast with the<para>
        /// last added names of the waveforms to the waveform list.</para>
        /// </summary>
        void GetWListLast();

        /// <summary>
        /// Using WLISt:LIST? return the names of the waveforms in the waveform list.<para>
        /// Note.  Limited usage due limit of return string sizes.</para><para>
        /// Not published.  Manufacturing usage only.</para>
        /// </summary>
        void GetWListList();

        /// <summary>
        /// Using WLISt:NAME? to update the WaveformListName property<para>
        /// for the name of the waveform of an element in the waveform list</para>
        /// </summary>
        /// <param name="listIndex">Index of the waveform in the waveform list</param>
        void GetWlistName(string listIndex);

        /// <summary>
        /// Using WLISt:SIZE? to update the WaveformListSize<para>
        /// property of the size of the waveform list.</para>
        /// </summary>
        void GetWlistSize();

        /// <summary>
        /// Using WLISt:WAVeform:DATA transfer waveform data from the external controller into the waveform list
        /// </summary>
        /// <param name="wfmName"></param>
        /// <param name="startIndex"></param>
        /// <param name="size"></param>
        /// <param name="thisBlockData"></param>
        void SetWListWaveformData(string wfmName, string startIndex, string size, string thisBlockData);

        /// <summary>
        /// Using WLISt:WAVeform:DATA transfer waveform data from the external controller into the waveform list
        /// </summary>
        /// <param name="wfmName"></param>
        /// <param name="startIndex"></param>
        /// <param name="size"></param>
        /// <param name="thisBlockData"></param>
        void SetWListWaveformPieceData(string wfmName, string startIndex, string size, string thisBlockData);

        /// <summary>
        /// Using WLISt:WAVeform:DATA? update WaveformListData<para>
        /// property with waveform data from the waveform list</para>
        /// </summary>
        /// <param name="wfmName"></param>
        /// <param name="startIndex"></param>
        /// <param name="size"></param>
        void GetWListWaveformData(string wfmName, string startIndex, string size);

        /// <summary>
        /// Using WLIST:WAVeform:DELete delete the named waveform from the waveform list
        /// </summary>
        /// <param name="wfmName">Name of the waveform to delete</param>
        void WListWaveformDelete(string wfmName);

        /// <summary>
        /// Using WLISt:WAVeform:GRANularity? update the WaveformListGranularity<para>
        /// property for the required granularity for a valid waveform</para> 
        /// </summary>
        void GetWaveformGranularity();

        /// <summary>
        /// Using WLISt:WAVeform:LMAXimum? update the WaveformListMaxSamplepoints property
        ///</summary>
        void GetWlistMaxSamplePoints();

        /// <summary>
        /// Using WLISt:WAVeform:LMINimum? update the WaveformListMinSamplepoints property
        /// </summary>
        void GetWlistMinSamplePoints();

        /// <summary>
        /// Using WLIST:WAVeform:LENGth? to update the WaveformListLength<para>
        /// property for the size of the given waveform</para>
        /// </summary>
        /// <param name="wfmName">Name of the waveform to get the length of</param>
        void GetWListWaveformLength(string wfmName);

        /// <summary>
        /// Using WLISt:WAVeform:MARKer:DATA transfer marker data<para>
        /// from the external controller into the waveform list</para>
        /// </summary>
        /// <param name="wfmName"></param>
        /// <param name="startIndex"></param>
        /// <param name="size"></param>
        /// <param name="thisBlockData"></param>
        void SetWaveformMarkerData(string wfmName, string startIndex, string size, string thisBlockData);

        /// <summary>
        /// Using WLISt:WAVeform:MARKer:DATA? update the WaveformListMarkerData<para>
        /// property for the waveform marker data</para>
        /// </summary>
        void GetWaveformMarkerData(string wfmName, string startIndex, string size);

        /// <summary>
        /// Using WLISt:WAVeform:NEW create a new waveform of the given size and the given name
        /// </summary>
        /// <param name="wfmName">Name of the new waveform</param>
        /// <param name="size">Save of the new waveform</param>
        void CreateNewWListWaveform(string wfmName, string size);

        /// <summary>
        /// Using WLIST:WAVeform:NORMalize normalizes a waveform that exists in the waveform list
        /// </summary>
        /// <param name="wfmName">Waveform to normalize</param>
        /// <param name="normType">Noramlization type</param>
        void WListWaveformNormalize(string wfmName, string normType);

        /// <summary>
        /// Using WLIST:WAVeform:RESAmple resamples a waveform that exists in the waveform list
        /// </summary>
        /// <param name="wfmName">Waveform to normalize</param>
        /// <param name="size">Number of points to resample to</param>
        void WListWaveformResample(string wfmName, string size);

        /// <summary>
        /// Using WLIST:WAVeform:SHIFt shift a waveform that exists in the waveform list
        /// </summary>
        /// <param name="wfmName">Waveform to normalize</param>
        /// <param name="phase">Number of degrees to shift</param>
        void WListWaveformShift(string wfmName, string phase);

        /// <summary>
        /// Using WLIST:WAVeform:TSTamp? update the property WaveformListTimestamp for the given waveform
        /// </summary>
        /// <param name="wfmName">Name of the waveform to get the timestamp of</param>
        void GetWListWaveformTimestamp(string wfmName);

        /// <summary>
        /// Using WLIST:WAVeform:TYPE? update the property WaveformListType for the given waveform
        /// </summary>
        /// <param name="wfmName">Name of the waveform to get the type of</param>
        void GetWListWaveformType(string wfmName);

        /// <summary>
        /// //sdas2 6/3/2015
        /// <summary>
        /// Set the sampling rate of the particular waveform 
        /// WLISt:WAVEform:SRATe<wfm_name>,<sample_rate>
        /// </summary>
        /// <param name="wfmName">Waveform Name</param>
        /// <param name=sRate>specific awg</param>
        void SetWListWaveformSrate(string wfmName, string sRate);

        /// <summary>
        ///  //sdas2 6/3/2015
        /// <summary>
        /// Gets the sampling rate of the particular waveform 
        /// WLISt:WAVEform:SRATe?<wfm_name> (Query only)
        /// </summary>
        /// <param name="wfmName">Waveform Name</param>
        /// <return>Always return the Sampling rate of the Specific Waveform</return>
        void GetWListWaveformSrate(string wfmName);

        /// <summary>
        /// //sdas2 6/3/2015
        /// <summary> 
        /// Sets the Sample rate and Gets the Sample rate
        /// for a particular waveform
        /// </summary>
        string WaveformSRqueried { get; set; }

        /// <summary>
        /// Sets the instrument couple source mode of this awg
        /// </summary>
        /// <param name="setValue">Desired mode</param>
        void SetInstrumentCoupleSource(string setValue);

        /// <summary>
        /// Forces the awg to update its copy of instrument couple source mode
        /// </summary>
        void GetInstrumentCoupleSource();

        /// <summary>
        /// Set the %AWG instrument mode between AWG or FGen mode
        /// </summary>
        /// <param name="setValue">The desired instrument mode</param>
        void SetInstrumentMode(string setValue);

        /// <summary>
        /// Forces this awg to updates it's copy of the instrument mode
        /// </summary>
        void GetInstrumentMode();

        /// <summary>
        /// Using GPIBUsb:SETADDress set the address of the GPIB adapter device<para>
        /// Note: Set command differs from Query, uses SETADDress instead of ADDress@n</para>
        /// </summary>
        /// <param name="address">Address of the GPIB adapter device</param>
        void SetGPIBUsbAddress(int address);

        /// <summary>
        /// Using GPIBUsb:ADDress? update the property for the address of the GPIB adapter device
        /// </summary>
        void GetGPIBUsbAddress();

        /// <summary>
        /// Using GPIBUsb:HWVersion set the hardware version of the GPIB adapter device
        /// </summary>
        /// <param name="hwVersion">Hardware version of the GPIB adapter device</param>
        void SetGPIBUsbHwVersion(string hwVersion);

        /// <summary>
        /// Using GPIBUsb:HWVersion? update the property for the hardware version of the GPIB adapter device
        /// </summary>
        void GetGPIBUsbHwVersion();

        /// <summary>
        /// Using GPIBUsb:SETID set the ID of the GPIB adapter device<para>
        /// Note: Set command differs from Query, uses SETID instead of ID@n</para>
        /// </summary>
        /// <param name="id">ID of the GPIB adapter device</param>
        void SetGPIBUsbId(string id);

        /// <summary>
        /// Using GPIBUsb:ID? update the property for the ID of the GPIB adapter device
        /// </summary>
        void GetGPIBUsbId();

        /// <summary>
        /// Using GPIBUsb:STATus set the status of the GPIB adapter device
        /// </summary>
        /// <param name="status">Status of the GPIB adapter device</param>
        void SetGpibUsbStatus(string status);

        /// <summary>
        /// Using GPIBUsb:STATus? update the property for the status of the GPIB adapter device
        /// </summary>
        void GetGpibUsbStatus();

        string OpcQuery();
        void OpcCommand();

        /// <summary>
        /// Sends the WAI command
        /// </summary>
        void WaiCommand();

        void ClearErrors();

        /// <summary>
        /// Sets the Event Status Enable Register
        /// </summary>
        /// <param name="setValue"></param>
        void SetESE(string setValue);

        /// <summary>
        /// Queries and returns the value in the Event Status Enable Register
        /// </summary>
        void GetESE();

        /// <summary>
        /// Gets the status of the Event Status Enable Register
        /// </summary>
        string GetESR();

        /// <summary>
        /// Sets the bits in the Service Request Enable Register
        /// </summary>
        /// <param name="setValue"></param>
        void SetSRE(string setValue);

        /// <summary>
        /// Gets the bits in the Service Request Enable Register
        /// </summary>
        string GetSRE();

        /// <summary>
        /// Gets the contents of the Status Byte Register<para>
        /// </para>
        /// </summary>
        /// <returns>Current value for Status Byte Register</returns>
        string GetSTB();

        /// <summary>
        /// Returns the contents of the Operation Condition register (OCR)
        /// </summary>
        /// <returns></returns>
        string GetOperationConditionRegister();

        /// <summary>
        /// Sets the the mask for the Operation Enable Register (OENR)
        /// </summary>
        /// <param name="setValue"></param>
        void SetMaskOperationEnableRegister(string setValue);

        /// <summary>
        /// Gets the the mask for the Operation Enable Register (OENR)
        /// </summary>
        /// <returns>Current value for OENR</returns>
        string GetMaskOperationEnableRegister();

        /// <summary>
        /// Queries and returns the contents of the Operation Event Register. (OEVR)
        /// </summary>
        /// <returns>Operation Event Register</returns>
        string GetOperationEventRegister();

        /// <summary>
        /// Sets the value in the Status Operation NTransition register
        /// </summary>
        /// <param name="setValue">The value to set</param>
        void SetStatusOperationNTransitionRegister(string setValue);

        /// <summary>
        /// Queries and returns the value in the Status Operation NTransition register
        /// </summary>
        /// <returns>Current value for Status Operation NTransition Register</returns>
        string GetStatusOperationNTransitionRegister();

        /// <summary>
        /// Sets the value in the Status Operation PTransition register
        /// </summary>
        /// <param name="setValue">The value to set</param>
        void SetStatusOperationPTransitionRegister(string setValue);

        /// <summary>
        /// Queries and returns the value in the Status Operation PTransition register
        /// </summary>
        /// <returns>Current value for Status Operation PTransition Register</returns>
        string GetStatusOperationPTransitionRegister();

        /// <summary>
        /// This command resets the OENR and QENR registers.
        /// </summary>
        void ResetOENRAndQENRRegisters();

        /// <summary>
        /// Queries and returns the value in the Status Questionable Condition register
        /// </summary>
        /// <returns>Current value for Status Questionable Condition Register</returns>
        string GetStatusQuestionableConditionRegister();

        /// <summary>
        /// Sets the value in the Status Questionable Enable register
        /// </summary>
        /// <param name="setValue">The value to set</param>
        void SetStatusQuestionableEnableRegister(string setValue);

        /// <summary>
        /// Queries and returns the value in the Status Questionable Enable register
        /// </summary>
        /// <returns>Current value for Status Questionable Enable Register</returns>
        string GetStatusQuestionableEnableRegister();

        /// <summary>
        /// Queries and returns the value in the Status Questionable Event register (QEVR)
        /// </summary>
        /// <returns>Current value for Status Questionable Event Register</returns>
        string GetStatusQuestionableEventRegister();

        /// <summary>
        /// Sets the value in the Status Questionable NTransition register
        /// </summary>
        /// <param name="setValue">The value to set</param>
        void SetStatusQuestionableNTransitionRegister(string setValue);

        /// <summary>
        /// Queries and returns the value in the Status Questionable NTransition register
        /// </summary>
        /// <returns>Current value for Status Questionable NTransition Register</returns>
        string GetStatusQuestionableNTransitionRegister();

        /// <summary>
        /// Sets the value in the Status Questionable PTransition register
        /// </summary>
        /// <param name="setValue">The value to set</param>
        void SetStatusQuestionablePTransitionRegister(string setValue);

        /// <summary>
        /// Queries and returns the value in the Status Questionable PTransition register
        /// </summary>
        /// <returns>Current value for Status Questionable PTransition Register</returns>
        string GetStatusQuestionablePTransitionRegister();

        /// <summary>
        /// Using SLISt:NAME? get the name of the sequence of an element in the sequence list
        /// </summary>
        /// <param name="listIndex">Index of the sequence in the sequence list</param>
        /// <returns>The name of the waveform</returns>
        void GetSlistName(string listIndex);

        /// <summary>
        /// Using SLIST:SEQuence:DELete delete the sequence from the sequence list
        /// </summary>
        /// <param name="seqName">Name of the sequence to delete</param>
        /// <param name="addQuotes">Keyword such as ALL does not require quotes</param>
        void DeleteSequenceListSequence(string seqName, bool addQuotes = true);

        /// <summary>
        /// Using SLISt:SEQuence:EVENt:PJUMp:ENABle set the event pattern jump enable
        /// </summary>
        void SetSequenceEventPatternJumpEnable(string seqName, string enableState);

        /// <summary>
        /// Using SLISt:SEQuence:EVENt:PJUMp:ENABle? get the event pattern jump enable
        /// </summary>
        void GetSequenceEventPatternJumpEnable(string seqName);

        /// <summary>
        /// Using SLISt:SEQuence:EVENt:PJUMp:DEFine associate an event pattern<para>
        /// with the jumpe to step for Pattern Jump</para>
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="pattern"></param>
        /// <param name="jumpStep"></param>
        void SetSequenceEventPatternJumpDefine(string seqName, string pattern, string jumpStep);

        /// <summary>
        /// Using SLISt:SEQuence:EVENt:PJUMp:DEFine? get the jump step associated to the specified pattern
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="pattern"></param>
        void GetSequenceEventPatternJumpDefine(string seqName, string pattern);

        /// <summary>
        /// Using SLISt:SEQuence:EVENt:PJUMp:SIZE? get the maximum number of entries in the pattern jump table
        /// </summary>
        void GetSequenceEventPatternJumpSize();

        /// <summary>
        /// Using SLISt:SEQuence:EVENt:JTIMing sets how the sequencer<para>
        /// will respond to a logic event, pattern jump or a software</para><para>
        /// force jump.</para>
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="mode">of END or IMMediate</param>
        void SetSequenceEventPatternJumpTiming(string seqName, string mode);

        /// <summary>
        /// Using SLISt:SEQuence:EVENt:JTIMing? get the mode for how the sequencer<para>
        /// will respond to a logic event, pattern jump or a software</para><para>
        /// force jump.</para>
        /// </summary>
        /// <param name="seqName"></param>
        void GetSequenceEventPatternJumpTiming(string seqName);

        /// <summary>
        /// Using SLISt:SEQuence:LENGth? get the length of the named sequence.
        /// </summary>
        void GetSequenceLength(string seqName);

        /// <summary>
        /// Using SLISt:SEQuence:NEW create a new sequence of the given size and the given name
        /// </summary>
        /// <param name="seqName">Name of the new sequence</param>
        /// <param name="size">Save of the new sequence</param>
        /// <param name="tracks">Sequence can have 1-8 tracks</param>
        void CreateSListSequenceNew(string seqName, string size, string tracks);

        /// <summary>
        /// Using SLISt:SEQuence:STEP:RFlag set the enable flag repeat on or off
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="mode">ON|OFF|0|1</param>
        void SetSequenceRepeatFlag(string seqName, string mode);

        /// <summary>
        /// Using SLISt:SEQuence:STEP:RFlag?  gets the enable flag repeat state on or off
        /// </summary>
        /// <param name="seqName"></param>
        /// <returns>state of enable flag repeat setting</returns>
        void GetSequenceRepeatFlag(string seqName);

        /// <summary>
        /// Using SLISt:SEQuence:STEP:EJUMp set the step or step action for the<para>
        /// sequencer's event jump operation.</para>
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="mode">NR1|NEXT|FIRSt|LAST|END</param>
        /// <param name="step">Step from 1 to 16383</param>
        void SetSequenceStepEventJumpOperation(string seqName, string mode, string step);

        /// <summary>
        /// Using SLISt:SEQuence:STEP:EJUMp? get the step or step action for the<para>
        /// sequencer's event jump operation.</para>
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="step">Step from 1 to 16383</param>
        void GetSequenceStepEventJumpOperation(string seqName, string step);

        /// <summary>
        /// Using SLISt:SEQuence:STEP:EJINput selects the event jump input
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="step">Step from 1 to 16383</param>
        /// <param name="mode">ATRigger|BTRigger|OFF</param>
        void SetSequenceStepEventJumpInput(string seqName, string step, string mode);

        /// <summary>
        /// Using SLISt:SEQuence:STEP:EJINput? get the selected event jump input
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="step">Step from 1 to 16383</param>
        void GetSequenceStepEventJumpInput(string seqName, string step);

        /// <summary>
        /// Using SLISt:SEQuence:STEP[n]:GOTO set the target step for the GOTO command<para>
        /// of the sequencer at the current step</para>
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="step">Step from 1 to 16383</param>
        /// <param name="mode">nr1|LAST|FIRSt|NEXT|END</param>
        void SetSequenceStepGoto(string seqName, string step, string mode);

        /// <summary>
        /// Using SLISt:SEQuence:STEP:GOTO? get the target step for the GOTO command<para>
        /// of the sequencer at the current step</para>
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="step"></param>
        void GetSequenceStepGoto(string seqName, string step);

        /// <summary>
        /// Using SLISt:SEQuence:STEP:MAX? get maximum number of steps allowed in a sequence
        /// </summary>
        void GetSequenceStepMax();

        /// <summary>
        /// Using SLISt:SEQuence:STEP:RCOunt set the repeat count
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="step">Step from 1 to 16383</param>
        /// <param name="mode">nr1|ONCE|INFinite</param>
        void SetSequenceStepRepeatCount(string seqName, string step, string mode);

        /// <summary>
        /// Using SLISt:SEQuence:STEP:RCOunt? get the repeat count
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="step">Step from 1 to 16383</param>
        void GetSequenceStepRepeatCount(string seqName, string step);

        /// <summary>
        /// Using SLISt:SEQuence:STEP:RCOunt:MAX? get maximum number of repeat count allowed
        /// </summary>
        void GetSequenceStepRepeatCountMax();

        /// <summary>
        /// Using SLISt:SEQuence:STEP:TASSet? get the waveform name at the specified step and track
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="step"></param>
        /// <param name="track"></param>
        void GetSequenceStepTrackAsset(string seqName, string step, string track);

        /// <summary>
        /// Using SLISt:SEQuence:STEP:TASSet:SEQuence set a sequence to a step(as a subsequence) and of a sequence
        /// Note:  Applies to all tracks in the sequence
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="stepNumber"></param>
        /// <param name="subSeqName"></param>
        void SetSequenceStepTrackAssetForSequence(string seqName, string stepNumber, string subSeqName);

        /// <summary>
        /// Using SLISt:SEQuence:STEP[n]:TASSet[m]:TYPE? get the type of asset assigned to the specified step and track
        /// </summary>
        /// <returns>returns asset type (WAVeform|SEQuence)</returns>
        void GetSequenceStepTrackAssetType(string seqName, string step, string track);

        /// <summary>
        /// Using SLISt:SEQuence:STEP:TASSet:WAVeform set a wfm to a step and track of a sequence
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="stepNumber"></param>
        /// <param name="trackNumber"></param>
        /// <param name="wfmName"></param>
        void SetSequenceStepTrackAssetForWaveform(string seqName, string stepNumber, string trackNumber, string wfmName);

        /// <summary>
        /// Using SLISt:SEQuence:STEP:TRACk:MAX? get maximum number of tracks allowed in a sequence
        /// </summary>
        void GetSequenceStepTrackCountMax();

        /// <summary>
        /// Using SLISt:SEQuence:STEP:TFLag[m]:[ALPHA]FLAG set a flag value of the track in a specific sequence step for the specified flag
        /// flag settings are (NOCHANGE|HIGH|LOW|TOGGLE|PULSE)
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="stepNumber"></param>
        /// <param name="trackNumber"></param>
        /// <param name="flagAlpha">four flags can be set (A|B|C|D)FLAG</param>
        /// <param name="flagSetting">flag settings are (NOCHANGE|HIGH|LOW|TOGGLE|PULSE)</param>
        void SetSequenceStepTrackFlagValue(string seqName, string stepNumber, string trackNumber, string flagAlpha, string flagSetting);

        /// <summary>
        /// Using SLISt:SEQuence:STEP:TFLag[m]:[ALPHA]FLAG? gets value of flag for the track in a specific sequence step for the specified flag
        /// </summary>
        /// <returns>returns flag value (NOCHANGE|HIGH|LOW|TOGGLE|PULSE)</returns>
        void GetSequenceStepTrackFlagValue(string seqName, string stepNumber, string trackNumber, string flagAlpha);
        
        /// <summary>
        /// Using SLISt:SEQuence:STEP[n]:WINPut selects the mode to<para>
        /// listen for trigger signal</para>
        /// </summary>
        /// <param name="seqName">The named sequence</param>
        /// <param name="step">Step from 1 to 16383</param>
        /// <param name="mode">ATRigger|BTRigger|OFF</param>
        void SetSequenceStepWaitInput(string seqName, string step, string mode);

        /// <summary>
        /// Using SLISt:SEQuence:STEP[n]:WINPut? get the selected the name of<para>
        /// the waveform at the chosen step.</para>
        /// </summary>
        /// <param name="seqName">The named sequence</param>
        /// <param name="step">Step from 1 to 16383</param>
        void GetSequenceStepWaitInput(string seqName, string step);

        /// <summary>
        /// Using SLISt:SEQuence:TRACks? get the number of tracks of the named sequence.
        /// </summary>
        void GetSequenceTracks(string seqName);

        /// <summary>
        /// Using SLISt:SEQuence:TSTamp? get the timestamp of the named sequence.
        /// </summary>
        void GetSequenceTimestamp(string seqName);

        /// <summary>
        /// Using SLISt:SIZE? get the size of the sequence list.
        /// </summary>
        void GetSlistSize();

        /// <summary>
        /// Using *TRG create a trigger event
        /// </summary>
        void SetTriggerEvent();

        /// <summary>
        /// Using TRIGger:IMMediate Force a trigger event
        /// </summary>
        /// <param name="triggerSelection"></param>
        void ForceTriggerEvent(string triggerSelection);

        /// <summary>
        /// Using TRIGger:IMPedance set a trigger impedance
        /// </summary>
        /// <param name="triggerSelection">Selects trigger A or B</param>
        /// <param name="setValue"> Impedance value of 50 or 1000 Ohms</param>
        void SetTriggerImpedance(string triggerSelection, string setValue);

        /// <summary>
        /// Using TRIGger:IMPedance? get a trigger impedance
        /// </summary>
        /// <param name="triggerSelection">Selects trigger A or B</param>
        void GetTriggerImpedance(string triggerSelection);

        /// <summary>
        /// Using TRIGger:LEVel set a trigger level
        /// </summary>
        /// <param name="triggerSelection">Selects Trigger A or B</param>
        /// <param name="setValue">Trigger Level</param>
        void SetTriggerLevel(string triggerSelection, string setValue);

        /// <summary>
        /// Using TRIGger:LEVel? get a trigger level
        /// </summary>
        /// <param name="triggerSelection">Selects Trigger A or B</param>
        void GetTriggerLevel(string triggerSelection);

        /// <summary>
        /// Using TRIGger:MODE set the trigger mode
        /// </summary>
        /// <param name="setValue">The desired mode for the trigger</param>
        void SetTriggerMode(string setValue);

        /// <summary>
        /// Using TRIGger:MODE? get a trigger mode
        /// </summary>
        /// <return>The Trigger Mode</return>
        void GetTriggerMode();

        /// <summary>
        /// Using TRIGger:SEQuence:INTerval to set the internal trigger inetrval
        /// </summary>
        /// <param name="setValue">Trigger Level</param>
        void SetAwgTriggerInterval(string setValue);

        /// <summary>
        /// Using TRIGger:SEQuence:INTerval? to get the internal trigger inetrval
        /// </summary>
        /// <returns>Internal Trigger Time Interval Value</returns>
        void GetAwgTriggerInterval();

        /// <summary>
        /// Using TRIGger:SLOPe set a trigger slope to setValue
        /// </summary>
        /// <param name="triggerSelection">Selects Trigger A or B</param>
        /// <param name="setValue">Trigger slope</param>
        void SetTriggerSlope(string triggerSelection, string setValue);

        /// <summary>
        /// Using TRIGger:SLOPe? get a Trigger slope
        /// </summary>
        /// <param name="triggerSelection">Selects trigger A or B</param>
        void GetTriggerSlope(string triggerSelection);

        /// <summary>
        /// Using TRIGger:SOURce set the trigger source between internal and external
        /// </summary>
        /// <param name="setValue">Trigger source desired</param>
        void SetTriggerSource(string setValue);

        /// <summary>
        /// Using TRIGger:SOURce get a trigger source
        /// </summary>
        void GetTriggerSource();

        /// <summary>
        /// Using TRIGger:WVALue set a trigger wait on trigger value
        /// </summary>
        /// <param name="setValue"></param>
        void SetTriggerWValue(string setValue);

        /// <summary>
        ///  Using TRIGger:WVALue? get a trigger wait on trigger value
        /// </summary>
        void GetTriggerWValue();

        //void DiagLoopState(string setValue);
        
        /// <summary>
        /// Property for Sync Hub Deskew State<para>
        /// Update occurs with Get action</para>
        /// </summary>
        string SyncHubDeskewState { get; set; }

        /// <summary>
        /// Property for Sync Hub Enable State<para>
        /// Update occurs with Get action</para>
        /// </summary>
        string SyncHubEnableState { get; set; }

        /// <summary>
        /// Property for Sync Hub Play Disable State<para>
        /// Update occurs with Get action</para>
        /// </summary>
        string SyncHubPlayDisableState { get; set; }

        /// <summary>
        /// Property for Sync Hub Slave Disable State<para>
        /// Update occurs with Get action</para>
        /// </summary>
        string SyncHubSlaveDisableState { get; set; }

        /// <summary>
        /// Property for Sync Hub Test Mode State<para>
        /// Update occurs with Get action</para>
        /// </summary>
        string SyncHubTestModeState { get; set; }

        /// <summary>
        /// Property for Sync Hub Test Type Mode<para>
        /// Update occurs with Get action</para>
        /// </summary>
        string SyncHubTestTypeMode { get; set; }

        /// <summary>
        /// Property for Sync Hub Type Mode<para>
        /// Update occurs with Get action</para>
        /// </summary>
        string SyncHubTypeMode { get; set; }

        //These commands require either a Sync Hub setup or device to be in manufacturing mode to run in testmode
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
        /// Property for Sync Hub Configuration Setting<para>
        /// Update occurs with Get action</para>
        /// </summary>
        string SyncHubConfigSetting { get; set; }

        /// <summary>
        /// Using SYNChronize:CONFigure?
        /// This command gets the configuration of the ports in a Synchronization HUB system and forces 
        /// an initialization with the selected configuration. This is an overlapped command.
        /// </summary>
        /// <returns>Port Setting values, odd numbers between 3 and 15 are valid for system </returns>
        void GetSyncHubConfig();

        /// <summary>
        /// Using SYNChronize:CONFigure
        /// This command configures the ports in a Synchronization HUB system and forces 
        /// an initialization with the selected configuration. This is an overlapped command.
        /// </summary>
        /// <param name="setValue">Port Setting values, odd numbers between 3 and 15 are valid for system </param>
        void SetSyncHubConfig(string setValue);


        #endregion SYNChronize:CONFigure

        #region SYNChronize:DESKew:ABORt

        /// <summary>
        /// Using SYNChronize:DESKew:ABORt
        /// TThis command only cancels a system deskew calibration. It is an overlapped command. 
        /// This command may take up to 10 minutes to cancel.
        /// </summary>
        void SetSyncHubDeskewAbort();
        #endregion SYNChronize:DESKew:ABORt

        #region SYNChronize:DESKew:[STARt]

        /// <summary>
        /// Using SYNChronize:DESKew:[STARt]
        /// This command only performs a system deskew calibration. It is an overlapped command. 
        /// This command may take up to 30 minutes to complete. 
        /// </summary>
        void SetSyncHubDeskewStart();
        #endregion SYNChronize:DESKew:[STARt]

        #region SYNChronize:DESKew:STATe?

        /// <summary>
        /// Using SYNChronize:DESKew:STATe?
        /// This query only command retrieve the state of the system deskew calibration. 
        /// Valid only when SynchHub enabled and Master.
        /// </summary>
        /// <returns>0 for STOPPED and 1 for RUNNING</returns>
        void GetSyncHubDeskewStatus();
        #endregion SYNChronize:DESKew:STATe?

        #region SYNChronize:ENABle

        /// <summary>
        /// Using SYNChronize:ENABle 
        /// This command enables this AWG to be part of a system to synchronize multiple AWGs. 
        /// This is an overlapped command.
        /// </summary>
        /// <param name="state">On or Off Settings</param>
        void SetSyncHubEnable(string state);

        /// <summary>
        /// Using SYNChronize:ENABle?
        /// This query returns Sync Hub Enable State
        /// </summary>
        /// <returns>0 for OFF and 1 for ON</returns>
        void GetSyncHubEnableStatus();
        #endregion SYNChronize:ENABle

        #region SYNChronize:PLAY:DISable?

        /// <summary>
        /// Using SYNChronize:PLAY:DISable?
        /// This query only command retrieves state of this AWG70000 with regard to which PI commands should be disabled
        /// when AWGSYNC01 is enabled and the play state is not idle. That is the system has started or is playing the selected waveforms and sequences.
        /// This is an unpublished command
        /// </summary>
        /// <returns>0 for OFF and 1 for ON</returns>
        void GetSyncHubPlayDisableStatus();

        #endregion SYNChronize:PLAY:DISable?

        #region SYNChronize:SLAVe:DISable?

        /// <summary>
        /// Using SYNChronize:SLAVe:DISable?
        /// This query only command retrieves state of this AWG70000 with regard to which PI commands should be disabled
        /// when AWGSYNC01 is enabled and this AWG70000 is a slave.
        /// This is an unpublished command
        /// </summary>
        /// <returns>0 for not a slave and 1 for is a slave and mode is enabled</returns>
        void GetSyncHubSlaveDisableStatus();
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
        void SetSyncTestMode(string state);

        /// <summary>
        /// Using SYNChronize:TESTmode?
        /// This query only command retrieves the testmode state of this AWG70000 in the synchronized HUB system.
        /// This command requires the application starts in manufacturing mode 
        /// This is an unpublished command
        /// </summary>
        /// <returns>0 not in testmode, 1 in testmode</returns>
        void GetSyncHubTestModeStatus();
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
        void SetSyncTestType(string mode);

        /// <summary>
        /// Using SYNChronize:TTYPe?
        /// This command retrieves the the test type for this AWG70000 in the synchronized system when AWGSYNC01 test mode is enabled. 
        /// This command requires the application starts in  manufacturing mode.
        /// </summary>
        /// <returns>MASTer/SLAVe</returns>
        void GetSyncHubTestTypeMode();
        #endregion SYNChronize:TTYPe

        #region SYNChronize:TYPE?
        /// <summary>
        /// Using SYNChronize:TYPE?
        /// This query only command retrieves the type of this AWG70000 in the synchronized HUB system.
        /// The Synch Hub Type is not active until after Synch Hub Enable has completed.
        /// </summary>
        /// <returns>MASTer/SLAVe/UNKNown</returns>
        void GetSyncHubTypeMode();
        #endregion SYNChronize:TYPE?

        #region MultiTone types

        /// <summary>
        /// Property for MultiTone Type
        /// </summary>
        string MultiToneType { get; set; }

        string MultiToneName { get; set; }

        string MultiToneChannel { get; set; }

        string MultiToneChannelPlay { get; set; }

        string MultiToneSamplingRate { get; set; }

        string MultiToneSamplingRateAuto { get; set; }

        string MultiToneToneStart { get; set; }

        string MultiToneToneEnd { get; set; }

        string MultiToneToneSpacing { get; set; }

        string MultiToneToneNumTones { get; set; }

        string MultiToneTonePhase { get; set; }

        string MultiToneTonePhaseUserDefined { get; set; }

        string MultiToneNotchEnable { get; set; }

        /// <summary>
        /// Contains both start and end in a single line
        /// </summary>
        string MultiToneNotchStartEnd { get; set; }

        string MultiToneNotchStart { get; set; }

        string MultiToneNotchEnd { get; set; }

        string MultiToneNotchCount { get; set; }

        string MultiToneChirpLow { get; set; }

        string MultiToneChirpHigh { get; set; }

        string MultiToneChirpSweepRate { get; set; }

        string MultiToneChirpSweepTime { get; set; }

        string MultiToneChirpFrequencySweep { get; set; }

        #endregion


        #region MultiTone

        #region MTONE:RESEt
        //sdas2 9/1/2015
        /// <summary>
        ///  reset multitone Module
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
        void GetMultiToneType();

        #endregion



        #region MTONe:COMPile

        //dstockwe 2014/11/20
        /// <summary>
        /// Compile MultiTone module
        /// </summary>
        void StartMultiToneCompile();

        #endregion

        #region MTONe:COMPile:CANCel

        //dstockwe 2014/11/20
        /// <summary>
        /// Cancels an active compile in MultiTone module
        /// </summary>
        void MultiToneCancelCompile();

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
        void GetMultiToneName();

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
        void GetMultiToneChannel();

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
        void GetMultiToneChannelPlay();

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
        void GetMultiToneSamplingRate();

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
        void GetMultiToneAutoSamplingRate();

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
        void GetMultiToneToneStart();

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
        void GetMultiToneToneEnd();

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
        void GetMultiToneToneSpacing();

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
        void GetMultiToneToneNTones();

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
        void GetMultiToneTonePhase();

        #endregion

        #region MTONe:TONes:PHASe:UNDEFined[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone Phase User Defined
        /// </summary>
        void SetMultiToneTonePhaseUserDefined(string setValue);

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone Phase User Defined
        /// </summary>
        void GetMultiToneTonePhaseUserDefined();

        #endregion



        #region MTONe:TONes:NOTCh16[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone notch
        /// </summary>
        void SetMultiToneToneNotch(string setValue, string notchIndex);

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone notch
        /// </summary>
        void GetMultiToneToneNotch(string notchIndex);

        #endregion

        #region MTONe:TONes:NOTCh16:ADD

        //dstockwe 2014/11/20
        /// <summary>
        /// Add MultiTone tone notch
        /// </summary>
        void SetMultiToneToneNotchAdd(string setStartValue, string setEndValue);

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
        void GetMultiToneToneNotchEnable();

        #endregion

        #region MTONe:TONes:NOTCh16:STARt[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone notch start
        /// </summary>
        void SetMultiToneToneNotchStart(string setValue, string notchIndex);

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone notch start
        /// </summary>
        void GetMultiToneToneNotchStart(string notchIndex);

        #endregion

        #region MTONe:TONes:NOTCh16:END[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone notch end
        /// </summary>
        void SetMultiToneToneNotchEnd(string setValue, string notchIndex);

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone notch end
        /// </summary>
        void GetMultiToneToneNotchEnd(string notchIndex);

        #endregion

        #region MTONe:TONes:NOTCh16:DELete

        //dstockwe 2014/11/20
        /// <summary>
        /// Deletes specified notch(es)
        /// </summary>
        void DeleteMultiToneToneNotch(string setValue, string notchIndex);

        #endregion

        #region MTONe:TONes:NOTCh16:COUNT[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone notch
        /// </summary>
        void GetMultiToneToneNotchCount();

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
        void GetMultiToneChirpLow();

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
        void GetMultiToneChirpHigh();

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
        void GetMultiToneChirpSweepRate();

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
        void GetMultiToneChirpSweepTime();

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
        void GetMultiToneFrequencySweep();

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

        

      /// <summary>
      ///Property of signal format WLISt:WAVeform:SFORmat 
      /// </summary>
      
        string signalFormatQueried { get; set; }

        /// <summary>
        ///Property of AWGControl:PJUMp:SEDGe
        /// </summary>

        string strobEdgeQueried { get; set; }


        /// <summary>
        ///Property of AWGControl:PJUMp:JSTRobe
        /// </summary>

        string jumpOnStrobeStatusQueried { get; set; }

        /// <summary>
        ///Property of CPLAYBACK:COMPILE:LSEQuence 
        /// </summary>
        string LoopSequenceQueried { get; set; }


        /// <summary>
        /// Using SLISt:SEQuence:STEP:ADD Add steps to the sequence
        /// </summary>
        /// <param name="addStep"></param>
        /// <param name="atWhatStep"></param>
        /// <param name="sequenceName"></param>
        void AddStepToSlistSequence(string addStep, string atWhatStep, string sequenceName);


        /// <summary>
        /// Using CPLAYBACK:COMPILE:LSEQuence sets the loop sequence is ON/OFF
        /// </summary>
        /// <param name="setValue"></param>
         void SelectLoopSequence(string setValue);

       

       /// <summary>
       /// Using CPLAYBACK:COMPILE:LSEQuence get the loop sequence is ON/OFF
       /// </summary>
        void GetLoopSequence();

        /// <summary>
        /// Using WLISt:WAVeform:SFORmat  sets the waveform format for a given waveform to I/Q/REAL/UND
        /// </summary>
        /// <param name="signalFormat"></param>
        /// <param name="wfmName"></param>
        /// <param name="awg"></param>
        void SetSignalFormat(string signalFormat, string wfmName, IAWG awg);

        /// <summary>
        /// Using WLISt:WAVeform:SFORmat? get the waveform format for a given waveform
        /// compares with the expected value
        /// </summary>
        /// <param name="wfmName"></param>
        void GetSignalFormat(string wfmName);

        /// <summary>
        /// Using AWGControl:PJUMp:SEDGe  set the Strobe edge value to RISING/FALLING
        /// </summary>
        /// <param name="strobEdge"></param>
        void SetStrobEdge(string strobEdge);


       /// <summary>
       /// Using AWGControl:PJUMp:SEDGe get the Strobe edge value RISING/FALLING
       /// </summary>
       void GetStrobEdge();

       /// <summary>
       /// Using AWGControl:PJUMp:JSTRobe  set Jump on strobe status to ON/OFF
       /// </summary>
       /// <param name="setValue"></param>
      void SetJumpOnStrobe(string setValue);

       /// <summary>
       /// Using AWGControl:PJUMp:JSTRobe  get Jump on strobe status ON/OFF
       /// </summary>
       void GetJumpOnStrobeStatus();


       


       
    }
}
