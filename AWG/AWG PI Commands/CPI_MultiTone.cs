
namespace AwgTestFramework
{
    public partial class CPi70KCmds
    {
        #region MultiTone

        #region MTONE:RESEt
        //sdas2 9/1/2015
        /// <summary>
        /// reset Multitone Module
        /// </summary>

         public void AwgMultiToneReset()
        {
            const string commandLine = "MTONe:RESEt";
            _mAWGVisaSession.Write(commandLine);

        }
        #endregion

        #region MTONe:LOAD

        //dstockwe 2014/11/20
        /// <summary>
        /// Load MultiTone module
        /// </summary>
        public void AwgMultiToneLoad()
        {
            string commandLine = "WMODule:ACTive " + '"' + "Multitone" + '"'; 
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion

        #region MTONe:TYPE[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone Type
        /// </summary>
        public void SetMultiToneType(string setValue)
        {
            var commandLine = "MTONe:TYPE " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone Type
        /// </summary>
        public string GetMultiToneType()
        {
            string response;
            const string commandLine = "MTONe:TYPE?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion



        #region MTONe:COMPile

        //dstockwe 2014/11/20
        /// <summary>
        /// Compile MultiTone module
        /// </summary>
        public void AwgMultiToneCompile()
        {
            const string commandLine = "MTONe:COMPile";
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion

        #region MTONe:COMPile:CANCel

        //dstockwe 2014/11/20
        /// <summary>
        /// Cancels an active compile in MultiTone module
        /// </summary>
        public void AwgMultiToneCancelCompile()
        {
            const string commandLine = "MTONe:COMPile:CANCel";
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion

        #region MTONe:COMPile:NAME[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone Name
        /// </summary>
        public void SetMultiToneName(string setValue)
        {
            var commandLine = "MTONe:COMPile:NAME " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone Name
        /// </summary>
        public string GetMultiToneName()
        {
            string response;
            const string commandLine = "MTONe:COMPile:NAME?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion

        #region MTONe:COMPile:CHANnel[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone Assign to Channel
        /// </summary>
        public void SetMultiToneChannel(string setValue)
        {
            var commandLine = "MTONe:COMPile:CHANnel " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone Assign to Channel
        /// </summary>
        public string GetMultiToneChannel()
        {
            string response;
            const string commandLine = "MTONe:COMPile:CHANnel?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion

        #region MTONe:COMPile:PLAY[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone Assign to Channel and Play
        /// </summary>
        public void SetMultiToneChannelPlay(string setValue)
        {
            var commandLine = "MTONe:COMPile:PLAY " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone Assign to Channel and Play
        /// </summary>
        public string GetMultiToneChannelPlay()
        {
            string response;
            const string commandLine = "MTONe:COMPile:PLAY?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion

        #region MTONe:COMPile:SRATe[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone desired sampling rate
        /// </summary>
        public void SetMultiToneSamplingRate(string setValue)
        {
            var commandLine = "MTONe:COMPile:SRATe " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone desired sampling rate
        /// </summary>
        public string GetMultiToneSamplingRate()
        {
            string response;
            const string commandLine = "MTONe:COMPile:SRATe?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion

        #region MTONe:COMPile:SRATe:AUTO[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone auto desired sampling rate
        /// </summary>
        public void SetMultiToneAutoSamplingRate(string setValue)
        {
            var commandLine = "MTONe:COMPile:SRATe:AUTO " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone auto desired sampling rate
        /// </summary>
        public string GetMultiToneAutoSamplingRate()
        {
            string response;
            const string commandLine = "MTONe:COMPile:SRATe:AUTO?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion



        #region MTONe:TONes:STARt[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone start
        /// </summary>
        public void SetMultiToneToneStart(string setValue)
        {
            var commandLine = "MTONe:TONes:STARt " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone start
        /// </summary>
        public string GetMultiToneToneStart()
        {
            string response;
            const string commandLine = "MTONe:TONes:STARt?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion

        #region MTONe:TONes:END[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone end
        /// </summary>
        public void SetMultiToneToneEnd(string setValue)
        {
            var commandLine = "MTONe:TONes:END " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone end
        /// </summary>
        public string GetMultiToneToneEnd()
        {
            string response;
            const string commandLine = "MTONe:TONes:END?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion

        #region MTONe:TONes:SPACing[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone spacing
        /// </summary>
        public void SetMultiToneToneSpacing(string setValue)
        {
            var commandLine = "MTONe:TONes:SPACing " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone spacing
        /// </summary>
        public string GetMultiToneToneSpacing()
        {
            string response;
            const string commandLine = "MTONe:TONes:SPACing?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion

        #region MTONe:TONes:NTONes[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone number of tones
        /// </summary>
        public void SetMultiToneToneNTones(string setValue)
        {
            var commandLine = "MTONe:TONes:NTONes " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone number of tones
        /// </summary>
        public string GetMultiToneToneNTones()
        {
            string response;
            const string commandLine = "MTONe:TONes:NTONes?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion

        #region MTONe:TONes:PHASe[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone Phase
        /// </summary>
        public void SetMultiToneTonePhase(string setValue)
        {
            var commandLine = "MTONe:TONes:PHASe " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone Phase
        /// </summary>
        public string GetMultiToneTonePhase()
        {
            string response;
            const string commandLine = "MTONe:TONes:PHASe?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion

        #region MTONe:TONes:PHASe:UNDEFined[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone Phase User Defined
        /// </summary>
        public void SetMultiToneTonePhaseUserDefined(string setValue)
        {
            var commandLine = "MTONe:TONes:PHASe:UDEFined " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone Phase User Defined
        /// </summary>
        public string GetMultiToneTonePhaseUserDefined()
        {
            string response;
            const string commandLine = "MTONe:TONes:PHASe:UDEFined?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion



        #region MTONe:TONes:NOTCh16[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone notch
        /// </summary>
        public void SetMultiToneToneNotch(string setValue, string notchIndex = "1")
        {
            var commandLine = "MTONe:TONes:NOTCh" + notchIndex + " " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone notch
        /// </summary>
        public string GetMultiToneToneNotch(string notchIndex = "1")
        {
            string response;
            var commandLine = "MTONe:TONes:NOTCh" + notchIndex + "?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion

        #region MTONe:TONes:NOTCh16:ADD

        //dstockwe 2014/11/20
        /// <summary>
        /// Add MultiTone tone notch
        /// </summary>
        public void SetMultiToneToneNotchAdd(string setStartValue, string setEndValue, string notchIndex = "1")
        {
            var commandLine = "MTONe:TONes:NOTCh" + notchIndex + ":ADD " + setStartValue + ", " + setEndValue;
            _mAWGVisaSession.Write(commandLine);
        }
        
        #endregion

        #region MTONe:TONes:NOTCh16:ENABle[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone notch enable
        /// </summary>
        public void SetMultiToneToneNotchEnable(string setValue)
        {
            var commandLine = "MTONe:TONes:NOTCh:ENABle " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone notch enable
        /// </summary>
        public string GetMultiToneToneNotchEnable()
        {
            string response;
            const string commandLine = "MTONe:TONes:NOTCh:ENABle?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion

        #region MTONe:TONes:NOTCh16:STARt[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone notch start
        /// </summary>
        public void SetMultiToneToneNotchStart(string setValue, string notchIndex = "1")
        {
            var commandLine = "MTONe:TONes:NOTCh" + notchIndex + ":STARt " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone notch start
        /// </summary>
        public string GetMultiToneToneNotchStart(string notchIndex = "1")
        {
            string response;
            var commandLine = "MTONe:TONes:NOTCh" + notchIndex + ":STARt?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion

        #region MTONe:TONes:NOTCh16:END[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone tone notch end
        /// </summary>
        public void SetMultiToneToneNotchEnd(string setValue, string notchIndex = "1")
        {
            var commandLine = "MTONe:TONes:NOTCh" + notchIndex + ":END " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone notch end
        /// </summary>
        public string GetMultiToneToneNotchEnd(string notchIndex = "1")
        {
            string response;
            var commandLine = "MTONe:TONes:NOTCh" + notchIndex + ":END?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion

        #region MTONe:TONes:NOTCh16:DELete

        //dstockwe 2014/11/20
        /// <summary>
        /// Deletes specified notch(es)
        /// </summary>
        public void DeleteMultiToneToneNotch(string setValue, string notchIndex)
        {
            if (string.IsNullOrEmpty(setValue))
                setValue = "";

            var commandLine = "MTONe:TONes:NOTCh" + notchIndex + ":DELete " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion

        #region MTONe:TONes:NOTCh16:COUNT[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone tone notch
        /// </summary>
        public string GetMultiToneToneNotchCount()
        {
            string response;
            const string commandLine = "MTONe:TONes:NOTCh:COUNt?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion



        #region MTONe:CHIRp:LOW[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone chirp low
        /// </summary>
        public void SetMultiToneChirpLow(string setValue)
        {
            var commandLine = "MTONe:CHIRp:LOW " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone chirp low
        /// </summary>
        public string GetMultiToneChirpLow()
        {
            string response;
            const string commandLine = "MTONe:CHIRp:LOW?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion

        #region MTONe:CHIRp:HIGH[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone chirp high
        /// </summary>
        public void SetMultiToneChirpHigh(string setValue)
        {
            var commandLine = "MTONe:CHIRp:HIGH " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone chirp high
        /// </summary>
        public string GetMultiToneChirpHigh()
        {
            string response;
            const string commandLine = "MTONe:CHIRp:HIGH?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion

        #region MTONe:CHIRp:SRATe[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone chirp sweep rate
        /// </summary>
        public void SetMultiToneChirpSweepRate(string setValue)
        {
            var commandLine = "MTONe:CHIRp:SRATe " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone chirp sweep rate
        /// </summary>
        public string GetMultiToneChirpSweepRate()
        {
            string response;
            const string commandLine = "MTONe:CHIRp:SRATe?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion

        #region MTONe:CHIRp:STIMe[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone chirp sweep time
        /// </summary>
        public void SetMultiToneChirpSweepTime(string setValue)
        {
            var commandLine = "MTONe:CHIRp:STIMe " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone chirp sweep time
        /// </summary>
        public string GetMultiToneChirpSweepTime()
        {
            string response;
            const string commandLine = "MTONe:CHIRp:STIMe?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion

        #region MTONe:CHIRp:FSWeep[?]

        //dstockwe 2014/11/20
        /// <summary>
        /// Set MultiTone chirp frequency sweep
        /// </summary>
        public void SetMultiToneChirpFrequencySweep(string setValue)
        {
            var commandLine = "MTONe:CHIRp:FSWeep " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //dstockwe 2014/11/20
        /// <summary>
        /// Get MultiTone chirp frequency sweep
        /// </summary>
        public string GetMultiToneChirpFrequencySweep()
        {
            string response;
            const string commandLine = "MTONe:CHIRp:FSWeep?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion

        #endregion MultiTone
    }
}