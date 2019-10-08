//==========================================================================
// ExtSourceControlGroup.cs
//==========================================================================
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains helper functions that are called from the External Source Control PI step definitions
    /// 
    /// </summary>
    public class ExtSourceControlGroup
    {
        #region AWGControl:INTerleave:STATE
        /// <summary>
        /// Enables or disables the interleave states for channels on the external source
        /// 
        /// AWGControl:INTerleave:STATE
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <param name="state">interleave state ON|OFF</param>
        public void SetExtSrcInterLeaveState(IEXTSOURCE extSource, string state)
        {
            extSource.SetExtSrcInterLeaveState(state);
        }
        #endregion AWGControl:INTerleave:STATE

        #region AWGControl:INTerleave:ZERoing
        /// <summary>
        /// Sets or removes the zeroing option for interleave mode on the external source
        /// 
        /// AWGControl:INTerleave:ZERoing
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <param name="state">sets state for interleaving mode zeroing option</param>
        /// <returns>System error code and message</returns>
        public void SetExtSrcInterLeaveZeroing(IEXTSOURCE extSource, string state)
        {
            extSource.SetExtSrcInterLeaveZeroing(state);
        }
        #endregion AWGControl:INTerleave:ZERoing

        #region AWGControl:RMODe
        /// <summary>
        /// Sets the run mode for the external source
        /// 
        /// AWGControl:RMODe 
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <param name="mode">run mode setting</param>
        public void SetExtSrcRunMode(IEXTSOURCE extSource, string mode)
        {
            extSource.SetExtSrcRunMode(mode);
        }
        #endregion AWGControl:RMODe

        #region AWGControl:RMODe?
        /// <summary>
        /// Gets the run mode status from the external source
        /// 
        /// AWGControl:RMODe?
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <returns>run mode status</returns>
        public void GetExtSrcRunModeQuery(IEXTSOURCE extSource)
        {
            extSource.GetExtSrcRunModeQuery();
        }

        /// <summary>
        /// Compares an expected runmode type with the run mode type returned from the external source
        /// 
        /// AWGControl:RMODe?
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <param name="expectedMode">Expected mode type</param>
        public void TheExtSrcRunModeShouldBe(IEXTSOURCE extSource, string expectedMode)
        {
            extSource.GetExtSrcRunModeQuery();
            Assert.AreEqual(expectedMode, extSource.ExtSrcRunMode, "Expected run mode " + expectedMode + ".  External Source run mode is " + extSource.ExtSrcRunMode);
        }
        #endregion AWGControl:RMODe?

        #region AWGControl:RRATe
        /// <summary>
        /// Sets the repeat rate the external source
        /// 
        /// AWGControl:RRATe
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <param name="setValue">repeat rate value</param>
        public void SetExtSrcRepRate(IEXTSOURCE extSource, string setValue)
        {
           extSource.SetExtSrcRepRate(setValue);
        }
        #endregion AWGControl:RRATe

        #region AWGControl:RRATe?
        /// <summary>
        /// Gets the repeat rate the external source
        /// 
        /// AWGControl:RRATe?
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <returns>repeat rate value</returns>
        public void GetExtSrcRepRate(IEXTSOURCE extSource)
        {
            extSource.GetExtSrcRepRate();
        }
        #endregion AWGControl:RRATe?

        #region AWGControl:RUN:IMMediate
        /// <summary>
        /// Initiates the output of a waveform or sequence on the external source
        /// 
        /// AWGControl:RUN:IMMediate
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        public void SetExtSrcRunImm(IEXTSOURCE extSource)
        {
            extSource.SetExtSrcRunImm();
        }
        #endregion AWGControl:RUN:IMMediate

        #region AWGControl:SNAMe?
        /// <summary>
        /// Gets the filename of the current setup on the external source
        /// 
        /// AWGControl:SNAMe?
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <returns>filename including path of the setup file</returns>
        public void GetExtSrcSetupNameQuery(IEXTSOURCE extSource)
        {
            extSource.GetExtSrcSetupNameQuery();
        }

        public void TheExtSrcSetupNameShouldBe(IEXTSOURCE extSource, string expectedName)
        {
            extSource.GetExtSrcSetupNameQuery();
            Assert.AreEqual(expectedName, extSource.ExtSrcSetupNam, "The setup file " + extSource.ExtSrcSetupNam + " does not match expected");
        }
        #endregion AWGControl:SNAMe?

        #region AWGControl:STOP:IMMediate
        /// <summary>
        /// Stops the output of a waveform or sequence on the external source
        /// 
        /// AWGControl:STOP:IMMediate
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        public void SetExtSrcStopImm(IEXTSOURCE extSource)
        {
            extSource.SetExtSrcStopImm();
        }
        #endregion AWGControl:STOP:IMMediate

        #region AWGControl:SREStore
        /// <summary>
        /// Restores the AWG's settings from a speficied settings file for the external source
        /// 
        /// AWGControl:SREStore 
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <param name="filename">settings file to load</param>
        public void SetExtSrcFileRestore(IEXTSOURCE extSource, string filename)
        {
            extSource.SetExtSrcFileRestore(filename);
        }

        /// <summary>
        ///  Restores the AWG's settings from a speficied settings file and MSUS for the external source
        /// 
        /// AWGControl:SREStore
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <param name="filename">settings file to load</param>
        /// <param name="msus">mass storage unit specifier aka drive</param>
        public void SetExtSrcFileWithMsusRestore(IEXTSOURCE extSource, string filename, string msus)
        {
            if (msus != "")
            {
                msus = "," + "\"" + msus + "\"";
            } 
            extSource.SetExtSrcFileWithMsusRestore(filename, msus);
        }
        #endregion AWGControl:SREStore

        #region AWGControl:SSave
        /// <summary>
        /// Saves the external source's settings to a file
        /// 
        /// AWGControl:SSave
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <param name="filename">filename to save settings to</param>
        /// <param name="msus">mass storage unit specifier aka drive</param>
        public void SaveExtSrcSettings(IEXTSOURCE extSource, string filename, string msus)
        {
            if (msus != "")
            {
                msus = "," + "\"" + msus + "\"";
            } 
            extSource.SaveExtSrcSettings(filename, msus);
        }
        #endregion AWGControl:SSave
    }
}
