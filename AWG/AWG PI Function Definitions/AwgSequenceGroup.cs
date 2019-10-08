//==========================================================================
// AwgSequenceGroup.cs
//==========================================================================

using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains helper functions that are called from the %AWG Sequence PI step definitions
    /// 
    /// This "Helper" group does everything else but steps and TekVISA.
    /// Using parameters from the step, each helper will makes decisions
    /// such as send commands, or process responses from queries and
    /// do testing and generate asserts if necessary.
    /// 
    /// \ingroup grouphelperpi pisteps 
    /// </summary>

    public class AwgSequenceGroup
    {
        private readonly UTILS _utils = new UTILS();
       
        public enum StepGotoMode { Nr1, Last, First, Next, End}

        private const string SyntaxForStepGotoEnd = "END";
        private const string SyntaxForStepGotoFirst = "FIRS";
        private const string SyntaxForStepGotoLast = "LAST";
        private const string SyntaxForStepGotoNext = "NEXT";

        public enum StepEventJumpMode { Nr1, Last, First, Next, End }

        private const string SyntaxForStepEventJumpEnd = "END";
        private const string SyntaxForStepEventJumpFirst = "FIRS";
        private const string SyntaxForStepEventJumpLast = "LAST";
        private const string SyntaxForStepEventJumpNext = "NEXT";

        public enum StepEventJumpInputMode { Off, TriggerA, TriggerB, InternalTrigger }

        private const string SyntaxForStepEventJumpInputOff = "OFF";
        private const string SyntaxForStepEventJumpInputTriggerA = "ATR";
        private const string SyntaxForStepEventJumpInputTriggerB = "BTR";
        private const string SyntaxForStepEventJumpInputInternalTrigger = "ITR";

        public enum StepRepeatCountMode { Nr1, Once, Infinite }

        private const string SyntaxForStepRepeatCountOnce = "ONCE";
        private const string SyntaxForStepRepeatCountInfinite = "INF";

        public enum StepWaitInputMode { Off, TriggerA, TriggerB, InternalTrigger}

        private const string SyntaxForStepWaitInputOff = "OFF";
        private const string SyntaxForStepWaitInputTriggerA = "ATR";
        private const string SyntaxForStepWaitInputTriggerB = "BTR";
        private const string SyntaxForStepWaitInputInternalTrigger = "ITR";

        public enum SequenceEventJumpTiming { End, Immediate }

        public enum SequenceFlagRepeatState {Off, On}
        public const string SyntaxForSequenceFlagRepeatStateOn = "1";
        public const string SyntaxForSequenceFlagRepeatStateOff = "0";

        public enum SequenceFlagSetting { NoChange, High, Low, Toggle, Pulse}
        public const string SyntaxForSequenceFlagSettingNoChange = "NCH";
        public const string SyntaxForSequenceFlagSettingHigh = "HIGH";
        public const string SyntaxForSequenceFlagSettingLow = "LOW";
        public const string SyntaxForSequenceFlagSettingToggle = "TOGG";
        public const string SyntaxForSequenceFlagSettingPulse = "PULS";

        public const string SyntaxForSequenceEventJumpTimingEnd = "END";
        public const string SyntaxForSequenceEventJumpTimingImmediate = "IMM";

        public enum SequenceJumpPatternEvent { On, Off}

        public const string SyntaxForCommandSequenceJumpPatternEventOn = "ON";
        public const string SyntaxForCommandSequenceJumpPatternEventOff = "OFF";

        public const string SyntaxForQuerySequenceJumpPatternEventOn = "1";
        public const string SyntaxForQuerySequenceJumpPatternEventOff = "0";

        public enum SequenceTrackAssetType { Waveform, Sequence}

        public const string SyntaxForSequenceTrackAssetTypeWaveform = "WAV";
        public const string SyntaxForSequenceTrackAssetTypeSequence = "SEQ";

        #region SLIST

        #region SLISt:NAME

        //glennj 8/12/2013
        /// <summary>
        /// Using SLISt:NAME? get the name of the sequence of an element in the sequence list
        /// </summary>
        /// <param name="awg">Specific Awg object</param>
        /// <param name="listIndex"></param>
        public void UpdateSequenceListName(IAWG awg, string listIndex)
        {
            awg.GetSlistName(listIndex);
        }

        //glennj 8/12/2013
        /// <summary>
        /// Test against the updated property SequenceNameOfElement for SLISt:NAME?
        /// </summary>
        /// <param name="awg">Specific Awg object</param>
        /// <param name="expectedSeqName"></param>
        public void SequenceListNameShouldBe(IAWG awg, string expectedSeqName)
        {
            Assert.AreEqual(expectedSeqName, awg.SequenceNameOfElement);
        }

        #endregion SLISt:NAME

        #region SLISt:SEQuence:DELete

        //glennj 8/12/2013
      /// <summary>
      /// Uses SLIST:SEQuence:DELete to delete the sequence from the sequence list
      /// </summary>
      /// <param name="awg">Specific Awg object</param>
      /// <param name="seqName">Name of the sequence to delete</param>
      /// <param name="addQuotes">Keywords such as ALL don't need quotes</param>
      public void DeleteSequenceListSequence(IAWG awg, string seqName, bool addQuotes = true)
        {
            awg.DeleteSequenceListSequence(seqName, addQuotes);
        }

        #endregion SLISt:SEQuence:DELete

        #region SLISt:SEQuence:EVENt:JTIMing

        //glennj 8/12/2013
        /// <summary>
        /// Using SLISt:SEQuence:EVENt:JTIMing sets how the sequencer<para>
        /// will respond to a logic event, pattern jump or a software</para><para>
        /// force jump.</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="seqName"></param>
        /// <param name="eventJTimingMode">of END or IMMediate</param>
        public void SetSequenceEventPatternJumpTiming(IAWG awg, string seqName, SequenceEventJumpTiming eventJTimingMode)
        {
            var mode = (eventJTimingMode == SequenceEventJumpTiming.End) ? SyntaxForSequenceEventJumpTimingEnd : SyntaxForSequenceEventJumpTimingImmediate;
            awg.SetSequenceEventPatternJumpTiming(seqName, mode);
        }

        //glennj 8/12/2013
        /// <summary>
        /// Using SLISt:SEQuence:EVENt:JTIMing? update property for the mode for how the<para>
        /// sequencer will respond to a logic event, pattern jump or a software</para><para>
        /// force jump.</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="seqName"></param>
        public void UpdateSequenceEventPatternJumpTiming(IAWG awg, string seqName)
        {
            awg.GetSequenceEventPatternJumpTiming(seqName);
        }

        //glennj 8/12/2013
        /// <summary>
        /// Test for the expected sequence event pattern jump timing against the updated property
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="seqName"></param>
        /// <param name="expectedEventJTimingMode"></param>
        public void SequenceEventPatternJumpTimingShouldBe(IAWG awg, string seqName, SequenceEventJumpTiming expectedEventJTimingMode)
        {
            var expectedMode = (expectedEventJTimingMode == SequenceEventJumpTiming.End) ? SyntaxForSequenceEventJumpTimingEnd : SyntaxForSequenceEventJumpTimingImmediate;
            const string possibleErrorString = "Check for syntax or incorrect mode";
            Assert.AreEqual(expectedMode, awg.SequenceEventPatternJumpTiming, possibleErrorString);
        }

        #endregion SLISt:SEQuence:EVENt:JTIMing

        #region SLISt:SEQuence:EVENt:PJUMp:ENABle

        //glennj 8/12/2013
        /// <summary>
        /// Using SLISt:SEQuence:EVENt:PJUMp:ENABle set the event pattern jump enable
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="seqName"></param>
        /// <param name="setValue"></param>
        public void SetSequenceEventPatternJumpEnable(IAWG awg, string seqName, SequenceJumpPatternEvent setValue)
        {
            var enableState = (setValue == SequenceJumpPatternEvent.On)
                                  ? SyntaxForCommandSequenceJumpPatternEventOn
                                  : SyntaxForCommandSequenceJumpPatternEventOff;
            awg.SetSequenceEventPatternJumpEnable(seqName, enableState);
        }

        //glennj 8/12/2013
        /// <summary>
        /// Using SLISt:SEQuence:EVENt:PJUMp:ENABle? update the awg event pattern jump enable property
        /// </summary>
        /// <param name="awg">Specific Awg object</param>
        /// <param name="seqName">Name of sequence</param>
        public void UpdateSequenceEventPatternJumpEnableProperty(IAWG awg, string seqName)
        {
            awg.GetSequenceEventPatternJumpEnable(seqName);
        }

        //glennj 8/12/2013
        /// <summary>
        /// Test for the expected enable state against the updated property
        /// </summary>
        /// <param name="awg">Specific Awg object</param>
        /// <param name="seqName"></param>
        /// <param name="expectedEnableState"></param>
        public void SequenceEventPatternJumpEnableShouldBe(IAWG awg, string seqName, SequenceJumpPatternEvent expectedEnableState)
        {
            var expectedState = (expectedEnableState == SequenceJumpPatternEvent.On)
                                  ? SyntaxForQuerySequenceJumpPatternEventOn
                                  : SyntaxForQuerySequenceJumpPatternEventOff;
            const string possibleErrorString = "Check for syntax or incorrect state";
            Assert.AreEqual(expectedState, awg.SequenceEventPatternJumpEnable, possibleErrorString);
        }

        #endregion SLISt:SEQuence:EVENt:PJUMp:ENABle

        #region SLISt:SEQuence:EVENt:PJUMp:DEFine

        //glennj 8/12/2013
        /// <summary>
        /// Using SLISt:SEQuence:EVENt:PJUMp:DEFine associate an event pattern<para>
        /// with the jumpe to step for Pattern Jump</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="seqName"></param>
        /// <param name="pattern"></param>
        /// <param name="jumpStep"></param>
        public void SetSequenceEventPatternJumpDefine(IAWG awg, string seqName, string pattern, string jumpStep)
        {
            awg.SetSequenceEventPatternJumpDefine(seqName, pattern, jumpStep);
        }

        //glennj 8/12/2013
        /// <summary>
        /// Using SLISt:SEQuence:EVENt:PJUMp:DEFine? update the pattern jump define<para>
        /// step property associated to the specified pattern</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="seqName"></param>
        /// <param name="pattern"></param>
        public void UpdateSequenceEventPatternJumpDefine(IAWG awg, string seqName, string pattern)
        {
            awg.GetSequenceEventPatternJumpDefine(seqName, pattern);
        }

        //glennj 8/12/2013
        /// <summary>
        /// Test for the expected pattern jump define against the updated property
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="seqName">Holder, not currently used</param>
        /// <param name="expectedPattern"></param>
        public void SequenceEventPatternJumpDefineShouldBe(IAWG awg, string seqName, string expectedPattern)
        {
            Assert.AreEqual(expectedPattern, awg.SequenceEventPatternJumpDefine);
        }

        #endregion SLISt:SEQuence:EVENt:PJUMp:DEFine

        #region SLISt:SEQuence:EVENt:PJUMp:SIZE

        //glennj 8/12/2013
        /// <summary>
        /// Using SLISt:SEQuence:EVENt:PJUMp:SIZE? update the maximum number of entries property
        /// </summary>
        public void UpdateSequenceEventPatternJumpSize(IAWG awg)
        {
            awg.GetSequenceEventPatternJumpSize();
        }

        //glennj 8/12/2013
        /// <summary>
        /// Test for the expected maximum pattern jump size against the updated property
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedMaxNumber"></param>
        public void SequenceEventPatternJumpSizeShouldBe(IAWG awg, string expectedMaxNumber)
        {
            Assert.AreEqual(float.Parse(expectedMaxNumber), float.Parse(awg.SequenceEventPatternJumpSize));
        }

        #endregion SLISt:SEQuence:EVENt:PJUMp:SIZE

        #region SLISt:SEQuence:LENGth

        //glennj 8/12/2013
        /// <summary>
        /// Using SLISt:SEQuence:LENGth? update the length property for the named sequence 
        /// </summary>
        public void GetSequenceLength(IAWG awg, string seqName)
        {
            awg.GetSequenceLength(seqName);
        }

        //glennj 8/12/2013
        /// <summary>
        /// Test for the expected sequence length against the updated property
        /// </summary>
        public void SequenceLengthShouldBe(IAWG awg, string expectedSeqLength)
        {
            Assert.AreEqual(float.Parse(expectedSeqLength), float.Parse(awg.SequenceLength));
        }

        #endregion SLISt:SEQuence:LENGth

        #region SLISt:SEQuence:NEW

        //glennj 8/12/2013
      /// <summary>
      /// Using SLISt:SEQuence:NEW create a new sequence of the given size and the given name
      /// </summary>
      /// <param name="awg"></param>
      /// <param name="seqName">Name of the new sequence</param>
      /// <param name="size">Save of the new sequence</param>
      /// <param name="tracks">1-8 tracks, defaults to channels of awg if not specified</param>
      public void CreateANewSequence(IAWG awg, string seqName, string size, string tracks = "") 
        {
            awg.CreateSListSequenceNew(seqName, size, tracks);
        }

        #endregion SLISt:SEQuence:NEW

        #region SLISt:SEQuence:STEP:ADD

      //Keerthi 05/28/2015
      /// <summary>
      /// Using SLISt:SEQuence:STEP:ADD add steps to the sequence at a specified step
      /// </summary>
      /// <param name="sequenceName">Name of the new sequence</param>
      /// <param name="addStep">Add how many number of steps</param>
      /// /// <param name="atWhatStep">Add at what step</param>
      /// <param name="awg">specific awg</param>

      public void AddStepToSequence(string addStep, string atWhatStep, string sequenceName, IAWG awg)
      {

          awg.AddStepToSlistSequence(addStep, atWhatStep, sequenceName);
      }

      #endregion

      

        #region SLISt:SEQuence:RFLag
        /// <summary>
        /// Using SLISt:SEQuence:STEP:RFlag set the enable flag repeat on or off
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="seqName"></param>
        /// <param name="mode">ON|OFF|0|1</param>
        public void SetSequenceRepeatFlag(IAWG awg, string seqName, SequenceFlagRepeatState mode)
        {
            var flagRepeatMode = "";
            switch (mode)
            {
                case SequenceFlagRepeatState.Off:
                    flagRepeatMode = SyntaxForSequenceFlagRepeatStateOff;
                    break;
                case SequenceFlagRepeatState.On:
                    flagRepeatMode = SyntaxForSequenceFlagRepeatStateOn;
                    break;
            }
            awg.SetSequenceRepeatFlag(seqName, flagRepeatMode);
        }

        /// <summary>
        /// Using SLISt:SEQuence:STEP:RFlag?  gets the enable flag repeat state on or off
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="seqName"></param>
        /// <returns>state of enable flag repeat setting</returns>
        public void GetSequenceRepeatFlag(IAWG awg, string seqName)
        {
            awg.GetSequenceRepeatFlag(seqName);
        }

        public void SequenceRepeatFlagShouldBe(IAWG awg, string seqName, SequenceFlagRepeatState expectedRepeatFlagMode)
        {
            string expectedRepeatFlagSetting = "";

            switch (expectedRepeatFlagMode)
            {
                case SequenceFlagRepeatState.Off:
                    expectedRepeatFlagSetting = SyntaxForSequenceFlagRepeatStateOff;
                    break;
                case SequenceFlagRepeatState.On:
                    expectedRepeatFlagSetting = SyntaxForSequenceFlagRepeatStateOn;
                    break;
            }
            var possibleErrorString = "Expected: " + expectedRepeatFlagSetting + " Actual: " + awg.SequenceRepeatFlag;
            Assert.AreEqual(expectedRepeatFlagSetting, awg.SequenceRepeatFlag, possibleErrorString);
        }
        #endregion SLISt:SEQuence:RFLag

        #region SLISt:SEQuence:STEP:EJUMp

        //glennj 8/12/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:EJUMp set the step or step action for the<para>
        /// sequencer's event jump operation.</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="seqName"></param>
        /// <param name="mode">NR1|NEXT|FIRSt|LAST|END</param>
        /// <param name="step">Step from 1 to 16383</param>
        /// <param name="nr1Value"></param>
        public void SetSequenceStepEventJumpOperation(IAWG awg, string seqName, string step, StepEventJumpMode mode, string nr1Value = "")
      {
          string eventJumpSetting;
          switch (mode)
          {
              case StepEventJumpMode.End:
                  eventJumpSetting = SyntaxForStepEventJumpEnd;
                  break;
              case StepEventJumpMode.First:
                  eventJumpSetting = SyntaxForStepEventJumpFirst;
                  break;
              case StepEventJumpMode.Last:
                  eventJumpSetting = SyntaxForStepEventJumpLast;
                  break;
              case StepEventJumpMode.Next:
                  eventJumpSetting = SyntaxForStepEventJumpNext;
                  break;
              default:
                  eventJumpSetting = nr1Value;
                  break;
          }
          awg.SetSequenceStepEventJumpOperation(seqName, eventJumpSetting, step);
        }

        //glennj 8/12/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:EJUMp? update the step or step action for the<para>
        /// sequencer's event jump operation property.</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="seqName"></param>
        /// <param name="step">Step from 1 to 16383</param>
        public void UpdateSequenceStepEventJumpOperation(IAWG awg, string seqName, string step)
        {
            awg.GetSequenceStepEventJumpOperation(seqName, step);
        }

        //glennj 8/12/2103
        /// <summary>
        /// Test for the expected the step or step action against the updated property
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="seqName"></param>
        /// <param name="stepNumber"></param>
        /// <param name="mode"></param>
        /// <param name="nr1Value"></param>
        public void SequenceStepEventJumpOperationShouldBe(IAWG awg, string seqName, string stepNumber, StepEventJumpMode mode, string nr1Value = "")
        {
            string expectedEventJumpModeSetting = "";
            if (mode == StepEventJumpMode.Nr1)
            {
                float convertedNr1Value = 0;
                try
                {
                    convertedNr1Value = float.Parse(nr1Value);
                }
                catch (Exception)
                {
                    Assert.Fail("Not a valid number for a step");
                }
                Assert.AreEqual(convertedNr1Value, float.Parse(awg.SequenceStepEventJumpOpertation));
            }
            else
            {
                switch (mode)
                {
                    case StepEventJumpMode.End:
                        expectedEventJumpModeSetting = SyntaxForStepEventJumpEnd;
                        break;
                    case StepEventJumpMode.First:
                        expectedEventJumpModeSetting = SyntaxForStepEventJumpFirst;
                        break;
                    case StepEventJumpMode.Last:
                        expectedEventJumpModeSetting = SyntaxForStepEventJumpLast;
                        break;
                    case StepEventJumpMode.Next:
                        expectedEventJumpModeSetting = SyntaxForStepEventJumpNext;
                        break;
                }
                var possibleErrorString = "Expected: " + expectedEventJumpModeSetting + " Actual: " + awg.SequenceStepEventJumpOpertation;
                Assert.AreEqual(expectedEventJumpModeSetting, awg.SequenceStepEventJumpOpertation, possibleErrorString);
            }
        }

        #endregion SLISt:SEQuence:STEP:EJUMp

        #region SLISt:SEQuence:STEP:EJINput

        //glennj 8/12/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:EJINput selects the event jump input
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="seqName"></param>
        /// <param name="mode">ATRigger|BTRigger|OFF</param>
        /// <param name="step">Step from 1 to 16383</param>
        public void SetSequenceStepEventJumpInput(IAWG awg, string seqName, string step, StepEventJumpInputMode mode)
        {
            var eventJumpSetting = "";
            switch (mode)
            {
                case StepEventJumpInputMode.Off:
                    eventJumpSetting = SyntaxForStepEventJumpInputOff;
                    break;
                case StepEventJumpInputMode.TriggerA:
                    eventJumpSetting = SyntaxForStepEventJumpInputTriggerA;
                    break;
                case StepEventJumpInputMode.TriggerB:
                    eventJumpSetting = SyntaxForStepEventJumpInputTriggerB;
                    break;
                case StepEventJumpInputMode.InternalTrigger:
                    eventJumpSetting = SyntaxForStepEventJumpInputInternalTrigger;
                    break;
            }
            awg.SetSequenceStepEventJumpInput(seqName, step, eventJumpSetting);
        }

        //glennj 8/12/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:EJINput? update the selected event jump input property
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="seqName"></param>
        /// <param name="step">Step from 1 to 16383</param>
        public void UpdateSequenceStepEventJumpInput(IAWG awg, string seqName, string step)
        {
            awg.GetSequenceStepEventJumpInput(seqName, step);
        }

        //glennj 8/12/2013
        /// <summary>
        /// Test for the expected the event jump input against the updated property
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="stepNumber"></param>
        /// <param name="expectedJumpInputSelection"></param>
        /// <param name="seqName"></param>
        public void SequenceStepEventJumpInputShouldBe(IAWG awg, string seqName, string stepNumber, StepEventJumpInputMode expectedJumpInputSelection)
        {
            string expectedEventJumpModeSetting = "";

            switch (expectedJumpInputSelection)
            {
                case StepEventJumpInputMode.Off:
                    expectedEventJumpModeSetting = SyntaxForStepEventJumpInputOff;
                    break;
                case StepEventJumpInputMode.TriggerA:
                    expectedEventJumpModeSetting = SyntaxForStepEventJumpInputTriggerA;
                    break;
                case StepEventJumpInputMode.TriggerB:
                    expectedEventJumpModeSetting = SyntaxForStepEventJumpInputTriggerB;
                    break;
                case StepEventJumpInputMode.InternalTrigger:
                    expectedEventJumpModeSetting = SyntaxForStepEventJumpInputInternalTrigger;
                    break;
            }
            var possibleErrorString = "Expected: " + expectedEventJumpModeSetting + " Actual: " + awg.SequenceStepEventJumpInput;
            Assert.AreEqual(expectedEventJumpModeSetting, awg.SequenceStepEventJumpInput, possibleErrorString);
        }

        #endregion SLISt:SEQuence:STEP:EJINput

        #region SLISt:SEQuence:STEP:GOTO

        //glennj 8/12/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP[n]:GOTO set the target step for the GOTO command<para>
        /// of the sequencer at the current step</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="seqName"></param>
        /// <param name="mode">nr1|LAST|FIRSt|NEXT|END</param>
        /// <param name="step">Step from 1 to 16383</param>
        /// <param name="nr1Value"></param>
        public void SetSequenceStepGoto(IAWG awg, string seqName, string step, StepGotoMode mode, string nr1Value = "")
        {
            string gotoSetting;
            switch (mode)
            {
                case StepGotoMode.End:
                    gotoSetting = SyntaxForStepGotoEnd;
                    break;
                case StepGotoMode.First:
                    gotoSetting = SyntaxForStepGotoFirst;
                    break;
                case StepGotoMode.Last:
                    gotoSetting = SyntaxForStepGotoLast;
                    break;
                case StepGotoMode.Next:
                    gotoSetting = SyntaxForStepGotoNext;
                    break;
                default:
                    gotoSetting = nr1Value;
                    break;
            }
            awg.SetSequenceStepGoto(seqName, step, gotoSetting);
        }

        //glennj 8/12/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:GOTO? update the property for the target step<para>
        /// for the GOTO command of the sequencer at the current step</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="seqName"></param>
        /// <param name="step"></param>
        public void UpdateSequenceStepGoto(IAWG awg, string seqName, string step)
        {
            awg.GetSequenceStepGoto(seqName, step);
        }

        //glennj 8/12/2013
        /// <summary>
        /// Test for the expected the target step for the GOTO command against the updated property
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="stepNumber"></param>
        /// <param name="mode"></param>
        /// <param name="nr1Value"></param>
        /// <param name="seqName"></param>
        public void SequenceStepGotoShouldBe(IAWG awg, string seqName, string stepNumber, StepGotoMode mode, string nr1Value = "")
        {
            string expectedGotoSetting = "";
            if (mode == StepGotoMode.Nr1)
            {
                Assert.AreEqual(nr1Value, awg.SequenceStepGoto);
            }
            else
            {
                switch (mode)
                {
                    case StepGotoMode.End:
                        expectedGotoSetting = SyntaxForStepGotoEnd;
                        break;
                    case StepGotoMode.First:
                        expectedGotoSetting = SyntaxForStepGotoFirst;
                        break;
                    case StepGotoMode.Last:
                        expectedGotoSetting = SyntaxForStepGotoLast;
                        break;
                    case StepGotoMode.Next:
                        expectedGotoSetting = SyntaxForStepGotoNext;
                        break;
                }
                var possibleErrorString = "Expected: " + expectedGotoSetting + " Actual: " + awg.SequenceStepGoto;
                Assert.AreEqual(expectedGotoSetting, awg.SequenceStepGoto, possibleErrorString);
            }
        }

        #endregion SLISt:SEQuence:STEP:GOTO

        #region SLISt:SEQuence:STEP:MAX

        //glennj 8/12/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:MAX? update maximum number of steps allowed<para>
        /// in a sequence property</para>
        /// </summary>
        /// <param name="awg"></param>
        public void UpdateSequenceStepMax(IAWG awg)
        {
            awg.GetSequenceStepMax();
        }

        public void SequenceStepMaxShouldBe(IAWG awg, string expectedMaxSteps)
        {
            Assert.AreEqual(float.Parse(expectedMaxSteps), float.Parse(awg.SequenceStepMax));
        }

        #endregion SLISt:SEQuence:STEP:MAX

        #region SLISt:SEQuence:STEP:RCOunt

        //glennj 8/12/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:RCOunt set the repeat count
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="seqName"></param>
        /// <param name="step">Step from 1 to 16383</param>
        /// <param name="mode">nr1|ONCE|INFinite</param>
        /// <param name="nr1Value"></param>
        public void SetSequenceStepRepeatCount(IAWG awg, string seqName, string step, StepRepeatCountMode mode, string nr1Value = "")
        {
            string repeatCount;
            switch (mode)
            {
                case StepRepeatCountMode.Once:
                    repeatCount = SyntaxForStepRepeatCountOnce;
                    break;
                case StepRepeatCountMode.Infinite:
                    repeatCount = SyntaxForStepRepeatCountInfinite;
                    break;
                default:
                    repeatCount = nr1Value;
                    break;
            }
            awg.SetSequenceStepRepeatCount(seqName, step, repeatCount);
        }

        //glennj 8/12/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:RCOunt? update the repeat count awg property
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="seqName"></param>
        /// <param name="step">Step from 1 to 16383</param>
        public void UpdateSequenceStepRepeatCount(IAWG awg, string seqName, string step)
        {
            awg.GetSequenceStepRepeatCount(seqName, step);
        }

        /// <summary>
        /// Test for the expected the Step Repeat Count against the updated property
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="seqName"></param>
        /// <param name="stepNumber"></param>
        /// <param name="mode"></param>
        /// <param name="nr1Value"></param>
        public void SequenceStepRepeatCountShouldBe(IAWG awg, string seqName, string stepNumber, StepRepeatCountMode mode, string nr1Value = "")
        {
            string expectedRepeatCount = "";
            if (mode == StepRepeatCountMode.Nr1)
            {
                float convertedNr1Value = 0;
                try
                {
                    convertedNr1Value = float.Parse(nr1Value);
                }
                catch (Exception)
                {
                    Assert.Fail("Not a valid number for a step");
                }
                Assert.AreEqual(convertedNr1Value, float.Parse(awg.SequenceStepRepeatCount));
            }
            else
            {
                switch (mode)
                {
                    case StepRepeatCountMode.Once:
                        expectedRepeatCount = SyntaxForStepRepeatCountOnce;
                        break;
                    case StepRepeatCountMode.Infinite:
                        expectedRepeatCount = SyntaxForStepRepeatCountInfinite;
                        break;
                }
                var possibleErrorString = "Expected: " + expectedRepeatCount + " Actual: " + awg.SequenceStepGoto;
                Assert.AreEqual(expectedRepeatCount, awg.SequenceStepRepeatCount, possibleErrorString);
            }
        }

        #endregion SLISt:SEQuence:STEP:RCOunt

        #region SLISt:SEQuence:STEP:RCOunt:MAX

        //glennj 8/12/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:RCOunt:MAX? update the property for the maximum<para>
        /// number of repeat count allowed</para>
        /// </summary>
        public void UpdateSequenceStepRepeatCountMax(IAWG awg)
        {
            awg.GetSequenceStepRepeatCountMax();
        }

        /// <summary>
        /// Test for the expected the Max Step Repeat Count against the updated property
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedMaxCount"></param>
        public void SequenceStepRepeatCountMaxShouldBe(IAWG awg, string expectedMaxCount)
        {
            Assert.AreEqual(float.Parse(expectedMaxCount), float.Parse(awg.SequenceStepRepeatCountMax));
        }
        
        #endregion SLISt:SEQuence:STEP:RCOunt:MAX

        #region SLISt:SEQuence:STEP:TASSet

        //glennj 8/16/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:TASSet? update AWG property for the waveform name at the specified step and track
        /// </summary>
        public void UpdateSequenceStepTrackAsset(IAWG awg, string seqName, string stepNumber, string trackNumber)
        {
            awg.GetSequenceStepTrackAsset(seqName, stepNumber, trackNumber);
        }

        //glennj 8/16/2013
        /// <summary>
        /// Test for an expected sequence name in the updated property<para>
        /// Note: Sequence name, step number and waveform number are</para><para>
        /// not currently used.  The expected waveform is tested against</para><para>
        /// the one property that gets updated using sequence name, step</para><para>
        /// number and track number.</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="seqName"></param>
        /// <param name="stepNumber"></param>
        /// <param name="trackNumber"></param>
        /// <param name="expectedWfmName"></param>
        public void SequenceStepTrackAssetShouldBe(IAWG awg, string seqName, string stepNumber, string trackNumber,
                                                   string expectedWfmName)
        {
            const string possibleErrorString = "Updated property from a get for seq step track asset";
            Assert.AreEqual(expectedWfmName, _utils.Dequotify(awg.SequenceStepTrackAsset), possibleErrorString);
        }

        #endregion SLISt:SEQuence:STEP:TASSet

        #region SLISt:SEQuence:STEP:TASSet:SEQuence
        /// <summary>
        /// Using SLISt:SEQuence:STEP:TASSet:SEQuence set a sequence to a step(as a subsequence) and of a sequence
        /// Note:  Applies to all tracks in the sequence
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="seqName"></param>
        /// <param name="stepNumber"></param>
        /// <param name="subSeqName"></param>
        public void SetSequenceStepTrackAssetForSequence(IAWG awg, string seqName, string stepNumber, string subSeqName)
        {
            awg.SetSequenceStepTrackAssetForSequence(seqName, stepNumber, subSeqName);
        }
        #endregion SLISt:SEQuence:STEP:TASSet:SEQuence

        #region SLISt:SEQuence:STEP:TASSet:TYPE
        /// <summary>
        /// Using SLISt:SEQuence:STEP[n]:TASSet[m]:TYPE? get the type of asset assigned to the specified step and track
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="seqName"></param>
        /// <param name="stepNumber"></param>
        /// <param name="trackNumber"></param>
        /// <returns>gets asset type value (WAVeform|SEQuence)</returns>
        public void GetSequenceStepTrackAssetType(IAWG awg, string seqName, string stepNumber, string trackNumber)
        {
            awg.GetSequenceStepTrackAssetType(seqName, stepNumber, trackNumber);
        }

        /// <summary>
        /// Using SLISt:SEQuence:STEP[n]:TASSet[m]:TYPE? compares actual versus expected type of asset assigned to the specified step and track
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="seqName"></param>
        /// <param name="stepNumber"></param>
        /// <param name="trackNumber"></param>
        /// <param name="expectedAssetType"></param>
        /// <returns>compares asset type (WAVeform|SEQuence)</returns>
        public void SequenceStepTrackAssetTypeShouldBe(IAWG awg, string seqName, string stepNumber, string trackNumber, SequenceTrackAssetType expectedAssetType)
        {
            string expectedAssetTypeName = "";
            switch (expectedAssetType)
            {
                case SequenceTrackAssetType.Waveform:
                    expectedAssetTypeName = SyntaxForSequenceTrackAssetTypeWaveform;
                    break;
                case SequenceTrackAssetType.Sequence:
                    expectedAssetTypeName = SyntaxForSequenceTrackAssetTypeSequence;
                    break;
            }
            var possibleErrorString = "Expected: " + expectedAssetTypeName + " Actual: " + awg.SequenceStepTrackAssetType;
            Assert.AreEqual(expectedAssetTypeName, awg.SequenceStepTrackAssetType, possibleErrorString);
        }
        #endregion SLISt:SEQuence:STEP:TASSet:TYPE

        #region SLISt:SEQuence:STEP:TASSet:WAVeform

        //glennj 8/16/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:TASSet:WAVeform assign(set) a wfm to a step and track of a sequence
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="seqName"></param>
        /// <param name="stepNumber"></param>
        /// <param name="trackNumber"></param>
        /// <param name="wfmName"></param>
        public void SetSequenceStepTrackAssetForWaveform(IAWG awg, string seqName, string stepNumber, string trackNumber, string wfmName)
        {
            awg.SetSequenceStepTrackAssetForWaveform(seqName, stepNumber, trackNumber, wfmName);
        }

        #endregion SLISt:SEQuence:STEP:TASSet:WAVeform

        #region SLISt:SEQuence:STEP[n]:TFLag[m]:[ALPHA]FLAG
        /// <summary>
        /// Using SLISt:SEQuence:STEP:TFLag[m]:[ALPHA]FLAG set a flag value of the track in a specific sequence step for the specified flag
        /// flag settings are (NOCHANGE|HIGH|LOW|TOGGLE|PULSE)
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="seqName"></param>
        /// <param name="stepNumber"></param>
        /// <param name="trackNumber"></param>
        /// <param name="flagAlpha">four flags can be set (A|B|C|D)FLAG</param>
        /// <param name="flagMode">flag settings are (NOCHANGE|HIGH|LOW|TOGGLE|PULSE)</param>
        public void SetSequenceStepTrackFlagValue(IAWG awg, string seqName, string stepNumber, string trackNumber, string flagAlpha, SequenceFlagSetting flagMode)
        {
            var flagSetting = "";
            switch (flagMode)
            {
                case SequenceFlagSetting.NoChange:
                    flagSetting = SyntaxForSequenceFlagSettingNoChange;
                    break;
                case SequenceFlagSetting.High:
                    flagSetting = SyntaxForSequenceFlagSettingHigh;
                    break;
                case SequenceFlagSetting.Low:
                    flagSetting = SyntaxForSequenceFlagSettingLow;
                    break;
                case SequenceFlagSetting.Toggle:
                    flagSetting = SyntaxForSequenceFlagSettingToggle;
                    break;
                case SequenceFlagSetting.Pulse:
                    flagSetting = SyntaxForSequenceFlagSettingPulse;
                    break;
            } 
            awg.SetSequenceStepTrackFlagValue(seqName, stepNumber, trackNumber, flagAlpha, flagSetting);
        }

        /// <summary>
        /// Using SLISt:SEQuence:STEP:TFLag[m]:[ALPHA]FLAG? gets value of flag for the track in a specific sequence step for the specified flag
        /// </summary>
        /// <param name="awg"></param>
        ///  <param name="seqName"></param>
        /// <param name="stepNumber"></param>
        /// <param name="trackNumber"></param>
        /// <param name="flagAlpha">four flags can be set (A|B|C|D)FLAG</param>
        /// <returns>returns flag value (NOCHANGE|HIGH|LOW|TOGGLE|PULSE)</returns>
        public void GetSequenceStepTrackFlagValue(IAWG awg, string seqName, string stepNumber, string trackNumber, string flagAlpha)
        {
            awg.GetSequenceStepTrackFlagValue(seqName, stepNumber, trackNumber, flagAlpha);
        }

        public void SequenceStepTrackFlagValueShouldBe(IAWG awg, string seqName, string stepNumber, string trackNumber, string flagAlpha, SequenceFlagSetting expectedflagMode)
        {
            var expectedFlagSetting = "";
            switch (expectedflagMode)
            {
                case SequenceFlagSetting.NoChange:
                    expectedFlagSetting = SyntaxForSequenceFlagSettingNoChange;
                    break;
                case SequenceFlagSetting.High:
                    expectedFlagSetting = SyntaxForSequenceFlagSettingHigh;
                    break;
                case SequenceFlagSetting.Low:
                    expectedFlagSetting = SyntaxForSequenceFlagSettingLow;
                    break;
                case SequenceFlagSetting.Toggle:
                    expectedFlagSetting = SyntaxForSequenceFlagSettingToggle;
                    break;
                case SequenceFlagSetting.Pulse:
                    expectedFlagSetting = SyntaxForSequenceFlagSettingPulse;
                    break;
            }
            var possibleErrorString = "Expected: " + expectedFlagSetting + " Actual: " + awg.SequenceStepTrackFlagValue;
            Assert.AreEqual(expectedFlagSetting, awg.SequenceStepTrackFlagValue, possibleErrorString);
        }
        #endregion SLISt:SEQuence:STEP[n]:TFLag[m]:[ALPHA]FLAG

        #region SLISt:SEQuence:STEP:WAVeform
        // Obsoleted
        #endregion SLISt:SEQuence:STEP:WAVeform

        #region SLISt:SEQuence:STEP:WINPut

        //glennj 8/12/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP[n]:WINPut selects the mode to<para>
        /// listen for trigger signal</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="seqName">The named sequence</param>
        /// <param name="step">Step from 1 to 16383</param>
        /// <param name="mode">ATRigger|BTRigger|OFF</param>
        public void SetSequenceStepWaitInput(IAWG awg, string seqName, string step, StepWaitInputMode mode)
        {
            var waitSetting = "";
            switch (mode)
            {
                case StepWaitInputMode.Off:
                    waitSetting = SyntaxForStepWaitInputOff;
                    break;
                case StepWaitInputMode.TriggerA:
                    waitSetting = SyntaxForStepWaitInputTriggerA;
                    break;
                case StepWaitInputMode.TriggerB:
                    waitSetting = SyntaxForStepWaitInputTriggerB;
                    break;
                case StepWaitInputMode.InternalTrigger:
                    waitSetting = SyntaxForStepWaitInputInternalTrigger;
                    break;
            }

            awg.SetSequenceStepWaitInput(seqName, step, waitSetting);
        }

        //glennj 8/12/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP[n]:WINPut? update the property for<para>
        /// the selected the name of the waveform at the chosen step.</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="seqName">The named sequence</param>
        /// <param name="step">Step from 1 to 16383</param>
        public void UpdateSequenceStepWaitInput(IAWG awg, string seqName, string step)
        {
            awg.GetSequenceStepWaitInput(seqName, step);
        }

        public void SequenceStepWaitInputShouldBe(IAWG awg, string seqName, string stepNumber, StepWaitInputMode expectedWaitInputSelection)
        {
            string expectedWaitModeSetting = "";

            switch (expectedWaitInputSelection)
            {
                case StepWaitInputMode.Off:
                    expectedWaitModeSetting = SyntaxForStepWaitInputOff;
                    break;
                case StepWaitInputMode.TriggerA:
                    expectedWaitModeSetting = SyntaxForStepWaitInputTriggerA;
                    break;
                case StepWaitInputMode.TriggerB:
                    expectedWaitModeSetting = SyntaxForStepWaitInputTriggerB;
                    break;
                case StepWaitInputMode.InternalTrigger:
                    expectedWaitModeSetting = SyntaxForStepWaitInputInternalTrigger;
                    break;
            }
            var possibleErrorString = "Expected: " + expectedWaitModeSetting + " Actual: " + awg.SequenceStepWaitInput;
            Assert.AreEqual(expectedWaitModeSetting, awg.SequenceStepWaitInput, possibleErrorString);
        }
        #endregion SLISt:SEQuence:STEP:WINPut

        #region SLISt:SEQuence:TRACk?

        //glennj 8/15/2013
        /// <summary>
        /// Update the property for SLISt:SEQuence:TRACk? to get the number of tracks of the named sequence.
        /// </summary>
        public void GetSequenceTracks(IAWG awg, string seqName)
        {
            awg.GetSequenceTracks(seqName);
        }

        //glennj 8/15/2013
        /// <summary>
        /// Tests the updated property for an expected number of tracks<para>
        /// Currently the seqName is not being used.  The user must do a get</para><para>
        /// to update the single property.  Maybe in the future multiple sequences</para><para>
        /// will be tested in parallel but right now it is one at a time.</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="seqName"></param>
        /// <param name="expectedNumber"></param>
        public void NumberOfSequenceTracksShouldBe(IAWG awg, string seqName, string expectedNumber)
        {
            Assert.AreEqual(float.Parse(expectedNumber), float.Parse(awg.SequenceNumberOfTracks));
        }

        public void NumberOfSequenceTracksShouldBeEitherOr(IAWG awg, string seqName, string expectedNum1, string expectedNum2)
        {
            if ((float.Parse(expectedNum1)!=float.Parse(awg.SequenceNumberOfTracks)) && (float.Parse(expectedNum2)!=float.Parse(awg.SequenceNumberOfTracks)))
            {
                Assert.Fail("Number of Sequence Tracks was not " + expectedNum1 + " or " + expectedNum2 + ". Value returned was: " + awg.SequenceNumberOfTracks);
            }
        }
        #endregion SLISt:SEQuence:TRACk?

        #region SLISt:SEQuence:TRACk:MAX

        //glennj 8/12/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:TRACk:MAX? update maximum number of tracks allowed in a<para>
        /// sequence property </para>
        /// </summary>
        public void UpdateSequenceTrackMax(IAWG awg)
        {
            awg.GetSequenceStepTrackCountMax();
        }

        //glennj 8/12/2013
        /// <summary>
        /// Test for the expected the Max Track Count against the updated property
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedMaxCount"></param>
        public void SequenceTrackMaxShouldBe(IAWG awg, string expectedMaxCount)
        {
            Assert.AreEqual(float.Parse(expectedMaxCount), float.Parse(awg.SequenceStepTrackCountMax));
        }

        #endregion SLISt:SEQuence:TRACk:MAX

        #region SLISt:SEQuence:TSTamp

        //glennj 8/12/2013
        /// <summary>
        /// Using SLISt:SEQuence:TSTamp? update the timestamp of the named sequence property
        /// </summary>
        public void UpdateSequenceTimestamp(IAWG awg, string seqName)
        {
            awg.GetSequenceTimestamp(seqName);
        }

        //glennj 8/12/2013
        /// <summary>
        /// Test the updated property against an expected sequence timestamp
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedSequenceTimestamp"></param>
        public void SequenceTimestampShouldBe(IAWG awg, string expectedSequenceTimestamp)
        {
            Assert.AreEqual(expectedSequenceTimestamp, awg.SequenceTimestamp);
        }

        //glennj 8/13/2013
        /// <summary>
        /// Validate the sequence timestamp for format and range of possible values in each of the fields
        /// </summary>
        /// <param name="awg"></param>
        public void TimestampOfSeqFromSequenceListShouldMatchPattern(IAWG awg)
        {
            //See if the awg.waveform_timestamp string matches the expected pattern
            var validatePreMatcher = new Regex(@"(?:19[0-9]{2}|20[0-9]{2})/([0|1][0-2]|0[1-9])/[0-3][0-9] (?:2[0-4]|1[0-9]|0[0-9]):[0-5][0-9]:[0-5][0-9]");
            var match = validatePreMatcher.Match(awg.SequenceTimestamp);
            // Check the status string to see if the operation was sucessful
            if (!match.Success)
            {
                Assert.Fail("Timestamp pattern did not match expectations. Value returned was: " + awg.WaveformListTimestamp);
            }
        }

        #endregion SLISt:SEQuence:TSTamp

        #region SLISt:SIZE

        //glennj 8/12/2013
        /// <summary>
        /// Using SLISt:SIZE? update the size of the sequence list property.
        /// </summary>
        public void GetSlistSize(IAWG awg)
        {
            awg.GetSlistSize();
        }

        //glennj 8/1/2013
        /// <summary>
        /// Test the updated property against an expected sequence list size
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedSize"></param>
        public void SequenceListSizeShouldBe(IAWG awg, string expectedSize)
        {
            Assert.AreEqual(float.Parse(expectedSize), float.Parse(awg.SequenceListSize));
        }

        #endregion SLISt:SIZE

        #endregion SLIST



   



        
    }
}