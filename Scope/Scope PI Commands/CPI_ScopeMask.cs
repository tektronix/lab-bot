//==========================================================================
// CPI_ScopeMask.cs
//==========================================================================

namespace AwgTestFramework
{
    public partial class CPiScopeCmds
    {
        #region ScopeCommon
        #region MASK:COUNt RESET

        /// <summary>
        /// Resets the mask count
        /// Same Command for DPO and CSA change calls from CSA and DPO to ScopeMaskCountReset
        /// MASK:COUNt RESET
        /// </summary>
        public void ScopeMaskCountReset()
        {
            const string command = "MASK:COUNt RESET";
            _mScopeVisaSession.Write(command);
        }
        #endregion MASK:COUNt RESET

        #region MASK:SOUrce

        /// <summary>
        /// Sets the source for all the masks to given channel
        /// Can be set to other things but ignored here for brevity
        /// 
        /// MASK:SOUrce CH[n]
        /// </summary>
        /// <param name="channel">Channel source</param>
        public void ScopeMaskSourceCH(string channel)
        {
            const string command = "MASK:SOUrce CH";
            _mScopeVisaSession.Write(command + channel);
        }
        #endregion MASK:SOUrce

        #region RECAll:MASK

        /// <summary>
        /// jmanning 01/14/14
        /// Loads a mask file onto the scope
        /// 
        /// RECAll:MASK
        /// </summary>
        /// <param name="filepath">Setup filepath</param>
        public void ScopeRecallMask(string filepath)
        {
            filepath = '"' + filepath + '"';
            const string command = "RECAll:MASK ";
            _mScopeVisaSession.Write(command + filepath);
        }

        #endregion RECAll:MASK
        #endregion ScopeCommon

        #region CSA Only
        #region MASK:COUNt:STATE

        /// <summary>
        /// Turns the mask counting state on or off
        /// 
        /// MASK:COUNt:STATE
        /// </summary>
        /// <param name="state">Mask counting state</param>
        public void CSAMaskCountState(string state)
        {
            const string command = "MASK:COUNt:STATE ";
            _mScopeVisaSession.Write(command + state);
        }

        #endregion MASK:COUNt:STATE

        #region MASK:COUNt:TOTal?
        /// <summary>
        /// Gets the mask hit count for all the masks 
        /// 
        /// MASK:COUNt:TOTal?
        /// </summary>
        /// <returns>Mask hit count for all the masks</returns>
        public string CSAMaskHitCountTotalQuery()
        {
            string response;
            const string command = "MASK:COUNt:TOTal?";
            _mScopeVisaSession.Query(command, out response);
            //response = scope.ScopeErrorQueueParser(command, response);
            if (response == "")
            {
                //_mScopeVisaSession.Read(out response);
                response = _mScopeVisaSession.ErrorDescription;
            }
            return response;
        }
        #endregion MASK:COUNt:TOTal?

        #region MASK:MASK[n]:COUNt?
        /// <summary>
        /// Gets the CSA mask hit count for a specified masks
        /// 
        /// MASK:MASK[n]:COUNt?
        /// </summary>
        /// <param name="maskNumber">Desired mask</param>
        /// <returns>Mask count</returns>
        public string CSAMaskHitCountQuery(string maskNumber)
        {
            string response;
            string command = "MASK:MASK" + maskNumber + ":COUNt?";
            _mScopeVisaSession.Query(command, out response);
            //response = scope.ScopeErrorQueueParser(command, response);
            if (response == "")
            {
                //_mScopeVisaSession.Read(out response);
                response = _mScopeVisaSession.ErrorDescription;
            }
            return response;
        }
        #endregion MASK:MASK[n]:COUNt?

        #region MASK:MASK[n] DELETE
        /// <summary>
        /// Deletes the mask vertices for a given mask on a CSA
        /// 
        /// MASK:MASK[n]DELETE
        /// </summary>
        /// <param name="maskNumber">Mask to delete</param>
        public void CSAMaskDelete(string maskNumber)
        {
            string command = "MASK:MASK" + maskNumber + " DELETE";
            _mScopeVisaSession.Write(command);
        }
        #endregion MASK:MASK[n] DELETE

