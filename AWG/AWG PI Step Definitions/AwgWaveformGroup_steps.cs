// AwgWaveformGroupLow_steps.cs
// This file contains the low-order PI step definitions for the AWG PI Waveform Group commands. 
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
// AWG number -  AWG([1-4])
// Filename or path strings - ""(.+)"" used when you want to include the quotes in the captured string 
//                            \""(.+)\"" used when you want only the string that is delimited by the quotes 
//==========================================================================

using TechTalk.SpecFlow;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains the PI step definitions for the %AWG PI Waveform Group commands.

    /// Generally the steps are set, get and should be operations.  The step sole responsibility
    /// is to make sure the correct %AWG object is used and that parameters such as channel,
    /// markers and clock references are correct for the %AWG object.
    /// 
    /// \ingroup highpi pisteps
    /// 
    /// </summary>
    [Binding] //Very important! This entry needs to be made in each step definition file. 
    public class AwgWaveformListSteps
    {
        private readonly AwgWaveformGroup _awgWaveformGroup = new AwgWaveformGroup();

        #region WLISt:LAST

        //Jhowells 8/28/12
        //glennj 7/29/2013
        /// <summary>
        /// Gets the name of the most recently added waveform in the asset list
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \waveform\verbatim
        [When(@"I get the name of the last added waveform to the list on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the name of the last added waveform to the list on AWG ([1-4])")]
        public void GetTheLastAddedWaveformNameFromWaveformList(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.GetNameofLastAddedWfmInWfmList(awg);
        }

        //Jhowells 8/28/12
        //glennj 7/29/2013
        /// <summary>
        /// Compares the name of the most recently added waveform in the asset list against the expected value.
        /// </summary>
        /// <param name="expectedValue"></param>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \waveform\verbatim
        [Then(@"the name of the last added waveform to the list should be ""(.+|)"" on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the name of the last added waveform to the list should be ""(.+|)"" on AWG ([1-4])")]
        public void ThentheLastAddedWaveformNameShouldBe(string expectedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.LastAddedWaveformNameShouldBe(awg, expectedValue);
        }
        #endregion WLISt:LAST

        #region WLISt:LIST

        //Jhowells 8/28/12
        //glennj 7/29/2013
        /// <summary>
        /// Gets the names of the waveforms in the waveform list.
        /// 
        /// WLISt:LIST? (query only)
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \waveform\verbatim
        [When(@"I get the list of the waveforms on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the list of the waveforms on AWG ([1-4])")]
        public void GettheListOfWaveforms(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.GetTheWaveformList(awg);
        }

        //Jhowells 8/28/12
        //glennj 8/9/2013
        /// <summary>
        /// Compares the list of waveforms against a given list of waveforms and makes sure they match.<para>
        /// The order of waveforms are not guaranteed.  Lists are sorted before doing a one to one compare.</para><para>
        /// Related to the WLISt:LIST? (query only)</para>
        /// </summary>
        /// <param name="listWfms">A list of waveforms</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \waveform\verbatim
        [Then(@"the list of ""(.+)"" should match the list of the waveforms on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the list of ""(.+)"" should match the list of the waveforms on AWG ([1-4])")]
        public void ThenListofWfmsShouldContain(string listWfms, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.WfmListShouldContainTheseWfms(awg, listWfms);
        }

        //glennj 8/9/2013
        /// <summary>
        /// Checks for inclusion of a given waveform name using the list of list results
        /// </summary>
        /// <param name="expectedWfmName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \waveform\verbatim
        [Then(@"the name of ""(.+)"" should be included in the list of the waveforms on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the name of ""(.+)"" should be included in the list of the waveforms on AWG ([1-4])")]
        public void TheNameOfTheWaveformFromWaveformListShouldBeIncluded(string expectedWfmName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.WaveformNameShouldBeIncluded(awg, expectedWfmName, true);
        }

        //glennj 8/9/2013
        /// <summary>
        /// Checks for exclusion of a given waveform name using the list of list results
        /// </summary>
        /// <param name="expectedWfmName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \waveform\verbatim
        [Then(@"the name of ""(.+)"" should not be included in the list of the waveforms on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the name of ""(.+)"" should not be included in the list of the waveforms on AWG ([1-4])")]
        public void TheNameOfTheWaveformFromWaveformListShouldNotBeIncluded(string expectedWfmName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.WaveformNameShouldBeIncluded(awg, expectedWfmName, false);
        }

        #endregion WLISt:LIST

        #region WLISt:NAME

        //Jhowells 8/28/12
        //glennj 7/29/2013
        /// <summary>
        /// Gets the name of the waveform at a particular index in the waveform list
        /// </summary>
        /// <param name="listIndex">Waveform List Index</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \waveform\verbatim
        [When(@"I get the name of the waveform with an index of ((?<!\S)[-+]?\d+(?!\S)) in the waveform list on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the name of the waveform with an index of ((?<!\S)[-+]?\d+(?!\S)) in the waveform list on AWG ([1-4])")]
        public void GetTheNameOfTheWaveformeAtWaveformListIndex(string listIndex, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.GetWaveformAtIndex(awg, listIndex);
        }

        //Jhowells 8/28/12
        //glennj 7/29/2013
        /// <summary>
        /// Compares the name of the waveform against the expected value.
        /// </summary>
        /// <param name="expectedValue">Expected waveform name</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \waveform\verbatim
        [Then(@"the name of the waveform should be (.+) on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the name of the waveform should be (.+) on AWG ([1-4])")]
        public void TheNameOfTheWaveformAtWaveformListIndexShouldBe(string expectedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.WaveformNameAtIndexShouldBe(awg, expectedValue);
        }

        #endregion WLISt:NAME

        #region WLISt:SIZE

        //Jhowells 8/28/12
        //glennj 7/30/2013
        /// <summary>
        /// Gets the size of the waveform list.
        /// 
        /// WLISt:SIZE? (query only)
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \waveform\verbatim
        [When(@"I get the number of waveforms in the waveform list on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the number of waveforms in the waveform list on AWG ([1-4])")]
        public void GetTheNumberOfEntriesInTheWaveformList(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.GetNumberOfWaveformListEntries(awg);
        }

        //Jhowells 8/28/12
        //glennj 7/30/2013
        /// <summary>
        /// Compares the size of the waveform list against the expected value.
        /// 
        /// WLISt:SIZE? (query only)
        /// </summary>
        /// <param name="expectedValue">Expected number of entries</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \waveform\verbatim
        [Then(@"the number of waveforms should be ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the number of waveforms should be ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
        public void ThereShouldBeEntriesInTheWaveformList(string expectedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.ShouldBeAGivenNumberOfEntriesInWfmList(awg, expectedValue);
        }

        //Jhowells 1/23/13
        //glennj 7/30/2013
        //jmanning 03/17/2014
        // TODO: Should consider breaking this into multiple steps as in
        // a. Start the timer
        // b. do what ever work there is
        // c. Stop the timer and test the period
        /// <summary>
        /// Waits for the waveform list to have a waveform to be added
        /// 
        /// WLISt:SIZE? (query only)
        /// </summary>
        /// <param name="seconds">Time limit to wait for an entry to be added the waveform list</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \waveform\verbatim
        [When(@"I wait for up to ([0-9]+) seconds to add an entry to waveform list on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I wait for up to ([0-9]+) seconds to add an entry to waveform list on AWG ([1-4])")]
        public void WaitForEntryToWaveformList(string seconds, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.WaitForWfmListToAddWfms(awg, "1", seconds);
        }


        //Jhowells 1/23/13
        //glennj 7/30/2013
        //jmanning 03/17/2014
        // TODO: Should consider breaking this into multiple steps as in
        // a. Start the timer
        // b. do what ever work there is
        // c. Stop the timer and test the period
        /// <summary>
        /// Waits for the waveform list to have multiple waveforms added
        /// 
        /// WLISt:SIZE? (query only)
        /// </summary>
        /// <param name="numEntries">The number of waveforms to be added</param>
        /// <param name="seconds">Time limit to wait for an entry to the waveform list</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \waveform\verbatim
        [When(@"I wait for up to ([0-9]+) seconds to add ([0-9]+) entries to waveform list on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I wait for up to ([0-9]+) seconds to add ([0-9]+) entries to waveform list on AWG ([1-4])")]
        public void WaitForEntriesToWaveformList(string seconds, string numEntries, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.WaitForWfmListToAddWfms(awg, numEntries, seconds);
        }

        #endregion WLISt:SIZE

        #region WLISt:WAVeform:DATA

        // Unkown - 01/01/01
        //glennj 09/16/2013
        /// <summary>
        /// Transfers waveform data from an external controller into a specified waveform asset<para>
        /// It is important to note that only floating point is support which makes it a challenge to</para><para>
        /// type in a ascii and expect to be accurate.  So only reading and writing to files is being</para><para>
        /// supported.</para><para>
        /// NOTE: Before transferring data to the instrument, a waveform asset must be created@n</para><para>
        /// using the WLISt:WAVeform:NEW command. Use WLISt:WAVeform:DATA to set analog data. @n</para><para>
        /// To set the marker data, use the WLISt:WAVeform:MARKer:DATA command.@n</para>
        /// </summary>
        /// <param name="filePath">path to Block of data</param>
        /// <param name="startIndex">index to first byte in the block of data</param>
        /// <param name="blockSize">The size of the block in number of bytes</param>
        /// <param name="wfmName">Name of the waveform asset</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
           \waveform\verbatim
        [When(@"I transfer from a local file at path ""(.+)"" as a block of data starting at index (\d+) and block size of (\d+) to waveform ""(.+)"" on AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I transfer from a local file at path ""(.+)"" as a block of data starting at index (\d+) and block size of (\d+) to waveform ""(.+)"" on AWG ([1-4])")]
        public void TransferContentsOfFileAsBlockAtIndexBlockSizeToWaveformAsset(string filePath, string startIndex, string blockSize, string wfmName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.TransferWaveformDataByPieceFromPath(awg, wfmName, filePath, startIndex, blockSize);
        }

        // Unkown - 01/01/01
        //glennj 09/16/2013
        /// <summary>
        /// Transfers waveform data from an external controller into a specified waveform asset<para>
        /// It is important to note that only floating point is support which makes it a challenge to</para><para>
        /// type in a ascii and expect to be accurate.  So only reading and writing to files is being</para><para>
        /// supported.</para><para>
        /// NOTE: Before transferring data to the instrument, a waveform asset must be created@n</para><para>
        /// using the WLISt:WAVeform:NEW command. Use WLISt:WAVeform:DATA to set analog data. @n</para><para>
        /// To set the marker data, use the WLISt:WAVeform:MARKer:DATA command.@n</para>
        /// </summary>
        /// <param name="filePath">path to Block of data</param>
        /// <param name="startIndex">index to first byte in the block of data</param>
        /// <param name="wfmName">Name of the waveform asset</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
           \waveform\verbatim
        [When(@"I transfer from a local file at path ""(.+)"" as a block of data starting at index (\d+) to waveform ""(.+)"" on AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I transfer from a local file at path ""(.+)"" as a block of data starting at index (\d+) to waveform ""(.+)"" on AWG ([1-4])")]
        public void TransferContentsOfFileAsBlockAtIndexToWaveformAsset(string filePath, string startIndex, string wfmName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.TransferWaveformDataFromPath(awg, wfmName, filePath, AwgWaveformGroup.WaveformData.AnalogOnly, startIndex);
        }

        // Unkown - 01/01/01
        //glennj 09/16/2013
        /// <summary>
        /// Transfers waveform data from an external controller into a specified waveform asset
        /// </summary>
        /// <param name="filePath">path to Block of data</param>
        /// <param name="wfmName">Name of the waveform asset</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
           \waveform\verbatim
        [When(@"I transfer from a local file at path ""(.+)"" as a block of data to waveform ""(.+)"" on AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I transfer from a local file at path ""(.+)"" as a block of data to waveform ""(.+)"" on AWG ([1-4])")]
        public void TransferContentsOfFileAsBlockToWaveformAsset(string filePath, string wfmName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.TransferWaveformDataFromPath(awg, wfmName, filePath, AwgWaveformGroup.WaveformData.AnalogOnly);
        }

        //glennj 9/19/2013
        /// <summary>
        /// Transfers waveform data to an external controller from a specified waveform asset.<para>
        /// Data that is transferred from a waveform is specified by a starting index and block size.</para>
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="blockSize"></param>
        /// <param name="wfmName"></param>
        /// <param name="awgNumber"></param>
        /*!
           \waveform\verbatim
        [When(@"I get a block of data starting at index (\d+) and block size of (\d+) from the waveform ""(.+)"" from AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I get a block of data starting at index (\d+) and block size of (\d+) from the waveform ""(.+)"" from AWG ([1-4])")]
        public void TransferToLocalFileAtPathABlockOfIndexBlockSizeFromWaveform(string startIndex, string blockSize, string wfmName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.TransferWaveformDataToPath(awg, wfmName, AwgWaveformGroup.WaveformData.AnalogOnly, startIndex, blockSize);
        }

        //glennj 9/19/2013
        /// <summary>
        /// Transfers waveform data to an external controller from a specified waveform asset.<para>
        /// Data that is transferred from a waveform is specified by a starting index.</para>
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="wfmName"></param>
        /// <param name="awgNumber"></param>
        /*!
           \waveform\verbatim
        [When(@"I get a block of data starting at index (\d+) from the waveform ""(.+)"" from AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I get a block of data starting at index (\d+) from the waveform ""(.+)"" from AWG ([1-4])")]
        public void TransferToLocalFileAtPathABlockOfIndexFromWaveform(string startIndex, string wfmName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.TransferWaveformDataToPath(awg, wfmName, AwgWaveformGroup.WaveformData.AnalogOnly, startIndex);
        }

        //glennj 9/19/2013
        /// <summary>
        /// Transfers all waveform data to an external controller from a specified waveform asset.
        /// </summary>
        /// <param name="wfmName"></param>
        /// <param name="awgNumber"></param>
        /*!
           \waveform\verbatim
        [When(@"I get a block of data for the waveform ""(.+)"" from AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I get a block of data for the waveform ""(.+)"" from AWG ([1-4])")]
        public void TransferABlockFromWaveform(string wfmName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            //_awgWaveformGroup.TransferWaveformDataToPath(awg, wfmName, filePath, AwgWaveformGroup.WaveformData.AnalogOnly);
            _awgWaveformGroup.TransferWaveformDataToPath(awg, wfmName, AwgWaveformGroup.WaveformData.AnalogOnly);
        }

        //glennj 9/20/2013
        /// <summary>
        /// 
        /// </summary>
        /// <param name="originalPath"></param>
        /// <param name="awgNumber"></param>
        /*!
           \waveform\verbatim
        [Then(@"the local file at path ""(.+)"" should be the same as the block of data on AWG ([1-4])")]
           \endverbatim 
        */
        [Then(@"the local file at path ""(.+)"" should be the same as the block of data on AWG ([1-4])")]
        public void AnalogDataOfReadbackFileShouldBeTheSameAsOriginal(string originalPath, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.CompareWaveformFiles(awg, originalPath);
        }

        //glennj 9/20/2013
        /// <summary>
        /// This is a very special case.  Not generally used.  It is for a test case that starts with a new<para>
        /// waveform and and the waveform is filled with blocks.  Not all blocks are filled so that </para><para>
        /// some of the waveform should still be zero.</para>
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
           \waveform\verbatim
        [Then(@"the block of data should be zeros on AWG ([1-4])")]
           \endverbatim 
        */
        [Then(@"the block of data should be zeros on AWG ([1-4])")]
        public void AnalogDataOfReadbackFileShouldBeZero(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.BlockOfDataShouldBeZeros(awg);
        }

        #endregion WLISt:WAVeform:DATA

        #region WLISt:WAVeform:DELete

        //Jhowells 8/30/12
        //glennj 7/30/2013
        /// <summary>
        /// Deletes a waveform from the currently loaded setup.
        /// </summary>
        /// <param name="wfmName">Waveform Name</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \waveform\verbatim
        [When(@"I delete the waveform ""(.+)"" from the waveform list on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I delete the waveform ""(.+)"" from the waveform list on AWG ([1-4])")]
        public void DeleteWaveformListItem(string wfmName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.DeleteWfmFromWaveformList(awg, wfmName);
        }

        //glennj 7/30/2013
        /// <summary>
        /// Deletes all the waveforms from the currently loaded setup.
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \waveform\verbatim
        [When(@"I delete all waveforms from the waveform list on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I delete all waveforms from the waveform list on AWG ([1-4])")]
        public void DeleteAllWaveformListItems(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            const string wfmName = "ALL";
            _awgWaveformGroup.DeleteWfmFromWaveformList(awg, wfmName);
        }

        #endregion WLISt:WAVeform:DELete

        #region WLISt:WAVeform:LMAXimum

        //Kavitha 1/29/2013
        //glennj 7/30/2013
        /// <summary>
        /// Gets the maximum sample points allowed for the waveform
        /// 
        /// WLISt:WAVeform:LMAXimum? (query only)
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
          \waveform\verbatim
        [When(@"I get the maximum sample points allowed for any waveform on AWG ([1-4])")]
          \endverbatim 
        */
        [When(@"I get the maximum sample points allowed for any waveform on AWG ([1-4])")]
        public void GetTheMaximumSamplePointsAllowedForWaveformsInTheWaveformList(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.GetWfmMaxSamplePoints(awg);
        }

        //Kavitha 1/29/2013
        //glennj 7/30/2013
        /// <summary>
        /// Compares the maximum sample points queried against the expected value.
        /// 
        /// </summary>
        /// <param name="expectedValue">Expected number of entries</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
          \waveform\verbatim
        [Then(@"the maximum sample points allowed for the waveform should be ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
          \endverbatim 
        */
        [Then(@"the maximum sample points allowed for the waveform should be ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
        public void TheMaximumSamplePointsAllowedForTheWaveform(string expectedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.MaxWfmSamplePointsShouldBe(awg, expectedValue);
        }

        #endregion WLISt:WAVeform:LMAXimum

        #region WLISt:WAVeform:LMINimum

        //Kavitha 1/29/2013
        /// <summary>
        /// Gets the minimum sample points allowed for the waveform
        /// 
        /// WLISt:WAVeform:LMINimum? (query only)
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
          \waveform\verbatim
        [When(@"I get the minimum sample points allowed for any waveform on AWG ([1-4])")]
          \endverbatim 
        */
        [When(@"I get the minimum sample points allowed for any waveform on AWG ([1-4])")]
        public void GetTheMinimumSamplePointsAllowedForWaveformsInTheWaveformList(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.GetWfmMinSamplePoints(awg);
        }

        //Kavitha 1/29/2013
        /// <summary>
        /// Compares the minimum sample points queried against the expected value.
        /// 
        /// </summary>
        /// <param name="expectedValue">Expected number of entries</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
          \waveform\verbatim
        [Then(@"the minimum sample points allowed for the waveform should be ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
          \endverbatim 
        */
        [Then(@"the minimum sample points allowed for the waveform should be ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
        public void TheMinimumSamplePointsAllowedForTheWaveform(string expectedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.MinWfmSamplePointsShouldBe(awg, expectedValue);
        }

        #endregion WLISt:WAVeform:LMINimum

        #region WLISt:WAVeform:GRANularity
        
        //sforell 8/8/13 added the step 
        //jmanning 03/17/2014
        /// <summary>
        /// Gets the granularity of the waveforms in the waveform list
        /// </summary>
        /// <param name="awgNumber">The specified awg</param>
        /*!
            \waveform\verbatim
        [When(@"I get the Granularity from the waveform list on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the Granularity from the waveform list on AWG ([1-4])")]
        public void GetTheGranularityFromWaveformList(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.GetGranularityFromWaveformList(awg);
        }

        //sforell 8/8/13 added the step
        //jmanning 03/17/2014
        /// <summary>
        /// Compares the granularity from the awg to the expected granularity of one
        /// </summary>
        /// <param name="awgNumber">The specified awg</param>
        /*!
            \waveform\verbatim
        [Then(@"the Granularity from the waveform list should be one on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the Granularity from the waveform list should be one on AWG ([1-4])")]
        public void GranularityFromWaveformListShouleBeOne(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.GranularityFromWaveformListShouldBe(awg, "1");
        }

        //sforell 8/8/13 added the step
        /// <summary>
        /// Compares the granularity from the awg to the expected granularity of two
        /// </summary>
        /// <param name="awgNumber">The specified awg</param>
        /*!
            \waveform\verbatim
        [Then(@"the Granularity from the waveform list should be two on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the Granularity from the waveform list should be two on AWG ([1-4])")]
        public void GranularityFromWaveformListShouleBeTwo(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.GranularityFromWaveformListShouldBe(awg, "2");
        }



        #endregion WLISt:WAVeform:GRANularity

        #region WLISt:WAVeform:LENGth

        //Jhowells 8/28/12
        //glennj 7/30/2013
        /// <summary>
        /// Gets the length of the given waveform
        /// 
        /// WLIST:WAVeform:LENGth? (Query Only)
        /// </summary>
        /// <param name="wfmName">Name of the waveform</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \waveform\verbatim
        [When(@"I get the length of the waveform (.+) from the waveform list on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the length of the waveform (.+) from the waveform list on AWG ([1-4])")]
        public void GetTheLengthofWaveformFromWaveformList(string wfmName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.GetLengthofWfmInWaveformList(awg, wfmName);
        }

        //Jhowells 8/28/12
        //glennj 7/30/2013
        /// <summary>
        /// Compares the the length of the waveform against the expected value.
        /// </summary>
        /// <param name="expectedValue">Expected waveform length</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \waveform\verbatim
        [Then(@"the length of the waveform should be (.+) on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the length of the waveform should be (.+) on AWG ([1-4])")]
        public void ThenLengthofWaveformShouldBe(string expectedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.LengthOfWfmFromWaveformListShouldBe(awg, expectedValue);
        }

        #endregion WLISt:WAVeform:LENGth

        #region WLISt:WAVeform:MARKer:DATA

        //sforell 8/9/13 added step for WLISt:WAVeform:MARKer:DATA
        /// <summary>
        /// Sets the waveform marker data
        /// </summary>
        /// <param name="awgNumber">The specific AWG</param>
        /// <param name="wfmName">The name of the waveform in the waveform list</param>
        /// <param name="startIndex">The sample point to start from</param>
        /// <param name="size">The number of sample points to set</param>
        /// <param name="blockData">The data being set</param>
        /*!
           \waveform\verbatim
        [When(@"I set the waveform marker data to ""(.*)"" starting at index ((?<!\S)[-+]?\d+(?!\S)) of size ((?<!\S)[-+]?\d+(?!\S)) from waveform (.+) on AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I set the waveform marker data to ""(.*)"" starting at index ((?<!\S)[-+]?\d+(?!\S)) of size ((?<!\S)[-+]?\d+(?!\S)) from waveform (.+) on AWG ([1-4])")]
        public void SetWaveformMarkerData(string blockData, string startIndex, string size, string wfmName,  string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.SetWaveformMarkerData(awg, wfmName, startIndex, size, blockData);
        }

        //sforell 8/9/13 added step for WLISt:WAVeform:MARKer:DATA
        /// <summary>
        /// Gets the waveform marker data
        /// </summary>
        /// <param name="startIndex">The sample point to start from</param>
        /// <param name="size">The number of sample points to set</param>
        /// <param name="wfmName">The name of the waveform in the waveform list</param>
        /// <param name="awgNumber">The specific AWG</param>
        /*!
           \waveform\verbatim
        [When(@"I get the waveform marker data starting at index ((?<!\S)[-+]?\d+(?!\S)) of size ((?<!\S)[-+]?\d+(?!\S)) from waveform (.+) on AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I get the waveform marker data starting at index ((?<!\S)[-+]?\d+(?!\S)) of size ((?<!\S)[-+]?\d+(?!\S)) from waveform (.+) on AWG ([1-4])")]
        public void GetWaveformMarkerData(string startIndex, string size, string wfmName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.GetWaveformMarkerData(awg, wfmName, startIndex, size);
        }

        //sforell 8/9/13 added step for WLISt:WAVeform:MARKer:DATA
        /// <summary>
        /// Compares the waveform market data to the expected value
        /// </summary>
        /// <param name="awgNumber">The specified awg</param>
        /// <param name="expectedValue">The expected value to check for</param>
        /*!
           \waveform\verbatim
        [Then(@"the waveform marker data should be ""(.+)"" on AWG ([1-4])")]
           \endverbatim 
        */
        [Then(@"the waveform marker data should be ""(.+)"" on AWG ([1-4])")]
        public void TheWaveformMarkerDataShouldBe(string expectedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.CompareWaveformMarkerData(awg, expectedValue);
        }

        #endregion WLISt:WAVeform:MARKer:DATA

        #region WLISt:WAVeform:NEW

        // Unkown - 01/01/01
        //glennj 7/30/2013
        /// <summary>
        /// Creates a new waveform of the given size with the given name and loads it into the waveform list
        /// </summary>
        /// <param name="wfmName">Name of the new waveform</param>
        /// <param name="size">Desired size of the new waveform</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
           \waveform\verbatim
        [When(@"I create a new waveform named ""(.+)"" of size ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I create a new waveform named ""(.+)"" of size ((?<!\S)[-+]?\d+(?!\S)) on AWG ([1-4])")]

        public void CreateANewWaveform(string wfmName, string size, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.CreateANewWaveform(awg, wfmName, size);
        }
        #endregion WLISt:WAVeform:NEW

        #region WLISt:WAVeform:SFORmat

        //Keerthi 05/28/2015
        /// <summary>
        /// sets the signal format for a given waveform name
        /// </summary>
        /// <param name="signalFormat">Signal format type</param>
        /// <param name="wfmName">Name of the waveform</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
           \waveform\verbatim
        [When(@"I set the signal format to ""(.*)"" for waveform named ""(.*)"" on AWG (.*)")]
           \endverbatim 
         */

        [When(@"I set the signal format to ""(.*)"" for waveform named ""(.*)"" on AWG (.*)")]
        public void SetTheSignalFormaForWaveformNamed(string signalFormat, string wfmName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.SetSignalFormat(signalFormat, wfmName, awg);
        }

        #endregion WLISt:WAVeform:SFORmat

        #region WLISt:WAVeform:SFORmat?

        //Keerthi 05/28/2015
        /// <summary>
        /// Gets the signal format for a given waveform name
        /// </summary>
        /// <param name="wfmName">Name of the waveform</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
           \waveform\verbatim
        [When(@"I get the signal format of the waveform named ""(.*)"" for AWG ([1-4])")]
           \endverbatim 
         */

        [When(@"I get the signal format of the waveform named ""(.*)"" for AWG ([1-4])")]

        public void GetTheSignalFormatOfTheWaveformNamed(string wfmName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.GetSignalFormat(wfmName, awg);
        }

        //Keerthi 05/28/2015
        /// <summary>
        /// After getting the signal format for a given waveform name
        /// Compares the signal format type against the expected value
        /// </summary>
        /// <param name="expectedSignalFormat">Expected signal format type</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
           \waveform\verbatim
        [Then(@"the signal format of the waveform should be (.*) for AWG ([1-4])")]
           \endverbatim 
         */

        [Then(@"the signal format of the waveform should be (.*) for AWG ([1-4])")]

        public void SignalFormatOfTheWaveformShouldBe(string expectedSignalFormat, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.SignalFormatShouldBe(expectedSignalFormat, awg);
        }

       #endregion WLISt:WAVeform:SFORmat?

        #region WLISt:WAVeform:NORMalize

        //Jhowells 8/30/12
        //glennj 7/30/2013
        /// <summary>
        /// Normalizes a waveform that exists in the waveform list to the full range
        /// </summary>
        /// <param name="wfmName">Name of the waveform</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
           \waveform\verbatim
        [When(@"I normalize the waveform ""(.+)"" from the waveform list to the full amplitude range on AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I normalize the waveform ""(.+)"" from the waveform list to the full amplitude range on AWG ([1-4])")]
        public void NormalizeWaveformFromWaveformListToFullScale(string wfmName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.NormalizeWfmFromWaveformList(awg, wfmName, AwgWaveformGroup.WaveformNormalized.FullScale);
        }

        //glennj 7/30/2013
        /// <summary>
        /// Normalizes a waveform that exists in the waveform list to the full range while preserving zero offset
        /// </summary>
        /// <param name="wfmName">Name of the waveform</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
           \waveform\verbatim
        [When(@"I normalize the waveform ""(.+)"" from the waveform list to the full amplitude range while preserving the offset on AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I normalize the waveform ""(.+)"" from the waveform list to the full amplitude range while preserving the offset on AWG ([1-4])")]
        public void NormalizeWaveformFromWaveformListToZeroReference(string wfmName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.NormalizeWfmFromWaveformList(awg, wfmName, AwgWaveformGroup.WaveformNormalized.ZeroOffset);
        }

        #endregion WLISt:WAVeform:NORMalize

        #region WLISt:WAVeform:RESAmple

        //Jhowells 8/30/12
        //glennj 7/31/2013
        /// <summary>
        /// Resamples a waveform that exists in the waveform list
        /// 
        /// WLISt:WAVeform:RESAmple
        /// </summary>
        /// <param name="wfmName">Name of the waveform</param>
        /// <param name="size">Size to resample to</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
           \waveform\verbatim
        [When(@"I resample the waveform ""(.+)"" from the waveform list to size (.*) on AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I resample the waveform ""(.+)"" from the waveform list to size (.*) on AWG ([1-4])")]
        public void ResampleWaveformFromWaveformList(string wfmName, string size, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.ResampleWfmFromWaveformList(awg, wfmName, size);
        }

        #endregion WLISt:WAVeform:RESAmple

        #region WLISt:WAVeform:SHIFt

        //Jhowells 8/30/12
        //glennj 7/31/2013
        /// <summary>
        /// Shifts a waveform that exists in the waveform list
        /// 
        /// WLISt:WAVeform:SHIFt 
        /// </summary>
        /// <param name="wfmName">Name of the waveform</param>
        /// <param name="degrees">Number of degrees to shift</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
           \waveform\verbatim
        [When(@"I shift the waveform ""(.+)"" from the waveform list by (.*) degrees on AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I shift the waveform ""(.+)"" from the waveform list by (.*) degrees on AWG ([1-4])")]
        public void ShiftWaveformFromWaveformList(string wfmName, string degrees, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.ShiftWfmFromWaveformList(awg, wfmName, degrees);
        }

        #endregion WLISt:WAVeform:SHIFt

        #region WLISt:WAVeform:TSTamp

        //Jhowells 8/30/12
        //glennj 7/31/2013
        /// <summary>
        /// Gets the timestamp of the given waveform
        /// 
        /// WLIST:WAVeform:TSTamp? (Query only)
        /// </summary>
        /// <param name="wfmName">Name of the waveform</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \waveform\verbatim
        [When(@"I get the timestamp of the waveform ""(.+)"" from the waveform list on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the timestamp of the waveform ""(.+)"" from the waveform list on AWG ([1-4])")]
        public void GetTheTimestampofWaveformFromWaveformList(string wfmName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.GetTimestampofWfmfromWavefomList(awg, wfmName);
        }

        // Unkown - 01/01/01
        //glennj 7/31/2013
        /// <summary>
        /// Using the results of a query of WLIST:WAVeform:TSTamp?<para>
        /// compares the timestamp against the expected value.</para><para>
        /// TODO  This needs to be revisited.  This maybe should even be eliminated/removed.
        /// </para>
        /// </summary>
        /// <param name="expectedValue">Expected timestamp YYYY/MM/DD HH:MM:SS</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
          \waveform\verbatim
        [Then(@"the timestamp of the waveform should be ((?:19[0-9]{2}|20[0-9]{2})/(?:1[0-2]|0[1-9])/[0-3][0-9] (?:2[1-4]|1[0-9]|[0-9]):[0-5][0-9]:[0-5][0-9]) on AWG ([1-4])")]
          \endverbatim 
        */
        [Then(@"the timestamp of the waveform should be ((?:19[0-9]{2}|20[0-9]{2})/(?:1[0-2]|0[1-9])/[0-3][0-9] (?:2[1-4]|1[0-9]|[0-9]):[0-5][0-9]:[0-5][0-9]) on AWG ([1-4])")]
        public void ThenTimestampofWaveformOnTheAwgShouldBe(string expectedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.TimestampOfWfmFromWaveformListShouldBe(awg, expectedValue);
        }

        // Unkown - 01/01/01
        //glennj 7/31/2013
        /// <summary>
        /// Using the results of a query of WLIST:WAVeform:TSTamp?<para>
        /// compare the timestamp of the waveform against the expected format.</para><para>
        /// Expected timestamp pattern YYYY/MM/DD HH:MM:SS@n</para>
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
           \waveform\verbatim
        [Then(@"the timestamp of the waveform should be in an expected format on AWG ([1-4])")]
           \endverbatim 
       */
        [Then(@"the timestamp of the waveform should be in an expected format on AWG ([1-4])")]
        public void ThenTimestampofWaveformOnTheAwgShouldMatchExpectedPattern(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.TimestampOfWfmFromWaveformListShouldMatchPattern(awg);
        }
        #endregion WLISt:WAVeform:TSTamp

        #region WLISt:WAVeform:TYPE

        //Jhowells 8/30/12
        //glennj 7/31/2013
        /// <summary>
        /// Gets the waveform type
        /// 
        /// WLISt:WAVEform:TYPE? (Query Only)
        /// </summary>
        /// <param name="wfmName">Waveform Name</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \waveform\verbatim
        [When(@"I get the type of the waveform ""(.+)"" on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the type of the waveform ""(.+)"" on AWG ([1-4])")]
        public void GetTheTypeOfTheWaveform(string wfmName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.GetTypeofWfmInWaveformList(awg, wfmName);
        }

        //Jhowells 8/30/12
        //glennj 7/31/2013
        /// <summary>
        /// After getting the type using WLISt:WAVEform:TYPE?<para>
        /// compares the waveform type against the expected value.</para>
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \waveform\verbatim
        [Then(@"then the type of the waveform should be real on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"then the type of the waveform should be real on AWG ([1-4])")]
        public void ThenTypeOfTheWaveform(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.WaveformTypeShouldBe(awg, AwgWaveformGroup.WaveformType.Real);
        }

        #endregion WLISt:WAVeform:TYPE

        #region WLISt:WAVEfrom:SRATe

        /// <summary>
        ///  //sdas2 6/3/2015
        /// Set the sampling rate of the particular waveform 
        /// 
        /// WLISt:WAVEform:SRATe<wfmName>,<sRate>
        /// </summary>
        /// <param name="wfmName">Waveform Name</param>
        /// <param name=sRate>Specific Sample rate</param>

        [When(@"I set the  ""(.+)"" ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?)Samples value for the AWG ([1-4])")]
        public void SetTheSamplerateOfWaveformToTheAWG(string wfmName, string sRate, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.SamplerateWfmFromWaveformList(awg, wfmName, sRate);
            // ScenarioContext.Current.Pending();
        }


        /// <summary>
        ///  //sdas2 6/3/2015
        /// Gets the sampling rate of the particular waveform 
        /// WLISt:WAVEform:SRATe? (Query only)
        /// </summary>
        /// <param name="wfmName">Waveform Name</param>
        /// <return> Always return the Sampling rate of the Specific Waveform </return>

        [When(@"I get the query for ""(.+)"" command to the AWG ([1-4])")]
        public void GetTheSampleRateOfWaveformToTheAWG(string wfmName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.GetSamplerateWfmFromWaveformList(awg, wfmName);
            //ScenarioContext.Current.Pending();
        }

        /// <summary>
        /// //sdas2 6/3/2015
        /// Gets the  default sampling rate of the particular waveform 
        /// And Compairing 
        /// WLISt:WAVEform:SRATe? (Query only)
        /// </summary>
        /// <param name="wfmName">Waveform Name</param>
        /// <param name="actualSrate">Actual Sampling Rate</param>>

        [When(@"the Samplerate of waveform should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for AWG (.*)")]
        public void CompareSamplerateOfWaveformOnAWG(string actualSrate, string awgNumber)
        {

            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgWaveformGroup.CompareWaveformSRATE(awg, actualSrate);

            //ScenarioContext.Current.Pending();
        }
        #endregion WLISt:WAVeform:SRATe

        public string expectedSignalFormat { get; set; }
    }
}