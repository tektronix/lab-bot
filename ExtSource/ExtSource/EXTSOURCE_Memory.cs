//==========================================================================
// EXTSOURCE_MemorySection.cs
//==========================================================================

namespace AwgTestFramework
{
    public partial class EXTSOURCE
    {
        /// <summary>
        /// Imports a file on the external source as a waveform
        /// 
        /// MMEMory:IMPort
        /// </summary>
        /// <param name="wfmName">Waveform Name</param>
        /// <param name="fileName">Waveform File Name</param>
        /// <param name="wfmType">Waveform Type</param>
        public void SetExtSrcMemImport(string wfmName, string fileName, string wfmType)
        {
            _piex.SetExtSrcMemImport(wfmName, fileName, wfmType);
        }

        /// <summary>
        /// Deletes a file or directory from the external source's hard drive
        /// 
        /// MMEMory:DELete
        /// </summary>
        /// <param name="filename">filename to save settings to</param>
        /// <param name="msus">mass storage unit specifier aka drive</param>
        public void DeleteExtSrcMemFile(string filename, string msus)
        {
            _piex.DeleteExtSrcMemFile(filename, msus);
        }

    }
}
