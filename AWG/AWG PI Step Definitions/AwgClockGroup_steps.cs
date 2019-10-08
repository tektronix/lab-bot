using TechTalk.SpecFlow;

namespace AwgTestFramework 
{
    /// This class contains the PI step definitions for the %AWG PI Clock Group commands.

    /// Generally the steps are set, get and should be operations.  The step sole responsibility
    /// is to make sure the correct %AWG object is used and that parameters such as channel,
    /// markers and clock references are correct for the %AWG object.
    ///
    /// 
    /// \ingroup highpi pisteps 
    /// 
    [Binding] //Very important! This entry needs to be made in each step definition file.
    public class AwgClockSteps
    {
        private readonly AwgClockGroup _awgClockGroup = new AwgClockGroup();
        private readonly UtilitiesGroup _utilitiesGroup = new UtilitiesGroup();

        #region CLOCk:ECLock:DIVider

        //glennj 9/5/2013
        /// <summary>
        /// Set the awg's external clock divider
        /// 
        /// This is an overlapped command.
        /// 
        /// CLOCk:ECLock:DIVider
        /// </summary>
        /// <param name="binaryDivider"></param>
        /// <param name="clockNumber"></param>
        /// <param name="awgNumber"></param>
        /*!
           \clock\verbatim
        [When(@"I set the divider rate to (\d+) for external clock ([1-2]) for AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I set the divider rate to (\d+) for external clock ([1-2]) for AWG ([1-4])")]
        public void SetTheDividerRateOfTheExternalClockTo(string binaryDivider, string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.SetClockExternalDivider(awg, clockNumber, AwgClockGroup.ExternalClockDividerAs.Value, binaryDivider);
        }

        //glennj 9/5/2013
        /// <summary>
        /// Set the awg's external clock divider to the maximum
        /// 
        /// This is an overlapped command.
        /// 
        /// CLOCk:ECLock:DIVider
        /// </summary>
        /// <param name="clockNumber"></param>
        /// <param name="awgNumber"></param>
        /*!
           \clock\verbatim
        [When(@"I set the divider rate to maximum for external clock ([1-2]) for AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I set the divider rate to maximum for external clock ([1-2]) for AWG ([1-4])")]
        public void SetTheDividerRateOfTheExternalClockToMax(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.SetClockExternalDivider(awg, clockNumber, AwgClockGroup.ExternalClockDividerAs.Max);
        }

        //glennj 9/5/2013
        /// <summary>
        /// Set the awg's external clock divider to the minimum
        /// 
        /// This is an overlapped command.
        /// 
        /// CLOCk:ECLock:DIVider
        /// </summary>
        /// <param name="clockNumber"></param>
        /// <param name="awgNumber"></param>
        /*!
           \clock\verbatim
        [When(@"I set the divider rate to minimum for external clock ([1-2]) for AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I set the divider rate to minimum for external clock ([1-2]) for AWG ([1-4])")]
        public void SetTheDividerRateOfTheExternalClockToMin(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.SetClockExternalDivider(awg, clockNumber, AwgClockGroup.ExternalClockDividerAs.Min);
        }

        //glennj 9/5/2013
        /// <summary>
        /// Update the awg's property per clock external clock divider
        /// </summary>
        /// <param name="clockNumber"></param>
        /// <param name="awgNumber"></param>
        /*!
           \clock\verbatim
        [When(@"I get the divider rate for external clock ([1-2]) for AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I get the divider rate for external clock ([1-2]) for AWG ([1-4])")]
        public void GetTheDividerRateOfTheExternalClock(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.GetClockExternalDivider(awg, clockNumber);
        }

        //glennj 9/5/2013
        /// <summary>
        /// 
        /// </summary>
        /// <param name="expectedBinaryDivider"></param>
        /// <param name="clockNumber"></param>
        /// <param name="awgNumber"></param>
        /*!
           \clock\verbatim
        [Then(@"the divider rate should be (\d+) for external clock ([1-2]) for AWG ([1-4])")]
           \endverbatim 
        */
        [Then(@"the divider rate should be (\d+) for external clock ([1-2]) for AWG ([1-4])")]
        public void TheDividerRateOfTheExternalClockShouldBe(string expectedBinaryDivider, string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.ClockExternalDividerShouldBe(awg, clockNumber, expectedBinaryDivider);
        }

        #endregion CLOCk:ECLock:DIVider
        
        #region CLOCk:ECLock:FREQuency

        //Jhowells 9-4-12
        //glennj 1/28/2014
        /// <summary>
        /// Sets the expected frequency being provided by the external clock
        /// 
        /// This is an overlapped command.
        /// 
        /// CLOCk:ECLock:FREQuency
        /// </summary>
        /// <param name="setValue">Expected frequency</param>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [When(@"I set the external frequency to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the external frequency to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for clock ([1-2]) for AWG ([1-4])")]
        public void SetTheAWGExternalFrequency(string setValue, string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.SetExternalClockFrequency(awg, clockNumber, setValue);
        }

