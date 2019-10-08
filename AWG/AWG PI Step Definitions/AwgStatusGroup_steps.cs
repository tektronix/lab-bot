//==========================================================================
// AwgStatusGroup_steps.cs
// This file contains the PI step definitions for status group commands
// of AWGs in the framework
//==========================================================================

using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains the PI step definitions for the %AWG PI Status Group commands.

    /// Generally the steps are set, get and should be operations.  The step sole responsibility
    /// is to make sure the correct %AWG object is used and that parameters such as channel,
    /// markers and clock references are correct for the %AWG object.
    /// 
    /// 
    /// \ingroup highpi pisteps
    /// 
    /// </summary>
    [Binding] //Very important! This entry needs to be made in each step definition file. 
    public class AwgStatusSteps
    {
        private readonly AwgStatusGroup _awgStatusGroup = new AwgStatusGroup();
        #region *CLS
        //Jhowells 6-12-12
        //PHunter 9-19-2012 Abstracted out the write function
        /// <summary>
        /// Clears the error queue for a numbered AWG (AWG 1...AWG2...etc)
        ///
        /// *CLS 
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [When(@"I clear the error queue on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I clear the error queue on AWG ([1-4])")]
        public void ClearTheErrorQueueOnAnAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.AwgClearErrorQueue(awg);
        }
        #endregion *CLS

        #region *ESE
        //Jhowells 6-13-12
        //jmanning 03-24-2014
        /// <summary>
        /// Sets the value in Event Status enable Register
        /// 
        /// *ESE
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /// <param name="setValue">Status of Event Status Enable Register</param>
        /*!
            \status\verbatim
        [When(@"I set the value of the Event Status Enable register to ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the value of the Event Status Enable register to ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
        public void SetTheValueOfEventStatusEnableRegisterOnAnAWG(string setValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.SetEventStatusEnableRegister(awg, setValue);
        }
        #endregion *ESE

        #region *ESE?
        //Jhowells 6-13-12
        //jmanning 03/24/2014
        /// <summary>
        /// Gets the value of the event status enable Register
        /// 
        /// *ESE?
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [When(@"I get the value of the Event Status Enable register on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the value of the Event Status Enable register on AWG ([1-4])")]
        public void GetTheValueOfEventStatusEnableRegisterOnAnAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.GetEventStatusEnableRegister(awg);
        }

        //Jhowells 6-13-12
        //jmanning 03/24/2014
        /// <summary>
        /// Compares the value of the event status enable Register against the expected value.
        /// 
        /// *ESE?
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /// <param name="expectedValue">Expected status of Event Status Enable Register in decimal</param>
        /*!
            \status\verbatim
        [Then(@"the value of Event Status Enable register should be ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the value of Event Status Enable register should be ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
        public void TheValueOfEventStatusEnableRegisterOnAnAWGShouldBe(string expectedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.EventStatusEnableRegisterShouldBe(awg, expectedValue);
        }
        #endregion *ESE?

        #region *ESR?
        //Jhowells 6-13-12
        //jmanning 03/24/2014
        /// <summary>
        /// This query returns the value of the Standard Event Status Register
        /// 
        /// *ESR? (Query Only)
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [When(@"I get the value of standard event status register on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the value of Standard Event Status register on AWG ([1-4])")]
        public void GetTheValueOfStandardEventStatusRegisterOnTheAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.GetStandardEventStatusRegister(awg);
        }

        //Jhowells 6-13-12
        //jmanning 03/24/2014
        /// <summary>
        /// Compares the value of the Standard Event Status Register against the expected value.
        /// 
        /// *ESR? (Query Only)
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /// <param name="expectedValue">Expected Standard Event Status Register</param>
        /*!
            \status\verbatim
        [Then(@"the value of standard event status register on AWG([1-4]) should be ((?<!\S)[-+]?\d+(?!\S))")]
            \endverbatim 
        */
        [Then(@"the value of standard event status register should be ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
        public void TheValueOfStandardEventStatusRegisterOnTheAWGShouldBe(string expectedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.StandardEventStatusRegisterShouldBe(awg, expectedValue);
        }
        #endregion *ESR?

        #region *OPT?
        //jmanning 03/24/2014
        /// <summary>
        /// Verifies the given %AWG has option 01 installed
        /// 
        /// *OPT?(Query Only)
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [Given(@"the memory expansion option is installed on AWG ([1-4])")]
            \endverbatim 
        */
        [Given(@"the memory expansion option is installed on AWG ([1-4])")]
        public void GivenTheAWGHasTheOption01(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            const string option = "01";
            try
            {
                _awgStatusGroup.OptionIsOnAWG(awg, option);
            }
            catch (Exception)
            {
                Assert.Inconclusive("The requested AWG does not have the " + option + " option, test skipped"); //Did not find the desired option
            }
        }

        //jmanning 03/24/2014
        /// <summary>
        /// Verifies the given %AWG has option 03 installed
        /// 
        /// *OPT?(Query Only)
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [Given(@"the sequencing option is installed on AWG ([1-4])")]
            \endverbatim 
        */
        [Given(@"the sequencing option is installed on AWG ([1-4])")]
        public void GivenTheAWGHasTheOption03(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            const string option = "03";
            try
            {
                _awgStatusGroup.OptionIsOnAWG(awg, option);
            }
            catch (Exception)
            {
                Assert.Inconclusive("The requested AWG does not have the " + option + " option, test skipped"); //Did not find the desired option
            }
        }

        //jmanning 03/24/2014
        /// <summary>
        /// Verifies the given %AWG has option 150 installed
        /// 
        /// *OPT?(Query Only)
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [Given(@"the 50 G option 150 is installed on AWG ([1-4])")]
            \endverbatim 
        */
        [Given(@"the 50 G option 150 is installed on AWG ([1-4])")]
        public void GivenTheAWGHasTheOption150(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            const string option = "150";
            try
            {
                _awgStatusGroup.OptionIsOnAWG(awg, option);
            }
            catch (Exception)
            {
                Assert.Inconclusive("The requested AWG does not have the " + option + " option, test skipped"); //Did not find the desired option
            }
        }

        //jmanning 03/24/2014
        /// <summary>
        /// Verifies the given %AWG has option 208 installed
        /// 
        /// *OPT?(Query Only)
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [Given(@"the 8 G option 208 is installed on AWG ([1-4])")]
            \endverbatim 
        */
        [Given(@"the 8 G option 208 is installed on AWG ([1-4])")]
        public void GivenTheAWGHasTheOption208(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            const string option = "208";
            try
            {
                _awgStatusGroup.OptionIsOnAWG(awg, option);
            }
            catch (Exception)
            {
                Assert.Inconclusive("The requested AWG does not have the " + option + " option, test skipped"); //Did not find the desired option
            }
        }

        //jmanning 03/24/2014
        /// <summary>
        /// Verifies the given %AWG has option 216 installed
        /// 
        /// *OPT?(Query Only)
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [Given(@"the 16 G option 216 is installed on AWG ([1-4])")]
            \endverbatim 
        */
        [Given(@"the 16 G option 216 is installed on AWG ([1-4])")]
        public void GivenTheAWGHasTheOption216(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            const string option = "216";
            try
            {
                _awgStatusGroup.OptionIsOnAWG(awg, option);
            }
            catch (Exception)
            {
                Assert.Inconclusive("The requested AWG does not have the " + option + " option, test skipped"); //Did not find the desired option
            }
        }

        //jmanning 03/24/2014
        /// <summary>
        /// Verifies the given %AWG has option 225 installed
        /// 
        /// *OPT?(Query Only)
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [Given(@"the 25 G option 225 is installed on AWG ([1-4])")]
            \endverbatim 
        */
        [Given(@"the 25 G option 225 is installed on AWG ([1-4])")]
        public void GivenTheAWGHasTheOption225(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            const string option = "225";
            try
            {
                _awgStatusGroup.OptionIsOnAWG(awg, option);
            }
            catch (Exception)
            {
                Assert.Inconclusive("The requested AWG does not have the " + option + " option, test skipped"); //Did not find the desired option
            }
        }

        //jmanning 03/24/2014
        /// <summary>
        /// Checks for various optios on the %AWG
        /// </summary>
        /// <param name="option1">Option values: (01|132|150|208|216|225)</param>
        /// <param name="option2">Option values: (01|132|150|208|216|225)</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [Given(@"the option (01|03|132|150|208|216|225) or option (01|03|132|150|208|216|225) is installed on AWG ([1-4])")]
            \endverbatim 
        */
        [Given(@"the option (01|03|132|150|208|216|225) or option (01|03|132|150|208|216|225) is installed on AWG ([1-4])")]
        public void GivenTheAWGHasTheOptionOrOption(string option1, string option2, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);

            bool result1 = _awgStatusGroup.AWGOptionFinder(awg, option1);
            bool result2 = _awgStatusGroup.AWGOptionFinder(awg, option2);

            if (!result1 & !result2)
            {
                Assert.Inconclusive("The requested AWG does not have either option " + option1 + " or option " + option2 + ", test skipped"); //Did not find either desired option
            }
        }

        //jmanning 03/24/2014
        /// <summary>
        /// Verifies the specified %AWG has does not have option 01
        /// 
        /// *OPT?(Query Only)
        /// </summary>
        ///<param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [Given(@"the memory expansion option is not installed on AWG ([1-4])")]
            \endverbatim 
        */
        [Given(@"the memory expansion option is not installed on AWG ([1-4])")]
        public void GivenTheAWGDoesNotHaveTheOption01(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            const string option = "01";
            try
            {
                _awgStatusGroup.OptionIsNotOnAWG(awg, option);
            }
            catch (Exception)
            {
                Assert.Inconclusive("The requested AWG has the " + option + " option, test skipped"); //Found the (right) wrong option
            }
        }

        //jmanning 03/24/2014
        /// <summary>
        /// Verifies the specified %AWG has does not have option 03
        /// 
        /// *OPT?(Query Only)
        /// </summary>
        ///<param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [Given(@"the sequencing option is not installed on AWG ([1-4])")]
            \endverbatim 
        */
        [Given(@"the sequencing option is not installed on AWG ([1-4])")]
        public void GivenTheAWGDoesNotHaveTheOption03(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            const string option = "03";
            try
            {
                _awgStatusGroup.OptionIsNotOnAWG(awg, option);
            }
            catch (Exception)
            {
                Assert.Inconclusive("The requested AWG has the " + option + " option, test skipped"); //Found the (right) wrong option
            }
        }

        //jmanning 03/24/2014
        /// <summary>
        /// Verifies the specified %AWG has does not have option 150
        /// 
        /// *OPT?(Query Only)
        /// </summary>
        ///<param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [Given(@"the 50 G option 150 is not installed on AWG ([1-4])")]
            \endverbatim 
        */
        [Given(@"the 50 G option 150 is not installed on AWG ([1-4])")]
        public void GivenTheAWGDoesNotHaveTheOption150(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            const string option = "150";
            try
            {
                _awgStatusGroup.OptionIsNotOnAWG(awg, option);
            }
            catch (Exception)
            {
                Assert.Inconclusive("The requested AWG has the " + option + " option, test skipped"); //Found the (right) wrong option
            }
        }

        //jmanning 03/24/2014
        /// <summary>
        /// Verifies the specified %AWG has does not have option 208
        /// 
        /// *OPT?(Query Only)
        /// </summary>
        ///<param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [Given(@"the 8 G option 208 is not installed on AWG ([1-4])")]
            \endverbatim 
        */
        [Given(@"the 8 G option 208 is not installed on AWG ([1-4])")]
        public void GivenTheAWGDoesNotHaveTheOption208(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            const string option = "208";
            try
            {
                _awgStatusGroup.OptionIsNotOnAWG(awg, option);
            }
            catch (Exception)
            {
                Assert.Inconclusive("The requested AWG has the " + option + " option, test skipped"); //Found the (right) wrong option
            }
        }

        //jmanning 03/24/2014
        /// <summary>
        /// Verifies the specified %AWG has does not have option 216
        /// 
        /// *OPT?(Query Only)
        /// </summary>
        ///<param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [Given(@"the 16 G option 216 is not installed on AWG ([1-4])")]
            \endverbatim 
        */
        [Given(@"the 16 G option 216 is not installed on AWG ([1-4])")]
        public void GivenTheAWGDoesNotHaveTheOption216(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            const string option = "216";
            try
            {
                _awgStatusGroup.OptionIsNotOnAWG(awg, option);
            }
            catch (Exception)
            {
                Assert.Inconclusive("The requested AWG has the " + option + " option, test skipped"); //Found the (right) wrong option
            }
        }

        //jmanning 03/24/2014
        /// <summary>
        /// Verifies the specified %AWG has does not have option 225
        /// 
        /// *OPT?(Query Only)
        /// </summary>
        ///<param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [Given(@"the 25 G option 225 is not installed on AWG ([1-4])")]
            \endverbatim 
        */
        [Given(@"the 25 G option 225 is not installed on AWG ([1-4])")]
        public void GivenTheAWGDoesNotHaveTheOption225(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            const string option = "225";
            try
            {
                _awgStatusGroup.OptionIsNotOnAWG(awg, option);
            }
            catch (Exception)
            {
                Assert.Inconclusive("The requested AWG has the " + option + " option, test skipped"); //Found the (right) wrong option
            }
        }

        //jmanning 03/24/2014
        /// <summary>
        /// This command is used to return the implemented options on the AWG
        /// 
        /// *OPT?(Query Only)
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [When(@"I get value of the options implemented on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get value of the options implemented on AWG ([1-4])")]
        public void GetTheValueOfTheOptionsImplementedOnTheAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.GetOptions(awg);
        }

        //PHunter01/03/2013
        //jmanning 03/24/2014
        /// <summary>
        /// Compares the format of the optins_implemented string against a regular expression format 
        /// to test for validity
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
        \status\verbatim
        [Then(@"the options string response should be valid on AWG ([1-4])")]
        \endverbatim 
        */
        [Then(@"the options string response should be valid on AWG ([1-4])")]
        public void ThenTheAWGShouldRespondWithAValidOptionsString(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.AWGShouldRespondWithValidOptionsString(awg);
        }
        #endregion *OPT?

        #region *SRE
        //Jhowells 6-13-12
        //jmanning 03-25-2014
        /// <summary>
        /// Sets the value in Service Request Enable Register
        /// 
        /// *SRE 
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /// <param name="setValue">The value to be set</param>
        /*!
            \status\verbatim
        [When(@"I set the value of the Service Request Enable register to ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the value of the Service Request Enable register to ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
        public void SetTheValueOfServiceRequestEnableRegisterOnAnAWG(string setValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.SetServiceRequestEnableRegister(awg, setValue);
        }
        #endregion *SRE

        #region *SRE?
        //Jhowells 6-13-12
        //jmanning 03-25-2014
        /// <summary>
        /// This query returns the value of the Service Request Enable Register
        /// 
        /// *SRE?
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [When(@"I get the value of the Service Request Enable register on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the value of the Service Request Enable register on AWG ([1-4])")]
        public void GetTheValueOfServiceEnableRegisterOnAnAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.GetServiceRequestEnableRegister(awg);
        }

        //Jhowells 6-13-12
        /// <summary>
        /// Compares the value of the Service Request Enable Register against the expected value.
        /// 
        /// *SRE?
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /// <param name="expectedValue">Expected Service Request Enable Register value</param>
        /*!
            \status\verbatim
        [Then(@"the value of the Service Request Enable register on AWG([1-4]) should be ((?<!\S)[-+]?\d+(?!\S))")]
            \endverbatim 
        */
        [Then(@"the value of the Service Request Enable register should be ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
        public void TheValueOfServiceEnableRegisterOnAnAWGShouldBe(string expectedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.ServiceRequestEnableRegisterShouldBe(awg, expectedValue);
        }
        #endregion *SRE?

        #region *STB?
        //PHunter8/27/2012
        //jmanning 03/25/2014
        /// <summary>
        /// This query returns the value of the Status Byte Register and puts it in the 
        /// awg.status_byte_reg accessor
        /// 
        /// *STB? (Query Only)
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [When(@"I get the value of status byte register on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the value of Status Byte register on AWG ([1-4])")]
        public void GetTheValueOfStatusByteRegisterOnAnAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.GetStatusByteRegister(awg);
        }

        //Jhowells 6-13-12
        //jmanning 03/25/2014
        /// <summary>
        /// Compares the value of the Status Byte Register against the expected value.
        /// 
        /// *STB? (Query Only)
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /// <param name="expectedValue">Expected Status Byte Register</param>
        /*!
            \status\verbatim
        [Then(@"the Status Byte register value should be ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the Status Byte register value should be ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
        public void TheValueOfStatusByteRegisterOnAnAWGShouldBe(string expectedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.StatusByteRegisterShouldBe(awg, expectedValue);
        }

        //Jhowells 6-12-12
        //jmanning 03/25/2014
        /// <summary>
        /// This query returns the contents of Status Byte Register
        /// 
        /// *STB?
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [When(@"I verify that there are entries in the error queue on AWG ([1-4])]
            \endverbatim 
        */
        [When(@"I verify that there are entries in the error queue on AWG ([1-4])")]
        public void VerifyThatThereAreEntriesInErrorQueue(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.VerifyEntriesInErrorQueue(awg);
        }
        #endregion *STB?

        #region STATus:​OPERation:​CONDition?
        //Jhowells 6-13-12
        //jmanning 03/25/2014
        /// <summary>
        /// This query returns the contents of the Operation Condition Register
        /// 
        /// Note that the OCR is not used in the arbitrary waveform generator.@n
        /// STATus:​OPERation:​CONDition? (Query Only)
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [When(@"I get the contents of operation condition register on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the contents of operation condition register on AWG ([1-4])")]
        public void GetTheContentsOfOperationConditionRegisterOnTheAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.GetOperationConditionRegister(awg);
        }
        #endregion STATus:​OPERation:​CONDition?

        #region STATus:​OPERation:​ENABle
        //Jhowells 6-13-12
        /// <summary>
        /// Sets the mask of the Operation Enable Register
        /// 
        /// STATus:​OPERation:​ENABle
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /// <param name="setValue">Mask of the Operation Enable Register</param>
        /*!
            \status\verbatim
        [When(@"I set the mask value of operation enable register to ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the mask value of operation enable register to ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
        public void SetTheMaskValueOfOperationEnableRegisterOnTheAWG(string setValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.SetMaskOperationEnableRegister(awg, setValue);
        }
        #endregion STATus:​OPERation:​ENABle

        #region STATus:​OPERation:​ENABle?
        //Jhowells 6-13-12
        //jmanning 03-25-2014
        /// <summary>
        /// Gets the mask of the Operation Enable Register
        /// 
        /// STATus:​OPERation:​ENABle?
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [When(@"I get the mask value of operation enable register on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the mask value of operation enable register on AWG ([1-4])")]
        public void GetTheMaskValueOfOperationEnableRegisterOnTheAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.GetMaskOperationEnableRegister(awg);
        }

        //Jhowells 6-13-12
        /// <summary>
        /// Compares the mask of the Operation Enable Register against the expected value.
        /// 
        /// STATus:​OPERation:​ENABle?
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /// <param name="expectedValue">Expected Operation Enable Register Mask</param>
        /*!
            \status\verbatim
        [Then(@"the mask value of operation enable register on AWG([1-4]) should be ((?<!\S)[-+]?\d+(?!\S))")]
            \endverbatim 
        */
        [Then(@"the mask value of operation enable register should be ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
        public void TheAWGMaskValueofOperationEnableRegisterShouldBe(string expectedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.MaskOperationEnableRegisterShouldBe(awg, expectedValue);
        }
        #endregion STATus:​OPERation:​ENABle?

        #region STATus:​OPERation[:​EVENt]?
        //Jhowells 6-13-12
        //jmanning 03-25-2014
        /// <summary>
        /// This query returns the contents of the Operation Event Register
        /// 
        /// STATus:​OPERation[:​EVENt]? (Query Only)
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [When(@"I get the contents of Operation Event register on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the contents of Operation Event register on AWG ([1-4])")]
        public void GetTheContentsOfOperationEventRegisterOnAnAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.GetOperationEventRegister(awg);
        }

        //PHunter 8/27/2012
        //jmanning 03/25/2014
        /// <summary>
        /// Tests the value in the Operation Event Register against the expected value for the default AWG
        /// 
        /// </summary>
        /// <param name="expectedValue">Expected Operation Event Register value</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [When(@"the Operation Event register value should be ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the Operation Event register value should be ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
        public void TheOperationEventRegisterShoudlReturnAValueFromTheAwg(string expectedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.OperationEventRegisterShouldReturnValue(awg, expectedValue);
        }
        #endregion STATus:​OPERation[:​EVENt]?

        #region STATus:OPERation:NTransition
        //PHunter 01/08/2013
        //jmanning 03/25/2014
        /// <summary>
        /// Sets the value in Status Operation NTransition register for default AWG
        /// 
        /// STATus:OPERation:NTransition NR1
        /// </summary>
        /// <param name="setValue">The value to set in the Status Questionable NTransition Register</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [When(@"I set the Status Operation NTransition register value to ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4]))]
            \endverbatim 
        */
        [When(@"I set the Status Operation NTransition register value to ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
        public void SetTheValueOfStatusOperationNTransitionRegisterOnTheAWG(string setValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.SetStatusOperationNTransitionRegister(awg, setValue);
        }
        #endregion STATus:OPERation:NTransition

        #region STATus:OPERation:NTransition?
        //PHunter 01/08/2013
        //jmanning 03/25/2014
        /// <summary>
        /// Gets the value in Status Operation NTransition register for default AWG
        /// 
        /// STATus:OPERation:NTransition[?]
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [When(@"I get the value of the Status Operation NTransition register from the AWG")]
            \endverbatim 
        */
        [When(@"I get the Status Operation NTransition register value on AWG ([1-4])")]
        public void GetTheValueOfStatusOperationNTransitionRegisterOnTheAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.GetStatusOperationNTransitionRegister(awg);
        }

        //PHunter 01/08/2013
        //jmanning 03/25/2014
        /// <summary>
        /// Tests the value in Status Operation NTransition register for default AWG
        /// 
        /// STATus:OPERation:NTransition[?]
        /// </summary>
        /// <param name="expectedValue">The expected value to test</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [Then(@"the value of the Status Operation NTransition register on the AWG should be ((?<!\S)[-+]?\d+(?!\S))")]
            \endverbatim 
        */
        [Then(@"the Status Operation NTransition register value should be ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
        public void TheValueOfStatusOperationNTransitionRegisterOnTheAWGShouldBe(string expectedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.StatusOperationNTransitionRegisterShouldBe(awg, expectedValue);
        }
        #endregion STATus:OPERation:NTransition?

        #region STATus:OPERation:PTRansition
        //PHunter 01/08/2013
        //jmanning 03/25/2014
        /// <summary>
        /// Sets the value in Status Operation PTransition register for default AWG
        /// 
        /// STATus:OPERation:PTransition
        /// </summary>
        /// <param name="setValue">The value to set in the Status Questionable PTransition Register</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [When(@"I set the Status Operation PTransition register value to ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the Status Operation PTransition register value to ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
        public void SetTheValueOfStatusOperationPTransitionRegisterOnTheAWG(string setValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.SetStatusOperationPTransitionRegister(awg, setValue);
        }
        #endregion STATus:OPERation:PTRansition

        #region STATus:OPERation:PTRansition?
        //PHunter 01/08/2013
        //jmanning 03/25/2014
        /// <summary>
        /// Gets the value in Status Operation PTransition register for default AWG
        /// 
        /// STATus:OPERation:PTransition[?]
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [When(@"I get the value of the Status Operation PTransition register from the AWG")]
            \endverbatim 
        */
        [When(@"I get the Status Operation PTransition register value on AWG ([1-4])")]
        public void GetTheValueOfStatusOperationPTransitionRegisterOnTheAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.GetStatusOperationPTransitionRegister(awg);
        }

        //PHunter 01/08/2013
        //jmanning 03/25/2014
        /// <summary>
        /// Tests the value in Status Operation PTransition register for default AWG
        /// 
        /// STATus:OPERation:PTransition[?]
        /// </summary>
        /// <param name="expectedValue">The expected value to test</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [Then(@"the Status Operation PTransition register value should be ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the Status Operation PTransition register value should be ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
        public void TheValueOfStatusOperationPTransitionRegisterOnTheAWGShouldBe(string expectedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.StatusOperationPTransitionRegisterShouldBe(awg, expectedValue);
        }
        #endregion STATus:OPERation:PTRansition?

        #region STATus:PRESet
        //Jhowells 6-13-12
        //jmanning 03/25/2014
        /// <summary>
        /// This command sets the OENR and QENR registers.
        /// 
        /// STATus:PRESet
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [When(@"I set the OENR and QENR register on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the OENR and QENR register on AWG ([1-4])")]
        public void SetTheOENRAndQENRRegisterOnTheAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.PresetOENRAndQENRRegisters(awg);
        }
        #endregion STATus:PRESet

        #region STATus:QUEStionable:ENABle
        //PHunter 01/08/2013
        /// <summary>
        /// Sets the value in Status Questionable Enable register for specified AWG
        /// 
        /// STATus:QUEStionable:ENABle NR1
        /// </summary>
        /// <param name="setValue">The value to set in the Status Questionable Enable Register</param>
        ///  <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [When(@"I set the value of the Status Questionable Enable register on the AWG to ((?<!\S)[-+]?\d+(?!\S))")]
            \endverbatim 
        */
        [When(@"I set the Status Questionable Enable register value to ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
        public void SetTheValueOfStatusQuestionableEnableRegisterOnTheAWG(string setValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.SetStatusQuestionableEnableRegister(awg, setValue);
        }
        #endregion STATus:QUEStionable:ENABle

        #region STATus:QUEStionable:ENABle?
        //PHunter 01/08/2013
        //jmanning 03/25/2014
        /// <summary>
        /// Gets the value from the Status Questionable Enable register for specified AWG
        /// 
        /// STATus:QUEStionable:ENABle[?]
        /// </summary>
        ///  <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [[When(@"I get the Status Questionable Enable register value on AWG ([1-4])]
            \endverbatim 
        */
        [When(@"I get the Status Questionable Enable register value on AWG ([1-4])")]
        public void GetTheValueOfStatusQuestionableEnableRegisterOnTheAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.GetStatusQuestionableEnableRegister(awg);
        }

        //PHunter 01/08/2013
        /// <summary>
        /// Tests the value in Status Questionable Enable register for default AWG
        /// 
        /// STATus:QUEStionable:ENABle[?]
        /// </summary>
        /// <param name="expectedValue">The expected value to test</param>
        ///  <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [Then(@"the value of the Status Questionable Enable register on the AWG should be ((?<!\S)[-+]?\d+(?!\S))")]
            \endverbatim 
        */
        [Then(@"the Status Questionable Enable register value should be ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
        public void TheValueOfStatusQuestionableEnableRegisterOnTheAWGShouldBe(string expectedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.StatusQuestionableEnableRegisterShouldBe(awg, expectedValue);
        }
        #endregion STATus:QUEStionable:ENABle

        #region STATus:QUEStionable:NTRansition
        //PHunter 01/08/2013
        //jmanning 03/25/2014
        /// <summary>
        /// Sets the value in Status Questionable NTransition register for default AWG
        /// 
        /// STATus:QUEStionable:NTRransition NR1
        /// </summary>
        /// <param name="setValue">The value to set in the Status Questionable NTransition Register</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [When(@"I set the value of the Status Questionable NTransition register on the AWG to ((?<!\S)[-+]?\d+(?!\S))")]
            \endverbatim 
        */
        [When(@"I set the Status Questionable NTransition register value to ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
        public void SetTheValueOfStatusQuestionableNTransitionRegisterOnTheAWG(string setValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.SetStatusQuestionableNTransitionRegister(awg, setValue);
        }
        #endregion STATus:QUEStionable:NTRansition

        #region STATus:QUEStionable:NTRansition?
        //PHunter 01/08/2013
        //jmanning 03/25/2014
        /// <summary>
        /// Gets the value in Status Questionable NTransition register for default AWG
        /// 
        /// STATus:QUEStionable:NTRransition[?]
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [When(@"I get the Status Questionable NTransition register value on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the Status Questionable NTransition register value on AWG ([1-4])")]
        public void GetTheValueOfStatusQuestionableNTransitionRegisterOnTheAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.GetStatusQuestionableNTransitionRegister(awg);
        }

        //PHunter 01/08/2013
        //jmanning 03/25/2014
        /// <summary>
        /// Tests the value in Status Questionable NTransition register for default AWG
        /// 
        /// STATus:QUEStionable:NTRransition[?]
        /// </summary>
        /// <param name="expectedValue">The expected value to test</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [Then(@"the Status Questionable NTransition register value should be ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the Status Questionable NTransition register value should be ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
        public void TheValueOfStatusQuestionableNTransitionRegisterOnTheAWGShouldBe(string expectedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.StatusQuestionableNTransitionRegisterShouldBe(awg, expectedValue);
        }
        #endregion STATus:QUEStionable:NTRansition?

        #region STATus:QUEStionable:PTRansition
        //PHunter 01/08/2013
        /// <summary>
        /// Sets the value in Status Questionable PTransition register for default AWG
        /// 
        /// STATus:QUEStionable:PTrransition NR1
        /// </summary>
        /// <param name="setValue">The value to set in the Status Questionable PTransition Register</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [When(@"I set the Status Questionable PTransition register value to ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the Status Questionable PTransition register value to ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
        public void SetTheValueOfStatusQuestionablePTransitionRegisterOnTheAWG(string setValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.SetStatusQuestionablePTransitionRegister(awg, setValue);
        }
        #endregion STATus:QUEStionable:PTRansition

        #region STATus:QUEStionable:PTRansition?
        //PHunter 01/08/2013
        //jmanning 03/25/2014
        /// <summary>
        /// Gets the value in Status Questionable PTransition register for default AWG
        /// 
        /// STATus:QUEStionable:PTRansition[?]
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \status\verbatim
        [When(@"I get the Status Questionable PTransition register value on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the Status Questionable PTransition register value on AWG ([1-4])")]
        public void GetTheValueOfStatusQuestionablePTransitionRegisterOnTheAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.GetStatusQuestionablePTransitionRegister(awg);
        }

        //PHunter 01/08/2013
        //jmanning 03/25/2014
        /// <summary>
        /// Tests the value in Status Questionable PTransition register for default AWG
        /// 
        /// STATus:QUEStionable:PTRansition[?]
        /// </summary>
        /// <param name="expectedValue">The expected value to test</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
        \status\verbatim
        [Then(@"the Status Questionable PTransition register value should be ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
        \endverbatim 
        */
        [Then(@"the Status Questionable PTransition register value should be ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
        public void TheValueOfStatusQuestionablePTransitionRegisterOnTheAWGShouldBe(string expectedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgStatusGroup.StatusQuestionablePTransitionRegisterShouldBe(awg, expectedValue);
        }
        #endregion STATus:QUEStionable:PTRansition?
    }
}