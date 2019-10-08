//==========================================================================
// AwgDisplayGroup_Steps.cs
// This file contains the PI step definitions for the AWG PI Display Group commands. 
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
    /// This class contains the PI step definitions for the %AWG PI Display Group commands.

    /// Generally the steps are set, get and should be operations.  The step sole responsibility
    /// is to make sure the correct %AWG object is used and that parameters such as channel,
    /// markers and clock references are correct for the %AWG object.
    /// 
    /// \ingroup highpi pisteps
    /// 
    /// </summary>
    [Binding] //Very important! This entry needs to be made in each step definition file.
    public class AwgDisplayGroupSteps 
    {
        private readonly AwgDisplayGroup _awgDisplayGroup = new AwgDisplayGroup();

        // Unknown 01/01/01
        //glennj 7/30/2013
        /// <summary>
        /// Sets the channel plot display state to on
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
             \display\verbatim
        [When(@"I set the plot display state to on for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the plot display state to on for AWG ([1-4])")]
        public void SetPlotDisplayStateToOn(string awgNumber)
        {
            
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDisplayGroup.SetPlotDisplayState(awg, AwgDisplayGroup.DisplayPlot.On);
        }

        //glennj 7/30/2013
        /// <summary>
        /// Sets the channel plot display state to off
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
             \display\verbatim
        [When(@"I set the plot display state to off for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the plot display state to off for AWG ([1-4])")]
        public void SetPlotDisplayStateToOff(string awgNumber)
        {
            
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDisplayGroup.SetPlotDisplayState(awg, AwgDisplayGroup.DisplayPlot.Off);
        }

        // Unknown 01/01/01
        //glennj 7/30/2013
        /// <summary>
        /// Gets the plot display state 
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \display\verbatim
        [When(@"I get the plot display state for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the plot display state for AWG ([1-4])")]
        public void GetPlotDisplayState(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDisplayGroup.GetPlotDisplayState(awg);
        }

        // Unknown 01/01/01
        //glennj 7/30/2013
        /// <summary>
        /// Compares the current plot display to be on
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \display\verbatim
        [Then(@"the plot display state should be on for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the plot display state should be on for AWG ([1-4])")]
        public void TheDisplayStateShouldBeOn(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDisplayGroup.DisplayStateShouldBe(awg, AwgDisplayGroup.DisplayPlot.On);
        }

        //
        //glennj 7/30/2013
        /// <summary>
        /// Compares the current plot display to be off
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \display\verbatim
        [Then(@"the plot display state should be off for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the plot display state should be off for AWG ([1-4])")]
        public void TheDisplayStateShouldBeOff(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgDisplayGroup.DisplayStateShouldBe(awg, AwgDisplayGroup.DisplayPlot.Off);
        }

    }
}
