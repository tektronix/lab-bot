//==========================================================================
// AwgEventGroupLow_steps.cs
// This file contains the low-order PI step definitions for the AWG PI Event Group commands. 
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
// AWG number -  AWG([1-4])? -OR -
//            -  (?: the)? AWG([1-4])? (depends on language usage)
// File path strings - ""(.+)"" used when you want the string that is delimited by the quotes File path strings
//                      
//==========================================================================
using TechTalk.SpecFlow;

namespace AwgTestFramework
{
	/// <summary>
    /// This class contains the PI step definitions for the %AWG PI Event Group commands.

    /// Generally the steps are set, get and should be operations.  The step sole responsibility
    /// is to make sure the correct %AWG object is used and that parameters such as channel,
    /// markers and clock references are correct for the %AWG object.
    /// 
    /// \ingroup highpi pisteps
    /// 
	/// </summary>
	
	[Binding] //Very important! This entry needs to be made in each step definition file. 
	public class AwgEventSteps_Low
	{

	}

	/// <summary>
	/// This class contains the high-order PI step definitions for the %AWG PI Event Group commands.

	/// Low-level steps set and get the values for commands, and test the raw values as returned from the 
	/// instrument. They DO NOT interpret values in any way! Interpretation, normalization, etc. need to 
	/// occur in the High-level step definitions. Notice the use of the word "value" in the steps - this 
	/// usually implies that the query returns a 0 or 1 or abbreviated text value (like SOFT) that should 
	/// be interpreted as ON or OFF or SOFTWARE to make the step more user-friendly. We do that in the 
	/// High-order step definitions.
	/// 
	/// \ingroup highpi pisteps
	/// </summary>
	[Binding] //Very important! This entry needs to be made in each step definition file.     
	public class AwgEventSteps_High
	{
		private AwgEventSteps_Low EventStepsLow = new AwgEventSteps_Low(); //!< We create instances of the low level steps to reference their functions

	}
}