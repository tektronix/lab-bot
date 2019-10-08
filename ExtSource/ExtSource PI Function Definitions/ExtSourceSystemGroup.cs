//==========================================================================
// ExtSourceSystemGroup.cs
//==========================================================================

using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains helper functions that are called from the External Source System PI step definitions
    /// 
    /// </summary>
    public class ExtSourceSystemGroup
    {
        private readonly UTILS utils = new UTILS();

        #region *CLS
        /// <summary>
        /// Clears error queue of the external source
        /// 
        /// *CLS
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        public void ExtSrcCLS(IEXTSOURCE extSource)
        {
            extSource.ExtSrcCLS();
        }
        #endregion *CLS

        #region *ESR?
        /// <summary>
        /// Gets Standard Event Status Register
        /// basically means clearing it
        /// 
        /// *ESR?
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <returns>event status of the external source</returns>
        public void GetExtSrcESRQuery(IEXTSOURCE extSource)
        {
            extSource.GetExtSrcESRQuery();
        }
        #endregion *ESR?

        #region *IDN?
        /// <summary>
        /// Gets the id of the external source
        /// 
        /// *IDN?
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <returns>Id of the external source</returns>
        public void GetExtSrcIDNQuery(IEXTSOURCE extSource)
        {
            
            bool found = false;
            const int timesToFind = 3;
            for (int n = 0; n <= timesToFind; n++)//Giving the external source a certain number of tries to get the right response
            {
                extSource.GetExtSrcIDNQuery(); //
                found = utils.GetExtSourceIDInformation(extSource.ExtSrcIDResponse); //Parsing ExtSourceID returns a bool  
                if (found) //If returns true, valid id so a ExtSource is talking back!
                    break;
                Thread.Sleep(1000);
            }
            if (!found) //External source still won't talk back
            {
                Assert.Inconclusive("No External Source Found. ID Response returned " + extSource.ExtSrcIDResponse);
            }
        }
        #endregion *IDN?

        #region *RST
        /// <summary>
        /// Resets the external source
        /// 
        /// *RST
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        public void ExtSrcRst(IEXTSOURCE extSource)
        {
            extSource.ExtSrcRst();
        }
        #endregion *RST

        #region *OPC?
        /// <summary>
        /// Waits for the external source to complete using default timeout(15 seconds)
        /// 
        /// *OPC?
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <returns>OPC result</returns>
        public void WaitForExternalSource(IEXTSOURCE extSource)
        {
            extSource.GetExtSrcOPCQuery();
            Assert.AreEqual("1", extSource.ExtSrcOPC, "*OPC? query failed! Error was: " + extSource.ExtSrcOPC);
        }

        /// <summary>
        /// Waits for the external source to complete in a matter of seconds
        /// 
        /// *OPC?
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <param name="timeLimit">How long to wait for the OPC to return</param>
        /// <returns>OPC result</returns>
        public void WaitForTimelimitExternalSource(IEXTSOURCE extSource, string timeLimit)
        {
            uint seconds = uint.Parse(timeLimit);
            uint timeout = seconds * 1000; // Convert to milliseconds
            extSource.GetExtSrcOPCQuery(timeout);
            Assert.AreEqual("1", extSource.ExtSrcOPC, "*OPC? query failed! Error was: " + extSource.ExtSrcOPC);
        }
        #endregion *OPC?

        #region *OPT?
        /// <summary>
        /// Gets the options that are enabled on the external source
        /// 
        /// *OPT?
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <returns>Options enabled on the ext source</returns>
        public void GetExtSrcOptQuery(IEXTSOURCE extSource)
        {
            extSource.GetExtSrcOptQuery();
        }

        /// <summary>
        /// Gets and compares the options that are enabled versus an expected valueon the external source
        /// 
        /// *OPT?
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <param name="expectedOptions">Expected Options enabled on the ext source</param>
        public void TheExtSrcOptionsShouldBe(IEXTSOURCE extSource, string expectedOptions)
        {
            extSource.GetExtSrcOptQuery();
            Assert.AreEqual(expectedOptions, extSource.ExtSrcOptions);
        }
        #endregion *OPT?

        #region ALLev?
        /// <summary>
        /// Gets all the events on the external source
        /// 
        /// ALLEv?
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <returns>Id of the external source</returns>
        public void GetExtSrcALLEvQuery(IEXTSOURCE extSource)
        {
            extSource.GetExtSrcALLEvQuery();
        }
        #endregion ALLev?

        #region EVENT?
        /// <summary>
        /// Gets the current event code the queue
        /// 
        /// EVENT?
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <returns>Event code</returns>
        public void GetExtSrcEventQuery(IEXTSOURCE extSource)
        {
            extSource.GetExtSrcEventQuery();
        }
        #endregion EVENT?

        #region EVMsg?
        /// <summary>
        /// Gets the current event code and message on the queue
        /// 
        /// EVMsg?
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <returns>Event code and message</returns>
        public void GetExtSrcEventMessageQuery(IEXTSOURCE extSource)
        {
            extSource.GetExtSrcEventMessageQuery();
        }
        #endregion EVMsg?

        #region FACtory
        /// <summary>
        /// Resets external source to factory default setup
        /// 
        /// FACtory
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        public void SetExtSrcFactoryDefault(IEXTSOURCE extSource)
        {
            extSource.SetExtSrcFactoryDefault();
        }
        #endregion FACtory

        #region OUTput[n]:STATe
        /// <summary>
        /// Sets the output state for the specified channel on the external source
        /// 
        /// OUTput[n]:STATe
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <param name="channel">specified channel to use</param>
        /// <param name="state">ON or OFF value</param>
        public void SetExtSrcOutputState(IEXTSOURCE extSource, string channel, string state)
        {
            extSource.SetExtSrcOutputState(channel,state);
        }
        #endregion OUTput[n]:STATe

        #region SYSTem:ERRor?
        /// <summary>
        /// Gets the system error code and message from the external source
        /// 
        /// SYSTem:ERRor?
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <returns>System error code and message</returns>
        public void GetExtSrcSystemErrorQuery(IEXTSOURCE extSource)
        {
            extSource.GetExtSrcSystemErrorQuery();
        }

        /// <summary>
        /// Checks to verify that no system error has occured on the external source
        /// 
        /// SYSTem:ERRor?
        /// </summary>
        /// <param name="extSource">the EXTSOURCE object</param>
        /// <returns>System error code and message</returns>
        public void TheExtSrcShouldHaveNoErrors(IEXTSOURCE extSource)
        {
            extSource.GetExtSrcSystemErrorQuery();
            Regex responseRegex = new Regex("^0,\"No error\"$");
            Match m = responseRegex.Match(extSource.ExtSrcSystemError);
            Assert.IsTrue(m.Success, "An unexpected value:" + extSource.ExtSrcSystemError + " was returned from SYST:ERR?");
        }
        #endregion SYSTem:ERRor?
    }
}
