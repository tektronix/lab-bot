//==========================================================================
// AwgFGenGroup.cs
//==========================================================================

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains helper functions that are called from the %AWG FGen PI step definitions.
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
    public class AwgFGenGroup
    {
        public enum FGenChannelAmplitudeAs { Value, Min, Max }

        private const string FGenChannelAmplitudeMaxSyntax = "MAX";
        private const string FGenChannelAmplitudeMinSyntax = "MIN";

        public enum FGenChannelDCLevelAs { Value, Min, Max }

        private const string FGenChannelDCLevelMaxSyntax = "MAX";
        private const string FGenChannelDCLevelMinSyntax = "MIN";

        public enum FGenChannelFrequencyAs { Value, Min, Max }

        private const string FGenChannelFrequencyMaxSyntax = "MAX";
        private const string FGenChannelFrequencyMinSyntax = "MIN";

        public enum FGenChannelHighAs { Value, Min, Max }

        private const string FGenChannelHighMaxSyntax = "MAX";
        private const string FGenChannelHighMinSyntax = "MIN";

        public enum FGenChannelLowAs { Value, Min, Max }

        private const string FGenChannelLowMaxSyntax = "MAX";
        private const string FGenChannelLowMinSyntax = "MIN";

        public enum FGenChannelOffsetAs { Value, Min, Max }

        private const string FGenChannelOffsetMaxSyntax = "MAX";
        private const string FGenChannelOffsetMinSyntax = "MIN";

        public enum FGenChannelPhaseAs { Value, Min, Max }

        private const string FGenChannelPhaseMaxSyntax = "MAX";
        private const string FGenChannelPhaseMinSyntax = "MIN";

        public enum FGenChannelSymmetryAs { Value, Min, Max }

        private const string FGenChannelSymmetryMaxSyntax = "MAX";
        private const string FGenChannelSymmetryMinSyntax = "MIN";

        public enum FGenChannelTypeAs { Sine, Square, Triangle, Noise, DC, Gaussian, Exprise, Expdecay }

        private const string FGenChannelTypeSineCommandSyntax = "SINE";
        private const string FGenChannelTypeSquareCommandSyntax = "SQUare";
        private const string FGenChannelTypeTriangleCommandSyntax = "TRIangle";
        private const string FGenChannelTypeNoiseCommandSyntax = "NOISe";
        private const string FGenChannelTypeDCCommandSyntax = "DC";
        private const string FGenChannelTypeGaussianCommandSyntax = "GAUSsian";
        private const string FGenChannelTypeExpRiseCommandSyntax = "EXPRise";
        private const string FGenChannelTypeExpDecayCommandSyntax = "EXPDecay";
        private const string FGenChannelTypeNoneCommandSyntax = "NONE";

        private const string FGenChannelTypeSineQuerySyntax = "SINE";
        private const string FGenChannelTypeSquareQuerySyntax = "SQU";
        private const string FGenChannelTypeTriangleQuerySyntax = "TRI";
        private const string FGenChannelTypeNoiseQuerySyntax = "NOIS";
        private const string FGenChannelTypeDCQuerySyntax = "DC";
        private const string FGenChannelTypeGaussianQuerySyntax = "GAUS";
        private const string FGenChannelTypeExpRiseQuerySyntax = "EXPR";
        private const string FGenChannelTypeExpDecayQuerySyntax = "EXPD";
        private const string FGenChannelTypeNoneQuerySyntax = "NONE";

        public enum FGenCoupleAmplitude { Off, On }

        private const string FGenCoupleAmplitudeOffCommandSyntax = "OFF";
        private const string FGenCoupleAmplitudeOnCommandSyntax = "ON";
        private const string FGenCoupleAmplitudeOffQuerySyntax = "0";
        private const string FGenCoupleAmplitudeOnQuerySyntax = "1";

        public enum FGenCoupleFrequency { Off, On }

        private const string FGenCoupleFrequencyOffCommandSyntax = "OFF";
        private const string FGenCoupleFrequencyOnCommandSyntax = "ON";
        private const string FGenCoupleFrequencyOffQuerySyntax = "0";
        private const string FGenCoupleFrequencyOnQuerySyntax = "1";


        #region FGEN:CHANnel:AMPLitude

        /// <summary>
        /// Sets the amplitude of the generated waveform of the selected channel.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        /// <param name="setValueAs"></param>
        /// <param name="setValue"></param>
        public void SetTheAWGFgenAmplitudeValueTo(IAWG awg, string channel, FGenChannelAmplitudeAs setValueAs, string setValue = "")
        {
            var finalValue = setValue;
            switch (setValueAs)
            {
                case FGenChannelAmplitudeAs.Max:
                    finalValue = FGenChannelAmplitudeMaxSyntax;
                    break;
                case FGenChannelAmplitudeAs.Min:
                    finalValue = FGenChannelAmplitudeMinSyntax;
                    break;
            }
            awg.SetFGenChannelAmplitude(channel, finalValue);
        }

        /// <summary>
        /// Forces the awg to update it's copy of the amplitude of the generated waveform of the selected channel.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        public void GetTheAWGFgenAmplitudeValue(IAWG awg, string channel)
        {
            awg.GetFGenChannelAmplitude(channel);
        }

        /// <summary>
        /// Test an expected value against a copy of the amplitude of the generated waveform of the selected channel.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedValue"></param>
        /// <param name="logicalChannel"></param>
        public void AWGFgenAmplitudeValueShouldBe(IAWG awg, string logicalChannel, string expectedValue)
        {
            string fgenChannelAmplitude = awg.FGenChannelAmplitude(logicalChannel);
            string possibleErrorString = "Checking the FGen channel amplitude for channel " + logicalChannel;
            Assert.AreEqual(float.Parse(expectedValue), float.Parse(fgenChannelAmplitude), possibleErrorString);
        }

        #endregion FGEN:CHANnel:AMPLitude

        #region FGEN:CHANnel:DCLevel

        /// <summary>
        /// Sets the DC level of the generated waveform of the selected channel.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        /// <param name="setValueAs"></param>
        /// <param name="setValue"></param>
        public void SetTheAWGFgenDCLevelValueTo(IAWG awg, string channel, FGenChannelDCLevelAs setValueAs, string setValue = "")
        {
            var finalValue = setValue;
            switch (setValueAs)
            {
                case FGenChannelDCLevelAs.Max:
                    finalValue = FGenChannelDCLevelMaxSyntax;
                    break;
                case FGenChannelDCLevelAs.Min:
                    finalValue = FGenChannelDCLevelMinSyntax;
                    break;
            }
            awg.SetFGenChannelDCLevel(channel, finalValue);
        }

        /// <summary>
        /// Forces the awg to update it's copy of the DC level of the generated waveform of the selected channel.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        public void GetTheAWGFgenDCLevelValue(IAWG awg, string channel)
        {
            awg.GetFGenChannelDCLevel(channel);
        }

        /// <summary>
        /// Test an expected value against a copy of the DC level of the generated waveform of the selected channel.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedValue"></param>
        /// <param name="logicalChannel"></param>
        public void AWGFgenDCLevelValueShouldBe(IAWG awg, string logicalChannel, string expectedValue)
        {
            string fgenChannelDcLevel = awg.FGenChannelDcLevel(logicalChannel);
            string possibleErrorString = "Checking the FGen DC level for channel " + logicalChannel;
            Assert.AreEqual(float.Parse(expectedValue), float.Parse(fgenChannelDcLevel), possibleErrorString);
        }

        #endregion FGEN:CHANnel:DCLevel

        #region FGEN:CHANnel:FREQuency

        /// <summary>
        /// Sets the frequency of the generated waveform.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="logicalChannel"></param>
        /// <param name="setValueAs"></param>
        /// <param name="setValue"></param>
        public void SetAnAWGFgenFrequencyValueTo(IAWG awg, string logicalChannel, FGenChannelFrequencyAs setValueAs, string setValue = "")
        {
            var finalValue = setValue;
            switch (setValueAs)
            {
                case FGenChannelFrequencyAs.Max:
                    finalValue = FGenChannelFrequencyMaxSyntax;
                    break;
                case FGenChannelFrequencyAs.Min:
                    finalValue = FGenChannelFrequencyMinSyntax;
                    break;
            }
            awg.SetFGenChannelFrequency(logicalChannel, finalValue);
        }

        /// <summary>
        /// Forces the awg to update it's copy of the frequency of the generated waveform.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="logicalChannel"></param>
        public void GetTheAWGFgenFrequencyValue(IAWG awg, string logicalChannel)
        {
            awg.GetFGenChannelFrequency(logicalChannel);
        }

        /// <summary>
        /// Test an expected value against a copy of the frequency of the generated waveform.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedValue"></param>
        /// <param name="logicalChannel"></param>
        public void AWGFgenfrequencyValueShouldBe(IAWG awg, string logicalChannel, string expectedValue)
        {
            string fgenChannelFrequency = awg.FGenChannelFrequency(logicalChannel);
            string possibleErrorString = "Checking the FGen frequency for channel " + logicalChannel;
            Assert.AreEqual(float.Parse(expectedValue), float.Parse(fgenChannelFrequency), possibleErrorString);
        }

        #endregion FGEN:CHANnel:FREQuency

        #region FGEN:CHANnel:HIGH

        /// <summary>
        /// Sets the generated waveform's high voltage value of the selected channel.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="setValueAs"></param>
        /// <param name="setValue"></param>
        /// <param name="channel"></param>
        public void SetTheAWGFgenAmplitudeHighValueTo(IAWG awg, string channel, FGenChannelHighAs setValueAs, string setValue = "")
        {
            var finalValue = setValue;
            switch (setValueAs)
            {
                case FGenChannelHighAs.Max:
                    finalValue = FGenChannelHighMaxSyntax;
                    break;
                case FGenChannelHighAs.Min:
                    finalValue = FGenChannelHighMinSyntax;
                    break;
            }
            awg.SetFGenChannelHigh(channel, finalValue);
        }

        /// <summary>
        /// Forces the awg to update it's copy of the generated waveform's high voltage value of the selected channel.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        public void GetTheAWGFgenAmplitudeHighValue(IAWG awg, string channel)
        {
            awg.GetFGenChannelHigh(channel);
        }

        /// <summary>
        /// Test an expected value against a copy of the generated waveform's high voltage value of the selected channel.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedValue"></param>
        /// <param name="logicalChannel"></param>
        public void AWGFgenAmplitudeHighValueShouldBe(IAWG awg, string logicalChannel, string expectedValue)
        {
            string fgenChannelHigh = awg.FGenChannelHigh(logicalChannel);
            string possibleErrorString = "Checking the FGen high for channel " + logicalChannel;
            Assert.AreEqual(float.Parse(expectedValue), float.Parse(fgenChannelHigh), possibleErrorString);
        }

        #endregion FGEN:CHANnel:HIGH

        #region FGEN:CHANnel:LOW

        /// <summary>
        /// Sets the generated waveform's low voltage value of the selected channel.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        /// <param name="setValueAs"></param>
        /// <param name="setValue"></param>
        public void SetTheAWGFgenAmplitudeLowValueTo(IAWG awg, string channel, FGenChannelLowAs setValueAs, string setValue = "")
        {
            var finalValue = setValue;
            switch (setValueAs)
            {
                case FGenChannelLowAs.Max:
                    finalValue = FGenChannelLowMaxSyntax;
                    break;
                case FGenChannelLowAs.Min:
                    finalValue = FGenChannelLowMinSyntax;
                    break;
            }
            awg.SetFGenChannelLow(channel, finalValue);
        }

        /// <summary>
        /// Forces the awg to update it's copy of the generated waveform's Low voltage value of the selected channel.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        public void GetTheAWGFgenAmplitudeLowValue(IAWG awg, string channel)
        {
            awg.GetFGenChannelLow(channel);
        }

        /// <summary>
        /// Test an expected value against a copy of the generated waveform's Low voltage value of the selected channel.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="logicalChannel"></param>
        /// <param name="expectedValue"></param>
        public void AWGFgenAmplitudeLowValueShouldBe(IAWG awg, string logicalChannel, string expectedValue)
        {
            string fgenChannelLow = awg.FGenChannelLow(logicalChannel);
            string possibleErrorString = "Checking the FGen Low for channel " + logicalChannel;
            Assert.AreEqual(float.Parse(expectedValue), float.Parse(fgenChannelLow), possibleErrorString);
        }

        ///// <summary>
        ///// Sets the generated waveform's low voltage value of the selected channel.
        ///// </summary>
        ///// <param name="awg"></param>
        ///// <param name="setValue"></param>
        ///// <param name="channel"></param>
        //public void SetTheAWGFgenAmplitudeLowValueTo(IAWG awg, string channel, string setValue)
        //{
        //    awg.SetFGenChannelLow(channel, setValue);
        //}

        ///// <summary>
        ///// Forces the awg to update it's copy of the generated waveform's low voltage value of the selected channel.
        ///// </summary>
        ///// <param name="awg"></param>
        ///// <param name="channel"></param>
        //public void GetTheAWGFgenAmplitudeLowValue(IAWG awg, string channel)
        //{
        //    awg.GetFGenChannelLow(channel);
        //}

        ///// <summary>
        ///// Test an expected value against a copy of the generated waveform's high low value of the selected channel.
        ///// </summary>
        ///// <param name="awg"></param>
        ///// <param name="expectedValue"></param>
        ///// <param name="logicalChannel"></param>
        //public void AWGFgenAmplitudeLowValueShouldBe(IAWG awg, string logicalChannel, string expectedValue)
        //{
        //    string fgenChannelLow = awg.FGenChannelLow(logicalChannel);
        //    string possibleErrorString = "Checking the FGen Low for channel " + logicalChannel;
        //    Assert.AreEqual(float.Parse(expectedValue), float.Parse(fgenChannelLow), possibleErrorString);
        //}

        #endregion FGEN:CHANnel:LOW

        #region FGEN:CHANnel:OFFSet

        /// <summary>
        /// Sets the offset of the generated waveform of the selected channel.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="setValueAs"></param>
        /// <param name="setValue"></param>
        /// <param name="channel"></param>
        public void SetTheAWGFgenOffsetValueTo(IAWG awg, string channel, FGenChannelOffsetAs setValueAs, string setValue = "")
        {
            var finalValue = setValue;
            switch (setValueAs)
            {
                case FGenChannelOffsetAs.Max:
                    finalValue = FGenChannelOffsetMaxSyntax;
                    break;
                case FGenChannelOffsetAs.Min:
                    finalValue = FGenChannelOffsetMinSyntax;
                    break;
            }
            awg.SetFGenChannelOffset(channel, finalValue);
        }

        /// <summary>
        /// Forces the awg to update it's copy of the offset of the generated waveform of the selected channel.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        public void GetTheAWGFgenOffsetValue(IAWG awg, string channel)
        {
            awg.GetFGenChannelOffset(channel);
        }

        /// <summary>
        /// Test an expected value against a copy of the offset of the generated waveform of the selected channel.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="logicalChannel"></param>
        /// <param name="expectedOffset"></param>
        public void AWGFgenOffsetValueShouldBe(IAWG awg, string logicalChannel, string expectedOffset)
        {
            string fgenChannelOffset = awg.FGenChannelOffset(logicalChannel);
            string possibleErrorString = "Checking the FGen offset for channel " + logicalChannel;
            //Assert.AreEqual(expectedOffset, fgenChannelOffset, possibleErrorString);
            Assert.AreEqual(float.Parse(expectedOffset), float.Parse(fgenChannelOffset), possibleErrorString);
        }

        #endregion FGEN:CHANnel:OFFSet

        #region FGEN:PERiod

        /// <summary>
        /// Forces the awg to update it's copy of the generated waveform's period.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        public void GetTheAWGFgenPeriodValue(IAWG awg, string channel)
        {
            awg.GetFGenChannelPeriod(channel);
        }

        /// <summary>
        /// Test an expected value against a copy of the generated waveform's period.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="logicalChannel"></param>
        /// <param name="expectedPeriod"></param>
        public void AWGFgenPeriodValueShouldBe(IAWG awg, string logicalChannel, string expectedPeriod)
        {
            string fgenChannelPeriod = awg.FGenChannelPeriod(logicalChannel);
            string possibleErrorString = "Checking the FGen period for channel " + logicalChannel;
            Assert.AreEqual(expectedPeriod, fgenChannelPeriod, possibleErrorString);
        }

        #endregion FGEN:PERiod

        #region FGEN:CHANnel:PHASe

        /// <summary>
        /// Sets the generated waveform's phase of the selected channel.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        /// <param name="setValueAs"></param>
        /// <param name="setValue"></param>
        public void SetTheAWGFgenPhaseValueTo(IAWG awg, string channel, FGenChannelPhaseAs setValueAs, string setValue = "")
        {
            var finalValue = setValue;
            switch (setValueAs)
            {
                case FGenChannelPhaseAs.Max:
                    finalValue = FGenChannelPhaseMaxSyntax;
                    break;
                case FGenChannelPhaseAs.Min:
                    finalValue = FGenChannelPhaseMinSyntax;
                    break;
            }
            awg.SetFGenChannelPhase(channel, finalValue);
        }

        /// <summary>
        /// Forces the awg to update it's copy of the generated waveform's phase of the selected channel.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        public void GetTheAWGFgenPhaseValue(IAWG awg, string channel)
        {
            awg.GetFGenChannelPhase(channel);
        }

        /// <summary>
        /// Test an expected value against a copy of the generated waveform's phase of the selected channel.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="logicalChannel"></param>
        /// <param name="expectedPhase"></param>
        public void AWGFgenPhaseValueShouldBe(IAWG awg, string logicalChannel, string expectedPhase)
        {
            string fgenChannelPhase = awg.FGenChannelPhase(logicalChannel);
            string possibleErrorString = "Checking the FGen phase for channel " + logicalChannel;
            Assert.AreEqual(expectedPhase, fgenChannelPhase, possibleErrorString);
        }

        #endregion FGEN:CHANnel:PHASe

        #region FGEN:CHANnel:SYMMetry

        /// <summary>
        /// Sets the generated waveform's symmetry value of the selected channel.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        /// <param name="setValueAs"></param>
        /// <param name="setValue"></param>
        public void SetTheAWGFgenSymmetryValueTo(IAWG awg, string channel, FGenChannelSymmetryAs setValueAs, string setValue = "")
        {
            var finalValue = setValue;
            switch (setValueAs)
            {
                case FGenChannelSymmetryAs.Max:
                    finalValue = FGenChannelSymmetryMaxSyntax;
                    break;
                case FGenChannelSymmetryAs.Min:
                    finalValue = FGenChannelSymmetryMinSyntax;
                    break;
            }
            awg.SetFGenChannelSymmetry(channel, finalValue);
        }

        /// <summary>
        /// Forces the awg to update it's copy of the generated waveform's symmetry value of the selected channel.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        public void GetTheAWGFgenSymmetryValue(IAWG awg, string channel)
        {
            awg.GetFGenChannelSymmetry(channel);
        }

        /// <summary>
        /// Test an expected value against a copy of the generated waveform's symmetry value of the selected channel.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="logicalChannel"></param>
        /// <param name="expectedSymmetry"></param>
        public void AWGFgenSymmetryValueShouldBe(IAWG awg, string logicalChannel, string expectedSymmetry)
        {
            string fgenChannelSymmetry = awg.FGenChannelSymmetry(logicalChannel);
            string possibleErrorString = "Checking the FGen symmetry for channel " + logicalChannel;
            Assert.AreEqual(expectedSymmetry, fgenChannelSymmetry, possibleErrorString);
        }

        #endregion FGEN:CHANnel:SYMMetry

        #region FGEN:CHANnel:TYPE

        /// <summary>
        /// Sets the waveform type (shape) of the selected channel.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        /// <param name="setValueAs"></param>
        public void SetTheAWGFgenWaveformTypeValueTo(IAWG awg, string channel, FGenChannelTypeAs setValueAs)
        {
            string syntaxValue;

            switch (setValueAs)
            {
                case FGenChannelTypeAs.Sine:
                    syntaxValue = FGenChannelTypeSineCommandSyntax;
                    break;
                case FGenChannelTypeAs.Square:
                    syntaxValue = FGenChannelTypeSquareCommandSyntax;
                    break;
                case FGenChannelTypeAs.Triangle:
                    syntaxValue = FGenChannelTypeTriangleCommandSyntax;
                    break;
                case FGenChannelTypeAs.Noise:
                    syntaxValue = FGenChannelTypeNoiseCommandSyntax;
                    break;
                case FGenChannelTypeAs.DC:
                    syntaxValue = FGenChannelTypeDCCommandSyntax;
                    break;
                case FGenChannelTypeAs.Gaussian:
                    syntaxValue = FGenChannelTypeGaussianCommandSyntax;
                    break;
                case FGenChannelTypeAs.Exprise:
                    syntaxValue = FGenChannelTypeExpRiseCommandSyntax;
                    break;
                case FGenChannelTypeAs.Expdecay:
                    syntaxValue = FGenChannelTypeExpDecayCommandSyntax;
                    break;
                default:
                    syntaxValue = FGenChannelTypeNoneCommandSyntax;
                    break;
            }
            awg.SetFGenChannelType(channel, syntaxValue);
        }

        /// <summary>
        /// Forces the awg to update it's copy of the waveform type (shape) of the selected channel.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        public void GetTheAWGFgenWaveformTypeValue(IAWG awg, string channel)
        {
            awg.GetFGenChannelType(channel);
        }

        /// <summary>
        /// Test an expected value against a copy of the waveform type (shape) of the selected channel.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="logicalChannel"></param>
        /// <param name="expectedTypeAs"></param>
        public void AWGFGenWaveformTypeValueShouldBe(IAWG awg, string logicalChannel, FGenChannelTypeAs expectedTypeAs)
        {
            string expectedType;

            switch (expectedTypeAs)
            {
                case FGenChannelTypeAs.Sine:
                    expectedType = FGenChannelTypeSineQuerySyntax;
                    break;
                case FGenChannelTypeAs.Square:
                    expectedType = FGenChannelTypeSquareQuerySyntax;
                    break;
                case FGenChannelTypeAs.Triangle:
                    expectedType = FGenChannelTypeTriangleQuerySyntax;
                    break;
                case FGenChannelTypeAs.Noise:
                    expectedType = FGenChannelTypeNoiseQuerySyntax;
                    break;
                case FGenChannelTypeAs.DC:
                    expectedType = FGenChannelTypeDCQuerySyntax;
                    break;
                case FGenChannelTypeAs.Gaussian:
                    expectedType = FGenChannelTypeGaussianQuerySyntax;
                    break;
                case FGenChannelTypeAs.Exprise:
                    expectedType = FGenChannelTypeExpRiseQuerySyntax;
                    break;
                case FGenChannelTypeAs.Expdecay:
                    expectedType = FGenChannelTypeExpDecayQuerySyntax;
                    break;
                default:
                    expectedType = FGenChannelTypeNoneQuerySyntax;
                    break;
            }
            string fgenChannelType = awg.FGenChannelType(logicalChannel);
            string possibleErrorString = "Checking the FGen channel type for channel " + logicalChannel;
            Assert.AreEqual(expectedType, fgenChannelType, possibleErrorString);
        }

        #endregion FGEN:CHANnel:TYPE

        #region FGEN:COUPle:AMPLitude

        /// <summary>
        /// Sets the coupling of amplitude controls between channel 1 and channel 2 of a two channel AWG.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="setValue"></param>
        public void SetTheAWGFgenCouplingAmplitudeStateValueTo(IAWG awg, FGenCoupleAmplitude setValue)
        {
            string commandSyntax = setValue == FGenCoupleAmplitude.Off ? FGenCoupleAmplitudeOffCommandSyntax : FGenCoupleAmplitudeOnCommandSyntax;
            awg.SetFGenCoupleAmpl(commandSyntax);
        }

        /// <summary>
        /// Forces the awg to update it's copy of the coupling of amplitude controls between channel 1 and channel 2 of a two channel AWG.
        /// </summary>
        /// <param name="awg"></param>
        public void GetTheAWGFgenCouplingAmplitudeStateValue(IAWG awg)
        {
            awg.GetFGenCoupleAmpl();
        }

        /// <summary>
        /// Test an expected value against a copy of the coupling of amplitude controls between channel 1 and channel 2 of a two channel AWG.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedState"></param>
        public void AWGFgenCouplingAmplitudeStateValueShouldBe(IAWG awg, FGenCoupleAmplitude expectedState)
        {
            string queriedSyntax = expectedState == FGenCoupleAmplitude.Off ? FGenCoupleAmplitudeOffQuerySyntax : FGenCoupleAmplitudeOnQuerySyntax;
            const string possibleErrorString = "Checking the FGen coupling amplitude";
            Assert.AreEqual(queriedSyntax, awg.FGenCoupleAmplitude(), possibleErrorString);
        }

        #endregion FGEN:COUPle:AMPLitude

        #region Postponed

        /// <summary>
        /// Sets the coupling of Frequency controls between channel 1 and channel 2 of a two channel AWG.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="setValue"></param>
        public void SetTheAWGFgenCouplingFrequencyStateValueTo(IAWG awg, FGenCoupleFrequency setValue)
        {
            string commandSyntax = setValue == FGenCoupleFrequency.Off ? FGenCoupleFrequencyOffCommandSyntax : FGenCoupleFrequencyOnCommandSyntax;
            awg.SetFGenCoupleAmpl(commandSyntax);
        }

        /// <summary>
        /// Forces the awg to update it's copy of the coupling of Frequency controls between channel 1 and channel 2 of a two channel AWG.
        /// </summary>
        /// <param name="awg"></param>
        public void GetTheAWGFgenCouplingFrequencyStateValue(IAWG awg)
        {
            awg.GetFGenCoupleAmpl();
        }

        /// <summary>
        /// Test an expected value against a copy of the coupling of Frequency controls between channel 1 and channel 2 of a two channel AWG.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedState"></param>
        public void AWGFgenCouplingFrequencyStateValueShouldBe(IAWG awg, FGenCoupleFrequency expectedState)
        {
            string queriedSyntax = expectedState == FGenCoupleFrequency.Off ? FGenCoupleFrequencyOffQuerySyntax : FGenCoupleFrequencyOnQuerySyntax;
            const string possibleErrorString = "Checking the FGen coupling Frequency";
            Assert.AreEqual(queriedSyntax, awg.FGenCoupleFrequency(), possibleErrorString);
        }

        #endregion Postponed
    }
}