        //Jhowells 9-4-12
        //glennj 1/28/2014
        ///  <summary>
        ///  Returns the expected frequency being provided by the external clock
        ///  
        ///  CLOCk1:ECLock:FREQuency?
        ///  </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
           \clock\verbatim
        [When(@"I get the external frequency for clock ([1-2]) for AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I get the external frequency for clock ([1-2]) for AWG ([1-4])")]
        public void GetTheAWGClockExternalFrequency(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.GetExternalClockFrequency(awg, clockNumber);
        }

        //Jhowells 9-4-12
        //glennj 1/28/2014
        /// <summary>
        /// Compares the expected frequency being provided by the external clock against the expected value.
        /// 
        /// CLOCk1:ECLock:FREQuency
        /// </summary>
        /// <param name="expectedValue">Expected frequency</param>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [Then(@"the external frequency should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the external frequency should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for clock ([1-2]) for AWG ([1-4])")]
        public void TheAwgClockExternalFrequencyValueShouldBe(string expectedValue, string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.ExternalClockFrequencyShouldBe(awg, clockNumber, expectedValue);
        }

        //jmanning 05/02/2014
        /// <summary>
        /// Compares the expected frequency being provided by the external clock against the expected value within a certain tolerance.
        /// 
        /// CLOCk1:ECLock:FREQuency
        /// </summary>
        /// <param name="expectedValue">Expected frequency</param>
        /// <param name="percent">Acceptable tolerance level percentage</param>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [Then(@"the external frequency should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the external frequency should be within ([-+]?[0-9]*\.?[0-9]+)% tolerance of ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for clock ([1-2]) for AWG ([1-4])")]
        public void TheAwgClockExternalFrequencyValueShouldBeWithinTolerance(string percent, string expectedValue, string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.ExternalClockFrequencyShouldBeWithinTolerance(awg, clockNumber, expectedValue, percent);
        }
        #endregion CLOCk:ECLock:FREQuency
        
        #region CLOCk:ECLock:FREQuency:ADJust

        //glennj 9/5/2013
        /// <summary>
        /// Assumes that there is an external source (clock)
        /// 
        /// This is an overlapped command.
        /// 
        /// CLOCk:ECLock:FREQuency:ADJust
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
           \clock\verbatim
        [When(@"I adjust for the external clock ([1-2]) for AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I adjust for the external clock ([1-2]) for AWG ([1-4])")]
        public void AdjustForTheExternalClock(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.AdjustExternalClockFrequency(awg, clockNumber);
        }

        #endregion CLOCk:ECLock:FREQuency:ADJust

        #region CLOCk:ECLock:FREQuency:DETect

        //glennj 1/28/2014
        /// <summary>
        /// Force the awg to detect the frequency of the external clock in and then adjusts the system to use it.
        /// 
        /// This is an overlapped command.
        /// 
        /// CLOCk:ECLock:FREQuency:DETect
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
           \clock\verbatim
        [When(@"I detect the external frequency for clock ([1-2]) for AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I detect the external frequency for clock ([1-2]) for AWG ([1-4])")]
        public void SetTheAWGClockToAutoAcquireFrequency(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.DetectExternalClockFrequency(awg, clockNumber);
        }

        #endregion CLOCk:ECLock:FREQuency:DETect

        #region CLOCk:ECLOCk:MULTiplier

        //Jhowells 9-4-12
        //glennj 1/28/2014
        /// <summary>
        /// Sets the multipler rate of the external clock.
        /// 
        /// This is an overlapped command.
        /// 
        /// CLOCk:ECLOCk:MULTiplier
        /// </summary>
        /// <param name="setValue">Desired multipler Rate</param>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [When(@"I set the AWG clock (1|2) multipler rate to ([-+]?\d+)")]
            \endverbatim 
        */
        [When(@"I set the external clock multiplier rate to ([-+]?\d+) for clock ([1-2]) for AWG ([1-4])")]
        public void SetTheAWGMultiplerRate(string setValue, string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.SetClockMultiplier(awg, clockNumber, setValue);
        }

        //Jhowells 9-4-12
        //glennj 1/28/2014
        /// <summary>
        /// Gets the multipler rate of the external clock.
        /// 
        /// AWGControl:CLOCk{n}:MULTiplier?
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [When(@"I get the AWG clock (1|2) multipler rate")]
            \endverbatim 
       */
        [When(@"I get the external clock multiplier rate for clock ([1-2]) for AWG ([1-4])")]
        public void GetTheAWGClockMultiplerRate(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.GetClockMultiplier(awg, clockNumber);
        }

