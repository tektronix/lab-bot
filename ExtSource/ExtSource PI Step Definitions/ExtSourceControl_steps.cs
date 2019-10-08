//==========================================================================
// ExtSourceControl__steps.cs
// This file contains the low-order PI step definitions for the External Source PI Control Group commands. 
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
// File path strings - ""(.+)"" used when you want the string that is delimited by the quotes File path strings
//                         
//==========================================================================


using TechTalk.SpecFlow;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains the low-order PI step definitions for the External Source PI Control Group commands.

    /// Low-level steps set and get the values for commands, and test the raw values as returned from the 
    /// instrument. They DO NOT interpret values in any way! Interpretation, normalization, etc. need to 
    /// occur in the High-level step definitions. Notice the use of the word "value" in the steps - this 
    /// usually implies that the query returns a 0 or 1 or abbreviated text value (like SOFT) that should 
    /// be interpreted as ON or OFF or SOFTWARE to make the step more user-friendly. We do that in the 
    /// High-order step definitions.
    /// 
    /// </summary> 
    [Binding] //Very important! This entry needs to be made in each step definition file.
    public class ExtSourceControlSteps
    {
        private readonly ExtSourceControlGroup _extSourceControlGroup = new ExtSourceControlGroup();
        private readonly ExtSourceSystemGroup _extSourceSystemGroup = new ExtSourceSystemGroup();
        private readonly ExtSourceSourceGroup _extSourceSourceGroup = new ExtSourceSourceGroup();

        #region AWGControl:INTerleave[:STATe]
        /// <summary>
        /// Sets the interleave state to on for the External Source 
        /// </summary>
        /*!
            \control\verbatim
        [When(@"I turn interleaving on for the External Source")]
            \endverbatim 
        */
        [When(@"I turn interleaving on for the External Source")]
        public void SetExtSrcTheInterleaveStateOn()
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceControlGroup.SetExtSrcInterLeaveState(extSource, "ON");
        }

        /// <summary>
        /// Sets the interleave state to off for the External Source 
        /// </summary>
        /*!
            \control\verbatim
        [When(@"I turn interleaving off for the External Source")]
            \endverbatim 
        */
        [When(@"I turn interleaving off for the External Source")]
        public void SetExtSrcTheInterleaveStateOff()
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceControlGroup.SetExtSrcInterLeaveState(extSource, "OFF");
        }
        #endregion AWGControl:INTerleave[:STATe]

        #region AWGControl:INTerleave:ZERoing
        /// <summary>
        /// Sets the External Source interleave zeroing to ON
        /// </summary>
        /*!
            \control\verbatim
        [When(@"I set the interleave zeroing to on for the External Source")]
            \endverbatim 
        */
        [When(@"I set the interleave zeroing to on for the External Source")]
        public void SetInterleaveZeroingToOn()
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceControlGroup.SetExtSrcInterLeaveZeroing(extSource, "ON");
        }

        /// <summary>
        /// Sets the External Source interleave zeroing to OFF
        /// </summary>
        /*!
            \control\verbatim
        [When(@"I set the interleave zeroing to off for the External Source")]
            \endverbatim 
        */
        [When(@"I set the interleave zeroing to off for the External Source")]
        public void SetInterleaveZeroingToOff()
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceControlGroup.SetExtSrcInterLeaveZeroing(extSource, "OFF");
        }
        #endregion AWGControl:INTerleave:ZERoing 
        
        #region AWGControl:RMODe
        /// <summary>
        /// Set the run mode to continuous on the External Source

        /// AWGControl:RMODe CONTinuous
        /// </summary>
        /*!
            \control\verbatim
        [When(@"I set the run mode to continuous on the External Source")]
            \endverbatim 
        */
        [When(@"I set the run mode to continuous on the External Source")]
        public void SetTheExtSrcRunModeToContinuous()
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceControlGroup.SetExtSrcRunMode(extSource, "CONTinuous");
        }

        /// <summary>
        /// Set the run mode to enhanced on the External Source

        /// AWGControl:RMODe ENHanced
        /// </summary>
        /*!
            \control\verbatim
        [When(@"I set the run mode to enhanced on the External Source")]
            \endverbatim 
        */
        [When(@"I set the run mode to enhanced on the External Source")]
        public void SetTheExtSrcRunModeToEnhanced()
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceControlGroup.SetExtSrcRunMode(extSource, "ENHanced");
        }

        /// <summary>
        /// Set the run mode to gated on the External Source

        /// AWGControl:RMODe GATed
        /// </summary>
        /*!
            \control\verbatim
        [When(@"I set the run mode to gated on the External Source")]
            \endverbatim 
        */
        [When(@"I set the run mode to gated on the External Source")]
        public void SetTheExtSrcRunModeToGated()
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceControlGroup.SetExtSrcRunMode(extSource, "GATed");
        }

        /// <summary>
        /// Set the run mode to sequence on the External Source

        /// AWGControl:RMODe SEQuence
        /// </summary>
        /*!
            \control\verbatim
        [When(@"I set the run mode to sequence on the External Source")]
            \endverbatim 
        */
        [When(@"I set the run mode to sequence on the External Source")]
        public void SetTheExtSrcRunModeToSequence()
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceControlGroup.SetExtSrcRunMode(extSource, "SEQuence");
        }

        /// <summary>
        /// Set the run mode to triggered on the External Source

        /// AWGControl:RMODe TRIGgered
        /// </summary>
        /*!
            \control\verbatim
        [When(@"I set the run mode to triggered on the External Source")]
            \endverbatim 
        */
        [When(@"I set the run mode to triggered on the External Source")]
        public void SetTheExtSrcRunModeToTriggered()
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceControlGroup.SetExtSrcRunMode(extSource, "TRIGgered");
        }
        #endregion AWGControl:RMODe
       
        #region AWGControl:RMODe?
        /// <summary>
        /// Get the run mode type of the External Source

        /// AWGControl:RMODe
        /// </summary>
        /*!
          \control\verbatim
        [When(@"I get the run mode type on the External Source")]
          \endverbatim 
        */
        [When(@"I get the run mode type on the External Source")]
        public void GetExternalSourceRunModeValue()
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceControlGroup.GetExtSrcRunModeQuery(extSource);
        }

        /// <summary>
        /// Compares run mode type continuous with actual run mode type from the External Source
        /// </summary>
        /*!
          \control\verbatim
        [Then("the run mode type should be continuous on the External Source")]
              \endverbatim 
        */
        [Then("the run mode type should be continuous on the External Source")]
        public void TheExtSrcRunModeShouldBeContinuous()
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceControlGroup.TheExtSrcRunModeShouldBe(extSource, "CONT");
        }

        /// <summary>
        /// Compares run mode type enhanced with actual run mode type from the External Source
        /// </summary>
        /*!
          \control\verbatim
        [Then("the run mode type should be enhanced on the External Source")]
              \endverbatim 
        */
        [Then("the run mode type should be enhanced on the External Source")]
        public void TheExtSrcRunModeShouldBeEnhanced()
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceControlGroup.TheExtSrcRunModeShouldBe(extSource, "ENH");
        }

        /// <summary>
        /// Compares run mode type gated with actual run mode type from the External Source
        /// </summary>
        /*!
          \control\verbatim
        [Then("the run mode type should be gated on the External Source")]
              \endverbatim 
        */
        [Then("the run mode type should be gated on the External Source")]
        public void TheExtSrcRunModeShouldBeGated()
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceControlGroup.TheExtSrcRunModeShouldBe(extSource, "GAT");
        }

        /// <summary>
        /// Compares run mode type sequence with actual run mode type from the External Source
        /// </summary>
        /*!
          \control\verbatim
        [Then("the run mode type should be sequence on the External Source")]
              \endverbatim 
        */
        [Then("the run mode type should be sequence on the External Source")]
        public void TheExtSrcRunModeShouldBeSequence()
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceControlGroup.TheExtSrcRunModeShouldBe(extSource, "SEQ");
        }

        /// <summary>
        /// Compares run mode type triggered with actual run mode type from the External Source
        /// </summary>
        /*!
          \control\verbatim
        [Then("the run mode type should be triggered on the External Source")]
              \endverbatim 
        */
        [Then("the run mode type should be triggered on the External Source")]
        public void TheExtSrcRunModeShouldBeTriggered()
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceControlGroup.TheExtSrcRunModeShouldBe(extSource, "TRIG");
        }
        #endregion AWGControl:RMODe?

        #region AWGControl:RRATe
        /// <summary>
        /// Set the repetition rate on the External Source and assuming that it is an AWG7122C
        /// </summary>
        /// <param name="setValue"></param>
        [When(@"I set the repetition rate to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) on the External Source")]
        public void SetRepetitionRateOnExternalSource(string setValue)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceControlGroup.SetExtSrcRepRate(extSource, setValue);
        }
        #endregion AWGControl:RRATe

        #region AWGControl:RUN:IMMediate
        /// <summary>
        /// Runs the waveform in the External Source 

        /// AWGControl:RUN:IMMediate - (no query)
        /// </summary>
        /*!
            \extSource\verbatim
        [When(@"I run the External Source")]
            \endverbatim 
        */
        [When(@"I run the External Source")]
        public void RunTheWaveformInTheExtSrc()
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceControlGroup.SetExtSrcRunImm(extSource);
        }
        #endregion AWGControl:RUN:IMMediate

        #region AWGControl:SNAMe?
        /// <summary>
        /// Gets the name of the current setup loaded on the External Source
        /// 
        /// AWGControl:SNAMe?
        /// </summary>
        /*!
            @control\verbatim
        [When(@"I get the name of the current setup loaded on the External Source")]
            \endverbatim 
        */
        [When(@"I get the name of the current setup loaded on the External Source")]
        public void GettheCurrentSetupNameOnExtSrc()
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceControlGroup.GetExtSrcSetupNameQuery(extSource);
        }

        /// <summary>
        /// Compares the name of the current setup loaded on the External Source against the expected value.
        /// 
        /// AWGControl:SNAMe?
        /// </summary>
        /*!
            @control\verbatim
        [Then(@"the name of the current setup loaded should be (.+) on the External Source ")]
            \endverbatim 
        */
        [Then(@"the name of the current setup loaded should be (.+) on the External Source ")]
        public void TheCurrentSetupFileOnExtSrcShouldBe(string expectedFile)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceControlGroup.TheExtSrcSetupNameShouldBe(extSource, expectedFile);
        }
        #endregion AWGControl:SNAMe?

        #region AWGControl:SREStore
        /// <summary>
        /// Opens a setup file into the AWG
        /// 
        /// AWGControl:SREStore
        /// </summary>
        /// <param name="filename">Full path of the setup file</param>
        /// <param name="msus">Drive letter</param>
        /*!
            @massmemory\verbatim
        [When(@"I open a setup file ""(.+)"" from the (\w:|) drive to the External Source")]
            \endverbatim 
        */
        [When(@"I open a setup file ""(.+)"" from the (\w:|) drive to the External Source")]
        public void OpenASetupOntoExtSrc(string filename, string msus)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceControlGroup.SetExtSrcFileWithMsusRestore(extSource, filename, msus);
        }

        /// <summary>
        /// Loads a setup from a file

        /// AWGControl:SREStore
        /// </summary>
        /// <param name="filename"> Path of the setup file</param>
        /*!
            \extSource\verbatim
        [When(@"I restore with the ""(.+)"" file on the External Source")]
            \endverbatim 
        */
        [When(@"I restore with the ""(.+)"" file on the External Source")]
        public void RestoreAnExtSrcSetupFile(string filename)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceControlGroup.SetExtSrcFileRestore(extSource, filename);
        }
        #endregion AWGControl:SREStore

        #region AWGControl:SSave
        /// <summary>
        /// Saves the setup of the External source as an awg file to a specific drive
        /// 
        /// AWGControl:SSave
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="msus"></param>
        /*!
            @mcontrol\verbatim
        [When(@"I save the setup of the External Source to the file ""(.+)"" in the (|\w:) drive")]
            \endverbatim 
        */
        [When(@"I save the setup to the file ""(.+)"" in the (|\w:) drive of the External Source")]
        public void SaveTheSetupofExtSrcToFile(string filename, string msus)
        {
            IEXTSOURCE extsource = EXTSOURCE.GetExtSource(false);
            _extSourceControlGroup.SaveExtSrcSettings(extsource, filename, msus);
        }
        #endregion AWGControl:SSave

        #region AWGControl:STOP:IMMediate
        /// <summary>
        /// Stops the waveform

        /// AWGControl:STOP[:IMMediate]- (no query)
        /// </summary>
        /*!
            \extSource\verbatim
        [When(@"I stop the External Source")]
            \endverbatim 
        */
        [When(@"I stop the External Source")]
        public void StopTheExtSrc()
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceControlGroup.SetExtSrcStopImm(extSource);
        }
        #endregion AWGControl:STOP:IMMediate

        #region SetupExtRefSource
        public void SetupTheAwg7122AsExternalReferenceSource(string fileName, string repRate, string zeroingOn)
        {
            const string channelNumber = "1";
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            // Put AWG7122C into a known(default) state
            _extSourceSystemGroup.ExtSrcRst(extSource);
            // Always wait for it to complete or you can get into trouble
            _extSourceSystemGroup.WaitForExternalSource(extSource);
            // Turn the interleave mode to On
            const string interleaveOn = "1";
            _extSourceControlGroup.SetExtSrcInterLeaveState(extSource, interleaveOn);
            // Set state on interleave zeroing
            _extSourceControlGroup.SetExtSrcInterLeaveZeroing(extSource, zeroingOn);
            // Loading a known waveform to produce our external clock waveform for reference
            _extSourceSourceGroup.SetExtSrcFunctUser(extSource, fileName, channelNumber);
            // Not sure this is necessary but set the repetition rate
            _extSourceControlGroup.SetExtSrcRepRate(extSource, repRate);
            // Make sure the output state is on for Channel 1
            const string outputStateOn = "1";
            _extSourceSystemGroup.SetExtSrcOutputState(extSource, channelNumber, outputStateOn);
        }

        /// <summary>
        /// The AWG7122C is being dedicated as an external resource for the<para>
        /// external clock at 100MHz.  Pretty much the same setup will be</para><para>
        /// used so now it is all in one place instead of a number of steps.</para>
        /// </summary>
        /*!
          @massmemory\verbatim
        [When(@"I setup the AWG7122C as a 100MHz External Reference Source")]
            \endverbatim 
        */
        [When(@"I setup the AWG7122C as a 100MHz External Reference Source")]
        public void SetupTheAwg7122CA100MHzExternalReferenceSource()
        {
            // Loading a known waveform to produce our external clock waveform for reference
            const string fileName = "C:/Temp/waveforms/Pascal/Test Case Waveforms/100MHz-Reference.wfm";
            // Not sure this is necessary but set the repetition rate
            const string repRate = "100.00E+6";
            // Make sure the zeroing is off
            const string zeroingOn = "0";
            SetupTheAwg7122AsExternalReferenceSource(fileName, repRate, zeroingOn);
        }

        /// <summary>
        /// The AWG7122C is being dedicated as an external resource for the<para>
        /// external clock at 40MHz.  Pretty much the same setup will be</para><para>
        /// used so now it is all in one place instead of a number of steps.</para>
        /// </summary>
        /*!
          @massmemory\verbatim
        [When(@"I setup the AWG7122C as a 40MHz External Reference Source")]
            \endverbatim 
        */
        [When(@"I setup the AWG7122C as a 40MHz External Reference Source")]
        public void SetupTheAwg7122CA40MHzExternalReferenceSource()
        {
            // Loading a known waveform to produce our external clock waveform for reference
            const string fileName = "C:/Temp/waveforms/Pascal/Test Case Waveforms/40MHz-Reference.wfm";
            // Not sure this is necessary but set the repetition rate
            const string repRate = "40.00E+6";
            // Make sure the zeroing is off
            const string zeroingOn = "0";
            SetupTheAwg7122AsExternalReferenceSource(fileName, repRate, zeroingOn);
        }

        /// <summary>
        /// The AWG7122C is being dedicated as an external resource<para>
        /// for the external clock.  Pretty much the same setup will be</para><para>
        /// used so now it is all in one place instead of a number of steps.</para>
        /// </summary>
        /*!
          @massmemory\verbatim
        [When(@"I setup the AWG7122C as the External Source")]
            \endverbatim 
        */
        [When(@"I setup the AWG7122C as the External Source")]
        public void SetupTheAwg7122CAsTheExternalSource()
        {
            // Loading a known waveform to produce our external clock waveform
            const string fileName = "C:/Temp/waveforms/Pascal/Test Case Waveforms/TC_2930.wfm";
            // Not sure this is necessary but set the repetition rate
            const string repRate = "6.25E+9";
            // Make sure the zeroing is on
            const string zeroingOn = "1";
            SetupTheAwg7122AsExternalReferenceSource(fileName, repRate, zeroingOn);
        }

        /// <summary>
        /// The AWG7122C is being dedicated as an external resource for the<para>
        /// external clock at 10MHz.  Pretty much the same setup will be</para><para>
        /// used so now it is all in one place instead of a number of steps.</para>
        /// </summary>
        /*!
          @massmemory\verbatim
        [When(@"I setup the AWG7122C as a 10MHz External Reference Source")]
            \endverbatim 
        */
        [When(@"I setup the AWG7122C as a 10MHz External Reference Source")]
        public void SetupTheAwg7122CA10MHzExternalReferenceSource()
        {
            // Loading a known waveform to produce our external clock waveform for reference
            const string fileName = "C:/Temp/waveforms/Pascal/Test Case Waveforms/10MHz-Reference.wfm";
            // Not sure this is necessary but set the repetition rate
            const string repRate = "10.00E+6";
            // Make sure the zeroing is off
            const string zeroingOn = "0";
            SetupTheAwg7122AsExternalReferenceSource(fileName, repRate, zeroingOn);
        }
        #endregion SetupExtRefSource
    }
}
