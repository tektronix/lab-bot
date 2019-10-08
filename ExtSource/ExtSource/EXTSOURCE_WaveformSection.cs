//==========================================================================
// EXTSOURCE_WaveformSection.cs
//==========================================================================

namespace AwgTestFramework
{
    public partial class EXTSOURCE
    {
        /// <summary>
        /// Property to contain the External Source response from WLISt:SIZE?
        /// </summary>
        public string ExtSrcWfmListSize { get; set; }
        
        /// <summary>
        /// Gets the the size(number of waveforms) of the waveform list from the externl source
        /// 
        /// WLISt:SIZE?
        /// </summary>
        /// <returns>the size(number of waveforms) of the waveform list</returns>
        public void GetExtSrcWfmListSize()
        {
            ExtSrcWfmListSize = _piex.GetExtSrcWfmListSize();
        }

        /// <summary>
        /// Creates a new empty waveform in the waveform list of the current setup on the external source
        /// 
        /// WLISt:WAVeform:NEW
        /// </summary>
        /// <param name="wfmName">waveform name</param>
        /// <param name="wfmSize">waveform size(number of points)</param>
        /// <param name="wfmType">waveform type</param>
        public void SetExtSrcWfmNew(string wfmName, string wfmSize, string wfmType)
        {
            _piex.SetExtSrcWfmNew(wfmName, wfmSize, wfmType);
        }
    }
}