        //Jhowells 9-4-12
        //glennj 7/28/2014
        /// <summary>
        /// Compares the multipler rate of the external clock against the expected value.
        /// 
        /// CLOCk[1]:ECLock:MULTiplier
        /// </summary>
        /// <param name="expectedValue">Expected multipler rate</param>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
           \clock\verbatim
        [Then(@"the AWG clock multipler rate should be ([-+]?\d+)")]
           \endverbatim 
        */
        [Then(@"the external clock multiplier rate should be ([-+]?\d+) for clock ([1-2]) for AWG ([1-4])")]
        public void TheAwgClockMultiplerRateValueShouldBe(string expectedValue, string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.ClockMultiplerRateValueShouldBe(awg, expectedValue);
        }

        #endregion

        #region CLOCk:EREFerence:DIVider

        // Unknown 01/01/01
        //glennj 1/29/2014
        /// <summary>
        /// Sets the external reference clock divider for a clock and an AWG.
        /// The clock number is for future support.
        /// 
        /// This is an overlapped command.
        /// 
        /// CLOCk:EREFerence:DIVider
        /// </summary>
        /// <param name="setValue"></param>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
                \clock\verbatim
        [When(@"I set the AWG external reference clock ([1-2]) divider to ((?<!\S)[-+]?\d+(?!\S))")] // <NR1> matcher
                \endverbatim 
        */
        [When(@"I set the divider rate to ((?<!\S)[-+]?\d+(?!\S)) for the external reference for clock ([1-2]) for AWG ([1-4])")] // <NR1> matcher
        public void SetTheAWGExternalReferenceClockndivider(string setValue, string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.SetExternalReferenceClockDivider(awg, clockNumber, setValue);
        }

        // Unknown 01/01/01
        //glennj 1/29/2014
        /// <summary>
        /// Gets the external reference clock divider for the default awg and a clock.<para>
        /// The clock number is for future support.</para>
        /// 
        /// CLOCk:EREFerence:DIVider
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
                \clock\verbatim
        [When(@"I get the AWG external reference clock ([1-2]) divider")]
                \endverbatim 
        */
        [When(@"I get the divider rate for the external reference for clock ([1-2]) for AWG ([1-4])")] // <NR1> matcher
        public void GetTheAWGExternalReferenceClockndivider(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.GetExternalReferenceClockDivider(awg, clockNumber);
        }

        // Unknown 01/01/01
        //glennj 1/29/2014
        /// <summary>
        /// This tests a previously retrived external reference clock divider for the default awg and a clock.<para>
        /// The clock number is for future support.</para>
        /// 
        /// CLOCk:EREFerence:DIVider
        /// 
        /// </summary>
        /// <param name="expectedValue"></param>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
                \clock\verbatim
        [Then(@"the AWG external reference clock ([1-2]) divider should be ((?<!\S)[-+]?\d+(?!\S))")] // <NR1> matcher
                \endverbatim 
        */
        [Then(@"the divider rate should be ((?<!\S)[-+]?\d+(?!\S)) for the external reference for clock ([1-2]) for AWG ([1-4])")] // <NR1> matcher
        public void ThenTheAWGExternalReferenceClockndividerShouldBe(string expectedValue, string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.ExternalReferenceClockDividerShouldBe(awg, clockNumber, expectedValue);
        }

        #endregion CLOCk:EREFerence:DIVider

        #region CLOCk:EREFerence:FREQuency

        //Jhowells 1-16-13
        //glennj 1/29/2014
        /// <summary>
        /// Sets the expected frequency being provided by the external reference
        /// 
        /// This is an overlapped command.
        /// 
        /// CLOCk[n]:EREFerence:FREQuency
        /// </summary>
        /// <param name="setValue">Desired frequency</param>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
           \clock\verbatim
        [When(@"I set the frequency to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for the external reference for clock ([1-2]) for AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I set the frequency to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for the external reference for clock ([1-2]) for AWG ([1-4])")]
        public void SetTheAWGExternalReferenceFrequency(string setValue, string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.SetExternalClockReferenceFrequency(awg, clockNumber, setValue);
        }

        //Jhowells 1-16-13
        //glennj 1/29/2014
        /// <summary>
        /// Returns the expected frequency being provided by the external reference
        /// 
        /// CLOCk[n]:EREFerence:FREQuency?
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
           \clock\verbatim
        [When(@"I get the frequency for the external reference for clock ([1-2]) for AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I get the frequency for the external reference for clock ([1-2]) for AWG ([1-4])")]
        public void GetTheAWGClockExternalReferenceFrequency(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.GetExternalClockReferenceFrequency(awg, clockNumber);
        }

        //Jhowells 1-16-13
        //glennj 1/29/2014
        /// <summary>
        /// Compares the expected frequency being provided by the external reference against the expected value.
        /// 
        /// CLOCk[n]:EREFerence:FREQuency
        /// </summary>
        /// <param name="expectedValue">Expected reference frequency</param>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
           \clock\verbatim
        [Then(@"the frequency should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for the external reference for clock ([1-2]) for AWG ([1-4])")]
           \endverbatim 
        */
        [Then(@"the frequency should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for the external reference for clock ([1-2]) for AWG ([1-4])")]
        public void TheAwgClockExternalReferenceFrequencyValueShouldBe(string expectedValue, string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.ExternalClockReferenceFrequencyShouldBe(awg, clockNumber, expectedValue);
        }

