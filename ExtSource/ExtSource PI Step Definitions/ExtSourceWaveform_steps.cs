//==========================================================================
// ExtSourceWaveform__steps.cs
// This file contains the low-order PI step definitions for the External Source PI Waveform Group commands. 
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
    /// This class contains the low-order PI step definitions for the External Source PI Waveform Group commands.

    /// Low-level steps set and get the values for commands, and test the raw values as returned from the 
    /// instrument. They DO NOT interpret values in any way! Interpretation, normalization, etc. need to 
    /// occur in the High-level step definitions. Notice the use of the word "value" in the steps - this 
    /// usually implies that the query returns a 0 or 1 or abbreviated text value (like SOFT) that should 
    /// be interpreted as ON or OFF or SOFTWARE to make the step more user-friendly. We do that in the 
    /// High-order step definitions.
    /// 
    /// </summary> 
    [Binding] //Very important! This entry needs to be made in each step definition file.
    public class ExtSourceWaveformSteps
    {
        private readonly ExtSourceWaveformGroup _extSourceWaveformGroup = new ExtSourceWaveformGroup();

        #region WLISt:SIZE?

        /// <summary>
        /// Gets the waveform list count 
        /// 
        /// WLISt:SIZE? (query only)
        /// </summary>
        /*!
            \waveform\verbatim
        [When(@"I get the waveform list size on the External Source")]
            \endverbatim 
        */
        [When(@"I get the waveform list size on the External Source")]
        public void GetExtSrcWaveformListCount()
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceWaveformGroup.GetExtSrcWfmListSize(extSource);
        }


        /// <summary>
        /// Waits for the waveform list to have a waveform to be added
        /// 
        /// WLISt:SIZE? (query only)
        /// </summary>
        /// <param name="seconds">Time limit to wait for an entry to the waveform list</param>
        /*!
            \waveform\verbatim
        [When(@"I wait for up to ([0-9]+) seconds to add an entry to waveform list on the External Source")]
            \endverbatim 
        */
        [When(@"I wait for up to ([0-9]+) seconds to add an entry to waveform list on the External Source")]
        public void WaitForEntryToExtSrcWaveformList(string seconds)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceWaveformGroup.WaitForWfmListToAddWfms(extSource, "1", seconds);
        }

        /// <summary>
        /// Waits for the waveform list to have a waveform to be added
        /// 
        /// WLISt:SIZE? (query only)
        /// </summary>
        /// <param name="numEntries">Number of expected entries</param>
        /// <param name="seconds">Time limit to wait for an entry to the waveform list</param>
        /*!
            \waveform\verbatim
        [When(@"I wait for up to ([0-9]+) seconds to add ([0-9]+) entries to the waveform list on the External Source")]
            \endverbatim 
        */
        [When(@"I wait for up to ([0-9]+) seconds to add ([0-9]+) entries to the waveform list on the External Source")]
        public void WaitForEntriesToExtSrcWaveformList(string seconds, string numEntries)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceWaveformGroup.WaitForWfmListToAddWfms(extSource, numEntries, seconds);
        }
        #endregion WLISt:SIZE?

        #region WLISt:WAVeform:NEW
        /// <summary>
        /// Creates a new empty waveform of integer type in the waveform list
        /// 
        /// WLISt:WAVeform:NEW
        /// </summary>
        /// <param name="wfmName">Name of the new waveform</param>
        /// <param name="size">Size of the new waveform (in bytes)</param>
        /*!
          @waveform\verbatim
        [When(@"I create a new waveform named ""(.+)"" of size (\d+) and of integer type on the External Source")]
            \endverbatim 
        */
        [When(@"I create a new waveform named ""(.+)"" of size (\d+) and of integer type on the External Source")]
        public void CreateANewEmptyIntegerWaveformOnExtSrc(string wfmName, string size)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceWaveformGroup.SetExtSrcWfmNew(extSource, wfmName, size, "INTeger");
        }

        /// <summary>
        /// Creates a new empty waveform of real type in the waveform list
        /// 
        /// WLISt:WAVeform:NEW
        /// </summary>
        /// <param name="wfmName">Name of the new waveform</param>
        /// <param name="size">Size of the new waveform (in bytes)</param>
        /*!
          @waveform\verbatim
        [When(@"I create a new waveform named ""(.+)"" of size (\d+) and of real type on the External Source")]
            \endverbatim 
        */
        [When(@"I create a new waveform named ""(.+)"" of size (\d+) and of real type on the External Source")]
        public void CreateANewEmptyRealWaveformOnExtSrc(string wfmName, string size)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceWaveformGroup.SetExtSrcWfmNew(extSource, wfmName, size, "REAL");
        }
        #endregion WLISt:WAVeform:NEW
    }
}
