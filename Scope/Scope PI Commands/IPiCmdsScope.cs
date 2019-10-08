namespace AwgTestFramework
{
    interface IPiCmdsScope
    {
        #region shared by all
        uint DefaultVisaTimeout { get; set; }
        #endregion shared by all

        #region *Commands
        #region *CLS
        /// <summary>
        /// Clears error queue of the scope
        /// 
        /// *CLS
        /// </summary>
        void ScopeCLS();
        #endregion *CLS

        #region *ESR?
        /// <summary>
        /// Gets Standard Event Status Register
        /// basically means clearing it
        /// 
        /// *ESR?
        /// </summary>
        /// <returns>Content of the Standard Event Status Register</returns>
        string ScopeESRQuery();
        #endregion *ESR?

        #region *IDN?
        /// <summary>
        /// Gets the id of the scope
        /// 
        /// *IDN?
        /// </summary>
        /// <returns>Id of the scope</returns>
        string ScopeIDNQuery();
        #endregion *IDN?

        #region *RST
        /// <summary>
        /// Resets scope
        /// 
        /// *RST
        /// </summary>
        void ScopeReset();
        #endregion *RST

        #region *OPC?
        /// <summary>
        /// Waits for the scope to complete
        /// 
        /// *OPC?
        /// </summary>
        /// <returns>OPC result</returns>
        string ScopeOPCQuery(uint timeout);
        #endregion *OPC?
        #endregion *Commands

        #region ACQuire
        #region ACQuire:CURRentcount:ACQWfms?
        /// <summary>
        /// Gets the number of acquired waveforms from the CSA
        /// 
        /// ACQuire:CURRentcount:ACQWfms?
        /// </summary>
        /// <returns>Number of acquired waveforms</returns>
        string CSAAcquisitionCountQuery();
        #endregion ACQuire:CURRentcount:ACQWfms?

        #region ACQuire:CURRentcount:MASKWfms?
        /// <summary>
        /// Gets the CSA mask waveform acquisition count
        /// 
        /// ACQuire:CURRentcount:MASKWfms?
        /// </summary>
        /// <returns>Current waveform acquistion count</returns>
        string CSACurrentMaskWfmCountQuery();
        #endregion ACQuire:CURRentcount:MASKWfms?
        
        #region ACQuire:DATA:CLEar

        /// <summary>
        /// Resets the CSA waveform count acquisition count
        /// 
        /// ACQuire:DATA:CLEar
        /// </summary>
        void CSAResetAcquisitionCount();
        #endregion ACQuire:DATA:CLEar

        #region ACQuire:MODe
        /// <summary>
        /// Sets the Scope acquistion mode
        /// 
        /// ACQuire:MODe
        /// </summary>
        void ScopeAcquireMode(string mode);
        #endregion ACQuire:MODe
       
        #region ACQuire:NUMACq?
        /// <summary>
        /// Gets the number of acquired waveforms from the DPO since starting Acquisition with the ACQuire:STATE RUN command
        /// 
        /// ACQuire:NUMACq?
        /// </summary>
        /// <returns>Number of acquired waveforms</returns>
        string DPOAcquisitionCountQuery();
        #endregion ACQuire:NUMACq?

        #region ACQuire:STATE
        /// <summary>
        /// Sets the scope acquisition state
        /// 
        /// ACQuire:STATE
        /// </summary>
        void ScopeAcquireState(string state);
        #endregion ACQuire:STATE

        #region ACQuire:STATE?
        /// <summary>
        /// Gets the scope acquisition state
        /// 
        /// ACQuire:STATE?
        /// </summary>
        /// <returns>Scope state</returns>
        string ScopeAcquireStateQuery();
        #endregion ACQuire:STATE?

        #region ACQuire:STOPAfter
        /// <summary>
        /// Sets the DPO stop after mode
        /// 
        /// ACQuire:STOPAfter
        /// </summary>
        void DPOAcquireStopAfterMode(string mode);
        #endregion ACQuire:STOPAfter

        #region ACQuire:STOPAfter:CONDition

        /// <summary>
        /// Sets the acquisition stop after condition
        /// 
        /// ACQuire:STOPAfter:CONDition
        /// </summary>
        void CSAAcquireStopAfterConditionState(string state);
        #endregion ACQuire:STOPAfter:CONDition

        #region ACQuire:STOPAfter:COUNt
        /// <summary>
        /// Sets the criteria for when the CSA will stop acquisition
        /// 
        /// ACQuire:STOPAfter:COUNt
        /// </summary>
        void CSAAcquireStopAfterCount(string count);
        #endregion ACQuire:STOPAfter:COUNt

        #region ACQuire:STOPAfter:MODe
        /// <summary>
        /// Sets the acquisition stop after mode
        /// 
        /// ACQuire:STOPAfter:MODe
        /// </summary>
        void CSAAcquireStopAfterMode(string mode);
        #endregion ACQuire:STOPAfter:MODe
        #endregion ACQuire

        #region ALLev?
        /// <summary>
        /// Gets all the events on the scope
        /// Also removes returned events from the Event Queue
        /// ALLEv?
        /// </summary>
        /// <returns>All events and their messages</returns>
        string ScopeALLEvQuery();
        #endregion ALLev?

        #region AUTOSET
        #region AUTOSet
        /// <summary>
        /// Sets the DPO autoset type
        /// 
        /// AUTOSet
        /// </summary>
        void DPOAutosetType(string type);
        #endregion AUTOSet

        #region AUTOSet EXECute
        /// <summary>
        /// Autoset the scope
        /// 
        /// AUTOSet EXECute
        /// </summary>
        void ScopeAutoset();
        #endregion AUTOSet EXECute

        #region AUTOSet:TYPE
        /// <summary>
        /// Sets the CSA autoset type
        /// 
        /// AUTOSet:TYPE
        /// </summary>
        void CSAAutosetType(string type);
        #endregion AUTOSet:TYPE
        #endregion AUTOSET

        #region AUXout:SOUrce
        /// <summary>
        /// Sets the DPO trigger source at the BNC connector
        /// 
        /// AUXout:SOUrce
        /// </summary>
        void DPOAUXOutSource(string source);
        #endregion AUXout:SOUrce

        #region CH[n]
        #region CH[n]:OFFSet

        /// <summary>
        /// Sets the channel vertical offset
        /// 
        /// CH[n]:OFFSet
        /// </summary>
        void ScopeChannelOffset(string channel, string value);
        #endregion CH[n]:OFFSet

        #region CH[n]:SCAle
        /// jmanning 01/08/14
        /// Need to change DPO and CSA tests over to ScopeVerticalScale
        /// <summary>
        /// Sets the Scope vertical scale for the given channel
        /// 
        /// CH[n]:SCAle
        /// </summary>
        void ScopeVerticalScale(string channel, string scale);
        #endregion CH[n]:SCAle

        #region CH[n]:TERmination
        /// <summary>
        /// This command sets the connected/disconnected status of a 50 Ω resistor, which
        /// can be connected between the specified channel's coupled input and instrument
        /// ground.
        /// 
        /// CH[n]:TERmination
        /// </summary>
        void DPOCHTermination(string channel, string impedance);
        #endregion CH[n]:TERmination
        #endregion CH[n]

        #region DISplay:PERSistence
        /// <summary>
        /// Sets the DPO display persistence
        /// 
        /// DISplay:PERSistence
        /// </summary>
        void DPODisplayPersistence(string type);
        #endregion DISplay:PERSistence

        #region EVENT?
        /// <summary>
        /// Gets the current event code the queue
        /// 
        /// EVENT?
        /// </summary>
        /// <returns>Event code</returns>
        string ScopeEventQuery();
        #endregion EVENT?

        #region EVMsg?
        /// <summary>
        /// Gets the current event code and message on the queue
        /// 
        /// EVMsg?
        /// </summary>
        /// <returns>Event code and message</returns>
        string ScopeEventMessageQuery();
        #endregion EVMsg?

        #region FACtory
        /// <summary>
        /// Resets scope to factory default setup
        /// 
        /// FACtory
        /// </summary>
        void ScopeFactoryDefault();
        #endregion FACtory

        #region FASTAcq:STATE
        /// <summary>
        /// This command sets the state of Fast Acquisitions
        /// </summary>
        void DPOFastAcquisitions(string state);
        #endregion FASTAcq:STATE

        #region HORizontal
        #region HORizontal:MAIn:POSition

        /// <summary>
        /// Set the scope horizontal position
        /// 
        /// HORizontal:MAIn:POSition
        /// </summary>
        void ScopeHorizontalPosition(string position);
        #endregion HORizontal:MAIn:POSition

        #region HORizontal:MAIn:SCAle
        /// <summary>
        /// Sets the CSA horizonal scale
        /// 
        /// HORizontal:MAIn:SCAle
        /// </summary>
        void CSAHorizontalMainScale(string scale);
        #endregion HORizontal:MAIn:SCAle

        #region HORizontal:MODE:SAMPLERate
        /// <summary>
        /// Sets the DPO horizontal sample rate in samples per seconds
        /// 
        /// HORizontal:MODE:SAMPLERate
        /// </summary>
        void DPOHorizontalModeSampleRate(string rate);
        #endregion HORizontal:MODE:SAMPLERate

        #region HORizontal:MODE:SCAle
        /// <summary>
        /// Sets the DPO horizontal scale in seconds per division
        /// 
        /// HORizontal:MODE:SCAle
        /// </summary>
        void DPOHorizontalModeScale(string scale);
        #endregion HORizontal:MODE:SCAle
        #endregion HORizontal

        #region MEASUrement

        #region MEASUrement:MEAS[n]:MAXimum?

        /// <summary>
        /// Gets the maximum measurement from the CSA or DPO
        /// 
        /// MEASUrement:MEAS[n]:MAXimum?
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <returns>Maximum measurement</returns>
        string ScopeMeasureMaxQuery(string measurement);
        #endregion MEASUrement:MEAS[n]:MAXimum?

        #region MEASUrement:MEAS[n]:MEAN?
        /// <summary>
        /// Gets the mean measurement from the CSA or DPO
        /// 
        /// MEASUrement:MEAS[n]:MEAN?
        /// </summary>
        /// <returns>Mean measurement</returns>
        string ScopeMeasureMeanQuery(string measurement);
        #endregion MEASUrement:MEAS[n]:MEAN?

        #region MEASUrement:MEAS[n]:MINImum?

        /// <summary>
        /// Gets the minimum measurement from the CSA or DPO
        /// 
        /// MEASUrement:MEAS[n]:MINImum?
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <returns>Minimum measurement</returns>
        string ScopeMeasureMinQuery(string measurement);
        #endregion MEASUrement:MEAS[n]:MINImum?

        #region MEASUrement:MEAS[n]:SOUrce CH[n]

        /// <summary>
        /// Sets the DPO measurement source to a given channel
        /// 
        /// MEASUrement:MEAS[n]:SOUrce CH[n]
        /// </summary>
        /// <param name="source">hich channel to be used as a source for the measurement</param>
        /// <param name="measurement">Different numbered measurement displays</param>
        void DPOMeasureSource(string measurement, string source);
        #endregion MEASUrement:MEAS[n]:SOUrce CH[n]

        #region MEASUrement:MEAS[n]:SOURCE1 CH[n]
        /// <summary>
        /// Sets the measurement source for the CSA and the DPO
        /// 
        /// MEASUrement:MEAS[n]:SOURCE1 CH[n]
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <param name="sourceChan">Channel to use as Measurement Source</param>
        /// <param name="state">Measurement state</param>
        void ScopeMeasureSource(string measurement, string sourceChan, string state);
        #endregion MEASUrement:MEAS[n]:SOURCE1 CH[n]

        #region MEASUrement:MEAS[n]:SOUrce[channel]:WFM
        /// <summary>
        /// Sets the CSA measurement source to a given channel
        /// 
        /// MEASUrement:MEAS[n]:SOUrce[channel]:WFM
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <param name="source">Scope visa session and a collection of state variables</param>
        void CSAMeasureSource(string measurement, string source);
        #endregion MEASUrement:MEAS[n]:SOUrce[channel]:WFM

        #region MEASUrement:MEAS[n]:STATE

        /// <summary>
        /// Sets the measurement state for the CSA and the DPO
        /// 
        /// MEASUrement:MEAS[n]:STATE
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <param name="state">Measurement state</param>
        void ScopeMeasureState(string measurement, string state);
        #endregion MEASUrement:MEAS[n]:STATE

        #region MEASUrement:MEAS[n]:STDdev?
        /// <summary>
        /// Gets the standard deviation measurement from the CSA or DPO
        /// 
        /// MEASUrement:MEAS[n]:STDdev?
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <returns>Standard Deviation measurement</returns>
        string ScopeMeasureStdDevQuery(string measurement);
        #endregion MEASUrement:MEAS[n]:STDdev?   

        #region MEASUrement:MEAS[n]:TYPe
        /// <summary>
        /// Sets the measurement type for the CSA and the DPO
        /// 
        /// NOTE: The string values for type differs between CSA and DPO along with types available on the DPO that are not on the CSA@n
        /// MEASUrement:MEAS[n]:TYPe
        /// </summary>
        void ScopeMeasureType(string measurement, string type);
        #endregion MEASUrement:MEAS[n]:TYPe

        #region MEASUrement:MEAS[n]:VALue?
        /// <summary>
        /// Gets the measurement value from the CSA or DPO
        /// 
        /// MEASUrement:MEAS[n]:VALue?
        /// </summary>
        /// <returns>Measurement value</returns>
        string ScopeMeasureValueQuery(string measurement);
        #endregion MEASUrement:MEAS[n]:VALue?

        #region MEASUrement:MEAS1:STATistics:CLEAR
        /// <summary>
        /// Resets the CSA measurement statistics
        /// 
        /// MEASUrement:MEAS1:STATistics:CLEAR
        /// </summary>
        void CSAMeasurementReset();
        #endregion MEASUrement:MEAS1:STATistics:CLEAR

        #region MEASUrement:IMMed:SOUrce1 CH[n]
        /// <summary>
        /// Sets the DPO immediate source to a given channel
        /// 
        /// MEASUrement:IMMed:SOUrce1 CH[n]
        /// </summary>
        void DPOImmedMeasureSource(string source);
        #endregion MEASUrement:IMMed:SOUrce1 CH[n]

        #region MEASUrement:IMMed:TYPe
        /// <summary>
        /// Sets the DPO immediate measurement type
        /// 
        /// MEASUrement:IMMed:TYPe
        /// </summary>
        void DPOImmedMeasureType(string type);
        #endregion MEASUrement:IMMed:TYPe

        #region MEASUrement:IMMed:VALue
        /// <summary>
        /// Gets the DPO immediate value
        /// 
        /// MEASUrement:IMMed:VALue
        /// </summary>
        /// <returns>Immediate value</returns>
        string DPOImmedMeasureValueQuery();
        #endregion MEASUrement:IMMed:VALue

        #region MEASUrement:STATistics:COUNt RESET
        /// <summary>
        /// Resets the DPO measurement statistics
        /// 
        /// MEASUrement:STATistics:COUNt RESET
        /// </summary>
        void DPOMeasurementReset();
        #endregion MEASUrement:STATistics:COUNt RESET
        #endregion MEASUrement

        #region MASK
        #region MASK:COUNt:HITS?
        /// <summary>
        /// Gets the mask hit count for all the mask segments
        /// 
        /// MASK:COUNt:HITS?
        /// </summary>
        /// <returns>Mask hit count for all the masks</returns>
        string DPOMaskHitCountTotalQuery();
        #endregion MASK:COUNt:HITS?
               
        #region MASK:COUNt RESET
        /// <summary>
        /// Resets the mask count
        /// Same Command for DPO and CSA change calls from CSA and DPO to ScopeMaskCountReset
        /// MASK:COUNt RESET
        /// </summary>
        void ScopeMaskCountReset();
        #endregion MASK:COUNt RESET

        #region MASK:COUNt:SEG[n]:HITS?
        /// <summary>
        /// Gets the mask hit count for a specified mask segment on a DPO Scope
        /// 
        /// MASK:COUNt:SEG[n]:HITS?
        /// </summary>
        /// <returns>Mask count</returns>
        string DPOMaskSegmentHitCountQuery(int maskSegment);
        #endregion MASK:COUNt:SEG[n]:HITS?
              
        #region MASK:COUNt:STATE
        /// <summary>
        /// Turns the mask counting state on or off
        /// 
        /// MASK:COUNt:STATE
        /// </summary>
        void CSAMaskCountState(string state);
        #endregion MASK:COUNt:STATE

        #region MASK:COUNt:TOTal?
        /// <summary>
        /// Gets the mask hit count for all the masks 
        /// 
        /// MASK:COUNt:TOTal?
        /// </summary>
        /// <returns>Mask hit count for all the masks</returns>
        string CSAMaskHitCountTotalQuery();
        #endregion MASK:COUNt:TOTal?

        #region MASK:DISplay
        /// <summary>
        /// Used for turning on and off Masks withoout Deleting them
        /// Mask Counting, mask testing, and mask autoset are unavailable is the mask display is OFF
        /// Default setting is ON
        /// 
        /// MASK:DISplay [OFF|ON]
        /// </summary>
        void DPOMaskDisplayState(string displayState);
        #endregion MASK:DISplay

        #region MASK:MASK[n]:COUNt?
        /// <summary>
        /// Gets the CSA mask hit count for a specified masks
        /// 
        /// MASK:MASK[n]:COUNt?
        /// </summary>
        /// <returns>Mask count</returns>
        string CSAMaskHitCountQuery(string maskNumber);
        #endregion MASK:MASK[n]:COUNt?

        #region MASK:MASK[n] DELETE
        /// <summary>
        /// Deletes the mask vertices for a given mask on a CSA
        /// 
        /// MASK:MASK[n]DELETE
        /// </summary>
        void CSAMaskDelete(string maskNumber);
        #endregion MASK:MASK[n] DELETE

        #region MASK:MASK[n]:POINTSPcnt
        /// <summary>
        /// Sets the mask vertices for a given mask by percentage
        /// 
        /// MASK:MASK[n]:POINTSPcnt
        /// </summary>
        void CSAMaskPoint(string maskNumber, string maskList);
        #endregion MASK:MASK[n]:POINTSPcnt

        #region MASK:SOUrce
        /// <summary>
        /// Sets the source for all the masks to given channel
        /// Can be set to other things but ignored here for brevity
        /// 
        /// MASK:SOUrce CH[n]
        /// </summary>
        void ScopeMaskSourceCH(string channel);
        #endregion MASK:SOUrce

        #region MASK:STANdard
        /// <summary>
        /// Deletes the existing mask and sets the selected standard mask on a DPO scope
        /// 
        /// MASK:STANdard
        /// </summary>
        void DPOMaskStandardSet(string maskStandard);
        #endregion MASK:STANdard

        #region MASK:TESt:STATE
        /// <summary>
        /// Turns the mask test counting state on or off
        /// 
        /// MASK:TESt:STATE
        /// </summary>
        void DPOMaskCountState(string state);
        #endregion MASK:TESt:STATE

        #region MASK:TESt:STATUS?
        /// <summary>
        /// Gets the DPO Mask Test Status
        /// 
        /// MASK:TESt:STATUS?
        /// </summary>
        /// <returns>DPO mask test status</returns>
        string DPOMaskTestStatusQuery();
        #endregion MASK:TESt:STATUS?
        #endregion MASK

        #region RECAll
        #region RECAll:MASK
        /// <summary>
        /// Loads a mask file onto the scope
        /// 
        /// RECAll:MASK
        /// </summary>
        void ScopeRecallMask(string filepath);
        #endregion RECAll:MASK

        #region RECAll:SETUp
        /// <summary>
        /// Loads a setup file onto the scope
        /// 
        /// RECAll:SETUp
        /// </summary>
        void ScopeRecallSetup(string filepath);
        #endregion RECAll:SETUp
        #endregion RECAll

        #region REF[n]:VERTical:SCAle
        /// <summary>
        /// Sets the DPO vertical scale for the given reference waveform
        /// 
        /// REF[n]:VERTical:SCAle
        /// </summary>
        void DPORefVerticalScale(string channel, string scale);
        #endregion REF[n]:VERTical:SCAle

        #region SELect:CH
        /// <summary>
        /// Sets the Channel state [OFF|ON] for the desired Channel
        /// 
        /// SELect:CH[n] 
        /// </summary>
        void ScopeSelectChannelState(string channel, string state);
        #endregion SELect:CH

        #region SYSTem:ERRor?

        /// <summary>
        /// Gets the system error code and message from the scope
        /// 
        /// SYSTem:ERRor?
        /// </summary>
        /// <returns>System error code and message</returns>
        string GetScopeSystemErrorQuery();
        #endregion SYSTem:ERRor?

        #region TRIGger
        #region TRIGger:A:EDGe:SOUrce
        /// <summary>
        /// This command sets the source for the edge trigger
        /// 
        /// TRIGger:A:EDGe:SOUrce
        /// </summary>
        void DPOTriggerSource(string source);
        #endregion TRIGger:A:EDGe:SOUrce

        #region TRIGger:A:LEVel
        /// <summary>
        /// This command sets the level for trigger A for all channels
        /// 
        /// TRIGger:A:LEVel
        /// </summary>
        void DPOTriggerLevel(string setValue);
        #endregion TRIGger:A:LEVel

        #region TRIGger:A:LEVel:CH
        /// <summary>
        /// This command sets the CH[n] trigger level for
        /// TRIGGER:LVLSRCPREFERENCE SRCDEPENDENT mode.
        /// 
        /// TRIGger:A:LEVel:CH[n]
        /// </summary>
        void DPOTriggerLevelChannel(string setValue, string channel);
        #endregion TRIGger:A:LEVel:CH

        #region TRIGger:A:MODe
        /// <summary>
        /// Set the DPO trigger mode
        /// 
        /// TRIGger:A:MODe
        /// </summary>
        void DPOTriggerMode(string mode);
        #endregion TRIGger:A:MODe

        #region TRIGger:A:PULse:WINdow:EVENT
        /// <summary>
        /// This command sets or queries the window trigger event. This command is
        /// equivalent to selecting Window Setup from the Trig menu and selecting from
        /// the Window Event box.
        /// 
        /// TRIGger:A:PULse:WINdow:EVENT
        /// </summary>
        void DPOTriggerWindowEvent(string eventType);
        #endregion TRIGger:A:PULse:WINdow:EVENT

        #region TRIGger:A:PULse:WINdow:THReshold:
        /// <summary>
        /// This command sets the upper and lower limits for the pulse window trigger.
        /// 
        /// TRIGger:A:PULse:WINdow:THReshold:HIGH ;LOW
        /// </summary>
        void DPOTriggerWindow(string high, string low);
        #endregion TRIGger:A:PULse:WINdow:THReshold:

        #region TRIGger:STATe?
        /// <summary>
        /// This query-only command returns the current state of the triggering system
        /// 
        /// TRIGger:STATe?
        /// </summary>
        /// <returns>Current State of the triggering system</returns>
        string ScopeTriggerStateQuery();
        #endregion TRIGger:STATe?

        #region TRIGger:HOLDoff
        /// <summary>
        /// Sets the CSA trigger holdoff time
        /// 
        /// TRIGger:HOLDoff
        /// </summary>
        void CSATriggerHoldoff(string time);
        #endregion TRIGger:HOLDoff

        #region TRIGger:HOLDoff?
        /// <summary>
        /// Gets the CSA trigger holdoff time
        /// 
        /// TRIGger:HOLDoff?
        /// </summary>
        string CSATriggerHoldoffQuery();
        #endregion TRIGger:HOLDoff?

        #region TRIGger:MODe
        /// <summary>
        /// 
        /// </summary>
        void CSATriggerMode(string mode);
        #endregion TRIGger:MODe

        #region TRIGger:SOUrce
        /// <summary>
        /// TRIGger:SOUrce
        /// </summary>
        void CSATriggerSource(string source);
        #endregion TRIGger:SOUrce
        #endregion TRIGger
    }
}
