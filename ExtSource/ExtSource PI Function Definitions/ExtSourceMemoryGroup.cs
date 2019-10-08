//==========================================================================
// ExtSourceMemoryGroup.cs
//==========================================================================

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains helper functions that are called from the External Source Memory PI step definitions
    /// 
    /// </summary>
    public class ExtSourceMemoryGroup
    {
        #region MMEMory:IMPort
        /// <summary>
        /// Imports a file on the external source as a waveform
        /// 
        /// MMEMory:IMPort
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <param name="wfmName">Waveform Name</param>
        /// <param name="fileName">Waveform File Name</param>
        /// <param name="wfmType">Waveform Type</param>
        public void SetExtSrcMemImport(IEXTSOURCE extSource, string wfmName, string fileName, string wfmType)
        {
            extSource.SetExtSrcMemImport(wfmName,fileName,wfmType);
        }
        #endregion MMEMory:IMPort

        #region MMEMory:DELete
        /// <summary>
        /// Deletes a file or directory from the external source's hard drive
        /// 
        /// MMEMory:DELete
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <param name="filename">filename to save settings to</param>
        /// <param name="msus">mass storage unit specifier aka drive</param>
        public void DeleteExtSrcMemFile(IEXTSOURCE extSource, string filename, string msus)
        {
            extSource.DeleteExtSrcMemFile(filename,msus);
        }
        #endregion MMEMory:DELete
    }
}