        #endregion CLOCk:EREFerence:FREQuency

        #region CLOCk:EREFerence:FREQuency:DETect

        //Jhowells 1-16-13
        //glennj 1/29/2014
        /// <summary>
        /// Force the awg to detect the frequency of the external reference in and then adjusts the system to use it.
        /// 
        /// This is an overlapped command.
        /// 
        /// CLOCk[n]:EREFerence:FREQuency:DETect
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
           \clock\verbatim
        [When(@"I detect the frequency for the external reference for clock ([1-2]) for AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I detect the frequency for the external reference for clock ([1-2]) for AWG ([1-4])")]
        public void SetTheAWGClockToAutoAcquireReferenceFrequency(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.ForceClockReferenceFrequencyAutoDetect(awg, clockNumber);
        }

        #endregion CLOCk:EREFerence:FREQuency:DETect

        #region CLOCk:EREFerence:MULTiplier

        // Unknown 01/01/01
        //glennj 1/29/2014
        /// <summary>
        /// Sets the external reference clock multiplier for the default awg and a clock.<para>
        /// The clock number is for future support.</para>
        /// 
        /// This is an overlapped command.
        /// 
        /// CLOCk:EREFerence:MULTiplier
        /// </summary>
        /// <param name="setValue"></param>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [When(@"I set the multiplier rate to ([-+]?\d+) for the external reference for clock ([1-2]) for AWG ([1-4])")] // <NR1> matcher
            \endverbatim 
        */
        [When(@"I set the multiplier rate to ([-+]?\d+) for the external reference for clock ([1-2]) for AWG ([1-4])")] // <NR1> matcher
        public void SetTheAwgExternalReferenceClocknMultiplierTo(string setValue, string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.SetExternalReferenceClockMultiplierTo(awg, clockNumber, setValue);
        }

        // Unknown 01/01/01
        //glennj 1/29/2014
        /// <summary>
        /// Gets the external reference clock multiplier for the default awg and a clock.<para>
        /// The clock number is for future support.</para>
        /// 
        /// CLOCk:EREFerence:MULTiplier
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [When(@"I get the multiplier rate for the external reference for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the multiplier rate for the external reference for clock ([1-2]) for AWG ([1-4])")]
        public void GetTheAwgExternalReferenceClocknMultiplier(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.GetExternalReferenceClockMultiplier(awg, clockNumber);
        }

        // Unknown 01/01/01
        //glennj 1/29/2014
        /// <summary>
        /// This tests a previously retrived external reference clock multiplier for the default awg and a clock.<para>
        /// The clock number is for future support.</para>
        /// </summary>
        /// <param name="expectedValue"></param>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [Then(@"the multiplier rate should be ([-+]?\d+) for the external reference for clock ([1-2]) for AWG ([1-4])")] // <NR1> matcher
            \endverbatim 
        */
        [Then(@"the multiplier rate should be ([-+]?\d+) for the external reference for clock ([1-2]) for AWG ([1-4])")] // <NR1> matcher
        public void ExternalReferenceClocknMultiplierShouldBe(string expectedValue, string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.ExternalReferenceClockMultiplierShouldBe(awg, clockNumber, expectedValue);
        }

        #endregion CLOCk:EREFerence:MULTiplier

        #region CLOCK:JITTER

        //Jhowells 8-31-12
        //glennj 9/12/2013
        /// <summary>
        /// Sets the low jitter enabled of a clock to on for an awg
        /// 
        /// This is an overlapped command.
        /// 
        /// CLOCK:JITTER
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [When(@"I set the low jitter enable state to on for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the low jitter enable state to on for clock ([1-2]) for AWG ([1-4])")]
        public void SetTheAWGClockJitterStateToOn(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.SetClockJitter(awg, clockNumber,AwgClockGroup.ClockJitterState.On);
        }

        //glennj 9/12/2013
        /// <summary>
        /// Sets the low jitter enabled of a clock to off for an awg
        /// 
        /// CLOCK:JITTER
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [When(@"I set the low jitter enable state to off for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the low jitter enable state to off for clock ([1-2]) for AWG ([1-4])")]
        public void SetTheAWGClockJitterStateToOff(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.SetClockJitter(awg, clockNumber, AwgClockGroup.ClockJitterState.Off);
        }

        //Jhowells 8/31/12
        //glennj 9/12/2013
        ///  <summary>
        ///  Gets low jitter enable state of a clock for an awg
        /// 
        /// CLOCK:JITTER
        ///  </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [When(@"I get the low jitter enable state for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the low jitter enable state for clock ([1-2]) for AWG ([1-4])")]
        public void GetTheAWGClockJitterValue(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.GetClockJitter(awg, clockNumber);
        }

