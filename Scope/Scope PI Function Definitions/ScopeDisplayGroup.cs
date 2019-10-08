//==========================================================================
// ScopeDisplayGroup.cs
//==========================================================================

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains helper functions that are called from the Scope Acquisition PI step definitions
    /// 
    /// </summary>
    public class ScopeDisplayGroup 
    {
        #region ScopeCommon
        /// <summary>
        /// Autoset the scope
        /// 
        /// AUTOSet EXECute
        /// </summary>
        public void RunScopeAutoset(ISCOPE scope)
        {
            scope.ScopeAutosetExecute();
        }

        /// <summary>
        /// Sets the channel vertical offset
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="channel">Which channel</param>
        /// <param name="value">Offset value</param>
        public void SetScopeChannelOffset(ISCOPE scope, string channel, string value)
        {
            scope.SetScopeChannelOffset(channel, value);
        }

        /// <summary>
        /// Set the scope horizontal position
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="position">Desired horizontal position</param>
        public void SetScopeHorizontalPosition(ISCOPE scope, string position)
        {
            scope.SetScopeHorizontalPosition(position);
        }

        /// <summary>
        /// Sets the Scope vertical scale for the given channel
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="channel">Which channel</param>
        /// <param name="scale">Desired scale</param>
        public void SetScopeVerticalScale(ISCOPE scope, string channel, string scale)
        {
            scope.SetScopeVerticalScale(channel, scale);
        }
        #endregion ScopeCommon

        #region CSA Only
        /// <summary>
        /// Sets the CSA autoset type
        /// 
        /// AUTOSet:TYPE
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="type">Autoset type</param>
        public void SetCSAAutosetType(ISCOPE scope, string type)
        {
            scope.SetCSAAutosetType(type);
        }

        /// <summary>
        /// Sets the CSA horizonal scale
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="scale">Desired scale</param>
        public void SetCSAHorizontalMainScale(ISCOPE scope, string scale)
        {
            scope.SetCSAHorizontalMainScale(scale);
        }
        #endregion CSA Only

        #region DPO Only
        /// <summary>
        /// Sets the DPO autoset type
        /// 
        /// AUTOSet
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="type">Autoset type</param>
        public void SetDPOAutosetType(ISCOPE scope, string type)
        {
            scope.SetDPOAutosetType(type);
        }

        /// <summary>
        /// Sets the DPO Channel Termination Impedence Value
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="channel">Which channel</param>
        /// <param name="impedance"></param>
        public void SetDPOCHTermination(ISCOPE scope, string channel, string impedance)
        {
            scope.SetDPOCHTermination(channel, impedance);
        }
        
        /// <summary>
        /// Sets the DPO display persistence
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="type">Persistence type</param>
        public void DPODisplayPersistence(ISCOPE scope, string type)
        {
            scope.SetDPODisplayPersistence(type);
        }
        
        /// <summary>
        /// Sets the DPO horizontal sample rate in samples per seconds
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="rate">Desired rate</param>
        public void SetDPOHorizontalModeSampleRate(ISCOPE scope, string rate)
        {
            scope.SetDPOHorizontalModeSampleRate(rate);
        }

        /// <summary>
        /// Sets the DPO horizontal scale in seconds per division
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="scale">Desired scale</param>
        public void SetDPOHorizontalModeScale(ISCOPE scope, string scale)
        {
            scope.SetDPOHorizontalModeScale(scale);
        }
       
        /// <summary>
        /// Sets the DPO vertical scale for the given reference waveform
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="channel">Which channel</param>
        /// <param name="scale">Desired scale</param>
        public void SetDPORefVerticalScale(ISCOPE scope, string channel, string scale)
        {
            scope.SetDPORefVerticalScale(channel, scale);
        }
        #endregion DPO Only
    }
}
