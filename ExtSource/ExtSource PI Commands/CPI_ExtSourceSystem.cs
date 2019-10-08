//==========================================================================
// CPI_ExtSourceSystem.cs
//==========================================================================

namespace AwgTestFramework
{
    public partial class CPiExtSourceCmds
    {
        #region *CLS
        /// <summary>
        /// Clears error queue of the external source
        /// 
        /// *CLS
        /// </summary>
        public void ExtSrcCLS()
        {
            const string commandLine = "*CLS";
            _mExtSourceVisaSession.Write(commandLine);
        }
        #endregion *CLS

        #region *ESR?
        /// <summary>
        /// Gets Standard Event Status Register
        /// basically means clearing it
        /// 
        /// *ESR?
        /// </summary>
        /// <returns>event status of the external source</returns>
        public string GetExtSrcESRQuery()
        {
            string response;
            _mExtSourceVisaSession.Timeout = 5000; //Make five seconds to prevent timeouts
            const string command = "*ESR?";
            _mExtSourceVisaSession.Query(command, out response);
            if (response == "")
            {
                response = _mExtSourceVisaSession.ErrorDescription;
            }
            return response;
        }
        #endregion *ESR?

        #region *IDN?
        /// <summary>
        /// Gets the id of the external source
        /// 
        /// *IDN?
        /// </summary>
        /// <returns>Id of the external source</returns>
        public string GetExtSrcIDNQuery()
        {
            string response;
            const string command = "*IDN?";
            _mExtSourceVisaSession.Query(command, out response);
            return response;
        }
        #endregion *IDN?

        #region *RST
        /// <summary>
        /// Resets the external source
        /// 
        /// *RST
        /// </summary>
        public void ExtSrcRst()
        {
            const string commandLine = "*RST";
            _mExtSourceVisaSession.Write(commandLine);
        }
        #endregion *RST

        #region *OPC?
        /// <summary>
        /// Waits for the external source to complete
        /// 
        /// *OPC?
        /// </summary>
        /// <param name="timeout">How long to wait for the OPC to return</param>
        /// <returns>OPC result</returns>
        public string GetExtSrcOPCQuery(uint timeout = 15000)
        {
            string response;
            _mExtSourceVisaSession.Timeout = timeout;
            const string commandLine = "*OPC?";
            _mExtSourceVisaSession.Query(commandLine, out response);
            _mExtSourceVisaSession.Timeout = _mDefaultVISATimeout;
            return response;
        }
        #endregion *OPC?

        #region *OPT?
        /// <summary>
        /// Gets the options that are enabled on the external source
        /// 
        /// *OPT?
        /// </summary>
        /// <returns>Options enabled on the ext source</returns>
        public string GetExtSrcOptQuery()
        {
            string response;
            const string commandLine = "*OPT?";
            _mExtSourceVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion *OPT?

        #region ALLev?
        /// <summary>
        /// Gets all the events on the external source
        /// 
        /// ALLEv?
        /// </summary>
        /// <returns>Id of the external source</returns>
        public string GetExtSrcALLEvQuery()
        {
            string response;
            const string command = "ALLEv?";
            _mExtSourceVisaSession.Query(command, out response);
            if (response == "")
            {
                response = _mExtSourceVisaSession.ErrorDescription;
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
        public string GetExtSrcEventQuery()
        {
            string response;
            const string command = "EVENT?";
            _mExtSourceVisaSession.Query(command, out response);
            if (response == "")
            {
                response = _mExtSourceVisaSession.ErrorDescription;
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
        public string GetExtSrcEventMessageQuery()
        {
            string response;
            const string command = "EVMsg?";
            _mExtSourceVisaSession.Query(command, out response);
            if (response == "")
            {
                response = _mExtSourceVisaSession.ErrorDescription;
            }
            return response;
        }
        #endregion EVMsg?
        
        #region FACtory
        /// <summary>
        /// Resets external source to factory default setup
        /// 
        /// FACtory
        /// </summary>
        public void SetExtSrcFactoryDefault()
        {
            const string command = "FACtory";
            _mExtSourceVisaSession.Write(command);
        }
        #endregion FACtory

        #region OUTput[n]:STATe
        /// <summary>
        /// Sets the output state for the specified channel on the external source
        /// 
        /// OUTput[n]:STATe
        /// </summary>
        /// <param name="channel">specified channel to use</param>
        /// <param name="state">ON or OFF value</param>
        public void SetExtSrcOutputState(string channel, string state)
        {
            string commandLine = "OUTput" + channel + ":STATe " + state;
            _mExtSourceVisaSession.Write(commandLine);
        }
        #endregion OUTput[n]:STATe

        #region SYSTem:ERRor?
        /// <summary>
        /// Gets the system error code and message from the external source
        /// 
        /// SYSTem:ERRor?
        /// </summary>
        /// <returns>System error code and message</returns>
        public string GetExtSrcSystemErrorQuery()
        {
            string response;
            const string commandLine = "SYSTem:ERRor?";
            _mExtSourceVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion SYSTem:ERRor?
    }
}