        //Jhowells 8-31-12
        //glennj 9/12/2013
        /// <summary>
        /// Checks the low jitter is enabled state for on of a clock on an awg
        /// 
        /// CLOCK:JITTER
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [Then(@"the low jitter enable state should be on for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the low jitter enable state should be on for clock ([1-2]) for AWG ([1-4])")]
        public void ClockJitterValueShouldBeOn(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.ClockJitterValueShouldBe(awg, clockNumber, AwgClockGroup.ClockJitterState.On);
        }

        //glennj 9/12/2013
        /// <summary>
        /// Checks the low jitter is enabled state for off of a clock on an awg
        /// 
        /// CLOCK:JITTER
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [Then(@"the low jitter enable state should be off for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the low jitter enable state should be off for clock ([1-2]) for AWG ([1-4])")]
        public void ClockJitterValueShouldBeOff(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.ClockJitterValueShouldBe(awg, clockNumber, AwgClockGroup.ClockJitterState.Off);
        }

        #endregion CLOCK:JITTER

        #region CLOCk:OUTPut:FREQuency

        //Jhowells 9-4-12
        //sforell 8/19/13 changed it from calling GetExternalClockFrequency to GetClockOutputFrequency
        // Also moved it from PSR2 region to CLOCk:OUTPut:FREQuency
        /// <summary>
        /// Returns the output frequency of the specified clock.
        /// 
        ///  CLOCk:OUTPut:FREQuency?
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
           \clock\verbatim
        [When(@"I get the output frequency for clock ([1-2]) for AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I get the output frequency for clock ([1-2]) for AWG ([1-4])")]
        public void GetTheAWGClockOutputFrequency(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.GetClockOutputFrequency(awg, clockNumber);
        }

        //Jhowells 9-4-12
        //glennj 12/5/2013
        /// <summary>
        /// Compares the frequency output of a clock against the expected value.
        /// 
        /// CLOCk:OUTPut:FREQuency?
        /// </summary>
        /// <param name="expectedValue">Expected frequency output</param>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [Then(@"the output frequency should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the output frequency should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for clock ([1-2]) for AWG ([1-4])")]
        public void TheAWGClockOutputFrequencyValueShouldBe(string expectedValue, string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.ClockOutputFrequencyShouldBe(awg, clockNumber, expectedValue);
        }

        //Jhowells 9-4-12
        //glennj 12/5/2013
        /// <summary>
        /// Compares the frequency output of a clock against the expected value but within a range or percentage
        /// 
        /// CLOCk:OUTPut:FREQuency?
        /// </summary>
        /// <param name="expectedValue">Expected frequency output</param>
        /// <param name="percent"></param>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [Then(@"the output frequency should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) within ([0-9]+)% for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the output frequency should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) within ([0-9]+)% for clock ([1-2]) for AWG ([1-4])")]
        public void TheAWGClockOutputFrequencyValueShouldBePercent(string expectedValue, string percent, string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.ClockOutputFrequencyShouldBe(awg, clockNumber, expectedValue, percent);
        }



        #endregion CLOCk:OUTPut:FREQuency

        #region CLOCk:OUTPut[:STATe]

        //glennj 12/11/2013
        /// <summary>
        /// Sets the output state to ON for specified clock.
        /// 
        /// This is an overlapped command.
        /// 
        /// CLOCk[n]:OUTPut:STATe
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [When(@"I set the output state to on for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the output state to on for clock ([1-2]) for AWG ([1-4])")]
        public void SetTheAWGClockOutputStateOn(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.SetClockOutputState(awg, clockNumber, AwgClockGroup.ClockOutputState.On);
        }

        //glennj 12/11/2013
        /// <summary>
        /// Sets the output state to OFF for specified clock.
        /// 
        /// CLOCk[n]:OUTPut:STATe
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [When(@"I set the output state to off for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the output state to off for clock ([1-2]) for AWG ([1-4])")]
        public void SetTheAWGClockOutputStateOff(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.SetClockOutputState(awg, clockNumber, AwgClockGroup.ClockOutputState.Off);
        }

        //Jhowells 9-4-12
        /// <summary>
        /// Gets the output state of the specified clock.
        /// 
        /// AWGControl:CLOCk[n]:OUTPut:STATe
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [When(@"I get the output state for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the output state for clock ([1-2]) for AWG ([1-4])")]
        public void GetTheAWGClockOutputState(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.GetClockOutputState(awg, clockNumber);
        }

        //glennj 12/11/2013
        /// <summary>
        /// Checks the output state of the clock to ON
        /// 
        /// CLOCk[n]:OUTPut:STATe
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [Then(@"the output state should be on for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the output state should be on for clock ([1-2]) for AWG ([1-4])")]
        public void TheAWGClockOutputStateShouldBeOn(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.ClockOutputStateShouldBe(awg, clockNumber, AwgClockGroup.ClockOutputState.On);
        }

