
namespace AwgTestFramework
{
    public partial class CPi70KCmds
    {
        #region CapturePlayback

        #region CPLayback:CAPture:FILE 
        //jmanning 09/22/2014
        /// <summary>
        /// Using CPLayback:CAPture:FILE imports waveform/signal from specified file to captured signal list
        /// </summary>
        /// <param name="sigName">Desired signal to import to captured signal list</param>
        /// <param name="fileType">SIQ|CIQ</param>
        /// <param name="filePath1">file path which contains signal</param>
        /// <param name="filePath2">file path which contains signal</param>

        public void AwgCapturePlaybackFile (string sigName, string fileType, string filePath1, string filePath2)
        {
            var commandLine ="";
            if (fileType=="CIQ")
                commandLine = "CPLayback:CAPture:FILE " + '"' + sigName + '"' + ',' + fileType + ',' + '"' + filePath1 + '"';
            else
                commandLine = "CPLayback:CAPture:FILE " + '"' + sigName + '"' + ',' + fileType + ',' + '"' + filePath1 + '"' + ',' + '"' + filePath2 + '"';
            _mAWGVisaSession.Write(commandLine);
        }
        #endregion CPLayback:CAPture:FILE 
        
        #region CPLayback:COMPile
        //jmanning 09/22/2014
        /// <summary>
        /// Using CPLayback:COMPile to resamples and upconverts selected signals to specified carrier frequency
        /// </summary>
        public void AwgCompilePlaybackFiles()
        {
            var commandLine = "CPLayback:COMPile";
            _mAWGVisaSession.Write(commandLine);
        }
        #endregion CPLayback:COMPile

        #region CPLayback:CLISt:SIGNal:SCOMPile
        //jmanning 09/22/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:SCOMPile selects/deselects a signal from the captured signal list to be compiled.
        /// </summary>
        /// <param name="sigName">Desired signal to import to captured signal list</param>
        /// <param name="boolCompile">boolean compile select state</param>
        /// 
        public void SelectAwgCompilePlaybackFile(string sigName, bool boolCompile)
        {
            string state = "OFF";
            if (boolCompile) state = "ON";
            var commandLine = "CPLayback:CLISt:SIGNal:SCOMPile "+ '"' + sigName + '"' + ',' + state;
            _mAWGVisaSession.Write(commandLine);
        }
        #endregion CPLayback:CLISt:SIGNal:SCOMPile

