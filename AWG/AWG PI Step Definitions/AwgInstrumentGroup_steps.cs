//==========================================================================
// AwgInstrumentGroup_steps.cs
// This file contains the PI step definitions for instrument group commands
// of AWGs in the framework
//==========================================================================
// ReSharper disable CSharpWarnings::CS1587

using TechTalk.SpecFlow;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains the PI step definitions for the %AWG PI Status Group commands.

    /// Generally the steps are set, get and should be operations.  The step sole responsibility
    /// is to make sure the correct %AWG object is used and that parameters such as channel,
    /// markers and clock references are correct for the %AWG object.
    /// 
    /// \ingroup highpi pisteps
    /// 
    /// </summary>
    [Binding] //Very important! This entry needs to be made in each step definition file.     
    public class AwgInstrumentSteps
    {
        private readonly AwgInstrumentGroup _awgInstrumentGroup = new AwgInstrumentGroup();

        // glenn 10/24/2012
        /// <summary>
        /// Enables the AWG instrument couple source
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \instrument \verbatim 
        [When(@"I set the instrument couple source to on for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I set the instrument couple source to on for AWG ([1-4])")]
        public void WhenISetTheAWGInstrumentCoupleSourceToOn(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgInstrumentGroup.SetTheAwgInstrumentCoupleSource(awg, AwgInstrumentGroup.InstrumentCoupleSource.On);
        }

        //glennj 3/28/2014
        /// <summary>
        /// Disables the AWG instrument couple source
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \instrument \verbatim 
        [When(@"I set the instrument couple source to off for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I set the instrument couple source to off for AWG ([1-4])")]
        public void WhenISetTheAWGInstrumentCoupleSourceToOff(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgInstrumentGroup.SetTheAwgInstrumentCoupleSource(awg, AwgInstrumentGroup.InstrumentCoupleSource.Off);
        }

        // glenn 10/24/2012
        /// <summary>
        /// Gets the default AWG instrument couple source value.
        /// </summary>
        /*!
            \instrument \verbatim 
        [When(@"I get the instrument couple source for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I get the instrument couple source for AWG ([1-4])")]
        public void WhenIGetTheAWGInstrumentCoupleSource(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgInstrumentGroup.GetTheAwgInstrumentCoupleSource(awg);
        }

        //glennj 3/28/2014
        /// <summary>
        /// Validates the AWG instrument couple source is enabled
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \instrument \verbatim 
        [Then(@"the instrument couple source should be on for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the instrument couple source should be on for AWG ([1-4])")]
        public void ThenTheAWGInstrumentCoupleSourceShouldBeOn(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgInstrumentGroup.AwgInstrumentCoupleSourceShouldBe(awg, AwgInstrumentGroup.InstrumentCoupleSource.On);
        }

        //glennj 3/28/2014
        /// <summary>
        /// Validates the AWG instrument couple source is disabled
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \instrument \verbatim 
        [Then(@"the instrument couple source should be off for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the instrument couple source should be off for AWG ([1-4])")]
        public void ThenTheAWGInstrumentCoupleSourceShouldBeOff(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgInstrumentGroup.AwgInstrumentCoupleSourceShouldBe(awg, AwgInstrumentGroup.InstrumentCoupleSource.Off);
        }

        #region INSTrument:MODE

        //jhowells 1/30/13
        //glennj 3/28/2014
        /// <summary>
        /// Sets the instrument mode to awg for an AWG
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \instrument \verbatim 
        [When(@"I set the instrument mode to awg for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I set the instrument mode to awg for AWG ([1-4])")]
        public void SetInstrumentModeToAwg(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgInstrumentGroup.SetInstrumentMode(awg, AwgInstrumentGroup.InstrumentMode.Awg);
        }

        //glennj 3/28/2014
        /// <summary>
        /// Sets the instrument mode to function generator for an AWG
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \instrument \verbatim 
        [When(@"I set the instrument mode to function generator for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I set the instrument mode to function generator for AWG ([1-4])")]
        public void SetInstrumentModeToFGen(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgInstrumentGroup.SetInstrumentMode(awg, AwgInstrumentGroup.InstrumentMode.FGen);
        }

        //jhowells 1/30/13
        //glennj 3/28/2014
        /// <summary>
        /// Gets the instrument mode for an AWG
        /// </summary>
        /*!
            \instrument\verbatim 
        [When(@"I get the instrument mode for AWG ([1-4])")]
            \endverbatim
        */
        [When(@"I get the instrument mode for AWG ([1-4])")]
        public void GetTheInstrumentMode(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgInstrumentGroup.GetInstrumentMode(awg);
        }

        //jhowells 1/30/13
        //glennj 9/9/2013
        /// <summary>
        /// Verifies that the instrument mode is awg for an AWG
        /// </summary>
        /*!
            \instrument\verbatim 
        [Then(@"the instrument mode should be awg for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the instrument mode should be awg for AWG ([1-4])")]
        public void TheAWGInstrumentModeShouldBeAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgInstrumentGroup.AwgInstrumentModeShouldBe(awg, AwgInstrumentGroup.InstrumentMode.Awg);
        }

        //jhowells 1/30/13
        //glennj 9/9/2013
        /// <summary>
        /// Verifies that the instrument mode is function generator for an AWG
        /// </summary>
        /*!
            \instrument\verbatim 
        [Then(@"the instrument mode should be function generator for AWG ([1-4])")]
            \endverbatim
        */
        [Then(@"the instrument mode should be function generator for AWG ([1-4])")]
        public void TheAWGInstrumentModeShouldBeFgen(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgInstrumentGroup.AwgInstrumentModeShouldBe(awg, AwgInstrumentGroup.InstrumentMode.FGen);
        }

        #endregion INSTrument:MODE
    }
}