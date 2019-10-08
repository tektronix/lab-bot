//==========================================================================
// AwgOutputGroup_steps.cs
// This file contains the low-order PI step definitions for the AWG PI Output Group commands. 
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
// AWG number -  AWG([1-4])
// File path strings - ""(.+)"" used when you want the string that is delimited by the quotes File path strings
//                     \""(.+)\"" used when you want the string that is delimited by the quotes 
//==========================================================================
using TechTalk.SpecFlow;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains the PI step definitions for the %AWG PI Output Group commands.

    /// Generally the steps are set, get and should be operations.  The step sole responsibility
    /// is to make sure the correct %AWG object is used and that parameters such as channel,
    /// markers and clock references are correct for the %AWG object.
    /// 
    /// \ingroup highpi pisteps
    /// </summary>
    [Binding] //Very important! This entry needs to be made in each step definition file.
    public class AwgOutputSteps
    {
        private readonly AwgOutputGroup _awgOutputGroup = new AwgOutputGroup(); // Create the support objects that are needed.
        private readonly UtilitiesGroup _utilitiesGroup = new UtilitiesGroup();
        private readonly AwgSystemGroup _awgSystemGroup = new AwgSystemGroup(); //Used to verify filter hardware

        #region OUTPut[n]:ATTenuator:A1
        /// kaylak 11/14/2014
        /// <summary>
        /// Sets the filter attenuator A1 step value 
        /// </summary>
        /// <param name="stepValue">step value setting</param>
        /// <param name="channelNumber">Which AWG channel 1 or 2</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [When(@"I set the output filter attenuator A1 with a step value of (\d+)) for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the output filter attenuator A1 with a step value of (\d+) for channel ([1-4]) for AWG ([1-4])")]
        public void SetOutputFilterAttnA1StepValue(string stepValue, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.SetOutputFilterAttenuatorA1Step(awg, channelNumber, stepValue);
        }
        #endregion OUTPut[n]:ATTenuator:A1

        #region OUTPut[n]:ATTenuator:A1?
        /// kaylak 11/14/2014
        /// <summary>
        /// Gets the filter attenuator A1 step value
        /// </summary>
        /// <param name="channelNumber">Which AWG channel 1 or 2</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>

        /*!
            \output\verbatim
        [When(@"I get the output filter attenuator A1 step value for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the output filter attenuator A1 step value for channel ([1-4]) for AWG ([1-4])")]
        public void GetOutputFilterAttnA1StepValue(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.GetOutputFilterAttenuatorA1Step(awg, channelNumber);
        }

        /// kaylak 11/14/2014
        /// <summary>
        /// Checks that the output filter attenuator A1 step value versus expected value.
        /// </summary>
        /// <param name="expectedValue">expected step value</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [Then(@"the output filter attenuator A1 step value should be (\d+) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the output filter attenuator A1 step value should be (\d+) for AWG ([1-4])")]
        public void TheOutputFilterAttenuaorA1StepShouldBe(string expectedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgOutputGroup.OutputFilterAttenuatorA1StepShouldBe(awg, expectedValue);
        }
        #endregion OUTPut[n]:ATTenuator:A1?

        #region OUTPut[n]:ATTenuator:A2
        /// kaylak 11/14/2014
        /// <summary>
        /// Sets the filter attenuator A2 step value 
        /// </summary>
        /// <param name="stepValue">step value setting</param>
        /// <param name="channelNumber">Which AWG channel 1 or 2</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [When(@"I set the output filter attenuator A2 with a step value of (\d+)) for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the output filter attenuator A2 with a step value of (\d+) for channel ([1-4]) for AWG ([1-4])")]
        public void SetOutputFilterAttnA2StepValue(string stepValue, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.SetOutputFilterAttenuatorA2Step(awg, channelNumber, stepValue);
        }
        #endregion OUTPut[n]:ATTenuator:A2

        #region OUTPut[n]:ATTenuator:A2?
        /// kaylak 11/14/2014
        /// <summary>
        /// Gets the filter attenuator A2 step value
        /// </summary>
        /// <param name="channelNumber">Which AWG channel 1 or 2</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>

        /*!
            \output\verbatim
        [When(@"I get the output filter attenuator A2 step value for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the output filter attenuator A2 step value for channel ([1-4]) for AWG ([1-4])")]
        public void GetOutputFilterAttnA2StepValue(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.GetOutputFilterAttenuatorA2Step(awg, channelNumber);
        }

        /// kaylak 11/14/2014
        /// <summary>
        /// Checks that the output filter attenuator A2 step value versus expected value.
        /// </summary>
        /// <param name="expectedValue">expected step value</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [Then(@"the output filter attenuator A2 step value should be (\d+) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the output filter attenuator A2 step value should be (\d+) for AWG ([1-4])")]
        public void TheOutputFilterAttenuaorA2StepShouldBe(string expectedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgOutputGroup.OutputFilterAttenuatorA2StepShouldBe(awg, expectedValue);
        }
        #endregion OUTPut[n]:ATTenuator:A2?

        #region OUTPut[n]:ATTenuator:A3
        /// kaylak 11/14/2014
        /// <summary>
        /// Sets the filter attenuator A3 step value 
        /// </summary>
        /// <param name="stepValue">step value setting</param>
        /// <param name="channelNumber">Which AWG channel 1 or 2</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [When(@"I set the output filter attenuator A3 with a step value of (\d+)) for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the output filter attenuator A3 with a step value of (\d+) for channel ([1-4]) for AWG ([1-4])")]
        public void SetOutputFilterAttnA3StepValue(string stepValue, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.SetOutputFilterAttenuatorA3Step(awg, channelNumber, stepValue);
        }
        #endregion OUTPut[n]:ATTenuator:A3

        #region OUTPut[n]:ATTenuator:A3?
        /// kaylak 11/14/2014
        /// <summary>
        /// Gets the filter attenuator A3 step value
        /// </summary>
        /// <param name="channelNumber">Which AWG channel 1 or 2</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>

        /*!
            \output\verbatim
        [When(@"I get the output filter attenuator A3 step value for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the output filter attenuator A3 step value for channel ([1-4]) for AWG ([1-4])")]
        public void GetOutputFilterAttnA3StepValue(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.GetOutputFilterAttenuatorA3Step(awg, channelNumber);
        }

        /// kaylak 11/14/2014
        /// <summary>
        /// Checks that the output filter attenuator A3 step value versus expected value.
        /// </summary>
        /// <param name="expectedValue">expected step value</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [Then(@"the output filter attenuator A3 step value should be (\d+) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the output filter attenuator A3 step value should be (\d+) for AWG ([1-4])")]
        public void TheOutputFilterAttenuaorA3StepShouldBe(string expectedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgOutputGroup.OutputFilterAttenuatorA3StepShouldBe(awg, expectedValue);
        }
        #endregion OUTPut[n]:ATTenuator:A3?

        #region OUTPut[n]:ATTenuator:DAC
        //shkv 12/3/2014 Modified the regular expression as DAC values are -ve values in dbm
        /// kaylak 11/14/2014
        /// <summary>
        /// Sets the filter attenuator DAC step value 
        /// </summary>
        /// <param name="stepValue">step value setting</param>
        /// <param name="channelNumber">Which AWG channel 1 or 2</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [When(@"I set the output filter attenuator DAC with a step value of (\d+)) for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the output filter attenuator DAC with a step value of ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for channel ([1-4]) for AWG ([1-4])")]
        public void SetOutputFilterAttnDACStepValue(string stepValue, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.SetOutputFilterAttenuatorDACStep(awg, channelNumber, stepValue);
        }
        #endregion OUTPut[n]:ATTenuator:DAC

        #region OUTPut[n]:ATTenuator:DAC?
        /// kaylak 11/14/2014
        /// <summary>
        /// Gets the filter attenuator DAC step value
        /// </summary>
        /// <param name="channelNumber">Which AWG channel 1 or 2</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>

        /*!
            \output\verbatim
        [When(@"I get the output filter attenuator DAC step value for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the output filter attenuator DAC step value for channel ([1-4]) for AWG ([1-4])")]
        public void GetOutputFilterAttnDACStepValue(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.GetOutputFilterAttenuatorDACStep(awg, channelNumber);
        }
       //shkv 12/3/2014 Modified the regular expression
        /// kaylak 11/14/2014
        /// <summary>
        /// Checks that the output filter attenuator DAC step value versus expected value.
        /// </summary>
        /// <param name="expectedValue">expected step value</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [Then(@"the output filter attenuator DAC step value should be (\d+) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the output filter attenuator DAC step value should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for AWG ([1-4])")]
        public void TheOutputFilterAttenuaorDACStepShouldBe(string expectedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgOutputGroup.OutputFilterAttenuatorDACStepShouldBe(awg, expectedValue);
        }
        #endregion OUTPut[n]:ATTenuator:DAC?

        #region OUTPut[n]:FILTer
        //jmanning 09/22/2014
        /// <summary>
        /// Sets the filter to Band Pass for the specified output
        /// </summary>
        /// <param name="channelNumber">Which AWG channel 1 or 2</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [When(@"I set the output filter type to Band Pass for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the output filter type to band pass for channel ([1-4]) for AWG ([1-4])")]
        public void SetOutputFilterForChannelToBandPass(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.SetOutputFilter(awg, channelNumber, AwgOutputGroup.OutputFilterType.BandPass);
        }

        //jmanning 09/22/2014
        /// <summary>
        /// Sets the filter to low pass for the specified output
        /// </summary>
        /// <param name="channelNumber">Which AWG channel 1 or 2</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [When(@"I set the output filter type to low pass for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the output filter type to low pass for channel ([1-4]) for AWG ([1-4])")]
        public void SetOutputFilterForChannelToLowPass(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.SetOutputFilter(awg, channelNumber, AwgOutputGroup.OutputFilterType.LowPass);
        }
        
        //jmanning 09/22/2014
        /// <summary>
        /// Sets the filter to none for the specified output
        /// </summary>
        /// <param name="channelNumber">Which AWG channel 1 or 2</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [When(@"I set the output filter type to none for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the output filter type to none for channel ([1-4]) for AWG ([1-4])")]
        public void SetOutputFilterForChannelToNone(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.SetOutputFilter(awg, channelNumber, AwgOutputGroup.OutputFilterType.None);
        }
        #endregion OUTPut[n]:FILTer

        #region OUTPut[n]:FILTer?
        //jmanning 09/23/2014
        /// <summary>
        /// Using OUTPut[n]:FILTer? gets the filter type of the selected output
        /// </summary>  
        /// <param name="channelNumber">Which AWG channel 1 or 2</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [When(@"I get the output filter type for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the output filter type for channel ([1-4]) for AWG ([1-4])")]
        public void GetAllOutputsOffState(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.GetOutputFilter(awg, channelNumber);
        }
        //shkv 1/8/2015 Modified to add channel parameter
        //jmanning 09/23/2014
        /// <summary>
        /// Check that the output filter type versus expected filter type BandPass.
        /// </summary>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [Then(@"the output filter type should be Band Pass for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the output filter type should be band pass for channel ([1-4]) for AWG ([1-4])")]
        public void TheOutputFilterTypeShouldBeBandPass(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.OutputFilterTypeShouldBe(awg, AwgOutputGroup.OutputFilterType.BandPass);
        }
        //shkv 1/8/2015 Modified to add channel parameter
        //jmanning 09/23/2014
        /// <summary>
        /// Check that the output filter type versus expected filter type lowpass.
        /// </summary>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [Then(@"the output filter type should be low pass for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the output filter type should be low pass for channel ([1-4]) for AWG ([1-4])")]
        public void TheOutputFilterTypeShouldBeLowPass(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.OutputFilterTypeShouldBe(awg, AwgOutputGroup.OutputFilterType.LowPass);
        }
        //shkv 1/8/2015 Modified to add channel parameter
        //jmanning 09/23/2014
        /// <summary>
        /// Check that the output filter type versus expected filter type none.
        /// </summary>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [Then(@"the output filter type should be none for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the output filter type should be none for channel ([1-4]) for AWG ([1-4])")]
        public void TheOutputFilterTypeShouldBeNone(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.OutputFilterTypeShouldBe(awg, AwgOutputGroup.OutputFilterType.None);
        }
        #endregion OUTPut[n]:FILTer?

        #region OUTPut[n]:FILTer:BPASs:RANGe
        //shkv 1/8/2015 Fix for 5168 as regular expression does not work for or conditions
        /// kayla 11/14/2014
        /// <summary>
        /// Sets the filter path for the specified output
        /// </summary>
        /// <param name="range">Output filter range</param>
        /// <param name="channelNumber">Which AWG channel 1 or 2</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [When(@"I set the output filter band pass range to ([R10to14GHz|R13to18GHz]) for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the output filter band pass range to R10to14GHz for channel ([1-4]) for AWG ([1-4])")]
        public void SetOutputFilterBandPassRangeR10to14GHz(string channelNumber, string awgNumber)
        {
            AwgOutputGroup.OutputFilterBandPassRange expectedRange = AwgOutputGroup.OutputFilterBandPassRange.R10to14GHz;
            expectedRange = AwgOutputGroup.OutputFilterBandPassRange.R10to14GHz;
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.SetOutputFilterBandPassRangeR10to14GHz(awg, channelNumber, expectedRange);
        }

        [When(@"I set the output filter band pass range to R13to18GHz for channel ([1-4]) for AWG ([1-4])")]
        public void SetOutputFilterBandPassRangeR13to18GHz(string channelNumber, string awgNumber)
        {
            AwgOutputGroup.OutputFilterBandPassRange expectedRange = AwgOutputGroup.OutputFilterBandPassRange.R10to14GHz;
            expectedRange = AwgOutputGroup.OutputFilterBandPassRange.R13to18GHz;
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.SetOutputFilterBandPassRangeR13to18GHz(awg, channelNumber, expectedRange);
        }
        #endregion OUTPut[n]:FILTer:BPASs:RANGe

        #region OUTPut[n]:FILTer:BPASs:RANGe?
        /// kaylak 11/14/2014
        /// <summary>
        /// Gets the physical path for the filter attenuator for the specified output
        /// </summary>  
        /// <param name="channelNumber">Which AWG channel 1 or 2</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [When(@"I get the output filter band pass range for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the output filter band pass range for channel ([1-4]) for AWG ([1-4])")]
        public void GetOutputsFilterPath(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.GetOutputFilterBandPassRange(awg, channelNumber);
        }
        //shkv 1/8/2015 Added fix for 5168
        /// kaylak 11/14/2014
        /// <summary>
        /// Check that the output filter type versus expected filter type BandPass.
        /// </summary>
        /// <param name="channelNumber">Which AWG channel 1 or 2</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /// <param name="range">bandwidth range of filter</param>
        /*!
            \output\verbatim
        [Then(@"the output filter band pass range should be 10to14GHz for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the output filter path should be R10TO14GHZ for channel ([1-4]) for AWG ([1-4])")]
        public void TheOutputFilterBandPassRangeShouldBeR10to14GHz(string channelNumber, string awgNumber)
        {
            AwgOutputGroup.OutputFilterBandPassRange expectedRange = AwgOutputGroup.OutputFilterBandPassRange.R10to14GHz;

            expectedRange = AwgOutputGroup.OutputFilterBandPassRange.R10to14GHz;


            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.OutputFilterBandPassRangeShouldBeR10to14GHz(awg, expectedRange);
        }
        [Then(@"the output filter path should be R13TO18GHZ for channel ([1-4]) for AWG ([1-4])")]
        public void TheOutputFilterBandPassRangeShouldBeR13to18GHz(string channelNumber, string awgNumber)
        {
            AwgOutputGroup.OutputFilterBandPassRange expectedRange = AwgOutputGroup.OutputFilterBandPassRange.R10to14GHz;

            expectedRange = AwgOutputGroup.OutputFilterBandPassRange.R13to18GHz;

            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.OutputFilterBandPassRangeShouldBeR13to18GHz(awg, expectedRange);
        }
        #endregion OUTPut[n]:FILTer:BPASs:RANGe?

        #region OUTPut[n]:MODE
        //jmanning 09/22/2014
        /// <summary>
        /// Sets the sets the signal path [DIRect|AC]
        /// </summary>
        /// <param name="channelNumber">Which AWG channel 1 or 2</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [When(@"I set the output signal path mode to AC for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the output signal path mode to AC for channel ([1-4]) for AWG ([1-4])")]
        public void SetOutputModeForChannelToAC(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.SetOutputMode(awg, channelNumber, AwgOutputGroup.OutputModeType.AC);
        }

        //jmanning 09/22/2014
        /// <summary>
        /// Checks to see if AC hardware is installed on the AWG
        /// </summary>
        /// <param name="channelNumber">Which AWG channel 1 or 2</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [Given(@"the AC hardware is installed for AWG ([1-4])")]
            \endverbatim 
        */
        [Given(@"the AC hardware is installed for AWG ([1-4])")]
        public void CheckForACHardwareInstalled(string awgNumber)
        {
            bool installed = true;
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgOutputGroup.OutputFilterHardwareInstalled(awg, installed);
        }

        //jmanning 09/22/2014
        /// <summary>
        /// Checks to see if AC hardware is not installed on the AWG
        /// </summary>
        /// <param name="channelNumber">Which AWG channel 1 or 2</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [Given(@"the AC hardware is not installed for AWG ([1-4])")]
            \endverbatim 
        */
        [Given(@"the AC hardware is not installed for AWG ([1-4])")]
        public void CheckForACHardwareNotInstalled(string awgNumber)
        {
            bool notInstalled = false;
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgOutputGroup.OutputFilterHardwareInstalled(awg, notInstalled);
        }

        //jmanning 09/22/2014
        /// <summary>
        /// Sets the sets the signal path [DIRect|AC]
        /// </summary>
        /// <param name="channelNumber">Which AWG channel 1 or 2</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [When(@"I set the output signal path mode to direct for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the output signal path mode to direct for channel ([1-4]) for AWG ([1-4])")]
        public void SetOutputModeForChannelToDirect(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.SetOutputMode(awg, channelNumber, AwgOutputGroup.OutputModeType.Direct);
        }
        #endregion OUTPut[n]:MODE

        #region OUTPut[n]:MODE?
        //jmanning 09/23/2014
        /// <summary>
        /// Using OUTPut[n]:MODE? gets the signal path [DIRect|AC] for the selected output
        /// </summary>  
        /// <param name="channelNumber">Which AWG channel 1 or 2</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [When(@"I get the output mode for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the output mode for channel ([1-4]) for AWG ([1-4])")]
        public void GetOutputModeType(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.GetOutputMode(awg, channelNumber);
        }

        //jmanning 09/23/2014
        /// <summary>
        /// Check that the output mode type versus expected mode type AC.
        /// </summary>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [Then(@"the output mode type should be AC for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the output mode type should be AC for AWG ([1-4])")]
        public void TheOutputModeTypeShouldBeAC(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgOutputGroup.OutputModeTypeShouldBe(awg, AwgOutputGroup.OutputModeType.AC);
        }

        //jmanning 09/23/2014
        /// <summary>
        /// Check that the output mode type versus expected mode type direct.
        /// </summary>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [Then(@"the output mode type should be direct for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the output mode type should be direct for AWG ([1-4])")]
        public void TheOutputModeTypeShouldBeDirect(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgOutputGroup.OutputModeTypeShouldBe(awg, AwgOutputGroup.OutputModeType.Direct);
        }   
        #endregion OUTPut[n]:MODE?
        
        #region OUTPut:OFF

        //glennj 7/15/2013
        /// <summary>
        /// Using OUTPut:OFF set the "All Outputs Off" to on
        /// </summary>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
			\output\verbatim
		[When(@"I set the output state to on for all channels for AWG ([1-4])")]
			\endverbatim 
		*/
        [When(@"I set the output state to on for all channels for AWG ([1-4])")]
        public void SetAllOutputsOffStateToOn(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgOutputGroup.SetOutputOffMode(awg, AwgOutputGroup.OutputOffStateMode.On);
        }

        //glennj 7/15/2013
        /// <summary>
        /// Using OUTPut:OFF set the "All Outputs Off" to off
        /// </summary>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
			\output\verbatim
		[When(@"I set the output state to off for all channels for AWG ([1-4])")]
			\endverbatim 
		*/
        [When(@"I set the output state to off for all channels for AWG ([1-4])")]
        public void SetAllOutputsOffStateToOff(string awgNumber)
        { 
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgOutputGroup.SetOutputOffMode(awg, AwgOutputGroup.OutputOffStateMode.Off);
        }

        //glennj 7/15/2013
        /// <summary>
        /// Using OUTPut:OFF?, force the AWG to update its copy of "All Outputs Off" mode
        /// </summary>  
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [When(@"I get the output state for all channels on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the output state for all channels on AWG ([1-4])")]
        public void GetAllOutputsOffState(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgOutputGroup.GetOutputOffMode(awg);
        }

        //glennj 7/15/2013
        /// <summary>
        /// Checks to see if the AWG all outputs off state is enable (ON).
        /// </summary>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
			\output\verbatim
		[Then(@"the output state should be on for all channels for AWG ([1-4])")]
			\endverbatim 
		*/
        [Then(@"the output state should be on for all channels for AWG ([1-4])")]
        public void ThenAllOutputsOffStateShouldBeOn(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgOutputGroup.AllOutputsOffStateShouldBe(awg, AwgOutputGroup.OutputOffStateMode.On);
        }

        //glennj 7/15/2013
        /// <summary>
        /// Checks to see if the AWG all outputs off state is disable (OFF).
        /// </summary>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
			\output\verbatim
		[Then(@"the output state should be off for all channels for AWG ([1-4])")]
			\endverbatim 
		*/
        [Then(@"the output state should be off for all channels for AWG ([1-4])")]
        public void ThenAllOutputsOffStateShouldBeOff(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgOutputGroup.AllOutputsOffStateShouldBe(awg, AwgOutputGroup.OutputOffStateMode.Off);
        }

        #endregion OUTPut:OFF

        #region OUTPut:STATe

        //glennj 7/12/2013
        /// <summary>
        /// Turns on the output state of a AWG's channel
        /// </summary>
        /// <param name="channelNumber">Which AWG channel 1 or 2</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [When(@"I set the output state to on for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the output state to on for channel ([1-4]) for AWG ([1-4])")]
        public void SetOutputStateForChannelToOn(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.SetOutputState(awg, channelNumber, AwgOutputGroup.OutputStateMode.On);
        }

        //glennj 7/12/2013
        /// <summary>
        /// Turns off the output state of a AWG's channel
        /// </summary>
        /// <param name="channelNumber">Which AWG channel 1 or 2</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [When(@"I set the output state to off for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the output state to off for channel ([1-4]) for AWG ([1-4])")]
        public void SetOutputStateForChannelToOff(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.SetOutputState(awg, channelNumber, AwgOutputGroup.OutputStateMode.Off);
        }

        //glennj 7/15/2013
        /// <summary>
        /// Forces the AWG to update its local copy of the output state<para>
        /// NOTE: In the case of channel selection, it's necessary to violate our low-order rules a bit because we will</para> 
        /// run into problems assigning values to proper accessors.@n
        /// OUTPut[n][:STATe](?)
        /// </summary>
        /// <param name="channelNumber">Which AWG channel 1 or 2</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [When(@"I get the output state for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the output state for channel ([1-4]) for AWG ([1-4])")]
        public void GetOutputStateForChannel(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.GetOutputState(awg, channelNumber);
        }

        //glennj 7/15/2013
        /// <summary>
        /// Tests the output state of the given AWG and channel for on
        /// </summary>
        /// <param name="channelNumber">Which AWG channel 1 or 2</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [Then(@"the output state should be on for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the output state should be on for channel ([1-4]) for AWG ([1-4])")]
        public void TheAwgOutputStateValueShouldBeOn(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.OutputStateValueShouldBe(awg, channelNumber, AwgOutputGroup.OutputStateMode.On);
        }

        //glennj 7/15/2013
        /// <summary>
        /// Tests the output state of the given AWG and channel for off
        /// </summary>
        /// <param name="channelNumber">Which AWG channel 1 or 2</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [Then(@"the output state should be off for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the output state should be off for channel ([1-4]) for AWG ([1-4])")]
        public void TheAwgOutputStateValueShouldBeOff(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.OutputStateValueShouldBe(awg, channelNumber, AwgOutputGroup.OutputStateMode.Off);
        }

        #endregion Exercise OUTPut:STATe

        #region OUTPut:SVALue:ANALog:STATe

        //glennj 7/15/2013
        /// <summary>
        /// Using OUTPut:SVALue:ANAlog:STATe sets the output data position<para>
        /// of a waveform while the instrument is in the stopped state to off.</para>
        /// <para>
        /// NOTE: This is valid only when the Run Mode is Triggered or Gated.@n</para>
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [When(@"I set the analog output stop condition to off for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the analog output stop condition to off for channel ([1-4]) for AWG ([1-4])")]
        public void SetAnalogOutputStopStateForChannelToOff(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.SetOutputStopAnalogState(awg, channelNumber, AwgOutputGroup.OutputAnalogStopMode.Off);
        }

        //glennj 7/15/2013
        /// <summary>
        /// Using OUTPut:SVALue:ANAlog:STATe sets the output data position<para>
        /// of a waveform while the instrument is in the stopped state to zero.</para>
        /// <para>
        /// NOTE: This is valid only when the Run Mode is Triggered or Gated.@n</para>
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [When(@"I set the analog output stop condition to zero volts for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the analog output stop condition to zero volts for channel ([1-4]) for AWG ([1-4])")]
        public void SetAnalogOutputStopStateForChannelToZero(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.SetOutputStopAnalogState(awg, channelNumber, AwgOutputGroup.OutputAnalogStopMode.Zero);
        }

        //glennj 7/12/2013
        /// <summary>
        /// Using OUTPut:SVALue:ANAlog:STATe? forcee the AWG to update it local copy of<para>
        /// the output data position of a waveform while the instrument is in the stop state</para>
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [When(@"I get the analog output stop condition for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the analog output stop condition for channel ([1-4]) for AWG ([1-4])")]
        public void GetAnalogOutputStopStateForChannel(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.GetOutputStopAnalogState(awg, channelNumber);
        }

        //glennj 7/12/2013
        /// <summary>
        /// Check that the output stop state data position of a waveform is off.
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [Then(@"the analog output stop condition should be off for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the analog output stop condition should be off for channel ([1-4]) for AWG ([1-4])")]
        public void TheOutputStopAnalogStateValueShouldBeOff(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.OutputStopAnalogStateValueShouldBe(awg, channelNumber, AwgOutputGroup.OutputAnalogStopMode.Off);
        }

        //glennj 7/12/2013
        /// <summary>
        /// Check that the output stop state data position of a waveform is zero.
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [Then(@"the analog output stop condition should be zero volts for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the analog output stop condition should be zero volts for channel ([1-4]) for AWG ([1-4])")]
        public void TheOutputStopAnalogStateValueShouldBeZero(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.OutputStopAnalogStateValueShouldBe(awg, channelNumber, AwgOutputGroup.OutputAnalogStopMode.Zero);
        }

        #endregion OUTPut:SVALue:ANALog:STATe

        #region OUTPut:SVALue:MARKer

        //glennj 7/12/2013
        /// <summary>
        /// Sets the output data position off for specified marker while the instrument is in the stopped state
        /// 
        /// NOTE: This is valid only when the Run Mode is Triggered or Gated.@n
        /// OUTPut[n]:SVALue:MARKer
        /// </summary>
        /// <param name="marker">Which Marker</param>
        /// <param name="channelNumber">Which Channel</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
           \output\verbatim
        [When(@"I set the marker output stop condition to off for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the marker output stop condition to off for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
        public void SetMarkerOutputStopConditionChannelMarkerOff(string marker, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, marker);
            _awgOutputGroup.SetOutputStopMarkerState(awg, channelNumber, marker, AwgOutputGroup.OutputMarkerStopMode.Off);
        }

        //glennj 7/12/2013
        /// <summary>
        /// Sets the output data position to zero for specified marker while the instrument is in the stopped state
        /// 
        /// NOTE: This is valid only when the Run Mode is Triggered or Gated.@n
        /// OUTPut[n]:SVALue:MARKer
        /// </summary>
        /// <param name="marker">Which Marker</param>
        /// <param name="channelNumber">Which Channel</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
           \output\verbatim
        [When(@"I set the marker output stop condition to zero volts for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the marker output stop condition to zero volts for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
        public void SetMarkerOutputStopConditionChannelMarkerZero(string marker, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, marker);
            _awgOutputGroup.SetOutputStopMarkerState(awg, channelNumber, marker, AwgOutputGroup.OutputMarkerStopMode.Low);
        }

        //glennj 7/12/2013
        /// <summary>
        /// Forces the AWG to update it's local copy of the output data position of a<para>
        /// marker while the instrument is in the stop state</para>
        /// 
        /// NOTE: This is valid only when the Run Mode is Triggered or Gated.@n
        /// OUTPut[n]:SVALue:MARKer
        /// </summary>
        /// <param name="marker">Which marker</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
           \output\verbatim
        [When(@"I get the marker output stop condition for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I get the marker output stop condition for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
        public void GetMarkerOutputStopConditionChannelMarker(string marker, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, marker);
            _awgOutputGroup.GetOutputStopMarkerState(awg, channelNumber, marker);
        }

        //glennj 7/12/2013
        /// <summary>
        /// Checks to see that output data position is off for a specified marker while the instrument is in stop state.
        /// 
        /// OUTPut[n]:SVALue:MARKer
        /// </summary>
        /// <param name="marker">Which marker</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
           \output\verbatim
        [Then(@"the marker output stop condition should be off for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
        */
        [Then(@"the marker output stop condition should be off for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
        public void OutputStopMarkerStateValueShouldBeOff(string marker, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, marker);
            _awgOutputGroup.OutputStopMarkerStateValueShouldBe(awg, channelNumber, marker, AwgOutputGroup.OutputMarkerStopMode.Off);
        }

        //glennj 7/12/2013
        /// <summary>
        /// Checks to see that output data position is off for a specified marker while the instrument is in stop state.
        /// 
        /// OUTPut[n]:SVALue:MARKer
        /// </summary>
        /// <param name="marker">Which marker</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
           \output\verbatim
        [Then(@"the marker output stop condition should be zero volts for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
        */
        [Then(@"the marker output stop condition should be zero volts for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
        public void OutputStopMarkerStateValueShouldBeLow(string marker, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, marker);
            _awgOutputGroup.OutputStopMarkerStateValueShouldBe(awg, channelNumber, marker, AwgOutputGroup.OutputMarkerStopMode.Low);
        }

        #endregion OUTPut:SVALue:MARKer

        #region  OUTPut:WVALue:ANALog:STATe

        //glennj 7/15/2013
        /// <summary>
        /// Sets the output data position of a waveform while the instrument is in the waiting-for-trigger state to first
        /// 
        /// NOTE: This is valid only when the Run Mode is Triggered or Gated.@n
        /// 
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [When(@"I set the analog output wait condition to first point in waveform for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the analog output wait condition to first point in waveform for channel ([1-4]) for AWG ([1-4])")]
        public void SetAnalogOutputWaitForTriggerStateForChannelToFirst(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.SetOutputTriggerAnalogState(awg, channelNumber, AwgOutputGroup.OutputAnalogWaitMode.First);
        }

        //glennj 7/15/2013
        /// <summary>
        /// Sets the output data position of a waveform while the instrument is in the waiting-for-trigger state to zero
        /// 
        /// NOTE: This is valid only when the Run Mode is Triggered or Gated.@n
        /// 
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [When(@"I set the analog output wait condition to zero volts for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the analog output wait condition to zero volts for channel ([1-4]) for AWG ([1-4])")]
        public void SetAnalogOutputWaitForTriggerStateForChannelToZero(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.SetOutputTriggerAnalogState(awg, channelNumber, AwgOutputGroup.OutputAnalogWaitMode.Zero);
        }

        //glennj 7/15/2013
        /// <summary>
        /// Gets the output data position of a waveform while the instrument is in the waiting-for-trigger state
        /// 
        /// NOTE: This is valid only when the Run Mode is Triggered or Gated.@n
        /// OUTPut[n]:WVALue[:ANALog][:STATe]
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [When(@"I get the analog output wait condition for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the analog output wait condition for channel ([1-4]) for AWG ([1-4])")]
        public void GetAnalogOutputWaitForTriggerStateForChannel(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgOutputGroup.GetOutputTriggerAnalogState(awg, channelNumber);
        }

        //glennj 7/15/2013
        /// <summary>
        /// Verify the output waiting-for-trigger data position of a waveform is first.
        /// 
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [Then(@"the analog output wait condition should be first point in waveform for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the analog output wait condition should be first point in waveform for channel ([1-4]) for AWG ([1-4])")]
        public void TheOutputTriggerAnalogStateValueShouldBeFirst(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.OutputTriggerAnalogStateValueShouldBe(awg, channelNumber, AwgOutputGroup.OutputAnalogWaitMode.First);
        }

        //glennj 7/15/2013
        /// <summary>
        /// Verify the output waiting-for-trigger data position of a waveform is zero.
        /// 
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [Then(@"the analog output wait condition should be zero volts for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the analog output wait condition should be zero volts for channel ([1-4]) for AWG ([1-4])")]
        public void TheOutputTriggerAnalogStateValueShouldBeZero(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgOutputGroup.OutputTriggerAnalogStateValueShouldBe(awg, channelNumber, AwgOutputGroup.OutputAnalogWaitMode.Zero);
        }

        #endregion  OUTPut:WVALue:ANALog:STATe

        #region OUTPut:WVALue:MARKer

        //glennj 7/16/2013
        /// <summary>
        /// Using OUTPut:WVALue:MARKer:STATe sets the output state of a marker<para>
        /// when the instrument is in the waiting-for-trigger state to First.</para>
        /// 
        /// NOTE: This is valid only when the Run Mode is Triggered or Gated.@n
        /// 
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="marker">Which marker</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [When(@"I set the marker output wait condition to first point in waveform for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the marker output wait condition to first point in waveform for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
        public void SetMarkerOutputWaitForTriggerStateForChannelToFirst(string marker, string channelNumber, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, marker);
            _awgOutputGroup.SetOutputWaitForTriggerMarkerState(awg, channelNumber, marker, AwgOutputGroup.OutputMarkerWaitMode.First);
        }

        //glennj 7/16/2013
        /// <summary>
        /// Using OUTPut:WVALue:MARKer:STATe sets the output state of a marker<para>
        /// when the instrument is in the waiting-for-trigger state to High.</para>
        /// 
        /// NOTE: This is valid only when the Run Mode is Triggered or Gated.@n
        /// 
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="marker">Which marker</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [When(@"I set the marker output wait condition to logic high for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the marker output wait condition to logic high for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
        public void SetMarkerOutputWaitForTriggerStateForChannelToHigh(string marker, string channelNumber, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, marker);
            _awgOutputGroup.SetOutputWaitForTriggerMarkerState(awg, channelNumber, marker, AwgOutputGroup.OutputMarkerWaitMode.High);
        }

        //glennj 7/16/2013
        /// <summary>
        /// Using OUTPut:WVALue:MARKer:STATe sets the output state of a marker<para>
        /// when the instrument is in the waiting-for-trigger state to Low.</para>
        /// 
        /// NOTE: This is valid only when the Run Mode is Triggered or Gated.@n
        /// 
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="marker">Which marker</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [When(@"I set the marker output wait condition to logic low for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the marker output wait condition to logic low for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
        public void SetMarkerOutputWaitForTriggerStateForChannelToLow(string marker, string channelNumber, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, marker);
            _awgOutputGroup.SetOutputWaitForTriggerMarkerState(awg, channelNumber, marker, AwgOutputGroup.OutputMarkerWaitMode.Low);
        }

        //glennj 7/16/2013
        /// <summary>
        /// Using OUTPut:WVALue:MARKer:STATe? force the AWG to update its local copy of the output data position<para>
        /// of a marker while the instrument is in the waiting-for-trigger state</para>
        /// 
        /// NOTE: This is valid only when the Run Mode is Triggered or Gated.@n
        /// 
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="marker">Which marker</param>
        /// <param name="awgNumber">1 of 4 AWGs</param>
        /*!
            \output\verbatim
        [When(@"I get the marker output wait condition for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the marker output wait condition for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
        public void SetMarkerOutputWaitForTriggerStateForChannel(string marker, string channelNumber, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, marker);
            _awgOutputGroup.GetOutputWaitForTriggerMarkerState(awg, channelNumber, marker);
        }

        //glennj 7/16/2013
        /// <summary>
        /// Verify the output data wait for trigger state of a marker for an expected value First
        /// </summary>
        /// <param name="channelNumber">The channel</param>
        /// <param name="marker">The marker</param>
        /// <param name="awgNumber">The awg</param>
        /*!
          \output\verbatim
        [Then(@"the marker output wait condition should be first point in waveform for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
          \endverbatim 
       */
        [Then(@"the marker output wait condition should be first point in waveform for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
        public void OutputTriggerMarkerStateValueShouldBeFirst(string marker, string channelNumber, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, marker);
            _awgOutputGroup.OutputWaitForTriggerMarkerStateValueShouldBe(awg, channelNumber, marker, AwgOutputGroup.OutputMarkerWaitMode.First);
        }

        //glennj 7/16/2013
        /// <summary>
        /// Verify the output data wait for trigger state of a marker for an expected value High
        /// </summary>
        /// <param name="channelNumber">The channel</param>
        /// <param name="marker">The marker</param>
        /// <param name="awgNumber">The awg</param>
        /*!
          \output\verbatim
        [Then(@"the marker output wait condition should be logic high for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
          \endverbatim 
       */
        [Then(@"the marker output wait condition should be logic high for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
        public void OutputTriggerMarkerStateValueShouldBeHigh(string marker, string channelNumber, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, marker);
            _awgOutputGroup.OutputWaitForTriggerMarkerStateValueShouldBe(awg, channelNumber, marker, AwgOutputGroup.OutputMarkerWaitMode.High);
        }

        //glennj 7/16/2013
        /// <summary>
        /// Verify the output data wait for trigger state of a marker for an expected value Low
        /// </summary>
        /// <param name="channelNumber">The channel</param>
        /// <param name="marker">The marker</param>
        /// <param name="awgNumber">The awg</param>
        /*!
          \output\verbatim
        [Then(@"the marker output wait condition should be logic low for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
          \endverbatim 
       */
        [Then(@"the marker output wait condition should be logic low for marker ([1-4]) for channel ([1-4]) for AWG ([1-4])")]
        public void OutputTriggerMarkerStateValueShouldBeLow(string marker, string channelNumber, string awgNumber)
        {
            var awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber, marker);
            _awgOutputGroup.OutputWaitForTriggerMarkerStateValueShouldBe(awg, channelNumber, marker, AwgOutputGroup.OutputMarkerWaitMode.Low);
        }

        #endregion OUTPut:WVALue:MARKer

	}
}
