//==========================================================================
// AwgCapturePlaybackGroup.cs
//==========================================================================
using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains helper functions that are called from the %AWG Capture Playback PI step definitions.
    /// This class has no restrictions as to where it will be used.
    /// 
    /// This "Helper" group does everything else but steps and TekVISA.
    /// Using parameters from the step, each helper will makes decisions
    /// such as send commands, or process responses from queries and
    /// do testing and generate asserts if necessary.
    /// 
    /// \ingroup grouphelperpi pisteps 
    ///  
    /// 
    /// </summary>
    public class AwgCapturePlaybackGroup
    {

        public enum Loopsequence { On, Off }

        private const string LoopsequenceOnSyntax = "1";
        private const string LoopsequenceOffSyntax = "0";

        private readonly UTILS _utils = new UTILS();
        #region CapturePlayback
        #region CPLayback:CAPture:FILE
        //jmanning 09/22/2014
        /// <summary>
        /// Using CPLayback:CAPture:FILE imports waveform/signal from specified file to captured signal list
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="sigName">Desired signal to import to captured signal list</param>
        /// <param name="fileType">SIQ|CIQ</param>
        /// <param name="filePath1">file path which contains signal</param>
        /// <param name="filePath2">file path which contains signal</param>
        public void CapturePlaybackFile(IAWG awg, string sigName, string fileType, string filePath1, string filePath2)
        {
            awg.CapturePlaybackFile(sigName, fileType, filePath1, filePath2);
        }
        #endregion CPLayback:CAPture:FILE

        #region CPLayback:COMPile
        //jmanning 09/22/2014
        /// <summary>
        /// Using CPLayback:COMPile to resamples and upconverts selected signals to specified carrier frequency
        /// </summary>
        /// <param name="awg">specific awg object</param>
        public void CompilePlaybackFiles(IAWG awg)
        {
            awg.CompilePlaybackFiles();
        }
        #endregion CPLayback:COMPile

        #region CPLayback:CLISt:SIGNal:SCOMPile
        //jmanning 09/22/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:SCOMPile selects/deselects a signal from the captured signal list to be compiled.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="sigName">Desired signal to import to captured signal list</param>
        /// <param name="boolCompile">boolean compile select state</param>
        /// 
        public void SelectCompilePlaybackFile(IAWG awg, string sigName, bool boolCompile)
        {
            awg.SelectCompilePlaybackFile(sigName, boolCompile);
        }
        #endregion CPLayback:CLISt:SIGNal:SCOMPile

        #region CPLayback:CLISt:SIGNal:SCOMPile?
        //jmanning 09/22/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:SCOMPile selects/deselects a signal from the captured signal list to be compiled.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="sigName">Desired signal to import to captured signal list</param>
        /// <returns>Compile Select Status as a boolean</returns>
        public void GetCompileSelectStatusPlaybackFile(IAWG awg, string sigName)
        {
            awg.GetCompileSelectStatusPlaybackFile(sigName);
        }

        //jmanning 09/22/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:SCOMPile? Compares signal from the captured signal list selected/unselected compile state versus expected.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="expectedState">Select or Unselected State for Compile</param>
        public void CompileSelectStatusPlaybackFileShouldBe(IAWG awg, string expectedState)
        {
            string expectedStateValue = "0";
            if (expectedState=="selected") expectedStateValue ="1";
            string errMessage = "Received state value of " + awg.CompileSelectStatusPlaybackFile + " not expected output mode state of " + expectedState;
            Assert.AreEqual(expectedStateValue, awg.CompileSelectStatusPlaybackFile, errMessage);
        }
        #endregion CPLayback:CLISt:SIGNal:SCOMPile?

        #region CPLayback:COMPile:CFRequency
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:COMPile:CFRequency sets the carrier frequency for the compiled signals.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="freqValue">Desired carrier frequency setting in Hz</param>
        /// 
        public void SetCompileCarFrequency(IAWG awg, string freqValue)
        {
            awg.SetCompileCarFrequency(freqValue);
        }
        #endregion CPLayback:COMPile:CFRequency

        #region CPLayback:COMPile:CFRequency?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:COMPile:CFRequency? gets the carrier frequency for the compiled signals.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        public void GetCompileCarFrequency(IAWG awg)
        {
            awg.GetCompileCarFrequency();
        }

        //jmanning 09/22/2014
        /// <summary>
        /// Using CPLayback:COMPile:CFRequency? compares the carrier frequency for the compiled signals versus expected value..
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="expectedFreq">Expected Carrier Frequency</param>
        public void CompileCarrierFreqShouldBe(IAWG awg, string expectedFreq)
        {
            string errMessage = "Carrier Frequency of " + awg.CompileCarrierFrequency + " does not match expected value of " + expectedFreq;
            Assert.AreEqual(float.Parse(expectedFreq), float.Parse(awg.CompileCarrierFrequency), errMessage);
        }
        #endregion CPLayback:COMPile:CFRequency?

        #region CPLAYBACK:COMPILE:SRATE
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:COMPile:SRATE sets the output sampling rate for the compiled signals.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="sampleRate">Desired sample rate in samples/s</param>
        /// 
        public void SetCompileSampleRate(IAWG awg, string sampleRate)
        {
            awg.SetCompileSampleRate(sampleRate);
        }
        #endregion CPLAYBACK:COMPILE:SRATE

        #region CPLAYBACK:COMPILE:SRATE?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:COMPile:SRATE? gets the output sampling rate for the compiled signals.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// 
        public void GetCompileSampleRate(IAWG awg)
        {
            awg.GetCompileSampleRate();
        }

        //jmanning 09/22/2014
        /// <summary>
        /// UsingCPLayback:COMPile:SRATE compares the sample rate for the compiled signals versus expected value..
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="expectedSampRate">Expected Sample Rate</param>
        public void CompileSampleRateShouldBe(IAWG awg, string expectedSampRate)
        {
            string errMessage = "Sample Rate of " + awg.CompileSampleRate + " does not match expected value of " + expectedSampRate;
            Assert.AreEqual(float.Parse(expectedSampRate), float.Parse(awg.CompileSampleRate), errMessage);
        }
        #endregion CPLAYBACK:COMPILE:SRATE?

        #region CPLayback:COMPile:SRATe:AUTO
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:COMPile:SRATe:AUTO command sets if the system will calculate output sampling rate automatically when compiling the selected signals.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="autoCalcState">Auto calculate sample rate state</param>
        /// 
        public void SetCompileSampleRateAuto(IAWG awg, bool autoCalcState)
        {
            awg.SetCompileSampleRateAuto(autoCalcState);
        }
        #endregion CPLayback:COMPile:SRATe:AUTO

        #region CPLayback:COMPile:SRATe:AUTO?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:COMPile:SRATe:AUTO? query gets status  of if the system will calculate output sampling rate automatically when compiling the selected signals.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// 
        public void GetCompileSampleRateAuto(IAWG awg)
        {
            awg.GetCompileSampleRateAuto();
        }

        //jmanning 09/22/2014
        /// <summary>
        /// Using CPLayback:COMPile:SRATe:AUTO? Compares sample rate auto calculation state versus expected state.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="expectedState">Sample Rate Autocalculation state</param>
        public void CompileSampleRateAutoCalcStateShouldBe(IAWG awg, string expectedState)
        {
            string errMessage = "Sample Rate Auto Calculation state of " + awg.CompileSampleRateAutoState + " does not match expected state of " + expectedState;
            Assert.AreEqual(expectedState, awg.CompileSampleRateAutoState, errMessage);
        }
        #endregion CPLayback:COMPile:SRATe:AUTO?

        #region CPLayback:CLISt:NAME?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:NAME? query gets the name of a signal from the captured signal list in the position specified by the index value.  Index value is 1-based.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="listIndex">index position of signal in captured list</param>
        /// 
        public void GetCompileSignalName(IAWG awg, string listIndex)
        {
            awg.GetCompileSignalName(listIndex);
        }

        //jmanning 09/22/2014
        /// <summary>
        /// Using CPLayback:CLISt:NAME? Compares signal name from captured list with expected signal name.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="expectedName">Expected Signal Name</param>
        public void CompileSignalNameShouldBe(IAWG awg, string expectedName)
        {
            string actualName = _utils.Dequotify(awg.CompileSignalName);
            string errMessage = "Captured Signal Name of  " + actualName + " does not match expected name of " + expectedName;
            Assert.AreEqual(expectedName, actualName, errMessage);
        }
        #endregion CPLayback:CLISt:NAME?

        #region CPLayback:CLISt:SIGNal:DELete
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:DELete command removes the specified signal from the captured signal list. ALL clears the captured signal list.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="signalName">Signal name to delete. "ALL" deletes whole list</param>
        /// 
        public void DeleteCompileSignal(IAWG awg, string signalName)
        {
            awg.DeleteCompileSignal(signalName);
        }
        #endregion CPLayback:CLISt:SIGNal:DELete

        #region CPLayback:CLISt:SIZE?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIZE? query gets the Number of signals in the captured signal list.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// 
        public void GetCompileSignalsSize(IAWG awg)
        {
            awg.GetCompileSignalsSize();
        }

        //jmanning 09/22/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIZE? Compares numbers of signals from captured list with expected signal count.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="expectedCount">Expected Signal Count</param>
        public void CompileSignalCountShouldBe(IAWG awg, string expectedCount)
        {
            string errMessage = "Captured Signal count of  " + awg.CompileSignalsSize + " does not match expected count of " + expectedCount;
            Assert.AreEqual(expectedCount, awg.CompileSignalsSize, errMessage);
        }
        #endregion CPLayback:CLISt:SIZE?

        #region CPLayback:CLISt:SIGNal:OTIMe
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:OTIMe command sets the off time for the specified signal in the captured signal list.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <param name="offTime">time in seconds</param>
        /// 
        public void SetCompileSignalOffTime(IAWG awg, string signalName, string offTime)
        {
            awg.SetCompileSignalOffTime(signalName, offTime);
        }
        #endregion CPLayback:CLISt:SIGNal:OTIMe

        #region CPLayback:CLISt:SIGNal:OTIMe?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:OTIMe? query gets the off time for the specified signal in the captured signal list.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// 
        public void GetCompileSignalOffTime(IAWG awg, string signalName)
        {
            awg.GetCompileSignalOffTime(signalName);
        }


        //jmanning 09/22/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:OTIMe? Compares off time for the specified signal with expected off time period.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="expectedOffTime">Expected Off Time period</param>
        public void CompileSignalOffTimeShouldBe(IAWG awg, string expectedOffTime)
        {
            string errMessage = "Compiled Signal off time of " + awg.CompileSignalOffTime + " does not match expected time of " + expectedOffTime;
            Assert.AreEqual(float.Parse(expectedOffTime), float.Parse(awg.CompileSignalOffTime), errMessage);
        }
        #endregion CPLayback:CLISt:SIGNal:OTIMe?

        #region CPLayback:CLISt:SIGNal:WCOunt?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:WCOunt? query gets the number of waveform contained in a signal in the captured signal list.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// 
        public void GetCompileSignalWfmCount(IAWG awg, string signalName)
        {
            awg.GetCompileSignalWfmCount(signalName);
        }

        //jmanning 09/22/2014
        /// <summary>
        /// UsingCPLayback:CLISt:SIGNal:WCOunt? Compares numbers of waveforms contained in a signal from captured list with expected waveform count.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="expectedCount">Expected Waveform Count</param>
        public void CompileSignalWfmCountShouldBe(IAWG awg, string expectedCount)
        {
            string errMessage = "Captured Signal waveform count of  " + awg.CompileSignalWfmCount + " does not match expected count of " + expectedCount;
            Assert.AreEqual(expectedCount, awg.CompileSignalWfmCount, errMessage);
        }
        #endregion CPLayback:CLISt:SIGNal:WCOunt?

        #region CPLayback:CLISt:SIGNal:WAVeform:NAME?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:WAVeform:NAME? query gets the name of a waveform segment of a signal in the captured signal list.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <param name="wfmIndex">index of segment|waveform in specified signal</param>
        /// 
        public void GetCompileSignalWfmName(IAWG awg, string signalName, string wfmIndex)
        {
            awg.GetCompileSignalWfmName(signalName, wfmIndex);
        }

        //jmanning 09/22/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:WAVeform:NAME? Compares name of waveform in a signal from captured list with expected waveform name.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="expectedName">Expected Waveform Name</param>
        public void CompileSignalWfmNameShouldBe(IAWG awg, string expectedName)
        {
            string actualName = _utils.Dequotify(awg.CompileSignalWfmName);
            string errMessage = "Captured signal waveform name of  " + actualName + " does not match expected name of " + expectedName;
            Assert.AreEqual(expectedName, actualName, errMessage);
        }
        #endregion CPLayback:CLISt:SIGNal:WAVeform:NAME?

        #region CPLayback:CLISt:SIGNal:WAVeform:FOFFset
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:WAVeform:FOFFset sets the frequency offset of a waveform segment of a signal in the captured signal list.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <param name="wfmIndex">index of segment|waveform in specified signal</param>
        /// <param name="freqValue">Desired frequency offset setting in Hz</param>
        /// 
        public void SetCompileWfmFreqOffset(IAWG awg, string signalName, string wfmIndex, string freqValue)
        {
            awg.SetCompileWfmFreqOffset(signalName, wfmIndex, freqValue);
        }
        #endregion CPLayback:CLISt:SIGNal:WAVeform:FOFFset

        #region CPLayback:CLISt:SIGNal:WAVeform:FOFFset?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:WAVeform:FOFFset? gets the frequency offset value of a waveform segment fro specified signal in the captured signal list.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <param name="wfmIndex">index of segment|waveform in specified signal</param>
        /// 
        public void GetCompileWfmFreqOffset(IAWG awg, string signalName, string wfmIndex)
        {
            awg.GetCompileWfmFreqOffset(signalName, wfmIndex);
        }

        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:WAVeform:FOFFset? Compares freq offset value for the specified waveform with expected frequency offset.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="expectedFreqOffset">Expected frequency offset</param>
        public void CompileWfmFreqOffsetShouldBe(IAWG awg, string expectedFreqOffset)
        {
            string errMessage = "Compiled Waveform frequency offset of " + awg.CompileWfmFreqOffset + " does not match expected time of " + expectedFreqOffset;
            Assert.AreEqual(float.Parse(expectedFreqOffset), float.Parse(awg.CompileWfmFreqOffset), errMessage);
        }
        #endregion CPLayback:CLISt:SIGNal:WAVeform:FOFFset?

        #region CPLayback:CLISt:SIGNal:WAVeform:SRATe
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:WAVeform:SRATe sets the sample rate of a waveform segment of a signal in the captured signal list.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <param name="wfmIndex">index of segment|waveform in specified signal</param>
        /// <param name="sampleRate">Desired sample rate in samples/s</param>
        /// 
        public void SetCompileWfmSampleRate(IAWG awg, string signalName, string wfmIndex, string sampleRate)
        {
            awg.SetCompileWfmSampleRate(signalName, wfmIndex, sampleRate);
        }
        #endregion CPLayback:CLISt:SIGNal:WAVeform:SRATe

        #region CPLayback:CLISt:SIGNal:WAVeform:SRATe?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:WAVeform:SRATe? gets the sample rate value of a waveform segment for specified signal in the captured signal list.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <param name="wfmIndex">index of segment|waveform in specified signal</param>
        /// 
        public void GetCompileWfmSampleRate(IAWG awg, string signalName, string wfmIndex)
        {
            awg.GetCompileWfmSampleRate(signalName, wfmIndex);
        }

        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:WAVeform:SRATe? Compares sample rate for the specified waveform with expected sample rate value.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="expectedSampleRate">Expected sample rate</param>
        public void CompileWfmSampleRateShouldBe(IAWG awg, string expectedSampleRate)
        {
            string errMessage = "Compiled Waveform sample rate of " + awg.CompileWfmSampleRate + " does not match expected time of " + expectedSampleRate;
            Assert.AreEqual(float.Parse(expectedSampleRate), float.Parse(awg.CompileWfmSampleRate), errMessage);
        }
        #endregion CPLayback:CLISt:SIGNal:WAVeform:SRATe?
        #endregion CapturePlayback   


        #region CPLAYBACK:COMPILE:LSEQuence

        //keerthi 05/29/2015
        /// <summary>
        /// Using CPLAYBACK:COMPILE:LSEQuence sets the Loop sequnece ON/OFF
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="loopsequence">Loop sequence to be ON/</param>
        /// 

        public void SelectLoopSequence(IAWG awg, Loopsequence loopsequence)
        {
            string setValue = loopsequence == Loopsequence.On ? LoopsequenceOnSyntax : LoopsequenceOffSyntax;
            awg.SelectLoopSequence(setValue);

        }
        #endregion CPLAYBACK:COMPILE:LSEQuence

        #region CPLAYBACK:COMPILE:LSEQuence?

        //keerthi 05/29/2015
        /// <summary>
        /// Using CPLAYBACK:COMPILE:LSEQuence? Gets the Loop sequnece is ON/OFF
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// 
        public void GetLoopSequence(IAWG awg)
        {
            awg.GetLoopSequence();
        }

        //keerthi 05/29/2015
        /// <summary>
        /// Using CPLAYBACK:COMPILE:LSEQuence? Gets the Loop sequnece is ON/OFF
        /// compares with expected result with the actual result 
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="expectedLoopSequence">Desired carrier frequency setting in Hz</param>
        /// 

        public void LoopSequenceShouldBe(string expectedLoopSequence, IAWG awg)
        {
            // awg.Loopsequenceshouldbe(Expectedloopsequence);
            Assert.AreEqual(expectedLoopSequence, awg.LoopSequenceQueried);
        }

        #endregion CPLAYBACK:COMPILE:LSEQuence?



   }
 }