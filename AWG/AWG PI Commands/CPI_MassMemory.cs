
namespace AwgTestFramework
{
    public partial class CPi70KCmds
    {
        #region Mass Memory

        #region MMEMory:CATalog

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:CATalog? gets the current contents and state of the mass storage media.
        /// </summary>
        /// <param name="msus">Mass storage unit specifier</param>
        /// <returns>List of contents of the given mass storage in the format of: File name, file type, file size </returns>
        public string GetAwgMemoryCatalog(string msus)
        {
            string response;

            if (msus != "") //if the msus specified, it needs to be quote-delimited
            {
                msus = '"' + msus + '"';
            }

            string commandLine = "MMEMory:CATalog? " + msus;
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion MMEMory:CATalog

        #region MMEMory:CDIRectory

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:CDIRectory set the current directory of the %AWG not including the msus.
        /// </summary>
        /// <param name="path">Current directory path</param>
        public void SetAwgMemoryCDirectory(string path)
        {
            var commandLine = "MMEMory:CDIRectory " + '"' + path + '"';
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:CDIRectory? get the current directory of the %AWG not including the msus.
        /// </summary>
        /// <returns>Current directory path</returns>
        public string GetAwgMemoryCDirectory()
        {
            string response;
            const string commandLine = "MMEMory:CDIRectory?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion MMEMory:CDIRectory

        #region MMEMory:DATA

        //glennj 6/20/2013
        /// <summary>
        /// Using  MMEMory:DATA to write data onto the %AWG hard disk
        /// </summary>
        /// <param name="filePath">The path to write to</param>
        /// <param name="startPosition">The position to start writing at</param>
        /// <param name="blockData">The data to write</param>
        public void SetAwgMemoryData(string filePath, string startPosition, string blockData)
        {
            // Here, we get the byte length of the string, then we get the byte length of the length value (stupid IEE488.2 spec)
            var dataLength = blockData.Length;
// ReSharper disable SpecifyACultureInStringConversionExplicitly
            var tempString = dataLength.ToString();
// ReSharper restore SpecifyACultureInStringConversionExplicitly
            var tempLength = tempString.Length;
// ReSharper disable SpecifyACultureInStringConversionExplicitly
            var prefixCount = tempLength.ToString();
// ReSharper restore SpecifyACultureInStringConversionExplicitly

            // Then, we construct the prefix from those two strings and the pound sign
            var prefix = "#" + prefixCount + dataLength;

            // We use that prefix and concatenate it to the start of the data block
            var commandLine = "MMEMory:DATA " + '"' + filePath + '"' + ',' + startPosition + ',' + prefix + blockData;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:DATA? tries to read data from the %AWG hard disk and store the information in the %AWG object
        /// </summary>
        /// <param name="filePath">The path to read from</param>
        /// <param name="startPosition">The position to start reading from</param>
        /// <param name="dataSize">The size to read</param>
        public string GetAwgMemoryData(string filePath, string startPosition, string dataSize = "")
        {
            string response;

            // Since dataSize is optional, we may or may not need a leading comma for the command string
            if (dataSize != "")
            {
                dataSize = ", " + dataSize;
            }
            string commandLine = "MMEMory:DATA? " + '"' + filePath + '"' + ',' + startPosition + dataSize;
            _mAWGVisaSession.Query(commandLine, out response);

            //In this case, we need the OPC command to wait for the data to come back before we try to store it.
            //AwgOperationCompleteQuery(awg, m_defaultVISATimeout);             // glennj 6/21/2013.  An *OPC? here does not make any sense.
            // *OPC? are used for overlapped commands, not queries!
            return response;
        }

        #endregion MMEMory:DATA

        #region MMEMory:DATA:SIZE?

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:DATA:SIZE? gets the size in bytes of the given file
        /// </summary>
        /// <param name="filePath">Path of the file to be sized</param>
        /// <returns>Size of the file in bytes</returns>
        public string GetAwgMemoryDataSize(string filePath)
        {
            string response;
            var commandLine = "MMEMory:DATA:SIZE? " + '"' + filePath + '"';
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion MMEMory:DATA:SIZE?

        #region MMEMory:DELete

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:DELete delete a file or directory from the %AWG's hard disk
        /// </summary>
        /// <param name="fileName">File or directory path to be deleted</param>
        /// <param name="drive">Mass storage unit specifier</param>
        public void DeleteAwgMemory(string fileName, string drive)
        {
            var specificDrive = "";
            if (drive != "")
            {
                specificDrive = ',' + "\"" + drive + ":\"";
            }
            var commandLine = "MMEMory:DELete " + '"' + fileName + '"' + specificDrive;
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion MMEMory:DELete

        #region MMEMory:IMPort

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:IMPort imports a file
        /// </summary>
        /// <param name="wfmName">Desired waveform to import</param>
        /// <param name="fileName">file name</param>
        /// <param name="wfmType">waveform type</param>
        public void ImportAwgMemory(string wfmName, string wfmType, string fileName)
        {
            var commandLine = "MMEMory:IMPort " + '"' + wfmName + '"' + ',' + '"' + fileName + '"' + ',' + wfmType;
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion MMEMory:IMPort

        #region MMEMory:IMPort:PARameter:NORMalize

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:IMPort:PARameter:NORMalize sets a normalization mode for import
        /// </summary>
        /// <param name="type">Desired waveform to import</param>
        public void SetAwgMemoryImportNormalize(string type)
        {
            var commandLine = "MMEMory:IMPort:PARameter:NORMalize " + type;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:IMPort:PARameter:NORMalize? gets normalization mode for open
        /// </summary>
        /// <returns>Whether the imported waveform was actually normalized</returns>
        public string GetAwgMemoryImportNormalize()
        {
            string response;
            const string commandLine = "MMEMory:IMPort:PARameter:NORMalize?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion MMEMory:IMPort:PARameter:NORMalize

        #region MMEMory:MDIRectory

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:MDIRectory creates a new directory in the current path.
        /// </summary>
        /// <param name="directoryName"></param>
        public void AwgMemoryMDirectory(string directoryName)
        {
            var commandLine = "MMEMory:MDIRectory " + '"' + directoryName + '"';
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion MMEMory:MDIRectory

        #region MMEMory:MROPened?

        //jmanning 9/04/2014
        /// <summary>
        /// Using MMEMory:MROPened[:WAVeforms]? gets the recently opened waveforms
        /// </summary>
        /// <returns>Names of waveforms recently opened</returns>
        public string GetAwgMemoryRecentWaveformsOpened()
        {
            string response;
            var commandLine = "MMEMory:MROPened?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion MMEMory:MROPened?

        #region MMEMory:MROPened:SEQuences?

        //jmanning 9/04/2014
        /// <summary>
        /// Using MMEMory:MROPened:SEQuences? gets the recently opened sequences
        /// </summary>
        /// <returns>Names of sequences recently opened</returns>
        public string GetAwgMemoryRecentSequencesOpened()
        {
            string response;
            var commandLine = "MMEMory:MROPened:SEQuences?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion MMEMory:MROPened:SEQuences?

        #region MMEMory:MSIS

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:MSIS sets the drive (mass storage device) used by all the MEMMory commands.
        /// </summary>
        /// <param name="drive">Drive letter</param>
        public void SetAwgMemoryDrive(string drive)
        {
            var commandLine = "MMEMory:MSIS " + '"' + drive + '"';
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:MSIS? gets the mass storage device used by all the MMEmory commands
        /// </summary>
        /// <returns>Drive letter</returns>
        public string GetAwgMemoryMsis()
        {
            string response;
            const string commandLine = "MMEMory:MSIS?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }        

        #endregion MMEMory:MSIS

        #region MMEMory:OPEN

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:OPEN opens a waveform
        /// </summary>
        /// <param name="fileName">file name</param>
        public void OpenAwgMemory(string fileName)
        {
            string commandLine = "MMEMory:OPEN " + '\"' + fileName + '\"';
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion MMEMory:OPEN

        #region MMEMory:OPEN:PARameter:NORMalize

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:OPEN:PARameter:NORMalize sets a normalization mode for open
        /// </summary>
        /// <param name="waveform">Whether the opened waveform was actually normalized</param>
        public void SetAwgMemoryOpenNormalize(string waveform)
        {
            var commandLine = "MMEMory:OPEN:PARameter:NORMalize " + waveform;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:OPEN:PARameter:NORMalize? gets the normalization mode for open
        /// </summary>
        /// <returns>Whether the imported waveform was actually normalized</returns>
        public string GetAwgMemoryOpenNormalize()
        {
            string response;
            const string commandLine = "MMEMory:OPEN:PARameter:NORMalize?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion MMEMory:OPEN:PARameter:NORMalize

        #region MMEMory:OPEN:SASSet

        //sforell 8/26/13 fixed commandLine being changed completely to illegal syntax when desiredWfm was not empty
        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:OPEN:SASSet opens desired waveforms from an .AWG file or a native setup file into the arbitrary waveform generator’s assets.
        /// </summary>
        /// <param name="fileName">Path to the Setup file</param>
        /// <param name="desiredWfm">Optional names of a desired waveforms to open</param>
        public void OpenAwgMemorySasset(string fileName, string desiredWfm)
        {
            var commandLine = "MMEMory:OPEN:SASSet " + '\"' + fileName + '\"';
            if (desiredWfm != "")
            {
                commandLine += ",\"" + desiredWfm + "\"";
            }
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion MMEMory:OPEN:SASSet

        #region MMEMory:OPEN
        //shkv created to fix 5331
        //sforell 8/26/13 fixed commandLine being changed completely to illegal syntax when desiredWfm was not empty
        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:OPEN opens desired waveforms from an .AWG file or a native setup file into the arbitrary waveform generator’s assets.
        /// </summary>
        /// <param name="fileName">Path to the Setup file</param>
        /// <param name="desiredWfm">Optional names of a desired waveforms to open</param>
        public void OpenAwgMemory(string fileName, string desiredWfm)
        {
            var commandLine = "MMEMory:OPEN " + '\"' + fileName + '\"';
            if (desiredWfm != "")
            {
                commandLine += ",\"" + desiredWfm + "\"";
            }
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion MMEMory:OPEN

        #region MMEMory:OPEN:SASSet:SEQuence

        //glennj 8/8/2013
        /// <summary>
        /// Using MMEMory:OPEN:SASSetSEQuence: opens all or a desired sequence
        /// </summary>
        /// <param name="filePath">Path to the Setup file</param>
        /// <param name="desiredSequence">Optional names of a desired waveforms to open</param>
        public void OpenAwgMemorySassetSequence(string filePath, string desiredSequence)
        {
            var commandLine = "MMEMory:OPEN:SASSet:SEQuence " + '\"' + filePath + '\"';
            if (desiredSequence != "")
            {
                commandLine += "," + '\"' + desiredSequence + '\"'; 
            }
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion MMEMory:OPEN:SASSet:SEQuence

        #region MMEMory:OPEN:SASSet:SEQuence:MROPened?
        //jmanning 9/04/2014
        /// <summary>
        /// Using MMEMory:OPEN:SASSet:SEQuence:MROPened? gets the most recently opened sequence name
        /// </summary>
        /// <returns>Name of sequence most recently opened</returns>
        public string GetAwgMemoryMostRecentSequenceOpened()
        {
            string response;
            var commandLine = "MMEMory:OPEN:SASSet:SEQuence:MROPened?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion MMEMory:OPEN:SASSet:SEQuence:MROPened?

        #region MMEMory:OPEN:SETup

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:OPEN:SETup opens a setup file
        /// </summary>
        /// <param name="fileName">The name of the file to open</param>
        public void OpenAwgMemorySetup(string fileName)
        {
            var commandLine = "MMEMory:OPEN:SETup " + '"' + fileName + '"';
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion MMEMory:OPEN:SETup

        #region MMEMory:OPEN:TXT

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:OPEN:TXT opens a text file.
        /// </summary>
        /// <param name="fileName">Path of the text file</param>
        /// <param name="bitDepth">OPTIONAL: The bit depth of the text file required for digital</param>
        public void OpenAwgMemoryTxt(string fileName, string bitDepth)
        {
            if (bitDepth != "") //If the bit depth is empty no comma is needed in the write command
            {
                bitDepth = ',' + bitDepth;
            }
            var commandLine = "MMEMory:OPEN:TXT " + '\"' + fileName + '\"' + bitDepth;
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion MMEMory:OPEN:TXT

        #region MMEMory:SAVE:SETup

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:SAVE:SETup saves the current state of the AWG as a setup file
        /// </summary>
        /// <param name="filepath">Path to save the setup file</param>
        /// <param name="wAssets">Flag for including assets with the setup file</param>
        public void SaveAwgMemorySetup(string filepath, string wAssets)
        {
            if (wAssets != "")
            {
                wAssets = "," + wAssets;
            }
            var commandLine = "MMEMory:SAVE:SETup " + '"' + filepath + '"' + wAssets;
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion MMEMory:SAVE:SETup

        #region MMEMory:SAVE:TXT

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:SAVE:TXT saves the given asset as a TXT file
        /// </summary>
        /// <param name="assetName">Name of the asset to saved</param>
        /// <param name="filepath">New name and place to save the TXT file</param>
        /// <param name="fileType">Type of the text file to be saved</param>
        public void SaveAwgMemoryTXT(string assetName, string filepath, string fileType)
        {
            var commandLine = "MMEMory:SAVE:TXT " + '"' + assetName + '"' + ',' + '"' + filepath + '"' + ", " + fileType;
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion MMEMory:SAVE:TXT

        #region MMEMory:SAVE:WFMX

        //glennj 6/20/2013
        /// <summary>
        /// Using MMEMory:SAVE:WFMX saves the given asset as a WFMX file
        /// </summary>
        /// <param name="assetName">Name of the file to saved</param>
        /// <param name="filepath">New name and place to save the WFMX file</param>
        public void SaveAwgMemoryWFMX(string assetName, string filepath)
        {
            var commandLine = "MMEMory:SAVE:WFMX " + '"' + assetName + '"' + ',' + '"' + filepath + '"';
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion MMEMory:SAVE:WFMX

        #region MMEMor:SAVE:SEQuence

        //sforell 9/9/13 Added PI command
        /// <summary>
        /// Using MMEMory:SAVE:SEQuence saves the given asset as a SEQX file
        /// </summary>
        /// <param name="assetName">Name of the file to saved</param>
        /// <param name="filepath">New name and place to save the SEQX file</param>
        public void SaveAwgMemorySEQX(string assetName, string filepath)
        {
            string commandLine = "MMEMory:SAVE:SEQuence " + '"' + assetName + '"' + ',' + '"' + filepath + '"';
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion MMEMor:SAVE:SEQuence

        #endregion Mass Memory
    }
}