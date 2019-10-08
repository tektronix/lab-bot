
// ReSharper disable CheckNamespace
namespace AwgTestFramework
// ReSharper restore CheckNamespace
{
    public interface ISCOPE
    {
        #region AquisitionValues
        /// <summary>
        /// Property to contain the CSA response from ACQuire:CURRentcount:ACQWfms?
        /// </summary>
        string CSAAquisitionCount { get; set; }

        /// <summary>
        /// Property to contain the CSA response from ACQuire:CURRentcount:MASKWfms?
        /// </summary>
        string CSACurrentMaskCount { get; set; }

        /// <summary>
        /// Property to contain the DPO response from ACQuire:NUMACq?
        /// </summary>
        string DPOAcquisitionWfmCount { get; set; }

        /// <summary>
        /// Property to contain the response from ACQuire:STATE?
        /// </summary>
        string ScopeAquisitionState { get; set; }
        #endregion AquisitionValues

        #region MaskValues
        /// <summary>
        /// Property to contain the CSA response from MASK:COUNt:TOTal?
        /// </summary>
        string CSAMasksTotalHitCount { get; set; }

        /// <summary>
        /// Property to contain the CSA response from MASK:MASK[n]:COUNt?
        /// </summary>
        string [] CSAMaskHitCount { get; set; }

        /// <summary>
        /// Property to contain the DPO response from MASK:COUNt:HITS?
        /// </summary>
        string DPOMaskHitCountTotal { get; set; }

        /// <summary>
        /// Property to contain the DPO response from  MASK:COUNt:SEG[n]:HITS?
        /// </summary>
        string [] DPOMaskSegmentHitCount { get; set; }

        /// <summary>
        /// Property to contain the DPO response from  MASK:TESt:STATUS?
        /// </summary>
        string DPOMaskTestStatus { get; set; }
        #endregion MaskValues

        #region MeasuredValues
        /// <summary>
        /// Property to store Amplitude Measurement response 
        /// </summary>
        string ScopeMeasuredAmplitudeVal { get; set; }

        /// <summary>
        /// Property to store Burst Measurement Value
        /// </summary>
        string ScopeMeasuredBurstVal { get; set; }

        /// <summary>
        /// Property to store Fall Measurement Value
        /// </summary>
        string ScopeMeasuredFallVal { get; set; }
        
        /// <summary>
        /// Property to store Frequency Measurement response 
        /// </summary>
        string ScopeMeasuredFrequencyVal { get; set; }

        /// <summary>
        /// Property to store Mean Frequency Measurement Value
        /// </summary>
        string ScopeMeasuredFreqMeanVal { get; set; }

        /// <summary>
        /// Property to store High Measurement response 
        /// </summary>
        string ScopeMeasuredHighVal { get; set; }

        /// <summary>
        /// Property to store Hits Measurement response 
        /// </summary>
        string ScopeMeasuredHitsVal { get; set; }

        /// <summary>
        /// Property to store Low Measurement response
        /// </summary>
        string ScopeMeasuredLowVal { get; set; }

        /// <summary>
        /// Property to store Maximum Measurement response
        /// </summary>
        string ScopeMeasuredMaximumVal { get; set; }

        /// <summary>
        /// Property to store Mean Measurement response from MEASUrement:MEAS[n]:MEAN?
        /// </summary>
        string ScopeMeasuredMeanVal { get; set; }

        /// <summary>
        /// Property to store Median Measurement Value
        /// </summary>
        string ScopeMeasuredMedianVal { get; set; }

        /// <summary>
        /// Property to store Minimum Measurement Value
        /// </summary>
        string ScopeMeasuredMinimumVal { get; set; }

        /// <summary>
        /// Property to store Negative Crossing Period
        /// </summary>
        string ScopeMeasuredNegCrossVal { get; set; }

        /// <summary>
        /// Property to store Negative Duty Cycle Percentage
        /// </summary>
        string ScopeMeasuredNegDutyPercent { get; set; }

        /// <summary>
        /// Property to store negative width of the first negative pulse in time Measurement Value
        /// </summary>
        string ScopeMeasuredNegWidth { get; set; }
        
        /// <summary>
        /// Property to store Period Measurement Value
        /// </summary>
        string ScopeMeasuredPeriodVal { get; set; }

        /// <summary>
        /// Property to store Period Standard Deviation Measurement Value
        /// </summary>
        string ScopeMeasuredPeriodStDevVal { get; set; }

        /// <summary>
        /// Property to store Phase Measurement Value
        /// </summary>
        string ScopeMeasuredPhaseVal { get; set; }

        /// <summary>
        /// Property to store Peak to Peak Measurement Value
        /// </summary>
        string ScopeMeasuredPk2PkVal { get; set; }

        /// <summary>
        /// Property to store Peak to Peak Jitter Measurement Value
        /// </summary>
        string ScopeMeasuredPkPkJitterVal { get; set; }

        /// <summary>
        /// Property to store positive width of the first positive pulse in time Measurement Value
        /// </summary>
        string ScopeMeasuredPosWidth { get; set; }

        /// <summary>
        /// Property to store Rise Measurement Value
        /// </summary>
        string ScopeMeasuredRiseVal { get; set; }

        /// <summary>
        /// Property to store Rise Mean Measurement Value
        /// </summary>
        string ScopeMeasuredRiseMeanVal { get; set; }

        /// <summary>
        /// Property to store Standard Deviation Measurement response from MEASUrement:MEAS[n]:STDdev?
        /// </summary>
        string ScopeMeasuredStdDevVal { get; }

        /// <summary>
        /// Property to store Measurement Value response from MEASUrement:MEAS[n]:VALue?
        /// </summary>
        string ScopeMeasureValue { get; }

        /// <summary>
        /// Property to store Measurement Slot #1 Value
        /// </summary>
        string ScopeMeas1Value { get; set; }

        /// <summary>
        /// Property to store Measurement Slot #2 Value
        /// </summary>
        string ScopeMeas2Value { get; set; }

        /// <summary>
        /// Property to store Measurement Slot #3 Value
        /// </summary>
        string ScopeMeas3Value { get; set; }

        /// <summary>
        /// Property to store Measurement Slot #4 Value
        /// </summary>
        string ScopeMeas4Value { get; set; }



        /// <summary>
        /// Property to store DPO Immediate Value response from MEASUrement:IMMed:VALue?
        /// </summary>
        string DPOImmedMeasureValue { get; }

        /// <summary>
        /// Property to store DPO Immediate Peak to Peak Value
        /// </summary>
        string DPOImmedMeasurePk2PkValue { get; set; }

        /// <summary>
        /// Property to store DPO Immediate Amplitude Value
        /// </summary>
        string DPOImmedMeasureAmpValue { get; set; }

        /// <summary>
        /// Property to store DPO Immediate Rise Value
        /// </summary>
        string DPOImmedMeasureRiseValue { get; set; }

        #endregion MeasuredValues

        #region ScopeAccessors
        string ScopeIdString { get; }
        string ScopeFwVersion { get; }
        string ScopeNumberChans { get; }
        string ScopeSpeed { get; }
        string ScopeSystemErrorString { get; }
        string ScopeErrorMessageString { get; }

        /// <summary>
        /// Property to contain the Device response from SYST:ERR? query
        /// </summary>
        string ScopeSystemErrorResponse { get; set; }

        /// <summary>
        /// The Scope family is found in the *IDN? response TEKTRONIX,DPO7354,B055089,CF:91.1CT FV:5.3.5 Build 22<para>
        ///                                                                   ^^^</para><para>
        /// Currently one of two types, CSA or DPO</para>
        /// </summary>
        string ScopeFamilyType { get; }
        /// <summary>
        /// The model number is found in the *IDN? response TEKTRONIX,DPO7354,B055089,CF:91.1CT FV:5.3.5 Build 22<para>
        ///                                                              ^^^^</para><para>
        /// Currently one of three types, DPO(7300|73000) and CSA8000</para>
        /// </summary>
        string ScopeModelNumber { get; }
        /// <summary>
        /// The serial number is found in the *IDN? response TEKTRONIX,DPO7354,B055089,CF:91.1CT FV:5.3.5 Build 22<para>
        ///                                                                    ^^^^^^^</para>
        /// </summary>
        string ScopeSerialNumber { get; }

        /// <summary>
        /// A two digit number of 70 or 50 representing the 70k and 50k Scope family types
        /// </summary>
        string ScopeFamily { get; }
        /// <summary>
        /// A re-constructed string containing the family type, (e.g. Scope), model number and class letter
        /// </summary>
        string ScopeModelString { get; }

        /// <summary>
        /// Used to store a response from a SCOPEVisaSession.Read or Query
        /// </summary>
        string ScopeReadResponse { get; }

        /// <summary>
        /// Scope specific timer duration place holder.
        /// </summary>
        double ScopeTimerDuration { get; }
        #endregion ScopeAccessors

        #region SystemValues
        /// <summary>
        /// Property to contain the Standard Event Status Register response from *ESR? query
        /// </summary>
        string ScopeESRData { get; }

        /// <summary>
        /// Property to contain the Device response from *IDN? query
        /// </summary>
        string ScopeIDNResponse { get; }

        /// <summary>
        /// Property to contain the Device response from *OPC? query
        /// </summary>
        string ScopeOPCResponse { get; }

        /// <summary>
        /// Property to contain the Device response from ALLEv? query
        /// </summary>
        string ScopeALLEvResponse { get; }

        /// <summary>
        /// Property to contain the Device response from EVENT? query
        /// </summary>
        string ScopeEventCurrent { get; }

        /// <summary>
        /// Property to contain the Device response from EVMsg? query
        /// </summary>
        string ScopeEventMessageCurrent { get; }
        #endregion SystemValues

        #region TriggerValues
        /// <summary>
        /// Property to contain the Scope response from TRIGger:STATe? query
        /// </summary>
        string ScopeTriggerState { get; set; }

        /// <summary>
        /// Property to contain the CSA response from TRIGger:HOLDoff? query
        /// </summary>
        string CSATriggerHoldoffTime { get; set; }
        #endregion TriggerValues

        #region AquisitionMethods
        /// <summary>
        /// Set the Aquisition mode of the Scope
        /// 
        /// Uses ACQuire:MODe
        /// <param name="mode"></param>
        /// </summary>
        void SetScopeAcquisitionMode(string mode);

        /// <summary>
        /// Sets the Acquisition state of the Scope
        /// 
        /// uses ACQuire:STATE
        /// </summary>
        /// <param name="state"></param>
        void SetScopeAcquisitonState(string state);

        /// <summary>
        /// Gets the Acquisition state of the scope
        /// 
        /// uses ACQuire:STATE?
        /// </summary>
        /// <returns>Scope state</returns>
        void GetScopeAcquisitionState();

        /// <summary>
        /// Gets the number of acquired waveforms from the CSA
        /// 
        /// uses ACQuire:CURRentcount:ACQWfms?
        /// </summary>
        /// <returns>Number of acquired waveforms</returns>
        void GetCSAAcquisitionCount();

        /// <summary>
        /// Gets the CSA mask waveform acquisition count
        /// 
        /// uses ACQuire:CURRentcount:MASKWfms?
        /// </summary>
        /// <returns>Current waveform acquistion count</returns>
        void GetCSACurrentMaskWfmCount();

        /// <summary>
        /// Resets the CSA waveform count acquisition count
        /// 
        /// uses ACQuire:DATA:CLEar
        /// </summary>
        void CSAAcquisitionCountReset();

        /// <summary>
        /// Sets the acquisition stop after condition
        /// 
        /// uses ACQuire:STOPAfter:CONDition
        /// </summary>
        /// <param name="state"></param>
        void SetCSAAcquireStopAfterCondition(string state);

        /// <summary>
        /// Sets the criteria for when the CSA will stop acquisition
        /// 
        /// uses ACQuire:STOPAfter:COUNt
        /// </summary>
        /// <param name="count">Number of hits</param>
        void SetCSAAcquireStopAfterCount(string count);

        /// <summary>
        /// Sets the acquisition stop after mode for a CSA Scope
        /// 
        /// uses ACQuire:STOPAfter:MODe
        /// </summary>
        /// <param name="mode"></param>
        void SetCSAAcquireStopAfterMode(string mode);

        /// <summary>
        /// Gets the number of acquired waveforms from the DPO since starting Acquisition with the ACQuire:STATE RUN command
        /// 
        /// ACQuire:NUMACq?
        /// </summary>
        /// <returns>Number of acquired waveforms</returns>
        void GetDPOAcquisitionWfmCount();

        /// <summary>
        /// Sets the DPO stop after mode
        /// 
        /// uses ACQuire:STOPAfter
        /// </summary>
        /// <param name="mode">Desired DPO stop after mode</param>
        void SetDPOAcquireStopAfterMode(string mode);

        /// <summary>
        /// Sets the Fast Acquisitions State on a DPO
        /// </summary>
        /// <param name="state">Fast acquisition state [ON|OFF]</param>
        void SetDPOFastAcquisitions(string state);
        #endregion AquisitionMethods

        #region DisplayMethods
        /// <summary>
        /// Autoset the Scope
        /// 
        /// uses AUTOSet EXECute
        /// </summary>
        void ScopeAutosetExecute();

        /// <summary>
        /// Sets the Scope channel vertical offset
        /// 
        /// CH[n]:OFFSet
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="value">Offset value</param>
        void SetScopeChannelOffset(string channel, string value);

        // Need to change DPO and CSA tests over to ScopeVerticalScale
        /// <summary>
        /// Sets the Scope vertical scale for the given channel
        /// 
        /// use CH[n]:SCAle
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="scale">Desired scale</param>
        void SetScopeVerticalScale(string channel, string scale);

        /// <summary>
        /// Set the scope horizontal position
        /// 
        /// uses HORizontal:MAIn:POSition
        /// </summary>
        /// <param name="position">Desired horizontal position</param>
        void SetScopeHorizontalPosition(string position);

        /// <summary>
        /// Sets the CSA autoset type
        /// 
        /// uses AUTOSet:TYPE
        /// </summary>
        /// <param name="type">Autoset type</param>
        void SetCSAAutosetType(string type);

        /// <summary>
        /// Sets the CSA horizonal scale
        /// 
        /// uses HORizontal:MAIn:SCAle
        /// </summary>
        /// <param name="scale">Desired scale</param>
        void SetCSAHorizontalMainScale(string scale);

        /// <summary>
        /// Sets the DPO autoset type
        /// 
        /// AUTOSet
        /// </summary>
        /// <param name="type">Autoset type</param>
        void SetDPOAutosetType(string type);

        /// <summary>
        /// Sets the connected/disconnected status of a 50 Ω resistor, which
        /// can be connected between the specified channel's coupled input and instrument
        /// ground on a DPO.
        /// 
        /// uses CH[n]:TERmination
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="impedance">value ex. 50.0E+0</param>
        void SetDPOCHTermination(string channel, string impedance);

        /// <summary>
        /// Sets the DPO display persistence
        /// 
        /// uses DISplay:PERSistence
        /// </summary>
        /// <param name="type">Persistence type</param>
        void SetDPODisplayPersistence(string type);

        /// <summary>
        /// Sets the DPO horizontal sample rate in samples per seconds
        /// 
        /// uses HORizontal:MODE:SAMPLERate
        /// </summary>
        /// <param name="rate">Desired rate value sent in this format 5.0000E+6</param>
        void SetDPOHorizontalModeSampleRate(string rate);

        /// <summary>
        /// Sets the DPO horizontal scale in seconds per division
        /// 
        /// use HORizontal:MODE:SCAle
        /// </summary>
        /// <param name="scale">Desired scale value sent in the format of 20.0000E-6</param>
        void SetDPOHorizontalModeScale(string scale);

        /// <summary>
        /// Sets the DPO vertical scale for the given reference waveform
        /// 
        /// uses REF[n]:VERTical:SCAle
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="scale">Desired scale</param>
        void SetDPORefVerticalScale(string channel, string scale);
        #endregion DisplayMethods

        #region MaskMethods
        /// <summary>
        /// Resets the Mask Count on the Scope
        /// 
        /// uses MASK:COUNt RESET
        /// </summary>
        void ScopeMaskCountResetExecute();

        /// <summary>
        /// Sets the source for all the masks to given channel
        /// Can be set to other things but ignored here for brevity
        /// 
        /// MASK:SOUrce CH[n]
        /// </summary>
        /// <param name="channel">Channel source</param>
        void SetScopeMaskSourceCH(string channel);

        /// <summary>
        /// Loads a mask file onto the scope
        /// 
        /// uses RECAll:MASK
        /// </summary>
        /// <param name="filepath">Setup filepath</param>
        void ScopeRecallMaskExecute(string filepath);

        /// <summary>
        /// Sets the mask counting state on or off on a CSA
        /// 
        /// uses MASK:COUNt:STATE
        /// </summary>
        /// <param name="state">Mask counting state</param>
        void SetCSAMaskCountState(string state);

        /// <summary>
        /// Gets the mask hit count for all the masks on a CSA 
        /// 
        /// uses MASK:COUNt:TOTal?
        /// </summary>
        /// <returns>Mask hit count for all the masks</returns>
        void GetCSAMaskHitCountTotal();

        /// <summary>
        /// Gets the CSA mask hit count for a specified mask
        /// 
        /// uses MASK:MASK[n]:COUNt?
        /// </summary>
        /// <param name="maskNumber">Desired mask</param>
        /// <returns>Mask count</returns>
        void GetCSAMaskHitCount(int maskNumber);

        /// <summary>
        /// Sets the mask index of the mask that will be deleted on a CSA
        /// 
        /// uses MASK:MASK[n]DELETE
        /// </summary>
        /// <param name="maskNumber">Mask to delete</param>
        void SetCSAMaskDelete(string maskNumber);

        /// <summary>
        /// Sets the mask vertices for a given mask by percentage
        /// 
        /// MASK:MASK[n]:POINTSPcnt
        /// </summary>
        /// <param name="maskNumber">Desired mask number</param>
        /// <param name="maskList">List of points</param>
        void SetCSAMaskPoint(string maskNumber, string maskList);

        /// <summary>
        /// Gets the mask hit count for all the mask segments
        /// 
        /// use MASK:COUNt:HITS?
        /// </summary>
        /// <returns>Mask hit count for all the masks</returns>
        void GetDPOMaskHitCountTotal();

        /// <summary>
        /// Gets the mask hit count for a specified mask segment on a DPO Scope
        /// 
        /// MASK:COUNt:SEG[n]:HITS?
        /// </summary>
        /// <param name="maskNumber">Desired mask</param>
        /// <returns>Mask count</returns>
        void GetDPOMaskSegmentHitCount(int maskSegment);

        /// <summary>
        /// Sets Mask Display State
        /// Mask Counting, mask testing, and mask autoset are unavailable is the mask display is OFF
        /// Default setting is ON
        /// 
        /// uses MASK:DISplay [OFF|ON]
        /// </summary>
        /// <param name="displayState">Display State of Mask either ON or OFF</param>
        void SetDPOMaskDisplayState(string displayState);

        /// <summary>
        /// Deletes the existing mask and sets the selected standard mask on a DPO scope
        /// 
        /// uses MASK:STANdard
        /// </summary>
        /// <param name="maskNumber">Mask to delete</param>
        void SetDPOMaskStandard(string maskStandard);

        /// <summary>
        /// Sets the mask test counting state ON or OFF on a DPO Scope
        /// 
        /// MASK:TEST:STATE
        /// </summary>
        /// <param name="state">Mask Test counting state</param>
        void SetDPOMaskCountState(string state);

        /// <summary>
        /// Gets the DPO Mask Test Status
        /// 
        /// uses MASK:TESt:STATUS?
        /// </summary>
        void GetDPOMaskTestStatus();
        #endregion MaskMethods

        #region MeasureMethods
        /// <summary>
        /// Gets the mean measurement from Scope
        /// 
        /// uses MEASUrement:MEAS[n]:MEAN?
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <returns>Mean measurement</returns>
        void GetScopeMeasureMean(string measurement);

        /// <summary>
        /// Sets the measurement source for the CSA and the DPO
        /// 
        /// MEASUrement:MEAS[n]:SOURCE1 CH[n]
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <param name="sourceChan">Channel to use as Measurement Source</param>
        /// <param name="state">Measurement state</param>
        void SetScopeMeasureSource(string measurement, string sourceChan, string state);
        
        /// <summary>
        /// Sets the measurement state of the scope
        /// 
        /// uses MEASUrement:MEAS[n]:STATE
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <param name="state">Measurement state</param>
        void SetScopeMeasureState(string measurement, string state);

        /// <summary>
        /// Gets the standard deviation measurement from the scope
        /// 
        /// uses MEASUrement:MEAS[n]:STDdev?
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <returns>Standard Deviation measurement</returns>
        void GetScopeMeasureStdDev(string measurement);

        /// <summary>
        /// Sets the measurement type for the Scope
        /// 
        /// NOTE: The string values for type differs between CSA and DPO along with types available on the DPO that are not on the CSA@n
        /// uses MEASUrement:MEAS[n]:TYPe
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <param name="type">Measurement type</param>
        void SetScopeMeasureType(string measurement, string type);

        void MeasureAmplitude(ISCOPE scope, string measurement, string source);

        void MeasureBurst(ISCOPE scope, string measurement, string source);

        void MeasureFall(ISCOPE scope, string measurement, string source);

        void MeasureFrequency(ISCOPE scope, string measurement, string source);

        void MeasureHigh(ISCOPE scope, string measurement, string source);

        void MeasureHits(ISCOPE scope, string measurement, string source);

        void MeasureLow(ISCOPE scope, string measurement, string source);

        void MeasureMaximum(ISCOPE scope, string measurement, string source);

        void MeasureMedian(ISCOPE scope, string measurement, string source);

        void MeasureMinimum(ISCOPE scope, string measurement, string source);

        void MeasureNegCross(ISCOPE scope, string measurement, string source);
        
        void MeasureNegDuty(ISCOPE scope, string measurement, string source);

        void MeasureNegWidth(ISCOPE scope, string measurement, string source);

        void MeasurePeriod(ISCOPE scope, string measurement, string source);

        void MeasurePk2Pk(ISCOPE scope, string measurement, string source);

        void MeasureJitter(ISCOPE scope, string measurement, string source);

        void MeasurePosWidth(ISCOPE scope, string measurement, string source);

        void MeasureRise(ISCOPE scope, string measurement, string source);

        /// <summary>
        /// Gets the measurement value from the Scope
        /// 
        /// uses MEASUrement:MEAS[n]:VALue?
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <returns>Measurement value</returns>
        void GetScopeMeasureValue(string measurement);

        /// <summary>
        /// Gets the measurement value from the Scope
        /// 
        /// uses MEASUrement:MEAS[n]:MAXimum?
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <returns>Measurement value</returns>
        void GetScopeMeasureMaxValue(string measurement);

        /// <summary>
        /// Gets the measurement value from the Scope
        /// 
        /// uses MEASUrement:MEAS[n]:MINImum?
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <returns>Measurement value</returns>
        void GetScopeMeasureMinValue(string measurement);

        /// <summary>
        /// Sets the CSA measurement source to a given channel
        /// 
        /// uses MEASUrement:MEAS[n]:SOUrce[channel]:WFM
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <param name="source">Scope visa session and a collection of state variables</param>
        void SetCSAMeasureSource(string measurement, string source);

        /// <summary>
        /// Resets the CSA measurement statistics
        /// 
        /// uses MEASUrement:MEAS1:STATistics:CLEAR
        /// </summary>
        void CSAMeasurementResetExecute();

        /// <summary>
        /// Sets the DPO immediate source to a given channel
        /// 
        /// uses MEASUrement:IMMed:SOUrce1 CH[n]
        /// </summary>
        /// <param name="source">Which channel to be used as a source for the measurement </param>
        void SetDPOImmedMeasureSource(string source);

        /// <summary>
        /// Sets the DPO immediate measurement type
        /// 
        /// uses MEASUrement:IMMed:TYPe
        /// </summary>
        /// <param name="type">Measurement type</param>
        void SetDPOImmedMeasureType(string type);

        /// <summary>
        /// Gets the DPO immediate value
        /// 
        /// uses MEASUrement:IMMed:VALue
        /// </summary>
        /// <returns>Immediate value</returns>
        void GetDPOImmedMeasureValue();

        /// <summary>
        /// Sets the DPO measurement source to a given channel
        /// 
        /// uses MEASUrement:MEAS[n]:SOUrce CH[n]
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <param name="source">Which Channel will be used</param>
        void SetDPOMeasureSource(string measurement, string source);

        /// <summary>
        /// Resets the DPO measurement statistics
        /// 
        /// uses MEASUrement:STATistics:COUNt RESET
        /// </summary>
        void DPOMeasurementResetExecute();
        #endregion MeasureMethods

        #region SystemMethods
        /// <summary>
        /// Clears error queue of the scope
        /// 
        /// uses *CLS
        /// </summary>
        void ScopeCLSExecute();

        /// <summary>
        /// Gets Standard Event Status Register
        /// basically means clearing it
        /// 
        /// uses *ESR?
        /// </summary>
        /// <returns>Id of the scope</returns>
        void GetScopeESR();

        /// <summary>
        /// Gets the id of the scope
        /// 
        /// uses *IDN?
        /// </summary>
        /// <returns>Id of the scope</returns>
        void GetScopeIDN();

        /// <summary>
        /// Executes a scope reset
        /// 
        /// uses *RST
        /// </summary>
        void ScopeResetExecute();

        /// <summary>
        ///  Gets *OPC Query response
        /// 
        /// uses *OPC?
        /// </summary>
        /// <param name="timeout">How long to wait for the OPC to return</param>
        /// <returns>OPC result</returns>
        void GetScopeOPCResponse(uint timeout);

        /// <summary>
        /// Gets all the events on the scope
        /// 
        /// uses ALLEv?
        /// </summary>
        /// <returns>Event log</returns>
        void GetScopeALLEvResponse();

        /// <summary>
        /// Gets the current event code the queue
        /// 
        /// uses EVENT?
        /// </summary>
        /// <returns>Event code</returns>
        void GetScopeEvent();

        /// <summary>
        /// Gets the current event code and message on the queue
        /// 
        /// uses EVMsg?
        /// </summary>
        /// <returns>Event code and message</returns>
        void GetScopeEventMessage();

        /// <summary>
        /// Gets the system error code and message from the scope
        /// 
        /// SYSTem:ERRor?
        /// </summary>
        /// <returns>System error code and message</returns>
        void GetScopeSystemError();

        /// <summary>
        /// Executes a reset to factory default setup on the scope
        /// 
        /// uses FACtory
        /// </summary>
        void ScopeFactoryDefaultExecute();

        /// <summary>
        /// Loads a setup file onto the scope
        /// 
        /// uses RECAll:SETUp
        /// </summary>
        /// <param name="filepath">Setup filepath</param>
        void ScopeRecallSetupExecute(string filepath);

        /// <summary>
        /// Sets the Channel state [OFF|ON] for the desired Channel
        /// 
        /// uses SELect:CH[n] 
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="state">Desired channel state</param>
        void SetScopeSelectChannelState(string channel, string state);
        #endregion SystemMethods

        #region TriggerMethods
        /// <summary>
        /// Gets the current state of the triggering system
        /// 
        /// uses TRIGger:STATe?
        /// </summary>
        /// <returns>Current State of the triggering system</returns>
        void GetScopeTriggerState();

        /// <summary>
        /// Sets the CSA trigger holdoff time
        /// 
        /// uses TRIGger:HOLDoff
        /// </summary>
        /// <param name="time">Desired trigger holdoff time</param>
        void SetCSATriggerHoldoff(string time);

        /// <summary>
        /// Gets the CSA trigger holdoff time
        /// 
        /// uses TRIGger:HOLDoff?
        /// </summary>
        void GetCSATriggerHoldoff();

        /// <summary>
        /// Sets the CSA trigger mode
        /// 
        /// uses TRIGger:MODe 
        /// </summary>
        /// <param name="mode">trigger mode type</param>
        void SetCSATriggerMode(string mode);

        /// <summary>
        /// Sets the CSA trigger source
        /// 
        /// uses TRIGger:SOUrce
        /// </summary>
        /// <param name="source"></param>
        void SetCSATriggerSource(string source);

        /// <summary>
        /// Sets the DPO trigger source at the BNC connector
        /// 
        /// uses AUXout:SOUrce
        /// </summary>
        /// <param name="source">Desired trigger source</param>
        void SetDPOAUXOutSource(string source);

        /// <summary>
        /// Sets the source for edge trigger A.
        /// 
        /// TRIGger:A:EDGe:SOUrce
        /// </summary>
        /// <param name="source">Trigger Source</param>
        void SetDPOTriggerSource(string source);

        /// <summary>
        /// Sets the level for trigger A for all channels
        /// 
        /// TRIGger:A:LEVel
        /// </summary>
        /// <param name="setValue">Numeric value using this format 1.3000E+00 to set the trigger level</param>
        void SetDPOTriggerLevel(string setValue);

        /// <summary>
        /// Sets the CH[n] trigger level for
        /// TRIGGER:LVLSRCPREFERENCE SRCDEPENDENT mode.
        /// 
        /// TRIGger:A:LEVel:CH[n]
        /// </summary>
        /// <param name="setValue">Sets the mode value {ECL|TTL}</param>
        /// <param name="channel">Scope Channel</param>
        void SetDPOTriggerLevelChannel(string setValue, string channel);

        /// <summary>
        /// Set the DPO trigger mode
        /// 
        /// TRIGger:A:MODe
        /// </summary>
        /// <param name="mode">Trigger mode</param>
        void SetDPOTriggerMode(string mode);

        /// <summary>
        /// Sets the window trigger event. This command is
        /// equivalent to selecting Window Setup from the Trig menu and selecting from
        /// the Window Event box.
        /// 
        /// TRIGger:A:PULse:WINdow:EVENT
        /// </summary>
        /// <param name="eventType"></param>
        void SetDPOTriggerWindowEvent(string eventType);

        /// <summary>
        /// Sets the upper and lower limits for the pulse window trigger.
        /// 
        /// TRIGger:A:PULse:WINdow:THReshold:HIGH ;LOW
        /// </summary>

        /// <param name="high">upper limit value for the pulse window trigger, format 2.0000E+00</param>
        /// <param name="low">lower limit value for the pulse window trigger, format 50.0000E-03</param>
        void SetDPOTriggerWindow(string high, string low);
        #endregion TriggerMethods
    }
}
