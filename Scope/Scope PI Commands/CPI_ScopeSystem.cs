//==========================================================================
// CPI_ScopeSystem.cs
//==========================================================================

namespace AwgTestFramework
{
    public partial class CPiScopeCmds
    {
        #region ScopeCommon
        #region *CLS
        /// <summary>
        /// Clears error queue of the scope
        /// 
        /// *CLS
        /// </summary>
        public void ScopeCLS()
        {
            const string command = "*CLS";
            _mScopeVisaSession.Write(command);
        }
        #endregion *CLS

        #region *ESR?
        /// <summary>
        /// Gets Standard Event Status Register
        /// basically means clearing it
        /// 
        /// *ESR?
        /// </summary>
        /// <returns>Id of the scope</returns>
        public string ScopeESRQuery()
        {
            string response;
            _mScopeVisaSession.Timeout = 5000; //Make five seconds to prevent timeouts
            const string command = "*ESR?";
            _mScopeVisaSession.Query(command, out response);
            //response = scope.ScopeErrorQueueParser(command, response);
            if (response == "")
            {
                _mScopeVisaSession.Read(out response);
                response = _mScopeVisaSession.ErrorDescription;
            }
            return response;
        }
        #endregion *ESR?

        #region *IDN?
        /// <summary>
        /// Gets the id of the scope
        /// 
        /// *IDN?
        /// </summary>
        /// <returns>Id of the scope</returns>
        public string ScopeIDNQuery()
        {
            string response;
            const string command = "*IDN?";
            _mScopeVisaSession.Query(command, out response);
            return response;
        }
        #endregion *IDN?

        #region *RST
        /// <summary>
        /// Resets scope
        /// 
        /// *RST
        /// </summary>
        public void ScopeReset()
        {
            const string command = "*RST";
            _mScopeVisaSession.Write(command);
        }
        #endregion *RST

        #region *OPC?
        /// <summary>
        /// Waits for the scope to complete
        /// 
        /// *OPC?
        /// </summary>
        /// <param name="timeout">How long to wait for the OPC to return</param>
        /// <returns>OPC result</returns>
        public string ScopeOPCQuery(uint timeout)
        {
            string response;
            _mScopeVisaSession.Timeout = timeout;
            const string command = "*OPC?";
            _mScopeVisaSession.Query(command, out response);
            return response;
        }
        #endregion *OPC?

        #region ALLev?
        /// <summary>
        /// Gets all the events on the scope
        /// 
        /// ALLEv?
        /// </summary>
        /// <returns>Id of the scope</returns>
        public string ScopeALLEvQuery()
        {
            string response;
            const string command = "ALLEv?";
            _mScopeVisaSession.Query(command, out response);
            //response = scope.ScopeErrorQueueParser(command, response);
            if (response == "")
            {
                //_mScopeVisaSession.Read(out response);
                response = _mScopeVisaSession.ErrorDescription;
            }
            return response;
        }
        #endregion ALLev?

        #region EVENT?
        /// <summary>
        /// Gets the current event code the queue
        /// 
        /// EVENT?
        /// </summary>
        /// <returns>Event code</returns>
        public string ScopeEventQuery()
        {
            string response;
            const string command = "EVENT?";
            _mScopeVisaSession.Query(command, out response);
            //response = scope.ScopeErrorQueueParser(command, response);
            if (response == "")
            {
                //_mScopeVisaSession.Read(out response);
                response = _mScopeVisaSession.ErrorDescription;
            }
            return response;
        }
        #endregion EVENT?

        #region EVMsg?
        /// <summary>
        /// Gets the current event code and message on the queue
        /// 
        /// EVMsg?
        /// </summary>
        /// <returns>Event code and message</returns>
        public string ScopeEventMessageQuery()
        {
            string response;
            const string command = "EVMsg?";
            _mScopeVisaSession.Query(command, out response);
            //response = scope.ScopeErrorQueueParser(command, response);
            if (response == "")
            {
                //_mScopeVisaSession.Read(out response);
                response = _mScopeVisaSession.ErrorDescription;
            }
            return response;
        }
        #endregion EVMsg?
        
        #region FACtory
        /// <summary>
        /// Resets scope to factory default setup
        /// 
        /// FACtory
        /// </summary>
        public void ScopeFactoryDefault()
        {
            const string command = "FACtory";
            _mScopeVisaSession.Write(command);
        }
        #endregion FACtory

        #region RECAll:SETUp
        /// <summary>
        /// Loads a setup file onto the scope
        /// 
        /// RECAll:SETUp
        /// </summary>
        /// <param name="filepath">Setup filepath</param>
        public void ScopeRecallSetup(string filepath)
        {
            filepath = '"' + filepath + '"';
            const string command = "RECAll:SETUp ";
            _mScopeVisaSession.Write(command + filepath);
        }
        #endregion RECAll:SETUp

        #region SELect:CH
        /// <summary>
        /// Sets the Channel state [OFF|ON] for the desired Channel
        /// 
        /// SELect:CH[n] 
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="state">Desired channel state</param>
        public void ScopeSelectChannelState(string channel, string state)
        {
            string command = "SELect:CH" + channel + " " + state;
            _mScopeVisaSession.Write(command);
        }
        #endregion SELect:CH

        #region SYSTem:ERRor?
        /// <summary>
        /// Gets the system error code and message from the scope
        /// 
        /// SYSTem:ERRor?
        /// </summary>
        /// <returns>System error code and message</returns>
        public string GetScopeSystemErrorQuery()
        {
            string response;
            const string commandLine = "SYSTem:ERRor?";
            _mScopeVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion SYSTem:ERRor?
        #endregion ScopeCommon

        #region CSA Only

        #endregion CSA Only

        #region DPO Only

        #endregion DPO Only
    }
}
