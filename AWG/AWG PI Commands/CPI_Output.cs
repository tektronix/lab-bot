
namespace AwgTestFramework
{
    public partial class CPi70KCmds
    {

        #region Output

        #region OUTPut[n]:ATTenuator:A1
        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:A1 sets the step value setting for attenuator A1 of a channel in units of dB.
        /// This is a blocking and unpublished command
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="stepValue">step increment value</param>
        public void SetAwgOutputFilterAttenuatorA1Step(string outputIndex, string stepValue)
        {
            string commandLine = "OUTPut" + outputIndex + ":ATTenuator:A1 " + stepValue;
            _mAWGVisaSession.Write(commandLine);
        }
        #endregion OUTPut[n]:ATTenuator:A1

        #region OUTPut[n]:ATTenuator:A1?
        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:A1? gets the step value setting for attenuator A1 of a channel in units of dB.
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <returns>step increment value in dB</returns>
        public string GetAwgOutputFilterAttenuatorA1Step(string outputIndex)
        {
            string response;
            string commandLine = "OUTPut" + outputIndex + ":ATTenuator:A1?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion OUTPut[n]:ATTenuator:A1?

        #region OUTPut[n]:ATTenuator:A2
        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:A2 sets the step value setting for attenuator A2 of a channel in units of dB.
        /// This is a blocking and unpublished command
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="stepValue">step increment value</param>
        public void SetAwgOutputFilterAttenuatorA2Step(string outputIndex, string stepValue)
        {
            string commandLine = "OUTPut" + outputIndex + ":ATTenuator:A2 " + stepValue;
            _mAWGVisaSession.Write(commandLine);
        }
        #endregion OUTPut[n]:ATTenuator:A2

        #region OUTPut[n]:ATTenuator:A2?
        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:A2? gets the step value setting for attenuator A2 of a channel in units of dB.
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <returns>step increment value in dB</returns>
        public string GetAwgOutputFilterAttenuatorA2Step(string outputIndex)
        {
            string response;
            string commandLine = "OUTPut" + outputIndex + ":ATTenuator:A2?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion OUTPut[n]:ATTenuator:A2?

        #region OUTPut[n]:ATTenuator:A3
        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:A3 sets the step value setting for attenuator A3 of a channel in units of dB.
        /// This is a blocking and unpublished command
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="stepValue">step increment value</param>
        public void SetAwgOutputFilterAttenuatorA3Step(string outputIndex, string stepValue)
        {
            string commandLine = "OUTPut" + outputIndex + ":ATTenuator:A3 " + stepValue;
            _mAWGVisaSession.Write(commandLine);
        }
        #endregion OUTPut[n]:ATTenuator:A3

        #region OUTPut[n]:ATTenuator:A3?
        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:A3? gets the step value setting for attenuator A3 of a channel in units of dB.
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <returns>step increment value in dB</returns>
        public string GetAwgOutputFilterAttenuatorA3Step(string outputIndex)
        {
            string response;
            string commandLine = "OUTPut" + outputIndex + ":ATTenuator:A3?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion OUTPut[n]:ATTenuator:A3?

        #region OUTPut[n]:ATTenuator:DAC
        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:DAC sets the step value setting for the DAC of a channel in units of dBm.
        /// This is a blocking and unpublished command
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="stepValue">step increment value in units of dBm</param>
        public void SetAwgOutputFilterAttenuatorDACStep(string outputIndex, string stepValue)
        {
            string commandLine = "OUTPut" + outputIndex + ":ATTenuator:DAC " + stepValue;
            _mAWGVisaSession.Write(commandLine);
        }
        #endregion OUTPut[n]:ATTenuator:DAC

        #region OUTPut[n]:ATTenuator:DAC?
        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:DAC? gets the step value setting for the DAC of a channel in units of dBm.
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <returns>step increment value in dBm</returns>
        public string GetAwgOutputFilterAttenuatorDACStep(string outputIndex)
        {
            string response;
            string commandLine = "OUTPut" + outputIndex + ":ATTenuator:DAC?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion OUTPut[n]:ATTenuator:DAC?

        #region OUTPut[n]:FILTer
        //jmanning 09/22/2014
        /// <summary>
        /// Using OUTPut[n]:FILTer sets the filter type of the of the selected signal path
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="filterType">Type of Filter [NONE|BPASs|LPASs]</param>
        public void SetAwgOutputFilter(string outputIndex, string filterType)
        {
            string commandLine = "OUTPut" + outputIndex + ":FILTer " + filterType;
            _mAWGVisaSession.Write(commandLine);
        }
        #endregion OUTPut[n]:FILTer

        #region OUTPut[n]:FILTer?
        //jmanning 09/22/2014
        /// <summary>
        /// Using OUTPut[n]:FILTer? gets the filter type of the of the selected signal path
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <returns> Type of Filter [NONE|BPASs|LPASs]</returns>
        public string GetAwgOutputFilter(string outputIndex)
        {
            string response;
            string commandLine = "OUTPut" + outputIndex + ":FILTer?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion OUTPut[n]:FILTer?
     
        #region OUTPut[n]:FILTer:BPASs:RANGe
        //shkv 1/8/2015 Added fix for 5168
        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:FILTer:BPASs:RANGe selects the band pass filter's range
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="filterRange">band pass filter range</param>
        public void SetAwgOutputFilterBandPassRangeR13to18GHz(string outputIndex, string filterRange)
        {
            string commandLine = "OUTPut" + outputIndex + ":FILTer:BPASs:RANGe " + filterRange;
            _mAWGVisaSession.Write(commandLine);
        }

        public void SetAwgOutputFilterBandPassRangeR10to14GHz(string outputIndex, string filterRange)
        {
            string commandLine = "OUTPut" + outputIndex + ":FILTer:BPASs:RANGe " + filterRange;
            _mAWGVisaSession.Write(commandLine);
        }
        #endregion OUTPut[n]:FILTer:BPASs:RANGe

        #region OUTPut[n]:FILTer:BPASs:RANGe?
        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:FILTer:BPASs:RANGe? gets the band pass filter's range
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <returns>Type of Filter Band Pass Range</returns>
        public string GetAwgOutputFilterBandPassRange(string outputIndex)
        {
            string response;
            string commandLine = "OUTPut" + outputIndex + ":FILTer:BPASs:RANGe?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response; 
        }
        #endregion OUTPut[n]:FILTer:BPASs:RANGe?

        #region OUTPut[n]:PATH
        //shkv 12/9/2014 Modified the command from MODE to PATH
        //jmanning 09/22/2014
        /// <summary>
        /// Using OUTPut[n]:MODE sets the signal path [DIRect|AC]
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="signalPath">Signal Path Type of Filter [DIRect|AC]</param>
        public void SetAwgOutputMode(string outputIndex, string signalPath)
        {
            string commandLine = "OUTPut" + outputIndex + ":PATH " + signalPath;
            _mAWGVisaSession.Write(commandLine);
        }
        #endregion OUTPut[n]:PATH

        #region OUTPut[n]:PATH? 
        //shkv 12/9/2014 Modified the command from MODE to PATH
        //jmanning 09/22/2014
        /// <summary>
        /// Using OUTPut[n]:MODE? gets the signal path [DIRect|AC]
        /// </summary>
        /// <param name="outputIndex">Index of output</param>
        /// <returns> Signal Path Type of Filter [DIRect|AC]</returns>
        public string GetAwgOutputMode(string outputIndex)
        {
            string response;
            string commandLine = "OUTPut" + outputIndex + ":PATH?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion OUTPut[n]:PATH?

        //glennj 7/11/2013
        /// <summary>
        /// Using OUTPut:OFF set whether or not the "All Outputs Off" has been enabled
        /// </summary>
        /// <param name="value">Output off state to be set to</param>
        public void SetAwgOutputOff(string value)
        {
            string commandLine = "OUTPut:OFF "+ value;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 7/11/2013
        /// <summary>
        /// Using OUTPut:OFF get the "All Outputs Off" state
        /// </summary>
        /// <returns>Output off state</returns>
        public string GetAwgOutputOff()
        {
            string response;
            const string commandLine = "OUTPut:OFF?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        //glennj 7/11/2013
        /// <summary>
        /// Using OUTPut[n][:STATe] set the output state of the arbitrary waveform generator.
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="value"></param>
        public void SetAwgOutputState(string channel, string value)
        {
            string commandLine = "OUTPut" + channel + ":STATe " + value;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 7/11/2013
        /// <summary>
        /// Using OUTPut[n][:STATe]? get the output state of the arbitrary waveform generator.
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <returns></returns>
        public string GetAwgOutputState(string channel) 
        {
            string response;
            string commandLine = "OUTPut" + channel + ":STATe?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        //glennj 7/11/2013
        /// <summary>
        /// Using OUTPut[n]:SVALue[:ANAlog:][STATe] set the output data position of a waveform while the instrument is in the stop state
        /// </summary>
        /// <param name="channel">Which %AWG machine number</param>
        /// <param name="value">Output data position of a waveform</param>
        public void SetAwgOutputStopAnalogState(string channel, string value)
        {
            string commandLine = "OUTPut" + channel + ":SVALue:ANAlog:STATe " + value;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 7/11/2013
        /// <summary>
        /// Using OUTPut[n]:SVALue[:ANAlog:][STATe]? get the output data position of a waveform while the instrument is in the stop state
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <returns>Output data position of a waveform</returns>
        public string GetAwgOutputStopAnalogState(string channel)
        {
            string response;
            string commandLine = "OUTPut" + channel + ":SVALue:ANAlog:STATe?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        //glennj 7/11/2013
        /// <summary>
        /// Using OUTPut[n]:STOP:MARKer[n]:STATe set the output data position of a marker while the instrument is in the stop state
        /// </summary>
        /// <param name="channel">Which channel number</param>
        /// <param name="marker">Which marker number</param>
        /// <param name="value">Output data position of a waveform</param>
        public void SetAwgOutputStopMarkerState(string channel, string marker, string value)
        {
            string commandLine = "OUTPut" + channel + ":SVALue:MARKer"+ marker + ":STATe " + value;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 7/11/2013
        /// <summary>
        /// Using OUTPut[n]:STOP:MARKer[n]:STATe? get the output data position of a marker while the instrument is in the stop state
        /// </summary>
        /// <param name="channel">Which channel number</param>
        /// <param name="marker">Which marker number</param>
        /// <returns>Output data position of a waveform</returns>
        public string GetAwgOutputStopMarkerState(string channel, string marker)
        {
            string response;
            string commandLine = "OUTPut" + channel + ":SVALue:MARKer" + marker + ":STATe?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        //glennj 7/11/2013
        /// <summary>
        /// Using OUTPut[n]:WVALue[:ANALog][:STATe set the output data position of a waveform while the instrument is in the waiting-for-trigger state
        /// </summary>
        /// <param name="channel">Which %AWG machine number</param>
        /// <param name="value">Output data position of a waveform</param>
        public void SetAwgOutputWValueAnalogState(string channel, string value)
        {
            string commandLine = "OUTPut" + channel + ":WVALue:ANAlog:STATe " + value;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 7/11/2013
        /// <summary>
        /// Using OUTPut[n]:WVALue[:ANALog][:STATe]? get the output data position of a waveform while the instrument is in the waiting-for-trigger state
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <returns>Output data position of a waveform</returns>
        public string GetAwgOutputWValueAnalogState(string channel)
        {
            string response;
            string commandLine = "OUTPut" + channel + ":WVALue:ANAlog:STATe?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        //glennj 7/11/2013
        /// <summary>
        /// Using OUTPut[n]:WVALue[:ANALog][:STATe] set the output data position of a marker while the instrument is in the waiting-for-trigger state
        /// </summary>
        /// <param name="channel">Which channel number</param>
        /// <param name="marker">Which marker number</param>
        /// <param name="value">Output data position of a waveform</param>
        public void SetAwgOutputTriggerMarkerState(string channel, string marker, string value)
        {
            string commandLine = "OUTPut" + channel + ":WVALue:MARKer" + marker + ":STATe " + value;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 7/11/2013
        /// <summary>
        /// Using OUTPut[n]:WVALue:MARKer[n][:STATe]? get the output data position of a marker while the instrument is in the waiting-for-trigger state 
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="marker">Which marker number</param>
        /// <returns>Output data position of a waveform</returns>
        public string GetAwgOutputTriggerMarkerState(string channel, string marker)
        {
            string response;
            string commandLine = "OUTPut" + channel + ":WVALue:MARKer" + marker + ":STATe?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion Output
    
    }
}
