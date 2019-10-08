 //==========================================================================
// AwgSyncGroupLow_steps.cs
// This file contains the PI step definitions for the AWG PI Sync Group commands 
//
// Low-level steps set and get the values for commands, and test the raw values as returned from the 
// instrument. They DO NOT interpret values in any way! Interpretation, normalization, etc. need to 
// occur in the High-level step definitions. Notice the use of the word "value" in the steps - this 
// usually implies that the query returns a 0 or 1 or abbreviated text value (like SOFT) that should 
// be interpreted as ON or OFF or SOFTWARE to make the step more user-friendly. We do that in the 
// High-order step definitions.
// 
// PLEASE use the following regular expressions to match specified numeric formats and other values:
// <NR1> - ((?<!\S)[-+]?\d+(?!\S))
// <NR3> - ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?)
// AWG number -  AWG([1-4])? -OR -
//            -  (?: the)? AWG([1-4])? (depends on language usage)
// File path strings - ""(.+)"" used when you want the string that is delimited by the quotes File path strings
//                        
//==========================================================================

using System;
using TechTalk.SpecFlow;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains the PI step definitions for the %AWG PI Sync Group commands 

    /// Generally the steps are set, get and should be operations.  The step sole responsibility
    /// is to make sure the correct %AWG object is used and that parameters such as channel,
    /// markers and clock references are correct for the %AWG object.
    /// 
    /// \ingroup highpi pisteps
    /// 
    /// </summary>
    [Binding] //Very important! This entry needs to be made in each step definition file. 
    public class AwgSyncSteps
    {
        private readonly AwgSyncGroup _awgSyncGroup = new AwgSyncGroup();

        #region *OPC?
        //glennj 1/27/2014
        /// <summary>
        /// Wait a maximum amount of time for operation complete to happen
        /// </summary>
        /// <param name="numberOfSeconds"></param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \sync\verbatim
        [When(@"I wait (\d+) seconds for operation complete for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I wait (\d+) seconds for operation complete for AWG ([1-4])")]
        public void WaitAPeriodOfTimeSecondsForOperationComplete(string numberOfSeconds, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            uint timeout = Convert.ToUInt32(numberOfSeconds)*1000;
            _awgSyncGroup.AwgOperationCompleteQuery(awg, timeout);
        }

        //glennj 1/27/2014
        //jmanning 04/01/2014
        /// <summary>
        /// Wait a maximum amount of time in minutes for operation complete to happen
        /// </summary>
        /// <param name="numberOfMinutes"></param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \sync\verbatim
        [When(@"I wait (\d+) minutes for operation complete for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I wait (\d+) minutes for operation complete for AWG ([1-4])")]
        public void WaitAPeriodOfTimeMinutesForOperationComplete(string numberOfMinutes, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            uint timeout = Convert.ToUInt32(numberOfMinutes) * 1000 * 60;
            _awgSyncGroup.AwgOperationCompleteQuery(awg, timeout);
        }

        //glennj 1/28/2014
        /// <summary>
        /// Using *OPC?, this waits for the internal operation complete for a specific AWG
        /// 
        /// *OPC?
        /// </summary>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \sync\verbatim
        [When(@"I wait for operation complete for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I wait for operation complete for AWG ([1-4])")]
        public void WaitForOperationCompleteForAwg(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncGroup.AwgOperationCompleteQuery(awg, awg.DefaultVisaTimeout);
        }

        //glennj 12/12/2013
        /// <summary>
        /// This is targetted at PI commands that have both blocked and overlapped implementations.
        /// </summary>
        /// <param name="majorMinorVersion">Major[.Minor[.Version]]</param>
        /// <param name="awgNumber"></param>
        /*!
            \sync\verbatim
        [When(@"I wait for operation complete for earlier versions than ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I wait for operation complete for earlier versions than ""(.+)"" for AWG ([1-4])")]
        public void WaitForOperationCompleteForEarlierVersions(string majorMinorVersion, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncGroup.WaitForOperationCompleteForEarlierVersions(awg, majorMinorVersion);
        }
        
        //Glenn 10/1/2012
        //jmanning 04/01/2014
        /// <summary>
        /// Waits a certain duration for the specific %AWG to complete, checking the Event Status register for a responce to the OPC query
        /// 
        /// *OPC?
        /// </summary>
        /// <param name="value">The value for the timeout</param>
        /// <param name="awgNumber"></param>
        /*!
            \sync\verbatim
        [When(@"I poll the Event Status Register for up to (\d+) (seconds|minutes) waiting for operation complete for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I poll the Event Status Register for up to (\d+) seconds waiting for operation complete for AWG ([1-4])")]
        public void PollForOperationCompleteSecondsForAwg(uint value, string awgNumber)
        {
            const string interval = "seconds";
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncGroup.AwgWaitForOperationComplete(awg, value, interval);
        }

        [When(@"I poll the Event Status Register for up to (\d+) minutes waiting for operation complete for AWG ([1-4])")]
        public void PollForOperationCompleteMinutesForAwg(uint value, string awgNumber)
        {
            const string interval = "minutes";
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncGroup.AwgWaitForOperationComplete(awg, value, interval);
        }
        #endregion *OPC?

        #region *WAI
        //PHunter 8/7/2012
        /// <summary>
        /// Waits for the default %AWG to complete it's previous command 
        /// 
        /// *WAI
        /// </summary>
        /*!
            \sync\verbatim
        [When(@"I wait to ensure that the previous command is completed for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I wait to ensure that the previous command is completed for AWG ([1-4])")]
        public void WaitForThePreviousCommandToExecute(string awgNumber)
        {

            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncGroup.AwgWait(awg);
        }
        #endregion *WAI
    }
}