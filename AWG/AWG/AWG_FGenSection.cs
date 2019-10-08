using System;

// ReSharper disable CheckNamespace
namespace AwgTestFramework
// ReSharper restore CheckNamespace
{
    public partial class AWG
    {

        private readonly string[] _fgenChannelAmplitude = new string[AwgMaxChannels];

        //glennj 06/20/2013
        /// <summary>
        /// Set the amplitude value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Function generator amplitude value</param>
        public void SetFGenChannelAmplitude(string channel, string setValue)
        {
            _pi.SetAwgFGenChannelAmplitude(channel, setValue);
        }

        //glennj 06/20/2013
        /// <summary>
        /// Force to update it's local copy of the amplitude value for the given channel
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        public void GetFGenChannelAmplitude(string logicalChannel)
        {
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                _fgenChannelAmplitude[channelNumber - 1] = _pi.GetAwgFGenChannelAmplitude(logicalChannel);
            }
        }

        //glennj 1/6/2014
        /// <summary>
        /// Given a logical channel, return the channel amplitude
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        public string FGenChannelAmplitude(string logicalChannel)
        {
            string fgenChannelAmplitude = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                fgenChannelAmplitude = _fgenChannelAmplitude[channelNumber - 1];
            }
            return fgenChannelAmplitude;
        }

        private readonly string[] _fgenChannelDCLevel = new string[AwgMaxChannels];

        //glennj 1/7/2014
        /// <summary>
        /// Set the DC Level value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Function generator dclevel value</param>
        public void SetFGenChannelDCLevel(string channel, string setValue)
        {
            _pi.SetAwgFGenChannelDCLevel(channel, setValue);
        }

        //glennj 06/20/2013
        /// <summary>
        /// Force to update it's local ocpy of the DC Level value for the given channel
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        /// <returns>Function generator DC Level value</returns>
        public void GetFGenChannelDCLevel(string logicalChannel)
        {
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                _fgenChannelDCLevel[channelNumber - 1] = _pi.GetAwgFGenChannelDCLevel(logicalChannel);
            }
        }

        //glennj 1/7/2014
        /// <summary>
        /// Given a logical channel, return the channel DC level
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        public string FGenChannelDcLevel(string logicalChannel)
        {
            string fGenChannelDcLevel = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                fGenChannelDcLevel = _fgenChannelDCLevel[channelNumber - 1];
            }
            return fGenChannelDcLevel;
        }

        private readonly string[] _fgenChannelFrequency = new string[AwgMaxChannels];

        //glennj 1/7/2014
        /// <summary>
        /// Set the frequency for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Function generator low value</param>
        public void SetFGenChannelFrequency(string channel, string setValue)
        {
            _pi.SetAwgFGenChannelFrequency(channel, setValue);
        }

        //glennj 1/7/2014
        /// <summary>
        /// Force to update it's local copy of the frequency for the given channel
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        public void GetFGenChannelFrequency(string logicalChannel)
        {
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                _fgenChannelFrequency[channelNumber - 1] = _pi.GetAwgFGenChannelFrequency(logicalChannel);
            }
        }

        //glennj 1/7/2014
        /// <summary>
        /// Given a logical channel, return the channel waveform type
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        public string FGenChannelFrequency(string logicalChannel)
        {
            string fGenChannelFrequency = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                fGenChannelFrequency = _fgenChannelFrequency[channelNumber - 1];
            }
            return fGenChannelFrequency;
        }

        private readonly string[] _fgenChannelHigh = new string[AwgMaxChannels];

        //glennj 1/7/2014
        /// <summary>
        /// Set the high value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Function generator high value</param>
        public void SetFGenChannelHigh(string channel, string setValue)
        {
            _pi.SetAwgFGenChannelHigh(channel, setValue);
        }

        //glennj 1/7/2014
        /// <summary>
        /// Force to update it's local copy of the high value for the given channel
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        /// <returns>Function generator high value</returns>
        public void GetFGenChannelHigh(string logicalChannel)
        {
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                _fgenChannelHigh[channelNumber - 1] = _pi.GetAwgFGenChannelHigh(logicalChannel);
            }
        }

        //glennj 1/7/2014
        /// <summary>
        /// Given a logical channel, return the channel high
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        public string FGenChannelHigh(string logicalChannel)
        {
            string fGenChannelHigh = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                fGenChannelHigh = _fgenChannelHigh[channelNumber - 1];
            }
            return fGenChannelHigh;
        }

        private readonly string[] _fgenChannelLow  = new string[AwgMaxChannels];

        //glennj 1/7/2014
        /// <summary>
        /// Using FGEN:CHANnel:LOW set the low value for the given channel
        /// </summary>
        /// <param name="setValue">Function generator low value</param>
        /// <param name="channel">Which channel</param>
        public void SetFGenChannelLow(string channel, string setValue)
        {
            _pi.SetAwgFGenChannelLow(channel, setValue);
        }

        //glennj 1/7/2014
        /// <summary>
        /// Force to update it's local copy of the low value for the given channel
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        /// <returns>Function generator low value</returns>
        public void GetFGenChannelLow(string logicalChannel)
        {
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                _fgenChannelLow[channelNumber - 1] = _pi.GetAwgFGenChannelLow(logicalChannel);
            }
        }

        //glennj 1/7/2014
        /// <summary>
        /// Given a logical channel, return the channel low
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        public string FGenChannelLow(string logicalChannel)
        {
            string fGenChannelLow = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                fGenChannelLow = _fgenChannelLow[channelNumber - 1];
            }
            return fGenChannelLow;
        }

        private readonly string[] _fgenChannelOffset = new string[AwgMaxChannels];

        //glennj 06/20/2013
        /// <summary>
        /// Set the offset value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Function generator offset value</param>
        public void SetFGenChannelOffset(string channel, string setValue)
        {
            _pi.SetAwgFGenChannelOffset(channel, setValue);
        }

        //glennj 06/20/2013
        /// <summary>
        /// Force to update it's local copy of the offset value for the given channel
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        /// <returns>Function generator offset value</returns>
        public void GetFGenChannelOffset(string logicalChannel)
        {
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                _fgenChannelOffset[channelNumber - 1] = _pi.GetAwgFGenChannelOffset(logicalChannel);
            }
        }

        //glennj 1/7/2014
        /// <summary>
        /// Given a logical channel, return the channel offset
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        public string FGenChannelOffset(string logicalChannel)
        {
            string fGenChannelOffset = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                fGenChannelOffset = _fgenChannelOffset[channelNumber - 1];
            }
            return fGenChannelOffset;
        }

        private readonly string[] _fgenChannelPeriod = new string[AwgMaxChannels];

        //glennj 1/7/2014
        /// <summary>
        /// Force to update it's local copy of the period value for the given channel<para>
        /// (Query Only)</para>
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        /// <returns>Function generator period value</returns>
        public void GetFGenChannelPeriod(string logicalChannel)
        {
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                _fgenChannelPeriod[channelNumber - 1] = _pi.GetAwgFGenChannelPeriod(logicalChannel);
            }
        }

        //glennj 1/7/2014
        /// <summary>
        /// Given a logical channel, return the channel period
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        public string FGenChannelPeriod(string logicalChannel)
        {
            string fGenChannelPeriod = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                fGenChannelPeriod = _fgenChannelPeriod[channelNumber - 1];
            }
            return fGenChannelPeriod;
        }

        private readonly string[] _fgenChannelPhase = new string[AwgMaxChannels];

        //glennj 1/7/2014
        /// <summary>
        /// Set the phase value for the given channel
        /// </summary>
        /// <param name="setValue">Function generator phase value</param>
        /// <param name="channel">Which channel</param>
        public void SetFGenChannelPhase(string channel, string setValue)
        {
            _pi.SetAwgFGenChannelPhase(channel, setValue);
        }

        //glennj 1/7/2014
        /// <summary>
        /// Force to update it's local copy of the phase value for the given channel
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        /// <returns>Function generator phase value</returns>
        public void GetFGenChannelPhase(string logicalChannel)
        {
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                _fgenChannelPhase[channelNumber - 1] = _pi.GetAwgFGenChannelPhase(logicalChannel);
            }
        }

        //glennj 1/7/2014
        /// <summary>
        /// Return the channel phase
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        public string FGenChannelPhase(string logicalChannel)
        {
            string fGenChannelPhase = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                fGenChannelPhase = _fgenChannelPhase[channelNumber - 1];
            }
            return fGenChannelPhase;
        }

        private readonly string[] _fgenChannelSymmetry = new string[AwgMaxChannels];

        //glennj 1/7/2014
        /// <summary>
        /// Set the symmetry value for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">symmetry value</param>
        public void SetFGenChannelSymmetry( string channel, string setValue)
        {
            _pi.SetAwgFGenChannelSymmetry(channel, setValue);
        }

        //glennj 06/20/2013
        /// <summary>
        /// Force to update it's local copy of the symmetry value for the given channel
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        /// <returns>Function generator symmetry value</returns>
        public void GetFGenChannelSymmetry(string logicalChannel)
        {
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                _fgenChannelSymmetry[channelNumber - 1] = _pi.GetAwgFGenChannelSymmetry(logicalChannel);
            }
        }

        //glennj 1/7/2014
        /// <summary>
        /// Given a logical channel, return the channel symmetry
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        public string FGenChannelSymmetry(string logicalChannel)
        {
            string fGenChannelSymmetry = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                fGenChannelSymmetry = _fgenChannelSymmetry[channelNumber - 1];
            }
            return fGenChannelSymmetry;
        }

        private readonly string[] _fgenChannelType = new string[AwgMaxChannels];

        //glennj 06/20/2013
        /// <summary>
        /// Set the waveform type for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Waveform type</param>
        public void SetFGenChannelType(string channel, string setValue)
        {
            _pi.SetAwgFGenChannelType(channel, setValue);
        }

        //glennj 1/6/2014
        /// <summary>
        /// Force to update it's local copy of the waveform type for the given channel
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        /// <returns>Function generator waveform type</returns>
        public void GetFGenChannelType(string logicalChannel)
        {
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                _fgenChannelType[channelNumber - 1] = _pi.GetAwgFGenChannelType(logicalChannel);
            }
        }

        //glennj 1/6/2014
        /// <summary>
        /// Given a logical channel, return the channel waveform type
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        public string FGenChannelType(string logicalChannel)
        {
            string fGenChannelType = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                fGenChannelType = _fgenChannelType[channelNumber - 1];
            }
            return fGenChannelType;
        }

        private readonly string[] _fgenCoupleAmplitude = new string[AwgMaxChannels];

        //glennj 06/20/2013
        /// <summary>
        /// Using FGEN:COUPle:AMPLitude set the coupling amplitude Value
        /// </summary>
        /// <param name="setValue">FGen couple state</param>
        public void SetFGenCoupleAmpl(string setValue)
        {
            _pi.SetAwgFGenCoupleAmpl(setValue);
        }

        //glennj 1/7/2014
        /// <summary>
        /// Force to update it's local copy of the state of the coupling amplitude
        /// </summary>
        /// <returns>Function Generator coupling frequency value</returns>
        public void GetFGenCoupleAmpl(string logicalChannel = "1")
        {
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                _fgenCoupleAmplitude[channelNumber - 1] = _pi.GetAwgFGenCoupleAmpl(logicalChannel);
            }
        }

        //glennj 1/6/2014
        /// <summary>
        /// Given a logical channel, return the channel waveform type
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        public string FGenCoupleAmplitude(string logicalChannel = "1")
        {
            string fGenCoupleAmplitude = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                fGenCoupleAmplitude = _fgenCoupleAmplitude[channelNumber - 1];
            }
            return fGenCoupleAmplitude;
        }

        #region Postponed

        private readonly string[] _fgenCoupleFrequency = new string[AwgMaxChannels];

        //glennj 06/20/2013
        /// <summary>
        /// Sets the coupling frequency state
        /// </summary>
        /// <param name="setValue">FGen couple state</param>
        public void SetFGenCoupleFreq(string setValue)
        {
            _pi.SetAwgFGenCoupleFreq(setValue);
        }

        //glennj 1/7/2013
        /// <summary>
        /// Force to update it's local copy of the state of the coupling frequency
        /// </summary>
        /// <returns>Function Generator coupling frequency value</returns>
        public void GetFGenCoupleFreq(string logicalChannel = "1")
        {
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                _fgenCoupleFrequency[channelNumber - 1] = _pi.GetAwgFGenCoupleFreq(logicalChannel);
            }
        }

        //glennj 1/7/2014
        /// <summary>
        /// Given a logical channel, return the couple frequency
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        public string FGenCoupleFrequency(string logicalChannel = "1")
        {
            string fGenCoupleFrequency = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                fGenCoupleFrequency = _fgenCoupleFrequency[channelNumber - 1];
            }
            return fGenCoupleFrequency;
        }

        #endregion Postponed


    }
}
