//==========================================================================
// AwgOutputGroup.cs
//==========================================================================
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains helper functions that are called from the %AWG Output PI step definitions.
    /// This class has no restrictions as to where it will be used.
    /// 
    /// This "Helper" group does everything else but steps and TekVISA.
    /// Using parameters from the step, each helper will makes decisions
    /// such as send commands, or process responses from queries and
    /// do testing and generate asserts if necessary.
    /// 
    /// \ingroup grouphelperpi pisteps 
    /// </summary>
    public class AwgOutputGroup
    {
        public enum OutputFilterType {None, BandPass, LowPass}
        public enum OutputFilterBandPassRange {R10to14GHz, R13to18GHz}
        public enum OutputModeType {Direct,AC}
        public enum OutputStateMode { Off, On }
        public enum OutputOffStateMode { Off, On }
        public enum OutputAnalogStopMode { Off, Zero}
        public enum OutputMarkerStopMode { Off, Low }
        public enum OutputAnalogWaitMode { First, Zero }
        public enum OutputMarkerWaitMode { First, Low, High }

        public const string SyntaxForOutputFilterNone = "NONE";
        public const string SyntaxForOutputFilterBandPass = "BPAS";
        public const string SyntaxForOutputFilterLowPass = "LPAS";

        public const string SyntaxForOutputModeDirect = "DIR";
        public const string SyntaxForOutputModeAC = "AC"; 
        
        public const string SyntaxForOutputStateOn = "ON";
        public const string SyntaxForOutputStateOff = "OFF";

        public const string SyntaxForReturnedOutputStateOn = "1";
        public const string SyntaxForReturnedOutputStateOff = "0";

        public const string SyntaxForReturnedOutputStopValueAnalogOff = "OFF";
        public const string SyntaxForReturnedOutputStopValueAnalogZero = "ZERO";

        public const string SyntaxForOutputStopValueMarkerOff = "OFF";
        public const string SyntaxForOutputStopValueMarkerLow = "LOW";

        public const string SyntaxForOutputWaitValueAnalogFirst = "FIRS";
        public const string SyntaxForOutputWaitValueAnalogZero = "ZERO";

        public const string SyntaxForOutputWaitValueMarkerFirst = "FIRS";
        public const string SyntaxForOutputWaitValueMarkerLow   = "LOW";
        public const string SyntaxForOutputWaitValueMarkerHigh  = "HIGH";

        // Error strings
        public const string ErrorStringCheckingOutputOffStateForAwg     = "Checking the output off state for the AWG";
        public const string ErrorStringCheckingOutputOffStateForChannel = "Checking the output state for the channel ";
        public const string ErrorStringCheckingOutputStopAnalog         = "Checking the output stop value for analog for channel ";
        public const string ErrorStringCheckingOutputWaitAnalog         = "Checking the output wait value for analog for channel ";

        public const string ErrorStringCheckingOutputStopMarker         = "Checking the output stop value for marker ";
        public const string ErrorStringCheckingOutputWaitMarker         = "Checking the output wait value for marker ";
        public const string ErrorStringForChannel                       = " for channel ";

        #region OUTPut[n]:ATTenuator:A1
        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:A1 sets the step value setting for A1 attenuator of a channel in units of dB.
        /// This is a blocking
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="filterStepValue">step increment value</param>
        public void SetOutputFilterAttenuatorA1Step(IAWG awg, string outputIndex, string filterStepValue)
        {
            awg.SetOutputFilterAttenuatorA1Step(outputIndex, filterStepValue);
        }
        #endregion OUTPut[n]:ATTenuator:A1

        #region OUTPut[n]:ATTenuator:A1?
        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:A1? gets the step value setting for A1attenuator of a channel in units of dB.
        /// This is a blocking
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="outputIndex">Index of output</param>
        /// <returns>step increment value</returns>
        public void GetOutputFilterAttenuatorA1Step(IAWG awg, string outputIndex)
        {
            awg.GetOutputFilterAttenuatorA1Step(outputIndex);
        }

        //shkv - 12/3/2014 Added mean variable calculation,as TekVisa returns decimal values
        /// kaylak 11/14/2014
        /// <summary>
        /// Verify the AWG filter attenuator A1 step value 
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedValue"></param>
        public void OutputFilterAttenuatorA1StepShouldBe(IAWG awg, string expectedValue)
        {
            double mean = float.Parse(awg.OutputFilterAttnA1Step);
            string possibleErrorString = "Output filter attenuator A1 step value was  " + mean.ToString() + ".  Not the expected value of of " + expectedValue;
            Assert.AreEqual(expectedValue, mean.ToString(), possibleErrorString);
        }
        #endregion OUTPut[n]:ATTenuator:A1?

        #region OUTPut[n]:ATTenuator:A2
        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:A2 sets the step value setting for A2 attenuator of a channel in units of dB.
        /// This is a blocking
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="filterStepValue">step increment value</param>
        public void SetOutputFilterAttenuatorA2Step(IAWG awg, string outputIndex, string filterStepValue)
        {
            awg.SetOutputFilterAttenuatorA2Step(outputIndex, filterStepValue);
        }
        #endregion OUTPut[n]:ATTenuator:A2

        #region OUTPut[n]:ATTenuator:A2?
        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:A2? gets the step value setting for A2attenuator of a channel in units of dB.
        /// This is a blocking
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="outputIndex">Index of output</param>
        /// <returns>step increment value</returns>
        public void GetOutputFilterAttenuatorA2Step(IAWG awg, string outputIndex)
        {
            awg.GetOutputFilterAttenuatorA2Step(outputIndex);
        }
        //shkv -12/3/2014 Added mean variable calculation,as TekVisa returns decimal values
        /// kaylak 11/14/2014
        /// <summary>
        /// Verify the AWG filter attenuator A2 step value 
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedValue"></param>
        public void OutputFilterAttenuatorA2StepShouldBe(IAWG awg, string expectedValue)
        {
            double mean = float.Parse(awg.OutputFilterAttnA2Step);
            string possibleErrorString = "Output filter attenuator A2 step value was  " + mean.ToString() + ".  Not the expected value of of " + expectedValue;
            Assert.AreEqual(expectedValue, mean.ToString(), possibleErrorString);
        }
        #endregion OUTPut[n]:ATTenuator:A2?

        #region OUTPut[n]:ATTenuator:A3
        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:A3 sets the step value setting for A3 attenuator of a channel in units of dB.
        /// This is a blocking
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="filterStepValue">step increment value</param>
        public void SetOutputFilterAttenuatorA3Step(IAWG awg, string outputIndex, string filterStepValue)
        {
            awg.SetOutputFilterAttenuatorA3Step(outputIndex, filterStepValue);
        }
        #endregion OUTPut[n]:ATTenuator:A3

        #region OUTPut[n]:ATTenuator:A3?
        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:A3? gets the step value setting for A3attenuator of a channel in units of dB.
        /// This is a blocking
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="outputIndex">Index of output</param>
        /// <returns>step increment value</returns>
        public void GetOutputFilterAttenuatorA3Step(IAWG awg, string outputIndex)
        {
            awg.GetOutputFilterAttenuatorA3Step(outputIndex);
        }
        //shkv -12/3/2014 Added mean variable calculation,as TekVisa returns decimal values
        /// kaylak 11/14/2014
        /// <summary>
        /// Verify the AWG filter attenuator A3 step value 
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedValue"></param>
        public void OutputFilterAttenuatorA3StepShouldBe(IAWG awg, string expectedValue)
        {
            double mean = float.Parse(awg.OutputFilterAttnA3Step);
            string possibleErrorString = "Output filter attenuator A3 step value was  " + mean.ToString() + ".  Not the expected value of of " + expectedValue;
            Assert.AreEqual(expectedValue, mean.ToString(), possibleErrorString);
        }
        #endregion OUTPut[n]:ATTenuator:A3?

        #region OUTPut[n]:ATTenuator:DAC
        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:DAC sets the step value setting for DAC attenuator of a channel in units of dBm.
        /// This is a blocking
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="filterStepValue">step increment value</param>
        public void SetOutputFilterAttenuatorDACStep(IAWG awg, string outputIndex, string filterStepValue)
        {
            awg.SetOutputFilterAttenuatorDACStep(outputIndex, filterStepValue);
        }
        #endregion OUTPut[n]:ATTenuator:DAC

        #region OUTPut[n]:ATTenuator:DAC?
        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:ATTenuator:DAC? gets the step value setting for DACattenuator of a channel in units of dBm.
        /// This is a blocking
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="outputIndex">Index of output</param>
        /// <returns>step increment value</returns>
        public void GetOutputFilterAttenuatorDACStep(IAWG awg, string outputIndex)
        {
            awg.GetOutputFilterAttenuatorDACStep(outputIndex);
        }
        //shkv -12/3/2014 Added mean variable calculation,as TekVisa returns decimal values
        /// kaylak 11/14/2014
        /// <summary>
        /// Verify the AWG filter attenuator DAC step value 
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedValue"></param>
        public void OutputFilterAttenuatorDACStepShouldBe(IAWG awg, string expectedValue)
        {
            double mean = float.Parse(awg.OutputFilterAttnDACStep);
            string possibleErrorString = "Output filter attenuator DAC step value was  " + mean.ToString() + ".  Not the expected value of of " + expectedValue;
            Assert.AreEqual(expectedValue, mean.ToString(), possibleErrorString);
        }
        #endregion OUTPut[n]:ATTenuator:DAC?

        #region OUTPut[n]:FILTer
        //jmanning 09/22/2014
        /// <summary>
        /// Using OUTPut[n]:FILTer sets the filter type of the of the selected signal path
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="filterType">Type of Filter [NONE|BPASs|LPASs]</param>
        public void SetOutputFilter(IAWG awg, string outputIndex, OutputFilterType filterType)
        {
            var expectedSyntax = "Syntax not Valid";
            switch (filterType)
            {
                case OutputFilterType.BandPass:
                    expectedSyntax = SyntaxForOutputFilterBandPass;
                    break;
                case OutputFilterType.LowPass:
                    expectedSyntax = SyntaxForOutputFilterLowPass;
                    break;
                case OutputFilterType.None:
                    expectedSyntax = SyntaxForOutputFilterNone;
                    break;

            }
            awg.SetOutputFilter(outputIndex, expectedSyntax);
        }
        #endregion OUTPut[n]:FILTer

        #region OUTPut[n]:FILTer?
        //jmanning 09/22/2014
        /// <summary>
        /// Using OUTPut[n]:FILTer? gets the filter type of the of the selected signal path
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="outputIndex">Index of output</param>
        /// <returns> Type of Filter [NONE|BPASs|LPASs]</returns>
        public void GetOutputFilter(IAWG awg, string outputIndex)
        {
            awg.GetOutputFilter(outputIndex);
        }

        //jmanning 09/22/2014
        /// <summary>
        /// Verify the AWG filter type for an expected output source
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedFilterType"></param>
        public void OutputFilterTypeShouldBe(IAWG awg, OutputFilterType expectedFilterType)
        {
            var expectedSyntax = "Syntax not Valid";
            switch (expectedFilterType)
            {
                case OutputFilterType.BandPass:
                    expectedSyntax = SyntaxForOutputFilterBandPass;
                    break;
                case OutputFilterType.LowPass:
                    expectedSyntax = SyntaxForOutputFilterLowPass;
                    break;
                case OutputFilterType.None:
                    expectedSyntax = SyntaxForOutputFilterNone;
                    break;
                
            }
            string possibleErrorString = "Output filter type" + awg.OutputFilterType + " found not the expected filter type of " + expectedSyntax;
            Assert.AreEqual(expectedSyntax, awg.OutputFilterType, possibleErrorString);
        }
        #endregion OUTPut[n]:FILTer?

        #region OUTPut[n]:FILTer:BPASs:RANGe
        //shkv 1/8/2015 Added fix for 5168 
        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:FILTer:BPASs:RANGe sets the band pass filter range
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="filterRange">Type of Filter Path</param>
        public void SetOutputFilterBandPassRangeR13to18GHz(IAWG awg, string outputIndex, OutputFilterBandPassRange filterRange)
        {
            string expectedSyntax = "R13to18GHz";

            awg.SetOutputFilterBandPassRangeR13to18GHz(outputIndex, expectedSyntax);
        }
        public void SetOutputFilterBandPassRangeR10to14GHz(IAWG awg, string outputIndex, OutputFilterBandPassRange filterRange)
        {
            string expectedSyntax = "R10to14GHz";

            awg.SetOutputFilterBandPassRangeR10to14GHz(outputIndex, expectedSyntax);
        }
        #endregion OUTPut[n]:FILTer:BPASs:RANGe

        #region OUTPut[n]:FILTer:BPASs:RANGe?
        /// kaylak 11/14/2014
        /// <summary>
        /// Using OUTPut[n]:FILTer:BPASs:RANGe? gets the band pass filter range
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="outputIndex">Index of output</param>
        /// <returns>Type of Filter Path</returns>
        public void GetOutputFilterBandPassRange(IAWG awg, string outputIndex)
        {
            awg.GetOutputFilterBandPassRange(outputIndex);
        }
        //shkv 1/8/2015 Added fix for 5168
        //jmanning 09/22/2014
        /// <summary>
        /// Verify the AWG filter path for an expected output source
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedFilterPath"></param>
        public void OutputFilterBandPassRangeShouldBeR10to14GHz(IAWG awg, OutputFilterBandPassRange expectedFilterRange)
        {
            var expectedSyntax = "R10TO14GHZ";

            string possibleErrorString = "Output filter band pass range " + awg.OutputFilterBandPassRange + " found not the expected filter path of " + expectedSyntax;
            Assert.AreEqual(expectedSyntax, awg.OutputFilterBandPassRange, possibleErrorString);
        }

        public void OutputFilterBandPassRangeShouldBeR13to18GHz(IAWG awg, OutputFilterBandPassRange expectedFilterRange)
        {
            var expectedSyntax = "R13TO18GHZ";

            string possibleErrorString = "Output filter band pass range " + awg.OutputFilterBandPassRange + " found not the expected filter path of " + expectedSyntax;
            Assert.AreEqual(expectedSyntax, awg.OutputFilterBandPassRange, possibleErrorString);
        }     

        #endregion OUTPut[n]:FILTer:BPASs:RANGe?

        #region OUTPut[n]:PATH
        //shkv 12/9/2014 Modified the region name
        //jmanning 09/22/2014
        /// <summary>
        /// Using OUTPut[n]:MODE sets the signal path [DIRect|AC]
        /// </summary>
        /// <param name="awg">Object</param>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="signalPath">Signal Path Type of Filter [DIRect|AC]</param>
        public void SetOutputMode(IAWG awg, string outputIndex, OutputModeType signalPath)
        {
            string expectedSyntax = "Not Valid Signal Path";
            switch(signalPath)
            {
                case OutputModeType.AC:
                    expectedSyntax = SyntaxForOutputModeAC;
                    break;
                case OutputModeType.Direct:
                    expectedSyntax = SyntaxForOutputModeDirect;
                    break;
            }
            awg.SetOutputMode(outputIndex, expectedSyntax);
        }

        //shkv 12/9/2014 Modified the command to OUTPUT:PATH (Regex exp)
                //jmanning 09/22/2014
        /// <summary>
        /// Using OUTPut[n]:MODE sets the signal path [DIRect|AC]
        /// </summary>
        /// <param name="awg">Object</param>
        /// <param name="outputIndex">Index of output</param>
        /// <param name="signalPath">Signal Path Type of Filter [DIRect|AC]</param>
        public void OutputFilterHardwareInstalled(IAWG awg, bool installed)
        {
            awg.SetOutputMode("1", SyntaxForOutputModeAC);
            string response = awg.SystemErrorQueue();

            // Set a regex to the expected pattern of the '-241, "Hardware Missing;Command requires Option AC....' message
            var responseRegex = new Regex("^-241,\"Hardware missing;Command requires Option AC - OUTPut1:PATH AC\"$");
            Match m = responseRegex.Match(response);
            if (installed)
            {
                if (m.Success)
                    Assert.Inconclusive("AC Filter Hardware Not Installed.  Cannot test" + response);
            }
            else
            {
                if (!(m.Success))
                    Assert.Inconclusive("AC Filter Hardware Installed.  Cannot test" + response);
            }
        }
        #endregion OUTPut[n]:PATH

        #region OUTPut[n]:MODE?
        //jmanning 09/22/2014
        /// <summary>
        /// Using OUTPut[n]:MODE? gets the signal path [DIRect|AC]
        /// </summary>
        /// <param name="awg">Object</param>
        /// <param name="outputIndex">Index of output</param>
        /// <returns> Signal Path Type of Filter [DIRect|AC]</returns>
        public void GetOutputMode(IAWG awg, string outputIndex)
        {
            awg.GetOutputMode(outputIndex);
        }

        //jmanning 09/22/2014
        /// <summary>
        /// Verify the AWG output mode for an expected signal path
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedModeType"></param>
        public void OutputModeTypeShouldBe(IAWG awg, OutputModeType expectedModeType)
        {
            var expectedSyntax = (expectedModeType == OutputModeType.Direct) ? SyntaxForOutputModeDirect : SyntaxForOutputModeAC;
            string possibleErrorString = "Output mode " + awg.OutputModeType + " found not the expected mode of " + expectedSyntax;
            Assert.AreEqual(expectedSyntax, awg.OutputModeType, possibleErrorString);
        }        
        #endregion OUTPut[n]:MODE?
        
        #region OUTPut:OFF

        //glennj 1/7/2014
        /// <summary>
        /// Set the output "off" state for the AWG
        /// </summary>
        /// <param name="awg">Object</param>
        /// <param name="enable">state</param>
        public void SetOutputOffMode(IAWG awg, OutputOffStateMode enable)
        {
            string mode = (enable == OutputOffStateMode.On) ? SyntaxForOutputStateOn : SyntaxForOutputStateOff;
            awg.SetOutputOff(mode);
        }

        //glennj 1/7/2014
        /// <summary>
        /// Force the AWG to update it's output "off" state.
        /// </summary>
        /// <param name="awg"></param>
        public void GetOutputOffMode(IAWG awg)
        {
            awg.GetOutputOff();
        }

        //glennj 1/7/2014
        /// <summary>
        /// Test the AWG output off state for an expected state
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedState"></param>
        public void AllOutputsOffStateShouldBe(IAWG awg, OutputOffStateMode expectedState)
        {
            var expectedSyntax = (expectedState == OutputOffStateMode.On) ? SyntaxForReturnedOutputStateOn : SyntaxForReturnedOutputStateOff;
            const string possibleErrorString = ErrorStringCheckingOutputOffStateForAwg;
            Assert.AreEqual(expectedSyntax, awg.OutputOffState, possibleErrorString);
        }

        #endregion OUTPut:OFF

        #region OUTPut:STATe

        //glennj 1/7/2014
        /// <summary>
        /// Set the output state for a channel for an AWG
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        /// <param name="stateChange"></param>
        public void SetOutputState(IAWG awg, string channel, OutputStateMode stateChange)
        {
            string newState = stateChange == OutputStateMode.On ? SyntaxForOutputStateOn : SyntaxForOutputStateOff;
            awg.SetOutputState(channel, newState);
        }
        
        //glennj 1/7/2014
        /// <summary>
        /// Force the AWG to update it's channel output state for an AWG
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        public void GetOutputState(IAWG awg, string channel)
        {
            awg.GetOutputState(channel);
        }

        //glennj 1/7/2014
        /// <summary>
        /// Verify the AWG's updated state for a channel.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="logicalChannel"></param>
        /// <param name="expectedState"></param>
        public void OutputStateValueShouldBe(IAWG awg, string logicalChannel, OutputStateMode expectedState)
        {
            var expectedSyntax = expectedState == OutputStateMode.On ? SyntaxForReturnedOutputStateOn : SyntaxForReturnedOutputStateOff;

            string outputChannelState = awg.OutputChannelState(logicalChannel);
            string possibleErrorString = ErrorStringCheckingOutputOffStateForChannel + logicalChannel;
            Assert.AreEqual(expectedSyntax, outputChannelState, possibleErrorString);
        }

        #endregion OUTPut:STATe

        #region OUTPut:SVAlue:ANALog:STATe

        //glennj 1/8/2014
        /// <summary>
        /// Set the Stop Value for analog for a channel for an AWG
        /// </summary>
        /// <param name="awg">AWG object</param>
        /// <param name="logicalChannel">logical channel e.g. 1</param>
        /// <param name="state">OutputAnalogStopMode</param>
        public void SetOutputStopAnalogState(IAWG awg, string logicalChannel, OutputAnalogStopMode state)
        {
            string value = (state == OutputAnalogStopMode.Off) ? SyntaxForReturnedOutputStopValueAnalogOff : SyntaxForReturnedOutputStopValueAnalogZero;
            awg.SetOutputStopAnalogState(logicalChannel, value);
        }

        //glennj 1/8/2014
        /// <summary>
        /// Force the AWG to update it's copy of the Stop Value for a channel and awg
        /// </summary>
        /// <param name="awg">AWG object</param>
        /// <param name="logicalChannel">logical channel e.g. 1</param>
        public void GetOutputStopAnalogState(IAWG awg, string logicalChannel)
        {
            awg.GetOutputStopAnalogState(logicalChannel);
        }

        //glennj 1/8/2014
        /// <summary>
        /// Verify the copy of the Stop Value for a channel and awg
        /// </summary>
        /// <param name="awg">AWG object</param>
        /// <param name="logicalChannel">logical channel e.g. 1</param>
        /// <param name="expectedState">OutputAnalogStopMode</param>
        public void OutputStopAnalogStateValueShouldBe(IAWG awg, string logicalChannel, OutputAnalogStopMode expectedState)
        {
            string expectedSyntax = expectedState == OutputAnalogStopMode.Off ? SyntaxForReturnedOutputStopValueAnalogOff : SyntaxForReturnedOutputStopValueAnalogZero;

            string outputChannelStopValueAnalog = awg.OutputStopAnalogState(logicalChannel);
            string possibleErrorString = ErrorStringCheckingOutputStopAnalog + logicalChannel;
            Assert.AreEqual(expectedSyntax, outputChannelStopValueAnalog, possibleErrorString);
        }

        #endregion OUTPut:SVAlue:ANALog:STATe

        #region OUTPut:SVAlue:MARKer

        //glennj 1/8/2014
        /// <summary>
        /// Set the Output Stop state for a marker and for an AWG
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        /// <param name="marker"></param>
        /// <param name="condition"></param>
        public void SetOutputStopMarkerState(IAWG awg, string channel, string marker, OutputMarkerStopMode condition)
        {
            var setCondition = (condition == OutputMarkerStopMode.Off) ? SyntaxForOutputStopValueMarkerOff : SyntaxForOutputStopValueMarkerLow;
            awg.SetOutputStopMarkerState(channel, marker, setCondition);
        }

        //glennj 1/8/2014
        /// <summary>
        /// Have the AWG update it's copy of the Output Stop state for a marker and for an AWG
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        /// <param name="marker"></param>
        public void GetOutputStopMarkerState(IAWG awg, string channel, string marker)
        {
            awg.GetOutputStopMarkerState(channel, marker);
        }

        //glennj 1/8/2014
        /// <summary>
        /// Verify the expected state for the Output Stop state for a marker and for an AWG
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="logicalChannel"></param>
        /// <param name="logicalMarker"></param>
        /// <param name="expectedState"></param>
        public void OutputStopMarkerStateValueShouldBe(IAWG awg, string logicalChannel, string logicalMarker, OutputMarkerStopMode expectedState)
        {
            string expectedSyntax = (expectedState == OutputMarkerStopMode.Off) ? SyntaxForOutputStopValueMarkerOff : SyntaxForOutputStopValueMarkerLow;

            string outputChannelMarkerStopState = awg.OutputStopMarkerState(logicalChannel, logicalMarker);
            string possibleErrorString = ErrorStringCheckingOutputStopMarker + logicalMarker + ErrorStringForChannel + logicalChannel;
            Assert.AreEqual(expectedSyntax, outputChannelMarkerStopState, possibleErrorString);
        }

        #endregion OUTPut:SVAlue:MARKer

        #region OUTPut:WVAlue:ANALog:STATe

        //glennj 1/8/2014
        /// <summary>
        /// Set the output wait (trigger) state for a channel for an AWG
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="logicalChannel"></param>
        /// <param name="state"></param>
        public void SetOutputTriggerAnalogState(IAWG awg, string logicalChannel, OutputAnalogWaitMode state)
        {
            var value = (state == OutputAnalogWaitMode.First) ? SyntaxForOutputWaitValueAnalogFirst : SyntaxForOutputWaitValueAnalogZero;
            awg.SetOutputWaitForValueAnalogState(logicalChannel, value);
        }

        //glennj 1/8/2014
        /// <summary>
        /// Force the AWG to update it's copy of the wait state for a channel
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="logicalChannel"></param>
        public void GetOutputTriggerAnalogState(IAWG awg, string logicalChannel)
        {
            awg.GetOutputWValueAnalogState(logicalChannel);
        }

        //glennj 1/8/2014
        /// <summary>
        /// Verify the copy of the Wait Value for a channel and awg
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="logicalChannel"></param>
        /// <param name="expectedState"></param>
        public void OutputTriggerAnalogStateValueShouldBe(IAWG awg, string logicalChannel, OutputAnalogWaitMode expectedState)
        {
            string expectedSyntax = (expectedState == OutputAnalogWaitMode.First) ? SyntaxForOutputWaitValueAnalogFirst : SyntaxForOutputWaitValueAnalogZero;

            string outputChannelWaitValueAnalog = awg.OutputWaitAnalogState(logicalChannel);
            string possibleErrorString = ErrorStringCheckingOutputWaitAnalog + logicalChannel;
            Assert.AreEqual(expectedSyntax, outputChannelWaitValueAnalog, possibleErrorString);
        }

        #endregion OUTPut:WVAlue:ANALog:STATe

        #region OUTPut:WVAlue:MARKer

        //glennj 1/8/2014
        /// <summary>
        /// Set the wait (for trigger) value for a marker for a channel for an AWG
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        /// <param name="marker"></param>
        /// <param name="state"></param>
        public void SetOutputWaitForTriggerMarkerState(IAWG awg, string channel, string marker, OutputMarkerWaitMode state)
        {
            string expectedSyntax = SyntaxForOutputWaitValueMarkerFirst;

            switch (state)
            {
                case OutputMarkerWaitMode.High:
                    expectedSyntax = SyntaxForOutputWaitValueMarkerHigh;
                    break;
                case OutputMarkerWaitMode.Low:
                    expectedSyntax = SyntaxForOutputWaitValueMarkerLow;
                    break;
            }
            awg.SetOutputWaitForTriggerMarkerState(channel, marker, expectedSyntax);
        }

        //glennj 1/8/2014
        /// <summary>
        /// Force the AWG to update it's copy for the marker wait state for a channel
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="channel"></param>
        /// <param name="marker"></param>
        public void GetOutputWaitForTriggerMarkerState(IAWG awg, string channel, string marker)
        {
            awg.GetOutputTriggerMarkerState(channel, marker);
        }

        //glennj 1/8/2014
        /// <summary>
        /// Verify the expected state for the Output Wait state for a marker for a channel and for an AWG
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="logicalChannel"></param>
        /// <param name="logicalMarker"></param>
        /// <param name="expectedState"></param>
        public void OutputWaitForTriggerMarkerStateValueShouldBe(IAWG awg, string logicalChannel, string logicalMarker, OutputMarkerWaitMode expectedState)
        {
            string expectedSyntax = SyntaxForOutputWaitValueMarkerFirst;

            switch (expectedState)
            {
                case OutputMarkerWaitMode.High:
                    expectedSyntax = SyntaxForOutputWaitValueMarkerHigh;
                    break;
                case OutputMarkerWaitMode.Low:
                    expectedSyntax = SyntaxForOutputWaitValueMarkerLow;
                    break;
            }

            string outputChannelMarkerWaitState = awg.OutputWaitMarkerState(logicalChannel, logicalMarker);
            string possibleErrorString = ErrorStringCheckingOutputWaitMarker + logicalMarker + ErrorStringForChannel + logicalChannel;
            Assert.AreEqual(expectedSyntax, outputChannelMarkerWaitState, possibleErrorString);
        }

        #endregion OUTPut:WVAlue:MARKer
    }
}