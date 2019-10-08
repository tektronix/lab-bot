//==========================================================================
// ScopeAquire__steps.cs
// This file contains the low-order PI step definitions for the Scope PI Acquisition Group commands. 
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
using TestStack.White.AutomationElementSearch;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains the low-order PI step definitions for the Scope PI Acquisition Group commands.

    /// Low-level steps set and get the values for commands, and test the raw values as returned from the 
    /// instrument. They DO NOT interpret values in any way! Interpretation, normalization, etc. need to 
    /// occur in the High-level step definitions. Notice the use of the word "value" in the steps - this 
    /// usually implies that the query returns a 0 or 1 or abbreviated text value (like SOFT) that should 
    /// be interpreted as ON or OFF or SOFTWARE to make the step more user-friendly. We do that in the 
    /// High-order step definitions.
    /// 
    /// </summary> 
    [Binding] //Very important! This entry needs to be made in each step definition file.
    public class ScopeAquireSteps
    {
        private readonly ScopeAcquireGroup _scopeAcquireGroup = new ScopeAcquireGroup();

        #region ACQuire:MODe
        /// <summary>
        /// Sets the acquisition mode to AVErage on a Scope
        /// 
        /// (DPO|CSA)
        /// ACQuire:MODe AVErage
        /// </summary>
        /*!
            \SCOPE\verbatim
        [When(@"I set the acquisition mode to average on the Scope")]
            \endverbatim 
        */
        [When(@"I set the acquisition mode to average on the Scope")]
        public void SetTheScopeAcquisitionModeToAverage()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.SetScopeAcquisitionMode(scope, "AVErage");
        }

        /// <summary>
        /// Sets the acquisition mode to ENVelope on a Scope
        /// 
        /// (DPO|CSA)
        /// ACQuire:MODe ENVelope
        /// </summary>
        /*!
            \SCOPE\verbatim
        [When(@"I set the acquisition mode to envelope on the Scope")]
            \endverbatim 
        */
        [When(@"I set the acquisition mode to envelope on the Scope")]
        public void SetTheScopeAcquisitionModeToEnvelope()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.SetScopeAcquisitionMode(scope, "ENVelope");
        }

        /// <summary>
        /// Sets the acquisition mode to SAMple on a Scope
        /// 
        /// (DPO|CSA)
        /// ACQuire:MODe SAMple
        /// </summary>
        /*!
            \SCOPE\verbatim
        [When(@"I set the acquisition mode to sample on the Scope")]
            \endverbatim 
        */
        [When(@"I set the acquisition mode to sample on the Scope")]
        public void SetTheScopeAcquisitionModeToSample()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.SetScopeAcquisitionMode(scope, "SAMple");
        }

        /// <summary>
        /// Sets the acquisition mode to HIRes on a DPO Scope
        /// 
        /// ACQuire:MODe HIRes
        /// </summary>
        /*!
            \SCOPE\verbatim
        [When(@"I set the acquisition mode to hi res on the Scope")]
            \endverbatim 
        */
        [When(@"I set the acquisition mode to hi res on the Scope")]
        public void SetTheScopeScopeAcquisitionModeToHiRes()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.SetScopeAcquisitionMode(scope, "HIRes");
        }

        /// <summary>
        /// Sets the acquisition mode to PEAKdetect on a DPO Scope
        /// 
        /// ACQuire:MODe PEAKdetect
        /// </summary>
        /*!
            \SCOPE\verbatim
        [When(@"I set the acquisition mode to peak detect on the Scope")]
            \endverbatim 
        */
        [When(@"I set the acquisition mode to peak detect on the Scope")]
        public void SetTheScopeScopeAcquisitionModeToPeakDetect()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.SetScopeAcquisitionMode(scope, "PEAKdetect");
        }

        /// <summary>
        /// Sets the acquisition mode to WFMDB on a DPO Scope
        /// 
        /// ACQuire:MODe  WFMDB
        /// </summary>
        /*!
            \SCOPE\verbatim
        [When(@"I set the acquisition mode to waveform database on the Scope")]
            \endverbatim 
        */
        [When(@"I set the acquisition mode to waveform database on the Scope")]
        public void SetTheScopeScopeAcquisitionModeToWFMDB()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.SetScopeAcquisitionMode(scope, "WFMDB");
        }
        #endregion ACQuire:MODe

        #region ACQuire:NUMACq?
        /// <summary>
        /// Gets the mask waveform acquisition count from the DPO Scope. 
        ///  
        /// ACQuire:NUMACq?    
        /// </summary>    
        /*!
            \scope\verbatim
        [When(@"I get the mask waveform acquisition count from the Scope")]
            \endverbatim 
        */
        [When(@"I get the mask waveform acquisition count from the Scope")]
        public void GetScopeAcquisitionWfmCount()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.GetDPOAcquisitionWfmCount(scope);
        }

        /// <summary>
        /// Verfies the DPO Mask waveform acquisition has stopped. 
        ///  
        /// ACQuire:NUMACq?    
        /// </summary>    
        /*!
            \scope\verbatim
        [Then(@"the mask waveform acquisition count should be stopped on the Scope")]
            \endverbatim 
        */
        [Then(@"the mask waveform acquisition count should be stopped on the Scope")]
        public void TheScopeAcquisitionWfmCountShouldBeStopped()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.TheDPOAcquisitionWfmCountShouldBeTrending(scope, "stopped");
        }

        /// <summary>
        /// Verfies the DPO Mask waveform acquisition is increasing. 
        ///  
        /// ACQuire:NUMACq?       
        /// </summary>    
        /*!
            \scope\verbatim
        [Then(@"the mask waveform acquisition count should be increasing on the Scope")]
            \endverbatim 
        */
        [Then(@"the mask waveform acquisition count should be increasing on the Scope")]
        public void TheScopeWfmAcquisitionCountShouldBeIncreasing()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.TheDPOAcquisitionWfmCountShouldBeTrending(scope, "increasing");
        }

        /// <summary>
        /// Waits to see new acquisitions to show on the DPO Scope
        /// 
        /// ACQuire:NUMACq?
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"I wait for to see acquisitions show on the Scope")]
            \endverbatim 
        */
        [When(@"I wait for to see acquisitions show on the Scope")]
        public void WaitForScopeToShowAcquisitions()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.WaitSecondsForDPOScopeToShowAcquisitions(scope); //This is an infinite loop situation added a hard 10 second timeout
        }

        /// <summary>
        /// Waits for the given number of seconds to see new acquisitions on the DPO Scope
        /// 
        /// ACQuire:NUMACq?
        /// </summary>
        /// <param name="seconds">Number of seconds to wait</param>
        /*!
            \scope\verbatim
        [When(@"I wait ([0-9]+) seconds to see acquisitions on the Scope")]
            \endverbatim 
        */
        [When(@"I wait ([0-9]+) seconds to see acquisitions on the Scope")]
        public void WaitSecondsForScopeToShowAcquisitions(string seconds)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.WaitSecondsForDPOScopeToShowAcquisitions(scope, seconds);
        }

        /// <summary>
        /// Verfies the acquisition count is the given number on the DPO Scope.
        /// 
        /// ACQuire:NUMACq?
        /// </summary>
        /*!
            \scope\verbatim
        [Then(@"the acquisition count should be ([0-9]+) on the DPO scope")]
            \endverbatim 
        */
        [Then(@"the acquisition count should be ([0-9]+) on the DPO scope")]
        public void TheScopeAcquisitionCountShouldBe(string count)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.TheDPOScopeAcquisitionCountShouldBe(scope, count);
        }

        /// <summary>
        /// Verfies the acquisition count is between the given low and high numbers on the DPO Scope. 
        /// 
        /// ACQuire:NUMACq?
        /// </summary>
        /// <param name="low">Low acquisition count</param>
        /// <param name="high">High acquisition count</param>
        /*!
            \scope\verbatim
        [Then(@"the acquisition count should be between ([0-9]+) and ([0-9]+) on the Scope")]
            \endverbatim 
        */
        [Then(@"the acquisition count should be between ([0-9]+) and ([0-9]+) on the Scope")]
        public void TheScopeAcquisitionCountShouldBeBetween(string low, string high)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.TheDPOScopeAcquisitionCountShouldBeBetween(scope, high, low);
        }
        #endregion ACQuire:NUMACq?

        #region ACQUIRE:STATE
		/// <summary>
        /// Sets the Acquisition State to ON for the Scope.
        /// 
        /// (DPO|CSA)
        /// ACQUIRE:STATE ON
        /// </summary>
        /*!
           \scope\verbatim
        [When(@"I set the acquisition state to on for the Scope")]
           \endverbatim 
        */
        [When(@"I set the acquisition state to on for the Scope")]
        public void SetTheScopeAcquisitionStateToOn()
        {
            ISCOPE scope = SCOPE.GetScope(false);    
            _scopeAcquireGroup.SetScopeAcquisitionState(scope, "ON");
        }

        /// <summary>
        /// /// Sets the Acquisition State ot OFF for the Scope.
        /// 
        /// (DPO|CSA)
        /// ACQUIRE:STATE OFF
        /// </summary>
        /*!
           \scope\verbatim
        [When(@"I set the acquisition state to off for the Scope")]
           \endverbatim 
        */
        [When(@"I set the acquisition state to off for the Scope")]
        public void SetTheScopeAcquisitionStateToOff()
        {
            ISCOPE scope = SCOPE.GetScope(false);    
            _scopeAcquireGroup.SetScopeAcquisitionState(scope, "OFF");
        } 
	    #endregion ACQUIRE:STATE

        #region ACQUIRE:STATE?
        /// <summary>
        /// Gets the Acquisition state from the Scope.
        /// 
        /// (DPO|CSA)
        /// ACQUIRE:STATE?
        /// </summary>
        /*!
           \scope\verbatim
        [When(@"I get the acquisition state from the Scope")]
           \endverbatim 
       */
        [When(@"I get the acquisition state from the Scope")]
        public void GetScopeAcquisitionState()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.GetScopeAcquisitionState(scope);
        }

        /// <summary>
        /// Sets the Acquisition State to RUN on the Scope and checks after a period
        /// of seconds that is set to RUN
        /// 
        /// (DPO|CSA)
        /// ACQUIRE:STATE
        /// ACQUIRE:STATE?
        /// </summary>
        /// <param name="time">time in seconds to wait before checking in run state</param>
        /*!
          \scope\verbatim
        [When(@"I try to keep the acquisition state in run for ([0-9]+) seconds on the Scope")]
          \endverbatim 
        */
        [When(@"I try to keep the acquisition state in run for ([0-9]+) seconds on the Scope")]
        public void WaitForScopeToSettle(string time)
        {
            SCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.SetScopeAcquisitionStateAndWaitFor(scope, time);
        }
        
        /// <summary>
        /// Checks to see if the Scope stays in Acquisition State "RUN" aka ON or 1 for 
        /// a given amount of seconds
        /// 
        /// (DPO|CSA)
        /// ACQUIRE:STATE?
        /// </summary>
        /// <param name="time"></param>
        /*!
          \scope\verbatim
        [Then(@"the acquisition state should stay in run for ([0-9]+) seconds on the Scope")]
          \endverbatim 
        */
        [Then(@"the acquisition state should stay in run for ([0-9]+) seconds on the Scope")]
        public void TheScopeShouldStayInRunStateSeconds(string time)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.TheScopeStaysInAcquisitionStateFor(scope, "RUN", time, "seconds");
        }
        
        /// <summary>
        /// Checks to see if the Scope stays in Acquisition State "RUN" aka ON or 1 for 
        /// a given amount of minutes
        /// 
        /// (DPO|CSA)
        /// ACQUIRE:STATE?
        /// </summary>
        /// <param name="time"></param>
        /*!
          \scope\verbatim
        [Then(@"the acquisition state should stay in run for ([0-9]+) minutes on the Scope")]
          \endverbatim 
        */
        [Then(@"the acquisition state should stay in run for ([0-9]+) minutes on the Scope")]
        public void TheScopeShouldStayInRunStateMinutes(string time)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.TheScopeStaysInAcquisitionStateFor(scope, "RUN", time, "minutes");
        }

        /// <summary>
        /// Checks to see if the Scope stays in Acquisition State "OFF" aka STOP or 0 for 
        /// a given amount of seconds
        /// 
        /// (DPO|CSA)
        /// ACQUIRE:STATE?
        /// </summary>
        /// <param name="time"></param>
        /*!
          \scope\verbatim
        [Then(@"the acquisition state should stay in off for ([0-9]+) seconds on the Scope")]
          \endverbatim 
        */
        [Then(@"the acquisition state should stay in off for ([0-9]+) seconds on the Scope")]
        public void TheScopeShouldStayInOffStateSeconds(string time)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.TheScopeStaysInAcquisitionStateFor(scope, "OFF", time, "seconds");
        }

        /// <summary>
        /// /// Checks to see if the Scope stays in Acquisition State "OFF" aka STOP or 0 for  
        /// a given amount of minutes
        /// 
        /// (DPO|CSA)
        /// ACQUIRE:STATE?
        /// </summary>
        /// <param name="time"></param>
        /*!
          \scope\verbatim
        [Then(@"the acquisition state should stay in off for ([0-9]+) minutes on the Scope")]
          \endverbatim 
        */
        [Then(@"the acquisition state should stay in off for ([0-9]+) minutes on the Scope")]
        public void TheScopeShouldStayInOffStateMinutes(string time)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.TheScopeStaysInAcquisitionStateFor(scope, "OFF", time, "minutes");
        }
        #endregion ACQUIRE:STATE?

        #region ACQUIRE:STOPAfter
        /// <summary>
        /// Sets the Acquisition StopAfter mode to Runstop on a DPO Scope
        /// 
        /// DPO uses ACQUIRE:STOPAfter RUNSTop
        /// CSA uses ACQUIRE:STOPAfter:MODe RUNSTop
        /// </summary>
        /*!
           \Scope\verbatim
        [When(@"I set the acquisition stop after mode to run stop on the Scope")]
           \endverbatim 
        */
        [When(@"I set the acquisition stop after mode to run stop on the Scope")]
        public void SetTheScopeAcquisitionStopAfterModeToRunStop()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            if (scope.ScopeFamilyType=="CSA")
                _scopeAcquireGroup.SetCSAAcquisitionStopAfterMode(scope, "RUNSTop");
            else
                _scopeAcquireGroup.SetDPOAcquisitionStopAfterMode(scope, "RUNSTop");
        }

        /// <summary>
        /// Sets the Acquisition StopAfter mode to Sequence on a DPO Scope
        /// 
        /// ACQUIRE:STOPAfter
        /// </summary>
        /*!
           \scope\verbatim
        [When(@"I set the acquisition stop after mode to sequence on the Scope")]
           \endverbatim 
        */
        [When(@"I set the acquisition stop after mode to sequence on the Scope")]
        public void SetTheScopeAcquisitionStopAfterModeToSequence()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.SetDPOAcquisitionStopAfterMode(scope, "SEQuence");
        }
        #endregion ACQUIRE:STOPAfter

        #region FASTAcq:STATE
        /// <summary>
        /// Sets the Fast Acquisition State to ON for the DPO Scope
        /// 
        /// FASTAcq:STATE
        /// </summary>
        /*!
          \scope\verbatim
        [When("I set the fast acquistion state to on for the Scope")]
          \endverbatim 
        */
        [When("I set the fast acquistion state to on for the Scope")]
        public void SetTheScopeFastAcquisitionStateOn()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.SetDPOFastAcquisitions(scope, "ON");
        }

        /// <summary>
        /// Sets the Fast Acquisition State to OFF for the DPO Scope
        /// 
        /// FASTAcq:STATE
        /// </summary>
        /*!
          \scope\verbatim
        [When("I set the fast acquistion state to off for the Scope")]
          \endverbatim 
        */
        [When("I set the fast acquistion state to off for the Scope")]
        public void SetTheScopeFastAcquisitionStateOff()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.SetDPOFastAcquisitions(scope, "OFF");
        }
        #endregion FASTAcq:STATE 
       
        #region CSA Scope Only
        #region ACQuire:CURRentcount:MASKWfms?
        /// <summary>
        /// Gets the mask waveform acquisition count from the CSA
        /// 
        /// ACQuire:CURRentcount:MASKWfms?
        /// </summary>
        /*!
            \CSA\verbatim
        [When(@"I get the mask waveform acquisition count from the CSA")]
            \endverbatim 
        */
        [When(@"I get the mask waveform acquisition count from the CSA")]
        public void GetCSAWfmAcquisitionCount()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.GetCSACurrentMaskWfmCountQuery(scope);
        }


        /// <summary>
        /// Verfies that mask waveform acquisition is occuring. 
        /// 
        /// ACQuire:CURRentcount:MASKWfms? 
        /// </summary>    
        /// <param name="time">Amount of time to wait for acquisitions to appear</param>
        /*!
            \CSA\verbatim
        [When("I wait for [(0-9)+] seconds for mask waveform acquisitions to show on the CSA")]
            \endverbatim 
        */
        [When(@"I wait for [(0-9)+] seconds for mask waveform acquisitions to show on the CSA")]
        public void WaitForCSAToShowMaskWfmAcquisitions(string time)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.IWaitUntilCSAMaskShowsWfmAcquisitions(scope, time);
        }
        
        /// <summary>
        /// Verfies the CSA mask waveform acquisition value should be greater than this value. 
        /// 
        /// ACQuire:CURRentcount:MASKWfms?        
        /// </summary>
        /// <param name="expectedValue">Waveform count should be greater than this value</param>
        /*!
            \CSA\verbatim
        [Then(@"the mask waveform acquisition count should be greater than ([0-9]+) from the CSA")]
            \endverbatim 
        */
        [Then(@"the mask waveform acquisition count should be greater than ([0-9]+) from the CSA")]
        public void TheCSAWfmAcquisitionCountShouldBeGreaterThan(string expectedValue)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.TheCSAMaskWaveformAcquisitionCountShouldBeGreaterThan(scope, expectedValue);
        }


        /// <summary>
        /// Verfies the CSA Mask waveform acquisition has stopped. 
        ///  
        /// ACQuire:CURRentcount:MASKWfms?        
        /// </summary>    
        /*!
            \CSA\verbatim
        [Then(@"the mask waveform acquisition count should be stopped on the CSA")]
            \endverbatim 
        */
        [Then(@"the mask waveform acquisition count should be stopped on the CSA")]
        public void TheCSAWfmAcquisitionCountShouldBeStopped()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.TheCSAMaskWaveformAcquisitionCountShouldBeTrending(scope, "stopped");
        }

        /// <summary>
        /// Verfies the CSA Mask waveform acquisition is increasing. 
        ///  
        /// ACQuire:CURRentcount:MASKWfms?        
        /// </summary>    
        /*!
            \CSA\verbatim
        [Then(@"the mask waveform acquisition count should be increasing on the CSA")]
            \endverbatim 
        */
        [Then(@"the mask waveform acquisition count should be increasing on the CSA")]
        public void TheCSAWfmAcquisitionCountShouldBeIncreasing()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.TheCSAMaskWaveformAcquisitionCountShouldBeTrending(scope, "increasing");
        }
        #endregion ACQuire:CURRentcount:MASKWfms?

        #region ACQuire:CURRentcount:ACQWfms?
        /// <summary>
        /// Gets the acquisition count from the CSA
        /// 
        /// ACQuire:CURRentcount:ACQWfms?
        /// </summary>
        /*!
            \CSA\verbatim
        [When(@"I get the acquisition count from the CSA")]
            \endverbatim 
        */
        [When(@"I get the acquisition count from the CSA")]
        public void GetCSAAcquisitionCount()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.GetCSAAcquisitionCount(scope);
        }

        /// <summary>
        /// Waits to see new acquisitions to show on the CSA
        /// 
        /// ACQuire:CURRentcount:ACQWfms?
        /// </summary>
        /*!
            \CSA\verbatim
        [When(@"I wait for the to show acquisitions on the CSA")]
            \endverbatim 
        */
        [When(@"I wait for the to show acquisitions on the CSA")]
        public void WaitForCSAScopeToShowAcquisitions()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.WaitSecondsForCSAScopeToShowAcquisitions(scope); //This is an infinite loop situation added a hard 10 second timeout
        }

        /// <summary>
        /// Waits for the given number of seconds to see new acquisitions on the CSA
        /// 
        /// ACQuire:CURRentcount:ACQWfms?
        /// </summary>
        /// <param name="value">Number of seconds to wait</param>
        /*!
            \CSA\verbatim
        [When(@"I wait ([0-9]+) seconds to see acquisitions on the CSA")]
            \endverbatim 
        */
        [When(@"I wait ([0-9]+) seconds to see acquisitions on the CSA")]
        public void WaitSecondsForCSAScopeToShowAcquisitions(string value)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.WaitSecondsForCSAScopeToShowAcquisitions(scope, value);
        }

        /// <summary>
        /// Verfies the acquisition count is the given number on the CSA.
        /// 
        /// ACQuire:CURRentcount:ACQWfms?
        /// </summary>
        /*!
            \CSA\verbatim
        [Then(@"the acquisition count should be ([0-9]+) on the CSA scope")]
            \endverbatim 
        */
        [Then(@"the acquisition count should be ([0-9]+) on the CSA scope")]
        public void TheCSAScopeAcquisitionCountShouldBe(string count)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.TheCSAScopeAcquisitionCountShouldBe(scope, count);
        }

        /// <summary>
        /// Verfies the acquisition count is between the given low and high numbers on the CSA. 
        /// 
        /// ACQuire:CURRentcount:ACQWfms?
        /// </summary>
        /// <param name="low">Low acquisition count</param>
        /// <param name="high">High acquisition count</param>
        /*!
            \CSA\verbatim
        [Then(@"the acquisition count should be between ([0-9]+) and ([0-9]+) on the CSA")]
            \endverbatim 
        */
        [Then(@"the acquisition count should be between ([0-9]+) and ([0-9]+) on the CSA")]
        public void TheCSAScopeAcquisitionCountShouldBeBetween(string low, string high)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.TheCSAScopeAcquisitionCountShouldBeBetween(scope, high, low);
        }
        #endregion ACQuire:CURRentcount:ACQWfms?

        #region ACQuire:DATA:CLEar
        /// <summary>
        /// Resets the acquisition count for a CSA Scope
        /// 
        /// ACQuire:DATA:CLEar
        /// </summary>
        /*!
            \CSA\verbatim
        [When(@"I reset the acquisition count on the CSA")]
            \endverbatim 
        */
        [When(@"I reset the acquisition count on the CSA")]
        public void ResetTheCSAScopeAcquisitionCount()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.RunCSAResetAcquisitionCount(scope);
        }
        #endregion ACQuire:DATA:CLEar

        #region ACQUIRE:STOPAfter:CONDition
        /// <summary>
        /// Sets the stop after condition state to ACQWfms for the CSA
        /// 
        /// ACQUIRE:STOPAfter:CONDition
        /// </summary>
        /*!
           \csa\verbatim
        [When(@"I set the stop after condition state to acquired waveforms for the CSA")]
           \endverbatim 
       */
        [When(@"I set the stop after condition state to acquired waveforms for the CSA")]
        public void SetTheCSAConditionStateToACQWfms()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.SetCSAAcquisitionStopAfterConditionState(scope, "ACQWfms");
        }

        /// <summary>
        /// Sets the stop after condition state to AVGComp for the CSA
        /// 
        /// ACQUIRE:STOPAfter:CONDition
        /// </summary>
        /*!
           \csa\verbatim
        [When(@"I set the stop after condition state to average comp for the CSA")]
           \endverbatim 
       */
        [When(@"I set the stop after condition state to average comp for the CSA")]
        public void SetTheCSAConditionStateToAVGComp()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.SetCSAAcquisitionStopAfterConditionState(scope, "AVGComp");
        }

        /// <summary>
        /// Sets the stop after condition state to FRAMecycle for the CSA
        /// 
        /// ACQUIRE:STOPAfter:CONDition
        /// </summary>
        /*!
           \csa\verbatim
        [When(@"I set the stop after condition state to frame cycle for the CSA")]
           \endverbatim 
       */
        [When(@"I set the stop after condition state to frame cycle for the CSA")]
        public void SetTheCSAConditionStateToFrameCycle()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.SetCSAAcquisitionStopAfterConditionState(scope, "FRAMecycle");
        }

        /// <summary>
        /// Sets the stop after condition state to HISTHits for the CSA
        /// 
        /// ACQUIRE:STOPAfter:CONDition
        /// </summary>
        /*!
           \csa\verbatim
        [When(@"I set the stop after condition state to histogram hits for the CSA")]
           \endverbatim 
       */
        [When(@"I set the stop after condition state to histogram hits for the CSA")]
        public void SetTheCSAConditionStateToHISTHits()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.SetCSAAcquisitionStopAfterConditionState(scope, "HISTHits");
        }

        /// <summary>
        /// Sets the stop after condition state to HISTWaveform for the CSA
        /// 
        /// ACQUIRE:STOPAfter:CONDition
        /// </summary>
        /*!
           \csa\verbatim
        [When(@"I set the stop after condition state to histogram waveform for the CSA")]
           \endverbatim 
       */
        [When(@"I set the stop after condition state to histogram waveform for the CSA")]
        public void SetTheCSAConditionStateToHISTWaveform()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.SetCSAAcquisitionStopAfterConditionState(scope, "HISTWaveform");
        }

        /// <summary>
        /// Sets the stop after condition state to MASKSample for the CSA
        /// 
        /// ACQUIRE:STOPAfter:CONDition
        /// </summary>
        /*!
           \csa\verbatim
        [When(@"I set the stop after condition state to mask sample for the CSA")]
           \endverbatim 
       */
        [When(@"I set the stop after condition state to mask sample for the CSA")]
        public void SetTheCSAConditionStateToMaskSample()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.SetCSAAcquisitionStopAfterConditionState(scope, "MASKSample");
        }

        /// <summary>
        /// Sets the stop after condition state to MASKTOTalhit for the CSA
        /// 
        /// ACQUIRE:STOPAfter:CONDition
        /// </summary>
        /*!
           \csa\verbatim
        [When(@"I set the stop after condition state to mask total hits for the CSA")]
           \endverbatim 
       */
        [When(@"I set the stop after condition state to mask total hits for the CSA")]
        public void SetTheCSAConditionStateToMaskTotalHit()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.SetCSAAcquisitionStopAfterConditionState(scope, "MASKTOTalhit");
        }

        /// <summary>
        /// Sets the stop after condition state to MASKWaveform for the CSA
        /// 
        /// ACQUIRE:STOPAfter:CONDition
        /// </summary>
        /*!
           \csa\verbatim
        [When(@"I set the stop after condition state to mask Waveforms for the CSA")]
           \endverbatim 
       */
        [When(@"I set the stop after condition state to mask waveforms for the CSA")]
        public void SetTheCSAConditionStateToMaskWaveform()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.SetCSAAcquisitionStopAfterConditionState(scope, "MASKWaveform");
        }
        #endregion ACQUIRE:STOPAfter:CONDition

        #region ACQuire:STOPAfter:COUNt
        /// <summary>
        /// Sets the number of mask hits or histogram hits needed before the CSA will stop
        /// 
        /// ACQuire:STOPAfter:COUNt
        /// </summary>
        /// <param name="count">Stop after count</param>
        /*!
          \csa\verbatim
        [When(@"I set the acquisition stop after count of ((?<!\S)[-+]?\d+(?!\S)) for the CSA")]
          \endverbatim 
        */
        [When(@"I set the acquisition stop after count of ((?<!\S)[-+]?\d+(?!\S)) for the CSA")]
        public void SetAcquisitionStopAfterCount(string count)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.SetCSAAcquisitionStopAfterCount(scope, count);
        }
        #endregion ACQuire:STOPAfter:COUNt

        #region ACQUIRE:STOPAfter:MODe
        /// <summary>
        /// Sets the Acquisition StopAfter mode to Condition on a CSA Scope
        /// 
        /// ACQUIRE:STOPAfter:MODe
        /// </summary>
        /*!
           \CSA\verbatim
        [When(@"I set the acquisition stop after mode to CONDition on the CSA")]
           \endverbatim 
        */
        [When(@"I set the acquisition stop after mode to CONDition on the CSA")]
        public void SetTheCSAAcquisitionStopAfterModeToCondition()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeAcquireGroup.SetCSAAcquisitionStopAfterMode(scope, "CONDition");
        }
        #endregion ACQUIRE:STOPAfter:MODe
        #endregion CSA Scope Only
    }
}
