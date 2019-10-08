//==========================================================================
// AwgMultiToneGroup.cs
//==========================================================================
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
    public class AwgMultiToneGroup
    {
        public enum MultiToneType
        {
            Tones,
            Chirp
        }

        private const string SyntaxForMultiToneTypeTones = "TON";
        private const string SyntaxForMultiToneTypeChirp = "CHIR";

        private const string SyntaxForMultiToneChannelNone = "NONE";

        public enum BoolState
        {
            Off,
            On
        }

        private const string SyntaxForBoolStateOff = "0";
        private const string SyntaxForBoolStateOn = "1";

        public enum TonePhaseType
        {
            Random,
            Newman,
            UserDefined
        }

        private const string SyntaxForPhaseRandom = "RAND";
        private const string SyntaxForPhaseNewman = "NEWM";
        private const string SyntaxForPhaseUserDefined = "UDEF";

        public enum DeleteEntryAs
        {
            Value,
            All
        }

        private const string SyntaxForAll = "ALL";

        public enum ChirpFrequencySweep
        {
            LowHigh,
            HighLow
        }

        private const string SyntaxForFrequencySweepLowHigh = "LHIG";
        private const string SyntaxForFrequencySweepHighLow = "HLOW";

        public enum NumericEntryAs
        {
            Value,
            Min,
            Max
        }

        private const string SyntaxForNumericAsMin = "MIN";
        private const string SyntaxForNumericAsMax = "MAX";


        #region MultiTone

        #region MTONE:RESEt

        //sdas2 9/1/2015
        /// <summary>
        ///  Reset MultiTone Module
        /// </summary>
        /// <param name="awg"></param>
         public void AwgMultiToneReset(IAWG awg)
         {
           awg.AwgMultiToneReset();
         }
        #endregion

        #region MTONe:LOAD

        //dstockwe 2014/11/20
        /// <summary>
        /// Load MultiTone module
        /// </summary>
        public void AwgMultiToneLoad(IAWG awg)
        {
            awg.AwgMultiToneLoad();
        }

        #endregion

        #region MTONe:TYPE[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone Type
        /// </summary>
        public void SetMultiToneType(IAWG awg, MultiToneType type)
        {
            var typeSetting = "";
            switch (type)
            {
                case MultiToneType.Chirp:
                    typeSetting = SyntaxForMultiToneTypeChirp;
                    break;
                case MultiToneType.Tones:
                    typeSetting = SyntaxForMultiToneTypeTones;
                    break;
            }
            awg.SetMultiToneType(typeSetting);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone Type
        /// </summary>
        public void GetMultiToneType(IAWG awg)
        {
            awg.GetMultiToneType();
        }

        /// <summary>
        /// Compare actual to expected and report
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedState"></param>
        public void MultiToneTypeShouldBe(IAWG awg, MultiToneType expectedState)
        {
            var expectedSetting = "";
            var actualSetting = awg.MultiToneType;

            switch (expectedState)
            {
                case MultiToneType.Tones:
                    expectedSetting = SyntaxForMultiToneTypeTones;
                    break;
                case MultiToneType.Chirp:
                    expectedSetting = SyntaxForMultiToneTypeChirp;
                    break;
            }
            var possibleErrorString = "Expected: " + expectedSetting + " Actual: " + actualSetting;
            Assert.AreEqual(expectedSetting, actualSetting, possibleErrorString);
        }

        #endregion


        #region MTONe:COMPile

        //dstockwe 2014/11/20
        /// <summary>
        /// Compile MultiTone module
        /// </summary>
        public void AwgMultiToneCompile(IAWG awg)
        {
            awg.StartMultiToneCompile();
        }

        #endregion

        #region MTONe:COMPile:CANCel

        //dstockwe 2014/11/20
        /// <summary>
        /// Cancels an active compile in MultiTone module
        /// </summary>
        public void AwgMultiToneCancelCompile(IAWG awg)
        {
            awg.MultiToneCancelCompile();
        }

        #endregion

        #region MTONe:COMPile:NAME[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone Name
        /// </summary>
        public void SetMultiToneName(IAWG awg, string setValue)
        {
            awg.SetMultiToneName(setValue);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone Name
        /// </summary>
        public void GetMultiToneName(IAWG awg)
        {
            awg.GetMultiToneName();
        }

        /// <summary>
        /// Compare actual to expected and report
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedValue"></param>
        public void MultiToneNameShouldBe(IAWG awg, string expectedValue)
        {
            var expectedSetting = expectedValue;
            var actualSetting = awg.MultiToneName;

            var possibleErrorString = "Expected: " + expectedSetting + " Actual: " + actualSetting;
            Assert.AreEqual(expectedSetting, actualSetting, possibleErrorString);
        }

        #endregion

        #region MTONe:COMPile:CHANnel[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone Assign to Channel
        /// </summary>
        public void SetMultiToneChannel(IAWG awg, int channelNum)
        {
            var channel = SyntaxForMultiToneChannelNone;
            if (channelNum > 0)
                channel = channelNum.ToString();

            awg.SetMultiToneChannel(channel);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone Assign to Channel
        /// </summary>
        public void GetMultiToneChannel(IAWG awg)
        {
            awg.GetMultiToneChannel();
        }

        /// <summary>
        /// Compare actual to expected and report
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedValue"></param>
        public void MultiToneChannelShouldBe(IAWG awg, string expectedValue)
        {
            var expectedSetting = expectedValue;
            var actualSetting = awg.MultiToneChannel;

            var possibleErrorString = "Expected: " + expectedSetting + " Actual: " + actualSetting;
            Assert.AreEqual(expectedSetting, actualSetting, possibleErrorString);
        }

        #endregion

        #region MTONe:COMPile:PLAY[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone Assign to Channel and Play
        /// </summary>
        public void SetMultiToneChannelPlay(IAWG awg, BoolState setValue)
        {
            var value = SyntaxForBoolStateOff;
            switch (setValue)
            {
                case BoolState.Off:
                    value = SyntaxForBoolStateOff;
                    break;
                case BoolState.On:
                    value = SyntaxForBoolStateOn;
                    break;
            }

            awg.SetMultiToneChannelPlay(value);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone Assign to Channel and Play
        /// </summary>
        public void GetMultiToneChannelPlay(IAWG awg)
        {
            awg.GetMultiToneChannelPlay();
        }

        /// <summary>
        /// Compare actual to expected and report
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedState"></param>
        public void MultiToneChannelPlayShouldBe(IAWG awg, BoolState expectedState)
        {
            var expectedSetting = "";
            var actualSetting = awg.MultiToneChannelPlay;

            switch (expectedState)
            {
                case BoolState.Off:
                    expectedSetting = SyntaxForBoolStateOff;
                    break;
                case BoolState.On:
                    expectedSetting = SyntaxForBoolStateOn;
                    break;
            }
            var possibleErrorString = "Expected: " + expectedSetting + " Actual: " + actualSetting;
            Assert.AreEqual(expectedSetting, actualSetting, possibleErrorString);
        }

        #endregion

        #region MTONe:COMPile:SRATe[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone desired sampling rate
        /// </summary>
        public void SetMultiToneSamplingRate(IAWG awg, NumericEntryAs setValueAs, string setValue)
        {
            var finalValue = setValue;
            switch (setValueAs)
            {
                case NumericEntryAs.Max:
                    finalValue = SyntaxForNumericAsMax;
                    break;
                case NumericEntryAs.Min:
                    finalValue = SyntaxForNumericAsMin;
                    break;
            }
            awg.SetMultiToneSamplingRate(finalValue);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone desired sampling rate
        /// </summary>
        public void GetMultiToneSamplingRate(IAWG awg)
        {
            awg.GetMultiToneSamplingRate();
        }

        /// <summary>
        /// Compare actual to expected and report
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedValue"></param>
        public void MultiToneSamplingRateShouldBe(IAWG awg, string expectedValue)
        {
            var expectedSetting = expectedValue;
            var actualSetting = awg.MultiToneSamplingRate;

            var possibleErrorString = "Expected: " + expectedSetting + " Actual: " + actualSetting;
            Assert.AreEqual(float.Parse(expectedValue), float.Parse(actualSetting), possibleErrorString);
        }

        #endregion

        #region MTONe:COMPile:SRATe:AUTO[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone auto desired sampling rate
        /// </summary>
        public void SetMultiToneAutoSamplingRate(IAWG awg, BoolState setValue)
        {
            var value = SyntaxForBoolStateOff;
            switch (setValue)
            {
                case BoolState.Off:
                    value = SyntaxForBoolStateOff;
                    break;
                case BoolState.On:
                    value = SyntaxForBoolStateOn;
                    break;
            }

            awg.SetMultiToneAutoSamplingRate(value);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone auto desired sampling rate
        /// </summary>
        public void GetMultiToneAutoSamplingRate(IAWG awg)
        {
            awg.GetMultiToneAutoSamplingRate();
        }

        /// <summary>
        /// Compare actual to expected and report
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedState"></param>
        public void MultiToneSamplingRateAutoShouldBe(IAWG awg, BoolState expectedState)
        {
            var expectedSetting = "";
            var actualSetting = awg.MultiToneSamplingRateAuto;

            switch (expectedState)
            {
                case BoolState.Off:
                    expectedSetting = SyntaxForBoolStateOff;
                    break;
                case BoolState.On:
                    expectedSetting = SyntaxForBoolStateOn;
                    break;
            }
            var possibleErrorString = "Expected: " + expectedSetting + " Actual: " + actualSetting;
            Assert.AreEqual(expectedSetting, actualSetting, possibleErrorString);
        }

        #endregion


        #region MTONe:TONes:STARt[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone start
        /// </summary>
        public void SetMultiToneToneStart(IAWG awg, NumericEntryAs setValueAs, string setValue)
        {
            var finalValue = setValue;
            switch (setValueAs)
            {
                case NumericEntryAs.Max:
                    finalValue = SyntaxForNumericAsMax;
                    break;
                case NumericEntryAs.Min:
                    finalValue = SyntaxForNumericAsMin;
                    break;
            }
            awg.SetMultiToneToneStart(finalValue);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone start
        /// </summary>
        public void GetMultiToneToneStart(IAWG awg)
        {
            awg.GetMultiToneToneStart();
        }

        /// <summary>
        /// Compare actual to expected and report
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedValue"></param>
        public void MultiToneToneStartShouldBe(IAWG awg, string expectedValue)
        {
            var expectedSetting = expectedValue;
            var actualSetting = awg.MultiToneToneStart;

            var possibleErrorString = "Expected: " + expectedSetting + " Actual: " + actualSetting;
            Assert.AreEqual(float.Parse(expectedValue), float.Parse(actualSetting), possibleErrorString);
        }

        #endregion

        #region MTONe:TONes:END[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone end
        /// </summary>
        public void SetMultiToneToneEnd(IAWG awg, NumericEntryAs setValueAs, string setValue)
        {
            var finalValue = setValue;
            switch (setValueAs)
            {
                case NumericEntryAs.Max:
                    finalValue = SyntaxForNumericAsMax;
                    break;
                case NumericEntryAs.Min:
                    finalValue = SyntaxForNumericAsMin;
                    break;
            }
            awg.SetMultiToneToneEnd(finalValue);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone end
        /// </summary>
        public void GetMultiToneToneEnd(IAWG awg)
        {
            awg.GetMultiToneToneEnd();
        }

        /// <summary>
        /// Compare actual to expected and report
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedValue"></param>
        public void MultiToneToneEndShouldBe(IAWG awg, string expectedValue)
        {
            var expectedSetting = expectedValue;
            var actualSetting = awg.MultiToneToneEnd;

            var possibleErrorString = "Expected: " + expectedSetting + " Actual: " + actualSetting;
            Assert.AreEqual(float.Parse(expectedValue), float.Parse(actualSetting), possibleErrorString);
        }

        #endregion

        #region MTONe:TONes:SPACing[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone spacing
        /// </summary>
        public void SetMultiToneToneSpacing(IAWG awg, NumericEntryAs setValueAs, string setValue)
        {
            var finalValue = setValue;
            switch (setValueAs)
            {
                case NumericEntryAs.Max:
                    finalValue = SyntaxForNumericAsMax;
                    break;
                case NumericEntryAs.Min:
                    finalValue = SyntaxForNumericAsMin;
                    break;
            }
            awg.SetMultiToneToneSpacing(finalValue);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone spacing
        /// </summary>
        public void GetMultiToneToneSpacing(IAWG awg)
        {
            awg.GetMultiToneToneSpacing();
        }

        /// <summary>
        /// Compare actual to expected and report
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedValue"></param>
        public void MultiToneToneSpacingShouldBe(IAWG awg, string expectedValue)
        {
            var expectedSetting = expectedValue;
            var actualSetting = awg.MultiToneToneSpacing;

            var possibleErrorString = "Expected: " + expectedSetting + " Actual: " + actualSetting;
            Assert.AreEqual(float.Parse(expectedValue), float.Parse(actualSetting), possibleErrorString);
        }

        #endregion

        #region MTONe:TONes:NTONes[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone number of tones
        /// </summary>
        public void SetMultiToneToneNTones(IAWG awg, NumericEntryAs setValueAs, string setValue)
        {
            var finalValue = setValue;
            switch (setValueAs)
            {
                case NumericEntryAs.Max:
                    finalValue = SyntaxForNumericAsMax;
                    break;
                case NumericEntryAs.Min:
                    finalValue = SyntaxForNumericAsMin;
                    break;
            }
            awg.SetMultiToneToneNTones(finalValue);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone number of tones
        /// </summary>
        public void GetMultiToneToneNTones(IAWG awg)
        {
            awg.GetMultiToneToneNTones();
        }

        /// <summary>
        /// Compare actual to expected and report
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedValue"></param>
        public void MultiToneToneNumTonesShouldBe(IAWG awg, string expectedValue)
        {
            var expectedSetting = expectedValue;
            var actualSetting = awg.MultiToneToneNumTones;

            var possibleErrorString = "Expected: " + expectedSetting + " Actual: " + actualSetting;
            Assert.AreEqual(float.Parse(expectedValue), float.Parse(actualSetting), possibleErrorString);
        }

        #endregion

        #region MTONe:TONes:PHASe[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone Phase
        /// </summary>
        public void SetMultiToneTonePhase(IAWG awg, TonePhaseType phase)
        {
            var typeSetting = "";
            switch (phase)
            {
                case TonePhaseType.Random:
                    typeSetting = SyntaxForPhaseRandom;
                    break;
                case TonePhaseType.Newman:
                    typeSetting = SyntaxForPhaseNewman;
                    break;
                case TonePhaseType.UserDefined:
                    typeSetting = SyntaxForPhaseUserDefined;
                    break;
            }
            awg.SetMultiToneTonePhase(typeSetting);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone Phase
        /// </summary>
        public void GetMultiToneTonePhase(IAWG awg)
        {
            awg.GetMultiToneTonePhase();
        }

        /// <summary>
        /// Compare actual to expected and report
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedState"></param>
        public void MultiToneTonePhaseShouldBe(IAWG awg, TonePhaseType expectedState)
        {
            var expectedSetting = "";
            var actualSetting = awg.MultiToneTonePhase;

            switch (expectedState)
            {
                case TonePhaseType.Random:
                    expectedSetting = SyntaxForPhaseRandom;
                    break;
                case TonePhaseType.Newman:
                    expectedSetting = SyntaxForPhaseNewman;
                    break;
                case TonePhaseType.UserDefined:
                    expectedSetting = SyntaxForPhaseUserDefined;
                    break;
            }
            var possibleErrorString = "Expected: " + expectedSetting + " Actual: " + actualSetting;
            Assert.AreEqual(expectedSetting, actualSetting, possibleErrorString);
        }

        #endregion

        #region MTONe:TONes:PHASe:UNDEFined[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone Phase User Defined
        /// </summary>
        public void SetMultiToneTonePhaseUserDefined(IAWG awg, NumericEntryAs setValueAs, string setValue)
        {
            var finalValue = setValue;
            switch (setValueAs)
            {
                case NumericEntryAs.Max:
                    finalValue = SyntaxForNumericAsMax;
                    break;
                case NumericEntryAs.Min:
                    finalValue = SyntaxForNumericAsMin;
                    break;
            }
            awg.SetMultiToneTonePhaseUserDefined(finalValue);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone Phase User Defined
        /// </summary>
        public void GetMultiToneTonePhaseUserDefined(IAWG awg)
        {
            awg.GetMultiToneTonePhaseUserDefined();
        }

        /// <summary>
        /// Compare actual to expected and report
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedValue"></param>
        public void MultiToneTonePhaseUserDefinedShouldBe(IAWG awg, string expectedValue)
        {
            var expectedSetting = expectedValue;
            var actualSetting = awg.MultiToneTonePhaseUserDefined;

            var possibleErrorString = "Expected: " + expectedSetting + " Actual: " + actualSetting;
            Assert.AreEqual(float.Parse(expectedValue), float.Parse(actualSetting), possibleErrorString);
        }

        #endregion


        #region MTONe:TONes:NOTCh16[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone notch
        /// </summary>
        public void SetMultiToneToneNotch(IAWG awg, NumericEntryAs setStartValueAs, string startValue,
            NumericEntryAs setEndValueAs, string endValue, string notchIndex)
        {
            var finalStartValue = startValue;
            var finalEndValue = endValue;

            switch (setStartValueAs)
            {
                case NumericEntryAs.Max:
                    finalStartValue = SyntaxForNumericAsMax;
                    break;
                case NumericEntryAs.Min:
                    finalStartValue = SyntaxForNumericAsMin;
                    break;
            }
            switch (setEndValueAs)
            {
                case NumericEntryAs.Max:
                    finalEndValue = SyntaxForNumericAsMax;
                    break;
                case NumericEntryAs.Min:
                    finalEndValue = SyntaxForNumericAsMin;
                    break;
            }

            var finalValue = finalStartValue + ", " + finalEndValue;
            awg.SetMultiToneToneNotch(finalValue, notchIndex);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone notch
        /// </summary>
        public void GetMultiToneToneNotch(IAWG awg, string notchIndex)
        {
            awg.GetMultiToneToneNotch(notchIndex);
        }

        /// <summary>
        /// Compare actual to expected and report
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedStartValue"></param>
        /// <param name="expectedEndValue"></param>
        public void MultiToneNotchShouldBe(IAWG awg, string expectedStartValue, string expectedEndValue)
        {
            var splitStartEnd = awg.MultiToneNotchStartEnd.Split(',');
            if (splitStartEnd.Length != 2)
                Assert.Fail("Did not receive start and end value");

            var actualStartValue = splitStartEnd[0];
            var actualEndValue = splitStartEnd[1];

            var possibleStartErrorString = "Expected: " + expectedStartValue + " Actual: " + actualStartValue;
            var possibleEndErrorString = "Expected: " + expectedEndValue + " Actual: " + actualEndValue;

            Assert.AreEqual(float.Parse(expectedStartValue), float.Parse(actualStartValue), possibleStartErrorString);
            Assert.AreEqual(float.Parse(expectedEndValue), float.Parse(actualEndValue), possibleEndErrorString);
        }

        #endregion

        #region MTONe:TONes:NOTCh16:ADD

        //dstockwe 2014/11/20
        /// <summary>
        /// Add MultiTone tone notch
        /// </summary>
        public void SetMultiToneToneNotchAdd(IAWG awg, NumericEntryAs setStartValueAs, string startValue,
            NumericEntryAs setEndValueAs, string endValue)
        {
            var finalStartValue = startValue;
            var finalEndValue = endValue;
            switch (setStartValueAs)
            {
                case NumericEntryAs.Max:
                    finalStartValue = SyntaxForNumericAsMax;
                    break;
                case NumericEntryAs.Min:
                    finalStartValue = SyntaxForNumericAsMin;
                    break;
            }
            switch (setEndValueAs)
            {
                case NumericEntryAs.Max:
                    finalEndValue = SyntaxForNumericAsMax;
                    break;
                case NumericEntryAs.Min:
                    finalEndValue = SyntaxForNumericAsMin;
                    break;
            }
            awg.SetMultiToneToneNotchAdd(finalStartValue, finalEndValue);
        }

        #endregion

        #region MTONe:TONes:NOTCh16:ENABle[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone notch enable
        /// </summary>
        public void SetMultiToneToneNotchEnable(IAWG awg, BoolState setValue)
        {
            var value = SyntaxForBoolStateOff;
            switch (setValue)
            {
                case BoolState.Off:
                    value = SyntaxForBoolStateOff;
                    break;
                case BoolState.On:
                    value = SyntaxForBoolStateOn;
                    break;
            }

            awg.SetMultiToneToneNotchEnable(value);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone notch enable
        /// </summary>
        public void GetMultiToneToneNotchEnable(IAWG awg)
        {
            awg.GetMultiToneToneNotchEnable();
        }

        /// <summary>
        /// Compare actual to expected and report
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedState"></param>
        public void MultiToneToneNotchEnableShouldBe(IAWG awg, BoolState expectedState)
        {
            var expectedSetting = "";
            var actualSetting = awg.MultiToneNotchEnable;

            switch (expectedState)
            {
                case BoolState.Off:
                    expectedSetting = SyntaxForBoolStateOff;
                    break;
                case BoolState.On:
                    expectedSetting = SyntaxForBoolStateOn;
                    break;
            }
            var possibleErrorString = "Expected: " + expectedSetting + " Actual: " + actualSetting;
            Assert.AreEqual(expectedSetting, actualSetting, possibleErrorString);
        }

        #endregion

        #region MTONe:TONes:NOTCh16:STARt[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone notch start
        /// </summary>
        public void SetMultiToneToneNotchStart(IAWG awg, NumericEntryAs setValueAs, string setValue, string notchIndex)
        {
            var finalValue = setValue;
            switch (setValueAs)
            {
                case NumericEntryAs.Max:
                    finalValue = SyntaxForNumericAsMax;
                    break;
                case NumericEntryAs.Min:
                    finalValue = SyntaxForNumericAsMin;
                    break;
            }
            awg.SetMultiToneToneNotchStart(finalValue, notchIndex);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone notch start
        /// </summary>
        public void GetMultiToneToneNotchStart(IAWG awg, string notchIndex)
        {
            awg.GetMultiToneToneNotchStart(notchIndex);
        }

        /// <summary>
        /// Compare actual to expected and report
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedValue"></param>
        public void MultiToneNotchStartShouldBe(IAWG awg, string expectedValue)
        {
            var expectedSetting = expectedValue;
            var actualSetting = awg.MultiToneNotchStart;

            var possibleErrorString = "Expected: " + expectedSetting + " Actual: " + actualSetting;
            Assert.AreEqual(float.Parse(expectedValue), float.Parse(actualSetting), possibleErrorString);
        }

        #endregion

        #region MTONe:TONes:NOTCh16:END[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone notch end
        /// </summary>
        public void SetMultiToneToneNotchEnd(IAWG awg, NumericEntryAs setValueAs, string setValue, string notchIndex)
        {
            var finalValue = setValue;
            switch (setValueAs)
            {
                case NumericEntryAs.Max:
                    finalValue = SyntaxForNumericAsMax;
                    break;
                case NumericEntryAs.Min:
                    finalValue = SyntaxForNumericAsMin;
                    break;
            }
            awg.SetMultiToneToneNotchEnd(finalValue, notchIndex);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone notch end
        /// </summary>
        public void GetMultiToneToneNotchEnd(IAWG awg, string notchIndex)
        {
            awg.GetMultiToneToneNotchEnd(notchIndex);
        }

        /// <summary>
        /// Compare actual to expected and report
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedValue"></param>
        public void MultiToneNotchEndShouldBe(IAWG awg, string expectedValue)
        {
            var expectedSetting = expectedValue;
            var actualSetting = awg.MultiToneNotchEnd;

            var possibleErrorString = "Expected: " + expectedSetting + " Actual: " + actualSetting;
            Assert.AreEqual(float.Parse(expectedValue), float.Parse(actualSetting), possibleErrorString);
        }

        #endregion

        #region MTONe:TONes:NOTCh16:DELete

        //dstockwe 2014/11/20
        /// <summary>
        /// Deletes specified notch(es)
        /// </summary>
        public void DeleteMultiToneToneNotch(IAWG awg, DeleteEntryAs del, string notchIndex)
        {
            string all = "";

            if (del == DeleteEntryAs.All)
            {
                all = SyntaxForAll;
                notchIndex = "1";
            }

            awg.DeleteMultiToneToneNotch(all, notchIndex);
        }

        #endregion

        #region MTONe:TONes:NOTCh16:COUNT[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone notch
        /// </summary>
        public void GetMultiToneToneNotchCount(IAWG awg)
        {
            awg.GetMultiToneToneNotchCount();
        }

        /// <summary>
        /// Compare actual to expected and report
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedValue"></param>
        public void MultiToneNotchCountShouldBe(IAWG awg, string expectedValue)
        {
            var expectedSetting = expectedValue;
            var actualSetting = awg.MultiToneNotchCount;

            var possibleErrorString = "Expected: " + expectedSetting + " Actual: " + actualSetting;
            Assert.AreEqual(float.Parse(expectedValue), float.Parse(actualSetting), possibleErrorString);
        }

        #endregion


        #region MTONe:CHIRp:LOW[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone chirp low
        /// </summary>
        public void SetMultiToneChirpLow(IAWG awg, NumericEntryAs setValueAs, string setValue)
        {
            var finalValue = setValue;
            switch (setValueAs)
            {
                case NumericEntryAs.Max:
                    finalValue = SyntaxForNumericAsMax;
                    break;
                case NumericEntryAs.Min:
                    finalValue = SyntaxForNumericAsMin;
                    break;
            }
            awg.SetMultiToneChirpLow(finalValue);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone chirp low
        /// </summary>
        public void GetMultiToneChirpLow(IAWG awg)
        {
            awg.GetMultiToneChirpLow();
        }

        /// <summary>
        /// Compare actual to expected and report
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedValue"></param>
        public void MultiToneChirpLowShouldBe(IAWG awg, string expectedValue)
        {
            var expectedSetting = expectedValue;
            var actualSetting = awg.MultiToneChirpLow;

            var possibleErrorString = "Expected: " + expectedSetting + " Actual: " + actualSetting;
            Assert.AreEqual(float.Parse(expectedValue), float.Parse(actualSetting), possibleErrorString);
        }

        #endregion

        #region MTONe:CHIRp:HIGH[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone chirp high
        /// </summary>
        public void SetMultiToneChirpHigh(IAWG awg, NumericEntryAs setValueAs, string setValue)
        {
            var finalValue = setValue;
            switch (setValueAs)
            {
                case NumericEntryAs.Max:
                    finalValue = SyntaxForNumericAsMax;
                    break;
                case NumericEntryAs.Min:
                    finalValue = SyntaxForNumericAsMin;
                    break;
            }
            awg.SetMultiToneChirpHigh(finalValue);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone chirp high
        /// </summary>
        public void GetMultiToneChirpHigh(IAWG awg)
        {
            awg.GetMultiToneChirpHigh();
        }

        /// <summary>
        /// Compare actual to expected and report
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedValue"></param>
        public void MultiToneChirpHighShouldBe(IAWG awg, string expectedValue)
        {
            var expectedSetting = expectedValue;
            var actualSetting = awg.MultiToneChirpHigh;

            var possibleErrorString = "Expected: " + expectedSetting + " Actual: " + actualSetting;
            Assert.AreEqual(float.Parse(expectedValue), float.Parse(actualSetting), possibleErrorString);
        }

        #endregion

        #region MTONe:CHIRp:SRATe[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone chirp sweep rate
        /// </summary>
        public void SetMultiToneChirpSweepRate(IAWG awg, NumericEntryAs setValueAs, string setValue)
        {
            var finalValue = setValue;
            switch (setValueAs)
            {
                case NumericEntryAs.Max:
                    finalValue = SyntaxForNumericAsMax;
                    break;
                case NumericEntryAs.Min:
                    finalValue = SyntaxForNumericAsMin;
                    break;
            }
            awg.SetMultiToneChirpSweepRate(finalValue);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone chirp sweep rate
        /// </summary>
        public void GetMultiToneChirpSweepRate(IAWG awg)
        {
            awg.GetMultiToneChirpSweepRate();
        }

        /// <summary>
        /// Compare actual to expected and report
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedValue"></param>
        public void MultiToneChirpSweepRateShouldBe(IAWG awg, string expectedValue)
        {
            var expectedSetting = expectedValue;
            var actualSetting = awg.MultiToneChirpSweepRate;

            var possibleErrorString = "Expected: " + expectedSetting + " Actual: " + actualSetting;
            Assert.AreEqual(float.Parse(expectedValue), float.Parse(actualSetting), possibleErrorString);
        }

        #endregion

        #region MTONe:CHIRp:STIMe[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone chirp sweep time
        /// </summary>
        public void SetMultiToneChirpSweepTime(IAWG awg, NumericEntryAs setValueAs, string setValue)
        {
            var finalValue = setValue;
            switch (setValueAs)
            {
                case NumericEntryAs.Max:
                    finalValue = SyntaxForNumericAsMax;
                    break;
                case NumericEntryAs.Min:
                    finalValue = SyntaxForNumericAsMin;
                    break;
            }
            awg.SetMultiToneChirpSweepTime(finalValue);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone chirp sweep time
        /// </summary>
        public void GetMultiToneChirpSweepTime(IAWG awg)
        {
            awg.GetMultiToneChirpSweepTime();
        }

        /// <summary>
        /// Compare actual to expected and report
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedValue"></param>
        public void MultiToneChirpSweepTimeShouldBe(IAWG awg, string expectedValue)
        {
            var expectedSetting = expectedValue;
            var actualSetting = awg.MultiToneChirpSweepTime;

            var possibleErrorString = "Expected: " + expectedSetting + " Actual: " + actualSetting;
            Assert.AreEqual(float.Parse(expectedValue), float.Parse(actualSetting), possibleErrorString);
        }

        #endregion

        #region MTONe:CHIRp:FSWeep[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone chirp frequency sweep
        /// </summary>
        public void SetMultiToneChirpFrequencySweep(IAWG awg, ChirpFrequencySweep frequencySweep)
        {
            var typeSetting = "";
            switch (frequencySweep)
            {
                case ChirpFrequencySweep.LowHigh:
                    typeSetting = SyntaxForFrequencySweepLowHigh;
                    break;
                case ChirpFrequencySweep.HighLow:
                    typeSetting = SyntaxForFrequencySweepHighLow;
                    break;
            }
            awg.SetMultiToneChirpFrequencySweep(typeSetting);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone chirp frequency sweep
        /// </summary>
        public void GetMultiToneFrequencySweep(IAWG awg)
        {
            awg.GetMultiToneFrequencySweep();
        }

        /// <summary>
        /// Compare actual to expected and report
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedState"></param>
        public void MultiToneFrequencySweepShouldBe(IAWG awg, ChirpFrequencySweep expectedState)
        {
            var expectedSetting = "";
            var actualSetting = awg.MultiToneChirpFrequencySweep;

            switch (expectedState)
            {
                case ChirpFrequencySweep.HighLow:
                    expectedSetting = SyntaxForFrequencySweepHighLow;
                    break;
                case ChirpFrequencySweep.LowHigh:
                    expectedSetting = SyntaxForFrequencySweepLowHigh;
                    break;
            }
            var possibleErrorString = "Expected: " + expectedSetting + " Actual: " + actualSetting;
            Assert.AreEqual(expectedSetting, actualSetting, possibleErrorString);
        }

        #endregion

        #endregion MultiTone
    }
}