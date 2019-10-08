//==========================================================================
// AwgDiagnosticsGroupLow_steps.cs
// This file contains the low-order PI step definitions for the AWG PI Diagnostics Group commands. 
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
// AWG number -  AWG([1-4])? -OR -
//            -  (?: the)? AWG([1-4])? (depends on language usage)
// File path strings - ""(.+)"" used when you want the string that is delimited by the quotes File path strings
//                     \""(.+)\"" used when you want the string that is delimited by the quotes 
//==========================================================================

using TechTalk.SpecFlow;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains the PI step definitions for the %AWG PI Event Group commands.

    /// Generally the steps are set, get and should be operations.  The step sole responsibility
    /// is to make sure the correct %AWG object is used and that parameters such as channel,
    /// markers and clock references are correct for the %AWG object.
    /// 
    /// \ingroup pisteps
    /// 
    /// </summary>
    [Binding] //Very important! This entry needs to be made in each step definition file.     
    public class AwgDiagnosticsSteps
    {
        readonly AwgDiagnosticGroup _awgDiagnosticGroup = new AwgDiagnosticGroup();

        #region DIAGnostic:COMMent

        //PHunter 9/28/2012
        //glennj 3/10/2014
        /// <summary>
        /// Sends a string to the PI you can read in the CallMonitor log.
        /// The purpose of this was to embedded in the monitor log tags/comments
        /// that would help when trying to decipher the log contents.  Sometimes
        /// it is a challenge to know when a test starts and ends.
        /// 
        /// DIAGnostic:COMMent -Sends a string to the PI you can read in the CallMonitor log 
        /// for the default AWG.
        /// </summary>
        /// <param name="comment">The string you want embedded in the CallMonitor log</param>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostics \verbatim 
        [When(@"I send ""(.*)"" to the CallMonitor log for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I send ""(.*)"" to the CallMonitor log for AWG ([1-4])")]
        public void SendToCallMonitorOnTheAwg(string comment, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.SendToCallMonitorOnTheAwg(awg, comment);
        }
        
        ////glennj 10/30/2012
        /////  <summary>
        /////  Sends a string to the PI you can read in the CallMonitor log
        ///// 
        /////  DIAGnostic:COMMent -Sends a string to the PI you can read in the CallMonitor log 
        /////  for a specified AWG.
        /////  </summary>
        /////  <param name="comment">The string you want to read in the CallMonitor log</param>
        ///// <param name="awgNumber"></param>
        ///*!
        //    \diagnostics \verbatim 
        //[When(@"I send ""(.*)"" to the CallMonitor log on the AWG([1-4])")]
        //    \endverbatim
        //*/
        //[When(@"I send ""(.*)"" to the CallMonitor log on the AWG([1-4])")]
        //public void SendToCallMonitorOnTheAwg(string comment, string awgNumber)
        //{
        //    IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
        //    _awgDiagnosticsGroup.SendToCallMonitorOnTheAwg(awg, comment);
        //}

        #endregion DIAGnostic:COMMent

        #region DIAGnostic:DIMSec

        //glennj 10/7/2013
        // Non-published command that uses the AWG itself for a pause in mSec
        // Does a query with parameter in milliseconds which sleeps and returns nothing.
        [When(@"I pause (\d+) milliseconds using AWG ([1-4])")]
        public void WaitNSecondsUsingAWG(string delayInMSec, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagDelayInMSec(awg, delayInMSec);
        }

        #endregion DIAGnostic:DIMSec

        #region DIAGnostic:FORCe:FAILure 
        #endregion DIAGnostic:FORCe:FAILure

        #region DIAGnostic:SAResults
        #endregion DIAGnostic:SAResults

        #region DIAGnostic:MMODe

        // Unkown 01/01/01
        /// <summary>
        /// Verifies the AWG is in the "\TekCal" or manufacturing, mode
        /// 
        /// </summary>
        /*!
            \AWGSetup\verbatim
        [Given(@"the mode is manufacturing for AWG ([1-4])")]
            \endverbatim 
        */
        [Given(@"the mode is manufacturing for AWG ([1-4])")]
        public void PerferredAWGIsInManufacturingMode(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.AWGIsInManufacturingMode(awg, true);
        }

        // Unkown 01/01/01
        /// <summary>
        /// Verifies the AWG is not in the "\TekCal" or manufacturing, mode
        /// 
        /// </summary>
        /*!
            \AWGSetup\verbatim
        [Given(@"the mode is not manufacturing for AWG ([1-4])")]
            \endverbatim 
        */
        [Given(@"the mode is not manufacturing for AWG ([1-4])")]
        public void PreferredTheAWGIsNotInManufacturingMode(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.AWGIsInManufacturingMode(awg, false);
        }

    #endregion DIAGnostic:MMODe

        #region ACTive:MODE

        //glennj 3/11/2014
        ///  <summary>
        ///  Sets the active mode to normal for a specific AWG
        /// 
        ///  ACT:MODE <value></value>
        ///  </summary>
        /// <param name="awgNumber"></param>
        /*!
          \diagnostics \verbatim 
        [When(@"I set the active mode to normal for AWG ([1-4])")]
          \endverbatim
         */
        [When(@"I set the active mode to normal for AWG ([1-4])")]
        public void SetTheActiveModeToNormalForAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.SetTheActiveMode(awg, AwgDiagnosticGroup.ActiveModeAs.Normal);
        }

        //glennj 3/11/2014
        ///  <summary>
        ///  Sets the active mode to calibration for a specific AWG
        /// 
        ///  ACT:MODE <value></value>
        ///  </summary>
        /// <param name="awgNumber"></param>
        /*!
          \diagnostics \verbatim 
        [When(@"I set the active mode to calibration for AWG ([1-4])")]
          \endverbatim
         */
        [When(@"I set the active mode to calibration for AWG ([1-4])")]
        public void SetTheActiveModeToCalibrationForAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.SetTheActiveMode(awg, AwgDiagnosticGroup.ActiveModeAs.Calibration);
        }

        //glennj 3/11/2014
        ///  <summary>
        ///  Sets the active mode to diagnostics for a specific AWG
        /// 
        ///  ACT:MODE <value></value>
        ///  </summary>
        /// <param name="awgNumber"></param>
        /*!
          \diagnostics \verbatim 
        [When(@"I set the active mode to diagnostics for AWG ([1-4])")]
          \endverbatim
         */
        [When(@"I set the active mode to diagnostics for AWG ([1-4])")]
        public void SetTheActiveModeToDiagnosticsForAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.SetTheActiveMode(awg, AwgDiagnosticGroup.ActiveModeAs.Diagnostic);
        }

        //glennj 3/11/2014
        /// <summary>
        /// Gets the active mode to diag, cal, or norm.
        ///
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \diagnostics \verbatim 
        [When(@"I get the active mode for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I get the active mode for AWG ([1-4])")]
        public void WhenIGetTheActiveModeOfAWG1(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.GetAWGActiveMode(awg);
        }

        //glennj 3/11/2014
        ///  <summary>
        ///  Tests the active mode to be set to normal for a specific AWG
        /// 
        ///  ACT:MODE
        ///  </summary>
        /// <param name="awgNumber"></param>
        /*!
          \diagnostics \verbatim 
        [Then(@"the active mode should be normal for AWG ([1-4])")]
          \endverbatim
        */
        [Then(@"the active mode should be normal for AWG ([1-4])")]
        public void ActiveModeShouldBeNormalForAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.ActiveModeShouldBe(awg, AwgDiagnosticGroup.ActiveModeAs.Normal);
        }

        //glennj 3/11/2014
        ///  <summary>
        ///  Tests the active mode to be set to calibration for a specific AWG
        /// 
        ///  ACT:MODE
        ///  </summary>
        /// <param name="awgNumber"></param>
        /*!
          \diagnostics \verbatim 
        [Then(@"the active mode should be calibration for AWG ([1-4])")]
          \endverbatim
        */
        [Then(@"the active mode should be calibration for AWG ([1-4])")]
        public void ActiveModeShouldBeCalibrationForAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.ActiveModeShouldBe(awg, AwgDiagnosticGroup.ActiveModeAs.Calibration);
        }

        //glennj 3/11/2014
        ///  <summary>
        ///  Tests the active mode to be set to diagnostics for a specific AWG
        /// 
        ///  ACT:MODE
        ///  </summary>
        /// <param name="awgNumber"></param>
        /*!
          \diagnostics \verbatim 
        [Then(@"the active mode should be diagnostics for AWG ([1-4])")]
          \endverbatim
        */
        [Then(@"the active mode should be diagnostics for AWG ([1-4])")]
        public void ActiveModeShouldBeDiagnosticsForAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.ActiveModeShouldBe(awg, AwgDiagnosticGroup.ActiveModeAs.Diagnostic);
        }

        //glennj 3/11/2014
        ///  <summary>
        ///  Tests the active mode to be set to reset for a specific AWG
        /// 
        ///  ACT:MODE
        ///  </summary>
        /// <param name="awgNumber"></param>
        /*!
          \diagnostics \verbatim 
        [Then(@"the active mode should be reset for AWG ([1-4])")]
          \endverbatim
        */
        [Then(@"the active mode should be reset for AWG ([1-4])")]
        public void ActiveModeShouldBeResetForAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.ActiveModeShouldBe(awg, AwgDiagnosticGroup.ActiveModeAs.Reset);
        }

        #endregion ACTive:MODE

        #region *TST

        //glennj 3/11/2014
        /// <summary>
        /// Using the required SCPI "*TST?", run the POST (Power On Self Tests) and save results for a specified AWG
        ///
        /// *TST? (query only)
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \calibration\verbatim
        [When(@"I send the SCPI \*TST\? query and wait for results for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I send the SCPI \*TST\? query and wait for results for AWG ([1-4])")]
        public void WhenIThePowerOnSelfTestAndGetTheResults(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.RunScpiTstQueryAndSaveResults(awg);
        }

        //glennj 3/11/2014
        /// <summary>
        /// Verifies a valid *TST? result has been returned for a specified AWG
        ///
        /// *TST? (query only)
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \diagnostics\verbatim
        [Then(@"the SCPI \*TST\? results should be either pass or fail for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the SCPI \*TST\? results should be either pass or fail for AWG ([1-4])")]
        public void ThenThePostResultsShouldBeEitherPassOrFail(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.PostResultsShouldBeEitherPassOrFail(awg);
        }

        #endregion *TST

        #region DIAGnostic:ABORt

        //glennj 3/11/2014
        /// <summary>
        /// Aborts Diagnostics
        ///
        /// DIAG:ABORt
        /// Deprecated, use
        /// [When(@"I abort AWG([1-4]) diagnostics")]
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \diagnostics \verbatim 
        [When(@"I abort the diagnostics for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I abort the diagnostics for AWG ([1-4])")]
        public void AbortDiagnostics(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.AbortDiagnosticsOnAnAwg(awg);
        }

        #endregion DIAGnostic:ABORt

        #region DIAGnostic:CATalog

        //glennj 9/11/2013
        /// <summary>
        /// Gets a list of the available diagnostic subsystems
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
          \diagnostics \verbatim 
        [When(@"I get the diagnostic list of subsystems on AWG ([1-4])")]
          \endverbatim
        */
        [When(@"I get the list of diagnostic subsystems for AWG ([1-4])")]
        public void GetTheDiagnosticListOfSubsystems(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.GetDiagSubsystemsList(awg);                                // Sets DiagnosticCatalogOfSubsystems
        }

        //glennj 9/11/2013
        /// <summary>
        /// Gets a list of the available diagnostic subsystems
        /// </summary>
        /// <param name="subsystemName"></param>
        /// <param name="awgNumber"></param>
        /*!
          \diagnostics \verbatim 
        [When(@"I get the list of diagnostic areas for subsystem ""(.+)"" for AWG ([1-4])")]
          \endverbatim
        */
        [When(@"I get the list of diagnostic areas for subsystem ""(.+)"" for AWG ([1-4])")]
        public void GetTheDiagnosticListOfAreas(string subsystemName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.GetDiagnosticCatalogList(awg, subsystemName);              // Sets DiagnosticCatalogOfAreas
        }
        
        //glennj 9/11/2013
        /// <summary>
        /// Gets a list of the available diagnostic subsystems
        /// </summary>
        /// <param name="areaName"></param>
        /// <param name="subsystemName"></param>
        /// <param name="awgNumber"></param>
        /*!
          \diagnostics \verbatim 
        [When(@"I get the list of diagnostic tests for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
          \endverbatim
        */
        [When(@"I get the list of diagnostic tests for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
        public void GetTheDiagnosticListOfTests(string areaName, string subsystemName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.GetDiagnosticCatalogList(awg, subsystemName, areaName);    // DiagnosticCatalogOfTests
        }

        //glennj 9/11/2013
        /// <summary>
        /// Once a list of subsystems has been acquired, select by index, starting at 1,<para>
        /// a subsystem to be the "selected" or as context for other actions.</para>
        /// </summary>
        /// <param name="subsystemIndex"></param>
        /// <param name="awgNumber"></param>
        /*!
          \diagnostics \verbatim 
        [When(@"I set the subsystem context using the index of (\d+) from the list of diagnostic subsystems for AWG ([1-4])")]
          \endverbatim
        */
        [When(@"I set the subsystem context using the index of (\d+) from the list of diagnostic subsystems for AWG ([1-4])")]
        public void SelectTheSubsystemFromDiagSubsystemList(string subsystemIndex, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.SelectDiagnosticSubsystemFromListUsingIndex(awg, subsystemIndex);
        }

        //glennj 9/11/2013
        /// <summary>
        /// Once a context of a selected subsystem has been established, get a list of areas<para>
        /// for that subsystem.</para>
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
          \diagnostics \verbatim 
        [When(@"I get the list of diagnostic areas based on the subsystem context for AWG ([1-4])")]
          \endverbatim
        */
        [When(@"I get the list of diagnostic areas based on the subsystem context for AWG ([1-4])")]
        public void GetTheDiagnosticListOfAreas(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.GetDiagAreaList(awg);
        }

        //glennj 9/11/2013
        /// <summary>
        /// Once a list of areas has been acquired, select by index, starting at 1,<para>
        /// an area to be the "selected" or context of other actions.</para>
        /// </summary>
        /// <param name="areaIndex"></param>
        /// <param name="awgNumber"></param>
        /*!
          \diagnostics \verbatim 
        [When(@"I set the area context using the index of (\d+) from the list of diagnostic areas for AWG ([1-4])")]
          \endverbatim
        */
        [When(@"I set the area context using the index of (\d+) from the list of diagnostic areas for AWG ([1-4])")]
        public void SelectTheAreaFromDiagAreaList(string areaIndex, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.SelectDiagnosticAreaFromListUsingIndex(awg, areaIndex);
        }

        //glennj 9/11/2013
        /// <summary>
        /// Once a context of a selected area has been established, get a list of tests<para>
        /// for that area.</para>
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
          \diagnostics \verbatim 
        [When(@"I get the list of diagnostic tests based on the area context for AWG ([1-4])")]
          \endverbatim
        */
        [When(@"I get the list of diagnostic tests based on the area context for AWG ([1-4])")]
        public void GetTheDiagnosticListOfTests(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.GetDiagTestList(awg);
        }

        //glennj 9/11/2013
        /// <summary>
        /// Once a list of tests has been acquired, select by index, starting at 1,<para>
        /// a test to be the "selected" or context of other actions.</para>
        /// </summary>
        /// <param name="testIndex"></param>
        /// <param name="awgNumber"></param>
        /*!
          \diagnostics \verbatim 
        [When(@"I set the test context using the index of (\d+) from the list of diagnostic tests for AWG ([1-4])")]
          \endverbatim
        */
        [When(@"I set the test context using the index of (\d+) from the list of diagnostic tests for AWG ([1-4])")]
        public void SelectTheTestFromDiagTestList(string testIndex, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.SelectDiagnosticTestFromListUsingIndex(awg, testIndex);
        }

        //glennj 9/11/2013
        /// <summary>
        /// Based on the created test path based on the selected subsystem, area and test<para>
        /// selected one or more tests</para>
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
          \diagnostics \verbatim 
        [When(@"I select the test based on the selected contexts for AWG ([1-4])")]
          \endverbatim
        */
        [When(@"I select the test based on the selected contexts for AWG ([1-4])")]
        public void SelectTheDiagnosticUsingTheTestPath(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.UsingPresetContextSelectTest(awg);
        }

        #endregion DIAGnostic:CATalog

        #region DIAGnostic:CONTrol:COUNt

        //glennj 2/28/2014
        /// <summary>
        /// Sets the diagnostic loop count to the specified value.
        ///
        /// DIAGnostic:CONTrol:COUNt[?]
        /// </summary>
        /// <param name="setCount">Value that you want the loop count set to</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \diagnostic \verbatim 
        [When(@"I set the diagnostic loop count to (\d+) for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I set the diagnostic loop count to (\d+) for AWG ([1-4])")]
        public void WhenISetTheDiagnosticLoopCountTo(string setCount, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.SetDiagnosticLoopCount(awg, AwgDiagnosticGroup.DiagnosticLoopCountTypeAs.Nr1, setCount);
        }

        //glennj 2/28/2014
        /// <summary>
        /// Sets the diagnostic loop count to the max!
        ///
        /// DIAGnostic:CONTrol:COUNt[?]
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \diagnostic \verbatim 
        [When(@"I set the diagnostic loop count to maximum for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I set the diagnostic loop count to maximum for AWG ([1-4])")]
        public void WhenISetTheDiagnosticLoopCountToMax(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.SetDiagnosticLoopCount(awg, AwgDiagnosticGroup.DiagnosticLoopCountTypeAs.Max);
        }

        //glennj 2/28/2014
        /// <summary>
        /// Sets the diagnostic loop count to the min!
        ///
        /// DIAGnostic:CONTrol:COUNt[?]
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \diagnostic \verbatim 
        [When(@"I set the diagnostic loop count to minimum for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I set the diagnostic loop count to minimum for AWG ([1-4])")]
        public void WhenISetTheDiagnosticLoopCountToMin(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.SetDiagnosticLoopCount(awg, AwgDiagnosticGroup.DiagnosticLoopCountTypeAs.Min);
        }

        //zkoppert 7/12/12
        /// <summary>
        /// Gets the diagnostic loop count value.
        ///
        /// DIAGnostic:CONTrol:COUNt[?]
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \diagnostic \verbatim 
        [When(@"I get the diagnostic loop count for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I get the diagnostic loop count for AWG ([1-4])")]
        public void WhenIGetTheDiagnosticLoopCountValue(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.GetDiagnosticLoopCount(awg);
        }

        //zkoppert 7/12/12
        /// <summary>
        /// Check the diagnostic loop count value.
        ///
        /// CAL:CONT:COUN[?]
        /// </summary>
        /// <param name="expectedCount">Value expected for loop count</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \diagnostic \verbatim 
        [Then(@"the diagnostic loop count should be (\d+) for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the diagnostic loop count should be (\d+) for AWG ([1-4])")]
        public void ThenTheDiagnosticLoopCountValueShouldBe(string expectedCount, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagnosticLoopCountShouldBe_(awg, expectedCount);
        }

        #endregion DIAGnostic:CONTrol:COUNt

        #region DIAGnostic:CONTrol:HALT

        //glennj 06/05/2013
        ///  <summary>
        ///  Sets the diagnostic halt value to on.
        ///  
        ///  This can only be set in manufacturing mode.
        /// 
        ///  CAL:CONT:HALT[?]
        ///  </summary>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostic \verbatim 
        [When(@"I set the diagnostic halt control to on for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I set the diagnostic halt control to on for AWG ([1-4])")]
        public void SetTheDiagnosticHaltToOn(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.SetDiagnosticHalt(awg, AwgDiagnosticGroup.DiagnosticControlHaltMode.On);
        }

        //glennj 06/05/2013
        ///  <summary>
        ///  Sets the diagnostic halt value to off.
        /// 
        ///  CAL:CONT:HALT[?]
        ///  </summary>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostic \verbatim 
        [When(@"I set the diagnostic halt control to off for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I set the diagnostic halt control to off for AWG ([1-4])")]
        public void SetTheDiagnosticHaltToOff(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.SetDiagnosticHalt(awg, AwgDiagnosticGroup.DiagnosticControlHaltMode.Off);
        }

        //zkoppert 7/12/12
        /// <summary>
        /// Gets the diagnostic halt value.
        ///
        /// CAL:CONT:HALT[?]
        /// </summary>
        /*!
            \diagnostic \verbatim 
        [When(@"I get the diagnostic halt control for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I get the diagnostic halt control for AWG ([1-4])")]
        public void WhenIGetTheDiagnosticHaltValue(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.GetDiagnosticHaltUpdate(awg);
        }

        //glennj 2/28/2014
        ///  <summary>
        ///  Tests the diagnostic halt mode to be on
        /// 
        ///  CAL:CONT:HALT[?]
        ///  </summary>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostic \verbatim 
        [Then(@"the diagnostic halt control should be on for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the diagnostic halt control should be on for AWG ([1-4])")]
        public void DiagnosticHaltValueShouldBeOn(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagnosticHaltModeShouldBe(awg, AwgDiagnosticGroup.DiagnosticControlHaltMode.On);
        }

        //glennj 2/28/2014
        ///  <summary>
        ///  Tests the diagnostic halt mode to be off
        /// 
        ///  CAL:CONT:HALT[?]
        ///  </summary>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostic \verbatim 
        [Then(@"the diagnostic halt control should be off for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the diagnostic halt control should be off for AWG ([1-4])")]
        public void DiagnosticHaltValueShouldBeOff(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagnosticHaltModeShouldBe(awg, AwgDiagnosticGroup.DiagnosticControlHaltMode.Off);
        }


        #endregion DIAGnostic:CONTrol:HALT

        #region DIAGnostic:CONTrol:LOOP

        //glennj 2/10/2014
        ///  <summary>
        ///  Sets the diagnostic looping mode to loop once
        /// 
        ///  DIAGnostic:CONTrol:LOOP
        ///  </summary>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostic \verbatim 
        [When(@"I set the diagnostic loop control to loop once for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I set the diagnostic loop control to loop once for AWG ([1-4])")]
        public void SetTheDiagnosticLoopControlToLoopOnce(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.SetDiagnosticLoopControl(awg, AwgDiagnosticGroup.DiagnosticControlLoopMode.Once);
        }

        //glennj 2/10/2014
        ///  <summary>
        ///  Sets the diagnostic looping mode to loop continuously
        /// 
        ///  DIAGnostic:CONTrol:LOOP
        ///  </summary>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostic \verbatim 
        [When(@"I set the diagnostic loop control to loop continuous for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I set the diagnostic loop control to loop continuous for AWG ([1-4])")]
        public void SetTheDiagnosticLoopControlToLoopContnuous(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.SetDiagnosticLoopControl(awg, AwgDiagnosticGroup.DiagnosticControlLoopMode.Continuous);
        }

        //glennj 2/10/2014
        ///  <summary>
        ///  Sets the diagnostic looping mode to loop for a number of counts
        /// 
        ///  DIAGnostic:CONTrol:LOOP
        ///  </summary>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostic \verbatim 
        [When(@"I set the diagnostic loop control to loop for counts for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I set the diagnostic loop control to loop for counts for AWG ([1-4])")]
        public void SetTheDiagnosticLoopControlToLoopCount(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.SetDiagnosticLoopControl(awg, AwgDiagnosticGroup.DiagnosticControlLoopMode.Count);
        }

        //glennj 2/10/2014
        /// <summary>
        /// Gets the diagnostic loop value.
        ///
        /// DIAGnostic:CONTrol:LOOP?
        /// </summary>
        /*!
            \diagnostic \verbatim 
        [When(@"I get the diagnostic loop control for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I get the diagnostic loop control for AWG ([1-4])")]
        public void WhenIGetTheCurrentDiagnosticLoopSetting(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.UpdateDiagnosticControlLoopCopy(awg);
        }

        //glennj 2/28/2014
        ///  <summary>
        ///  Tests the diagnostic loop mode to be loop once
        /// 
        ///  DIAGnostic:CONTrol:LOOP
        ///  </summary>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostic \verbatim 
        [Then(@"the diagnostic loop control should be loop once for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the diagnostic loop control should be loop once for AWG ([1-4])")]
        public void CurrentDiagnosticLoopSettingShouldBeOnce(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagnosticLoopControlShouldBe(awg, AwgDiagnosticGroup.DiagnosticControlLoopMode.Once);
        }

        //glennj 2/28/2014
        ///  <summary>
        ///  Tests the diagnostic loop mode to be loop continuous
        /// 
        ///  DIAGnostic:CONTrol:LOOP
        ///  </summary>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostic \verbatim 
        [Then(@"the diagnostic loop control should be loop continuous for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the diagnostic loop control should be loop continuous for AWG ([1-4])")]
        public void CurrentDiagnosticLoopSettingShouldBeContinuous(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagnosticLoopControlShouldBe(awg, AwgDiagnosticGroup.DiagnosticControlLoopMode.Continuous);
        }

        //glennj 2/28/2014
        ///  <summary>
        ///  Tests the diagnostic loop mode to be loop for counts
        /// 
        ///  DIAGnostic:CONTrol:LOOP
        ///  </summary>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostic \verbatim 
        [Then(@"the diagnostic loop control should be loop for counts for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the diagnostic loop control should be loop for counts for AWG ([1-4])")]
        public void CurrentDiagnosticLoopSettingShouldBeCount(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagnosticLoopControlShouldBe(awg, AwgDiagnosticGroup.DiagnosticControlLoopMode.Count);
        }

        #endregion DIAGnostic:CONTrol:LOOP

        #region DIAGnostic:DATA

        //glennj 3/13/2014
        /// <summary>
        /// Gets results of last executed diagnostic test of the specified AWG
        /// 
        /// DIAG:DATA?
        /// </summary>
        /*!
        \diagnostics \verbatim 
        [When(@"I get the diagnostic data for AWG ([1-4])")]
        \endverbatim
       */
        [When(@"I get the diagnostic data for AWG ([1-4])")]
        public void WhenIGetTheAWGDiagnosticsData(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.GetTheAWGDiagnosticsData(awg);
        }

        //glennj 3/13/2014
        /// <summary>
        /// Compares the results of last executed diagnostic test against 1 of 2 expected values.
        /// 
        /// DIAG:DATA
        /// </summary>
        /*!
        \diagnostics \verbatim 
        [Then(@"the diagnostic data should be valid for AWG ([1-4])")]
        \endverbatim
        */
        [Then(@"the diagnostic data should be valid for AWG ([1-4])")]
        public void ThenTheAWGDiagnosticsDataShouldBeValid(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.AWGDiagnosticsDataShouldBeValid(awg);
        }

        #endregion DIAGnostic:DATA

        #region DIAGnostic[:IMMediate]

        // Unknown 01/01/01
        /// <summary>
        /// Executes all of the NORMal diagnostic tests.
        /// This is a blocking command.
        /// Hint.  Execute an *OPC? with at least 5 minutes.
        /// 
        /// DIAGnostic:IMMediate
        /// </summary>
        /*!
        \diagnostics \verbatim 
        [When(@"I execute the Diagnostic Immediate command for AWG ([1-4])")]
        \endverbatim
        */
        [When(@"I execute the Diagnostic Immediate command for AWG ([1-4])")]
        public void ExecuteImmediateDiagnostics(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.ExecuteImmediateDiagnostics(awg);
        }

        // Unknown 01/01/01
        /// <summary>
        /// Executes the selected tests and returns the results in the form of a numeric of values of 0 
        /// for no errors or  -330 for one or more tests failed.@n
        /// 
        /// DIAGnostic:IMMediate?
        /// </summary>
        /*!
            \diagnostics \verbatim 
        [When(@"I execute the Diagnostic Immediate query and wait for the result for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I execute the Diagnostic Immediate query and wait for the result for AWG ([1-4])")]
        public void ExecuteImmediateDiagnosticsAndGetResult(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.ExecuteImmediateDiagnosticsAndGetResult(awg);
        }

        // Unknown 01/01/01
        /// <summary>
        /// Validates the returned value from diagnostic immediate query command. 
        /// 
        /// DIAGnostic:IMMediate?
        /// </summary>
        /*!
            \diagnostics \verbatim 
        [Then(@"the Diagnostic Immediate result should be valid for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the Diagnostic Immediate result should be valid for AWG ([1-4])")]
        public void ThenTheAWGImmediateDiagnosticsShouldBeValid(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.AWGImmediateDiagnosticsShouldBeValid(awg);
        }

        #endregion DIAGnostic:[:IMMediate]

        #region DIAGnostic:LOG?

        //[When(@"I get the AWG diagnostics log")]
        //[When(@"I get the diagnostics log from AWG([1-4])")]
        //[When(@"I get AWG([1-4]) diagnostics log")]
        //[Then(@"the AWG diagnostic log result value should be empty")]
        //[Then(@"AWG([1-4]) diagnostic log result value should be empty")]
        //[Then(@"the diag log result value should not be empty on the AWG")]
        //[Then(@"the AWG diagnostic log should not be empty")]
        //[Then(@"the diag log result value should not be empty on AWG([1-4])")]
        //[Then(@"the AWG([1-4]) diagnostic log should not be empty")]

        //glennj 10/29/2012
        /// <summary>
        /// Gets the diagnostic log from a specified AWG
        ///
        /// DIAGnostic:LOG?
        /// </summary>
        /*!
            \diagnostics \verbatim 
        [When(@"I get the diagnostic log for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I get the diagnostic log for AWG ([1-4])")]
        public void WhenIGetTheAWGDiagnosticsLog(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.GetTheDiagnosticsLogFromAWG(awg);
        }

        //glennj 10/29/2012
        /// <summary>
        ///Checks that default AWG diagnostic log is empty.
        ///
        /// DIAGnostic:LOG?
        /// </summary>
        /*!
          \diagnostics \verbatim 
        [Then(@"the diagnostic log should be empty for AWG ([1-4])")]
          \endverbatim
        */
        [Then(@"the diagnostic log should be empty for AWG ([1-4])")]
        public void ThenTheAWGDiagLogResultValueShouldBeEmpty(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagnosticLogShouldBeEmpty(awg, true);
        }

        //glennj 10/29/2012
        /// <summary>
        /// Checks that the default AWG diagnostic log is not empty.
        ///
        /// DIAGnostic:LOG?
        /// </summary>  
        /*!
            \diagnostics \verbatim 
        [Then(@"the diagnostic log should not be empty for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the diagnostic log should not be empty for AWG ([1-4])")]
        public void ThenTheDiagLogResultValueShouldNotBeEmptyOnTheAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagnosticLogShouldBeEmpty(awg, false);
        }

        #endregion DIAGnostic:LOG?

        #region DIAGnostic:LOG:CLEar

        //[When(@"I clear and get the AWG diagnostics log")]
        //[When(@"I clear and get AWG([1-4]) diagnostics log")]
        //[When(@"I clear the AWG diagnostics log")]
        //[When(@"I clear AWG([1-4]) diagnostics log")]

        //glennj 3/17/2014
        /// <summary>
        /// Clears a specificed AWG diagnostic log
        /// 
        /// DIAG:LOG:CLEar
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \diagnostics \verbatim 
        [When(@"I clear the diagnostic log for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I clear the diagnostic log for AWG ([1-4])")]
        public void WhenIClearTheAWGDiagnosticsLog(string awgNumber)
        {

            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.ClearTheAWGDiagnosticsLog(awg);
        }

        #endregion DIAGnostic:LOG:CLEar

        #region DIAGnostic:LOG:DETails

        //old wording
        //[When(@"I set the AWG diagnostics log detail state to (ON|OFF|1|0)")]
        //[When(@"I set AWG([1-4]) diagnostics log detail state to (ON|OFF|1|0)")]
        //[Then(@"the AWG diagnostics log detail state should be (1|0)")]
        //[Then(@"AWG([1-4]) diagnostics log detail state should be (1|0)")]
        //[When(@"I get the AWG diagnostics log detail state")]
        //[When(@"I get AWG([1-4]) diagnostics log detail state")]

        //glennj 3/17/2014
        /// <summary>
        /// Sets the detailed mode to on for the diagnostic log
        /// 
        /// DIAGnostic:LOG:DETails
        /// </summary>
        /*!
            \diagnostic \verbatim 
        [When(@"I set the detailed mode to on for the diagnostic log AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I set the detailed mode to on for the diagnostic log AWG ([1-4])")]
        public void SetTheDiagnosticLogDetailedModeToOn(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.SetTheDiagnosticLogToDetailedMode(awg, AwgDiagnosticGroup.DiagnosticLogDetails.On);
        }

        //glennj 3/17/2014
        /// <summary>
        /// Sets the detailed mode to off for the diagnostic log
        /// 
        /// DIAGnostic:LOG:DETails
        /// 
        /// Not currently being used it would appear
        /// </summary>
        /*!
            \diagnostic \verbatim 
        [When(@"I set the detailed mode to off for the diagnostic log AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I set the detailed mode to off for the diagnostic log AWG ([1-4])")]
        public void SetTheDiagnosticLogDetailedModeToOff(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.SetTheDiagnosticLogToDetailedMode(awg, AwgDiagnosticGroup.DiagnosticLogDetails.Off);
        }

        //glennj 3/17/2014
        /// <summary>
        /// Gets the diagnostic detail status
        /// </summary>
        /*!
            \diagnostic \verbatim 
        [When(@"I get the detailed mode for the diagnostic log AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I get the detailed mode for the diagnostic log AWG ([1-4])")]
        public void WhenIGetTheDiagnosticLogDetailStatus(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.GetTheDiagnosticLogDetailStatus(awg);
        }

        //glennj 3/17/2014
        /// <summary>
        /// Verifies that detailed mode is on for the diagnostic log for an AWG
        /// 
        /// DIAGnostic:LOG:DETails
        /// </summary>
        /// <param name="awgNumber">Valid AWG logical number in a range 1 to 4</param>
        /*!
            \diagnostic \verbatim 
        [Then(@"the detailed mode should be on for the diagnostic log AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the detailed mode should be on for the diagnostic log AWG ([1-4])")]
        public void CalLogDetailedModeShouldBeOn(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagLogDetailedModeShouldBe(awg, AwgDiagnosticGroup.DiagnosticLogDetails.On);
        }

        //glennj 3/17/2014
        /// <summary>
        /// Verifies that detailed mode is off for the diagnostic log for an AWG
        /// 
        /// DIAGnostic:LOG:DETails
        /// </summary>
        /// <param name="awgNumber">Valid AWG logical number in a range 1 to 4</param>
        /*!
            \diagnostic \verbatim 
        [Then(@"the detailed mode should be off for the diagnostic log AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the detailed mode should be off for the diagnostic log AWG ([1-4])")]
        public void CalLogDetailedModeShouldBeOff(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagLogDetailedModeShouldBe(awg, AwgDiagnosticGroup.DiagnosticLogDetails.Off);
        }

        #endregion DIAGnostic:LOG:DETails

        #region DIAGnostic:LOG:FAILuresonly

        //Old wording
        //[When(@"I set the AWG diagnostics log failure mode to (ON|OFF|1|0)")]
        //[When(@"I set AWG([1-4]) diagnostics log failure mode to (ON|OFF|1|0)")]
        //[Then(@"the AWG diagnostics log failure mode should be (1|0)")]
        //[Then(@"AWG([1-4]) diagnostics log failure mode should be (1|0)")]
        //[When(@"I get the AWG diagnostics log failure mode")]
        //[When(@"I get AWG([1-4]) diagnostics log failure mode")]


        //glennj 2/7/2014
        /// <summary>
        /// Sets the log only failures text to the diagnostic log
        /// 
        /// DIAGnostic:LOG:FAILureonly
        /// </summary>
        /*!
            \diagnostic \verbatim 
        [When(@"I set the failure only mode to on for the diagnostic log for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I set the failure only mode to on for the diagnostic log for AWG ([1-4])")]
        public void WhenISetTheDiagnosticLogToFailuresOnlyToOn(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagnosticLogOnlyFailures(awg, AwgDiagnosticGroup.DiagnosticLogFailures.On);
        }

        // Unknown 01/01/01
        /// <summary>
        /// Sets the cal log failures Only flag to 0
        /// 
        /// DIAGnostic:LOG:FAILuresonly
        /// </summary>
        /*!
            \diagnostic \verbatim 
        [When(@"I set the failure only mode to off for the diagnostic log for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I set the failure only mode to off for the diagnostic log for AWG ([1-4])")]
        public void WhenISetTheDiagnosticLogToFailuresOnlyToOff(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagnosticLogOnlyFailures(awg, AwgDiagnosticGroup.DiagnosticLogFailures.Off);
        }

        // Unknown 01/01/01
        /// <summary>
        /// Gets the cal log failures only flag 
        /// </summary>
        /*!
            \diagnostic \verbatim 
        [When(@"I get the failure only mode for the diagnostic log for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I get the failure only mode for the diagnostic log for AWG ([1-4])")]
        public void WhenIGetTheDiagnosticLogFailureOnlyStatus(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.GetTheDiagnosticLogFailureOnlyStatus(awg);
        }
        // Unknown 01/01/01
        /// <summary>
        /// Verifies that the cal log failures only flag is set to 1
        /// </summary>
        /*!
            \diagnostic \verbatim 
        [Then(@"the failure only mode should be on for the diagnostic log for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the failure only mode should be on for the diagnostic log for AWG ([1-4])")]
        public void TheCalLogFailuresOnlyModeShouldBeOn(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.CalLogShouldBeSetToFailuresOnlyMode(awg, AwgDiagnosticGroup.DiagnosticLogFailures.On);
        }

        // Unknown 01/01/01
        /// <summary>
        /// Verifies that the cal log failures only flag is set to 0
        /// </summary>
        /*!
            \diagnostic \verbatim 
        [Then(@"the failure only mode should be off for the diagnostic log for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the failure only mode should be off for the diagnostic log for AWG ([1-4])")]
        public void TheCalLogFailuresOnlyModeShouldBeOff(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.CalLogShouldBeSetToFailuresOnlyMode(awg, AwgDiagnosticGroup.DiagnosticLogFailures.Off);
        }

        #endregion DIAGnostic:LOG:FAILuresonly

        #region DIAGnostic:LOOPs?

        //glennj 3/18/2014
        /// <summary>
        /// Get the number of completed loops
        /// 
        /// DIAGnostic:LOOPs?
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostic \verbatim 
        [When(@"I get the diagnostic completed loop count for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I get the diagnostic completed loop count for AWG ([1-4])")]
        public void GetTheDiagnosticCompletedLoopCount(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.GetCurrentDiagnosticLoopCount(awg);
        }

        //glennj 3/18/2014
        /// <summary>
        /// Test the updated current count of complete loops
        /// 
        /// DIAGnostic:LOOPs?
        /// </summary>
        /// <param name="expectedCount"></param>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostic \verbatim 
        [Then(@"the diagnostic completed loop count should be (\d+) for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the diagnostic completed loop count should be (\d+) for AWG ([1-4])")]
        public void TheDiagnosticCompletedLoopCountShouldBe(string expectedCount, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.CurrentDiagnosticLoopCountShouldBe(awg, expectedCount);
        }

        #endregion DIAGnostic:LOOPs?

        #region DIAGnostic:RESult?
        
        //glennj 9/11/2013
        /// <summary>
        /// This gets the result string the complete set for results for all selected tests
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostics \verbatim 
        [When(@"I get the diagnostic result for all for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I get the diagnostic result for all for AWG ([1-4])")]
        public void GetTheResultsForAllTests(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.GetTheDiagnosticResultFromTheAWGForPath(awg);
        }

        //glennj 9/11/2013
        /// <summary>
        /// This gets the result string for set of diagnostic tests based on selected<para>
        /// subsystem.</para>
        /// </summary>
        /// <param name="requiredSubsystem"></param>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostics \verbatim 
        [When(@"I get the diagnostic result for subsystem ""(.+)"" for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I get the diagnostic result for subsystem ""(.+)"" for AWG ([1-4])")]
        public void GetTheResultsForTestSelectedBySubsystem(string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.GetTheDiagnosticResultFromTheAWGForPath(awg, requiredSubsystem);
        }

        //glennj 9/11/2013
        /// <summary>
        /// This gets the result string for set of diagnostic tests based on selected<para>
        /// subsystem and area.</para>
        /// </summary>
        /// <param name="requiredArea"></param>
        /// <param name="requiredSubsystem"></param>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostics \verbatim 
        [When(@"I get the diagnostic result for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I get the diagnostic result for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
        public void GetTheResultsForTestSelectedBySubsystemArea(string requiredArea, string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.GetTheDiagnosticResultFromTheAWGForPath(awg, requiredSubsystem, requiredArea);
        }

        //glennj 9/11/2013
        /// <summary>
        /// This gets the result string for set of diagnostic tests based on selected<para>
        /// subsystem, area and test.</para>
        /// </summary>
        /// <param name="requiredTest"></param>
        /// <param name="requiredArea"></param>
        /// <param name="requiredSubsystem"></param>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostics \verbatim 
        [When(@"I get the diagnostic result for test ""(.+)"" for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I get the diagnostic result for test ""(.+)"" for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
        public void GetTheResultsForTestSelectedBySubsystemAreaTest(string requiredTest, string requiredArea, string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.GetTheDiagnosticResultFromTheAWGForPath(awg, requiredSubsystem, requiredArea, requiredTest);
        }

        //glennj 3/18/2014
        /// <summary>
        /// Using the predefined subsystem context, get the related result
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostics \verbatim 
        [When(@"I get the diagnostic result based on subsystem context for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I get the diagnostic result based on subsystem context for AWG ([1-4])")]
        public void GetDiagnosticResultBasedOnSubsytemContext(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.GetDiagnosticResultBasedOnContext(awg, true);
        }

        //glennj 3/18/2014
        /// <summary>
        /// Using the predefined subsystem and area context, get the related result
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostics \verbatim 
        [When(@"I get the diagnostic result based on area and subsystem context for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I get the diagnostic result based on area and subsystem context for AWG ([1-4])")]
        public void GetDiagnosticResultBasedOnAreaContext(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.GetDiagnosticResultBasedOnContext(awg, true, true);
        }

        //glennj 3/18/2014
        /// <summary>
        /// Using the predefined subsystem, area and test context, get the related result
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostics \verbatim 
        [When(@"I get the diagnostic result based on test and area and subsystem context for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I get the diagnostic result based on test and area and subsystem context for AWG ([1-4])")]
        public void GetDiagnosticResultBasedOnTestContext(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.GetDiagnosticResultBasedOnContext(awg, true, true, true);
        }

        //glennj 9/11/2013
        /// <summary>
        /// This checks for expected text to be contained in the returned result string.<para>
        /// Note, it doesn't test for position but is more like a feel good exercised.</para><para>
        /// As an example when getting the results for entire diagnostic set of tests,</para><para>
        /// maybe the only text that can be looked for is "NORM" which is an indication</para><para>
        /// that the mode was NORMal as oppose to POST or MANufacturing.</para>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostics \verbatim 
        [Then(@"the diagnostic result should contain ""(.+)"" on AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the diagnostic result should contain ""(.+)"" on AWG ([1-4])")]
        public void DiagnosticResultShouldContain(string text, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.ResultsForTestSelectedForAllShouldContain(awg, text, true);
        }

        //glennj 9/11/2013
        /// <summary>
        /// This checks for expected text to not be contained in the returned result string.<para>
        /// Note, it doesn't test for position but is more like a feel good exercised.</para><para>
        /// As an example when getting the results for entire diagnostic set of tests,</para><para>
        /// maybe the only text that can be looked for is "NORM" which is an indication</para><para>
        /// that the mode was NORMal as oppose to POST or MANufacturing.</para>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostics \verbatim 
        [Then(@"the diagnostic result should not contain ""(.+)"" on AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the diagnostic result should not contain ""(.+)"" on AWG ([1-4])")]
        public void DiagnosticResultShouldNotContain(string text, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.ResultsForTestSelectedForAllShouldContain(awg, text, false);
        }

        //glennj 9/11/2013
        /// <summary>
        /// This validation is based on the fact that a result string based on a selected subsystem<para>
        /// was done and tests to make sure that the string contains the said selected subsystem.</para>
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostics \verbatim 
        [Then(@"the results for tests selected by subsystem should contain test path on AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the diagnostic result based on context should contain subsystem name for AWG ([1-4])")]
        public void ResultBasedOnContextContainingSubsystemName(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.ResultsForTestSelectedBySubsystemAreaTestShouldContain(awg, AwgDiagnosticGroup.DiagnosticSelectedContext.Subsystem, true);
        }

        [Then(@"the diagnostic result based on context should not contain subsystem name for AWG ([1-4])")]
        public void ResultBasedOnContextNotContainingSubsystemName(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.ResultsForTestSelectedBySubsystemAreaTestShouldContain(awg, AwgDiagnosticGroup.DiagnosticSelectedContext.Subsystem, false);
        }

        //glennj 9/11/2013
        /// <summary>
        /// This validation is based on the fact that a result string based on a selected subsystem<para>
        /// and area was done and checks to make sure that the string contains the said selected subsystem</para><para>
        /// and area.</para>
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostics \verbatim 
        [Then(@"the results for tests selected by subsystem and area should contain test path on AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the diagnostic result based on context should contain area name for AWG ([1-4])")]
        public void ResultBasedOnContextContainingAreaName(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.ResultsForTestSelectedBySubsystemAreaTestShouldContain(awg, AwgDiagnosticGroup.DiagnosticSelectedContext.Area, true);
        }

        [Then(@"the diagnostic result based on context should not contain area name for AWG ([1-4])")]
        public void ResultBasedOnContextNotContainingAreaName(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.ResultsForTestSelectedBySubsystemAreaTestShouldContain(awg, AwgDiagnosticGroup.DiagnosticSelectedContext.Area, false);
        }

        //glennj 9/11/2013
        /// <summary>
        /// This validation is based on the fact that a result string based on a selected subsystem,<para>
        /// area and test was done and checks to make sure that the string contains the said selected</para><para>
        /// subsystem, area and test.</para>
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostics \verbatim 
        [Then(@"the results for tests selected by subsystem and area and test should contain test path on AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the diagnostic result based on context should contain test name for AWG ([1-4])")]
        public void ResultBasedOnContextContainingTestName(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.ResultsForTestSelectedBySubsystemAreaTestShouldContain(awg, AwgDiagnosticGroup.DiagnosticSelectedContext.Test, true);
        }

        [Then(@"the diagnostic result based on context should not contain test name for AWG ([1-4])")]
        public void ResultBasedOnContextNotContainingTestName(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.ResultsForTestSelectedBySubsystemAreaTestShouldContain(awg, AwgDiagnosticGroup.DiagnosticSelectedContext.Test, false);
        }

        // Unknown 01/01/01
        /// <summary>
        /// Verifies the pass count for the default AWG
        /// </summary>
        /// <param name="p0">0 or greater</param>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostics \verbatim 
        [Then(@"the AWG diagnostic result should have the pass count of ((?<!\S)[+]?\d+(?!\S))")]
            \endverbatim
        */
        [Then(@"the diagnostic result should have the pass count of ((?<!\S)[+]?\d+(?!\S)) for AWG ([1-4])")]
        public void ThenTheDiagnosticResultShouldHaveThePassCountOf(int p0, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagnosticResultShouldHaveThePassCountOf(awg, p0);
        }

        // Unknown 01/01/01
        /// <summary>
        /// Verifies the fail count for the default AWG
        /// </summary>
        /// <param name="p0">0 or greater</param>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostics \verbatim 
        [Then(@"the AWG diagnostic result should have the fail count of ((?<!\S)[+]?\d+(?!\S))")]
            \endverbatim
        */
        [Then(@"the diagnostic result should have the fail count of ((?<!\S)[+]?\d+(?!\S)) for AWG ([1-4])")]
        public void ThenTheDiagnosticResultShouldHaveTheFailCountOf(int p0, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagnosticResultShouldHaveTheFailCountOf(awg, p0);
        }

        #endregion DIAGnostic:RESult?

        #region DIAGnostic:RESult:TEMPerature?

        //old wording
        //[When(@"I get the diagnostics temperature from AWG([1-4])")]
        //[When(@"I get the AWG diagnostic temperature")]
        //[When(@"I get AWG([1-4]) diagnostic temperature")]
        //[When(@"I get the AWG diagnostic temperature for (.+)")]
        //[When(@"I get AWG([1-4]) diagnostic temperature for (.+)")]

        //glennj 3/17/2014
        /// <summary>
        /// Gets the highest recorded temperature for the specified AWG
        ///
        /// DIAGnostic:RESult:TEMPerature?
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \diagnostics \verbatim 
        [When(@"I get the diagnostic temperature for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I get the diagnostic temperature for AWG ([1-4])")]
        public void GetTheDiagnosticsTemperatureForAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.GetAWGDiagnosticTemperature(awg);
        }

        //glennj 3/17/2014
        ///  <summary>
        ///  Gets the highest recorded temperature for a specified subsystem and AWG
        /// 
        ///  DIAGnostic:RESult:TEMPerature?
        ///  </summary>
        /// <param name="subsystem"></param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \diagnostics \verbatim 
        [When(@"I get the diagnostic temperature for subsystem ""(.+)"" for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I get the diagnostic temperature for subsystem ""(.+)"" for AWG ([1-4])")]
        public void GetTheDiagnosticsTemperatureForSubsystemAWG(string subsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.GetAWGDiagnosticTemperature(awg, subsystem);
        }

        //glennj 3/17/2014
        ///  <summary>
        ///  Gets the highest recorded temperature for a specified area, subsystem and AWG
        /// 
        ///  DIAGnostic:RESult:TEMPerature?
        ///  </summary>
        /// <param name="area"></param>
        /// <param name="subsystem"></param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \diagnostics \verbatim 
        [When(@"I get the diagnostic temperature for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I get the diagnostic temperature for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
        public void GetTheDiagnosticsTemperatureForSubsystemAWG(string area, string subsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.GetAWGDiagnosticTemperature(awg, subsystem, area);
        }

        //glennj 3/17/2014
        ///  <summary>
        ///  Gets the highest recorded temperature for a specified test, area, subsystem and AWG
        /// 
        ///  DIAGnostic:RESult:TEMPerature?
        ///  </summary>
        /// <param name="test"></param>
        /// <param name="area"></param>
        /// <param name="subsystem"></param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \diagnostics \verbatim 
        [When(@"I get the diagnostic temperature for test ""(.+)"" for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I get the diagnostic temperature for test ""(.+)"" for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
        public void GetTheDiagnosticsTemperatureForSubsystemAWG(string test, string area, string subsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.GetAWGDiagnosticTemperature(awg, subsystem, area, test);
        }

        //glennj 3/17/2014
        /// <summary>
        /// Tests the previously retrieved returned string for the temperature for a specified AWG
        /// to be empty.
        ///  
        ///  DIAGnostic:RESult:TEMPerature?
        ///  </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \diagnostics \verbatim 
        [Then(@"the diagnostic temperature should be empty for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the diagnostic temperature should be empty for AWG ([1-4])")]
        public void DiagnosticsTemperatureResultStringShouldBeEmpty(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagnosticDiagnosticTemperatureShouldBeNulled(awg, true);
        }

        //glennj 3/17/2014
        /// <summary>
        /// Tests the previously retrieved returned string for the temperature for a specified AWG
        /// to be not empty.
        ///  
        ///  DIAGnostic:RESult:TEMPerature?
        ///  </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \diagnostics \verbatim 
        [Then(@"the diagnostic temperature should not be empty for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the diagnostic temperature should not be empty for AWG ([1-4])")]
        public void DiagnosticsTemperatureResultStringShouldNotBeEmpty(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagnosticDiagnosticTemperatureShouldBeNulled(awg, false);
        }

        //glennj 12/2/2013 added step
        /// <summary>
        /// Tests the previously retrieved returned string for the temperature for a specified AWG
        /// to contain a defined string
        /// 
        /// </summary>
        /// <param name="awgNumber"></param>
        /// <param name="containedValue">The expected feel good text</param>
        /*!
            \diagnostic \verbatim
        [Then(@"the diagnostic temperature should contain ""(.*)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the diagnostic temperature should contain ""(.*)"" for AWG ([1-4])")]
        public void ThenDiagnosticTemperatureResultShouldContain(string containedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagnosticTemperatureResultShouldContain(awg, containedValue, true);
        }

        //glennj 12/2/2013 added step
        /// <summary>
        /// Tests the previously retrieved returned string for the temperature for a specified AWG
        /// to not contain a defined string
        /// 
        /// </summary>
        /// <param name="awgNumber"></param>
        /// <param name="containedValue">The expected feel good text</param>
        /*!
            \diagnostic \verbatim
        [Then(@"the diagnostic temperature should not contain ""(.*)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the diagnostic temperature should not contain ""(.*)"" for AWG ([1-4])")]
        public void ThenDiagnosticTemperatureResultShouldNotContain(string containedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagnosticTemperatureResultShouldContain(awg, containedValue, false);
        }

        #endregion DIAGnostic:RESult:TEMPerature?

        #region DIAGnostic:RESult:TIME?

        //[When(@"I get the diagnostics time from AWG([1-4])")]
        //[When(@"I get the AWG diagnostic time")]
        //[When(@"I get AWG([1-4]) diagnostic time")]
        //[When(@"I get the AWG diagnostic time for (.+)")]
        //[Then(@"the AWG diagnostic time should be a valid value")]
        //[When(@"I get AWG([1-4]) diagnostic time for (.+)")]

        //glennj 3/17/2014
        /// <summary>
        /// Gets the highest recorded time for the specified AWG
        ///
        /// DIAGnostic:RESult:TIME?
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \diagnostics \verbatim 
        [When(@"I get the diagnostic time for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I get the diagnostic time for AWG ([1-4])")]
        public void GetTheDiagnosticsTimeForAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.GetAWGDiagnosticTime(awg);
        }

        //glennj 3/17/2014
        ///  <summary>
        ///  Gets the highest recorded time for a specified subsystem and AWG
        /// 
        ///  DIAGnostic:RESult:TIME?
        ///  </summary>
        /// <param name="subsystem"></param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \diagnostics \verbatim 
        [When(@"I get the diagnostic time for subsystem ""(.+)"" for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I get the diagnostic time for subsystem ""(.+)"" for AWG ([1-4])")]
        public void GetTheDiagnosticsTimeForSubsystemAWG(string subsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.GetAWGDiagnosticTime(awg, subsystem);
        }

        //glennj 3/17/2014
        ///  <summary>
        ///  Gets the highest recorded time for a specified area, subsystem and AWG
        /// 
        ///  DIAGnostic:RESult:TIME?
        ///  </summary>
        /// <param name="area"></param>
        /// <param name="subsystem"></param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \diagnostics \verbatim 
        [When(@"I get the diagnostic time for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I get the diagnostic time for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
        public void GetTheDiagnosticsTimeForSubsystemAWG(string area, string subsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.GetAWGDiagnosticTime(awg, subsystem, area);
        }

        //glennj 3/17/2014
        ///  <summary>
        ///  Gets the highest recorded time for a specified test, area, subsystem and AWG
        /// 
        ///  DIAGnostic:RESult:TIME?
        ///  </summary>
        /// <param name="test"></param>
        /// <param name="area"></param>
        /// <param name="subsystem"></param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \diagnostics \verbatim 
        [When(@"I get the diagnostic time for test ""(.+)"" for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I get the diagnostic time for test ""(.+)"" for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
        public void GetTheDiagnosticsTimeForSubsystemAWG(string test, string area, string subsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.GetAWGDiagnosticTime(awg, subsystem, area, test);
        }

        //glennj 3/17/2014
        /// <summary>
        /// Tests the previously retrieved returned string for the time for a specified AWG
        /// to be empty.
        ///  
        ///  DIAGnostic:RESult:TIME?
        ///  </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \diagnostics \verbatim 
        [Then(@"the diagnostic time should be empty for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the diagnostic time should be empty for AWG ([1-4])")]
        public void DiagnosticsTimeResultStringShouldBeEmpty(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagnosticDiagnosticTimeShouldBeNulled(awg, true);
        }

        //glennj 3/17/2014
        /// <summary>
        /// Tests the previously retrieved returned string for the time for a specified AWG
        /// to be not empty.
        ///  
        ///  DIAGnostic:RESult:TIME?
        ///  </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \diagnostics \verbatim 
        [Then(@"the diagnostic time should not be empty for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the diagnostic time should not be empty for AWG ([1-4])")]
        public void DiagnosticsTimeResultStringShouldNotBeEmpty(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagnosticDiagnosticTimeShouldBeNulled(awg, false);
        }

        //glennj 12/2/2013 added step
        /// <summary>
        /// Tests the previously retrieved returned string for the time for a specified AWG
        /// to contain a defined string
        /// 
        /// </summary>
        /// <param name="awgNumber"></param>
        /// <param name="containedValue">The expected feel good text</param>
        /*!
            \diagnostic \verbatim
        [Then(@"the diagnostic result should contain ""(.*)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the diagnostic time should contain ""(.*)"" for AWG ([1-4])")]
        public void ThenDiagnosticTimeResultShouldContain(string containedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagnosticTimeResultShouldContain(awg, containedValue, true);
        }

        //glennj 12/2/2013 added step
        /// <summary>
        /// Tests the previously retrieved returned string for the time for a specified AWG
        /// to not contain a defined string
        /// 
        /// </summary>
        /// <param name="awgNumber"></param>
        /// <param name="containedValue">The expected feel good text</param>
        /*!
            \diagnostic \verbatim
        [Then(@"the diagnostic result should contain ""(.*)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the diagnostic time should not contain ""(.*)"" for AWG ([1-4])")]
        public void ThenDiagnosticTimeResultShouldNotContain(string containedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagnosticTimeResultShouldContain(awg, containedValue, false);
        }

        #endregion DIAGnostic:RESult:TIME?

        #region DIAGnostic:RUNNing?

        //glennj 3/18/2014
        /// <summary>
        /// Update the AWG object with the running state status
        /// </summary>
        /// <param name="awgNumber"></param>
        [When(@"I get the diagnostic running state for AWG ([1-4])")]
        public void GetTheDiagnosticsRunningState(string awgNumber)
        {

            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.GetDiagnosticRunningState(awg);
        }

        //zkoppert 7/3/12
        //glennj 9/3/2013
        /// <summary>
        /// Verifies that Diagnostic tests are currently running via DIAG:RUNN? query on a numbered AWG (AWG1, AWG2...etc.)
        ///
        /// DIAG:RUNNing?
        /// Deprecated. Use
        /// [Then(@"AWG([1-4]) diagnostics should be running")]
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \diagnostics \verbatim 
        [Then(@"the diagnostic running state should be running for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the diagnostic running state should be running for AWG ([1-4])")]
        public void ThenTheDiagnosticsShouldBeRunningOnAnAwg(string awgNumber)
        {

            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagnosticRunningStateShouldBe(awg,
                                        AwgDiagnosticGroup.DiagnosticRunningState.Running);
        }

        //zkoppert 7/3/12
        //glennj 9/3/2013
        /// <summary>
        /// Verifies that Diagnostic tests are currently NOT running via DIAG:RUNN? query.
        ///
        /// DIAG:RUNNing?
        /// Deprecated. Use
        /// [Then(@"AWG([1-4]) diagnostics should not be running")]
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param> 
        /*!
            \diagnostics \verbatim 
        [Then(@"the diagnostic running state should not be running for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the diagnostic running state should not be running for AWG ([1-4])")]
        public void ThenTheDiagnosticsShouldNotBeRunningOnAWG1(string awgNumber)
        {

            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagnosticRunningStateShouldBe(awg,
                                        AwgDiagnosticGroup.DiagnosticRunningState.Stopped);
        }

        #endregion DIAGnostic:RUNNing?

        #region DIAGnostic:SELect

        //glennj 3/12/2014
        /// <summary>
        /// Selects all the diagnostic tests for the  current diagnostic type. 
        /// 
        /// DIAGnostic:SELect "ALL"
        /// </summary>
        /*!
            \diagnostic \verbatim
        [When(@"I select all diagnostic tests for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I select all diagnostic tests for AWG ([1-4])")]
        public void WhenISelectAllDiagnosticTests(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.SelectAllDiagnosticTestsOnAWG(awg, true);
        }

        //zkoppert 7/11/12
        //glennj 2/6/2014
        ///  <summary>
        ///  Selects the specified diagnostic subsystem.
        /// 
        ///  DIAGnostic:SELect test
        ///  </summary>
        /// <param name="requiredSubsystem"></param>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostic \verbatim 
        [When(@"I select the diagnostic tests for subsystem ""(.+)"" for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I select the diagnostic tests for subsystem ""(.+)"" for AWG ([1-4])")]
        public void WhenISelectTheDiagnosticSubsystemProcedures(string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.SelectTheDiagnosticTestOnAWG(awg, true, requiredSubsystem);
        }

        //glennj 2/6/2014
        ///  <summary>
        ///  Selects the specified diagnostic area.
        /// 
        ///  DIAGnostic:SELect test
        ///  </summary>
        /// <param name="requiredArea"></param>
        /// <param name="requiredSubsystem"></param>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostic \verbatim
        [When(@"I select the diagnostic tests for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I select the diagnostic tests for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
        public void WhenISelectTheDiagnosticTest(string requiredArea, string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.SelectTheDiagnosticTestOnAWG(awg, true, requiredSubsystem, requiredArea);
        }

        //glennj 2/6/2014
        ///  <summary>
        ///  Selects the specified diagnostic test.
        /// 
        ///  DIAGnostic:SELect test
        ///  </summary>
        /// <param name="requiredTest"></param>
        /// <param name="requiredArea"></param>
        /// <param name="requiredSubsystem"></param>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostic \verbatim
        [When(@"I select the diagnostic test ""(.+)"" for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I select the diagnostic test ""(.+)"" for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
        public void WhenISelectTheDiagnosticProcedure(string requiredTest, string requiredArea, string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.SelectTheDiagnosticTestOnAWG(awg, true, requiredSubsystem, requiredArea, requiredTest);
        }

        #endregion DIAGnostic:SELect

        #region DIAGnostic:SELect:VERify?

        //zkoppert 7/3/12
        ///  <summary>
        ///  Compares the specified test in the specified category context expecting a selected state.
        /// 
        ///  DIAG:SEL:VER? test
        ///  </summary>
        /// <param name="requiredSubsystem"></param>
        /// <param name="requiredArea"></param>
        /// <param name="requiredTest"></param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \diagnostics \verbatim 
        [Then(@"the diagnostic test should be selected for test ""(.+)"" for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the diagnostic test should be selected for test ""(.+)"" for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
        public void ThenTheDiagnosticTestShouldBeSelectedOnAWG(string requiredTest, string requiredArea, string requiredSubsystem, string awgNumber)
        {

            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagnosticTestShouldBeSelectedOnAWG(awg, requiredSubsystem, requiredArea, requiredTest, true);
        }

        //zkoppert 7/3/12
        ///  <summary>
        ///  Compares the specified test in the specified category context expecting an unselected state.
        /// 
        ///  DIAG:SEL:VER? test
        ///  </summary>
        /// <param name="requiredSubsystem"></param>
        /// <param name="requiredTest"></param>
        /// <param name="requiredArea"></param> 
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \diagnostics \verbatim 
        [Then(@"the diagnostic test should not be selected for test ""(.+)"" for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the diagnostic test should not be selected for test ""(.+)"" for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
        public void ThenTheTestShouldBeUnselectedOnAWG(string requiredTest, string requiredArea, string requiredSubsystem, string awgNumber)
        {

            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagnosticTestShouldBeSelectedOnAWG(awg, requiredSubsystem, requiredArea, requiredTest, false);
        }

        #endregion DIAGnostic:SELect:VERify?

        #region DIAGnostic:STARt

        //glennj 10/31/2012
        /// <summary>
        /// Start the diagnostics on the specified AWG
        ///
        /// DIAGnostic:STARt - starts the selected set of tests on the default AWG
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \diagnostics \verbatim 
        [When(@"I start the diagnostics for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I start the diagnostics for AWG ([1-4])")]
        public void StartTheAWGDiagnostics(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.StartDiagnosticsOnAnAwg(awg);
        }
        #endregion DIAGnostic:STARt

        #region DIAGnostic:STOP

        //zkoppert 7/5/12
        /// <summary>
        /// Stops diagnostics after current test is completed on the specified AWG
        ///
        /// DIAG:STOP
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \diagnostics \verbatim 
        [When(@"I stop the diagnostics for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I stop the diagnostics for AWG ([1-4])")]
        public void WhenIStopDiagnosticsAfterCurrentTestOnAnAwg(string awgNumber)
        {

            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.StopDiagnosticsOnAnAwg(awg);
        }

        #endregion DIAGnostic:STOP

        #region DIAGnostic:STOP:STATe?

        //glennj 3/14/2014
        /// <summary>
        /// Gets the diagnostic stop state.
        ///
        /// DIAGnostic:STOP:STATe?
        /// </summary>
        /*!
            \diagnostic \verbatim 
        [When(@"I get the diagnostic stop state for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I get the diagnostic stop state for AWG ([1-4])")]
        public void WhenIGetTheDiagnosticStopState(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.GetDiagnosticStopState(awg);
        }

        //glennj 3/14/2014
        ///  <summary>
        ///  Checks that the diagnostic stop state to be stopped for AWG.
        /// 
        ///  DIAGnostic:STOP:STATe?
        ///  </summary>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostic \verbatim 
        [Then(@"the diagnostic stop state should be stopped for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the diagnostic stop state should be stopped for AWG ([1-4])")]
        public void ThenTheAwgDiagnosticStopStateShouldBeStopped(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagnosticStopStateShouldBe(awg, AwgDiagnosticGroup.DiagnosticStoppedState.Stopped);
        }

        //glennj 3/14/2014
        ///  <summary>
        ///  Checks that the diagnostic stop state to be not stopped for AWG.
        /// 
        ///  DIAGnostic:STOP:STATe?
        ///  </summary>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostic \verbatim 
        [Then(@"the diagnostic stop state should not be stopped for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the diagnostic stop state should not be stopped for AWG ([1-4])")]
        public void ThenTheAwgDiagnosticStopStateShouldBeNotStopped(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagnosticStopStateShouldBe(awg, AwgDiagnosticGroup.DiagnosticStoppedState.NotStopped);
        }

        #endregion DIAGnostic:STOP:STATe?

        #region DIAGnostic:TYPE

        //glennj 3/13/2014
        /// <summary>
        /// Sets the diagnostic type context to Normal
        /// </summary>
        /// <param name="awgNumber"></param>
        [When(@"I set the diagnostic type to normal for AWG ([1-4])")]
        public void SetTheDiagnosticTypeToNormal(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.SendAsTheDiagnosticsTestModeOnAnAWG(awg, AwgDiagnosticGroup.DiagnosticType.Normal);
        }

        //glennj 3/13/2014
        /// <summary>
        /// Sets the diagnostic type context to Power On Self Test (POST)
        /// </summary>
        /// <param name="awgNumber"></param>
        [When(@"I set the diagnostic type to POST for AWG ([1-4])")]
        public void SetTheDiagnosticTypeToPost(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.SendAsTheDiagnosticsTestModeOnAnAWG(awg, AwgDiagnosticGroup.DiagnosticType.POST);
        }

        //glennj 3/13/2014
        /// <summary>
        /// Sets the diagnostic type context to engineering.
        /// Requires AWG to be in manufacturing mode
        /// </summary>
        /// <param name="awgNumber"></param>
        [When(@"I set the diagnostic type to engineering for AWG ([1-4])")]
        public void SetTheDiagnosticTypeToEngineering(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.SendAsTheDiagnosticsTestModeOnAnAWG(awg, AwgDiagnosticGroup.DiagnosticType.Engineering);
        }

        //glennj 3/13/2014
        /// <summary>
        /// Sets the diagnostic type context to manufacturing.
        /// Requires AWG to be in manufacturing mode
        /// </summary>
        /// <param name="awgNumber"></param>
        [When(@"I set the diagnostic type to manufacturing for AWG ([1-4])")]
        public void SetTheDiagnosticTypeToManufacturing(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.SendAsTheDiagnosticsTestModeOnAnAWG(awg, AwgDiagnosticGroup.DiagnosticType.Manufacturing);
        }

        //glennj 3/13/2014
        /// <summary>
        /// Sets the diagnostic type context to ORT.
        /// Requires AWG to be in manufacturing mode
        /// </summary>
        /// <param name="awgNumber"></param>
        [When(@"I set the diagnostic type to ORT for AWG ([1-4])")]
        public void SetTheDiagnosticTypeToORT(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.SendAsTheDiagnosticsTestModeOnAnAWG(awg, AwgDiagnosticGroup.DiagnosticType.ORT);
        }

        //glennj 3/13/2014
        /// <summary>
        /// Sets the diagnostic type context to RTC.
        /// Requires AWG to be in manufacturing mode
        /// </summary>
        /// <param name="awgNumber"></param>
        [When(@"I set the diagnostic type to RTC for AWG ([1-4])")]
        public void SetTheDiagnosticTypeToRTC(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.SendAsTheDiagnosticsTestModeOnAnAWG(awg, AwgDiagnosticGroup.DiagnosticType.RTC);
        }
        
        //zkoppert 7/3/12
        /// <summary>
        /// Gets the type or context of the diagnostic tests.
        ///
        /// DIAG:TYPE?
        /// Deprecate. Use
        /// [When(@"I get AWG([1-4]) diagnostic type")]
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \diagnostics \verbatim 
        [When(@"I get the diagnostic type from AWG([1-4])")]
            \endverbatim
        */
        [When(@"I get the diagnostic type for AWG ([1-4])")]
        public void WhenIGetTheDiagnosticTypeFromAWG(string awgNumber)
        {

            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.GetTheDiagnosticTypeFromAWG(awg);
        }

        //glennj 3/18/2014
        /// <summary>
        /// Checks to verify that the updated diagnostic test type is normal
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
          \diagnostics \verbatim 
        [Then(@"the diagnostic type should be normal for AWG ([1-4])")]
          \endverbatim
        */
        [Then(@"the diagnostic type should be normal for AWG ([1-4])")]
        public void DiagnosticTypeShouldBeNormal(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagnosticTypeFromAWGShouldBeType(awg, AwgDiagnosticGroup.DiagnosticType.Normal);
        }

        //glennj 3/18/2014
        /// <summary>
        /// Checks to verify that the updated diagnostic test type is POST or Power On Self Test
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
          \diagnostics \verbatim 
        [Then(@"the diagnostic type should be POST for AWG ([1-4])")]
          \endverbatim
        */
        [Then(@"the diagnostic type should be POST for AWG ([1-4])")]
        public void DiagnosticTypeShouldBePost(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagnosticTypeFromAWGShouldBeType(awg, AwgDiagnosticGroup.DiagnosticType.POST);
        }

        //glennj 3/18/2014
        /// <summary>
        /// Checks to verify that the updated diagnostic test type is engineering
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
          \diagnostics \verbatim 
        [Then(@"the diagnostic type should be engineering for AWG ([1-4])")]
          \endverbatim
        */
        [Then(@"the diagnostic type should be engineering for AWG ([1-4])")]
        public void DiagnosticTypeShouldBeEngineering(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagnosticTypeFromAWGShouldBeType(awg, AwgDiagnosticGroup.DiagnosticType.Engineering);
        }

        //glennj 3/18/2014
        /// <summary>
        /// Checks to verify that the updated diagnostic test type is manufacturing
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
          \diagnostics \verbatim 
        [Then(@"the diagnostic type should be manufacturing for AWG ([1-4])")]
          \endverbatim
        */
        [Then(@"the diagnostic type should be manufacturing for AWG ([1-4])")]
        public void DiagnosticTypeShouldBeManufacturing(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagnosticTypeFromAWGShouldBeType(awg, AwgDiagnosticGroup.DiagnosticType.Manufacturing);
        }

        //glennj 3/18/2014
        /// <summary>
        /// Checks to verify that the updated diagnostic test type is ORT
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
          \diagnostics \verbatim 
        [Then(@"the diagnostic type should be ORT for AWG ([1-4])")]
          \endverbatim
        */
        [Then(@"the diagnostic type should be ORT for AWG ([1-4])")]
        public void DiagnosticTypeShouldBeORT(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagnosticTypeFromAWGShouldBeType(awg, AwgDiagnosticGroup.DiagnosticType.ORT);
        }

        //glennj 3/18/2014
        /// <summary>
        /// Checks to verify that the updated diagnostic test type is RTC
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
          \diagnostics \verbatim 
        [Then(@"the diagnostic type should be RTC for AWG ([1-4])")]
          \endverbatim
        */
        [Then(@"the diagnostic type should be RTC for AWG ([1-4])")]
        public void DiagnosticTypeShouldBeRTC(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagnosticTypeFromAWGShouldBeType(awg, AwgDiagnosticGroup.DiagnosticType.RTC);
        }

        #endregion DIAGnostic:TYPE
        
        #region DIAGnostic:TYPE:CATalog?

        //glennj 2/5/2014
        /// <summary>
        /// Gets the diagnostic type catalog from the AWG and stores it to awg.diagnostic_catalog. 
        /// 
        /// DIAGnostic:TYPE:CATalog?
        /// </summary>
        /*!
            \diagnostic\verbatim
        [When(@"I get the list of diagnostic types for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the list of diagnostic types for AWG ([1-4])")]
        public void WhenIGetTheAwgDiagnosticTypeCatalog(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.GetTheAwgDiagnosticTypeCatalog(awg);
        }

        //glennj 2/5/2014
        /// <summary>
        /// Semi verifies the diagnostic type catalogs
        /// 
        /// DIAGnostic:TYPE:CATalog?
        /// </summary>
        /*!
            \diagnostic\verbatim
        [Then(@"the list of diagnostic types should be valid for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the list of diagnostic types should be valid for AWG ([1-4])")]
        public void ThenTheDiagnosticTypeCatalogFromAWG1ShouldBeValid(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.DiagnosticTypeListValidation(awg);
        }

        #endregion DIAGnostic:TYPE:CATalog?

        #region DIAGnostic:UNSelect

        //glennj 3/12/2014
        /// <summary>
        /// Unselects all the diagnostic tests for the  current diagnostic type. 
        /// 
        /// DIAGnostic:UNSelect "ALL"
        /// </summary>
        /*!
            \diagnostic \verbatim
        [When(@"I unselect all diagnostic tests for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I unselect all diagnostic tests for AWG ([1-4])")]
        public void WhenIUnselectAllDiagnosticTests(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.SelectAllDiagnosticTestsOnAWG(awg, false);
        }

        //zkoppert 7/11/12
        //glennj 2/6/2014
        ///  <summary>
        ///  Unselects the specified diagnostic subsystem.
        /// 
        ///  DIAGnostic:UNSelect test
        ///  </summary>
        /// <param name="requiredSubsystem"></param>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostic \verbatim 
        [When(@"I unselect the diagnostic tests for subsystem ""(.+)"" for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I unselect the diagnostic tests for subsystem ""(.+)"" for AWG ([1-4])")]
        public void WhenIUnselectTheDiagnosticSubsystemProcedures(string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.SelectTheDiagnosticTestOnAWG(awg, false, requiredSubsystem);
        }

        //glennj 2/6/2014
        ///  <summary>
        ///  Unselects the specified diagnostic area.
        /// 
        ///  DIAGnostic:UNSelect test
        ///  </summary>
        /// <param name="requiredArea"></param>
        /// <param name="requiredSubsystem"></param>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostic \verbatim
        [When(@"I unselect the diagnostic tests for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I unselect the diagnostic tests for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
        public void WhenIUnselectTheDiagnosticTest(string requiredArea, string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.SelectTheDiagnosticTestOnAWG(awg, false, requiredSubsystem, requiredArea);
        }

        //glennj 2/6/2014
        ///  <summary>
        ///  Unselects the specified diagnostic test.
        /// 
        ///  DIAGnostic:UNSelect test
        ///  </summary>
        /// <param name="requiredTest"></param>
        /// <param name="requiredArea"></param>
        /// <param name="requiredSubsystem"></param>
        /// <param name="awgNumber"></param>
        /*!
            \diagnostic \verbatim
        [When(@"I unselect the diagnostic test ""(.+)"" for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I unselect the diagnostic test ""(.+)"" for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
        public void WhenIUnselectTheDiagnosticProcedure(string requiredTest, string requiredArea, string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDiagnosticGroup.SelectTheDiagnosticTestOnAWG(awg, false, requiredSubsystem, requiredArea, requiredTest);
        }

        #endregion DIAGnostic:UNSelect

    }
}