        //glennj 12/11/2013
        /// <summary>
        /// Checks the output state of the clock to OFF
        /// 
        /// CLOCk[n]:OUTPut:STATe
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [Then(@"the output state should be off for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the output state should be off for clock ([1-2]) for AWG ([1-4])")]
        public void TheAWGClockOutputStateShouldBeOff(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.ClockOutputStateShouldBe(awg, clockNumber, AwgClockGroup.ClockOutputState.Off);
        }

        #endregion CLOCk:OUTPut[:STATe]

        #region CLOCk:PHASe[:ADJust]

        //glennj 9/11/2013
        /// <summary>
        /// Set the clock phase
        /// 
        /// This is an overlapped command.
        /// 
        /// CLOCk:PHASe[:ADJust]
        /// </summary>
        /// <param name="setPhaseValue"></param>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [When(@"I set the phase adjust to ([-+]?\d+) for clock ([1-2]) for AWG ([1-4])")] 
            \endverbatim 
        */
        [When(@"I set the phase adjust to ([-+]?\d+) for clock ([1-2]) for AWG ([1-4])")]
        public void SetThePhaseAdjustOfClock(string setPhaseValue, string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.SetClockPhaseAdjust(awg, clockNumber, AwgClockGroup.ClockPhaseAs.Nr1, setPhaseValue);
        }

        //glennj 9/11/2013
        /// <summary>
        /// Set clock phase to max
        /// 
        /// CLOCk:PHASe[:ADJust]
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [When(@"I set the phase adjust to maximum for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the phase adjust to maximum for clock ([1-2]) for AWG ([1-4])")]
        public void SetThePhaseAdjustOfClockToMax(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.SetClockPhaseAdjust(awg, clockNumber, AwgClockGroup.ClockPhaseAs.Max);
        }

        //glennj 9/11/2013
        /// <summary>
        /// Set clock phase to min
        /// 
        /// CLOCk:PHASe[:ADJust]
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [When(@"I set the phase adjust to minimum for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the phase adjust to minimum for clock ([1-2]) for AWG ([1-4])")]
        public void SetThePhaseAdjustOfClockToMin(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.SetClockPhaseAdjust(awg, clockNumber, AwgClockGroup.ClockPhaseAs.Min);
        }

        //glennj 9/11/2013
        /// <summary>
        /// Get the clock phase
        /// 
        /// CLOCk:PHASe[:ADJust]
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [When(@"I get the phase adjust for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the phase adjust for clock ([1-2]) for AWG ([1-4])")]
        public void GetThePhaseAdjustOfClock(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.GetClockPhaseAdjust(awg, clockNumber);
        }

        //glennj 9/11/2013
        /// <summary>
        /// Test for an expected clock phase
        /// 
        /// CLOCk:PHASe[:ADJust]
        /// </summary>
        /// <param name="expectedPhase"></param>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [Then(@"the phase adjust should be ([-+]?\d+) for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the phase adjust should be ([-+]?\d+) for clock ([1-2]) for AWG ([1-4])")]
        public void ThePhaseAdjustOfClockShouldBe(string expectedPhase, string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.ClockPhaseAdjustShouldBe(awg, clockNumber, expectedPhase);
        }

        #endregion CLOCk:PHASe[:ADJust]

        #region CLOCk:SOURce

        // Unknown 01/01/01
        //glennj 8/6/2013
        /// <summary>
        /// This sets the AWG clock reference source specifically to internal.<para>
        /// The reason that internal is spelled out is to be consistent with other steps</para><para>
        /// that specificially spell out the clock reference.</para><para>
        /// An example of this is the step "I set the AWG external reference clock"</para>
        /// 
        /// This is an overlapped command.
        /// 
        /// CLOCk:PHASe[:ADJust]
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [When(@"I set the source to internal for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the source to internal for clock ([1-2]) for AWG ([1-4])")]
        public void SetTheAwgClockReferenceSourceToInternal(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.SetClockSource(awg, clockNumber, AwgClockGroup.SourceClock.Internal);
        }

        // Unknown 01/01/01
        //glennj 8/6/2013
        /// <summary>
        /// This sets the AWG clock reference source specifically to external.<para>
        /// The reason that external is spelled out is to be consistent with other steps</para><para>
        /// that specificially spell out the clock reference.</para><para>
        /// An example of this is the step "I set the AWG external reference clock"</para>
        /// 
        /// This is an overlapped command.
        /// 
        /// CLOCk:PHASe[:ADJust]
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [When(@"I set the source to external for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the source to external for clock ([1-2]) for AWG ([1-4])")]
        public void SetTheAwgClockReferenceSourceToExternal(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.SetClockSource(awg, clockNumber, AwgClockGroup.SourceClock.External);
        }

