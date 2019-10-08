//==========================================================================
// ScopeMeasure__steps.cs
// This file contains the low-order PI step definitions for the Scope PI Measure Group commands. 
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
// File path strings - ""(.+)"" used when you want the string that is delimited by the quotes File path strings
//                         
//==========================================================================

using System;
using System.Threading;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains the low-order PI step definitions for the Scope PI Measure Group commands.

    /// Low-level steps set and get the values for commands, and test the raw values as returned from the 
    /// instrument. They DO NOT interpret values in any way! Interpretation, normalization, etc. need to 
    /// occur in the High-level step definitions. Notice the use of the word "value" in the steps - this 
    /// usually implies that the query returns a 0 or 1 or abbreviated text value (like SOFT) that should 
    /// be interpreted as ON or OFF or SOFTWARE to make the step more user-friendly. We do that in the 
    /// High-order step definitions.
    /// 
    /// </summary> 
    [Binding] //Very important! This entry needs to be made in each step definition file.
    public class ScopeMeasureSteps
    {
        private readonly ScopeMeasureGroup _scopeMeasureGroup = new ScopeMeasureGroup();
        private readonly ScopeTriggerGroup _scopeTriggerGroup = new ScopeTriggerGroup();

        #region MEASUrement:IMMed:SOUrce1 CH[n]
        /// <summary>
        /// Sets the DPO immediate measurement source
        /// 
        /// MEASUrement:IMMed:SOUrce1 CH[n]
        /// 
        /// Only the channels where added as sources for now, if math, ref or histograms is needed see 
        /// Section 2-407 pg 419 in the DPO 7k PI manual
        /// </summary>
        /// <param name="source">Which channel to take the measurement from</param>
        /*!
           \scope\verbatim
        [When("I set immediate measurement source to channel ([1-4]) on the Scope")]
           \endverbatim 
        */
        [When("I set immediate measurement source to channel ([1-4]) on the Scope")]
        public void SetTheScopeImmedMeasurementSourceChannel(string source)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetDPOImmediateMeasurementSource(scope, source);
        }
        #endregion MEASUrement:IMMed:SOUrce1 CH[n]

        #region MEASUrement:IMMed:TYPe
        /// <summary>
        /// Sets the immediate measurement to the type amplitude for a DPO Scope
        /// 
        /// MEASUrement:IMMed:TYPe AMPlitude
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"When I set the immediate measurement type to amplitude on the Scope")]
            \endverbatim 
       */
        [When(@"When I set the immediate measurement type to amplitude on the Scope")]
        public void SetTheScopeImmedMeasurementTypeAmplitude()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetDPOImmediateMeasurementType(scope, "AMPlitude");
        }

        /// <summary>
        /// Sets the immediate measurement to the type frequency for a DPO Scope
        /// 
        /// MEASUrement:IMMed:TYPe FREQuency
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"When I set the immediate measurement type to frequency on the Scope")]
            \endverbatim 
       */
        [When(@"When I set the immediate measurement type to frequency on the Scope")]
        public void SetTheScopeImmedMeasurementTypeFrequency()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetDPOImmediateMeasurementType(scope, "FREQuency");
        }

        /// <summary>
        /// Sets the immediate measurement to the type high for a DPO Scope
        /// 
        /// MEASUrement:IMMed:TYPe HIGH
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"When I set the immediate measurement type to high on the Scope")]
            \endverbatim 
       */
        [When(@"When I set the immediate measurement type to high on the Scope")]
        public void SetTheScopeImmedMeasurementTypeHigh()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetDPOImmediateMeasurementType(scope, "HIGH");
        }

        /// <summary>
        /// Sets the immediate measurement to the type hits for a DPO Scope
        /// 
        /// MEASUrement:IMMed:TYPe HITs
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"When I set the immediate measurement type to hits on the Scope")]
            \endverbatim 
       */
        [When(@"When I set the immediate measurement type to hits on the Scope")]
        public void SetTheScopeImmedMeasurementTypeHits()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetDPOImmediateMeasurementType(scope, "HITs");
        }

        /// <summary>
        /// Sets the immediate measurement to the type low for a DPO Scope
        /// 
        /// MEASUrement:IMMed:TYPe LOW
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"When I set the immediate measurement type to low on the Scope")]
            \endverbatim 
       */
        [When(@"When I set the immediate measurement type to low on the Scope")]
        public void SetTheScopeImmedMeasurementTypeLow()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetDPOImmediateMeasurementType(scope, "LOW");
        }

        /// <summary>
        /// Sets the immediate measurement to the type maximum for a DPO Scope
        /// 
        /// MEASUrement:IMMed:TYPe MAXimum
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"When I set the immediate measurement type to maximum on the Scope")]
            \endverbatim 
       */
        [When(@"When I set the immediate measurement type to maximum on the Scope")]
        public void SetTheScopeImmedMeasurementTypeMaximum()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetDPOImmediateMeasurementType(scope, "MAXimum");
        }

        /// <summary>
        /// Sets the immediate measurement to the type mean for a DPO Scope
        /// 
        /// MEASUrement:IMMed:TYPe MEAN
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"When I set the immediate measurement type to mean on the Scope")]
            \endverbatim 
       */
        [When(@"When I set the immediate measurement type to mean on the Scope")]
        public void SetTheScopeImmedMeasurementTypeMean()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetDPOImmediateMeasurementType(scope, "MEAN");
        }

        /// <summary>
        /// Sets the immediate measurement to the type median for a DPO Scope
        /// 
        /// MEASUrement:IMMed:TYPe MEDian
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"When I set the immediate measurement type to median on the Scope")]
            \endverbatim 
       */
        [When(@"When I set the immediate measurement type to median on the Scope")]
        public void SetTheScopeImmedMeasurementTypeMedian()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetDPOImmediateMeasurementType(scope, "MEDian");
        }

        /// <summary>
        /// Sets the immediate measurement to the type minimum for a DPO Scope
        /// 
        /// MEASUrement:IMMed:TYPe MINImum
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"When I set the immediate measurement type to minimum on the Scope")]
            \endverbatim 
       */
        [When(@"When I set the immediate measurement type to minimum on the Scope")]
        public void SetTheScopeImmedMeasurementTypeMinimum()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetDPOImmediateMeasurementType(scope, "MINImum");
        }

        /// <summary>
        /// Sets the immediate measurement to the type period for a DPO Scope
        /// 
        /// MEASUrement:IMMed:TYPe PERIod
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"When I set the immediate measurement type to period on the Scope")]
            \endverbatim 
       */
        [When(@"When I set the immediate measurement type to period on the Scope")]
        public void SetTheScopeImmedMeasurementTypePeriod()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetDPOImmediateMeasurementType(scope, "PERIod");
        }

        /// <summary>
        /// Sets the immediate measurement to the type phase for a DPO Scope
        /// 
        /// MEASUrement:IMMed:TYPe PHase
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"When I set the immediate measurement type to phase on the Scope")]
            \endverbatim 
       */
        [When(@"When I set the immediate measurement type to phase on the Scope")]
        public void SetTheScopeImmedMeasurementTypePhase()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetDPOImmediateMeasurementType(scope, "PHAse");
        }

        /// <summary>
        /// Sets the immediate measurement to the type peak to peak for a DPO Scope
        /// 
        /// MEASUrement:IMMed:TYPe PK2Pk
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"When I set the immediate measurement type to peak to peak on the Scope")]
            \endverbatim 
       */
        [When(@"When I set the immediate measurement type to peak to peak on the Scope")]
        public void SetTheScopeImmedMeasurementTypePk2Pk()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetDPOImmediateMeasurementType(scope, "PK2Pk");
        }

        /// <summary>
        /// Sets the immediate measurement to the type jitter for a DPO Scope
        /// 
        /// MEASUrement:IMMed:TYPe PKPKJitter
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"When I set the immediate measurement type to jitter on the Scope")]
            \endverbatim 
       */
        [When(@"When I set the immediate measurement type to jitter on the Scope")]
        public void SetTheScopeImmedMeasurementTypePkPkJitter()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetDPOImmediateMeasurementType(scope, "PKPKJitter");
        }

        /// <summary>
        /// Sets the immediate measurement to the type rise for a DPO Scope
        /// 
        /// MEASUrement:IMMed:TYPe RISe
        /// </summary>
        /*!
            \SPO\verbatim
        [When(@"When I set the immediate measurement type to rise on the Scope")]
            \endverbatim 
       */
        [When(@"When I set the immediate measurement type to RISe on the Scope")]
        public void SetTheScopeImmedMeasurementTypeRise()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetDPOImmediateMeasurementType(scope, "RISe");
        }
        #endregion MEASUrement:IMMed:TYPe

        #region MEASUrement:IMMed:VALue?
        /// <summary>
        /// Gets the DPO immediate amplitude measurement for the given channel
        /// 
        /// MEASUrement:IMMed:VALue?
        /// </summary>
        /// <param name="source">Which channel</param>
        /*!
            \scope\verbatim
        [When(@"I get the immediate amplitude measurement for channel([1-4]) from the Scope")]
            \endverbatim 
        */
        [When(@"I get the immediate amplitude measurement for channel([1-4]) from the Scope")]
        public void GetTheScopeImmediateAmplitudeMeasurement(string source)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            // Set up the measurement
            _scopeMeasureGroup.ImmedMeasureAmpl(scope, source);
            // Get the value
            _scopeMeasureGroup.GetDPOImmediateMeasurementValue(scope);
        }

        /// <summary>
        /// Gets the immediate amplitude peak to peak measurement for the given channel from the DPO Scope
        /// </summary>
        /// 
        /// MEASUrement:IMMed:SOUrce1 CH[n]
        /// MEASUrement:IMMed:VALue?
        /// <param name="source">Which channel</param>
        /*!
            \scope\verbatim
        [When(@"I get the immediate amplitude peak to peak measurement for channel ([1-4]) from the Scope")]
            \endverbatim 
        */
        [When(@"I get the immediate amplitude peak to peak measurement for channel ([1-4]) from the Scope")]
        public void GetTheScopeImmediatePk2PkAmplitudeMeasurement(string source)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            // Set up the measurement
            _scopeMeasureGroup.ImmedMeasureAmplPk2Pk(scope, source);
            // Get the value
            _scopeMeasureGroup.GetDPOImmedMeasureValuePk2Pk(scope);
        }

        /// <summary>
        /// Gets the immediate rise time measurement for the given channel from the DPO Scope
        /// 
        /// MEASUrement:IMMed:SOUrce1 CH[n]
        /// MEASUrement:IMMed:VALue?
        /// </summary>
        /// <param name="source">Which channel</param>
        /*!
            \scope\verbatim
        [When(@"I get the immediate rise time measurement for channel ([1-4]) from the Scope")]
            \endverbatim 
        */
        [When(@"I get the immediate rise time measurement for channel ([1-4]) from the Scope")]
        public void GetTheScopeImmediateRiseTimeMeasurement(string source)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            // Set up the measurement
            _scopeMeasureGroup.ImmedMeasureRise(scope, source);
            // Get the value
            _scopeMeasureGroup.GetDPOImmedMeasureValueRise(scope);
        }
        #endregion MEASUrement:IMMed:VALue?
        
        #region MEASUrement:MEAS[n]:MEAN?
        /// <summary>
        /// Gets the mean rise time measurement for the given channel for the Scope
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// MEASUrement:MEAS[n]:MEAN?
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <param name="source">Which channel</param>
        /*!
            \scope\verbatim
        [When(@"I get the mean rise time measurement number ([1-8]) for channel ([1-4]) from the Scope")]
            \endverbatim 
        */
        [When(@"I get the mean rise time measurement number ([1-8]) for channel ([1-4]) from the Scope")]
        public void GetTheScopeMeanRiseTimeMeasurement(string measurement, string source)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.MeasureRise(scope, measurement, source);
            _scopeMeasureGroup.GetScopeMeasureValueMeanRise(scope, measurement);
        }


        /// <summary>
        /// Compares the Scope rise time measurement against the expected value within the given percentage tolerance. 
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// MEASUrement:MEAS[n]:MEAN?
        /// </summary>
        /// <param name="stringValue">Expected rise time measurement</param>
        /// <param name="stringPercentage">Percentage tolerance</param>
        /*!
            \scope\verbatim
        [Then(@"the rise time measurement should be ([0-9]+.[0-9]+)ns within ([0-9]+)% on the Scope")]
            \endverbatim 
        */
        [Then(@"the rise time measurement should be ([0-9]+.[0-9]+)ns within ([0-9]+)% on the Scope")]
        public void TheScopeRiseTimeMeasurementShouldBeWithinPercentage(string stringValue, string stringPercentage)
        {
            float value = float.Parse(stringValue);
            float percentage = float.Parse(stringPercentage);

            ISCOPE scope = SCOPE.GetScope(false);
            double min = value - ((value * (percentage / 100.0))); // Note that the time measurements are in ns
            double max = value + ((value * (percentage / 100.0)));

            _scopeMeasureGroup.TheScopeMeanRiseTimeMeasurementShouldBe(scope, min, max);
        }


        /// <summary>
        /// Gets the Scope frequency measurement for the given channel
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// MEASUrement:MEAS[n]:MEAN?
        /// </summary>
        /// <param name="measurement">Which measurement slot</param>
        /// <param name="source">Which channel</param>
        /*!
            \scope\verbatim
        [When(@"I get the frequency mean measurement number ([1-8]) for channel ([1-4]) on the Scope")]
            \endverbatim 
        */
        [When(@"I get the frequency mean measurement number ([1-8]) for channel ([1-4]) on the Scope")]
        public void GetTheScopeFrequencyMeanMeasurement(string measurement, string source)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.MeasureFrequency(scope, measurement, source);
            _scopeMeasureGroup.GetScopeMeasureValueFreqMean(scope, measurement);
        }

        /// <summary>
        /// Compares the frequency time measurement against the expected value within the given percentage tolerance from the Scope. 
        ///
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// MEASUrement:MEAS[n]:MEAN?
        /// </summary>
        /// <param name="scopeType"></param>
        /// <param name="stringValue">Expected frequency time measurement</param>
        /// <param name="stringPercentage">Percentage tolerance</param>
        /*!
            \scope\verbatim
        [Then(@"the frequency measurement should be ([0-9]+.[0-9]+)MHz within ([0-9]+)% on the Scope")]
            \endverbatim 
        */
        [Then(@"the frequency measurement should be ([0-9]+.[0-9]+)MHz within ([0-9]+)% on the Scope")]
        public void TheScopeFrequencyMeasurementShouldBeWithinPercentage(string scopeType, string stringValue, string stringPercentage)
        {
            float value = float.Parse(stringValue);
            float percentage = float.Parse(stringPercentage);

            ISCOPE scope = SCOPE.GetScope(false);
            // Set up the measurement
            double min = value - ((value * (percentage / 100.0)));
            double max = value + ((value * (percentage / 100.0)));
            _scopeMeasureGroup.TheScopeMeanFrequencyMeasurementShouldBe(scope, min, max);
        }
        #endregion MEASUrement:MEAS[n]:MEAN?

        #region MEASUrement:MEAS[n]:SOUrce CH[n]
        /// <summary>
        /// Sets the DPO measurement source for a specified Channel
        /// 
        /// MEASUrement:MEAS[n]:SOUrce CH[n]
        /// 
        /// Only the channels where added as sources for now, if math, ref or histograms is needed see 
        /// Section 2-424 pg 436 in the DPO 7k PI manual
        /// </summary>
        /// <param name="measureSlot">Measurement number 1-8</param>
        /// <param name="source">Which channel to take the measurement from</param>
        /*!
           \scope\verbatim
        [When("I set measurement number ([1-8]) source to channel ([1-4]) on the Scope")]
           \endverbatim 
        */
        [When("I set measurement number ([1-8]) source to channel ([1-4]) on the Scope")]
        public void SetTheScopeMeasurementSource(string measureSlot, string source)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetDPOMeasurementSource(scope, measureSlot, source);
        }
        #endregion MEASUrement:MEAS[n]:SOUrce CH[n]

        #region MEASUrement:MEAS[n]:STATE
        /// <summary>
        /// Sets the measurement state to ON of the specified measurement slot of a Scope
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:STATE
        /// </summary>
        /// <param name="measureSlot">Different numbered measurement displays </param>
        /*!
          \scope\verbatim
        [When(@"I set the measurement number ([1-8]) state to on for the Scope")]
          \endverbatim 
       */
        [When(@"I set the measurement number ([1-8]) state to on for the Scope")]
        public void SetScopeMeasurementSourceToOn(string measureSlot)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetScopeMeasurementState(scope, measureSlot, "ON");
        }

        /// <summary>
        /// Sets the measurement state to OFF of the specified measurement slot of a Scope
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:STATE
        /// </summary>
        /// <param name="measureSlot">Different numbered measurement displays </param>
        /*!
          \scope\verbatim
        [When(@"I set the measurement number ([1-8]) state to off for the Scope")]
          \endverbatim 
       */
        [When(@"I set the measurement number ([1-8]) state to off for the Scope")]
        public void SetScopeMeasurementSourceToOff(string measureSlot)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetScopeMeasurementState(scope, measureSlot, "OFF");
        }
        #endregion MEASUrement:MEAS[n]:STATE

        #region  MEASUrement:MEAS[n]:STDdev?
        /// <summary>
        /// Gets the period std deviation measurement for the given channel on the Scope
        /// 
        /// (DPO/CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// MEASUrement:MEAS[n]:STDdev?
        /// </summary>
        /// <param name="measurement"></param>
        /// <param name="source">Which channel</param>
        /*!
            \scope\verbatim
        [When(@"I get the standard deviation period measurement number ([1-8]) for channel ([1-4]) from the Scope")]
            \endverbatim 
        */
        [When(@"I get the standard deviation period measurement number ([1-8]) for channel ([1-4]) from the Scope")]
        public void GetTheScopePeriodStdDevMeasurement(string measurement, string source)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.MeasurePeriod(scope, measurement, source);
            // Get the value
            _scopeMeasureGroup.GetScopeMeasureValuePeriodStdDev(scope, measurement);
        }

        /// <summary>
        /// Gets the mean std deviation measurement for the given channel on the Scope
        /// 
        /// (DPO/CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// MEASUrement:MEAS[n]:STDdev?
        /// </summary>
        /// <param name="measurement"></param>
        /// <param name="source">Which channel</param>
        /*!
            \scope\verbatim
        [When(@"I get the standard deviation of mean measurement number ([1-8]) for channel ([1-4]) from the Scope")]
            \endverbatim 
        */
        [When(@"I get the standard deviation of mean measurement number ([1-8]) for channel ([1-4]) from the Scope")]
        public void GetTheScopeMeanStdDevMeasurement(string measurement, string source)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.MeasureMean(scope, measurement, source);
            // Get the value
            _scopeMeasureGroup.GetScopeMeasureMeanStdDev(scope, measurement);
        }
        #endregion  MEASUrement:MEAS[n]:STDdev?

        #region MEASUrement:MEAS[n]:TYPe
        /// <summary>
        /// Sets the measurement slot selected to the type AMPlitude for a Scope
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// </summary>
        /// <param name="measureSlot">Which measurement slot</param>
        /*!
            \scope\verbatim
        [When(@"When I set the measurement number ([1-8]) type to amplitude on the Scope")]
            \endverbatim 
       */
        [When(@"I set the measurement number ([1-8]) type to amplitude on the Scope")]
        public void SetTheScopeMeasurementTypeAmplitude(string measureSlot)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetScopeMeasurementType(scope, measureSlot, "AMPlitude");
        }

        /// <summary>
        /// Sets the measurement slot selected to the type BURst for a Scope
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// </summary>
        /// <param name="measureSlot">Which measurement slot</param>
        /*!
            \scope\verbatim
        [When(@"When I set the measurement number ([1-8]) type to burst on the Scope")]
            \endverbatim 
       */
        [When(@"I set the measurement number ([1-8]) type to burst on the Scope")]
        public void SetTheScopeMeasurementTypeBurst(string measureSlot)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetScopeMeasurementType(scope, measureSlot, "BURst");
        }

        /// <summary>
        /// Sets the measurement slot selected to the type FALL for a Scope
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// </summary>
        /// <param name="measureSlot">Which measurement slot</param>
        /*!
            \scope\verbatim
        [When(@"When I set the measurement number ([1-8]) type to fall on the Scope")]
            \endverbatim 
       */
        [When(@"I set the measurement number ([1-8]) type to fall on the Scope")]
        public void SetTheScopeMeasurementTypeFall(string measureSlot)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetScopeMeasurementType(scope, measureSlot, "FALL");
        }

        /// <summary>
        /// Sets the measurement slot selected to the type FREQuency for a Scope
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// </summary>
        /// <param name="measureSlot">Which measurement slot</param>
        /*!
            \scope\verbatim
        [When(@"When I set the measurement number ([1-8]) type to frequency on the Scope")]
            \endverbatim 
       */
        [When(@"I set the measurement number ([1-8]) type to frequency on the Scope")]
        public void SetTheScopeMeasurementTypeFrequency(string measureSlot)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetScopeMeasurementType(scope, measureSlot, "FREQuency");
        }

        /// <summary>
        /// Sets the measurement slot selected to the type HIGH for a Scope
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// </summary>
        /// <param name="measureSlot">Which measurement slot</param>
        /*!
            \scope\verbatim
        [When(@"I set the measurement number ([1-8]) type to high on the Scope")]
            \endverbatim 
       */
        [When(@"I set the measurement number ([1-8]) type to high on the Scope")]
        public void SetTheScopeMeasurementTypeHigh(string measureSlot)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetScopeMeasurementType(scope, measureSlot, "HIGH");
        }

        /// <summary>
        /// Sets the measurement slot selected to the type HITs for a Scope
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// </summary>
        /// <param name="measureSlot">Which measurement slot</param>
        /*!
            \scope\verbatim
        [When(@"I set the measurement number ([1-8]) type to hits on the Scope")]
            \endverbatim 
       */
        [When(@"I set the measurement number ([1-8]) type to hits on the Scope")]
        public void SetTheScopeMeasurementTypeHits(string measureSlot)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetScopeMeasurementType(scope, measureSlot, "HITs");
        }

        /// <summary>
        /// Sets the measurement slot selected to the type LOW for a Scope
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// </summary>
        /// <param name="measureSlot">Which measurement slot</param>
        /*!
            \scope\verbatim
        [When(@"I set the measurement number ([1-8]) type to low on the Scope")]
            \endverbatim 
       */
        [When(@"I set the measurement number ([1-8]) type to low on the Scope")]
        public void SetTheScopeMeasurementTypeLow(string measureSlot)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetScopeMeasurementType(scope, measureSlot, "LOW");
        }

        /// <summary>
        /// Sets the measurement slot selected to the type MAXimum for a Scope
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// </summary>
        /// <param name="measureSlot">Which measurement slot</param>
        /*!
            \scope\verbatim
        [When(@"I set the measurement number ([1-8]) type to maximum on the Scope")]
            \endverbatim 
       */
        [When(@"I set the measurement number ([1-8]) type to maximum on the Scope")]
        public void SetTheScopeMeasurementTypeMaximum(string measureSlot)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetScopeMeasurementType(scope, measureSlot, "MAXimum");
        }

        /// <summary>
        /// Sets the measurement slot selected to the type MEAN for a Scope
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// </summary>
        /// <param name="measureSlot">Which measurement slot</param>
        /*!
            \scope\verbatim
        [When(@"I set the measurement number ([1-8]) type to mean on the Scope")]
            \endverbatim 
       */
        [When(@"I set the measurement number ([1-8]) type to mean on the Scope")]
        public void SetTheScopeMeasurementTypeMean(string measureSlot)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetScopeMeasurementType(scope, measureSlot, "MEAN");
        }

        /// <summary>
        /// Sets the measurement slot selected to the type MEDian for a Scope
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// </summary>
        /// <param name="measureSlot">Which measurement slot</param>
        /*!
            \scope\verbatim
        [When(@"I set the measurement number ([1-8]) type to median on the Scope")]
            \endverbatim 
       */
        [When(@"I set the measurement number ([1-8]) type to median on the Scope")]
        public void SetTheScopeMeasurementTypeMedian(string measureSlot)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetScopeMeasurementType(scope, measureSlot, "MEDian");
        }

        /// <summary>
        /// Sets the measurement slot selected to the type MINImum for a Scope
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// </summary>
        /// <param name="measureSlot">Which measurement slot</param>
        /*!
            \scope\verbatim
        [When(@"I set the measurement number ([1-8]) type to minimum on the Scope")]
            \endverbatim 
       */
        [When(@"I set the measurement number ([1-8]) type to minimum on the Scope")]
        public void SetTheScopeMeasurementTypeMinimum(string measureSlot)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetScopeMeasurementType(scope, measureSlot, "MINImum");
        }

        /// <summary>
        /// Sets the measurement slot selected to the type NCROss for a Scope
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// </summary>
        /// <param name="measureSlot">Which measurement slot</param>
        /*!
            \scope\verbatim
        [When(@"I set the measurement number ([1-8]) type to negative cross timing on the Scope")]
            \endverbatim 
       */
        [When(@"I set the measurement number ([1-8]) type to negative cross timing on the Scope")]
        public void SetTheScopeMeasurementTypeNegCross(string measureSlot)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetScopeMeasurementType(scope, measureSlot, "NCROss");
        }

        /// <summary>
        /// Sets the measurement slot selected to the type NCROss for a Scope
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// </summary>
        /// <param name="measureSlot">Which measurement slot</param>
        /*!
            \scope\verbatim
        [When(@"I set the measurement number ([1-8]) type to negative duty cycle on the Scope")]
            \endverbatim 
       */
        [When(@"I set the measurement number ([1-8]) type to negative duty cycle on the Scope")]
        public void SetTheScopeMeasurementTypeNegDuty(string measureSlot)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetScopeMeasurementType(scope, measureSlot, "NDUty");
        }

        /// <summary>
        /// Sets the measurement slot selected to the type negative pulse width timing for a Scope
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// </summary>
        /// <param name="measureSlot">Which measurement slot</param>
        /*!
            \scope\verbatim
        [When(@"I set the measurement number ([1-8]) type to negative pulse width timing on the Scope")]
            \endverbatim 
       */
        [When(@"I set the measurement number ([1-8]) type to negative pulse width timing on the Scope")]
        public void SetTheScopeMeasurementTypeNegPulseWidth(string measureSlot)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetScopeMeasurementType(scope, measureSlot, "NWIdth");
        }

        /// <summary>
        /// Sets the measurement slot selected to the type PERIod for a Scope
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// </summary>
        /// <param name="measureSlot">Which measurement slot</param>
        /*!
            \scope\verbatim
        [When(@"I set the measurement number ([1-8]) type to period on the Scope")]
            \endverbatim 
       */
        [When(@"I set the measurement number ([1-8]) type to period on the Scope")]
        public void SetTheScopeMeasurementTypePeriod(string measureSlot)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetScopeMeasurementType(scope, measureSlot, "PERIod");
        }

        /// <summary>
        /// Sets the measurement slot selected to the type PHAse for a Scope
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// </summary>
        /// <param name="measureSlot">Which measurement slot</param>
        /*!
            \scope\verbatim
        [When(@"I set the measurement number ([1-8]) type to phase on the Scope")]
            \endverbatim 
       */
        [When(@"I set the measurement number ([1-8]) type to phase on the Scope")]
        public void SetTheScopeMeasurementTypePhase(string measureSlot)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetScopeMeasurementType(scope, measureSlot, "PHAse");
        }

        /// <summary>
        /// Sets the measurement slot selected to the type PK2Pk for a Scope
        /// 
        /// (DPO|CSA)(DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// </summary>
        /// <param name="measureSlot">Which measurement slot</param>
        /*!
            \scope\verbatim
        [When(@"I set the measurement number ([1-8]) type to peak to peak on the Scope")]
            \endverbatim 
       */
        [When(@"I set the measurement number ([1-8]) type to peak to peak on the Scope")]
        public void SetTheScopeMeasurementTypePk2Pk(string measureSlot)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetScopeMeasurementType(scope, measureSlot, "PK2Pk");
        }

        /// <summary>
        /// Sets the measurement slot selected to the type PKPKJitter for a Scope
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// </summary>
        /// <param name="measureSlot">Which measurement slot</param>
        /*!
            \scope\verbatim
        [When(@"I set the measurement number ([1-8]) type to jitter on the Scope")]
            \endverbatim 
       */
        [When(@"I set the measurement number ([1-8]) type to jitter on the Scope")]
        public void SetTheScopeMeasurementTypePkPkJitter(string measureSlot)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetScopeMeasurementType(scope, measureSlot, "PKPKJitter");
        }

        /// <summary>
        /// Sets the measurement slot selected to the type psoitive pulse width timing for a Scope
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// </summary>
        /// <param name="measureSlot">Which measurement slot</param>
        /*!
            \scope\verbatim
        [When(@"I set the measurement number ([1-8]) type to positive pulse width timing on the Scope")]
            \endverbatim 
       */
        [When(@"I set the measurement number ([1-8]) type to positive pulse width timing on the Scope")]
        public void SetTheScopeMeasurementTypePosPulseWidth(string measureSlot)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetScopeMeasurementType(scope, measureSlot, "PWIdth");
        }
        
        /// <summary>
        /// Sets the measurement slot selected to the type RISe for a Scope
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// </summary>
        /// <param name="measureSlot">Which measurement slot</param>
        /*!
            \scope\verbatim
        [When(@"I set the measurement number ([1-8]) type to rise on the Scope")]
            \endverbatim 
       */
        [When(@"I set the measurement number ([1-8]) type to rise on the Scope")]
        public void SetTheScopeMeasurementTypeRise(string measureSlot)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.SetScopeMeasurementType(scope, measureSlot, "RISe");
        }
        #endregion MEASUrement:MEAS[n]:TYPe

        #region MEASUrement:MEAS[n]:VALue?
        /// <summary>
        /// Gets the Scope amplitude measurement for the given channel
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:VALue?
        /// 
        /// </summary>
        /// <param name="measurement"></param>
        /// <param name="source">Which channel</param>
        /*!
            \scope\verbatim
        [When(@"I get the amplitude value of measurement number ([1-8]) for channel ([1-4]) on the Scope")]
            \endverbatim 
        */
        [When(@"I get the amplitude value of measurement number ([1-8]) for channel ([1-4]) on the Scope")]
        public void GetTheScopeAmplitudeMeasurement(string measurement, string source)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.MeasureAmplitude(scope, measurement, source);
            // Get the value
            _scopeMeasureGroup.GetScopeMeasureValueAmp(scope, measurement);
        }

        /// <summary>
        /// Gets the Scope burst measurement for the given channel
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:VALue?
        /// 
        /// </summary>
        /// <param name="measurement"></param>
        /// <param name="source">Which channel</param>
        /*!
            \scope\verbatim
        [When(@"I get the burst value of measurement number ([1-8]) for channel ([1-4]) on the Scope")]
            \endverbatim 
        */
        [When(@"I get the burst value of measurement number ([1-8]) for channel ([1-4]) on the Scope")]
        public void GetTheScopeBurstMeasurement(string measurement, string source)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.MeasureBurst(scope, measurement, source);
            // Get the value
            _scopeMeasureGroup.GetScopeMeasureValueBurst(scope, measurement);
        }

        /// <summary>
        /// Gets the Scope fall timing measurement for the given channel
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:VALue?
        /// 
        /// </summary>
        /// <param name="measurement"></param>
        /// <param name="source">Which channel</param>
        /*!
            \scope\verbatim
        [When(@"I get the fall time measurement number ([1-8]) for channel ([1-4]) on the Scope")]
            \endverbatim 
        */
        [When(@"I get the fall time measurement number ([1-8]) for channel ([1-4]) on the Scope")]
        public void GetTheScopeFallTimingMeasurement(string measurement, string source)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.MeasureFall(scope, measurement, source);
            // Get the value
            _scopeMeasureGroup.GetScopeMeasureValueFall(scope, measurement);
        }

        /// <summary>
        /// Compares the Scope fall time measurement against the expected value within the given percentage tolerance. 
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// MEASUrement:MEAS[n]:VALue?
        /// </summary>
        /// <param name="stringValue">Expected rise time measurement</param>
        /// <param name="stringPercentage">Percentage tolerance</param>
        /*!
            \scope\verbatim
        [Then(@"the fall time measurement should be ([0-9]+.[0-9]+) seconds within ([0-9]+)% on the Scope")]
            \endverbatim 
        */
        [Then(@"the fall time measurement should be ([0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) seconds within ([0-9]+)% on the Scope")]
        public void TheScopeFallTimeMeasurementShouldBeWithinPercentage(string stringValue, string stringPercentage)
        {
            float value = float.Parse(stringValue);
            float percentage = float.Parse(stringPercentage);

            ISCOPE scope = SCOPE.GetScope(false);
            double min = value - ((value * (percentage / 100.0))); // Note that the time measurements are in seconds
            double max = value + ((value * (percentage / 100.0)));

            _scopeMeasureGroup.TheScopeFallTimeMeasurementShouldBe(scope, min, max);
        }

        /// <summary>
        /// Compares the Scope positive pulse width timing measurement against the expected value within the given percentage tolerance. 
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// MEASUrement:MEAS[n]:VALue?
        /// </summary>
        /// <param name="stringValue">Expected positive pulse width timing measurement</param>
        /// <param name="stringPercentage">Percentage tolerance</param>
        /*!
            \scope\verbatim
        [Then(@"the positive pulse width timing should be ([0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) seconds within ([0-9]+)% on the Scope")]
            \endverbatim 
        */
        [Then(@"the positive pulse width timing measurement should be ([0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) seconds within ([0-9]+)% on the Scope")]
        public void TheScopePosPulseWidthMeasurementShouldBeWithinPercentage(string stringValue, string stringPercentage)
        {
            float value = float.Parse(stringValue);
            float percentage = float.Parse(stringPercentage);

            ISCOPE scope = SCOPE.GetScope(false);
            double min = value - ((value * (percentage / 100.0))); // Note that the time measurements are in seconds
            double max = value + ((value * (percentage / 100.0)));

            _scopeMeasureGroup.TheScopePosWidthTimeMeasurementShouldBe(scope, min, max);
        }

        /// <summary>
        /// Compares the Scope negative pulse width timing measurement against the expected value within the given percentage tolerance. 
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// MEASUrement:MEAS[n]:VALue?
        /// </summary>
        /// <param name="stringValue">Expected negative pulse width timing measurement</param>
        /// <param name="stringPercentage">Percentage tolerance</param>
        /*!
            \scope\verbatim
        [Then(@"the negative pulse width timing should be ([0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) seconds within ([0-9]+)% on the Scope")]
            \endverbatim 
        */
        [Then(@"the negative pulse width timing measurement should be ([0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) seconds within ([0-9]+)% on the Scope")]
        public void TheScopeNegPulseWidthMeasurementShouldBeWithinPercentage(string stringValue, string stringPercentage)
        {
            float value = float.Parse(stringValue);
            float percentage = float.Parse(stringPercentage);

            ISCOPE scope = SCOPE.GetScope(false);
            double min = value - ((value * (percentage / 100.0))); // Note that the time measurements are in seconds
            double max = value + ((value * (percentage / 100.0)));

            _scopeMeasureGroup.TheScopeNegWidthTimeMeasurementShouldBe(scope, min, max);
        }

        /// <summary>
        /// Gets the Scope mean measurement value for the given channel
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// MEASUrement:MEAS[n]:VALue?
        /// 
        /// </summary>
        /// <param name="measurement"></param>
        /// <param name="source">Which channel</param>
        /*!
            \scope\verbatim
        [When(@"I get the mean measurement value of measurement number ([1-8]) for channel ([1-4]) on the Scope")]
            \endverbatim 
        */
        [When(@"I get the mean value measurement of measurement number ([1-8]) for channel ([1-4]) on the Scope")]
        public void GetTheScopeMeanMeasurementMeanVal(string measurement, string source)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.MeasureMean(scope, measurement, source);
            // Get the value
            _scopeMeasureGroup.GetScopeMeasureMeanValue(scope, measurement);
        }

        /// <summary>
        /// Gets the Scope mean measurement value for the given channel
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// MEASUrement:MEAS[n]:VALue?
        /// 
        /// </summary>
        /// <param name="measurement"></param>
        /// <param name="source">Which channel</param>
        /*!
            \scope\verbatim
        [When(@"I get the mean measurement value of measurement number ([1-8]) for channel ([1-4]) on the Scope")]
            \endverbatim 
        */
        [When(@"I get the mean measurement value of measurement number ([1-8]) for channel ([1-4]) on the Scope")]
        public void GetTheScopeMeanMeasurementVal(string measurement, string source)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.MeasureMean(scope, measurement, source);
            // Get the value
            _scopeMeasureGroup.GetScopeMeasureValueMean(scope, measurement);
        }

        /// <summary>
        /// Gets the Scope mean measurement value for the given channel
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// MEASUrement:MEAS[n]:VALue?
        /// 
        /// </summary>
        /// <param name="measurement"></param>
        /// <param name="source">Which channel</param>
        /*!
            \scope\verbatim
        [When(@"I get the negative crossing timing value of measurement number ([1-8]) for channel ([1-4]) on the Scope")]
            \endverbatim 
        */
        [When(@"I get the negative crossing timing value of measurement number ([1-8]) for channel ([1-4]) on the Scope")]
        public void GetTheScopeNegativeCrossingMeasurement(string measurement, string source)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.MeasureNegCross(scope, measurement, source);
            // Get the value
            _scopeMeasureGroup.GetScopeMeasureValueNegCrossing(scope, measurement);
        }

        /// <summary>
        /// Gets the Scope negative duty cycle percentage measurement for the given channel
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// MEASUrement:MEAS[n]:VALue?
        /// 
        /// </summary>
        /// <param name="measurement"></param>
        /// <param name="source">Which channel</param>
        /*!
            \scope\verbatim
        [When(@"I get the negative duty cycle percentage measurement number ([1-8]) for channel ([1-4]) on the Scope")]
            \endverbatim 
        */
        [When(@"I get the negative duty cycle percentage measurement number ([1-8]) for channel ([1-4]) on the Scope")]
        public void GetTheScopeNegativeDutyCycleMeasurement(string measurement, string source)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.MeasureNegDuty(scope, measurement, source);
            // Get the value
            _scopeMeasureGroup.GetScopeMeasureValueNegDuty(scope, measurement);
        }

        /// <summary>
        /// Gets the Scope negative pulse width timming measurement for the given channel
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// MEASUrement:MEAS[n]:VALue?
        /// 
        /// </summary>
        /// <param name="measurement"></param>
        /// <param name="source">Which channel</param>
        /*!
            \scope\verbatim
        [When(@"I get the negative width pulse timing value of measurement number ([1-8]) for channel ([1-4]) on the Scope")]
            \endverbatim 
        */
        [When(@"I get the negative width pulse timing value of measurement number ([1-8]) for channel ([1-4]) on the Scope")]
        public void GetTheScopeNegativePulseWidthMeasurement(string measurement, string source)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.MeasureNegWidth(scope, measurement, source);
            // Get the value
            _scopeMeasureGroup.GetScopeMeasureValueNegWidth(scope, measurement);
        }

        /// <summary>
        /// Gets the Scope positive pulse width timming measurement for the given channel
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// MEASUrement:MEAS[n]:VALue?
        /// 
        /// </summary>
        /// <param name="measurement"></param>
        /// <param name="source">Which channel</param>
        /*!
            \scope\verbatim
        [When(@"I get the positive width pulse timing value of measurement number ([1-8]) for channel ([1-4]) on the Scope")]
            \endverbatim 
        */
        [When(@"I get the positive width pulse timing value of measurement number ([1-8]) for channel ([1-4]) on the Scope")]
        public void GetTheScopePositivePulseWidthMeasurement(string measurement, string source)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.MeasurePosWidth(scope, measurement, source);
            // Get the value
            _scopeMeasureGroup.GetScopeMeasureValuePosWidth(scope, measurement);
        }

        /// <summary>
        /// Compares the negative duty cycle percentage measurement against the expected value within the given percentage tolerance from the Scope. 
        ///
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// MEASUrement:MEAS[n]:VALue?
        /// </summary>
        /// <param name="scopeType"></param>
        /// <param name="stringValue">Expected duty cycle measurement</param>
        /// <param name="stringPercentage">Percentage tolerance</param>
        /*!
            \scope\verbatim
        [Then(@"the negative duty cycle percentage should be ([0-9]+.[0-9]+)% within ([0-9]+)% on the Scope")]
            \endverbatim 
        */
        [Then(@"the negative duty cycle percentage should be ([0-9]+.[0-9]+)% within ([0-9]+)% on the Scope")]
        public void TheScopeNegativeDutyCycleMeasurementShouldBeWithinPercentage(string scopeType, string stringValue, string stringPercentage)
        {
            float value = float.Parse(stringValue);
            float percentage = float.Parse(stringPercentage);

            ISCOPE scope = SCOPE.GetScope(false);
            // Set up the measurement
            double min = value - ((value * (percentage / 100.0)));
            double max = value + ((value * (percentage / 100.0)));
            _scopeMeasureGroup.TheScopeNegDutyCycleMeasurementShouldBe(scope, min, max);
        }


        /// <summary>
        /// Gets the Scope minimal measurement for the given channel
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:MINImum?
        /// 
        /// </summary>
        /// <param name="measurement"></param>
        /// <param name="source">Which channel</param>
        /*!
            \scope\verbatim
        [When(@"I get the minimum value of measurement number ([1-8]) for channel ([1-4]) on the Scope")]
            \endverbatim 
        */
        [When(@"I get the minimum value of measurement number ([1-8]) for channel ([1-4]) on the Scope")]
        public void GetTheScopeMinimumMeasurement(string measurement, string source)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.MeasureMinimum(scope, measurement, source);
            // Get the value
            _scopeMeasureGroup.GetScopeMeasurementMinValue(scope, measurement);
        }

        /// <summary>
        /// Gets the Scope minimal measurement for the given channel
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:MINImum?
        /// 
        /// </summary>
        /// <param name="measurement"></param>
        /// <param name="source">Which channel</param>
        /*!
            \scope\verbatim
        [When(@"I get the value of minimum measurement number ([1-8]) for channel ([1-4]) on the Scope")]
            \endverbatim 
        */
        [When(@"I get the value of minimum measurement number ([1-8]) for channel ([1-4]) on the Scope")]
        public void GetTheScopeValueMinimumMeasurement(string measurement, string source)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.MeasureMinimum(scope, measurement, source);
            // Get the value
            _scopeMeasureGroup.GetScopeMeasurementValueMin(scope, measurement);
        }

        /// <summary>
        /// Gets the Scope maximum measurement for the given channel
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:MAXimum?
        /// 
        /// </summary>
        /// <param name="measurement"></param>
        /// <param name="source">Which channel</param>
        /*!
            \scope\verbatim
        [When(@"I get the maximum value of measurement number ([1-8]) for channel ([1-4]) on the Scope")]
            \endverbatim 
        */
        [When(@"I get the maximum value of measurement number ([1-8]) for channel ([1-4]) on the Scope")]
        public void GetTheScopeMaximumMeasurement(string measurement, string source)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.MeasureMaximum(scope, measurement, source);
            // Get the value
            _scopeMeasureGroup.GetScopeMeasurementMaxValue(scope, measurement);
        }


        /// <summary>
        /// Verifies the given Scope amplitude measurement is within a given percentage tolerance
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// MEASUrement:MEAS[n]:VALue?
        /// </summary>
        /// <param name="stringValue">Expected amplitude measurement</param>
        /// <param name="stringPercentage">Percentage accuracy</param>
        /*!
            \scope\verbatim
        [Then(@"the amplitude measurement should be ([0-9]+.[0-9]+)V within ([0-9]+)% om the Scope")]
            \endverbatim 
        */
        [Then(@"the amplitude measurement should be ([0-9]+.[0-9]+)V within ([0-9]+)% on the Scope")]
        public void TheScopeAmplitudeMeasurementShouldBeWithinPercentage(string stringValue, string stringPercentage)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            float value = float.Parse(stringValue);
            float percentage = float.Parse(stringPercentage);

            // Set up the measurement
            double min = value - (value * (percentage / 100.0));
            double max = value + (value * (percentage / 100.0));

            _scopeMeasureGroup.TheScopeAmpMeasurementShouldBe(scope, min, max);
        }

        /// <summary>
        /// Verifies the given Scope minimum measurement is within a given percentage tolerance
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// MEASUrement:MEAS[n]:VALue?
        /// </summary>
        /// <param name="stringValue">Expected amplitude measurement</param>
        /// <param name="stringPercentage">Percentage accuracy</param>
        /*!
            \scope\verbatim
        [Then(@"the minimum measurement should be ([0-9]+.[0-9]+)V within ([0-9]+)% om the Scope")]
            \endverbatim 
        */
        [Then(@"the minimum measurement should be ([0-9]+.[0-9]+)V within ([0-9]+)% on the Scope")]
        public void TheScopeMinimumMeasurementShouldBeWithinPercentage(string stringValue, string stringPercentage)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            float value = float.Parse(stringValue);
            float percentage = float.Parse(stringPercentage);

            // Set up the measurement
            double min = value - (value * (percentage / 100.0));
            double max = value + (value * (percentage / 100.0));

            _scopeMeasureGroup.TheScopeMinMeasurementShouldBe(scope, min, max);
        }

        /// <summary>
        /// Verifies the given minimum measurement is within a given voltage tolerance
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// MEASUrement:MEAS[n]:VALue?
        /// </summary>
        /// <param name="stringValue">Expected minimal measurement</param>
        /// <param name="toleranceVolts">volatge accuracy</param>
        /*!
            \scope\verbatim
        [Then(@"the minimum measurement should be ([0-9]+.[0-9]+)V within ([0-9]+.[0-9]+)V on the Scope")]
            \endverbatim 
        */
        [Then(@"the minimum measurement should be ([0-9]+.[0-9]+)V within ([0-9]+.[0-9]+)V on the Scope")]
        public void TheScopeMinValueMeasurementShouldBeWithinVoltage(string stringValue, string toleranceVolts)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            float value = float.Parse(stringValue);
            float tolerance = float.Parse(toleranceVolts);

            // Set up the measurement
            double min = value - tolerance;
            double max = value + tolerance;

            _scopeMeasureGroup.TheScopeMinMeasurementShouldBe(scope, min, max);
        }
        
        /// <summary>
        /// Verifies the given Scope maximum measurement is within a given percentage tolerance
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// MEASUrement:MEAS[n]:VALue?
        /// </summary>
        /// <param name="stringValue">Expected maximum measurement</param>
        /// <param name="stringPercentage">Percentage accuracy</param>
        /*!
            \scope\verbatim
        [Then(@"the maximum measurement should be ([0-9]+.[0-9]+)V within ([0-9]+)% om the Scope")]
            \endverbatim 
        */
        [Then(@"the maximum measurement should be ([0-9]+.[0-9]+)V within ([0-9]+)% on the Scope")]
        public void TheScopeMaxMeasurementShouldBeWithinPercentage(string stringValue, string stringPercentage)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            float value = float.Parse(stringValue);
            float percentage = float.Parse(stringPercentage);

            // Set up the measurement
            double min = value - (value * (percentage / 100.0));
            double max = value + (value * (percentage / 100.0));

            _scopeMeasureGroup.TheScopeMaxMeasurementShouldBe(scope, min, max);
        }

        /// <summary>
        /// Verifies the given Scope amplitude measurement is within a given percentage tolerance
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// MEASUrement:MEAS[n]:VALue?
        /// </summary>
        /// <param name="stringValue">Expected amplitude measurement</param>
        /// <param name="stringPercentage">Percentage accuracy</param>
        /*!
            \scope\verbatim
        [Then(@"the mean measurement should be ([0-9]+.[0-9]+)V within ([0-9]+)% om the Scope")]
            \endverbatim 
        */
        [Then(@"the mean measurement should be ([0-9]+.[0-9]+)V within ([0-9]+)% on the Scope")]
        public void TheScopeMeanValueMeasurementShouldBeWithinPercentage(string stringValue, string stringPercentage)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            float value = float.Parse(stringValue);
            float percentage = float.Parse(stringPercentage);

            // Set up the measurement
            double min = value - (value * (percentage / 100.0));
            double max = value + (value * (percentage / 100.0));

            _scopeMeasureGroup.TheScopeMeanMeasurementValueShouldBe(scope, min, max);
        }

        /// <summary>
        /// Verifies the given Scope amplitude measurement is within a given percentage tolerance
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// MEASUrement:MEAS[n]:VALue?
        /// </summary>
        /// <param name="stringValue">Expected amplitude measurement</param>
        /// <param name="toleranceVolts">Percentage accuracy</param>
        /*!
            \scope\verbatim
        [Then(@"the mean measurement should be ([0-9]+.[0-9]+)V within ([0-9]+)% om the Scope")]
            \endverbatim 
        */
        [Then(@"the mean measurement should be ([0-9]+.[0-9]+)V within ([0-9]+.[0-9]+)V on the Scope")]
        public void TheScopeMeanValueMeasurementShouldBeWithinVoltage(string stringValue, string toleranceVolts)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            float value = float.Parse(stringValue);
            float tolerance = float.Parse(toleranceVolts);

            // Set up the measurement
            double min = value - tolerance;
            double max = value + tolerance;

            _scopeMeasureGroup.TheScopeMeanMeasurementValueShouldBe(scope, min, max);
        }


        /// <summary>
        /// Gets the peak to peak measurement for the given channel from the Scope
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// MEASUrement:MEAS[n]:VALue?
        /// </summary>
        /// <param name="measurement">which measurement slot</param>
        /// <param name="source">Which channel</param>
        /*!
            \scope\verbatim
        [When(@"I get the amplitude peak to peak measurement number ([1-8]) for channel ([1-4]) on the Scope")]
            \endverbatim 
        */
        [When(@"I get the amplitude peak to peak measurement number ([1-8]) for channel ([1-4]) on the Scope")]
        public void GetTheScopePk2PkAmplitudeMeasurement(string measurement, string source)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            // Set up the measurement
            _scopeMeasureGroup.MeasurePk2Pk(scope, measurement, source);
            // Get the value
            _scopeMeasureGroup.GetScopeMeasureValuePk2Pk(scope, measurement);
        }

        /// <summary>
        /// Verifies the mplitude peak to peak measurement is within a given percentage tolerance on the Scope
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// MEASUrement:MEAS[n]:VALue?
        /// </summary>
        /// <param name="stringValue">Expected amplitude peak to peak measurement</param>
        /// <param name="stringPercentage">Percentage accuracy</param>
        /*!
            \scope\verbatim
        [Then(@"the amplitude peak to peak measurement should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?)V within ([0-9]+)% on the Scope"]
            \endverbatim 
        */
        [Then(@"the amplitude peak to peak measurement should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?)V within ([0-9]+)% on the Scope")]
        public void TheScopeAmplitudePk2PkMeasurementShouldBeWithinPercentage(string stringValue, string stringPercentage)
        {
            ISCOPE scope = SCOPE.GetScope(false);

            float value = float.Parse(stringValue);
            float percentage = float.Parse(stringPercentage);

            // Set up the measurement
            double min = value - ((value * percentage) / 100.0);
            double max = value + ((value * percentage) / 100.0);
            // Get the value
            _scopeMeasureGroup.TheScopePK2PKMeasurementShouldBe(scope, min, max);
        }

        /// <summary>
        /// Gets the jitter measurement for the given channel on the Scope
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// MEASUrement:MEAS[n]:VALue?
        /// </summary>
        /// <param name="measurement"></param>
        /// <param name="source">Which channel</param>
        /*!
            \scope\verbatim
        [When(@"I get the jitter measurement number ([1-8]) for channel ([1-4]) on the Scope")]
            \endverbatim 
        */
        [When(@"I get the jitter measurement number ([1-8]) for channel ([1-4]) on the Scope")]
        public void GetTheScopeJitterMeasurement(string measurement, string source)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.MeasureJitter(scope, measurement, source);
            // Get the value
            _scopeMeasureGroup.GetScopeMeasureValueJitter(scope, measurement);
        }

        /// <summary>
        /// Gets the period measurement for the given channel from the Scope
        /// 
        /// (DPO|CSA)
        /// MEASUrement:MEAS[n]:TYPe
        /// MEASUrement:MEAS[n]:VALue?
        /// </summary>
        /// <param name="measurement">Which measurement slot</param>
        /// <param name="source">Which channel</param>
        /*!
            \scope\verbatim
        [When(@"I get the Scope amplitude measurement for channel ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the period measurement number ([1-8]) for channel ([1-4]) on the Scope")]
        public void GetTheScopePeriodMeasurement(string measurement, string source)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.MeasurePeriod(scope, measurement, source);
            // Get the value
            _scopeMeasureGroup.GetScopeMeasureValuePeriod(scope, measurement);
        }
        #endregion MEASUrement:MEAS[n]:VALue?

        #region MEASUrement:STATistics:COUNt RESET
        /// <summary>
        /// Resets the measurement stats for the DPO scope.
        /// 
        /// MEASUrement:STATistics:COUNt RESET
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"I reset the measurement statistics on the Scope")]
            \endverbatim 
        */
        [When(@"I reset the measurement statistics on the Scope")]
        public void ResetTheScopeMeasurementStatistics()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.ResetDPOMeasurement(scope);
        }
        #endregion MEASUrement:STATistics:COUNt RESET

        #region LogTheScopeMeasurementsIntoFile
        /// <summary>
        /// Takes four measurements from the given source and logs the results in the given file
        /// </summary>
        /// <param name="type1">First measuremnt type FREQ|PK2PK|JITTER|RISE|AMPL</param>
        /// <param name="type2">Second measurement type FREQ|PK2PK|JITTER|RISE|AMPL</param>
        /// <param name="type3">Third measurement type FREQ|PK2PK|JITTER|RISE|AMPL</param>
        /// <param name="type4">Fourth measurement type FREQ|PK2PK|JITTER|RISE|AMPL</param>
        /// <param name="source">Which channel the measurement should be taken from</param>
        /// <param name="filename">Desired name of the log file</param>
        /*!
           \scope\verbatim
        [When("I log four measurements (FREQ|PK2PK|JITTER|RISE|AMPL|PERIOD) and (FREQ|PK2PK|JITTER|RISE|AMPL|PERIOD) and (FREQ|PK2PK|JITTER|RISE|AMPL|PERIOD) and (FREQ|PK2PK|JITTER|RISE|AMPL|PERIOD) at CH([1-4]) into a file named (.+)")]
           \endverbatim 
       */
        [When("I log four measurements (FREQ|PK2PK|JITTER|RISE|AMPL|PERIOD) and (FREQ|PK2PK|JITTER|RISE|AMPL|PERIOD) and (FREQ|PK2PK|JITTER|RISE|AMPL|PERIOD) and (FREQ|PK2PK|JITTER|RISE|AMPL|PERIOD) at CH([1-4]) into a file named (.+)")]
        public void LogTheScopeMeasurementsIntoFile(string type1, string type2, string type3, string type4, string source, string filename)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.GetFourDPOMeasurementsandStore(scope, type1, type2, type3, type4, source, filename);
        }
        #endregion LogTheScopeMeasurementsIntoFile

        #region  ScopeShouldStayInStateWhileLogging
        public void ScopeShouldStayInStateWhileLogging(ISCOPE scope, long timeout, int checkInterval)
        {
            UTILS.HiPerfTimer Timer1 = new UTILS.HiPerfTimer();
            double totalTime = 0;
            const string triggerHappy = "TRIGGER"; //Indicates there is a waveform to be be triggered from 
            //First check before entering loop
            _scopeTriggerGroup.GetScopeTriggerState(scope);
            string trig = scope.ScopeTriggerState;
            if (trig != triggerHappy)
            {
                if (trig != "") //Don't view a return of an empty string as a fail, just queueing problems 
                {
                    Assert.Fail("Scope no longer in " + triggerHappy + " state");
                }
            }

            // Start the timer, and wait up to the max amount of time 
            while (totalTime < timeout)
            {
                Timer1.Start();
                _scopeTriggerGroup.GetScopeTriggerState(scope);
                trig = scope.ScopeTriggerState;
                if (trig != triggerHappy)
                {
                    if (trig != "") //Don't view a return of an empty string as a fail, just queueing problems 
                    {
                        _scopeMeasureGroup.GetFourDPOMeasurementsandStore(scope, "JITTER", "AMPL", "FREQ",
                            "PERIOD,\n\n*LOST TRIGGER @ " + UTILS.NiceTime + " *", "1",
                            "Long Term Waveform Test" + UTILS.NiceDate);
                        Assert.Fail("Scope no longer in " + triggerHappy + " state");
                    }
                }
                Thread.Sleep(checkInterval); // Have to make sure this is between the start/stop commands
                _scopeMeasureGroup.GetFourDPOMeasurementsandStore(scope, "JITTER", "AMPL", "FREQ", "PERIOD", "1",
                    "Long Term Waveform Test" + UTILS.NiceDate);
                Timer1.Stop();
                totalTime = totalTime + Timer1.Duration; // Add the current interval to the total
            }

        }
        /// <summary>
        /// The DPO Scope should stay in RUN mode for the specified time period in seconds while logging measurements.
        /// </summary>
        /// <param name="time">Time in seconds to check the DPO stays in the given state</param>
        /*!
           \scope\verbatim
        [Then("the state should stay in RUN for ([0-9]+) seconds logging measurements on the Scope")]
           \endverbatim 
       */
        [Then("the state should stay in RUN for ([0-9]+) seconds logging measurements on the Scope")]
        public void TheScopeShouldStayInStateAndLogMeasurementsForSeconds(string time)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            int timeout = Int16.Parse(time);
            int checkInterval = 500;
            ScopeShouldStayInStateWhileLogging(scope, timeout, checkInterval);
        }

        /// <summary>
        /// The DPO Scope should stay in RUN mode for the specified time period in minutes while logging measurements.
        /// </summary>
        /// <param name="time">Time in minutes to check the DPO stays in the given state</param>
        /*!
           \scope\verbatim
        [Then("the state should stay in RUN for ([0-9]+) minutes logging measurements on the Scope")]
           \endverbatim 
       */
        [Then("the state should stay in RUN for ([0-9]+) minutes logging measurements on the Scope")]
        public void TheScopeShouldStayInStateAndLogMeasurementsForMinutes(string time)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            int value = Int16.Parse(time);
            int checkInterval = 10000; //value in milliseconds
            long timeout = value * 60; //value in seconds
            ScopeShouldStayInStateWhileLogging(scope, timeout, checkInterval);
        }
        #endregion  ScopeShouldStayInStateWhileLogging

        #region CSA Only
        #region MEASUrement:MEAS1:STATistics:CLEAR
        /// <summary>
        /// Resets the measurement stats for the CSA scope.
        /// 
        /// MEASUrement:MEAS1:STATistics:CLEAR
        /// </summary>
        /*!
            \CSA\verbatim
        [When(@"I reset the measurement statistics on the CSA")]
            \endverbatim 
        */
        [When(@"I reset the measurement statistics on the CSA")]
        public void ResetTheCSAScopeMeasurementStatistics()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeMeasureGroup.ResetCSAMeasurement(scope);
        }
        #endregion MEASUrement:MEAS1:STATistics:CLEAR
        #endregion CSA only
    }
}
