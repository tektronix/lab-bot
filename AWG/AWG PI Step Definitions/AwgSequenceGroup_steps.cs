//==========================================================================
// AwgSequenceGroup_steps.cs
// This file contains the PI step definitions for the AWG PI Sequence Group commands. 
//
// Steps DO NOT interpret values in any way! Interpretation, normalization, etc. need to 
// occur in the helper group functions. Notice the use of the word "value" in the steps - this 
// usually implies that the query returns a 0 or 1 or abbreviated text value (like SOFT) that should 
// be interpreted as ON or OFF or SOFTWARE to make the step more user-friendly. We do that in the 
// High-order step definitions.
// 
// PLEASE use the following regular expressions to match specified numeric formats and other values:
// <NR1> - ((?<!\S)[-+]?\d+(?!\S))
// <NR3> - ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?)
// AWG number -  AWG([1-4])
// File path strings - ""(.+)"" used when you want the string that is delimited by the quotes File path strings
//                     \""(.+)\"" used when you want the string that is delimited by the quotes 
//==========================================================================

// Each Sequence ELement Parameter list has (by index):
// [0] - empty - I'd rather not play zero-based array games whth channel numbers!
// [1]  Seq_CH1WfmName
// [2]  Seq_CH2WfmName
// [3]  Seq_CH3WfmName
// [4]  Seq_CH4WfmName
// [5]  Seq_WaitTrigState
// [6]  Seq_InfiniteLoopState
// [7]  Seq_LoopCountValue
// [8]  Seq_EventJumpTargetType
// [9]  Seq_EventJumpPattern
// [10] Seq_EventJumpTargetIndex
// [11] Seq_GoToState
// [12] Seq_GoToIndexValue
// [13] Seq_SubsequenceName
// [14] Seq_MaxArraySize - always must be the last item in the enum in AWG.cs

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace AwgTestFramework
{
    ///<summary>
    /// This class contains the PI step definitions for the %AWG PI Sequence Group commands.

    /// Generally the steps are set, get and should be operations.  The step sole responsibility
    /// is to make sure the correct %AWG object is used and that parameters such as channel,
    /// markers and clock references are correct for the %AWG object.
    /// 
    /// \ingroup highpi pisteps
    /// 
    /// </summary>
    [Binding] //Very important! This entry needs to be made in each step definition file. 
    public class AwgSequenceSteps
    {
        readonly AwgSequenceGroup _awgSequenceGroup = new AwgSequenceGroup(); 

        #region SLIST

        #region SLISt:NAME

        //glennj 8/13/2013
        /// <summary>
        /// Gets the name of the sequence at a particular index in the sequence list
        /// </summary>
        /// <param name="listIndex">Sequence List Index</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \sequence\verbatim
        [When(@"I get the name of the sequence with an index of ((?<!\S)[-+]?\d+(?!\S)) in the sequence list for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the name of the sequence with an index of ((?<!\S)[-+]?\d+(?!\S)) in the sequence list for AWG ([1-4])")]
        public void GetTheNameOfTheSequenceeAtSequenceListIndex(string listIndex, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.UpdateSequenceListName(awg, listIndex);
        }

        //glennj 8/13/2013
        /// <summary>
        /// Compares the name of the Sequence against the expected value.
        /// </summary>
        /// <param name="expectedSeqName">Expected Sequence name</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \sequence\verbatim
        [Then(@"the name of the sequence should be ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the name of the sequence should be ""(.+)"" for AWG ([1-4])")]
        public void TheNameOfTheSequenceAtSequenceListIndexShouldBe(string expectedSeqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceListNameShouldBe(awg, expectedSeqName);
        }


        #endregion SLISt:NAME

        #region SLISt:SEQuence:DELete

        //glennj 8/13/2013
        /// <summary>
        /// Deletes a sequence
        /// </summary>
        /// <param name="seqName">sequence Name</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \sequence\verbatim
        [When(@"I delete the sequence ""(.+)"" from the sequence list for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I delete the sequence ""(.+)"" from the sequence list for AWG ([1-4])")]
        public void DeleteSequenceListItem(string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.DeleteSequenceListSequence(awg, seqName);
        }

        //glennj 8/13/2013
        /// <summary>
        /// Deletes all the sequences from the currently loaded setup.
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \sequence\verbatim
        [When(@"I delete all sequences from the sequence list for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I delete all sequences from the sequence list for AWG ([1-4])")]
        public void DeleteAllSequenceListItems(string awgNumber)
        { 
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            const string seqName = "ALL";
            _awgSequenceGroup.DeleteSequenceListSequence(awg, seqName, false);
        }

        #endregion SLISt:SEQuence:DELete

        #region SLISt:SEQuence:EVENt:JTIMing

        //glennj 8/20/2013
        /// <summary>
        /// Set the Event Jump Timing to be the End for a given sequence and AWG
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I set the jump timing event to the end for sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the jump timing event to the end for sequence ""(.+)"" for AWG ([1-4])")]
        public void SetEventJumpTimingToTheEndForSequence(string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceEventPatternJumpTiming(awg, seqName, AwgSequenceGroup.SequenceEventJumpTiming.End);
        }

        //glennj 8/20/2013
        /// <summary>
        /// Set the Event Jump Timing to Immediate for a given sequence and AWG
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I set the jump timing event to be immediate for sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the jump timing event to be immediate for sequence ""(.+)"" for AWG ([1-4])")]
        public void SetEventJumpTimingToBeImmediateForSequence(string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceEventPatternJumpTiming(awg, seqName, AwgSequenceGroup.SequenceEventJumpTiming.Immediate);
        }

        //glennj 8/20/2013
        /// <summary>
        /// Update the property for Event Jump Timing of an AWG for a specific sequence
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I get the jump timing event for sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the jump timing event for sequence ""(.+)"" for AWG ([1-4])")]
        public void GetEventJumpTimingForSequence(string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.UpdateSequenceEventPatternJumpTiming(awg, seqName);
        }

        //glennj 8/20/2013
        /// <summary>
        /// Test the property of an AWG for an expected Event Jump Timing state of End
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [Then(@"the jump timing event for sequence ""(.+)"" should be the end for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the jump timing event for sequence ""(.+)"" should be the end for AWG ([1-4])")]
        public void EventJumpTimingForSequenceShouldBeTheEnd(string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceEventPatternJumpTimingShouldBe(awg, seqName, AwgSequenceGroup.SequenceEventJumpTiming.End);
        }

        //glennj 8/20/2013
        /// <summary>
        /// Test the property of an AWG for an expected Event Jump Timing state of Immediate
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [Then(@"the jump timing event for sequence ""(.+)"" should be immediate for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the jump timing event for sequence ""(.+)"" should be immediate for AWG ([1-4])")]
        public void EventJumpTimingForSequenceShouldBeImmediate(string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceEventPatternJumpTimingShouldBe(awg, seqName, AwgSequenceGroup.SequenceEventJumpTiming.Immediate);
        }

        #endregion SLISt:SEQuence:EVENt:JTIMing

        #region SLISt:SEQuence:EVENt:PJUMp:ENABle

        //glennj 8/20/2013
        /// <summary>
        /// Set the jump pattern event for a sequence to On
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I set the jump pattern event to on for sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the jump pattern event to on for sequence ""(.+)"" for AWG ([1-4])")]
        public void SetJumpPatternEventToOn(string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceEventPatternJumpEnable(awg, seqName, AwgSequenceGroup.SequenceJumpPatternEvent.On);
        }

        //glennj 8/20/2013
        /// <summary>
        /// Set the jump pattern event for a sequence to Off
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I set the jump pattern event to off for sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the jump pattern event to off for sequence ""(.+)"" for AWG ([1-4])")]
        public void SetJumpPatternEventToOff(string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceEventPatternJumpEnable(awg, seqName, AwgSequenceGroup.SequenceJumpPatternEvent.Off);
        }

        //glennj 8/20/2013
        /// <summary>
        /// Get (update) the property of the AWG for the state of the jump pattern event
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I get the jump pattern event for sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the jump pattern event for sequence ""(.+)"" for AWG ([1-4])")]
        public void GetJumpPatternEventFor(string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.UpdateSequenceEventPatternJumpEnableProperty(awg, seqName);
        }

        //glennj 8/20/2013
        /// <summary>
        /// The jump pattern event for a specified sequence for a specified AWG should be On
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [Then(@"the jump pattern event for sequence ""(.+)"" should be on for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the jump pattern event for sequence ""(.+)"" should be on for AWG ([1-4])")]
        public void JumpPatternEventShouldBeOn(string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceEventPatternJumpEnableShouldBe(awg, seqName, AwgSequenceGroup.SequenceJumpPatternEvent.On);
        }

        //glennj 8/20/2013
        /// <summary>
        /// The jump pattern event for a specified sequence for a specified AWG should be Off
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [Then(@"the jump pattern event for sequence ""(.+)"" should be off for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the jump pattern event for sequence ""(.+)"" should be off for AWG ([1-4])")]
        public void JumpPatternEventShouldBeOff(string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceEventPatternJumpEnableShouldBe(awg, seqName, AwgSequenceGroup.SequenceJumpPatternEvent.Off);
        }

        #endregion SLISt:SEQuence:EVENt:PJUMp:ENABle

        #region SLISt:SEQuence:EVENt:PJUMp:DEFine

        //glennj 8/20/2013
        /// <summary>
        /// Associate a pattern with step to jump to for a sequence of a an AWG
        /// </summary>
        /// <param name="jumpStep"></param>
        /// <param name="pattern"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I set the step of (\d+) for the jump pattern of (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the step of (\d+) for the jump pattern of (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SetTheStepOfForTheJumpPatternOfSequence(string jumpStep, string pattern, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceEventPatternJumpDefine(awg, seqName, pattern, jumpStep);
        }

        //glennj 8/20/2013
        /// <summary>
        /// Get the step that is associated to a pattern of a sequence
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I get the step for the jump pattern of (\d+) for sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the step for the jump pattern of (\d+) for sequence ""(.+)"" for AWG ([1-4])")]
        public void GetTheStepForTheJumpPatternOfForSequence(string pattern, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.UpdateSequenceEventPatternJumpDefine(awg, seqName, pattern);
        }

        //glennj 8/20/2013
        /// <summary>
        /// Compare expected step association with the updated property
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="jumpStep"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [Then(@"the step for the jump pattern for sequence ""(.+)"" should be (\d+) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the step for the jump pattern for sequence ""(.+)"" should be (\d+) for AWG ([1-4])")]
        public void StepForTheJumpPatternForSequenceShouldBe(string seqName, string jumpStep, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceEventPatternJumpDefineShouldBe(awg, seqName, jumpStep);
        }

        #endregion SLISt:SEQuence:EVENt:PJUMp:DEFine

        #region SLISt:SEQuence:EVENt:PJUMp:SIZE

        //glennj 8/21/2013
        /// <summary>
        /// Updates the property of AWG for max number of Pattern Jumps
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I get the max number of pattern jumps for a sequence for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the max number of pattern jumps for a sequence for AWG ([1-4])")]
        public void GetMaxNumberOfPatternJumpsForASequence(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.UpdateSequenceEventPatternJumpSize(awg);
        }

        //glennj 8/31/2013
        /// <summary>
        /// Compare for a the expected number of max pattern jumps to update property
        /// </summary>
        /// <param name="expectedMaxNumber"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [Then(@"the max number of pattern jumps for a sequence should be (\d+) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the max number of pattern jumps for a sequence should be (\d+) for AWG ([1-4])")]
        public void MaxNumberOfPatternJumpsForASequenceShouldBe(string expectedMaxNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceEventPatternJumpSizeShouldBe(awg, expectedMaxNumber);
        }

        #endregion SLISt:SEQuence:EVENt:PJUMp:SIZE

        #region SLISt:SEQuence:LENGth

        //glennj 8/13/2013
        /// <summary>
        /// Gets the number of steps of the given sequence
        /// </summary>
        /// <param name="seqName">Name of the sequence</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \sequence\verbatim
        [When(@"I get the length of the sequence ""(.+)"" from the sequence list for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the length of the sequence ""(.+)"" from the sequence list for AWG ([1-4])")]
        public void GetTheLengthOfSequenceFromSequenceList(string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.GetSequenceLength(awg, seqName);
        }

        //glennj 8/13/2013
        /// <summary>
        /// Compares the the length of the sequence against the expected value.
        /// </summary>
        /// <param name="expectedLength">Expected sequence length</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \sequence\verbatim
        [Then(@"the length of the sequence should be (.+) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the length of the sequence should be (.+) for AWG ([1-4])")]
        public void ThenLengthofSequenceShouldBe(string expectedLength, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceLengthShouldBe(awg, expectedLength);
        }


        #endregion SLISt:SEQuence:LENGth

        #region SLISt:SEQuence:NEW

        //glennj 8/12/2013
        /// <summary>
        /// Creates a new sequence of the given size with the given name and loads it into the sequence list
        /// </summary>
        /// <param name="seqName">Name of the new sequence</param>
        /// <param name="size">Desired size of the new sequence</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
           \sequence\verbatim
        [When(@"I create a new sequence named ""(.+)"" of size ((?<!\S)[-+]?\d+(?!\S)) for AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I create a new sequence named ""(.+)"" of size ((?<!\S)[-+]?\d+(?!\S)) for AWG ([1-4])")]
        public void CreateANewSequenceOfSize(string seqName, string size, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.CreateANewSequence(awg, seqName, size);
        }

        //glennj 8/12/2013
        /// <summary>
        /// Creates a new sequence of the given size with the given name and loads it into the sequence list
        /// </summary>
        /// <param name="seqName">Name of the new sequence</param>
        /// <param name="size">Desired size of the new sequence</param>
        /// <param name="tracks">1-8 tracks</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
           \sequence\verbatim
        [When(@"I create a new sequence named ""(.+)"" of size ((?<!\S)[-+]?\d+(?!\S)) and ((?<!\S)[-+]?\d+(?!\S)) tracks for AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I create a new sequence named ""(.+)"" of size ((?<!\S)[-+]?\d+(?!\S)) and ((?<!\S)[-+]?\d+(?!\S)) tracks for AWG ([1-4])")]
        public void CreateANewSequenceofSizeAndNumberOfTracks(string seqName, string size, string tracks, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.CreateANewSequence(awg, seqName, size, tracks);
        }

        #endregion SLISt:SEQuence:NEW

        #region SLISt:SEQuence:STEP:ADD

        //Keerthi 05/28/2015
        /// <summary>
        /// Add steps to the sequence at a specified step
        /// </summary>
        /// <param name="seqName">Name of the new sequence</param>
        /// <param name="addNoOfSteps">Add how many number of steps</param>
        /// /// <param name="addAtWhatStep">Add at what step</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
           \sequence\verbatim
       [When(@"I add (.*) new steps at the step (.*) of the named sequence ""(.*)"" for AWG ([1-4])")]
           \endverbatim 
        */

        [When(@"I add (\d+) new steps at the step (\d+) of the named sequence ""(.*)"" for AWG ([1-4])")]

        public void AddNewStepsAtTheNamedSequence(string addNoOfSteps, string addAtWhatStep, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.AddStepToSequence(addNoOfSteps, addAtWhatStep, seqName, awg);

        }

       #endregion SLISt:SEQuence:STEP:ADD


        

        #region SLISt:SEQuence:RFLag
        /// <summary>
        /// Using SLISt:SEQuence:STEP:RFlag set the enable flag repeat mode to on
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \sequence\verbatim
        [When(@"I set the enable flag repeat to on for the sequence named ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the enable flag repeat to on for the sequence named ""(.+)"" for AWG ([1-4])")]
        public void SetSequenceRepeatFlagOn(string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceRepeatFlag(awg, seqName, AwgSequenceGroup.SequenceFlagRepeatState.On);
        }

        /// <summary>
        /// Using SLISt:SEQuence:STEP:RFlag set the enable flag repeat mode to off
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \sequence\verbatim
        [When(@"I set the enable flag repeat to off for the sequence named ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the enable flag repeat to off for the sequence named ""(.+)"" for AWG ([1-4])")]
        public void SetSequenceRepeatFlagOff(string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceRepeatFlag(awg, seqName, AwgSequenceGroup.SequenceFlagRepeatState.Off);
        }

        /// <summary>
        /// Using SLISt:SEQuence:STEP:RFlag?  gets the enable flag repeat state on or off
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \sequence\verbatim
        [When(@"I get the enable flag repeat value for the sequence named ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the enable flag repeat value for the sequence named ""(.+)"" for AWG ([1-4])")]
        public void GetSequenceRepeatFlagState(string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.GetSequenceRepeatFlag(awg, seqName);
        }

        /// <summary>
        /// Using SLISt:SEQuence:STEP:RFlag checks to see if expected and actual enable flag repeat state are both ON
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \sequence\verbatim
        [Then(@"the enable flag repeat state should be on for the sequence named ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the enable flag repeat state should be on for the sequence named ""(.+)"" for AWG ([1-4])")]
        public void SequenceRepeatFlagStateShouldBeOn(string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceRepeatFlagShouldBe(awg,seqName,AwgSequenceGroup.SequenceFlagRepeatState.On);
        }

        /// <summary>
        /// Using SLISt:SEQuence:STEP:RFlag checks to see if expected and actual enable flag repeat state are both OFF
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \sequence\verbatim
        [Then(@"the enable flag repeat state should be off for the sequence named ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the enable flag repeat state should be off for the sequence named ""(.+)"" for AWG ([1-4])")]
        public void SequenceRepeatFlagStateShouldBeOff(string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceRepeatFlagShouldBe(awg, seqName, AwgSequenceGroup.SequenceFlagRepeatState.Off);
        }
        #endregion SLISt:SEQuence:RFLag

        #region SLISt:SEQuence:STEP:EJUMp

        /// <summary>
        /// Set Event Jump is a specific step number
        /// </summary>
        /// <param name="jumpStepNumber"></param>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I set the event jump to step (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the event jump to step (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SetEventJumpToStepOfStepOfSequence(string jumpStepNumber, string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceStepEventJumpOperation(awg, seqName, stepNumber, AwgSequenceGroup.StepEventJumpMode.Nr1, jumpStepNumber);
        }

        /// <summary>
        /// Set Event Jump is the first step of the sequence
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I set the event jump to the first step of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the event jump to the first step of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SetEventJumpToFirstStepOfStepOfSequence(string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceStepEventJumpOperation(awg, seqName, stepNumber, AwgSequenceGroup.StepEventJumpMode.First);
        }

        /// <summary>
        /// Set Event Jump is the last step of the sequence
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I set the event jump to the last step of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the event jump to the last step of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SetEventJumpToLastStepOfStepOfSequence(string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceStepEventJumpOperation(awg, seqName, stepNumber, AwgSequenceGroup.StepEventJumpMode.Last);
        }

        /// <summary>
        /// Set Event Jump is the next step of the sequence
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I set the event jump to the next step of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the event jump to the next step of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SetEventJumpToNextStepOfStepOfSequence(string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceStepEventJumpOperation(awg, seqName, stepNumber, AwgSequenceGroup.StepEventJumpMode.Next);
        }

        /// <summary>
        /// Set Event Jump is the end of the sequence where it sits at 0 volts until play is stopped
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I set the event jump to the end step of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the event jump to the end step of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SetEventJumpToEndStepOfStepOfSequence(string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceStepEventJumpOperation(awg, seqName, stepNumber, AwgSequenceGroup.StepEventJumpMode.End);
        }

        /// <summary>
        /// Gets the Set Event Jump for a specific step of a specific sequence
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I get the event jump of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the event jump of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void GetEventJumpOfStepOfSequence(string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.UpdateSequenceStepEventJumpOperation(awg, seqName, stepNumber);
        }

        /// <summary>
        /// Compares the update property SequenceStepEventJumpOpertation for a step Set Event Jump should be integer/value
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="stepTarget"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [Then(@"the event jump of step (\d+) of sequence ""(.+)"" should be (\d+) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the event jump of step (\d+) of sequence ""(.+)"" should be (\d+) for AWG ([1-4])")]
        public void EventJumpOfStepOfSequenceShouldBeStepNumber(string stepNumber, string seqName, string stepTarget, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceStepEventJumpOperationShouldBe(awg, seqName, stepNumber, AwgSequenceGroup.StepEventJumpMode.Nr1, stepTarget);
        }

        /// <summary>
        /// Compares the update property SequenceStepEventJumpOpertation for a step Set Event Jump should be First
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [Then(@"the event jump of step (\d+) of sequence ""(.+)"" should be first for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the event jump of step (\d+) of sequence ""(.+)"" should be first for AWG ([1-4])")]
        public void EventJumpOfStepOfSequenceShouldBeFirst(string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceStepEventJumpOperationShouldBe(awg, seqName, stepNumber, AwgSequenceGroup.StepEventJumpMode.First);
        }

        /// <summary>
        /// Compares the update property SequenceStepEventJumpOpertation for a step Set Event Jump should be Last
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [Then(@"the event jump of step (\d+) of sequence ""(.+)"" should be last for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the event jump of step (\d+) of sequence ""(.+)"" should be last for AWG ([1-4])")]
        public void EventJumpOfStepOfSequenceShouldBeLast(string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceStepEventJumpOperationShouldBe(awg, seqName, stepNumber, AwgSequenceGroup.StepEventJumpMode.Last);
        }

        /// <summary>
        /// 
        /// Compares the update property SequenceStepEventJumpOpertation for a step Set Event Jump should be Next
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [Then(@"the event jump of step (\d+) of sequence ""(.+)"" should be next for AWG ([1-4])")
            \endverbatim 
        */
        [Then(@"the event jump of step (\d+) of sequence ""(.+)"" should be next for AWG ([1-4])")]
        public void EventJumpOfStepOfSequenceShouldBeNext(string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceStepEventJumpOperationShouldBe(awg, seqName, stepNumber, AwgSequenceGroup.StepEventJumpMode.Next);
        }

        /// <summary>
        /// Compares the update property SequenceStepEventJumpOpertation for a step Set Event Jump should be End
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [Then(@"the event jump of step (\d+) of sequence ""(.+)"" should be end for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the event jump of step (\d+) of sequence ""(.+)"" should be end for AWG ([1-4])")]
        public void EventJumpOfStepOfSequenceShouldBeEnd(string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceStepEventJumpOperationShouldBe(awg, seqName, stepNumber, AwgSequenceGroup.StepEventJumpMode.End);
        }

        #endregion SLISt:SEQuence:STEP:EJUMp

        #region SLISt:SEQuence:STEP:EJINput

        /// <summary>
        /// Set the Event Jump Input to a specific step number of a specific sequence to off
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I set the event jump input to off of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the event jump input to off of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SetEventJumpInputToStepOfStepOfSequenceToOff(string stepNumber, string seqName, string awgNumber)
        {
            
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceStepEventJumpInput(awg, seqName, stepNumber, AwgSequenceGroup.StepEventJumpInputMode.Off);
        }

        /// <summary>
        /// Set the Event Jump Input to a specific step number of a specific sequence to trigger A
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I set the event jump input to trigger A of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the event jump input to trigger A of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SetEventJumpInputToStepOfStepOfSequenceTriggerA(string stepNumber, string seqName, string awgNumber)
        {
            
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceStepEventJumpInput(awg, seqName, stepNumber, AwgSequenceGroup.StepEventJumpInputMode.TriggerA);
        }

        /// <summary>
        /// Set the Event Jump Input to a specific step number of a specific sequence to trigger B
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I set the event jump input to trigger B of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the event jump input to trigger B of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SetEventJumpInputToStepOfStepOfSequenceTriggerB(string stepNumber, string seqName, string awgNumber)
        {
            
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceStepEventJumpInput(awg, seqName, stepNumber, AwgSequenceGroup.StepEventJumpInputMode.TriggerB);
        }

        /// <summary>
        /// Set the Event Jump Input to a specific step number of a specific sequence to internal trigger 
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I set the event jump input to internal trigger of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the event jump input to internal trigger of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SetEventJumpInputToStepOfStepOfSequenceInternalTrigger(string stepNumber, string seqName, string awgNumber)
        {

            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceStepEventJumpInput(awg, seqName, stepNumber, AwgSequenceGroup.StepEventJumpInputMode.InternalTrigger);
        }
        
        /// <summary>
        /// Gets the Event Jump Input mode for a specific step of a specific sequence
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I get the event jump input of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the event jump input of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void GetEventJumpInputOfStepOfSequence(string stepNumber, string seqName, string awgNumber)
        {
            
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.UpdateSequenceStepEventJumpInput(awg, seqName, stepNumber);
        }

        /// <summary>
        /// Compares the update property SequenceStepEventJumpInput for a step Set Event Jump Input should be Off
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [Then(@"the event jump input of step (\d+) of sequence ""(.+)"" should be off for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the event jump input of step (\d+) of sequence ""(.+)"" should be off for AWG ([1-4])")]
        public void EventJumpInputOfStepOfSequenceShouldBeEnd(string stepNumber, string seqName, string awgNumber)
        {
            
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceStepEventJumpInputShouldBe(awg, seqName, stepNumber, AwgSequenceGroup.StepEventJumpInputMode.Off);
        }

        /// <summary>
        /// Compares the update property SequenceStepEventJumpInput for a step Set Event Jump Input should be Trigger A
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [Then(@"the event jump input of step (\d+) of sequence ""(.+)"" should be trigger A for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the event jump input of step (\d+) of sequence ""(.+)"" should be trigger A for AWG ([1-4])")]
        public void EventJumpInputOfStepOfSequenceShouldBeTriggerA(string stepNumber, string seqName, string awgNumber)
        {
            
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceStepEventJumpInputShouldBe(awg, seqName, stepNumber, AwgSequenceGroup.StepEventJumpInputMode.TriggerA);
        }

        /// <summary>
        /// Compares the update property SequenceStepEventJumpInput for a step Set Event Jump Input should be Trigger B
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [Then(@"the event jump input of step (\d+) of sequence ""(.+)"" should be trigger B for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the event jump input of step (\d+) of sequence ""(.+)"" should be trigger B for AWG ([1-4])")]
        public void EventJumpInputOfStepOfSequenceShouldBeTriggerB(string stepNumber, string seqName, string awgNumber)
        {
            
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceStepEventJumpInputShouldBe(awg, seqName, stepNumber, AwgSequenceGroup.StepEventJumpInputMode.TriggerB);
        }

        /// <summary>
        /// Compares the update property SequenceStepEventJumpInput for a step Set Event Jump Input should be Internal Trigger
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [Then(@"the event jump input of step (\d+) of sequence ""(.+)"" should be internal trigger for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the event jump input of step (\d+) of sequence ""(.+)"" should be internal trigger for AWG ([1-4])")]
        public void EventJumpInputOfStepOfSequenceShouldBeTriggerInternal(string stepNumber, string seqName, string awgNumber)
        {

            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceStepEventJumpInputShouldBe(awg, seqName, stepNumber, AwgSequenceGroup.StepEventJumpInputMode.InternalTrigger);
        }

        #endregion SLISt:SEQuence:STEP:EJINput

        #region SLISt:SEQuence:STEP:GOTO

        /// <summary>
        /// Goto target is a specific step number
        /// </summary>
        /// <param name="nextStep"></param>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I set the goto target to step (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")] 
            \endverbatim 
        */
        [When(@"I set the goto target to step (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SetGotoTargetToStepOfStepOfSequence(string nextStep, string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceStepGoto(awg, seqName, stepNumber, AwgSequenceGroup.StepGotoMode.Nr1, nextStep);
        }

        /// <summary>
        /// Goto target is the first step of the sequence
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I set the goto target to the first step of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the goto target to the first step of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SetGotoTargetToFirstStepOfStepOfSequence(string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceStepGoto(awg, seqName, stepNumber, AwgSequenceGroup.StepGotoMode.First);
        }

        /// <summary>
        /// Goto target is the last step of the sequence
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I set the goto target to the last step of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the goto target to the last step of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SetGotoTargetToLastStepOfStepOfSequence(string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceStepGoto(awg, seqName, stepNumber, AwgSequenceGroup.StepGotoMode.Last);
        }

        /// <summary>
        /// Goto target is the next step of the sequence
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I set the goto target to the next step of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the goto target to the next step of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SetGotoTargetToNextStepOfStepOfSequence(string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceStepGoto(awg, seqName, stepNumber, AwgSequenceGroup.StepGotoMode.Next);
        }

        /// <summary>
        /// Goto target is the end of the sequence where it sits at 0 volts until play is stopped
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I set the goto target to the end step of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the goto target to the end step of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SetGotoTargetToEndStepOfStepOfSequence(string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceStepGoto(awg, seqName, stepNumber, AwgSequenceGroup.StepGotoMode.End);
        }

        /// <summary>
        /// Gets the goto target for a specific step of a specific sequence
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I get the goto target of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the goto target of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void GetGotoTargetOfStepOfSequence(string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.UpdateSequenceStepGoto(awg, seqName, stepNumber);
        }

        /// <summary>
        /// Compares the update property SequenceStepGoto for a step goto target should be integer/value
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="stepTarget"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [Then(@"the goto target of step (\d+) of sequence ""(.+)"" should be (\d+) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the goto target of step (\d+) of sequence ""(.+)"" should be (\d+) for AWG ([1-4])")]
        public void GotoTargetOfStepOfSequenceShouldBeStepNumber(string stepNumber, string seqName, string stepTarget, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceStepGotoShouldBe(awg, seqName, stepNumber, AwgSequenceGroup.StepGotoMode.Nr1, stepTarget);
        }

        /// <summary>
        /// Compares the update property SequenceStepGoto for a step goto target should be First
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [Then(@"the goto target of step (\d+) of sequence ""(.+)"" should be first for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the goto target of step (\d+) of sequence ""(.+)"" should be first for AWG ([1-4])")]
        public void GotoTargetOfStepOfSequenceShouldBeFirst(string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceStepGotoShouldBe(awg, seqName, stepNumber, AwgSequenceGroup.StepGotoMode.First);
        }

        /// <summary>
        /// Compares the update property SequenceStepGoto for a step goto target should be Last
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [Then(@"the goto target of step (\d+) of sequence ""(.+)"" should be last for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the goto target of step (\d+) of sequence ""(.+)"" should be last for AWG ([1-4])")]
        public void GotoTargetOfStepOfSequenceShouldBeLast(string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceStepGotoShouldBe(awg, seqName, stepNumber, AwgSequenceGroup.StepGotoMode.Last);
        }

        /// <summary>
        /// Compares the update property SequenceStepGoto for a step goto target should be Next
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [Then(@"the goto target of step (\d+) of sequence ""(.+)"" should be next for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the goto target of step (\d+) of sequence ""(.+)"" should be next for AWG ([1-4])")]
        public void GotoTargetOfStepOfSequenceShouldBeNext(string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceStepGotoShouldBe(awg, seqName, stepNumber, AwgSequenceGroup.StepGotoMode.Next);
        }

        /// <summary>
        /// Compares the update property SequenceStepGoto for a step goto target should be End
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [Then(@"the goto target of step (\d+) of sequence ""(.+)"" should be end for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the goto target of step (\d+) of sequence ""(.+)"" should be end for AWG ([1-4])")]
        public void GotoTargetOfStepOfSequenceShouldBeEnd(string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceStepGotoShouldBe(awg, seqName, stepNumber, AwgSequenceGroup.StepGotoMode.End);
        }

        #endregion SLISt:SEQuence:STEP:GOTO

        #region SLISt:SEQuence:STEP:MAX

        //glennj 8/21/2013
        /// <summary>
        /// Updates the property of AWG for max number of available steps
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I get the max number of steps for a sequence for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the max number of steps for a sequence for AWG ([1-4])")]
        public void GetMaxNumberOfStepsForASequence(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.UpdateSequenceStepMax(awg);
        }

        //glennj 8/31/2013
        /// <summary>
        /// Compare for a the expected number of max steps to update property
        /// </summary>
        /// <param name="expectedMaxSteps"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [Then(@"the max number of steps for a sequence should be (\d+) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the max number of steps for a sequence should be (\d+) for AWG ([1-4])")]
        public void MaxNumberOfStepsForASequenceShouldBe(string expectedMaxSteps, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceStepMaxShouldBe(awg, expectedMaxSteps);
        }

        #endregion SLISt:SEQuence:STEP:MAX

        #region SLISt:SEQuence:STEP:RCOunt

        /// <summary>
        /// The repeat count is a specific step number
        /// </summary>
        /// <param name="repeatCount"></param>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I set the repeat count to (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the repeat count to (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SetRepeatCountToStepOfStepOfSequenceToNr1(string repeatCount, string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceStepRepeatCount(awg, seqName, stepNumber, AwgSequenceGroup.StepRepeatCountMode.Nr1, repeatCount);
        }

        /// <summary>
        /// The repeat count is set to Once.
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I set the repeat count to once of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the repeat count to once of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SetRepeatCountToStepOfStepOfSequenceToOnce(string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceStepRepeatCount(awg, seqName, stepNumber, AwgSequenceGroup.StepRepeatCountMode.Once);
        }

        /// <summary>
        /// The repeat count is set to Infinite.
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I set the repeat count to infinite of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the repeat count to infinite of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SetRepeatCountToStepOfStepOfSequenceToInfinite(string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceStepRepeatCount(awg, seqName, stepNumber, AwgSequenceGroup.StepRepeatCountMode.Infinite);
        }

        /// <summary>
        /// Gets the repeat count for a specific step of a specific sequence
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I get the repeat count of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the repeat count of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void GetRepeatCountOfStepOfSequence(string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.UpdateSequenceStepRepeatCount(awg, seqName, stepNumber);
        }

        /// <summary>
        /// Compares the update property SequenceStepRepeatCount for a step repeat count and should be integer
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="expectedRepeatCount"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [Then(@"the repeat count of step (\d+) of sequence ""(.+)"" should be (\d+) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the repeat count of step (\d+) of sequence ""(.+)"" should be (\d+) for AWG ([1-4])")]
        public void RepeatCountOfStepOfSequenceShouldBeNr1(string stepNumber, string seqName, string expectedRepeatCount, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceStepRepeatCountShouldBe(awg, seqName, stepNumber, AwgSequenceGroup.StepRepeatCountMode.Nr1, expectedRepeatCount);
        }

        /// <summary>
        /// Compares the update property SequenceStepRepeatCount for a step repeat count and should be Once
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [Then(@"the repeat count of step (\d+) of sequence ""(.+)"" should be once for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the repeat count of step (\d+) of sequence ""(.+)"" should be once for AWG ([1-4])")]
        public void RepeatCountOfStepOfSequenceShouldBeOnce(string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceStepRepeatCountShouldBe(awg, seqName, stepNumber, AwgSequenceGroup.StepRepeatCountMode.Once);
        }

        /// <summary>
        /// Compares the update property SequenceStepRepeatCount for a step repeat count and should be Once
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [Then(@"the repeat count of step (\d+) of sequence ""(.+)"" should be infinite for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the repeat count of step (\d+) of sequence ""(.+)"" should be infinite for AWG ([1-4])")]
        public void RepeatCountOfStepOfSequenceShouldBeInfinite(string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceStepRepeatCountShouldBe(awg, seqName, stepNumber, AwgSequenceGroup.StepRepeatCountMode.Infinite);
        }

        #endregion SLISt:SEQuence:STEP:RCOunt

        #region SLISt:SEQuence:STEP:RCOunt:MAX

        //glennj 8/21/2013
        /// <summary>
        /// Updates the property of AWG for max number of repeat counts
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I get the max number of repeat counts for a sequence for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the max number of repeat counts for a sequence for AWG ([1-4])")]
        public void GetMaxNumberOfRepeatCountsForASequence(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.UpdateSequenceStepRepeatCountMax(awg);
        }

        //glennj 8/31/2013
        /// <summary>
        /// Compare for a the expected number of max repeat counts to update property
        /// </summary>
        /// <param name="expectedMaxRepeatCounts"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [Then(@"the max number of repeat counts for a sequence should be (\d+) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the max number of repeat counts for a sequence should be (\d+) for AWG ([1-4])")]
        public void MaxNumberOfRepeatCountsForASequenceShouldBe(string expectedMaxRepeatCounts, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceStepRepeatCountMaxShouldBe(awg, expectedMaxRepeatCounts);
        }

        #endregion SLISt:SEQuence:STEP:RCOunt:MAX

        #region SLISt:SEQuence:STEP:TASSet

        //glennj 8/14/2013
        //jmannning 04/17/2014  Added preferred method of track asset that covers both sequence and waveform track asset cases 
        /// <summary>
        /// Get(update property) the waveform for a specified track of a specified step of specified sequence on a specified awg
        /// </summary>
        /// <param name="trackNumber"></param>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I get the waveform for track (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the waveform for track (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void GetTheWaveformForStepWaveformOfSequence(string trackNumber, string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.UpdateSequenceStepTrackAsset(awg, seqName, stepNumber, trackNumber);
        }
        [When(@"I get the asset name for track (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void GetTheTrackAssetNameForStepOfSequence(string trackNumber, string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.UpdateSequenceStepTrackAsset(awg, seqName, stepNumber, trackNumber);
        }
        //glennj 8/14/2013
        //jmannning 04/17/2014  Added preferred method of track asset that covers both sequence and waveform track asset cases 
        /// <summary>
        /// Compare an expected waveform name to the update property.<para>
        /// Note: track, step and sequence name are required but not functional.</para><para>
        /// There is only one property and must be updated before each (should be) compare</para>
        /// </summary>
        /// <param name="trackNumber"></param>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="expectedWfmName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [Then(@"the waveform for track (\d+) of step (\d+) of sequence ""(.+)"" should be ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the waveform for track (\d+) of step (\d+) of sequence ""(.+)"" should be ""(.+)"" for AWG ([1-4])")]
        public void TheWaveformForStepWaveformOfSequenceShouldBe(string trackNumber, string stepNumber, string seqName, string expectedWfmName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceStepTrackAssetShouldBe(awg, seqName, stepNumber, trackNumber, expectedWfmName);
        }

        [Then(@"the asset name for track (\d+) of step (\d+) of sequence ""(.+)"" should be ""(.+)"" for AWG ([1-4])")]
        public void TheTrackAssetNameForStepOfSequenceShouldBe(string trackNumber, string stepNumber, string seqName, string expectedAssetName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceStepTrackAssetShouldBe(awg, seqName, stepNumber, trackNumber, expectedAssetName);
        }
        #endregion SLISt:SEQuence:STEP:TASSet

        #region SLISt:SEQuence:STEP:TASSet:SEQuence
        /// <summary>
        /// Using SLISt:SEQuence:STEP:TASSet:SEQuence set a sequence to a step(as a subsequence) and of a sequence
        /// Note:  Applies to all tracks in the sequence
        /// </summary>
        /// <param name="subSeqName"></param> 
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>      
        /*
            \sequence\verbatim
        [When(@"I set the subsequence to ""(.+)"" for step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the subsequence to ""(.+)"" for step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SetSequenceStepTrackAssetForSequence(string subSeqName, string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceStepTrackAssetForSequence(awg, seqName, stepNumber, subSeqName);
        }
        #endregion SLISt:SEQuence:STEP:TASSet:SEQuence

        #region SLISt:SEQuence:STEP:TASSet:TYPE
        /// <summary>
        /// Using SLISt:SEQuence:STEP[n]:TASSet[m]:TYPE? get the type of asset assigned to the specified step and track
        /// </summary>
        /// <param name="trackNumber"></param>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /// <returns>gets asset type value (WAVeform|SEQuence)</returns>
        /*
            \sequence\verbatim
        [When(@"I get the track asset type for track (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the track asset type for track (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void GetSequenceStepTrackAssetType(string trackNumber, string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.GetSequenceStepTrackAssetType(awg, seqName, stepNumber, trackNumber);
        }

        /// <summary>
        /// Using SLISt:SEQuence:STEP[n]:TASSet[m]:TYPE? compares actual versus expected type of sequence for asset assigned to the specified step and track
        /// </summary>
        /// <param name="trackNumber"></param>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /// <returns>compares asset type (WAVeform|SEQuence)</returns>
        /*
            \sequence\verbatim
        [Then(@"the track asset type should be sequence for track (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the track asset type should be sequence for track (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SequenceStepTrackAssetTypeShouldBeSequence(string trackNumber, string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceStepTrackAssetTypeShouldBe(awg, seqName, stepNumber, trackNumber, AwgSequenceGroup.SequenceTrackAssetType.Sequence);
        }
        
        /// <summary>
        /// Using SLISt:SEQuence:STEP[n]:TASSet[m]:TYPE? compares actual versus expected type of waveform for asset assigned to the specified step and track
        /// </summary>
        /// <param name="trackNumber"></param>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /// <returns>compares asset type (WAVeform|SEQuence)</returns>
        /*
            \sequence\verbatim
        [Then(@"the track asset type should be waveform for track (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the track asset type should be waveform for track (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SequenceStepTrackAssetTypeShouldBeWaveform(string trackNumber, string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceStepTrackAssetTypeShouldBe(awg, seqName, stepNumber, trackNumber, AwgSequenceGroup.SequenceTrackAssetType.Waveform);
        }
        #endregion SLISt:SEQuence:STEP:TASSet:TYPE

        #region SLISt:SEQuence:STEP:TASSet:WAVeform

        //glennj 8/14/2013
        /// <summary>
        /// Select(set) the waveform for a specified track of a specified step of specified sequence on a specified awg
        /// </summary>
        /// <param name="wfmName"></param>
        /// <param name="trackNumber"></param>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I set the waveform to ""(.+)"" for track (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the waveform to ""(.+)"" for track (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SetTheWaveformForTrackStepSequence(string wfmName, string trackNumber, string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceStepTrackAssetForWaveform(awg, seqName, stepNumber, trackNumber, wfmName);
        }

        #endregion SLISt:SEQuence:STEP:TASSet:WAVeform

        #region SLISt:SEQuence:STEP[n]:TFLag[m]:[ALPHA]FLAG
        /// <summary>
        /// Using SLISt:SEQuence:STEP:TFLag[m]:[ALPHA]FLAG set a flag value of the track in a specific sequence step for the specified flag
        /// flag settings are (NOCHANGE|HIGH|LOW|TOGGLE|PULSE)
        /// </summary>
        /// <param name="flagAlpha">four flags can be set (A|B|C|D)FLAG</param>
        /// <param name="trackNumber"></param>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*
            \sequence\verbatim
        [When(@"I set (A|B|C|D)Flag setting to no change for track (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set (A|B|C|D)Flag setting to no change for track (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SetSequenceStepTrackFlagValueToNoChange(string flagAlpha, string trackNumber, string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceStepTrackFlagValue(awg, seqName, stepNumber, trackNumber, flagAlpha, AwgSequenceGroup.SequenceFlagSetting.NoChange);
        }

        /*
            \sequence\verbatim
        [When(@"I set (A|B|C|D)Flag setting to high for track (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set (A|B|C|D)Flag setting to high for track (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SetSequenceStepTrackFlagValueToHigh(string flagAlpha, string trackNumber, string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceStepTrackFlagValue(awg, seqName, stepNumber, trackNumber, flagAlpha, AwgSequenceGroup.SequenceFlagSetting.High);
        }

        /*
            \sequence\verbatim
        [When(@"I set (A|B|C|D)Flag setting to low for track (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set (A|B|C|D)Flag setting to low for track (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SetSequenceStepTrackFlagValueToLow(string flagAlpha, string trackNumber, string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceStepTrackFlagValue(awg, seqName, stepNumber, trackNumber, flagAlpha, AwgSequenceGroup.SequenceFlagSetting.Low);
        }

        /*
            \sequence\verbatim
        [When(@"I set (A|B|C|D)Flag setting to toggle for track (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set (A|B|C|D)Flag setting to toggle for track (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SetSequenceStepTrackFlagValueToToggle(string flagAlpha, string trackNumber, string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceStepTrackFlagValue(awg, seqName, stepNumber, trackNumber, flagAlpha, AwgSequenceGroup.SequenceFlagSetting.Toggle);
        }

        /*
            \sequence\verbatim
        [When(@"I set (A|B|C|D)Flag setting to pulse for track (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set (A|B|C|D)Flag setting to pulse for track (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SetSequenceStepTrackFlagValueToPulse(string flagAlpha, string trackNumber, string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceStepTrackFlagValue(awg, seqName, stepNumber, trackNumber, flagAlpha, AwgSequenceGroup.SequenceFlagSetting.Pulse);
        }


        /// <summary>
        /// Using SLISt:SEQuence:STEP:TFLag[m]:[ALPHA]FLAG? gets value of flag for the track in a specific sequence step for the specified flag
        /// </summary>
        /// <param name="flagAlpha">four flags can be set (A|B|C|D)FLAG</param>
        /// <param name="trackNumber"></param>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /// <returns>returns flag value (NOCHANGE|HIGH|LOW|TOGGLE|PULSE)</returns>
        /*
            \sequence\verbatim
        [When(@"I get (A|B|C|D)Flag setting value for track (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get (A|B|C|D)Flag setting value for track (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void GetSequenceStepTrackFlagValue(string flagAlpha, string trackNumber, string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.GetSequenceStepTrackFlagValue(awg, seqName, stepNumber, trackNumber, flagAlpha);
        }

        /// <summary>
        /// Using SLISt:SEQuence:STEP:TFLag[m]:[ALPHA]FLAG? compares flag setting value to expected flag setting of for the track in a specific sequence step for the specified flag 
        /// </summary>
        /// <param name="flagAlpha">four flags can be set (A|B|C|D)FLAG</param>
        /// <param name="trackNumber"></param>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /// <returns>returns flag value (NOCHANGE|HIGH|LOW|TOGGLE|PULSE)</returns>
        /*
            \sequence\verbatim
        [Then(@"the (A|B|C|D)Flag setting value should be no change for track (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the (A|B|C|D)Flag setting value should be no change for track (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SequenceStepTrackFlagValueShouldBeNoChange(string flagAlpha, string trackNumber, string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceStepTrackFlagValueShouldBe(awg, seqName, stepNumber, trackNumber, flagAlpha, AwgSequenceGroup.SequenceFlagSetting.NoChange);
        }

        /*
            \sequence\verbatim
        [Then(@"the (A|B|C|D)Flag setting value should be high change for track (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the (A|B|C|D)Flag setting value should be high for track (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SequenceStepTrackFlagValueShouldBeHigh(string flagAlpha, string trackNumber, string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceStepTrackFlagValueShouldBe(awg, seqName, stepNumber, trackNumber, flagAlpha, AwgSequenceGroup.SequenceFlagSetting.High);
        }

        /*
            \sequence\verbatim
        [Then(@"the (A|B|C|D)Flag setting value should be low for track (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim     
        */
        [Then(@"the (A|B|C|D)Flag setting value should be low for track (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SequenceStepTrackFlagValueShouldBeLow(string flagAlpha, string trackNumber, string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceStepTrackFlagValueShouldBe(awg, seqName, stepNumber, trackNumber, flagAlpha, AwgSequenceGroup.SequenceFlagSetting.Low);
        }

        /*
            \sequence\verbatim
        [Then(@"the (A|B|C|D)Flag setting value should be toggle for track (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the (A|B|C|D)Flag setting value should be toggle for track (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SequenceStepTrackFlagValueShouldBeToggle(string flagAlpha, string trackNumber, string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceStepTrackFlagValueShouldBe(awg, seqName, stepNumber, trackNumber, flagAlpha, AwgSequenceGroup.SequenceFlagSetting.Toggle);
        }

        /*
            \sequence\verbatim
        [Then(@"the (A|B|C|D)Flag setting value should be pulse for track (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the (A|B|C|D)Flag setting value should be pulse for track (\d+) of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SequenceStepTrackFlagValueShouldBePulse(string flagAlpha, string trackNumber, string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceStepTrackFlagValueShouldBe(awg, seqName, stepNumber, trackNumber, flagAlpha, AwgSequenceGroup.SequenceFlagSetting.Pulse);
        }
        #endregion SLISt:SEQuence:STEP[n]:TFLag[m]:[ALPHA]FLAG

        #region SLISt:SEQuence:STEP:WAVeform

        // Obsolete.  Changed to SLISt:SEQuence:STEP:TASSet:WAVeform and SLISt:SEQuence:STEP:TASSet?

        #endregion SLISt:SEQuence:STEP:WAVeform

        #region SLISt:SEQuence:STEP:WINPut

        /// <summary>
        /// Set the Wait for Input to a specific step number of a specific sequence to off
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I set the wait input to off of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the wait input to off of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SetWaitInputToStepOfStepOfSequenceToOff(string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceStepWaitInput(awg, seqName, stepNumber, AwgSequenceGroup.StepWaitInputMode.Off);
        }

        /// <summary>
        /// Set the Wait for Input to a specific step number of a specific sequence to trigger A
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I set the wait input to use trigger A of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the wait input to use trigger A of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SetWaitInputToStepOfStepOfSequenceTriggerA(string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceStepWaitInput(awg, seqName, stepNumber, AwgSequenceGroup.StepWaitInputMode.TriggerA);
        }

        /// <summary>
        /// Set the Wait for Input to a specific step number of a specific sequence to trigger B
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I set the wait input to use trigger B of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the wait input to use trigger B of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SetWaitInputToStepOfStepOfSequenceTriggerB(string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceStepWaitInput(awg, seqName, stepNumber, AwgSequenceGroup.StepWaitInputMode.TriggerB);
        }

        /// <summary>
        /// Set the Wait for Input to a specific step number of a specific sequence to internal trigger
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I set the wait input to use internal trigger of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set the wait input to use internal trigger of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void SetWaitInputToStepOfStepOfSequenceInternalTrigger(string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SetSequenceStepWaitInput(awg, seqName, stepNumber, AwgSequenceGroup.StepWaitInputMode.InternalTrigger);
        }
        
        /// <summary>
        /// Gets the Wait for Input mode for a specific step of a specific sequence
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I get the wait input state of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the wait input state of step (\d+) of sequence ""(.+)"" for AWG ([1-4])")]
        public void GetWaitInputOfStepOfSequence(string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.UpdateSequenceStepWaitInput(awg, seqName, stepNumber);
        }

        /// <summary>
        /// Compares the update property SequenceStepWaitInput for wait state input for a specific step and should be Off
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [Then(@"the wait input of step (\d+) of sequence ""(.+)"" should be off for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the wait input of step (\d+) of sequence ""(.+)"" should be off for AWG ([1-4])")]
        public void WaitInputOfStepOfSequenceShouldBeOff(string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceStepWaitInputShouldBe(awg, seqName, stepNumber, AwgSequenceGroup.StepWaitInputMode.Off);
        }

        /// <summary>
        /// Compares the update property SequenceStepWaitInput for wait state input for a specific step and should be Trigger A
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [Then(@"the wait input of step (\d+) of sequence ""(.+)"" should be to use trigger A for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the wait input of step (\d+) of sequence ""(.+)"" should be to use trigger A for AWG ([1-4])")]
        public void WaitInputOfStepOfSequenceShouldBeTriggerA(string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceStepWaitInputShouldBe(awg, seqName, stepNumber, AwgSequenceGroup.StepWaitInputMode.TriggerA);
        }

        /// <summary>
        /// Compares the update property SequenceStepWaitInput for wait state input for a specific step and should be Trigger B
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [Then(@"the wait input of step (\d+) of sequence ""(.+)"" should be to use trigger B for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the wait input of step (\d+) of sequence ""(.+)"" should be to use trigger B for AWG ([1-4])")]
        public void WaitInputOfStepOfSequenceShouldBeTriggerB(string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceStepWaitInputShouldBe(awg, seqName, stepNumber, AwgSequenceGroup.StepWaitInputMode.TriggerB);
        }

        /// <summary>
        /// Compares the update property SequenceStepWaitInput for wait state input for a specific step and should be Internal Trigger 
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [Then(@"the wait input of step (\d+) of sequence ""(.+)"" should be to use internal trigger for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the wait input of step (\d+) of sequence ""(.+)"" should be to use internal trigger for AWG ([1-4])")]
        public void WaitInputOfStepOfSequenceShouldBeInternalTrigger(string stepNumber, string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceStepWaitInputShouldBe(awg, seqName, stepNumber, AwgSequenceGroup.StepWaitInputMode.InternalTrigger);
        }
        #endregion SLISt:SEQuence:STEP:WINPut

        #region SLISt:SEQuence:TRACk?

        //glennj 8/15/2013
        /// <summary>
        /// Update the property for SLISt:SEQuence:TRACk? to get the number of tracks of the named sequence.
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I get the number of tracks of sequence ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the number of tracks of sequence ""(.+)"" for AWG ([1-4])")]
        public void GetTheNumberOfTracksOfSequence(string seqName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.GetSequenceTracks(awg, seqName);
        }

        //glennj 8/15/2013
        /// <summary>
        /// Tests the updated property for an expected number of tracks<para>
        /// Currently the seqName is not being used.  The user must do a get</para><para>
        /// to update the single property.  Maybe in the future multiple sequences</para><para>
        /// will be tested in parallel but right now it is one at a time.</para>
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="expectedNumber"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [Then(@"the the number of tracks of sequence ""(.+)"" should be (\d+) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the the number of tracks of sequence ""(.+)"" should be (\d+) for AWG ([1-4])")]
        public void TheNumberOfSequenceTracksShouldBe(string seqName, string expectedNumber, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.NumberOfSequenceTracksShouldBe(awg, seqName, expectedNumber);
        }

        [Then(@"the the number of tracks of sequence ""(.+)"" should be (\d+) or (\d+) for AWG ([1-4])")]
        public void TheNumberOfSequenceTracksShouldBe(string seqName, string expectedNum1, string expectedNum2, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.NumberOfSequenceTracksShouldBeEitherOr(awg, seqName, expectedNum1, expectedNum2);
        }
        #endregion SLISt:SEQuence:TRACk?

        #region SLISt:SEQuence:TRACk:MAX

        //glennj 8/21/2013
        /// <summary>
        /// Updates the property of AWG for max number of available tracks
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [When(@"I get the max number of tracks for a sequence for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the max number of tracks for a sequence for AWG ([1-4])")]
        public void GetMaxNumberOfTracksForASequence(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.UpdateSequenceTrackMax(awg);
        }

        //glennj 8/31/2013
        /// <summary>
        /// Compare for a the expected number of max tracks to update property
        /// </summary>
        /// <param name="expectedMaxTracks"></param>
        /// <param name="awgNumber"></param>
        /*!
            \sequence\verbatim
        [Then(@"the max number of tracks for a sequence should be (\d+) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the max number of tracks for a sequence should be (\d+) for AWG ([1-4])")]
        public void MaxNumberOfTracksForASequenceShouldBe(string expectedMaxTracks, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceTrackMaxShouldBe(awg, expectedMaxTracks);
        }

        #endregion SLISt:SEQuence:TRACk:MAX

        #region SLISt:SEQuence:TSTamp

        //glennj 7/31/2013
        /// <summary>
        /// Gets the timestamp of the given sequence
        /// 
        /// SLISt:sequence:TSTamp? (Query only)
        /// </summary>
        /// <param name="wfmName">Name of the sequence</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \sequence\verbatim
        [When(@"I get the timestamp of the sequence ""(.+)"" from the sequence list for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the timestamp of the sequence ""(.+)"" from the sequence list for AWG ([1-4])")]
        public void GetTheTimestampofSequenceFromSequenceList(string wfmName, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.UpdateSequenceTimestamp(awg, wfmName);
        }

        //glennj 8/13/2013
        /// <summary>
        /// Using the results of a query of SLIST:SEQuence:TSTamp?<para>
        /// compare the timestamp of the sequence against the expected format.</para><para>
        /// Expected timestamp pattern YYYY/MM/DD HH:MM:SS@n</para>
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
           \sequence\verbatim
        [Then(@"the timestamp of the sequence should be in an expected format for AWG ([1-4])")]
           \endverbatim 
       */
        [Then(@"the timestamp of the sequence should be in an expected format for AWG ([1-4])")]
        public void ThenTimestampofSequenceOnTheAwgShouldMatchExpectedPattern(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.TimestampOfSeqFromSequenceListShouldMatchPattern(awg);
        }

        #endregion SLISt:SEQuence:TSTamp

        #region SLISt:SIZE


        //glennj 8/12/2013
        /// <summary>
        /// Gets the size of the sequence list.
        /// 
        /// SLISt:SIZE? (query only)
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \sequence\verbatim
        [When(@"I get the number of sequences in the sequence list for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the number of sequences in the sequence list for AWG ([1-4])")]
        public void GetTheNumberOfEntriesInTheSequenceList(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.GetSlistSize(awg);
        }

        //glennj 8/12/2013
        /// <summary>
        /// Compares the size of the sequence list against the expected value.
        /// 
        /// SLISt:SIZE? (query only)
        /// </summary>
        /// <param name="expectedValue">Expected number of entries</param>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \sequence\verbatim
        [Then(@"the number of sequences should be ((?<!\S)[-+]?\d+(?!\S)) for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the number of sequences should be ((?<!\S)[-+]?\d+(?!\S)) for AWG ([1-4])")]
        public void ThereShouldBeEntriesInThesequenceList(string expectedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSequenceGroup.SequenceListSizeShouldBe(awg, expectedValue);
        }

        #endregion SLISt:SIZE
        #endregion SLIST
    }
}