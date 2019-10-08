//==========================================================================
// SCOPE_TriggerSection.cs
//==========================================================================
namespace AwgTestFramework
{
    public partial class SCOPE
    {
        /// <summary>
        /// Property to contain the Scope response from TRIGger:STATe? query
        /// </summary>
        public string ScopeTriggerState { get; set; }
          
        /// <summary>
        /// Property to contain the CSA response from TRIGger:HOLDoff? query
        /// </summary>
        public string CSATriggerHoldoffTime { get; set; }
        
        
        /// <summary>
        /// Gets the current state of the triggering system
        /// 
        /// uses TRIGger:STATe?
        /// </summary>
        /// <returns>Current State of the triggering system</returns>
        public void GetScopeTriggerState()
        {
            ScopeTriggerState = _pis.ScopeTriggerStateQuery();
        }

        /// <summary>
        /// Sets the CSA trigger holdoff time
        /// 
        /// uses TRIGger:HOLDoff
        /// </summary>
        /// <param name="time">Desired trigger holdoff time</param>
        public void SetCSATriggerHoldoff(string time)
        {
            _pis.CSATriggerHoldoff(time);
        }

        /// <summary>
        /// Gets the CSA trigger holdoff time
        /// 
        /// uses TRIGger:HOLDoff?
        /// </summary>
        public void GetCSATriggerHoldoff()
        {
            CSATriggerHoldoffTime = _pis.CSATriggerHoldoffQuery();
        }

        /// <summary>
        /// Sets the CSA trigger mode
        /// 
        /// uses TRIGger:MODe 
        /// </summary>
        /// <param name="mode">trigger mode type</param>
        public void SetCSATriggerMode(string mode)
        {
            _pis.CSATriggerMode(mode);
        }

        /// <summary>
        /// Sets the CSA trigger source
        /// 
        /// uses TRIGger:SOUrce
        /// </summary>
        /// <param name="source"></param>
        public void SetCSATriggerSource(string source)
        {
            _pis.CSATriggerSource(source);
        }

        /// <summary>
        /// Sets the DPO trigger source at the BNC connector
        /// 
        /// uses AUXout:SOUrce
        /// </summary>
        /// <param name="source">Desired trigger source</param>
        public void SetDPOAUXOutSource(string source)
        {
            _pis.DPOAUXOutSource(source);
        }

        /// <summary>
        /// Sets the source for edge trigger A.
        /// 
        /// TRIGger:A:EDGe:SOUrce
        /// </summary>
        /// <param name="source">Trigger Source</param>
        public void SetDPOTriggerSource(string source)
        {
            _pis.DPOTriggerSource(source);
        }

        /// <summary>
        /// Sets the level for trigger A for all channels
        /// 
        /// TRIGger:A:LEVel
        /// </summary>
        /// <param name="setValue">Numeric value using this format 1.3000E+00 to set the trigger level</param>
        public void SetDPOTriggerLevel(string setValue)
        {
            _pis.DPOTriggerLevel(setValue);
        }

        /// <summary>
        /// Sets the CH[n] trigger level for
        /// TRIGGER:LVLSRCPREFERENCE SRCDEPENDENT mode.
        /// 
        /// TRIGger:A:LEVel:CH[n]
        /// </summary>
        /// <param name="setValue">Sets the mode value {ECL|TTL}</param>
        /// <param name="channel">Scope Channel</param>
        public void SetDPOTriggerLevelChannel(string setValue, string channel)
        {
            _pis.DPOTriggerLevelChannel(setValue, channel);
        }

        /// <summary>
        /// Set the DPO trigger mode
        /// 
        /// TRIGger:A:MODe
        /// </summary>
        /// <param name="mode">Trigger mode</param>
        public void SetDPOTriggerMode(string mode)
        {
            _pis.DPOTriggerMode(mode);
        }

        /// <summary>
        /// Sets the window trigger event. This command is
        /// equivalent to selecting Window Setup from the Trig menu and selecting from
        /// the Window Event box.
        /// 
        /// TRIGger:A:PULse:WINdow:EVENT
        /// </summary>
        /// <param name="eventType"></param>
        public void SetDPOTriggerWindowEvent(string eventType)
        {
            _pis.DPOTriggerWindowEvent(eventType);
        }

        /// <summary>
        /// Sets the upper and lower limits for the pulse window trigger.
        /// 
        /// TRIGger:A:PULse:WINdow:THReshold:HIGH ;LOW
        /// </summary>

        /// <param name="high">upper limit value for the pulse window trigger, format 2.0000E+00</param>
        /// <param name="low">lower limit value for the pulse window trigger, format 50.0000E-03</param>
        public void SetDPOTriggerWindow(string high, string low)
        {
            _pis.DPOTriggerWindow(high, low);
        }
    }
}
