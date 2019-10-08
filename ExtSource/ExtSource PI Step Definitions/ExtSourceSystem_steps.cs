//==========================================================================
// ExtSourceSystem__steps.cs
// This file contains the low-order PI step definitions for the External Source PI System Group commands. 
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

using TechTalk.SpecFlow;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains the low-order PI step definitions for the External Source PI System Group commands.

    /// Low-level steps set and get the values for commands, and test the raw values as returned from the 
    /// instrument. They DO NOT interpret values in any way! Interpretation, normalization, etc. need to 
    /// occur in the High-level step definitions. Notice the use of the word "value" in the steps - this 
    /// usually implies that the query returns a 0 or 1 or abbreviated text value (like SOFT) that should 
    /// be interpreted as ON or OFF or SOFTWARE to make the step more user-friendly. We do that in the 
    /// High-order step definitions.
    /// 
    /// </summary> 
    [Binding] //Very important! This entry needs to be made in each step definition file.
    public class ExtSourceSystemSteps
    {
        private readonly ExtSourceSystemGroup _extSourceSystemGroup = new ExtSourceSystemGroup();
        /// <summary>
        /// Open a new VISA session to the external source
        /// </summary>  
        /*!
            \extsource\verbatim
        [Given(@"an External Source")]
            \endverbatim 
        */
        [Given(@"an External Source")]
        public void GivenAnExternalSource()
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(true);
            _extSourceSystemGroup.GetExtSrcIDNQuery(extSource);
            //Make sure no errors from previous tests/runs
            _extSourceSystemGroup.ExtSrcCLS(extSource);
        }

        /// <summary>
        /// Gets the external source ID information
        /// </summary>
        /*!
           \extsource\verbatim
        [When(@"I get the ID String from the External Source")]
           \endverbatim 
       */
        [When(@"I get the ID String from the External Source")]
        public void GetTheExternalSourceID()
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceSystemGroup.GetExtSrcIDNQuery(extSource);
        }

        /// <summary>
        /// Clears the error queue on the External Source
        ///
        /// *CLS 
        /// </summary>
        /*!
            \status\verbatim
        [When(@"I clear the error queue on the External Source")]
            \endverbatim 
        */
        [When(@"I clear the error queue on the External Source")]
        public void ClearTheErrorQueueOnTheExtSrc()
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceSystemGroup.ExtSrcCLS(extSource);
        }

        /// <summary>
        /// This command is used to return the implemented options on the external source
        /// 
        /// *OPT?(Query Only)
        /// </summary>
        /*!
            \status\verbatim
        [When(@"I get value of the options implemented on the External Source")]
            \endverbatim 
        */
        [When(@"I get value of the options implemented on the External Source")]
        public void GetTheValueOfTheOptionsImplementedOnTheExtSrc()
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceSystemGroup.GetExtSrcOptQuery(extSource);
        }


        //Jhowells 6-13-12
        /// <summary>
        /// Compares implemented options on the AWG against the expected options.
        /// 
        /// *OPT?(Query Only)
        /// </summary>
        /// <param name="expectedOptions"></param>
        /*!
            \status\verbatim
        [Then(@"the value of options implemented on the External Source should be (.+)")]
            \endverbatim 
        */
        [Then(@"the value of options implemented on the External Source should be (.+)")]
        public void TheValueOfOptionsImplementedOnTheExtSrcShouldBe(string expectedOptions)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceSystemGroup.TheExtSrcOptionsShouldBe(extSource, expectedOptions);
        }
     
        /// <summary>
        /// Set the output state for a channel for the external source to On
        /// </summary>
        /// <param name="channel"></param>
        /*!
            \extsource\verbatim
        [When(@"I set the output state for channel (1|2) to on for the External Source")]
            \endverbatim 
        */
        [When(@"I set the output state for channel (1|2) to on for the External Source")]
        public void SetTheExtSrcOutputStateToOn(string channel)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceSystemGroup.SetExtSrcOutputState(extSource, channel, "ON");
        }

        //glennj 09/23/2013
        /// <summary>
        /// Set the output state for a channel for the external source to Off
        /// </summary>
        /// <param name="channel"></param>
        /*!
            \extsource\verbatim
        [When(@"I set the output state for channel (1|2) to off for the External Source")]
            \endverbatim 
        */
        [When(@"I set the output state for channel (1|2) to off for the External Source")]
        public void SetTheExtSrcOutputStateToOff(string channel)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceSystemGroup.SetExtSrcOutputState(extSource, channel, "OFF");
        }
        
        /// <summary>
        /// Resets the External Source
        /// 
        /// *RST
        /// </summary>
        /*!
            \system\verbatim
        [When(@"I perform a reset on the External Source"")]
            \endverbatim 
        */
        [When(@"I perform a reset on the External Source")]
        public void ResetTheExternalSource()
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceSystemGroup.ExtSrcRst(extSource);
            _extSourceSystemGroup.WaitForExternalSource(extSource);
        }

        /// <summary>
        /// Waits a certain duration in seconds for the external source to complete an operation
        /// </summary>
        /*!
           \system\verbatim
        [When("I wait ([0-9]+) seconds for the task to complete on the External Source")]
           \endverbatim 
        */
        [When("I wait ([0-9]+) seconds for the task to complete on the External Source")]
        public void WaitForExtSrcCompleteTimelimit(string seconds)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
           _extSourceSystemGroup.WaitForTimelimitExternalSource(extSource, seconds);
        }

        /// <summary>
        /// Waits for an external source to complete an operation
        /// </summary>
        /*!
           \system\verbatim
        [When("I wait for the operation to complete on the External Source")]
           \endverbatim 
        */
        [When("I wait for the operation to complete on the External Source")]
        public void WaitForExtSrcComplete()
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceSystemGroup.WaitForExternalSource(extSource);
        }
        
        /// <summary>
        /// Queries the error queue for a 0 error message fron the External Source 
        /// 
        /// Purposely no "get" step for the error queue, we want to get and check it every time.@n
        /// SYSTem:ERRor?
        /// </summary>
        /*!
            \system\verbatim
        [Then(@"there should be no error from the External Source")]
            \endverbatim 
        */
        [Then(@"there should be no error from the External Source")]
        public void ThereShouldBeNoErrorFromTheExtSrc()
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceSystemGroup.TheExtSrcShouldHaveNoErrors(extSource);
        }
    }
}