        // Unknown 01/01/01
        //glennj 8/6/2013
        /// <summary>
        /// This sets the AWG clock reference source specifically to external fixed.<para>
        /// The reason that external is spelled out is to be consistent with other steps</para><para>
        /// that specificially spell out the clock reference.</para><para>
        /// An example of this is the step "I set the AWG external reference clock"</para>
        /// 
        /// This is an overlapped command.
        /// 
        /// CLOCk:PHASe[:ADJust]
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [When(@"I set the source to external fixed reference for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the source to external fixed reference for clock ([1-2]) for AWG ([1-4])")]
        public void SetTheAwgClockReferenceSourceToExternalFixed(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.SetClockSource(awg, clockNumber, AwgClockGroup.SourceClock.Fixed);
        }

        // Unknown 01/01/01
        //glennj 8/6/2013
        /// <summary>
        /// This sets the AWG clock reference source specifically to external variable.<para>
        /// The reason that external is spelled out is to be consistent with other steps</para><para>
        /// that specificially spell out the clock reference.</para><para>
        /// An example of this is the step "I set the AWG external reference clock"</para>
        /// 
        /// This is an overlapped command.
        /// 
        /// CLOCk:PHASe[:ADJust]
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [When(@"I set the source to external variable reference for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the source to external variable reference for clock ([1-2]) for AWG ([1-4])")]
        public void SetTheAwgClockReferenceSourceToExternalVariable(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.SetClockSource(awg, clockNumber, AwgClockGroup.SourceClock.Variable);
        }

        //Jhowells 6-8-12
        //glennj 8/6/2013
        /// <summary>
        /// Gets the %AWG clock source
        ///
        /// CLOCk:SOURce?
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [When(@"I get the source for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the source for clock ([1-2]) for AWG ([1-4])")]
        public void GetTheAWGClockSourceValue(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.GetClockSource(awg, clockNumber);
        }

        //glennj 8/6/2013
        /// <summary>
        /// Check against an updated AWG property for clock source for internal
        /// 
        /// CLOCk:PHASe[:ADJust]
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [Then(@"the source should be internal for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the source should be internal for clock ([1-2]) for AWG ([1-4])")]
        public void TheSourceClockShouldBeInternal(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.SourceClockShouldBe(awg, clockNumber, AwgClockGroup.SourceClock.Internal);
        }

        //glennj 8/6/2013
        /// <summary>
        /// Check against an updated AWG property for clock source for external
        /// 
        /// CLOCk:PHASe[:ADJust]
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [Then(@"the source should be external for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the source should be external for clock ([1-2]) for AWG ([1-4])")]
        public void TheSourceClockShouldBeExternal(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.SourceClockShouldBe(awg, clockNumber, AwgClockGroup.SourceClock.External);
        }

        //glennj 8/6/2013
        /// <summary>
        /// Check against an updated AWG property for clock source for external fixed
        /// 
        /// CLOCk:PHASe[:ADJust]
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [Then(@"the source should be external fixed reference for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the source should be external fixed reference for clock ([1-2]) for AWG ([1-4])")]
        public void TheSourceClockShouldBeFixed(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.SourceClockShouldBe(awg, clockNumber, AwgClockGroup.SourceClock.Fixed);
        }

        //glennj 8/6/2013
        /// <summary>
        /// Check against an updated AWG property for clock source for external variable
        /// 
        /// CLOCk:PHASe[:ADJust]
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [Then(@"the source should be external variable reference for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the source should be external variable reference for clock ([1-2]) for AWG ([1-4])")]
        public void TheSourceClockShouldBeVariable(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.SourceClockShouldBe(awg, clockNumber, AwgClockGroup.SourceClock.Variable);
        }

        #endregion CLOCk:SOURce

        #region CLOCk:SOUT[:STATe]

        //glennj 1/27/2014
        /// <summary>
        /// Set the state of the Sync Clock Out output to on for a clock for an AWG.
        /// 
        /// CLOCk:SOUT[:STATe]
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [When(@"I set the sync output state to on for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the sync output state to on for clock ([1-2]) for AWG ([1-4])")]
        public void SetTheAwgSyncClockOutputStateToOn(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.SetSyncClockOutputState(awg, clockNumber, AwgClockGroup.SyncClockOutputState.On);
        }

        //glennj 1/27/2014
        /// <summary>
        /// Set the state of the Sync Clock Out output to off for a clock for an AWG.
        /// 
        /// CLOCk:SOUT[:STATe]
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [When(@"I set the sync output state to off for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the sync output state to off for clock ([1-2]) for AWG ([1-4])")]
        public void SetTheAwgSyncClockOutputStateToOff(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.SetSyncClockOutputState(awg, clockNumber, AwgClockGroup.SyncClockOutputState.Off);
        }

