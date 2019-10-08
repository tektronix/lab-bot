
namespace AwgTestFramework
{
    public partial class AWG
    {

        string NumberOfChannels { get; set; }

        /// <summary>
        /// Contains response of AWGControl:CLOCk1:DRATe?
        /// </summary>
        public string ControlClock1DividerRate { get; set; }

        /// <summary>
        /// Contains response of AWGControl:CLOCk2:DRATe?
        /// </summary>
        public string ControlClock2DividerRate { get; set; }

        /// <summary>
        /// Contains response of AWGControl:CLOCk:PHASe:ADJust?
        /// </summary>
        public string ControlClockPhaseAdjust { get; set; }

        /// <summary>
        /// Contains response of AWGControl:CONFigure:CNUMber?
        /// </summary>
        public string ControlConfigureChannelNumber { get; set; }

        /// <summary>
        /// Contains response of AWGControl:DOUTput[n][:STATe]?
        /// </summary>
        public string ControlDACState { get; set; }

        /// <summary>
        /// Contains response of AWGControl:INTerleave:ADJustment:AMPLitude?
        /// </summary>
        public string ControlInterleaveAdjustmentAmplitude { get; set; }

        /// <summary>
        /// Contains response of AWGControl:INTerleave:ADJustment:PHASe?
        /// </summary>
        public string ControlInterleaveAdjustmentPhase { get; set; }

        /// <summary>
        /// Contains response of AWGControl:RMODe?
        /// </summary>
        public string ControlRunMode { get; set; }

        /// <summary>
        /// Contains response of AWGControl:RSTate?
        /// </summary>
        public string ControlRunState { get; set; }

        /// <summary>
        /// Contains response of AWGControl:SNAMe?
        /// </summary>
        public string ControlSavedSetupLocation { get; set; }

        #region AWGControl:CLOCk:DRATe
        //glennj 7/17/2013
        /// <summary>
        /// Using AWGControl:CLOCk:DRATe, set the divider rate for the external clock<para>
        /// This is backward compatibile support only.  Use CLOCk:EREFerence:DIVider</para>
        /// </summary>
        /// <returns></returns>
        public void SetControlClockDividerRate(string clock, string value)
        {
            _pi.SetAwgControlClockDividerRate(clock, value);
        }

        // glennj 7/17/2013/2013
        /// <summary>
        /// Using AWGControl:CLOCk:DRATe?, get the divider rate for the external clock<para>
        /// This is backward compatibile support only.  Use CLOCk:EREFerence:DIVider?</para>
        /// </summary>
        /// <returns>"number of channels"</returns>
        public void GetControlClockDividerRate(string clockNumber)
        {
            switch (clockNumber)
            {
                case "1":
                    ControlClock1DividerRate = _pi.GetAwgControlClockDividerRate(clockNumber);
                    break;
                case "2":
                    ControlClock2DividerRate = _pi.GetAwgControlClockDividerRate(clockNumber);
                    break;
            }
        }
        #endregion AWGControl:CLOCk:DRATe

        #region AWGControl:CLOCk:PHASe:ADJust
        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:CLOCk:PHASe:ADJust, set the internal clock phase<para>
        /// This is backward compatibile support only.  Use CLOCk:PHASEe:ADJust</para>
        /// </summary>
        /// <returns></returns>
        public void SetControlClockPhaseAdjust(string value)
        {
            _pi.SetAwgControlClockPhaseAdjust(value);
        }

        // glennj 06/4/2013
        /// <summary>
        /// Using AWGControl:CLOCk:PHASe:ADJust?, update the property ControlClockPhaseAdjust<para>
        /// This is backward compatibile support only.  Use CLOCk:PHASEe:ADJust?</para>
        /// </summary>
        /// <returns>"number of channels"</returns>
        public void GetControlClockPhaseAdjust()
        {
            ControlClockPhaseAdjust = _pi.GetAwgControlClockPhaseAdjust();
        }
        #endregion AWGControl:CLOCk:PHASe:ADJust

        // glennj 06/4/2013
        /// <summary>
        /// Forces to update the property number_of_channels
        /// </summary>  
        public void FindNumberOfChannels()
        {
            NumberOfChannels = _pi.GetAwgControlConfCNum();
        }

        //glennj 1/6/2014
        /// <summary>
        /// Return the number of channels that the AWG<para>
        /// thinks it has.  This would initially have been </para><para>
        /// updated when the AWG object was created.</para>
        /// </summary>
        /// <returns></returns>
        public string GetNumberOfChannels()
        {
            return NumberOfChannels;
        }