        #region CPLayback:CLISt:SIGNal:SCOMPile?
        //jmanning 09/22/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:SCOMPile selects/deselects a signal from the captured signal list to be compiled.
        /// </summary>
        /// <param name="sigName">Desired signal to import to captured signal list</param>
        /// <returns>Compile Select Status as a boolean</returns>
        public string GetCompileSelectStatusPlaybackFile(string sigName)
        {
            string response;
            var commandLine = "CPLayback:CLISt:SIGNal:SCOMpile? " + '"' + sigName + '"';
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion CPLayback:CLISt:SIGNal:SCOMPile?

        #region CPLayback:COMPile:CFRequency
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:COMPile:CFRequency sets the carrier frequency for the compiled signals.
        /// </summary>
        /// <param name="freqValue">Desired carrier frequency setting in Hz</param>
        /// 
        public void SetAwgCompileCarFrequency(string freqValue)
        {
            var commandLine = "CPLayback:COMPile:CFRequency " + freqValue;
            _mAWGVisaSession.Write(commandLine);
        }
        #endregion CPLayback:COMPile:CFRequency
        
        #region CPLayback:COMPile:CFRequency?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:COMPile:CFRequency? gets the carrier frequency for the compiled signals.
        /// </summary>
        public string GetAwgCompileCarFrequency()
        {
            string response;
            const string commandLine = "CPLayback:COMPile:CFRequency?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion CPLayback:COMPile:CFRequency?

        #region CPLAYBACK:COMPILE:SRATE
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:COMPile:SRATE sets the output sampling rate for the compiled signals.
        /// </summary>
        /// <param name="sampleRate">Desired sample rate in samples/s</param>
        /// 
        public void SetAwgCompileSampleRate(string sampleRate)
        {
            var commandLine = "CPLayback:COMPile:SRATe " + sampleRate;
            _mAWGVisaSession.Write(commandLine);
        }
        #endregion CPLAYBACK:COMPILE:SRATE

        #region CPLAYBACK:COMPILE:SRATE?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:COMPile:SRATE? gets the output sampling rate for the compiled signals.
        /// </summary>
        /// <returns>Desired sample rate in samples/s</returns>
        /// 
        public string GetAwgCompileSampleRate()
        {
            string response;
            const string commandLine = "CPLayback:COMPile:SRATe?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion CPLAYBACK:COMPILE:SRATE?

        #region CPLayback:COMPile:SRATe:AUTO
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:COMPile:SRATe:AUTO command sets if the system will calculate output sampling rate automatically when compiling the selected signals.
        /// </summary>
        /// <param name="autoCalcState">Auto calculate sampe rate state</param>
        /// 
        public void SetAwgCompileSampleRateAuto(bool autoCalcState)
        {
            string stateName = "OFF";
            if (autoCalcState) stateName = "ON";
            var commandLine = "CPLayback:COMPile:SRATe:AUTO " + stateName;
            _mAWGVisaSession.Write(commandLine);
        }
        #endregion CPLayback:COMPile:SRATe:AUTO

        #region CPLayback:COMPile:SRATe:AUTO?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:COMPile:SRATe:AUTO? query gets status  of if the system will calculate output sampling rate automatically when compiling the selected signals.
        /// </summary>
        /// <return>Auto calculate sampe rate state</return>
        /// 
        public string GetAwgCompileSampleRateAuto()
        {
            string response;
            const string commandLine = "CPLayback:COMPile:SRATe:AUTO?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion CPLayback:COMPile:SRATe:AUTO?

        #region CPLayback:CLISt:NAME?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:NAME? query gets the name of a signal from the captured signal list in the position specified by the index value.  Index value is 1-based.
        /// </summary>
        /// <param name="listIndex">index position of signal in captured list</param>
        /// <return>Signal name from the captured signal list at index specified</return>
        /// 
        public string GetAwgCompileSignalName(string listIndex)
        {
            string response;
            string commandLine = "CPLayback:CLISt:NAME? " + listIndex;
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion CPLayback:CLISt:NAME?
        
        #region CPLayback:CLISt:SIGNal:DELete
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:DELete command removes the specified signal from the captured signal list. ALL clears the captured signal list.
        /// </summary>
        /// <param name="signalName">Signal name to delete. "ALL" deletes whole list</param>
        /// 
        public void DeleteAwgCompileSignal(string signalName)
        {
            var commandLine = "";
            if(signalName=="ALL")
                commandLine = "CPLayback:CLISt:SIGNal:DELete ALL";
            else
                commandLine = "CPLayback:CLISt:SIGNal:DELete " + '"'+ signalName + '"';
            _mAWGVisaSession.Write(commandLine);
        }
        #endregion CPLayback:CLISt:SIGNal:DELete

        #region CPLayback:CLISt:SIZE?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIZE? query gets the Number of signals in the captured signal list.
        /// </summary>
        /// <return>Number of signals in the captured signal list</return>
        /// 
        public string GetAwgCompileSignalsSize()
        {
            string response;
            const string commandLine = "CPLayback:CLISt:SIZE? ";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion CPLayback:CLISt:SIZE?

        #region CPLayback:CLISt:SIGNal:WAVeform:OTIMe
        //shkv 11/19/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:WAVeform:OTIMe command sets the off time for the specified signal in the captured signal list.
        /// </summary>
        /// Modified the code as per the new requirement change for the PI Command
        /// <param name="offTime">time in seconds</param>
        /// 
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:OTIMe command sets the off time for the specified signal in the captured signal list.
        /// </summary>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <param name="offTime">time in seconds</param>
        /// 
        public void SetAwgCompileSignalOffTime(string signalName, string offTime)
        {
            var commandLine = "CPLayback:CLISt:SIGNal:WAVeform:OTIMe " + '"' + signalName + '"' + "," + 1 + "," + offTime;
            _mAWGVisaSession.Write(commandLine);
        }
        #endregion CPLayback:CLISt:SIGNal:WAVeform:OTIMe

        #region CPLayback:CLISt:SIGNal:WAVeform:OTIMe?
        //shkv 11/19/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:WAVeform:OTIMe command sets the off time for the specified signal in the captured signal list.
        /// </summary>
        /// Modified the code as per the new requirement change for the PI Command
        /// <param name="offTime">time in seconds</param>
        /// 
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:OTIMe? query gets the off time for the specified signal in the captured signal list.
        /// </summary>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <returns> off time in seconds</returns>
        /// 
        public string GetAwgCompileSignalOffTime(string signalName)
        {
            string response;
            var commandLine = "CPLayback:CLISt:SIGNal:WAVeform:OTIMe? " + '"' + signalName + '"' + "," + 1;
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion CPLayback:CLISt:SIGNal:WAVeform:OTIMe?

        #region CPLayback:CLISt:SIGNal:WCOunt?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:WCOunt? query gets the number of waveform contained in a signal in the captured signal list.
        /// </summary>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <returns> the number of waveform contained in specified signal</returns>
        /// 
        public string GetAwgCompileSignalWfmCount(string signalName)
        {
            string response;
            var commandLine = "CPLayback:CLISt:SIGNal:WCOunt? " + '"' + signalName + '"';
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion CPLayback:CLISt:SIGNal:WCOunt?

        #region CPLayback:CLISt:SIGNal:WAVeform:NAME?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:WAVeform:NAME? query gets the name of a waveform segment of a signal in the captured signal list.
        /// </summary>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <param name="wfmIndex">index of segment|waveform in specified signal</param>
        /// <returns> the name of waveform contained in specified signal's index</returns>
        /// 
        public string GetAwgCompileSignalWfmName(string signalName, string wfmIndex)
        {
            string response;
            var commandLine = "CPLayback:CLISt:SIGNal:WAVeform:NAME? " + '"' + signalName + '"' + "," + wfmIndex;
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion CPLayback:CLISt:SIGNal:WAVeform:NAME?

        #region CPLayback:CLISt:SIGNal:WAVeform:FOFFset
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:WAVeform:FOFFset sets the frequency offset of a waveform segment of a signal in the captured signal list.
        /// </summary>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <param name="wfmIndex">index of segment|waveform in specified signal</param>
        /// <param name="freqValue">Desired frequency offset setting in Hz</param>
        /// 
        public void SetAwgCompileWfmFreqOffset(string signalName, string wfmIndex, string freqValue)
        {
            var commandLine = "CPLayback:CLISt:SIGNal:WAVeform:FOFFset " + '"' + signalName + '"' + "," + wfmIndex + "," + freqValue;
            _mAWGVisaSession.Write(commandLine);
        }
        #endregion CPLayback:CLISt:SIGNal:WAVeform:FOFFset
        
        #region CPLayback:CLISt:[SIGNal:]WAVeform:FOFFset?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:WAVeform:FOFFset? gets the frequency offset value of a waveform segment fro specified signal in the captured signal list.
        /// </summary>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <param name="wfmIndex">index of segment|waveform in specified signal</param>
        /// <returns>Specified waveform frequency offset value</returns>
        /// 
        public string GetAwgCompileWfmFreqOffset(string signalName, string wfmIndex)
        {
            string response;
            var commandLine = "CPLayback:CLISt:SIGNal:WAVeform:FOFFset? " + '"' + signalName + '"' + "," + wfmIndex;
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion CPLayback:CLISt:[SIGNal:]WAVeform:FOFFset?
        
        #region CPLayback:CLISt:[SIGNal:]WAVeform:SRATe
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:WAVeform:SRATe sets the sample rate of a waveform segment of a signal in the captured signal list.
        /// </summary>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <param name="wfmIndex">index of segment|waveform in specified signal</param>
        /// <param name="sampleRate">Desired sample rate in samples/s</param>
        /// 
        public void SetAwgCompileWfmSampleRate(string signalName, string wfmIndex, string sampleRate)
        {
            var commandLine = "CPLayback:CLISt:SIGNal:WAVeform:SRATe " + '"' + signalName + '"' + "," + wfmIndex + "," + sampleRate;
            _mAWGVisaSession.Write(commandLine);
        }
        #endregion CPLayback:CLISt:SIGNal:WAVeform:SRATe
        
        #region CPLayback:CLISt:SIGNal:WAVeform:SRATe?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:WAVeform:SRATe? gets the sample rate value of a waveform segment for specified signal in the captured signal list.
        /// </summary>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <param name="wfmIndex">index of segment|waveform in specified signal</param>
        /// <returns>Specified waveform sample rate value</returns>
        /// 
        public string GetAwgCompileWfmSampleRate(string signalName, string wfmIndex)
        {
            string response;
            var commandLine = "CPLayback:CLISt:SIGNal:WAVeform:SRATe? " + '"' + signalName + '"' + "," + wfmIndex;
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion CPLayback:CLISt:SIGNal:WAVeform:SRATe?       

        #region CPLAYBACK:COMPILE:LSEQuence

        //keerthi 05/29/2015
        /// <summary>
        /// Using CPLAYBACK:COMPILE:LSEQuence sets the Loop sequnece to ON/OFF
        /// </summary>
        /// <param name="setValue">sets CPLAYBACK:COMPILE:LSEQuence to ON/OFF </param>

        public void SelectLoopSequence(string setValue)
        {

            var command = "CPLAYBACK:COMPILE:LSEQuence " + setValue;
            _mAWGVisaSession.Write(command);

        }

        #endregion CPLAYBACK:COMPILE:LSEQuence

        #region CPLAYBACK:COMPILE:LSEQuence?

        //keerthi 05/29/2015
        /// <summary>
        /// Using CPLAYBACK:COMPILE:LSEQuence? gets whether the Loop sequnece is ON/OFF
        /// </summary>
       

        public string GetLoopSequence()
        {
            string response;
            const string commandLine = "CPLAYBACK:COMPILE:LSEQuence?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;


        }

        #endregion CPLAYBACK:COMPILE:LSEQuence?

        #endregion CapturePlayback
    }
}