        #region MASK:MASK[n]:POINTSPcnt
        /// <summary>
        /// Sets the mask vertices for a given mask by percentage
        /// 
        /// MASK:MASK[n]:POINTSPcnt
        /// </summary>
        /// <param name="maskNumber">Desired mask number</param>
        /// <param name="maskList">List of points</param>
        public void CSAMaskPoint(string maskNumber, string maskList)
        {
            string command = "MASK:MASK" + maskNumber + " POINTSPcnt";
            _mScopeVisaSession.Write(command + maskList);
        }
        #endregion MASK:MASK[n]:POINTSPcnt
        #endregion CSA Only

        #region DPO Only
        #region MASK:COUNt:HITS?
        /// <summary>
        /// Gets the mask hit count for all the mask segments
        /// 
        /// MASK:COUNt:HITS?
        /// </summary>
        /// <returns>Mask hit count for all the masks</returns>
        public string DPOMaskHitCountTotalQuery()
        {
            string response;
            const string command = "MASK:COUNt:HITS?";
            _mScopeVisaSession.Query(command, out response);
            //response = scope.ScopeErrorQueueParser(command, response);
            if (response == "")
            {
                //_mScopeVisaSession.Read(out response);
                response = _mScopeVisaSession.ErrorDescription;
            }
            return response;
        }
        #endregion MASK:COUNt:HITS?

        #region MASK:COUNt:SEG[n]:HITS?
        /// <summary>
        /// Gets the mask hit count for a specified mask segment on a DPO Scope
        /// 
        /// MASK:COUNt:SEG[n]:HITS?
        /// </summary>
        /// <param name="maskSegment">Specified Mask Segment</param>
        /// <returns>Mask count</returns>
        public string DPOMaskSegmentHitCountQuery(int maskSegment)
        {
            int maskSegmentIndex = maskSegment - 1;
            string response;
            string command = "MASK:COUNt:SEG" + maskSegmentIndex + ":HITS?";
            _mScopeVisaSession.Query(command, out response);
            if (response == "")
            {
                //_mScopeVisaSession.Read(out response);
                response = _mScopeVisaSession.ErrorDescription;
            }
            return response;
        }
        #endregion MASK:COUNt:SEG[n]:HITS?

        #region MASK:DISplay
        /// <summary>
        /// Used for turning on and off Masks withoout Deleting them
        /// Mask Counting, mask testing, and mask autoset are unavailable is the mask display is OFF
        /// Default setting is ON
        /// 
        /// MASK:DISplay [OFF|ON]
        /// </summary>
        /// <param name="displayState">Mast Display State ON or OFF</param>
        public void DPOMaskDisplayState(string displayState)
        {
            string command = "MASK:DISplay " + displayState;
            _mScopeVisaSession.Write(command);
        }
        #endregion MASK:DISplay

        #region MASK:STANdard
        /// <summary>
        /// Deletes the existing mask and sets the selected standard mask on a DPO scope
        /// 
        /// MASK:STANdard
        /// </summary>
        /// <param name="maskStandard">Mask Standard to load</param>
        public void DPOMaskStandardSet(string maskStandard)
        {
            string command = "MASK:STANdard " + maskStandard;
            _mScopeVisaSession.Write(command);
        }
        #endregion MASK:STANdard

        #region MASK:TESt:STATE

        /// <summary>
        /// Turns the mask test counting state on or off
        /// 
        /// MASK:TESt:STATE
        /// </summary>
        /// <param name="state">Mask Test counting state</param>
        public void DPOMaskCountState(string state)
        {
            const string command = "MASK:TESt:STATE ";
            _mScopeVisaSession.Write(command + state);
        }

        #endregion MASK:TESt:STATE

        #region MASK:TESt:STATUS?
        /// <summary>
        /// Gets the DPO Mask Test Status
        /// 
        /// MASK:TESt:STATUS?
        /// </summary>
        /// <returns>Mask Test Status</returns>
        public string DPOMaskTestStatusQuery()
        {
            string response;
            const string command = "MASK:TESt:STATUS?";
            _mScopeVisaSession.Query(command, out response);
            if (response == "")
            {
                response = _mScopeVisaSession.ErrorDescription;
            }
            return response;
        }
        #endregion MASK:TESt:STATUS? 
        #endregion DPO Only
    }
}
