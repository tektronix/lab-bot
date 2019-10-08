//==========================================================================
// SCOPE_SystemSection.cs
//==========================================================================
namespace AwgTestFramework
{
    public partial class SCOPE
    {
        /// <summary>
        /// Property to contain the Standard Event Status Register response from *ESR? query
        /// </summary>
        public string ScopeESRData { get; set; }
        
        /// <summary>
        /// Property to contain the Device response from *IDN? query
        /// </summary>
        public string ScopeIDNResponse { get; set; }
        
        /// <summary>
        /// Property to contain the Device response from *OPC? query
        /// </summary>
        public string ScopeOPCResponse { get; set; }
        
         /// <summary>
        /// Property to contain the Device response from ALLEv? query
        /// </summary>
        public string ScopeALLEvResponse { get; set; }

        /// <summary>
        /// Property to contain the Device response from EVENT? query
        /// </summary>
        public string ScopeEventCurrent { get; set; }
        
        /// <summary>
        /// Property to contain the Device response from EVMsg? query
        /// </summary>
        public string ScopeEventMessageCurrent { get; set; }

        /// <summary>
        /// Property to contain the Device response from SYST:ERR? query
        /// </summary>
        public string ScopeSystemErrorResponse { get; set; }

        /// <summary>
        /// Clears error queue of the scope
        /// 
        /// uses *CLS
        /// </summary>
        public void ScopeCLSExecute()
        {
            _pis.ScopeCLS();
        }

        /// <summary>
        /// Gets Standard Event Status Register
        /// basically means clearing it
        /// 
        /// uses *ESR?
        /// </summary>
        /// <returns>Id of the scope</returns>
        public void GetScopeESR()
        {
            ScopeESRData = _pis.ScopeESRQuery();
        }
        
        /// <summary>
        /// Gets the id of the scope
        /// 
        /// uses *IDN?
        /// </summary>
        /// <returns>Id of the scope</returns>
        public void GetScopeIDN()
        {
            ScopeIDNResponse = _pis.ScopeIDNQuery();
            GetScopeInformation(ScopeIDNResponse);
        }

        /// <summary>
        /// Executes a scope reset
        /// 
        /// uses *RST
        /// </summary>
        public void ScopeResetExecute()
        {
            _pis.ScopeReset();
        }
 
        /// <summary>
        ///  Gets *OPC Query response
        /// 
        /// uses *OPC?
        /// </summary>
        /// <param name="timeout">How long to wait for the OPC to return</param>
        /// <returns>OPC result</returns>
        public void GetScopeOPCResponse(uint timeout)
        {
            ScopeOPCResponse = _pis.ScopeOPCQuery(timeout);
        }

        /// <summary>
        /// Gets all the events on the scope
        /// 
        /// uses ALLEv?
        /// </summary>
        /// <returns>Event log</returns>
        public void GetScopeALLEvResponse()
        {
            ScopeALLEvResponse = _pis.ScopeALLEvQuery();
        }

        /// <summary>
        /// Gets the current event code the queue
        /// 
        /// uses EVENT?
        /// </summary>
        /// <returns>Event code</returns>
        public void GetScopeEvent()
        {
            ScopeEventCurrent = _pis.ScopeEventQuery();
        }

        /// <summary>
        /// Gets the current event code and message on the queue
        /// 
        /// uses EVMsg?
        /// </summary>
        /// <returns>Event code and message</returns>
        public void GetScopeEventMessage()
        {
            ScopeEventMessageCurrent = _pis.ScopeEventMessageQuery();
        }

        /// <summary>
        /// Executes a reset to factory default setup on the scope
        /// 
        /// uses FACtory
        /// </summary>
        public void ScopeFactoryDefaultExecute()
        {
            _pis.ScopeFactoryDefault();
        }

        /// <summary>
        /// Loads a setup file onto the scope
        /// 
        /// uses RECAll:SETUp
        /// </summary>
        /// <param name="filepath">Setup filepath</param>
        public void ScopeRecallSetupExecute(string filepath)
        {
            _pis.ScopeRecallSetup(filepath);
        }

        /// <summary>
        /// Sets the Channel state [OFF|ON] for the desired Channel
        /// 
        /// uses SELect:CH[n] 
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="state">Desired channel state</param>
        public void SetScopeSelectChannelState(string channel, string state)
        {
            _pis.ScopeSelectChannelState(channel, state);
        }

        /// <summary>
        /// Gets the system error code and message from the scope
        /// 
        /// SYSTem:ERRor?
        /// </summary>
        /// <returns>System error code and message</returns>
        public void GetScopeSystemError()
        {
            ScopeSystemErrorResponse = _pis.GetScopeSystemErrorQuery();
        }
    }
}
