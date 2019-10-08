//==========================================================================
// EXTSOURCE_SystemSection.cs
//==========================================================================

namespace AwgTestFramework
{
    public partial class EXTSOURCE
    {
        /// <summary>
        /// Property to contain the External Source response from *ESR?
        /// </summary>
        public string ExtSrcESR { get; set; }

        /// <summary>
        /// Property to contain the External Source response from *IDN?
        /// </summary>
        public string ExtSrcIDResponse { get; set; }

        /// <summary>
        /// Property to contain the External Source response from *OPC?
        /// </summary>
        public string ExtSrcOPC { get; set; }

        /// <summary>
        /// Property to contain the External Source response from *OPT?
        /// </summary>
        public string ExtSrcOptions { get; set; }

        /// <summary>
        /// Property to contain the External Source response from ALLEv?
        /// </summary>
        public string ExtSrcAllEvents { get; set; }

        /// <summary>
        /// Property to contain the External Source response from EVENT?
        /// </summary>
        public string ExtSrcEvent { get; set; }

        /// <summary>
        /// Property to contain the External Source response from EVMsg?
        /// </summary>
        public string ExtSrcEventMessage { get; set; }

        /// <summary>
        /// Property to contain the External Source response from SYSTem:ERRor?
        /// </summary>
        public string ExtSrcSystemError { get; set; }


        /// <summary>
        /// Clears error queue of the external source
        /// 
        /// *CLS
        /// </summary>
        public void ExtSrcCLS()
        {
            _piex.ExtSrcCLS();
        }

        /// <summary>
        /// Gets Standard Event Status Register
        /// basically means clearing it
        /// 
        /// *ESR?
        /// </summary>
        /// <returns>event status of the external source</returns>
        public void GetExtSrcESRQuery()
        {
            ExtSrcESR = _piex.GetExtSrcESRQuery();
        }

        /// <summary>
        /// Gets the id of the external source
        /// 
        /// *IDN?
        /// </summary>
        /// <returns>Id of the external source</returns>
        public void GetExtSrcIDNQuery()
        {
            ExtSrcIDResponse = _piex.GetExtSrcIDNQuery();
        }

        /// <summary>
        /// Resets the external source
        /// 
        /// *RST
        /// </summary>
        public void ExtSrcRst()
        {
            _piex.ExtSrcRst();
        }

        /// <summary>
        /// Waits for the external source to complete
        /// 
        /// *OPC?
        /// </summary>
        /// <param name="timeout">How long to wait for the OPC to return</param>
        /// <returns>OPC result</returns>
        public void GetExtSrcOPCQuery(uint timeout = 15000)
        {
            ExtSrcOPC = _piex.GetExtSrcOPCQuery();
        }

        /// <summary>
        /// Gets the options that are enabled on the external source
        /// 
        /// *OPT?
        /// </summary>
        /// <returns>Options enabled on the ext source</returns>
        public void GetExtSrcOptQuery()
        {
            ExtSrcOptions = _piex.GetExtSrcOptQuery();
        }

        /// <summary>
        /// Gets all the events on the external source
        /// 
        /// ALLEv?
        /// </summary>
        /// <returns>Id of the external source</returns>
        public void GetExtSrcALLEvQuery()
        {
            ExtSrcAllEvents = _piex.GetExtSrcALLEvQuery();
        }

        /// <summary>
        /// Gets the current event code the queue
        /// 
        /// EVENT?
        /// </summary>
        /// <returns>Event code</returns>
        public void GetExtSrcEventQuery()
        {
            ExtSrcEvent = _piex.GetExtSrcEventQuery();
        }

        /// <summary>
        /// Gets the current event code and message on the queue
        /// 
        /// EVMsg?
        /// </summary>
        /// <returns>Event code and message</returns>
        public void GetExtSrcEventMessageQuery()
        {
            ExtSrcEventMessage = _piex.GetExtSrcEventMessageQuery();
        }

        /// <summary>
        /// Resets external source to factory default setup
        /// 
        /// FACtory
        /// </summary>
        public void SetExtSrcFactoryDefault()
        {
            _piex.SetExtSrcFactoryDefault();
        }
 
        /// <summary>
        /// Sets the output state for the specified channel on the external source
        /// 
        /// OUTput[n]:STATe
        /// </summary>
        /// <param name="channel">specified channel to use</param>
        /// <param name="state">ON or OFF value</param>
        public void SetExtSrcOutputState(string channel, string state)
        {
            _piex.SetExtSrcOutputState(channel, state);
        }

        /// <summary>
        /// Gets the system error code and message from the external source
        /// 
        /// SYSTem:ERRor?
        /// </summary>
        /// <returns>System error code and message</returns>
        public void GetExtSrcSystemErrorQuery()
        {
            ExtSrcSystemError = _piex.GetExtSrcSystemErrorQuery();
        }
    }
}
