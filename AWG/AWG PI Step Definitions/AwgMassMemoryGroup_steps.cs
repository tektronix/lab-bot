//==========================================================================
// AwgMassMemoryGroupLow_steps.cs
// This file contains the low-order PI step definitions for the AWG PI Mass Memory Group commands. 
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
// File path strings - ""(.+)"" used when you want the string that is delimited by the quotes
//==========================================================================

using TechTalk.SpecFlow;

namespace AwgTestFramework
{
    /// <summary> 
    /// This class contains the PI step definitions for the %AWG PI Mass Memory Group commands.

    /// Generally the steps are set, get and should be operations.  The step sole responsibility
    /// is to make sure the correct %AWG object is used and that parameters such as channel,
    /// markers and clock references are correct for the %AWG object.
    /// 
    /// \ingroup highpi pisteps
    /// 
    /// </summary>
    [Binding] //Very important! This entry needs to be made in each step definition file. 
    public class AwgMassMemorySteps
    {
        // Objects used to support the Mass Memory Steps
        readonly AwgMassMemoryGroup _awgMassMemoryGroup = new AwgMassMemoryGroup();

        #region MMEMory:CATalog

        //PHunter 20121113
        //glennj 7/3/2013
        /// <summary>
        /// Gets current contents of the mass storage media on a AWG and specific drive
        /// 
        /// MMEMory:CATalog? "msus" (query only)
        /// </summary>
        /// <param name="msus">Mass storage unit specifer</param>
        /// <param name="awgNumber"></param>
        /*!
            \massmemory\verbatim
        [When(@"I get the mass memory catalog from drive (\w:) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the mass memory catalog from drive (\w:) for AWG ([1-4])")]
        public void GetTheMassMemoryCatalog(string msus, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.GetTheMassMemoryCatalog(awg, msus);
        }

        //PHunter 20121113
        //glennj 7/3/2013
        /// <summary>
        /// Gets current contents of the mass storage media on a AWG and default drive
        /// 
        /// MMEMory:CATalog? (query only)
        /// </summary>
        /*!
            \massmemory\verbatim
        [When(@"I get the mass memory catalog for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the mass memory catalog for AWG ([1-4])")]
        public void GetTheMassMemoryCatalog(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            const string msus = "";
            _awgMassMemoryGroup.GetTheMassMemoryCatalog(awg, msus);
        }

        //Jhowells
        /// <summary>
        /// Get a warm fuzzy feeling that the mass memory catalog works when<para>
        /// in the returned string a partial string for a Recycle bin is present.</para>
        /// 
        /// MMEMory:CATalog? (query only)
        /// </summary>
        /*!
            \massmemory\verbatim
        [Then(@"the mass memory catalog should be valid for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the mass memory catalog should be valid for AWG ([1-4])")]
        public void ThenTheMassMemoryCatalogShouldBeValid(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.TheMassMemoryCatalogShouldBeValid(awg);
        }

        #endregion MMEMory:CATalog

        #region MMEMory:CDIRectory


        //Jhowells
        //glennj 6/25/2013
        /// <summary>
        /// Sets the current directory of the file system to the specified path on an %AWG<para>
        /// 
        ///  MMEMory:CDIRectory(?)</para>
        /// </summary>
        /// <param name="path">File system path</param>
        /// <param name="awgNumber"></param>
        /*!
            \massmemory\verbatim
        [When(@"I set the current directory to ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the current directory to ""(.+)"" for AWG ([1-4])")]
        public void SetTheCurrentDirectoryTo(string path, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.SetTheCurrentDirectoryTo(awg, path);
        }

        //Jhowells
        /// <summary>
        /// Gets the current directory of the file system on an %AWG<para>
        /// 
        ///  MMEMory:CDIRectory(?)</para>
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \massmemory\verbatim
        [When(@"I get the current directory for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the current directory for AWG ([1-4])")]
        public void GetTheCurrentDirectory(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.GetTheCurrentDirectory(awg);
        }

        //Jhowells
        /// <summary>
        /// Compares the path of the current directory of the file system on the %AWG against the expected path
        /// 
        /// 
        ///  MMEMory:CDIRectory(?)
        /// </summary>
        /// <param name="expectedPath">Expected file system path</param>
        /// <param name="awgNumber"></param>
        /*!
            \massmemory\verbatim
        [Then(@"the current directory should be ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the current directory should be ""(.+)"" for AWG ([1-4])")]
        public void ThenTheCurrentDirectoryShouldBe(string expectedPath, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            expectedPath = '"' + expectedPath + '"';
            _awgMassMemoryGroup.TheCurrentDirectoryShouldBe(awg, expectedPath);
        }


        #endregion MMEMory:CDIRectory

        #region MMEMory:DATA

        //PHunter 20130114
        //glennj 7/3/2013
        /// <summary>
        /// Sends block data to a specified file at a specified (zero-based) starting index for the default AWG
        /// 
        /// MMEMory:DATA
        /// </summary>
        /// <param name="blockData">The block of data to send</param>
        /// <param name="startPosition">The (zero-based) starting index</param>
        /// <param name="filePath">The file name or file path to send the data</param>
        /// <param name="awgNumber"></param>
        /// 
        /*!
            \massmemory\verbatim
        [When(@"I send the string ""(.+)"" as block data at the starting index of (\d+) to the ""(.+)"" file for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I send the string ""(.+)"" as block data at the starting index of (\d+) to the ""(.+)"" file for AWG ([1-4])")]
        public void SendBLockDataToPositionAndFileOnTheAWG(string blockData, string startPosition, string filePath, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.SendBLockDataToPositionAndFileOnTheAWG(awg, filePath, startPosition, blockData);
        }

        //PHunter 20130114
        //glennj 7/3/2013
        /// <summary>
        /// Gets a block of data from the specified file and specified (zero-based) starting index for the default AWG
        /// This variant of the step gets all data from the starting index to the end of the data.
        /// 
        /// MMEMory:DATA?
        /// </summary>
        /// <param name="startPosition">The (zero-based) starting index</param>
        /// <param name="filePath">The file name or file path to send the data</param>
        /// <param name="awgNumber"></param>
        /// 
        /*!
            \massmemory\verbatim
        [When(@"I get the block data as a string from the starting index of (\d+) from the ""(.+)"" file for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the block data as a string from the starting index of (\d+) from the ""(.+)"" file for AWG ([1-4])")]
        public void GetBLockDataFromPositionAndFileOnTheAWG(string startPosition, string filePath, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            // Get the block data and store it in awg.blockData accessor
            _awgMassMemoryGroup.GetBLockDataFromPositionAndFileOnTheAWG(awg, filePath, startPosition);
        }

        //PHunter 20130114
        //glennj 7/3/2013
        /// <summary>
        /// Gets a specified block of data from the specified file and specified (zero-based) starting index for the default AWG
        /// This variant of the step gets only the specified number of bytes from the starting index and puts it in the awg.blockData accessor
        /// 
        /// MMEMory:DATA?
        /// </summary>
        /// <param name="dataSize"></param>
        /// <param name="startPosition">The (zero-based) starting index</param>
        /// <param name="filePath">The file name or file path to send the data</param>
        /// <param name="awgNumber"></param>
        /// 
        /*!
            \massmemory\verbatim
        [When(@"I get (\d+) bytes of the block data as a string starting at index (\d+) from the ""(.+)"" file for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get (\d+) bytes of the block data as a string starting at index (\d+) from the ""(.+)"" file for AWG ([1-4])")]
        public void GetBytesOfBLockDataFromPositionAndFileOnTheAWG(string dataSize, string startPosition, string filePath, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            // Get the block data and store it in awg.blockData accessor
            _awgMassMemoryGroup.GetBLockDataFromPositionAndFileOnTheAWG(awg, filePath, startPosition, dataSize);
        }

        //PHunter 20130114
        //glennj 7/3/2013
        /// <summary>
        /// Tests the contents of the awg.blockData accessor against the expected value
        /// 
        /// MMEMory:DATA?
        /// </summary>
        /// <param name="expectedData">The block of data to be tested</param>
        /// <param name="awgNumber"></param>
        /// 
        /*!
            \massmemory\verbatim
        [Then(@"the block data returned should be ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
       */
        [Then(@"the block data returned should be ""(.+)"" for AWG ([1-4])")]
        public void ThenTheBlockDataReturnedFromTheAwgShouldBe(string expectedData, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.TheBlockDataReturnedFromTheAwgShouldBe(awg, expectedData);
        }

