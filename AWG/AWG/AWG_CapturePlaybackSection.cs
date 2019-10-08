using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable CheckNamespace
namespace AwgTestFramework
// ReSharper restore CheckNamespace
{

    public partial class AWG
    {
        #region CapturePlayback

        /// <summary>
        /// Property to contain the response from CPLayback:CLISt:SIGNal:SCOMPile?
        /// </summary>
        public string CompileSelectStatusPlaybackFile { get; set; }

        /// <summary>
        /// Property to contain the response from CPLayback:COMPile:CFRequency?
        /// </summary>
        public string CompileCarrierFrequency { get; set; }

        /// <summary>
        /// Property to contain the response from CPLayback:COMPile:SRATE?
        /// </summary>
        public string CompileSampleRate { get; set; }

        /// <summary>
        /// Property to contain the response from CPLayback:COMPile:SRATe:AUTO?
        /// </summary>
        public string CompileSampleRateAutoState { get; set; }

        /// <summary>
        /// Property to contain the response from CPLayback:CLISt:NAME?
        /// </summary>
        public string CompileSignalName { get; set; }

        /// <summary>
        /// Property to contain the response from CPLayback:CLISt:SIZE?
        /// </summary>
        public string CompileSignalsSize { get; set; }
        
        /// <summary>
        /// Property to contain the response from CPLayback:CLISt:SIGNal:OTIMe?
        /// </summary>
        public string CompileSignalOffTime { get; set; }

        /// <summary>
        /// Property to contain the response from CPLayback:CLISt:SIGNal:WCOunt?
        /// </summary>
        public string CompileSignalWfmCount { get; set; }

        /// <summary>
        /// Property to contain the response from CPLayback:CLISt:SIGNal:WAVeform:NAME?
        /// </summary>
        public string CompileSignalWfmName { get; set; }
        
        /// <summary>
        /// Property to contain the response from CCPLayback:CLISt:SIGNal:WAVeform:FOFFset?
        /// </summary>
        public string CompileWfmFreqOffset { get; set; }

        /// <summary>
        /// Property to contain the response from CPLayback:CLISt:SIGNal:WAVeform:SRATe?
        /// </summary>
        public string CompileWfmSampleRate { get; set; }

        /// <summary>
        /// Property to contain the response from CPLAYBACK:COMPILE:LSEQuence?
        /// </summary>

        public string LoopSequenceQueried { get; set; }

        #region CPLayback:CAPture:FILE
        //jmanning 09/22/2014
        /// <summary>
        /// Using CPLayback:CAPture:FILE imports waveform/signal from specified file to captured signal list
        /// </summary>
        /// <param name="sigName">Desired signal to import to captured signal list</param>
        /// <param name="fileType">SIQ|CIQ</param>
        /// <param name="filePath1">file path which contains signal</param>
        /// <param name="filePath2">file path which contains signal</param>

        public void CapturePlaybackFile(string sigName, string fileType, string filePath1, string filePath2)
        {
            _pi.AwgCapturePlaybackFile(sigName, fileType, filePath1, filePath2);
        }
        #endregion CPLayback:CAPture:FILE

        #region CPLayback:COMPile
        //jmanning 09/22/2014
        /// <summary>
        /// Using CPLayback:COMPile to resamples and upconverts selected signals to specified carrier frequency
        /// </summary>
        public void CompilePlaybackFiles()
        {
            _pi.AwgCompilePlaybackFiles();
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
        public void SelectCompilePlaybackFile(string sigName, bool boolCompile)
        {
            _pi.SelectAwgCompilePlaybackFile(sigName, boolCompile);
        }
        #endregion CPLayback:CLISt:SIGNal:SCOMPile

        #region CPLayback:CLISt:SIGNal:SCOMPile?        
        //jmanning 09/22/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:SCOMPile selects/deselects a signal from the captured signal list to be compiled.
        /// </summary>
        /// <param name="sigName">Desired signal to import to captured signal list</param>
        /// <returns>Compile Select Status as a boolean</returns>
        public void GetCompileSelectStatusPlaybackFile(string sigName)
        {
            CompileSelectStatusPlaybackFile = _pi.GetCompileSelectStatusPlaybackFile(sigName);
        }
        #endregion CPLayback:CLISt:SIGNal:SCOMPile?

        #region CPLayback:COMPile:CFRequency
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:COMPile:CFRequency sets the carrier frequency for the compiled signals.
        /// </summary>
        /// <param name="freqValue">Desired carrier frequency setting in Hz</param>
        /// 
        public void SetCompileCarFrequency(string freqValue)
        {
            _pi.SetAwgCompileCarFrequency(freqValue);
        }
        #endregion CPLayback:COMPile:CFRequency

        #region CPLayback:COMPile:CFRequency?        
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:COMPile:CFRequency? gets the carrier frequency for the compiled signals.
        /// </summary>
        public void GetCompileCarFrequency()
        {
            CompileCarrierFrequency = _pi.GetAwgCompileCarFrequency();
        }
        #endregion CPLayback:COMPile:CFRequency?

        #region CPLAYBACK:COMPILE:SRATE
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:COMPile:SRATE sets the output sampling rate for the compiled signals.
        /// </summary>
        /// <param name="sampleRate">Desired sample rate in samples/s</param>
        /// 
        public void SetCompileSampleRate(string sampleRate)
        {
            _pi.SetAwgCompileSampleRate(sampleRate);
        }
        #endregion CPLAYBACK:COMPILE:SRATE

        #region CPLAYBACK:COMPILE:SRATE?        
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:COMPile:SRATE? gets the output sampling rate for the compiled signals.
        /// </summary>
        /// <returns>Desired sample rate in samples/s</returns>
        /// 
        public void GetCompileSampleRate()
        {
            CompileSampleRate = _pi.GetAwgCompileSampleRate();
        }
        #endregion CPLAYBACK:COMPILE:SRATE?

        #region CPLayback:COMPile:SRATe:AUTO
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:COMPile:SRATe:AUTO command sets if the system will calculate output sampling rate automatically when compiling the selected signals.
        /// </summary>
        /// <param name="autoCalcState">Auto calculate sampe rate state</param>
        /// 
        public void SetCompileSampleRateAuto(bool autoCalcState)
        {
            _pi.SetAwgCompileSampleRateAuto(autoCalcState);
        }
        #endregion CPLayback:COMPile:SRATe:AUTO

        #region CPLayback:COMPile:SRATe:AUTO?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:COMPile:SRATe:AUTO? query gets status  of if the system will calculate output sampling rate automatically when compiling the selected signals.
        /// </summary>
        /// <return>Auto calculate sampe rate state</return>
        /// 
        public void GetCompileSampleRateAuto()
        {
            CompileSampleRateAutoState = _pi.GetAwgCompileSampleRateAuto();
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
        public void GetCompileSignalName(string listIndex)
        {
            CompileSignalName = _pi.GetAwgCompileSignalName(listIndex);
        }
        #endregion CPLayback:CLISt:NAME?

        #region CPLayback:CLISt:SIGNal:DELete
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:DELete command removes the specified signal from the captured signal list. ALL clears the captured signal list.
        /// </summary>
        /// <param name="signalName">Signal name to delete. "ALL" deletes whole list</param>
        /// 
        public void DeleteCompileSignal(string signalName)
        {
            _pi.DeleteAwgCompileSignal(signalName);
        }
        #endregion CPLayback:CLISt:SIGNal:DELete

        #region CPLayback:CLISt:SIZE?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIZE? query gets the Number of signals in the captured signal list.
        /// </summary>
        /// <return>Number of signals in the captured signal list</return>
        /// 
        public void GetCompileSignalsSize()
        {
            CompileSignalsSize = _pi.GetAwgCompileSignalsSize();
        }
        #endregion CPLayback:CLISt:SIZE?

        #region CPLayback:CLISt:SIGNal:OTIMe
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:OTIMe command sets the off time for the specified signal in the captured signal list.
        /// </summary>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <param name="offTime">time in seconds</param>
        /// 
        public void SetCompileSignalOffTime(string signalName, string offTime)
        {
            _pi.SetAwgCompileSignalOffTime(signalName, offTime);
        }
        #endregion CPLayback:CLISt:SIGNal:OTIMe

        #region CPLayback:CLISt:SIGNal:OTIMe?        
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:OTIMe? query gets the off time for the specified signal in the captured signal list.
        /// </summary>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <returns> off time in seconds</returns>
        /// 
        public void GetCompileSignalOffTime(string signalName)
        {
            CompileSignalOffTime = _pi.GetAwgCompileSignalOffTime(signalName);
        }
        #endregion CPLayback:CLISt:SIGNal:OTIMe?

        #region CPLayback:CLISt:SIGNal:WCOunt?        
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:WCOunt? query gets the number of waveform contained in a signal in the captured signal list.
        /// </summary>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <returns> the number of waveform contained in specified signal</returns>
        /// 
        public void GetCompileSignalWfmCount(string signalName)
        {
            CompileSignalWfmCount = _pi.GetAwgCompileSignalWfmCount(signalName);
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
        public void GetCompileSignalWfmName(string signalName, string wfmIndex)
        {
            CompileSignalWfmName = _pi.GetAwgCompileSignalWfmName(signalName, wfmIndex);
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
        public void SetCompileWfmFreqOffset(string signalName, string wfmIndex, string freqValue)
        {
            _pi.SetAwgCompileWfmFreqOffset(signalName, wfmIndex, freqValue);
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
        public void GetCompileWfmFreqOffset(string signalName, string wfmIndex)
        {
            CompileWfmFreqOffset = _pi.GetAwgCompileWfmFreqOffset(signalName, wfmIndex);
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
        public void SetCompileWfmSampleRate(string signalName, string wfmIndex, string sampleRate)
        {
            _pi.SetAwgCompileWfmSampleRate(signalName, wfmIndex, sampleRate);
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
        public void GetCompileWfmSampleRate(string signalName, string wfmIndex)
        {
            CompileWfmSampleRate = _pi.GetAwgCompileWfmSampleRate(signalName, wfmIndex);
        }
        #endregion CPLayback:CLISt:SIGNal:WAVeform:SRATe?

        #region CPLAYBACK:COMPILE:LSEQuence

        //keerthi 05/29/2015
        /// <summary>
        /// Using CPLAYBACK:COMPILE:LSEQuence, sets the Loop sequnece ON/OFF
        /// </summary>
        /// <param name="setValue">sets CPLAYBACK:COMPILE:LSEQuence to ON/OFF </param>
       
        public void SelectLoopSequence(string setValue)
        {
            _pi.SelectLoopSequence(setValue);

        }

        #endregion CPLAYBACK:COMPILE:LSEQuence

        #region CPLAYBACK:COMPILE:LSEQuence?

        //keerthi 05/29/2015
        /// <summary>
        /// Using CPLAYBACK:COMPILE:LSEQuence? gets the Loop sequnece is ON/OFF
        /// </summary>
        

        public void GetLoopSequence()
        {
            LoopSequenceQueried = _pi.GetLoopSequence();

        }

        #endregion CPLAYBACK:COMPILE:LSEQuence?

        #endregion CapturePlayback

       
    }
}
