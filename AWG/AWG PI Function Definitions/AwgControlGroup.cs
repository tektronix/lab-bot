//==========================================================================
// AwgControlGroup.cs
//==========================================================================
using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains helper functions that are called from the %AWG Control PI step definitions.
    /// This class has no restrictions as to where it will be used.
    /// 
    /// This "Helper" group does everything else but steps and TekVISA.
    /// Using parameters from the step, each helper will makes decisions
    /// such as send commands, or process responses from queries and
    /// do testing and generate asserts if necessary.
    /// 
    /// \ingroup grouphelperpi pisteps 
    ///  
    /// 
    /// </summary>
    public class AwgControlGroup
    {
        public enum ControlRunState { Stopped, Waiting, Running }

        private const string SyntaxForRunStateStopped = "0";
        private const string SyntaxForRunStateWaiting = "1";
        private const string SyntaxForRunStateRunning = "2";
        private const string WordingForStateStopped = "Stopped";
        private const string WordingForStateWaiting = "Waiting for trigger";
        private const string WordingForStateRunning = "Running";

        public enum InterleaveAdjustmentAmplitudeAs { Value, Min, Max }

        private const string InterleaveAdjustmentAmplitudeMaxSyntax = "MAX";
        private const string InterleaveAdjustmentAmplitudeMinSyntax = "MIN";

        public enum InterleaveAdjustmentPhaseAs { Value, Min, Max }

        private const string InterleaveAdjustmentPhaseMaxSyntax = "MAX";
        private const string InterleaveAdjustmentPhaseMinSyntax = "MIN";


        #region AWGControl:CONFigure:CNUMber?
        public void FindTheNumberOfChannelsAvailable(IAWG awg) 
        {
            awg.FindNumberOfChannels();
        }
        #endregion

        #region AWGControl:DOUTput[n][:STATe]
        //jmanning 09/24/2014
        /// <summary>
        /// Using AWGControl:DOUTput[n][:STATe] enables the raw DAC waveform outputs for the specified channel.
        /// </summary>
        /// <param name="channel">specified output channel</param>
        /// <param name="boolState">Desired enabled state</param>
        public void SetControlDACState(IAWG awg, string channel, string boolState)
        {
            awg.SetControlDACState(channel, boolState);
        }

        //jmanning 09/24/2014
        /// <summary>
        /// Using AWGControl:DOUTput[n][:STATe]? return the enable state for raw DAC waveform output for the specified channel.
        /// </summary>
        /// <param name="channel">specified output channel</param>
        /// <returns>state for raw DAC waveform output usage</returns>
        public void GetControlDACState(IAWG awg, string channel)
        {
            awg.GetControlDACState(channel);
        }

        //jmanning 09/24/2014
        /// <summary>
        /// Using AWGControl:DOUTput[n][:STATe]? compares the enable state for raw DAC waveform output to expected state for the specified channel.
        /// </summary>
        /// <param name="expectedState">expected state of output for DAC waveform enablement</param>
        /// <returns>state for raw DAC waveform output usage</returns>
        public void ControlDACStateShouldbe(IAWG awg, string expectedState)
        {
            string errMessage = "Received state of " + awg.ControlDACState + " not expected output mode state of " + expectedState;
            Assert.AreEqual(awg.ControlDACState, expectedState, errMessage);
        }
        #endregion AWGControl:DOUTput[n][:STATe]
        #region AWGControl:INTerleave:ADJustment:AMPLitude


        public void SetInterleaveAdjustmentAmplitude(IAWG awg, InterleaveAdjustmentAmplitudeAs setValueAs, string setValue = "")
        {
            var finalValue = setValue;
            switch (setValueAs)
            {
                case InterleaveAdjustmentAmplitudeAs.Min:
                    finalValue = InterleaveAdjustmentAmplitudeMinSyntax;
                    break;
                case InterleaveAdjustmentAmplitudeAs.Max:
                    finalValue = InterleaveAdjustmentAmplitudeMaxSyntax;
                    break;
            }
            awg.SetInterleaveAdjustmentAmplitude(finalValue);
        }

        public void GetInterleaveAdjustmentAmplitude(IAWG awg)
        {
            awg.GetInterleaveAdjustmentAmplitude();
        }

        public void InterleaveAdjustmentAmplitudeShouldBe(IAWG awg, string expectedValue)
        {
            Assert.AreEqual(float.Parse(expectedValue), float.Parse(awg.ControlInterleaveAdjustmentAmplitude));
        }
        #endregion

        #region AWGControl:INTerleave:ADJustment:PHASe

        public void SetInterleaveAdjustmentPhase(IAWG awg, InterleaveAdjustmentPhaseAs setValueAs, string setValue = "")
        {
            var finalValue = setValue;
            switch (setValueAs)
            {
                case InterleaveAdjustmentPhaseAs.Min:
                    finalValue = InterleaveAdjustmentPhaseMinSyntax;
                    break;
                case InterleaveAdjustmentPhaseAs.Max:
                    finalValue = InterleaveAdjustmentPhaseMaxSyntax;
                    break;
            }
            awg.SetInterleaveAdjustmentPhase(finalValue);
        }

        public void GetInterleaveAdjustmentPhase(IAWG awg)
        {
            awg.GetInterleaveAdjustmentPhase();
        }

        public void InterleaveAdjustmentPhaseShouldBe(IAWG awg, string expectedValue)
        {
            Assert.AreEqual(float.Parse(expectedValue), float.Parse(awg.ControlInterleaveAdjustmentPhase));
        }
        #endregion
        #region AWGControl:RMODe
        public void SetRunMode(IAWG awg, string setValue)
        {
            awg.SetRunMode(setValue);
        }

        public void GetRunMode(IAWG awg)
        {
            awg.GetRunMode();
        }

        public void RunModeShouldBe(IAWG awg, string expectedValue)
        {
            string interpreted;
            switch (expectedValue)
            {
                case "CONTinuous":
                    interpreted = "CONT";
                    break;
                case "TRIGgered":
                    interpreted = "TRIG";
                    break;
                default:
                    interpreted = expectedValue;
                    break;
            }
            Assert.AreEqual(awg.ControlRunMode, interpreted);
        }
        #endregion
        #region AWGControl:RSTate?

        public void GetRunState(IAWG awg)
        {
            awg.GetRunState();
        }

        /// <summary>
        /// The return response is always in the terms of 0, 1 and 2.<para>
        /// These translate into 0 for stopped, 1 for waiting and</para><para>
        /// 2 for running.</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedState"></param>
        public void RunStateofTheAwgShouldBe(IAWG awg, ControlRunState expectedState)
        {
            var expectedStateSyntax = SyntaxForRunStateStopped;
            var expectedStateWording = WordingForStateStopped;
            var actualStateWording = WordingForStateStopped;

            switch (expectedState)
            {
                case ControlRunState.Running:
                    expectedStateSyntax = SyntaxForRunStateRunning;
                    expectedStateWording = WordingForStateRunning;
                    break;
                case ControlRunState.Waiting:
                    expectedStateSyntax = SyntaxForRunStateWaiting;
                    expectedStateWording = WordingForStateWaiting;
                    break;
                case ControlRunState.Stopped:
                    expectedStateSyntax = SyntaxForRunStateStopped;
                    expectedStateWording = WordingForStateStopped;
                    break;
            }

            switch (awg.ControlRunState)
            {
                case SyntaxForRunStateRunning:
                    actualStateWording = WordingForStateRunning;
                    break;
                case SyntaxForRunStateWaiting:
                    actualStateWording = WordingForStateWaiting;
                    break;
                case SyntaxForRunStateStopped:
                    actualStateWording = WordingForStateStopped;
                    break;
            }

            string possibleErrorString = "Expected state is " + expectedStateWording + " and Actual state is " +
                                         actualStateWording;
            // All the above work for this test.
            Assert.AreEqual(expectedStateSyntax, awg.ControlRunState, possibleErrorString);
        }

        /// <summary>
        /// This looks for an expected run state.  The AWG is polled at an<para>
        /// interval and the intervals between polls for a number of seconds.</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedState"></param>
        /// <param name="numberOfSeconds"></param>
        /// <param name="numberOfPolls"></param>
        public void PollForRunningStateofTheAwgShouldBe(IAWG awg, ControlRunState expectedState, string numberOfSeconds, string numberOfPolls)
        {

            var expectedStateSyntax = SyntaxForRunStateStopped;
            var expectedStateWording = WordingForStateStopped;
            var actualStateWording = WordingForStateStopped;

            switch (expectedState)
            {
                case ControlRunState.Running:
                    expectedStateSyntax = SyntaxForRunStateRunning;
                    expectedStateWording = WordingForStateRunning;
                    break;
                case ControlRunState.Waiting:
                    expectedStateSyntax = SyntaxForRunStateWaiting;
                    expectedStateWording = WordingForStateWaiting;
                    break;
                case ControlRunState.Stopped:
                    expectedStateSyntax = SyntaxForRunStateStopped;
                    expectedStateWording = WordingForStateStopped;
                    break;
            }

            int maxTimesToPoll = Convert.ToInt32(numberOfPolls);
            int pollNumber = 0;
            bool foundExpectedState;

            do
            {
                Thread.Sleep(1000);     // Delay 1 second
                awg.GetRunState();

                switch (awg.ControlRunState)
                {
                    case SyntaxForRunStateRunning:
                        actualStateWording = WordingForStateRunning;
                        break;
                    case SyntaxForRunStateWaiting:
                        actualStateWording = WordingForStateWaiting;
                        break;
                    case SyntaxForRunStateStopped:
                        actualStateWording = WordingForStateStopped;
                        break;
                }

                foundExpectedState = (expectedStateSyntax == awg.ControlRunState);

                pollNumber += 1;    // Keep track of polls and make it obvious instead of burying it in the while test below

            } while (!foundExpectedState && (pollNumber < maxTimesToPoll));

            string possibleErrorString = "Expected " + expectedStateWording + " was not found in " + numberOfPolls + " polls. " + "Actual was " + actualStateWording;

            // All the above work for this test.
            Assert.AreEqual(expectedStateSyntax, awg.ControlRunState, possibleErrorString);
        }

        #endregion
        #region AWGControl:RUN[:IMMediate]
        public void RunTheAwg(IAWG awg)
        {
            awg.RunImmediate();
        }
        #endregion
        #region AWGControl:SNAMe?

        public void GetMostRecentlySavedSetupLocation(IAWG awg)
        {
            awg.GetSavedSetupLocation();
        }

        public void SetupLocationShouldBe(IAWG awg, string expectedValue, string msus)
        {
            string[] setupLoc = awg.ControlSavedSetupLocation.Split(',');
            if (setupLoc.Length != 2) //Break up the returned string for more informative error messages
            {
                Assert.Fail("Invalid Setup Location String Return"); //Something has gone wrong with the delimiter
            }
            var setupFileName = setupLoc[0]; //Empty the array back into the AWG vars
            var setupFileMsus = setupLoc[1];
            Assert.AreEqual(setupFileName, '"' + expectedValue + '"', "Setup Location File Path Did Not Match");
            Assert.AreEqual(setupFileMsus, '"' + msus + '"', "Setup Location Mass Storage Units Did Not Match");

        }
        #endregion
        #region AWGControl:SREStore
        public void RestoreSetupTheAwg(IAWG awg, string filename, string msus)
        {
            if (msus != "") //If the msus is blank no comma is needed in the write command
            {
                msus = ",\"" + msus + '"';
            }
            awg.SetupRestore(filename, msus);
        }
        #endregion
        #region AWGControl:SSAVe
        public void SaveSetupTheAwg(IAWG awg, string filename, string msus)
        {
            if (msus != "") //If the msus is blank no comma is needed in the write command
            {
                msus = ",\"" + msus + '"';
            }
            awg.SetupSave(filename, msus);
        }
        #endregion
        #region AWGControl:STOP[:IMMediate]
        public void StopTheAwg(IAWG awg)
        {
            awg.StopImmediate();
        }
        #endregion

    }
 }