        #endregion MMEMory:DATA

        #region MMEMory:DATA:SIZE?

        //Jhowells
        //glennj 6/21/2013
        /// <summary>
        /// Force the awg to update's copy of the size of the the given file in bytes
        /// 
        /// MMEMory:DATA:SIZE?
        /// </summary>
        /// <param name="filePath">Path to the file to be sized</param>
        /// <param name="awgNumber"></param>
        /*!
            \massmemory\verbatim
        [When(@"I get the size of the file ""(.+)"" from AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the size of the file ""(.+)"" from AWG ([1-4])")]
        public void GetTheSizeOfFile(string filePath, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.GetTheSizeOfFile(awg, filePath);
        }

        //Jhowells
        //glennj 7/3/2013
        /// <summary>
        /// Compares the size of the file against the expected value.
        /// 
        /// MMEMory:DATA:SIZE?
        /// </summary>
        /// <param name="expectedSize">Expected file size</param>
        /// <param name="awgNumber"></param>
        /*!
            \massmemory\verbatim
        [Then(@"the file size should be (.+) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the file size should be (.+) for AWG ([1-4])")]
        public void ThenTheFileSizeOnAWGShouldbe(string expectedSize, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.TheFileSizeOnAWGShouldbe(awg, expectedSize);
        }

        #endregion MMEMory:DATA:SIZE?

        #region MMEMory:DELete

        //glennj 6/25/2013
        /// <summary>
        /// Deletes a file on the current drive on an AWG
        /// 
        /// MMEMory:DELete
        /// </summary>
        /// <param name="fileName">Name of waveform</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
           \massmemory\verbatim
        [When(@"I delete the file ""(.+)"" for AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I delete the file ""(.+)"" for AWG ([1-4])")]
        public void DeleteTheFileOnAwg(string fileName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.DeleteFileorDirectoryInMassStorage(awg, fileName);
        }

        //glennj 6/25/2013
        /// <summary>
        /// Deletes a file on a specific drive on an AWG
        /// 
        /// MMEMory:DELete
        /// </summary>
        /// <param name="fileName">Name of waveform</param>
        /// <param name="driveLetter">Drive(msus) letter</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
           \massmemory\verbatim
        [When(@"I delete the file ""(.+)"" on drive ([A-Z]): for AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I delete the file ""(.+)"" on drive ([A-Z]): for AWG ([1-4])")]
        public void DeleteTheFileOnDriveOnAwg(string fileName, string driveLetter, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.DeleteFileorDirectoryInMassStorage(awg, fileName, driveLetter);
        }

        //glennj 6/25/2013
        /// <summary>
        /// Deletes a directory on the current drive on an AWG
        /// 
        /// MMEMory:DELete
        /// </summary>
        /// <param name="directoryName">Name of directory</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
           \massmemory\verbatim
        [When(@"I delete the directory ""(.+)"" for AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I delete the directory ""(.+)"" for AWG ([1-4])")]
        public void DeleteTheDirectoryOnAwg(string directoryName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.DeleteFileorDirectoryInMassStorage(awg, directoryName);
        }

        //glennj 6/25/2013
        /// <summary>
        /// Deletes a directory on a specific drive on an AWG
        /// 
        /// MMEMory:DELete
        /// </summary>
        /// <param name="directoryName">Name of directory</param>
        /// <param name="driveLetter">Drive(msus) letter</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
           \massmemory\verbatim
        [When(@"I delete the directory ""(.+)"" on drive ([A-Z]): for AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I delete the directory ""(.+)"" on drive ([A-Z]): for AWG ([1-4])")]
        public void DeleteTheDirectoryOnDriveOnAwg(string directoryName, string driveLetter, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.DeleteFileorDirectoryInMassStorage(awg, directoryName, driveLetter);
        }

        #endregion MMEMory:DELete

        #region MMEMory:IMPort

        // Tests should not be using any step that makes a reference to MMEMory:IMPort which has been depreciated
        // and is checked for syntax only for backward compatibility.  MEMMory:IMPort uses the same underlying
        // methods as MEMMory:OPEN to do the work.
        // Tests should be using steps that use the MEMMory:OPEN PI command.
        // Version 62 of this file has the entire set of steps that used to be here.

        // MEMMory:OPEN command does not work for files with .AWG/.AWGX/.TXT/.MAT
        // only use MMEMory:IMPort for those cases or abnormal usage

        //jmanning 3/17/2014
        //glennj 4/1/2014
        /// <summary>
        /// Imports a waveform file as specific format type from a file path into the AWG’s waveform asset list
        /// 
        /// This is an overlapped command.
        /// 
        /// :MMEMory:IMPort
        /// </summary>
        /// <param name="wfmName">Name that the imported waveform will have </param>
        /// <param name="fileType">Type of waverform file</param>
        /// <param name="fileName">Path of the file to be imported</param>
        /// <param name="awgNumber">Specific AWG</param>
        /*!
           \massmemory\verbatim
        [When(@"I import the waveform (.+) as (.+) format type from file ""(.+)"" to AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I import the waveform ""(.+)"" as (.+) format type from file ""(.+)"" for AWG ([1-4])")]
        public void WaveformImportAsFormatTypeAllFromFile(string wfmName, AwgMassMemoryGroup.WaveformFormatType fileType, string fileName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.ImportAFile(awg, wfmName, fileType, fileName);
        }
       
        //glennj 6/26/2013
        /// <summary>
        /// Imports a waveform file as TXT format type from a file path into the AWG’s waveform asset list
        /// 
        /// This is an overlapped command.
        /// 
        /// :MMEMory:IMPort
        /// 
        /// </summary>
        /// <param name="wfmName">Name that the imported waveform will have </param>
        /// <param name="fileName">Path of the file to be imported</param>
        /// <param name="awgNumber">Specific AWG</param>
        /*!
           \massmemory\verbatim
        [When(@"I import the waveform (.+) as format type TXT from file ""(.+)"" to AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I import the waveform (.+) as format type TXT from file ""(.+)"" for AWG ([1-4])")]
        public void WaveformImportAsFormatTypeTXTFromFile(string wfmName, string fileName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.ImportAFile(awg, wfmName, AwgMassMemoryGroup.WaveformFormatType.TXT, fileName);
        }
        #endregion :MMEMory:IMPort

        #region MMEMory:IMPort:PARameter:NORMalize

        //glennj 6/25/2013
        /// <summary>
        /// Sets the imported data to no normalized during text data import operation.<para>
        /// using the non-perferred MMEMory:IMPort:PARameter:NORMalize</para><para>
        /// The PI command has been replaced with MMEMory:OPEN:PARameter:NORMalize</para>
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
              \massmemory\verbatim
        [When(@"I set the normalization type for data to be imported to no normalization for AWG ([1-4])")]
              \endverbatim 
        */
        [When(@"I set the normalization type for data to be imported to no normalization for AWG ([1-4])")]
        public void SetTheNormalizationTypeToNoNormalizationForDataToBeImported(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.SetTheNormalizationValueOfDataToBeImported(awg, AwgMassMemoryGroup.NormalizationType.None);
        }

