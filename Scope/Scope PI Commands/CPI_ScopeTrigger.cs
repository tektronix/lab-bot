//==========================================================================
// CPI_ScopeTrigger.cs
//==========================================================================

namespace AwgTestFramework
{
    public partial class CPiScopeCmds
    {
        #region ScopeCommon
        #region TRIGger:STATe?
        /// <summary>
        /// This query-only command returns the current state of the triggering system
        /// 
        /// TRIGger:STATe?
        /// </summary>
        /// <returns>Current State of the triggering system</returns>
        public string ScopeTriggerStateQuery()
        {
            string response;
            const string command = "TRIGger:STATe?";
            _mScopeVisaSession.Query(command, out response);
            //response = scope.ScopeErrorQueueParser(command, response);
            if (response == "")
            {
                _mScopeVisaSession.Read(out response);
                response = _mScopeVisaSession.ErrorDescription;
            }
            return response;
        }
        #endregion TRIGger:STATe?
        #endregion ScopeCommon

        #region CSA Only
        #region TRIGger:HOLDoff
        /// <summary>
        /// Sets the CSA trigger holdoff time
        /// 
        /// TRIGger:HOLDoff
        /// </summary>
        /// <param name="time">Desired trigger holdoff time</param>
        public void CSATriggerHoldoff(string time)
        {
            const string command = "TRIGger:HOLDoff ";
            _mScopeVisaSession.Write(command + time);
        }
        #endregion TRIGger:HOLDoff

        #region TRIGger:HOLDoff?
        /// <summary>
        /// Gets the CSA trigger holdoff time
        /// 
        /// TRIGger:HOLDoff?
        /// </summary>
        public string CSATriggerHoldoffQuery()
        {
            const string command = "TRIGger:HOLDoff?";
            string response;
            _mScopeVisaSession.Query(command, out response);
            //response = scope.ScopeErrorQueueParser(command, response);
            if (response == "")
            {
                //_mScopeVisaSession.Read(out response);
                response = _mScopeVisaSession.ErrorDescription;
            }
            return response;
        }
        #endregion TRIGger:HOLDoff?

        #region TRIGger:MODe
        /// <summary>
        /// Sets the CSA Trigger Mode 
        /// 
        /// TRIGger:MODe
        /// </summary>
        /// <param name="mode"></param>
        public void CSATriggerMode(string mode)
        {
            const string command = "TRIGger:MODe ";
            _mScopeVisaSession.Write(command + mode);
        }
        #endregion TRIGger:MODe

        #region TRIGger:SOUrce
        /// <summary>
        /// TRIGger:SOUrce
        /// </summary>
        /// <param name="source"></param>
        public void CSATriggerSource(string source)
        {
            const string command = "TRIGger:SOUrce ";
            _mScopeVisaSession.Write(command + source);
        }
        #endregion TRIGger:SOUrce
        #endregion CSA Only

        #region DPO Only
        #region AUXout:SOUrce
        /// <summary>
        /// Sets the DPO trigger source at the BNC connector
        /// 
        /// AUXout:SOUrce
        /// </summary>
        /// <param name="source">Desired trigger source</param>
        public void DPOAUXOutSource(string source)
        {
            const string command = "AUXout:SOUrce ";
            _mScopeVisaSession.Write(command + source);
        }
        #endregion AUXout:SOUrce

        #region TRIGger:A:EDGe:SOUrce
        /// <summary>
        /// This command sets the source for the edge trigger
        /// 
        /// TRIGger:A:EDGe:SOUrce
        /// </summary>
        /// <param name="source">Trigger Source</param>
        public void DPOTriggerSource(string source)
        {
            const string command = "TRIGger:A:EDGe:SOUrce ";
            _mScopeVisaSession.Write(command + source);
        }
        #endregion TRIGger:A:EDGe:SOUrce

        #region TRIGger:A:LEVel
        /// <summary>
        /// This command sets the level for trigger A for all channels
        /// 
        /// TRIGger:A:LEVel
        /// </summary>
        /// <param name="setValue">Numeric value using this format 1.3000E+00 to set the trigger level</param>
        public void DPOTriggerLevel(string setValue)
        {
            const string command = "TRIGger:A:LEVel ";
            _mScopeVisaSession.Write(command + setValue);
        }
        #endregion TRIGger:A:LEVel

        #region TRIGger:A:LEVel:CH
        /// <summary>
        /// This command sets the CH[n] trigger level for
        /// TRIGGER:LVLSRCPREFERENCE SRCDEPENDENT mode.
        /// 
        /// TRIGger:A:LEVel:CH[n]
        /// </summary>
        /// <param name="setValue">Sets the mode value {ECL|TTL}</param>
        /// <param name="channel">Scope Channel</param>
        public void DPOTriggerLevelChannel(string setValue, string channel)
        {
            string command = "TRIGger:A:LEVel:CH" + channel + " ";
            _mScopeVisaSession.Write(command + setValue);
        }
        #endregion TRIGger:A:LEVel:CH

        #region TRIGger:A:MODe
        /// <summary>
        /// Set the DPO trigger mode
        /// 
        /// TRIGger:A:MODe
        /// </summary>
        /// <param name="mode">Trigger mode</param>
        public void DPOTriggerMode(string mode)
        {
            const string command = "TRIGger:A:MODe ";
            _mScopeVisaSession.Write(command + mode);
        }
        #endregion TRIGger:A:MODe

        #region TRIGger:A:PULse:WINdow:EVENT
        /// <summary>
        /// This command sets or queries the window trigger event. This command is
        /// equivalent to selecting Window Setup from the Trig menu and selecting from
        /// the Window Event box.
        /// 
        /// TRIGger:A:PULse:WINdow:EVENT
        /// </summary>
        /// <param name="eventType"></param>
        public void DPOTriggerWindowEvent(string eventType)
        {
            string command = "TRIGger:A:PULse:WINdow:EVENT " + eventType;
            _mScopeVisaSession.Write(command);
        }
        #endregion TRIGger:A:PULse:WINdow:EVENT

        #region TRIGger:A:PULse:WINdow:THReshold:
        /// <summary>
        /// This command sets the upper and lower limits for the pulse window trigger.
        /// 
        /// TRIGger:A:PULse:WINdow:THReshold:HIGH ;LOW
        /// </summary>

        /// <param name="high">upper limit value for the pulse window trigger, format 2.0000E+00</param>
        /// <param name="low">lower limit value for the pulse window trigger, format 50.0000E-03</param>
        public void DPOTriggerWindow(string high, string low)
        {
            string command = "TRIGger:A:PULse:WINdow:THReshold:HIGH " + high + ";LOW " + low;
            _mScopeVisaSession.Write(command);
        }
        #endregion TRIGger:A:PULse:WINdow:THReshold:
        #endregion DPO Only
    }
}
