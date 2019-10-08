//==========================================================================
// CPI_ExtSourceWaveform.cs
//==========================================================================

namespace AwgTestFramework
{
    public partial class CPiExtSourceCmds
    {
        #region WLISt:SIZE?
        /// <summary>
        /// Gets the the size(number of waveforms) of the waveform list from the externl source
        /// 
        /// WLISt:SIZE?
        /// </summary>
        /// <returns>the size(number of waveforms) of the waveform list</returns>
        public string GetExtSrcWfmListSize()
        {
            string response;
            const string command = "WLISt:SIZE?";
            _mExtSourceVisaSession.Query(command, out response);
            return response;
        }
        #endregion WLISt:SIZE?

        #region WLISt:WAVeform:NEW
        /// <summary>
        /// Creates a new empty waveform in the waveform list of the current setup on the external source
        /// 
        /// WLISt:WAVeform:NEW
        /// </summary>
        /// <param name="wfmName">waveform name</param>
        /// <param name="wfmSize">waveform size(number of points)</param>
        /// <param name="wfmType">waveform type</param>
        public void SetExtSrcWfmNew( string wfmName, string wfmSize, string wfmType)
        {
            string commandLine = "WLISt:WAVeform:NEW " + wfmName + ", " + wfmSize + ", " + wfmType;
            _mExtSourceVisaSession.Write(commandLine);
        }
        #endregion WLISt:WAVeform:NEW
    }
}