        //glennj 6/25/2013
        /// <summary>
        /// Sets the imported data to be normalized to the full amplitude range during text data import operation.<para>
        /// MMEMory:IMPort:PARameter:NORMalize(?)</para>
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
              \massmemory\verbatim
        [When(@"I set the normalization type for data to be imported to full amplitude range for AWG ([1-4])")]
              \endverbatim 
        */
        [When(@"I set the normalization type for data to be imported to full amplitude range for AWG ([1-4])")]
        public void SetTheNormalizationTypeToFullAmplitudeRangeForDataToBeImported(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.SetTheNormalizationValueOfDataToBeImported(awg, AwgMassMemoryGroup.NormalizationType.FullRange);
        }

        //glennj 6/25/2013
        /// <summary>
        /// Sets the imported data to be normalized to the full amplitude range and<para>
        /// preserve the zero offset during text data import operation.</para><para>
        /// MMEMory:IMPort:PARameter:NORMalize(?)</para>
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
              \massmemory\verbatim
        [When(@"I set the normalization type for data to be imported to full amplitude range and offset preserved for AWG ([1-4])")]
              \endverbatim 
        */
        [When(@"I set the normalization type for data to be imported to full amplitude range and offset preserved for AWG ([1-4])")]
        public void SetTheNormalizationTypeToOffsetPreservedForDataToBeImported(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.SetTheNormalizationValueOfDataToBeImported(awg, AwgMassMemoryGroup.NormalizationType.PreserveOffset);
        }

        //Jhowells
        /// <summary>
        /// Gets if the imported data is normalized during text data import operation.
        ///
        /// MMEMory:IMPort:PARameter:NORMalize(?)
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            @massmemory\verbatim
        [When(@"I get the normalization type for data to be imported for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the normalization type for data to be imported for AWG ([1-4])")]
        public void GetTheNormalizationOfDataToBeImported(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.GetTheNormalizationOfDataToBeImported(awg);
        }

        //glennj 6/25/2013
        /// <summary>
        /// Verifies the normalization type to be no normalized during text data import operation.<para>
        /// MMEMory:IMPort:PARameter:NORMalize(?)</para>
        /// </summary>
        /// <param name="awgNumber">Specific awg</param>
        /*!
              \massmemory\verbatim
        [Then(@"the normalization type for imported data should be no normalization for AWG ([1-4])")]
              \endverbatim 
         */
        [Then(@"the normalization type for imported data should be no normalization for AWG ([1-4])")]
        public void TheNormalizationTypeForImportedDataShouldBeNoNormalization(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.NormalizationValueOfDataTypeShouldBe(awg, AwgMassMemoryGroup.NormalizationCommand.Import,
                                                                            AwgMassMemoryGroup.NormalizationType.None);
        }

        //glennj 6/25/2013
        /// <summary>
        /// Verifies the normalization type to be full amplitide during text data import operation.<para>
        /// MMEMory:IMPort:PARameter:NORMalize(?)</para>
        /// </summary>
        /// <param name="awgNumber">Specific awg</param>
        /*!
              \massmemory\verbatim
        [Then(@"the normalization type for imported data should be full amplitude range for AWG ([1-4])")]
              \endverbatim 
         */
        [Then(@"the normalization type for imported data should be full amplitude range for AWG ([1-4])")]
        public void TheNormalizationTypeForImportedDataShouldBeFullAmplitude(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.NormalizationValueOfDataTypeShouldBe(awg, AwgMassMemoryGroup.NormalizationCommand.Import,
                                                                            AwgMassMemoryGroup.NormalizationType.FullRange);
        }

