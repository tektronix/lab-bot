namespace AwgTestFramework
{
    public partial class AWG
    {
        
        /// <summary>
        /// Property for response from SLISt:NAME?
        /// </summary>
        public string SequenceNameOfElement { get; set; }
        
        /// <summary>
        /// Property for response from SLISt:SEQuence:EVENt:PJUMp:ENABle?
        /// </summary>
        public string SequenceEventPatternJumpEnable { get; set; }
        
        /// <summary>
        /// Property for response from SLISt:SEQuence:EVENt:PJUMp:DEFine?
        /// </summary>
        public string SequenceEventPatternJumpDefine { get; set; }
        
        /// <summary>
        /// Property for response from SLISt:SEQuence:EVENt:PJUMp:SIZE?
        /// </summary>
        public string SequenceEventPatternJumpSize { get; set; }
        
        /// <summary>
        /// Property for response from SLISt:SEQuence:EVENt:JTIMing?
        /// </summary>
        public string SequenceEventPatternJumpTiming { get; set; }
        
        /// <summary>
        /// Property for response from SLISt:SEQuence:LENGth?
        /// </summary>
        public string SequenceLength { get; set; }

        /// <summary>
        /// Using SLISt:SEQuence:STEP:RFlag?  gets the enable flag repeat state on or off
        /// </summary>
        public string SequenceRepeatFlag { get; set; }

        /// <summary>
        /// Property for response from SLISt:SEQuence:STEP:EJUMp?
        /// </summary>
        public string SequenceStepEventJumpOpertation { get; set; }
       
        /// <summary>
        /// Property for response from SLISt:SEQuence:STEP:EJINput?
        /// </summary>
        public string SequenceStepEventJumpInput { get; set; }
        
        /// <summary>
        /// Property for response from SLISt:SEQuence:STEP:GOTO?
        /// </summary>
        public string SequenceStepGoto { get; set; }
        
        /// <summary>
        /// Property for response from SLISt:SEQuence:STEP:MAX?
        /// </summary>
        public string SequenceStepMax { get; set; }
        
        /// <summary>
        /// Property for response from SLISt:SEQuence:STEP:RCOunt?
        /// </summary>
        public string SequenceStepRepeatCount { get; set; }
        
        /// <summary>
        /// Property for response from SLISt:SEQuence:STEP:RCOunt:MAX?
        /// </summary>
        public string SequenceStepRepeatCountMax { get; set; }
        
        /// <summary>
        /// Property for response from SLISt:SEQuence:STEP:TASSet?
        /// </summary>
        public string SequenceStepTrackAsset { get; set; }
        
        /// <summary>
        /// Property for response from SLISt:SEQuence:STEP[n]:TASSet[m]:TYPE?
        /// </summary>
        public string SequenceStepTrackAssetType  { get; set; }
        
        /// <summary>
        /// Property for response from SLISt:SEQuence:STEP:TRACk:MAX?
        /// </summary>
        public string SequenceStepTrackCountMax { get; set; }
        
        /// <summary>
        /// Property for response from SLISt:SEQuence:STEP:TFLag[m]:[ALPHA]FLAG? 
        /// </summary>
        public string SequenceStepTrackFlagValue { get; set; }
        
        /// <summary>
        /// Property for response from SLISt:SEQuence:STEP[n]:WAVeform[m]?
        /// </summary>
        public string SequenceStepWaveformName { get; set; }
        
        /// <summary>
        /// Property for response from SLISt:SEQuence:STEP[n]:WINPut?
        /// </summary>
        public string SequenceStepWaitInput { get; set; }
        
        /// <summary>
        /// Property for response from SLISt:SEQuence:TRACks?
        /// </summary>
        public string SequenceNumberOfTracks { get; set; }
        
        /// <summary>
        /// Property for response from SLISt:SEQuence:TSTamp?
        /// </summary>
        public string SequenceTimestamp { get; set; }
        
        /// <summary>
        /// Property for response from SLISt:SIZE?
        /// </summary>
        public string SequenceListSize { get; set; }

     


        #region SLISt:NAME

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:NAME? get the name of the sequence of an element in the sequence list
        /// </summary>
        /// <param name="listIndex">Index of the sequence in the sequence list</param>
        /// <returns>The name of the waveform</returns>
        public void GetSlistName(string listIndex)
        {
            SequenceNameOfElement = _util.Dequotify(_pi.GetAwgSlistName(listIndex));
        }

        #endregion SLISt:NAME

        #region SLISt:SEQuence:DELete

        //glennj 8/9/2013
        /// <summary>
        /// Using SLIST:SEQuence:DELete delete the sequence from the sequence list
        /// </summary>
        /// <param name="seqName">Name of the sequence to delete</param>
        /// <param name="addQuotes">Keyword such as ALL does not require quotes</param>
        public void DeleteSequenceListSequence(string seqName, bool addQuotes = true)
        {
            _pi.DeleteAwgSListSequence(seqName, addQuotes);
        }

        #endregion SLISt:SEQuence:DELete

        #region SLISt:SEQuence:EVENt:PJUMp:ENABle

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:EVENt:PJUMp:ENABle set the event pattern jump enable
        /// </summary>
        public void SetSequenceEventPatternJumpEnable(string seqName, string enableState)
        {
            _pi.SetAwgSequenceEventPatternJumpEnable(seqName, enableState);
        }

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:EVENt:PJUMp:ENABle? get the event pattern jump enable
        /// </summary>
        /// <returns>event pattern jump enable</returns>
        public void GetSequenceEventPatternJumpEnable(string seqName)
        {
            SequenceEventPatternJumpEnable = _pi.GetAwgSequenceEventPatternJumpEnable(seqName);
        }

        #endregion SLISt:SEQuence:EVENt:PJUMp:ENABle

        #region SLISt:SEQuence:EVENt:PJUMp:DEFine

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:EVENt:PJUMp:DEFine associate an event pattern<para>
        /// with the jumpe to step for Pattern Jump</para>
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="pattern"></param>
        /// <param name="jumpStep"></param>
        public void SetSequenceEventPatternJumpDefine(string seqName, string pattern, string jumpStep)
        {
            _pi.SetAwgSequenceEventPatternJumpDefine(seqName, pattern, jumpStep);
        }

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:EVENt:PJUMp:DEFine? get the jump step associated to the specified pattern
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="pattern"></param>
        /// <returns>event pattern jump enable</returns>
        public void GetSequenceEventPatternJumpDefine(string seqName, string pattern)
        {
            SequenceEventPatternJumpDefine = _pi.GetAwgSequenceEventPatternJumpDefine(seqName, pattern);
        }

        #endregion SLISt:SEQuence:EVENt:PJUMp:DEFine

        #region SLISt:SEQuence:EVENt:PJUMp:SIZE

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:EVENt:PJUMp:SIZE? get the maximum number of entries in the pattern jump table
        /// </summary>
        /// <returns>event pattern jump enable</returns>
        public void GetSequenceEventPatternJumpSize()
        {
            SequenceEventPatternJumpSize = _pi.GetAwgSequenceEventPatternJumpSize();
        }

        #endregion SLISt:SEQuence:EVENt:PJUMp:SIZE

        #region SLISt:SEQuence:EVENt:JTIMing

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:EVENt:JTIMing sets how the sequencer<para>
        /// will respond to a logic event, pattern jump or a software</para><para>
        /// force jump.</para>
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="mode">of END or IMMediate</param>
        public void SetSequenceEventPatternJumpTiming(string seqName, string mode)
        {
            _pi.SetAwgSequenceEventPatternJumpTiming(seqName, mode);
        }

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:EVENt:JTIMing? get the mode for how the sequencer<para>
        /// will respond to a logic event, pattern jump or a software</para><para>
        /// force jump.</para>
        /// </summary>
        /// <param name="seqName"></param>
        /// <returns>event pattern jump enable</returns>
        public void GetSequenceEventPatternJumpTiming(string seqName)
        {
            SequenceEventPatternJumpTiming = _pi.GetAwgSequenceEventPatternJumpTiming(seqName);
        }

        #endregion SLISt:SEQuence:EVENt:JTIMing

        #region SLISt:SEQuence:LENGth

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:LENGth? get the length of the named sequence.
        /// </summary>
        /// <returns>length of named sequence</returns>
        public void GetSequenceLength(string seqName)
        {
            SequenceLength = _pi.GetAwgSequenceLength(seqName);
        }

        #endregion SLISt:SEQuence:LENGth

        #region SLISt:SEQuence:NEW

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:NEW create a new sequence of the given size and the given name
        /// </summary>
        /// <param name="seqName">Name of the new sequence</param>
        /// <param name="size">Save of the new sequence</param>
        /// <param name="tracks">Sequence can have 1-8 tracks</param>
        public void CreateSListSequenceNew(string seqName, string size, string tracks)
        {
            _pi.CreateAwgSListSequenceNew(seqName, size, tracks);
        }

        #endregion SLISt:SEQuence:NEW

        #region SLISt:SEQuence:STEP:ADD

        //Keerthi 05/28/2015
        /// <summary>
        /// Using SLISt:SEQuence:STEP:ADD add steps to the sequence at a specified step
        /// </summary>
        /// <param name="seqName">Name of the new sequence</param>
        /// <param name="addToSeqStep">Add how many number of steps</param>
        /// /// <param name="addAtWhatStep">Add at what step</param>
       

        public void AddStepToSlistSequence(string addToSeqStep, string addAtWhatStep, string seqName)
        {

            _pi.AddStepToSlistSequence(addToSeqStep, addAtWhatStep, seqName);

        }


        #endregion

       

        #region SLISt:SEQuence:RFLag
        /// <summary>
        /// Using SLISt:SEQuence:STEP:RFlag set the enable flag repeat on or off
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="mode">ON|OFF|0|1</param>
        public void SetSequenceRepeatFlag(string seqName, string mode)
        {
            _pi.SetAwgSequenceRepeatFlag(seqName, mode);
        }

        /// <summary>
        /// Using SLISt:SEQuence:STEP:RFlag?  gets the enable flag repeat state on or off
        /// </summary>
        /// <param name="seqName"></param>
        /// <returns>state of enable flag repeat setting</returns>
        public void GetSequenceRepeatFlag(string seqName)
        {
            SequenceRepeatFlag = _pi.GetAwgSequenceRepeatFlag(seqName);
        }
        #endregion SLISt:SEQuence:RFLag

        #region SLISt:SEQuence:STEP:EJUMp

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:EJUMp set the step or step action for the<para>
        /// sequencer's event jump operation.</para>
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="mode">NR1|NEXT|FIRSt|LAST|END</param>
        /// <param name="step">Step from 1 to 16383</param>
        public void SetSequenceStepEventJumpOperation(string seqName, string mode, string step)
        {
            _pi.SetAwgSequenceStepEventJumpOperation(seqName, mode, step);
        }

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:EJUMp? get the step or step action for the<para>
        /// sequencer's event jump operation.</para>
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="step">Step from 1 to 16383</param>
        /// <returns>event jump operation mode</returns>
        public void GetSequenceStepEventJumpOperation(string seqName, string step)
        {
            SequenceStepEventJumpOpertation = _pi.GetAwgSequenceStepEventJumpOperation(seqName, step);
        }

        #endregion SLISt:SEQuence:STEP:EJUMp

        #region SLISt:SEQuence:STEP:EJINput

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:EJINput selects the event jump input
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="step">Step from 1 to 16383</param>
        /// <param name="mode">ATRigger|BTRigger|ITRigger|OFF</param>
        public void SetSequenceStepEventJumpInput(string seqName, string step, string mode)
        {
            _pi.SetAwgSequenceStepEventJumpInput(seqName, step, mode);
        }

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:EJINput? get the selected event jump input
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="step">Step from 1 to 16383</param>
        /// <returns>event jump operation mode</returns>
        public void GetSequenceStepEventJumpInput(string seqName, string step)
        {
            SequenceStepEventJumpInput = _pi.GetAwgSequenceStepEventJumpInput(seqName, step);
        }

        #endregion SLISt:SEQuence:STEP:EJINput

        #region SLISt:SEQuence:STEP:GOTO

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP[n]:GOTO set the target step for the GOTO command<para>
        /// of the sequencer at the current step</para>
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="step">Step from 1 to 16383</param>
        /// <param name="mode">nr1|LAST|FIRSt|NEXT|END</param>
        public void SetSequenceStepGoto(string seqName, string step, string mode)
        {
            _pi.SetAwgSequenceStepGoto(seqName, step, mode);
        }

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:GOTO? get the target step for the GOTO command<para>
        /// of the sequencer at the current step</para>
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="step"></param>
        /// <returns>event jump operation mode</returns>
        public void GetSequenceStepGoto(string seqName, string step)
        {
            SequenceStepGoto = _pi.GetAwgSequenceStepGoto(seqName, step);
        }

        #endregion SLISt:SEQuence:STEP:GOTO

        #region SLISt:SEQuence:STEP:MAX

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:MAX? get maximum number of steps allowed in a sequence
        /// </summary>
        /// <returns>maximum number of steps allowed as an nr1</returns>
        public void GetSequenceStepMax()
        {
            SequenceStepMax = _pi.GetAwgSequenceStepMax();
        }

        #endregion SLISt:SEQuence:STEP:MAX

        #region SLISt:SEQuence:STEP:RCOunt

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:RCOunt set the repeat count
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="step">Step from 1 to 16383</param>
        /// <param name="mode">nr1|ONCE|INFinite</param>
        public void SetSequenceStepRepeatCount(string seqName, string step, string mode)
        {
            _pi.SetAwgSequenceStepRepeatCount(seqName, step, mode);
        }

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:RCOunt? get the repeat count
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="step">Step from 1 to 16383</param>
        /// <returns>repeat mode or count</returns>
        public void GetSequenceStepRepeatCount(string seqName, string step)
        {
            SequenceStepRepeatCount = _pi.GetAwgSequenceStepRepeatCount(seqName, step);
        }

        #endregion SLISt:SEQuence:STEP:RCOunt

        #region SLISt:SEQuence:STEP:RCOunt:MAX

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:RCOunt:MAX? get maximum number of repeat count allowed
        /// </summary>
        /// <returns>returns nr1 for max repeat counts</returns>
        public void GetSequenceStepRepeatCountMax()
        {
            SequenceStepRepeatCountMax = _pi.GetAwgSequenceStepRepeatCountMax();
        }

        #endregion SLISt:SEQuence:STEP:RCOunt:MAX

        #region SLISt:SEQuence:STEP:TASSet

        //glennj 8/16/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:TASSet? get the waveform name at the specified step and track
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="step"></param>
        /// <param name="track"></param>
        public void GetSequenceStepTrackAsset(string seqName, string step, string track)
        {
            SequenceStepTrackAsset = _pi.GetAwgSequenceStepTrackAsset(seqName, step, track);
        }

        #endregion SLISt:SEQuence:STEP:TASSet

        #region SLISt:SEQuence:STEP:TASSet:SEQuence
        // jmanning 04/09/2014-PASCAL PSR3
        /// <summary>
        /// Using SLISt:SEQuence:STEP:TASSet:SEQuence set a sequence to a step(as a subsequence) and of a sequence
        /// Note:  Applies to all tracks in the sequence
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="stepNumber"></param>
        /// <param name="subSeqName"></param>
        public void SetSequenceStepTrackAssetForSequence(string seqName, string stepNumber, string subSeqName)
        {
            _pi.SetAwgSequenceStepTrackAssetForSequence(seqName, stepNumber, subSeqName);
        }
        #endregion SLISt:SEQuence:STEP:TASSet:SEQuence

        #region SLISt:SEQuence:STEP:TASSet:TYPE
        // jmanning 04/09/2014-PASCAL PSR3
        /// <summary>
        /// Using SLISt:SEQuence:STEP[n]:TASSet[m]:TYPE? get the type of asset assigned to the specified step and track
        /// </summary>
        /// <returns>returns asset type (WAVeform|SEQuence)</returns>
        public void GetSequenceStepTrackAssetType(string seqName, string step, string track)
        {
            SequenceStepTrackAssetType = _pi.GetAwgSequenceStepTrackAssetType(seqName, step, track);
        }
        #endregion SLISt:SEQuence:STEP:TASSet:TYPE

        #region SLISt:SEQuence:STEP:TASSet:WAVeform
        //glennj 8/16/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:TASSet:WAVeform set a wfm to a step and track of a sequence
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="stepNumber"></param>
        /// <param name="trackNumber"></param>
        /// <param name="wfmName"></param>
        public void SetSequenceStepTrackAssetForWaveform(string seqName, string stepNumber, string trackNumber, string wfmName)
        {
            _pi.SetAwgSequenceStepTrackAssetForWaveform(seqName, stepNumber, trackNumber, wfmName);
        }

        #endregion SLISt:SEQuence:STEP:TASSet:WAVeform

        #region SLISt:SEQuence:STEP[n]:TFLag[m]:[ALPHA]FLAG
        // jmanning 04/09/2014-PASCAL PSR3
        /// <summary>
        /// Using SLISt:SEQuence:STEP:TFLag[m]:[ALPHA]FLAG set a flag value of the track in a specific sequence step for the specified flag
        /// flag settings are (NOCHANGE|HIGH|LOW|TOGGLE|PULSE)
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="stepNumber"></param>
        /// <param name="trackNumber"></param>
        /// <param name="flagAlpha">four flags can be set (A|B|C|D)FLAG</param>
        /// <param name="flagSetting">flag settings are (NOCHANGE|HIGH|LOW|TOGGLE|PULSE)</param>
        public void SetSequenceStepTrackFlagValue(string seqName, string stepNumber, string trackNumber, string flagAlpha, string flagSetting)
        {
            _pi.SetAwgSequenceStepTrackFlagValue(seqName, stepNumber, trackNumber, flagAlpha, flagSetting);
        }

        // jmanning 04/09/2014-PASCAL PSR3
        /// <summary>
        /// Using SLISt:SEQuence:STEP:TFLag[m]:[ALPHA]FLAG? gets value of flag for the track in a specific sequence step for the specified flag
        /// </summary>
        /// <returns>returns flag value (NOCHANGE|HIGH|LOW|TOGGLE|PULSE)</returns>
        public void GetSequenceStepTrackFlagValue(string seqName, string stepNumber, string trackNumber, string flagAlpha)
        {
            SequenceStepTrackFlagValue = _pi.GetAwgSequenceStepTrackFlagValue(seqName, stepNumber, trackNumber, flagAlpha);
        }
        #endregion SLISt:SEQuence:STEP[n]:TFLag[m]:[ALPHA]FLAG

        #region SLISt:SEQuence:STEP:TRACk:MAX

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:TRACk:MAX? get maximum number of tracks allowed in a sequence
        /// </summary>
        /// <returns>returns nr1 for max tracks</returns>
        public void GetSequenceStepTrackCountMax()
        {
            SequenceStepTrackCountMax = _pi.GetAwgSequenceStepTrackCountMax();
        }

        #endregion SLISt:SEQuence:STEP:TRACk:MAX

        #region SLISt:SEQuence:STEP:WAVeform

        // Removed as command was changed

        #endregion SLISt:SEQuence:STEP:WAVeform

        #region SLISt:SEQuence:STEP:WINPut

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP[n]:WINPut selects the mode to<para>
        /// listen for trigger signal</para>
        /// </summary>
        /// <param name="seqName">The named sequence</param>
        /// <param name="step">Step from 1 to 16383</param>
        /// <param name="mode">ATRigger|BTRigger|ITRigger|OFF</param>
        public void SetSequenceStepWaitInput(string seqName, string step, string mode)
        {
            _pi.SetAwgSequenceStepWaitInput(seqName, step, mode);
        }

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP[n]:WINPut? get the selected the name of<para>
        /// the waveform at the chosen step.</para>
        /// </summary>
        /// <param name="seqName">The named sequence</param>
        /// <param name="step">Step from 1 to 16383</param>
        /// <returns>wait input mode for a step of a sequence</returns>
        public void GetSequenceStepWaitInput(string seqName, string step)
        {
            SequenceStepWaitInput = _pi.GetAwgSequenceStepWaitInput(seqName, step);
        }

        #endregion SLISt:SEQuence:STEP:WINPut

        #region SLISt:SEQuence:TRACk?

        //glennj 8/15/2013
        /// <summary>
        /// Using SLISt:SEQuence:TRACk? get the number of tracks of the named sequence.
        /// </summary>
        /// <returns>timestamp of named sequence</returns>
        public void GetSequenceTracks(string seqName)
        {
            SequenceNumberOfTracks = _pi.GetAwgSequenceTracks(seqName);
        }

        #endregion SLISt:SEQuence:TRACk?

        #region SLISt:SEQuence:TSTamp

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:TSTamp? get the timestamp of the named sequence.
        /// </summary>
        /// <returns>timestamp of named sequence</returns>
        public void GetSequenceTimestamp(string seqName)
        {
            SequenceTimestamp = _pi.GetAwgSequenceTimestamp(seqName);
        }

        #endregion SLISt:SEQuence:TSTamp

        #region SLISt:SIZE

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SIZE? get the size of the sequence list.
        /// </summary>
        /// <returns>Size of the sequence list</returns>
        public void GetSlistSize()
        {
            SequenceListSize = _pi.GetAwgSlistSize();
        }

        #endregion SLISt:SIZE


        
    }
}
