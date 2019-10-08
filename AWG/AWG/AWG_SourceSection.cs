using System;
// ReSharper disable CheckNamespace
namespace AwgTestFramework
// ReSharper restore CheckNamespace
{

    public partial class AWG
    {

        #region Source
        /// <summary>
        /// Property to contain the response from SOURce[n]:FLAG[ALPHA][:STAte]?
        /// </summary>
        public string SourceFlagState { get; set; }
   
        #region SOURce[n]:CASSet

        /// <summary>
        /// Holds the updated response from SOURce[n]:CASSet?
        /// </summary>
        private readonly string[] _sourceChannelAssignedAsset = new string[AwgMaxChannels];

        //glennj 1/20/2014
        /// <summary>
        /// Using SOURce[n]:CASSet? get the asset assigned to a channel
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        public void GetSourceChannelAsset(string logicalChannel)
        {
            var channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                _sourceChannelAssignedAsset[channelNumber - 1] = _pi.GetAwgSourceChannelAsset(logicalChannel);
            }
        }

        //glennj 1/8/2014
        /// <summary>
        /// Given a logical channel, return the channel assigned asset
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        public string SourceChannelAssignedAsset(string logicalChannel)
        {
            string sourceChannelAssignedAsset = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                sourceChannelAssignedAsset = _sourceChannelAssignedAsset[channelNumber - 1];
            }
            return sourceChannelAssignedAsset;
        }

        #endregion SOURce[n]:CASSet

        #region SOURce[n]:CASSet:SEQuence

        //glennj 8/22/2013
        /// <summary>
        /// Using SOURce[n]:CASSet:SEQuence assign an asset of a track of a sequence to a channel
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <param name="sequenceName"></param>
        /// <param name="trackNumber"></param>
        public void SetSourceChannelAssetSequence(string logicalChannel, string sequenceName, string trackNumber)
        {
            _pi.SetAwgSourceChannelAssetSequence(logicalChannel, sequenceName, trackNumber);
        }

        #endregion SOURce[n]:CASSet:SEQuence

        #region SOURce[n]:CASSet:TYPE

        /// <summary>
        /// Holds the updated response from SOURce[1]:CASSet:TYPE?
        /// </summary>
        //public string Source1ChannelAssignedAssetType { get; set; }
        //public string Source2ChannelAssignedAssetType { get; set; }
        private readonly string[] _sourceChannelAssignedAssetType = new string[AwgMaxChannels];

        //glennj 8/22/2013
        /// <summary>
        /// Using SOURce:CASSet:TYPE?, get the type of the asset assigned to a channel
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        public void GetSourceChannelAssetType(string logicalChannel)
        {
            var channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                _sourceChannelAssignedAssetType[channelNumber - 1] = _pi.GetAwgSourceChannelAssetType(logicalChannel);
            }
        }

        //glennj 1/20/2014
        /// <summary>
        /// Given a logical channel, return the type of the asset assigned to a channel
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        public string SourceChannelAssignedAssetType(string logicalChannel)
        {
            string sourceChannelAssignedAssetType = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                sourceChannelAssignedAssetType = _sourceChannelAssignedAssetType[channelNumber - 1];
            }
            return sourceChannelAssignedAssetType;
        }

        #endregion SOURce[n]:CASSet:TYPE

        #region SOURce[n]:CASSet:WAVeform

        //glennj 8/22/2013
        /// <summary>
        /// Using SOURce:CASSet:WAVeform assign a waveform to a channel
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="wfmName"></param>
        public void SetSourceChannelAssetWaveform(string channel, string wfmName)
        {
            _pi.SetAwgSourceChannelAssetWaveform(channel, wfmName);
        }

        #endregion SOURce[n]:CASSet:WAVeform

        #region SOURce:DAC:RESolution

        //glennj 1/21/2014
        /// <summary>
        /// Contains response from SOURCE1:DAC:RESOLUTION?
        /// </summary>
        private readonly string[] _sourceDacResolution = new string[AwgMaxChannels];

        //glennj 7/17/2013
        /// <summary>
        /// Set the DAC resolution on a specified channel
        /// </summary>
        /// <param name="logicalChannel">Channel desired to set DAC resolution for</param>
        /// <param name="resolution">Resolution of the DAC</param>
        public void SetSourceDacResolution(string logicalChannel, string resolution)
        {
            _pi.SetAwgSourceDacResolution(logicalChannel, resolution);
        }

        //glennj 1/21/2014
        /// <summary>
        /// Update the property containing the DAC resolution on a specified channel
        /// </summary>
        /// <param name="logicalChannel">Channel desired to read DAC resolution</param>
        /// <returns>DAC Resolution</returns>
        public void GetSourceDacResolution(string logicalChannel)
        {
            var channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                _sourceDacResolution[channelNumber - 1] = _pi.GetAwgSourceDacResolution(logicalChannel);
            }
        }

        //glennj 1/21/2014
        /// <summary>
        /// Given a logical channel, return the DAC resolution
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        public string SourceDacResolution(string logicalChannel)
        {
            string sourceDacResolution = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                sourceDacResolution = _sourceDacResolution[channelNumber - 1];
            }
            return sourceDacResolution;
        }

        #endregion SOURce:DAC:RESolution

        #region SOURce[n]:POWer:AMPLitude
        /// <summary>
        /// Property contains the response from [SOURce[c]]:POWer[:LEVel][:IMMediate][:AMPLitude]?
        /// </summary>
        private readonly string[] _sourcePowerAmplitude = new string[AwgMaxChannels];

        /// kaylak 11/14/2014
        /// <summary>
        /// Using SOURce[n]:POWer:AMPLitude set the Source Power Amplitude
        /// </summary>
        /// <param name="logicalChannel">Channel</param>
        /// <param name="setValue">Source Amplitude</param>
        public void SetSourcePowerAmplitude(string logicalChannel, string setValue)
        {
            _pi.SetAwgSourcePowerAmplitude(logicalChannel, setValue);
        }

        //jmanning 09/24/2013
        /// <summary>
        /// Using SOURce[n]:POWer:AMPLitude? get the Source Power Amplitude
        /// </summary>
        /// <param name="logicalChannel">Channel</param>
        /// <returns>Source Power Amplitude</returns>
        public void GetSourcePowerAmplitude(string logicalChannel)
        {
            var channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                _sourcePowerAmplitude[channelNumber - 1] = _pi.GetAwgSourcePowerAmplitude(logicalChannel);
            }
        }

        /// kaylak 11/14/2014
        /// <summary>
        /// Given a logical channel, return the copy for a Source Power Amplitude
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns>Source Power Value</returns>
        public string SourcePowerAmplitude(string logicalChannel)
        {
            string sourcePowerAmplitude = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                sourcePowerAmplitude = _sourcePowerAmplitude[channelNumber - 1];
            }
            return sourcePowerAmplitude;
        }
        #endregion SOURce[n]:POWer:AMPLitude

        #region SOURce[n]:FLAG[ALPHA]
        //jmanning 04/09/2014-NEW PSR3
        /// <summary>
        /// Using SOURce[n]:FLAG[ALPHA][:STAte] to set on or off status to specified flag
        /// </summary>
        /// <param name="sourceNum"></param>
        /// <param name="flagAlpha"></param>
        /// <param name="flagState"></param>
        void SetSourceFlagState(string sourceNum, string flagAlpha, string flagState)
        {
            _pi.SetAwgSourceFlagState(sourceNum, flagAlpha, flagState);
        }

        //jmanning 04/09/2014-NEW PSR3
        /// <summary>
        /// Using SOURce[n]:FLAG[ALPHA][:STAte]? to get on or off status to specified flag
        /// </summary>
        /// <param name="sourceNum"></param>
        /// <param name="flagAlpha"></param>
        /// <returns>flagState</returns>
        void GetSourceFlagState(string sourceNum, string flagAlpha)
        {
            SourceFlagState = _pi.GetAwgSourceFlagState(sourceNum, flagAlpha);
        }
        #endregion SOURce[n]:FLAG[ALPHA]

        #region SOURce:FREQuency

        /// <summary>
        /// Contains response from SOURce[n]:FREQuency?
        /// </summary>
        private readonly string[] _sourceFrequency = new string[AwgMaxClocks];

        //glennj 7/17/2013
        /// <summary>
        /// Using [SOURce[n]]:FREQuency set the sampling frequency for the desired clock
        /// </summary>
        /// <param name="logicalClock"></param>
        /// <param name="setValue"></param>
        public void SetSourceFrequency(string logicalClock, string setValue)
        {
            _pi.SetAwgSourceFrequency(logicalClock, setValue);
        }

        //glennj 1/21/2014
        /// <summary>
        /// Using [SOURce[n]]:FREQuency get the sampling frequency for the desired clock
        /// </summary>
        /// 
        /// <param name="logicalClock"></param>
        /// <returns></returns>
        public void GetSourceFrequency(string logicalClock)
        {
            var clockNumber = Convert.ToInt32(logicalClock);
            if (clockNumber <= AwgMaxClocks)
            {
                _sourceFrequency[clockNumber - 1] = _pi.GetAwgSourceFrequency(logicalClock);
            }
        }

        //glennj 1/21/2014
        /// <summary>
        /// Given a logical clock, return the clock sample rate
        /// </summary>
        /// <param name="logicalClock"></param>
        /// <returns></returns>
        public string SourceFrequency(string logicalClock)
        {
            string sourceFrequency = null;
            int clockNumber = Convert.ToInt32(logicalClock);
            if (clockNumber <= AwgMaxClocks)
            {
                sourceFrequency = _sourceFrequency[clockNumber - 1];
            }
            return sourceFrequency;
        }

        #endregion SOURce:FREQuency

        #region SOURce:JUMP:FORCe

        //glennj 8/23/2013
        /// <summary>
        /// Using SOURce:JUMP:FORCE, force a running sequence to jump to First, Current, Last, End or a specified step
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="forceJumpType"></param>
        public void ForceSourceChannelJump(string channel, string forceJumpType)
        {
            _pi.ForceAwgSourceChannelJump(channel, forceJumpType);
        }

        #endregion SOURce:JUMP:FORCe

        #region SOURce:JUMP:PATTern:FORCe

        //glennj 8/23/2013
        /// <summary>
        /// Using SOURce:JUMP:PATTern:FORCE, force a running sequence to jump to with a pattern match
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="forceJumpPattern"></param>
        public void ForceSourceChannelJumpPattern(string channel, string forceJumpPattern)
        {
            _pi.ForceAwgSourceChannelJumpPattern(channel, forceJumpPattern);
        }

        #endregion SOURce:JUMP:PATTern:FORCe

        #region SOURce:MARKer:DELay

        /// <summary>
        /// Contains response from SOURCE1:MARKER1:DELAY?
        /// </summary>
        private readonly string[,] _sourceMarkerDelay = new string[AwgMaxChannels, AwgMaxMarkers];

        //glennj 7/17/2013
        /// <summary>
        /// Set the source marker delay on the given channel
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <param name="marker">Marker</param>
        /// <param name="setValue">Delay value</param>
        public void SetSourceMarkerDelay(string channel, string marker, string setValue)
        {
            _pi.SetAwgSourceMarkerDelay(channel, marker, setValue);
        }

        //glennj 7/17/2013
        /// <summary>
        /// Update the copy of the source marker delay for the given channel and marker
        /// </summary>
        /// <param name="logicalChannel">Channel</param>
        /// <param name="logicalMarker">Marker Channel</param>
        public void GetSourceMarkerDelay(string logicalChannel, string logicalMarker)
        {
            int channelNumber = Convert.ToInt32(logicalChannel);
            int markerNumber = Convert.ToInt32(logicalMarker);
            if ((channelNumber <= AwgMaxChannels) && (markerNumber <= AwgMaxMarkers))
            {
                _sourceMarkerDelay[channelNumber - 1, markerNumber - 1] = _pi.GetAwgSourceMarkerDelay(logicalChannel, logicalMarker);
            }
        }

        //glennj 1/21/2014
        /// <summary>
        /// Returns the awg's copy of the source marker delay for the given channel and marker
        /// </summary>
        /// <param name="logicalChannel">Which channel number</param>
        /// <param name="logicalMarker">Which marker number</param>
        /// <returns>Delay</returns>
        public string SourceMarkerDelay(string logicalChannel, string logicalMarker)
        {
            string sourceMarkerDelay = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            int markerNumber = Convert.ToInt32(logicalMarker);
            if ((channelNumber <= AwgMaxChannels) && (markerNumber <= AwgMaxMarkers))
            {
                sourceMarkerDelay = _sourceMarkerDelay[channelNumber - 1, markerNumber - 1];
            }

            return sourceMarkerDelay;
        }

        #endregion SOURce:MARKer:DELay

        #region SOURce:MARKer:VOLTage:LEVel:IMMediate:AMPLitude

        /// <summary>
        /// Contains response from SOURce[c]:MARKer[m]:VOLTage:LEVel:IMMediate:AMPLitude
        /// </summary>

        private readonly string[,] _sourceMarkerAmplitude = new string[AwgMaxChannels, AwgMaxMarkers];

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce[c]:MARKer[m]:VOLTage:LEVel:IMMediate:AMPLitude set the marker amplitude on a given channel
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <param name="marker">Marker</param>
        /// <param name="setValue">Amplitude</param>
        public void SetSourceMarkerAmplitude(string channel, string marker, string setValue)
        {
            _pi.SetAwgSourceMarkerAmplitude(channel, marker, setValue);
        }

        //glennj 1/21/2014
        /// <summary>
        /// Update the copy per channel per marker for amplitude
        /// </summary>
        /// <param name="logicalChannel">Channel</param>
        /// <param name="logicalMarker">Marker Channel</param>
        public void GetSourceMarkerAmplitude(string logicalChannel, string logicalMarker)
        {
            int channelNumber = Convert.ToInt32(logicalChannel);
            int markerNumber = Convert.ToInt32(logicalMarker);
            if ((channelNumber <= AwgMaxChannels) && (markerNumber <= AwgMaxMarkers))
            {
                _sourceMarkerAmplitude[channelNumber - 1, markerNumber - 1] = _pi.GetAwgSourceMarkerAmplitude(logicalChannel, logicalMarker);
            }
        }

        //glennj 1/21/2014
        /// <summary>
        /// Returns the awg's copy of the source marker amplitude for the given channel and marker
        /// </summary>
        /// <param name="logicalChannel">Which channel number</param>
        /// <param name="logicalMarker">Which marker number</param>
        /// <returns>Amplitude</returns>
        public string SourceMarkerAmplitude(string logicalChannel, string logicalMarker)
        {
            string sourceMarkerAmplitude = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            int markerNumber = Convert.ToInt32(logicalMarker);
            if ((channelNumber <= AwgMaxChannels) && (markerNumber <= AwgMaxMarkers))
            {
                sourceMarkerAmplitude = _sourceMarkerAmplitude[channelNumber - 1, markerNumber - 1];
            }

            return sourceMarkerAmplitude;
        }

        #endregion SOURce:MARKer:VOLTage:LEVel:IMMediate:AMPLitude

        #region SOURce:MARKer:VOLTage:LEVel:IMMediate:HIGH


        /// <summary>
        /// Contains response from SOURce[c]:MARKer[m]:VOLTage:LEVel:IMMediate:HIGH
        /// </summary>
        private readonly string[,] _sourceMarkerHigh = new string[AwgMaxChannels, AwgMaxMarkers];

        //glennj 7/17/2013
        /// <summary>
        /// Set the high voltage marker threshold
        /// </summary>
        /// <param name="logicalChannel">Channel</param>
        /// <param name="logicalMarker">Marker</param>
        /// <param name="setValue">Voltage Threshold</param>
        public void SetSourceMarkerVoltageHigh(string logicalChannel, string logicalMarker, string setValue)
        {
            _pi.SetAwgSourceMarkerVoltageHigh(logicalChannel, logicalMarker, setValue);
        }

        //glennj 1/21/2014
        /// <summary>
        /// Update the copy for the high voltage marker threshold
        /// </summary>
        /// <param name="logicalChannel">Channel</param>
        /// <param name="logicalMarker">Marker</param>
        public void GetSourceMarkerVoltageHigh(string logicalChannel, string logicalMarker)
        {
            int channelNumber = Convert.ToInt32(logicalChannel);
            int markerNumber = Convert.ToInt32(logicalMarker);
            if ((channelNumber <= AwgMaxChannels) && (markerNumber <= AwgMaxMarkers))
            {
                _sourceMarkerHigh[channelNumber - 1, markerNumber - 1] = _pi.GetAwgSourceMarkerVoltageHigh(logicalChannel, logicalMarker);
            }
        }

        //glennj 1/21/2014
        /// <summary>
        /// Returns the awg's copy of the source marker high threshold for the given channel and marker
        /// </summary>
        /// <param name="logicalChannel">Which channel number</param>
        /// <param name="logicalMarker">Which marker number</param>
        /// <returns>High threshold</returns>
        public string SourceMarkerHigh(string logicalChannel, string logicalMarker)
        {
            string sourceMarkerHigh = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            int markerNumber = Convert.ToInt32(logicalMarker);
            if ((channelNumber <= AwgMaxChannels) && (markerNumber <= AwgMaxMarkers))
            {
                sourceMarkerHigh = _sourceMarkerHigh[channelNumber - 1, markerNumber - 1];
            }

            return sourceMarkerHigh;
        }

        #endregion SOURce:MARKer:VOLTage:LEVel:IMMediate:HIGH

        #region SOURce:MARKer:VOLTage:LEVel:IMMediate:LOW

        /// <summary>
        /// Contains response from SOURce[c]:MARKer[m]:VOLTage:LEVel:IMMediate:LOW
        /// </summary>
        private readonly string[,] _sourceMarkerLow = new string[AwgMaxChannels, AwgMaxMarkers];

        //glennj 7/17/2013
        /// <summary>
        /// Set the low voltage threshold for a marker
        /// </summary>
        /// <param name="logicalChannel">Channel</param>
        /// <param name="logicalMarker">Marker</param>
        /// <param name="setValue">Voltage Threshold</param>
        public void SetSourceMarkerVoltageLow(string logicalChannel, string logicalMarker, string setValue)
        {
            _pi.SetAwgSourceMarkerVoltageLow(logicalChannel, logicalMarker, setValue);
        }

        //glennj 1/21/2014
        /// <summary>
        /// Update the copy for the low voltage threshold for a marker
        /// </summary>
        /// <param name="logicalChannel">Channel</param>
        /// <param name="logicalMarker">Marker</param>
        /// <returns>Voltage Threshold</returns>
        public void GetSourceMarkerVoltageLow(string logicalChannel, string logicalMarker)
        {
            int channelNumber = Convert.ToInt32(logicalChannel);
            int markerNumber = Convert.ToInt32(logicalMarker);
            if ((channelNumber <= AwgMaxChannels) && (markerNumber <= AwgMaxMarkers))
            {
                _sourceMarkerLow[channelNumber - 1, markerNumber - 1] = _pi.GetAwgSourceMarkerVoltageLow(logicalChannel, logicalMarker);
            }
        }

        //glennj 1/21/2014
        /// <summary>
        /// Returns the awg's copy of the source marker Low threshold for the given channel and marker
        /// </summary>
        /// <param name="logicalChannel">Which channel number</param>
        /// <param name="logicalMarker">Which marker number</param>
        /// <returns>Low threshold</returns>
        public string SourceMarkerLow(string logicalChannel, string logicalMarker)
        {
            string sourceMarkerLow = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            int markerNumber = Convert.ToInt32(logicalMarker);
            if ((channelNumber <= AwgMaxChannels) && (markerNumber <= AwgMaxMarkers))
            {
                sourceMarkerLow = _sourceMarkerLow[channelNumber - 1, markerNumber - 1];
            }

            return sourceMarkerLow;
        }

        #endregion SOURce:MARKer:VOLTage:LEVel:IMMediate:LOW

        #region SOURce:MARKer:VOLTage:LEVel:IMMediate:OFFSet

        /// <summary>
        /// Contains response from SOURce[c]:MARKer[m]:VOLTage:LEVel:IMMediate:OFFSet
        /// </summary>
        private readonly string[,] _sourceMarkerOffset = new string[AwgMaxChannels, AwgMaxMarkers];

        //glennj 7/17/2013
        /// <summary>
        /// Set the Marker offset voltage on a given channel
        /// </summary>
        /// <param name="logicalChannel">Channel</param>
        /// <param name="logicalMarker">Marker</param>
        /// <param name="setValue">Offset Voltage</param>
        public void SetSourceMarkerVoltageOffset(string logicalChannel, string logicalMarker, string setValue)
        {
            _pi.SetAwgSourceMarkerVoltageOffset(logicalChannel, logicalMarker, setValue);
        }

        //glennj 1/21/2014
        /// <summary>
        /// Update the copy for the Marker offset voltage on a given channel
        /// </summary>
        /// <param name="logicalChannel">Channel</param>
        /// <param name="logicalMarker">Marker</param>
        /// <returns>Offset Voltage</returns>
        public void GetSourceMarkerVoltageOffset(string logicalChannel, string logicalMarker)
        {
            int channelNumber = Convert.ToInt32(logicalChannel);
            int markerNumber = Convert.ToInt32(logicalMarker);
            if ((channelNumber <= AwgMaxChannels) && (markerNumber <= AwgMaxMarkers))
            {
                _sourceMarkerOffset[channelNumber - 1, markerNumber - 1] = _pi.GetAwgSourceMarkerVoltageOffset(logicalChannel, logicalMarker);
            }
        }

        //glennj 1/21/2014
        /// <summary>
        /// Returns the awg's copy of the source marker offset voltage for the given channel and marker
        /// </summary>
        /// <param name="logicalChannel">Which channel number</param>
        /// <param name="logicalMarker">Which marker number</param>
        /// <returns>Low threshold</returns>
        public string SourceMarkerOffset(string logicalChannel, string logicalMarker)
        {
            string sourceMarkerOffset = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            int markerNumber = Convert.ToInt32(logicalMarker);
            if ((channelNumber <= AwgMaxChannels) && (markerNumber <= AwgMaxMarkers))
            {
                sourceMarkerOffset = _sourceMarkerOffset[channelNumber - 1, markerNumber - 1];
            }

            return sourceMarkerOffset;
        }

        #endregion SOURce:MARKer:VOLTage:LEVel:IMMediate:OFFSet

        #region SOURce:RCCouple

        /// <summary>
        /// Contains response of SOURce:RCCouple?
        /// </summary>
        public string SourceRunCoupledMode { get; set; }

        //glennj 9/3/2013
        /// <summary>
        /// Using SOURce:RCCouple set the Run Coupled Coupling mode
        /// </summary>
        /// <param name="setValue"></param>
        public void SetSourceRunCoupledMode(string setValue)
        {
            _pi.SetAwgSourceRunCoupledMode(setValue);
        }

        //glennj 9/3/2013
        /// <summary>
        /// Using SOURce:RCCouple get the Run Coupled Coupling mode
        /// </summary>
        /// <returns></returns>
        public void GetSourceRunCoupledMode()
        {
            SourceRunCoupledMode = _pi.GetAwgSourceRunCoupledMode();
        }

        #endregion SOURce:RCCouple

        #region SOURce:RMODe

        /// <summary>
        /// Contains response for SOURce[c]:RMODe?
        /// </summary>
        private readonly string[] _sourceRunMode = new string[AwgMaxChannels];

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce:RMODe set the run mode
        /// </summary>
        /// <param name="logicalChannel">channel</param>
        /// <param name="setValue">Desired run mode</param>
        public void SetSourceRunMode(string logicalChannel, string setValue)
        {
            _pi.SetAwgSourceRunMode(logicalChannel, setValue);
        }

        //glennj 1/21/2014
        /// <summary>
        /// Updates the copy for the run mode for a given channel
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        /// <returns>Current run mode for the given channel</returns>
        public void GetSourceRunMode(string logicalChannel)
        {
            var channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                _sourceRunMode[channelNumber - 1] = _pi.GetAwgSourceRunMode(logicalChannel);
            }
        }

        //glennj 1/21/2014
        /// <summary>
        /// Return the copy of the run mode for the given channel
        /// </summary>
        /// <param name="logicalChannel">Depending on the awg, a number between 1 and 4</param>
        /// <returns>A copy of the Run mode for the given channel</returns>
        public string SourceRunMode(string logicalChannel)
        {
            string sourceRunMode = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                sourceRunMode = _sourceRunMode[channelNumber - 1];
            }
            return sourceRunMode;
        }

        #endregion SOURce:RMODe

        #region SOURce:ROSCillator:MULTiplier

        /// <summary>
        /// Contains response of SOURce:ROSCillator:MULTIPLIER?
        /// </summary>
        private readonly string[] _sourceReferenceMultiplier = new string[AwgMaxClocks];

        //glennj 1/21/2014
        /// <summary>
        /// Using set the multiplier rate of the external reference oscillator
        /// </summary>
        /// <param name="logicalClock">clock number</param>
        /// <param name="setValue">Oscillator multiplier value</param>
        public void SetSourceReferenceOscillatorMultiplier(string logicalClock, string setValue)
        {
            _pi.SetAwgSourceReferenceOscillatorMultiplier(logicalClock, setValue);
        }

        //glennj 7/17/2013
        /// <summary>
        /// Update the copy of the multiplier rate of the external reference oscillator
        /// </summary>
        /// <param name="logicalClock">clock number</param>
        public void GetSourceReferenceOscillatorMultiplier(string logicalClock)
        {
            var clockNumber = Convert.ToInt32(logicalClock);
            if (clockNumber <= AwgMaxClocks)
            {
                _sourceReferenceMultiplier[clockNumber - 1] = _pi.GetAwgSourceReferenceOscillatorMultiplier(logicalClock);
            }
        }

        //glennj 1/21/2014
        /// <summary>
        /// Given a logical clock, return the multiplier rate of the external reference oscillator
        /// </summary>
        /// <param name="logicalClock"></param>
        /// <returns></returns>
        public string SourceReferenceMultiplier(string logicalClock)
        {
            string sourceReferenceMultiplier = null;
            int clockNumber = Convert.ToInt32(logicalClock);
            if (clockNumber <= AwgMaxClocks)
            {
                sourceReferenceMultiplier = _sourceReferenceMultiplier[clockNumber - 1];
            }
            return sourceReferenceMultiplier;
        }

        #endregion SOURce:ROSCillator:MULTiplier

        #region SOURC[n]:SCSTep?

        /// <summary>
        /// Contains response for SOURce1:SCSTep?
        /// </summary>
        private readonly string[] _sourceSequenceCurrentStep = new string[AwgMaxChannels];

        //glennj
        /// <summary>
        /// Using SOURce:SCSTep? get the Sequence Current STep.<para>
        /// Note, not real time</para>
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        public void GetSourceChannelCurrentStep(string logicalChannel)
        {
            var channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                _sourceSequenceCurrentStep[channelNumber - 1] = _pi.GetAwgSourceChannelCurrentStep(logicalChannel);
            }
        }

        //glennj 1/21/2014
        /// <summary>
        /// Return the copy of the current step for the given channel
        /// </summary>
        /// <param name="logicalChannel">Depending on the awg, a number between 1 and 4</param>
        /// <returns>A copy of the current step for the given channel</returns>
        public string SourceSequenceCurrentStep(string logicalChannel)
        {
            string sourceSequenceCurrentStep = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                sourceSequenceCurrentStep = _sourceSequenceCurrentStep[channelNumber - 1];
            }
            return sourceSequenceCurrentStep;
        }

        #endregion SOURC[n]:SCSTep?

        #region SOURce:SKEW

        /// <summary>
        /// Contains response for SOURce[c]:SKEW?
        /// </summary>
        private readonly string[] _sourceSkew = new string[AwgMaxChannels];

        //glennj 7/17/2013
        /// <summary>
        /// Set the skew for the waveform associated with a channel.
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        /// <param name="setValue">Skew</param>
        public void SetSourceSkew(string logicalChannel, string setValue)
        {
            _pi.SetAwgSourceSkew(logicalChannel, setValue);
        }

        //glennj 7/17/2013
        /// <summary>
        /// Update the copy for the skew for the waveform associated with a channel.
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        public void GetSourceSkew(string logicalChannel)
        {
            var channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                _sourceSkew[channelNumber - 1] = _pi.GetAwgSourceSkew(logicalChannel);
            }
        }

        //glennj 1/21/2014
        /// <summary>
        /// Return the copy of the source skew for the given channel
        /// </summary>
        /// <param name="logicalChannel">Depending on the awg, a number between 1 and 4</param>
        /// <returns>A copy of the source skew for the given channel</returns>
        public string SourceSkew(string logicalChannel)
        {
            string sourceSkew = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                sourceSkew = _sourceSkew[channelNumber - 1];
            }
            return sourceSkew;
        }

        #endregion SOURce:SKEW

        #region SOURce:TINPut

        /// <summary>
        /// Contains response for SOURce1:TINPut?
        /// </summary>
        private readonly string[] _sourceTriggerInput = new string[AwgMaxChannels];

        //glennj 7/17/2013
        /// <summary>
        /// Set the Trigger input Source for the given clock
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Desired run mode</param>
        public void SetSourceTriggerInput(string clockNumber, string setValue)
        {
            _pi.SetAwgSourceTriggerInput(clockNumber, setValue);
        }

        //glennj 1/21/2014
        /// <summary>
        /// Update the copy for the Source Trigger Input for a given channel
        /// </summary>
        /// <param name="logicalChannel">Depending on the awg a number between 1 and 4</param>
        public void GetSourceTriggerInput(string logicalChannel)
        {
            var channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                _sourceTriggerInput[channelNumber - 1] = _pi.GetAwgSourceTriggerInput(logicalChannel);
            }
        }

        //glennj 1/21/2014
        /// <summary>
        /// Return the copy of the trigger input for the given channel
        /// </summary>
        /// <param name="logicalChannel">Depending on the awg, a number between 1 and 4</param>
        /// <returns>A copy of the source skew for the given channel</returns>
        public string SourceTriggerInput(string logicalChannel)
        {
            string sourceTriggerInput = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                sourceTriggerInput = _sourceTriggerInput[channelNumber - 1];
            }
            return sourceTriggerInput;
        }

        #endregion SOURce:TINPut

        #region [SOURce[c]]:VOLTage[:LEVel][:IMMediate][:AMPLitude]

        /// <summary>
        /// Property contains the response from [SOURce[c]]:VOLTage[:LEVel][:IMMediate][:AMPLitude]?
        /// </summary>
        private readonly string[] _sourceAnalogVoltageAmplitude = new string[AwgMaxChannels];

        //glennj 7/17/2013
        /// <summary>
        /// Set a Source Voltage Amplitude
        /// </summary>
        /// <param name="logicalChannel">Channel</param>
        /// <param name="setValue">Source Amplitude</param>
        public void SetSourceAnalogVoltageAmplitude(string logicalChannel, string setValue)
        {
            _pi.SetAwgSourceVoltageAmplitude(logicalChannel, setValue);
        }

        //glennj 1/21/2014
        /// <summary>
        /// Update the copy for a Source Voltage Amplitude
        /// </summary>
        /// <param name="logicalChannel">Channel</param>
        /// <returns>Source Amplitude</returns>
        public void GetSourceAnalogVoltageAmplitude(string logicalChannel)
        {
            var channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                _sourceAnalogVoltageAmplitude[channelNumber - 1] = _pi.GetAwgSourceVoltageAmplitude(logicalChannel);
            }
        }

        //glennj 1/21/2014
        /// <summary>
        /// Given a logical channel, return the copy for a Source Voltage Amplitude
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        public string SourceAnalogVoltageAmplitude(string logicalChannel)
        {
            string sourceAnalogVoltageAmplitude = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                sourceAnalogVoltageAmplitude = _sourceAnalogVoltageAmplitude[channelNumber - 1];
            }
            return sourceAnalogVoltageAmplitude;
        }

        #endregion [SOURce[c]]:VOLTage[:LEVel][:IMMediate][:AMPLitude]

        #region [SOURce[c]]:VOLTage[:LEVel][:IMMediate]:HIGH

        /// <summary>
        /// Property contains the response from [SOURCE[c]]:VOLTage[:LEVel][:IMMediate]:HIGH?
        /// </summary>
        private readonly string[] _sourceAnalogVoltageHigh = new string[AwgMaxChannels];

        //glennj 7/17/2013
        /// <summary>
        /// Set the waveform voltage high for the given channel
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        /// <param name="setValue">Desired voltage</param>
        public void SetSourceAnalogVoltageHigh(string logicalChannel, string setValue)
        {
            _pi.SetAwgSourceVoltageHigh(logicalChannel, setValue);
        }

        //glennj 7/17/2013
        /// <summary>
        /// Update the copy for the waveform voltage high for the given channel
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        public void GetSourceAnalogVoltageHigh(string logicalChannel)
        {
            var channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                _sourceAnalogVoltageHigh[channelNumber - 1] = _pi.GetAwgSourceVoltageHigh(logicalChannel);
            }
        }

        //glennj 1/21/2014
        /// <summary>
        /// Given a logical channel, return the copy for a Source Voltage High
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        public string SourceAnalogVoltageHigh(string logicalChannel)
        {
            string sourceAnalogVoltageHigh = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                sourceAnalogVoltageHigh = _sourceAnalogVoltageHigh[channelNumber - 1];
            }
            return sourceAnalogVoltageHigh;
        }

        #endregion [SOURce[c]]:VOLTage[:LEVel][:IMMediate]:HIGH

        #region [SOURce[c]]:VOLTage[:LEVel][:IMMediate]:LOW

        /// <summary>
        /// Property contains the response from [SOURCE[c]]:VOLTage[:LEVel][:IMMediate]:LOW?
        /// </summary>
        private readonly string[] _sourceAnalogVoltageLow = new string[AwgMaxChannels];

        //glennj 7/17/2013
        /// <summary>
        /// Set the waveform voltage low for the given channel
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        /// <param name="setValue">Desired voltage</param>
        public void SetSourceAnalogVoltageLow(string logicalChannel, string setValue)
        {
            _pi.SetAwgSourceVoltageLow(logicalChannel, setValue);
        }

        //glennj 1/21/2014
        /// <summary>
        /// Update the copy for the waveform voltage low for the given channel
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        public void GetSourceAnalogVoltageLow(string logicalChannel)
        {
            var channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                _sourceAnalogVoltageLow[channelNumber - 1] = _pi.GetAwgSourceVoltageLow(logicalChannel);
            }
        }

        //glennj 1/21/2014
        /// <summary>
        /// Given a logical channel, return the copy for a Source Voltage Low
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        public string SourceAnalogVoltageLow(string logicalChannel)
        {
            string sourceAnalogVoltageLow = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                sourceAnalogVoltageLow = _sourceAnalogVoltageLow[channelNumber - 1];
            }
            return sourceAnalogVoltageLow;
        }

        #endregion [SOURce[c]]:VOLTage[:LEVel][:IMMediate]:LOW

        #region SOURce:WAVeform

        /// <summary>
        /// Contains response for SOURce[c]:WAVeform?
        /// </summary>
        private readonly string[] _sourceWaveformAssignedName = new string[AwgMaxChannels];

        //glennj 7/17/2013
        /// <summary>
        /// Assigns the waveform from the current waveform list to a channel
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <param name="waveform">Name of waveform</param>
        public void SetSourceWaveform(string channel, string waveform)
        {
            _pi.SetAwgSourceWaveform(channel, waveform);
        }

        //glennj 7/17/2013
        /// <summary>
        /// Using [SOURce[n]]:WAVeform? get the output waveform from the current waveform list to a channel
        /// </summary>
        /// <param name="logicalChannel">Depending on AWG a number between 1 and 4</param>
        public void GetSourceWaveform(string logicalChannel)
        {
            var channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                _sourceWaveformAssignedName[channelNumber - 1] = _pi.GetAwgSourceWaveform(logicalChannel);
            }
        }

        //glennj 1/21/2014
        /// <summary>
        /// Given a logical channel, return the copy for a assigned waveform name
        /// </summary>
        /// <param name="logicalChannel">Depending on AWG a number between 1 and 4</param>
        /// <returns></returns>
        public string SourceWaveformAssignedName(string logicalChannel)
        {
            string sourceWaveformAssignedName = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                sourceWaveformAssignedName = _sourceWaveformAssignedName[channelNumber - 1];
            }
            return sourceWaveformAssignedName;
        }

        #endregion SOURce:WAVeform

        #endregion Source

    }
}