        //glennj 6/25/2013
        /// <summary>
        /// Verifies the normalization type to be full amplitide plus offset preserved during text data import operation.<para>
        /// MMEMory:IMPort:PARameter:NORMalize(?)</para>
        /// </summary>
        /// <param name="awgNumber">Specific awg</param>
        /*!
              \massmemory\verbatim
        [Then(@"the normalization type for imported data should be full amplitude range and offset preserved for AWG ([1-4])")]
              \endverbatim 
         */
        [Then(@"the normalization type for imported data should be full amplitude range and offset preserved for AWG ([1-4])")]
        public void TheNormalizationTypeForImportedDataShouldBeOffsetPreserved(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.NormalizationValueOfDataTypeShouldBe(awg, AwgMassMemoryGroup.NormalizationCommand.Import,
                                                                            AwgMassMemoryGroup.NormalizationType.PreserveOffset);
        }

        #endregion MMEMory:IMPort:PARameter:NORMalize

        #region MMEMory:MDIRectory

        //Jhowells
        //glennj 6/21/2013
        /// <summary>
        /// Creates a new directory in the current path.
        /// 
        /// MMEMory:MDIRectory
        /// </summary>
        /// <param name="directoryName">New directory name</param>
        /// <param name="awgNumber"></param>
        /*!
            \massmemory\verbatim
        [When(@"I create a new directory named ""(.+)"" in the current directory for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I create a new directory named ""(.+)"" in the current directory for AWG ([1-4])")]
        public void CreateNewDirectoryInCurrentDirectory(string directoryName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.CreateNewDirectoryInCurrentDirectory(awg, directoryName);
        }

        #endregion MMEMory:MDIRectory
        
        #region NOT IMPLEMENTED
        /*
        #region MMEMory:MROPened?
        //jmanning 9/04/2014
        /// <summary>
        /// Updates the recently opened waveforms on the AWG
        /// 
        /// MMEMory:MROPened[:WAVeforms]?
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \massmemory\verbatim
        [When(@"I get the recently opened waveforms from AWG ([1-4])")]
            \endverbatim 
        
        [When(@"I get the recently opened waveforms from AWG ([1-4])")]
        public void GetMemoryRecentWaveformsOpened(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.GetMemoryRecentWaveformsOpened(awg);
        }

        //jmanning 9/04/2014
        /// <summary>
        /// Checks for inclusion of a given waveform name using the response from querying memory for recently opened list
        /// </summary>
        /// <param name="expectedWfmName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \waveform\verbatim
        [Then(@"the name of ""(.+)"" should be included in the list of recently opened waveforms on AWG ([1-4])")]
            \endverbatim 
        
        [Then(@"the name of ""(.+)"" should be included in the list of recently opened waveforms on AWG ([1-4])")]
        public void TheNameOfTheWaveformFromRecentWaveformsShouldInclude(string expectedWfmName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.RecentlyOpenedWaveformNameShouldInclude(awg, expectedWfmName, true);
        }

        //jmanning 9/04/2014
        /// <summary>
        /// Checks for exclusion of a given waveform name using the response from querying memory for recently opened list
        /// </summary>
        /// <param name="expectedWfmName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \waveform\verbatim
        [Then(@"the name of ""(.+)"" should not be included in the list of recently opened waveforms on AWG ([1-4])")]
            \endverbatim 
        
        [Then(@"the name of ""(.+)"" should not be included in the list of recently opened waveforms on AWG ([1-4])")]
        public void TheNameOfTheWaveformFromRecentWaveformsShouldNotInclude(string expectedWfmName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.RecentlyOpenedWaveformNameShouldInclude(awg, expectedWfmName, false);
        }
        #endregion MMEMory:MROPened?

        #region MMEMory:MROPened:SEQuences?
        //jmanning 9/04/2014
        /// <summary>
        /// Updates the recently opened sequences on the AWG
        /// 
        /// MMEMory:MROPened:SEQuences?
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \massmemory\verbatim
        [When(@"I get the recently opened sequences from AWG ([1-4])")]
            \endverbatim 
        
        [When(@"I get the recently opened sequences from AWG ([1-4])")]
        public void GetMemoryRecentSequencesOpened(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.GetMemoryRecentSequencesOpened(awg);
        }

        //jmanning 9/04/2014
        /// <summary>
        /// Checks for inclusion of a given sequences name using the response from querying memory for recently opened list
        /// </summary>
        /// <param name="expectedSeqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \waveform\verbatim
        [Then(@"the name of ""(.+)"" should be included in the list of recently opened sequences on AWG ([1-4])")]
            \endverbatim 
        
        [Then(@"the name of ""(.+)"" should be included in the list of recently opened sequences on AWG ([1-4])")]
        public void TheNameOfTheSequenceFromRecentSequencesShouldInclude(string expectedSeqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.RecentlyOpenedSequenceNameShouldInclude(awg, expectedSeqName, true);
        }

        //jmanning 9/04/2014
        /// <summary>
        /// Checks for exclusion of a given waveform name using the response from querying memory for recently opened list
        /// </summary>
        /// <param name="expectedSeqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \waveform\verbatim
        [Then(@"the name of ""(.+)"" should not be included in the list of recently opened sequences on AWG ([1-4])")]
            \endverbatim 
        
        [Then(@"the name of ""(.+)"" should not be included in the list of recently opened sequences on AWG ([1-4])")]
        public void TheNameOfTheSequenceFromRecentSequencesShouldNotInclude(string expectedSeqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.RecentlyOpenedSequenceNameShouldInclude(awg, expectedSeqName, false);
        }
        #endregion MMEMory:MROPened:SEQuences?
        */
        #endregion NOT IMPLEMENTED

        #region MMEMory:MSIS

