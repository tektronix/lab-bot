
using System;
using System.Globalization;

namespace AwgTestFramework 
{
    public partial class CPi70KCmds
    {
        #region Waveform

        #region WLIST

        #region WLISt:LAST

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:LAST? return the names of the waveforms in the waveform list.
        /// </summary>
        /// <returns>List of waveforms in the asset list</returns>
        public string GetAwgWListLast()
        {
            string response;
            const string commandLine = "WLISt:LAST?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;   
        }

        #endregion WLISt:LIST

        #region WLIST:LIST

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:LIST? return the names of the waveforms in the waveform list.
        /// </summary>
        /// <returns>List of waveforms in the asset list</returns>
        public string GetAwgWListList()
        {
            string response;
            const string commandLine = "WLISt:LIST?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion WLIST:LIST

        #region WLISt:NAME

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:NAME? get the name of the waveform of an element in the waveform list
        /// </summary>
        /// <param name="listIndex">Index of the waveform in the waveform list</param>
        /// <returns>The name of the waveform</returns>
        public string GetAwgWlistName(string listIndex)
        {
            string response;
            string commandLine = "WLISt:NAME? " + listIndex;
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion WLISt:NAME

        #region WLISt:SIZE

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:SIZE? get the size of the waveform list.
        /// </summary>
        /// <returns>Size of the waveform list</returns>
        public string GetAwgWlistSize()
        {
            string response;
            const string commandLine = "WLISt:SIZE?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion WLISt:SIZE

        #region WLISt:WAVeform:SFORmat

        //Keerthi 05/28/2015
        /// <summary>
        /// Using WLISt:WAVeform:SFORmat sets the signal format for the waveform
        /// </summary>
        /// <param name="signalFormat">Signal format type (I/Q/REAL/UND)</param>
        /// <param name="wfmName">Name of the waveform</param>
        /// <param name="awg">specific awg</param>


        public void SetSignalFormat(string signalFormat, string wfmName, IAWG awg)
        {

            string commandLine = "WLISt:WAVeform:SFORmat " + '"' + wfmName + '"' + ',' + signalFormat;
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion WLISt:WAVeform:SFORmat

        #region WLISt:WAVeform:SFORmat?

        //Keerthi 05/28/2015
        /// <summary>
        /// Using WLISt:WAVeform:SFORmat? Gets the signal format for a given waveform name and return the string value
        /// </summary>
        /// <param name="wfmName">Name of the waveform</param>

        public string GetSignalFormat(string wfmName)
        {
            string response;
            string commandLine = "WLIST:WAVEFORM:SFORMAT? " + '"' + wfmName + '"';
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

       #endregion WLISt:WAVeform:SFORmat?

        #region WLISt:WAVeform:DATA

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:WAVeform:DATA transfer waveform data from the external controller into the waveform list 
        /// </summary>
        /// <param name="wfmName"></param>
        /// <param name="startIndex"></param>
        /// <param name="size"></param>
        /// <param name="blockData">Expecting an CSV list of 4 byte floating point</param>
        public void SetAwgWListWaveformData(string wfmName, string startIndex, string size, string blockData)
        {
            string commandLine = "WLISt:WAVeform:DATA " + '"' + wfmName + '"';
            if (startIndex != "")
            {
                commandLine += ',' + startIndex;
            }
            if (size != "")
            {
                commandLine += ',' + size;
            }

            // Split the block of analog values into an array
            string[] analogValues = blockData.Split(',');
            // Now we can get the number of values in the block and times for 4 (4bytes/float) number of
            int numberOfBytes = (analogValues.Length * 4);
            // Need to build the prefix to the block with standard "#dxxx"
            string header = ",#" + numberOfBytes.ToString(CultureInfo.InvariantCulture).Length + numberOfBytes.ToString(CultureInfo.InvariantCulture);
            // Add it to the command line
            commandLine += header;

            // Now a byte array needs to be created that will hold the command, parameters, header and block of data.

            byte[] cmdInBytes = new byte[commandLine.Length + numberOfBytes];
            int cmdInBytesIndex;

            for (cmdInBytesIndex = 0; cmdInBytesIndex < commandLine.Length; cmdInBytesIndex += 1)
            {
                cmdInBytes[cmdInBytesIndex] = (byte) commandLine[cmdInBytesIndex];
            }

            foreach (string analogValue in analogValues)
            {
                float fvalue = Convert.ToSingle(analogValue);
                byte[] fvalueAsBytes = BitConverter.GetBytes(fvalue);
                foreach (byte asByte in fvalueAsBytes)
                {
                    cmdInBytes[cmdInBytesIndex++] += asByte;
                }
            }

            _mVISAExt.Write(cmdInBytes);
        }

        /// <summary>
        /// Using WLISt:WAVeform:DATA transfer waveform data from the external controller into the waveform list 
        /// </summary>
        /// <param name="wfmName"></param>
        /// <param name="startIndex"></param>
        /// <param name="size"></param>
        /// <param name="blockData">Expecting an CSV list of 4 byte floating point</param>
        public void SetAwgWListWaveformPieceData(string wfmName, string startIndex, string size, string blockData)
        {
            string commandLine = "WLISt:WAVeform:DATA " + '"' + wfmName + '"';
            if (startIndex != "")
            {
                commandLine += ',' + startIndex;
            }
            if (size != "")
            {
                commandLine += ',' + size;
            }
            commandLine += ',' + blockData;

            // Split the block of analog values into an array
           // string[] analogValues = blockData.Split(',');
            // Now we can get the number of values in the block and times for 4 (4bytes/float) number of
           // int numberOfBytes = (analogValues.Length * 4);
            // Need to build the prefix to the block with standard "#dxxx"
            //string header = ",#" + numberOfBytes.ToString(CultureInfo.InvariantCulture).Length + numberOfBytes.ToString(CultureInfo.InvariantCulture);
            // Add it to the command line
           // commandLine += header

            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:WAVeform:DATA? transfer waveform data from the external controller into the waveform list
        /// </summary>
        /// <param name="wfmName"></param>
        /// <param name="startIndex"></param>
        /// <param name="size"></param>
        public byte[] GetAwgWListWaveformData(string wfmName, string startIndex, string size)
        {
            string commandLine = "WLISt:WAVeform:DATA? " + '"' + wfmName + '"';
            if (startIndex != "")
            {
                commandLine += ',' + startIndex;
            }
            if (size != "")
            {
                commandLine += ',' + size;
            }

            _mAWGVisaSession.Write(commandLine);

// ReSharper disable RedundantAssignment
// ReSharper disable SuggestUseVarKeywordEvident
            byte[] cmdInBytes = new byte[1];
// ReSharper restore SuggestUseVarKeywordEvident
// ReSharper restore RedundantAssignment

            _mAWGVisaSession.ReadBinary(out cmdInBytes);
            return cmdInBytes;
        }

        #endregion WLISt:WAVeform:DATA

        #region WLISt:WAVeform:DELete

        //glennj 7/25/2013
        /// <summary>
        /// Using WLIST:WAVeform:DELete delete the waveform from the waveform list
        /// </summary>
        /// <param name="wfmName">Name of the waveform to delete</param>
        public void AwgWListWaveformDelete(string wfmName)
        {
            string commandLine = "WLIST:WAVeform:DELete " + wfmName ;
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion WLISt:WAVeform:DELete

        #region WLISt:WAVeform:LMAXimum

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:WAVeform:LMAXimum? get the maximum sample points allowed for the waveform
        ///</summary>
        /// <returns>Max Sample Points of the waveform </returns>
        public string GetAwgWlistMaxSamplePoints()
        {
          string response;
          const string commandLine = "WLIST:WAVeform:LMAXimum?";
          _mAWGVisaSession.Query(commandLine, out response);
          return response;
        }

        #endregion WLISt:WAVeform:LMAXimum

        #region WLISt:WAVeform:LMINimum

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:WAVeform:LMINimum? get the minimum sample points allowed for the waveform
        /// </summary>
        /// <returns>Min Sample Points of the waveform </returns>
        public string GetAwgWlistMinSamplePoints()
        {
          string response;
          const string commandLine = "WLIST:WAVeform:LMINimum?";
          _mAWGVisaSession.Query(commandLine, out response);
          return response;
        }

        #endregion WLISt:WAVeform:LMINimum

        #region WLISt:WAVeform:GRANularity

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:WAVeform:GRANularity? get the required granularity for a waveform
        /// </summary>
        /// <returns>Minimum granularity for a waveform </returns>
        public string GetAwgWaveformGranularity()
        {
            string response;
            const string commandLine = "WLISt:WAVeform:GRANularity?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion WLISt:WAVeform:GRANularity

        #region WLISt:WAVeform:LENGth

        //glennj 7/25/2013
        /// <summary>
        /// Using WLIST:WAVeform:LENGth? get the length of the given waveform
        /// </summary>
        /// <param name="wfmName">Name of the waveform to get the length of</param>
        /// <returns>The length of the waveform</returns>
        public string GetAwgWListWaveformLength(string wfmName)
        {
            string response;
            string commandLine = "WLIST:WAVeform:LENGth? " + '"' + wfmName + '"';
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion WLISt:WAVeform:LENGth

        #region WLISt:WAVeform:MARKer:DATA

        //glennj 7/25/2013
        //sforell 8/9/13 added auto formatting for the block data to make it into IEEE block data format
        /// <summary>
        /// Using WLISt:WAVeform:MARKer:DATA set the waveform marker data
        /// </summary>
        public void SetAwgWaveformMarkerData(string wfmName, string startIndex, string size, string blockData)
        {
            string commandLine = "WLISt:WAVeform:MARKer:DATA " + '"' + wfmName + '"';
            if (startIndex != null)
            {
                commandLine += ',' + startIndex;
            }
            if (size != null)
            {
                commandLine += ',' + size;
            }

            // Here, we get the byte length of the string, then we get the byte length of the length value (to make it fit the IEE488.2 spec)
            int dataLength = blockData.Length;
            string tempString = dataLength.ToString();
            int tempLength = tempString.Length;
            string prefixCount = tempLength.ToString();

            // Then, we construct the prefix from those two strings and the pound sign
            string prefix = "#" + prefixCount + dataLength;

            commandLine += ',' + prefix + blockData;

            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 7/25/2013
        //sforell 8/9/13 modified the response format so it returns a more simple response rather than strange ascii characters
        /// <summary>
        /// Using WLISt:WAVeform:MARKer:DATA? get the waveform marker data
        /// </summary>
        /// <returns>Minimum granularity for a waveform </returns>
        public string GetAwgWaveformMarkerData(string wfmName, string startIndex, string size)
        {
            string commandLine = "WLISt:WAVeform:MARKer:DATA? " + '"' + wfmName + '"';
            if (startIndex != null)
            {
                commandLine += ',' + startIndex;
            }
            if (size != null)
            {
                commandLine += ',' + size;
            }

            string response;
            _mAWGVisaSession.Query(commandLine, out response);

            return UTILS.ConvertAsciiToString(response);
        }

        #endregion WLISt:WAVeform:MARKer:DATA

        #region WLISt:WAVeform:NEW

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:WAVeform:NEW create a new waveform of the given size and the given name
        /// </summary>
        /// <param name="wfmName">Name of the new waveform</param>
        /// <param name="size">Save of the new waveform</param>
        public void CreateAwgWListWaveformNew(string wfmName, string size)
        {
            string commandLine = "WLISt:WAVeform:NEW " + '"' + wfmName + '"' + ',' + size;
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion WLISt:WAVeform:NEW

        #region WLISt:WAVeform:NORMalize

        //glennj 7/25/2013
        /// <summary>
        /// Using WLIST:WAVeform:NORMalize normalizes a waveform that exists in the waveform list
        /// </summary>
        /// <param name="wfmName">Waveform to normalize</param>
        /// <param name="normType">Noramlization type</param>
        public void AwgWListWaveformNormalize(string wfmName, string normType)
        {
            string commandLine = "WLIST:WAVeform:NORMalize " + '"' + wfmName + '"' + ',' + '"' + normType + '"';
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion WLISt:WAVeform:NORMalize

        #region WLISt:WAVeform:RESAmple

        //glennj 7/25/2013
        /// <summary>
        /// Using WLIST:WAVeform:RESAmple resamples a waveform that exists in the waveform list
        /// </summary>
        /// <param name="wfmName">Waveform to normalize</param>
        /// <param name="size">Number of points to resample to</param>
        public void AwgWListWaveformResample(string wfmName, string size)
        {
            string commandLine = "WLIST:WAVeform:RESAmple " + '"' + wfmName + '"' + ',' + size ;
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion WLISt:WAVeform:RESAmple

        #region WLISt:WAVeform:SHIFt

        //glennj 7/25/2013
        //sforell 8/12/13 took away the quotes around phase - it was invalid syntax and did not actually send the command properly
        /// <summary>
        /// Using WLIST:WAVeform:SHIFt shift a waveform that exists in the waveform list
        /// </summary>
        /// <param name="wfmName">Waveform to normalize</param>
        /// <param name="phase">Number of degrees to shift</param>
        public void AwgWListWaveformShift(string wfmName, string phase)
        {
            string commandLine = "WLIST:WAVeform:SHIFt " + '"' + wfmName + '"' + ',' +  phase;
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion WLISt:WAVeform:SHIFt

        #region WLISt:WAVeform:TSTamp

        //glennj 7/25/2013
        /// <summary>
        /// Using WLIST:WAVeform:TSTamp? get the timestamp of the given waveform
        /// </summary>
        /// <param name="wfmName">Name of the waveform to get the timestamp of</param>
        /// <returns>The timestamp of the waveform</returns>
        public string GetAwgWListWaveformTimestamp(string wfmName)
        {
            string response;
            string commandLine = "WLIST:WAVeform:TSTamp? " + '"' + wfmName + '"';
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion WLISt:WAVeform:TSTamp

        #region WLISt:WAVeform:TYPE

        //glennj 7/25/2013
        /// <summary>
        /// Using WLIST:WAVeform:TYPE? get the type of the given waveform
        /// </summary>
        /// <param name="wfmName">Name of the waveform to get the type of</param>
        /// <returns>The type of the waveform (Always REAL)</returns>
        public string GetAwgWListWaveformType(string wfmName)
        {
            string response;
            string commandLine = "WLIST:WAVeform:TYPE? " + '"' + wfmName + '"';
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion WLISt:WAVeform:TYPE

        #region WLISt:WAVeform:SRATe
        //sdas2 5/28/2015
        /// <summary>
        /// Using WLIST:WAVeform:SRATe  set the sample rate of the given waveform
        /// </summary>
        /// <wfmName>Name of the waveform </wfmName>
        /// <sRate>Sample Rate set for the waveform</sRate>
        public void SetAwgSamplingRate(string wfmName, string sRate)
        {
            string commandLine = "WLISt:WAVeform:SRATe " + '"' + wfmName + '"' + ',' + sRate;
            _mAWGVisaSession.Write(commandLine);

        }
        //sdas2 5/28/2015
        /// <summary>
        /// Using WLIST:WAVeform:SRATe? Get the sample rate of the given waveform
        /// </summary>
        /// <wfmName>Name of the waveform </wfmName>
        /// <return>The sampling rate of the specific Waveform</return>  
        public string GetAwgWListWaveformSRATe(string wfmName)
        {
            string response;
            string commandLine = "WLIST:WAVeform:SRATe? " + '"' + wfmName + '"';
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion WLISt:WAVeform:SRATe

        #endregion WLIST

        #endregion Waveform
    }
}
