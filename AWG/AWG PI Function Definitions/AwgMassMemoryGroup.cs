//==========================================================================
// AwgMassMemoryGroup.cs
//==========================================================================
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains helper functions that are called from the %AWG Mass Memory PI step definitions.
    /// This class has no restrictions as to where it will be used.
    /// 
    /// This "Helper" group does everything else but steps and TekVISA.
    /// Using parameters from the step, each helper will makes decisions
    /// such as sending commands, or process responses from queries and
    /// do testing and generate asserts if necessary.
    /// 
    /// \ingroup grouphelperpi pisteps 
    /// </summary>
    public class AwgMassMemoryGroup
    {
        private readonly UTILS _utils = new UTILS();

        public enum NormalizationType { None, FullRange, PreserveOffset }
        public enum NormalizationCommand { Import, Open }

        public enum TextFileType {FloatingPoint, DAC_8Bit, DAC_9Bit, DAC_10Bit, DAC_14Bit }

        public enum SaveSetupAssets { With, Without, Default }

        public enum WaveformFormatType
        {
            FLOATING_POINT, DAC_8_BIT, DAC_9_BIT, DAC_10_BIT, DAC_14_BIT,
            TDS3000, DPO4000, TDS5000, TDS6000, TDS7000, DPO7000, DPO70000, DSA70000,
            AWG400_WFM, AWG500_WFM, AWG600_WFM, AWG700_WFM, AWG400_PAT, AWG500_PAT, AWG600_PAT, AWG700_PAT,
            AFG3000, RSA3000, RSA6000,
            ISF, TDS, TXT, TXT8, TXT9, TXT10, TXT14, WFM, PAT, TFW, IQT, TIQ,
            

        }
        //glennj 6/21/2013
        /// <summary>
        /// Given a waveform name, file and type, import a waveform
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="wfmName">Specific AWG object</param>
        /// <param name="wfmType"></param>
        /// <param name="fileName"></param>
        public void ImportAFile(IAWG awg, string wfmName, WaveformFormatType wfmType, string fileName)
        {
            string wfmFormat = "";
            switch (wfmType)
            {
                case WaveformFormatType.ISF:
                case WaveformFormatType.TDS3000:
                case WaveformFormatType.DPO4000:
                    wfmFormat = "ISF";
                    break;
                case WaveformFormatType.TDS:
                case WaveformFormatType.TDS5000:
                case WaveformFormatType.TDS6000:
                case WaveformFormatType.TDS7000:
                case WaveformFormatType.DPO7000:
                case WaveformFormatType.DPO70000:
                case WaveformFormatType.DSA70000:
                    wfmFormat = "TDS";
                    break;
                case WaveformFormatType.TXT:
                case WaveformFormatType.FLOATING_POINT:
                    wfmFormat = "TXT";
                    break;
                case WaveformFormatType.TXT8:
                case WaveformFormatType.DAC_8_BIT:
                    wfmFormat = "TXT8";
                    break;
                case WaveformFormatType.TXT9:
                case WaveformFormatType.DAC_9_BIT:
                    wfmFormat = "TXT9";
                    break;
                case WaveformFormatType.TXT10:
                case WaveformFormatType.DAC_10_BIT:
                    wfmFormat = "TXT10";
                    break;
                case WaveformFormatType.TXT14:
                case WaveformFormatType.DAC_14_BIT:
                    wfmFormat = "TXT14";
                    break;
                case WaveformFormatType.WFM:
                case WaveformFormatType.AWG400_WFM:
                case WaveformFormatType.AWG500_WFM:
                case WaveformFormatType.AWG600_WFM:
                case WaveformFormatType.AWG700_WFM:
                    wfmFormat = "WFM";
                    break;
                case WaveformFormatType.PAT:
                case WaveformFormatType.AWG400_PAT:
                case WaveformFormatType.AWG500_PAT:
                case WaveformFormatType.AWG600_PAT:
                case WaveformFormatType.AWG700_PAT:
                    wfmFormat = "PAT";
                    break;
                case WaveformFormatType.TFW:
                case WaveformFormatType.AFG3000:
                    wfmFormat = "TFW";
                    break;
                case WaveformFormatType.IQT:
                case WaveformFormatType.RSA3000:
                    wfmFormat = "IQT";
                    break;
                case WaveformFormatType.TIQ:
                case WaveformFormatType.RSA6000:
                    wfmFormat = "TIQ";
                    break;
            }

            awg.MemoryImport(_utils.Dequotify(wfmName), wfmFormat, fileName);
        }

        //glennj 6/21/2013
        /// <summary>
        /// Opens desired waveforms from an .AWG file or a native setup file<para>
        /// into the arbitrary waveform generator’s assets.</para>
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="fileName">Path to the Setup file</param>
        /// <param name="desiredWfm">Optional names of a desired waveforms to open</param>
        public void LoadSingleAsset(IAWG awg, string fileName, string desiredWfm = "")
        {
            awg.OpenMemorySasset(fileName, desiredWfm);
        }

        //shkv 11/21/2014
        /// <summary>
        /// Opens desired waveforms from an .AWG file or a native setup file<para>
        /// into the arbitrary waveform generator’s assets.</para>
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="fileName">Path to the Setup file</param>
        /// <param name="desiredWfm">Optional names of a desired waveforms to open</param>
        public void LoadSingle(IAWG awg, string fileName, string desiredWfm = "")
        {
            awg.OpenMemory(fileName, desiredWfm);
        }
        /// <summary>
        /// Open all or one sequence from a given filepath
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="filePath"></param>
        /// <param name="desiredSequence"></param>
        public void OpenMemorySassetSequence(IAWG awg, string filePath, string desiredSequence = "")
        {
            awg.OpenMemorySassetSequence(filePath, desiredSequence);
        }

        //jmanning 9/04/2014
        /// <summary>
        /// Updates the recently opened sequences using MMEMory:OPEN:SASSet:SEQuence:MROPened?
        /// </summary>
        /// <returns>Names of sequences recently opened</returns>
        public void GetMemoryMostRecentSequenceOpened(IAWG awg)
        {
            awg.UpdateMemoryMostRecentSequenceOpened();
        }

        //jmanning 9/04/2014
        /// <summary>
        /// This command queries which sequence was most recently added or <para>
        /// replaced from the most recently opened or imported sequence file. </para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedSeqName"></param>
        /// <param name="toBeOrNotToBe">True to include, False should not be included</param>
        public void MostRecentlyOpenedSequenceNameShould(IAWG awg, string expectedSeqName, bool toBeOrNotToBe)
        {
            string seqName = awg.MassMemoryMostRecentlyOpenedSequence;

            bool notFound = true;

            if (_utils.Dequotify(seqName) == expectedSeqName)
            {
               if (toBeOrNotToBe)
               {
                    notFound = false;
               }
            }

            if (toBeOrNotToBe)
            {
                Assert.IsFalse(notFound, "Expected Sequence name " + expectedSeqName + " was not found.  Name Found was " + awg.MassMemoryMostRecentlyOpenedSequence);
            }
            else
            {
                Assert.IsTrue(notFound, "Sequence name was unexpectedly found:  " + expectedSeqName);
            }
        }
        
        //glennj 6/21/2013
        /// <summary>
        /// Load a file into the AWG waveform list.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="fileName">file name</param>
        public void OpenAWaveformFromAFileOnTheAwg(IAWG awg, string fileName)
        {
            awg.MemoryOpen(fileName);
        }

        //glennj 6/21/2013
        /// <summary>
        /// Opens a text file.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="fileName">Path of the text file</param>
        /// <param name="bitDepth">OPTIONAL: The bit depth of the text file required for digital</param>
        public void OpenTXTFileFromAsset(IAWG awg, string fileName, TextFileType bitDepth)
        {
            string textType = "";
            switch (bitDepth)
            {
                case TextFileType.FloatingPoint:
                    textType = "ANAL";
                    break;
                case TextFileType.DAC_8Bit:
                    textType = "DIG8";
                    break;
                case TextFileType.DAC_9Bit:
                    textType = "DIG9";
                    break;
                case TextFileType.DAC_10Bit:
                    textType = "DIG10";
                    break;
                case TextFileType.DAC_14Bit:
                    textType = "DIG14";
                    break;
            }

            awg.MemoryOpenTxt(fileName, textType);
        }

        //glennj 6/21/2013
        /// <summary>
        /// Opens a setup file
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="fileName">The name of the file to open</param>
        public void OpenASetupFile(IAWG awg, string fileName)
        {
            awg.MemoryOpenSetup(fileName);
        }

        //glennj 6/21/2013
        /// <summary>
        /// Set normalization type for select file import operations.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="type">Normalization type</param>
        public void SetTheNormalizationValueOfDataToBeImported(IAWG awg, NormalizationType type)
        {
            string requiredSyntax;
            switch (type)
            {
                case NormalizationType.None:
                    requiredSyntax = "NONE";
                    awg.SetMemoryImportNormalize(requiredSyntax);
                    break;
                case NormalizationType.FullRange:
                    requiredSyntax = "FSC";
                    awg.SetMemoryImportNormalize(requiredSyntax);
                    break;
                case NormalizationType.PreserveOffset:
                    requiredSyntax = "ZREF";
                    awg.SetMemoryImportNormalize(requiredSyntax);
                    break;
            }
        }

        //glennj 6/21/2013
        /// <summary>
        /// Forces the awg to update's it's copy of the import parameter normalize type
        /// </summary>
        /// <param name="awg">specific awg object</param>
        public void GetTheNormalizationOfDataToBeImported(IAWG awg)
        {
            awg.UpdateMemoryImportNormalize();
        }

        /// <summary>
        /// Given an expected value, compare it to the updated copy of<para>
        /// import_parameter_normalize of the given awg</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="command"></param>
        /// <param name="expectedValue"></param>
        public void NormalizationValueOfDataTypeShouldBe(IAWG awg, NormalizationCommand command, NormalizationType expectedValue)
        {
            string interpretedValue = "";
            string awgCopy = (command == NormalizationCommand.Import ? awg.MassMemoryImportParameterNormalize : awg.MassMemoryOpenParameterNormalize);
            switch (expectedValue)
            {
                case NormalizationType.None:
                    interpretedValue = "NONE";
                    break;
                case NormalizationType.FullRange:
                    interpretedValue = "FSC";
                    break;
                case NormalizationType.PreserveOffset:
                    interpretedValue = "ZREF";
                    break;
            }
            Assert.AreEqual(interpretedValue, awgCopy);
        }

        //glennj 6/21/2013
        /// <summary>
        /// Set the normalized type for imported waveforms.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="type">Normalize type</param>
        public void SetTheNormalizationValueOfDataToBeOpened(IAWG awg, NormalizationType type)
        {
            string requiredSyntax;
            switch (type)
            {
                case NormalizationType.None:
                    requiredSyntax = "NONE";
                    awg.SetMemoryOpenNormalize(requiredSyntax);
                    break;
                case NormalizationType.FullRange:
                    requiredSyntax = "FSC";
                    awg.SetMemoryOpenNormalize(requiredSyntax);
                    break;
                case NormalizationType.PreserveOffset:
                    requiredSyntax = "ZREF";
                    awg.SetMemoryOpenNormalize(requiredSyntax);
                    break;
            }
        }

        //glennj 6/21/2013
        /// <summary>
        /// Forces the awg to refresh it's copy of the open normalize mode
        /// </summary>
        /// <param name="awg">specific awg object</param>
        public void GetTheNormalizationOfDataToBeOpened(IAWG awg)
        {
            awg.UpdateMemoryOpenNormalize();
        }

        //glennj 6/21/2013
        /// <summary>
        /// Saves the given asset as a WFMX file
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="assetName">Name of the file to saved</param>
        /// <param name="filepath">New name and place to save the WFMX file</param>
        public void SaveTheAssetAsAWFMX(IAWG awg, string assetName, string filepath)
        {
            awg.MemorySaveWFMX(assetName, filepath);
        }

        //sforell 9/9/13 added support for SEQuence
        /// <summary>
        /// Saves the given asset as a SEQX file
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="assetName">Name of the file to saved</param>
        /// <param name="filepath">New name and place to save the SEQX file</param>
        public void SaveTheAssetAsASEQX(IAWG awg, string assetName, string filepath)
        {
            awg.MemorySaveSEQX(assetName, filepath);
        }

        //glennj 6/21/2013
        /// <summary>
        /// Saves the given asset as a TXT file
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="assetName">Name of the asset to saved</param>
        /// <param name="filepath">New name and place to save the TXT file</param>
        /// <param name="fileType">Type of the text file to be saved</param>
        public void SaveTheAssetAsATXT(IAWG awg, string assetName, string filepath, TextFileType fileType)
        {
            string requiredFileType = "";
            switch (fileType)
            {
                case TextFileType.FloatingPoint:
                    requiredFileType = "ANAL";
                    break;
                case TextFileType.DAC_8Bit:
                    requiredFileType = "DIG8";
                    break;
                case TextFileType.DAC_9Bit:
                    requiredFileType = "DIG9";
                    break;
                case TextFileType.DAC_10Bit:
                    requiredFileType = "DIG10";
                    break;
                default:
                    return;
            }
            awg.MemorySaveTXT(assetName, filepath, requiredFileType);
        }

        //glennj 6/21/2013
        /// <summary>
        /// Save the current state of the AWG as a setup file
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="filepath">Path to save the setup file</param>
        /// <param name="howToSaveAssets"></param>
        public void SaveTheSetup(IAWG awg, string filepath, SaveSetupAssets howToSaveAssets) 
        {
            string wAssets;
            switch (howToSaveAssets)
            {
                case SaveSetupAssets.With:
                    wAssets = "ON";
                    break;
                case SaveSetupAssets.Without:
                    wAssets = "OFF";
                    break;
                default:
                    wAssets = "";
                    break;
            }
            
            awg.MemorySaveSetup(filepath, wAssets);
        }

        //glennj 6/21/2013
        /// <summary>
        /// Force the AWG to update it's copy of the contents and state of the mass storage media.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="msus">Mass storage unit specifier</param>
        public void GetTheMassMemoryCatalog(IAWG awg, string msus)
        {
            awg.UpdateMemoryCatalog(msus);
        }

        public void TheMassMemoryCatalogShouldBeValid(IAWG awg)
        {
            Assert.IsTrue(awg.MassMemoryCatalog.Contains("\"$Recycle.Bin,DIR,0\"")); //Known for certain all AWGs will have a recycle bin
        }

        //glennj 6/21/2013
        /// <summary>
        /// Sets the current directory of the %AWG for the current msus.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="path">Current directory path</param>
        public void SetTheCurrentDirectoryTo(IAWG awg, string path)
        {
            awg.SetMemoryCDirectory(path);
        }

        //jmanning 9/04/2014
        /// <summary>
        /// Gets the recently opened waveforms using MMEMory:MROPened[:WAVeforms]?
        /// </summary>
        /// <returns>Names of waveforms recently opened</returns>
        public void GetMemoryRecentWaveformsOpened(IAWG awg)
        {
            awg.UpdateMemoryRecentWaveformsOpened();
        }

        //jmanning 9/04/2014
        /// <summary>
        /// This depends on the content of Waveform list of lists<para>
        /// It will use whatever is in the list to check against.</para><para>
        /// It does not look for duplicates.  Though there shouldn't be</para><para>
        /// but this isn't testing for accuracy of the list at the moment.</para><para>
        /// Code generates an error of the expected waveform name is not found.</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedWfmName"></param>
        /// <param name="toIncludeOrNotToInclude">True to include, False should not be included</param>
        public void RecentlyOpenedWaveformNameShouldInclude(IAWG awg , string expectedWfmName, bool toIncludeOrNotToInclude )
        {
            string[] wfmNames = awg.MassMemoryRecentlyOpenedWaveforms.Split(',');
            bool notFound = true;

            foreach (var wfmName in wfmNames)
            {
                if (_utils.Dequotify(wfmName) == expectedWfmName)
                {
                    if (toIncludeOrNotToInclude)
                    {
                        notFound = false;
                        break;            
                    }
                }
            }

            if (toIncludeOrNotToInclude)
            {
                Assert.IsFalse(notFound, "Waveform name was not found:  " + expectedWfmName + " in set of " + awg.MassMemoryRecentlyOpenedWaveforms);
            }
            else
            {
                Assert.IsTrue(notFound, "Waveform name was found:  " + expectedWfmName);
            }
        }
        
        //jmanning 9/04/2014
        /// <summary>
        /// Updates the recently opened sequences using MMEMory:MROPened:SEQuences?
        /// </summary>
        /// <returns>Names of sequences recently opened</returns>
        public void GetMemoryRecentSequencesOpened(IAWG awg)
        {
            awg.UpdateMemoryRecentSequencesOpened();
        }

        //jmanning 9/04/2014
        /// <summary>
        /// This depends on the content of sequence list of lists<para>
        /// It will use whatever is in the list to check against.</para><para>
        /// It does not look for duplicates.  Though there shouldn't be</para><para>
        /// but this isn't testing for accuracy of the list at the moment.</para><para>
        /// Code generates an error of the expected waveform name is not found.</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedSeqName"></param>
        /// <param name="toIncludeOrNotToInclude">True to include, False should not be included</param>
        public void RecentlyOpenedSequenceNameShouldInclude(IAWG awg, string expectedSeqName, bool toIncludeOrNotToInclude)
        {
            string[] seqNames = awg.MassMemoryRecentlyOpenedSequences.Split(',');

            bool notFound = true;

            foreach (var seqName in seqNames)
            {
                if (_utils.Dequotify(seqName) == expectedSeqName)
                {
                    if (toIncludeOrNotToInclude)
                    {
                        notFound = false;
                        break;
                    }
                }
            }

            if (toIncludeOrNotToInclude)
            {
                Assert.IsFalse(notFound, "Sequence name was not found:  " + expectedSeqName + " in set of " + awg.MassMemoryRecentlyOpenedSequences);
            }
            else
            {
                Assert.IsTrue(notFound, "Sequence name was found:  " + expectedSeqName);
            }
        }

        //glennj 6/21/2013
        /// <summary>
        /// Force awg to update it's local copy of the current directory
        /// </summary>
        /// <param name="awg">specific awg object</param>
        public void GetTheCurrentDirectory(IAWG awg)
        {
            awg.UpdateMemoryCDirectory();
        }

        public void TheCurrentDirectoryShouldBe(IAWG awg, string expectedPath)
        {
			Assert.AreEqual(expectedPath, awg.MassMemoryCurrentDirectory);
        }

        //glennj 6/21/2013
        /// <summary>
        /// Write data onto the %AWG hard disk
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="filePath">The path to write to</param>
        /// <param name="startPosition">The position to start writing at</param>
        /// <param name="blockData">The data to write</param>
        public void SendBLockDataToPositionAndFileOnTheAWG(IAWG awg, string filePath, string startPosition, string blockData)
        {
            awg.SetMemoryData(filePath, startPosition, blockData);
        }

        //glennj 6/21/2013
        /// <summary>
        /// Forces the AWG to try reading data from the %AWG hard disk and<para>
        /// store the information in it's local copy named block_data</para>
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="filePath">The path to read from</param>
        /// <param name="startPosition">The position to start reading from</param>
        /// <param name="dataSize">The size to read</param>
        public void GetBLockDataFromPositionAndFileOnTheAWG(IAWG awg, string filePath, string startPosition, string dataSize = "")
        {
            awg.UpdateMemoryData(filePath, startPosition, dataSize);
        }

        //glennj 1/7/2014
        /// <summary>
        /// Given and AWG and the data as a string, compare to updated block data.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedData"></param>
        public void TheBlockDataReturnedFromTheAwgShouldBe(IAWG awg, string expectedData)
        {
            Assert.AreEqual(expectedData, awg.MassMemoryBlockData, "The block data contents verification.");
        }

        //glennj 6/21/2013
        /// <summary>
        /// Force the awg to update's copy of the size of the the given file in bytes
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="filePath">Path of the file to be sized</param>
        public void GetTheSizeOfFile(IAWG awg, string filePath)
        {
            awg.UpdateMemoryDataSize(filePath);
        }

        public void TheFileSizeOnAWGShouldbe(IAWG awg, string expectedSize)
        {
            Assert.AreEqual(expectedSize, awg.MassMemoryDataSize);
        }

        //glennj 6/21/2013
        /// <summary>
        /// Deletes a file or directory from the %AWG's hard disk
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="fileName">File or directory path to be deleted</param>
        /// <param name="drive"></param>
        public void DeleteFileorDirectoryInMassStorage(IAWG awg, string fileName, string drive = "" )
        {
            awg.MemoryDelete(fileName, drive);
        }

        //glennj 6/21/2013
        /// <summary>
        /// Creates a new directory in the current path.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="directoryName"></param>
        public void CreateNewDirectoryInCurrentDirectory(IAWG awg, string directoryName)
        {
            awg.MemoryMDirectory(directoryName);
        }

        //glennj 6/21/2013
        /// <summary>
        /// Sets the mass storage device used by all the MEMMory commands.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="msus">Drive letter</param>
        public void SetTheStorageDriveSpecifier(IAWG awg, string msus)
        {
            awg.SetMemoryDrive(msus);
        }

        //glennj 6/21/2013
        /// <summary>
        /// Forces the AWG to update it's local copy of the mass storage device<para>
        /// used by all the MMEmory commands</para>
        /// </summary>
        /// <param name="awg">specific awg object</param>
        public void GetTheCurrentDriveSpecifier(IAWG awg)
        {
            awg.UpdateMemoryDrive();
        }

        public void CurrentStorageUnitSpecifierShouldBe(IAWG awg, string expectedValue)
        {
			Assert.AreEqual(expectedValue, awg.MassMemoryCurrentDrive);
        }
    }
}