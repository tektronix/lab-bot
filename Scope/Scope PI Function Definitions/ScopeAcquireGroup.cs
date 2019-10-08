//==========================================================================
// ScopeAquireGroup.cs
//==========================================================================
using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains helper functions that are called from the Scope Acquisition PI step definitions
    /// 
    /// </summary>
    public class ScopeAcquireGroup
    {
        private readonly UtilitiesGroup _utilitiesGroup = new UtilitiesGroup();

        #region ScopeCommon

        /// <summary>
        /// Sets the Scope acquistion mode
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="mode">Scope acquisition mode</param>
        public void SetScopeAcquisitionMode(ISCOPE scope, string mode)
        {
            scope.SetScopeAcquisitionMode(mode);
        }

        /// <summary>
        /// Gets the scope acquisition state
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <returns>Scope state</returns>
        public void GetScopeAcquisitionState(ISCOPE scope)
        {
            scope.GetScopeAcquisitionState();
        }

        /// <summary>
        /// Sets the scope acquisition state
        /// 
        /// </summary>       
        /// <param name="scope">the SCOPE object</param>
        /// <param name="state"></param>
        public void SetScopeAcquisitionState(ISCOPE scope, string state)
        {
            scope.SetScopeAcquisitonState(state);
        }

        public void SetScopeAcquisitionStateAndWaitFor(ISCOPE scope, string time)
        {
            UTILS.HiPerfTimer Timer1 = new UTILS.HiPerfTimer(); 
            scope.SetScopeAcquisitonState("ON");
            double maxTime = double.Parse(time);
            double total_time = 0;
            Thread.Sleep(3000);
            while (total_time < maxTime)
            {
                Timer1.Start();
                scope.GetScopeAcquisitionState();
                scope.SetScopeAcquisitonState("ON");
                Thread.Sleep(1000); // Have to make sure this is between the start/stop commands
                Timer1.Stop();
                // Add the current interval to the total
                total_time = total_time + Timer1.Duration;
            }
            scope.GetScopeAcquisitionState();
            if (scope.ScopeAquisitionState == "0")
            {
                Assert.Fail("Scope was unsuccessfully kept in RUN state");
            }
        }
        
        
        public void TheScopeStaysInAcquisitionStateFor(ISCOPE scope, string givenState, string time, string units)
        {
            UTILS.HiPerfTimer Timer1 = new UTILS.HiPerfTimer();
            long timeout = 0;
            double totalTime = 0;
            int value = Int16.Parse(time);
            string acquireState = "";
            int checkInterval = 500;
            //Convert to milliseconds
            switch (units)
            {
                case "minutes":
                case "min":
                    timeout = value*60; //Convert to seconds
                    checkInterval = 10000;
                        //Really no need to tie up TekVisa with calls every half second if the timeout is in minutes change to every 10 seconds
                    break;

                case "seconds":
                case "sec":
                    timeout = value;
                    break;
            }
            //Convert the given state to 1 or 0 to match what the Scope will return
            switch (givenState)
            {
                case "ON":
                case "RUN":
                    acquireState = "1";
                    break;

                case "OFF":
                case "STOP":
                    acquireState = "0";
                    break;

                default:
                    acquireState = givenState;
                    break;
            }
            scope.GetScopeAcquisitionState();
            string state = scope.ScopeAquisitionState;
            if (state != acquireState)
            {
                if (acquireState != "") //Don't view a return of an empty string as a fail
                {
                    Assert.Fail("Scope no longer in " + acquireState + " state");
                }
            }
            // Start the timer, and wait up to the max amount of time 
            while (totalTime < timeout)
            {
                Timer1.Start();
                scope.GetScopeAcquisitionState();
                state = scope.ScopeAquisitionState;
                if (state != acquireState)
                {
                    if (acquireState != "")
                    {
                        Assert.Fail("Scope no longer in " + acquireState + " state");
                    }
                }
                Thread.Sleep(checkInterval); // Have to make sure this is between the start/stop commands
                Timer1.Stop(); //CheckInterval is changed if the timeout is in minutes to reduce traffic

                // Add the current interval to the total
                totalTime = totalTime + Timer1.Duration;
            }
        }

        #endregion ScopeCommon

        #region CSA Only

        /// <summary>
        /// Gets the number of acquired waveforms from the CSA
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="time">anount of time to wait in seconds, default is 10 seconds</param>
        public void WaitSecondsForCSAScopeToShowAcquisitions(ISCOPE scope, string time = "10")
        {
            int currentAcqCount = 0;
            double totalTime = 0;
            UTILS.HiPerfTimer Timer1 = new UTILS.HiPerfTimer();

            // Get initial acq count from scope, initialize the time accumulator
            scope.GetCSAAcquisitionCount();
            //Error checking for a empty string otherwise, parse as normal
            int initialAcqCount = string.IsNullOrWhiteSpace(scope.CSAAquisitionCount)
                ? 0
                : int.Parse(scope.CSAAquisitionCount);

            // Start the timer, and wait up to the max number of seconds specified for acqs to appear ever 500ms
            while ((totalTime < double.Parse(time)) && (initialAcqCount == currentAcqCount))
            {
                Timer1.Start();
                scope.GetCSAAcquisitionCount();
                //Error checking for a empty string otherwise, parse as normal
                currentAcqCount = string.IsNullOrWhiteSpace(scope.CSAAquisitionCount)
                    ? 0
                    : int.Parse(scope.CSAAquisitionCount);
                Thread.Sleep(500); // Have to make sure this is between the start/stop commands
                Timer1.Stop();

                // Add the current interval to the total
                totalTime = totalTime + Timer1.Duration;
            }

            if (initialAcqCount == currentAcqCount)
            {
                Assert.Fail(totalTime + " sec. passed with no acquisitions counted on scope. Max time allowed was " +
                            time + " seconds.");
            }
        }

        /// <summary>
        /// Gets the number of acquired waveforms from the CSA
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        public void GetCSAAcquisitionCount(ISCOPE scope)
        {
            scope.GetCSAAcquisitionCount();
        }

        /// <summary>
        /// Compares the Acquisition Count to a expected count value for a CSA Scope
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="count">Expected Count Value</param>
        public void TheCSAScopeAcquisitionCountShouldBe(ISCOPE scope, string count)
        {
            int scopeAcqCount = scope.CSAAquisitionCount == " " ? 0 : int.Parse(scope.CSAAquisitionCount);
            int expectedAcqCount = int.Parse(count);
            Assert.AreEqual(expectedAcqCount, scopeAcqCount, "CSA Scope acquisition count " + scopeAcqCount + " does not match expected " + expectedAcqCount);
        }

        /// <summary>
        /// Verifies that the Acquisition Count is within a specific count range for a CSA Scope
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="high">High Count Value of the Range</param>
        /// <param name="low">Low Count Value of the Range</param>
        public void TheCSAScopeAcquisitionCountShouldBeBetween(ISCOPE scope, string high, string low)
        {
            int scopeAcqCount = scope.CSAAquisitionCount == " " ? 0 : int.Parse(scope.CSAAquisitionCount);
            int highAcqCount = int.Parse(high);
            int lowAcqCount = int.Parse(low);
            if ((scopeAcqCount < lowAcqCount) || (scopeAcqCount > highAcqCount))
            {
                Assert.Fail("CSA Scope acquisition count was " + scopeAcqCount + " and the allowable range was from " + lowAcqCount + " to " + highAcqCount);
            }
        }
        
        /// <summary>
        /// Resets the CSA waveform count acquisition count
        /// 
        /// </summary>
        /// <param name="scope"></param>
        public void RunCSAResetAcquisitionCount(ISCOPE scope)
        {
            scope.CSAAcquisitionCountReset();
        }

        /// <summary>
        /// Sets the CSA's acquisition stop after condition
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="state"></param>
        public void SetCSAAcquisitionStopAfterConditionState(ISCOPE scope, string state)
        {
            scope.SetCSAAcquireStopAfterCondition(state);
        }

        /// <summary>
        /// Sets the criteria for when the CSA will stop acquisition
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="count">Number of hits</param>
        public void SetCSAAcquisitionStopAfterCount(ISCOPE scope, string count)
        {
            scope.SetCSAAcquireStopAfterCount(count);
        }

        /// <summary>
        /// Sets the CSA's acquisition stop after mode
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="mode"></param>
        public void SetCSAAcquisitionStopAfterMode(ISCOPE scope, string mode)
        {
            scope.SetCSAAcquireStopAfterMode(mode);
        }

        /// <summary>
        /// Gets the CSA mask waveform acquisition count
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        public void GetCSACurrentMaskWfmCountQuery(ISCOPE scope)
        {
            scope.GetCSACurrentMaskWfmCount();
        }

        /// <summary>
        /// Compares the CSA mask waveform acquisition value should be greater than this value. 
        /// 
        /// ACQuire:CURRentcount:MASKWfms?        
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="expectedValue">Waveform count should be greater than this value</param>
        public void TheCSAMaskWaveformAcquisitionCountShouldBeGreaterThan(ISCOPE scope, string expectedValue)
        {
            int wfmCount = string.IsNullOrWhiteSpace(scope.CSACurrentMaskCount)
                ? 0
                : int.Parse(scope.CSACurrentMaskCount);
            int greaterWfmCount = int.Parse(expectedValue);
            if (!(wfmCount > greaterWfmCount))
            {
                Assert.Fail("CSA mask waveform acquisition count of " + wfmCount + " is not greater than " +
                            greaterWfmCount);
            }
        }

        /// <summary>
        /// Looks at the trend(stopped or increasing) of the mask waveform acquisition count for the CSA Scope. 
        /// 
        /// ACQuire:CURRentcount:MASKWfms?        
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="trend">Mask Acquisition Count Trending[increasing|stopped]</param>
        public void TheCSAMaskWaveformAcquisitionCountShouldBeTrending(ISCOPE scope, string trend)
        {
            scope.GetCSACurrentMaskWfmCount();
            int initialWfmCount = string.IsNullOrWhiteSpace(scope.CSACurrentMaskCount)
                ? 0
                : int.Parse(scope.CSACurrentMaskCount);
            _utilitiesGroup.WaitNSeconds(3);
            scope.GetCSACurrentMaskWfmCount();
            int latestWfmCount = string.IsNullOrWhiteSpace(scope.CSACurrentMaskCount)
                ? 0
                : int.Parse(scope.CSACurrentMaskCount);
            switch (trend)
            {
                case "increasing":
                    if (initialWfmCount >= latestWfmCount)
                    {
                        Assert.Fail("The acquisition counts were not increasing");
                    }
                    break;

                case "stopped":
                    if (initialWfmCount != latestWfmCount)
                    {
                        Assert.Fail("The acquisition counts were increasing when they should have been stopped");
                    }
                    break;
            }
        }


        /// <summary>
        /// Compares the CSA mask waveform acquisition value should be greater than this value. 
        /// 
        /// ACQuire:CURRentcount:MASKWfms?        
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="time">Amount of time to wait inbetween taking counts</param>
        public void IWaitUntilCSAMaskShowsWfmAcquisitions(ISCOPE scope, string time)
        {
            int currentWfmAcqCount = 0;
            double totalTime = 0;
            UTILS.HiPerfTimer Timer1 = new UTILS.HiPerfTimer();
            double maxTime = double.Parse(time);

            //Error checking for a empty string otherwise, parse as normal
            int initialWfmAcqCount = string.IsNullOrWhiteSpace(scope.CSACurrentMaskCount)
                ? 0
                : int.Parse(scope.CSACurrentMaskCount);

            // Start the timer, and wait up to the max number of seconds specified for acqs to appear ever 500ms
            while ((totalTime < maxTime) && (initialWfmAcqCount == currentWfmAcqCount))
            {
                Timer1.Start();
                scope.GetCSACurrentMaskWfmCount();
                //Error checking for a empty string otherwise, parse as normal
                currentWfmAcqCount = string.IsNullOrWhiteSpace(scope.CSACurrentMaskCount)
                    ? 0
                    : int.Parse(scope.CSACurrentMaskCount);
                Thread.Sleep(500); // Have to make sure this is between the start/stop commands
                Timer1.Stop();

                // Add the current interval to the total
                totalTime = totalTime + Timer1.Duration;
            }

            if (initialWfmAcqCount == currentWfmAcqCount)
            {
                Assert.Fail(totalTime + " sec. passed with no acquisitions counted on CSA scope. Max time allowed was " +
                            maxTime + " seconds.");
            }
        }

        #endregion CSA Only

        #region DPO Only

        /// <summary>
        /// Gets the number of acquired waveforms from the DPO since starting Acquisition with the ACQuire:STATE RUN command
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <returns>Number of acquired waveforms</returns>
        public void GetDPOAcquisitionWfmCount(ISCOPE scope)
        {
            scope.GetDPOAcquisitionWfmCount();
        }

        /// <summary>
        /// Looks at the trend(stopped or increasing) of the mask waveform acquisition count for the CSA Scope. 
        /// 
        /// ACQuire:NUMACq?      
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="trend">Mask Acquisition Count Trending[increasing|stopped]</param>
        public void TheDPOAcquisitionWfmCountShouldBeTrending(ISCOPE scope, string trend)
        {
            scope.GetDPOAcquisitionWfmCount();
            int initialWfmCount = string.IsNullOrWhiteSpace(scope.DPOAcquisitionWfmCount)
                ? 0
                : int.Parse(scope.DPOAcquisitionWfmCount);
            _utilitiesGroup.WaitNSeconds(3);
            scope.GetDPOAcquisitionWfmCount();
            int latestWfmCount = string.IsNullOrWhiteSpace(scope.DPOAcquisitionWfmCount)
                ? 0
                : int.Parse(scope.DPOAcquisitionWfmCount);
            switch (trend)
            {
                case "increasing":
                    if (initialWfmCount >= latestWfmCount)
                    {
                        Assert.Fail("The waveform acquisition counts were not increasing");
                    }
                    break;

                case "stopped":
                    if (initialWfmCount != latestWfmCount)
                    {
                        Assert.Fail("The waveform acquisition counts were increasing when they should have been stopped");
                    }
                    break;
            }
        }

        /// <summary>
        /// Gets the number of acquired waveforms from the DPO Scope
        /// 
        /// ACQuire:NUMACq?
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="time">anount of time to wait in seconds, default is 10 seconds</param>
        public void WaitSecondsForDPOScopeToShowAcquisitions(ISCOPE scope, string time = "10")
        {
            int currentAcqCount = 0;
            double totalTime = 0;
            UTILS.HiPerfTimer Timer1 = new UTILS.HiPerfTimer();

            // Get initial acq count from scope, initialize the time accumulator
            scope.GetDPOAcquisitionWfmCount();
            //Error checking for a empty string otherwise, parse as normal
            int initialAcqCount = string.IsNullOrWhiteSpace(scope.DPOAcquisitionWfmCount)
                ? 0
                : int.Parse(scope.DPOAcquisitionWfmCount);

            // Start the timer, and wait up to the max number of seconds specified for acqs to appear ever 500ms
            while ((totalTime < double.Parse(time)) && (initialAcqCount == currentAcqCount))
            {
                Timer1.Start();
                scope.GetDPOAcquisitionWfmCount();
                //Error checking for a empty string otherwise, parse as normal
                currentAcqCount = string.IsNullOrWhiteSpace(scope.DPOAcquisitionWfmCount)
                    ? 0
                    : int.Parse(scope.DPOAcquisitionWfmCount);
                Thread.Sleep(500); // Have to make sure this is between the start/stop commands
                Timer1.Stop();

                // Add the current interval to the total
                totalTime = totalTime + Timer1.Duration;
            }

            if (initialAcqCount == currentAcqCount)
            {
                Assert.Fail(totalTime + " sec. passed with no acquisitions counted on DPO scope. Max time allowed was " +
                            time + " seconds.");
            }
        }

        /// <summary>
        /// Compares the Acquisition Count to a expected count value for a DPO Scope
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="count">Expected Count Value</param>
        public void TheDPOScopeAcquisitionCountShouldBe(ISCOPE scope, string count)
        {
            int scopeAcqCount = scope.DPOAcquisitionWfmCount == " " ? 0 : int.Parse(scope.DPOAcquisitionWfmCount);
            int expectedAcqCount = int.Parse(count);
            Assert.AreEqual(expectedAcqCount, scopeAcqCount, "DPO Scope acquisition count " + scopeAcqCount + " does not match expected " + expectedAcqCount);
        }

        /// <summary>
        /// Verifies that the Acquisition Count is within a specific count range for a DPO Scope
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="high">High Count Value of the Range</param>
        /// <param name="low">Low Count Value of the Range</param>
        public void TheDPOScopeAcquisitionCountShouldBeBetween(ISCOPE scope, string high, string low)
        {
            int scopeAcqCount = scope.DPOAcquisitionWfmCount == " " ? 0 : int.Parse(scope.DPOAcquisitionWfmCount);
            int highAcqCount = int.Parse(high);
            int lowAcqCount = int.Parse(low);
            if ((scopeAcqCount < lowAcqCount) || (scopeAcqCount > highAcqCount))
            {
                Assert.Fail("DPO Scope acquisition count was " + scopeAcqCount + " and the allowable range was from " + lowAcqCount + " to " + highAcqCount);
            }
        }
        
        /// <summary>
        /// Sets the DPO Fast Acquisition State 
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="state">Fast acquisition state</param>
        public void SetDPOFastAcquisitions(ISCOPE scope, string state)
        {
            scope.SetDPOFastAcquisitions(state);
        }

        /// <summary>
        /// Sets the DPO stop after mode
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="mode">Desired DPO stop after mode</param>
        public void SetDPOAcquisitionStopAfterMode(ISCOPE scope, string mode)
        {
            scope.SetDPOAcquireStopAfterMode(mode);
        }

        #endregion DPO Only
    }
}
