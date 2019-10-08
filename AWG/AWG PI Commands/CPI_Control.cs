
using System.Threading;

namespace AwgTestFramework
{
    public partial class CPi70KCmds
    {
        #region AWGControl

        #region deprecated

        // These commands are being phased out and are only in
        // the AWG PI command set for backwards compatibility.
        // There are new commands that are intended to be clearer
        // and to reflect what the AWG requires.


        #region AWGControl:CLOCk:DRATe

        //glennj 7/17/2013
        /// <summary>
        /// Using AWGControl:CLOCk:DRATe, set the divider rate for the external clock<para>
        /// This is backward compatibile support only.  Use CLOCk:EREFerence:DIVider</para>
        /// </summary>
        /// <returns></returns>
        public void SetAwgControlClockDividerRate(string clock, string value)
        {
            var commandLine = "AWGControl:CLOCk" + clock + ":DRATe " + value;
            _mAWGVisaSession.Write(commandLine);
        }

        // glennj 7/17/2013/2013
        /// <summary>
        /// Using AWGControl:CLOCk:DRATe?, get the divider rate for the external clock<para>
        /// This is backward compatibile support only.  Use CLOCk:EREFerence:DIVider?</para>
        /// </summary>
        /// <returns>"number of channels"</returns>
        public string GetAwgControlClockDividerRate(string clock)
        {
            string response;
            var commandLine = "AWGControl:CLOCk" + clock + ":DRATe?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion AWGControl:CLOCk:DRATe

        #region AWGControl:CLOCk:PHASe:ADJust

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:CLOCk:PHASe:ADJust, set the internal clock phase<para>
        /// This is backward compatibile support only.  Use CLOCk:PHASEe:ADJust</para>
        /// </summary>
        /// <returns></returns>
        public void SetAwgControlClockPhaseAdjust(string value)
        {
            var commandLine = "AWGControl:CLOCk:PHASe:ADJust " + value;
            _mAWGVisaSession.Write(commandLine);
        }

        // glennj 06/4/2013
        /// <summary>
        /// Using AWGControl:CLOCk:PHASe:ADJust?, get the internal clock phase<para>
        /// This is backward compatibile support only.  Use CLOCk:PHASEe:ADJust?</para>
        /// </summary>
        /// <returns>"number of channels"</returns>
        public string GetAwgControlClockPhaseAdjust()
        {
            string response;
            const string commandLine = "AWGControl:CLOCk:PHASe:ADJust?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion AWGControl:CLOCk:PHASe:ADJust

        #region AWGControl:CLOCk:SOURce

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:CLOCk:SOURce, set the clock source<para>
        /// This is backward compatibile support only.  Use CLOCk:SOURce</para>
        /// </summary>
        /// <returns></returns>
        public void SetAwgControlClockSource(string value)
        {
            var commandLine = "AWGControl:CLOCk:SOURce " + value;
            _mAWGVisaSession.Write(commandLine);
        }

        // glennj 06/4/2013
        /// <summary>
        /// Using AWGControl:CLOCk:PHASe:ADJust?, get the internal clock phase<para>
        /// This is backward compatibile support only.  Use CLOCk:SOURce?</para>
        /// </summary>
        /// <returns>"number of channels"</returns>
        public string GetAwgControlClockSource()
        {
            string response;
            const string commandLine = "AWGControl:CLOCk:SOURce?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion AWGControl:CLOCk:SOURce

        #region AWGControl:DOUTput[n][:STATe]
        //jmanning 09/24/2014
        /// <summary>
        /// Using AWGControl:DOUTput[n][:STATe] enables the raw DAC waveform outputs for the specified channel.
        /// </summary>
        /// <param name="channel">specified output channel</param>
        /// <param name="boolState">Desired enabled state</param>
        public void SetAwgControlDACState(string channel, string boolState)
        {
            string commandLine = "AWGControl:DOUTput" + channel + " " + boolState;
            _mAWGVisaSession.Write(commandLine);
        }

        //jmanning 09/24/2014
        /// <summary>
        /// Using AWGControl:DOUTput[n][:STATe]? return the enable state for raw DAC waveform output for the specified channel.
        /// </summary>
        /// <param name="channel">specified output channel</param>
        /// <returns>state for raw DAC waveform output usage</returns>
        public string GetAwgControlDACState(string channel)
        {
            string response;
            string commandLine = "AWGControl:DOUTput" + channel + ":STATE?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion AWGControl:DOUTput[n][:STATe]

        #region AWGControl:SREStore

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:SREStore, load a setup as from a file
        /// </summary>
        /// <param name="filename">Path of the setup file</param>
        /// <param name="msus">>Mass storage unit specifier</param>
        public void AwgSRestore(string filename, string msus)
        {
            string commandLine = "AWGControl:SREStore " + '"' + filename + '"' + msus;
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion AWGControl:SREStore

        #region AWGControl:SSAVe

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:SSAVe, save an %AWG setup as a file
        /// </summary>
        /// <param name="filename">Path of the setup file</param>
        /// <param name="msus">Mass storage unit specifier</param>
        public void AwgSSave(string filename, string msus)
        {
            string commandLine = "AWGControl:SSAVe " + '"' + filename + '"' + msus;
             _mAWGVisaSession.Write(commandLine);
        }

        #endregion AWGControl:SSAVe

        #endregion deprecated

        #region AWGControl:CONFigure:CNUMber?

        // glennj 06/4/2013
        /// <summary>
        /// Returns the number of Channels
        /// </summary>
        /// <returns>"number of channels"</returns>
        public string GetAwgControlConfCNum()
        {
            string response;
            const string commandLine = "AWGControl:CONFigure:CNUMber?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion AWGControl:CONFigure:CNUMber?

        #region AWGControl:INTerleave:ADJustment:AMPLitude

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:INTerleave:ADJustment:AMPLitude set the interleave amplitude adjustment as a percentage of the analog output voltage.
        /// </summary>
        /// <param name="setValue"></param>
        public void SetAwgInterleaveAdjustmentAmplitude(string setValue)
        {
            string commandLine = "AWGControl:INTerleave:ADJustment:AMPLitude " + setValue;
             _mAWGVisaSession.Write(commandLine);
        }

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:INTerleave:ADJustment:AMPLitude? get the interleave amplitude adjustment as a percentage of the analog output voltage.
        /// </summary>
        /// <returns></returns>
        public string GetAwgInterleaveAdjustmentAmplitude()
        {
            string response;
            const string commandLine = "AWGControl:INTerleave:ADJustment:AMPLitude?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion AWGControl:INTerleave:ADJustment:AMPLitude

        #region AWGControl:INTerleave:ADJustment:PHASe

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:INTerleave:ADJustment:PHASe set the interleave adjustment phase
        /// </summary>
        /// <param name="setValue"></param>
        public void SetAwgInterleaveAdjustmentPhase(string setValue)
        {
            string commandLine = "AWGControl:INTerleave:ADJustment:PHASe " + setValue;
             _mAWGVisaSession.Write(commandLine);
        }

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:INTerleave:ADJustment:PHASe? get the interleave adjustment phase
        /// </summary>
        /// <returns></returns>
        public string GetAwgInterleaveAdjustmentPhase()
        {
            string response;
            const string commandLine = "AWGControl:INTerleave:ADJustment:PHASe?";
             _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion AWGControl:INTerleave:ADJustment:PHASe

        #region AWGControl:RMODe

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:RMODe set the run mode of the %AWG
        /// </summary>
        /// <param name="setValue">Desired run mode</param>
        public void SetAwgRMode(string setValue)
        {
            string commandLine = "AWGControl:RMODe " + setValue;
             _mAWGVisaSession.Write(commandLine);
        }

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:RMODe? return the run mode of the %AWG
        /// </summary>
        /// <returns>Run Mode</returns>
        public string GetAwgRMode()
        {
            string response;
            const string commandLine = "AWGControl:RMODe?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion AWGControl:RMODe

        #region AWGControl:RSTate?

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:RSTate? returns the state of the %AWG
        /// </summary>
        /// <returns>State of the %AWG</returns>
        public string GetAwgRState()
        {
            string response;
            const string commandLine = "AWGControl:RSTate?";
            Thread.Sleep(1000);
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion AWGControl:RSTate?

        #region AWGControl:RUN:IMMediate

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:RUN:IMMediate initiate the output of a waveform
        /// </summary>
        public void AwgRunImmediate()
        {
             _mAWGVisaSession.Write("AWGControl:RUN:IMMediate");
        }

        #endregion AWGControl:RUN:IMMediate

        #region AWGControl:SNAMe?

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:SNAMe? get the %AWG's most recently saved setup location
        /// </summary>
        /// <returns>Most recently saved setup location</returns>
        public string GetAwgSName()
        {
            string response;
            const string commandLine = "AWGControl:SNAMe?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion AWGControl:SNAMe?

        #region AWGControl:STOP:IMMediate

        //glennj 7/16/2013
        /// <summary>
        /// Using AWGControl:STOP:IMMediate, stop the requested AWG's output
        /// </summary>
        public void AwgStopImmediate()
        {
             _mAWGVisaSession.Write("AWGControl:STOP:IMMediate");
        }

        #endregion AWGControl:STOP:IMMediate

        #endregion AWGControl
    }
}
