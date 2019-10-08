//==========================================================================
// EXTSOURCE_ControlSection.cs
//==========================================================================

namespace AwgTestFramework
{
    public partial class EXTSOURCE
    {
        /// <summary>
        /// Property to contain the External Source response from AWGControl:RMODe?
        /// </summary>
        public string ExtSrcRunMode { get; set; }

        /// <summary>
        /// Property to contain the External Source response from AWGControl:RRATe?
        /// </summary>
        public string ExtSrcRepRate { get; set; }

        /// <summary>
        /// Property to contain the External Source response from AWGControl:SNAMe?
        /// </summary>
        public string ExtSrcSetupNam { get; set; }
        
        /// <summary>
        /// Enables or disables the interleave states for channels on the external source
        /// 
        /// use AWGControl:INTerleave:STATE
        /// </summary>
        /// <param name="state">interleave state ON|OFF</param>
        public void SetExtSrcInterLeaveState(string state)
        {
            _piex.SetExtSrcInterLeaveState(state);
        }

        /// <summary>
        /// Sets or removes the zeroing option for interleave mode on the external source
        /// 
        /// AWGControl:INTerleave:ZERoing
        /// </summary>
        /// <param name="state">sets state for interleaving mode zeroing option</param>
        /// <returns>System error code and message</returns>
        public void SetExtSrcInterLeaveZeroing(string state)
        {
            _piex.SetExtSrcInterLeaveZeroing(state);
        }

        /// <summary>
        /// Sets the run mode for the external source
        /// 
        /// AWGControl:RMODe 
        /// </summary>
        /// <param name="mode">run mode setting</param>
        public void SetExtSrcRunMode(string mode)
        {
           _piex.SetExtSrcRunMode(mode);
        }

        /// <summary>
        /// Gets the run mode status from the external source
        /// 
        /// AWGControl:RMODe?
        /// </summary>
        /// <returns>run mode status</returns>
        public void GetExtSrcRunModeQuery()
        {
            ExtSrcRunMode = _piex.GetExtSrcRunModeQuery();
        }

        /// <summary>
        /// Sets the repeat rate the external source
        /// 
        /// AWGControl:RRATe
        /// </summary>
        /// <param name="setValue">repeat rate value</param>
        /// <returns>System error code and message</returns>
        public void SetExtSrcRepRate(string setValue)
        {
            _piex.SetExtSrcRepRate(setValue);
        }

        /// <summary>
        /// Gets the repeat rate the external source
        /// 
        /// AWGControl:RRATe?
        /// </summary>
        /// <returns>repeat rate value</returns>
        public void GetExtSrcRepRate()
        {
            ExtSrcRepRate = _piex.GetExtSrcRepRate();
        }

        /// <summary>
        /// Initiates the output of a waveform or sequence on the external source
        /// 
        /// AWGControl:RUN:IMMediate
        /// </summary>
        public void SetExtSrcRunImm()
        {
            _piex.SetExtSrcRunImm();
        }

        /// <summary>
        /// Gets the filename of the current setup on the external source
        /// 
        /// AWGControl:SNAMe?
        /// </summary>
        /// <returns>filename including path of the setup file</returns>
        public void GetExtSrcSetupNameQuery()
        {
            ExtSrcSetupNam = _piex.GetExtSrcSetupNameQuery();
        }

        /// <summary>
        /// Stops the output of a waveform or sequence on the external source
        /// 
        /// AWGControl:STOP:IMMediate
        /// </summary>
        public void SetExtSrcStopImm()
        {
            _piex.SetExtSrcStopImm();
        }

        /// <summary>
        /// Restores the AWG's settings from a speficied settings file for the external source
        /// 
        /// AWGControl:SREStore 
        /// </summary>
        /// <param name="filename">settings file to load</param>
        public void SetExtSrcFileRestore(string filename)
        {
            _piex.SetExtSrcFileRestore(filename);
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
            _piex.SetExtSrcFileWithMsusRestore(filename, msus);
        }

        /// <summary>
        /// Saves the external source's settings to a file
        /// 
        /// AWGControl:SSave
        /// </summary>
        /// <param name="filename">filename to save settings to</param>
        /// <param name="msus">mass storage unit specifier aka drive</param>
        public void SaveExtSrcSettings(string filename, string msus)
        {
            _piex.SaveExtSrcSettings(filename, msus);
        }
    }
}
