using System;
// ReSharper disable CheckNamespace
namespace AwgTestFramework
// ReSharper restore CheckNamespace
{
    public partial class AWG
    {
        #region OUTPut[n]:ATTenuator:A1
        // kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:A1 sets the step value setting for A1 attenuator of a channel in units of steps.
        /// This is a blocking and unpublished command
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="filterStepValue">step increment value</param>
        public void SetOutputFilterAttenuatorA1Step(string outputIndex, string filterStepValue)
        {
            _pi.SetAwgOutputFilterAttenuatorA1Step(outputIndex, filterStepValue);
        }
        #endregion OUTPut[n]:ATTenuator:A1

        #region OUTPut[n]:ATTenuator:A1?
        /// <summary>
        /// Property for response from OUTPut[n]:ATTenuator:A1?
        /// </summary>
        public string OutputFilterAttnA1Step { get; set; }

        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:A1? gets the step value setting for A1 attenuator of a channel in units of steps.
        /// This is a blocking and unpublished command
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <returns>step increment value</returns>
        public void GetOutputFilterAttenuatorA1Step(string outputIndex)
        {
            OutputFilterAttnA1Step = _pi.GetAwgOutputFilterAttenuatorA1Step(outputIndex);
        }
        #endregion OUTPut[n]:ATTenuator:A1?

        #region OUTPut[n]:ATTenuator:A2
        // kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:A2 sets the step value setting for A2 attenuator of a channel in units of steps.
        /// This is a blocking and unpublished command
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="filterStepValue">step increment value</param>
        public void SetOutputFilterAttenuatorA2Step(string outputIndex, string filterStepValue)
        {
            _pi.SetAwgOutputFilterAttenuatorA2Step(outputIndex, filterStepValue);
        }
        #endregion OUTPut[n]:ATTenuator:A2

        #region OUTPut[n]:ATTenuator:A2?
        /// <summary>
        /// Property for response from OUTPut[n]:ATTenuator:A2?
        /// </summary>
        public string OutputFilterAttnA2Step { get; set; }

        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:A2? gets the step value setting for A2 attenuator of a channel in units of steps.
        /// This is a blocking and unpublished command
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <returns>step increment value</returns>
        public void GetOutputFilterAttenuatorA2Step(string outputIndex)
        {
            OutputFilterAttnA2Step = _pi.GetAwgOutputFilterAttenuatorA2Step(outputIndex);
        }
        #endregion OUTPut[n]:ATTenuator:A2?

        #region OUTPut[n]:ATTenuator:A3
        // kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:A3 sets the step value setting for A3 attenuator of a channel in units of steps.
        /// This is a blocking and unpublished command
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="filterStepValue">step increment value</param>
        public void SetOutputFilterAttenuatorA3Step(string outputIndex, string filterStepValue)
        {
            _pi.SetAwgOutputFilterAttenuatorA3Step(outputIndex, filterStepValue);
        }
        #endregion OUTPut[n]:ATTenuator:A3

        #region OUTPut[n]:ATTenuator:A3?
        /// <summary>
        /// Property for response from OUTPut[n]:ATTenuator:A3?
        /// </summary>
        public string OutputFilterAttnA3Step { get; set; }

        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:A3? gets the step value setting for A3 attenuator of a channel in units of steps.
        /// This is a blocking and unpublished command
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <returns>step increment value</returns>
        public void GetOutputFilterAttenuatorA3Step(string outputIndex)
        {
            OutputFilterAttnA3Step = _pi.GetAwgOutputFilterAttenuatorA3Step(outputIndex);
        }
        #endregion OUTPut[n]:ATTenuator:A3?

        #region OUTPut[n]:ATTenuator:DAC
        // kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:DAC sets the step value setting for DAC attenuator of a channel in units of steps.
        /// This is a blocking and unpublished command
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="filterStepValue">step increment value</param>
        public void SetOutputFilterAttenuatorDACStep(string outputIndex, string filterStepValue)
        {
            _pi.SetAwgOutputFilterAttenuatorDACStep(outputIndex, filterStepValue);
        }
        #endregion OUTPut[n]:ATTenuator:DAC

        #region OUTPut[n]:ATTenuator:DAC?
        /// <summary>
        /// Property for response from OUTPut[n]:ATTenuator:DAC?
        /// </summary>
        public string OutputFilterAttnDACStep { get; set; }

        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:DAC? gets the step value setting for DAC attenuator of a channel in units of steps.
        /// This is a blocking and unpublished command
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <returns>step increment value</returns>
        public void GetOutputFilterAttenuatorDACStep(string outputIndex)
        {
            OutputFilterAttnDACStep = _pi.GetAwgOutputFilterAttenuatorDACStep(outputIndex);
        }
        #endregion OUTPut[n]:ATTenuator:DAC?
        
        #region OUTPut[n]:FILTer
        //jmanning 09/22/2014
        /// <summary>
        /// Using OUTPut[n]:FILTer sets the filter type of the of the selected signal path
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="filterType">Type of Filter [NONE|BPASs|LPASs]</param>
        public void SetOutputFilter(string outputIndex, string filterType)
        {
            _pi.SetAwgOutputFilter(outputIndex, filterType);
        }
        #endregion OUTPut[n]:FILTer

        #region OUTPut[n]:FILTer?
        /// <summary>
        /// Property for response from OUTPut[n]:FILTer?
        /// </summary>
        public string OutputFilterType { get; set; }
        
        //jmanning 09/22/2014
        /// <summary>
        /// Using OUTPut[n]:FILTer? gets the filter type of the of the selected signal path
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <returns> Type of Filter [NONE|BPASs|LPASs]</returns>
        public void GetOutputFilter(string outputIndex)
        {
            OutputFilterType = _pi.GetAwgOutputFilter(outputIndex);
        }
        #endregion OUTPut[n]:FILTer?

        #region OUTPut[n]:FILTer:BPASs:RANGe

        //shkv 1/8/2015 Added fix for 5168
        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:FILTer:BPASs:RANGe sets the band pass filter range
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="filterRange">Type of Filter range</param>
        public void SetOutputFilterBandPassRangeR10to14GHz(string outputIndex, string filterRange)
        {
            _pi.SetAwgOutputFilterBandPassRangeR10to14GHz(outputIndex, filterRange);
        }
        public void SetOutputFilterBandPassRangeR13to18GHz(string outputIndex, string filterRange)
        {
            _pi.SetAwgOutputFilterBandPassRangeR13to18GHz(outputIndex, filterRange);
        }
        #endregion OUTPut[n]:FILTer:BPASs:RANGe

        #region OUTPut[n]:FILTer:BPASs:RANGe?
        /// <summary>
        /// Property for response from OUTPut[n]:FILTer:BPASs:RANGe?
        /// </summary>
        public string OutputFilterBandPassRange { get; set; }

        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:FILTer:BPASs:RANGe? gets the band pass filter range
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <returns>Type of Filter Range</returns>
        public void GetOutputFilterBandPassRange(string outputIndex)
        {
            OutputFilterBandPassRange = _pi.GetAwgOutputFilterBandPassRange(outputIndex);
        }
        #endregion OUTPut[n]:FILTer:BPASs:RANGe?

        #region OUTPut[n]:MODE
        //jmanning 09/22/2014
        /// <summary>
        /// Using OUTPut[n]:MODE sets the signal path [DIRect|AC]
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="signalPath">Signal Path Type of Filter [DIRect|AC]</param>
        public void SetOutputMode(string outputIndex, string signalPath)
        {
            _pi.SetAwgOutputMode(outputIndex, signalPath);
        }
        #endregion OUTPut[n]:MODE

        #region OUTPut[n]:MODE?
        /// <summary>
        /// Property for response from OUTPut[n]:MODE?
        /// </summary>
        public string OutputModeType { get; set; }

        //jmanning 09/22/2014
        /// <summary>
        /// Using OUTPut[n]:MODE? gets the signal path [DIRect|AC]
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <returns> Signal Path Type of Filter [DIRect|AC]</returns>
        public void GetOutputMode(string outputIndex)
        {
            OutputModeType = _pi.GetAwgOutputMode(outputIndex);
        }
        #endregion OUTPut[n]:MODE?

        #region OUTPut:OFF

        /// <summary>
        /// Used for the property for OUTPut:OFF (GetOutputOff())
        /// </summary>
        public string OutputOffState { get; set; }
        
        //glennj 7/11/2013
        /// <summary>
        /// Using OUTPut:OFF set whether or not the "All Outputs Off" has been enabled
        /// </summary>
        /// <param name="value">Output off state to be set to</param>
        public void SetOutputOff(string value)
        {
            _pi.SetAwgOutputOff(value);
        }

        //glennj 7/11/2013
        /// <summary>
        /// Forces this awg to updates it's copy of the output off mode
        /// </summary>
        public void GetOutputOff()
        {
            OutputOffState = _pi.GetAwgOutputOff();
        }
        #endregion OUTPut:OFF
  
        #region OUTPut[:STATe]

        private readonly string[] _outputChannelStateValue = new string[AwgMaxChannels];

        //glennj 7/11/2013
        /// <summary>
        /// Set the output state.
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="value"></param>
        public void SetOutputState(string channel, string value)
        {
            _pi.SetAwgOutputState(channel, value);
        }

        //glennj 1/8/2014
        /// <summary>
        /// Forces this awg to updates it's copy of the output state
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        public void GetOutputState(string logicalChannel)
        {
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                _outputChannelStateValue[channelNumber - 1] = _pi.GetAwgOutputState(logicalChannel);
            }
        }

        //glennj 1/8/2014
        /// <summary>
        /// Given a logical channel, return the channel output state
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        public string OutputChannelState(string logicalChannel)
        {
            string outputChannelState = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                outputChannelState = _outputChannelStateValue[channelNumber - 1];
            }
            return outputChannelState;
        }

        #endregion OUTPut[:STATe]

        #region OUTPut:SVALue:ANALog:STATe

        /// <summary>
        /// Used for the copies of the properties from OUTPut1:SVALue[:ANALog][:STATe]
        /// </summary>
        private readonly string[] _outputChannelStopValueAnalogState = new string[AwgMaxChannels];

        //glennj 7/11/2013
        /// <summary>
        /// Set the output data position of a waveform when in the stop state
        /// </summary>
        /// <param name="channel">Which %AWG machine number</param>
        /// <param name="value">Output data position of a waveform</param>
        public void SetOutputStopAnalogState(string channel, string value)
        {
            _pi.SetAwgOutputStopAnalogState(channel, value);
        }

        //glennj 1/8/2014
        /// <summary>
        /// Forces this awg to updates it's copy of the output Stop Value Analog State
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        public void GetOutputStopAnalogState(string logicalChannel)
        {
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                _outputChannelStopValueAnalogState[channelNumber - 1] = _pi.GetAwgOutputStopAnalogState(logicalChannel);
            }
        }

        //glennj 1/8/2014
        /// <summary>
        /// Given a logical channel, return the copy of the channel output stop value state
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        public string OutputStopAnalogState(string logicalChannel)
        {
            string outputStopAnalogState = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                outputStopAnalogState = _outputChannelStopValueAnalogState[channelNumber - 1];
            }
            return outputStopAnalogState;
        }

        #endregion OUTPut:SVALue:ANALog:STATe

        #region OUTPut:SVALue:MARKer

        /// <summary>
        /// Used for the property for OUTPut:SVALue:MARKer
        /// </summary>
        private readonly string[,] _outputChannelMarkerStopValues = new string[AwgMaxChannels, AwgMaxMarkers];

        //glennj 7/11/2013
        /// <summary>
        /// Set the output data position of a marker when the instrument is in the stop state
        /// </summary>
        /// <param name="channel">Which channel number</param>
        /// <param name="marker">Which marker number</param>
        /// <param name="value">Output data position of a waveform</param>
        public void SetOutputStopMarkerState(string channel, string marker, string value)
        {
            _pi.SetAwgOutputStopMarkerState(channel, marker, value);
        }

        //glennj 7/11/2013
        /// <summary>
        /// Forces this awg to updates it's copy of the output Stop Value Marker State
        /// </summary>
        /// <param name="logicalChannel">Which channel number</param>
        /// <param name="logicalMarker">Which marker number</param>
        /// <returns>Output data position of a waveform</returns>
        public void GetOutputStopMarkerState(string logicalChannel, string logicalMarker)
        {
            int channelNumber = Convert.ToInt32(logicalChannel);
            int markerNumber  = Convert.ToInt32(logicalMarker);
            if ((channelNumber <= AwgMaxChannels) && (markerNumber <= AwgMaxMarkers))
            {
                _outputChannelMarkerStopValues[channelNumber - 1, markerNumber - 1] = _pi.GetAwgOutputStopMarkerState(logicalChannel, logicalMarker);
            }
        }

        //glennj 7/11/2013
        /// <summary>
        /// Returns the awg's copy of the output Stop Value Marker State per channel
        /// </summary>
        /// <param name="logicalChannel">Which channel number</param>
        /// <param name="logicalMarker">Which marker number</param>
        /// <returns>Output data position of a waveform</returns>
        public string OutputStopMarkerState(string logicalChannel, string logicalMarker)
        {
            string outputStopMarkerState = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            int markerNumber = Convert.ToInt32(logicalMarker);
            if ((channelNumber <= AwgMaxChannels) && (markerNumber <= AwgMaxMarkers))
            {
                outputStopMarkerState = _outputChannelMarkerStopValues[channelNumber - 1, markerNumber - 1];
            }

            return outputStopMarkerState;
        }


        #endregion OUTPut:SVALue:MARKer

        #region OUTPut:WVALue:ANALog:STATe

        /// <summary>
        /// Used for the property for OUTPut1:WVALue[:ANALog][:STATe]
        /// </summary>
        private readonly string[] _outputChannelWaitValueAnalogState = new string[AwgMaxChannels];

        //glennj 7/11/2013
        /// <summary>
        /// Set the output data position of channel while the instrument is in the waiting-for-trigger state
        /// </summary>
        /// <param name="logicalChannel">Which %AWG machine number</param>
        /// <param name="value">Output data position of a waveform</param>
        public void SetOutputWaitForValueAnalogState(string logicalChannel, string value)
        {
            _pi.SetAwgOutputWValueAnalogState(logicalChannel, value);
        }

        //glennj 1/8/2014
        /// <summary>
        /// Forces the awg to updates it's copy of the output Wait Value Analog State
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        public void GetOutputWValueAnalogState(string logicalChannel)
        {
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                _outputChannelWaitValueAnalogState[channelNumber - 1] = _pi.GetAwgOutputWValueAnalogState(logicalChannel);
            }
        }

        //glennj 1/8/2014
        /// <summary>
        /// Given a logical channel, return the copy of the analog output wait value state for a channel
        /// </summary>
        /// <param name="logicalChannel"></param>
        /// <returns></returns>
        public string OutputWaitAnalogState(string logicalChannel)
        {
            string outputWaitAnalogState = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            if (channelNumber <= AwgMaxChannels)
            {
                outputWaitAnalogState = _outputChannelWaitValueAnalogState[channelNumber - 1];
            }
            return outputWaitAnalogState;
        }

        #endregion OUTPut:WVALue:ANALog:STATe

        #region OUTPut:WVALue:MARKer:STATe

        /// <summary>
        /// Used for the property for OUTPut1:WVALue:MARKer1
        /// </summary>
        private readonly string[,] _outputChannelMarkerWaitValues = new string[AwgMaxChannels, AwgMaxMarkers];

        //glennj 7/11/2013
        /// <summary>
        /// Set the output data position of a marker while the instrument is in the waiting-for-trigger state
        /// </summary>
        /// <param name="channel">Which channel number</param>
        /// <param name="marker">Which marker number</param>
        /// <param name="value">Output data position of a waveform</param>
        public void SetOutputWaitForTriggerMarkerState(string channel, string marker, string value)
        {
            _pi.SetAwgOutputTriggerMarkerState(channel, marker, value);
        }

        //glennj 7/11/2013
        /// <summary>
        /// Forces this awg to updates it's copy of the output Wait for trigger Value Marker State
        /// </summary>
        /// <param name="logicalChannel">Which channel</param>
        /// <param name="logicalMarker">Which marker number</param>
        /// <returns>Output data position of a waveform</returns>
        public void GetOutputTriggerMarkerState(string logicalChannel, string logicalMarker)
        {
            int channelNumber = Convert.ToInt32(logicalChannel);
            int markerNumber = Convert.ToInt32(logicalMarker);
            if ((channelNumber <= AwgMaxChannels) && (markerNumber <= AwgMaxMarkers))
            {
                _outputChannelMarkerWaitValues[channelNumber - 1, markerNumber - 1] = _pi.GetAwgOutputTriggerMarkerState(logicalChannel, logicalMarker);
            }
        }

        //glennj 7/11/2013
        /// <summary>
        /// Returns the awg's copy of the output Wait Value Marker State per channel
        /// </summary>
        /// <param name="logicalChannel">Which channel number</param>
        /// <param name="logicalMarker">Which marker number</param>
        /// <returns>Output data position of a waveform</returns>
        public string OutputWaitMarkerState(string logicalChannel, string logicalMarker)
        {
            string outputWaitMarkerState = null;
            int channelNumber = Convert.ToInt32(logicalChannel);
            int markerNumber = Convert.ToInt32(logicalMarker);
            if ((channelNumber <= AwgMaxChannels) && (markerNumber <= AwgMaxMarkers))
            {
                outputWaitMarkerState = _outputChannelMarkerWaitValues[channelNumber - 1, markerNumber - 1];
            }

            return outputWaitMarkerState;
        }

        #endregion OUTPut:WVALue:MARKer:STATe

    }
}
