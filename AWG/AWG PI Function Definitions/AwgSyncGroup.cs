//==========================================================================
// AwgSyncGroup.cs
//==========================================================================

using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using System;
using System.Threading;
using System.Diagnostics;

namespace AwgTestFramework 
{
    /// <summary>
    /// This class contains helper functions that are called from the %AWG Synce PI step definitions.
    /// This class has no restrictions as to where it will be used.
    /// 
    /// This "Helper" group does everything else but steps and TekVISA.
    /// Using parameters from the step, each helper will makes decisions
    /// such as send commands, or process responses from queries and
    /// do testing and generate asserts if necessary.
    /// 
    /// \ingroup grouphelperpi pisteps 
    /// 
    /// </summary>
    public class AwgSyncGroup 
    {       
        // glennj 06/03/2013
        /// <summary>
        /// Ensures that the last overlapped command is complete.<para></para>
        /// Unless there was a timeout, the query by definition always<para>
        /// returns a "1".</para>
        /// </summary>
        /// <param name="awg">Works on a specific AWG object</param>
        /// <param name="timeout">Optional timeout value (ms)</param>
        /// <returns>Integer "1" value when pending operations are complete</returns>
        public void AwgOperationCompleteQuery(IAWG awg, uint timeout = 90000)
        {
            awg.SessionTimeout = timeout;
          
            string response = awg.OpcQuery();
            string status = awg.ErrorDescription();

            //See if the status string contains the word "success"
            Regex validatePreMatcher = new Regex(@"Success.+");
            Match match = validatePreMatcher.Match(status);

            //TODO: PWH This is admittedly a bit sloppy - I'd rather abstract this into a function to validate an OPC result and specify the sleep interval
            // Check the status string to see if the operation was sucessful
            if (!match.Success)
            {
                //This warning will show up in the SpecFlow test log
                string possibleErrorString = "WARNING: Initial *OPC? failed with timeout of " + timeout.ToString(CultureInfo.InvariantCulture) + "! " + status + ". Try again in 5 seconds to try to recover...";
                Console.WriteLine(possibleErrorString);                
                Thread.Sleep(5000);
                
                //Reset the VISA timeout to desired value and try again
                awg.SessionTimeout = timeout; 
                string response2 = awg.OpcQuery();
                string status2 = awg.ErrorDescription();

                //Again see if the status string contains the word "Success"
                Regex validatePreMatcher2 = new Regex(@"Success.+");
                Match match2 = validatePreMatcher2.Match(status2);
                if (!match2.Success)
                {
                    Assert.Fail("*OPC? failed on second attempt! " + status2);
                }
            }

            //reset the timeout to it's default value
            awg.SessionTimeout = awg.DefaultVisaTimeout; // Reset timeout to default specified in AWG.cs             
        }

        private const int Major = 0;
        private const int Minor = 1;
        private const int Version = 2;

        //glennj 12/12/2013
        /// <summary>
        /// Only do a *OPC? if the version is less than the current AWG notion of version.
        /// </summary>
        /// <param name="majorMinorVersion">Major[.Minor[.Version]]</param>
        /// <param name="awg">object</param>
        public void WaitForOperationCompleteForEarlierVersions(IAWG awg, string majorMinorVersion)
        {
            string[] field = majorMinorVersion.Split(new[] { '.' });

            bool executeOpc = false;

            // Only change behavior if version number is supplied
            if (field.Length > Major)
            {
                // Test the major
                if ((Convert.ToInt32(field[Major])) > (Convert.ToInt32(awg.AppVersionMajor)))
                {
                    executeOpc = true;
                }
                else if ((Convert.ToInt32(field[Major])) == (Convert.ToInt32(awg.AppVersionMajor)))
                {
                    // If there a minor
                     if (field.Length > Minor)
                    {
                        // Test the minor
                        if ((Convert.ToInt32(field[Minor])) > (Convert.ToInt32(awg.AppVersionMinor)))
                        {
                            executeOpc = true;
                        }
                        else if ((Convert.ToInt32(field[Minor])) == (Convert.ToInt32(awg.AppVersionMinor)))
                        {
                            // If there a version
                             if (field.Length > Version)
                            {
                                // Test the minor
                                if ((Convert.ToInt32(field[Version])) > (Convert.ToInt32(awg.AppVersionVersion)))
                                {
                                    executeOpc = true;
                                }
                            }
                        }
                    }
                }
            }

            // If version number provide is less than the version number of the AWG object
            // then do the normal expected *OPC?
            if (executeOpc)
            {
                AwgOperationCompleteQuery(awg);
            }
        }

        //glennj 06/07/2013
        /// <summary>
        /// Sets the Operation Complete when the last overlapped command is complete.
        /// </summary>
        /// <param name="index">%AWG index number (this is zero based, not to be confused with AWG number)</param>
        public void AwgOperationCompleteCommand(IAWG awg)
        {
            awg.OpcCommand();             
        }

        //glennj 06/07/2013
        /// <summary>
        /// Blocks the %AWG from executing further commands until the overlapped command is finished.
        /// </summary>
        /// <param name="index">awg object</param>
        public void AwgWait(IAWG awg)
        { 
            awg.WaiCommand();                                       // *WAI
        }

        public void AwgWaitForOperationComplete(IAWG awg, uint value, string intervalType)
        {
            int timeout;
            bool opcOccurred = false;
            if (intervalType == "minutes")
            {
                timeout = ((int)value * 60000);
            }

            else
            {
                timeout = ((int)value * 1000);
            }

            awg.OpcCommand();           // Issue the *OPC command

            int delayBetweenPolls = 1000;  // or 1 sec

            do
            {
                timeout -= delayBetweenPolls;       // Poll every second
                Thread.Sleep(delayBetweenPolls);
                string response = awg.GetESR();   // AwgStandardEventStatusRegisterQuery(awg);
                if (response != null)
                {
                    uint esr = 0;
                    try
                    {
                        esr = Convert.ToUInt32(response);
                        // Test for bit 0 being set to indicate OPC has ocurred
                        if ((esr & 0x1) == 0x1)
                        {
                            opcOccurred = true;
                        }
                    }
                    catch
                    {
                        // Apparently it is not a valid string for converstion.  Now what?
                    }
                }
            } while ((timeout > 0) && (!opcOccurred));

            Assert.IsTrue(opcOccurred, "Timed out of " + value.ToString() + " " + intervalType + " while polling *ESR for Operation Complete");
        }
    }
}