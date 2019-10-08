//==========================================================================
// AwgCalibrationGroupLow_steps.cs
// This file contains the low-order PI step definitions for the AWG PI Calibration Group commands. 
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
//                         
//==========================================================================
using TechTalk.SpecFlow;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains the PI step definitions for the %AWG PI Calibration Group commands.

    /// Generally the steps are set, get and should be operations.  The step sole responsibility
    /// is to make sure the correct %AWG object is used and that parameters such as channel,
    /// markers and clock references are correct for the %AWG object.
    /// 
    /// \ingroup highpi pisteps 
    /// 
    /// </summary> 
    [Binding] //Very important! This entry needs to be made in each step definition file.
    public class AwgCalibrationSteps
    {
        private readonly AwgCalibrationGroup _awgCalibrationGroup = new AwgCalibrationGroup();

        #region *CAL?

        //Jhowells 6-13-12
        /// <summary>
        /// Runs the short form of internal calibration of the instrument and returns status
        ///
        /// *CAL? (query only)
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
          \calibration\verbatim
        [When(@"I send the required SCPI calibration query for AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I send the required SCPI calibration query for AWG ([1-4])")]
        public void RunInternalCalibrationShortFormAndGetResult(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.RunInternalCalibrationShortFormAndGetResult(awg);
        }

        //zkoppert 7/9/12
        /// <summary>
        /// Verifies a valid calibration status has been returned.
        ///
        /// CAL? (query only)
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \calibration\verbatim
        [Then(@"the calibration results should be either pass or fail for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the calibration results should be either pass or fail for AWG ([1-4])")]
        public void ThenTheCalibrationsResultsShouldBeEitherPassOrFail(string awgNumber)
        {
            //Initialize
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.CalibrationsResultsShouldBeEitherPassOrFail(awg);
        }

        #endregion

        #region CALibration:ABORt
        //glennj 9/26/12
        /// <summary>
        /// Aborts calibration the current test ASAP.
        ///
        /// CAL:ABORt
        /// </summary>
        /*!
            \calibration \verbatim
        [When(@"I abort the calibration for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I abort the calibration for AWG ([1-4])")]
        public void WhenIAbortCalibration(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.AbortCalibration(awg);
        }
        #endregion CALibration:ABORt

        #region CALibration[:ALL]?

        //Jhowells 6-13-12
        /// <summary>
        /// Runs the internal calibration of the instrument
        ///
        /// Query form is equivalent to *CAL? in effect.
        /// 
        /// CALibration[:ALL]?
        /// </summary>
        /*!
          \calibration\verbatim
        [When(@"I run the internal calibration for AWG ([1-4])")]
          \endverbatim 
        */
        [When(@"I run the internal calibration for AWG ([1-4])")]
        public void RunInternalCalibration(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.RunInternalCalibration(awg);
        }

        //Jhowells 6-13-12
        /// <summary>
        /// Runs the internal calibration of the instrument and returns status
        ///
        /// Query form is equivalent to *CAL? in effect.
        /// 
        /// CALibration[:ALL]?
        /// </summary>
        /*!
          \calibration\verbatim
        [When(@"I run the internal calibration and get the result for AWG ([1-4])")]
          \endverbatim 
        */
        [When(@"I run the internal calibration and get the result for AWG ([1-4])")]
        public void RunInternalCalibrationAndGetResult(string awgNumber)
        {
            //Initialize
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.RunInternalCalibrationAndGetResult(awg);
        }

        //glennj 12/2/2013 added step
        /// <summary>
        /// Compares the calibration results from the awg with the expected value
        /// 
        /// CALibration[:ALL]?
        /// </summary>
        /// <param name="awgNumber"></param>
        /// <param name="containedValue">The expected feel good text</param>
        /*!
            \calibration\verbatim
        [Then(@"the calibration result should contain ""(.*)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the calibration result should contain ""(.*)"" for AWG ([1-4])")]
        public void ThenCalibrationResultShouldContain(string containedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.CalibrationResultShouldContain(awg, containedValue);
        }

        #endregion CALibration[:ALL]?

        #region CALibration:CATalog?

        //zkoppert 7/10/12
        /// <summary>
        /// Gets the calibration procedures list from current calibration type. 
        /// 
        /// CALibration:CATalog?
        /// </summary>
        /*!
            \calibration\verbatim
        [When(@"I get the list of calibration procedures for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the list of calibration procedures for AWG ([1-4])")]
        public void WhenIGetTheCalibrationProceduresList(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.GetTheCalibrationProceduresList(awg);
        }

        //glennj 2/5/2014
        /// <summary>
        /// Verifies the calibration procedures list from specified AWG. 
        /// 
        /// CALibration:CATalog?
        /// </summary>
        /*!
            \calibration\verbatim
        [Then(@"the list of calibration procedures should not be empty for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the list of calibration procedures should not be empty for AWG ([1-4])")]
        public void ThenTheCalibrationProceduresListFromAWG1ShouldBeValid(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.CalibrationProceduresListFromAWG1ShouldBeValid(awg);
        }

        #endregion CALibration:CATalog?

        #region CALibration:CONTrol:HALT

        //glennj 06/05/2013
        ///  <summary>
        ///  Sets the calibration halt value to on.
        ///  
        ///  This can only be set in manufacturing mode.
        /// 
        ///  CAL:CONT:HALT[?]
        ///  </summary>
        /// <param name="awgNumber"></param>
        /*!
            \calibration \verbatim 
        [When(@"I set the calibration halt control to on for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I set the calibration halt control to on for AWG ([1-4])")]
        public void SetTheCalibrationHaltToOn(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.SetCalibrationHalt(awg, AwgCalibrationGroup.CalibrationControlHaltMode.On);
        }

        //glennj 06/05/2013
        ///  <summary>
        ///  Sets the calibration halt value to off.
        /// 
        ///  CAL:CONT:HALT[?]
        ///  </summary>
        /// <param name="awgNumber"></param>
        /*!
            \calibration \verbatim 
        [When(@"I set the calibration halt control to off for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I set the calibration halt control to off for AWG ([1-4])")]
        public void SetTheCalibrationHaltToOff(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.SetCalibrationHalt(awg, AwgCalibrationGroup.CalibrationControlHaltMode.Off);
        }

        //zkoppert 7/12/12
        /// <summary>
        /// Gets the calibration halt value.
        ///
        /// CAL:CONT:HALT[?]
        /// </summary>
        /*!
            \calibration \verbatim 
        [When(@"I get the calibration halt control for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I get the calibration halt control for AWG ([1-4])")]
        public void WhenIGetTheCalibrationHaltValue(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.GetCalibrationHaltUpdate(awg);
        }

        //glennj 2/28/2014
        ///  <summary>
        ///  Tests the calibration halt mode to be on
        /// 
        ///  CAL:CONT:HALT[?]
        ///  </summary>
        /// <param name="awgNumber"></param>
        /*!
            \calibration \verbatim 
        [Then(@"the calibration halt control should be on for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the calibration halt control should be on for AWG ([1-4])")]
        public void CalibrationHaltValueShouldBeOn(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.CalibrationHaltModeShouldBe(awg, AwgCalibrationGroup.CalibrationControlHaltMode.On);
        }

        //glennj 2/28/2014
        ///  <summary>
        ///  Tests the calibration halt mode to be off
        /// 
        ///  CAL:CONT:HALT[?]
        ///  </summary>
        /// <param name="awgNumber"></param>
        /*!
            \calibration \verbatim 
        [Then(@"the calibration halt control should be off for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the calibration halt control should be off for AWG ([1-4])")]
        public void CalibrationHaltValueShouldBeOff(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.CalibrationHaltModeShouldBe(awg, AwgCalibrationGroup.CalibrationControlHaltMode.Off);
        }

        #endregion CALibration:CONTrol:HALT

        #region CALibration:CONTrol:LOOP

        //glennj 2/10/2014
        ///  <summary>
        ///  Sets the calibration looping mode to loop once
        ///  
        ///  This can only be set in manufacturing mode.
        /// 
        ///  CAL:CONT:LOOP[?]
        ///  </summary>
        /// <param name="awgNumber"></param>
        /*!
            \calibration \verbatim 
        [When(@"I set the calibration loop control to loop once for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I set the calibration loop control to loop once for AWG ([1-4])")]
        public void SetTheCalibrationLoopControlToLoopOnce(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.SetCalibrationLoopControl(awg, AwgCalibrationGroup.CalibrationControlLoopMode.Once);
        }

        //glennj 2/10/2014
        ///  <summary>
        ///  Sets the calibration looping mode to loop continuously
        ///  
        ///  This can only be set in manufacturing mode.
        /// 
        ///  CAL:CONT:LOOP[?]
        ///  </summary>
        /// <param name="awgNumber"></param>
        /*!
            \calibration \verbatim 
        [When(@"I set the calibration loop control to loop continuous for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I set the calibration loop control to loop continuous for AWG ([1-4])")]
        public void SetTheCalibrationLoopControlToLoopContnuous(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.SetCalibrationLoopControl(awg, AwgCalibrationGroup.CalibrationControlLoopMode.Continuous);
        }

        //glennj 2/10/2014
        ///  <summary>
        ///  Sets the calibration looping mode to loop for a number of counts
        ///  
        ///  This can only be set in manufacturing mode.
        /// 
        ///  CAL:CONT:LOOP[?]
        ///  </summary>
        /// <param name="awgNumber"></param>
        /*!
            \calibration \verbatim 
        [When(@"I set the calibration loop control to loop for counts for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I set the calibration loop control to loop for counts for AWG ([1-4])")]
        public void SetTheCalibrationLoopControlToLoopCount(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.SetCalibrationLoopControl(awg, AwgCalibrationGroup.CalibrationControlLoopMode.Count);
        }

        //glennj 2/10/2014
        /// <summary>
        /// Gets the calibration loop value.
        ///
        /// CAL:CONT:LOOP[?]
        /// </summary>
        /*!
            \calibration \verbatim 
        [When(@"I get the calibration loop control for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I get the calibration loop control for AWG ([1-4])")]
        public void WhenIGetTheCurrentCalibrationLoopSetting(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.UpdateCalibrationControlLoopCopy(awg);
        }

        //glennj 2/28/2014
        ///  <summary>
        ///  Tests the calibration loop mode to be loop once
        /// 
        ///  CAL:CONT:LOOP[?]
        ///  </summary>
        /// <param name="awgNumber"></param>
        /*!
            \calibration \verbatim 
        [Then(@"the calibration loop control should be loop once for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the calibration loop control should be loop once for AWG ([1-4])")]
        public void CurrentCalibrationLoopSettingShouldBeOnce(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.CalibrationLoopControlShouldBe(awg, AwgCalibrationGroup.CalibrationControlLoopMode.Once);
        }

        //glennj 2/28/2014
        ///  <summary>
        ///  Tests the calibration loop mode to be loop continuous
        /// 
        ///  CAL:CONT:LOOP[?]
        ///  </summary>
        /// <param name="awgNumber"></param>
        /*!
            \calibration \verbatim 
        [Then(@"the calibration loop control should be loop continuous for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the calibration loop control should be loop continuous for AWG ([1-4])")]
        public void CurrentCalibrationLoopSettingShouldBeContinuous(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.CalibrationLoopControlShouldBe(awg, AwgCalibrationGroup.CalibrationControlLoopMode.Continuous);
        }

        //glennj 2/28/2014
        ///  <summary>
        ///  Tests the calibration loop mode to be loop for counts
        /// 
        ///  CAL:CONT:LOOP[?]
        ///  </summary>
        /// <param name="awgNumber"></param>
        /*!
            \calibration \verbatim 
        [Then(@"the calibration loop control should be loop for counts for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the calibration loop control should be loop for counts for AWG ([1-4])")]
        public void CurrentCalibrationLoopSettingShouldBeCount(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.CalibrationLoopControlShouldBe(awg, AwgCalibrationGroup.CalibrationControlLoopMode.Count);
        }

        #endregion CALibration:CONTrol:LOOP

        #region CALibration:CONTrol:COUNt

        //glennj 2/28/2014
        /// <summary>
        /// Sets the calibration loop count to the specified value.
        ///  
        ///  This can only be set in manufacturing mode.
        ///
        /// CAL:CONT:COUN[?]
        /// </summary>
        /// <param name="setCount">Value that you want the loop count set to</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \calibration \verbatim 
        [When(@"I set the calibration loop count to (\d+) for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I set the calibration loop count to (\d+) for AWG ([1-4])")]
        public void WhenISetTheCalibrationLoopCountTo(string setCount, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.AwgCalLoopCount(awg, AwgCalibrationGroup.CalibrationLoopCountTypeAs.Nr1, setCount);
        }

        //glennj 2/28/2014
        /// <summary>
        /// Sets the calibration loop count to the max!
        ///  
        ///  This can only be set in manufacturing mode.
        ///
        /// CAL:CONT:COUN[?]
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \calibration \verbatim 
        [When(@"I set the calibration loop count to maximum for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I set the calibration loop count to maximum for AWG ([1-4])")]
        public void WhenISetTheCalibrationLoopCountToMax(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.AwgCalLoopCount(awg, AwgCalibrationGroup.CalibrationLoopCountTypeAs.Max);
        }

        //glennj 2/28/2014
        /// <summary>
        /// Sets the calibration loop count to the min!
        ///  
        ///  This can only be set in manufacturing mode.
        ///
        /// CAL:CONT:COUN[?]
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \calibration \verbatim 
        [When(@"I set the calibration loop count to minimum for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I set the calibration loop count to minimum for AWG ([1-4])")]
        public void WhenISetTheCalibrationLoopCountToMin(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.AwgCalLoopCount(awg, AwgCalibrationGroup.CalibrationLoopCountTypeAs.Min);
        }

        //zkoppert 7/12/12
        /// <summary>
        /// Gets the calibration loop count value.
        ///
        /// CAL:CONT:COUN[?]
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \calibration \verbatim 
        [When(@"I get the calibration loop count for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I get the calibration loop count for AWG ([1-4])")]
        public void WhenIGetTheCalibrationLoopCountValue(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.UpdateCalibrationLoopCount(awg);
        }

        //zkoppert 7/12/12
        /// <summary>
        /// Check the calibration loop count value.
        ///
        /// CAL:CONT:COUN[?]
        /// </summary>
        /// <param name="expectedCount">Value expected for loop count</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \calibration \verbatim 
        [Then(@"the calibration loop count should be (.+) for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the calibration loop count should be (.+) for AWG ([1-4])")]
        public void ThenTheCalibrationLoopCountValueShouldBe(string expectedCount, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.CalibrationLoopCountShouldBe(awg, expectedCount);
        }

        #endregion CALibration:CONTrol:COUNt

        #region CALibration:DATA:FACTory

        //jhowells 7/13/12
        //glennj 9/20/2013
        /// <summary>
        /// Gets the calibration factory data for subsystem ""(.+)"" for AWG ([1-4])")]
        /// 
        /// CAL:DATA:FACTory?
        /// </summary>
        /*!
            \calibration\verbatim
        [When(@"I get the factory calibration data for subsystem ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the factory calibration data for subsystem ""(.+)"" for AWG ([1-4])")]
        public void GetTheAWGFactoryCalibrationDataForSubsystem(string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.GetTheAWGFactoryCalibrationDataForTheXpath(awg, requiredSubsystem);
        }

        //glennj 2/28/2014
        /// <summary>
        /// Gets the calibration factory data for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
        /// 
        /// CAL:DATA:FACTory?
        /// </summary>
        /*!
            \calibration\verbatim
        [When(@"I get the factory calibration data for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the factory calibration data for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
        public void GetTheAWGFactoryCalibrationDataForTheArea(string requiredArea, string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.GetTheAWGFactoryCalibrationDataForTheXpath(awg, requiredSubsystem, requiredArea);
        }

        //glennj 2/28/2014
        /// <summary>
        /// Gets the calibration factory data for a procedure for an area for a subsystem for an AWG
        /// 
        /// CAL:DATA:FACTory?
        /// </summary>
        /*!
            \calibration\verbatim
        [When(@"I get the factory calibration data for procedure ""(.+)"" for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the factory calibration data for procedure ""(.+)"" for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
        public void GetTheAWGFactoryCalibrationDataForTheProcedure(string requiredProcedure, string requiredArea, string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.GetTheAWGFactoryCalibrationDataForTheXpath(awg, requiredSubsystem, requiredArea, requiredProcedure);
        }

        //glennj 2/28/2014
        /// <summary>
        /// Verify the calibration factory data is in a valid XML format.
        /// 
        /// Does not validate the contents.
        /// 
        /// CAL:DATA:FACTory?
        /// </summary>
        /*!
            \calibration\verbatim
        [Then(@"the factory calibration data should be valid for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the factory calibration data should be valid for AWG ([1-4])")]
        public void FactoryCalibrationDataShouldBeValid(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.CalibrationDataFromAWGShouldBeValid(awg, AwgCalibrationGroup.CalibrationDataType.Factory);
        }

        //glennj 3/7/2014
        /// <summary>
        /// Saves the calibration factory data to a file for AWG ([1-4])")]
        /// 
        /// CAL:DATA:FACTory?
        /// </summary>
        /*!
            \calibration\verbatim
        [When(@"I save the factory calibration data to the file ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I save the factory calibration data to the file ""(.+)"" for AWG ([1-4])")]
        public void SaveTheAWGFactoryCalibrationDataForSubsystem(string fileName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.SaveTheCalibrationData(awg, AwgCalibrationGroup.CalibrationDataType.Factory, fileName);
        }

        #endregion CALibration:DATA:FACTory

        #region CALibration:DATA:USER

        //jhowells 1/9/13
        //glennj 2/28/2014
        /// <summary>
        /// Gets the calibration user data for a subsystem for an AWG
        /// 
        /// CAL:DATA:USER?
        /// </summary>
        /// <param name="requiredSubsystem"></param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \system\verbatim
        [When(@"I get the user calibration data for subsystem ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the user calibration data for subsystem ""(.+)"" for AWG ([1-4])")]
        public void GetTheAWGUserCalibrationDataForSubsystem(string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.GetTheAWGUserCalibrationDataForTheXpath(awg, requiredSubsystem);
        }

        //glennj 2/28/2014
        /// <summary>
        /// Gets the calibration user data for an area for a subsystem for an AWG
        /// 
        /// CAL:DATA:USER?
        /// </summary>
        /// <param name="requiredArea"></param>
        /// <param name="requiredSubsystem"></param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \system\verbatim
        [When(@"I get the user calibration data for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the user calibration data for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
        public void GetTheAWGUserCalibrationDataForTheArea(string requiredArea, string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.GetTheAWGUserCalibrationDataForTheXpath(awg, requiredSubsystem, requiredArea);
        }

        //glennj 2/28/2014
        /// <summary>
        /// Gets the calibration user data for a procedure for an area for a subsystem for an AWG
        /// 
        /// CAL:DATA:USER?
        /// </summary>
        /// <param name="requiredArea"></param>
        /// <param name="requiredSubsystem"></param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /// <param name="requiredProcedure"></param>
        /*!
            \system\verbatim
        [When(@"I get the user calibration data for procedure ""(.+)"" for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the user calibration data for procedure ""(.+)"" for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
        public void GetTheAWGUserCalibrationDataForTheProcedure(string requiredProcedure, string requiredArea, string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.GetTheAWGUserCalibrationDataForTheXpath(awg, requiredSubsystem, requiredArea, requiredProcedure);
        }

        //jhowells 7/13/12
        //glennj 2/10/2014
        /// <summary>
        /// Verifies that calibration factory data from the given AWG is valid xml.
        /// 
        /// CAL:DATA:USER?
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \calibration\verbatim
        [Then(@"the user calibration data should be valid for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the user calibration data should be valid for AWG ([1-4])")]
        public void UserCalibrationDataShouldBeValid(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.CalibrationDataFromAWGShouldBeValid(awg, AwgCalibrationGroup.CalibrationDataType.User);
        }

        //glennj 10/12/12
        /// <summary>
        /// Sets the calibration user data of the AWG.
        /// 
        /// This uses whatever the AWG object has as xml set of constants.@n
        /// CAL:DATA:USER
        /// </summary>
        /// <param name="requiredArea"></param>
        /// <param name="requiredSubsystem"></param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \calibration\verbatim
        [When(@"I set the calibration user data on channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the user calibration data for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
        public void WhenISetCalUserDataOnChannel(string requiredArea, string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.SetTheAWGUserCalibrationData(awg, requiredSubsystem, requiredArea);
        }

        //glennj 3/7/2014
        /// <summary>
        /// Saves the calibration user data to a file for AWG ([1-4])")]
        /// 
        /// CAL:DATA:USER?
        /// </summary>
        /*!
            \calibration\verbatim
        [When(@"I save the user calibration data to the file ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I save the user calibration data to the file ""(.+)"" for AWG ([1-4])")]
        public void SaveTheAWGUserCalibrationData(string fileName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.SaveTheCalibrationData(awg, AwgCalibrationGroup.CalibrationDataType.User, fileName);
        }

        //glennj 3/7/2014
        /// <summary>
        /// Saves the calibration user data to a file for AWG ([1-4])")]
        /// 
        /// CAL:DATA:FACTory?
        /// </summary>
        /*!
            \calibration\verbatim
        [When(@"I save the user calibration data to the file ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I load the user calibration data from the file ""(.+)"" for AWG ([1-4])")]
        public void LoadTheAWGUserCalibrationData(string fileName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.LoadTheCalibrationData(awg, fileName);
        }

        #endregion CALibration:DATA:USER

        #region CALibration:LOG

        //zkoppert 8/7/12
        //glennj 2/7/2014
        /// <summary>
        /// Gets the calibration log and stores it to the awg instance
        /// 
        /// CALibration:LOG
        /// </summary>
        /*!
            \calibration\verbatim
        [When(@"I get the calibration log for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the calibration log for AWG ([1-4])")]
        public void WhenIGetTheAWGCalibrationLog(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.GetTheAWGCalibrationLog(awg);
        }

        //zkoppert 8/7/12
        //glenn 2/7/2014
        /// <summary>
        /// Verifies the calibration result is empty.
        /// 
        /// CALibration:LOG
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \calibration\verbatim
        [Then(@"the calibration log should be empty for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the calibration log should be empty for AWG ([1-4])")]
        public void ThenTheCalLogResultValueShouldBeEmptyOnAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.CalibrationLogShouldBeEmpty(awg, true);
        }

        //glenn 2/28/2014
        /// <summary>
        /// Verifies the calibration result is not empty.
        /// 
        /// CALibration:LOG
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \calibration\verbatim
        [Then(@"the calibration log should be empty for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the calibration log should not be empty for AWG ([1-4])")]
        public void ThenTheCalLogResultValueShouldNotBeEmptyOnAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.CalibrationLogShouldBeEmpty(awg, false);
        }

        #endregion CALibration:LOG

        #region CALibration:LOG:CLEar

        //zkoppert 8/7/12
        //glennj 2/7/2014
        /// <summary>
        /// Clears the Calibration Log of all current data.
        /// 
        /// CALibration:LOG:CLEar
        /// </summary>
        /*!
            \calibration\verbatim
        [When(@"I clear the calibration log for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I clear the calibration log for AWG ([1-4])")]
        public void WhenIClearTheAWGCalibrationLog(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.ClearTheAWGCalibrationLog(awg);
        }

        #endregion CALibration:LOG:CLEar

        #region CALibration:LOG:DETails

        // Unknown 01/01/01
        //glennj 2/7/2014
        /// <summary>
        /// Sets the detailed mode to on for the cal log
        /// 
        /// CALibration:LOG:DETails
        /// 
        /// Not currently being used it would appear
        /// </summary>
        /*!
            \calibration \verbatim 
        [When(@"I set the detailed mode to on for the calibration log AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I set the detailed mode to on for the calibration log AWG ([1-4])")]
        public void SetTheCalibrationLogDetailedModeToOn(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.SetTheCalibrationLogToDetailedMode(awg, AwgCalibrationGroup.CalibrationLogDetails.On);
        }

        //glennj 2/7/2014
        /// <summary>
        /// Sets the detailed mode to off for the cal log
        /// 
        /// CALibration:LOG:DETails
        /// 
        /// Not currently being used it would appear
        /// </summary>
        /*!
            \calibration \verbatim 
        [When(@"I set the detailed mode to off for the calibration log AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I set the detailed mode to off for the calibration log AWG ([1-4])")]
        public void SetTheCalibrationLogDetailedModeToOff(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.SetTheCalibrationLogToDetailedMode(awg, AwgCalibrationGroup.CalibrationLogDetails.Off);
        }

        //glennj 2/7/2014
        /// <summary>
        /// Gets the calibration detail status
        /// </summary>
        /*!
            \calibration \verbatim 
        [When(@"I get the detailed mode for the calibration log AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I get the detailed mode for the calibration log AWG ([1-4])")]
        public void WhenIGetTheCalibrationLogDetailStatus(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.GetTheCalibrationLogDetailStatus(awg);
        }

        // Unknown 01/01/01
        //glennj 2/7/2014
        /// <summary>
        /// Verifies that detailed mode is on for the calibration log for an AWG
        /// 
        /// CALibration:LOG:DETails
        /// </summary>
        /// <param name="awgNumber">Valid AWG logical number in a range 1 to 4</param>
        /*!
            \calibration \verbatim 
        [Then(@"the detailed mode should be on for the calibration log AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the detailed mode should be on for the calibration log AWG ([1-4])")]
        public void CalLogDetailedModeShouldBeOn(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.CalLogDetailedModeShouldBe(awg, AwgCalibrationGroup.CalibrationLogDetails.On);
        }

        // Unknown 01/01/01
        //glennj 2/7/2014
        /// <summary>
        /// Verifies that detailed mode is off for the calibration log for an AWG
        /// 
        /// CALibration:LOG:DETails
        /// </summary>
        /// <param name="awgNumber">Valid AWG logical number in a range 1 to 4</param>
        /*!
            \calibration \verbatim 
        [Then(@"the detailed mode should be off for the calibration log AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the detailed mode should be off for the calibration log AWG ([1-4])")]
        public void CalLogDetailedModeShouldBeOff(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.CalLogDetailedModeShouldBe(awg, AwgCalibrationGroup.CalibrationLogDetails.Off);
        }

        #endregion CALibration:LOG:DETails

        #region CALibration:LOG:FAILuresonly

        // Unknown 01/01/01
        //glennj 2/7/2014
        /// <summary>
        /// Sets the log only failures text to the calibration log
        /// 
        /// CALibration:LOG:FAILureonly
        /// </summary>
        /*!
            \calibration \verbatim 
        [When(@"I set the failure only mode to on for the calibration log for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I set the failure only mode to on for the calibration log for AWG ([1-4])")]
        public void WhenISetTheCalibrationLogToFailuresOnlyToOn(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.CalibrationLogOnlyFailures(awg, AwgCalibrationGroup.CalibrationLogFailures.On);
        }

        // Unknown 01/01/01
        /// <summary>
        /// Sets the cal log failures Only flag to 0
        /// 
        /// CALibration:LOG:FAILuresonly
        /// </summary>
        /*!
            \calibration \verbatim 
        [When(@"I set the failure only mode to off for the calibration log for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I set the failure only mode to off for the calibration log for AWG ([1-4])")]
        public void WhenISetTheCalibrationLogToFailuresOnlyToOff(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.CalibrationLogOnlyFailures(awg, AwgCalibrationGroup.CalibrationLogFailures.Off);
        }

        // Unknown 01/01/01
        /// <summary>
        /// Gets the cal log failures only flag 
        /// </summary>
        /*!
            \calibration \verbatim 
        [When(@"I get the failure only mode for the calibration log for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I get the failure only mode for the calibration log for AWG ([1-4])")]
        public void WhenIGetTheCalibrationLogFailureOnlyStatus(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.GetTheCalibrationLogFailureOnlyStatus(awg);
        }
        // Unknown 01/01/01
        /// <summary>
        /// Verifies that the cal log failures only flag is set to 1
        /// </summary>
        /*!
            \calibration \verbatim 
        [Then(@"the failure only mode should be on for the calibration log for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the failure only mode should be on for the calibration log for AWG ([1-4])")]
        public void TheCalLogFailuresOnlyModeShouldBeOn(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.CalLogShouldBeSetToFailuresOnlyMode(awg, AwgCalibrationGroup.CalibrationLogFailures.On);
        }

        // Unknown 01/01/01
        /// <summary>
        /// Verifies that the cal log failures only flag is set to 0
        /// </summary>
        /*!
            \calibration \verbatim 
        [Then(@"the failure only mode should be off for the calibration log for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the failure only mode should be off for the calibration log for AWG ([1-4])")]
        public void TheCalLogFailuresOnlyModeShouldBeOff(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.CalLogShouldBeSetToFailuresOnlyMode(awg, AwgCalibrationGroup.CalibrationLogFailures.Off);
        }
        #endregion CALibration:LOG:FAILuresonly

        #region CALibration:LOOP?

        //zkoppert 7/12/12
        //glennj 2/10/2014
        /// <summary>
        /// Gets the number of calibration loops completed.
        ///
        /// CAL:LOOP?
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \calibration \verbatim 
        [When(@"I get the number of calibration loops that have completed for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I get the number of calibration loops that have completed for AWG ([1-4])")]
        public void WhenIGetTheNumberOfCalibrationLoopsThatHasCompleted(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.GetTheNumberOfCalibrationLoopsThatHasCompleted(awg);
        }

        //zkoppert 7/12/12
        //glennj 2/10/2014
        /// <summary>
        /// Compares the number of calibration loops completed to the expected value.
        ///
        /// CAL:LOOP?
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /// <param name="expectedLoopCount">Expected number of calibration loops completed</param>
        /*!
            \calibration \verbatim 
        [Then(@"the number of calibration loops that have completed should be (.d) for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the number of calibration loops that have completed should be (.d) for AWG ([1-4])")]
        public void ThenTheNumberOfCalibrationLoopsThatHasCompletedShouldBe(string expectedLoopCount, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.NumberOfCalibrationLoopsCompletedShouldBe(awg, expectedLoopCount);
        }

        #endregion CALibration:LOOP

        #region CALibration:TYPE

        //Unknown 01/01/01
        //glennj 2/28/2014
        /// <summary>
        /// Sets the calibration type to external. 
        /// 
        /// CAL:TYPE[?]
        /// </summary>
        /// <param name="awgNumber">Valid AWG logical number in a range 1 to 4</param>
        /*!
            \calibration\verbatim
        [When(@"I set the calibration type to external for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the calibration type to external for AWG ([1-4])")]
        public void WhenISetTheCalibrationTypeToTypeExternal(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.SetTheCalibrationTypeToType(awg, AwgCalibrationGroup.CalibrationType.External);
        }

        //glennj 2/28/2014
        /// <summary>
        /// Sets the calibration type to internal. 
        /// 
        /// CAL:TYPE[?]
        /// </summary>
        /// <param name="awgNumber">Valid AWG logical number in a range 1 to 4</param>
        /*!
            \calibration\verbatim
        [When(@"I set the calibration type to internal for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the calibration type to internal for AWG ([1-4])")]
        public void WhenISetTheCalibrationTypeToTypeInternal(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.SetTheCalibrationTypeToType(awg, AwgCalibrationGroup.CalibrationType.Internal);
        }

        //zkoppert 7/10/12
        /// <summary>
        /// Gets the calibration type which should be external or internal. 
        /// 
        /// CAL:TYPE[?]
        /// </summary>
        /*!
            \calibration\verbatim
        [When(@"I get the calibration type for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the calibration type for AWG ([1-4])")]
        public void WhenIGetTheCalibrationType(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.GetTheCalibrationType(awg);
        }

        //zkoppert 7/10/12
        /// <summary>
        /// Tests the calibration type to be internal.
        /// 
        /// CAL:TYPE[?]
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \calibration\verbatim
        [Then(@"the calibration type should be internal for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the calibration type should be internal for AWG ([1-4])")]
        public void TheCalibrationTypeShouldBeInternal(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.CalibrationTypeOnAWGShouldBe(awg, AwgCalibrationGroup.CalibrationType.Internal);
        }

        //glennj 2/28/2014
        /// <summary>
        /// Tests the calibration type to be external.
        /// 
        /// CAL:TYPE[?]
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \calibration\verbatim
        [Then(@"the calibration type should be external for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the calibration type should be external for AWG ([1-4])")]
        public void TheCalibrationTypeShouldBeExternal(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.CalibrationTypeOnAWGShouldBe(awg, AwgCalibrationGroup.CalibrationType.External);
        }

        #endregion CALibration:TYPE

        #region CALibration:TYPE:CATalog?

        //glennj 2/5/2014
        /// <summary>
        /// Gets the calibration type catalog from the AWG and stores it to awg.calibration_catalog. 
        /// 
        /// CAL:TYPE:CATalog?
        /// </summary>
        /*!
            \calibration\verbatim
        [When(@"I get the list of calibration types for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the list of calibration types for AWG ([1-4])")]
        public void WhenIGetTheAwgCalibrationTypeCatalog(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.GetTheAwgCalibrationTypeCatalog(awg);
        }

        //glennj 2/5/2014
        /// <summary>
        /// Semi verifies the calibration type catalogs
        /// 
        /// CAL:TYPE:CATalog?
        /// </summary>
        /*!
            \calibration\verbatim
        [Then(@"the list of calibration types should be valid for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the list of calibration types should be valid for AWG ([1-4])")]
        public void ThenTheCalibrationTypeCatalogFromAWG1ShouldBeValid(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.CalibrationTypeListValidation(awg);
        }

        #endregion CALibration:TYPE:CATalog?

        #region CALibration:RESTore

        // Currently not doing any steps to "restore"

        #endregion CALibration:RESTore

        #region CALibration:RESult?

        //zkoppert 7/13/12
        /// <summary>
        /// Forces the AWG object to update calibration results for the overall
        ///
        /// CAL:RES?
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
          \calibration \verbatim 
        [When(@"I get the calibration result for AWG ([1-4])")]
          \endverbatim
        */
        [When(@"I get the calibration result for AWG ([1-4])")]
        public void WhenIGetTheOverallCalibrationResults(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.GetTheCalibrationResult(awg);
        }

        //glennj 3/3/2014
        ///  <summary>
        ///  Forces the AWG object to update calibration results for a subsystem
        /// 
        ///  CAL:RES?
        ///  </summary>
        /// <param name="subsystem"></param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
          \calibration \verbatim 
        [When(@"I get the calibration result for subsystem ""(.+)"" for AWG ([1-4])")]
          \endverbatim
        */
        [When(@"I get the calibration result for subsystem ""(.+)"" for AWG ([1-4])")]
        public void WhenIGetTheCalibrationResultForSubsystem(string subsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.GetTheCalibrationResult(awg, subsystem);
        }

        //glennj 3/3/2014
        ///  <summary>
        ///  Forces the AWG object to update calibration results for an area for a subsystem
        /// 
        ///  CAL:RES?
        ///  </summary>
        /// <param name="area"></param>
        /// <param name="subsystem"></param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
          \calibration \verbatim 
        [When(@"I get the calibration result for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
          \endverbatim
        */
        [When(@"I get the calibration result for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
        public void WhenIGetTheCalibrationResultForArea(string area, string subsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.GetTheCalibrationResult(awg, subsystem, area);
        }

        //glennj 3/3/2014
        ///  <summary>
        ///  Forces the AWG object to update calibration results for a procedure for an area for a subsystem
        /// 
        ///  CAL:RES?
        ///  </summary>
        /// <param name="procedure"></param>
        /// <param name="area"></param>
        /// <param name="subsystem"></param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
          \calibration \verbatim 
        [When(@"I get the calibration result for procedure ""(.+)"" for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
          \endverbatim
        */
        [When(@"I get the calibration result for procedure ""(.+)"" for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
        public void WhenIGetTheCalibrationResultForProcedure(string procedure, string area, string subsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.GetTheCalibrationResult(awg, subsystem, area, procedure);
        }

        //zkoppert 7/16/12
        //glennj 2/10/2014
        /// <summary>
        /// Verifies the calibration result is not empty.
        /// 
        /// CAL:RES?
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \calibration\verbatim
        [Then(@"the cal log result value should not be empty on AWG([1-4])")]
            \endverbatim 
        */
        [Then(@"the calibration result should not be empty for AWG ([1-4])")]
        public void ThenTheCalLogResultValueShouldNotBeEmpty(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.CalibrationResultShouldNotBeEmpty(awg);
        }

        #endregion CALibration:RESult?

        #region CALibration:RESult:TEMPerature

        //zkoppert 7/13/12
        ///  <summary>
        ///  Gets the calibration temperature for a subsystem
        /// 
        ///  CAL:RES:TEMP?
        ///  </summary>
        /// <param name="requiredSubsystem"></param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
          \calibration \verbatim 
        [When(@"I get the calibration temperature from AWG([1-4]) from (.+)")]
          \endverbatim
        */
        [When(@"I get the temperature for subsystem ""(.+)"" for AWG ([1-4])")]
        public void GetThetemperatureProcedure(string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.GetTemperatureForProcedure(awg, requiredSubsystem);
        }

        ///  <summary>
        ///  Gets the calibration temperature for an area
        /// 
        ///  CAL:RES:TEMP?
        ///  </summary>
        /// <param name="requiredArea"></param>
        /// <param name="requiredSubsystem"></param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
          \calibration \verbatim 
        [When(@"I get the calibration temperature from AWG([1-4]) from (.+)")]
          \endverbatim
        */
        [When(@"I get the temperature for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
        public void GetThetemperatureProcedure(string requiredArea, string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.GetTemperatureForProcedure(awg, requiredSubsystem, requiredArea);
        }

        ///  <summary>
        ///  Gets the calibration temperature for a procedure
        /// 
        ///  CAL:RES:TEMP?
        ///  </summary>
        /// <param name="requiredPrecedure"></param>
        /// <param name="requiredArea"></param>
        /// <param name="requiredSubsystem"></param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
          \calibration \verbatim 
        [When(@"I get the calibration temperature from AWG([1-4]) from (.+)")]
          \endverbatim
        */
        [When(@"I get the temperature for procedure ""(.+)"" for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
        public void GetThetemperatureProcedure(string requiredPrecedure, string requiredArea, string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.GetTemperatureForProcedure(awg, requiredSubsystem, requiredArea, requiredPrecedure);
        }

        //zkoppert 7/13/12
        /// <summary>
        /// Checks the calibration temperature and verifies its not empty.
        ///
        /// CAL:RES:TEMP?
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
          \calibration \verbatim 
        [Then(@"the temperature for the procedure should not be empty for AWG ([1-4])")]
          \endverbatim
        */
        [Then(@"the temperature for the procedure should not be empty for AWG ([1-4])")]
        public void ThenTheCalibrationTemperatureOnAWGShouldNotBeEmpty(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.CalibrationResultTemperatureShouldNotBeEmpty(awg);
        }
        #endregion CALibration:RESult:TEMPerature

        #region CALibration:RESult:TIME

        //zkoppert 7/13/12
        ///  <summary>
        ///  Gets the calibration time for a subsystem
        /// 
        ///  CAL:RES:TIME?
        ///  </summary>
        /// <param name="requiredSubsystem"></param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
          \calibration \verbatim 
        [When(@"I get the time for subsystem ""(.+)"" for AWG ([1-4])")]
          \endverbatim
        */
        [When(@"I get the time for subsystem ""(.+)"" for AWG ([1-4])")]
        public void GetTheTimeForProcedure(string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.GetTimeForProcedure(awg, requiredSubsystem);
        }

        //glennj 2/28/2014
        ///  <summary>
        ///  Gets the calibration time for an area
        /// 
        ///  CAL:RES:TIME?
        ///  </summary>
        /// <param name="requiredArea"></param>
        /// <param name="requiredSubsystem"></param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
          \calibration \verbatim 
        [When(@"I get the time for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
          \endverbatim
        */
        [When(@"I get the time for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
        public void GetTheTimeForProcedure(string requiredArea, string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.GetTimeForProcedure(awg, requiredSubsystem, requiredArea);
        }

        //glennj 2/28/2014
        ///  <summary>
        ///  Gets the calibration time for a procedure
        /// 
        ///  CAL:RES:TIME?
        ///  </summary>
        /// <param name="requiredPrecedure"></param>
        /// <param name="requiredArea"></param>
        /// <param name="requiredSubsystem"></param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
          \calibration \verbatim 
        [When(@"I get the time for procedure ""(.+)"" for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
          \endverbatim
        */
        [When(@"I get the time for procedure ""(.+)"" for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
        public void GetTheTimeForProcedure(string requiredPrecedure, string requiredArea, string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.GetTimeForProcedure(awg, requiredSubsystem, requiredArea, requiredPrecedure);
        }

        //zkoppert 7/13/12
        /// <summary>
        /// Checks the calibration time and verifies its not empty.
        ///
        /// CAL:RES:TIME?
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
          \calibration \verbatim 
        [Then(@"the time for the procedure should not be empty for AWG ([1-4])")]
          \endverbatim
        */
        [Then(@"the time for the procedure should not be empty for AWG ([1-4])")]
        public void ThenTheCalibrationTimeOnAWGShouldNotBeEmpty(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.CalibrationResultTimeShouldNotBeEmpty(awg);
        }
        #endregion CALibration:RESult:TIME

        #region CALibration:RUNNing?

        //zkoppert 7/11/12
        /// <summary>
        /// Verifies that calibration is currently running
        ///
        /// CAL:RUNNing?
        /// </summary>
        /*!
            \calibration \verbatim
        [Then(@"the calibration should be running for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the calibration should be running for AWG ([1-4])")]
        public void ThenTheCalibrationShouldBeRunning(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.CalShouldBeRunning(awg);
        }

        #endregion CALibration:RUNNing?

        #region CALibration:SELect

        //zkoppert 7/11/12
        /// <summary>
        /// Selects all the calibration procedures for the  current calibration type. 
        /// 
        /// CALibration:SELect "ALL"
        /// </summary>
        /*!
            \calibration \verbatim
        [When(@"I select all calibration procedures for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I select all calibration procedures for AWG ([1-4])")]
        public void WhenISelectAllCalibrationTests(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.SelectAllCal(awg);
        }

        //zkoppert 7/11/12
        //glennj 2/6/2014
        ///  <summary>
        ///  Selects the specified calibration subsystem.
        /// 
        ///  CALibration:UNSelect test
        ///  </summary>
        /// <param name="requiredSubsystem"></param>
        /// <param name="awgNumber"></param>
        /*!
            \calibration \verbatim 
        [When(@"I select the calibration procedures for subsystem ""(.+)"" for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I select the calibration procedures for subsystem ""(.+)"" for AWG ([1-4])")]
        public void WhenISelectTheCalibrationSubsystemProcedures(string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.SelectCal(awg, requiredSubsystem);
        }

        //glennj 2/6/2014
        ///  <summary>
        ///  Selects the specified calibration area.
        /// 
        ///  CALibration:SELect test
        ///  </summary>
        /// <param name="requiredArea"></param>
        /// <param name="requiredSubsystem"></param>
        /// <param name="awgNumber"></param>
        /*!
            \calibration \verbatim
        [When(@"I select the calibration procedures for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I select the calibration procedures for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
        public void WhenISelectTheCalibrationTest(string requiredArea, string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.SelectCal(awg, requiredSubsystem, requiredArea);
        }

        //glennj 2/6/2014
        ///  <summary>
        ///  Selects the specified calibration procedure.
        /// 
        ///  CALibration:SELect test
        ///  </summary>
        /// <param name="requiredPrecedure"></param>
        /// <param name="requiredArea"></param>
        /// <param name="requiredSubsystem"></param>
        /// <param name="awgNumber"></param>
        /*!
            \calibration \verbatim
        [When(@"I select the calibration procedure ""(.+)"" for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I select the calibration procedure ""(.+)"" for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
        public void WhenISelectTheCalibrationProcedure(string requiredPrecedure, string requiredArea, string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.SelectCal(awg, requiredSubsystem, requiredArea, requiredPrecedure);
        }


        #endregion CALibration:SELect

        #region CALibration:SELect:VERify?

        //zkoppert 7/11/12
        /// <summary>
        /// Veriy that the specified calibration procedure is selected.
        /// 
        /// CALibration:SELect:VERify?
        /// </summary>
        /// <param name="requiredPrecedure"></param>
        /// <param name="requiredArea"></param>
        /// <param name="requiredSubsystem"></param>
        /// <param name="awgNumber"></param>
        /*!
            \calibration \verbatim 
        [Then(@"the AWG calibration (.+) should be selected")]
            \endverbatim
        */
        [Then(@"the calibration procedure should be selected for procedure ""(.+)"" for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
        public void ThenTheCalibrationTestShouldBeSelected(string requiredPrecedure, string requiredArea, string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.CalShouldBeSelected(awg, requiredSubsystem, requiredArea, requiredPrecedure);
        }

        //zkoppert 7/11/12
        /// <summary>
        /// Compares the specified calibration test in the specified category context to expected value.
        /// 
        /// Expects the test to be unselected.
        /// </summary>
        /// <param name="requiredPrecedure"></param>
        /// <param name="requiredArea"></param>
        /// <param name="requiredSubsystem"></param>
        /// <param name="awgNumber"></param>
        /*!
            \calibration \verbatim 
        [Then(@"the AWG calibration (.+) should be unselected")]
            \endverbatim
        */
        [Then(@"the calibration procedure should not be selected for procedure ""(.+)"" for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
        public void ThenTheCalibrationTestShouldBeUnselected(string requiredPrecedure, string requiredArea, string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.CalShouldNotBeSelected(awg, requiredSubsystem, requiredArea, requiredPrecedure);
        }

        #endregion CALibration:SELect:VERify?

        #region CALibration:UNSelect

        //zkoppert 7/10/12
        /// <summary>
        /// Unselects all the calibration procedures list from current calibration type. 
        /// 
        /// CALibration:UNSelect "ALL"
        /// </summary>
        /*!
            \calibration \verbatim
        [When(@"I unselect all AWG calibration tests")]
            \endverbatim 
        */
        [When(@"I unselect all calibration procedures for AWG ([1-4])")]
        public void WhenIUnselectAllCalibrationTests(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.UnselectAllCal(awg);
        }

        //zkoppert 7/11/12
        //glennj 2/6/2014
        ///  <summary>
        ///  Unselects the specified calibration subsystem.
        /// 
        ///  CALibration:UNSelect test
        ///  </summary>
        /// <param name="requiredSubsystem"></param>
        /// <param name="awgNumber"></param>
        /*!
            \calibration \verbatim
        [When(@"I unselect the calibration procedure ""(.+)"" for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I unselect the calibration procedures for subsystem ""(.+)"" for AWG ([1-4])")]
        public void WhenIUnselectTheCalibrationSubsystemProcedures(string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.UnselectCal(awg, requiredSubsystem);
        }

        //glennj 2/6/2014
        ///  <summary>
        ///  Unselects the specified calibration area.
        /// 
        ///  CALibration:UNSelect test
        ///  </summary>
        /// <param name="requiredArea"></param>
        /// <param name="requiredSubsystem"></param>
        /// <param name="awgNumber"></param>
        /*!
            \calibration \verbatim
        [When(@"I unselect the calibration procedure ""(.+)"" for ""(.+)"" for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I unselect the calibration procedures for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
        public void WhenIUnselectTheCalibrationAreaProcedures(string requiredArea, string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.UnselectCal(awg, requiredSubsystem, requiredArea);
        }

        //glennj 2/6/2014
        ///  <summary>
        ///  Unselects the specified calibration procedure.
        /// 
        ///  CALibration:UNSelect test
        ///  </summary>
        /// <param name="requiredPrecedure"></param>
        /// <param name="requiredArea"></param>
        /// <param name="requiredSubsystem"></param>
        /// <param name="awgNumber"></param>
        /*!
            \calibration \verbatim
        [When(@"I unselect the calibration procedure ""(.+)"" for ""(.+)"" for ""(.+)"" for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I unselect the calibration procedure ""(.+)"" for are ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
        public void WhenIUnselectTheCalibrationProcedures(string requiredPrecedure, string requiredArea, string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.UnselectCal(awg, requiredSubsystem, requiredArea, requiredPrecedure);
        }

        #endregion CALibration:UNSelect

        #region CALibration:STARt

        //zkoppert 7/11/12
        /// <summary>
        /// Runs calibration on specified AWG.
        /// 
        /// CALibration:STARt
        /// </summary>
        /*!
            \calibration \verbatim 
        [When(@"I run the AWG calibration")]
            \endverbatim
        */
        [When(@"I start the calibration for AWG ([1-4])")]
        public void WhenIRunCalibration(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.RunCalibration(awg);
        }
      
        #endregion CALibration:STARt

        #region CALibration:STATe:FACTory?

        // Unknown 01/01/01
        /// <summary>
        /// Gets the factory settings for an AWG for an area for a subsystem for an AWG
        /// </summary>
        /// <param name="requiredArea"></param>
        /// <param name="requiredSubsystem"></param>
        /// <param name="awgNumber"></param>
        /*!
            \calibration\verbatim
        [When(@"I get the calibration factory state for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the calibration factory state for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
        public void WhenIGetCalibrationFactoryStateAnArea(string requiredArea, string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.GetTheFactoryStateOfTheCalibration(awg, requiredSubsystem, requiredArea);
        }

        // Unknown 01/01/01
        /// <summary>
        /// Gets the factory settings for an AWG for a subsystem for an AWG
        /// </summary>
        /// <param name="requiredSubsystem"></param>
        /// <param name="awgNumber"></param>
        /*!
            \calibration\verbatim
        [When(@"I get the calibration factory state for subsystem ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the calibration factory state for subsystem ""(.+)"" for AWG ([1-4])")]
        public void WhenIGetCalibrationFactoryStateASubsystem(string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.GetTheFactoryStateOfTheCalibration(awg, requiredSubsystem);
        }

        // Unknown 01/01/01
        /// <summary>
        /// Checks if the factory state returns a valid format
        /// </summary>
        /*!
            \calibration\verbatim
        [Then(@"the factory state of the calibration for the AWG should have a valid format")]
            \endverbatim 
        */
        [Then(@"the calibration factory state should have a valid format for AWG ([1-4])")]
        public void FactoryStateoftheCalibrationforAWGShouldHaveAVaildFormat(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.StateoftheCalibrationforAWGShouldHaveAVaildFormat(awg, AwgCalibrationGroup.CalibrationDataType.Factory);
        }

        #endregion CALibration:STATe:FACTory?

        #region CALibration:STATe:USER?

        //sforell 8/20/13 added step
        //glennj 2/6/2014
        /// <summary>
        /// Gets the calibration user state for the awg
        /// 
        /// CALibration:STATe:USER?
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \calibration\verbatim
        [When(@"I get the calibration user state for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the calibration user state for AWG ([1-4])")]
        public void WhenIGetTheCalUserState(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.GetCalUserState(awg);
        }

        //glennj 2/6/2014
        /// <summary>
        /// Gets the calibration user state for a specified subsystem for a AWG
        /// 
        /// CALibration:STATe:USER?
        /// </summary>
        /// <param name="awgNumber"></param>
        /// <param name="requiredSubsystem">Valid subsystem name</param>
        /*!
            \calibration\verbatim
        [When(@"I get the calibration user state for ""(.*)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the calibration user state for subsystem ""(.+)"" for AWG ([1-4])")]
        public void WhenIGetTheCalUserStateForSubsystem(string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.GetCalUserState(awg, requiredSubsystem);
        }

        //glennj 2/6/2014
        /// <summary>
        /// Gets the calibration user state for a specified subsystem and area for a AWG
        /// 
        /// CALibration:STATe:USER?
        /// </summary>
        /// <param name="awgNumber"></param>
        /// <param name="requiredSubsystem">Valid subsystem name</param>
        /// <param name="requiredArea">Valid area name</param>
        /*!
            \calibration\verbatim
        [When(@"I get the calibration user state for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the calibration user state for area ""(.+)"" for subsystem ""(.+)"" for AWG ([1-4])")]
        public void WhenIGetTheCalUserStateForArea(string requiredArea, string requiredSubsystem, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.GetCalUserState(awg, requiredSubsystem, requiredArea);
        }

        //sforell 8/20/13 added step
        /// <summary>
        /// Compares the calibration user state from the awg with the expected value
        /// </summary>
        /// <param name="awgNumber"></param>
        /// <param name="expectedText">The expected user state</param>
        /*!
            \calibration\verbatim
        [Then(@"the calibration user state should contain ""(.*)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the calibration user state should contain ""(.+)"" for AWG ([1-4])")]
        public void ThenTheCalUserStateShouldContain(string expectedText, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.CalibrationUserStateShouldContain(awg, expectedText);
        }

        // Unknown 01/01/01
        /// <summary>
        /// Checks if the factory state returns a valid format
        /// </summary>
        /*!
            \calibration\verbatim
        [Then(@"the factory state of the calibration for the AWG should have a valid format")]
            \endverbatim 
        */
        [Then(@"the calibration user state should have a valid format for AWG ([1-4])")]
        public void UserStateoftheCalibrationforAWGShouldHaveAVaildFormat(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.StateoftheCalibrationforAWGShouldHaveAVaildFormat(awg, AwgCalibrationGroup.CalibrationDataType.User);
        }

        //sforell 8/20/13 added step
        /// <summary>
        /// Makes sure the calibration user state temperature is valid if the system is calibrated
        /// </summary>
        /*!
            \calibration\verbatim
        [Then(@"the calibration user state should have a valid temperature for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the calibration user state should have a valid temperature for AWG ([1-4])")]
        public void ThenTheCalibrationUserStateOfTheAwgShouldHaveAValidTemperature(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.CalibrationUserStateTempShouldBeValid(awg);
        }

        //sforell 8/20/13 added step
        /// <summary>
        /// Makes sure the calibration user state date matches today's date
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \calibration\verbatim
        [Then(@"the calibration user state should have the current date for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the calibration user state should have the current date for AWG ([1-4])")]
        public void ThenTheCalibrationUserStateOfTheAwgShouldHaveTheCurrentDate(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.CalibrationUserStateDateShouldBeToday(awg);
        }

        #endregion CALibration:STATe:USER?

        #region CALibration:STOP

        // Note to anyone looking for a stop step.  The PI command for "stopping" the calibration has been removed.
        // One "aborts" the calibration process.

        #endregion CALibration:STOP

        #region CALibration:STOP:STATe?

        //zkoppert 7/11/12
        /// <summary>
        /// Gets the calibration stop state.
        ///
        /// CALibration:STOP:STAT?
        /// </summary>
        /*!
            \calibration \verbatim 
        [When(@"I get the calibration stop state for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I get the calibration stop state for AWG ([1-4])")]
        public void WhenIGetTheCalibrationStopState(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.GetCalibrationStopState(awg);
        }

        //Unknown 01/01/01
        //glennj 2/10/2014
        ///  <summary>
        ///  Compares the calibration stop state to be stopped for AWG.
        /// 
        ///  CALibration:STOP:STAT?
        ///  </summary>
        /// <param name="awgNumber"></param>
        /*!
            \calibration \verbatim 
        [Then(@"the calibration stop state should be stopped for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the calibration stop state should be stopped for AWG ([1-4])")]
        public void ThenTheAwgCalibrationStopStateShouldBeStopped(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.CalibrationStopStateShouldBe(awg, AwgCalibrationGroup.CalibrationStoppedState.Stopped);
        }

        //glennj 3/14/2014
        ///  <summary>
        ///  Compares the calibration stop state to be stopped for AWG.
        /// 
        ///  CALibration:STOP:STAT?
        ///  </summary>
        /// <param name="awgNumber"></param>
        /*!
            \calibration \verbatim 
        [Then(@"the calibration stop state should not be stopped for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the calibration stop state should not be stopped for AWG ([1-4])")]
        public void ThenTheAwgCalibrationStopStateShouldBeNotStopped(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCalibrationGroup.CalibrationStopStateShouldBe(awg, AwgCalibrationGroup.CalibrationStoppedState.NotStopped);
        }

        #endregion CALibration:STOP:STATe?

    }
}
