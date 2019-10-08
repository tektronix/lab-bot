//==========================================================================
// AwgMultiToneGroup_steps.cs
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

using System;
using TechTalk.SpecFlow;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains the PI step definitions for the %AWG PI MultiTone Group commands.
    /// \ingroup highpi pisteps 
    /// 
    /// </summary> 
    [Binding] //Very important! This entry needs to be made in each step definition file.
    public class AwgMultiToneSteps
    {
        private readonly AwgMultiToneGroup _awgMultiToneGroup = new AwgMultiToneGroup();

        #region MultiTone

        #region MTONE:RESEt

        //sdas2  9/1/2015
        /// <summary>
        /// Reset MultiTone Module
        /// </summary>
        /// <param name="awgNumber"></param>
   
          [When(@"I reset for MultiTone plugin for AWG ([1-4])")]
        public void WhenIResetForMultiTonePluginForAWG(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.AwgMultiToneReset(awg);
           
        }
        #endregion

        #region MTONe:LOAD

        [When(@"I load the MultiTone module for AWG ([1-4])")]
        public void WhenILoadTheMultiToneModuleForAWG(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.AwgMultiToneLoad(awg);
        }

        #endregion

        #region MTONe:TYPE[?]

        [When(@"I set the MultiTone type to Tones for AWG ([1-4])")]
        public void SetTheMultiToneTypeToTones(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneType(awg, AwgMultiToneGroup.MultiToneType.Tones);
        }

        [When(@"I set the MultiTone type to Chirp for AWG ([1-4])")]
        public void SetTheMultiToneTypeToChirp(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneType(awg, AwgMultiToneGroup.MultiToneType.Chirp);
        }

        [When(@"I get the MultiTone type for AWG ([1-4])")]
        public void GetTheMultiToneType(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.GetMultiToneType(awg);
        }

        [Then(@"the MultiTone type should be Tones for AWG ([1-4])")]
        public void ThenTheMultiToneTypeShouldBeTones(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.MultiToneTypeShouldBe(awg, AwgMultiToneGroup.MultiToneType.Tones);
        }


        [Then(@"the MultiTone type should be Chirp for AWG ([1-4])")]
        public void ThenTheMultiToneTypeShouldBeChirp(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.MultiToneTypeShouldBe(awg, AwgMultiToneGroup.MultiToneType.Chirp);
        }

        #endregion

        #region MTONe:COMPile

        [When(@"I compile the MultiTone module for AWG ([1-4])")]
        public void WhenICompileTheMultiToneModuleForAWG(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.AwgMultiToneCompile(awg);
        }

        #endregion

        #region MTONe:COMPile:CANCel

        [When(@"I cancel compilation for the MultiTone module for AWG ([1-4])")]
        public void WhenICancelCompileTheMultiToneModuleForAWG(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.AwgMultiToneCancelCompile(awg);
        }

        #endregion

        #region MTONe:COMPile:NAME[?]

        [When(@"I set the MultiTone signal name to (.*) for AWG ([1-4])")]
        public void SetTheMultiToneSignalNameTo(string name, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneName(awg, name);
        }

        [When(@"I get the MultiTone signal name for AWG ([1-4])")]
        public void GetTheMultiToneSignalName(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.GetMultiToneName(awg);
        }

        [Then(@"the MultiTone signal name should be (.*) for AWG ([1-4])")]
        public void ThenTheMultiToneSignalNameShouldBe(string name, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.MultiToneNameShouldBe(awg, name);
        }

        #endregion

        #region MTONe:COMPile:CHANnel[?]

        [When(@"I set the MultiTone compilation settings to Compile Only for AWG ([1-4])")]
        public void SetMultiToneToCompileOnly(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneChannel(awg, 0);
        }

        [When(@"I set the MultiTone compilation settings to Compile and Assign to Channel ([1-4]) for AWG ([1-4])")]
        public void SetMultiToneToCompileAndAssignToChannel(string channelNo, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            var channel = Convert.ToInt32(channelNo);
            _awgMultiToneGroup.SetMultiToneChannel(awg, channel);
        }


        [When(@"I get the MultiTone compilation settings for Compile and Assign to Channel for AWG ([1-4])")]
        public void GetTheMultiToneChannel(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.GetMultiToneChannel(awg);
        }

        [Then(@"the MultiTone Compile and Assign to Channel status should be ([1-4]) for AWG ([1-4])")]
        public void ThenTheMultiToneCompileAndAssignShouldBe(string name, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.MultiToneChannelShouldBe(awg, name);
        }

        [Then(@"the MultiTone Compile and Assign to Channel status should be Compile Only for AWG ([1-4])")]
        public void ThenTheMultiToneCompileAndAssignShouldBe(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.MultiToneChannelShouldBe(awg, "NONE");
        }

        #endregion

        #region MTONe:COMPile:PLAY[?]

        [When(@"I set the MultiTone compilation settings to play after compilation for AWG ([1-4])")]
        public void SetTheMultiTonePlayToOn(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneChannelPlay(awg, AwgMultiToneGroup.BoolState.On);
        }

        [When(@"I set the MultiTone compilation settings to not play after compilation for AWG ([1-4])")]
        public void SetTheMultiTonePlayToOff(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneChannelPlay(awg, AwgMultiToneGroup.BoolState.Off);
        }

        [When(@"I get the MultiTone play after compile setting for AWG ([1-4])")]
        public void GetTheMultiTonePlayState(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.GetMultiToneChannelPlay(awg);
        }

        [Then(@"the MultiTone play after compile setting should be on for AWG ([1-4])")]
        public void ThenTheMultiTonePlayStateShouldBeOn(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.MultiToneChannelPlayShouldBe(awg, AwgMultiToneGroup.BoolState.On);
        }

        [Then(@"the MultiTone play after compile setting should be off for AWG ([1-4])")]
        public void ThenTheMultiTonePlayStateShouldBeOff(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.MultiToneChannelPlayShouldBe(awg, AwgMultiToneGroup.BoolState.Off);
        }

        #endregion

        #region MTONe:COMPile:SRATe[?]

        [When(@"I set the MultiTone signal sampling rate to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) Hz for AWG ([1-4])")]
        public void SetTheMultiToneSignalSampleRateTo(string value, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneSamplingRate(awg, AwgMultiToneGroup.NumericEntryAs.Value, value);
        }

        [When(@"I set the MultiTone signal sampling rate to the lowest possible value for AWG ([1-4])")]
        public void SetTheMultiToneSignalSampleRateToMin(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneSamplingRate(awg, AwgMultiToneGroup.NumericEntryAs.Min, "");
        }

        [When(@"I set the MultiTone signal sampling rate to the highest possible value for AWG ([1-4])")]
        public void SetTheMultiToneSignalSampleRateToMax(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneSamplingRate(awg, AwgMultiToneGroup.NumericEntryAs.Max, "");
        }

        [When(@"I get the MultiTone signal sample rate for AWG ([1-4])")]
        public void GetTheMultiToneSampleRate(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.GetMultiToneSamplingRate(awg);
        }

        [Then(@"the MultiTone signal sample rate should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) Hz for AWG ([1-4])")]
        public void ThenTheMultiToneSampleRateShouldBe(string value, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.MultiToneSamplingRateShouldBe(awg, value);
        }

        #endregion

        #region MTONe:COMPile:SRATe:AUTO[?]

        [When(@"I set the MultiTone compilation settings to automatically calculate sample rate for AWG ([1-4])")]
        public void SetTheMultiToneAutoSRToOn(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneAutoSamplingRate(awg, AwgMultiToneGroup.BoolState.On);
        }

        [When(@"I set the MultiTone compilation settings to not automatically calculate sample rate for AWG ([1-4])")]
        public void SetTheMultiToneAutoSRToOff(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneAutoSamplingRate(awg, AwgMultiToneGroup.BoolState.Off);
        }

        [When(@"I get the MultiTone Auto sample rate compile setting for AWG ([1-4])")]
        public void GetTheMultiToneAutoSR(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.GetMultiToneAutoSamplingRate(awg);
        }

        [Then(@"the MultiTone auto sample rate compile setting should be on for AWG ([1-4])")]
        public void ThenTheMultiToneAutoSRShouldBeOn(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.MultiToneSamplingRateAutoShouldBe(awg, AwgMultiToneGroup.BoolState.On);
        }

        [Then(@"the MultiTone auto sample rate compile setting should be off for AWG ([1-4])")]
        public void ThenTheMultiToneAutoSRShouldBeOff(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.MultiToneSamplingRateAutoShouldBe(awg, AwgMultiToneGroup.BoolState.Off);
        }

        #endregion

        #region MTONe:TONes:STARt[?]

        [When(@"I set the MultiTone tones start frequency to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) Hz for AWG ([1-4])")]
        public void SetTheMultiToneStartFreqTo(string value, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneToneStart(awg, AwgMultiToneGroup.NumericEntryAs.Value, value);
        }

        [When(@"I set the MultiTone tones start frequency to the lowest possible value for AWG ([1-4])")]
        public void SetTheMultiToneStartFreqToMin(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneToneStart(awg, AwgMultiToneGroup.NumericEntryAs.Min, "");
        }

        [When(@"I set the MultiTone tones start frequency to the highest possible value for AWG ([1-4])")]
        public void SetTheMultiToneStartFreqToMax(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneToneStart(awg, AwgMultiToneGroup.NumericEntryAs.Max, "");
        }

        [When(@"I get the MultiTone tones start frequency for AWG ([1-4])")]
        public void GetTheMultiToneStartFreq(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.GetMultiToneToneStart(awg);
        }

        [Then(@"the MultiTone tones start frequency should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) Hz for AWG ([1-4])")]
        public void ThenTheMultiToneStartFreqShouldBe(string value, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.MultiToneToneStartShouldBe(awg, value);
        }

        #endregion

        #region MTONe:TONes:END[?]

        [When(@"I set the MultiTone tones end frequency to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) Hz for AWG ([1-4])")]
        public void SetTheMultiToneEndFreqTo(string value, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneToneEnd(awg, AwgMultiToneGroup.NumericEntryAs.Value, value);
        }

        [When(@"I set the MultiTone tones end frequency to the lowest possible value for AWG ([1-4])")]
        public void SetTheMultiToneEndFreqToMin(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneToneEnd(awg, AwgMultiToneGroup.NumericEntryAs.Min, "");
        }

        [When(@"I set the MultiTone tones end frequency to the highest possible value for AWG ([1-4])")]
        public void SetTheMultiToneEndFreqToMax(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneToneEnd(awg, AwgMultiToneGroup.NumericEntryAs.Max, "");
        }

        [When(@"I get the MultiTone tones end frequency for AWG ([1-4])")]
        public void GetTheMultiToneEndFreq(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.GetMultiToneToneEnd(awg);
        }

        [Then(@"the MultiTone tones end frequency should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) Hz for AWG ([1-4])")]
        public void ThenTheMultiToneEndFreqShouldBe(string value, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.MultiToneToneEndShouldBe(awg, value);
        }

        #endregion

        #region MTONe:TONes:SPACing[?]

        [When(@"I set the MultiTone tones spacing to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) Hz for AWG ([1-4])")]
        public void SetTheMultiToneSpacingFreqTo(string value, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneToneSpacing(awg, AwgMultiToneGroup.NumericEntryAs.Value, value);
        }

        [When(@"I set the MultiTone tones spacing to the lowest possible value for AWG ([1-4])")]
        public void SetTheMultiToneSpacingFreqToMin(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneToneSpacing(awg, AwgMultiToneGroup.NumericEntryAs.Min, "");
        }

        [When(@"I set the MultiTone tones spacing to the highest possible value for AWG ([1-4])")]
        public void SetTheMultiToneSpacingFreqToMax(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneToneSpacing(awg, AwgMultiToneGroup.NumericEntryAs.Max, "");
        }

        [When(@"I get the MultiTone tones spacing for AWG ([1-4])")]
        public void GetTheMultiToneSpacingFreq(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.GetMultiToneToneSpacing(awg);
        }

        [Then(@"the MultiTone tones spacing should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) Hz for AWG ([1-4])")]
        public void ThenTheMultiToneSpacingFreqShouldBe(string value, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.MultiToneToneSpacingShouldBe(awg, value);
        }

        #endregion

        #region MTONe:TONes:NTONes[?]

        [When(@"I set the MultiTone number of Tones to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for AWG ([1-4])")]
        public void SetTheMultiToneNTonesTo(string value, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneToneNTones(awg, AwgMultiToneGroup.NumericEntryAs.Value, value);
        }

        [When(@"I set the MultiTone number of Tones to the lowest possible value for AWG ([1-4])")]
        public void SetTheMultiToneNTonesToMin(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneToneNTones(awg, AwgMultiToneGroup.NumericEntryAs.Min, "");
        }

        [When(@"I set the MultiTone number of Tones to the highest possible value for AWG ([1-4])")]
        public void SetTheMultiToneNTonesToMax(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneToneNTones(awg, AwgMultiToneGroup.NumericEntryAs.Max, "");
        }

        [When(@"I get the MultiTone number of Tones for AWG ([1-4])")]
        public void GetTheMultiToneNTones(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.GetMultiToneToneNTones(awg);
        }

        [Then(@"the MultiTone number of Tones should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for AWG ([1-4])")]
        public void ThenTheMultiToneNTonesShouldBe(string value, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.MultiToneToneNumTonesShouldBe(awg, value);
        }

        #endregion

        #region MTONe:TONes:PHASe[?]

        [When(@"I set the MultiTone tones phase to Random for AWG ([1-4])")]
        public void SetTheMultiTonePhaseToRandom(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneTonePhase(awg, AwgMultiToneGroup.TonePhaseType.Random);
        }

        [When(@"I set the MultiTone tones phase to Newman for AWG ([1-4])")]
        public void SetTheMultiTonePhaseToNewman(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneTonePhase(awg, AwgMultiToneGroup.TonePhaseType.Newman);
        }

        [When(@"I set the MultiTone tones phase to User Defined for AWG ([1-4])")]
        public void SetTheMultiTonePhaseToUserDefined(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneTonePhase(awg, AwgMultiToneGroup.TonePhaseType.UserDefined);
        }


        [When(@"I get the MultiTone tones phase for AWG ([1-4])")]
        public void GetTheMultiTonePhase(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.GetMultiToneTonePhase(awg);
        }


        [Then(@"the MultiTone tone phase should be Random for AWG ([1-4])")]
        public void ThenTheMultiTonePhaseShouldBeRandom(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.MultiToneTonePhaseShouldBe(awg, AwgMultiToneGroup.TonePhaseType.Random);
        }

        [Then(@"the MultiTone tone phase should be Newman for AWG ([1-4])")]
        public void ThenTheMultiTonePhaseShouldBeNewman(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.MultiToneTonePhaseShouldBe(awg, AwgMultiToneGroup.TonePhaseType.Newman);
        }

        [Then(@"the MultiTone tone phase should be User Defined for AWG ([1-4])")]
        public void ThenTheMultiTonePhaseShouldBeUserDefined(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.MultiToneTonePhaseShouldBe(awg, AwgMultiToneGroup.TonePhaseType.UserDefined);
        }

        #endregion

        #region MTONe:TONes:PHASe:UDEFined[?]

        [When(@"I set the MultiTone tones user defined phase to ((?<!\S)[-+]?\d+(?!\S)) degrees for AWG ([1-4])")]
        public void SetTheMultiToneUserDefinedPhaseTo(string value, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneTonePhaseUserDefined(awg, AwgMultiToneGroup.NumericEntryAs.Value, value);
        }

        [When(@"I set the MultiTone tones user defined phase to the lowest possible value for AWG ([1-4])")]
        public void SetTheMultiToneUserDefinedPhaseToMin(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneTonePhaseUserDefined(awg, AwgMultiToneGroup.NumericEntryAs.Min, "");
        }

        [When(@"I set the MultiTone tones user defined phase to the highest possible value for AWG ([1-4])")]
        public void SetTheMultiToneUserDefinedPhaseToMax(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneTonePhaseUserDefined(awg, AwgMultiToneGroup.NumericEntryAs.Max, "");
        }

        [When(@"I get the MultiTone tones user defined phase for AWG ([1-4])")]
        public void GetTheMultiToneUserDefinedPhase(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.GetMultiToneTonePhaseUserDefined(awg);
        }

        [Then(@"the MultiTone tones user defined phase should be ((?<!\S)[-+]?\d+(?!\S)) degrees for AWG ([1-4])")]
        public void ThenTheMultiToneUserDefinedPhaseShouldBe(string value, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.MultiToneTonePhaseUserDefinedShouldBe(awg, value);
        }

        #endregion

        #region MTONe:TONes:NOTCh:ADD

        [When(@"I add a MultiTone tone notch with a start frequency of ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) Hz and an end frequency of ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) Hz for AWG ([1-4])")]
        public void AddMultiToneNotch(string startValue, string endValue, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneToneNotchAdd(awg, AwgMultiToneGroup.NumericEntryAs.Value, startValue,
                AwgMultiToneGroup.NumericEntryAs.Value, endValue);
        }

        [When(@"I add a MultiTone tone notch with the lowest possible values for start and end for AWG ([1-4])")]
        public void AddMultiToneNotchMin(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneToneNotchAdd(awg, AwgMultiToneGroup.NumericEntryAs.Min, "",
                AwgMultiToneGroup.NumericEntryAs.Min, "");
        }

        [When(@"I add a MultiTone tone notch with the highest possible values for start and end for AWG ([1-4])")]
        public void AddMultiToneNotchMax(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneToneNotchAdd(awg, AwgMultiToneGroup.NumericEntryAs.Max, "",
                AwgMultiToneGroup.NumericEntryAs.Max, "");
        }
        
        #endregion

        #region MTONe:TONes:NOTCh:ENABle[?]

        [When(@"I enable notches for MultiTone tones for AWG ([1-4])")]
        public void SetTheMultiToneNotchesToOn(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneToneNotchEnable(awg, AwgMultiToneGroup.BoolState.On);
        }

        [When(@"I disable notches for MultiTone tones for AWG ([1-4])")]
        public void SetTheMultiToneNotchesToOff(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneToneNotchEnable(awg, AwgMultiToneGroup.BoolState.Off);
        }

        [When(@"I get the MultiTone tone notch enable setting for AWG ([1-4])")]
        public void GetTheMultiToneNotchEnableState(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.GetMultiToneToneNotchEnable(awg);
        }

        [Then(@"the MultiTone tone notch enable setting should be on for AWG ([1-4])")]
        public void ThenTheMultiToneNotchEnableShouldBeOn(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.MultiToneToneNotchEnableShouldBe(awg, AwgMultiToneGroup.BoolState.On);
        }

        [Then(@"the MultiTone tone notch enable setting should be off for AWG ([1-4])")]
        public void ThenTheMultiToneNotchEnableShouldBeOff(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.MultiToneToneNotchEnableShouldBe(awg, AwgMultiToneGroup.BoolState.Off);
        }

        #endregion

        #region MTONe:TONes:NOTCh[?]

        [When(@"I set MultiTone tone notch ([1-9]|1[0-6]) with a start frequency of ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) Hz and an end frequency of ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) Hz for AWG ([1-4])")]
        public void SetMultiToneNotch(string notchNumber, string startValue, string endValue, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneToneNotch(awg, AwgMultiToneGroup.NumericEntryAs.Value, startValue,
                AwgMultiToneGroup.NumericEntryAs.Value, endValue, notchNumber);
        }

        [When(@"I set MultiTone tone notch ([1-9]|1[0-6]) with the lowest possible values for start and end for AWG ([1-4])")]
        public void SetMultiToneNotchMin(string notchNumber, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneToneNotchAdd(awg, AwgMultiToneGroup.NumericEntryAs.Min, "",
                AwgMultiToneGroup.NumericEntryAs.Min, "");
        }

        [When(@"I set MultiTone tone notch ([1-9]|1[0-6]) with the highest possible values for start and end for AWG ([1-4])")]
        public void SetMultiToneNotchMax(string notchNumber, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneToneNotchAdd(awg, AwgMultiToneGroup.NumericEntryAs.Max, "",
                AwgMultiToneGroup.NumericEntryAs.Max, "");
        }

        [When(@"I get the MultiTone tones notch ([1-9]|1[0-6]) start and end frequency for AWG ([1-4])")]
        public void GetTheMultiToneNotchStartEndFreq(string notchNumber, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.GetMultiToneToneNotch(awg, notchNumber);
        }

        [Then(@"the MultiTone tones notch start frequency should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) Hz and the end frequency should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) Hz for AWG ([1-4])")]
        public void ThenTheMultiToneNotchFreqShouldBe(string startValue, string endValue, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.MultiToneNotchShouldBe(awg, startValue, endValue);
        }

        #endregion

        #region MTONe:TONes:NOTCh:STARt[?]

        [When(@"I set MultiTone tone notch ([1-9]|1[0-6]) with a start frequency of ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) Hz for AWG ([1-4])")]
        public void SetMultiToneNotchStart(string notchNumber, string startValue, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneToneNotchStart(awg, AwgMultiToneGroup.NumericEntryAs.Value, startValue,
                notchNumber);
        }

        [When(@"I set MultiTone tone notch ([1-9]|1[0-6]) with the lowest possible values for start frequency for AWG ([1-4])")]
        public void SetMultiToneNotchStartMin(string notchNumber, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneToneNotchStart(awg, AwgMultiToneGroup.NumericEntryAs.Min, "",
                notchNumber);
        }

        [When(@"I set MultiTone tone notch ([1-9]|1[0-6]) with the highest possible values for start frequency for AWG ([1-4])")]
        public void SetMultiToneNotchStartMax(string notchNumber, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneToneNotchStart(awg, AwgMultiToneGroup.NumericEntryAs.Max, "",
                notchNumber);
        }

        [When(@"I get the MultiTone tones notch ([1-9]|1[0-6]) start frequency for AWG ([1-4])")]
        public void GetTheMultiToneNotchStartFreq(string notchNumber, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.GetMultiToneToneNotchStart(awg, notchNumber);
        }

        [Then(@"the MultiTone tones notch start frequency should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) Hz for AWG ([1-4])")]
        public void ThenTheMultiToneNotchStartFreqShouldBe(string startValue, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.MultiToneNotchStartShouldBe(awg, startValue);
        }

        #endregion

        #region MTONe:TONes:NOTCh:END[?]

        [When(@"I set MultiTone tone notch ([1-9]|1[0-6]) with a end frequency of ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) Hz for AWG ([1-4])")]
        public void SetMultiToneNotchEnd(string notchNumber, string endValue, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneToneNotchEnd(awg, AwgMultiToneGroup.NumericEntryAs.Value, endValue,
                notchNumber);
        }

        [When(@"I set MultiTone tone notch ([1-9]|1[0-6]) with the lowest possible values for end frequency for AWG ([1-4])")]
        public void SetMultiToneNotchEndMin(string notchNumber, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneToneNotchEnd(awg, AwgMultiToneGroup.NumericEntryAs.Min, "",
                notchNumber);
        }

        [When(@"I set MultiTone tone notch ([1-9]|1[0-6]) with the highest possible values for end frequency for AWG ([1-4])")]
        public void SetMultiToneNotchEndMax(string notchNumber, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneToneNotchEnd(awg, AwgMultiToneGroup.NumericEntryAs.Max, "",
                notchNumber);
        }

        [When(@"I get the MultiTone tones notch ([1-9]|1[0-6]) end frequency for AWG ([1-4])")]
        public void GetTheMultiToneNotchEndFreq(string notchNumber, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.GetMultiToneToneNotchEnd(awg, notchNumber);
        }

        [Then(@"the MultiTone tones notch end frequency should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) Hz for AWG ([1-4])")]
        public void ThenTheMultiToneNotchEndFreqShouldBe(string endValue, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.MultiToneNotchEndShouldBe(awg, endValue);
        }

        #endregion

        #region MTONe:TONes:NOTCh:DELete

        [When(@"I delete MultiTone tone notch ([1-9]|1[0-6]) for AWG ([1-4])")]
        public void DeleteMultiToneNotch(string notchNumber, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.DeleteMultiToneToneNotch(awg, AwgMultiToneGroup.DeleteEntryAs.Value, notchNumber);
        }

        [When(@"I delete all MultiTone tone notches for AWG ([1-4])")]
        public void DeleteAllMultiToneNotches(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.DeleteMultiToneToneNotch(awg, AwgMultiToneGroup.DeleteEntryAs.All, "1");
        }

        #endregion

        #region MTONe:TONes:NOTCh:COUNt?
        
        [When(@"I get the MultiTone tones notch count for AWG ([1-4])")]
        public void GetTheMultiToneNotchCount(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.GetMultiToneToneNotchCount(awg);
        }

        [Then(@"the MultiTone tones notch count should be ([0-9]|1[0-6]) for AWG ([1-4])")]
        public void ThenTheMultiToneNotchCountShouldBe(string value, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.MultiToneNotchCountShouldBe(awg, value);
        }

        #endregion

        #region MTONe:CHIRp:LOW[?]

        [When(@"I set the MultiTone chirp low frequency to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) Hz for AWG ([1-4])")]
        public void SetTheMultiToneChirpLowTo(string value, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneChirpLow(awg, AwgMultiToneGroup.NumericEntryAs.Value, value);
        }

        [When(@"I set the MultiTone chirp low frequency to the lowest possible value for AWG ([1-4])")]
        public void SetTheMultiToneChirpLowToMin(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneChirpLow(awg, AwgMultiToneGroup.NumericEntryAs.Min, "");
        }

        [When(@"I set the MultiTone chirp low frequency to the highest possible value for AWG ([1-4])")]
        public void SetTheMultiToneChirpLowToMax(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneChirpLow(awg, AwgMultiToneGroup.NumericEntryAs.Max, "");
        }

        [When(@"I get the MultiTone chirp low frequency for AWG ([1-4])")]
        public void GetTheMultiToneChirpLow(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.GetMultiToneChirpLow(awg);
        }

        [Then(@"the MultiTone chirp low frequency should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) Hz for AWG ([1-4])")]
        public void ThenTheMultiToneChirpLowShouldBe(string value, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.MultiToneChirpLowShouldBe(awg, value);
        }

        #endregion

        #region MTONe:CHIRp:HIGH[?]

        [When(@"I set the MultiTone chirp high frequency to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) Hz for AWG ([1-4])")]
        public void SetTheMultiToneChirpHighTo(string value, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneChirpHigh(awg, AwgMultiToneGroup.NumericEntryAs.Value, value);
        }

        [When(@"I set the MultiTone chirp high frequency to the lowest possible value for AWG ([1-4])")]
        public void SetTheMultiToneChirpHighToMin(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneChirpHigh(awg, AwgMultiToneGroup.NumericEntryAs.Min, "");
        }

        [When(@"I set the MultiTone chirp high frequency to the highest possible value for AWG ([1-4])")]
        public void SetTheMultiToneChirpHighToMax(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneChirpHigh(awg, AwgMultiToneGroup.NumericEntryAs.Max, "");
        }

        [When(@"I get the MultiTone chirp high frequency for AWG ([1-4])")]
        public void GetTheMultiToneChirpHigh(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.GetMultiToneChirpHigh(awg);
        }

        [Then(@"the MultiTone chirp high frequency should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) Hz for AWG ([1-4])")]
        public void ThenTheMultiToneChirpHighShouldBe(string value, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.MultiToneChirpHighShouldBe(awg, value);
        }

        #endregion

        #region MTONe:CHIRp:SRATe[?]

        [When(@"I set the MultiTone chirp sweep rate to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) Hz/uSec for AWG ([1-4])")]
        public void SetTheMultiToneChirpSweepRateTo(string value, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneChirpSweepRate(awg, AwgMultiToneGroup.NumericEntryAs.Value, value);
        }

        [When(@"I set the MultiTone chirp sweep rate to the lowest possible value for AWG ([1-4])")]
        public void SetTheMultiToneChirpSweepRateToMin(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneChirpSweepRate(awg, AwgMultiToneGroup.NumericEntryAs.Min, "");
        }

        [When(@"I set the MultiTone chirp sweep rate to the highest possible value for AWG ([1-4])")]
        public void SetTheMultiToneChirpSweepRateToMax(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneChirpSweepRate(awg, AwgMultiToneGroup.NumericEntryAs.Max, "");
        }

        [When(@"I get the MultiTone chirp sweep rate for AWG ([1-4])")]
        public void GetTheMultiToneChirpSweepRate(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.GetMultiToneChirpSweepRate(awg);
        }

        [Then(@"the MultiTone chirp sweep rate should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) Hz/uSec for AWG ([1-4])")]
        public void ThenTheMultiToneChirpSweepRateShouldBe(string value, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.MultiToneChirpSweepRateShouldBe(awg, value);
        }

        #endregion

        #region MTONe:CHIRp:STIMe[?]

        [When(@"I set the MultiTone chirp sweep time to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) Sec for AWG ([1-4])")]
        public void SetTheMultiToneChirpSweepTimeTo(string value, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneChirpSweepTime(awg, AwgMultiToneGroup.NumericEntryAs.Value, value);
        }

        [When(@"I set the MultiTone chirp sweep time to the lowest possible value for AWG ([1-4])")]
        public void SetTheMultiToneChirpSweepTimeToMin(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneChirpSweepTime(awg, AwgMultiToneGroup.NumericEntryAs.Min, "");
        }

        [When(@"I set the MultiTone chirp sweep time to the highest possible value for AWG ([1-4])")]
        public void SetTheMultiToneChirpSweepTimeToMax(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneChirpSweepTime(awg, AwgMultiToneGroup.NumericEntryAs.Max, "");
        }

        [When(@"I get the MultiTone chirp sweep time for AWG ([1-4])")]
        public void GetTheMultiToneChirpSweepTime(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.GetMultiToneChirpSweepTime(awg);
        }

        [Then(@"the MultiTone chirp sweep time should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) Sec for AWG ([1-4])")]
        public void ThenTheMultiToneChirpSweepTimeShouldBe(string value, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.MultiToneChirpSweepTimeShouldBe(awg, value);
        }

        #endregion

        #region MTONe:CHIRp:FSWeep[?]

        [When(@"I set the MultiTone chirp frequency to sweep from low to high for AWG ([1-4])")]
        public void SetTheMultiToneChirpFrequencySweepToLHigh(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneChirpFrequencySweep(awg, AwgMultiToneGroup.ChirpFrequencySweep.LowHigh);
        }

        [When(@"I set the MultiTone chirp frequency to sweep from high to low for AWG ([1-4])")]
        public void SetTheMultiToneChirpFrequencySweepToHLow(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.SetMultiToneChirpFrequencySweep(awg, AwgMultiToneGroup.ChirpFrequencySweep.HighLow);
        }

        [When(@"I get the MultiTone frequency sweep for AWG ([1-4])")]
        public void GetTheMultiToneChirpFrequencySweep(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.GetMultiToneFrequencySweep(awg);
        }

        [Then(@"the MultiTone chirp frequency should sweep from low to high for AWG ([1-4])")]
        public void ThenTheMultiToneChirpFrequencySweepShouldBeLHigh(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.MultiToneFrequencySweepShouldBe(awg, AwgMultiToneGroup.ChirpFrequencySweep.LowHigh);
        }


        [Then(@"the MultiTone chirp frequency should sweep from high to low for AWG ([1-4])")]
        public void ThenTheMultiToneChirpFrequencySweepShouldBeHLow(string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgMultiToneGroup.MultiToneFrequencySweepShouldBe(awg, AwgMultiToneGroup.ChirpFrequencySweep.HighLow);
        }

        #endregion

        #endregion MultiTone
    }
}
