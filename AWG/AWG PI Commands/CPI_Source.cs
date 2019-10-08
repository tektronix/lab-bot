

using System.Drawing;

namespace AwgTestFramework
{
    public partial class CPi70KCmds
    {
        #region Source


        #region SOURce[n]:CASSet

        //glennj 8/22//2013
        /// <summary>
        /// Using SOURce[n]:CASSet? get the asset assigned to a channel
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        public string GetAwgSourceChannelAsset(string channel)
        {
            string response;
            string commandLine = "SOURce" + channel + ":CASSet?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion SOURce[n]:CASSet

        #region SOURce[n]:CASSet:SEQuence

        //glennj 8/22/2013
        /// <summary>
        /// Using SOURce[n]:CASSet:SEQuence assign an asset of a track of a sequence to a channel
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="seqName"></param>
        /// <param name="trackNumber"></param>
        public void SetAwgSourceChannelAssetSequence(string channel, string seqName, string trackNumber)
        {
            string commandLine = "SOURce" + channel + ":CASSet:SEQuence ";
            commandLine += '"' + seqName + '"';
            commandLine += "," + trackNumber;
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion SOURce[n]:CASSet:SEQuence

        #region SOURce[n]:CASSet:TYPE

        //glennj 8/22/2013
        /// <summary>
        /// Using SOURce:CASSet:TYPE?, get the type of the asset assigned to a channel
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        public string GetAwgSourceChannelAssetType(string channel)
        {
            string response;
            string commandLine = "SOURce" + channel + ":CASSet:TYPE?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion SOURce[n]:CASSet:TYPE

        #region SOURce[n]:CASSet:WAVeform

        //glennj 8/22/2013
        /// <summary>
        /// Using SOURce:CASSet:WAVeform assign a waveform to a channel
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="wfmName"></param>
        public void SetAwgSourceChannelAssetWaveform(string channel, string wfmName)
        {
            string commandLine = "SOURce" + channel + ":CASSet:WAVeform ";
            commandLine += '"' + wfmName + '"';
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion SOURce[n]:CASSet:WAVeform

        #region SOURce[n]:DAC:RESolution

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce[n]:DAC:RESolution set the DAC resolution on a specified channel
        /// </summary>
        /// <param name="channel">Channel desired to set DAC resolution for</param>
        /// <param name="resolution">Resolution of the DAC</param>
        public void SetAwgSourceDacResolution(string channel, string resolution)
        { 
            string commandLine = "SOURce" + channel + ":DAC:RESolution " + resolution;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce[n]:DAC:RESolution? get the DAC resolution on a specified channel
        /// </summary>
        /// <param name="channel">Channel desired to read DAC resolution</param>
        /// <returns>DAC Resolution</returns>
        public string GetAwgSourceDacResolution(string channel)
        {
            string response;
            string commandLine = "SOURce" + channel + ":DAC:RESolution?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion SOURce[n]:DAC:RESolution

        #region SOURce:JUMP:FORCe

        //glennj 8/23/2013
        /// <summary>
        /// Using SOURce:JUMP:FORCE, force a running sequence to jump to First, Current, Last, End or a specified step
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="forceJumpType"></param>
        public void ForceAwgSourceChannelJump(string channel, string forceJumpType)
        {
            string commandLine = "SOURce" + channel + ":JUMP:FORCe " + forceJumpType;
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion SOURce:JUMP:FORCe 

        #region SOURce:JUMP:PATTern:FORCe

        //glennj 8/23/2013
        /// <summary>
        /// Using SOURce:JUMP:PATTern:FORCE, force a running sequence to jump to with a pattern match
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="forceJumpPattern"></param>
        public void ForceAwgSourceChannelJumpPattern(string channel, string forceJumpPattern)
        {
            string commandLine = "SOURce" + channel + ":JUMP:PATTern:FORCe " + forceJumpPattern;
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion SOURce:JUMP:PATTern:FORCe

        #region SOURce[n]:FLAG[ALPHA]
        //jmanning 04/09/2014-NEW PSR3
        /// <summary>
        /// Using SOURce[n]:FLAG[ALPHA][:STAte] to set on or off status to specified flag
        /// </summary>
        /// <param name="sourceNum"></param>
        /// <param name="flagAlpha"></param>
        /// <param name="flagState"></param>
        public void SetAwgSourceFlagState(string sourceNum, string flagAlpha, string flagState)
        {
            string commandLine = "SOURce" + sourceNum;
            commandLine += ":FLAG" + flagAlpha;
            commandLine += ":STAte " + flagState;
            _mAWGVisaSession.Write(commandLine);
        }
        
        //jmanning 04/09/2014-NEW PSR3
        /// <summary>
        /// Using SOURce[n]:FLAG[ALPHA][:STAte]? to get on or off status to specified flag
        /// </summary>
        /// <param name="sourceNum"></param>
        /// <param name="flagAlpha"></param>
        /// <returns>flagState</returns>
        public string GetAwgSourceFlagState(string sourceNum, string flagAlpha)
        {
            string response;
            string commandLine = "SOURce" + sourceNum;
            commandLine += ":FLAG" + flagAlpha;
            commandLine += ":STAte?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion SOURce[n]:FLAG[ALPHA]

        #region SOURce[1]:FREQuency

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce[1]:FREQuency set the sampling frequency for the desired clock channel
        /// </summary>
        /// <param name="clockNumber"></param>
        /// <param name="setValue"></param>
        public void SetAwgSourceFrequency(string clockNumber, string setValue)
        {
            string commandLine = "SOURce" + clockNumber + ":FREQuency  " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 7/17/2013
        /// <summary>
        /// Using [SOURce[1]:FREQuency get the sampling frequency for the desired clock channel
        /// </summary>
        /// 
        /// <param name="clockNumber"></param>
        /// <returns></returns>
        public string GetAwgSourceFrequency(string clockNumber)
        {
            string response;
            string commandLine = "SOURce" + clockNumber + ":FREQuency?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion [SOURce[1]:FREQuency

        #region SOURce[n]:MARKer[n]:DELAY
        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce[n]:MARKer[n]:DELAY set the source marker delay on the given channel
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <param name="marker">Marker</param>
        /// <param name="setValue">Delay value</param>
        public void SetAwgSourceMarkerDelay(string channel, string marker, string setValue)
        {
            string commandLine = "SOURce" + channel + ":MARKer" + marker + ":DELay  " + setValue; 
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce[n]:MARKer[n]:DELAY get the source marker delay on the given channel
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <param name="marker">Marker</param>
        /// <returns>Delay value</returns>
        public string GetAwgSourceMarkerDelay(string channel, string marker)
        {
            string response;
            string commandLine = "SOURce" + channel + ":MARKer" + marker + ":DELay?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion SOURce[n]:MARKer[n]:DELAY

        #region SOURce[n]:MARKer[n]:VOLTage:HIGH

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce[n]:MARKer[n]:VOLTage:HIGH set the high voltage marker threshold
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <param name="marker">Marker</param>
        /// <param name="setValue">High Voltage Threshold</param>
        public void SetAwgSourceMarkerVoltageHigh(string channel, string marker, string setValue)
        {
            string commandLine = "SOURce" + channel + ":MARKer" + marker + ":VOLTage:HIGH " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce[n]:MARKer[n]:VOLTage:HIGH? get the high voltage marker threshold
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <param name="marker">Marker</param>
        /// <returns>High Voltage Threshold</returns>
        public string GetAwgSourceMarkerVoltageHigh(string channel, string marker)
        {
            string response;
            string commandLine = "SOURce" + channel + ":MARKer" + marker + ":VOLTage:HIGH?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion SOURce[n]:MARKer[n]:VOLTage:HIGH

        #region SOURce[n]:MARKer[n]:VOLTage:LEVel:IMMediate:AMPLitude

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce[n]:MARKer[n]:VOLTage:LEVel:IMMediate:AMPLitude set the marker amplitude on a given channel
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <param name="marker">Marker</param>
        /// <param name="setValue">Amplitude</param>
        public void SetAwgSourceMarkerAmplitude(string channel, string marker, string setValue)
        {
            string commandLine = "SOURce" + channel + ":MARKer" + marker + ":VOLTage:LEVel:IMMediate:AMPLitude " +
                                 setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce[n]:MARKer[n]:VOLTage:LEVel:IMMediate:AMPLitude? get the marker amplitude on a given channel
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <param name="marker">Marker</param>
        /// <returns>Amplitude</returns>
        public string GetAwgSourceMarkerAmplitude(string channel, string marker)
        {
            string response;
            string commandLine = "SOURce" + channel + ":MARKer" + marker + ":VOLTage:LEVel:IMMediate:AMPLitude?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion SOURce[n]:MARKer[n]:VOLTage:LEVel:IMMediate:AMPLitude

        #region SOURce[n]:MARKer[n]:VOLTage:LOW

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce[n]:MARKer[n]:VOLTage:LOW set the low voltage threshold for a marker
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <param name="marker">Marker</param>
        /// <param name="setValue"></param>
        /// <returns>Low Voltage Threshold</returns>
        public void SetAwgSourceMarkerVoltageLow(string channel, string marker, string setValue)
        {
            string commandLine = "SOURce" + channel + ":MARKer" + marker + ":VOLTage:LOW " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce[n]:MARKer[n]:VOLTage:LOW? get the low voltage threshold for a marker
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <param name="marker">Marker</param>
        /// <returns>Low Voltage Threshold</returns>
        public string GetAwgSourceMarkerVoltageLow(string channel, string marker)
        {
            string response;
            string commandLine = "SOURce" + channel + ":MARKer" + marker + ":VOLTage:LOW?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion SOURce[n]:MARKer[n]:VOLTage:LOW

        #region SOURce[n]:MARKer[n]:VOLTage:OFFSET

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce[n]:MARKer[n]:VOLTage:OFFSET set the Marker offset voltage on a given channel
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <param name="marker">Marker</param>
        /// <param name="setValue">Offset Voltage</param>
        public void SetAwgSourceMarkerVoltageOffset(string channel, string marker, string setValue)
        {
            string commandLine = "SOURce" + channel + ":MARKer" + marker + ":VOLTage:OFFSet " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce[n]:MARKer[n]:VOLTage:OFFSET? get the Marker offset voltage on a given channel
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <param name="marker">Marker</param>
        /// <returns>Offset Voltage</returns>
        public string GetAwgSourceMarkerVoltageOffset(string channel, string marker)
        {
            string response;
            string commandLine = "SOURce" + channel + ":MARKer" + marker + ":VOLTage:OFFSet?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion SOURce[n]:MARKer[n]:VOLTage:OFFSET

        #region SOURce[n]:POWer:AMPLitude
        ///kaylak 11/14/2014
        /// <summary>
        /// Using SOURce[n]:POWer:AMPLitude set the Source POWer Amplitude
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <param name="setValue">Source Amplitude</param>
        public void SetAwgSourcePowerAmplitude(string channel, string setValue)
        {
            string commandLine = "SOURce" + channel + ":POWer:AMPLitude " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        ///kaylak 11/14/2014
        /// <summary>
        /// Using SOURce[n]:POWer:AMPLitude? get the Source POWer Amplitude
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <returns>Source POWer Amplitude</returns>
        public string GetAwgSourcePowerAmplitude(string channel)
        {
            string response;
            string commandLine = "SOURce" + channel + ":POWer:AMPLitude?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion SOURce[n]:POWer:AMPLitude

        #region SOURce:RCCouple

        //glennj 9/3/2013
        /// <summary>
        /// Using SOURce:RCCouple set the Run Coupled Coupling mode
        /// </summary>
        /// <param name="setValue"></param>
        public void SetAwgSourceRunCoupledMode(string setValue)
        {
            var commandLine = "SOURce:RCCouple " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 9/3/2013
        /// <summary>
        /// Using SOURce:RCCouple get the Run Coupled Coupling mode
        /// </summary>
        /// <returns></returns>
        public string GetAwgSourceRunCoupledMode()
        {
            string response;
            const string commandLine = "SOURce:RCCouple?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion SOURce:RCCouple

        #region SOURce[n]:RMODe

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce:RMODe set the run mode
        /// </summary>
        /// <param name="channel">channel</param>
        /// <param name="setValue">Desired run mode</param>
        public void SetAwgSourceRunMode(string channel, string setValue)
        {
            string commandLine = "SOURce" + channel + ":RMODe " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce:RMODe? get the run mode
        /// </summary>
        /// <param name="channelNumber">Which clock</param>
        /// <returns>Current run mode for the given clock</returns>
        public string GetAwgSourceRunMode(string channelNumber)
        {
            string response;
            string commandLine = "SOURce" + channelNumber + ":RMODe?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion SOURce:RMODe

        #region SOURce[n]:ROSCillator:MULTiplier

        // Added by Kavitha 02/04/2013 to include SOURce[1]:ROSCillator:MULTiplier command
        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce[n]:ROSCillator:MULTiplier set the multiplier rate of the external reference oscillator
        /// </summary>
        /// <param name="clockNumber">clock number</param>
        /// <param name="setValue">Oscillator multiplier value</param>
        public void SetAwgSourceReferenceOscillatorMultiplier(string clockNumber, string setValue)
        {
            string commandLine = "SOURce" + clockNumber + ":ROSCillator:MULTiplier " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce[n]:ROSCillator:MULTiplier? get the multiplier rate of the external reference oscillator
        /// </summary>
        /// <param name="clockNumber">clock number</param>
        /// <returns>Oscillator multiplier value</returns>
        public string GetAwgSourceReferenceOscillatorMultiplier(string clockNumber)
        {
            string response;
            string commandLine = "SOURce" + clockNumber + ":ROSCillator:MULTiplier?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion SOURce[n]:ROSCillator:MULTiplier

        #region SOURC[n]:SCSTep?

        //glennj
        /// <summary>
        /// Using SOURce:SCSTep? get the Sequence Current STep.<para>
        /// Note, not real time</para>
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        public string GetAwgSourceChannelCurrentStep(string channel)
        {
            string response;
            string commandLine = "SOURce" + channel + ":SCSTep?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion SOURC[n]:SCSTep?

        #region SOURce[n]:SKEW

        //glennj 7/17/2013
        /// <summary>
        /// Using [SOURce[n]]:SKEW set the skew for the waveform associated with a channel.
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Skew</param>
        public void SetAwgSourceSkew(string channel, string setValue)
        {
            string commandLine = "SOURce" + channel + ":SKEW " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 7/17/2013
        /// <summary>
        /// Using [SOURce[n]]:SKEW? get the skew for the waveform associated with a channel.
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <returns>Skew</returns>
        public string GetAwgSourceSkew(string channel)
        {
            string response;
            string commandLine = "SOURce" + channel + ":" + "SKEW?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion [SOURce[n]]:SKEW

        #region SOURce[n]:TINPut

        //glennj 7/17/2013
        /// <summary>
        /// Using [SOURce[n]:]TINPut set the Trigger input for the given clock
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Desired run mode</param>
        public void SetAwgSourceTriggerInput(string clockNumber, string setValue)
        { 
            string commandLine = "SOURce" + clockNumber + ":TINPut " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 7/17/2013
        /// <summary>
        /// Using [SOURce[n]:]TINPut? get the Trigger input for the given clock
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <returns>Current Trigger input value for the given clock</returns>
        public string GetAwgSourceTriggerInput(string clockNumber)
        {
            string response;
            string commandLine = "SOURce" + clockNumber + ":TINPut?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion [SOURce[n]:]TINPut

        #region SOURce[n]:VOLTage:AMPLitude

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce[n]:VOLTage:AMPLitude set the Source Amplitude
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <param name="setValue">Source Amplitude</param>
        public void SetAwgSourceVoltageAmplitude(string channel, string setValue)
        {
            string commandLine = "SOURce" + channel + ":VOLTage:AMPLitude " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce[n]:VOLTage:AMPLitude? get the Source Amplitude
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <returns>Source Amplitude</returns>
        public string GetAwgSourceVoltageAmplitude(string channel)
        {
            string response;
            string commandLine = "SOURce" + channel + ":VOLTage:AMPLitude?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion SOURce[n]:VOLTage:AMPLitude

        #region SOURce[n]:VOLTage:HIGH

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce[n]:VOLTage:HIGH set the waveform high for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Desired voltage</param>
        public void SetAwgSourceVoltageHigh(string channel, string setValue)
        {
            string commandLine = "SOURce" + channel + ":VOLTage:HIGH " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce[n]:VOLTage:HIGH set the waveform high for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <returns>Voltage high</returns>
        public string GetAwgSourceVoltageHigh(string channel)
        {
            string response;
            string commandLine = "SOURce" + channel + ":VOLTage:HIGH?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion SOURce[n]:VOLTage:HIGH

        #region SOURce[n]:VOLTage:LOW

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce[n]:VOLTage:LOW set the waveform low for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Desired voltage</param>
        public void SetAwgSourceVoltageLow(string channel, string setValue)
        {
            string commandLine = "SOURce" + channel + ":VOLTage:LOW " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 7/17/2013
        /// <summary>
        /// Using SOURce[n]:VOLTage:LOW? get the waveform low for the given channel
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <returns>Voltage Low</returns>
        public string GetAwgSourceVoltageLow(string channel)
        {
            string response;
            string commandLine = "SOURce" + channel + ":VOLTage:LOW?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion SOURce[n]:VOLTage:LOW

        #region SOURce[n]]:WAVeform

        //glennj 7/17/2013
        /// <summary>
        /// Using [SOURce[n]]:WAVeform set the output waveform from the current waveform list to a channel
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <param name="waveform">Output waveform</param>
        public void SetAwgSourceWaveform(string channel, string waveform)
        {
            string commandLine = "SOURce" + channel + ":WAVeform " + '"' + waveform + '"';
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 7/17/2013
        /// <summary>
        /// Using [SOURce[n]]:WAVeform? get the output waveform from the current waveform list to a channel
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <returns>Current waveform loaded on the given channel</returns>
        public string GetAwgSourceWaveform(string channel)
        {
            string response;
            string commandLine = "SOURce" + channel + ":WAVEform?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion [SOURce[n]]:WAVeform

        #endregion Source
    }
}
