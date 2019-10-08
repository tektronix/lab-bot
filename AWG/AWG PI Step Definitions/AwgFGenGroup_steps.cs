//==========================================================================
// AwgFGenGroup_steps.cs  
// This file contains thePI step definitions for the AWG function generator group PI commands. 
//
// PLEASE use the following regular expressions to match specified numeric formats and other values:
// <NR1> - ((?<!\S)[-+]?\d+(?!\S))
// <NR3> - ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?|MAX|MIN) for a SET operation
//       - ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for a GET or SHOULD BE operation
// AWG number - AWG OR NO MATCHER FOR DEFAULT AWG
// Channel - ([1-4]) Yes, they are only two channels now...but a future 5k will have four.
// File path strings - ""(.+)"" used when you want the string that is delimited by the quotes.
//                     use for File path strings and strings that may contain spaces.
//==========================================================================

using TechTalk.SpecFlow;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains the PI step definitions for the %AWG PI Function Generator Group commands.

    /// Generally the steps are set, get and should be operations.  The step sole responsibility
    /// is to make sure the correct %AWG object is used and that parameters such as channel,
    /// markers and clock references are correct for the %AWG object.
    /// 
    /// \ingroup highpi pisteps
    /// 
    /// </summary>
    [Binding] //Very important! This entry needs to be made in each step definition file. 
    public class AwgFGenSteps
    {
        private readonly AwgFGenGroup _awgFGenGroup = new AwgFGenGroup();
        private readonly UtilitiesGroup _utilitiesGroup = new UtilitiesGroup();

        #region FGEN[:CHANnel]:AMPLitude

        //glennj 3/27/2014
        /// <summary>
        /// Sets the function generator amplitude value for the given channel
        /// 
        /// FGEN:[CHANnel[n]]:AMPLitude
        /// </summary>
        /// <param name="setValue">Function generator amplitude value</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator amplitude to ([0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) volts for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator amplitude to ([0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) volts for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheFGenAmplitudeInVolts(string setValue, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.SetTheAWGFgenAmplitudeValueTo(awg, channelNumber, AwgFGenGroup.FGenChannelAmplitudeAs.Value, setValue);
        }

        //glennj d
        /// <summary>
        /// Sets the function generator amplitude to minimum volts for channel for AWG
        /// 
        /// FGEN:[CHANnel[n]]:AMPLitude
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator amplitude to minimum volts for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator amplitude to minimum volts for channel ([1-4]) for AWG ([1-4])")]
        public void SetFunctionGeneratorAmplitudeToMin(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.SetTheAWGFgenAmplitudeValueTo(awg, channelNumber, AwgFGenGroup.FGenChannelAmplitudeAs.Min);
        }

        //glennj d
        /// <summary>
        /// Sets the function generator amplitude to maximum volts for channel for AWG
        /// 
        /// FGEN:[CHANnel[n]]:AMPLitude
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator amplitude to maximum volts for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator amplitude to maximum volts for channel ([1-4]) for AWG ([1-4])")]
        public void SetFunctionGeneratorAmplitudeToMax(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.SetTheAWGFgenAmplitudeValueTo(awg, channelNumber, AwgFGenGroup.FGenChannelAmplitudeAs.Max);
        }

        //jhowells 1/30/13
        //glennj d
        /// <summary>
        /// Gets the function generator amplitude value for the given channel
        /// FGEN:[CHANnel[n]]:AMPLitude?
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I get the function generator amplitude for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I get the function generator amplitude for channel ([1-4]) for AWG ([1-4])")]
        public void GetTheAWGFgenAmplitudeValue(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.GetTheAWGFgenAmplitudeValue(awg, channelNumber);
        }

        //jhowells 1/30/13
        //glennj d
        /// <summary>
        /// Compares the function generator amplitude value against the expected value.
        /// 
        /// FGEN:[CHANnel[n]]:AMPLitude
        /// </summary>
        /// <param name="expectedValue">Expected function generator amplitude value</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [Then(@"the function generator amplitude should be ([0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) volts for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [Then(@"the function generator amplitude should be ([0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) volts for channel ([1-4]) for AWG ([1-4])")]
        public void TheAWGFgenAmplitudeValueShouldBe(string expectedValue, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.AWGFgenAmplitudeValueShouldBe(awg, channelNumber, expectedValue);
        }

        #endregion FGEN[:CHANnel]:AMPLitude

        #region FGEN[:CHANnel]:DCLevel

        // Unknown 01/01/01
        //glennj 8/7/2013
        //glennj d
        /// <summary>
        /// Sets the function generator DC level value for the given channel and the specified %AWG
        /// 
        /// FGEN:[CHANnel[n]]:DCLevel
        /// </summary>
        /// <param name="setValue">Function generator DCLevel value</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator DC level to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) volts for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator DC level to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) volts for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheAWGFgenDCLevelValueTo(string setValue, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.SetTheAWGFgenDCLevelValueTo(awg, channelNumber, AwgFGenGroup.FGenChannelDCLevelAs.Value, setValue);
        }

        //glennj d
        /// <summary>
        /// Sets the function generator DC level value to minimum for channel for %AWG
        /// 
        /// FGEN:[CHANnel[n]]:DCLevel
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator DC level to minimum volts for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator DC level to minimum volts for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheAWGFgenDCLevelValueToMin(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.SetTheAWGFgenDCLevelValueTo(awg, channelNumber, AwgFGenGroup.FGenChannelDCLevelAs.Min);
        }

        //glennj d
        /// <summary>
        /// Sets the function generator DC level value to maximum for channel for %AWG
        /// 
        /// FGEN:[CHANnel[n]]:DCLevel
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator DC level to maximum volts for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator DC level to maximum volts for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheAWGFgenDCLevelValueToMax(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.SetTheAWGFgenDCLevelValueTo(awg, channelNumber, AwgFGenGroup.FGenChannelDCLevelAs.Max);
        }

        //glennj 8/7/2013
        //glennj d
        /// <summary>
        /// Gets the function generator DC level value for the given channel for the default %AWG
        /// 
        /// FGEN:[CHANnel[n]]:DCLevel?
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
           \FGen\verbatim
        [When(@"I get the function generator DC level for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I get the function generator DC level for channel ([1-4]) for AWG ([1-4])")]
        public void GetTheAWGFgenDCLevelValue(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.GetTheAWGFgenDCLevelValue(awg, channelNumber);
        }

        // Unknown 01/01/01
        //glennj 8/7/2013
        //glennj d
        /// <summary>
        /// Compares the function generator DC level value against the expected value for the default %AWG.
        /// 
        /// FGEN:[CHANnel[n]]:DCLevel
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="expectedValue">Expected function generator DCLevel value</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
           \FGen\verbatim
        [Then(@"the function generator DC level should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) volts for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [Then(@"the function generator DC level should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) volts for channel ([1-4]) for AWG ([1-4])")]
        public void TheAWGFgenDCLevelValueShouldBe(string expectedValue, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.AWGFgenDCLevelValueShouldBe(awg, channelNumber, expectedValue);
        }

        #endregion FGEN[:CHANnel]:DCLevel

        #region FGEN[:CHANnel]:FREQuency
        
        // Unknown 01/01/01
        //glennj d
        /// <summary> 
        /// Sets the function generator frequency value for the given channel
        /// 
        /// FGEN:[CHANnel[n]]:FREQuency
        /// </summary>
        /// <param name="setValue">Function generator frequency value</param>
        /// <param name="channelNumber">AWG Channel Number</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator frequency to ([0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) Hz for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator frequency to ([0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) Hz for channel ([1-4]) for AWG ([1-4])")]
        public void SetAnAWGFgenFrequencyValueTo(string setValue, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.SetAnAWGFgenFrequencyValueTo(awg, channelNumber, AwgFGenGroup.FGenChannelFrequencyAs.Value, setValue);
        }

        //glennj d
        /// <summary> 
        /// Sets the function generator frequency to minimum for the given channel
        /// 
        /// FGEN:[CHANnel[n]]:FREQuency
        /// </summary>
        /// <param name="channelNumber">AWG Channel Number</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator frequency to minimum Hz for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator frequency to minimum Hz for channel ([1-4]) for AWG ([1-4])")]
        public void SetAnAWGFgenFrequencyValueToMin(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.SetAnAWGFgenFrequencyValueTo(awg, channelNumber, AwgFGenGroup.FGenChannelFrequencyAs.Min);
        }

        //glennj d
        /// <summary> 
        /// Sets the function generator frequency to maximum for the given channel
        /// 
        /// FGEN:[CHANnel[n]]:FREQuency
        /// </summary>
        /// <param name="channelNumber">AWG Channel Number</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator frequency to maximum Hz for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator frequency to maximum Hz for channel ([1-4]) for AWG ([1-4])")]
        public void SetAnAWGFgenFrequencyValueToMax(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.SetAnAWGFgenFrequencyValueTo(awg, channelNumber, AwgFGenGroup.FGenChannelFrequencyAs.Max);
        }

        //glennj d
        /// <summary>
        /// Gets the function generator frequency value for the given channel
        /// 
        /// FGEN:[CHANnel[n]]:FREQuency
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I get the function generator frequency for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim
       */
        [When(@"I get the function generator frequency for channel ([1-4]) for AWG ([1-4])")]
        public void GetTheAWGFgenFrequencyValue(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.GetTheAWGFgenFrequencyValue(awg, channelNumber);
        }

        //glennj d
        /// <summary>
        /// Compares the function generator frequency value for the given channel against the expected value.
        /// 
        /// FGEN:[CHANnel[n]]:FREQuency
        /// </summary>
        /// <param name="expectedValue">Expected function generator frequency value</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [Then(@"the function generator frequency should be ([0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) Hz for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [Then(@"the function generator frequency should be ([0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) Hz for channel ([1-4]) for AWG ([1-4])")]
        public void TheAWGFgenfrequencyValueShouldBe(string expectedValue, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.AWGFgenfrequencyValueShouldBe(awg, channelNumber, expectedValue);
        }

        #endregion FGEN[:CHANnel]:FREQuency

        #region FGEN[:CHANnel]:HIGH

        //glennj 3/24/2014
        /// <summary>
        /// Sets the function generator high value for the given channel
        /// 
        /// FGEN:[CHANnel[n]]:HIGH
        /// </summary>
        /// <param name="setHighValue"></param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator high to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) volts for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator high to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) volts for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheFGenAmplitudeHighInVoltsTo(string setHighValue, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.SetTheAWGFgenAmplitudeHighValueTo(awg, channelNumber, AwgFGenGroup.FGenChannelHighAs.Value, setHighValue );
        }

        //glennj 3/24/2014
        /// <summary>
        /// Sets the function generator high value to a minimum for the given channel
        /// 
        /// FGEN:[CHANnel[n]]:HIGH
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator high to minimum volts for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator high to minimum volts for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheFGenAmplitudeHighInVoltsToMin(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.SetTheAWGFgenAmplitudeHighValueTo(awg, channelNumber, AwgFGenGroup.FGenChannelHighAs.Min);
        }

        //glennj 3/24/2014
        /// <summary>
        /// Sets the function generator high value to a maximum for the given channel
        /// 
        /// FGEN:[CHANnel[n]]:HIGH
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator high to maximum volts for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator high to maximum volts for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheFGenAmplitudeHighInVoltsToMax(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.SetTheAWGFgenAmplitudeHighValueTo(awg, channelNumber, AwgFGenGroup.FGenChannelHighAs.Max);
        }

        //glennj d
        /// <summary>
        /// Gets the function generator high value for the given channel
        /// 
        /// FGEN:[CHANnel[n]]:HIGH?
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I get the function generator high for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I get the function generator high for channel ([1-4]) for AWG ([1-4])")]
        public void GetTheAWGFgenAmplitudeHightValue(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.GetTheAWGFgenAmplitudeHighValue(awg, channelNumber);
        }

        //glennj d
        /// <summary>
        /// Compares the function generator high value against the expected value.
        /// 
        /// FGEN:[CHANnel[n]]:HIGH
        /// </summary>
        /// <param name="expectedHighValue">Expected function generator high value</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [Then(@"the function generator high should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) volts for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [Then(@"the function generator high should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) volts for channel ([1-4]) for AWG ([1-4])")]
        public void TheAWGFgenAmplitudeHighValueShouldBe(string expectedHighValue, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.AWGFgenAmplitudeHighValueShouldBe(awg, channelNumber, expectedHighValue);
        }

        #endregion FGEN[:CHANnel]:HIGH

        #region FGEN[:CHANnel]:LOW
        
        //glennj d
        /// <summary>
        /// Sets the function generator low value for the given channel
        /// 
        /// FGEN:[CHANnel[n]]:LOW
        /// </summary>
        /// <param name="setLowValue">Function generator low value</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator low to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) volts for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator low to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) volts for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheFGenAmplitudeLowInVoltsTo(string setLowValue, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.SetTheAWGFgenAmplitudeLowValueTo(awg, channelNumber, AwgFGenGroup.FGenChannelLowAs.Value,
                                                           setLowValue);
        }

        //glennj d
        /// <summary>
        /// Sets the function generator low value to the minimum for the given channel
        /// 
        /// FGEN:[CHANnel[n]]:LOW
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator low to minimum volts for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator low to minimum volts for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheFGenAmplitudeLowInVoltsToMin(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.SetTheAWGFgenAmplitudeLowValueTo(awg, channelNumber, AwgFGenGroup.FGenChannelLowAs.Min);
        }

        //glennj d
        /// <summary>
        /// Sets the function generator low value to the maximum for the given channel
        /// 
        /// FGEN:[CHANnel[n]]:LOW
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator low to maximum volts for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator low to maximum volts for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheFGenAmplitudeLowInVoltsToMax(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.SetTheAWGFgenAmplitudeLowValueTo(awg, channelNumber, AwgFGenGroup.FGenChannelLowAs.Max);
        }

        //glennj d
        /// <summary>
        /// Gets the function generator low value for the given channel
        /// 
        /// FGEN:[CHANnel[n]]:LOW
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I get the function generator low for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I get the function generator low for channel ([1-4]) for AWG ([1-4])")]
        public void GetTheAWGFgenAmplitudeLowValue(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.GetTheAWGFgenAmplitudeLowValue(awg, channelNumber);
        }

        //glennj
        /// <summary>
        /// Compares the function generator low value for the given channel against the expected value.
        /// 
        /// FGEN:[CHANnel[n]]:LOW
        /// </summary>
        /// <param name="expectedLowValue">Expected function generator low value</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [Then(@"the function generator low should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) volts for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [Then(@"the function generator low should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) volts for channel ([1-4]) for AWG ([1-4])")]
        public void TheAWGFgenAmplitudeLowValueShouldBe(string expectedLowValue, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.AWGFgenAmplitudeLowValueShouldBe(awg, channelNumber, expectedLowValue);
        }

        #endregion FGEN[:CHANnel]:LOW

        #region FGEN[:CHANnel]:OFFSet

        //glennj d
        /// <summary>
        /// Sets the function generator offset value for the given channel and the given %AWG
        /// 
        /// FGEN:[CHANnel[n]]:OFFset
        /// </summary>
        /// <param name="setValue">Function generator offset value</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator offset to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) volts for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator offset to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) volts for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheAWGFgenOffsetValueTo(string setValue, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.SetTheAWGFgenOffsetValueTo(awg, channelNumber, AwgFGenGroup.FGenChannelOffsetAs.Value, setValue);
        }

        //glennj d
        /// <summary>
        /// Sets the function generator offset value to a minimum for the given channel and the given %AWG
        /// 
        /// FGEN:[CHANnel[n]]:OFFset
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator offset to minimum volts for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator offset to minimum volts for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheAWGFgenOffsetValueToMin(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.SetTheAWGFgenOffsetValueTo(awg, channelNumber, AwgFGenGroup.FGenChannelOffsetAs.Min);
        }

        //glennj d
        /// <summary>
        /// Sets the function generator offset value to a maximum for the given channel and the given %AWG
        /// 
        /// FGEN:[CHANnel[n]]:OFFset
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator offset to maximum volts for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator offset to maximum volts for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheAWGFgenOffsetValueToMax(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.SetTheAWGFgenOffsetValueTo(awg, channelNumber, AwgFGenGroup.FGenChannelOffsetAs.Max);
        }

        //glennj d
        /// <summary>
        /// Gets the function generator offset value for the given channel for the default %AWG
        /// 
        /// FGEN:[CHANnel[n]]:OFFset?
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I get the function generator offset for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I get the function generator offset for channel ([1-4]) for AWG ([1-4])")]
        public void GetTheAWGFgenOffsetValue(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.GetTheAWGFgenOffsetValue(awg, channelNumber);
        }

        //glennj d
        /// <summary>
        /// Compares the function generator offset value against the expected value for the default %AWG.
        /// 
        /// FGEN:[CHANnel[n]]:OFFset
        /// </summary>
        /// <param name="expectedValue">Expected function generator offset value</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [Then(@"the function generator offset should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) volts for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [Then(@"the function generator offset should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) volts for channel ([1-4]) for AWG ([1-4])")]
        public void TheAWGFgenOffsetValueShouldBe(string expectedValue, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.AWGFgenOffsetValueShouldBe(awg, channelNumber, expectedValue);
        }

        #endregion FGEN[:CHANnel]:OFFSet

        #region FGEN[:CHANnel]:PERiod?

        //glennj d
        /// <summary>
        /// Gets the Period Value for Function Generator Waveforms
        /// 
        /// FGEN:[CHANnel[n]]:PERiod? (Query Only)
        /// </summary>
        /*!
           \FGen\verbatim
        [When(@"I get the function generator waveform period for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I get the function generator waveform period for channel ([1-4]) for AWG ([1-4])")]
        public void GetTheAWGFgenPeriodValue(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgFGenGroup.GetTheAWGFgenPeriodValue(awg, channelNumber);
        }

        //glennj d
        /// <summary>
        /// Compares the period value for function generator against the expected value.
        /// 
        /// FGEN[:CHANnel]:PERiod
        /// </summary>
        /// <param name="expectedValue">Expected Period Value for Function Generator</param>
        /// <param name="channelNumber"></param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [Then(@"the function generator waveform period should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) seconds for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [Then(@"the function generator waveform period should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) seconds for channel ([1-4]) for AWG ([1-4])")]
        public void TheAWGFgenPeriodValueShouldBe(string expectedValue, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgFGenGroup.AWGFgenPeriodValueShouldBe(awg, channelNumber, expectedValue);
        }

        #endregion FGEN[:CHANnel]:PERiod?

        #region FGEN[:CHANnel]:PHASe

        //glennj d
        /// <summary>
        /// Sets the function generator phase value for the given channel
        /// 
        /// FGEN:[CHANnel[n]]:PHASe
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="setValue">Function generator phase value</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator phase to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) degrees for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator phase to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) degrees for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheFGenPhaseTo(string setValue, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.SetTheAWGFgenPhaseValueTo(awg, channelNumber, AwgFGenGroup.FGenChannelPhaseAs.Value, setValue);
        }

        //glennj d
        /// <summary>
        /// Sets the function generator phase value to minimum for the given channel
        /// 
        /// FGEN:[CHANnel[n]]:PHASe
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator phase to minimum degrees for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator phase to minimum degrees for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheFGenPhaseToMin(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.SetTheAWGFgenPhaseValueTo(awg, channelNumber, AwgFGenGroup.FGenChannelPhaseAs.Min);
        }

        //glennj d
        /// <summary>
        /// Sets the function generator phase value to maximum for the given channel
        /// 
        /// FGEN:[CHANnel[n]]:PHASe
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator phase to maximum degrees for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator phase to maximum degrees for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheFGenPhaseToMax(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.SetTheAWGFgenPhaseValueTo(awg, channelNumber, AwgFGenGroup.FGenChannelPhaseAs.Max);
        }

        //glennj d
        /// <summary>
        /// Gets the function generator phase value for the given channel
        /// 
        /// FGEN:[CHANnel[n]]:PHASe
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I get the function generator phase for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I get the function generator phase for channel ([1-4]) for AWG ([1-4])")]
        public void GetTheAWGFgenPhaseValue(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.GetTheAWGFgenPhaseValue(awg, channelNumber);
        }

        //glennj d
        /// <summary>
        /// Compares the function generator phase value for the given channel against the expected value.
        /// 
        /// FGEN:[CHANnel[n]]:PHASe
        /// </summary>
        /// <param name="expectedValue">Expected function generator phase value</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [Then(@"the function generator phase should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) degrees for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [Then(@"the function generator phase should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) degrees for channel ([1-4]) for AWG ([1-4])")]
        public void TheAWGFgenPhaseValueShouldBe(string expectedValue, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.AWGFgenPhaseValueShouldBe(awg, channelNumber, expectedValue);
        }

        #endregion FGEN[:CHANnel]:PHASe

        #region FGEN[:CHANnel]:SYMMetry
  
        //glennj 3/24/2014
        /// <summary>
        /// Sets the function generator symmetry value for the given channel
        /// 
        /// FGEN:[CHANnel[n]]:SYMMetry
        /// </summary>
        /// <param name="setValue">Function generator symmetry value</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator symmetry to (\d+) percent for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator symmetry to (\d+) percent for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheAWGFgenSymmetryValueTo(string setValue, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.SetTheAWGFgenSymmetryValueTo(awg, channelNumber, AwgFGenGroup.FGenChannelSymmetryAs.Value, setValue);
        }

        //glennj 3/24/2014
        /// <summary>
        /// Sets the function generator symmetry to minimum for the given channel
        /// 
        /// FGEN:[CHANnel[n]]:SYMMetry
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator symmetry to minimum percent for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator symmetry to minimum percent for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheAWGFgenSymmetryValueToMin(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.SetTheAWGFgenSymmetryValueTo(awg, channelNumber, AwgFGenGroup.FGenChannelSymmetryAs.Min);
        }

        //glennj 3/24/2014
        /// <summary>
        /// Sets the function generator symmetry to maximum for the given channel
        /// 
        /// FGEN:[CHANnel[n]]:SYMMetry
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator symmetry to maximum percent for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator symmetry to maximum percent for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheAWGFgenSymmetryValueToMax(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.SetTheAWGFgenSymmetryValueTo(awg, channelNumber, AwgFGenGroup.FGenChannelSymmetryAs.Max);
        }

        //glennj 3/24/2014
        /// <summary>
        /// Gets the function generator symmetry value for the given channel
        /// 
        /// FGEN:[CHANnel[n]]:SYMMetry
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I get the AWG function generator symmetry value for channel ([1-4])")]
           \endverbatim 
       */
        [When(@"I get the function generator symmetry for channel ([1-4]) for AWG ([1-4])")]
        public void GetTheAWGFgenSymmetryValue(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.GetTheAWGFgenSymmetryValue(awg, channelNumber);
        }

        //glennj d
        /// <summary>
        /// Checks the function generator symmetry for the given channel against the expected value.
        /// 
        /// FGEN:[CHANnel[n]]:SYMMetry
        /// </summary>
        /// <param name="expectedSymmetry">Expected function generator symmetry value</param>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [Then(@"the function generator symmetry should be (\d+) percent for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [Then(@"the function generator symmetry should be (\d+) percent for channel ([1-4]) for AWG ([1-4])")]
        public void TheAWGFgenSymmetryValueShouldBe(string expectedSymmetry, string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.AWGFgenSymmetryValueShouldBe(awg, channelNumber, expectedSymmetry);
        }

        #endregion FGEN[:CHANnel]:SYMMetry

        #region FGEN[:CHANnel]:TYPE

        //glennj 6/17/2013
        /// <summary>
        /// Sets the function generator waveform type to Sine
        /// 
        /// FGEN:CHANnel[n]:TYPE
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator waveform type to sine for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator waveform type to sine for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheAWGFgenWaveformTypeValueToSine(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.SetTheAWGFgenWaveformTypeValueTo(awg, channelNumber, AwgFGenGroup.FGenChannelTypeAs.Sine);
        }

        //glennj 6/17/2013
        /// <summary>
        /// Sets the function generator waveform type to square
        /// 
        /// FGEN:CHANnel[n]:TYPE
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator waveform type to square for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator waveform type to square for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheAWGFgenWaveformTypeValueToSquare(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.SetTheAWGFgenWaveformTypeValueTo(awg, channelNumber, AwgFGenGroup.FGenChannelTypeAs.Square);
        }

        //glennj 6/17/2013
        /// <summary>
        /// Sets the function generator waveform type to triangle
        /// 
        /// FGEN:CHANnel[n]:TYPE
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator waveform type to triangle for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator waveform type to triangle for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheAWGFgenWaveformTypeValueToTriangle(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.SetTheAWGFgenWaveformTypeValueTo(awg, channelNumber, AwgFGenGroup.FGenChannelTypeAs.Triangle);
        }

        //glennj 6/17/2013
        /// <summary>
        /// Sets the function generator waveform type to noise
        /// 
        /// FGEN:CHANnel[n]:TYPE
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator waveform type to noise for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator waveform type to noise for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheAWGFgenWaveformTypeValueToNoise(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.SetTheAWGFgenWaveformTypeValueTo(awg, channelNumber, AwgFGenGroup.FGenChannelTypeAs.Noise);
        }

        //glennj 6/17/2013
        /// <summary>
        /// Sets the function generator waveform type to DC
        /// 
        /// FGEN:CHANnel[n]:TYPE
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator waveform type to DC for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator waveform type to DC for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheAWGFgenWaveformTypeValueToDC(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.SetTheAWGFgenWaveformTypeValueTo(awg, channelNumber, AwgFGenGroup.FGenChannelTypeAs.DC);
        }

        //glennj 6/17/2013
        /// <summary>
        /// Sets the function generator waveform type to gaussian
        /// 
        /// FGEN:CHANnel[n]:TYPE
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator waveform type to gaussian for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator waveform type to gaussian for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheAWGFgenWaveformTypeValueToGaussian(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.SetTheAWGFgenWaveformTypeValueTo(awg, channelNumber, AwgFGenGroup.FGenChannelTypeAs.Gaussian);
        }

        //glennj 6/17/2013
        /// <summary>
        /// Sets the function generator waveform type to exponential rise
        /// 
        /// FGEN:CHANnel[n]:TYPE
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator waveform type to exponential rise for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator waveform type to exponential rise for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheAWGFgenWaveformTypeValueToExprise(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.SetTheAWGFgenWaveformTypeValueTo(awg, channelNumber, AwgFGenGroup.FGenChannelTypeAs.Exprise);
        }

        //glennj 6/17/2013
        /// <summary>
        /// Sets the function generator waveform type to exponential decay
        /// 
        /// FGEN:CHANnel[n]:TYPE
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator waveform type to exponential decay for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator waveform type to exponential decay for channel ([1-4]) for AWG ([1-4])")]
        public void SetTheAWGFgenWaveformTypeValueToExpdecay(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.SetTheAWGFgenWaveformTypeValueTo(awg, channelNumber, AwgFGenGroup.FGenChannelTypeAs.Expdecay);
        }


        //jhowells 1/30/13
        //glennj d
        /// <summary>
        /// Gets the function generator waveform type for the given channel for the default %AWG
        /// FGEN:CHANnel[n]:TYPE?   
        /// </summary>
        /// <param name="channelNumber">Which channel</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I get the function generator waveform type for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I get the function generator waveform type for channel ([1-4]) for AWG ([1-4])")]
        public void GetTheAWGFgenWaveformTypeValue(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.GetTheAWGFgenWaveformTypeValue(awg, channelNumber);
        }

        //glennj d
        /// <summary>
        /// Verifies the function generator waveform type for the given channel is sine
        /// 
        /// FGEN:CHANnel[n]:TYPE?
        /// </summary>
        /// <param name="channelNumber">Which channel 1|2|3|4</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [Then(@"the function generator waveform type should be sine for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [Then(@"the function generator waveform type should be sine for channel ([1-4]) for AWG ([1-4])")]
        public void TheFGenWaveformTypeShouldBeSine(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.AWGFGenWaveformTypeValueShouldBe(awg, channelNumber, AwgFGenGroup.FGenChannelTypeAs.Sine);
        }

        //glennj d
        /// <summary>
        /// Verifies the function generator waveform type for the given channel is square
        /// 
        /// FGEN:CHANnel[n]:TYPE?
        /// </summary>
        /// <param name="channelNumber">Which channel 1|2|3|4</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [Then(@"the function generator waveform type should be square for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [Then(@"the function generator waveform type should be square for channel ([1-4]) for AWG ([1-4])")]
        public void TheFGenWaveformTypeShouldBeSquare(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.AWGFGenWaveformTypeValueShouldBe(awg, channelNumber, AwgFGenGroup.FGenChannelTypeAs.Square);
        }

        //glennj d
        /// <summary>
        /// Verifies the function generator waveform type for the given channel is triangle
        /// 
        /// FGEN:CHANnel[n]:TYPE?
        /// </summary>
        /// <param name="channelNumber">Which channel 1|2|3|4</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [Then(@"the function generator waveform type should be triangle for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [Then(@"the function generator waveform type should be triangle for channel ([1-4]) for AWG ([1-4])")]
        public void TheFGenWaveformTypeShouldBeTriangle(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.AWGFGenWaveformTypeValueShouldBe(awg, channelNumber, AwgFGenGroup.FGenChannelTypeAs.Triangle);
        }

        //glennj d
        /// <summary>
        /// Verifies the function generator waveform type for the given channel is noise
        /// 
        /// FGEN:CHANnel[n]:TYPE?
        /// </summary>
        /// <param name="channelNumber">Which channel 1|2|3|4</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [Then(@"the function generator waveform type should be noise for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [Then(@"the function generator waveform type should be noise for channel ([1-4]) for AWG ([1-4])")]
        public void TheFGenWaveformTypeShouldBeNoise(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.AWGFGenWaveformTypeValueShouldBe(awg, channelNumber, AwgFGenGroup.FGenChannelTypeAs.Noise);
        }

        //glennj d
        /// <summary>
        /// Verifies the function generator waveform type for the given channel is DC
        /// 
        /// FGEN:CHANnel[n]:TYPE?
        /// </summary>
        /// <param name="channelNumber">Which channel 1|2|3|4</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [Then(@"the function generator waveform type should be DC for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [Then(@"the function generator waveform type should be DC for channel ([1-4]) for AWG ([1-4])")]
        public void TheFGenWaveformTypeShouldBeDC(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.AWGFGenWaveformTypeValueShouldBe(awg, channelNumber, AwgFGenGroup.FGenChannelTypeAs.DC);
        }

        //glennj d
        /// <summary>
        /// Verifies the function generator waveform type for the given channel is gaussian
        /// 
        /// FGEN:CHANnel[n]:TYPE?
        /// </summary>
        /// <param name="channelNumber">Which channel 1|2|3|4</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [Then(@"the function generator waveform type should be gaussian for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [Then(@"the function generator waveform type should be gaussian for channel ([1-4]) for AWG ([1-4])")]
        public void TheFGenWaveformTypeShouldBeGaussian(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.AWGFGenWaveformTypeValueShouldBe(awg, channelNumber, AwgFGenGroup.FGenChannelTypeAs.Gaussian);
        }

        //glennj d
        /// <summary>
        /// Verifies the function generator waveform type for the given channel is exponential rise
        /// 
        /// FGEN:CHANnel[n]:TYPE?
        /// </summary>
        /// <param name="channelNumber">Which channel 1|2|3|4</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [Then(@"the function generator waveform type should be exponential rise for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [Then(@"the function generator waveform type should be exponential rise for channel ([1-4]) for AWG ([1-4])")]
        public void TheFGenWaveformTypeShouldBeExprise(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.AWGFGenWaveformTypeValueShouldBe(awg, channelNumber, AwgFGenGroup.FGenChannelTypeAs.Exprise);
        }

        //glennj d
        /// <summary>
        /// Verifies the function generator waveform type for the given channel is exponential decay
        /// 
        /// FGEN:CHANnel[n]:TYPE?
        /// </summary>
        /// <param name="channelNumber">Which channel 1|2|3|4</param>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [Then(@"the function generator waveform type should be exponential decay for channel ([1-4]) for AWG ([1-4])")]
           \endverbatim 
       */
        [Then(@"the function generator waveform type should be exponential decay for channel ([1-4]) for AWG ([1-4])")]
        public void TheFGenWaveformTypeShouldBeExpdecay(string channelNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, channelNumber);
            _awgFGenGroup.AWGFGenWaveformTypeValueShouldBe(awg, channelNumber, AwgFGenGroup.FGenChannelTypeAs.Expdecay);
        }

        #endregion FGEN[:CHANnel]:TYPE

        #region FGEN:COUPle:AMPLitude

        //glennj d
        /// <summary>
        /// Enables Amplitude Coupling for Function Generator output channels
        /// 
        /// FGEN:COUPle:AMPLitude argument
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator coupling to on for amplitude for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator coupling to on for amplitude for AWG ([1-4])")]
        public void SetTheAWGFgenCouplingAmplitudeStateValueToOn(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgFGenGroup.SetTheAWGFgenCouplingAmplitudeStateValueTo(awg, AwgFGenGroup.FGenCoupleAmplitude.On);
        }

        //glennj d
        /// <summary>
        /// Disables Amplitude Coupling for Function Generator output channels
        /// 
        /// FGEN:COUPle:AMPLitude argument
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator coupling to off for amplitude for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator coupling to off for amplitude for AWG ([1-4])")]
        public void SetTheAWGFgenCouplingAmplitudeStateValueToOff(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgFGenGroup.SetTheAWGFgenCouplingAmplitudeStateValueTo(awg, AwgFGenGroup.FGenCoupleAmplitude.Off);
        }

        //glennj d
        /// <summary>
        /// Gets the Coupling Amplitude Value for Function Generator
        /// 
        /// FGEN:COUPle:AMPLitude?
        /// </summary>
        /*!
           \FGen\verbatim
        [When(@"I get the function generator coupling for amplitude for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I get the function generator coupling for amplitude for AWG ([1-4])")]
        public void GetTheAWGFgenCouplingAmplitudeStateValue(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgFGenGroup.GetTheAWGFgenCouplingAmplitudeStateValue(awg);
        }

        //glennj 3/24/2014
        /// <summary>
        /// Verifies the coupling amplitude is enabled for function generator
        /// 
        /// FGEN:COUPle:AMPLitude
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [Then(@"the function generator coupling should be on for amplitude for AWG ([1-4])")]
           \endverbatim 
       */
        [Then(@"the function generator coupling should be on for amplitude for AWG ([1-4])")]
        public void TheAWGFgenCouplingAmplitudeStateValueShouldBeOn(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgFGenGroup.AWGFgenCouplingAmplitudeStateValueShouldBe(awg, AwgFGenGroup.FGenCoupleAmplitude.On);
        }

        //glennj 3/24/2014
        /// <summary>
        /// Verifies the coupling amplitude is disabled for function generator
        /// 
        /// FGEN:COUPle:AMPLitude
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [Then(@"the function generator coupling should be off for amplitude for AWG ([1-4])")]
           \endverbatim 
       */
        [Then(@"the function generator coupling should be off for amplitude for AWG ([1-4])")]
        public void TheAWGFgenCouplingAmplitudeStateValueShouldBeOff(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgFGenGroup.AWGFgenCouplingAmplitudeStateValueShouldBe(awg, AwgFGenGroup.FGenCoupleAmplitude.Off);
        }

        #endregion FGEN:COUPle:AMPLitude

        #region Postponed

        #region FGEN:COUPle:FREQuency

        //glennj d
        /// <summary>
        /// Enables the FGen coupling frequency state value
        /// 
        /// FGEN:COUPle:FREQuency
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator coupling to on for frequency for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator coupling to on for frequency for AWG ([1-4])")]
        public void SetTheAWGFgenCouplingFrequencyStateValueToOn(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgFGenGroup.SetTheAWGFgenCouplingFrequencyStateValueTo(awg, AwgFGenGroup.FGenCoupleFrequency.On);
        }

        //glennj d
        /// <summary>
        /// Disables the FGen coupling frequency state value
        /// 
        /// FGEN:COUPle:FREQuency
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator coupling to off for frequency for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator coupling to off for frequency for AWG ([1-4])")]
        public void SetTheAWGFgenCouplingFrequencyStateValueToOff(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgFGenGroup.SetTheAWGFgenCouplingFrequencyStateValueTo(awg, AwgFGenGroup.FGenCoupleFrequency.Off);
        }

        //glennj d
        /// <summary>
        /// Gets the FGen coupling frequency state value
        /// 
        /// FGEN:COUPle:FREQuency?
        /// </summary>
        /*!
           \FGen\verbatim
        [When(@"I get the function generator coupling for frequency for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I get the function generator coupling for frequency for AWG ([1-4])")]
        public void GetTheAWGFgenCouplingFrequencyStateValue(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgFGenGroup.GetTheAWGFgenCouplingFrequencyStateValue(awg);
        }

        //glennj d
        /// <summary>
        /// Verifies the FGen coupling frequency is enabled
        /// 
        /// FGEN:COUPle:FREQuency
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator coupling should be on for frequency for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator coupling should be on for frequency for AWG ([1-4])")]
        public void TheAWGFgenCouplingfrequencyStateValueShouldBeOn(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgFGenGroup.AWGFgenCouplingFrequencyStateValueShouldBe(awg, AwgFGenGroup.FGenCoupleFrequency.On);
        }

        //glennj d
        /// <summary>
        /// Verifies the FGen coupling frequency is disabled
        /// 
        /// FGEN:COUPle:FREQuency
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
           \FGen\verbatim
        [When(@"I set the function generator coupling should be off for frequency for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the function generator coupling should be off for frequency for AWG ([1-4])")]
        public void TheAWGFgenCouplingfrequencyStateValueShouldBeOff(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgFGenGroup.AWGFgenCouplingFrequencyStateValueShouldBe(awg, AwgFGenGroup.FGenCoupleFrequency.Off);
        }

        #endregion FGEN:COUPle:FREQeuncy

        #endregion Postponed

    }
}