        //Jhowells
        //glennj 6/21/2013
        /// <summary>
        /// Sets the drive (mass storage device, aka msus) used by all MMEMory commands
        /// 
        /// MMEMory:MSIS
        /// </summary>
        /// <param name="drive">Drive letter, needs to be followed by a ":"</param>
        /// <param name="awgNumber"></param>
        /*!
            \massmemory\verbatim
        [When(@"I set the drive to ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the drive to ""(.+)"" for AWG ([1-4])")]
        public void SetTheDriveSpecifier(string drive, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.SetTheStorageDriveSpecifier(awg, drive);
        }

        //Jhowells
        //glennj 6/21/2013
        /// <summary>
        /// Forces the AWG to update it's local copy of the mass storage device<para>
        /// used by all the MMEmory commands</para>
        ///
        /// MMEMory:MSIS(?)
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \massmemory\verbatim
        [When(@"I get the drive for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the drive for AWG ([1-4])")]
        public void GetTheCurrentStorageUnitSpecifier(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.GetTheCurrentDriveSpecifier(awg);
        }

        //Jhowells
        /// <summary>
        /// Compares the mass storage device used by all MMEMory commands against expected value
        ///
        /// MMEMory:MSIS(?)
        /// </summary>
        /// <param name="awgNumber"></param>
        /// <param name="expectedValue">Expected drive Letter</param>
        /*!
            \massmemory\verbatim
        [Then(@"the drive for AWG ([1-4]) should be ""(.+)""")]
            \endverbatim 
        */
        [Then(@"the drive should be ""(.+)"" for AWG ([1-4])")]
        public void TheCurrentStorageUnitSpecifierShouldBe(string expectedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            expectedValue = '"' + expectedValue + '"'; //Add the quotes to match the returned value
            _awgMassMemoryGroup.CurrentStorageUnitSpecifierShouldBe(awg, expectedValue);
        }


        #endregion MMEMory:MSIS

        #region MMEMory:OPEN
        /// <summary>
        /// Opens an asset into the AWG’s setup as a waveform or sequence
        ///
        /// NOTE: If the asset name already exists, it will be overwritten without warning.@n
        /// The file name must contain a path and drive letter@n
        /// Will not open TXT files, AWG files, or AWGX files@n
        /// 
        /// MMEMory:OPEN (no query)
        /// </summary>
        /// <param name="fileName">Path of the asset to be imported</param>
        /// <param name="awgNumber"></param>
        /*!
            @massmemory\verbatim
        [When(@"I open the file ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I open the file ""(.+)"" for AWG ([1-4])")]
        public void OpenAWaveformFromAFileOnTheAwg(string fileName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.OpenAWaveformFromAFileOnTheAwg(awg, fileName);
        }
        #endregion MMEMory:OPEN

        #region MMEMory:OPEN:PARameter:NORMalize

        //glennj 7/2/2013
        /// <summary>
        /// Sets the normalize mode during the open operation to full amplitude range and preserving the 0 offset
        /// 
        /// MMEMory:OPEN:PARameter:NORMalize
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \massmemory\verbatim
        [When(@"I set the normalization type for data to be opened to full amplitude range and offset preserved for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the normalization type for data to be opened to full amplitude range and offset preserved for AWG ([1-4])")]
        public void SetTheNormalizationValueOfDataToFullAndPreserved(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.SetTheNormalizationValueOfDataToBeOpened(awg, AwgMassMemoryGroup.NormalizationType.PreserveOffset);
        }

        //glennj 7/2/2013
        /// <summary>
        /// Sets the normalize mode during the open operation to full amplitude range
        /// 
        /// MMEMory:OPEN:PARameter:NORMalize
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \massmemory\verbatim
        [When(@"I set the normalization type for data to be opened to full amplitude range for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the normalization type for data to be opened to full amplitude range for AWG ([1-4])")]
        public void SetTheNormalizationValueOfDataToFullAmplitude(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.SetTheNormalizationValueOfDataToBeOpened(awg, AwgMassMemoryGroup.NormalizationType.FullRange);
        }

        //Jhowells
        //glennj 7/2/2013
        /// <summary>
        /// Sets the normalize mode during the open operation to no normalization
        /// 
        /// MMEMory:OPEN:PARameter:NORMalize
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \massmemory\verbatim
        [When(@"I set the normalization type for data to be opened to no normalization for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the normalization type for data to be opened to no normalization for AWG ([1-4])")]
        public void SetTheNormalizationValueOfDataToNoNormalization(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.SetTheNormalizationValueOfDataToBeOpened(awg, AwgMassMemoryGroup.NormalizationType.None);
        }

        //Jhowells
        //glennj 6/21/2013
        /// <summary>
        /// Forces the awg to refresh it's copy of the normalize mode during the open operation.
        /// 
        /// MMEMory:OPEN:PARameter:NORMalize?
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            @massmemory\verbatim
        [When(@"I get the normalization type for data to be opened for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the normalization type for data to be opened for AWG ([1-4])")]
        public void GetTheNormalizationOfDataToBeOpened(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.GetTheNormalizationOfDataToBeOpened(awg);
        }

        //Jhowells
        //glennj 7/2/2013
        /// <summary>
        /// Compares the value of the normalize mode during the open operation against<para>
        /// the expected value of None.</para><para>
        /// Do a get to refresh the AWG's copy of the mode</para><para>
        /// MMEMory:OPEN:PARameter:NORMalize?</para>
        /// </summary>
        /*!
              \massmemory\verbatim
        [Then(@"the normalization type for opened data should be no normalization for AWG ([1-4])")]
              \endverbatim 
        */
        [Then(@"the normalization type for opened data should be no normalization for AWG ([1-4])")]
        public void TheNormalizationValueOfDataToBeOpenedShouldBeNoNone(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.NormalizationValueOfDataTypeShouldBe(awg, AwgMassMemoryGroup.NormalizationCommand.Open,
                                                                            AwgMassMemoryGroup.NormalizationType.None);
        }

        //Jhowells
        //glennj 7/2/2013
        /// <summary>
        /// Compares the value of the normalize mode during the open operation against<para>
        /// the expected value of Full Amplitude.</para><para>
        /// Do a get to refresh the AWG's copy of the mode</para><para>
        /// MMEMory:OPEN:PARameter:NORMalize?</para>
        /// </summary>
        /*!
              \massmemory\verbatim
        [Then(@"the normalization type for opened data should be full amplitude range for AWG ([1-4])")]
              \endverbatim 
        */
        [Then(@"the normalization type for opened data should be full amplitude range for AWG ([1-4])")]
        public void TheNormalizationValueOfDataToBeOpenedShouldBeFull(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.NormalizationValueOfDataTypeShouldBe(awg, AwgMassMemoryGroup.NormalizationCommand.Open,
                                                                            AwgMassMemoryGroup.NormalizationType.FullRange);
        }

