//==========================================================================
// ScopeTrigger__steps.cs
// This file contains the low-order PI step definitions for the Scope PI Trigger Group commands. 
//
// Low-level steps set and get the values for commands, and test the raw values as returned from the 
// instrument. They DO NOT interpret values in any way! Interpretation, normalization, etc. need to 
// occur in the High-level step definitions. Notice the use of the word "value" in the steps - this 
// usually implies that the query returns a 0 or 1 or abbreviated text value (like SOFT) that should 
// be interpreted as ON or OFF or SOFTWARE to make the step more user-friendly. We do that in the 
// High-order step definitions.
// 
// PLEASE use the following regular expressions to match specified numeric formats and other values:
// <NR1> - ((?<!\S)[-+]?\d+(?!\S))
// <NR3> - ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?)
// File path strings - ""(.+)"" used when you want the string that is delimited by the quotes File path strings
//                         
//==========================================================================

using TechTalk.SpecFlow;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains the low-order PI step definitions for the Scope PI Trigger Group commands.
    /// Low-level steps set and get the values for commands, and test the raw values as returned from the 
    /// instrument. They DO NOT interpret values in any way! Interpretation, normalization, etc. need to 
    /// occur in the High-level step definitions. Notice the use of the word "value" in the steps - this 
    /// usually implies that the query returns a 0 or 1 or abbreviated text value (like SOFT) that should 
    /// be interpreted as ON or OFF or SOFTWARE to make the step more user-friendly. We do that in the 
    /// High-order step definitions.
    /// 
    /// </summary> 
    [Binding] //Very important! This entry needs to be made in each step definition file.
    public class ScopeTriggerSteps
    {
        private readonly ScopeTriggerGroup _scopeTriggerGroup = new ScopeTriggerGroup();

        #region AUXOUT:SOURCE
        /// <summary>
        /// Changes the state of the 10 MHz External clock output to OFF for a DPO Scope
        ///
        /// AUXOUT:SOURCE OFF
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"I turn the 10 MHz reference clock output off for the Scope")]
            \endverbatim 
        */
        [When(@"I turn the 10 MHz reference clock output off for the Scope")]
        public void SetTheScope10MhzReferenceClockStateOff()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.SetDPOTriggerSourceForTheBNCConnector(scope, "OFF");
        }

        /// <summary>
        /// Sets Aux Trigger source at the BNC Connector to trigger A for a DPO Scope
        /// 
        /// AUXOUT:SOURCE ATRIGger
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"I set the trigger source at BNC connector to trigger A on the Scope")]
            \endverbatim 
        */
        [When(@"I set the trigger source at BNC connector to trigger A on the Scope")]
        public void SetTheScopeTriggerSourceAtBNCConnectorATrig()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.SetDPOTriggerSourceForTheBNCConnector(scope, "ATRIGger");
        }

        /// <summary>
        /// Sets Aux Trigger source at the BNC Connector to trigger B for a DPO Scope
        /// 
        /// AUXOUT:SOURCE BTRIGger
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"I set the trigger source at BNC connector to trigger B on the Scope")]
            \endverbatim 
        */
        [When(@"I set the trigger source at BNC connector to trigger B on the Scope")]
        public void SetTheScopeTriggerSourceAtBNCConnectorBTrig()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.SetDPOTriggerSourceForTheBNCConnector(scope, "BTRIGger");
        }

        /// <summary>
        /// Sets Aux Trigger source at the BNC Connector to main for a DPO Scope
        /// 
        /// AUXOUT:SOURCE MAIn
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"I set the trigger source at BNC connector to main om the Scope")]
            \endverbatim 
        */
        [When(@"I set the trigger source at BNC connector to main on the Scope")]
        public void SetTheScopeTriggerSourceAtBNCConnectorMain()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.SetDPOTriggerSourceForTheBNCConnector(scope, "MAIn");
        }

        /// <summary>
        /// Sets Aux Trigger source at the BNC Connector to delayed for a DPO Scope
        /// 
        /// AUXOUT:SOURCE DELayed
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"I set the trigger source at BNC connector to delayed on the Scope")]
            \endverbatim 
        */
        [When(@"I set the trigger source at BNC connector to delayed on the Scope")]
        public void SetTheScopeTriggerSourceAtBNCConnectorDelayed(string source)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.SetDPOTriggerSourceForTheBNCConnector(scope, "DELayed");
        }

        /// <summary>
        /// Sets Aux Trigger source at the BNC Connector to REF Out for a DPO Scope
        /// 
        /// AUXOUT:SOURCE REFOut
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"I set the trigger source at BNC connector to REF Out on the Scope")]
            \endverbatim 
        */
        [When(@"I set the trigger source at BNC connector to REF Out on the Scope")]
        public void SetTheScopeTriggerSourceAtBNCConnector2RefOut(string source)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.SetDPOTriggerSourceForTheBNCConnector(scope, "REFOut");
        }

        /// <summary>
        /// Changes the state of the 10 MHz External clock output to on for a DPO Scope
        ///
        /// AUXOUT:SOURCE ON
        /// </summary>
        /*!
            \scope\verbatim
        [[When(@"I turn the 10 MHz reference clock output on for the Scope")]
            \endverbatim 
        */
        [When(@"I turn the 10 MHz reference clock output on for the Scope")]
        public void SetTheScope10MhzReferenceClockStateOn()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.SetDPOTriggerSourceForTheBNCConnector(scope, "ON");
        }
        #endregion AUXOUT:SOURCE

        #region TRIGger:A:EDGE:SOURCE
        /// <summary>
        /// Set the trigger source to auxiliary for a DPO Scope
        /// 
        /// TRIGger:A:EDGE:SOURCE AUX
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"I set the trigger source to auxillary on the Scope")]
            \endverbatim 
        */
        [When(@"I set the trigger source to auxillary on the Scope")]
        public void SetTheScopeTriggerSourceAux()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.SetDPOTriggerSource(scope, "AUX");
        }

        /// <summary>
        /// Set the trigger source to line for a DPO Scope
        /// 
        /// TRIGger:A:EDGE:SOURCE LINE
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"I set the trigger source to line on the Scope")]
            \endverbatim 
        */
        [When(@"I set the trigger source to line on the Scope")]
        public void SetTheScopeTriggerSourceLine()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.SetDPOTriggerSource(scope, "LINE");
        }

        /// <summary>
        /// Set the trigger source to the specified channel for a DPO Scope
        /// 
        /// TRIGger:A:EDGE:SOURCE CH[n]
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"I set the trigger source to channel ([1-4] on the Scope")]
            \endverbatim 
        */
        [When(@"I set the trigger source to channel ([1-4]) on the Scope")]
        public void SetTheScopeTriggerSourceChannel(string channel)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            string source = "CH" + channel;
            _scopeTriggerGroup.SetDPOTriggerSource(scope, source);
        }
        #endregion TRIGger:A:EDGE:SOURCE

        #region TRIGger:A:LEVel
        /// <summary>
        /// Set the global trigger level for all channels on a DPO Scope
        /// 
        /// TRIGger:A:LEVel
        /// </summary>
        /// <param name="setValue">Trigger level</param>
        /*!
            \scope\verbatim
        [When(@"I set the trigger level to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?)V on the Scope")]
            \endverbatim 
        */
        [When(@"I set the trigger level to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?)V on the Scope")]
        public void SetTheScopeTriggerLevel(string setValue)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.SetDPOTriggerLevel(scope, setValue);
        }
        #endregion TRIGger:A:LEVel

        #region TRIGger:A:LEVel:CH[x]
        /// <summary>
        /// Set the trigger level for a given channel on a DPO Scope
        /// 
        /// TRIGger:A:LEVel:CH[x]
        /// </summary>
        /// <param name="setValue">Trigger level</param>
        /// <param name="channel">Trigger source CH1|CH2|CH3|CH4</param>
        /*!
            \scope\verbatim
        [When(@"I set the trigger level to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?)V for channel ([1-4]) on the Scope")]
            \endverbatim 
        */
        [When(@"I set the trigger level to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?)V for channel ([1-4]) on the Scope")]
        public void SetTheScopeTriggerLevelForGivenChannel(string setValue, string channel)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.SetDPOTriggerLevelChannel(scope, setValue, channel);
        }
        #endregion TRIGger:A:LEVel:CH[x]

        #region TRIGger:A:MODe
        /// <summary>
        /// Sets the trigger mode to auto on a DPO Scope
        /// 
        /// TRIGger:A:MODe AUTO
        /// </summary>
        /*!
			\scope\verbatim
        [When(@"I set the trigger mode to auto on the Scope")]
			\endverbatim 
		*/
        [When(@"I set the trigger mode to auto on the Scope")]
        public void SetTheScopeTriggerModeAuto()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.SetDPOTriggerMode(scope, "AUTO");
        }

        /// <summary>
        /// Sets the trigger mode to normal on a DPO Scope
        /// 
        /// TRIGger:A:MODe NORMal
        /// </summary>
        /*!
			\scope\verbatim
        [When(@"I set the trigger mode to normal on the Scope")]
			\endverbatim 
		*/
        [When(@"I set the trigger mode to normal on the Scope")]
        public void SetTheScopeTriggerModeNormal()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.SetDPOTriggerMode(scope, "NORMal");
        }
        #endregion TRIGger:A:MODe

        #region TRIGGER:A:PULSE:WINDOW:EVENT
        /// <summary>
        /// Sets the trigger window to trigger for an entering window event on a DPO Scope
        /// 
        /// TRIGGER:A:PULSE:WINDOW:EVENT ENTERSWindow
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"I set the trigger window to trigger when entering window event occurs on the Scope")]
            \endverbatim 
        */
        [When(@"I set the trigger window to trigger when entering window event occurs on the Scope")]
        public void SetTheScopeTriggerWindowEventTypeEntersWindow()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.SetDPOTriggerWindowEvent(scope, "ENTERSWindow");
        }

        /// <summary>
        /// Sets the trigger window to trigger for a exiting window event on a DPO Scope
        /// 
        /// TRIGGER:A:PULSE:WINDOW:EVENT EXITSWindow
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"I set the trigger window to trigger when exiting windowevent occurs on the Scope")]
            \endverbatim 
        */
        [When(@"I set the trigger window to trigger when exiting windowevent occurs on the Scope")]
        public void SetTheScopeTriggerWindowEventTypeExitsWindow()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.SetDPOTriggerWindowEvent(scope, "EXITSWindow");
        }
        
        /// <summary>
        /// Sets the trigger window to trigger for a inside window greater than threshold event on a DPO Scope
        /// 
        /// TRIGGER:A:PULSE:WINDOW:EVENT INSIDEGreater
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"I set the trigger window to trigger when inside window greater than threshold event occurs on the Scope")]
            \endverbatim 
        */
        [When(@"I set the trigger window to trigger when inside window greater than threshold event occurs on the Scope")]
        public void SetTheScopeTriggerWindowEventTypeInGreater()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.SetDPOTriggerWindowEvent(scope, "INSIDEGreater");
        }
        
        /// <summary>
        /// Sets the trigger window to trigger for an outside window greater than threshold event on a DPO Scope
        /// 
        /// TRIGGER:A:PULSE:WINDOW:EVENT OUTSIDEGreater
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"I set the trigger window to trigger when outside window greater than threshold event occurs on the Scope")]
            \endverbatim 
        */
        [When(@"I set the trigger window to trigger when outside window greater than threshold event occurs on the Scope")]
        public void SetTheScopeTriggerWindowEventTypeOutGreater()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.SetDPOTriggerWindowEvent(scope, "OUTSIDEGreater");
        }
        #endregion TRIGGER:A:PULSE:WINDOW:EVENT

        #region TRIGGER:A:PULSE:WINDOW:THRESHOLD:
        /// <summary>
        /// Sets the trigger window with the given high and low thresholds on a DPO Scope
        /// 
        /// TRIGger:A:PULse:WINdow:THReshold:HIGH [high];LOW [low]
        /// </summary>
        /// <param name="high">High voltage window threshold</param>
        /// <param name="low">Low voltage window threshold</param>
        /*!
            \scope\verbatim
        [When(@"I set the trigger window from -([0-9].[0-9]+)V to \+([0-9].[0-9]+)V on the Scope")]
            \endverbatim 
        */
        [When(@"I set the trigger window from -([0-9].[0-9]+)V to \+([0-9].[0-9]+)V on the Scope")]
        public void SetTheScopeTriggerWindow(string high, string low)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.SetDPOTriggerWindow(scope, high, low);
        }
        #endregion TRIGGER:A:PULSE:WINDOW:THRESHOLD:

        #region TRIGger:STATe?
        /// <summary>
        /// Get the trigger state from the Scope
        /// 
        /// (DPO|CSA)
        /// TRIGger:STATe?
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"I get the trigger state from the Scope")]
            \endverbatim 
        */
        [When(@"I get the trigger state from the Scope")]
        public void GetTheScopeTriggerState()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.GetScopeTriggerState(scope);
        }
        /// <summary>
        /// Compares the the expected ARMED value versus the current trigger state of the scope.  
        /// 
        /// (DPO|CSA)
        /// TRIGger:STATe?
        /// </summary>
        /*!
            \scope\verbatim
        [Then(@"the trigger state should say ARMED on the Scope")]
            \endverbatim 
        */
        [Then(@"the trigger state should say ARMED on the Scope")]
        public void TheScopeTriggerStateShouldBeArmed()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.TheScopeTriggerStateShouldBe(scope, "ARMED");
        }

        /// <summary>
        /// Compares the expected AUTO value versus the current trigger state of the scope.  
        /// 
        /// (DPO|CSA)
        /// TRIGger:STATe?
        /// </summary>
        /*!
            \scope\verbatim
        [Then(@"the trigger state should say AUTO on the Scope")]
            \endverbatim 
        */
        [Then(@"the trigger state should say AUTO on the Scope")]
        public void TheScopeTriggerStateShouldBeAuto()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.TheScopeTriggerStateShouldBe(scope, "AUTO");
        }

        /// <summary>
        /// Compares the expected DPO value versus the current trigger state of the scope.  
        /// 
        /// TRIGger:STATe?
        /// </summary>
        /*!
            \scope\verbatim
        [Then(@"the trigger state should say DPO on the Scope")]
            \endverbatim 
        */
        [Then(@"the trigger state should say DPO on the Scope")]
        public void TheScopeTriggerStateShouldBeDPO()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.TheScopeTriggerStateShouldBe(scope, "DPO");
        }


        /// <summary>
        /// Compares the expected PARTIAL value versus the current trigger state of the scope.  
        /// 
        /// (DPO|CSA)
        /// TRIGger:STATe?
        /// </summary>
        /*!
            \scope\verbatim
        [Then(@"the trigger state should say PARTIAL on the Scope")]
            \endverbatim 
        */
        [Then(@"the trigger state should say PARTIAL on the Scope")]
        public void TheScopeTriggerStateShouldBePartial()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.TheScopeTriggerStateShouldBe(scope, "PARTIAL");
        }

        /// <summary>
        /// Compares the expected READY value versus the current trigger state of the scope.  
        /// 
        /// (DPO|CSA)
        /// TRIGger:STATe?
        /// </summary>
        /*!
            \scope\verbatim
        [Then(@"the trigger state should say READY on the Scope")]
            \endverbatim 
        */
        [Then(@"the trigger state should say READY on the Scope")]
        public void TheScopeTriggerStateShouldBeReady()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.TheScopeTriggerStateShouldBe(scope, "READY");
        }

        /// <summary>
        /// Compares the expected SAVE value versus the current trigger state of the scope.  
        /// 
        /// (DPO|CSA)
        /// TRIGger:STATe?
        /// </summary>
        /*!
            \scope\verbatim
        [Then(@"the trigger state should be SAVE on the Scope")]
            \endverbatim 
        */
        [Then(@"the trigger state should say SAVE on the Scope")]
        public void TheScopeTriggerStateShouldBeSave()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.TheScopeTriggerStateShouldBe(scope, "SAVE");
        }

        /// <summary>
        /// Compares the expected TRIGGER value versus the current trigger state of the scope.  
        /// 
        /// (DPO|CSA)
        /// TRIGger:STATe?
        /// </summary>
        /*!
            \scope\verbatim
        [Then(@"the trigger state should be TRIGGER on the Scope")]
            \endverbatim 
        */
        [Then(@"the trigger state should say TRIGGER on the Scope")]
        public void TheScopeTriggerStateShouldBeTrigger()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.TheScopeTriggerStateShouldBe(scope, "TRIGGER");
        }

        /// <summary>
        /// Verfies that no waveform is detected in the Scope
        /// 
        /// (DPO|CSA)
        /// TRIGger:STATe?
        /// </summary>
        /*!
            \scope\verbatim
        [Then(@"no wavefrom should be detected on the Scope")]
            \endverbatim 
        */
        [Then(@"no wavefrom should be detected on the Scope")]
        public void TheScopeShouldNotDetectAWaveform()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.TheScopeShouldNotDetectWaveform(scope);
        }
        #endregion TRIGger:STATe?

        #region CSA Only
        #region TRIGger:HOLDoff
        /// <summary>
        /// Set the trigger holdoff for a CSA Scope
        /// 
        /// TRIGger:HOLDoff
        /// </summary>
        /*!
            \csa\verbatim
        [When(@"I set the trigger holdoff to ([0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) on the CSA")]
            \endverbatim 
        */
        [When(@"I set the trigger holdoff to ([0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) on the CSA")]
        public void SetTheCSATriggerHoldoff(string value)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.SetCSATriggerHoldoff(scope, value);
        }
        #endregion TRIGger:HOLDoff

        #region TRIGger:HOLDoff?
        /// <summary>
        /// Get the trigger holdoff value on a CSA Scope
        /// 
        /// TRIGger:HOLDoff?
        /// </summary>
        /*!
            \csa\verbatim
        [When(@"I get the trigger holdoff value from the CSA")]
            \endverbatim 
        */
        [When(@"I get the trigger holdoff value from the CSA")]
        public void GetTheCSATriggerHoldoff()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.GetCSATriggerHoldoff(scope);
        }

        /// <summary>
        /// Compares the trigger holdoff time expected value to the value retrieved from the CSA Scope.    
        /// 
        /// TRIGger:HOLDoff?
        /// </summary>
        /*!
            \csa\verbatim
        [Then(@"the trigger holdoff should be ([0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) on the CSA")]
            \endverbatim 
        */
        [Then(@"the trigger holdoff should be ([0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) on the CSA")]
        public void TheCSATriggerHoldoffShouldBe(string value)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.TheCSATriggerHoldoffShouldBe(scope, value);
        }
        #endregion TRIGger:HOLDoff?

        #region TRIGger:MODe
        /// <summary>
        /// Sets the trigger mode to auto on a CSA Scope
        /// 
        /// TRIGger:MODe AUTO
        /// </summary>
        /*!
			\CSA\verbatim
        [When(@"I set the trigger mode to auto on the CSA")]
			\endverbatim 
		*/
        [When(@"I set the trigger mode to auto on the CSA")]
        public void SetTheCSATriggerModeAuto()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.SetCSATriggerMode(scope, "AUTO");
        }

        /// <summary>
        /// Sets the trigger mode to normal on a CSA Scope
        /// 
        /// TRIGger:MODe NORMal
        /// </summary>
        /*!
			\CSA\verbatim
        [When(@"I set the trigger mode to normal on the CSA")]
			\endverbatim 
		*/
        [When(@"I set the trigger mode to normal on the CSA")]
        public void SetTheCSATriggerModeNormal()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.SetCSATriggerMode(scope, "NORMal");
        }
        #endregion TRIGger:MODe

        #region TRIGger:SOURCE
        /// <summary>
        /// Set the trigger source to clock recovery for a CSA Scope
        /// 
        /// TRIGger:SOURCE CLKRECovery
        /// </summary>
        /*!
            \csa\verbatim
        [When(@"I set the trigger source to clock recovery on the CSA")]
            \endverbatim 
        */
        [When(@"I set the trigger source to clock recovery on the CSA")]
        public void SetTheCSATriggerSourceClkRec()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.SetCSATriggerSource(scope, "CLKRECovery");
        }

        /// <summary>
        /// Set the trigger source to external direct for a CSA Scope
        /// 
        /// TRIGger:SOURCE EXTDirect
        /// </summary>
        /*!
            \csa\verbatim
        [When(@"I set the trigger source to external direct on the CSA")]
            \endverbatim 
        */
        [When(@"I set the trigger source to external direct on the CSA")]
        public void SetTheCSATriggerSourceExtDir()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.SetCSATriggerSource(scope, "EXTDirect");
        }

        /// <summary>
        /// Set the trigger source to external prescaler for a CSA Scope
        /// 
        /// TRIGger:SOURCE EXTPrescaler
        /// </summary>
        /*!
            \csa\verbatim
        [When(@"I set the trigger source to external prescaler on the CSA")]
            \endverbatim 
        */
        [When(@"I set the trigger source to external prescaler on the CSA")]
        public void SetTheCSATriggerSourceExtPreS()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.SetCSATriggerSource(scope, "EXTPrescaler");
        }

        /// <summary>
        /// Set the trigger source to internal clock for a CSA Scope
        /// 
        /// TRIGger:SOURCE INTClk
        /// </summary>
        /*!
            \csa\verbatim
        [When(@"I set the trigger source to internal clock on the CSA")]
            \endverbatim 
        */
        [When(@"I set the trigger source to internal clock on the CSA")]
        public void SetTheCSATriggerSourceIntClk()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.SetCSATriggerSource(scope, "INTClk");
        }

        /// <summary>
        /// Set the trigger source to PSYNc for a CSA Scope
        /// 
        /// TRIGger:SOURCE PSYNc
        /// </summary>
        /*!
            \csa\verbatim
        [When(@"I set the trigger source to pattern synchronized on the CSA")]
            \endverbatim 
        */
        [When(@"I set the trigger source to pattern synchronized on the CSA")]
        public void SetTheCSATriggerSourcePsync()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeTriggerGroup.SetCSATriggerSource(scope, "PSYNc");
        }
        #endregion TRIGger:SOURCE
        #endregion CSA only
    }
}
