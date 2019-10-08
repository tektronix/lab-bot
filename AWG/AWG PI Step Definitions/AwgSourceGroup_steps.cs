//==========================================================================
// AwgSourceGroupLow_steps.cs
// This file contains the low-order PI step definitions for the AWG PI Source Group commands. 
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
// AWG number - (?: the)?? AWG(\d?) NOTE: if the statement is like: "Then AWG2 should...", you must delete the leading space in from of the AWG part of the matcher
// File path strings - ""(.+)"" all path strings must be delineated by quotes in step definitions! 
//==========================================================================

using TechTalk.SpecFlow;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains the PI step definitions for the %AWG PI Source Group commands.

    /// Generally the steps are set, get and should be operations.  The step sole responsibility
    /// is to make sure the correct %AWG object is used and that parameters such as channel,
    /// markers and clock references are correct for the %AWG object.
    /// 
    /// \ingroup highpi pisteps 
    /// </summary>
    [Binding] //Veeerrry important! This entry needs to be made in each step definition file.
    public class AwgSourceSteps 
    {
        private readonly UTILS.Converter _converter = new UTILS.Converter();
        private readonly AwgSourceGroup _awgSourceGroup = new AwgSourceGroup();
        private readonly UtilitiesGroup _utilitiesGroup = new UtilitiesGroup();


        #region SOURce[n]:CASSet

        //glennj 8/23/2013
        /// <summary>
        /// Get the name of the assigned asset of a channel on an Awg
        /// </summary>
        /// <param name="channelNumber"></param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [When(@"I get the assigned asset for channel ([1-4]) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the assigned asset for channel ([1-4]) on AWG ([1-4])")]
        public void GetTheAssignedAssetForChannel(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.GetTheSourceChannelAsset(awg, channelNumber);
        }

        //glennj 8/23/2013
        /// <summary>
        /// Check the asset name on a channel of an Awg
        /// </summary>
        /// <param name="channelNumber"></param>
        /// <param name="expectedAssetName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [Then(@"the assigned asset for channel ([1-4]) should be ""(.+)"" on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the assigned asset for channel ([1-4]) should be ""(.+)"" on AWG ([1-4])")]
        public void TheAssignedAssetForChannelShouldBe(string channelNumber, string expectedAssetName, string awgNumber)
        {

            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SourceChannelAssetNameShouldBe(awg, channelNumber, expectedAssetName);
        }

        #endregion SOURce[n]:CASSet

        #region SOURce[n]:CASSet:SEQuence

        //glennj 8/23/2013
        /// <summary>
        /// Assign to a channel a track of a sequence on an Awg
        /// </summary>
        /// <param name="trackNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="channelNumber"></param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [When(@"I set the assigned asset to track (\d+) of the sequence ""(.+)"" for channel ([1-4]) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the assigned asset to track (\d+) of the sequence ""(.+)"" for channel ([1-4]) on AWG ([1-4])")]
        public void SetTheAssignedAssetToTrackOfTheSequenceForChannel(string trackNumber, string seqName,
                                                                      string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SetSourceChannelAssetSequence(awg, channelNumber, seqName, trackNumber);
        }

        #endregion SOURce[n]:CASSet:SEQuence

        #region SOURce[n]:CASSet:TYPE

        //glennj 8/23/2013
        /// <summary>
        /// Get the type of the asset assigned to a channel on an Awg
        /// </summary>
        /// <param name="channelNumber"></param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [When(@"I get the type of the assigned asset for channel ([1-4]) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the type of the assigned asset for channel ([1-4]) on AWG ([1-4])")]
        public void GetTheTypeOfTheAssignedAssetForChannel(string channelNumber, string awgNumber)
        {

            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.GetSourceChannelAssetType(awg, channelNumber);
        }

        //glennj 8/23/2013
        /// <summary>
        /// The assigned asset type of a channel on an Awg should be a sequence type, SEQ
        /// </summary>
        /// <param name="channelNumber"></param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [Then(@"the type of the assigned asset for channel ([1-4]) should be sequence on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the type of the assigned asset for channel ([1-4]) should be sequence on AWG ([1-4])")]
        public void TheTypeOfTheAssignedAssetForChannelShouldBeSeq(string channelNumber, string awgNumber)
        {

            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SourceChannelAssetTypeShouldBe(awg, channelNumber, AwgSourceGroup.SourceAssetType.Seq);
        }

        //glennj 8/23/2013
        /// <summary>
        /// The assigned asset type of a channel on an Awg should be a waveform type, WAV
        /// </summary>
        /// <param name="channelNumber"></param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [Then(@"the type of the assigned asset for channel ([1-4]) should be waveform on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the type of the assigned asset for channel ([1-4]) should be waveform on AWG ([1-4])")]
        public void TheTypeOfTheAssignedAssetForChannelShouldBeWav(string channelNumber, string awgNumber)
        {

            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SourceChannelAssetTypeShouldBe(awg, channelNumber, AwgSourceGroup.SourceAssetType.Wav);
        }

        //glennj 8/23/2013
        /// <summary>
        /// The assigned asset type of a channel on an Awg should be none
        /// </summary>
        /// <param name="channelNumber"></param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [Then(@"the type of the assigned asset for channel ([1-4]) should be none on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the type of the assigned asset for channel ([1-4]) should be none on AWG ([1-4])")]
        public void TheTypeOfTheAssignedAssetForChannelShouldBeNone(string channelNumber, string awgNumber)
        {

            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SourceChannelAssetTypeShouldBe(awg, channelNumber, AwgSourceGroup.SourceAssetType.None);
        }

        #endregion SOURce[n]:CASSet:TYPE

        #region SOURce[n]:CASSet:WAVeform

        //glennj 8/23/2013
        /// <summary>
        /// Assign to a channel a waveform on an Awg
        /// </summary>
        /// <param name="wfmName"></param>
        /// <param name="channelNumber"></param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [When(@"I set the assigned asset to the waveform ""(.+)"" for channel ([1-4]) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the assigned asset to the waveform ""(.+)"" for channel ([1-4]) on AWG ([1-4])")]
        public void SetTheAssignedAssetToWaveformForChannel(string wfmName, string channelNumber, string awgNumber)
        {

            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SetSourceChannelAssetWaveform(awg, channelNumber, wfmName);
        }

        #endregion SOURce[n]:CASSet:WAVeform

        #region SOURce:DAC:RESolution
        //Jhowells 6-12-12
        //glennj 9/9/2013, added 9 bit support
        //jmanning 03/27/2014
        /// <summary>
        /// Sets the DAC resolution to 8 bits on specified channel on specified AWG.
        /// 
        /// [SOURce[n]]:?DAC:?RESolution
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \source\verbatim
        [When(@"I set the source DAC resolution value to 8 bits for channel ([1-4]) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the source DAC resolution value to 8 bits for channel ([1-4]) on AWG ([1-4])")]
        public void SetTheAwgDacResolution8Bit( string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            const string resolution = "8";
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SetDACResolution(awg, channelNumber, resolution);
        }

        //Jhowells 6-12-12
        //glennj 9/9/2013, added 9 bit support
        //jmanning 03/27/2014
        /// <summary>
        /// Sets the DAC resolution to 9 bits on specified channel on specified AWG.
        /// 
        /// [SOURce[n]]:?DAC:?RESolution
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \source\verbatim
        [When(@"I set the source DAC resolution value to 9 bits for channel ([1-4]) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the source DAC resolution value to 9 bits for channel ([1-4]) on AWG ([1-4])")]
        public void SetTheAwgDacResolution9Bit(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            const string resolution = "9";
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SetDACResolution(awg, channelNumber, resolution);
        }

        //Jhowells 6-12-12
        //glennj 9/9/2013, added 9 bit support
        //jmanning 03/27/2014
        /// <summary>
        /// Sets the DAC resolution to 10 bits on specified channel on specified AWG.
        /// 
        /// [SOURce[n]]:?DAC:?RESolution
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \source\verbatim
        [When(@"I set the source DAC resolution value to 10 bits for channel ([1-4]) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the source DAC resolution value to 10 bits for channel ([1-4]) on AWG ([1-4])")]
        public void SetTheAwgDacResolution10Bit(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            const string resolution = "10";
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SetDACResolution(awg, channelNumber, resolution);
        }

        //Jhowells 6-12-12
        //glennj 9/9/2013, added 9 bit support
        //jmanning 03/27/2014
        /// <summary>
        /// Sets the DAC resolution to 10 bits on specified channel on specified AWG.
        /// 
        /// [SOURce[n]]:?DAC:?RESolution
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /// <param name="resolution">resolution bit value</param>
        /*!
            \source\verbatim
        [When(@"I set the source DAC resolution value to 10 bits for channel ([1-4]) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the DAC resolution value to (8|9|10) bits for channel ([1-4]) on AWG ([1-4])")]
        public void SetTheAwgDacResolutionBit(string resolution, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SetDACResolution(awg, channelNumber, resolution);
        }
        
        // Kavitha : Added default statement which was missing for the case statement
        //Jhowells 6-12-12
        //jmanning 03/27/2014
        /// <summary>
        /// Gets the DAC resolution.
        /// 
        /// [SOURce[n]]:?DAC:?RESolution
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \source\verbatim
        [When(@"I get the DAC resolution for channel ([1-4]) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the DAC resolution for channel ([1-4]) on AWG ([1-4])")]
        public void GetTheDacResolutionValue(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.GetDACResolution(awg, channelNumber);
        }

        //Jhowells 6-12-12
        //jmanning 03/27/2014
        /// <summary>
        /// Compares the DAC resolution against the expected value of 8 bits.
        /// [SOURce[n]]:?DAC:?RESolution
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \source\verbatim
        [Then(@"the DAC resolution bit value should be 8 for channel ([1-4]) on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the DAC resolution bit value should be 8 for channel ([1-4]) on AWG ([1-4])")]
        public void TheAwgDacResolutionBitValueShouldBe8(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            const string expectedResolution = "8";
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SourceDacResolutionShouldBe(awg, channelNumber, expectedResolution);
        }

        //Jhowells 6-12-12
        //jmanning 03/27/2014
        /// <summary>
        /// Compares the DAC resolution against the expected value of 9 bits.
        /// [SOURce[n]]:?DAC:?RESolution
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \source\verbatim
        [Then(@"the DAC resolution bit value should be 9 for channel ([1-4]) on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the DAC resolution bit value should be 9 for channel ([1-4]) on AWG ([1-4])")]
        public void TheAwgDacResolutionBitValueShouldBe9(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            const string expectedResolution = "9";
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SourceDacResolutionShouldBe(awg, channelNumber, expectedResolution);
        }

        //Jhowells 6-12-12
        //jmanning 03/27/2014
        /// <summary>
        /// Compares the DAC resolution against the expected value of 10 bits.
        /// [SOURce[n]]:?DAC:?RESolution
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \source\verbatim
        [Then(@"the DAC resolution bit value should be 10 for channel ([1-4]) on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the DAC resolution bit value should be 10 for channel ([1-4]) on AWG ([1-4])")]
        public void TheAwgDacResolutionBitValueShouldBe10(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            const string expectedResolution = "10";
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SourceDacResolutionShouldBe(awg, channelNumber, expectedResolution);
        }
        #endregion SOURce:DAC:RESolution

        #region SOURce:POWer:AMPLitude
        ///  <summary>
        ///  Sets the default AWG source amplitude by unit for the channel
        /// 
        ///  Sets the default AWG source amplitude for channel 1,2,3 or 4 to a value of dBm
        ///  [SOURce[n]]:POWer[:LEVel][:IMMediate][:AMPLitude]
        ///  </summary>
        ///  <param name="setValue">Source Power Amplitude value</param>
        /// <param name="units"></param>
        ///  <param name="channelNumber">Which %AWG channel 1|2|3|4</param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [When(@"I set the source amplitude to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?)dBm for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the source amplitude to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?)dBm for channel ([1-4]) for AWG ([1-4])")]
        public void SetSourcePowerAmplitudeInDBMs(string setValue, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SetSourcePowerAmplitude(awg, channelNumber, AwgSourceGroup.SourcePowerAmplitude.Nr1, setValue);
        }
        //shkv 1/8/2015 Modified the When statement to match with the test case
        // Maximum in not being tested

        [When(@"I set the source dBm amplitude to maximum for channel ([1-4]) for AWG ([1-4])")]
        public void SetSourceDMBAmplitudeToMax(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SetSourcePowerAmplitude(awg, channelNumber, AwgSourceGroup.SourcePowerAmplitude.Max);
        }
        //shkv 1/8/2015 Modified the When statement to match with the test case
        // Minimum in not being tested

        [When(@"I set the source dBm amplitude to minimum for channel ([1-4]) for AWG ([1-4])")]
        public void SetSourcePowerAmplitudeToMin(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SetSourcePowerAmplitude(awg, channelNumber, AwgSourceGroup.SourcePowerAmplitude.Min);
        }

        //shkv 1/8/2015 Modified the When statement to match with the test case
        /// kaylak 11/14/2014
        /// <summary>
        /// Gets the waveform power amplitude for the default AWG
        /// [SOURce[n]]:POWer[:LEVel][:IMMediate][:AMPLitude]
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [When(@"I get the source power amplitude for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the source dBm amplitude for channel ([1-4]) for AWG ([1-4])")]
        public void GetAwgSourcePowerAmplitude(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.GetSourcePowerAmplitude(awg, channelNumber);
        }

        /// kaylak 11/14/2014
        /// <summary>
        /// Compares the default AWG waveform power amplitude against the expected value.
        /// 
        /// [SOURce[n]]:POWer[:LEVel][:IMMediate][:AMPLitude]
        /// </summary>
        /// <param name="expectedValue">Expected waveform power amplitude</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [Then(@"the source amplitude should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?)dBm for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the source amplitude should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?)dBm for channel ([1-4]) for AWG ([1-4])")]
        public void TheAwgSourcePowerAmplitudeValueShouldBe(string expectedValue, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SourcePowerAmplitudeValueShouldBe(awg, channelNumber, expectedValue);
        }
        #endregion SOURce:POWer:AMPLitude

        #region [SOURce[n]]:JUMP:FORCe

        //glennj 8/23/2013
        /// <summary>
        /// Force a running sequence to jump to the beginning of the current step (waveform)                        Not found in any test case
        /// </summary>
        /// <param name="channelNumber"></param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [When(@"I force the sequence to jump to the current step for channel ([1-4]) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I force the sequence to jump to the current step for channel ([1-4]) on AWG ([1-4])")]
        public void ForceTheSequenceToJumpToTheCurrentStepForChannel(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.ForceSourceChannelToJump(awg, channelNumber, AwgSourceGroup.SourceForceJumpType.Current);
        }

        //glennj 8/23/2013
        /// <summary>
        /// Force a running sequence to jump to the beginning of the first step (waveform)
        /// </summary>
        /// <param name="channelNumber"></param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [When(@"I force the sequence to jump to the first step for channel ([1-4]) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I force the sequence to jump to the first step for channel ([1-4]) on AWG ([1-4])")]
        public void ForceTheSequenceToJumpToTheFirstStepForChannel(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.ForceSourceChannelToJump(awg, channelNumber, AwgSourceGroup.SourceForceJumpType.First);
        }

        //glennj 8/23/2013
        /// <summary>
        /// Force a running sequence to jump to the beginning of the last step (waveform)
        /// </summary>
        /// <param name="channelNumber"></param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [When(@"I force the sequence to jump to the last step for channel ([1-4]) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I force the sequence to jump to the last step for channel ([1-4]) on AWG ([1-4])")]
        public void ForceTheSequenceToJumpToTheLastStepForChannel(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.ForceSourceChannelToJump(awg, channelNumber, AwgSourceGroup.SourceForceJumpType.Last);
        }

        //glennj 8/23/2013
        /// <summary>
        /// Force a running sequence to jump to the beginning of the end step (waveform)
        /// </summary>
        /// <param name="channelNumber"></param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [When(@"I force the sequence to jump to the end step for channel ([1-4]) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I force the sequence to jump to the end step for channel ([1-4]) on AWG ([1-4])")]
        public void ForceTheSequenceToJumpToTheEndStepForChannel(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.ForceSourceChannelToJump(awg, channelNumber, AwgSourceGroup.SourceForceJumpType.End);
        }

        //glennj 8/23/2013
        /// <summary>
        /// Force a running sequence to jump to the beginning of an arbitrary step (waveform)
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="channelNumber"></param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [When(@"I force the sequence to jump to step number (\d+) for channel ([1-4]) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I force the sequence to jump to step number (\d+) for channel ([1-4]) on AWG ([1-4])")]
        public void ForceTheSequenceToJumpToTheCurrentStepForChannel(string stepNumber, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.ForceSourceChannelToJump(awg, channelNumber, AwgSourceGroup.SourceForceJumpType.Nr1, stepNumber);
        }

        #endregion [SOURce[n]]:JUMP:FORCe

        #region SOURce:JUMP:PATTern:FORCe

        //glennj 8/26/2013
        /// <summary>
        /// Force a running sequence to jump to with a pattern match
        /// </summary>
        /// <param name="forceJumpPattern"></param>
        /// <param name="channelNumber"></param>
        /// <param name="awgNumber"></param>
        [When(@"I force the sequence to jump to pattern (\d+) for channel ([1-4]) on AWG ([1-4])")]
        public void ForceTheSequenceToJumpToPatternForChannel(string forceJumpPattern, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.ForceSourceChannelJumpPattern(awg, channelNumber, forceJumpPattern);
        }

        #endregion SOURce:JUMP:PATTern:FORCe

        #region SOURce:FREQuency
        // Unknown 01/01/01
        //glennj 7/18/2013 
        //jmanning 03/28/2014
        /// <summary>
        /// Sets the sampling frequency of the %AWG with units
        /// [SOURce[1]]:?FREQuency
        /// </summary>
        /// <param name="channelNumber">In this context it is a channel</param>
        /// <param name="setValue">Sampling Frequency</param>
        /// <param name="units">Which units the sampling frequency is in</param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [When(@"I set the source sampling frequency to ([-+]?(?:[0-9]+(?:\.[0-9]*)?|\.[0-9]+)(?:[eE][-+]?[0-9]+)?)(MHz|GHz) for channel ([1-4]) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the source sampling frequency to ([-+]?(?:[0-9]+(?:\.[0-9]*)?|\.[0-9]+)(?:[eE][-+]?[0-9]+)?)(MHz|GHz) for channel ([1-4]) on AWG ([1-4])")]
        public void SetTheSamplingFrequencyToValueAndUnits(string setValue, string units, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            string valueToSet = setValue + units;
            _awgSourceGroup.SetSourceSampleRate(awg, channelNumber, valueToSet);
        }

        // Unknown 01/01/01
        //glennj 7/18/2013 
        //jmanning 03/28/2014
        /// <summary>
        /// Gets the sampling frequency of the %AWG
        /// [SOURce[1]]:FREQuency?
        /// </summary>
        /// <param name="channelNumber">In this context it is a channel</param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [When(@"I get the AWG([1-4]) sampling frequency")]
            \endverbatim 
        */
        [When(@"I get the source sampling frequency for channel ([1-4]) on AWG ([1-4])")]
        public void GetTheSamplingFrequency(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.GetSourceSampleRate(awg, channelNumber);
        }

        // Unknown 01/01/01
        //glennj 7/18/2013 Note: Since this is legecy support,
        //    consider not having the channel should not be in step defintion.
        //jmanning 03/28/2014
        /// <summary>
        /// Compares the sampling frequency of the %AWG against the expected value.
        /// [SOURce[1]]:?FREQuency
        /// </summary>
        /// <param name="expectedValue">Expected sampling frequency</param>
        /// <param name="awgNumber">AWG number</param>
        /*!
            \source\verbatim
        [Then(@"the source sampling frequency value should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) Hertz on AWG ([1-4])")] 
            \endverbatim 
        */
        [Then(@"the source sampling frequency value should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) Hertz on AWG ([1-4])")]
        // <NR3> matcher
        public void ThenAnAwgSamplingFrequencyValueShouldBe(string expectedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            const string channelNumber = "1";
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SourceSampleRateShouldBe(awg, channelNumber, expectedValue);
        }
        #endregion SOURce:FREQuency

        #region SOURce:MARKer:DELay
        //Jhowells 6-12-12
        //glennj 8/6/2013
        /// <summary>
        /// Sets the marker delay.
        /// [SOURce[n]]:?MARKer[1|2]:?DELay
        /// </summary>
        /// <param name="setValue">Delay value</param>
        /// <param name="markerNumber">Which marker</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \source\verbatim
        [When(@"I set the delay to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the delay to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheMarkerDelay(string setValue, string markerNumber, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, markerNumber);
            _awgSourceGroup.SetSourceMarkerDelay(awg, channelNumber, markerNumber, AwgSourceGroup.SourceMarkerDelay.Nr1, setValue);
        }

        [When(@"I set the delay to max for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheMarkerDelayToMax(string markerNumber, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, markerNumber);
            _awgSourceGroup.SetSourceMarkerDelay(awg, channelNumber, markerNumber, AwgSourceGroup.SourceMarkerDelay.Max);
        }

        [When(@"I set the delay to min for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheMarkerDelayToMin(string markerNumber, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, markerNumber);
            _awgSourceGroup.SetSourceMarkerDelay(awg, channelNumber, markerNumber, AwgSourceGroup.SourceMarkerDelay.Min);
        }

        //Jhowells 6-12-12
        //glennj 8/6/2013
        /// <summary>
        /// Gets the marker delay.
        /// [SOURce[n]]:?MARKer[1|2]:?DELay
        /// </summary>
        /// <param name="channelNumber"></param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /// <param name="markerNumber">Which marker</param>
        /*!
            \source\verbatim
        [When(@"I get the delay for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the delay for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
        public void GetTheMarkerDelay(string markerNumber, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, markerNumber);
            _awgSourceGroup.GetSourceMarkerDelay(awg, channelNumber, markerNumber);
        }

        //Jhowells 6-12-12
        //glennj 8/6/2013
        /// <summary>
        /// Compares the marker delay against the expected value..
        /// [SOURce[n]]:?MARKer[1|2]:?DELay
        /// </summary>
        /// <param name="markerNumber">Which marker</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="expectedDelay">Expected marker delay</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \source\verbatim
        [Then(@"the delay should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the delay should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
        public void TheAwgNMarkerDelayValueShouldBe(string expectedDelay, string markerNumber, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, markerNumber);
            _awgSourceGroup.SourceMarkerDelayShouldBe(awg, channelNumber, markerNumber, expectedDelay);
        }

        #endregion  SOURce:MARKer:DELay

        #region SOURce:MARKer:VOLTage[:LEVel][:IMMediate][:AMPLitude]

        //Jhowells 6-12-12 Step works PI command times out
        //glennj 9/9/2013
        //jmanning 03/27/2014
        /// <summary>
        /// Sets the amplitude of Marker
        /// </summary>
        /// <param name="setValue">Marker amplitude</param>
        /// <param name="markerNumber">Which marker</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \source\verbatim
        [When(@"I set the amplitude for marker ([1-4]) for channel ([1-4]) to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the amplitude to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for marker ([1-4]) for channel ([1-4]) on AWG ([1-4])")]
        public void SetTheSourceMarkerAmplitude(string setValue, string markerNumber, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, markerNumber);
            _awgSourceGroup.SetSourceMarkerAmplitude(awg, channelNumber, markerNumber, AwgSourceGroup.SourceMarkerVoltageImmediateAmplitude.Nr1, setValue);
        }

        //glennj 9/9/2013
        /// <summary>
        /// Sets the amplitude of Marker to Max
        /// </summary>
        /// <param name="markerNumber">Which marker</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \source\verbatim
        [When(@"I set the amplitude to maximum for marker ([1-4]) for channel ([1-4]) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the amplitude to maximum for marker ([1-4]) for channel ([1-4]) on AWG ([1-4])")]
        public void SetTheSourceMarkerAmplitudeToMax(string markerNumber, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, markerNumber);
            _awgSourceGroup.SetSourceMarkerAmplitude(awg, channelNumber, markerNumber, AwgSourceGroup.SourceMarkerVoltageImmediateAmplitude.Max);
        }

        //glennj 9/9/2013
        //jmanning 03/27/2014
        /// <summary>
        /// Sets the amplitude of Marker to Min
        /// </summary>
        /// <param name="markerNumber">Which marker</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \source\verbatim
        [When(@"I set the amplitude to minimum for marker ([1-4]) for channel ([1-4]) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the amplitude to minimum for marker ([1-4]) for channel ([1-4]) on AWG ([1-4])")]
        public void SetTheSourceMarkerAmplitudeToMin(string markerNumber, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, markerNumber);
            _awgSourceGroup.SetSourceMarkerAmplitude(awg, channelNumber, markerNumber, AwgSourceGroup.SourceMarkerVoltageImmediateAmplitude.Min);
        }

        //Jhowells 6-12-12 Step works PI command times out
        //glennj 9/9/2013
        /// <summary>
        /// Gets the amplitude of Marker
        /// </summary>
        /// <param name="markerNumber">Which marker</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \source\verbatim
        [When(@"I get the amplitude for marker ([1-4]) for channel ([1-4]) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the amplitude for marker ([1-4]) for channel ([1-4]) on AWG ([1-4])")]
        public void GetTheSourceMarkerAmplitudeValue(string markerNumber, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, markerNumber);
            _awgSourceGroup.GetSourceMarkerAmplitude(awg, channelNumber, markerNumber);
        }

        //Jhowells 6-12-12 Step works PI command times out
        //glennj 9/9/2013
        //jmanning 03/27/2014
        /// <summary>
        /// Compares the amplitude of Marker against the expected value.
        /// </summary>
        /// <param name="expectedValue">Expected marker amplitude value</param>
        /// <param name="markerNumber">Which marker</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \source\verbatim
        [Then(@"the amplitude should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for marker ([1-4]) for channel ([1-4]) on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the amplitude should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for marker ([1-4]) for channel ([1-4]) on AWG ([1-4])")]
        public void TheAwgSourceMarkerAmplitudeValueShouldBe(string expectedValue, string markerNumber, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, markerNumber);
            _awgSourceGroup.SourceMarkerAmplitudeShouldBe(awg, channelNumber, markerNumber, expectedValue);
        }
        #endregion SOURce:MARKer:VOLTage[:LEVel][:IMMediate][:AMPLitude]

        #region SOURce:MARKer:VOLTage[:LEVel][:IMMediate]:HIGH
        //Jhowells 6-12-12
        /// <summary>
        /// Sets the marker high voltage
        /// 
        /// [SOURce[n]]:?MARKer[1|2]:?VOLTage[:?LEVel][:?IMMediate]:?HIGH
        /// </summary>
        /// <param name="markerNumber">Which marker</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="setValue">Marker high voltage</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \source\verbatim
        [When(@"I set the high voltage to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the high voltage to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheMarkerHighVoltage(string setValue, string markerNumber, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, markerNumber);
            _awgSourceGroup.SetSourceMarkerVoltageHigh(awg, channelNumber, markerNumber, AwgSourceGroup.SourceMarkerVoltageImmediateHigh.Nr1, setValue);
        }

        // Not found in any test case

        [When(@"I set the high voltage to max for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheMarkerHighVoltageToMax(string markerNumber, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, markerNumber);
            _awgSourceGroup.SetSourceMarkerVoltageHigh(awg, channelNumber, markerNumber, AwgSourceGroup.SourceMarkerVoltageImmediateHigh.Max);
        }

        // Not found in any test case

        [When(@"I set the high voltage to min for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheMarkerHighVoltageToMin(string markerNumber, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, markerNumber);
            _awgSourceGroup.SetSourceMarkerVoltageHigh(awg, channelNumber, markerNumber, AwgSourceGroup.SourceMarkerVoltageImmediateHigh.Min);
        }

        //Jhowells 6-12-12
        /// <summary>
        /// Gets the marker high voltage
        /// 
        /// [SOURce[n]]:?MARKer[1|2]:?VOLTage[:?LEVel][:?IMMediate]:?HIGH
        /// </summary>
        /// <param name="markerNumber">Which marker</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \source\verbatim
        [When(@"I get the high voltage for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the high voltage for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
        public void GetTheMarkerHighVoltageValue(string markerNumber, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, markerNumber);
            _awgSourceGroup.GetSourceMarkerVoltageHigh(awg, channelNumber, markerNumber);
        }

        //Jhowells 6-12-12
        /// <summary>
        /// Compares the marker high voltage against the expected value.
        /// [SOURce[n]]:?MARKer[1|2]:?VOLTage[:?LEVel][:?IMMediate]:?HIGH
        /// </summary>
        /// <param name="markerNumber">Which marker</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="expectedValue">Expected marker high voltage</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \source\verbatim
        [Then(@"the high voltage should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the high voltage should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
        public void TheMarkerHighVoltageValueshouldBe(string expectedValue, string markerNumber, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, markerNumber);
            _awgSourceGroup.SourceMarkerVoltageHighShouldBe(awg, channelNumber, markerNumber, expectedValue);
        }
        #endregion SOURce:MARKer:VOLTage[:LEVel][:IMMediate]:HIGH

        #region SOURce:MARKer:VOLTage[:LEVel][:IMMediate]:LOW
        //Jhowells 6-12-12
        /// <summary>
        /// Sets the marker low voltage
        /// 
        /// [SOURce[n]]:?MARKer[1|2]:?VOLTage[:?LEVel][:?IMMediate]:?LOW
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /// <param name="markerNumber">Which marker</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="setValue">Marker low voltage</param>
        /*!
            \source\verbatim
        [When(@"I set the low voltage to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim  
        */
        [When(@"I set the low voltage to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheMarkerLowVoltage(string setValue, string markerNumber, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, markerNumber);
            _awgSourceGroup.SetSourceMarkerVoltageLow(awg, channelNumber, markerNumber, AwgSourceGroup.SourceMarkerVoltageImmediateLow.Nr1, setValue);
        }

        // Maximum not being tested

        [When(@"I set the low voltage to max for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheMarkerLowVoltageToMax(string markerNumber, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, markerNumber);
            _awgSourceGroup.SetSourceMarkerVoltageLow(awg, channelNumber, markerNumber, AwgSourceGroup.SourceMarkerVoltageImmediateLow.Max);
        }

        // Minimum not being tested

        [When(@"I set the low voltage to min for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheMarkerLowVoltageToMin(string markerNumber, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, markerNumber);
            _awgSourceGroup.SetSourceMarkerVoltageLow(awg, channelNumber, markerNumber, AwgSourceGroup.SourceMarkerVoltageImmediateLow.Min);
        }

        //Jhowells 6-12-12
        /// <summary>
        /// Gets the marker low voltage
        /// 
        /// [SOURce[n]]:?MARKer[1|2]:?VOLTage[:?LEVel][:?IMMediate]:?LOW
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /// <param name="markerNumber">Which marker</param>
        /// <param name="channelNumber">Which channel</param>
        /*!
            \source\verbatim
        [When(@"I get the low voltage for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the low voltage for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
        public void GetTheMarkerlowVoltageValue(string markerNumber, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, markerNumber);
            _awgSourceGroup.GetSourceMarkerVoltageLow(awg, channelNumber, markerNumber);
        }

        //Jhowells 6-12-12
        /// <summary>
        /// Compares the marker low voltage against the expected value.
        /// 
        /// [SOURce[n]]:?MARKer[1|2]:?VOLTage[:?LEVel][:?IMMediate]:?LOW
        /// </summary>
        /// <param name="expectedValue">Expected marker low voltage</param>
        /// <param name="markerNumber">Which marker</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \source\verbatim
        [Then(@"the low voltage should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the low voltage should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
        public void TheMarkerLowVoltageValueshouldBe(string expectedValue, string markerNumber, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, markerNumber);
            _awgSourceGroup.SourceMarkerVoltageLowShouldBe(awg, channelNumber, markerNumber, expectedValue);
        }
        #endregion SOURce:MARKer:VOLTage[:LEVel][:IMMediate]:LOW

        #region SOURce:MARKer:VOLTage:IMMediate:OFFSet
        //Jhowells 6-12-12 Step works PI command times out
        //jmanning 03/27/2014
        /// <summary>
        /// Sets the marker offset voltage
        /// 
        /// [SOURce[n]]:?MARKer[1|2]:?VOLTage[:?LEVel][:?IMMediate]:?OFFSET
        /// </summary>
        /// <param name="setValue">Marker offset voltage</param>
        /// <param name="markerNumber">Which marker</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \source\verbatim
        [When(@"I set the offset voltage to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for marker ([1-4]) for channel ([1-4]) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the offset voltage to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for marker ([1-4]) for channel ([1-4]) on AWG ([1-4])")]
        public void SetTheMarkerOffsetVoltage(string setValue, string markerNumber, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, markerNumber);
            _awgSourceGroup.SetSourceMarkerVoltageOffset(awg, channelNumber, markerNumber, AwgSourceGroup.SourceMarkerVoltageImmediateOffset.Nr1, setValue);
        }

        // Max not being test with this or any other step

        [When(@"I set the offset voltage to maximum for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheMarkerOffsetVoltageToMax(string markerNumber, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, markerNumber);
            _awgSourceGroup.SetSourceMarkerVoltageOffset(awg, channelNumber, markerNumber, AwgSourceGroup.SourceMarkerVoltageImmediateOffset.Max);
        }

        // Min not being test with this or any other step

        [When(@"I set the offset voltage to minimum for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheMarkerOffsetVoltageToMin(string markerNumber, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, markerNumber);
            _awgSourceGroup.SetSourceMarkerVoltageOffset(awg, channelNumber, markerNumber, AwgSourceGroup.SourceMarkerVoltageImmediateOffset.Min);
        }

        //Jhowells 6-12-12 Step works PI command times out
        //jmanning 03/27/2014
        /// <summary>
        /// Gets the offset voltage for the specified marker on the specified channel on the specified AWG
        /// 
        /// [SOURce[n]]:?MARKer[1|2]:?VOLTage[:?LEVel][:?IMMediate]:?OFFSET
        /// </summary>
        /// <param name="markerNumber">Which marker</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \source\verbatim
        [When(@"I get the offset voltage for marker ([1-4]) for channel ([1-4]) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the offset voltage for marker ([1-4]) for channel ([1-4]) on AWG ([1-4])")]
        public void GetTheMarkerOffsetVoltageValue(string markerNumber, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, markerNumber);
            _awgSourceGroup.GetSourceMarkerVoltageOffset(awg, channelNumber, markerNumber);
        }

        //Jhowells 6-12-12 Step works PI command times out
        //jmanning 03/27/2014
        /// <summary>
        /// Compares the specified marker offset voltage against the expected value.
        /// 
        /// [SOURce[n]]:?MARKer[1|2]:?VOLTage[:?LEVel][:?IMMediate]:?OFFSET
        /// </summary>
        /// <param name="expectedValue">Expected marker offset voltage</param>
        /// <param name="markerNumber">Which marker</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \source\verbatim
        [Then(@"the offset voltage value should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for marker ([1-4]) for channel ([1-4]) on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the offset voltage value should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for marker ([1-4]) for channel ([1-4]) on AWG ([1-4])")]
        public void TheMarkerOffsetVoltageValueshouldBe(string expectedValue, string markerNumber, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, markerNumber);
            _awgSourceGroup.SourceMarkerOffsetVoltageShouldBe(awg, channelNumber, markerNumber, expectedValue);
        }
        #endregion SOURce:MARKer:VOLTage:IMMediate:OFFSet

        #region SOURce:RCCouple

        //glennj 9/3/2013
        /// <summary>
        /// Set the Run/Coupled mode to On
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [When(@"I set the source run coupled mode to on on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the source run coupled mode to on on AWG ([1-4])")]
        public void SetSourceRunCoupledModeToOn(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, "1");
            _awgSourceGroup.SetTheSourceRunCoupledMode(awg, AwgSourceGroup.SourceRunCoupledMode.On);
        }

        //glennj 9/3/2013
        /// <summary>
        /// Set the Run/Coupled mode to Off
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [When(@"I set the source run coupled mode to off on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the source run coupled mode to off on AWG ([1-4])")]
        public void SetSourceRunCoupledModeToOff(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSourceGroup.SetTheSourceRunCoupledMode(awg, AwgSourceGroup.SourceRunCoupledMode.Off);
        }

        //glennj 9/3/2013
        /// <summary>
        /// Update the Run/Coupled mode property of the AWG
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [When(@"I get the source run coupled mode on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the source run coupled mode on AWG ([1-4])")]
        public void GetSourceRunCoupledMode(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSourceGroup.GetTheSourceRunCoupledMode(awg); 
        }

        //glennj 9/3/2013
        /// <summary>
        /// Compare the Run/Coupled mode property to be On for the AWG
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [Then(@"the source run couple mode should be on on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the source run couple mode should be on on AWG ([1-4])")]
        public void SourceRunCoupledModeShouldBeOn(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSourceGroup.SourceRunCoupledModeShouldBe(awg, AwgSourceGroup.SourceRunCoupledMode.On);
        }

        //glennj 9/3/2013
        /// <summary>
        /// Compare the Run/Coupled mode property to be Off for the AWG
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [Then(@"the source run couple mode should be off on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the source run couple mode should be off on AWG ([1-4])")]
        public void SourceRunCoupledModeShouldBeOff(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSourceGroup.SourceRunCoupledModeShouldBe(awg, AwgSourceGroup.SourceRunCoupledMode.Off);
        }

        #endregion SOURce:RCCouple

        #region SOURce:RMODe

        // Unknown 01/01/01
        //glennj 9/4/2013
        /// <summary>
        /// Sets the channel run mode to continous
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
                \source\verbatim
        [When(@"I set the run mode to run continuous without a trigger for channel ([1-4]) for AWG ([1-4])")]
                \endverbatim 
        */
        [When(@"I set the run mode to run continuous without a trigger for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheAwgSourceRunModeToContinous(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SetSourceRunMode(awg, channelNumber, AwgSourceGroup.SourceChannelRunMode.Continous);
        }

        //glennj 9/4/2013
        /// <summary>
        /// Sets the channel run mode to triggered (trigger and run once)
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
                \source\verbatim
        [When(@"I set the run mode to run once when triggered for channel ([1-4]) for AWG ([1-4])")]
                \endverbatim 
        */
        [When(@"I set the run mode to run once when triggered for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheAwgSourceRunModeToTriggered(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SetSourceRunMode(awg, channelNumber, AwgSourceGroup.SourceChannelRunMode.TriggeredOnce);
        }

        //glennj 9/4/2013
        /// <summary>
        /// Sets the channel run mode to triggered continous (trigger and run continously)
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
                \source\verbatim
        [When(@"I set the run mode to run continuous when triggered for channel ([1-4]) for AWG ([1-4])")]
                \endverbatim 
        */
        [When(@"I set the run mode to run continuous when triggered for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheAwgSourceRunModeToTriggeredContinous(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SetSourceRunMode(awg, channelNumber, AwgSourceGroup.SourceChannelRunMode.TriggerContinous);
        }

        // Unknown 01/01/01
        //glennj 9/4/2013
        /// <summary>
        /// Gets the %AWG run mode of a source (aka channel)
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
                \source\verbatim
        [When(@"I get the run mode for channel ([1-4]) for AWG ([1-4])")]
                \endverbatim 
        */
        [When(@"I get the run mode for channel ([1-4]) for AWG ([1-4])")]
        public void GetTheAwgSourceRunMode(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.GetSourceRunMode(awg, channelNumber);
        }

        // Unknown 01/01/01
        //glennj 9/4/2013
        /// <summary>
        /// Checks the updated property for a continous run mode
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
               \source\verbatim
        [Then(@"the run mode should be run continuous without a trigger for channel ([1-4]) for AWG ([1-4])")]
               \endverbatim 
        */
        [Then(@"the run mode should be run continuous without a trigger for channel ([1-4]) for AWG ([1-4])")]
        public void TheAwgClockSourceShouldBeContinous(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SourceRunModeShouldBe(awg, channelNumber, AwgSourceGroup.SourceChannelRunMode.Continous);
        }

        //glennj 9/4/2013
        /// <summary>
        /// Checks the updated property for a triggered run once mode
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
               \source\verbatim
        [Then(@"the run mode should be run once when triggered for channel ([1-4]) for AWG ([1-4])")]
               \endverbatim 
        */
        [Then(@"the run mode should be run once when triggered for channel ([1-4]) for AWG ([1-4])")]
        public void TheAwgClockSourceShouldBeTriggered(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SourceRunModeShouldBe(awg, channelNumber, AwgSourceGroup.SourceChannelRunMode.TriggeredOnce);
        }

        //glennj 9/4/2013
        /// <summary>
        /// Checks the updated property for a triggered run continous mode
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
               \source\verbatim
        [Then(@"the run mode should be run continuous when triggered for channel ([1-4]) for AWG ([1-4])")]
               \endverbatim 
        */
        [Then(@"the run mode should be run continuous when triggered for channel ([1-4]) for AWG ([1-4])")]
        public void TheAwgClockSourceShouldBeTriggeredContinuous(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SourceRunModeShouldBe(awg, channelNumber, AwgSourceGroup.SourceChannelRunMode.TriggerContinous);
        }

        #endregion SOURce:RMODe

        #region SOURce:ROSCillator:MULTiplier

        //Kavitha 02/04/2013 Added variable for multiple clocks
        //jmanning 03/27/2014
        /// <summary>
        /// Sets the external reference oscillator multiplier rate of the %AWG
        /// 
        /// [SOURce[1]]:ROSCillator:MULTiplier]
        /// </summary>
        /// <param name="setValue">Reference oscillator multiplier rate</param>
        /// <param name="channelNumber">Which channel source</param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [When(@"I set the source external reference oscillator multiplier rate to ((?<!\S)[-+]?\d+(?!\S)) for channel ([1-4]) on AWG ([1-4])"]
            \endverbatim 
        */
        [When(@"I set the source external reference oscillator multiplier rate to ((?<!\S)[-+]?\d+(?!\S)) for channel ([1-4]) on AWG ([1-4])")]
        public void SetTheExternalReferenceOscillatorMultiplierRate(string setValue, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSourceGroup.SetReferenceOscillatorMultiplierRate(awg, channelNumber, setValue);
        }

        //Kavitha 02-04-2013
        //jmanning 03/27/2014
        /// <summary>
        /// Gets the AWG clock source external reference oscillator multiplier rate of the %AWG
        /// 
        /// [SOURce[1]]:ROSCillator:MULTiplier]
        /// </summary>
        /// <param name="channelNumber">Which channel source</param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim    
        [When(@"I get the source external reference oscillator multiplier rate for channel ([1-4]) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the source external reference oscillator multiplier rate for channel ([1-4]) on AWG ([1-4])")]
        public void GetTheSourceReferenceOscillatorMultiplierRate(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSourceGroup.GetReferenceOscillatorMultiplierRate(awg, channelNumber);
        }

        //Kavitha 02/04/2013
        //jmanning 03/27/2014
        /// <summary>
        /// Compares the reference oscillator multiplier rate of the %AWG against the expected value.
        /// 
        /// [SOURce[1]]:ROSCillator:MULTiplier]
        /// </summary>
        /// <param name="expectedValue">Expected reference oscillator multiplier rate</param>
        /// <param name="channelNumber"></param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [Then(@"the AWG reference oscillator multiplier rate value should be ((?<!\S)[-+]?\d+(?!\S))")]
            \endverbatim 
        */
        [Then(@"the reference oscillator multiplier rate value should be ((?<!\S)[-+]?\d+(?!\S)) for channel ([1-4]) on AWG ([1-4])")] // <NR1> matcher
        public void ThenTheAwgReferenceOscillatorMultiplierRateValueShouldBe(string expectedValue, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSourceGroup.ReferenceOscillatorMultiplierRateValueShouldBe(awg, channelNumber, expectedValue);
        }

        #endregion SOURce:ROSCillator:MULTiplier

        #region SOURce:SCSTep?

        //glennj 8/23/2013
        /// <summary>
        /// Get the current step of a channel on an Awg
        /// </summary>
        /// <param name="channelNumber"></param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [When(@"I get the current step for channel ([1-4]) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the current step for channel ([1-4]) on AWG ([1-4])")]
        public void GetTheCurrentStepForChannel(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.GetSourceChannelSequenceCurrentStep(awg, channelNumber);
        }

        //glennj 20131001
        /// <summary>
        /// This polls for an expected step.  This is necessary for testing as there is<para>
        /// no mechanism that knows when a step changed just because the sequencer was</para><para>
        /// told to move (e.g. jump).  The DB cell gets updated in a polling manner also.</para>
        /// </summary>
        /// <param name="numberOfPolls"></param>
        /// <param name="numberOfSeconds"></param>
        /// <param name="expectedStep"></param>
        /// <param name="channelNumber"></param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [When(
            @"I poll the current step for a max of (\d+) times at (\d+) second intervals for a change to (\d+) for channel ([1-4]) on AWG ([1-4])"
            )]
            \endverbatim 
        */
        [When(
            @"I poll the current step for a max of (\d+) times at (\d+) second intervals for a change to (\d+) for channel ([1-4]) on AWG ([1-4])"
            )]
        public void PollTheCurrentStepForExpectedStep(string numberOfPolls, string numberOfSeconds, string expectedStep, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.PollForSourceChannelSequenceCurrentStep(awg, channelNumber, expectedStep, numberOfSeconds, numberOfPolls);
        }

        //glennj 20131001
        /// <summary>
        /// This polls for an expected step.  This is necessary for testing as there is<para>
        /// no mechanism that knows when a step changed just because the sequencer was</para><para>
        /// told to move (e.g. jump).  The DB cell gets updated in a polling manner also.</para>
        /// </summary>
        /// <param name="numberOfPolls"></param>
        /// <param name="numberOfSeconds"></param>
        /// <param name="channelNumber"></param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [When(
            @"I poll the current step for a max of (\d+) times at (\d+) second intervals for a change to the end for channel ([1-4]) on AWG ([1-4])"
            )]
            \endverbatim 
        */
        [When(
            @"I poll the current step for a max of (\d+) times at (\d+) second intervals for a change to the end for channel ([1-4]) on AWG ([1-4])"
            )]
        public void PollTheCurrentStepForExpectedEndStep(string numberOfPolls, string numberOfSeconds, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.PollForSourceChannelSequenceCurrentStep(awg, channelNumber, AwgSourceGroup.CurrentStepAsEnd, numberOfSeconds, numberOfPolls);
        }

        //glennj 8/23/2013
        //jmanning 03/27/2014
        /// <summary>
        /// Test the updated current step property of a channel on an Awg
        /// </summary>
        /// <param name="channelNumber"></param>
        /// <param name="expectedCurrentStep"></param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [Then(@"the current step should be (\d+) for channel ([1-4]) on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the current step should be (\d+) for channel ([1-4]) on AWG ([1-4])")]
        public void TheCurrentStepForChannelShouldBe(string expectedCurrentStep, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SourceChannelSequenceCurrentStepShouldBe(awg, channelNumber,
                AwgSourceGroup.SourceChannelSequenceCurrentStepKeyword.String, expectedCurrentStep);
        }

        //glennj 8/28/2013
        //jmanning 03/27/2014
        /// <summary>
        /// Test just for the "END" state for the current step.
        /// </summary>
        /// <param name="channelNumber"></param>
        /// <param name="awgNumber"></param>
        [Then(@"the current step should be the end step for channel ([1-4]) on AWG ([1-4])")]
        public void TheCurrentStepForChannelShouldBeTheEnd(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SourceChannelSequenceCurrentStepShouldBe(awg, channelNumber,
                AwgSourceGroup.SourceChannelSequenceCurrentStepKeyword.End);
        }

        #endregion SOURce:SCSTep?

        #region SOURce:SKEW
        //jmanning 03/27/2014
        /// <summary>
        /// Sets the skew for the waveform associated with a channel.
        /// 
        /// [SOURce[n]]:SKEW
        /// </summary>
        /// <param name="setValue">Skew</param>
        /// <param name="units">Units of the skew pico seconds or seconds or the MAX or MIN keywords</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [When(@"I set the AWG source skew to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?.+|MAX|MIN)(PS|ps|sec|s||) for channel ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the source skew to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?.+)(PS|ps|sec|s||) for channel ([1-4]) on AWG ([1-4])")]
        public void SetTheSourceSkew(string setValue, string units, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            string setSkew = units != "" ? _converter.PicotoSecond(setValue, units) : setValue;
            _awgSourceGroup.SetSourceSkew(awg, channelNumber, AwgSourceGroup.SourceSkew.Nr1, setSkew);
        }

        // max doesn't seem to be found in any test case

        [When(@"I set the source skew to maximum for channel ([1-4]) on AWG ([1-4])")]
        public void SetTheSourceSkewToMax(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SetSourceSkew(awg, channelNumber, AwgSourceGroup.SourceSkew.Max);
        }

        // min doesn't seem to be found in any test case

        [When(@"I set the source skew to minimum for channel ([1-4]) on AWG ([1-4])")]
        public void SetTheSourceSkewToMin(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SetSourceSkew(awg, channelNumber, AwgSourceGroup.SourceSkew.Min);
        }

        // Kavitha : Added default statement which was missing for the case statement
        /// <summary>
        /// Gets the skew for the waveform associated with a channel.
        /// [SOURce[n]]:SKEW
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [When(@"I get the AWG source skew for channel ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the source skew for channel ([1-4]) on AWG ([1-4])")]
        public void GetTheSourceSkewValue(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.GetSourceSkew(awg, channelNumber);
        }

        // Kavitha : Added default statement which was missing for the case statement
        /// <summary>
        /// Compares the skew for the waveform associated with a channel against the expected value.
        /// 
        /// [SOURce[n]]:SKEW
        /// </summary>
        /// <param name="expectedValue">Skew</param>
        /// <param name="units">Units of the skew pico seconds or seconds</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
             \source\verbatim
        [Then(@"the AWG source skew value for channel ([1-4]) should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?.+)(PS|ps|sec|s)")]
            \endverbatim 
        */
        [Then(@"the source skew value should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?.+)(PS|ps|sec|s) for channel ([1-4]) on AWG ([1-4])")]
        public void TheSourceSkewValueShouldBe(string expectedValue, string units, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            //Converts the value depending on the unit
            string expectedSkew = _converter.PicotoSecond(expectedValue, units);
            _awgSourceGroup.SourceSkewShouldBe(awg, channelNumber, expectedSkew);
        }
        #endregion SOURce:SKEW

        #region SOURce:TINPut

        //Kavitha 2/14/2013
        //glennj 7/19/2013
        //glennj 9/4/2013
        //jmanning 03/27/2014
        /// <summary>
        /// Sets the Trigger Input to trigger A
        /// </summary>
        /// <param name="channelNumber"></param>
        /// <param name="awgNumber"></param>
        /*!
          \Trigger Input\verbatim 
        [When(@"I set the input trigger to trigger A for channel ([1-4]) for AWG ([1-4])")]
          \endverbatim
         */
        [When(@"I set the input trigger to trigger A for channel ([1-4]) for AWG ([1-4])")]
        public void WhenISetTheTriggerInputToAonTheAwg(string channelNumber, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSourceGroup.SetSourceTriggerInput(awg, channelNumber, AwgSourceGroup.SourceChannelInputTrigger.A);
        }

        /// <summary>
        /// Sets the Trigger Input to trigger B
        /// </summary>
        /// <param name="channelNumber"></param>
        /// <param name="awgNumber"></param>
        /*!
          \Trigger Input\verbatim 
        [When(@"I set the input trigger to trigger B for channel ([1-4]) for AWG ([1-4])")]
          \endverbatim
         */
        [When(@"I set the input trigger to trigger B for channel ([1-4]) for AWG ([1-4])")]
        public void WhenISetTheTriggerInputToBonTheAwg(string channelNumber, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSourceGroup.SetSourceTriggerInput(awg, channelNumber, AwgSourceGroup.SourceChannelInputTrigger.B);
        }


        /// <summary>
        /// Sets the Trigger Input to internal trigger 
        /// </summary>
        /// <param name="channelNumber"></param>
        /// <param name="awgNumber"></param>
        /*!
          \Trigger Input\verbatim 
        [When(@"I set the input trigger to internal trigger for channel ([1-4]) for AWG ([1-4])")]
          \endverbatim
         */
        [When(@"I set the input trigger to internal trigger for channel ([1-4]) for AWG ([1-4])")]
        public void WhenISetTheTriggerInputToInternalOnTheAwg(string channelNumber, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSourceGroup.SetSourceTriggerInput(awg, channelNumber, AwgSourceGroup.SourceChannelInputTrigger.Internal);
        }


        //Kavitha 02-14-2013
        //glennj 7/19/2013
        //glennj 9/4/2013
        /// <summary>
        /// Update the AWG's property for a channel for its trigger input
        /// </summary>
        /// <param name="channelNumber">Which clock</param>
        /// <param name="awgNumber"></param>
        /*!
           \clock\verbatim
        [When(@"I get the input trigger for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I get the input trigger for channel ([1-4]) for AWG ([1-4])")]
        public void GetTheAwgClockTriggerInput(string channelNumber, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSourceGroup.GetSourceTriggerInput(awg, channelNumber);
        }

        //glennj 7/19/2013
        //glennj 9/4/2013
        //jmanning 03/27/2014
        /// <summary>
        /// Check for a specified A trigger input for an update channel trigger type property
        /// </summary>
        /// <param name="channelNumber"></param>
        /// <param name="awgNumber"></param>
        /*!
          \diagnostics\verbatim 
        [Then(@"the input trigger should be trigger A for channel ([1-4]) for AWG ([1-4])")]
          \endverbatim
         */
        [Then(@"the input trigger should be trigger A for channel ([1-4]) for AWG ([1-4])")]
        public void ThenTheTriggerInputValueFromTheAwgShouldBeA(string channelNumber, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSourceGroup.SourceTriggerInputShouldBe(awg, channelNumber, AwgSourceGroup.SourceChannelInputTrigger.A);
        }

        /// <summary>
        /// Check for a specified B trigger input for an update channel trigger type property
        /// </summary>
        /// <param name="channelNumber"></param>
        /// <param name="awgNumber"></param>
        /*!
          \diagnostics\verbatim 
        [Then(@"the input trigger should be trigger B for channel ([1-4]) for AWG ([1-4])")]
          \endverbatim
         */
        [Then(@"the input trigger should be trigger B for channel ([1-4]) for AWG ([1-4])")]
        public void ThenTheTriggerInputValueFromTheAwgShouldBeB(string channelNumber, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSourceGroup.SourceTriggerInputShouldBe(awg, channelNumber, AwgSourceGroup.SourceChannelInputTrigger.B);
        }

        /// <summary>
        /// Check for a specified internal trigger input for an update channel trigger type property
        /// </summary>
        /// <param name="channelNumber"></param>
        /// <param name="awgNumber"></param>
        /*!
          \diagnostics\verbatim 
        [Then(@"the input trigger should be internal trigger for channel ([1-4]) for AWG ([1-4])")]
          \endverbatim
         */
        [Then(@"the input trigger should be internal trigger for channel ([1-4]) for AWG ([1-4])")]
        public void ThenTheTriggerInputValueFromTheAwgShouldBeInternal(string channelNumber, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSourceGroup.SourceTriggerInputShouldBe(awg, channelNumber, AwgSourceGroup.SourceChannelInputTrigger.Internal);
        }
        #endregion SOURce:TINPut

        #region SOURce:VOLTage:AMPLitude

        ///  <summary>
        ///  Sets the default AWG source amplitude by unit for the channel
        /// 
        ///  Sets the default AWG source amplitude for channel 1,2,3 or 4 to a value of millivolts or volts@n
        ///  [SOURce[n]]:?VOLTage[:?LEVel][:?IMMediate][:?AMPLitude]
        ///  </summary>
        ///  <param name="setValue">Source Amplitude value</param>
        ///  <param name="units">Units of source amplitude in mV|V|millivolts|volts</param>
        ///  <param name="channelNumber">Which %AWG channel 1|2|3|4</param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [When(@"I set the source amplitude to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?)(mV|V|millivolts|volts) for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the source amplitude to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?)(mV|V|millivolts|volts) for channel ([1-4]) for AWG ([1-4])")]
        public void SetSourceAmplitudeInVolts(string setValue, string units, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            string valueToSet = _converter.mVToVolt(setValue, units);
            _awgSourceGroup.SetSourceAnalogVoltageAmplitude(awg, channelNumber, AwgSourceGroup.SourceVoltageAmplitude.Nr1, valueToSet);
        }

        // Maximum in not being tested

        [When(@"I set the source amplitude to maximum for channel ([1-4]) for AWG ([1-4])")]
        public void SetSourceAmplitudeToMax(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SetSourceAnalogVoltageAmplitude(awg, channelNumber, AwgSourceGroup.SourceVoltageAmplitude.Max);
        }

        // Minimum in not being tested

        [When(@"I set the source amplitude to minimum for channel ([1-4]) for AWG ([1-4])")]
        public void SetSourceAmplitudeToMin(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SetSourceAnalogVoltageAmplitude(awg, channelNumber, AwgSourceGroup.SourceVoltageAmplitude.Min);
        }

        //PHunter 03-04-13

        /// <summary>
        /// Gets the waveform amplitude for the default AWG
        /// [SOURce[n]]:?VOLTage[:?LEVel][:?IMMediate][:?AMPLitude]
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [When(@"I get the source amplitude for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the source amplitude for channel ([1-4]) for AWG ([1-4])")]
        public void GetAwgSourceAmplitude(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.GetSourceAnalogVoltageAmplitude(awg, channelNumber);
        }

        //grj 10/24/2012
        /// <summary>
        /// Compares the default AWG waveform amplitude against the expected value.
        /// 
        /// [SOURce[n]]:?VOLTage[:?LEVel][:?IMMediate][:?AMPLitude]
        /// </summary>
        /// <param name="expectedValue">Expected waveform amplitude</param>
        /// <param name="units"></param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [Then(@"the source amplitude should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?)(mV|V|millivolts|volts) for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the source amplitude should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?)(mV|V|millivolts|volts) for channel ([1-4]) for AWG ([1-4])")]
        public void TheAwgSourceAmplitudeValueShouldBe(string expectedValue, string units, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            string valueToValidate = _converter.mVToVolt(expectedValue, units);
            _awgSourceGroup.SourceAnalogAmplitudeValueShouldBe(awg, channelNumber, valueToValidate);
        }


        #endregion SOURce:VOLTage:AMPLitude

        #region SOURce:VOLTage:HIGH 

        // Unknown 01/01/01
        /// <summary>
        /// Sets the waveform high amplitude
        /// 
        /// [SOURce[n]]:VOLTage[:LEVel][:IMMediate]:High
        /// </summary>
        /// <param name="setValue">Waveform high amplitude</param>
        /// <param name="awgNumber"></param>
        /// <param name="channelNumber">Which channel</param>
        /*!
            \source\verbatim
        [When(@"I set the source amplitude high to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the source amplitude high to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheSource1High(string setValue, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SetSourceAnalogVoltageHigh(awg, channelNumber, AwgSourceGroup.SourceVoltageHigh.Nr1, setValue);
        }

        [When(@"I set the source amplitude high to max for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheSource1HighToMax(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SetSourceAnalogVoltageHigh(awg, channelNumber, AwgSourceGroup.SourceVoltageHigh.Max);
        }

        [When(@"I set the source amplitude high to min for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheSource1HighToMin(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SetSourceAnalogVoltageHigh(awg, channelNumber, AwgSourceGroup.SourceVoltageHigh.Min);
        }

        // Unknown 01/01/01
        /// <summary>
        /// Gets the waveform high amplitude
        /// 
        /// [SOURce[n]]:VOLTage[:LEVel][:IMMediate]:High?
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [When(@"I get the source amplitude high for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the source amplitude high for channel ([1-4]) for AWG ([1-4])")]
        public void GetTheSourceHighValue(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.GetSourceAnalogVoltageHigh(awg, channelNumber);
        }

        // Unknown 01/01/01
        /// <summary>
        /// Compares the waveform high amplitude against the expected value.
        /// 
        /// [SOURce[n]]:VOLTage[:LEVel][:IMMediate]:High
        /// </summary>
        /// <param name="expectedValue">Expected waveform high amplitude</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [Then(@"the AWG source amplitude high should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the AWG source amplitude high should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for channel ([1-4]) for AWG ([1-4])")]
        public void TheAwgSourceHighValueShouldBe(string expectedValue, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SourceAnalogVoltageHighShouldBe(awg, channelNumber, expectedValue);
        }

        #endregion SOURce:VOLTage:HIGH

        #region SOURce:VOLTage:LOW

        //glennj 12/10/2013
        /// <summary>
        /// Sets the waveform low amplitude.
        /// 
        /// [SOURce[n]]:VOLTage[:LEVel][:IMMediate]:Low
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="setValue">Waveform low amplitude</param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [When(@"I set the source amplitude low to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the source amplitude low to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheSource1Low(string setValue, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SetSourceAnalogVoltageLow(awg, channelNumber, AwgSourceGroup.SourceVoltageLow.Nr1, setValue);
        }

        [When(@"I set the source amplitude low to max for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheSource1LowToMax(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SetSourceAnalogVoltageLow(awg, channelNumber, AwgSourceGroup.SourceVoltageLow.Max);
        }

        [When(@"I set the source amplitude low to min for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheSource1LowToMin(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SetSourceAnalogVoltageLow(awg, channelNumber, AwgSourceGroup.SourceVoltageLow.Min);
        }

        //glennj 12/10/2013
        /// <summary>
        /// Gets the waveform low amplitude.
        /// 
        /// [SOURce[n]]:?VOLTage[:?LEVel][:?IMMediate][:?Low]
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [When(@"I get the source amplitude low for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the source amplitude low for channel ([1-4]) for AWG ([1-4])")]
        public void GetTheSourceLowValue(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.GetSourceAnalogVoltageLow(awg, channelNumber);
        }

        // Unknown 01/01/01
        /// <summary>
        /// Compares the waveform low amplitude against the expected value.
        /// 
        /// [SOURce[n]]:?VOLTage[:?LEVel][:?IMMediate][:?Low]
        /// </summary>
        /// <param name="expectedValue">Expected waveform low amplitude</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
            \source\verbatim
        [Then(@"the AWG source low value for channel ([1-4]) should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?)")]
            \endverbatim 
        */
        [Then(@"the AWG source amplitude low should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for channel ([1-4]) for AWG ([1-4])")]
        public void TheAwgSourceLowValueShouldBe(string expectedValue, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SourceAnalogVoltageLowShouldBe(awg, channelNumber, expectedValue);
        }

        #endregion SOURce:VOLTage:LOW

        #region SOURce:WAVeform

        //glennj 2/4/2014
        //jmanning 03/27/2014
        /// <summary>
        /// Assigns a waveform from the waveform list to a channel.
        /// This is the preferred step.  Use of the wording "load"
        /// is not appropriate for this PI command.
        /// 
        /// [SOURce[n]]:?WAVeform
        /// </summary>
        /// <param name="waveform">Waveform name</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \source\verbatim
        [When(@"I set the source to the waveform ""(.+)"" for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the source to the waveform ""(.+)"" for channel ([1-4]) for AWG ([1-4])")]
        public void AssignTheWaveformOnChannel(string waveform, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SetSourceWaveform(awg, channelNumber, waveform);
        }

        // Unknown 01/01/01
        //jmanning 03/27/2014
        /// <summary>
        /// Gets the output waveform from the current waveform list to a channel
        /// [SOURce[n]]:?WAVeform
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /// <param name="channelNumber">Which channel</param>
        /// 
        /*!
            \source\verbatim
        [When(@"I get the source waveform name for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the source waveform name for channel ([1-4]) for AWG ([1-4])")]
        public void GetTheWaveformValue(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.GetSourceWaveform(awg, channelNumber);
        }

        // Unknown 01/01/01
        //jmanning 03/27/2014
        /// <summary>
        /// Tests the output waveform from the indicated channel against the expected value.
        /// [SOURce[n]]:?WAVeform
        /// </summary>
        /// <param name="expectedWaveformPath">Expected waveform name</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
            \source\verbatim
        [Then(@"the source waveform name should be ""(.+)"" for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the source waveform name should be ""(.+)"" for channel ([1-4]) for AWG ([1-4])")]
        public void TheWaveformValueShouldBe(string expectedWaveformPath, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgSourceGroup.SourceWaveformShouldBe(awg, channelNumber, expectedWaveformPath);
        }
        #endregion SOURce:WAVeform
  }
}