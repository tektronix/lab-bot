//==========================================================================
// AwgSystemGroupL_steps.cs
// This file contains the PI step definitions for the AWG PI System Group commands 
//==========================================================================

using System.IO;
using TechTalk.SpecFlow;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains the PI step definitions for the %AWG PI System Group commands 

    /// Generally the steps are set, get and should be operations.  The step sole responsibility
    /// is to make sure the correct %AWG object is used and that parameters such as channel,
    /// markers and clock references are correct for the %AWG object.
    /// 
    /// \ingroup highpi pisteps
    /// 
    /// </summary>
    [Binding] //Very important! This entry needs to be made in each step definition file. 
    public class AwgSystemSteps //: AwgSystemGroup
    {

        private readonly AwgSystemGroup _awgSystemGroup = new AwgSystemGroup();
        private readonly AwgSyncGroup _awgSyncGroup = new AwgSyncGroup();

        #region *IDN?
        //Jhowells 6-8-12
        //jmanning 03/18/2014
        /// <summary>
        /// Gets the identification information for the arbitrary waveform generator.
        /// 
        /// *IDN?
        /// </summary>
        /// <param name="awgNumber">The specified %AWG machine number</param>
        /*!
            \system\verbatim
        [When(@"I get the ID from AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the ID string from AWG ([1-4])")]
        public void GetAnAwgId(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.AwgIdentifyYourself(awg);       // Go query yourself and decode and save it.
        }

        //glennj 11/22/2013
        /// <summary>
        /// Select or assign context for an AWG
        /// </summary>
        /// <param name="awgNumber">The specified %AWG</param>
        /*!
            \system\verbatim
        [When(@"I set the context for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the context for AWG ([1-4])")]
        public void SelectAwgContext(string awgNumber)
        {
            AwgSetupSteps.AssignAwgContext(awgNumber);
        }

        // jmanning 03/18/2014
        /// <summary>
        /// Verifies that the *IDN query has returned a valid string format for a particular %AWG
        /// 
        /// *IDN?
        /// </summary>
        /// <param name="awgNumber">The specified %AWG machine number</param>
        /*!
            \system\verbatim
        [Then(@"the returned identity response should be a valid nomenclature string for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the returned identity response should be a valid nomenclature string for AWG ([1-4])")]
        public void AnAWGShouldRespondWithValidNomenclatureString(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.VerifyValidNomenclatureString(awg);
        }

        //jmanning 3-6-14
        /// <summary>
        /// This verifies that the SW Version is current enough to run the test.
        /// 
        /// assumes *IDN? has been performed prior
        /// </summary>
        /// <param name="majorMinorVersion">Major[.Minor[.Version]]</param>
        /// <param name="awgNumber">The specified %AWG</param>
        /*!
            \sync\verbatim
        [Given(@"the application software version is ""(.+)"" or newer for AWG ([1-4])")]
            \endverbatim 
        */
        [Given(@"the application software version is ""(.+)"" or newer for AWG ([1-4])")]
        public void GivenTestAppliesForVersionsAsNewAs(string majorMinorVersion, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.GivenTestAppliesForVersionsAsNewAs(awg, majorMinorVersion);
        }

        //jmanning 3-11-14
        /// <summary>
        /// This verifies that the SW Version is old enough to run the test.
        /// 
        /// assumes *IDN? has been performed prior
        /// </summary>
        /// <param name="majorMinorVersion">Major[.Minor[.Version]]</param>
        /// <param name="awgNumber">The specified %AWG</param>
        /*!
            \sync\verbatim
        [Given(@"the application software version is ""(.+)"" or older for AWG ([1-4])")]
            \endverbatim 
        */
        [Given(@"the application software version is ""(.+)"" or older for AWG ([1-4])")]
        public void GivenTestAppliesForVersionsAsOldAs(string majorMinorVersion, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.GivenTestAppliesForVersionsAsOldAs(awg, majorMinorVersion);
        }

        //glennj 11/22/2013
        /// <summary>
        /// Verifies that the specified AWG is a 50k or 70k 
        /// </summary>
        /// <param name="expectedFamily"></param>
        /// <param name="awgNumber">The specified %AWG</param>
        /*!
            \system\verbatim
        [Given(@"the family is (70|50)k for AWG ([1-4])")]
            \endverbatim 
        */
        [Given(@"the family is (70|50)k for AWG ([1-4])")]
        public void GivenTheFamilyIsForAWG(string expectedFamily, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.VerifyExpectedAwgFamily(awg, expectedFamily);
        }

        #endregion *IDN?
        
        #region *LRN?
        //PHunter 2/7/2013
        //jmanning 03/18/2014
        /// <summary>
        /// Gets the current settings for the arbitrary waveform generator.
        /// 
        /// *LRN?
        /// </summary>
        /// <param name="awgNumber">The specified %AWG</param>
        /*!
            \system\verbatim
        [When(@"I get the current settings from AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the current settings from AWG ([1-4])")]
        public void GetTheAwgSettings(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.AwgLRNQuery(awg);
        }  
      
        //PHunter 2/7/2013
        //jmanning 03/18/2014
        /// <summary>
        /// Saves the contents of awg.lrn to a named file.
        /// 
        /// *LRN?
        /// </summary>
        /// <param name="filePath">The path of the settings file to save to</param>
        /// <param name="awgNumber">The specified %AWG</param>
        /*!
            \system\verbatim
        [When(@"I save the to file ""(.+)"" the current settings of AWG ([1-4])")]
            \endverbatim 
        */

        [When(@"I save the to file ""(.+)"" the current settings of AWG ([1-4])")]
        public void SaveTheAwgSettings(string filePath, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            //Write the awg.lrn string contents to the file
            File.WriteAllText(filePath, awg.Lrn);
        }

        //PHunter 2/8/2013
        //jmanning 03/18/2014
        //TODO: I should be shot for putting this wad of code in a steps file...:-)
        /// <summary>
        /// Compares the contents of awg.lrn to a named file.
        /// 
        /// *LRN?
        /// </summary>
        /// <param name="filePath">The path of the settings file to compare to</param>
        /// <param name="awgNumber">The specified %AWG</param>
        /*!
            \system\verbatim
        [Then(@"the AWG current settings should match the ""(.+)"" file")]
            \endverbatim 
        */
        [Then(@"the ""(.+)"" file settings should match current settings for AWG ([1-4])")]
        public void CompareTheAwgSettings(string filePath, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.VerifyLrnResultsMatchFile(awg, filePath);
        }
        #endregion *LRN?

        #region *RST
        //jmanning 03/18/2014
        /// <summary>
        /// Resets a particular %AWG
        /// 
        /// *RST
        /// </summary>
        /// <param name="awgNumber">The specified %AWG machine number [1-4]</param>
        /*!
            \system\verbatim
        [When(@"I reset AWG([1-4])")]
            \endverbatim 
        */  
        [When(@"I reset AWG ([1-4])")]
        public void PreferredResetAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.AwgRST(awg);
            _awgSyncGroup.AwgOperationCompleteQuery(awg);
            //AwgContextFunctions.SetContextToAwgMode();
            //Above sets UI context to AWG mode - this is one of a few places where a PI command can screw up the UI.  Not sure if needed
        }
        #endregion *RST

        #region AWGControl:CONFigure:CNUMber?
        //zkoppert 7/13/12
        //jmanning 03/18/2014
        /// <summary>
        /// Verifies a particular %AWG has only one channel
        /// 
        /// AWGControl:CONFigure:CNUMber?
        /// </summary>
        /// <param name="awgNumber">The specified %AWG number</param>
        /*!
            \system\verbatim
        [Given(@"there is only one channel on AWG ([1-4])")]
            \endverbatim 
        */
        [Given(@"there is only one channel on AWG ([1-4])")]
        public void GivenTheAWGHasOnlyOneChannel(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            const string expectedCount = "1";
            _awgSystemGroup.VerifyChannelCount(awg, expectedCount);
        }

        //zkoppert 7/13/12
        //jmanning 03/18/2014
        /// <summary>
        /// Verifies a particular %AWG has only two channels
        /// 
        /// AWGControl:CONFigure:CNUMber?
        /// </summary>
        /// <param name="awgNumber">The specified %AWG number</param>
        /*!
            \system\verbatim
        [Given(@"there are only two channels on AWG ([1-4])")]
            \endverbatim 
        */
        [Given(@"there are only two channels on AWG ([1-4])")]
        public void GivenTheAWGHasTwoChannel(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            const string expectedCount = "2";
            _awgSystemGroup.VerifyChannelCount(awg, expectedCount);
        }

        //zkoppert 7/13/12
        //jmanning 03/18/2014
        /// <summary>
        /// Verifies a particular %AWG has only four channels
        /// 
        /// AWGControl:CONFigure:CNUMber?
        /// </summary>
        /// <param name="awgNumber">The specified %AWG number</param>
        /*!
            \system\verbatim
        [Given(@"there are only four channels on AWG ([1-4])")]
            \endverbatim 
        */
        [Given(@"there are only four channels on AWG ([1-4])")]
        public void GivenTheAWGHasFourChannel(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            const string expectedCount = "4";
            _awgSystemGroup.VerifyChannelCount(awg, expectedCount);
        }

        //Jhowells 6-8-12
        //jmannning 03/18/2014
        /// <summary>
        /// Verify the number of channels from the model_number on a particular %AWG matches the actual channels on the %AWG
        /// 
        /// *IDN?
        /// AWGControl:CONFigure:CNUMber?
        /// </summary>
        /// <param name="awgNumber">The specified %AWG machine number</param>
        /*!
            \system\verbatim
        [Then(@"the number of available channels should match that indicated by the model number on AWG ([1-4])")]
            \endverbatim 
          */
        [Then(@"the number of available channels should match that indicated by the model number on AWG ([1-4])")]
        public void TheNumeberOfAvailableChannelsShouldMatchTheModelNumber(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.VerifyModelNumberShouldMatchAwgChannelCount(awg);
        }
        #endregion AWGControl:CONFigure:CNUMber?

        #region  SYSTem:DATE
        //Jhowells 6-11-12
        //jmanning 03/18/2014
        /// <summary>
        /// Updates the AWG's property for that contains current system date
        /// 
        /// SYSTem:DATE?
        /// </summary>
        /// <param name="awgNumber">The specified %AWG</param>
        /*!
            \system\verbatim
        [When(@"I get the current system date on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the current system date on AWG ([1-4])")]
        public void GetTheSystemDateValueonAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.AwgSystemDateQuery(awg);
        }

        //Added by Kavitha 02/01/2013
        /// <summary>
        /// Sets the system date on a particular %AWG
        /// 
        /// SYSTem:DATE
        /// </summary>
        /// <param name="year">The value to set the year to</param>
        /// <param name="month">The value to set the month to</param>
        /// <param name="days">The value to set the day to</param>
        /// <param name="awgNumber">The specified %AWG</param>
        /*!
            \system\verbatim
        [When(@"I set the system year to (19[0-9]{2}|20[0-9]{2}) month to (0[1-9]|1[012]) day to (0[1-9]|[12][0-9]|3[01]) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the system year to (19[0-9]{2}|20[0-9]{2}) month to (0[1-9]|1[012]) day to (0[1-9]|[12][0-9]|3[01]) on AWG ([1-4])")]
        public void SetTheSystemDateValueonAWG(string year, string month, string days, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            string dateString = year + "," + month + "," + days;
            _awgSystemGroup.AwgSystemDate(awg, dateString);
        }
        #endregion  SYSTem:DATE

        #region SYSTem:Error?

        //Jhowells 6-11-12
        /// <summary>
        /// Queries the error queue for a particular %AWG. 
        /// 
        /// SYSTem:Error?
        /// </summary>
        /// <param name="awgNumber">The specified %AWG machine number</param>
        /*!
            \system\verbatim
        [When(@"I query the error queue on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I query the error queue on AWG ([1-4])")]
        public void QueryTheErrorQueueonAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.QueryTheErrorQueue(awg);
        }

        //glennj 3/24/2014
        /// <summary>
        /// Queries the error queue for a particular %AWG. 
        /// 
        /// SYSTem:Error?
        /// </summary>
        /// <param name="awgNumber">The specified %AWG machine number</param>
        /*!
            \system\verbatim
        [When(@"I query the error queue for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I query the error queue for AWG ([1-4])")]
        public void QueryTheErrorQueueForAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.QueryTheErrorQueue(awg);
        }

        //Jhowells 6-11-12
        //glennj 06/04/2013
        //jmanning 03/18/2014
        /// <summary>
        /// Queries the error queue for a 0 error message from a particular %AWG
        /// 
        /// Purposely no "get" step for the error queue, we want to get and check it every time.@n
        /// SYSTem:ERRor?
        /// </summary>
        /// <param name="awgNumber">The specified %AWG machine number [1-4]</param>
        /*!
            \system\verbatim
        [Then(@"there should be no error on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"there should be no error on AWG ([1-4])")]
        public void PreferredThereShouldBeNoErrorOnAwg(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.CheckForError(awg, true);
        }

        //glennj 3/25/2014
        /// <summary>
        /// Queries the error queue for a 0 error message from a particular %AWG
        /// 
        /// Purposely no "get" step for the error queue, we want to get and check it every time.@n
        /// SYSTem:ERRor?
        /// </summary>
        /// <param name="awgNumber">The specified %AWG machine number [1-4]</param>
        /*!
            \system\verbatim
        [Then(@"there should be no error for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"there should be no error for AWG ([1-4])")]
        public void PreferredThereShouldBeNoErrorForAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.CheckForError(awg, true);
        }

        //glennj 06/04/2013
        //jmanning 03/18/2014
        /// <summary>
        /// Queries the error queue for an error message fron the default %AWG
        /// 
        /// Purposely no "get" step for the error queue, we want to get and check it every time.@n
        /// SYSTem:ERRor?
        /// </summary>
        /*!
            \system\verbatim
        [Then(@"there should be an error on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"there should be an error on AWG ([1-4])")]
        public void ThenThereShouldBeAnErrorOnAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.CheckForError(awg, false);
        }

        //glennj 3/25/2014
        /// <summary>
        /// Queries the error queue for an error message fron the default %AWG
        /// 
        /// Purposely no "get" step for the error queue, we want to get and check it every time.@n
        /// SYSTem:ERRor?
        /// </summary>
        /*!
            \system\verbatim
        [Then(@"there should be an error for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"there should be an error for AWG ([1-4])")]
        public void PreferredThenThereShouldBeAnErrorForAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.CheckForError(awg, false);
        }

        //PHunter 08/08/12
        //jmanning 03/18/2014
        /// <summary>
        /// Verifies the last error code matches the expected value from the default %AWG
        /// 
        /// SYSTem:ERRor?
        /// </summary>
        /// <param name="expectedErrorNumber">The expected error code</param>
        /// <param name="awgNumber"></param>
        /*!
            \system\verbatim
        [Then(@"the expected error (.+) should be returned on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the expected error (.+) should be returned on AWG ([1-4])")]
        public void PreferredAnErrorShouldBeReturnedOnAwg(string expectedErrorNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.CheckForSpecificError(awg, expectedErrorNumber, true);
        }

        //glennj 3/25/2014
        /// <summary>
        /// Verifies the last error code matches the expected value from the default %AWG
        /// 
        /// SYSTem:ERRor?
        /// </summary>
        /// <param name="expectedErrorNumber">The expected error code</param>
        /// <param name="awgNumber"></param>
        /*!
            \system\verbatim
        [Then(@"the expected error (.+) should be returned for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the expected error (.+) should be returned for AWG ([1-4])")]
        public void PreferredAnErrorShouldBeReturnedForAwg(string expectedErrorNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.CheckForSpecificError(awg, expectedErrorNumber, true);
        }

        //Jhowells 6/11/12
        //jmanning 03/18/2014
        /// <summary>
        /// Compares the last error code for a particular %AWG against the expected value and fails if they match
        /// 
        /// SYSTem:ERRor?
        /// </summary>
        /// <param name="expectedValue">The expected error code</param>
        /// <param name="awgNumber">The specified %AWG machine number</param>
        /*!
            \system\verbatim
        [Then(@"a (.+) error should not be returned on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"a (.+) error should not be returned on AWG ([1-4])")]
        public void AnErrorShouldNotBeReturnedOnAWG(string expectedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.CheckForSpecificError(awg, expectedValue, false);
        }

        //Jhowells 6/11/12
        //jmanning 03/18/2014
        /// <summary>
        /// Compares the last error code for a particular %AWG against the expected value and fails if they match
        /// 
        /// SYSTem:ERRor?
        /// </summary>
        /// <param name="expectedValue">The expected error code</param>
        /// <param name="awgNumber">The specified %AWG machine number</param>
        /*!
            \system\verbatim
        [Then(@"a (.+) error should not be returned for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"a (.+) error should not be returned for AWG ([1-4])")]
        public void AnErrorShouldNotBeReturnedForAWG(string expectedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.CheckForSpecificError(awg, expectedValue, false);
        }

        //glennj 6/17/2013
        /// <summary>
        /// Check the last updated copy of system error quue for a specific error code
        /// </summary>
        /// <param name="expectedCode"></param>
        /// <param name="awgNumber"></param>
        /*!
            \system\verbatim
        [Then(@"the error code should be (.*) from AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the error code should be (.*) from AWG ([1-4])")]
        public void ThenTheErrorCodeShouldBeFromAWG(string expectedCode, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.TheErrorCodeShouldBeFromAWG(awg, expectedCode);
        }

        //glennj 3/24/2014
        /// <summary>
        /// Check the last updated copy of system error quue for a specific error code
        /// </summary>
        /// <param name="expectedCode"></param>
        /// <param name="awgNumber"></param>
        /*!
            \system\verbatim
        [Then(@"the error code should be (.*) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the error code should be (.*) for AWG ([1-4])")]
        public void ThenTheErrorCodeShouldBeForAWG(string expectedCode, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.TheErrorCodeShouldBeFromAWG(awg, expectedCode);
        }

        //glennj 6/17/2013
        /// <summary>
        /// Check the last updated copy of the system error for a specific phrase
        /// </summary>
        /// <param name="expectedPhrase"></param>
        /// <param name="awgNumber"></param>
        /*!
            \system\verbatim
        [Then(@"the error phrase should contain (.*) from AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the error phrase should contain (.*) from AWG ([1-4])")]
        public void ThenTheErrorPhraseShouldBeFromAWG(string expectedPhrase, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.TheErrorPhraseShouldBeFromAWG(awg, expectedPhrase);
        }

        //glennj 3/24/2014
        /// <summary>
        /// Check the last updated copy of the system error for a specific phrase
        /// </summary>
        /// <param name="expectedPhrase"></param>
        /// <param name="awgNumber"></param>
        /*!
            \system\verbatim
        [Then(@"the error phrase should contain (.*) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the error phrase should contain (.*) for AWG ([1-4])")]
        public void ThenTheErrorPhraseShouldBeForAWG(string expectedPhrase, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.TheErrorPhraseShouldBeFromAWG(awg, expectedPhrase);
        }

        #endregion SYSTem:Error?

        #region SYSTem:ERRor:COUNt?
        //glennj 8/29/2013
        /// <summary>
        /// Forces the AWG to update's its copy of number of errors in the system error queue
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \system\verbatim
        [When(@"I get the system error queue count on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the system error queue count on AWG ([1-4])")]
        public void GetTheSystemErrorQueueCount(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.GetSystemErrorQueueCount(awg);
        }

        //glennj 8/29/2013
        /// <summary>
        /// Tests an updated system error queue count property of the AWG
        /// </summary>
        /// <param name="expectedCount"></param>
        /// <param name="awgNumber"></param>
        /*!
            \system\verbatim
        [Then(@"the system error queue count should be (\d+) on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the system error queue count should be (\d+) on AWG ([1-4])")]
        public void SystemErrorQueueCountShouldBe(string expectedCount, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.SystemErrorQueueCountShouldBe(awg, expectedCount);
        }
        #endregion SYSTem:ERRor:COUNt?

        #region SYSTem:ERRor:DIALog

        //glennj 8/29/2013
        /// <summary>
        /// Set the Dialog display mode to On
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \system\verbatim
        [When(@"I set the system error dialog mode to on on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the system error dialog mode to on on AWG ([1-4])")]
        public void SetTheSystemErrorDialogModeToOn(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.SetSystemErrorDialogMode(awg, AwgSystemGroup.SystemErrorDialogMode.On);
        }

        //glennj 8/29/2013
        /// <summary>
        /// Set the Dialog display mode to Off
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \system\verbatim
        [When(@"I set the system error dialog mode to off on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the system error dialog mode to off on AWG ([1-4])")]
        public void SetTheSystemErrorDialogModeToOff(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.SetSystemErrorDialogMode(awg, AwgSystemGroup.SystemErrorDialogMode.Off);
        }

        //glennj 8/29/2013
        /// <summary>
        /// Get, update the AWG property of the for the system error dialog
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \system\verbatim
        [When(@"I get the system error dialog mode on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the system error dialog mode on AWG ([1-4])")]
        public void GetTheSystemErrorDialogMode(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.GetSystemErrorDialogMode(awg);
        }

        //glennj 8/29/2013
        /// <summary>
        /// Check to see that the System Error Dialog mode is on
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \system\verbatim
        [Then(@"the the system error dialog mode should be on on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the the system error dialog mode should be on on AWG ([1-4])")]
        public void TheSystemErrorDialogModeShouldBeOn(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.SystemErrorDialogModeShouldBe(awg, AwgSystemGroup.SystemErrorDialogMode.On);
        }

        //glennj 8/29/2013
        /// <summary>
        /// Check to see that the System Error Dialog mode is off
        /// </summary>
        /*!
            \system\verbatim
        [Then(@"the the system error dialog mode should be off on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the the system error dialog mode should be off on AWG ([1-4])")]
        public void TheSystemErrorDialogModeShouldBeOff(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.SystemErrorDialogModeShouldBe(awg, AwgSystemGroup.SystemErrorDialogMode.Off);
        }

        #endregion SYSTem:ERRor:DIALog

        #region SYSTem:TIME
        //Jhowells 6/11/12
        //Kavitha 01/30/2013: We need to relook at the regular expression here as it does not accept 23:50:40
        //Kavitha 02/01/2013: Changed the Reg Epxression to check hours, minutes, seconds separately
        //jmanning 03/18/2014
        /// <summary>
        /// Sets the system time
        /// 
        /// SYSTem:TIME
        /// </summary>
        /// <param name="hours">The hour value to set to</param>
        /// <param name="minutes">The minute value to set to</param>
        /// <param name="seconds">The second value to set to</param>
        /// <param name="awgNumber">The specified %AWG</param>
        /*!
            \system\verbatim
        [When(@"I set the system time to (2[0-4]|[0-1][0-9]) hours ([0-5][0-9]) minutes ([0-5][0-9]) seconds on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the system time to (2[0-4]|[0-1][0-9]) hours ([0-5][0-9]) minutes ([0-5][0-9]) seconds on AWG ([1-4])")]
        public void SetTheSystemTimeValueonAWG(string hours, string minutes, string seconds, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.AwgSystemTime(awg, hours, minutes, seconds);
        }

        //PWH 6-17-2013
        //jmanning 03/18/2014
        /// <summary>
        /// Gets the current system time and stores it
        /// 
        /// SYSTem:TIME?
        /// </summary>
        /// <param name="awgNumber">The specified %AWG</param>
        /*!
            \system\verbatim
        [When(@"I get the current AWG system time")]
            \endverbatim 
        */
        [When(@"I get the current system time on AWG ([1-4])")]
        public void GetTheCurrentAwgSystemTime(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.AwgSystemTimeQuery(awg);
        }


        //Jhowells 6/11/12
        //jmanning 03/18/2014
        /// <summary>
        /// Verifies the system hours, minutes, and seconds matches the expected valuess.
        /// 
        /// SYSTem:TIME?
        /// </summary>
        /// <param name="expectedHours">Expected hours</param>
        /// <param name="expectedMinutes">Expected minutes</param>
        /// <param name="expectedSeconds">Expected seconds</param>
        /// <param name="awgNumber">The specified %AWG</param>
        /*!
            \system\verbatim
        [Then(@"the AWG system time should be near (2[0-3]|[0-1][0-9]),([0-5][0-9]),([0-5][0-9])")]
            \endverbatim 
        */
        [Then(@"the system time should be near (2[0-3]|[0-1][0-9]),([0-5][0-9]),([0-5][0-9]) on AWG ([1-4])")]
        public void TheAWGSystemTimeShouldBeNear(string expectedHours, string expectedMinutes, string expectedSeconds, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.TimesShouldBeClose(awg, expectedHours, expectedMinutes, expectedSeconds);
        }
        #endregion SYSTem:TIME

        #region  SYSTem:VERSion?
        //Jhowells 6/11/12
        //jmanning 03/18/2014
        /// <summary>
        /// Gets the SCPI version number to which the command conforms.
        /// 
        /// SYSTem:VERSion?
        /// </summary>
        /// <param name="awgNumber">The particular %AWG machine number</param>
        /*!
             \system\verbatim
        [When(@"I get the system SCPI version on AWG ([1-4])")]
             \endverbatim 
        */
        [When(@"I get the system SCPI version on AWG ([1-4])")]
        public void GetAnAWGSystemScpiVersion(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.AwgUpdateScpiVersion(awg);
        }

        //Jhowells 6/11/12
        /// <summary>
        /// Verifies a particular %AWG's SCPI version matches the expected value
        /// 
        /// SYSTem:VERSion?
        /// </summary>
        /// <param name="awgNumber">The specified %AWG number</param>
        /// <param name="expectedVersion">The expected SCPI version</param>
        /*!
            \system\verbatim
        [Then(@"the AWG([1-4]) system SCPI version value should be (\d{4}\.\d)")]
            \endverbatim 
        */
        [Then(@"the system SCPI version value should be (\d{4}\.\d) on AWG ([1-4])")]
        public void AnAWGSystemScpiVersionValueShouldBe(string expectedVersion, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.VerifyScpiVersion(awg, expectedVersion);
        }
        #endregion SYSTem:VERSion?

        #region VISA SESSION READ
        //zkoppert 7/10/12
        /// <summary>
        /// Reads from the specified %AWG.
        /// 
        /// 
        /// </summary>
        /// <param name="awgNumber">The specified %AWG machine number</param>
        /*!
            \system\verbatim
        [When(@"I read from AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I read from AWG ([1-4])")]
        public void ReadFromTheAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSystemGroup.ReadFromAWG(awg);
        }
        #endregion VISA SESSION READ

        #region GIVEN CLOCK
        //GRJ 1/7/2013
        //jmanning 03/18/2014
        /// <summary>
        /// A particular %AWG may have more than 1 clock starting in PSR2.
        /// 
        /// Note: Implementation incomplete for this scenario
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \system\verbatim
        [Given(@"the AWG has one clock")]
            \endverbatim 
        */
        [Given(@"there is only one clock on AWG ([1-4])")] 
        public void GivenAnAWGHasOneClock(string awgNumber)
        {
#pragma warning disable 168
            var awg = AwgSetupSteps.GetAWG(awgNumber);
#pragma warning restore 168
            ScenarioContext.Current.Pending();
        }
        
        //GRJ 1/7/2013
        //jmanning 03/18/2014
        /// <summary>
        /// A particular %AWG may have more than 1 clock starting in PSR2.
        /// 
        /// Note: Implementation incomplete for this scenario
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \system\verbatim
        [Given(@"the AWG has one clock")]
            \endverbatim 
        */
        [Given(@"there are two clocks on AWG ([1-4])")]
        public void GivenAnAWGHasTwoClock(string awgNumber)
        {
#pragma warning disable 168
            var awg = AwgSetupSteps.GetAWG(awgNumber);
#pragma warning restore 168
            ScenarioContext.Current.Pending();
        }
        #endregion GIVEN CLOCK
    }
}