        //Jhowells
        //glennj 7/2/2013
        /// <summary>
        /// Compares the value of the normalize mode during the open operation against<para>
        /// the expected value of Full Amplitude and perserved the 0 offset.</para><para>
        /// Do a get to refresh the AWG's copy of the mode</para><para>
        /// MMEMory:OPEN:PARameter:NORMalize?</para>
        /// </summary>
        /*!
              \massmemory\verbatim
        [Then(@"the normalization type for opened data should be full amplitude range and offset preserved for AWG ([1-4])")]
              \endverbatim 
        */
        [Then(@"the normalization type for opened data should be full amplitude range and offset preserved for AWG ([1-4])")]
        public void TheNormalizationValueOfDataToBeOpenedShouldBePreserved(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.NormalizationValueOfDataTypeShouldBe(awg, AwgMassMemoryGroup.NormalizationCommand.Open,
                                                                            AwgMassMemoryGroup.NormalizationType.PreserveOffset);
        }

        #endregion MMEMory:OPEN:PARameter:NORMalize

        #region MMEMory:OPEN:SETup

        //Jhowells
        /// <summary>
        /// Opens a setup file into the AWG
        /// 
        /// MMEMory:OPEN:SETup
        /// </summary>
        /// <param name="fileName">Path of the setup file</param>
        /// <param name="awgNumber"></param>
        /*!
            @massmemory\verbatim
        [When(@"I open the setup file ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I open the setup file ""(.+)"" for AWG ([1-4])")]
        public void OpenASetupFile(string fileName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.OpenASetupFile(awg, fileName);
        }

        #endregion MMEMory:OPEN:SETup

        #region MMEMory:OPEN:TXT

        //glennj 7/2/2013
        /// <summary>
        /// Opens a text file into the AWG's setup as a waveform as floating point values
        /// 
        /// NOTE - If the waveform (asset) name already exists, it will be overwritten without warning.@n
        /// The file name must contain a path and drive letter. For digital TXT files bit depth is required.@n
        /// For analog TXT files bit depth is not required.@n
        /// MEMMory:OPEN:TXT
        /// </summary>
        /// <param name="fileName">Path of the text file</param>
        /// <param name="awgNumber"></param>
        /*!
           @massmemory\verbatim
        [When(@"I open the txt file ""(.+)"" as floating point values for AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I open the txt file ""(.+)"" as floating point values for AWG ([1-4])")]
        public void OpenAtxtFileFromAssetAsFloat(string fileName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.OpenTXTFileFromAsset(awg, fileName, AwgMassMemoryGroup.TextFileType.FloatingPoint);
        }

        //glennj 7/2/2013
        /// <summary>
        /// Opens a text file into the AWG's setup as a waveform as 8 bit DAC
        /// 
        /// NOTE - If the waveform (asset) name already exists, it will be overwritten without warning.@n
        /// The file name must contain a path and drive letter. For digital TXT files bit depth is required.@n
        /// For analog TXT files bit depth is not required.@n
        /// MEMMOry:OPEN:TXT
        /// </summary>
        /// <param name="fileName">Path of the text file</param>
        /// <param name="awgNumber"></param>
        /*!
           @massmemory\verbatim
        [When(@"I open the txt file ""(.+)"" as 8 bit DAC values for AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I open the txt file ""(.+)"" as 8 bit DAC values for AWG ([1-4])")]
        public void OpenAtxtFileFromAssetAs8Bit(string fileName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.OpenTXTFileFromAsset(awg, fileName, AwgMassMemoryGroup.TextFileType.DAC_8Bit);
        }

        //sforell 7/2/2013 added a step for 9 bit DAC 
        /// <summary>
        /// Opens a text file into the AWG's setup as a waveform as 9 bit DAC
        /// 
        /// NOTE - If the waveform (asset) name already exists, it will be overwritten without warning.@n
        /// The file name must contain a path and drive letter. For digital TXT files bit depth is required.@n
        /// For analog TXT files bit depth is not required.@n
        /// MEMMOry:OPEN:TXT
        /// </summary>
        /// <param name="fileName">Path of the text file</param>
        /// <param name="awgNumber"></param>
        /*!
           @massmemory\verbatim
        [When(@"I open the txt file ""(.+)"" as 9 bit DAC values for AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I open the txt file ""(.+)"" as 9 bit DAC values for AWG ([1-4])")]
        public void OpenAtxtFileFromAssetAs9Bit(string fileName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.OpenTXTFileFromAsset(awg, fileName, AwgMassMemoryGroup.TextFileType.DAC_9Bit);
        }

        //glennj 7/2/2013
        /// <summary>
        /// Opens a text file into the AWG's setup as a waveform as 10 bit DAC
        /// 
        /// NOTE - If the waveform (asset) name already exists, it will be overwritten without warning.@n
        /// The file name must contain a path and drive letter. For digital TXT files bit depth is required.@n
        /// For analog TXT files bit depth is not required.@n
        /// MEMMOry:OPEN:TXT
        /// </summary>
        /// <param name="fileName">Path of the text file</param>
        /// <param name="awgNumber"></param>
        /*!
           @massmemory\verbatim
        [When(@"I open the txt file ""(.+)"" as 10 bit DAC values for AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I open the txt file ""(.+)"" as 10 bit DAC values for AWG ([1-4])")]
        public void OpenAtxtFileFromAssetAs10Bit(string fileName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.OpenTXTFileFromAsset(awg, fileName, AwgMassMemoryGroup.TextFileType.DAC_10Bit);
        }

        //glennj 7/2/2013
        /// <summary>
        /// Opens a text file into the AWG's setup as a waveform as 14 bit DAC
        /// 
        /// NOTE - If the waveform (asset) name already exists, it will be overwritten without warning.@n
        /// The file name must contain a path and drive letter. For digital TXT files bit depth is required.@n
        /// For analog TXT files bit depth is not required.@n
        /// MEMMOry:OPEN:TXT
        /// </summary>
        /// <param name="fileName">Path of the text file</param>
        /// <param name="awgNumber"></param>
        /*!
           @massmemory\verbatim
        [When(@"I open the txt file ""(.+)"" as 14 bit DAC values for AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I open the txt file ""(.+)"" as 14 bit DAC values for AWG ([1-4])")]
        public void OpenAtxtFileFromAssetAs14Bit(string fileName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.OpenTXTFileFromAsset(awg, fileName, AwgMassMemoryGroup.TextFileType.DAC_14Bit);
        }

        #endregion MMEMory:OPEN:TXT

        #region MMEMory:OPEN:SASSet[:WAVeform]

        //Jhowells
        //glennj 7/2/2013
        /// <summary>
        /// Opens desired waveforms from a setup file.
        /// 
        /// MMEMory:OPEN:SASSet
        /// </summary>
        /// <param name="desiredWfm">Optional names of a desired waveforms to open</param>
        /// <param name="fileName">Path to the Setup file</param>
        /// <param name="awgNumber"></param>
        /*!
          @massmemory\verbatim
        [When(@"I open the single waveform ""(.+)"" from the file ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I open the single waveform ""(.+)"" from the file ""(.+)"" for AWG ([1-4])")]
        public void OpenTheWaveformFromAFileToTheAwgAssetList(string desiredWfm, string fileName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.LoadSingleAsset(awg, fileName, desiredWfm);
        }
        //shkv 11/21/2014 - Modified the file to support command MMEMory:OPEN
        //glennj 7/2/2013
        /// <summary>
        /// Opens all waveforms from a setup file.
        /// 
        /// MMEMory:OPEN:SASSet
        /// </summary>
        /// <param name="fileName">Path to the Setup file</param>
        /// <param name="awgNumber"></param>
        /*!
          @massmemory\verbatim
        [When(@"I open the all waveforms from the file ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I open the all waveforms from the file ""(.+)"" for AWG ([1-4])")]
        public void OpenAllWaveformFromAFileToTheAwgAssetList(string fileName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.LoadSingle(awg, fileName);
        }

        #endregion MMEMory:OPEN:SASSet[:WAVeform]

        #region MMEMory:OPEN:SASSet:SEQuence

        /// <summary>
        /// Using MMEMory:OPEN:SASSet:SEQuence load/open a single sequence
        /// </summary>
        /// <param name="sequenceName"></param>
        /// <param name="fileName"></param>
        /// <param name="awgNumber"></param>
        /*!
          @massmemory\verbatim
        [When(@"I open the single sequence (.+) from the file ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I open the single sequence (.+) from the file ""(.+)"" for AWG ([1-4])")]
        public void OpenTheSequencesFromAFileToTheAwgAssetList(string sequenceName, string fileName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.OpenMemorySassetSequence(awg, fileName, sequenceName);
        }

        /// <summary>
        /// Using MMEMory:OPEN:SASSet:SEQuence load/open all sequences
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="awgNumber"></param>
        /*!
           @massmemory\verbatim
        [When(@"I open all sequences from the file ""(.+)"" for AWG ([1-4])")]
             \endverbatim 
        */
        [When(@"I open all sequences from the file ""(.+)"" for AWG ([1-4])")]
        public void OpenAllSequencesFromAFileToTheAwgAssetList(string fileName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.OpenMemorySassetSequence(awg, fileName);
        }

