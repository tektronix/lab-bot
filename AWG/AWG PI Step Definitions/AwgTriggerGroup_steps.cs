//==========================================================================
// AwgTriggerGroupLow_steps.cs
// This file contains the low-order PI step definitions for the AWG PI Trigger Group commands. 
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
//                        
//==========================================================================

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains the PI step definitions for the %AWG PI Trigger Group commands.

    /// Generally the steps are set, get and should be operations.  The step sole responsibility
    /// is to make sure the correct %AWG object is used and that parameters such as channel,
    /// markers and clock references are correct for the %AWG object.
    /// 
    /// \ingroup highpi pisteps
    /// 
    /// </summary>
    [Binding] //Very important! This entry needs to be made in each step definition file. 
    public class AwgTriggerSteps
    {
        private readonly AwgTriggerGroup _awgTriggerGroup = new AwgTriggerGroup();

        

        #region *TRG

        //Jhowells 3/27/2013
        /// <summary>
        /// Generates a Trigger Event using Trigger A
        ///</summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \trigger\verbatim
        [When(@"I generate a Trigger Event on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I generate a Trigger Event on AWG ([1-4])")]
        public void GenerateTRGEvent(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgTriggerGroup.GenerateTriggerEvent(awg);
        }
        #endregion *TRG

        #region TRIGger:IMMediate

        //Jhowells 3/27/2013
        /// <summary>
        /// Generates A or B Trigger Event
        /// </summary>
        /// <param name="triggerSelection">The trigger (A|B) to be selected</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \trigger\verbatim
        [When(@"I generate an event for Trigger (A|B|) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I generate an event for Trigger (A|B|) on AWG ([1-4])")]
        public void GenerateTriggerEvent(string triggerSelection, string awgNumber)
        { 
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgTriggerGroup.GenerateTriggerEvent(awg, triggerSelection);
        }

        #endregion TRIGger:IMMediate

        #region TRIGger:IMPedance

        //Jhowells 6-12-12
        //glennj 7/24/2013
        /// <summary>
        /// Sets the Trigger Impedance value to 50
        /// </summary>
        /// <param name="triggerSelection">The trigger (A|B) to be selected</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \trigger\verbatim
        [When(@"I set the trigger impedance value to 50 for Trigger (A|B) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the trigger impedance value to 50 for Trigger (A|B) on AWG ([1-4])")]
        public void SetTheTriggerImpedanceValueTo50(string triggerSelection, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgTriggerGroup.SetTriggerImpedance(awg, triggerSelection, AwgTriggerGroup.TriggerImpedance.Fifty);
        }

        //glennj 7/24/2013
        /// <summary>
        /// Sets the Trigger Impedance value to 1000
        /// </summary>
        /// <param name="triggerSelection">The trigger (A|B) to be selected</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \trigger\verbatim
        [When(@"I set the trigger impedance value to 1000 for Trigger (A|B) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the trigger impedance value to 1000 for Trigger (A|B) on AWG ([1-4])")]
        public void SetTheTriggerImpedanceValueTo1000(string triggerSelection, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgTriggerGroup.SetTriggerImpedance(awg, triggerSelection, AwgTriggerGroup.TriggerImpedance.OneThousand);
        }

        //Jhowells 6-12-12
        //zkoppert 6/28/12
        //glennj 7/24/2013
        /// <summary>
        /// Gets the Trigger Impedance value
        ///
        /// TRIGger:?IMPedance?
        /// </summary>
        /// <param name="triggerSelection">The trigger (A|B) to be selected</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \trigger\verbatim
        [When(@"I get the trigger impedance value for Trigger (A|B) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the trigger impedance value for Trigger (A|B) on AWG ([1-4])")]
        public void GetTheTriggerImpedanceValue(string triggerSelection, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgTriggerGroup.GetTriggerImpedance(awg, triggerSelection);
        }

        //Jhowells 6-12-12
        //zkoppert 6/28/12
        //glennj 7/24/2013
        /// <summary>
        /// Compares the Trigger Impedance value against the expected value of 50
        /// </summary>
        /// <param name="triggerSelection">The trigger (A|B) to be selected</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \trigger\verbatim
        [Then(@"the trigger impedance value for Trigger (A|B) should be 50 on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the trigger impedance value for Trigger (A|B) should be 50 on AWG ([1-4])")]
        public void TheAWGTriggerImpedanceValueShouldBe50(string triggerSelection, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgTriggerGroup.TriggerImpedanceShouldBe(awg, triggerSelection, AwgTriggerGroup.TriggerImpedance.Fifty);
        }

        //glennj 7/24/2013
        /// <summary>
        /// Compares the Trigger Impedance value against the expected value of 1000
        /// </summary>
        /// <param name="triggerSelection">The trigger (A|B) to be selected</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \trigger\verbatim
        [Then(@"the trigger impedance value for Trigger (A|B) should be 1000 on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the trigger impedance value for Trigger (A|B) should be 1000 on AWG ([1-4])")]
        public void TheAWGTriggerImpedanceValueShouldBe1000(string triggerSelection, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgTriggerGroup.TriggerImpedanceShouldBe(awg, triggerSelection, AwgTriggerGroup.TriggerImpedance.OneThousand);
        }

        #endregion TRIGger:IMPedance

        #region TRIGger:LEVel
        //jmanning 03/18/2014 Removed duplicate commands
        //Jhowells 6-12-12
        //zkoppert 6/29/12
        //glennj 7/24/2013
        /// <summary>
        /// Sets the trigger input level (threshold) in Volts
        /// </summary>
        /// <param name="setValue">Trigger input level</param>
        /// <param name="triggerSelection">The trigger (A|B) to be selected</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \trigger\verbatim
        [When(@"I set the trigger level value to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) V for Trigger (A|B) on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the trigger level value to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) V for Trigger (A|B) on AWG ([1-4])")]
        public void SetTheTriggerLevelValuewInVolts(string setValue, string triggerSelection, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);

            //Interpret the units selected in the step and convert the value to volts
            float interpretedValue = (float.Parse(setValue));

            // Convert the float to a string
            string valueToSet = Convert.ToString(interpretedValue);
            _awgTriggerGroup.SetTriggerLevel(awg, triggerSelection, valueToSet);
        }

        //Jhowells 6-12-12
        //zkoppert 6/29/12
        //glennj 7/24/2013
        /// <summary>
        /// Gets the Trigger Level value.
        /// </summary>
        /// <param name="triggerSelection">The trigger (A|B) to be selected</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
		        \trigger\verbatim
        [When(@"I get the trigger level value for Trigger (A|B) on AWG ([1-4])")]
		        \endverbatim 
        */
        [When(@"I get the trigger level value for Trigger (A|B) on AWG ([1-4])")]
        public void GetTheTriggerLevelValue(string triggerSelection, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgTriggerGroup.GetTriggerLevel(awg, triggerSelection);
        }

        //Jhowells 6-12-12
        //zkoppert 6/29/12
        //glennj 7/24/2013
        /// <summary>
        /// Compares the Trigger  Level value against the expected value.
        ///</summary>
        /// <param name="triggerSelection">The trigger (A|B) to be selected</param>
        /// <param name="expectedValue"></param>
        /// <param name="awgNumber">specific awg</param>
        /*!
	        \trigger\verbatim
        [Then(@"the trigger level value for Trigger (A|B) should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) V on AWG ([1-4])")]
	        \endverbatim 
        */
        [Then(@"the trigger level value for Trigger (A|B) should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) V on AWG ([1-4])")]
        public void TheAWGTriggerLevelValueInVShouldBe(string triggerSelection, string expectedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);

            //Interpret the units selected in the step and convert the value to volts
            float interpretedValue = float.Parse(expectedValue);

            // Convert the float to a string
            string expectedValueToCompareTo = Convert.ToString(interpretedValue);
            _awgTriggerGroup.TriggerLevelShouldBe(awg, triggerSelection, expectedValueToCompareTo);
        }

        #endregion TRIGger:LEVel

        #region TRIGger:MODE

        //Kavitha 02/19/2013
        //glennj 07/24/2013
        /// <summary>
        /// Sets the Trigger Mode value asynchronous
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \trigger\verbatim
        [When(@"I set the trigger mode value to asynchronous on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the trigger mode value to asynchronous on AWG ([1-4])")]
        public void SetTheAWGTriggerModeValueToAsync(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgTriggerGroup.SetTriggerMode(awg, AwgTriggerGroup.TriggerMode.Asynchronous);
        }

        //glennj 07/24/2013
        /// <summary>
        /// Sets the Trigger Mode value synchronous
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \trigger\verbatim
        [When(@"I set the trigger mode value to synchronous on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the trigger mode value to synchronous on AWG ([1-4])")]
        public void SetTheAWGTriggerModeValueToSync(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgTriggerGroup.SetTriggerMode(awg, AwgTriggerGroup.TriggerMode.Synchronous);
        }


        //Kavitha 02/19/2013
        //glennj 07/24/2013
        /// <summary>
        /// Gets the Trigger  Mode value
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \trigger\verbatim
        [When(@"I get the trigger mode value on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the trigger mode value on AWG ([1-4])")]
        public void GetTheTriggerModeValue(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgTriggerGroup.GetTriggerMode(awg);
        }

        //Kavitha 02/19/2013
        //glennj 7/24/2013
        /// <summary>
        /// Compares the Trigger  Mode value asynchronous
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \trigger\verbatim
        [Then(@"I the trigger mode value should be asynchronous on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the trigger mode value should be asynchronous on AWG ([1-4])")]
        public void TheAWGTriggerModeValueShouldBeAsync(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgTriggerGroup.TriggerModeShouldBe(awg, AwgTriggerGroup.TriggerMode.Asynchronous);
        }

        //glennj 7/24/2013
        /// <summary>
        /// Compares the Trigger  Mode value synchronous
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \trigger\verbatim
        [Then(@"I the trigger mode value should be synchronous on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the trigger mode value should be synchronous on AWG ([1-4])")]
        public void TheAWGTriggerModeValueShouldBeSync(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgTriggerGroup.TriggerModeShouldBe(awg, AwgTriggerGroup.TriggerMode.Synchronous);
        }

        #endregion TRIGger:MODE

        #region TRIGger[:SEQuence]:INTerval
        // jmanning 04/08/2014
        /// <summary>
        /// Using TRIGger:SEQuence:INTerval to set the internal trigger interval
        /// </summary>
        /// <param name="setValue">Trigger Interval Value in Seconds</param>
        /*!
            \trigger\verbatim
         [When(@"I set the internal trigger interval value to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) seconds for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the internal trigger interval value to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) seconds for AWG ([1-4])")]
        public void SetTheInternalTriggerIntervalValueInSeconds(string setValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);

            //Interpret the units selected in the step and convert the value to seconds
            float interpretedValue = (float.Parse(setValue));

            // Convert the float to a string
            string valueToSet = Convert.ToString(interpretedValue);
            _awgTriggerGroup.SetTriggerInterval(awg, valueToSet);
        }

        [When(@"I set the internal trigger interval to minimal value for AWG ([1-4])")]
        public void SetTheInternalTriggerIntervalMinimalValue(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            const string valueToSet = "MIN";
            _awgTriggerGroup.SetTriggerInterval(awg, valueToSet);
        }

        [When(@"I set the internal trigger interval to maximum value for AWG ([1-4])")]
        public void SetTheInternalTriggerIntervalMaximumValue(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            const string valueToSet = "MAX";
            _awgTriggerGroup.SetTriggerInterval(awg, valueToSet);
        }

        // jmanning 04/08/2014
        /// <summary>
        /// Using TRIGger:SEQuence:INTerval? to get the internal trigger inetrval
        /// </summary>
        /// <returns>Internal Trigger Time Interval Value</returns>
        /*!
            \trigger\verbatim
        [When(@"I get the internal trigger interval value for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the internal trigger interval value for AWG ([1-4])")]
        public void GetTheInternalTriggerIntervalValue(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgTriggerGroup.GetTriggerInterval(awg);
        }

        // jmanning 04/08/2014
        /// <summary>
        /// Compares the internal Trigger interval value against the expected value.
        ///</summary>
        /// <param name="expectedValue"></param>
        /// <param name="awgNumber">specific awg</param>
        /*!
	        \trigger\verbatim
        [Then(@"the internal trigger interval value for should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) seconds for AWG ([1-4])")]
	        \endverbatim 
        */
        [Then(@"the internal trigger interval value for should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) seconds for AWG ([1-4])")]
        public void TheAWGTriggerLevelValueInVShouldBe(string expectedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);

            //Interpret the units selected in the step and convert the value to volts
            float interpretedValue = float.Parse(expectedValue);

            // Convert the float to a string
            string expectedValueToCompareTo = Convert.ToString(interpretedValue);
            _awgTriggerGroup.TheInternalTriggerIntervalShouldBe(awg, expectedValueToCompareTo);
        }
        #endregion TRIGger[:SEQuence]:INTerval
        #region TRIGger:SLOPe

        //zkoppert 6/29/12
        //glennj 7/24/2013
        /// <summary>
        /// Sets the Trigger  Slope value to positive
        /// </summary>
        /// <param name="triggerSelection">The trigger (A|B) to be selected</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
		        \trigger\verbatim
        [When(@"I set the trigger slope value to positive for Trigger (A|B) on AWG ([1-4])")]
		        \endverbatim 
        */
        [When(@"I set the trigger slope value to positive for Trigger (A|B) on AWG ([1-4])")]
        public void SetTheTriggerSlopeToPositive(string triggerSelection, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgTriggerGroup.SetTriggerSlope(awg, triggerSelection, AwgTriggerGroup.TriggerSlope.Positive);
        }

        //glennj 7/24/2013
        /// <summary>
        /// Sets the Trigger  Slope value to negative
        /// </summary>
        /// <param name="triggerSelection">The trigger (A|B) to be selected</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
		        \trigger\verbatim
        [When(@"I set the trigger slope value to negative for Trigger (A|B) on AWG ([1-4])")]
		        \endverbatim 
        */
        [When(@"I set the trigger slope value to negative for Trigger (A|B) on AWG ([1-4])")]
        public void SetTheTriggerSlopeToNegative(string triggerSelection, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgTriggerGroup.SetTriggerSlope(awg, triggerSelection, AwgTriggerGroup.TriggerSlope.Negative);
        }

        //zkoppert 6/29/12
        //glennj 7/24/2013
        /// <summary>
        /// Gets the Trigger  Slope value
        /// </summary>
        /// <param name="triggerSelection">The trigger (A|B) to be selected</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
	        \trigger\verbatim
        [When(@"I get the trigger slope value for Trigger (A|B) on AWG ([1-4])")]
	        \endverbatim 
        */
        [When(@"I get the trigger slope value for Trigger (A|B) on AWG ([1-4])")]
        public void GetTheAWGTriggerSlopeValue(string triggerSelection, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgTriggerGroup.GetTriggerSlope(awg, triggerSelection);
        }

        //Jhowells 6-12-12
        //zkoppert 6/29/12
        //glennj 7/24/2013
        /// <summary>
        /// Compares Trigger  Slope value for a positive slope.
        /// </summary>
        /// <param name="triggerSelection">The trigger (A|B) to be selected</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
		        \trigger\verbatim
        [When(@"then the trigger slope value for Trigger (A|B) should be positive on AWG ([1-4])")]
		        \endverbatim 
	        */
        [Then(@"the trigger slope value for Trigger (A|B) should be positive on AWG ([1-4])")]
        public void TheAWGTriggerSlopeValueShouldBePostive(string triggerSelection, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgTriggerGroup.TriggerSlopeShouldBe(awg, triggerSelection, AwgTriggerGroup.TriggerSlope.Positive);
        }

        //glennj 7/24/2013
        /// <summary>
        /// Compares Trigger  Slope value for a negative slope.
        /// </summary>
        /// <param name="triggerSelection">The trigger (A|B) to be selected</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
		        \trigger\verbatim
        [Then(@"the trigger slope value for Trigger (A|B) should be negative on AWG ([1-4])")]
		        \endverbatim 
	        */
        [Then(@"the trigger slope value for Trigger (A|B) should be negative on AWG ([1-4])")]
        public void TheAWGTriggerSlopeValueShouldBeNegative(string triggerSelection, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgTriggerGroup.TriggerSlopeShouldBe(awg, triggerSelection, AwgTriggerGroup.TriggerSlope.Negative);
        }

        #endregion TRIGger:SLOPe

        #region TRIGger:SOURce

        //Jhowells 6-12-12
        //glennj 7/24/2013
        /// <summary>
        /// Sets the Trigger  Source value to external
        ///
        /// NOTE: As of PSR1 this can only "change" to EXTernal@n
        /// TRIGger:?SOURce
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \trigger\verbatim
        [When(@"I set the trigger source value to external on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the trigger source value to external on AWG ([1-4])")]
        public void SetTheTriggerSourceToExternal(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgTriggerGroup.SetTriggerSource(awg, AwgTriggerGroup.TriggerSource.External);
        }

        //glennj 7/24/2013
        /// <summary>
        /// Sets the Trigger  Source value to internal
        ///
        /// NOTE: As of PSR1 this can only "change" to EXTernal@n
        /// TRIGger:?SOURce
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \trigger\verbatim
        [When(@"I set the trigger source value to internal on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the trigger source value to internal on AWG ([1-4])")]
        public void SetTheTriggerSourceToInternal(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgTriggerGroup.SetTriggerSource(awg, AwgTriggerGroup.TriggerSource.Internal);
        }

        //Jhowells 6-12-12
        //glennj 7/24/2013
        /// <summary>
        /// Gets the Trigger  Source value<para>
        /// </para>
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
		        \trigger\verbatim
        [When(@"I get the trigger source value on AWG ([1-4])")]
		        \endverbatim 
        */
        [When(@"I get the trigger source value on AWG ([1-4])")]
        public void GetTheTriggerSourceValue(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgTriggerGroup.GetTriggerSource(awg);
        }

        //Jhowells 6-12-12
        //glennj 7/24/2013
        /// <summary>
        /// Compares the Trigger  Source value against the expected value.
        ///
        /// NOTE: As of PSR1 the only value it can be is EXTernal
        /// TRIGger:?SOURce
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
	        \trigger\verbatim
        [Then(@"the trigger source value should be external on AWG ([1-4])")]
	        \endverbatim 
        */
        [Then(@"the trigger source value should be external on AWG ([1-4])")]
        public void TheAWGTriggerSourceValueShouldBeExternal(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgTriggerGroup.TriggerSourceShouldBe(awg, AwgTriggerGroup.TriggerSource.External);
        }

        //glennj 7/24/2013
        /// <summary>
        /// Compares the Trigger  Source value against the expected of INTernal.
        ///
        /// NOTE: As of PSR1 the only value it can be is External
        /// TRIGger:?SOURce
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
	        \trigger\verbatim
        [Then(@"the trigger source value should be internal on AWG ([1-4])")]
	        \endverbatim 
        */
        [Then(@"the trigger source value should be internal on AWG ([1-4])")]
        public void TheAWGTriggerSourceValueShouldBeInternal(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgTriggerGroup.TriggerSourceShouldBe(awg, AwgTriggerGroup.TriggerSource.Internal);
        }

        #endregion TRIGger:SOURce

        #region AWGControl:PJUMP:SEDGE

        //Keerthi 05/28/2015
        /// <summary>
        /// Sets the pattern jump strobe edge value
        /// </summary>
        /// <param name="strobEdge">Name of the waveform</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
           \Trigger\verbatim
        [When(@"I set the patternjump strobe edge to ""(.*)"" for AWG ([1-4])")]
           \endverbatim 
         */

        [When(@"I set the patternjump strobe edge to ""(.*)"" for AWG ([1-4])")]
        public void SetThePatternjumpStrobeEdgeTo(string strobEdge, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgTriggerGroup.SetStrobEdge(strobEdge, awg);
        }


        #endregion AWGControl:PJUMP:SEDGE


        #region AWGControl:PJUMP:SEDGE?

        //Keerthi 05/28/2015
        /// <summary>
        /// gets the pattern jump strobe edge value
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
           \Trigger\verbatim
        [When(@"I get the patternjump strobe edge value for AWG ([1-4])")]
           \endverbatim 
         */

        [When(@"I get the patternjump strobe edge value for AWG ([1-4])")]

        public void GetThePatternjumpStrobeEdgeValue(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);

            _awgTriggerGroup.GetStrobEdge(awg);

        }

        //Keerthi 05/28/2015
        /// <summary>
        /// After getting the pattern jump stobe edge value
        /// compares the pattern jump strobe edge value against expected value 
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        ///  /// <param name="expectedStrobEdge">passing string expected strobe edge value</param>
        /*!
           \Trigger\verbatim
       [Then(@"the patternjump strobe edge value should be ""(.*)"" for AWG ([1-4])")]
           \endverbatim 
         */

        [Then(@"the patternjump strobe edge value should be ""(.*)"" for AWG ([1-4])")]

        public void PatternjumpStrobeEdgeValueShouldBe(string expectedStrobEdge, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgTriggerGroup.StrobEdgeShouldBe(expectedStrobEdge,awg);
        }

        #endregion AWGControl:PJUMP:SEDGE?

        
        
        #region AWGControl:PJUMp:JSTRobe

        //Keerthi 05/28/2015
        /// <summary>
        /// Sets jump on strobe always as ON in Trigger tab of AWG application
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
           \Trigger\verbatim
        [When(@"I set the Jump on strobe always as ON for AWG ([1-4])")]
           \endverbatim 
         */

        [When(@"I set the Jump on strobe always as ON for AWG ([1-4])")]

        public void SetTheJumpOnStrobeAlwaysAsOn(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);

            _awgTriggerGroup.JumpOnStrobeAlways(awg, AwgTriggerGroup.jumpOnStrobe.On);

        }


        //Keerthi 05/28/2015
        /// <summary>
        /// Sets jump on strobe always as OFF in Trigger tab of AWG application
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
           \Trigger\verbatim
        [When(@"I set the Jump on strobe always as OFF for AWG ([1-4])")]
           \endverbatim 
         */

        [When(@"I set the Jump on strobe always as OFF for AWG ([1-4])")]

        public void SetTheJumpOnStrobeAlwaysAsOff(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);

            _awgTriggerGroup.JumpOnStrobeAlways(awg, AwgTriggerGroup.jumpOnStrobe.Off);
        }

        #endregion AWGControl:PJUMp:JSTRobe

       #region AWGControl:PJUMp:JSTRobe?

        //Keerthi 05/28/2015
        /// <summary>
        /// gets the jump on strobe edege whether it is ON/OFF
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
           \Trigger\verbatim
        [When(@"I get the Jump on strobe always status for AWG ([1-4])")]
           \endverbatim 
         */

        [When(@"I get the Jump on strobe always status for AWG ([1-4])")]

       public void GetTheJumpOnStrobeAlwaysStatus(string awgNumber)
       {
           IAWG awg = AwgSetupSteps.GetAWG(awgNumber);

           _awgTriggerGroup.GetJumpOnStrobeStatus(awg);
        }


        //Keerthi 05/28/2015
        /// <summary>
        /// gets the jump on strobe edege 
        /// compares with the queried result with the expected result
        /// </summary>
        /// <param name="jumponstrobestate">jump on strobe edge state</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
           \Trigger\verbatim
        [Then(@"the Jump on strobe always should be (.*) for AWG ([1-4])")]
           \endverbatim 
         */

        [Then(@"the Jump on strobe always should be (.*) for AWG ([1-4])")]

       public void ThenTheJumpOnStrobeAlwaysShouldBeForAWG(string jumponstrobestate, string awgNumber)
       {
           IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
           _awgTriggerGroup.JumpOnStrobeShouldBe(jumponstrobestate, awg);
       }


      #endregion AWGControl:PJUMp:JSTRobe?



     #region TRIGger:WVALue

     // Unkown 01/01/01
        //glennj 7/24/2013
        /// <summary>
        /// Sets the analog DAC while the instrument is in the waiting-for-trigger state first.
        /// 
        /// This is valid only when Run Mode is Triggered or Gated. @n
        /// TRIGger:?WVALue
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
                \trigger\verbatim
        [When(@"I set the analog output trigger wait value to first for all channels on AWG ([1-4])")]
                \endverbatim 
        */
        [When(@"I set the analog output trigger wait value to first for all channels on AWG ([1-4])")]
        public void SetTheTriggerOutputDataPositionToFirst(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgTriggerGroup.SetTriggerWValue(awg, AwgTriggerGroup.TriggerWaitValue.First);
        }

        //glennj 7/24/2013
        /// <summary>
        /// Sets the analog DAC while the instrument is in the waiting-for-trigger state to zero.
        /// 
        /// This is valid only when Run Mode is Triggered or Gated. @n
        /// TRIGger:?WVALue
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
                \trigger\verbatim
        [When(@"I set the analog output trigger wait value to zero for all channels on AWG ([1-4])")]
                \endverbatim 
        */
        [When(@"I set the analog output trigger wait value to zero for all channels on AWG ([1-4])")]
        public void SetTheTriggerOutputDataPositionToZero(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgTriggerGroup.SetTriggerWValue(awg, AwgTriggerGroup.TriggerWaitValue.Zero);
        }


        // Unkown 01/01/01
        //glennj 7/24/2013
        /// <summary>
        /// Gets the output data position of a waveform while the instrument is in the waiting-for-trigger state.
        /// This is valid only when Run Mode is Triggered or Gated. @n
        /// TRIGger:?WVALue
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \trigger\verbatim
        [When(@"I get the analog output trigger wait value for all channels on AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the analog output trigger wait value for all channels on AWG ([1-4])")]
        public void GetTheTriggerOutputDataPositionValue(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgTriggerGroup.GetTriggerWValue(awg);
        }

        // Unkown 01/01/01
        //glennj 7/24/2013
        /// <summary>
        /// Compares the output data position of a waveform while the instrument is in the waiting-for-trigger state
        /// against the expected value of FIRS.
        /// 
        /// This is valid only when Run Mode is Triggered or Gated. @n
        /// TRIGger:?WVALue
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \trigger\verbatim
        [Then(@"the analog output trigger wait value should be first for all channels on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the analog output trigger wait value should be first for all channels on AWG ([1-4])")]
        public void TheAWGTriggerOutputDataPositionValueShouldBeFirst(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgTriggerGroup.TriggerWValueShouldBe(awg, AwgTriggerGroup.TriggerWaitValue.First);
        }

        //glennj 7/24/2013
        /// <summary>
        /// Compares the output data position of a waveform while the instrument is in the waiting-for-trigger state
        /// against the expected value of ZERO.
        /// 
        /// This is valid only when Run Mode is Triggered or Gated. @n
        /// TRIGger:?WVALue
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \trigger\verbatim
        [Then(@"the analog output trigger wait value should be zero for all channels on AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the analog output trigger wait value should be zero for all channels on AWG ([1-4])")]
        public void TheAWGTriggerOutputDataPositionValueShouldBeZero(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgTriggerGroup.TriggerWValueShouldBe(awg, AwgTriggerGroup.TriggerWaitValue.Zero);
        }

        #endregion TRIGger:WVALue


      
    }
}