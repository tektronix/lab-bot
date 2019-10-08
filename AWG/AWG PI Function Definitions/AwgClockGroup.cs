//==========================================================================
// AwgClockGroup.cs
//==========================================================================
using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains helper functions that are called from the %AWG Clock PI step definitions.
    /// This class has no restrictions as to where it will be used.
    /// 
    /// This "Helper" group does everything else but steps and TekVISA.
    /// Using parameters from the step, each helper will makes decisions
    /// such as send commands, or process responses from queries and
    /// do testing and generate asserts if necessary.
    /// 
    /// CLOCk:ECLock:DIVider
    /// 
    /// \ingroup grouphelperpi pisteps
    /// 
    /// </summary>
    public class AwgClockGroup
    {
        readonly UtilitiesGroup _utilitiesGroup = new UtilitiesGroup();

        public enum SyncClockOutputState { On, Off }
        public enum SourceClock { Internal, External, Fixed, Variable }

        public  enum ExternalClockDividerAs {Value, Min, Max}

        private const string ExternalClockDividerMaxSyntax = "MAX";
        private const string ExternalClockDividerMinSyntax = "MIN";

        public enum ClockPhaseAs { Nr1, Min, Max }

        private const string ClockPhaseMaxSyntax = "MAX";
        private const string ClockPhaseMinSyntax = "MIN";

        public enum ClockJitterState { On, Off }

        private const string ClockJitterStateOnSyntax  = "1";
        private const string ClockJitterStateOffSyntax = "0";

        public enum ClockOutputState { On, Off }

        private const string ClockOutputStateOnSyntax = "1";
        private const string ClockOutputStateOffSyntax = "0";

        public enum ClockSampleRateAs { Value, Min, Max }

        private const string ClockSampleRateMaxSyntax = "MAX";
        private const string ClockSampleRateMinSyntax = "MIN";

        #region CLOCk:ECLock:DIVider

        //glennj 9/5/2013
        /// <summary>
        /// Using CLOCk:ECLock:DIVider to set the divider
        /// 
        /// CLOCk:ECLock:DIVider
        /// 
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValueAs">Set as min, max or as value</param>
        /// <param name="setValue">Divide by a power of 2</param>
        public void SetClockExternalDivider(IAWG awg, string clockNumber, ExternalClockDividerAs setValueAs, string setValue = "")
        {
            var finalValue = setValue;
            switch (setValueAs)
            {
                case ExternalClockDividerAs.Min:
                    finalValue = ExternalClockDividerMinSyntax;
                    break;
                case ExternalClockDividerAs.Max:
                    finalValue = ExternalClockDividerMaxSyntax;
                    break;
            }
            awg.SetClockExternalDivider(clockNumber, finalValue);
        }

        //glennj 9/5/2013
        /// <summary>
        /// Using CLOCk:ECLock:DIVider? to get the divider setting
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="clockNumber">Which clock</param>
        /// <returns>The divider setting</returns>
        public void GetClockExternalDivider(IAWG awg, string clockNumber)
        {
            awg.GetClockExternalDivider(clockNumber);
        }

        public void ClockExternalDividerShouldBe(IAWG awg, string clockNumber, string expectedDivider)
        {
            string clockExternalDivider = awg.ClockExternalDivider(clockNumber);
            string possibleErrorString = "Checking the external clock divider rate for clock " + clockNumber;
            Assert.AreEqual(float.Parse(expectedDivider), float.Parse(clockExternalDivider), possibleErrorString);
        }

        #endregion CLOCk:ECLock:DIVider

        #region CLOCk:ECLock:FREQuency
        // Unkown 01/01/01
        /// <summary>
        /// Using CLOCk:ECLock:FREQuency Set expected frequency being provided by the external clock
        /// </summary>
        /// <param name="awg">awg object</param>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Frequency being provided by the external clock</param>
        public void SetExternalClockFrequency(IAWG awg, string clockNumber, string setValue)
        {
            awg.SetClockExternalClockFrequency(clockNumber, setValue);
        }

        // Unkown 01/01/01
        /// <summary>
        /// Returns expected frequency being provided by the external clock
        /// 
        /// CLOCk:ECLock:FREQuency?
        /// </summary>
        /// <param name="awg">awg object</param>
        /// <param name="clockNumber">Which clock</param>
        /// <returns>Frequency being provided by the external clock</returns>
        public void GetExternalClockFrequency(IAWG awg, string clockNumber)
        {
            awg.GetClockExternalClockFrequency(clockNumber);
        }

        public void ExternalClockFrequencyShouldBe(IAWG awg, string clockNumber, string expectedValue)
        {
            string possibleErrorString = "Checking the external clock frequency" + clockNumber;
            Assert.AreEqual(expectedValue, awg.ClockExternalClockFrequency(clockNumber), possibleErrorString);
        }

        public void ExternalClockFrequencyShouldBeWithinTolerance(IAWG awg, string clockNumber, string expectedValue, string percent)
        {
            float value = float.Parse(expectedValue); //Parse the string to begin calculations
            float percentage = float.Parse(percent);

            double min = value - ((value * (percentage / 100.0)));
            double max = value + ((value * (percentage / 100.0)));

            double mean = float.Parse(awg.ClockExternalClockFrequency(clockNumber));
            string possibleErrorString = "External clock frequency reading, " + mean + ", not within " + percent + "% of " + expectedValue + " for clock " + clockNumber;
            Assert.IsTrue((mean >= min) && (mean <= max), possibleErrorString);
        }
        #endregion CLOCk:ECLock:FREQuency

        #region CLOCk:ECLock:FREQuency:ADJust

        public void AdjustExternalClockFrequency(IAWG awg, string clockNumber)
        {
            awg.AdjustClockExternalClockFrequency(clockNumber);
        }
        

        #endregion CLOCk:ECLock:FREQuency:ADJust

        #region CLOCk:ECLock:FREQuency:DETect

        /// <summary>
        /// Tell the AWG to detect the external clock frequency
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="clockNumber"></param>
        public void DetectExternalClockFrequency(IAWG awg, string clockNumber)
        {
            awg.ClockExternalClockFrequencyAuto(clockNumber);
        }

        #endregion CLOCk:ECLock:FREQuency:DETect

        #region CLOCk:ECLock:MULTiplier
        // Unkown 01/01/01
        /// <summary>
        /// Using CLOCk:ECLock:MULTiplier set the multipler rate of the external clock
        /// </summary>
        /// <param name="awg">awg object</param>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Multipler rate of the external clock</param>
        public void SetClockMultiplier(IAWG awg, string clockNumber, string setValue)
        {
            awg.SetExternalClockMultiplier(clockNumber, setValue);
        }

        // Unkown 01/01/01
        /// <summary>
        /// Using CLOCk:ECLock:MULTiplier? get the multipler rate of the external clock.
        /// 
        /// CLOCk{n}:MULTiplier?
        /// </summary>
        /// <param name="awg">awg object</param>
        /// <param name="clockNumber">Which clock</param>
        /// <returns>Multipler rate of the external clock</returns>
        public void GetClockMultiplier(IAWG awg, string clockNumber)
        {
            awg.GetExternalClockMultiplier(clockNumber);
        }

        //glennj 12/5/2013
        /// <summary>
        /// Compare updated clock multipler for the AWG against<para>
        /// the expected multipler.</para><para>
        /// Note: Written as if association with more than 1 clock was possible.</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedValue"></param>
        /// <param name="clockNumber"></param>
        public void ClockMultiplerRateValueShouldBe(IAWG awg, string expectedValue, string clockNumber = "1")
        {
            string possibleErrorString = "Verifying the multipler for clock " + clockNumber;
            Assert.AreEqual(expectedValue, awg.ClockMultipler(clockNumber), possibleErrorString);
        }

        #endregion CLOCk:ECLock:MULTiplier

        #region CLOCk:EREFerence:DIVider
        // Unkown 01/01/01
        /// <summary>
        /// Sets the divider rate of the external reference signal when the external reference is variable
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="clockNumber"></param>
        /// <param name="setValue"></param>
        public void SetExternalReferenceClockDivider(IAWG awg, string clockNumber, string setValue)
        {
            awg.SetExternalReferenceClockDivider(clockNumber, setValue);
        }

        // Unkown 01/01/01
        /// <summary>
        /// Updates the awg's copy of the divider rate of the external reference signal and<para>
        /// and returns a copy of it</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="clockNumber"></param>
        /// <returns></returns>
        public void GetExternalReferenceClockDivider(IAWG awg, string clockNumber)
        {
            awg.GetExternalReferenceClockDivider(clockNumber);
        }

        //Kavitha: 01/17/2013 Corrected the default statement
        /// <summary>
        /// Compares the expected value to a previously saved one.
        /// </summary>
        /// <param name="awg">the object</param>
        /// <param name="clockNumber">the clock</param>
        /// <param name="expectedValue">the value to compare against</param>
        public void ExternalReferenceClockDividerShouldBe(IAWG awg, string clockNumber, string expectedValue)
        {
            string externalReferenceClockDivider = awg.ExternalReferenceClockDivider(clockNumber);
            string possibleErrorString = "Checking the external reference divider for clock " + clockNumber;
            Assert.AreEqual(expectedValue, externalReferenceClockDivider, possibleErrorString);
        }
        #endregion CLOCk:EREFerence:DIVider

        #region CLOCk:EREFerence:FREQuency

        //sforell 8/19/13 renamed by adding "External"
        // Unkown 01/01/01
        /// <summary>
        /// Sets expected frequency being provided by the external clock
        /// </summary>
        /// <param name="awg">awg object</param>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Frequency being provided by the external reference</param>
        public void SetExternalClockReferenceFrequency(IAWG awg, string clockNumber, string setValue)
        {
            awg.SetClockExternalReferenceFrequency(clockNumber, setValue);
        }

        //sforell 8/19/13 renamed by adding "External"
        // Unkown 01/01/01
        /// <summary>
        /// Update the expected frequency being provided by the external reference
        /// </summary>
        /// <param name="awg">awg object</param>
        /// <param name="clockNumber">Which clock</param>
        /// <returns>Frequency being provided by the external reference</returns>
        public void GetExternalClockReferenceFrequency(IAWG awg, string clockNumber)
        {
            awg.GetClockExternalReferenceFrequency(clockNumber);
        }

        //glennj 12/5/2013
        /// <summary>
        /// Compares the expected value to the updated awg attribute for the external clock reference frequency
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="clockNumber"></param>
        /// <param name="expectedValue"></param>
        public void ExternalClockReferenceFrequencyShouldBe(IAWG awg, string clockNumber, string expectedValue)
        {
            string possibleErrorString = "Checking the external reference frequency for clock " + clockNumber;
            Assert.AreEqual(float.Parse(expectedValue), float.Parse(awg.ClockExternalReferenceFrequency(clockNumber)), possibleErrorString);
        }

        #endregion CLOCk:EREFerence:FREQuency

        #region CLOCk:EREFerence:FREQuency:DETect
        
        //glennj 06/10/2013
        /// <summary>
        /// Tells the system to acquire the external reference and adjust the system to use it
        /// </summary>
        /// <param name="awg">awg object</param>
        /// <param name="clockNumber">Which clock</param>
        public void ForceClockReferenceFrequencyAutoDetect(IAWG awg, string clockNumber) 
        {
            awg.ForceClockExternalReferenceFrequencyDetect(clockNumber);
        }

        #endregion CLOCk:EREFerence:FREQuency:DETect

        #region CLOCk:EREFerence:MULTiplier

        // Unkown 01/01/01
        /// <summary>
        /// This is now just a pass through for setting the external reference clock<para>
        /// multiplier value.  There is no additional processing.  This is not</para><para>
        /// responsible (at the moment) for any error checking.</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="clockNumber"></param>
        /// <param name="setValue"></param>
        public void SetExternalReferenceClockMultiplierTo(IAWG awg, string clockNumber, string setValue)
        {
            awg.SetExternalReferenceClockMultiplier(clockNumber, setValue);
        }

        // Unkown 01/01/01
        /// <summary>
        /// This queries for the current setting of the external reference clock<para>
        /// multiplier value.  The response is saved in the AWG object.</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="clockNumber"></param>
        public void GetExternalReferenceClockMultiplier(IAWG awg, string clockNumber)
        {
            awg.GetExternalReferenceClockMultiplier(clockNumber);
        }

        //Kavitha: 01/17/2013 Corrected the default statement
        /// <summary>
        /// Compares the expected value to a previously saved one.
        /// </summary>
        /// <param name="awg">the object</param>
        /// <param name="clockNumber">the clock</param>
        /// <param name="expectedValue">the value to compare against</param>
        public void ExternalReferenceClockMultiplierShouldBe(IAWG awg, string clockNumber, string expectedValue)
        {
            string externalReferenceClockMultiplier = awg.ExternalReferenceClockMultiplier(clockNumber);
            string possibleErrorString = "Checking the External Reference Multiplier for clock " + clockNumber;
            Assert.AreEqual(Convert.ToDouble(expectedValue), Convert.ToDouble(externalReferenceClockMultiplier), possibleErrorString);
        }

        #endregion CLOCk:EREFerence:MULTiplier

        #region CLOCk:JITTer

        //glennj 6/7/2013
        /// <summary>
        /// Sets whether low jitter is enabled on the system.
        /// </summary>
        /// <param name="awg">awg object</param>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="jitterState"></param>
        public void SetClockJitter(IAWG awg, string clockNumber, ClockJitterState jitterState)
        {
            var setValue = (jitterState == ClockJitterState.Off) ? ClockJitterStateOffSyntax : ClockJitterStateOnSyntax;
            awg.SetClockJitter(clockNumber, setValue);
        }

        //glennj 6/7/2013
        /// <summary>
        /// Returns whether low jitter is enabled on the system after<para>
        /// updating the Awg's local copy</para>
        /// </summary>
        /// <param name="awg">awg object</param>
        /// <param name="clockNumber">Which clock</param>
        /// <returns>Whether low jitter is enabled</returns>
        public void GetClockJitter(IAWG awg, string clockNumber)
        {
            awg.GetClockJitter(clockNumber);
        }

        //glennj 9/12/2013
        public void ClockJitterValueShouldBe(IAWG awg, string clockNumber, ClockJitterState jitterState)
        {
            var expectedValue = (jitterState == ClockJitterState.Off) ? ClockJitterStateOffSyntax : ClockJitterStateOnSyntax;
            string clockJitter = awg.ClockJitter(clockNumber);
            string possibleErrorString = "Checking the jitter for clock " + clockNumber;
            Assert.AreEqual(expectedValue, clockJitter, possibleErrorString);
        }

        #endregion CLOCk:JITTer

        #region CLOCk:OUTPut:FREQuency

        // Unkown 01/01/01
        /// <summary>
        /// Returns the output frequency of the specified clock after<para>
        /// updating the Awg's local copy</para>
        /// </summary>
        /// <param name="awg">awg object</param>
        /// <param name="clockNumber">Which clock</param>
        /// <returns>Output frequency</returns>
        public void GetClockOutputFrequency(IAWG awg, string clockNumber)
        {
            awg.GetClockOutputFrequency(clockNumber);
        }

        //glennj 1/30/2014
        /// <summary>
        /// Some frequencies will not be exact as set.  They will be expected to be within a range though.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="clockNumber"></param>
        /// <param name="expectedValue"></param>
        /// <param name="percent"></param>
        public void ClockOutputFrequencyShouldBe(IAWG awg, string clockNumber, string expectedValue, string percent=null)
        {
            string possibleErrorString = "Checking the output clock frequency for clock " + clockNumber;
            if (percent == null)
            {
                Assert.AreEqual(float.Parse(expectedValue), float.Parse(awg.ClockOutputFrequency(clockNumber)), possibleErrorString);
            }
            else
            {
                float value = float.Parse(expectedValue); //Parse the string to begin calculations
                float percentage = float.Parse(percent);

                double min = value - ((value * (percentage / 100.0)));
                double max = value + ((value * (percentage / 100.0)));

                double actual = float.Parse(awg.ClockOutputFrequency(clockNumber));

                Assert.IsTrue((actual >= min) && (actual <= max), "Output clock frequency of " + actual + " was not between " + min + " and " + max);
            }
        }

        #endregion CLOCk:OUTPut:FREQuency

        #region CLOCk:OUTPut:STATe

        // Unkown 01/01/01
        /// <summary>
        /// Sets the output state of the specified clock.
        /// </summary>
        /// <param name="awg">awg object</param>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="outputState"></param>
        public void SetClockOutputState(IAWG awg, string clockNumber, ClockOutputState outputState)
        {
            string setValue = outputState == ClockOutputState.On ? ClockOutputStateOnSyntax : ClockOutputStateOffSyntax;
            awg.SetClockOutputState(clockNumber, setValue);
        }

        // Unkown 01/01/01
        /// <summary>
        /// Returns the output state of the specified clock after<para>
        /// updating the Awg's local copy</para>
        /// </summary>
        /// <param name="awg">awg object</param>
        /// <param name="clockNumber">Which clock</param>
        /// <returns>Output state</returns>
        public void GetClockOutputState(IAWG awg, string clockNumber)
        {
            awg.GetClockOutputState(clockNumber);
        }

        public void ClockOutputStateShouldBe(IAWG awg, string clockNumber, ClockOutputState expectedValue)
        {
            string interpretiveValue = expectedValue == ClockOutputState.On ? ClockOutputStateOnSyntax : ClockOutputStateOffSyntax;

            string clockOutputState = awg.ClockOutputState(clockNumber);
            string possibleErrorString = "Checking the output state for clock " + clockNumber;
            Assert.AreEqual(interpretiveValue, clockOutputState, possibleErrorString);
            
        }


        #endregion CLOCk:OUTPut:STATe

        #region CLOCk:PHASe:ADJust

        //glennj 9/11/2013
        /// <summary>
        /// TSets the internal clock phase adjustment of the AWG
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="clockNumber"></param>
        /// <param name="phaseAs"></param>
        /// <param name="setValue"></param>
        public void SetClockPhaseAdjust(IAWG awg, string clockNumber, ClockPhaseAs phaseAs, string setValue = "")
        {
            var andTheFinalValueIs = setValue;
            if (phaseAs != ClockPhaseAs.Nr1)
            {
                andTheFinalValueIs = (phaseAs == ClockPhaseAs.Max) ? ClockPhaseMaxSyntax : ClockPhaseMinSyntax;
            }
            awg.SetClockPhaseAdjust(clockNumber, andTheFinalValueIs);
        }

        // Unkown 01/01/01
        /// <summary>
        /// 
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="clockNumber"></param>
        public void GetClockPhaseAdjust(IAWG awg, string clockNumber)
        {
            awg.GetClockPhaseAdjust(clockNumber);
        }

        //Kavitha: 01/17/2013 Corrected the default statement
        /// <summary>
        /// 
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="clockNumber"></param>
        /// <param name="expectedValue"></param>
        public void ClockPhaseAdjustShouldBe(IAWG awg, string clockNumber, string expectedValue)
        {
            string clockPhaseAdjust = awg.ClockPhaseAdjust(clockNumber);
            string possibleErrorString = "Checking the phase adjust for clock " + clockNumber;
            Assert.AreEqual(Convert.ToDouble(expectedValue), Convert.ToDouble(clockPhaseAdjust), possibleErrorString);
        }

        #endregion CLOCk:PHASe:ADJust

        #region CLOCk:SOURce

        // Unkown 01/01/01
        /// <summary>
        /// 
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="clockNumber"></param>
        /// <param name="setValue"></param>
        public void SetClockSource(IAWG awg, string clockNumber, SourceClock setValue)
        {
            var clockSource = "INT";
            switch (setValue)
            {
                case SourceClock.Internal:
                    clockSource = "INT";
                    break;
                case SourceClock.External:
                    clockSource = "EXT";
                    break;
                case SourceClock.Fixed:
                    clockSource = "EFIX";
                    break;
                case SourceClock.Variable:
                    clockSource = "EVAR";
                    break;
            }
            awg.SetClockSource(clockNumber, clockSource);
        }

        // Unkown 01/01/01
        /// <summary>
        /// Sets the Clock Source to the desired value.
        /// </summary>
        /// <param name="awg">Awg object</param>
        /// <param name="clockNumber">Which clock</param>
        public void GetClockSource(IAWG awg, string clockNumber)
        {
            awg.GetClockSource(clockNumber);
        }

        public void SourceClockShouldBe(IAWG awg, string clockNumber, SourceClock shouldBe)
        {

            string clockSource = awg.ClockSource(clockNumber);
            string possibleErrorString = "Checking the source for clock " + clockNumber;    

            switch (shouldBe)
            {
                case SourceClock.Internal:
                    Assert.AreEqual("INT", clockSource, possibleErrorString);
                    break;
                case SourceClock.External:
                    Assert.AreEqual("EXT", clockSource, possibleErrorString);
                    break;
                case SourceClock.Fixed:
                    Assert.AreEqual("EFIX", clockSource, possibleErrorString);
                    break;
                case SourceClock.Variable:
                    Assert.AreEqual("EVAR", clockSource, possibleErrorString);
                    break;
            }
        }

        #endregion CLOCk:SOURce

        #region CLOCk:SOUT:STATe
        /// <summary>
        /// Sets an awg's Sync Clock Output state to On or Off
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="clockNumber"></param>
        /// <param name="onOrOffState"></param>
        public void SetSyncClockOutputState(IAWG awg, string clockNumber, SyncClockOutputState onOrOffState)
        {
            string state = (onOrOffState == SyncClockOutputState.On) ? "On" : "Off";
            awg.SetClockSoutState(clockNumber, state);

        }

        /// <summary>
        /// Forces the awg object to update it's copy of the Sync Clock Output State
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="clockNumber"></param>
        public void GetSyncClockOutputState(IAWG awg, string clockNumber)
        {
            awg.GetAwgClockSoutState(clockNumber);
        }

        public void SyncClockOutputStateShouldBe(IAWG awg, string clockNumber, SyncClockOutputState onOrOffState)
        {
            string expectedState = (onOrOffState == SyncClockOutputState.On) ? "1" : "0";
            string clockSoutState = awg.ClockSoutState(clockNumber);
            Assert.AreEqual(expectedState, clockSoutState, "Unexpected Sync Output State");
        }
        #endregion CLOCk:SOUT:STATe

        #region CLOCk:SRATe
        // Unkown 01/01/01
        /// <summary>
        /// Sets the sample rate for the given clock
        /// </summary>
        /// <param name="awg">awg object</param>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValueAs">ClockSampleRateAs enum of Value, Min or Max</param>
        /// <param name="setValue">Sample Rate</param>
        public void SetClockSRate(IAWG awg, string clockNumber, ClockSampleRateAs setValueAs, string setValue = "")
        {
            var finalValue = setValue;
            switch (setValueAs)
            {
                case ClockSampleRateAs.Min:
                    finalValue = ClockSampleRateMinSyntax;
                    break;
                case ClockSampleRateAs.Max:
                    finalValue = ClockSampleRateMaxSyntax;
                    break;
            }
            awg.SetClockSRate(clockNumber, finalValue);
        }

        // Unkown 01/01/01
        /// <summary>
        /// Using CLOCk{n}:SRATe?, it forces the sample rate property for the given clock to update
        /// </summary>
        /// <param name="awg">awg object</param>
        /// <param name="clockNumber">Which clock</param>
        /// <returns>Sample rate</returns>
        public void GetClockSRate(IAWG awg, string clockNumber)
        {
            awg.GetClockSRate(clockNumber);
        }


        public void ClockSRateShouldBe(IAWG awg, string clockNumber, string expectedValue)
        {
            string possibleErrorString = "Checking the clock sample rate for clock " + clockNumber;
            Assert.AreEqual(expectedValue, awg.ClockSampleRate(clockNumber), possibleErrorString);           
        }

        public void ClockSRateWithUnitsShouldBe(IAWG awg, string clockNumber, string expectedValue, string percent)
        {

            float value = float.Parse(expectedValue); //Parse the string to begin calculations
            float percentage = float.Parse(percent);

            double min = value - ((value * (percentage / 100.0)));
            double max = value + ((value * (percentage / 100.0)));

            double mean = float.Parse(awg.ClockSampleRate(clockNumber));

            Assert.IsTrue((mean >= min) && (mean <= max), "Sample rate " + mean + " was not between " + min + " and " + max);
        }

        public void ClockSRateWithPercentOnlyShouldBe(IAWG awg, string clockNumber, string expectedValue, string percent)
        {

            float value = float.Parse(expectedValue); //Parse the string to begin calculations
            float percentage = float.Parse(percent);

            double min = value - ((value * (percentage / 100.0)));
            double max = value + ((value * (percentage / 100.0)));

            double mean = float.Parse(awg.ClockSampleRate(clockNumber));

            // This may or may not stay in the final code.
            // The goal is to get a little more detail to any failure, (aka not between the min and max)
            // like if there was more time, would we get the correct answer.
            // This would mean that the clock rate really wasn't ready when it said it was
            // which is why were getting the current value to check.
            // If it is really stuck, then there are other problems.
            // And for the reader, this is not normally what would happen but this is where
            // it appears to be breaking so in goes the check until further notice.
            //
            // First pass at the code will be to pause for 1 second, and then get the clock rate again.
            if (!((mean >= min) && (mean <= max)))
            {
                //bool didItFailTheInitialTest = true;
                const int additionalPause = 5;
                _utilitiesGroup.WaitNSeconds(additionalPause);
                GetClockSRate(awg, "1");            // For now, only clock 1
                double meanAgain = float.Parse(awg.ClockSampleRate(clockNumber));

                if (!((meanAgain >= min) && (meanAgain <= max)))
                {
                    string possibleError = "After pausing another " + additionalPause.ToString(CultureInfo.InvariantCulture) + " seconds, the sample rate " + meanAgain + " was not between " + min + " and " + max;
                    Assert.IsTrue((meanAgain >= min) && (meanAgain <= max), possibleError);
                }
                else
                {
                    string possibleError = "After pausing another " + additionalPause.ToString(CultureInfo.InvariantCulture) + " seconds, the sample rate was correct.  First test failed when it said it was done.";
                    Assert.IsTrue((mean >= min) && (mean <= max), possibleError);
                }
            }
        }

        #endregion CLOCk:SRATe



    }
}