        //glennj 1/27/2014
        /// <summary>
        /// Get the state of the Sync Clock Out output.  It will be either on or off.
        /// It is important to note that this updates a copy of the response for the
        /// given AWG.  Normally after the get a test or should be is performed to
        /// verify the expected state.
        /// 
        /// CLOCk:SOUT[:STATe]?
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [When(@"I get the sync output state for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the sync output state for clock ([1-2]) for AWG ([1-4])")]
        public void GetAwgSyncClockOutputState(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.GetSyncClockOutputState(awg, clockNumber);
        }

        //glennj 1/27/2014
        /// <summary>
        /// The state of the Sync Clock Out output should be either on.
        /// It is important to note, this compares against a copy of the state as
        /// as result of doing the get the state for the Sync Clock Out output.
        /// 
        /// CLOCk:SOUT[:STATe]
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [Then(@"the sync output state should be on for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the sync output state should be on for clock ([1-2]) for AWG ([1-4])")]
        public void SyncClockOutputStateShouldBeOn(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.SyncClockOutputStateShouldBe(awg, clockNumber, AwgClockGroup.SyncClockOutputState.On);
        }

        //glennj 1/27/2014
        /// <summary>
        /// The state of the Sync Clock Out output should be either off.
        /// It is important to note, this compares against a copy of the state as
        /// as result of doing the get the state for the Sync Clock Out output.
        /// 
        /// CLOCk:SOUT[:STATe]
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [Then(@"the sync output state should be off for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the sync output state should be off for clock ([1-2]) for AWG ([1-4])")]
        public void SyncClockOutputStateShouldBeOff(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.SyncClockOutputStateShouldBe(awg, clockNumber, AwgClockGroup.SyncClockOutputState.Off);
        }

        #endregion CLOCk:SOUT[:STATe]

        #region CLOCk:SRATe

        //Jhowells 8/31/12
        //glennj 7/22/2013
        /// <summary>
        /// Sets the sample rate.
        /// 
        /// This is an overlapped command.
        /// 
        /// CLOCk:SRATe
        /// </summary>
        /// <param name="setValue">Sample Rate string value</param>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [When(@"I set the sample rate to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the sample rate to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) for clock ([1-2]) for AWG ([1-4])")]
        public void SetTheAWGClockSampleRate(string setValue, string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.SetClockSRate(awg, clockNumber, AwgClockGroup.ClockSampleRateAs.Value, setValue);
        }

        //Jhowells 8/31/12
        //glennj 7/22/2013
        /// <summary>
        /// Sets the sample rate.
        /// 
        /// This is an overlapped command.
        /// 
        /// CLOCk:SRATe
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [When(@"I set the sample rate to minimum for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the sample rate to minimum for clock ([1-2]) for AWG ([1-4])")]
        public void SetTheAWGClockSampleRateToMin(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.SetClockSRate(awg, clockNumber, AwgClockGroup.ClockSampleRateAs.Min);
        }

        //Jhowells 8/31/12
        //glennj 7/22/2013
        /// <summary>
        /// Sets the sample rate.
        /// 
        /// This is an overlapped command.
        /// 
        /// CLOCk:SRATe
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [When(@"I set the sample rate to maximum for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the sample rate to maximum for clock ([1-2]) for AWG ([1-4])")]
        public void SetTheAWGClockSampleRateToMax(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.SetClockSRate(awg, clockNumber, AwgClockGroup.ClockSampleRateAs.Max);
        }

        //Jhowells 8/31/12
        /// <summary>
        /// Updates AWG sample rate property
        /// 
        /// CLOCk:SRATe
        /// </summary>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [When(@"I get the sample rate for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the sample rate for clock ([1-2]) for AWG ([1-4])")]
        public void GetTheAWGClockSampleRateValue(string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.GetClockSRate(awg, clockNumber);
        }

        //Jhowells 1/28/13
        //glennj 7/22/2013
        /// <summary>
        /// Tests the clock sample rate has been changed to the expected value
        /// 
        /// CLOCk:SRATe
        /// </summary>
        /// <param name="expectedValue">Expected Clock Sample Rate Value</param>
        /// <param name="percent">percentage error that is allowed</param>
        /// <param name="clockNumber">A number between 1 and 2 depending on the AWG type</param>
        /// <param name="awgNumber">A number between 1 and 4 depending on the AWG type</param>
        /*!
            \clock\verbatim
        [Then(@"the sample rate should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) within ([0-9]+)% for clock ([1-2]) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the sample rate should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) within ([0-9]+)% for clock ([1-2]) for AWG ([1-4])")]
        public void TheAWGClockSampleRateValueShouldBe(string expectedValue, string percent, string clockNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.VerifyChannelMarkerClockParameters(awg, null, null, clockNumber);
            _awgClockGroup.ClockSRateWithPercentOnlyShouldBe(awg, clockNumber, expectedValue, percent);
        }
        #endregion CLOCk:SRATe

    }
}
