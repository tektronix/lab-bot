//==========================================================================
// AwgCapturePlaybackGroup_steps.cs
// This file contains the low-order PI step definitions for the AWG PI Capture Playback Group commands. 
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
// AWG number -  AWG([1-4])? -OR -
//            -  (?: the)? AWG([1-4])? (depends on language usage)
// File path strings - ""(.+)"" used when you want the string that is delimited by the quotes File path strings
//                         
//==========================================================================
using TechTalk.SpecFlow;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains the PI step definitions for the %AWG PI Calibration Group commands.

    /// Generally the steps are set, get and should be operations.  The step sole responsibility
    /// is to make sure the correct %AWG object is used and that parameters such as channel,
    /// markers and clock references are correct for the %AWG object.
    /// 
    /// \ingroup highpi pisteps 
    /// 
    /// </summary> 
    [Binding] //Very important! This entry needs to be made in each step definition file.
    public class AwgCapturePlaybackSteps
    {
        private readonly AwgCapturePlaybackGroup _awgCapturePlaybackGroup = new AwgCapturePlaybackGroup();
        private readonly UTILS.Converter _converter = new UTILS.Converter();
        private readonly UtilitiesGroup _utilitiesGroup = new UtilitiesGroup();
        
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
        /// <param name="awgNumber"></param>
        [When(@"I import the baseband IQ waveform ""(.+)"" to the signal ""(.+)"" in the captured list for AWG ([1-4])")]
        public void CaptureCIQPlaybackFile(string filePath1, string sigName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.CapturePlaybackFile(awg, sigName, "CIQ", filePath1, "");
        }
        [When(@"I import the separate baseband I waveform ""(.+)"" and Q waveform ""(.+)"" to the signal ""(.+)"" in the captured list for AWG ([1-4])")]
        public void CaptureSIQPlaybackFile(string filePath1, string filePath2, string sigName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.CapturePlaybackFile(awg, sigName, "SIQ", filePath1, filePath2);
        }
        #endregion CPLayback:CAPture:FILE

        #region CPLayback:COMPile
        /// <summary>
        ///  Using CPLayback:COMPile to resamples and upconverts selected signals to specified carrier frequency
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \captureplayback\verbatim
        When(@"I compile the selected signals from the captured signal list for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I compile the selected signals from the captured signal list for AWG ([1-4])")]
        public void CompilePlaybackFiles(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.CompilePlaybackFiles(awg);
        }
        #endregion CPLayback:COMPile

        #region CPLayback:CLISt:SIGNal:SCOMPile
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:SCOMPile selects/deselects a signal from the captured signal list to be compiled.
        /// </summary>
        /// <param name="sigName">Desired signal to import to captured signal list</param>
        /// <param name="awgNumber"></param>
        /*!
            \captureplayback\verbatim
        [When(@"I select to compile the signal ""(.+)"" from the captured signal list for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I select to compile the signal ""(.+)"" from the captured signal list for AWG ([1-4])")]
        public void SetCompileSignalSelected(string signalName, string awgNumber)
        {
            bool select = true;
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.SelectCompilePlaybackFile(awg, signalName, select);
        }
        /*
            \captureplayback\verbatim
        [When(@"I deselect to compile the signal ""(.+)"" from the captured signal list for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I deselect to compile the signal ""(.+)"" from the captured signal list for AWG ([1-4])")]
        public void SetCompileSignalNotSelected(string signalName, string awgNumber)
        {
            bool deselect = false;
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.SelectCompilePlaybackFile(awg, signalName, deselect);
        }
        #endregion CPLayback:CLISt:SIGNal:SCOMPile

        #region CPLayback:CLISt:SIGNal:SCOMPile?
        //jmanning 09/22/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:SCOMPile? gets whether a signal is selected/deselected from the captured signal list to be compiled.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="sigName">Desired signal to import to captured signal list</param>
        /*
            \captureplayback\verbatim
        When(@"I compile the selected signals from the captured signal list for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get select to compile status for the signal ""(.+)"" from the captured signal list for AWG ([1-4])")]
        public void SetCompileSignalSelectedState(string signalName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.GetCompileSelectStatusPlaybackFile(awg, signalName);
        }

        /*
            \captureplayback\verbatim
        When(@"I compile the selected signals from the captured signal list for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the compile select status should be marked selected for the signal from the captured signal list for AWG ([1-4])")]
        public void TheCompileSignalSelectedStateShouldbeSelected(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.CompileSelectStatusPlaybackFileShouldBe(awg, "selected");
        }

        /*
            \captureplayback\verbatim
        When(@"I compile the selected signals from the captured signal list for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the compile select status should be marked not selected for the signal from the captured signal list for AWG ([1-4])")]
        public void TheCompileSignalSelectedStateShouldbeNotSelected(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.CompileSelectStatusPlaybackFileShouldBe(awg, "not selected");
        }
        #endregion CPLayback:CLISt:SIGNal:SCOMPile?


        #region CPLAYBACK:COMPILE:LSEQuence

        //keerthi 05/29/2015
        /// <summary>
        /// Selects the loop sequence in capture palyback
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \Capture playback\verbatim
        [When(@"I select the capture and playback loop sequence for AWG ([1-4])")]
            \endverbatim 
        */

        [When(@"I select the capture and playback loop sequence for AWG ([1-4])")]
        public void SelectTheCaptureAndPlaybackLoopSequence(string awgNumber)
        {
           
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.SelectLoopSequence(awg, AwgCapturePlaybackGroup.Loopsequence.On);
        }


        //keerthi 05/29/2015
        /// <summary>
        /// Deselects the loop sequence in capture palyback
        ///  </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \Capture playback\verbatim
          [When(@"I deselect the capture and playback loop sequence for AWG ([1-4])")]
            \endverbatim 
        */

        [When(@"I deselect the capture and playback loop sequence for AWG ([1-4])")]
        public void DeselectTheCaptureAndPlaybackLoopSequence(string awgNumber)
        {
         
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.SelectLoopSequence(awg, AwgCapturePlaybackGroup.Loopsequence.Off);

        }

        #endregion CPLAYBACK:COMPILE:LSEQuence

        #region CPLAYBACK:COMPILE:LSEQuence?
        //keerthi 05/29/2015
        /// <summary>
        /// Querys and gets whether the loop sequence is On/Off in capture palyback
        ///  </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \Capture playback\verbatim
          [When(@"I get the loop sequence status for AWG ([1-4])")]
            \endverbatim 
        */

        [When(@"I get the loop sequence status for AWG ([1-4])")]
        public void GetTheLoopSequenceStatus(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.GetLoopSequence(awg);
        }

        //keerthi 05/29/2015
        /// <summary>
        /// Querys and gets whether the loop sequence is On/Off in capture palyback
        /// Compares the query result with the expected result
        ///  </summary>
        /// <param name="awgNumber">specific awg</param>
        /// /// <param name="expectedLoopsequence">Expected loop sequence</param>
        /*!
            \Capture playback\verbatim
           [Then(@"the loop sequence status should be (.*) for AWG ([1-4])")]
            \endverbatim 
        */

        [Then(@"the loop sequence status should be (.*) for AWG ([1-4])")]
        public void LoopSequenceStatusShouldBe(string expectedLoopsequence, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.LoopSequenceShouldBe(expectedLoopsequence,awg);
        }

        #endregion CPLAYBACK:COMPILE:LSEQuence?


        #region CPLayback:COMPile:CFRequency
        /// <summary>
        /// Sets the carrier frequency for the compiled capture list signals of the %AWG with units
        /// CPLayback:COMPile:CFRequency sets the carrier frequency for the compiled signals.
        /// </summary>
        /// <param name="setValue">Carrier Frequency for compiled signals</param>
        /// <param name="units">Which units the sampling frequency is in</param>
        /// <param name="awgNumber"></param>
        /*!
            \captureplayback\verbatim
        [When(@"I set the carrier frequency to ([-+]?(?:[0-9]+(?:\.[0-9]*)?|\.[0-9]+)(?:[eE][-+]?[0-9]+)?)Hz for captured signals for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the carrier frequency to ([-+]?(?:[0-9]+(?:\.[0-9]*)?|\.[0-9]+)(?:[eE][-+]?[0-9]+)?)Hz for captured signals for AWG ([1-4])")]
        public void SetTheCompileCarFrequencyToValueAndUnits(string setValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.SetCompileCarFrequency(awg, setValue);
        }
        #endregion CPLayback:COMPile:CFRequency

        #region CPLayback:COMPile:CFRequency?
        /// <summary>
        /// Gets the carrier frequency for the compiled capture list signals of the %AWG with units
        /// CPLayback:COMPile:CFRequency? gets the carrier frequency for the compiled signals.
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \captureplayback\verbatim
        [When(@"I get the carrier frequency for captured list signals for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the carrier frequency for captured list signals for AWG ([1-4])")]
        public void GetTheCompileCarFrequency(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.GetCompileCarFrequency(awg);
        }

        /// <summary>
        /// Sets the carrier frequency for the compiled capture list signals of the %AWG with units
        /// CPLayback:COMPile:CFRequency sets the carrier frequency for the compiled signals.
        /// </summary>
        /// <param name="setValue">Carrier Frequency for compiled signals</param>
        /// <param name="units">Which units the sampling frequency is in</param>
        /// <param name="awgNumber"></param>
        /*!
            \captureplayback\verbatim
        [Then(@"the carrier frequency should be ([-+]?(?:[0-9]+(?:\.[0-9]*)?|\.[0-9]+)(?:[eE][-+]?[0-9]+)?)Hz  for the captured signals for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the carrier frequency should be ([-+]?(?:[0-9]+(?:\.[0-9]*)?|\.[0-9]+)(?:[eE][-+]?[0-9]+)?)Hz for the captured signals for AWG ([1-4])")]
        public void TheCompileCarFrequencyShouldBe(string expectedFreq, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.CompileCarrierFreqShouldBe(awg, expectedFreq);
        }
        #endregion CPLayback:COMPile:CFRequency?

        #region CPLAYBACK:COMPILE:SRATE
        /// <summary>
        /// Using CPLayback:COMPile:SRATE sets the output sampling rate for the captured signals.
        /// </summary>
        /// <param name="sampleRate">Desired sample rate in samples/s</param>
        /// <param name="awgNumber"></param>
        /*!
            \captureplayback\verbatim
        [When(@"I set sample rate to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for the captured list signals for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set sample rate to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for the captured list signals for AWG ([1-4])")]
        public void SetTheCompileSampleRate(string sampleRate, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber); 
            _awgCapturePlaybackGroup.SetCompileSampleRate(awg, sampleRate);
        }
        #endregion CPLAYBACK:COMPILE:SRATE

        #region CPLAYBACK:COMPILE:SRATE?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:COMPile:SRATE? gets the output sampling rate for the captured signals.
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \captureplayback\verbatim
        [When(@"I get sample rate for the captured list signals for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get sample rate for the captured list signals for AWG ([1-4])")]
        public void GetTheCompileSampleRate(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.GetCompileSampleRate(awg);
        }

        //jmanning 09/22/2014
        /// <summary>
        /// UsingCPLayback:COMPile:SRATE compares the sample rate for the captured signals versus expected value..
        /// </summary>
        /// <param name="expectedSampRate">Expected Sample Rate</param>
        /// <param name="awgNumber"></param>
        /*!
            \captureplayback\verbatim
        [When(@"I get sample rate for the captured list signals for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the sample rate should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for the captured list signals for AWG ([1-4])")]
        public void TheCompileSampleRateShouldBe(string expectedSampRate, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.CompileSampleRateShouldBe(awg, expectedSampRate);
        }
        #endregion CPLAYBACK:COMPILE:SRATE?

        #region CPLayback:COMPile:SRATe:AUTO
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:COMPile:SRATe:AUTO command sets if the system will calculate output sampling rate automatically when compiling the selected signals.
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \captureplayback\verbatim
        [When(@"I turn on sample rate auto calculate for the captured signal list for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I turn on sample rate auto calculate for the captured signal list for AWG ([1-4])")]
        /// 
        public void SetTheCompileSampleRateAutoOn(string awgNumber)
        {
            bool select = true;
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.SetCompileSampleRateAuto(awg, select);
        }

        /*!
            \captureplayback\verbatim
        [When(@"I turn off sample rate auto calculate for the captured signal list for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I turn off sample rate auto calculate for the captured signal list for AWG ([1-4])")]
        /// 
        public void SetTheCompileSampleRateAutoOff(string awgNumber)
        {
            bool deselect = false;
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.SetCompileSampleRateAuto(awg, deselect);
        }
        #endregion CPLayback:COMPile:SRATe:AUTO

        #region CPLayback:COMPile:SRATe:AUTO?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:COMPile:SRATe:AUTO? query gets status  of if the system will calculate output sampling rate automatically when compiling the selected signals.
        /// </summary>
        /// <param name="awgNumber">specific awg object</param>
        /// 
        /*!
            \captureplayback\verbatim
        [When(@"I get the sample rate auto calculate state for the captured signal list for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the sample rate auto calculate state for the captured signal list for AWG ([1-4])")]
        /// 
        public void GetTheCompileSampleRateAuto(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.GetCompileSampleRateAuto(awg);
        }

        //jmanning 09/22/2014
        /// <summary>
        /// Using CPLayback:COMPile:SRATe:AUTO? Compares sample rate auto calculation state versus expected state.
        /// </summary>
        /// <param name="awgNumber">specific awg object</param>
        /// 
        /*!
            \captureplayback\verbatim
        [Then(@"the sample rate auto calculate state should be on for the captured signal list for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the sample rate auto calculate state should be on for the captured signal list for AWG ([1-4])")]
        /// 
        public void TheCompileSampleRateAutoCalcStateShouldBeOn(string awgNumber)
        {
            const string ON = "1";
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.CompileSampleRateAutoCalcStateShouldBe(awg, ON);
        }

        /*!
            \captureplayback\verbatim
        [Then(@"the sample rate auto calculate state should be on for the captured signal list for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the sample rate auto calculate state should be off for the captured signal list for AWG ([1-4])")]
        /// 
        public void TheCompileSampleRateAutoCalcStateShouldBeOff(string awgNumber)
        {
            const string OFF = "0";
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.CompileSampleRateAutoCalcStateShouldBe(awg, OFF);
        }
        #endregion CPLayback:COMPile:SRATe:AUTO?
        
        #region CPLayback:CLISt:NAME?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:NAME? query gets the name of a signal from the captured signal list in the position specified by the index value.  Index value is 1-based.
        /// </summary>
        /// <param name="listIndex">index position of signal in captured list</param>
        /// <param name="awgNumber">specific awg object</param>
        /// 
        /*!
            \captureplayback\verbatim
        [When(@"I get the signal name at index (\d+) of the captured signal list for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the signal name at index (\d+) of the captured signal list for AWG ([1-4])")]
        /// 
        public void GetTheCompileSignalName(string listIndex, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.GetCompileSignalName(awg, listIndex);
        }


        //jmanning 09/22/2014
        /// <summary>
        /// Using CPLayback:CLISt:NAME? Compares signal name from captured list with expected signal name.
        /// </summary>
        /// <param name="expectedName">Expected Signal Name</param>
        /// <param name="awgNumber">specific awg object</param>
        /// 
        /*!
            \captureplayback\verbatim
        [Then(@"the signal name should be ""(.+)"" for the captured signal at the expected index for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the signal name should be ""(.+)"" for the captured signal at the expected index for AWG ([1-4])")]
        /// 
        public void TheCompileSignalNameShouldBe(string signalName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.CompileSignalNameShouldBe(awg, signalName);
        }
        #endregion CPLayback:CLISt:NAME?

        #region CPLayback:CLISt:SIGNal:DELete
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:DELete command removes the specified signal from the captured signal list. ALL clears the captured signal list.
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="signalName">Signal name to delete. "ALL" deletes whole list</param>
        /// <param name="awgNumber">specific awg object</param>
        /// 
        /*!
            \captureplayback\verbatim
        [When(@"I delete the signal named ""(.+)"" from the captured signal list for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I delete the signal named ""(.+)"" from the captured signal list for AWG ([1-4])")]
        /// 
        public void DeleteTheCompileSignalNamed(string signalName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.DeleteCompileSignal(awg, signalName);
        }

        /*!
            \captureplayback\verbatim
        [When(@"I delete all the signals from the captured signal list for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I delete all the signals from the captured signal list for AWG ([1-4])")]
        /// 
        public void DeleteAllTheCompiledSignals(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.DeleteCompileSignal(awg, "ALL");
        }
        #endregion CPLayback:CLISt:SIGNal:DELete

        #region CPLayback:CLISt:SIZE?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIZE? query gets the Number of signals in the captured signal list.
        /// </summary>
        /// <param name="awgNumber">specific awg object</param>
        /// 
        /*!
            \captureplayback\verbatim
        [When(@"I get the numbers of signals in the captured signal list for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the numbers of signals in the captured signal list for AWG ([1-4])")]
        ///  
        public void GetTheCompileSignalCount(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.GetCompileSignalsSize(awg);
        }

        //jmanning 09/22/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIZE? Compares numbers of signals from captured list with expected signal count.
        /// </summary>
        /// <param name="expectedCount">Expected Signal Count</param>
        /// <param name="awgNumber">specific awg object</param>
        /// 
        /*!
            \captureplayback\verbatim
        [Then(@"the number of captured signals should be (\d+) in the captured signal list for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the number of captured signals should be (\d+) in the captured signal list for AWG ([1-4])")]
        ///  
        public void TheCompileSignalCountShouldBe(string expectedCount, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.CompileSignalCountShouldBe(awg, expectedCount);
        }
        #endregion CPLayback:CLISt:SIZE?

        #region CPLayback:CLISt:SIGNal:OTIMe
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:OTIMe command sets the off time for the specified signal in the captured signal list.
        /// </summary>
        /// <param name="offTime">time in seconds</param>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <param name="awgNumber"></param>
        /*!
            \captureplayback\verbatim
        [When(@"I set the off time to ([-+]?(?:[0-9]+(?:\.[0-9]*)?|\.[0-9]+)(?:[eE][-+]?[0-9]+)?) seconds for captured signal named ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the off time to ([-+]?(?:[0-9]+(?:\.[0-9]*)?|\.[0-9]+)(?:[eE][-+]?[0-9]+)?) seconds for captured signal named ""(.+)"" for AWG ([1-4])")]
        public void SetTheCompileSignalOffTime(string offTime, string signalName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.SetCompileSignalOffTime(awg, signalName, offTime);
        }
        #endregion CPLayback:CLISt:SIGNal:OTIMe

        #region CPLayback:CLISt:SIGNal:OTIMe?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:OTIMe? query gets the off time for the specified signal in the captured signal list.
        /// </summary>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <param name="awgNumber"></param>
        /*!
            \captureplayback\verbatim
        [When(@"I get the off time for captured signal named ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the off time for captured signal named ""(.+)"" for AWG ([1-4])")]
        public void GetTheCompileSignalOffTime(string signalName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.GetCompileSignalOffTime(awg, signalName);
        }

        //jmanning 09/22/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:OTIMe? Compares off time for the specified signal with expected off time period.
        /// </summary>
        /// <param name="expectedOffTime">time in seconds</param>
        /// <param name="awgNumber"></param>
        /*!
            \captureplayback\verbatim
        [Then(@"the off time should be ([-+]?(?:[0-9]+(?:\.[0-9]*)?|\.[0-9]+)(?:[eE][-+]?[0-9]+)?) seconds for the specified captured signal for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the off time should be ([-+]?(?:[0-9]+(?:\.[0-9]*)?|\.[0-9]+)(?:[eE][-+]?[0-9]+)?) seconds for the specified captured signal for AWG ([1-4])")]
        public void TheCompileSignalOffTimeShouldBe(string expectedOffTime, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.CompileSignalOffTimeShouldBe(awg, expectedOffTime);
        }
        #endregion CPLayback:CLISt:SIGNal:OTIMe?

        #region CPLayback:CLISt:SIGNal:WCOunt?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:WCOunt? query gets the number of waveform contained in a signal in the captured signal list.
        /// </summary>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <param name="awgNumber">specific awg object</param>
        /// 
        /*!
            \captureplayback\verbatim
        [When(@"I get the number of waveforms contained in the signal ""(.+)"" from the captured signal list for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the number of waveforms contained in the signal ""(.+)"" from the captured signal list for AWG ([1-4])")]
        public void GetTheCompileSignalWfmCount(string signalName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.GetCompileSignalWfmCount(awg, signalName);
        }

        //jmanning 09/22/2014
        /// <summary>
        /// UsingCPLayback:CLISt:SIGNal:WCOunt? Compares numbers of waveforms contained in a signal from captured list with expected waveform count.
        /// </summary>
        /// <param name="expectedCount">Expected Waveform Count</param>
        /// <param name="awgNumber"></param>
        /*!
            \captureplayback\verbatim
        [Then(@"the off time should be ([-+]?(?:[0-9]+(?:\.[0-9]*)?|\.[0-9]+)(?:[eE][-+]?[0-9]+)?) seconds for the specified captured signal for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the number of waveforms should be  (\d+) contained in the specified captured signal for AWG ([1-4])")]
        public void TheCompileSignalWfmCountShouldBe(string expectedCount, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.CompileSignalWfmCountShouldBe(awg, expectedCount);
        }
        #endregion CPLayback:CLISt:SIGNal:WCOunt?

        #region CPLayback:CLISt:SIGNal:WAVeform:NAME?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:WAVeform:NAME? query gets the name of a waveform segment of a signal in the captured signal list.
        /// </summary>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <param name="wfmIndex">index of segment|waveform in specified signal</param>
        /// <param name="awgNumber">specific awg object</param>
        /// 
        /*!
            \captureplayback\verbatim
        [When(@"I get the waveform name at index (\d+) in the signal ""(.+)"" from the captured signal list for AWG ([1-4])")] 
            \endverbatim 
        */
        [When(@"I get the waveform name at index (\d+) in the signal ""(.+)"" from the captured signal list for AWG ([1-4])")] 
        public void GetCompileSignalWfmName(string wfmIndex, string signalName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.GetCompileSignalWfmName(awg, signalName, wfmIndex);
        }

        //jmanning 09/22/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:WAVeform:NAME? Compares name of waveform in a signal from captured list with expected waveform name.
        /// </summary>
        /// <param name="expectedName">Expected Waveform Name</param>
        /// <param name="awgNumber">specific awg object</param>
        /// 
        /*!
            \captureplayback\verbatim
        [Then(@"the waveform name should be ""(.+)"" at the specified captured signal index for AWG ([1-4])")] 
            \endverbatim 
        */
        [Then(@"the waveform name should be ""(.+)"" at the specified captured signal index for AWG ([1-4])")] 
        public void TheCompileSignalWfmNameShouldBe(string expectedName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.CompileSignalWfmNameShouldBe(awg, expectedName);
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
        /// <param name="awgNumber">specific awg object</param>
        /// 
        /*!
            \captureplayback\verbatim
        [When(@"I set the frequency offset to ([-+]?(?:[0-9]+(?:\.[0-9]*)?|\.[0-9]+)(?:[eE][-+]?[0-9]+)?)Hz for the waveform at index (\d+) in the signal ""(.+)"" from the captured signal list for AWG ([1-4])")]  
            \endverbatim 
        */
        [When(@"I set the frequency offset to ([-+]?(?:[0-9]+(?:\.[0-9]*)?|\.[0-9]+)(?:[eE][-+]?[0-9]+)?)Hz for the waveform at index (\d+) in the signal ""(.+)"" from the captured signal list for AWG ([1-4])")] 
        public void SetTheCompileWfmFreqOffset(string freqValue, string wfmIndex, string signalName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.SetCompileWfmFreqOffset(awg, signalName, wfmIndex, freqValue);
        }
        #endregion CPLayback:CLISt:SIGNal:WAVeform:FOFFset

        #region CPLayback:CLISt:SIGNal:WAVeform:FOFFset?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:WAVeform:FOFFset? gets the frequency offset value of a waveform segment fro specified signal in the captured signal list.
        /// </summary>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <param name="wfmIndex">index of segment|waveform in specified signal</param>
        /// <param name="awgNumber">specific awg object</param>
        /*!
           \captureplayback\verbatim
        [When(@"I get the frequency offset value for the waveform at index (\d+) in the signal ""(.+)"" from the captured signal list for AWG ([1-4])")] 
           \endverbatim 
       */
        [When(@"I get the frequency offset value for the waveform at index (\d+) in the signal ""(.+)"" from the captured signal list for AWG ([1-4])")] 
        public void GetTheCompileWfmFreqOffset(string wfmIndex, string signalName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.GetCompileWfmFreqOffset(awg, signalName, wfmIndex);
        }

        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:WAVeform:FOFFset? Compares freq offset value for the specified waveform with expected frequency offset.
        /// </summary>
        /// <param name="expectedFreqOffset">Expected frequency offset</param>
        /// <param name="awgNumber">specific awg object</param>
        /*!
           \captureplayback\verbatim
         [Then(@"the frequency offset value should be ([-+]?(?:[0-9]+(?:\.[0-9]*)?|\.[0-9]+)(?:[eE][-+]?[0-9]+)?)Hz for the specified waveform from the captured signal list for AWG ([1-4])")]  
           \endverbatim 
       */
        [Then(@"the frequency offset value should be ([-+]?(?:[0-9]+(?:\.[0-9]*)?|\.[0-9]+)(?:[eE][-+]?[0-9]+)?)Hz for the specified waveform from the captured signal list for AWG ([1-4])")] 
        public void CompileWfmFreqOffsetShouldBe(string expectedFreqOffset, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.CompileWfmFreqOffsetShouldBe(awg, expectedFreqOffset);
        }
        #endregion CPLayback:CLISt:SIGNal:WAVeform:FOFFset?

        #region CPLayback:CLISt:SIGNal:WAVeform:SRATe
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:WAVeform:SRATe sets the sample rate of a waveform segment of a signal in the captured signal list.
        /// </summary>
        /// <param name="sampleRate">Desired sample rate in samples/s</param>
        /// <param name="wfmIndex">index of segment|waveform in specified signal</param>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <param name="awgNumber">specific awg object</param>
        /// 
        /*!
            \captureplayback\verbatim
        [When(@"I set the sample rate to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for the waveform at index (\d+) in the signal ""(.+)"" from the captured signal list for AWG ([1-4])")] 
            \endverbatim 
        */
        [When(@"I set the sample rate to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for the waveform at index (\d+) in the signal ""(.+)"" from the captured signal list for AWG ([1-4])")] 
        public void SetTheCompileWfmSampleRate(string sampleRate, string wfmIndex, string signalName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.SetCompileWfmSampleRate(awg, signalName, wfmIndex, sampleRate);
        }
        #endregion CPLayback:CLISt:SIGNal:WAVeform:SRATe

        #region CPLayback:CLISt:SIGNal:WAVeform:SRATe?
        //jmanning 09/25/2014
        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:WAVeform:SRATe? gets the sample rate value of a waveform segment for specified signal in the captured signal list.
        /// </summary>
        /// <param name="wfmIndex">index of segment|waveform in specified signal</param>
        /// <param name="signalName">name of signal in captured signals list</param>
        /// <param name="awgNumber">specific awg object</param>
        /// 
        /*!
            \captureplayback\verbatim
        [When(@"I get the sample rate for the waveform at index (\d+) in the signal ""(.+)"" from the captured signal list for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the sample rate for the waveform at index (\d+) in the signal ""(.+)"" from the captured signal list for AWG ([1-4])")]
        public void GetTheCompileWfmSampleRate(string wfmIndex, string signalName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.GetCompileWfmSampleRate(awg, signalName, wfmIndex);
        }

        /// <summary>
        /// Using CPLayback:CLISt:SIGNal:WAVeform:SRATe? Compares sample rate for the specified waveform with expected sample rate value.
        /// </summary>
        /// <param name="sampleRate">Desired sample rate in samples/s</param>
        /// <param name="awgNumber">specific awg object</param>
        /// 
        /*!
            \captureplayback\verbatim
        [Then(@"the sample rate should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for the specifed waveform from the captured signal list for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the sample rate should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for the specifed waveform from the captured signal list for AWG ([1-4])")]
        public void TheCompileWfmSampleRateShouldBe(string sampleRate, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgCapturePlaybackGroup.CompileWfmSampleRateShouldBe(awg, sampleRate);
        }
        #endregion CPLayback:CLISt:SIGNal:WAVeform:SRATe?
        #endregion CapturePlayback   
    }
}
