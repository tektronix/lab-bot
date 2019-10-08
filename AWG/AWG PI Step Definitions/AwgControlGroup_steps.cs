//==========================================================================
// AwgControlGroup_steps.cs
// This file contains the step definitions for the AWGControl Group PI commands. 
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
    /// This class contains the PI step definitions for the %AWG PI Control Group commands.

    /// Generally the steps are set, get and should be operations.  The step sole responsibility
    /// is to make sure the correct %AWG object is used and that parameters such as channel,
    /// markers and clock references are correct for the %AWG object.
    /// 
    /// \ingroup highpi pisteps 
    ///
    [Binding] //Very important! This entry needs to be made in each step definition file.
    public class AwgControlSteps
    {
        private readonly AwgControlGroup _awgControlGroup = new AwgControlGroup();
 
        #region AWGControl:CONFigure:CNUMber

        //Jhowells 6-8-12
        /// <summary>
        /// Gets the number channels available on the %AWG
        /// 
        /// AWGControl:CONFigure:CNUMber?
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \control\verbatim
        [When(@"I get the number of channels available for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the number of channels available for AWG ([1-4])")]
        public void GetTheNumberOfChannelsAvailable(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgControlGroup.FindTheNumberOfChannelsAvailable(awg);
        }

        #endregion AWGControl:CONFigure:CNUMber

        #region AWGControl:DOUTput[n][:STATe]
        //jmanning 09/24/2014
        /// <summary>
        /// Enables the raw DAC waveform outputs for the specified channel.
        /// This command is for AWG7K backward compatibility only. Use OUTPut:MODE:DIRect instead
        /// </summary>
        /// <param name="channel">specified output channel</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \control\verbatim
        [When(@"I set the enable raw DAC waveform outputs to on for Channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the enable raw DAC waveform outputs to on for Channel ([1-4]) for AWG ([1-4])")]
        public void SetControlDACStateEnabled(string channel, string awgNumber)
        {
            string enabled = "1"; //default state same as OUTPut:MODE DIRect
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgControlGroup.SetControlDACState(awg, channel, enabled);
        }

        //jmanning 09/24/2014
        /// <summary>
        /// Disables the raw DAC waveform outputs for the specified channel.
        /// This command is for AWG7K backward compatibility only. Use OUTPut:MODE:DIRect instead
        /// </summary>
        /// <param name="channel">specified output channel</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \control\verbatim
        [When(@"I set the enable raw DAC waveform outputs to off for Channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the enable raw DAC waveform outputs to off for Channel ([1-4]) for AWG ([1-4])")]
        public void SetControlDACStateDisabled(string channel, string awgNumber)
        {
            string disabled = "0"; //same as OUTPut:MODE AC
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgControlGroup.SetControlDACState(awg, channel, disabled);
        }
        
        //jmanning 09/24/2014
        /// <summary>
        /// Using AWGControl:DOUTput[n][:STATe]? return the enable state for raw DAC waveform output for the specified channel.
        /// </summary>
        /// <param name="channel">specified output channel</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \control\verbatim
        [When(@"I get the raw DAC waveform output enable state for Channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the raw DAC waveform output enable state for Channel ([1-4]) for AWG ([1-4])")]
        public void GetControlDACStateStatus(string channel, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgControlGroup.GetControlDACState(awg, channel);
        }

        /// <summary>
        /// Using AWGControl:DOUTput[n][:STATe]? compares the enable state for raw DAC waveform output for the specified channel versus expected state.
        /// </summary>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \control\verbatim
        [Then(@"the raw DAC waveform output enable state should be enabled for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the raw DAC waveform output enable state should be enabled for AWG ([1-4])")]
        public void TheAwgControlDACStateShouldEnabled(string awgNumber)
        {
            string enabled = "1"; 
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgControlGroup.ControlDACStateShouldbe(awg, enabled);
        }


        /// <summary>
        /// Using AWGControl:DOUTput[n][:STATe]? compares the enable state for raw DAC waveform output for the specified channel versus expected state.
        /// </summary>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \control\verbatim
        [Then(@"the raw DAC waveform output enable state should be disabled for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the raw DAC waveform output enable state should be disabled for AWG ([1-4])")]
        public void TheAwgControlDACStateShouldDisabled(string awgNumber)
        {
            string disabled = "0";
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgControlGroup.ControlDACStateShouldbe(awg, disabled);
        }
        #endregion AWGControl:DOUTput[n][:STATe]

        #region AWGControl:INTerleave:ADJustment:AMPLitude

        // Unkown 01/01/01
        //glennj 1/31/2014
        /// <summary>
        /// Sets the %AWG interleave adjustment amplitude.
        /// 
        /// AWGControl:INTerleave:ADJustment:AMPLitude
        /// </summary>
        /// <param name="setValue">amplitude as a percent with max of 10</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \control\verbatim
        [When(@"I set the amplitude to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for the interleave adjustment for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the amplitude to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for the interleave adjustment for AWG ([1-4])")]
        public void SetTheInterleaveAdjustmentAmplitude(string setValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgControlGroup.SetInterleaveAdjustmentAmplitude(awg, AwgControlGroup.InterleaveAdjustmentAmplitudeAs.Value, setValue);
        }

        //glennj 1/31/2014
        /// <summary>
        /// Sets the %AWG interleave adjustment amplitude to minimum
        /// 
        /// AWGControl:INTerleave:ADJustment:AMPLitude
        /// </summary>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \control\verbatim
        [When(@"I set the amplitude to minimum for the interleave adjustment for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the amplitude to minimum for the interleave adjustment for AWG ([1-4])")]
        public void SetTheInterleaveAdjustmentAmplitudeToMin(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgControlGroup.SetInterleaveAdjustmentAmplitude(awg, AwgControlGroup.InterleaveAdjustmentAmplitudeAs.Min);
        }

        //glennj 1/31/2014
        /// <summary>
        /// Sets the %AWG interleave adjustment amplitude to maximum
        /// 
        /// AWGControl:INTerleave:ADJustment:AMPLitude
        /// </summary>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \control\verbatim
        [When(@"I set the amplitude to maximum for the interleave adjustment for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the amplitude to maximum for the interleave adjustment for AWG ([1-4])")]
        public void SetTheInterleaveAdjustmentAmplitudeToMax(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgControlGroup.SetInterleaveAdjustmentAmplitude(awg, AwgControlGroup.InterleaveAdjustmentAmplitudeAs.Max);
        }

        // Unkown 01/01/01
        /// <summary>
        /// Gets the %AWG interleave adjustment amplitude. 
        ///
        /// AWGControl:INTerleave:ADJustment:AMPLitude?
        /// </summary>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
          \control\verbatim
        [When(@"I get the AWG interleave adjustment amplitude")]
          \endverbatim 
        */
        [When(@"I get the amplitude for the interleave adjustment for AWG ([1-4])")]
        public void GetTheInterleaveAdjustmentAmplitude(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgControlGroup.GetInterleaveAdjustmentAmplitude(awg);
        }

        // Unkown 01/01/01
        //glennj 1/31/2014
        /// <summary>
        /// Tests the %AWG interleave adjustment amplitude against the expected value. 
        /// AWGControl:INTerleave:ADJustment:AMPLitude
        /// </summary>
        /// <param name="expectedValue">expected interleave adjustment amplitude value </param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
          \control\verbatim
        [Then(@"the amplitude should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for the interleave adjustment for AWG ([1-4])")]
          \endverbatim 
        */
        [Then(@"the amplitude should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for the interleave adjustment for AWG ([1-4])")]
        public void TheAwgInterleaveAdjustmentAmplitudeShouldBe(string expectedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgControlGroup.InterleaveAdjustmentAmplitudeShouldBe(awg, expectedValue);
        }

        #endregion AWGControl:INTerleave:ADJustment:AMPLitude

        #region AWGControl:INTerleave:ADJustment:PHASe

        // Unkown 01/01/01
        /// <summary>
        /// Sets the %AWG interleave adjustment phase
        ///
        /// AWGControl:INTerleave:ADJustment:PHASe
        /// </summary>
        /// <param name="setValue">phase as a number between 180 and -180 degrees at 0.1 resultion</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \control\verbatim
        [When(@"I set the phase to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for the interleave adjustment for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the phase to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for the interleave adjustment for AWG ([1-4])")]
        public void SetTheInterleaveAdjustmentPhase(string setValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgControlGroup.SetInterleaveAdjustmentPhase(awg, AwgControlGroup.InterleaveAdjustmentPhaseAs.Value, setValue);
        }

        //glennj 1/31/2014
        /// <summary>
        /// Sets the %AWG interleave adjustment phase to minimum
        /// 
        /// AWGControl:INTerleave:ADJustment:PHASe
        /// </summary>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \control\verbatim
        [When(@"I set the phase to minimum for the interleave adjustment for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the phase to minimum for the interleave adjustment for AWG ([1-4])")]
        public void SetTheInterleaveAdjustmentPhaseToMin(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgControlGroup.SetInterleaveAdjustmentPhase(awg, AwgControlGroup.InterleaveAdjustmentPhaseAs.Min);
        }

        //glennj 1/31/2014
        /// <summary>
        /// Sets the %AWG interleave adjustment phase to maximum
        /// 
        /// AWGControl:INTerleave:ADJustment:PHASe
        /// </summary>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \control\verbatim
        [When(@"I set the phase to maximum for the interleave adjustment for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the phase to maximum for the interleave adjustment for AWG ([1-4])")]
        public void SetTheInterleaveAdjustmentPhaseToMax(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgControlGroup.SetInterleaveAdjustmentPhase(awg, AwgControlGroup.InterleaveAdjustmentPhaseAs.Max);
        }

        // Unkown 01/01/01
        /// <summary>
        /// Gets the %AWG interleave adjustment phase
        ///
        /// AWGControl:INTerleave:ADJustment:PHASe
        /// </summary>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
          \control\verbatim
        [When(@"I get the phase for the interleave adjustment for AWG ([1-4])")]
          \endverbatim 
        */
        [When(@"I get the phase for the interleave adjustment for AWG ([1-4])")]
        public void GetTheInterleaveAdjustmentPhase(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgControlGroup.GetInterleaveAdjustmentPhase(awg);
        }

        // Unkown 01/01/01
        /// <summary>
        /// Compares the %AWG interleave adjustment phase value against the expected value

        /// AWGControl:INTerleave:ADJustment:PHASe
        /// </summary>
        /// <param name="expectedValue">Expected AWG interleave adjustment phase value</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
          \control\verbatim
        [Then(@"the phase should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for the interleave adjustment for AWG ([1-4])")]
          \endverbatim 
        */
        [Then(@"the phase should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for the interleave adjustment for AWG ([1-4])")]
        public void TheAwgInterleaveAdjustmentPhaseShouldBe(string expectedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgControlGroup.InterleaveAdjustmentPhaseShouldBe(awg, expectedValue);
        }

        #endregion AWGControl:INTerleave:ADJustment:PHASe

        #region AWGControl:RMODe

        // These steps have been removed.  This needs to be tested as backwards compatibile which is only syntax.
        // If the run mode is required, use the step for SOURce:RMODe which includes the old modes plus new ones.

        #endregion AWGControl:RMODe

        #region AWGControl:RSTate

        // Unkown 01/01/01
        /// <summary>
        /// Returns the run state of the %AWG
        /// 
        /// AWGControl:RSTate?
        /// </summary>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \control\verbatim
        [When(@"I get the run state for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the run state for AWG ([1-4])")]
        public void GetTheRunState(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgControlGroup.GetRunState(awg);
        }

        //glennj 2/3/2014
        /// <summary>
        /// Compares current %AWG run state against the expected value of stopped
        /// 
        /// AWGControl:RSTate?
        /// </summary>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \control\verbatim
        [Then(@"the run state should be stopped for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the run state should be stopped for AWG ([1-4])")]
        public void TheAwgRunStateShouldBeStopped(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgControlGroup.RunStateofTheAwgShouldBe(awg, AwgControlGroup.ControlRunState.Stopped); 
        }

        //glennj 2/3/2014
        /// <summary>
        /// Compares current %AWG run state against the expected value of waiting for trigger
        /// 
        /// AWGControl:RSTate?
        /// </summary>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \control\verbatim
        [Then(@"the run state should be waiting for trigger for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the run state should be waiting for trigger for AWG ([1-4])")]
        public void TheAwgRunStateShouldBeWaiting(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgControlGroup.RunStateofTheAwgShouldBe(awg, AwgControlGroup.ControlRunState.Waiting);
        }

        //glennj 2/3/2014
        /// <summary>
        /// Compares current %AWG run state against the expected value of running
        /// 
        /// AWGControl:RSTate?
        /// </summary>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \control\verbatim
        [Then(@"the run state should be running for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the run state should be running for AWG ([1-4])")]
        public void TheAwgRunStateShouldBeRunning(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgControlGroup.RunStateofTheAwgShouldBe(awg, AwgControlGroup.ControlRunState.Running);
        }

        //glennj 10/21/2013
        /// <summary>
        /// This polls for an expected state of stopped.  This is necessary for testing as there is<para>
        /// no mechanism that knows when running state has been updated.</para><para>
        /// There have been problems where there is an expected state but</para><para>
        /// the pause (or no pause) hasn't been long enough.  And what is</para><para>
        /// long enough?</para><para>
        /// The DB cell gets updated in a polling manner also.</para>
        /// </summary>
        /// <param name="numberOfPolls"></param>
        /// <param name="numberOfSeconds"></param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \control\verbatim
        [When(@"I poll the running state for a max of (\d+) times at (\d+) second intervals for a change to stopped for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I poll the running state for a max of (\d+) times at (\d+) second intervals for a change to stopped for AWG ([1-4])")]
        public void PollTheRunningStateForExpectedStoppedState(string numberOfPolls, string numberOfSeconds, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgControlGroup.PollForRunningStateofTheAwgShouldBe(awg, AwgControlGroup.ControlRunState.Stopped, numberOfSeconds, numberOfPolls);
        }

        //glennj 10/21/2013
        /// <summary>
        /// This polls for an expected state of waiting for trigger.  This is necessary for testing as there is<para>
        /// no mechanism that knows when running state has been updated.</para><para>
        /// There have been problems where there is an expected state but</para><para>
        /// the pause (or no pause) hasn't been long enough.  And what is</para><para>
        /// long enough?</para><para>
        /// The DB cell gets updated in a polling manner also.</para>
        /// </summary>
        /// <param name="numberOfPolls"></param>
        /// <param name="numberOfSeconds"></param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \control\verbatim
        [When(@"I poll the running state for a max of (\d+) times at (\d+) second intervals for a change to waiting for trigger for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I poll the running state for a max of (\d+) times at (\d+) second intervals for a change to waiting for trigger for AWG ([1-4])")]
        public void PollTheRunningStateForExpectedWaitingForTriggerState(string numberOfPolls, string numberOfSeconds, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgControlGroup.PollForRunningStateofTheAwgShouldBe(awg, AwgControlGroup.ControlRunState.Waiting, numberOfSeconds, numberOfPolls);
        }

        //glennj 10/21/2013
        /// <summary>
        /// This polls for an expected state of running.  This is necessary for testing as there is<para>
        /// no mechanism that knows when running state has been updated.</para><para>
        /// There have been problems where there is an expected state but</para><para>
        /// the pause (or no pause) hasn't been long enough.  And what is</para><para>
        /// long enough?</para><para>
        /// The DB cell gets updated in a polling manner also.</para>
        /// </summary>
        /// <param name="numberOfPolls"></param>
        /// <param name="numberOfSeconds"></param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \control\verbatim
        [When(@"I poll the running state for a max of (\d+) times at (\d+) second intervals for a change to running for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I poll the running state for a max of (\d+) times at (\d+) second intervals for a change to running for AWG ([1-4])")]
        public void PollTheRunningStateForExpectedRunningState(string numberOfPolls, string numberOfSeconds, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgControlGroup.PollForRunningStateofTheAwgShouldBe(awg, AwgControlGroup.ControlRunState.Running, numberOfSeconds, numberOfPolls);
        }
        #endregion AWGControl:RSTate

        #region AWGControl:RUN:IMMediate

        //glennj 2/3/2014
        /// <summary>
        /// Runs the loaded waveform on the default %AWG. 
        /// 
        /// AWGControl:RUN:IMMediate - (no query)
        /// </summary>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
          \control\verbatim
        [When(@"I initiate play for AWG ([1-4])")]
          \endverbatim 
        */
        [When(@"I initiate play for AWG ([1-4])")]
        public void PlayTheAwg(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgControlGroup.RunTheAwg(awg);
        }

        // PHunter 09-17-2012
        /// <summary>
        /// Runs the loaded waveform on the default %AWG. 
        /// 
        /// AWGControl:RUN:IMMediate - (no query)
        /// </summary>
        /*!
          \control\verbatim
        [When(@"I run the AWG")]
          \endverbatim 
        */
        [When(@"I run the AWG")]
        public void RunTheAwg()
        {
            IAWG awg = AwgSetupSteps.GetAWG(AwgSetupSteps.AwgContext);
            _awgControlGroup.RunTheAwg(awg);
        }

        #endregion AWGControl:RUN:IMMediate

        #region AWGControl:SNAMe

        // Unkown 01/01/01
        /// <summary>
        /// Returns the %AWG's most recently saved setup location
        /// 
        /// AWGControl:SNAMe?
        /// </summary>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \control\verbatim
        [When(@"I get the most recently saved setup location for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the most recently saved setup location for AWG ([1-4])")]
        public void GetTheMostRecentlySavedSetupLocation(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgControlGroup.GetMostRecentlySavedSetupLocation(awg);
        }

        // Unkown 01/01/01
        /// <summary>
        /// Compares the %AWG's most recently saved setup location against the expected value.
        /// 
        /// AWGControl:SNAMe?
        /// </summary>
        /// <param name="expectedValue"></param>
        /// <param name="msus"></param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \control\verbatim
        [Then(@"the most recently saved setup location should be ""(.+)"" on drive ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the most recently saved setup location should be ""(.+)"" on drive ""(.+)"" for AWG ([1-4])")]
        public void TheSetupLocationShouldBe(string expectedValue, string msus, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgControlGroup.SetupLocationShouldBe(awg, expectedValue, msus);
        }

        #endregion AWGControl:SNAMe

        #region AWGControl:STOP:IMMediate

        // JHowells 10/10/12
        /// <summary>
        /// Stops the output of the loaded waveform on the default %AWG. 
        /// 
        /// AWGControl:STOP[:IMMediate] - (no query)
        /// </summary>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
          \control\verbatim
        [When(@"I stop AWG ([1-4])")]
          \endverbatim 
        */
        [When(@"I stop AWG ([1-4])")]
        public void StopTheAwg(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgControlGroup.StopTheAwg(awg);
        }

        #endregion AWGControl:STOP:IMMediate

        #region Futures

        #region AWGControl:COMPile

        //Jhowells 6-11-12
        //glennj 7/16/2013
        // When it is decided that Equation Editor is in, this needs work TODO
        /// <summary>
        /// Compiles an equation editor file on the given %AWG.
        ///
        /// Using the specified path on the instrument compiles an equation editor file.@n
        /// AWGControl:COMPile "path"
        /// </summary>
        /// <param name="path">Path to the file</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \control\verbatim
        [When(@"I compile the ""(.+)"" equation file for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I compile the ""(.+)"" equation file for AWG ([1-4])")]
        public void CompileEquationEditorFileOnAwg1(string path, string awgNumber)
        {
            //IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            //_awgControlGroup.AwgControlCompile(awg, path); TODO
        }

        #endregion AWGControl:COMPile

        #endregion Futures
    }
}