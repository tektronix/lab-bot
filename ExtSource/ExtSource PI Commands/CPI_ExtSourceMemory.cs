//==========================================================================
// CPI_ExtSourceMemory.cs
//==========================================================================

namespace AwgTestFramework
{
    public partial class CPiExtSourceCmds
    {
        #region MMEMory:IMPort
        /// <summary>
        /// Imports a file on the external source as a waveform
        /// 
        /// MMEMory:IMPort
        /// </summary>
        /// <param name="wfmName">Waveform Name</param>
        /// <param name="fileName">Waveform File Name</param>
        /// <param name="wfmType">Waveform Type</param>
        public void SetExtSrcMemImport( string wfmName, string fileName, string wfmType)
        {
            string commandLine = "MMEMory:IMPort " + '"' + wfmName + '"' + ',' + '"' + fileName + '"' + ',' + wfmType;
            _mExtSourceVisaSession.Write(commandLine);
        }
        #endregion MMEMory:IMPort

        #region MMEMory:DELete
        /// <summary>
        /// Deletes a file or directory from the external source's hard drive
        /// 
        /// MMEMory:DELete
        /// </summary>
        /// <param name="filename">filename to save settings to</param>
        /// <param name="msus">mass storage unit specifier aka drive</param>
        public void DeleteExtSrcMemFile(string filename, string msus)
        {
            string commandLine = "MMEMory:DELete " + '"' + filename + '"' + msus;
            _mExtSourceVisaSession.Write(commandLine);
        }
        #endregion MMEMory:DELete
    }
}
