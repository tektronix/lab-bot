//==========================================================================
// ScopeSystemGroup.cs
//==========================================================================
using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains helper functions that are called from the Scope System PI step definitions
    /// 
    /// </summary>
    public class ScopeSystemGroup 
    {
        #region ScopeCommon
        /// <summary>
        /// Clears error queue of the scope
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        public void RunScopeCLS(ISCOPE scope)
        {
            scope.ScopeCLSExecute();
        }

        /// <summary>
        /// Gets all the events on the scope
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        public void GetScopeALLEvResponse(ISCOPE scope)
        {
            scope.GetScopeALLEvResponse();
        }

        /// <summary>
        /// Gets Standard Event Status Register
        /// basically means clearing it
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        public void GetScopeESRResponse(ISCOPE scope)
        {
            scope.GetScopeESR();
        }

        /// <summary>
        /// Gets the current event code the queue
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <returns>Event code</returns>
        public void GetScopeEventResponse(ISCOPE scope)
        {
            scope.GetScopeEvent();
        }
        
        /// <summary>
        /// Gets the current event code and message on the queue
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        public void GetScopeEventMessage(ISCOPE scope)
        {
            scope.GetScopeEventMessage();
        }
        
        /// <summary>
        /// Resets scope to factory default setup
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        public void RunScopeFactoryDefault(ISCOPE scope)
        {
            scope.ScopeFactoryDefaultExecute();
        }
        
        /// <summary>
        /// Gets the id of the scope
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        public void GetScopeIDNResponse(ISCOPE scope)
        {
            try
            {
                scope.GetScopeIDN();
            }
            catch (Exception)
            {
                Assert.Inconclusive("No Scope Found.  IDN Query Returned:  " + scope.ScopeIDNResponse);
                //Catch thrown exception from ID step
            }
            scope.ScopeResetExecute();
            scope.ScopeCLSExecute(); 
        }

        public void CheckScopeFamilyType(ISCOPE scope, string scopeType)
        {
            Assert.AreEqual(scopeType, scope.ScopeFamilyType, "Scope Found was a " + scope.ScopeFamilyType + ".  Expected a " + scopeType + " Scope");
        }

        /// <summary>
        /// Waits for the scope to complete
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="timeout">How long to wait for the OPC to return</param>
        public void GetScopeOPCResponse(ISCOPE scope, uint timeout)
        {
            scope.GetScopeOPCResponse(timeout);
        }

        public void WaitForScopeToCompleteBeforeTimeout(ISCOPE scope, uint timeout = 15000)
        {
            scope.GetScopeOPCResponse(timeout);
        }
        
        /// <summary>
        /// Loads a setup file onto the scope
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="filepath">Setup filepath</param>
        public void RunScopeRecallSetup(ISCOPE scope, string filepath)
        {
            scope.ScopeRecallSetupExecute(filepath);
        }

        /// <summary>
        /// Resets the scope
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        public void RunScopeReset(ISCOPE scope)
        {
            scope.ScopeResetExecute();
        }

        /// <summary>
        /// Gets the system error code and message from the external source
        /// 
        /// SYSTem:ERRor?
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <returns>System error code and message</returns>
        public void GetScopeSystemErrorQuery(ISCOPE scope)
        {
            scope.GetScopeSystemError();
        }

        /// <summary>
        /// Checks to verify that no system error has occured on the scope
        /// 
        /// SYSTem:ERRor?
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <returns>System error code and message</returns>
        public void TheScopeShouldHaveNoErrors(ISCOPE scope)
        {
            scope.GetScopeSystemError();
            Regex responseRegex = new Regex("\"Queue empty - No events to report\"");
            Match m = responseRegex.Match(scope.ScopeSystemErrorResponse);
            Assert.IsTrue(m.Success, "An unexpected value: " + scope.ScopeSystemErrorResponse+ " was returned from SYST:ERR?");
        }

        /// <summary>
        /// Sets the channel state for the selected channel
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="channel">Which channel</param>
        /// <param name="state">Desired channel state</param>
        public void SetScopeSelectChannelState(ISCOPE scope, string channel, string state)
        {
            scope.SetScopeSelectChannelState(channel, state);
        }
        #endregion ScopeCommon

        #region CSA Only
        #endregion CSA Only

        #region DPO Only
        #endregion DPO Only
    }
}
