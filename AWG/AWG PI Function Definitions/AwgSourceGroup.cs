//==========================================================================
// AwgSourceGroup.cs
//==========================================================================

using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains helper functions that are called from the %AWG Source PI step definitions.
    /// This class has no restrictions as to where it will be used.
    /// 
    /// This "Helper" group does everything else but steps and TekVISA.
    /// Using parameters from the step, each helper will makes decisions
    /// such as send commands, or process responses from queries and
    /// do testing and generate asserts if necessary.
    /// 
    /// \ingroup grouphelperpi pisteps 
    /// 
    /// </summary>
    public class AwgSourceGroup
    {

        #region Error Strings

        private const string ErrorStringCheckingNamedAssetAssigned      = "Checking the named asset assigned to channel ";
        private const string ErrorStringCheckingTypeAssetAssigned       = "Checking the asset type assigned to channel ";
        private const string ErrorStringCheckingSourceSampleRate        = "Checking the sample rate for clock ";
        private const string ErrorStringCheckingSourceDacResolution     = "Checking the source DAC resolution for channel ";

        private const string ErrorStringCheckingMarkerDelay             = "Checking the delay for marker ";
        private const string ErrorStringCheckingMarkerAmplitude         = "Checking the amplitude for marker ";
        private const string ErrorStringCheckingMarkerHighThreshold     = "Checking the high threshold for marker ";
        private const string ErrorStringCheckingMarkerLowThreshold      = "Checking the low threshold for marker ";
        private const string ErrorStringCheckingMarkerOffsetVoltage     = "Checking the offset voltage for marker ";


        private const string ErrorStringCheckingExternalMultiplierRate  = "Checking the external reference oscillator multiplier for clock ";

        private const string ErrorStringCheckingRunMode                 = "Checking the run mode for channel ";
        private const string ErrorStringCheckingRunCoupledMode          = "Checking the run couple control";
        private const string ErrorStringCheckingSourceSkew              = "Checking the skew for the waveform for channel ";
        private const string ErrorStringCheckingSourceTriggerInput      = "Checking the trigger input for channel ";

        private const string ErrorStringCheckingChannelAmplitudeVoltage = "Checking the amplitude voltage";
        private const string ErrorStringCheckingChannelAmplitudePower   = "Checking the amplitude power";
        private const string ErrorStringCheckingChannelHighThreshold    = "Checking the high threshold voltage";
        private const string ErrorStringCheckingChannelLowThreshold     = "Checking the low threshold voltage";
        private const string ErrorStringCheckingChannelAssignedWaveform = "Checking the assigned waveform";
        private const string ErrorStringForChannel                      = " for channel ";

        #endregion Error Strings

        #region SOURce[n]:CASSet

        //glennj 8/22//2013
        /// <summary>
        /// Using SOURce[n]:CASSet? get the name of the asset assigned to a channel
        /// </summary>
        /// <param name="awg">The </param>
        /// <param name="channelNumber"></param>
        public void GetTheSourceChannelAsset(IAWG awg, string channelNumber)
        {
            awg.GetSourceChannelAsset(channelNumber);
        }

        //glennj 1/20/2013
        /// <summary>
        /// Compare against an expected asset name
        /// </summary>
        /// <param name="awg">The object to work on</param>
        /// <param name="logicalChannel">The name says it all, the logical channel</param>
        /// <param name="expectedAssetName">Set expectations</param>
        public void SourceChannelAssetNameShouldBe(IAWG awg, string logicalChannel, string expectedAssetName)
        {
            string sourceChannelAssignedAsset = awg.SourceChannelAssignedAsset(logicalChannel);
            var possibleErrorMessage = ErrorStringCheckingNamedAssetAssigned + logicalChannel;
            Assert.AreEqual(expectedAssetName, sourceChannelAssignedAsset, possibleErrorMessage);
        }

        #endregion SOURce[n]:CASSet

        #region SOURce[n]:CASSet:SEQuence

        //glennj 8/22/2013
        /// <summary>
        /// Using SOURce[n]:CASSet:SEQuence assign an asset of a track of a sequence to a channel
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channelNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="trackNumber"></param>
        public void SetSourceChannelAssetSequence(IAWG awg, string channelNumber, string seqName, string trackNumber)
        {
            awg.SetSourceChannelAssetSequence(channelNumber, seqName, trackNumber);
        }

        #endregion SOURce[n]:CASSet:SEQuence

        #region SOURce[n]:CASSet:TYPE

        /// <summary>
        /// Enum used by SOURce[n]:CASSet:TYPE related steps in parameter passing
        /// </summary>
        public enum SourceAssetType { Wav, Seq, None }

        // Syntax SOURce:CASSet:TYPE
        private const string SyntaxForSourceCassetTypeWav = "WAV";
        private const string SyntaxForSourceCassetTypeSeq = "SEQ";
        private const string SyntaxForSourceCassetTypeNone = "NONE";

        //glennj 8/22/2013
        /// <summary>
        /// Using SOURce:CASSet:TYPE?, update the copy for the type of the asset assigned for a channel
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channelNumber"></param>
        public void GetSourceChannelAssetType(IAWG awg, string channelNumber)
        {
            awg.GetSourceChannelAssetType(channelNumber);
        }

        //glennj 8/22/2013
        /// <summary>
        /// Expecting the type to be "WAV", "SEQ" or "NONE"
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="logicalChannel"></param>
        /// <param name="expectedAssetType"></param>
        public void SourceChannelAssetTypeShouldBe(IAWG awg, string logicalChannel, SourceAssetType expectedAssetType)
        {
            string sourceChannelAssignedAssetType = awg.SourceChannelAssignedAssetType(logicalChannel);
            var possibleErrorMessage = ErrorStringCheckingTypeAssetAssigned + logicalChannel;

            var expectedType = "";
            switch (expectedAssetType)
            {
                case SourceAssetType.None:
                    expectedType = SyntaxForSourceCassetTypeNone;
                    break;
                case SourceAssetType.Seq:
                    expectedType = SyntaxForSourceCassetTypeSeq;
                    break;
                case SourceAssetType.Wav:
                    expectedType = SyntaxForSourceCassetTypeWav;
                break;
            }

            Assert.AreEqual(expectedType, sourceChannelAssignedAssetType, possibleErrorMessage);
        }

        #endregion SOURce[n]:CASSet:TYPE

        #region SOURce[n]:CASSet:WAVeform

        //glennj 8/22/2013
        /// <summary>
        /// Using SOURce:CASSet:WAVeform assign a waveform to a channel
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channelNumber"></param>
        /// <param name="wfmName"></param>
        public void SetSourceChannelAssetWaveform(IAWG awg, string channelNumber, string wfmName)
        {
            awg.SetSourceChannelAssetWaveform(channelNumber, wfmName);
        }

        #endregion SOURce[n]:CASSet:WAVeform

        #region SOURce:FREQuency

        /// <summary>
        /// Sets the clock sample rate.  This is for backward compatibility<para>
        /// for Kepler.  The are new clock commands to move forward with.</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        /// <param name="setValue"></param>
        public void SetSourceSampleRate(IAWG awg, string channel, string setValue)
        {
            awg.SetSourceFrequency(channel, setValue);
        }

        /// <summary>
        /// Refreshes the a channel's sample frequency by querying the awg.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        public void GetSourceSampleRate(IAWG awg, string channel)
        {
            awg.GetSourceFrequency(channel);
        }

        /// <summary>
        /// The Sample Rate is checked for an expected value.<para>
        /// To refresh contents of the property, do a</para><para>
        /// GetSourceSampleRate(IAWG awg, string channel)</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="logicalClock"></param>
        /// <param name="expectedSampleRate"></param>
        public void SourceSampleRateShouldBe(IAWG awg, string logicalClock, string expectedSampleRate)
        {
            string sourceFrequency = awg.SourceFrequency(logicalClock);
            var possibleErrorMessage = ErrorStringCheckingSourceSampleRate + logicalClock;
            Assert.AreEqual(float.Parse(expectedSampleRate), float.Parse(sourceFrequency), possibleErrorMessage);
        }

        #endregion SOURce:FREQuency

        #region SOURce:DAC:RESolution

        /// <summary>
        /// Set the DAC resolution for a channel
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        /// <param name="resolution"></param>
        public void SetDACResolution(IAWG awg, string channel, string resolution)
        {
            awg.SetSourceDacResolution(channel, resolution);
        }

        /// <summary>
        /// Update the awg property SourceDacResolution for the specified channel
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        public void GetDACResolution(IAWG awg, string channel)
        {
            awg.GetSourceDacResolution(channel);
        }

        /// <summary>
        /// Tests the attribute for an expected DAC resolution
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="logicalChannel"></param>
        /// <param name="expectedResolution"></param>
        public void SourceDacResolutionShouldBe(IAWG awg, string logicalChannel, string expectedResolution)
        {
            string sourceDacResolution = awg.SourceDacResolution(logicalChannel);
            var possibleErrorMessage = ErrorStringCheckingSourceDacResolution + logicalChannel;
            Assert.AreEqual(expectedResolution, sourceDacResolution, possibleErrorMessage);
        }


        #endregion SOURce:DAC:RESolution

        #region [SOURce]:POWer[:LEVel][:IMMediate][:AMPLitude]
        /// kaylak 11/14/2014
        /// <summary>
        /// Enum used by [SOURce:]POWer[:LEVel][:IMMediate][:AMPLitude] related steps in parameter passing
        /// </summary>
        public enum SourcePowerAmplitude { Nr1, Min, Max }

        // Syntax for parameters for [SOURce:]POWer[:LEVel][:IMMediate][:AMPLitude]
        private const string SyntaxForSourcePowerAmplitudeMin = "MIN";
        private const string SyntaxForSourcePowerAmplitudeMax = "MAX";

        public void SetSourcePowerAmplitude(IAWG awg, string channel, SourcePowerAmplitude parameter, string setNr1 = "")
        {
            string setValue = setNr1;

            if (parameter != SourcePowerAmplitude.Nr1)
            {
                setValue = (parameter == SourcePowerAmplitude.Min)
                               ? SyntaxForSourcePowerAmplitudeMin
                               : SyntaxForSourcePowerAmplitudeMax;
            }
            awg.SetSourcePowerAmplitude(channel, setValue);
        }

        public void GetSourcePowerAmplitude(IAWG awg, string channel)
        {
            awg.GetSourcePowerAmplitude(channel);
        }

        //jmanning 09/23/2014
        /// <summary>
        /// Given an awg object and the specific channel, the expected value is compared<para>
        /// to a previously saved value.  Note it is important that this is the current</para><para>
        /// working paradigm that a get needs to be done before a test of the value can be done.</para>
        /// </summary>
        /// <param name="awg">an awg object</param>
        /// <param name="logicalChannel">which channel</param>
        /// <param name="expectedValue">the exact value to be tested against</param>
        public void SourcePowerAmplitudeValueShouldBe(IAWG awg, string logicalChannel, string expectedValue)
        {
            string sourcePowerAmplitude = awg.SourcePowerAmplitude(logicalChannel);
            var possibleErrorMessage = ErrorStringCheckingChannelAmplitudePower + ErrorStringForChannel + logicalChannel;
            Assert.AreEqual(Convert.ToDouble(expectedValue), Convert.ToDouble(sourcePowerAmplitude), possibleErrorMessage);
        }
        #endregion [SOURce:]POWer[:LEVel][:IMMediate][:AMPLitude]

        #region SOURce:JUMP:FORCe

        /// <summary>
        /// Enum used by SOURce:JUMP:FORCe related steps in parameter passing
        /// </summary>
        public enum SourceForceJumpType { Nr1, First, Last, Current, End }

        // Parameter syntax used by SOURce:JUMP:FORCe
        private const string SyntaxForSourceForceJumpFirst = "FIRS";
        private const string SyntaxForSourceForceJumpCurrent = "CURR";
        private const string SyntaxForSourceForceJumpEnd = "END";
        private const string SyntaxForSourceForceJumpLast = "LAST";

        public void ForceSourceChannelToJump(IAWG awg, string channelNumber, SourceForceJumpType forceJumpType, string stepToGoto = "")
        {
            var jumpType = stepToGoto;
            switch (forceJumpType)
            {
                case SourceForceJumpType.Current:
                    jumpType = SyntaxForSourceForceJumpCurrent;
                    break;
                case SourceForceJumpType.End:
                    jumpType = SyntaxForSourceForceJumpEnd;
                    break;
                case SourceForceJumpType.First:
                    jumpType = SyntaxForSourceForceJumpFirst;
                    break;
                case SourceForceJumpType.Last:
                    jumpType = SyntaxForSourceForceJumpLast;
                    break;
            }
            awg.ForceSourceChannelJump(channelNumber, jumpType);
        }

        #endregion SOURce:JUMP:FORCe

        #region SOURce:JUMP:PATTern:FORCe

        //glennj 8/23/2013
        /// <summary>
        /// Using SOURce:JUMP:PATTern:FORCE, force a running sequence to jump to with a pattern match
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        /// <param name="forceJumpPattern"></param>
        public void ForceSourceChannelJumpPattern(IAWG awg, string channel, string forceJumpPattern)
        {
            awg.ForceSourceChannelJumpPattern(channel, forceJumpPattern);
        }

        #endregion SOURce:JUMP:PATTern:FORCe

        #region SOURce:MARKer:DELay

        /// <summary>
        /// Enum used by SOURce:MARKer:DELay related steps in parameter passing
        /// </summary>
        public enum SourceMarkerDelay { Nr1, Min, Max }

        // Syntax for parameters for SOURce:MARKer:DELay
        private const string SyntaxForSourceMarkerDelayMin = "MIN";
        private const string SyntaxForSourceMarkerDelayMax = "MAX";

        /// <summary>
        /// Set a marker delay
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        /// <param name="marker"></param>
        /// <param name="parameter"></param>
        /// <param name="setNr1"></param>
        public void SetSourceMarkerDelay(IAWG awg, string channel, string marker, SourceMarkerDelay parameter, string setNr1 = "")
        {
            string setValue = setNr1;

            if (parameter != SourceMarkerDelay.Nr1)
            {
                setValue = (parameter == SourceMarkerDelay.Min)
                               ? SyntaxForSourceMarkerDelayMin
                               : SyntaxForSourceMarkerDelayMax;
            }
            awg.SetSourceMarkerDelay(channel, marker, setValue);
        }
        /// <summary>
        /// Update Source Marker Delay property
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        /// <param name="marker"></param>
        public void GetSourceMarkerDelay(IAWG awg, string channel, string marker)
        {
            awg.GetSourceMarkerDelay(channel, marker);
        }

        /// <summary>
        /// Test a property for an expected delay
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="logicalChannel"></param>
        /// <param name="logicalMarker"></param>
        /// <param name="expectedDelay"></param>
        public void SourceMarkerDelayShouldBe(IAWG awg, string logicalChannel, string logicalMarker, string expectedDelay)
        {
            string sourceMarkerDelay = awg.SourceMarkerDelay(logicalChannel, logicalMarker);
            string possibleErrorString = ErrorStringCheckingMarkerDelay + logicalMarker + ErrorStringForChannel + logicalChannel;
            Assert.AreEqual(expectedDelay, sourceMarkerDelay, possibleErrorString);
        }

        #endregion SOURce:MARKer:DELay

        #region SOURce:MARKer:VOLTage:IMMediate:AMPLitude

        /// <summary>
        /// Enum used by SOURce:MARKer:VOLTage:IMMediate:AMPLitude related steps in parameter passing
        /// </summary>
        public enum SourceMarkerVoltageImmediateAmplitude { Nr1, Min, Max }

        // Syntax for parameters for SOURce:MARKer:VOLTage:IMMediate:AMPLitude
        private const string SyntaxForSourceMarkerVoltageImmediateAmplitudeMax = "MAX";
        private const string SyntaxForSourceMarkerVoltageImmediateAmplitudeMin = "MIN";

        /// <summary>
        /// Set the source marker voltage amplitude peak to peak range
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        /// <param name="marker"></param>
        /// <param name="parameter"></param>
        /// <param name="setNr1"></param>
        public void SetSourceMarkerAmplitude(IAWG awg, string channel, string marker, SourceMarkerVoltageImmediateAmplitude parameter, string setNr1 = "")
        {
            string setValue = setNr1;

            if (parameter != SourceMarkerVoltageImmediateAmplitude.Nr1)
            {
                setValue = (parameter == SourceMarkerVoltageImmediateAmplitude.Min)
                               ? SyntaxForSourceMarkerVoltageImmediateAmplitudeMin
                               : SyntaxForSourceMarkerVoltageImmediateAmplitudeMax;
            }

            awg.SetSourceMarkerAmplitude(channel, marker, setValue);
        }
        /// <summary>
        /// Update the property for source marker voltage amplitude peak to peak range
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        /// <param name="marker"></param>
        public void GetSourceMarkerAmplitude(IAWG awg, string channel, string marker)
        {
            awg.GetSourceMarkerAmplitude(channel, marker);
        }

        /// <summary>
        /// Test a property for for source marker voltage amplitude peak to peak range
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="logicalChannel"></param>
        /// <param name="logicalMarker"></param>
        /// <param name="expectedAmplitude"></param>SourceMarkerAmplitude
        public void SourceMarkerAmplitudeShouldBe(IAWG awg, string logicalChannel, string logicalMarker, string expectedAmplitude)
        {
            string sourceMarkerAmplitude = awg.SourceMarkerAmplitude(logicalChannel, logicalMarker);
            string possibleErrorString = ErrorStringCheckingMarkerAmplitude + logicalMarker + ErrorStringForChannel + logicalChannel;
            Assert.AreEqual(float.Parse(expectedAmplitude), float.Parse(sourceMarkerAmplitude), possibleErrorString);
        }    

        #endregion SOURce:MARKer:VOLTage:IMMediate:AMPLitude

        #region SOURce:MARKer:VOLTage:IMMediate:HIGH

        /// <summary>
        /// Enum used by SOURce:MARKer:VOLTage:IMMediate:HIGH related steps in parameter passing
        /// </summary>
        public enum SourceMarkerVoltageImmediateHigh { Nr1, Min, Max }

        // Syntax for parameters for SOURce:MARKer:VOLTage:IMMediate:HIGH
        private const string SyntaxForSourceMarkerVoltageImmediateHighMax = "MAX";
        private const string SyntaxForSourceMarkerVoltageImmediateHighMin = "MIN";

        /// <summary>
        /// Set the source marker voltage high boundary
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        /// <param name="marker"></param>
        /// <param name="parameter"></param>
        /// <param name="setNr1"></param>
        public void SetSourceMarkerVoltageHigh(IAWG awg, string channel, string marker, SourceMarkerVoltageImmediateHigh parameter, string setNr1 = "")
        {
            string setValue = setNr1;

            if (parameter != SourceMarkerVoltageImmediateHigh.Nr1)
            {
                setValue = (parameter == SourceMarkerVoltageImmediateHigh.Min)
                               ? SyntaxForSourceMarkerVoltageImmediateHighMin
                               : SyntaxForSourceMarkerVoltageImmediateHighMax;
            }
            awg.SetSourceMarkerVoltageHigh(channel,marker,setValue);
        }
        /// <summary>
        /// Update the property for the source marker voltage high boundary
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        /// <param name="marker"></param>
        public void GetSourceMarkerVoltageHigh(IAWG awg, string channel, string marker)
        {
            awg.GetSourceMarkerVoltageHigh(channel, marker);
        }

        /// <summary>
        /// Verify the source marker voltage high boundary property
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="logicalChannel"></param>
        /// <param name="logicalMarker"></param>
        /// <param name="expectedHighThreshold"></param>SourceMarkerHigh
        public void SourceMarkerVoltageHighShouldBe(IAWG awg, string logicalChannel, string logicalMarker, string expectedHighThreshold)
        {
            string sourceMarkerHigh = awg.SourceMarkerHigh(logicalChannel, logicalMarker);
            string possibleErrorString = ErrorStringCheckingMarkerHighThreshold + logicalMarker + ErrorStringForChannel + logicalChannel;
            Assert.AreEqual(float.Parse(expectedHighThreshold), float.Parse(sourceMarkerHigh), possibleErrorString);
        }
        #endregion SOURce:MARKer:VOLTage:IMMediate:HIGH

        #region SOURce:MARKer:VOLTage:IMMediate:LOW

        /// <summary>
        /// Enum used by SOURce:MARKer:VOLTage:IMMediate:LOW related steps in parameter passing
        /// </summary>
        public enum SourceMarkerVoltageImmediateLow { Nr1, Min, Max }

        // Syntax for parameters for SOURce:MARKer:VOLTage:IMMediate:LOW
        private const string SyntaxForSourceMarkerVoltageImmediateLowMin = "MIN";
        private const string SyntaxForSourceMarkerVoltageImmediateLowMax = "MAX";

        /// <summary>
        /// Set the source marker voltage low boundary
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        /// <param name="marker"></param>
        /// <param name="parameter"></param>
        /// <param name="setNr1"></param>
        public void SetSourceMarkerVoltageLow(IAWG awg, string channel, string marker, SourceMarkerVoltageImmediateLow parameter, string setNr1 = "")
        {
            string setValue = setNr1;

            if (parameter != SourceMarkerVoltageImmediateLow.Nr1)
            {
                setValue = (parameter == SourceMarkerVoltageImmediateLow.Min)
                               ? SyntaxForSourceMarkerVoltageImmediateLowMin
                               : SyntaxForSourceMarkerVoltageImmediateLowMax;
            }
            awg.SetSourceMarkerVoltageLow(channel,marker,setValue);
        }
        /// <summary>
        /// Update the property for source marker voltage low boundary
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        /// <param name="marker"></param>
        public void GetSourceMarkerVoltageLow(IAWG awg, string channel, string marker)
        {
            awg.GetSourceMarkerVoltageLow(channel, marker);
        }

        /// <summary>
        /// Verify the source marker voltage low boundary property
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="logicalChannel"></param>
        /// <param name="logicalMarker"></param>
        /// <param name="expectedLowThreshold"></param>
        public void SourceMarkerVoltageLowShouldBe(IAWG awg, string logicalChannel, string logicalMarker, string expectedLowThreshold)
        {
            string sourceMarkerLow = awg.SourceMarkerLow(logicalChannel, logicalMarker);
            string possibleErrorString = ErrorStringCheckingMarkerLowThreshold + logicalMarker + ErrorStringForChannel + logicalChannel;
            Assert.AreEqual(float.Parse(expectedLowThreshold), float.Parse(sourceMarkerLow), possibleErrorString);
        }
        
        #endregion SOURce:MARKer:VOLTage:IMMediate:LOW

        #region SOURce:MARKer:VOLTage:IMMediate:OFFSet

        /// <summary>
        /// Enum used by SOURce:MARKer:VOLTage:IMMediate:OFFSet related steps in parameter passing
        /// </summary>
        public enum SourceMarkerVoltageImmediateOffset { Nr1, Min, Max }

        // Syntax for parameters for SOURce:MARKer:VOLTage:IMMediate:OFFSet
        private const string SyntaxForSourceMarkerVoltageImmediateOffsetMin = "MIN";
        private const string SyntaxForSourceMarkerVoltageImmediateOffsetMax = "MAX";

        public void SetSourceMarkerVoltageOffset(IAWG awg, string channel, string marker, SourceMarkerVoltageImmediateOffset parameter, string setNr1 = "")
        {
            string setValue = setNr1;

            if (parameter != SourceMarkerVoltageImmediateOffset.Nr1)
            {
                setValue = (parameter == SourceMarkerVoltageImmediateOffset.Min)
                               ? SyntaxForSourceMarkerVoltageImmediateOffsetMin
                               : SyntaxForSourceMarkerVoltageImmediateOffsetMax;
            }
            awg.SetSourceMarkerVoltageOffset(channel,marker,setValue);
        }

        public void GetSourceMarkerVoltageOffset(IAWG awg, string channel, string marker)
        {
            awg.GetSourceMarkerVoltageOffset(channel, marker);
        }

        //glennj 1/21/2014
        /// <summary>
        /// Verify the source marker offset voltage
        /// </summary>
        /// <param name="awg">object to work on</param>
        /// <param name="logicalChannel">Depending on AWG a number between 1 and 4</param>
        /// <param name="logicalMarker">Depending on AWG a number between 1 and 4</param>
        /// <param name="expectedOffsetVoltage"></param>
        public void SourceMarkerOffsetVoltageShouldBe(IAWG awg, string logicalChannel, string logicalMarker, string expectedOffsetVoltage)
        {
            string sourceMarkerOffset = awg.SourceMarkerOffset(logicalChannel, logicalMarker);
            string possibleErrorString = ErrorStringCheckingMarkerOffsetVoltage + logicalMarker + ErrorStringForChannel + logicalChannel;
            Assert.AreEqual(float.Parse(expectedOffsetVoltage), float.Parse(sourceMarkerOffset), possibleErrorString);
        }

        #endregion SOURce:MARKer:VOLTage:IMMediate:OFFSet

        #region SOURce:RCCouple

        /// <summary>
        /// Enum used by SOURce:RCCouple related steps in parameter passing
        /// </summary>
        public enum SourceRunCoupledMode { On, Off }

        // Syntax for parameters for SOURce:RCCouple 
        private const string SyntaxForSourceRunCoupledModeOn = "ON";
        private const string SyntaxForSourceRunCoupledModeOff = "OFF";

        private const string SyntaxForReturnedSourceRunCoupledModeOn = "1";
        private const string SyntaxForReturnedSourceRunCoupledModeOff = "0";

        //glennj 9/3/2013
        /// <summary>
        /// Using SOURce:RCCouple set the Run Coupled Coupling mode
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="setValue"></param>
        public void SetTheSourceRunCoupledMode(IAWG awg, SourceRunCoupledMode setValue)
        {
            var mode = (setValue == SourceRunCoupledMode.Off)
                           ? SyntaxForSourceRunCoupledModeOff
                           : SyntaxForSourceRunCoupledModeOn;
           awg.SetSourceRunCoupledMode(mode);
        }

        //glennj 9/3/2013
        /// <summary>
        /// Using SOURce:RCCouple get a copy of the Run Coupled Coupling mode
        /// </summary>
        /// <param name="awg"></param>
        public void GetTheSourceRunCoupledMode(IAWG awg)
        {
            awg.GetSourceRunCoupledMode();
        }

        //glennj 9/3/2013
        /// <summary>
        /// Expecting a certain RunCoupled state.  Make sure the AWG property is updated though.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedValue"></param>
        public void SourceRunCoupledModeShouldBe(IAWG awg, SourceRunCoupledMode expectedValue)
        {
            string actualSourceRunCoupledMode = awg.SourceRunCoupledMode;
            string expectedReturnSyntax = (expectedValue == SourceRunCoupledMode.On)
                                              ? SyntaxForReturnedSourceRunCoupledModeOn
                                              : SyntaxForReturnedSourceRunCoupledModeOff;
            Assert.AreEqual((expectedReturnSyntax), (actualSourceRunCoupledMode), ErrorStringCheckingRunCoupledMode);
        }

        #endregion SOURce:RCCouple

        #region SOURce:RMODe

        /// <summary>
        /// Enum used by SOURce:RMODe related steps in parameter passing
        /// </summary>
        public enum SourceChannelRunMode { Continous, TriggeredOnce, TriggerContinous }

        // Syntax for parameters for SOURce:RCCouple
        private const string SyntaxForSourceChannelRunModeContinous = "CONT";
        private const string SyntaxForSourceChannelRunModeTriggered = "TRIG";
        private const string SyntaxForSourceChannelRunModeTriggeredContinous = "TCON";

        /// <summary>
        /// Set the run mode on a channel for continously, trigger run once or trigger run continously
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        /// <param name="setRunMode"></param>
        public void SetSourceRunMode(IAWG awg, string channel, SourceChannelRunMode setRunMode)
        {
            string runMode = "";

            switch (setRunMode)
            {
                case SourceChannelRunMode.Continous:
                    runMode = SyntaxForSourceChannelRunModeContinous;
                    break;
                case SourceChannelRunMode.TriggeredOnce:
                    runMode = SyntaxForSourceChannelRunModeTriggered;
                    break;
                case SourceChannelRunMode.TriggerContinous:
                    runMode = SyntaxForSourceChannelRunModeTriggeredContinous;
                    break;
            }

            awg.SetSourceRunMode(channel, runMode);
        }

        /// <summary>
        /// Update the awg run mode copy for the requested channel
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        public void GetSourceRunMode(IAWG awg, string channel)
        {
            awg.GetSourceRunMode(channel);
        }

        //glennj 1/21/2014
        /// <summary>
        /// Verify the run mode for a given channel is correct.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="logicalChannel"></param>
        /// <param name="expectedRunMode"></param>
        public void SourceRunModeShouldBe(IAWG awg, string logicalChannel, SourceChannelRunMode expectedRunMode)
        {
            string expectedModeTranslated = "";

            switch (expectedRunMode)
            {
                case SourceChannelRunMode.Continous:
                    expectedModeTranslated = SyntaxForSourceChannelRunModeContinous;
                    break;
                case SourceChannelRunMode.TriggeredOnce:
                    expectedModeTranslated = SyntaxForSourceChannelRunModeTriggered;
                    break;
                case SourceChannelRunMode.TriggerContinous:
                    expectedModeTranslated = SyntaxForSourceChannelRunModeTriggeredContinous;
                    break;
            }
            string sourceRunMode = awg.SourceRunMode(logicalChannel);
            string possibleErrorString = ErrorStringCheckingRunMode + logicalChannel;
            Assert.AreEqual(expectedModeTranslated, sourceRunMode, possibleErrorString);
        }

        #endregion SOURce:RMODe

        #region SOURce:ROSCillator:MULTiplier

        // Backwards compatibility command

        public void SetReferenceOscillatorMultiplierRate(IAWG awg, string channel, string setValue)
        {
            awg.SetSourceReferenceOscillatorMultiplier(channel, setValue);
        }

        public void GetReferenceOscillatorMultiplierRate(IAWG awg, string channel)
        {
            awg.GetSourceReferenceOscillatorMultiplier(channel);
        }

        //glennj 1/21/2014
        /// <summary>
        /// Checks the multiplier of the external reference signal.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="logicalClock"></param>
        /// <param name="expectedExternalMultiplier"></param>
        public void ReferenceOscillatorMultiplierRateValueShouldBe(IAWG awg, string logicalClock, string expectedExternalMultiplier)
        {
            string sourceReferenceMultiplier = awg.SourceReferenceMultiplier(logicalClock);
            var possibleErrorMessage = ErrorStringCheckingExternalMultiplierRate + logicalClock;
            Assert.AreEqual(expectedExternalMultiplier, sourceReferenceMultiplier, possibleErrorMessage);
        }

        #endregion SOURce:ROSCillator:MULTiplier

        #region SOURce:SCSTep?

        public enum SourceChannelSequenceCurrentStepKeyword { End, String }

        /// <summary>
        /// Used by a calling step definition to indicate that this not a specified step number but the "End"<para>
        /// Could have been done differently but ... it works.</para>
        /// </summary>
        public const string CurrentStepAsEnd = "End";

        public void GetSourceChannelSequenceCurrentStep(IAWG awg, string channelNumber)
        {
            awg.GetSourceChannelCurrentStep(channelNumber);
        }

        /// <summary>
        /// There is no sync mechanism that can be used to know when the step has actually changed.<para>
        /// There are a number of reasons for this such as internally in the VSlice, there is polling</para><para>
        /// when it gets a chance to update the ISDB that we are quering.</para>
        /// </summary>
        /// <param name="awg">Object that represents the AWG to work on</param>
        /// <param name="logicalChannel">There is a sequence step per channel</param>
        /// <param name="expectedStep">This can be the "END" or an NR1</param>
        /// <param name="numberOfSeconds">Interval to poll</param>
        /// <param name="numberOfPolls">Number of times to poll</param>
        public void PollForSourceChannelSequenceCurrentStep(IAWG awg, string logicalChannel, string expectedStep, string numberOfSeconds, string numberOfPolls)
        {
            bool lookForStepNumber = (expectedStep != CurrentStepAsEnd);    // Looking for a string (such as "End") or a string value
            bool foundExpectedStep = false;
            string lookForThisStep = "";
            if (lookForStepNumber)
            {
                lookForThisStep = '"' + expectedStep + '"';
            }
            int maxTimesToPoll = Convert.ToInt32(numberOfPolls);
            int pollNumber = 0;
            string currentStep;

            do
            {
                Thread.Sleep(1000);     // Delay 1 second
                awg.GetSourceChannelCurrentStep(logicalChannel);
                currentStep = awg.SourceSequenceCurrentStep(logicalChannel);
                // Look for an INT or string
                if (lookForStepNumber)
                {
                    try
                    {
                        foundExpectedStep = (lookForThisStep == currentStep);
                    }
                    catch (Exception)
                    {
                        // Since we are getting to the catch block, then it wasn't a number, was it.
                        string reasonForFailure = "Expected step was " + lookForThisStep + " Actual step was " + currentStep;
                        Assert.Fail(reasonForFailure);
                    }
                }
                else // Test for a string value
                {
                    foundExpectedStep = (SyntaxForSourceForceJumpEnd == currentStep);
                }
                pollNumber += 1;    // Keep track of polls and make it obvious instead of burying it in the while test below
            } while (!foundExpectedStep && (pollNumber < maxTimesToPoll));

            string possibleErrorString = "Expected step " + expectedStep + " was not found in " + numberOfPolls + " polls.";
            // If it is a number, then it tests one way, else test for a string
            if (lookForStepNumber)
            {
                Assert.AreEqual(lookForThisStep, currentStep, possibleErrorString);
            }
            else
            {
                Assert.AreEqual(SyntaxForSourceForceJumpEnd, currentStep, possibleErrorString);
            }
        }

        public void SourceChannelSequenceCurrentStepShouldBe(IAWG awg, string logicalChannel,
            SourceChannelSequenceCurrentStepKeyword keyword, string expectedCurrentStep = "")
        {
            string currentStep = awg.SourceSequenceCurrentStep(logicalChannel);
            string expectedCurrentStepinQuotes = '"' + expectedCurrentStep + '"';
            string possibleError = "Expected step was " + expectedCurrentStep + " Actual step was " + currentStep;
            if (keyword == SourceChannelSequenceCurrentStepKeyword.End)
            {
                Assert.AreEqual(SyntaxForSourceForceJumpEnd, currentStep, possibleError);
            }
            else
            {
                Assert.AreEqual(expectedCurrentStepinQuotes, currentStep, possibleError);
            }
        }

        #endregion SOURce:SCSTep?

        #region SOURce:SKEW

        /// <summary>
        /// Enum used by SOURce:SKEW related steps in parameter passing
        /// </summary>
        public enum SourceSkew { Nr1, Min, Max }

        // Syntax for parameters for SOURce:SKEW
        private const string SyntaxForSourceSkewMin = "MIN";
        private const string SyntaxForSourceSkewMax = "MAX";

        public void SetSourceSkew(IAWG awg, string channel, SourceSkew parameter, string setNr1 = "")
        {
            string setValue = setNr1;

            if (parameter != SourceSkew.Nr1)
            {
                setValue = (parameter == SourceSkew.Min)
                               ? SyntaxForSourceSkewMin
                               : SyntaxForSourceSkewMax;
            }
            awg.SetSourceSkew(channel, setValue);
        }

        public void GetSourceSkew(IAWG awg, string channel)
        {
            awg.GetSourceSkew(channel);
        }

        //glennj 1/21/2014
        /// <summary>
        /// Comparing an expected skew to the actual for a given channel
        /// </summary>
        /// <param name="awg">An object to work on</param>
        /// <param name="logicalChannel">Depending on the awg, a channel between 1 and 4</param>
        /// <param name="expectedSkew">Expected skew</param>
        public void SourceSkewShouldBe(IAWG awg, string logicalChannel, string expectedSkew)
        {
            string sourceSkew = awg.SourceSkew(logicalChannel);
            var possibleErrorMessage = ErrorStringCheckingSourceSkew + logicalChannel;
            Assert.AreEqual(float.Parse(expectedSkew), float.Parse(sourceSkew), possibleErrorMessage);
        }

        #endregion SOURce:SKEW

        #region SOURce:TINPut
        /// <summary>
        /// Enum used by SOURce[n]:CASSet:TYPE related steps in parameter passing
        /// </summary>
        public enum SourceChannelInputTrigger { A, B, Internal }

        // Syntax for parameters for SOURce:TINPut
        private const string SyntaxForSourceChannelInputTriggerA = "ATR";
        private const string SyntaxForSourceChannelInputTriggerB = "BTR";
        private const string SyntaxForSourceChannelInputInternalTrigger = "ITR";

        public void SetSourceTriggerInput(IAWG awg, string channel, SourceChannelInputTrigger setValue)
        {
            var triggerParameter = "";
            switch (setValue)
            {
                case SourceChannelInputTrigger.A:
                    triggerParameter = SyntaxForSourceChannelInputTriggerA;
                    break;
                case SourceChannelInputTrigger.B:
                    triggerParameter = SyntaxForSourceChannelInputTriggerB;
                    break;
                case SourceChannelInputTrigger.Internal:
                    triggerParameter = SyntaxForSourceChannelInputInternalTrigger;
                    break;
            }
            awg.SetSourceTriggerInput(channel, triggerParameter);
        }

        public void GetSourceTriggerInput(IAWG awg, string channel)
        {
            awg.GetSourceTriggerInput(channel);
        }

        //glennj 1/21/2014
        /// <summary>
        /// Checking against the updated copy for the source trigger input per channel
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="logicalChannel"></param>
        /// <param name="expectedValue"></param>
        public void SourceTriggerInputShouldBe(IAWG awg, string logicalChannel, SourceChannelInputTrigger expectedValue)
        {

            string sourceTriggerInput = awg.SourceTriggerInput(logicalChannel);
            var possibleErrorMessage = ErrorStringCheckingSourceTriggerInput + logicalChannel;
            var triggerParameter = "";

            switch (expectedValue)
            {
                case SourceChannelInputTrigger.A:
                    triggerParameter = SyntaxForSourceChannelInputTriggerA;
                    break;
                case SourceChannelInputTrigger.B:
                    triggerParameter = SyntaxForSourceChannelInputTriggerB;
                    break;
                case SourceChannelInputTrigger.Internal:
                    triggerParameter = SyntaxForSourceChannelInputInternalTrigger;
                    break;
            }
            Assert.AreEqual(triggerParameter, sourceTriggerInput, possibleErrorMessage);
        }

        #endregion SOURce:TINPut

        #region [SOURce]:VOLTage[:LEVel][:IMMediate][:AMPLitude]

        /// <summary>
        /// Enum used by [SOURce:]VOLTage[:LEVel][:IMMediate][:AMPLitude] related steps in parameter passing
        /// </summary>
        public enum SourceVoltageAmplitude { Nr1, Min, Max }

        // Syntax for parameters for [SOURce:]VOLTage[:LEVel][:IMMediate][:AMPLitude]
        private const string SyntaxForSourceVoltageAmplitudeMin = "MIN";
        private const string SyntaxForSourceVoltageAmplitudeMax = "MAX";

        public void SetSourceAnalogVoltageAmplitude(IAWG awg, string channel, SourceVoltageAmplitude parameter, string setNr1 = "")
        {
            string setValue = setNr1;

            if (parameter != SourceVoltageAmplitude.Nr1)
            {
                setValue = (parameter == SourceVoltageAmplitude.Min)
                               ? SyntaxForSourceVoltageAmplitudeMin
                               : SyntaxForSourceVoltageAmplitudeMax;
            }
            awg.SetSourceAnalogVoltageAmplitude(channel, setValue);
        }

        public void GetSourceAnalogVoltageAmplitude(IAWG awg, string channel)
        {
            awg.GetSourceAnalogVoltageAmplitude(channel);
        }

        //glennj 1/21/2014
        /// <summary>
        /// Given an awg object and the specific channel, the expected value is compared<para>
        /// to a previously saved value.  Note it is important that this is the current</para><para>
        /// working paradigm that a get needs to be done before a test of the value can be done.</para>
        /// </summary>
        /// <param name="awg">an awg object</param>
        /// <param name="logicalChannel">which channel</param>
        /// <param name="expectedValue">the exact value to be tested against</param>
        public void SourceAnalogAmplitudeValueShouldBe(IAWG awg, string logicalChannel, string expectedValue)
        {
            string sourceAnalogVoltageAmplitude = awg.SourceAnalogVoltageAmplitude(logicalChannel);
            var possibleErrorMessage = ErrorStringCheckingChannelAmplitudeVoltage + ErrorStringForChannel + logicalChannel;
            Assert.AreEqual(Convert.ToDouble(expectedValue), Convert.ToDouble(sourceAnalogVoltageAmplitude), possibleErrorMessage);         
        }

        #endregion [SOURce:]VOLTage[:LEVel][:IMMediate][:AMPLitude]

        #region [SOURce]:VOLTage[:LEVel][:IMMediate]:HIGH

        /// <summary>
        /// Enum used by SOURce:VOLTage:HIGH related steps in parameter passing
        /// </summary>
        public enum SourceVoltageHigh { Nr1, Min, Max }

        // Syntax for parameters for SOURce:VOLTage:HIGH
        private const string SyntaxForSourceVoltageHighMin = "MIN";
        private const string SyntaxForSourceVoltageHighMax = "MAX";

        public void SetSourceAnalogVoltageHigh(IAWG awg, string channel, SourceVoltageHigh parameter, string setNr1 = "")
        {
            string setValue = setNr1;

            if (parameter != SourceVoltageHigh.Nr1)
            {
                setValue = (parameter == SourceVoltageHigh.Min)
                               ? SyntaxForSourceVoltageHighMin
                               : SyntaxForSourceVoltageHighMax;
            }
            awg.SetSourceAnalogVoltageHigh(channel, setValue);
        }

        public void GetSourceAnalogVoltageHigh(IAWG awg, string channel)
        {
            awg.GetSourceAnalogVoltageHigh(channel);
        }

        //glennj 1/21/2014
        /// <summary>
        /// Given an awg object and the specific channel, the expected value is compared<para>
        /// to a previously saved value.  Note it is important that this is the current</para><para>
        /// working paradigm that a get needs to be done before a test of the value can be done.</para>
        /// </summary>
        /// <param name="awg">an awg object</param>
        /// <param name="logicalChannel">which channel</param>
        /// <param name="expectedValue">the exact value to be tested against</param>
        public void SourceAnalogVoltageHighShouldBe(IAWG awg, string logicalChannel, string expectedValue)
        {
            string sourceAnalogVoltageHigh = awg.SourceAnalogVoltageHigh(logicalChannel);
            var possibleErrorMessage = ErrorStringCheckingChannelHighThreshold + ErrorStringForChannel + logicalChannel;
            Assert.AreEqual(float.Parse(expectedValue), float.Parse(sourceAnalogVoltageHigh), possibleErrorMessage);
        }

        #endregion SOURce:VOLTage:HIGH

        #region [SOURce]:VOLTage[:LEVel][:IMMediate]:LOW

        /// <summary>
        /// Enum used by SOURce:VOLTage:LOW related steps in parameter passing
        /// </summary>
        public enum SourceVoltageLow { Nr1, Min, Max }

        // Syntax for parameters for SOURce:VOLTage:LOW
        private const string SyntaxForSourceVoltageLowMin = "MIN";
        private const string SyntaxForSourceVoltageLowMax = "MAX";

        public void SetSourceAnalogVoltageLow(IAWG awg, string channel, SourceVoltageLow parameter, string setNr1 = "")
        {
            string setValue = setNr1;

            if (parameter != SourceVoltageLow.Nr1)
            {
                setValue = (parameter == SourceVoltageLow.Min)
                               ? SyntaxForSourceVoltageLowMin
                               : SyntaxForSourceVoltageLowMax;
            }
            awg.SetSourceAnalogVoltageLow(channel, setValue);
        }

        public void GetSourceAnalogVoltageLow(IAWG awg, string channel)
        {
            awg.GetSourceAnalogVoltageLow(channel);
        }

        //glennj 1/21/2014
        /// <summary>
        /// Given an awg object and the specific channel, the expected value is compared<para>
        /// to a previously saved value.  Note it is important that this is the current</para><para>
        /// working paradigm that a get needs to be done before a test of the value can be done.</para>
        /// </summary>
        /// <param name="awg">an awg object</param>
        /// <param name="logicalChannel">which channel</param>
        /// <param name="expectedValue">the exact value to be tested against</param>
        public void SourceAnalogVoltageLowShouldBe(IAWG awg, string logicalChannel, string expectedValue)
        {
            string sourceAnalogVoltageLow = awg.SourceAnalogVoltageLow(logicalChannel);
            var possibleErrorMessage = ErrorStringCheckingChannelLowThreshold + ErrorStringForChannel + logicalChannel;
            Assert.AreEqual(float.Parse(expectedValue), float.Parse(sourceAnalogVoltageLow), possibleErrorMessage);
        }

        #endregion SOURce:VOLTage:LOW

        #region SOURce:WAVeform

        public void SetSourceWaveform(IAWG awg, string channel, string waveformPath)
        {
            awg.SetSourceWaveform(channel, waveformPath);
        }

        public void GetSourceWaveform(IAWG awg, string channel)
        {
            awg.GetSourceWaveform(channel);
        }

        //glennj 1/22/2014
        /// <summary>
        /// Given an awg object and the specific channel, the expected path is compared<para>
        /// to a previously saved copy path.  Note it is important that this is the current</para><para>
        /// working paradigm that a get needs to be done before a test of the value can be done.</para>
        /// </summary>
        /// <param name="awg">an awg object</param>
        /// <param name="logicalChannel">which channel</param>
        /// <param name="expectedWaveformPath">the exact path to be tested against</param>
        public void SourceWaveformShouldBe(IAWG awg, string logicalChannel, string expectedWaveformPath)
        {
            string sourceWaveformAssignedName = awg.SourceWaveformAssignedName(logicalChannel);
            string expectedWaveformPathwQuotes = "\"" + expectedWaveformPath + "\"";
            var possibleErrorMessage = ErrorStringCheckingChannelAssignedWaveform + ErrorStringForChannel + logicalChannel;
            Assert.AreEqual((expectedWaveformPathwQuotes), (sourceWaveformAssignedName), possibleErrorMessage);
        }

        #endregion SOURce:WAVeform

    }
}