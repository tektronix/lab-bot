//==========================================================================
// SCOPE_MaskSection.cs
//==========================================================================
namespace AwgTestFramework
{
    public partial class SCOPE
    {
        /// <summary>
        /// Property to contain the CSA response from MASK:COUNt:TOTal?
        /// </summary>
        public string CSAMasksTotalHitCount { get; set; }
        
        /// <summary>
        /// Property to contain the CSA response from MASK:MASK[n]:COUNt?
        /// </summary>
        public string [] CSAMaskHitCount { get; set; }
        
        /// <summary>
        /// Property to contain the DPO response from MASK:COUNt:HITS?
        /// </summary>
        public string DPOMaskHitCountTotal { get; set; }
        
        /// <summary>
        /// Property to contain the DPO response from  MASK:COUNt:SEG[n]:HITS?
        /// </summary>
        public string [] DPOMaskSegmentHitCount { get; set; }

        /// <summary>
        /// Property to contain the DPO response from  MASK:TESt:STATUS?
        /// </summary>
        public string DPOMaskTestStatus { get; set; }
        

        /// <summary>
        /// Resets the Mask Count on the Scope
        /// 
        /// uses MASK:COUNt RESET
        /// </summary>
        public void ScopeMaskCountResetExecute()
        {
            _pis.ScopeMaskCountReset();
        }

        /// <summary>
        /// Sets the source for all the masks to given channel
        /// Can be set to other things but ignored here for brevity
        /// 
        /// MASK:SOUrce CH[n]
        /// </summary>
        /// <param name="channel">Channel source</param>
        public void SetScopeMaskSourceCH(string channel)
        {
            _pis.ScopeMaskSourceCH(channel);
        }

        /// <summary>
        /// Loads a mask file onto the scope
        /// 
        /// uses RECAll:MASK
        /// </summary>
        /// <param name="filepath">Setup filepath</param>
        public void ScopeRecallMaskExecute(string filepath)
        {
            _pis.ScopeRecallMask(filepath);
        }

        /// <summary>
        /// Sets the mask counting state on or off on a CSA
        /// 
        /// uses MASK:COUNt:STATE
        /// </summary>
        /// <param name="state">Mask counting state</param>
        public void SetCSAMaskCountState(string state)
        {
            _pis.CSAMaskCountState(state);
        }

        /// <summary>
        /// Gets the mask hit count for all the masks on a CSA 
        /// 
        /// uses MASK:COUNt:TOTal?
        /// </summary>
        /// <returns>Mask hit count for all the masks</returns>
        public void  GetCSAMaskHitCountTotal()
        {
            CSAMasksTotalHitCount = _pis.CSAMaskHitCountTotalQuery();
        }

        /// <summary>
        /// Gets the CSA mask hit count for a specified masks
        /// 
        /// uses MASK:MASK[n]:COUNt?
        /// </summary>
        /// <param name="maskNumber">Desired mask</param>
        /// <returns>Mask count</returns>
        public void GetCSAMaskHitCount(int maskNumber)
        {
            int index = maskNumber - 1;
            string maskNum = maskNumber.ToString();
            CSAMaskHitCount[index] = _pis.CSAMaskHitCountQuery(maskNum);
        }

        /// <summary>
        /// Sets the mask index of the mask that will be deleted on a CSA
        /// 
        /// uses MASK:MASK[n]DELETE
        /// </summary>
        /// <param name="maskNumber">Mask to delete</param>
        public void SetCSAMaskDelete(string maskNumber)
        {
            _pis.CSAMaskDelete(maskNumber);
        }

        /// <summary>
        /// Sets the mask vertices for a given mask by percentage
        /// 
        /// MASK:MASK[n]:POINTSPcnt
        /// </summary>
        /// <param name="maskNumber">Desired mask number</param>
        /// <param name="maskList">List of points</param>
        public void SetCSAMaskPoint(string maskNumber, string maskList)
        {
            _pis.CSAMaskPoint(maskNumber, maskList);
        }

        /// <summary>
        /// Gets the mask hit count for all the mask segments
        /// 
        /// use MASK:COUNt:HITS?
        /// </summary>
        /// <returns>Mask hit count for all the masks</returns>
        public void  GetDPOMaskHitCountTotal()
        {
            DPOMaskHitCountTotal = _pis.DPOMaskHitCountTotalQuery();
        }
        
        /// <summary>
        /// Gets the mask hit count for a specified mask segment on a DPO Scope
        /// 
        /// MASK:COUNt:SEG[n]:HITS?
        /// </summary>
        /// <param name="maskSegment">Specified Mask Segment Number</param>
        /// <returns>Mask count</returns>
        public void GetDPOMaskSegmentHitCount(int maskSegment)
        {
            int maskSegmentNum = maskSegment - 1;
            DPOMaskSegmentHitCount[maskSegmentNum] = _pis.DPOMaskSegmentHitCountQuery(maskSegment);
        }

        /// <summary>
        /// Sets Mask Display State
        /// Mask Counting, mask testing, and mask autoset are unavailable is the mask display is OFF
        /// Default setting is ON
        /// 
        /// uses MASK:DISplay [OFF|ON]
        /// </summary>
        /// <param name="displayState">Display State of Mask either ON or OFF</param>
        public void SetDPOMaskDisplayState(string displayState)
        {
            _pis.DPOMaskDisplayState(displayState);
        }

        /// <summary>
        /// Deletes the existing mask and sets the selected standard mask on a DPO scope
        /// 
        /// uses MASK:STANdard
        /// </summary>
        /// <param name="maskStandard">Mask Standard to load</param>
        public void SetDPOMaskStandard(string maskStandard)
        {
            _pis.DPOMaskStandardSet(maskStandard);
        }

        /// <summary>
        /// Sets the mask test counting state ON or OFF on a DPO Scope
        /// 
        /// MASK:TESt:STATE
        /// </summary>
        /// <param name="state">Mask Test counting state</param>
        public void SetDPOMaskCountState(string state)
        {
            _pis.DPOMaskCountState(state);
        }


        /// <summary>
        /// Gets the DPO Mask Test Status
        /// 
        /// uses MASK:TESt:STATUS?
        /// </summary>
        public void GetDPOMaskTestStatus()
        {
            DPOMaskTestStatus = _pis.DPOMaskTestStatusQuery();
        }
    }
}
