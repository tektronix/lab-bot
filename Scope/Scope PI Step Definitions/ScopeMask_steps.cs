//==========================================================================
// ScopeMask__steps.cs
// This file contains the low-order PI step definitions for the Scope PI Mask Group commands. 
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
    /// This class contains the low-order PI step definitions for the Scope PI Mask Group commands.

    /// Low-level steps set and get the values for commands, and test the raw values as returned from the 
    /// instrument. They DO NOT interpret values in any way! Interpretation, normalization, etc. need to 
    /// occur in the High-level step definitions. Notice the use of the word "value" in the steps - this 
    /// usually implies that the query returns a 0 or 1 or abbreviated text value (like SOFT) that should 
    /// be interpreted as ON or OFF or SOFTWARE to make the step more user-friendly. We do that in the 
    /// High-order step definitions.
    /// 
    /// </summary> 
    [Binding] //Very important! This entry needs to be made in each step definition file.
    public class ScopeMaskSteps
    {
        private readonly ScopeMaskGroup _scopeMaskGroup = new ScopeMaskGroup();
        private readonly UtilitiesGroup _utilitiesGroup = new UtilitiesGroup();

        #region MASK:COUNt:HITS?
        /// <summary>
        /// Gets the total mask hit count from the DPO. 
        /// 
        /// MASK:COUNt:HITS?
        /// </summary>
        /*!
          \scope\verbatim
        [When(@"I get the total mask hit counts from the Scope")]
          \endverbatim 
        */
        [When(@"I get the total mask hit counts from the Scope")]
        public void GetTheScopeMaskTotalCount()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMaskGroup.GetDPOMaskHitCountTotal(scope);
        }

        /// <summary>
        /// Compares the mask hit count against the expected value on a DPO Scope. 
        /// 
        /// MASK:COUNt:HITS?
        /// </summary>
        /// <param name="expectedValue">Expected mask count</param>
        /*!
          \scope\verbatim
        [Then(@"the mask hit count should be less than or equal to ((?<!\S)[-+]?\d+(?!\S)) on the Scope")]
          \endverbatim 
        */
        [Then(@"the mask hit count should be less than or equal to ((?<!\S)[-+]?\d+(?!\S)) on the Scope")]
        public void TheScopeMaskHitCountShouldBeLessThan(string expectedValue)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMaskGroup.TheDPOMaskHitCountTotalShouldBeLessThanOrEqualTo(scope, expectedValue);
        }
        #endregion MASK:COUNt:HITS?

        #region MASK:COUNt:SEG[n]:HITS?
        /// <summary>
        /// Gets the mask hit count for a specified mask segment on a DPO Scope
        /// 
        /// MASK:COUNt:SEG[n]:HITS?
        /// </summary>
        /// <param name="maskSegment">Desired mask segment</param>
        /*!
          \scope\verbatim
        [When(@"I get the hit count of individual mask segment ([1-8]) from the Scope")]
          \endverbatim 
        */
        [When(@"I get the hit count of individual mask segment ([1-8]) from the Scope")]
        public void GetTheScopeMaskSegmentHitCount(int maskSegment)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMaskGroup.GetDPOMaskSegmentHitCount(scope, maskSegment);
        }
        #endregion MASK:COUNt:SEG[n]:HITS?
        
        #region MASK:COUNt RESET
        /// <summary>
        /// Resets the Scope mask count
        /// 
        /// (DPO|CSA)
        /// MASK:COUNt RESET
        /// </summary>
        /*!
            \Scope\verbatim
        [When(@"I reset the mask count on the Scope")]
          \endverbatim 
        */
        [When(@"I reset the mask count on the Scope")]
        public void ResetScopeMaskCount()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMaskGroup.RunScopeMaskCountReset(scope);
        }
        #endregion MASK:COUNt RESET

        #region MASK:DISplay
        /// <summary>
        /// Sets the mask display state to OFF for a DPO Scope
        /// Mask Counting, mask testing, and mask autoset are unavailable is the mask display is OFF
        /// Default setting is ON
        /// 
        /// MASK:DISplay OFF
        /// </summary>
        /*!
           \scope\verbatim
        [When(@"I set the mask display state to off for the Scope"))]
           \endverbatim 
        */
        [When(@"I set the mask display state to off for the Scope")]
        public void SetTheScopeMaskDisplayStateOff()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMaskGroup.SetDPOMaskDisplayState(scope, "OFF");
        }

        /// <summary>
        /// Sets the mask display state to ON for a DPO Scope
        /// Mask Counting, mask testing, and mask autoset are unavailable is the mask display is OFF
        /// Default setting is ON
        /// 
        /// MASK:DISplay ON
        /// </summary>
        /*!
           \scope\verbatim
        [When(@"I set the mask display state to on for the Scope"))]
           \endverbatim 
        */
        [When(@"I set the mask display state to on for the Scope")]
        public void SetTheScopeMaskDisplayStateOn()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMaskGroup.SetDPOMaskDisplayState(scope, "ON");
        }
        #endregion MASK:DISplay

        #region MASK:SOUrce CH[n]
        /// <summary>
        /// Sets the specified channel to be compared against the mask 
        /// 
        /// A lot of other options were left out of the command including setting the timebase since only the default was needed@n
        /// See 2-204 pg 216 for all the options
        /// 
        /// (DPO|CSA)
        /// MASK:SOUrce CH[n]
        /// </summary>
        /// <param name="channel">Which channel the mask will count</param>
        /*!
            \scope\verbatim
        [When(@"I set the mask source to channel ([1-4]) on the Scope")]
           \endverbatim 
        */
        [When(@"I set the mask source to channel ([1-4]) on the Scope")]
        public void SetTheScopeChannelMaskSource(string channel)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMaskGroup.SetScopeChannelMaskSource(scope, channel);
        }
        #endregion MASK:SOUrce CH[n]

        #region MASK:STANdard
        /// <summary>
        /// Deletes the existing mask and sets the selected standard mask on a DPO scope
        /// 
        /// MASK:STANdard
        /// </summary>
        /// <param name="maskStandard">Standard Mask to Apply</param>
        /*!
           \scope\verbatim
        [When(@"I set the mask standard to blah on the Scope"))]
           \endverbatim 
        */
        [When(@"I set the mask standard to blah on the Scope")]
        public void SetTheScopeMaskStandard(string maskStandard)
        {
            //Unused need to determine the regex to use for this due to all the standard types
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMaskGroup.SetDPOMaskStandard(scope, maskStandard);
        }
        #endregion MASK:STANdard

        #region MASK:TESt:STATE
        /// <summary>
        /// Sets the mask test state to OFF for a DPO Scope
        /// 
        /// MASK:TESt:STATE OFF
        /// </summary>
        /*!
           \scope\verbatim
        [When(@"I set the mask count state to off for the Scope"))]
           \endverbatim 
        */
        [When(@"I set the mask count state to off for the Scope")]
        public void SetTheScopeMaskCountStateOff()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMaskGroup.SetDPOMaskCountState(scope, "OFF");
        }

        /// <summary>
        /// Sets the mask test state to ON for a DPO Scope
        /// 
        /// MASK:TESt:STATE ON
        /// </summary>
        /*!
           \scope\verbatim
        [When(@"I set the mask count state to on for the Scope"))]
           \endverbatim 
        */
        [When(@"I set the mask count state to on for the Scope")]
        public void SetTheScopeMaskCountStateOn()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMaskGroup.SetDPOMaskCountState(scope, "ON");
        }
        #endregion MASK:TESt:STATE

        #region MASK:TESt:STATUS?
        /// <summary>
        /// Gets the mask test status for a DPO Scope. 
        /// 
        /// MASK:TESt:STATUS?
        /// </summary>
        /*!
          \scope\verbatim
        [When(@"I get the mask test status for the Scope")]
          \endverbatim 
        */
        [When(@"I get the mask test status for the Scope")]
        public void GetTheScopeMaskTestStatus()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMaskGroup.GetDPOMaskTestStatus(scope);
        }

        /// <summary>
        /// Compares the DPO mask test status against the expected status of OFF. 
        /// 
        /// MASK:TESt:STATUS?
        /// </summary>
        /*!
          \scope\verbatim
        [Then(@"the mask test status should say OFF on the Scope")]
          \endverbatim 
        */
        [Then(@"the mask test status should say OFF on the Scope")]
        public void TheScopeMaskTestStatusShouldBeOff()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMaskGroup.DPOMaskTestStatusShouldBe(scope, "OFF");
        }

        /// <summary>
        /// Compares the DPO mask test status against the expected status of DELAY. 
        /// 
        /// MASK:TESt:STATUS?
        /// </summary>
        /*!
          \scope\verbatim
        [Then(@"the mask test status should say DELAY on the Scope")]
          \endverbatim 
        */
        [Then(@"the mask test status should say DELAY on the Scope")]
        public void TheScopeMaskTestStatusShouldBeDelay()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMaskGroup.DPOMaskTestStatusShouldBe(scope, "DELAY");
        }

        /// <summary>
        /// Compares the DPO mask test status against the expected status of PASSING. 
        /// 
        /// MASK:TESt:STATUS?
        /// </summary>
        /*!
          \scope\verbatim
        [Then(@"the mask test status should say PASSING on the Scope")]
          \endverbatim 
        */
        [Then(@"the mask test status should say PASSING on the Scope")]
        public void TheScopeMaskTestStatusShouldBePassing()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMaskGroup.DPOMaskTestStatusShouldBe(scope, "PASSING");
        }

        /// <summary>
        /// Compares the DPO mask test status against the expected status of FAILING. 
        /// 
        /// MASK:TESt:STATUS?
        /// </summary>
        /*!
          \scope\verbatim
        [Then(@"the mask test status should say FAILING on the Scope")]
          \endverbatim 
        */
        [Then(@"the mask test status should say FAILING on the Scope")]
        public void TheScopeMaskTestStatusShouldBeFailing()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMaskGroup.DPOMaskTestStatusShouldBe(scope, "FAILING");
        }

        /// <summary>
        /// Compares the DPO mask test status against the expected status of PASSED. 
        /// 
        /// MASK:TESt:STATUS?
        /// </summary>
        /*!
          \scope\verbatim
        [Then(@"the mask test status should say PASSED on the Scope")]
          \endverbatim 
        */
        [Then(@"the mask test status should say PASSED on the Scope")]
        public void TheScopeMaskTestStatusShouldBePassed()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMaskGroup.DPOMaskTestStatusShouldBe(scope, "PASSED");
        }

        /// <summary>
        /// Compares the DPO mask test status against the expected status of FAILED. 
        /// 
        /// MASK:TESt:STATUS?
        /// </summary>
        /*!
          \scope\verbatim
        [Then(@"the mask test status should say FAILED on the Scope")]
          \endverbatim 
        */
        [Then(@"the mask test status should say FAILED on the Scope")]
        public void TheScopeMaskTestStatusShouldBeFailed()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMaskGroup.DPOMaskTestStatusShouldBe(scope, "FAILED");
        }
        #endregion MASK:TESt:STATUS?

        #region RECAll: MASK
        /// <summary>
        /// Loads the given mask file into the scope
        /// 
        /// (DPO|CSA)
        /// RECAll: MASK
        /// </summary>
        /// <param name="filepath">Filepath of the mask file</param>
        /*!
            \scope\verbatim
        [When(@"I recall the mask file ""(.+)"" on the Scope")]
            \endverbatim 
        */
        [When(@"I recall the mask file ""(.+)"" on the Scope")]
        public void RecallScopeMask(string filepath)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMaskGroup.RunScopeRecallMask(scope, filepath);
        }
        #endregion RECAll: MASK

        #region CSA Only
        #region MASK:COUNt:STATE
        /// <summary>
        /// Sets the mask count state to ON for a CSA Scope
        /// 
        /// MASK:COUNt:STATE ON
        /// </summary>
        /// <param name="state">Mask count state ON|OFF</param>
        /*!
           \CSA\verbatim
        [When(@"I set the mask count state to on for the CSA"))]
           \endverbatim 
        */
        [When(@"I set the mask count state to on for the CSA")]
        public void SetCSAMaskCountStateON()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMaskGroup.SetCSAMaskCountState(scope, "ON");
        }

        /// <summary>
        /// Sets the mask count state to OFF for a CSA Scope
        /// 
        /// MASK:COUNt:STATE
        /// </summary>
        /// <param name="state">Mask count state ON|OFF</param>
        /*!
           \CSA\verbatim
        [When(@"I set the mask count state to off for the CSA"))]
           \endverbatim 
        */
        [When(@"I set the mask count state to off for the CSA")]
        public void SetCSAMaskCountStateOFF()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMaskGroup.SetCSAMaskCountState(scope, "OFF");
        }
        #endregion MASK:COUNt:STATE

        #region MASK:COUNt:TOTal?
        /// <summary>
        /// Gets the mask count total from the CSA Scope. 
        /// 
        /// MASK:COUNt:TOTal?
        /// </summary>
        /*!
          \CSA\verbatim
        [When(@"I get the mask count total from the CSA")]
          \endverbatim 
        */
        [When(@"I get the mask count total from the CSA")]
        public void GetCSAMaskCountTotal()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMaskGroup.GetCSAMaskHitCountTotal(scope);
        }

        /// <summary>
        /// Compares the mask count against the expected value on a CSA Scope. 
        /// 
        /// MASK:COUNt:TOTal?
        /// </summary>
        /// <param name="expectedValue">Expected mask count</param>
        /*!
          \CSA\verbatim
        [Then(@"the mask count should be less than or equal to ((?<!\S)[-+]?\d+(?!\S)) from the CSA")]
          \endverbatim 
        */
        [Then(@"the mask count should be less than or equal to ((?<!\S)[-+]?\d+(?!\S)) from the CSA")]
        public void TheCSAMaskCountShouldBeLessThan(string expectedValue)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMaskGroup.TheCSAMaskHitCountTotalShouldBeLessThanOrEqualTo(scope, expectedValue);
        }
        #endregion MASK:COUNt:TOTal?

        #region MASK:MASK[n]:COUNt?
        /// <summary>
        /// Gets the mask hit count for the specified mask from the CSA scope
        /// 
        /// MASK:MASK[n]:COUNt?
        /// </summary>
        /// <param name="maskNumber">Desired mask</param>
        /*
           \CSA\verbatim
        [When(@"I get the individual mask ([1-8]) hit counts for (\d+\.?\d?\d?) seconds from the CSA")]
           \endverbatim 
        */
        [When(@"I get the individual mask ([1-8]) hit counts for (\d+\.?\d?\d?) seconds from the CSA")]
        public void GetCSAIndividualMaskCounts(int maskNumber, string seconds )
        {
            ISCOPE scope = SCOPE.GetScope(false);
            float time = float.Parse(seconds);
            _utilitiesGroup.WaitNSeconds(time);
            _scopeMaskGroup.GetCSAMaskHitCount(scope, maskNumber);
        }

        /// <summary>
        /// Gets the individual mask counts for all masks from the CSA scope
        /// 
        /// MASK:MASK[n]:COUNt?
        /// </summary>
        /*
           \CSA\verbatim
        [When(@"I get all of the individual mask hit counts for (\d+\.?\d?\d?) seconds from the CSA")]
           \endverbatim 
        */
        [When(@"I get all of the individual mask hit counts for (\d+\.?\d?\d?) seconds from the CSA")]
        public void GetCSAAllIndividualMaskCounts(string seconds)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            float time = float.Parse(seconds);
            _utilitiesGroup.WaitNSeconds(time);
            _scopeMaskGroup.GetCSAAllIndividualMaskHitCount(scope);
        }

        /// <summary>
        /// Verifies that the mask count values for two different masks are within a certainn percentage 
        /// tolerance of each other on a CSA scope
        /// 
        /// MASK:MASK[n]:COUNt?
        /// </summary>
        /// <param name="maskNum1">First mask number</param>
        /// <param name="maskNum2">Second mask number</param>
        /// <param name="percent">Maximum percent difference</param>
        /*
           \CSA\verbatim
        [Then(@"the mask ([1-8]) count and the mask ([1-8]) count should be within (\d+)% of each other for the CSA")]
           \endverbatim 
        */
        [Then(@"the mask ([1-8]) count and the mask ([1-8]) count should be within (\d+)% of each other for the CSA")]
        public void TheTwoCSAMasksAreWithinAPercentage(string maskNum1, string maskNum2, string percent)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMaskGroup.TheCSAMasksHitCountsShouldBeWithinaPercentageOfEachOther(scope, maskNum1, maskNum2, percent);
        }
        #endregion MASK:MASK[n]:COUNt?

        #region MASK:MASK[n] DELETE
        /// <summary>
        /// Deletes the number mask or a list of masks
        /// 
        /// MASK:MASK
        /// </summary>
        /// <param name="maskList">A single value or a comma separated list of masks to be deleted</param>
        /*
          \CSA\verbatim
        [When(@"I delete the mask numbers in the list ([1-8](?:\,[1-8])*) from the CSA")
          \endverbatim 
        */
        [When(@"I delete the mask numbers in the list ([1-8](?:\,[1-8])*) from the CSA")]
        public void DeleteCSAMaskNumbersFromaList(string maskList)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            if (maskList.Length == 1)
            {
                _scopeMaskGroup.SetCSAMaskDelete(scope, maskList);
            }
            else
            {
                string[] maskNumbers = maskList.Split(',');
                foreach (var maskNumber in maskNumbers)
                {
                    _scopeMaskGroup.SetCSAMaskDelete(scope, maskNumber);
                    _utilitiesGroup.WaitNSeconds(1);
                }
            }
        }
        #endregion MASK:MASK[n] DELETE

        #region MASK:MASK[n]:POINTSPcnt
        /// <summary>
        /// Sets the mask vertices for a given mask by percentage
        /// 
        /// MASK:MASK[n]:POINTSPcnt
        /// </summary>
        /// <param name="maskNum">Desired mask number</param>
        /// <param name="points">List of points</param>
        /*!
         \CSA\verbatim
        [When(@"I set the points for mask ([1-8]) at ((?:(?:1[0-9][0-9]|[0-9]{1,2})(?:\.[0-9]{1,4})?),(?:(?:1[0-9][0-9]|[0-9]{1,2})(?:\.[0-9]{1,4})?)(?:,(?:(?:1[0-9][0-9]|[0-9]{1,2})(?:\.[0-9]{1,4})?){0,48})) on the CSA")]
         \endverbatim 
        */
        [When(@"I set the points for mask ([1-8]) at ((?:(?:1[0-9][0-9]|[0-9]{1,2})(?:\.[0-9]{1,4})?),(?:(?:1[0-9][0-9]|[0-9]{1,2})(?:\.[0-9]{1,4})?)(?:,(?:(?:1[0-9][0-9]|[0-9]{1,2})(?:\.[0-9]{1,4})?){0,48})) on the CSA")]
        public void SetCSAMaskPoints(string maskNum, string points)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMaskGroup.SetCSAMaskPoint(scope, maskNum, points);
        }
        #endregion MASK:MASK[n]:POINTSPcnt
        #endregion CSA only
    }
}