        #endregion MMEMory:OPEN:SASSet:SEQuence

        #region MMEMory:OPEN:SASSet:SEQuence:MROPened?
        //jmanning 9/04/2014
        /// <summary>
        /// Updates the recently opened sequences on the AWG
        /// 
        /// MMEMory:OPEN:SASSet:SEQuence:MROPened?
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \massmemory\verbatim
        [When(@"I get the most recently opened sequence from AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the most recently opened sequence from AWG ([1-4])")]
        public void GetMemoryMostRecentSequenceOpened(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.GetMemoryMostRecentSequenceOpened(awg);
        }

        //jmanning 9/04/2014
        /// <summary>
        /// Checks sequence name versus the response from querying memory for most recently opened sequence
        /// </summary>
        /// <param name="expectedSeqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \waveform\verbatim
         [Then(@"the sequence named ""(.+)"" should be the most recently opened sequence on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the sequence named ""(.+)"" should be the most recently opened sequence on AWG ([1-4])")]
        public void TheNameOfTheMostRecentSequenceShouldBe(string expectedSeqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.MostRecentlyOpenedSequenceNameShould(awg, expectedSeqName, true);
        }

        //jmanning 9/04/2014
        /// <summary>
        /// Checks sequence name versus the response from querying memory for most recently opened sequence
        /// </summary>
        /// <param name="expectedSeqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \waveform\verbatim
         [Then(@"the sequence named ""(.+)"" should not be the most recently opened sequence on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the sequence named ""(.+)"" should not be the most recently opened sequence on AWG ([1-4])")]
        public void TheNameOfTheMostRecentSequenceShouldNotBe(string expectedSeqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.MostRecentlyOpenedSequenceNameShould(awg, expectedSeqName, false);
        }
        #endregion MMEMory:OPEN:SASSet:SEQuence:MROPened?

        #region MMEMory:SAVE:SETup

        //Jhowells
        //glennj 7/3/2013
        /// <summary>
        /// Save the current state of the AWG optionally with any assets
        /// 
        /// MMEMory:SAVE:SETup
        /// </summary>
        /// <param name="filepath">Filepath of the new setup file</param>
        /// <param name="awgNumber"></param>
        /*!
             \massmemory\verbatim
        [When(@"I save the setup with assets to the file ""(.+)"" for AWG ([1-4])")]
             \endverbatim 
         */
        [When(@"I save the setup with assets to the file ""(.+)"" for AWG ([1-4])")]
        public void SaveTheSetupWith(string filepath, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.SaveTheSetup(awg, filepath, AwgMassMemoryGroup.SaveSetupAssets.With);
        }

        //Jhowells
        //glennj 7/3/2013
        /// <summary>
        /// Save the current state of the AWG optionally without any assets
        /// 
        /// MMEMory:SAVE:SETup
        /// </summary>
        /// <param name="filepath">Filepath of the new setup file</param>
        /// <param name="awgNumber"></param>
        /*!
             \massmemory\verbatim
        [When(@"I save the setup without assets to the file ""(.+)"" for AWG ([1-4])")]
             \endverbatim 
         */
        [When(@"I save the setup without assets to the file ""(.+)"" for AWG ([1-4])")]
        public void SaveTheSetupWithout(string filepath, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.SaveTheSetup(awg, filepath, AwgMassMemoryGroup.SaveSetupAssets.Without);
        }

