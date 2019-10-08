// ReSharper disable CheckNamespace
namespace AwgTestFramework
// ReSharper restore CheckNamespace
{

    public partial class AWG
    {
        #region MultiTone types

        /// <summary>
        /// Property for MultiTone Type
        /// </summary>
        public string MultiToneType { get; set; }

        public string MultiToneName { get; set; }

        public string MultiToneChannel { get; set; }

        public string MultiToneChannelPlay { get; set; }

        public string MultiToneSamplingRate { get; set; }

        public string MultiToneSamplingRateAuto { get; set; }

        public string MultiToneToneStart { get; set; }

        public string MultiToneToneEnd { get; set; }

        public string MultiToneToneSpacing { get; set; }

        public string MultiToneToneNumTones { get; set; }

        public string MultiToneTonePhase { get; set; }

        public string MultiToneTonePhaseUserDefined { get; set; }

        public string MultiToneNotchEnable { get; set; }

        /// <summary>
        /// Contains both start and end in a single line
        /// </summary>
        public string MultiToneNotchStartEnd { get; set; }

        public string MultiToneNotchStart { get; set; }

        public string MultiToneNotchEnd { get; set; }

        public string MultiToneNotchCount { get; set; }

        public string MultiToneChirpLow { get; set; }

        public string MultiToneChirpHigh { get; set; }

        public string MultiToneChirpSweepRate { get; set; }

        public string MultiToneChirpSweepTime { get; set; }

        public string MultiToneChirpFrequencySweep { get; set; }

        #endregion 


        #region MultiTone

        #region MTONE:RESEt
        //sdas2 9/1/2015
        /// <summary>
        /// Reset MTone Module 
        /// </summary>
        public void AwgMultiToneReset()
        {
            _pi.AwgMultiToneReset();
        }
        #endregion

        #region MTONe:LOAD

        //dstockwe 2014/11/20
        /// <summary>
        /// Load MultiTone module
        /// </summary>
        public void AwgMultiToneLoad()
        {
            _pi.AwgMultiToneLoad();
        }

        #endregion

        #region MTONe:TYPE[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone Type
        /// </summary>
        public void SetMultiToneType(string setValue)
        {
            _pi.SetMultiToneType(setValue);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone Type
        /// </summary>
        public void GetMultiToneType()
        {
            MultiToneType = _pi.GetMultiToneType();
        }

        #endregion

        #region MTONe:COMPile

        //dstockwe 2014/11/20
        /// <summary>
        /// Compile MultiTone module
        /// </summary>
        public void StartMultiToneCompile()
        {
            _pi.AwgMultiToneCompile();
        }

        #endregion

        #region MTONe:COMPile:CANCel

        //dstockwe 2014/11/20
        /// <summary>
        /// Cancels an active compile in MultiTone module
        /// </summary>
        public void MultiToneCancelCompile()
        {
            _pi.AwgMultiToneCancelCompile();
        }

        #endregion

        #region MTONe:COMPile:NAME[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone Name
        /// </summary>
        public void SetMultiToneName(string setValue)
        {
            _pi.SetMultiToneName(setValue);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone Name
        /// </summary>
        public void GetMultiToneName()
        {
            MultiToneName = _pi.GetMultiToneName();
        }

        #endregion

        #region MTONe:COMPile:CHANnel[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone Assign to Channel
        /// </summary>
        public void SetMultiToneChannel(string setValue)
        {
            _pi.SetMultiToneChannel(setValue);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone Assign to Channel
        /// </summary>
        public void GetMultiToneChannel()
        {
            MultiToneChannel = _pi.GetMultiToneChannel();
        }

        #endregion

        #region MTONe:COMPile:PLAY[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone Assign to Channel and Play
        /// </summary>
        public void SetMultiToneChannelPlay(string setValue)
        {
            _pi.SetMultiToneChannelPlay(setValue);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone Assign to Channel and Play
        /// </summary>
        public void GetMultiToneChannelPlay()
        {
            MultiToneChannelPlay = _pi.GetMultiToneChannelPlay();
        }

        #endregion

        #region MTONe:COMPile:SRATe[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone desired sampling rate
        /// </summary>
        public void SetMultiToneSamplingRate(string setValue)
        {
            _pi.SetMultiToneSamplingRate(setValue);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone desired sampling rate
        /// </summary>
        public void GetMultiToneSamplingRate()
        {
            MultiToneSamplingRate = _pi.GetMultiToneSamplingRate();
        }

        #endregion

        #region MTONe:COMPile:SRATe:AUTO[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone auto desired sampling rate
        /// </summary>
        public void SetMultiToneAutoSamplingRate(string setValue)
        {
            _pi.SetMultiToneAutoSamplingRate(setValue);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone auto desired sampling rate
        /// </summary>
        public void GetMultiToneAutoSamplingRate()
        {
            MultiToneSamplingRateAuto = _pi.GetMultiToneAutoSamplingRate();
        }

        #endregion



        #region MTONe:TONes:STARt[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone start
        /// </summary>
        public void SetMultiToneToneStart(string setValue)
        {
            _pi.SetMultiToneToneStart(setValue);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone start
        /// </summary>
        public void GetMultiToneToneStart()
        {
            MultiToneToneStart = _pi.GetMultiToneToneStart();
        }

        #endregion

        #region MTONe:TONes:END[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone end
        /// </summary>
        public void SetMultiToneToneEnd(string setValue)
        {
            _pi.SetMultiToneToneEnd(setValue);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone end
        /// </summary>
        public void GetMultiToneToneEnd()
        {
            MultiToneToneEnd = _pi.GetMultiToneToneEnd();
        }

        #endregion

        #region MTONe:TONes:SPACing[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone spacing
        /// </summary>
        public void SetMultiToneToneSpacing(string setValue)
        {
            _pi.SetMultiToneToneSpacing(setValue);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone spacing
        /// </summary>
        public void GetMultiToneToneSpacing()
        {
            MultiToneToneSpacing = _pi.GetMultiToneToneSpacing();
        }

        #endregion

        #region MTONe:TONes:NTONes[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone number of tones
        /// </summary>
        public void SetMultiToneToneNTones(string setValue)
        {
            _pi.SetMultiToneToneNTones(setValue);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone number of tones
        /// </summary>
        public void GetMultiToneToneNTones()
        {
            MultiToneToneNumTones = _pi.GetMultiToneToneNTones();
        }

        #endregion

        #region MTONe:TONes:PHASe[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone Phase
        /// </summary>
        public void SetMultiToneTonePhase(string setValue)
        {
            _pi.SetMultiToneTonePhase(setValue);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone Phase
        /// </summary>
        public void GetMultiToneTonePhase()
        {
            MultiToneTonePhase = _pi.GetMultiToneTonePhase();
        }

        #endregion

        #region MTONe:TONes:PHASe:UDEFined[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone Phase User Defined
        /// </summary>
        public void SetMultiToneTonePhaseUserDefined(string setValue)
        {
            _pi.SetMultiToneTonePhaseUserDefined(setValue);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone Phase User Defined
        /// </summary>
        public void GetMultiToneTonePhaseUserDefined()
        {
            MultiToneTonePhaseUserDefined = _pi.GetMultiToneTonePhaseUserDefined();
        }

        #endregion



        #region MTONe:TONes:NOTCh16[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone notch
        /// </summary>
        public void SetMultiToneToneNotch(string setValue, string notchIndex)
        {
            _pi.SetMultiToneToneNotch(setValue, notchIndex);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone notch
        /// </summary>
        public void GetMultiToneToneNotch(string notchIndex)
        {
            MultiToneNotchStartEnd = _pi.GetMultiToneToneNotch(notchIndex);
        }

        #endregion

        #region MTONe:TONes:NOTCh16:ADD

        //dstockwe 2014/11/20
        /// <summary>
        /// Add MultiTone tone notch
        /// </summary>
        public void SetMultiToneToneNotchAdd(string setStartValue, string setEndValue)
        {
            _pi.SetMultiToneToneNotchAdd(setStartValue, setEndValue);
        }

        #endregion

        #region MTONe:TONes:NOTCh16:ENABle[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone notch enable
        /// </summary>
        public void SetMultiToneToneNotchEnable(string setValue)
        {
            _pi.SetMultiToneToneNotchEnable(setValue);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone notch enable
        /// </summary>
        public void GetMultiToneToneNotchEnable()
        {
            MultiToneNotchEnable = _pi.GetMultiToneToneNotchEnable();
        }

        #endregion

        #region MTONe:TONes:NOTCh16:STARt[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone notch start
        /// </summary>
        public void SetMultiToneToneNotchStart(string setValue, string notchIndex)
        {
            _pi.SetMultiToneToneNotchStart(setValue, notchIndex);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone notch start
        /// </summary>
        public void GetMultiToneToneNotchStart(string notchIndex)
        {
            MultiToneNotchStart = _pi.GetMultiToneToneNotchStart(notchIndex);
        }

        #endregion

        #region MTONe:TONes:NOTCh16:END[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone notch end
        /// </summary>
        public void SetMultiToneToneNotchEnd(string setValue, string notchIndex)
        {
            _pi.SetMultiToneToneNotchEnd(setValue, notchIndex);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone notch end
        /// </summary>
        public void GetMultiToneToneNotchEnd(string notchIndex)
        {
            MultiToneNotchEnd = _pi.GetMultiToneToneNotchEnd(notchIndex);
        }

        #endregion

        #region MTONe:TONes:NOTCh16:DELete

        //dstockwe 2014/11/20
        /// <summary>
        /// Deletes specified notch(es)
        /// </summary>
        public void DeleteMultiToneToneNotch(string setValue, string notchIndex)
        {
            _pi.DeleteMultiToneToneNotch(setValue, notchIndex);
        }

        #endregion

        #region MTONe:TONes:NOTCh16:COUNT[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone notch
        /// </summary>
        public void GetMultiToneToneNotchCount()
        {
            MultiToneNotchCount = _pi.GetMultiToneToneNotchCount();
        }

        #endregion



        #region MTONe:CHIRp:LOW[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone chirp low
        /// </summary>
        public void SetMultiToneChirpLow(string setValue)
        {
            _pi.SetMultiToneChirpLow(setValue);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone chirp low
        /// </summary>
        public void GetMultiToneChirpLow()
        {
            MultiToneChirpLow = _pi.GetMultiToneChirpLow();
        }

        #endregion

        #region MTONe:CHIRp:HIGH[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone chirp high
        /// </summary>
        public void SetMultiToneChirpHigh(string setValue)
        {
            _pi.SetMultiToneChirpHigh(setValue);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone chirp high
        /// </summary>
        public void GetMultiToneChirpHigh()
        {
            MultiToneChirpHigh = _pi.GetMultiToneChirpHigh();
        }

        #endregion

        #region MTONe:CHIRp:SRATe[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone chirp sweep rate
        /// </summary>
        public void SetMultiToneChirpSweepRate(string setValue)
        {
            _pi.SetMultiToneChirpSweepRate(setValue);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone chirp sweep rate
        /// </summary>
        public void GetMultiToneChirpSweepRate()
        {
            MultiToneChirpSweepRate = _pi.GetMultiToneChirpSweepRate();
        }

        #endregion

        #region MTONe:CHIRp:STIMe[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone chirp sweep time
        /// </summary>
        public void SetMultiToneChirpSweepTime(string setValue)
        {
            _pi.SetMultiToneChirpSweepTime(setValue);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone chirp sweep time
        /// </summary>
        public void GetMultiToneChirpSweepTime()
        {
            MultiToneChirpSweepTime = _pi.GetMultiToneChirpSweepTime();
        }

        #endregion

        #region MTONe:CHIRp:FSWeep[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone chirp frequency sweep
        /// </summary>
        public void SetMultiToneChirpFrequencySweep(string setValue)
        {
            _pi.SetMultiToneChirpFrequencySweep(setValue);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone chirp frequency sweep
        /// </summary>
        public void GetMultiToneFrequencySweep()
        {
            MultiToneChirpFrequencySweep = _pi.GetMultiToneChirpFrequencySweep();
        }

        #endregion

        #endregion MultiTone
    }
}
