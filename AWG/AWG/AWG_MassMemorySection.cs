
// ReSharper disable CheckNamespace
namespace AwgTestFramework
// ReSharper restore CheckNamespace
{
    public partial class AWG
    {
        /// <summary>
        /// Attribute that is updated from the UpdateMemoryDataSize()
        /// </summary>
        public string MassMemoryDataSize { get; set; }

        /// <summary>
        /// Attribute that is updated by using UpdateMemoryData()
        /// </summary>
        public string MassMemoryBlockData { get; set; }

        /// <summary>
        /// Attribute that is updated by using UpdateMemoryCatalog()
        /// </summary>
        public string MassMemoryCatalog { get; set; }

        /// <summary>
        /// Attribute that is updated by using UpdateMemoryCDirectory()
        /// </summary>
        public string MassMemoryCurrentDirectory { get; set; }

        /// <summary>
        /// Attribute that is updated by using UpdateMemoryDrive()
        /// </summary>
        public string MassMemoryCurrentDrive { get; set; }

        /// <summary>
        /// Attribute that is updated by using UpdateMemoryImportNormalize()
        /// </summary>
        public string MassMemoryImportParameterNormalize { get; set; }

        /// <summary>
        /// Attribute that is updated by using UpdateMemoryOpenNormalize()
        /// </summary>
        public string MassMemoryOpenParameterNormalize { get; set; }

        /// <summary>
        /// Attribute that is updated by using UpdateMemoryRecentSequencesOpened()
        /// </summary>
        public string MassMemoryRecentlyOpenedSequences { get; set; }

        /// <summary>
        /// Attribute that is updated by using UpdateMemoryRecentWaveformsOpened()
        /// </summary>
        public string MassMemoryRecentlyOpenedWaveforms { get; set; }

        /// <summary>
        /// Attribute that is updated by using UpdateMemoryMostRecentSequenceOpened()
        /// </summary>
        public string MassMemoryMostRecentlyOpenedSequence { get; set; }

        #region Mass Memory

        #region #region MMEMory:CATalog
        //glennj 6/20/2013
        /// <summary>
        /// Updates the local copy the current contents and state of the mass storage media.
        /// </summary>
        /// <param name="msus">Mass storage unit specifier</param>
        /// <returns>List of contents of the given mass storage in the format of: File name, file type, file size </returns>
        public void UpdateMemoryCatalog(string msus)
        {
            MassMemoryCatalog = _pi.GetAwgMemoryCatalog(msus);
        }

        #endregion #region MMEMory:CATalog

        #region MMEMory:CDIRectory
        //glennj 6/20/2013
        /// <summary>
        /// Set the current directory of the current msus
        /// </summary>
        /// <param name="path">Current directory path</param>
        public void SetMemoryCDirectory(string path)
        {
            _pi.SetAwgMemoryCDirectory(path);
        }

        //glennj 6/20/2013
        /// <summary>
        /// Update the local copy of the current directory
        /// </summary>
        public void UpdateMemoryCDirectory()
        {
            MassMemoryCurrentDirectory = _pi.GetAwgMemoryCDirectory();
        }
        #endregion MMEMory:CDIRectory

        #region MMEMory:DATA
        //glennj 6/20/2013
        /// <summary>
        /// Write data onto the %AWG hard disk
        /// </summary>
        /// <param name="filePath">The path to write to</param>
        /// <param name="startPosition">The position to start writing at</param>
        /// <param name="blockOfData">The data to write</param>
        public void SetMemoryData(string filePath, string startPosition, string blockOfData)
        {
            _pi.SetAwgMemoryData(filePath, startPosition, blockOfData);
        }

        //glennj 6/20/2013
        /// <summary>
        /// Read data from the %AWG hard disk and store the information locally in block data
        /// </summary>
        /// <param name="filePath">The path to read from</param>
        /// <param name="startPosition">The position to start reading from</param>
        /// <param name="sizeOfData">The size to read</param>
        public void UpdateMemoryData(string filePath, string startPosition, string sizeOfData = "")
        {
            MassMemoryBlockData = _pi.GetAwgMemoryData(filePath, startPosition, sizeOfData);
        }
        #endregion MMEMory:DATA

        #region MMEMory:DATA:SIZE?
        //glennj 6/20/2013
        /// <summary>
        /// Updates local dataSize for the given file
        /// </summary>
        /// <param name="filePath">Path of the file to be sized</param>
        /// <returns>Size of the file in bytes</returns>
        public void UpdateMemoryDataSize(string filePath)
        {
            MassMemoryDataSize = _pi.GetAwgMemoryDataSize(filePath);
        }
        #endregion MMEMory:DATA:SIZE?

        #region MMEMory:DELete
        //glennj 6/20/2013
        /// <summary>
        /// Delete a file or directory from the %AWG's hard disk
        /// </summary>
        /// <param name="fileName">File or directory path to be deleted</param>
        /// <param name="msus">Mass storage unit specifier</param>
        public void MemoryDelete(string fileName, string msus)
        {
            _pi.DeleteAwgMemory(fileName, msus);
        }
        #endregion MMEMory:DELete

        #region MMEMory:IMPort
        //glennj 6/20/2013
        /// <summary>
        /// Imports a file
        /// </summary>
        /// <param name="wfmName">Desired waveform to import</param>
        /// <param name="wfmType">waveform type</param>
        /// <param name="fileName">file name</param>
        public void MemoryImport(string wfmName, string wfmType, string fileName)
        {
            _pi.ImportAwgMemory(wfmName, wfmType, fileName);
        }
        #endregion MMEMory:IMPort

        #region MMEMory:IMPort:PARameter:NORMalize
        //glennj 6/20/2013
        /// <summary>
        /// Sets the normalize type for import
        /// </summary>
        /// <param name="type">normalization type</param>
        public void SetMemoryImportNormalize(string type)
        {
            _pi.SetAwgMemoryImportNormalize(type);
        }

        //glennj 6/20/2013
        /// <summary>
        /// Update local copy of the import parameter normalize type
        /// </summary>
        public void UpdateMemoryImportNormalize()
        {
            MassMemoryImportParameterNormalize = _pi.GetAwgMemoryImportNormalize();
        }
        #endregion MMEMory:IMPort:PARameter:NORMalize

        #region MMEMory:MDIRectory
        //glennj 6/20/2013
        /// <summary>
        /// Creates a new directory in the current path.
        /// </summary>
        /// <param name="directoryName"></param>
        public void MemoryMDirectory(string directoryName)
        {
            _pi.AwgMemoryMDirectory(directoryName);
        }
        #endregion MMEMory:MDIRectory

        #region MMEMory:MROPened?

        //jmanning 9/04/2014
        /// <summary>
        /// Updates the recently opened waveforms using MMEMory:MROPened[:WAVeforms]?
        /// </summary>
        /// <returns>Names of waveforms recently opened</returns>
        public void UpdateMemoryRecentWaveformsOpened()
        {
            MassMemoryRecentlyOpenedWaveforms = _pi.GetAwgMemoryRecentWaveformsOpened();
        }

        #endregion MMEMory:MROPened?

        #region MMEMory:MROPened:SEQuences?

        //jmanning 9/04/2014
        /// <summary>
        /// Updates the recently opened sequences using MMEMory:MROPened:SEQuences?
        /// </summary>
        /// <returns>Names of sequences recently opened</returns>
        public void UpdateMemoryRecentSequencesOpened()
        {
            MassMemoryRecentlyOpenedSequences = _pi.GetAwgMemoryRecentSequencesOpened();
        }

        #endregion MMEMory:MROPened:SEQuences?
        
        #region MMEMory:MSIS
        //glennj 6/20/2013
        /// <summary>
        /// Sets the mass storage device used by all the MEMMory commands.
        /// </summary>
        /// <param name="drive">Drive letter</param>
        public void SetMemoryDrive(string drive)
        {
            _pi.SetAwgMemoryDrive(drive);
        }

        //glennj 6/20/2013
        /// <summary>
        /// Update the local copy of the current drive of the mass storage device used by all the MMEmory commands
        /// </summary>
        /// <returns>Drive letter</returns>
        public void UpdateMemoryDrive()
        {
            MassMemoryCurrentDrive = _pi.GetAwgMemoryMsis();
        }
        #endregion MMEMory:MSIS

        #region MMEMory:OPEN
        //glennj 6/20/2013
        /// <summary>
        /// Opens a waveform
        /// </summary>
        /// <param name="fileName">file name</param>
        public void MemoryOpen(string fileName)
        {
            _pi.OpenAwgMemory(fileName);
        }
        #endregion MMEMory:OPEN

        #region MMEMory:OPEN:PARameter:NORMalize
        //glennj 6/20/2013
        /// <summary>
        /// Sets a normalization type(mode) for open
        /// </summary>
        /// <param name="type">type of normalization</param>
        public void SetMemoryOpenNormalize(string type)
        {
            _pi.SetAwgMemoryOpenNormalize(type);
        }

        //glennj 6/20/2013
        /// <summary>
        /// Update the local copy of the normalization mode for open
        /// </summary>
        public void UpdateMemoryOpenNormalize()
        {
            MassMemoryOpenParameterNormalize = _pi.GetAwgMemoryOpenNormalize();
        }
        #endregion MMEMory:OPEN:PARameter:NORMalize

        #region MMEMory:OPEN:SASSet
        //glennj 6/20/2013
        /// <summary>
        /// Opens desired waveforms from an .AWG file or a native setup file<para>
        /// into the arbitrary waveform generator’s assets.</para>
        /// </summary>
        /// <param name="fileName">Path to the Setup file</param>
        /// <param name="desiredWfm">Optional names of a desired waveforms to open</param>
        public void OpenMemorySasset(string fileName, string desiredWfm)
        {
            _pi.OpenAwgMemorySasset(fileName, desiredWfm);
        }
        #endregion MMEMory:OPEN:SASSet

        #region MMEMory:OPEN
        //shkv 11/21/2014 updated to support MMEMory:OPEN
        //glennj 6/20/2013
        /// <summary>
        /// Opens desired waveforms from an .AWG file or a native setup file<para>
        /// into the arbitrary waveform generator’s assets.</para>
        /// </summary>
        /// <param name="fileName">Path to the Setup file</param>
        /// <param name="desiredWfm">Optional names of a desired waveforms to open</param>
        public void OpenMemory(string fileName, string desiredWfm)
        {
            _pi.OpenAwgMemory(fileName, desiredWfm);
        }
        #endregion MMEMory:OPEN

        #region MMEMory:OPEN:SASSet:SEQuence
        //glennj 8/8/2013
        /// <summary>
        /// Using MMEMory:OPEN:SASSetSEQuence: opens all or a desired sequence
        /// </summary>
        /// <param name="filePath">Path to the Setup file</param>
        /// <param name="desiredSequence">Optional names of a desired waveforms to open</param>
        public void OpenMemorySassetSequence(string filePath, string desiredSequence)
        {
            _pi.OpenAwgMemorySassetSequence(filePath, desiredSequence);
        }
        #endregion MMEMory:OPEN:SASSet:SEQuence

        #region MMEMory:OPEN:SASSet:SEQuence:MROPened?

        //jmanning 9/04/2014
        /// <summary>
        /// Updates the name of the most recently opened sequence using MMEMory:OPEN:SASSet:SEQuence:MROPened?
        /// </summary>
        /// <returns>Names of sequence most recently opened</returns>
        public void UpdateMemoryMostRecentSequenceOpened()
        {
            MassMemoryMostRecentlyOpenedSequence = _pi.GetAwgMemoryMostRecentSequenceOpened();
        }

        #endregion MMEMory:OPEN:SASSet:SEQuence:MROPened?


        #region MMEMory:OPEN:SETup
        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:OPEN:SETup opens a setup file
        /// </summary>
        /// <param name="fileName">The name of the file to open</param>
        public void MemoryOpenSetup(string fileName)
        {
            _pi.OpenAwgMemorySetup(fileName);
        }
        #endregion MMEMory:OPEN:SETup

        #region MMEMory:OPEN:TXT
        //glennj 6/20/2013
        /// <summary>
        /// Opens a text file.
        /// </summary>
        /// <param name="fileName">Path of the text file</param>
        /// <param name="bitDepth">OPTIONAL: The bit depth of the text file required for digital</param>
        public void MemoryOpenTxt(string fileName, string bitDepth)
        {
            _pi.OpenAwgMemoryTxt(fileName, bitDepth);
        }
        #endregion MMEMory:OPEN:TXT

        #region MMEMory:SAVE:SETup
        //glennj 6/20/2013
        /// <summary>
        /// Saves the current state of the AWG as a setup file
        /// </summary>
        /// <param name="filepath">Path to save the setup file</param>
        /// <param name="wAssets">Flag for including assets with the setup file</param>
        public void MemorySaveSetup(string filepath, string wAssets)
        {
            _pi.SaveAwgMemorySetup(filepath, wAssets);
        }
        #endregion MMEMory:SAVE:SETup

        #region MMEMory:SAVE:TXT
        //glennj 6/20/2013
        /// <summary>
        /// Saves the given asset as a TXT file
        /// </summary>
        /// <param name="assetName">Name of the asset to saved</param>
        /// <param name="filepath">New name and place to save the TXT file</param>
        /// <param name="fileType">Type of the text file to be saved</param>
        public void MemorySaveTXT(string assetName, string filepath, string fileType)
        {
            _pi.SaveAwgMemoryTXT(assetName, filepath, fileType);
        }
        #endregion MMEMory:SAVE:TXT

        #region MMEMory:SAVE:WFMX
        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:SAVE:WFMX saves the given asset as a WFMX file
        /// </summary>
        /// <param name="assetName">Name of the file to saved</param>
        /// <param name="filepath">New name and place to save the WFMX file</param>
        public void MemorySaveWFMX(string assetName, string filepath)
        {
            _pi.SaveAwgMemoryWFMX(assetName, filepath);
        }
        #endregion MMEMory:SAVE:WFMX

        #region MMEMor:SAVE:SEQuence
        //sforell 9/9/13
        /// <summary>
        /// Using MMEMory:SAVE:WFMX saves the given asset as a WFMX file
        /// </summary>
        /// <param name="assetName">Name of the file to saved</param>
        /// <param name="filepath">New name and place to save the WFMX file</param>
        public void MemorySaveSEQX(string assetName, string filepath)
        {
            _pi.SaveAwgMemorySEQX(assetName, filepath);
        }
        #endregion MMEMor:SAVE:SEQuence

        #endregion Mass Memory


    }
}