        //Jhowells
        //glennj 7/3/2013
        /// <summary>
        /// Save the current state of the AWG default with is saving assets
        /// 
        /// MMEMory:SAVE:SETup
        /// </summary>
        /// <param name="filepath">Filepath of the new setup file</param>
        /// <param name="awgNumber"></param>
        /*!
             \massmemory\verbatim
        [When(@"I save the setup to the file ""(.+)"" for AWG ([1-4])")]
             \endverbatim 
         */
        [When(@"I save the setup to the file ""(.+)"" for AWG ([1-4])")]
        public void SaveTheSetupDefault(string filepath, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.SaveTheSetup(awg, filepath, AwgMassMemoryGroup.SaveSetupAssets.Default);
        }

        #endregion region MMEMory:SAVE:SETup

        #region MMEMory:SAVE:SEQuence

        //sforell 9/9/13 added step
        /// <summary>
        /// Save the given asset as a SEQX file
        /// 
        /// MMEMory:SAVE:SEQuence
        /// </summary>
        /// <param name="assetName">Name of the asset to saved</param>
        /// <param name="filePath">New name and place to save the SEQX file</param>
        /// <param name="awgNumber"></param>
        /*!
           \massmemory\verbatim
        [When(@"I save the asset ""(.+)"" as the SEQX file ""(.+)"" for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I save the asset ""(.+)"" as the SEQX file ""(.+)"" for AWG ([1-4])")]
        public void SaveTheAssetAsASeqx(string assetName, string filePath, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.SaveTheAssetAsASEQX(awg, assetName, filePath);
        }

        #endregion MMEMory:SAVE:SEQuence

        #region MMEMory:SAVE[:WAVeform]:TXT

        //glennj 6/21/2013
        /// <summary>
        /// Saves the given asset as a Floating point (ANALog) TXT file
        /// 
        /// MMEMory:SAVE[:WAVeform]:TXT
        /// </summary>
        /// <param name="assetName">Name of the asset to saved</param>
        /// <param name="filePath">New name and place to save the TXT file</param>
        /// <param name="awgNumber"></param>
        /*!
             \massmemory\verbatim
        [When(@"I save the asset ""(.+)"" as floating point values to the TXT file ""(.+)"" for AWG ([1-4])")]
             \endverbatim 
         */
        [When(@"I save the asset ""(.+)"" as floating point values to the TXT file ""(.+)"" for AWG ([1-4])")]
        public void SaveTheAssetAsFloatingTXT(string assetName, string filePath, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.SaveTheAssetAsATXT(awg, assetName, filePath, AwgMassMemoryGroup.TextFileType.FloatingPoint);
        }

        //glennj 6/21/2013
        /// <summary>
        /// Saves the given asset as a 8 bit DAC (DIG8) TXT file
        /// 
        /// MMEMory:SAVE[:WAVeform]:TXT
        /// </summary>
        /// <param name="assetName">Name of the asset to saved</param>
        /// <param name="filePath">New name and place to save the TXT file</param>
        /// <param name="awgNumber"></param>
        /*!
             \massmemory\verbatim
        [When(@"I save the asset ""(.+)"" as 8 bit DAC values to the TXT file ""(.+)"" for AWG ([1-4])")]
             \endverbatim 
         */
        [When(@"I save the asset ""(.+)"" as 8 bit DAC values to the TXT file ""(.+)"" for AWG ([1-4])")]
        public void SaveTheAssetAs8BitTXT(string assetName, string filePath, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.SaveTheAssetAsATXT(awg, assetName, filePath, AwgMassMemoryGroup.TextFileType.DAC_8Bit);
        }


        //sforell 8/28/13 added 9 bit support
        /// <summary>
        /// Saves the given asset as a 9 bit DAC (DIG9) TXT file
        /// 
        /// MMEMory:SAVE[:WAVefrom]:TXT
        /// </summary>
        /// <param name="assetName">Name of the asset to saved</param>
        /// <param name="filePath">New name and place to save the TXT file</param>
        /// <param name="awgNumber"></param>
        /*!
             \massmemory\verbatim
        [When(@"I save the asset ""(.+)"" as 9 bit DAC values to the TXT file ""(.+)"" for AWG ([1-4])")]
             \endverbatim 
         */
        [When(@"I save the asset ""(.+)"" as 9 bit DAC values to the TXT file ""(.+)"" for AWG ([1-4])")]
        public void SaveTheAssetAs9BitTXT(string assetName, string filePath, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.SaveTheAssetAsATXT(awg, assetName, filePath, AwgMassMemoryGroup.TextFileType.DAC_9Bit);
        }


        //glennj 6/21/2013
        /// <summary>
        /// Saves the given asset as a 10 bit DAC (DIG10) TXT file
        /// 
        /// MMEMory:SAVE[:WAVeform]:TXT
        /// </summary>
        /// <param name="assetName">Name of the asset to saved</param>
        /// <param name="filePath">New name and place to save the TXT file</param>
        /// <param name="awgNumber"></param>
        /*!
             \massmemory\verbatim
        [When(@"I save the asset ""(.+)"" as 10 bit DAC values to the TXT file ""(.+)"" for AWG ([1-4])")]
             \endverbatim 
         */
        [When(@"I save the asset ""(.+)"" as 10 bit DAC values to the TXT file ""(.+)"" for AWG ([1-4])")]
        public void SaveTheAssetAs10BitTXT(string assetName, string filePath, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.SaveTheAssetAsATXT(awg, assetName, filePath, AwgMassMemoryGroup.TextFileType.DAC_10Bit);
        }

        #endregion MMEMory:SAVE[:WAVeform]:TXT

        #region MMEMory:SAVE[:WAVeform][:WFMX]

        //Jhowells
        /// <summary>
        /// Save the given asset as a WFMX file
        /// 
        /// 
        /// MMEMory:SAVE:WFMX
        /// </summary>
        /// <param name="assetName">Name of the asset to saved</param>
        /// <param name="filePath">New name and place to save the WFMX file</param>
        /// <param name="awgNumber"></param>
        /*!
           \massmemory\verbatim
        [When(@"I save the asset ""(.+)"" as the WFMX file ""(.+)"" for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I save the asset ""(.+)"" as the WFMX file ""(.+)"" for AWG ([1-4])")]
        public void SaveTheAssetAsAwfmx(string assetName, string filePath, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMassMemoryGroup.SaveTheAssetAsAWFMX(awg, assetName, filePath);
        }

        #endregion MMEMory:SAVE[:WAVeform][:WFMX]

    }
}