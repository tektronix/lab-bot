//==========================================================================
// ExtSourceWaveformGroup.cs
//==========================================================================

using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains helper functions that are called from the External Source Waveform PI step definitions
    /// 
    /// </summary>
    public class ExtSourceWaveformGroup
    {
        #region WLISt:SIZE?
        /// <summary>
        /// Gets the the size(number of waveforms) of the waveform list from the externl source
        /// 
        /// WLISt:SIZE?
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <returns>the size(number of waveforms) of the waveform list</returns>
        public void GetExtSrcWfmListSize(IEXTSOURCE extSource)
        {
            extSource.GetExtSrcWfmListSize();
        }

        public void WaitForWfmListToAddWfms(IEXTSOURCE extSource, string numEntries, string seconds)
        {
            UTILS.HiPerfTimer timer = new UTILS.HiPerfTimer();
            double totalTime = 0;
            int currentEntries = Int16.Parse(extSource.ExtSrcWfmListSize);
            int expectedEntries = Int16.Parse(numEntries) + currentEntries;
         
            while ((totalTime < double.Parse(seconds)))
            {
                timer.Start();
                extSource.GetExtSrcWfmListSize();
                if (Int16.Parse(extSource.ExtSrcWfmListSize) == expectedEntries)
                {
                    return;
                }
                Thread.Sleep(50); // Have to make sure this is between the start/stop commands
                timer.Stop();
                // Add the current interval to the total
                totalTime = totalTime + timer.Duration;
            }
            Assert.Fail("Waveform entries were not added in the allowed " + seconds + " seconds time limit.  Waveform Entries Found: " + extSource.ExtSrcWfmListSize);
        }
        #endregion WLISt:SIZE?

        #region WLISt:WAVeform:NEW
        /// <summary>
        /// Creates a new empty waveform in the waveform list of the current setup on the external source
        /// 
        /// WLISt:WAVeform:NEW
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <param name="wfmName">waveform name</param>
        /// <param name="wfmSize">waveform size(number of points)</param>
        /// <param name="wfmType">waveform type</param>
        public void SetExtSrcWfmNew(IEXTSOURCE extSource, string wfmName, string wfmSize, string wfmType)
        {
            extSource.SetExtSrcWfmNew(wfmName,wfmSize,wfmType);
        }
        #endregion WLISt:WAVeform:NEW
    }
}
