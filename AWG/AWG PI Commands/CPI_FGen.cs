

namespace AwgTestFramework
{
    public partial class CPi70KCmds
    {
        #region FGen

        #region FGEN:CHANnel:AMPLitude

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:AMPLitude set the amplitude value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Function generator amplitude value</param>
        public void SetAwgFGenChannelAmplitude(string channel, string setValue)
        {
            string commandLine = "FGEN:CHANnel" + channel + ":AMPLitude " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:AMPLitude? get the amplitude value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <returns>Function generator amplitude value</returns>
        public string GetAwgFGenChannelAmplitude(string channel)
        {
            string response;
            string commandLine = "FGEN:CHANnel" + channel + ":AMPLitude?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion FGEN:CHANnel:AMPLitude

        #region FGEN:CHANnel:FREQuency
        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:FREQuency set the low value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Function generator low value</param>
        public void SetAwgFGenChannelFrequency(string channel, string setValue)
        {
            string commandLine = "FGEN:CHANnel" + channel + ":FREQuency " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:FREQuency? get the low value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        public string GetAwgFGenChannelFrequency(string channel)
        {
            string response;
            string commandLine = "FGEN:CHANnel" + channel + ":FREQuency?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion FGEN:CHANnel:FREQuency

        #region FGEN:CHANnel:DCLevel

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:DCLevel set the DC Level value for the given channel
        /// </summary>
        /// <param name="setValue">Function generator dclevel value</param>
        /// <param name="channel">Which channel</param>
        public void SetAwgFGenChannelDCLevel(string channel, string setValue)
        {
            string commandLine = "FGEN:CHANnel" + channel + ":DCLevel " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:DCLevel? get the DC Level value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <returns>Function generator DC Level value</returns>
        public string GetAwgFGenChannelDCLevel(string channel)
        {
            string response;
            string commandLine = "FGEN:CHANnel" + channel + ":DCLevel?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion FGEN:CHANnel:DCLevel

        #region FGEN:CHANnel:HIGH

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:HIGH set the high value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Function generator high value</param>
        public void SetAwgFGenChannelHigh(string channel, string setValue) 
        {
            string commandLine = "FGEN:CHANnel" + channel + ":HIGH " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:HIGH? get the high value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <returns>Function generator high value</returns>
        public string GetAwgFGenChannelHigh(string channel)
        {
            string response;
            string commandLine = "FGEN:CHANnel" + channel + ":HIGH?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion FGEN:CHANnel:HIGH

        #region FGEN:CHANnel:LOW

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:LOW set the low value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Function generator low value</param>
        public void SetAwgFGenChannelLow(string channel, string setValue)
        {
            string commandLine = "FGEN:CHANnel" + channel + ":LOW " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:LOW? get the low value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <returns>Function generator low value</returns>
        public string GetAwgFGenChannelLow(string channel)
        {
            string response;
            string commandLine = "FGEN:CHANnel" + channel + ":LOW?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion FGEN:CHANnel:LOW

        #region FGEN:CHANnel:OFFSet

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:OFFset set the offset value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Function generator offset value</param>
        public void SetAwgFGenChannelOffset(string channel, string setValue)
        {
            string commandLine = "FGEN:CHANnel" + channel + ":OFFset " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:OFFset? get the offset value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <returns>Function generator offset value</returns>
        public string GetAwgFGenChannelOffset(string channel)
        {
            string response;
            string commandLine = "FGEN:CHANnel" + channel + ":OFFset?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion FGEN:CHANnel:OFFSet

        #region FGEN:CHANnel:PERiod?

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:PERiod? get the period value for the given channel<para>
        /// (Query Only)</para>
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <returns>Function generator period value</returns>
        public string GetAwgFGenChannelPeriod(string channel)
        {
            string response;
            string commandLine = "FGEN:CHANnel" + channel + ":PERiod?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion FGEN:CHANnel:PERiod?

        #region FGEN:CHANnel:PHASe

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:PHASe set the phase value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Function generator phase value</param>
        public void SetAwgFGenChannelPhase(string channel, string setValue)
        {
            string commandLine = "FGEN:CHANnel" + channel + ":PHASe " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:PHASe? get the phase value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <returns>Function generator phase value</returns>
        public string GetAwgFGenChannelPhase(string channel)
        {
            string response;
            string commandLine = "FGEN:CHANnel" + channel + ":PHASe?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion FGEN:CHANnel:PHASe

        #region FGEN:CHANnel:SYMMetry

        //glennj 1/7/2014
        /// <summary>
        /// Using FGEN:CHANnel:SYMMetry set the symmetry value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">symmetry value</param>
        public void SetAwgFGenChannelSymmetry(string channel, string setValue)
        {
            string commandLine = "FGEN:CHANnel" + channel + ":SYMMetry " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:SYMMetry? get the symmetry value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <returns>Function generator symmetry value</returns>
        public string GetAwgFGenChannelSymmetry(string channel)
        {
            string response;
            string commandLine = "FGEN:CHANnel" + channel + ":SYMMetry?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion FGEN:CHANnel:SYMMetry

        #region FGEN:CHANnel:TYPE

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:TYPE set the waveform type for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Waveform type</param>
        public void SetAwgFGenChannelType(string channel, string setValue)
        {
            string commandLine = "FGEN:CHANnel" + channel + ":TYPE " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:CHANnel:TYPE? get the waveform type for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <returns>Function generator waveform type</returns>
        public string GetAwgFGenChannelType(string channel)
        {
            string response;
            string commandLine = "FGEN:CHANnel" + channel + ":TYPE?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        
        #endregion FGEN:CHANnel:TYPE

        #region FGEN:COUPle:AMPLitude

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:COUPle:AMPLitude set the coupling amplitude Value
        /// </summary>
        /// <param name="setValue">FGen couple state</param>
        public void SetAwgFGenCoupleAmpl(string setValue)
        {
            string commandLine = "FGEN:COUPle:AMPLitude " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 1/7/2014
        /// <summary>
        /// Using FGEN:COUPle:AMPLitude? get the state of the coupling amplitude.<para>
        /// For the 70k, the use of a channel is not valid and is ignored.</para><para>
        /// It is here for consistency.</para>
        /// </summary>
        /// <returns>Function Generator coupling frequency value</returns>
        public string GetAwgFGenCoupleAmpl(string logicalChannel = "1")
        {
            string response;
            const string commandLine = "FGEN:COUPle:AMPLitude?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion FGEN:COUPle:AMPLitude

        #region Postponed

        #region FGEN:COUPle:FREQeuncy

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:COUPle:FREQeuncy set the coupling frequency state
        /// </summary>
        /// <param name="setValue">FGen couple state</param>
        public void SetAwgFGenCoupleFreq(string setValue)
        {
            string commandLine = "FGEN:COUPle:FREQuency " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:COUPle:FREQeuncy? get the state of the coupling frequency<para>
        /// For the 70k, the use of a channel is not valid and is ignored.</para><para>
        /// It is here for consistency.</para>
        /// </summary>
        /// <returns>Function Generator coupling frequency value</returns>
        public string GetAwgFGenCoupleFreq(string logicalChannel = "1")
        {
            string response;
            const string commandLine = "FGEN:COUPle:FREQuency?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion FGEN:COUPle:FREQeuncy

        #endregion Postponed

        #endregion FGen
    }
}
