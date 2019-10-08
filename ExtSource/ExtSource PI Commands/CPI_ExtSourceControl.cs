//==========================================================================
// CPI_ExtSourceControl.cs
//==========================================================================

namespace AwgTestFramework
{
    public partial class CPiExtSourceCmds
    {
        #region AWGControl:INTerleave:STATE
        /// <summary>
        /// Enables or disables the interleave states for channels on the external source
        /// 
        /// AWGControl:INTerleave:STATE
        /// </summary>
        /// <param name="state">interleave state ON|OFF</param>
        public void SetExtSrcInterLeaveState(string state)
        {
            string commandLine = "AWGControl:INTerleave:STATE " + state;
            _mExtSourceVisaSession.Write(commandLine);
        }
        #endregion AWGControl:INTerleave:STATE

        #region AWGControl:INTerleave:ZERoing
        /// <summary>
        /// Sets or removes the zeroing option for interleave mode on the external source
        /// 
        /// AWGControl:INTerleave:ZERoing
        /// </summary>
        /// <param name="state">sets state for interleaving mode zeroing option</param>
        /// <returns>System error code and message</returns>
        public void SetExtSrcInterLeaveZeroing(string state)
        {
            string commandLine = "AWGControl:INTerleave:ZERoing " + state;
            _mExtSourceVisaSession.Write(commandLine);
        }
        #endregion AWGControl:INTerleave:ZERoing

        #region AWGControl:RMODe
        /// <summary>
        /// Sets the run mode for the external source
        /// 
        /// AWGControl:RMODe 
        /// </summary>
        /// <param name="mode">run mode setting</param>
        public void SetExtSrcRunMode(string mode)
        {
            string command = "AWGControl:RMODe " + mode;
            _mExtSourceVisaSession.Write(command);
        }
        #endregion AWGControl:RMODe

        #region AWGControl:RMODe?
        /// <summary>
        /// Gets the run mode status from the external source
        /// 
        /// AWGControl:RMODe?
        /// </summary>
        /// <returns>run mode status</returns>
        public string GetExtSrcRunModeQuery()
        {
            string response;
            const string command = "AWGControl:RMODe?";
            _mExtSourceVisaSession.Query(command, out response);
            return response;
        }
        #endregion AWGControl:RMODe?
        
        #region AWGControl:RRATe
        /// <summary>
        /// Sets the repeat rate the external source
        /// 
        /// AWGControl:RRATe
        /// </summary>
        /// <param name="setValue">repeat rate value</param>
        public void SetExtSrcRepRate(string setValue)
        {
            string commandLine = "AWGControl:RRATe " + setValue;
            _mExtSourceVisaSession.Write(commandLine);
        }
        #endregion AWGControl:RRATe

        #region AWGControl:RRATe?
        /// <summary>
        /// Gets the repeat rate the external source
        /// 
        /// AWGControl:RRATe?
        /// </summary>
        /// <returns>repeat rate value</returns>
        public string GetExtSrcRepRate()
        {
            string response;
            const string command = "AWGControl:RRATe?";
            _mExtSourceVisaSession.Query(command, out response);
            return response;
        }
        #endregion AWGControl:RRATe?

        #region AWGControl:RUN:IMMediate
        /// <summary>
        /// Initiates the output of a waveform or sequence on the external source
        /// 
        /// AWGControl:RUN:IMMediate
        /// </summary>
        public void SetExtSrcRunImm()
        {
            const string command = "AWGControl:RUN:IMMediate";
            _mExtSourceVisaSession.Write(command);
        }
        #endregion AWGControl:RUN:IMMediate

        #region AWGControl:SNAMe?
        /// <summary>
        /// Gets the filename of the current setup on the external source
        /// 
        /// AWGControl:SNAMe?
        /// </summary>
        /// <returns>filename including path of the setup file</returns>
        public string GetExtSrcSetupNameQuery()
        {
            string response;
            const string command = "AWGControl:SNAMe?";
            _mExtSourceVisaSession.Query(command, out response);
            return response;
        }
        #endregion AWGControl:SNAMe?

        #region AWGControl:STOP:IMMediate
        /// <summary>
        /// Stops the output of a waveform or sequence on the external source
        /// 
        /// AWGControl:STOP:IMMediate
        /// </summary>
        public void SetExtSrcStopImm()
        {
            const string command = "AWGControl:STOP:IMMediate";
            _mExtSourceVisaSession.Write(command);
        }
        #endregion AWGControl:STOP:IMMediate

        #region AWGControl:SREStore
        /// <summary>
        /// Restores the AWG's settings from a speficied settings file for the external source
        /// 
        /// AWGControl:SREStore 
        /// </summary>
        /// <param name="filename">settings file to load</param>
        public void SetExtSrcFileRestore( string filename)
        {
            string command = "AWGControl:SREStore " + filename;
            _mExtSourceVisaSession.Write(command);
        }

        /// <summary>
        ///  Restores the AWG's settings from a speficied settings file and MSUS for the external source
        /// 
        /// AWGControl:SREStore
        /// </summary>
        /// <param name="filename">settings file to load</param>
        /// <param name="msus">mass storage unit specifier aka drive</param>
        public void SetExtSrcFileWithMsusRestore(string filename, string msus)
        {
            string commandLine = "AWGControl:SREStore " + '"' + filename + '"' + msus;
            _mExtSourceVisaSession.Write(commandLine);
        }
        #endregion AWGControl:SREStore

        #region AWGControl:SSave
        /// <summary>
        /// Saves the external source's settings to a file
        /// 
        /// AWGControl:SSave
        /// </summary>
        /// <param name="filename">filename to save settings to</param>
        /// <param name="msus">mass storage unit specifier aka drive</param>
        public void SaveExtSrcSettings(string filename, string msus)
        {
            string commandLine = "AWGControl:SSave " + '"' + filename + '"' + msus;
            _mExtSourceVisaSession.Write(commandLine);
        }
        #endregion AWGControl:SSave
    }
}
