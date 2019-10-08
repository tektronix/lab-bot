//==========================================================================
// ScopeTriggerGroup.cs
//==========================================================================

using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains helper functions that are called from the Scope Trigger PI step definitions
    /// 
    /// </summary>
    public class ScopeTriggerGroup 
    {
        #region ScopeCommon
        /// <summary>
        /// Gets the trigger state from the Scope
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        public void GetScopeTriggerState(ISCOPE scope)
        {
            scope.GetScopeTriggerState();
        }

        public void TheScopeTriggerStateShouldBe(ISCOPE scope, string state)
        {
            Assert.AreEqual(state, scope.ScopeTriggerState, "Expected trigger state " + state + " did not match scope trigger state: " + scope.ScopeTriggerState);
        }

        public void TheScopeShouldNotDetectWaveform(ISCOPE scope)
        {
            Thread.Sleep(2000); //Wait for the Scope to sort itself out
            GetScopeTriggerState(scope);
            if (scope.ScopeTriggerState == "TRIGGER")
            {
                Assert.Fail("Waveform found when it should have been OFF. Trigger state found was: " + scope.ScopeTriggerState);
            }
        }
        #endregion ScopeCommon

        #region CSA Only
        /// <summary>
        /// Gets the CSA trigger holdoff time
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        public void GetCSATriggerHoldoff(ISCOPE scope)
        {
            scope.GetCSATriggerHoldoff();
        }
        
        /// <summary>
        /// Sets the CSA trigger holdoff time
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="time">Desired trigger holdoff time</param>
        public void SetCSATriggerHoldoff(ISCOPE scope, string time)
        {
            scope.SetCSATriggerHoldoff(time);
        }

        /// <summary>
        /// Compares the CSA trigger holdoff time against the expected value.
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="value">Expected value to compare with Trigger holdoff value</param>
        public void TheCSATriggerHoldoffShouldBe(ISCOPE scope, string value)
        {
            Assert.AreEqual(value, scope.CSATriggerHoldoffTime, "Trigger holdoff value did not match expected value");
        }
        
        /// <summary>
        /// Sets the CSA trigger mode
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="mode">Trigger mode</param>
        public void SetCSATriggerMode(ISCOPE scope, string mode)
        {
            scope.SetCSATriggerMode(mode);
        }

        /// <summary>
        /// Sets the CSA trigger source
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="source">source to trigger off of</param>
        public void SetCSATriggerSource(ISCOPE scope, string source)
        {
            scope.SetCSATriggerSource(source);
        }

        #endregion CSA Only

        #region DPO Only
        /// <summary>
        /// Sets the DPO trigger source at the BNC connector
        /// 
        /// AUXout:SOUrce
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="source">Desired trigger source</param>
        public void SetDPOAUXOutSource(ISCOPE scope, string source)
        {
            scope.SetDPOAUXOutSource(source);
        }
        /// <summary>
        /// Sets the DPO trigger source at the BNC connector
        /// 
        /// AUXout:SOUrce
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="source">Desired trigger source</param>
        public void SetDPOTriggerSourceForTheBNCConnector(ISCOPE scope, string source)
        {
            scope.SetDPOAUXOutSource(source);
        }
        
        /// <summary>Sets the DPO trigger level for all channels
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="setValue">trigger level</param>
        public void SetDPOTriggerLevel(ISCOPE scope, string setValue)
        {
            scope.SetDPOTriggerLevel(setValue);
        }
        
        /// <summary>Sets the DPO trigger level for the specified channel
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="setValue">trigger level</param>
        /// <param name="channel">specified scope channel to use</param>
        public void SetDPOTriggerLevelChannel(ISCOPE scope, string setValue, string channel)
        {
            scope.SetDPOTriggerLevelChannel(setValue, channel);
        }
        
        /// <summary>
        /// Sets the DPO trigger mode
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="mode">Trigger mode</param>
        public void SetDPOTriggerMode(ISCOPE scope, string mode)
        {
            scope.SetDPOTriggerMode(mode);
        }

        /// <summary>
        /// Sets the DPO trigger source 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="source">object to trigger off of</param>
        public void SetDPOTriggerSource(ISCOPE scope, string source)
        {
            scope.SetDPOTriggerSource(source);
        }
        
        /// <summary>
        /// Sets the high and low window thresholds for the trigger
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="high">high limit</param>
        /// <param name="low">low limit</param>
        public void SetDPOTriggerWindow(ISCOPE scope, string high, string low)
        {
            scope.SetDPOTriggerWindow(high, low);
        }

        /// <summary>
        /// Sets the event type for the trigger window 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="eventType">trigger event type</param>
        public void SetDPOTriggerWindowEvent(ISCOPE scope, string eventType)
        {
            scope.SetDPOTriggerWindowEvent(eventType);
        }
        #endregion DPO Only
    }
}