        #region AWGControl:DOUTput[n][:STATe]
        //jmanning 09/24/2014
        /// <summary>
        /// Using AWGControl:DOUTput[n][:STATe] enables the raw DAC waveform outputs for the specified channel.
        /// </summary>
        /// <param name="channel">specified output channel</param>
        /// <param name="boolState">Desired enabled state</param>
        public void SetControlDACState(string channel, string boolState)
        {
            _pi.SetAwgControlDACState(channel, boolState);
        }

        //jmanning 09/24/2014
        /// <summary>
        /// Using AWGControl:DOUTput[n][:STATe]? return the enable state for raw DAC waveform output for the specified channel.
        /// </summary>
        /// <param name="channel">specified output channel</param>
        /// <returns>state for raw DAC waveform output usage</returns>
        public void GetControlDACState(string channel)
        {
            ControlDACState = _pi.GetAwgControlDACState(channel);
        }
        #endregion AWGControl:DOUTput[n][:STATe]
        
        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:INTerleave:ADJustment:AMPLitude set the interleave amplitude adjustment as a percentage of the analog output voltage.
        /// </summary>
        /// <param name="setValue"></param>
        public void SetInterleaveAdjustmentAmplitude(string setValue)
        {
            _pi.SetAwgInterleaveAdjustmentAmplitude(setValue);
        }

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:INTerleave:ADJustment:AMPLitude? updates the property<para>
        /// ControlInterleaveAdjustmentAmplitude</para>
        /// </summary>
        /// <returns></returns>
        public void GetInterleaveAdjustmentAmplitude()
        {
            ControlInterleaveAdjustmentAmplitude = _pi.GetAwgInterleaveAdjustmentAmplitude();
        }

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:INTerleave:ADJustment:PHASe set the interleave adjustment phase
        /// </summary>
        /// <param name="setValue"></param>
        public void SetInterleaveAdjustmentPhase(string setValue)
        {
            _pi.SetAwgInterleaveAdjustmentPhase(setValue);
        }

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:INTerleave:ADJustment:PHASe? updates the property ControlInterleaveAdjustmentPhase
        /// </summary>
        /// <returns></returns>
        public void GetInterleaveAdjustmentPhase()
        {
            ControlInterleaveAdjustmentPhase = _pi.GetAwgInterleaveAdjustmentPhase();
        }

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:RMODe set the run mode of the %AWG
        /// </summary>
        /// <param name="setValue">Desired run mode</param>
        public void SetRunMode(string setValue)
        {
            _pi.SetAwgRMode(setValue);
        }

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:RMODe? update property ControlRunMode
        /// </summary>
        /// <returns></returns>
        public void GetRunMode()
        {
            ControlRunMode = _pi.GetAwgRMode();
        }

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:RSTate? updates the property ControlRunState
        /// </summary>
        /// <returns></returns>
        public void GetRunState()
        {
            ControlRunState = _pi.GetAwgRState();
        }

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:RUN:IMMediate initiate the output of a waveform
        /// </summary>
        public void RunImmediate()
        {
            _pi.AwgRunImmediate();
        }

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:SNAMe? get the %AWG's most recently saved setup location
        /// </summary>
        /// <returns>Most recently saved setup location</returns>
        public void GetSavedSetupLocation()
        {
            ControlSavedSetupLocation = _pi.GetAwgSName();
        }

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:SREStore, load a setup as from a file<para>
        /// Preferred command is MMEMory:OPEN:SETup</para>
        /// </summary>
        /// <param name="filename">Path of the setup file</param>
        /// <param name="msus">>Mass storage unit specifier</param>
        public void SetupRestore(string filename, string msus)
        {
            _pi.AwgSRestore(filename, msus);
        }

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:SSAVe, save an %AWG setup as a file<para>
        /// Perferred command is MMEMory:SAVE:SETup.</para>
        /// </summary>
        /// <param name="filename">Path of the setup file</param>
        /// <param name="msus">Mass storage unit specifier</param>
        public void SetupSave(string filename, string msus)
        {
            _pi.AwgSSave(filename, msus);
        }

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:STOP:IMMediate, stop the requested AWG's output
        /// </summary>
        public void StopImmediate()
        {
            _pi.AwgStopImmediate();
        }

    }
}
