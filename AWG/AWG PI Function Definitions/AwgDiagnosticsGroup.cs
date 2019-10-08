//==========================================================================
// AwgDiagnosticsGroup.cs
//==========================================================================

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains helper functions that are called from the %AWG Diagnostic PI step definitions.
    /// This class has no restrictions as to where it will be used.
    /// 
    /// This "Helper" group does everything else but steps and TekVISA.
    /// Using parameters from the step, each helper will makes decisions
    /// such as send commands, or process responses from queries and
    /// do testing and generate asserts if necessary.
    /// 
    /// \ingroup grouphelperpi pisteps 
    /// 
    /// 
    /// </summary>
    public class AwgDiagnosticGroup
    {
        private readonly UTILS _utils = new UTILS();

        public enum ActiveModeAs { Normal, Calibration, Diagnostic, Reset }

        private const string ActiveModeNormalSyntax = "NORM";
        private const string ActiveModeCalibrationSyntax = "CAL";
        private const string ActiveModeDiagnosticSyntax = "DIAG";
        private const string ActiveModeResetSyntax = "RES";

        public enum DiagnosticType { Engineering, Manufacturing, Normal, ORT, POST, RTC }

        private const string DiagnosticTypeEngineeringSyntax = "ENG";
        private const string DiagnosticTypeManufacturingSyntax = "MAN";
        private const string DiagnosticTypeNormalSyntax = "NORM";
        private const string DiagnosticTypeORTSyntax = "ORT";
        private const string DiagnosticTypePOSTSyntax = "POST";
        private const string DiagnosticTypeRTCSyntax = "RTC";

        private const string SelectAllSyntax = "ALL";

        public enum DiagnosticLogDetails { On, Off }

        private const string DiagnosticLogDetailsOnSyntaxSend = "ON";
        private const string DiagnosticLogDetailsOffSyntaxSend = "OFF";
        private const string DiagnosticLogDetailsOnSyntaxReceived = "1";
        private const string DiagnosticLogDetailsOffSyntaxReceived = "0";

        public enum DiagnosticLogFailures { On, Off }

        private const string DiagnosticLogFailuresOnSyntaxSend = "ON";
        private const string DiagnosticLogFailuresOffSyntaxSend = "OFF";
        private const string DiagnosticLogFailuresOnSyntaxReceived = "1";
        private const string DiagnosticLogFailuresOffSyntaxReceived = "0";

        public enum DiagnosticRunningState { Running, Stopped }

        public enum DiagnosticControlLoopMode { Once, Continuous, Count }

        private const string DiagnosticControlLoopOnceSyntaxSend = "ONCE";
        private const string DiagnosticControlLoopContinuousSyntaxSend = "CONTinuous";
        private const string DiagnosticControlLoopCountSyntaxSend = "COUNt";

        private const string DiagnosticControlLoopOnceSyntaxReceived = "ONCE";
        private const string DiagnosticControlLoopContinuousSyntaxReceived = "CONT";
        private const string DiagnosticControlLoopCountSyntaxReceived = "COUN";

        public enum DiagnosticLoopCountTypeAs { Nr1, Min, Max }

        private const string DiagnosticLoopCountMaxSyntax = "MAX";
        private const string DiagnosticLoopCountMinSyntax = "MIN";

        public enum DiagnosticControlHaltMode { On, Off }

        private const string DiagnosticControlHaltOnSyntaxSend = "ON";
        private const string DiagnosticControlHaltOffSyntaxSend = "OFF";
        private const string DiagnosticControlHaltOnSyntaxReceived = "1";
        private const string DiagnosticControlHaltOffSyntaxReceived = "0";

        private const string ErrorMessageDiagnosticCheckingHaltMode = "Checking for the correct diagnostic halt mode.";

        public enum DiagnosticStoppedState { Stopped, NotStopped }

        private const string DiagnosticControlStoppedStateStoppedSyntax = "1";
        private const string DiagnosticControlStoppedStateNotStoppedSyntax = "0";

        public enum DiagnosticDiagnosticTemperature { Null, NonNull }

        private const string ErrorMessageDiagnosticCheckingStoppedState = "Checking for the correct diagnostic stopped state.";

        private const string ErrorMessageDiagnsoitcTemperatureResultStringIsNonNull = "Checking temperature result string for non-nulled";
        private const string ErrorMessageDiagnsoitcTemperatureResultStringIsNull = "Checking temperature result string for nulled";

        private const string ErrorMessageDiagnsoitcTimeResultStringIsNonNull = "Checking time result string for non-nulled";
        private const string ErrorMessageDiagnsoitcTimeResultStringIsNull = "Checking time result string for nulled";

        public enum DiagnosticSelectedContext { Subsystem, Area, Test }

        #region ACTive:MODE

        /// <summary>
        /// Sets the active mode of the AWG
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="mode">enum ActiveModeAs</param>
        public void SetTheActiveMode(IAWG awg, ActiveModeAs mode)
        {
            string command;
            switch (mode)
            {
                case ActiveModeAs.Calibration:
                    command = ActiveModeCalibrationSyntax;
                    break;
                case ActiveModeAs.Diagnostic:
                    command = ActiveModeDiagnosticSyntax;
                    break;
                default: // ActiveModeAs.Normal:
                    command = ActiveModeNormalSyntax;
                    break;
            }
            awg.DiagActiveMode(command);
        }
   
        /// <summary>
        /// Forces the AWG object to update's copy of the Active mode
        /// </summary>
        /// <param name="awg"></param>
        public void GetAWGActiveMode(IAWG awg)
        {
            awg.DiagActiveModeQuery();
        }
     
        /// <summary>
        /// Verifies the queried forms of the parameter for the Active Mode.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedValue"></param>
        public void ActiveModeShouldBe(IAWG awg, ActiveModeAs expectedValue)
        {
            string expectedSyntax;
            switch (expectedValue)
            {
                case ActiveModeAs.Calibration:
                    expectedSyntax = ActiveModeCalibrationSyntax;
                    break;
                case ActiveModeAs.Diagnostic:
                    expectedSyntax = ActiveModeDiagnosticSyntax;
                    break;
                case ActiveModeAs.Reset:
                    expectedSyntax = ActiveModeResetSyntax;
                    break;
                default: // ActiveModeAs.Normal
                    expectedSyntax = ActiveModeNormalSyntax;
                    break;
            }
            Assert.AreEqual(expectedSyntax, awg.DiagnosticActiveMode);
        }

        #endregion ACTive:MODE

        #region *TST

        //glennj 6/11/2013
        /// <summary>
        /// Using *TST? have the AWG to run POST and update it's copy of DiagPostResult
        /// </summary>
        /// <returns>POST status indicator</returns>
        public void RunScpiTstQueryAndSaveResults(IAWG awg)
        {
            awg.TstQuery();
        }

        //glennj 6/12/2013
        /// <summary>
        /// Verify the POST results
        /// </summary>
        /// <param name="awg"></param>
        public void PostResultsShouldBeEitherPassOrFail(IAWG awg)
        {
            string postRes = awg.DiagPostResult;

            switch (postRes) //Each outcome should have an assert so the test can pass or fail
            {
                case "-330":
                    Assert.AreEqual("-330", postRes);
                    break;
                case "0":
                    Assert.AreEqual("0", postRes);
                    break;
                default:
                    Assert.Fail("*TST? has returned an invalid response.");
                    break;
            }
        }

        #endregion *TST

        #region DIAGnostic:ABORt

        //glennj 6/12/2013
        /// <summary>
        /// Forces the AWG diagnostics to abort!
        /// </summary>
        /// <param name="awg"></param>
        public void AbortDiagnosticsOnAnAwg(IAWG awg)
        {
            awg.DiagAbort();
        }

        #endregion DIAGnostic:ABORt

        #region DIAGnostic:CATalog

        /// <summary>
        /// Gets a list of tests per subsystem and area.<para>
        /// Results are stored in the awg object per subsystem and area.</para><para>
        /// It is important to note that only one subsystem and area are</para><para>
        /// used at the same time.  To define a test, a subsystem and area</para><para>
        /// must be defined first.</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="subsystem"></param>
        /// <param name="area"></param>
        public void GetDiagnosticCatalogList(IAWG awg, string subsystem = "", string area = "")
        {
            awg.GetDiagCatalog(subsystem, area);
        }

        //glennj 3/19/2014
        /// <summary>
        /// Gets the Subsystem list based on preset Diagnostic type
        /// </summary>
        /// <param name="awg"></param>
        public void GetDiagSubsystemsList(IAWG awg)
        {
            GetDiagnosticCatalogList(awg);
        }

        //glennj 3/19/2014
        /// <summary>
        /// Gets an Area list based on preset Diagnostic type AND
        /// supplied Subsystem.  If a Subsystem name is not given
        /// then used the "subsystem context".
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="optionalSubsystem"></param>
        public void GetDiagAreaList(IAWG awg, string optionalSubsystem = "")
        {
            string useThisSubsystem = (optionalSubsystem != "") ? optionalSubsystem : awg.DiagnosticSubsystemSelected;
            GetDiagnosticCatalogList(awg, useThisSubsystem);
        }

        //glennj 3/19/2014
        /// <summary>
        /// Gets a Test list based on preset Diagnostic type AND
        /// supplied Area.  If a Area name is not given
        /// then used the "area context" and preselected subsystem
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="optionalArea"></param>
        public void GetDiagTestList(IAWG awg, string optionalArea = "")
        {
            string useThisArea = (optionalArea != "") ? optionalArea : awg.DiagnosticAreaSelected;
            GetDiagnosticCatalogList(awg, awg.DiagnosticSubsystemSelected, useThisArea);
        }

        //glennj 3/19/2014
        /// <summary>
        /// Using the given index, select the nth subsystem from the previously fetched subsystem list
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="subsystemIndex"></param>
        public void SelectDiagnosticSubsystemFromListUsingIndex(IAWG awg, string subsystemIndex)
        {
            awg.SelectDiagSubsystemFromPropertyList(subsystemIndex);
        }

        //glennj 3/19/2014
        /// <summary>
        /// Using the given index, select the nth area from the previously fetched area list
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="areaIndex"></param>
        public void SelectDiagnosticAreaFromListUsingIndex(IAWG awg, string areaIndex)
        {
            awg.SelectDiagAreaFromPropertyList(areaIndex);
        }

        //glennj 3/19/2014
        /// <summary>
        /// Using the given index, select the nth test from the previously fetched test list
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="testIndex"></param>
        public void SelectDiagnosticTestFromListUsingIndex(IAWG awg, string testIndex)
        {
            awg.SelectDiagTestFromPropertyList(testIndex);
        }

        #endregion DIAGnostic:CATalog

        #region DIAGnostic:COMMent

        /// <summary>
        /// Printf comment thats shows up in monitor trace but is a NO-OP to the AWG.
        /// Current usefulness is in doubt.  But its here and works.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="comment"></param>
        public void SendToCallMonitorOnTheAwg(IAWG awg, string comment)
        {
            awg.DiagComment(comment);
        }

        #endregion DIAGnostic:COMMent

        #region DIAGnostic:CONTrol:COUNt

        //glennj 6/12/2013
        /// <summary>
        /// Sets the initial number of loop count
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="setValueAs">NR1, Min, Max</param>
        /// <param name="setValue"></param>
        public void SetDiagnosticLoopCount(IAWG awg, DiagnosticLoopCountTypeAs setValueAs, string setValue = "")
        {
            var finalValue = setValue;
            switch (setValueAs)
            {
                case DiagnosticLoopCountTypeAs.Max:
                    finalValue = DiagnosticLoopCountMaxSyntax;
                    break;
                case DiagnosticLoopCountTypeAs.Min:
                    finalValue = DiagnosticLoopCountMinSyntax;
                    break;
            }
            awg.DiagControlCount(finalValue);
        }

        //glennj 6/12/2013
        /// <summary>
        /// Forces the AWG to update it's local copy of the inital loop count
        /// </summary>
        /// <param name="awg"></param>
        public void GetDiagnosticLoopCount(IAWG awg)
        {
            awg.DiagControlCountQuery();
        }

        //glennj 3/19/2014
        /// <summary>
        /// Tests the pre fetched loop count against a supplied expected
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedValue"></param>
        public void DiagnosticLoopCountShouldBe_(IAWG awg, string expectedValue)
        {
            Assert.AreEqual(expectedValue, awg.DiagLoopCount, "Checking the diagnostic loop count value");
        }

        #endregion DIAGnostic:CONTrol:COUNt

        #region DIAGnostic:CONTrol:HALT

        //glennj 6/11/2013
        /// <summary>
        /// Sets the halt value to what is specified in the setValue variable.
        /// </summary>
        /// <param name="awg">the AWG object</param>
        /// <param name="haltMode">set the boolean HALT variable.</param>
        public void SetDiagnosticHalt(IAWG awg, DiagnosticControlHaltMode haltMode)
        {
            string haltSyntax = (haltMode == DiagnosticControlHaltMode.On)
                                    ? DiagnosticControlHaltOnSyntaxSend
                                    : DiagnosticControlHaltOffSyntaxSend;
            awg.DiagHalt(haltSyntax);
        }

        //glennj 6/11/2013
        /// <summary>
        /// Forces the AWG to update it's local cal_halt state
        /// </summary>
        /// <param name="awg">the AWG object</param>
        public void GetDiagnosticHaltUpdate(IAWG awg)
        {
            awg.DiagHaltQuery();
        }

        //glennj 3/19/2014
        /// <summary>
        /// Tests for an expected halt state
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectMode"></param>
        public void DiagnosticHaltModeShouldBe(IAWG awg, DiagnosticControlHaltMode expectMode)
        {
            string expectedHaltSyntax = (expectMode == DiagnosticControlHaltMode.On)
                                    ? DiagnosticControlHaltOnSyntaxReceived
                                    : DiagnosticControlHaltOffSyntaxReceived;
            Assert.AreEqual(expectedHaltSyntax, awg.DiagnosticHalt, ErrorMessageDiagnosticCheckingHaltMode);
        }

        #endregion DIAGnostic:CONTrol:HALT

        #region DIAGnostic:CONTrol:LOOP

        //glennj 6/11/2013
        /// <summary>
        /// Sets the value of the calibration loop control
        /// </summary>
        /// <param name="awg">the AWG object</param>
        /// <param name="setMode"></param>
        public void SetDiagnosticLoopControl(IAWG awg, DiagnosticControlLoopMode setMode)
        {
            string setValue = "";
            switch (setMode)
            {
                case DiagnosticControlLoopMode.Once:
                    setValue = DiagnosticControlLoopOnceSyntaxSend;
                    break;
                case DiagnosticControlLoopMode.Continuous:
                    setValue = DiagnosticControlLoopContinuousSyntaxSend;
                    break;
                case DiagnosticControlLoopMode.Count:
                    setValue = DiagnosticControlLoopCountSyntaxSend;
                    break;
            }
            awg.DiagControlLoop(setValue);
        }

        //glennj 6/11/2013
        /// <summary>
        /// Forces the AWG to update it's local diag loop state
        /// </summary>
        /// <param name="awg">the AWG object</param>
        public void UpdateDiagnosticControlLoopCopy(IAWG awg)
        {
            awg.DiagControlLoopQuery();
        }

        //glennj 3/19/2014
        /// <summary>
        /// Tests for an expected loop mode of once, continuous or count
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedMode"></param>
        public void DiagnosticLoopControlShouldBe(IAWG awg, DiagnosticControlLoopMode expectedMode)
        {
            string expectedSyntax = "";
            switch (expectedMode)
            {
                case DiagnosticControlLoopMode.Once:
                    expectedSyntax = DiagnosticControlLoopOnceSyntaxReceived;
                    break;
                case DiagnosticControlLoopMode.Continuous:
                    expectedSyntax = DiagnosticControlLoopContinuousSyntaxReceived;
                    break;
                case DiagnosticControlLoopMode.Count:
                    expectedSyntax = DiagnosticControlLoopCountSyntaxReceived;
                    break;
            }

            const string possibleErrorMessage = "Checking the Diagnostic loop control.";
            Assert.AreEqual(expectedSyntax, awg.DiagLoopState, possibleErrorMessage);
        }

        #endregion Diagnostic:CONTrol:LOOP

        #region DIAGnostic:DATA?

        //glennj 3/19/2014
        /// <summary>
        /// Gets the results of the last executed tests for the
        /// diagnostic type of normal
        /// </summary>
        /// <param name="awg"></param>
        public void GetTheAWGDiagnosticsData(IAWG awg)
        {
            awg.DiagData();
        }

        //glennj 6/12/2013
        /// <summary>
        /// This tests the result of POST which should be 0 or -330
        /// </summary>
        /// <param name="awg"></param>
        public void AWGDiagnosticsDataShouldBeValid(IAWG awg)
        {
            if ((awg.DiagnositcData != "0") && (awg.DiagnositcData != "-330"))
            {
                Assert.Fail("Diagnostics data returned the invalid value of " + awg.DiagnositcData);
            }
        }

        #endregion DIAGnostic:DATA

        #region DIAGnostic[:IMMediate]

        //glennj 6/12/2013
        /// <summary>
        /// Forces the AWG to do diagnostics
        /// </summary>
        /// <param name="awg"></param>
        public void ExecuteImmediateDiagnostics(IAWG awg)
        {
            awg.DiagImmediate();
        }

        //glennj 6/12/2013
        /// <summary>
        /// Forces the AWG to do all of the Normal diagnostics and<para>
        /// saves a copy of the results.</para>
        /// </summary>
        /// <param name="awg"></param>
        public void ExecuteImmediateDiagnosticsAndGetResult(IAWG awg)
        {
            awg.DiagImmediateQuery();
        }

        //glennj 6/12/2013
        /// <summary>
        /// tests the immediate results
        /// </summary>
        /// <param name="awg"></param>
        public void AWGImmediateDiagnosticsShouldBeValid(IAWG awg)
        {
            if ((awg.DiagImmediateResult != "0") && (awg.DiagImmediateResult != "-330"))
            {
                Assert.Fail("Diagnostics Immediate returned the invalid value of " + awg.DiagImmediateResult);
            }
        }

        #endregion DIAGnostic[:IMMediate]

        #region DIAGnostic:DIMSec

        //glennj 3/19/2014
        /// <summary>
        /// Calls a thread delay in the specified AWG and returns
        /// a 1 when the delay is done.
        /// 
        /// Diagnostic and testing support
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="delayInMSec"></param>
        public void DiagDelayInMSec(IAWG awg, string delayInMSec)
        {
            uint currentSessionTimeout = awg.SessionTimeout;
            awg.SessionTimeout = (Convert.ToUInt32(delayInMSec) + 10000); // Add 1 sec for cushin
            awg.DiagDelayInMSec(delayInMSec);
            awg.SessionTimeout = currentSessionTimeout;
        }

        #endregion DIAGnostic:DIMSec

        #region DIAGnostic:MMODe?
        
        //glennj 3/19/2014
        /// <summary>
        /// Returns the status of the AWG if it was started in manufacturing more, or not.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="inOrOut">True is in manufacturing mode</param>
        public void AWGIsInManufacturingMode(IAWG awg, bool inOrOut)
        {
            string mode = awg.DiagManufacturingMode();

            if (inOrOut)    // If true, it is IN and mode should "1" for true
            {
                if (mode == "0")
                {
                    Assert.Inconclusive("AWG was not in manufacturing mode, test(s) skipped");
                }
            }
            else
            {
                if (mode == "1")
                {
                    Assert.Inconclusive("AWG was in manufacturing mode, test(s) skipped");
                }
            }
        }
        
        #endregion DIAGnostic:MMODe?

        #region DIAGnostic:LOG:DETails

        //glennj 6/12/2013
        /// <summary>
        /// Sets the amount of detail the log stores
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="setValue"></param>
        public void SetTheAWGDiagnosticsLogDetailState(IAWG awg, string setValue)
        {
            awg.DiagLogDetails(setValue);
        }

        //glennj 3/19/2014
        /// <summary>
        /// Tests the state of the log store details mode
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedValue"></param>
        public void AWGDiagnosticsLogDetailStateShouldBe(IAWG awg, string expectedValue)
        {
            Assert.AreEqual(expectedValue, awg.DiagLogDetail);
        }

        #endregion DIAGnostic:LOG:DETails

        #region DIAGnostic:LOG:FAILuresonly

        /// <summary>
        /// Controls what is saved to the log file
        /// </summary>
        /// <param name="awg">the AWG object</param>
        /// <param name="logFailures"></param>
        public void DiagnosticLogOnlyFailures(IAWG awg, DiagnosticLogFailures logFailures)
        {
            string failureSyntax = logFailures == DiagnosticLogFailures.On
                                       ? DiagnosticLogFailuresOnSyntaxSend
                                       : DiagnosticLogFailuresOffSyntaxSend;
            awg.DiagLogFailuresOnly(failureSyntax);
        }

        /// <summary>
        /// Forces the AWG to update its cal fail only flag<para>
        /// by quering the AWG</para>
        /// </summary>
        /// <param name="awg">the AWG object</param>
        public void GetTheDiagnosticLogFailureOnlyStatus(IAWG awg)
        {
            awg.DiagLogFailuresOnlyQuery();
        }

        /// <summary>
        /// Checks for expected state of Store Failures Only mode
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedMode"></param>
        public void CalLogShouldBeSetToFailuresOnlyMode(IAWG awg, DiagnosticLogFailures expectedMode)
        {
            string expectedSyntax = expectedMode == DiagnosticLogFailures.On
                                        ? DiagnosticLogFailuresOnSyntaxReceived
                                        : DiagnosticLogFailuresOffSyntaxReceived;
            const string possibleErrorMessage = "Checking Diagnostic Log Failures Only state";
            Assert.AreEqual(expectedSyntax, awg.DiagLogFail, possibleErrorMessage);
        }

        #endregion DIAGnostic:LOG:FAILuresonly

        #region DIAGnostic:LOOPs

        /// <summary>
        /// Gets the last count for completed diagnostic loops.
        /// </summary>
        /// <param name="awg"></param>
        public void GetCurrentDiagnosticLoopCount(IAWG awg)
        {
            awg.GetDiagLoops();
        }

        /// <summary>
        /// Checks for the expected completed loop count
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedLoopCount"></param>
        public void CurrentDiagnosticLoopCountShouldBe(IAWG awg, string expectedLoopCount)
        {
            const string possibleErrorMessage = "Checking for an expected diagnostic completed loop count.";
            Assert.AreEqual(expectedLoopCount, awg.DiagLoops, possibleErrorMessage);
        }

        #endregion DIAGnostic:LOOPs

        #region DIAGnostic:RESult?

        //glennj 6/12/2013
        /// <summary>
        /// Forces the AWG to update it's local copy of test results for the given xpath
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="optionalSubsystem"></param>
        /// <param name="optionalArea"></param>
        /// <param name="optionalTest"></param>
        public void GetTheDiagnosticResultFromTheAWGForPath(IAWG awg, string optionalSubsystem = "", string optionalArea = "", string optionalTest = "")
        {
            awg.DiagResultQuery( optionalSubsystem, optionalArea, optionalTest);
        }

        /// <summary>
        /// Uses predefined context names for subsystem, area and test.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="basedOnSubsystem">If true, used context</param>
        /// <param name="basedOnArea">If true, used context, requires subsystem</param>
        /// <param name="basedOnTest">If true, used context, requires area and subsystem</param>
        public void GetDiagnosticResultBasedOnContext(IAWG awg,
                                                        bool basedOnSubsystem = false,
                                                        bool basedOnArea = false,
                                                        bool basedOnTest = false)
        {
            string optionalSubsystem = "";
            string optionalArea = "";
            string optionalTest = "";

            if (basedOnSubsystem)
            {
                optionalSubsystem = awg.DiagnosticSubsystemSelected;
                if (basedOnArea)
                {
                    optionalArea = awg.DiagnosticAreaSelected;
                    if (basedOnTest)
                    {
                        optionalTest = awg.DiagnosticTestSelected;
                    }
                }
            }

            awg.DiagResultQuery(optionalSubsystem, optionalArea, optionalTest);         
        }

        /// <summary>
        /// Test supplied text string to be contained or not in the results
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="text">The text to check to see if it is or not contained in results</param>
        /// <param name="contained">True means text should be contained in results</param>
        public void ResultsForTestSelectedForAllShouldContain(IAWG awg, string text, bool contained)
        {
            string possibleError;
            if (contained)
            {
                possibleError = "Missing text of " + text;
                Assert.IsTrue(awg.DiagResult.Contains(text), possibleError);
            }
            else
            {
                possibleError = "Contained text of " + text;
                Assert.IsFalse(awg.DiagResult.Contains(text), possibleError);
            }
        }

        /// <summary>
        /// Test for previously created context subsystem, area or test to be contained or not.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="context">Subsystem, Area or Test</param>
        /// <param name="contained">True means text should be contained in results</param>
        public void ResultsForTestSelectedBySubsystemAreaTestShouldContain(IAWG awg, DiagnosticSelectedContext context, bool contained)
        {
            string possibleError;
            if (contained)
            {
                switch (context)
                {
                    case DiagnosticSelectedContext.Area:
                        possibleError = "Missing Area name of " + awg.DiagnosticAreaSelected;
                        Assert.IsTrue(awg.DiagResult.Contains(awg.DiagnosticAreaSelected), possibleError);
                        break;
                    case DiagnosticSelectedContext.Subsystem:
                        possibleError = "Missing Subsystem name of " + awg.DiagnosticSubsystemSelected;
                        Assert.IsTrue(awg.DiagResult.Contains(awg.DiagnosticSubsystemSelected), possibleError);
                        break;
                    default: //DiagnosticSelectedContext.Test
                        possibleError = "Missing Test name of " + awg.DiagnosticTestSelected;
                        Assert.IsTrue(awg.DiagResult.Contains(awg.DiagnosticTestSelected), possibleError);
                        break;
                }
            }
            else
            {
                switch (context)
                {
                    case DiagnosticSelectedContext.Area:
                        possibleError = "Contained Area name of " + awg.DiagnosticAreaSelected;
                        Assert.IsFalse(awg.DiagResult.Contains(awg.DiagnosticAreaSelected), possibleError);
                        break;
                    case DiagnosticSelectedContext.Subsystem:
                        possibleError = "Contained Subsystem name of " + awg.DiagnosticSubsystemSelected;
                        Assert.IsFalse(awg.DiagResult.Contains(awg.DiagnosticSubsystemSelected), possibleError);
                        break;
                    default: //DiagnosticSelectedContext.Test
                        possibleError = "Contained Test name of " + awg.DiagnosticTestSelected;
                        Assert.IsFalse(awg.DiagResult.Contains(awg.DiagnosticTestSelected), possibleError);
                        break;
                }
            }
        }

        public void DiagnosticResultShouldHaveThePassCountOf(IAWG awg, int p0)
        {
            var separator = new[] { "(", ")" };
            var temp = awg.DiagResult.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            // The result can have a Pass count
            if (temp.Length >= 6)
            {
                // P is 4, and Count is 5, index wise
                Assert.AreEqual(p0, Convert.ToInt32(temp[5]));
            }
            else
            {
                Assert.Fail("Diagnostics results returned value was " + awg.DiagResult);
            }
        }

        public void DiagnosticResultShouldHaveTheFailCountOf(IAWG awg, int p0)
        {
            var separator = new[] { "(", ")" };
            var temp = awg.DiagResult.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            // The result can have a Fail count
            if (temp.Length >= 8)
            {
                // P is 6, and Count is 7, index wise
                Assert.AreEqual(p0, Convert.ToInt32(temp[7]));
            }
            else
            {
                Assert.Fail("Diagnostics results returned value was " + awg.DiagResult);
            }
        }

        #endregion DIAGnostic:RESult?

        #region DIAGnostic:LOG:CLEar

        // glennj 6/12/2013
        /// <summary>
        /// Given an awg, the awg's diagnostic log is cleared
        /// </summary>
        /// <param name="awg">The specified %AWG</param>
        public void ClearTheAWGDiagnosticsLog(IAWG awg)
        {
            awg.DiagLogClear();
        }

        //glennj 3/17/2014
        /// <summary>
        /// 
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="trueOrFalse"></param>
        public void DiagnosticLogShouldBeEmpty(IAWG awg, bool trueOrFalse)
        {
            if (trueOrFalse) // if true
            {
                Assert.AreEqual("\"\"", awg.DiagLog);
            }
            else
            {
                Assert.AreNotEqual("\"\"", awg.DiagLog);
            }
        }

        #endregion DIAGnostic:LOG:CLEar

        #region DIAGnostic:LOG?

        // glennj 6/12/2013
        /// <summary>
        /// Forces the AWG to update it's diagnostics' log
        /// </summary>
        /// <param name="awg">The specified %AWG</param>
        public void GetTheDiagnosticsLogFromAWG(IAWG awg)
        {
            awg.DiagLogQuery();
        }

        #endregion DIAGnostic:LOG?

        #region DIAGnostic:LOG:DETails

        /// <summary>
        /// Sets the amount of details the log saves
        /// </summary>
        /// <param name="awg">the AWG object</param>
        /// <param name="setValue"></param>
        public void SetTheDiagnosticLogToDetailedMode(IAWG awg, DiagnosticLogDetails setValue)
        {
            string correctSyntax = setValue == DiagnosticLogDetails.On
                                ? DiagnosticLogDetailsOnSyntaxSend
                                : DiagnosticLogDetailsOffSyntaxSend;
            awg.DiagLogDetails(correctSyntax);
        }

        /// <summary>
        /// Forces the AWG to update its copy of the cal log details flag
        /// </summary>
        /// <param name="awg">the AWG object</param>
        public void GetTheDiagnosticLogDetailStatus(IAWG awg)
        {
            awg.DiagLogDetailsQuery();
        }

        /// <summary>
        /// Looks for the expected state
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedState"></param>
        public void DiagLogDetailedModeShouldBe(IAWG awg, DiagnosticLogDetails expectedState)
        {
            string expectedSyntax = expectedState == DiagnosticLogDetails.On
                                        ? DiagnosticLogDetailsOnSyntaxReceived
                                        : DiagnosticLogDetailsOffSyntaxReceived;
            const string possibleErrorMessage = "Checking for the state of the detail mode for the Diagnostic Log";
            Assert.AreEqual(expectedSyntax, awg.DiagLogDetail, possibleErrorMessage);
        }

        #endregion DIAGnostic:LOG:DETails

        #region DIAGnostic:RUNNing?

        /// <summary>
        /// Update the Diagnostic's running state
        /// </summary>
        /// <param name="awg"></param>
        public void GetDiagnosticRunningState(IAWG awg)
        {
            awg.GetDiagRunningState();
        }

        /// <summary>
        /// Comparing to the updated running state
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="runningState"></param>
        public void DiagnosticRunningStateShouldBe(IAWG awg, DiagnosticRunningState runningState )
        {
            if (runningState == DiagnosticRunningState.Stopped)
            {
                Assert.AreEqual("\"\"", awg.DiagRunningState);
            }
            else
            {
                Assert.AreNotEqual("\"\"", awg.DiagRunningState);
            }
        }

        #endregion DIAGnostic:RUNNing?

        #region DIAGnostic:RESult:TEMPerature?

        /// <summary>
        /// Gets the temperature for the specified subsystem, area or test.
        /// If no subsystem is supplied, then its the overall temperature of the AWG
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="optionalSubsystem">Which subsystem</param>
        /// <param name="optionalArea">Which area, requires subsystem</param>
        /// <param name="optionalTest">Which test, requires area and subsystem</param>
        public void GetAWGDiagnosticTemperature(IAWG awg, string optionalSubsystem = "", string optionalArea = "", string optionalTest = "")
        {
            awg.DiagResultTempQuery(optionalSubsystem, optionalArea, optionalTest);
        }

        /// <summary>
        /// Checking for null and non-nulled returned strings for diagnostic temperature
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="nulled"></param>
        public void DiagnosticDiagnosticTemperatureShouldBeNulled(IAWG awg, bool nulled)
        {
            if (nulled)
            {
                Assert.AreEqual("\"\"", awg.DiagTemp, ErrorMessageDiagnsoitcTemperatureResultStringIsNonNull);
            }
            else
            {
                Assert.AreNotEqual("\"\"", awg.DiagTemp, ErrorMessageDiagnsoitcTemperatureResultStringIsNull);
            }
        }

        public void DiagnosticTemperatureResultShouldContain(IAWG awg, string containedValue, bool shouldContain)
        {
            if (shouldContain)
            {
                string possibleErrorMessage = "Diagnostic temperature result " + awg.DiagTemp + " did not contain " +
                                              containedValue;
                bool containsValue = awg.DiagTemp.Contains(containedValue);
                Assert.AreEqual(true, containsValue, possibleErrorMessage);
            }
            else
            {
                string possibleErrorMessage = "Diagnostic temperature result " + awg.DiagTemp + " did contain " +
                                              containedValue;
                bool containsValue = awg.DiagTemp.Contains(containedValue);
                Assert.AreEqual(false, containsValue, possibleErrorMessage);
            }
        }

        #endregion DIAGnostic:RESult:TEMPerature?

        #region DIAGnostic:RESult:TIME?

        /// <summary>
        /// Gets the time for the specified subsystem, area or test.
        /// If no subsystem is supplied, then its the overall time of the AWG
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="optionalSubsystem">Which subsystem</param>
        /// <param name="optionalArea">Which area, requires subsystem</param>
        /// <param name="optionalTest">Which test, requires area and subsystem</param>
        public void GetAWGDiagnosticTime(IAWG awg, string optionalSubsystem = "", string optionalArea = "", string optionalTest = "")
        {
            awg.DiagResultTimeQuery(optionalSubsystem, optionalArea, optionalTest);
        }

        /// <summary>
        /// Checking for null and non-nulled returned strings for diagnostic time
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="nulled"></param>
        public void DiagnosticDiagnosticTimeShouldBeNulled(IAWG awg, bool nulled)
        {
            if (nulled)
            {
                Assert.AreEqual("\"\"", awg.DiagTemp, ErrorMessageDiagnsoitcTimeResultStringIsNonNull);
            }
            else
            {
                Assert.AreNotEqual("\"\"", awg.DiagTemp, ErrorMessageDiagnsoitcTimeResultStringIsNull);
            }
        }

        public void DiagnosticTimeResultShouldContain(IAWG awg, string containedValue, bool shouldContain)
        {
            if (shouldContain)
            {
                string possibleErrorMessage = "Diagnostic time result " + awg.DiagTime + " did not contain " +
                                              containedValue;
                bool containsValue = awg.DiagTime.Contains(containedValue);
                Assert.AreEqual(true, containsValue, possibleErrorMessage);
            }
            else
            {
                string possibleErrorMessage = "Diagnostic time result " + awg.DiagTime + " did contain " +
                                              containedValue;
                bool containsValue = awg.DiagTime.Contains(containedValue);
                Assert.AreEqual(false, containsValue, possibleErrorMessage);
            }
        }

        #endregion DIAGnostic:RESult:TIME?

        #region DIAGnostic:SELect/UNSelect

        /// <summary>
        /// Special.  This is used in conjunction with testing selection for any set of lists.
        /// It does not have hardcoded names.  It builds selections based on indexes.
        /// </summary>
        /// <param name="awg"></param>
        public void UsingPresetContextSelectTest(IAWG awg)
        {
            SelectTheDiagnosticTestOnAWG(awg, true, awg.DiagnosticSubsystemSelected, awg.DiagnosticAreaSelected, awg.DiagnosticTestSelected);
        }

        //glennj 6/12/2013
        /// <summary>
        /// Based on supplied bool value, this selects all or unselects all
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="select">True selects all</param>
        public void SelectAllDiagnosticTestsOnAWG(IAWG awg, bool select)
        {
            if (select)
            {
                awg.DiagSelect(SelectAllSyntax);
            }
            else
            {
                awg.DiagUnselect(SelectAllSyntax);
            }
        }

        //glennj 6/12/2013
        /// <summary>
        /// Selects (or unselects) a subsystem, an area or a test based on supplied parameters.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="select"></param>
        /// <param name="requiredSubsystem"></param>
        /// <param name="optionalArea"></param>
        /// <param name="optionalTest"></param>
        public void SelectTheDiagnosticTestOnAWG(IAWG awg, bool select, string requiredSubsystem, string optionalArea = "", string optionalTest = "")
        {
            string deQuotedSubsystem = _utils.Dequotify(requiredSubsystem);
            string deQuotedArea = _utils.Dequotify(optionalArea);
            string deQuotedTest = _utils.Dequotify(optionalTest);
            if (select)
            {
                awg.DiagSelect(deQuotedSubsystem, deQuotedArea, deQuotedTest);
            }
            else
            {
                awg.DiagUnselect(deQuotedSubsystem, deQuotedArea, deQuotedTest);
            }
        }

        /// <summary>
        /// Verifies that a test is selected or not.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="requiredSubsystem"></param>
        /// <param name="requiredArea"></param>
        /// <param name="requiredTest"></param>
        /// <param name="selectForTrue"></param>
        public void DiagnosticTestShouldBeSelectedOnAWG(IAWG awg, string requiredSubsystem, string requiredArea, string requiredTest, bool selectForTrue)
        {
            const string falseStr = "0"; // '"' + "0" + '"';
            const string trueStr = "1"; // '"' + "1" + '"';

            string deQuotedSubsystem = _utils.Dequotify(requiredSubsystem);
            string deQuotedArea = _utils.Dequotify(requiredArea);
            string deQuotedTest = _utils.Dequotify(requiredTest);

            string responseStr = awg.DiagSelectVerifyQuery(deQuotedSubsystem, deQuotedArea, deQuotedTest);

            // Test first for a valid response
            if ((responseStr != trueStr) && (responseStr != falseStr))
            {
                Assert.Fail("Response for DIAG:SEL:VER? is invalid: " + responseStr);
            }

            bool isSelected = (responseStr == trueStr);

            if (selectForTrue)
            {
                Assert.IsTrue(isSelected, "Expected test to be selected for " + requiredSubsystem + "," + requiredArea + "," + requiredTest);
            }
            else
            {
                Assert.IsFalse(isSelected, "Expected test to be not selected for " + requiredSubsystem + "," + requiredArea + "," + requiredTest);
            }
        }

        #endregion DIAGnostic::SELect/UNSelect

        #region DIAGnostic:STARt

        //glennj 6/12/2013
        /// <summary>
        /// Starts the AWG diagnostics
        /// </summary>
        /// <param name="awg"></param>
        public void StartDiagnosticsOnAnAwg(IAWG awg)
        {
            awg.DiagStart();
        }

        #endregion DIAGnostic:STARt

        #region DIAGnostic:STOP

        //glennj 6/12/2013
        /// <summary>
        /// Stops the AWG's diagnostics
        /// </summary>
        /// <param name="awg"></param>
        public void StopDiagnosticsOnAnAwg(IAWG awg)
        {
            awg.DiagStop();
        }

        #endregion DIAGnostic:STOP

        #region DIAGnostic:STOP:STATe?

        //glennj 6/12/2013
        /// <summary>
        /// Forces the AWG to update a local copy of stop state
        /// </summary>
        /// <param name="awg"></param>
        public void GetDiagnosticStopState(IAWG awg)
        {
            awg.DiagStopStateQuery();
        }

        public void DiagnosticStopStateShouldBe(IAWG awg, DiagnosticStoppedState expectedState)
        {
            string expectSyntax = (expectedState == DiagnosticStoppedState.Stopped)
                                      ? DiagnosticControlStoppedStateStoppedSyntax
                                      : DiagnosticControlStoppedStateNotStoppedSyntax;
            const string possibleErrorMessage = ErrorMessageDiagnosticCheckingStoppedState;
            Assert.AreEqual(expectSyntax, awg.DiagStopState, possibleErrorMessage);
        }

        #endregion DIAGnostic:STOP:STATe?

        #region DIAGnostic:TYPE

        /// <summary>
        /// Change the diag type (aka normal or post)
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="type"></param>
        public void SendAsTheDiagnosticsTestModeOnAnAWG(IAWG awg, DiagnosticType type)
        {
            string typeSyntax;
            switch (type)
            {
                case DiagnosticType.Engineering:
                    typeSyntax = DiagnosticTypeEngineeringSyntax;
                    break;
                case DiagnosticType.Manufacturing:
                    typeSyntax = DiagnosticTypeManufacturingSyntax;
                    break;
                case DiagnosticType.ORT:
                    typeSyntax = DiagnosticTypeORTSyntax;
                    break;
                case DiagnosticType.POST:
                    typeSyntax = DiagnosticTypePOSTSyntax;
                    break;
                case DiagnosticType.RTC:
                    typeSyntax = DiagnosticTypeRTCSyntax;
                    break;
                default: // DiagnosticType.Normal:
                    typeSyntax = DiagnosticTypeNormalSyntax;
                    break;
            }
            awg.DiagType(typeSyntax);
        }

        //glennj 6/12/2013
        /// <summary>
        /// Forces the AWG object to update it's local copy of the diagnostic type
        /// </summary>
        /// <param name="awg"></param>
        public void GetTheDiagnosticTypeFromAWG(IAWG awg)
        {
            awg.DiagTypeQuery();
        }

        public void DiagnosticTypeFromAWGShouldBeType(IAWG awg, DiagnosticType type)
        {
            string expectedTypeSyntax;
            switch (type)
            {
                case DiagnosticType.Engineering:
                    expectedTypeSyntax = DiagnosticTypeEngineeringSyntax;
                    break;
                case DiagnosticType.Manufacturing:
                    expectedTypeSyntax = DiagnosticTypeManufacturingSyntax;
                    break;
                case DiagnosticType.ORT:
                    expectedTypeSyntax = DiagnosticTypeORTSyntax;
                    break;
                case DiagnosticType.POST:
                    expectedTypeSyntax = DiagnosticTypePOSTSyntax;
                    break;
                case DiagnosticType.RTC:
                    expectedTypeSyntax = DiagnosticTypeRTCSyntax;
                    break;
                default: // DiagnosticType.Normal:
                    expectedTypeSyntax = DiagnosticTypeNormalSyntax;
                    break;
            }

            const string possibleErrorMessage = "Checking the copy for the diagnostic type.";
            Assert.AreEqual(expectedTypeSyntax, awg.DiagnosticType, possibleErrorMessage);
        }

        #endregion DIAGnostic:TYPE

        #region DIAGnostic:TYPE:CATalog?

        /// <summary>
        /// Forces the AWG to update its copy of the diagnostic catalog
        /// </summary>
        /// <param name="awg">the AWG object</param>
        public void GetTheAwgDiagnosticTypeCatalog(IAWG awg)
        {
            awg.DiagTypeCategory();
        }

        public void DiagnosticTypeListValidation(IAWG awg)
        {
            // First make sure that it is not null
            if (awg.DiagnosticTypeCatalog == "")
            {
                const string errorMessage = "List for diagnostic types was empty";
                Assert.Fail(errorMessage);
            }
            // In order to be considered valid for this step, it should contain at least "NORM"
            if (!awg.DiagnosticTypeCatalog.Contains("NORM"))
            {
                string errorMessage = "Diagnostic type of NORM was not found in the list: " + awg.DiagnosticTypeCatalog;
                Assert.Fail(errorMessage);
            }
            // In order to be considered valid for this step, it should contain at least "POST"
            if (!awg.DiagnosticTypeCatalog.Contains("POST"))
            {
                string errorMessage = "Diagnostic type of POST was not found in the list: " + awg.DiagnosticTypeCatalog;
                Assert.Fail(errorMessage);
            }
        }

        /// <summary>
        /// Using the property, , that should be updated using<para>
        /// DIAGnostic:TYPE:CATalog?, a list of types is passed</para><para>
        /// to check to see if they are present.</para>
        /// </summary>
        /// <param name="awg">The specific awg</param>
        /// <param name="listOfTypes">CSV of types</param>
        public void DiagnosticTypeCatalogFromAWG1ShouldContain(IAWG awg, string listOfTypes)
        {
            var stringSeparators = new[] { "," };
            var calType = listOfTypes.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

            foreach (var s in calType)
            {
                var containsType = awg.DiagnosticTypeCatalog.Contains(s);
                if (!containsType)
                {
                    Assert.IsFalse(containsType, "Diagnostic catalog is not valid");
                }
            }
        }

        #endregion DIAGnostic:TYPE:CATalog?

    }
}