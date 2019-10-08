

namespace AwgTestFramework
{
    public partial class CPi70KCmds
    {
        #region Sequence

        #region SLIST

        #region SLISt:NAME

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:NAME? get the name of the sequence of an element in the sequence list
        /// </summary>
        /// <param name="listIndex">Index of the sequence in the sequence list</param>
        /// <returns>The name of the waveform</returns>
        public string GetAwgSlistName(string listIndex)
        {
            string response;
            string commandLine = "SLISt:NAME? " + listIndex;
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion SLISt:NAME

        #region SLISt:SEQuence:DELete

        //glennj 8/9/2013
        /// <summary>
        /// Using SLIST:SEQuence:DELete delete the sequence from the sequence list
        /// </summary>
        /// <param name="seqName">Name of the sequence to delete</param>
        /// <param name="addQuotes">only non-keywords need quotes</param>
        public void DeleteAwgSListSequence(string seqName, bool addQuotes)
        {
            string commandLine;
            if (addQuotes)
            {
                commandLine = "SLISt:SEQuence:DELete " + '"' + seqName + '"';
            }
            else
            {
                commandLine = "SLISt:SEQuence:DELete "       + seqName ;
            }
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion SLISt:SEQuence:DELete

        #region SLISt:SEQuence:EVENt:PJUMp:ENABle

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:EVENt:PJUMp:ENABle set the event pattern jump enable
        /// </summary>
        public void SetAwgSequenceEventPatternJumpEnable(string seqName, string enableState)
        {
            string commandLine = "SLISt:SEQuence:EVENt:PJUMp:ENABle " + '"' + seqName + '"' + ',' + enableState;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:EVENt:PJUMp:ENABle? get the event pattern jump enable
        /// </summary>
        /// <returns>event pattern jump enable</returns>
        public string GetAwgSequenceEventPatternJumpEnable(string seqName)
        {
            string response;
            var commandLine = "SLISt:SEQuence:EVENt:PJUMp:ENABle? " + '"' + seqName + '"';
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
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
        public void SetAwgSequenceEventPatternJumpDefine(string seqName, string pattern, string jumpStep)
        {
            var commandLine = "SLISt:SEQuence:EVENt:PJUMp:DEFine " + '"' + seqName + '"' + ',' + pattern + ',' + jumpStep;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:EVENt:PJUMp:DEFine? get the jump step associated to the specified pattern
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="pattern"></param>
        /// <returns>event pattern jump enable</returns>
        public string GetAwgSequenceEventPatternJumpDefine(string seqName, string pattern)
        {
            string response;
            var commandLine = "SLISt:SEQuence:EVENt:PJUMp:DEFine? " + '"' + seqName + '"' + ',' + pattern;
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion SLISt:SEQuence:EVENt:PJUMp:DEFine

        #region SLISt:SEQuence:EVENt:PJUMp:SIZE

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:EVENt:PJUMp:SIZE? get the maximum number of entries in the pattern jump table
        /// </summary>
        /// <returns>event pattern jump enable</returns>
        public string GetAwgSequenceEventPatternJumpSize()
        {
            string response;
            const string commandLine = "SLISt:SEQuence:EVENt:PJUMp:SIZE?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
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
        public void SetAwgSequenceEventPatternJumpTiming(string seqName, string mode)
        {
            var commandLine = "SLISt:SEQuence:EVENt:JTIMing " + '"' + seqName + '"' + ',' + mode;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:EVENt:JTIMing? get the mode for how the sequencer<para>
        /// will respond to a logic event, pattern jump or a software</para><para>
        /// force jump.</para>
        /// </summary>
        /// <param name="seqName"></param>
        /// <returns>event pattern jump enable</returns>
        public string GetAwgSequenceEventPatternJumpTiming(string seqName)
        {
            string response;
            var commandLine = "SLISt:SEQuence:EVENt:JTIMing? " + '"' + seqName + '"';
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion SLISt:SEQuence:EVENt:JTIMing

        #region SLISt:SEQuence:LENGth

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:LENGth? get the length of the named sequence.
        /// </summary>
        /// <returns>length of named sequence</returns>
        public string GetAwgSequenceLength(string seqName)
        {
            string response;
            //var command = "SLISt:SEQuence:LENGth? " + '"' + seqName + '"';
            var  commandLine = "SLIS:SEQ:LENG? " + '"' + seqName + '"';
            _mAWGVisaSession.Query( commandLine, out response);
            return response;
        }

        #endregion SLISt:SEQuence:LENGth

        #region SLISt:SEQuence:NEW

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:NEW create a new sequence of the given size and the given name
        /// </summary>
        /// <param name="seqName">Name of the new sequence</param>
        /// <param name="size">Save of the new sequence</param>
        /// <param name="tracks">optional number of tracks may be specified</param>
        public void CreateAwgSListSequenceNew(string seqName, string size, string tracks = "")
        {
            string commandLine = "SLISt:SEQuence:NEW " + '"' + seqName + '"' + ',' + size;
            if (tracks != "")
            {
                commandLine += ',' + tracks;
            }
            _mAWGVisaSession.Write(commandLine);
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

           string commandLine = "SLISt:SEQuence:STEP:ADD " + '"' + seqName + '"' + ',' + addAtWhatStep + ',' + addToSeqStep;

            _mAWGVisaSession.Write(commandLine);
        }

        #endregion

        //#region WLISt:WAVeform:SFORmat


        //public void addingwlistsignalformat(string signalformat, string wfmName, IAWG awg)
        //{

        //    string commandLine = "WLISt:WAVeform:SFORmat " + '"' + wfmName + '"' + ',' + signalformat;
        //    _mAWGVisaSession.Write(commandLine);
        //}

        //public string Newsignalformatshouldbe(string wfmname)
        //{
        //    string response;
        //    var commandLine = "WLIST:WAVEFORM:SFORMAT? " + '"' + wfmname + '"';
        //    _mAWGVisaSession.Query(commandLine, out response);
        //    return response;
        //}


        //#endregion WLISt:WAVeform:SFORmat

        #region SLISt:SEQuence:RFLag
        /// <summary>
        /// Using SLISt:SEQuence:STEP:RFlag set the enable flag repeat on or off
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="mode">ON|OFF|0|1</param>
        public void SetAwgSequenceRepeatFlag(string seqName, string mode)
        {
            var commandLine = "SLISt:SEQuence:RFLag ";
            commandLine += '"' + seqName + '"' + ',' + mode;
            _mAWGVisaSession.Write(commandLine);
        }

        /// <summary>
        /// Using SLISt:SEQuence:STEP:RFlag?  gets the enable flag repeat state on or off
        /// </summary>
        /// <param name="seqName"></param>
        /// <returns>state of enable flag repeat setting</returns>
        public string GetAwgSequenceRepeatFlag(string seqName)
        {
            string response;
            var commandLine = "SLISt:SEQuence:RFLag? ";
            commandLine += '"' + seqName + '"';
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
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
        public void SetAwgSequenceStepEventJumpOperation(string seqName, string mode, string step)
        {
            var commandLine = "SLISt:SEQuence:STEP" + step;
            commandLine += ":EJUMp " + '"' + seqName + '"' + ',' + mode;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:EJUMp? get the step or step action for the<para>
        /// sequencer's event jump operation.</para>
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="step">Step from 1 to 16383</param>
        /// <returns>event jump operation mode</returns>
        public string GetAwgSequenceStepEventJumpOperation(string seqName, string step)
        {
            string response;
            var commandLine = "SLISt:SEQuence:STEP" + step;
            commandLine += ":EJUMp? " + '"' + seqName + '"';
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion SLISt:SEQuence:STEP:EJUMp

        #region SLISt:SEQuence:STEP:EJINput

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:EJINput selects the event jump input mode
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="step">Step from 1 to 16383</param>
        /// <param name="mode">ATRigger|BTRigger|ITRigger|OFF</param>
        public void SetAwgSequenceStepEventJumpInput(string seqName, string step, string mode) 
        {
            var commandLine = "SLISt:SEQuence:STEP" + step;
            commandLine += ":EJINput " + '"' + seqName + '"' + ',' + mode;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:EJINput? get the selected event jump input
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="step">Step from 1 to 16383</param>
        /// <returns>event jump operation mode</returns>
        public string GetAwgSequenceStepEventJumpInput(string seqName, string step)
        {
            string response;
            var commandLine = "SLISt:SEQuence:STEP" + step;
            commandLine += ":EJINput? " + '"' + seqName + '"';
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
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
        public void SetAwgSequenceStepGoto(string seqName, string step, string mode)
        {
            var commandLine = "SLISt:SEQuence:STEP" + step;
            commandLine += ":GOTO " + '"' + seqName + '"' + ',' + mode;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:GOTO? get the target step for the GOTO command<para>
        /// of the sequencer at the current step</para>
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="step"></param>
        /// <returns>event jump operation mode</returns>
        public string GetAwgSequenceStepGoto(string seqName, string step)
        {
            string response;
            var commandLine = "SLISt:SEQuence:STEP" + step;
            commandLine += ":GOTO? " + '"' + seqName + '"';
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion SLISt:SEQuence:STEP:GOTO

        #region SLISt:SEQuence:STEP:MAX

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:MAX? get maximum number of steps allowed in a sequence
        /// </summary>
        /// <returns>maximum number of steps allowed as an nr1</returns>
        public string GetAwgSequenceStepMax()
        {
            string response;
            const string commandLine = "SLISt:SEQuence:STEP:MAX?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
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
        public void SetAwgSequenceStepRepeatCount(string seqName, string step, string mode)
        {
            var commandLine = "SLISt:SEQuence:STEP" + step;
            commandLine += ":RCOunt " + '"' + seqName + '"' + ',' + mode;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:RCOunt? get the repeat count
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="step">Step from 1 to 16383</param>
        /// <returns>repeat mode or count</returns>
        public string GetAwgSequenceStepRepeatCount(string seqName, string step)
        {
            string response;
            var commandLine = "SLISt:SEQuence:STEP" + step;
            commandLine += ":RCOunt? " + '"' + seqName + '"';
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion SLISt:SEQuence:STEP:RCOunt

        #region SLISt:SEQuence:STEP:RCOunt:MAX

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:RCOunt:MAX? get maximum number of repeat count allowed
        /// </summary>
        /// <returns>returns nr1 for max repeat counts</returns>
        public string GetAwgSequenceStepRepeatCountMax()
        {
            string response;
            const string commandLine = "SLISt:SEQuence:STEP:RCOunt:MAX? ";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion SLISt:SEQuence:STEP:RCOunt:MAX

        #region SLISt:SEQuence:STEP:TASSet

        //glennj 8/16/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:TASSet? get the waveform name at the specified step and track
        /// </summary>
        /// <returns>returns nr1 for max repeat counts</returns>
        public string GetAwgSequenceStepTrackAsset(string seqName, string step, string track)
        {
            string response;
            var commandLine = "SLISt:SEQuence:STEP" + step;
            commandLine += ":TASSet" + track + "? " + '"' + seqName + '"';
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
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
        public void SetAwgSequenceStepTrackAssetForSequence(string seqName, string stepNumber, string subSeqName)
        {
            var commandLine = "SLISt:SEQuence:STEP" + stepNumber;
            commandLine += ":TASSet";
            commandLine += ":SEQuence " + '"' + seqName + '"';
            commandLine += "," + '"' + subSeqName + '"';
            _mAWGVisaSession.Write(commandLine);
        }
        #endregion SLISt:SEQuence:STEP:TASSet:SEQuence

        #region SLISt:SEQuence:STEP:TASSet:TYPE
        // jmanning 04/09/2014-PASCAL PSR3
        /// <summary>
        /// Using SLISt:SEQuence:STEP[n]:TASSet[m]:TYPE? get the type of asset assigned to the specified step and track
        /// </summary>
        /// <returns>returns asset type (WAVeform|SEQuence)</returns>
        public string GetAwgSequenceStepTrackAssetType(string seqName, string step, string track)
        {
            string response;
            var commandLine = "SLISt:SEQuence:STEP" + step;
            commandLine += ":TASSet" + track;
            commandLine += ":TYPE? " + '"' + seqName + '"';
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
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
        public void SetAwgSequenceStepTrackAssetForWaveform(string seqName, string stepNumber, string trackNumber, string wfmName)
        {
            var commandLine = "SLISt:SEQuence:STEP" + stepNumber;
            commandLine    += ":TASSet" + trackNumber;
            commandLine    += ":WAVeform " + '"' + seqName + '"';
            commandLine    += "," + '"' + wfmName + '"';
            _mAWGVisaSession.Write(commandLine);
        }
        #endregion SLISt:SEQuence:STEP:TASSet:WAVeform

        #region SLISt:SEQuence:STEP[n]:TFLag[m]:[ALPHA]FLag
        // jmanning 04/09/2014-PASCAL PSR3
        /// <summary>
        /// Using SLISt:SEQuence:STEP[n]:TFLag[m]:[APLHA]FLAG set a flag value of the track in a specific sequence step for the specified flag
        /// </summary>
        /// <param name="seqName"></param>
        /// <param name="stepNumber"></param>
        /// <param name="trackNumber"></param>
        /// <param name="flagAlpha">four flags can be set (A|B|C|D)FLAG</param>
        /// <param name="flagSetting">flag settings are (NOCHANGE|HIGH|LOW|TOGGLE|PULSE)</param>
        public void SetAwgSequenceStepTrackFlagValue(string seqName, string stepNumber, string trackNumber, string flagAlpha, string flagSetting)
        {
            var commandLine = "SLISt:SEQuence:STEP" + stepNumber;
            commandLine += ":TFLag" + trackNumber;
            commandLine += ":" + flagAlpha + "FLag ";
            commandLine += '"' + seqName + '"';
            commandLine += "," + flagSetting;
            _mAWGVisaSession.Write(commandLine);
        }

        // jmanning 04/09/2014-PASCAL PSR3
        /// <summary>
        /// Using SLISt:SEQuence:STEP[n]:TFLag[m]:[ALPHA]FLag? gets value of flag for the track in a specific sequence step for the specified flag
        /// </summary>
        /// <returns>returns flag value (NOCHANGE|HIGH|LOW|TOGGLE|PULSE)</returns>
        public string GetAwgSequenceStepTrackFlagValue(string seqName, string stepNumber, string trackNumber, string flagAlpha)
        {
            string response;
            var commandLine = "SLISt:SEQuence:STEP" + stepNumber;
            commandLine += ":TFLag" + trackNumber;
            commandLine += ":" + flagAlpha + "FLag? ";
            commandLine += '"' + seqName + '"';
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion SLISt:SEQuence:STEP[n]:TFLag[m]:[ALPHA]FLag

        #region SLISt:SEQuence:STEP:WAVeform
        // obsolete
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
        public void SetAwgSequenceStepWaitInput(string seqName, string step, string mode)
        {
            var commandLine = "SLISt:SEQuence:STEP" + step;
            commandLine += ":WINPut " + '"' + seqName + '"' + ',' + mode;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP[n]:WINPut? get the selected the name of<para>
        /// the waveform at the chosen step.</para>
        /// </summary>
        /// <param name="seqName">The named sequence</param>
        /// <param name="step">Step from 1 to 16383</param>
        /// <returns>wait input mode for a step of a sequence</returns>
        public string GetAwgSequenceStepWaitInput(string seqName, string step)
        {
            string response;
            var commandLine = "SLISt:SEQuence:STEP" + step;
            commandLine += ":WINPut? " + '"' + seqName + '"';
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion SLISt:SEQuence:STEP:WINPut

        #region SLISt:SEQuence:TRACk?

        //glennj 8/15/2013
        /// <summary>
        /// Using SLISt:SEQuence:TRACk? get the number of tracks of the named sequence.
        /// </summary>
        /// <returns>timestamp of named sequence</returns>
        public string GetAwgSequenceTracks(string seqName)
        {
            string response;
            var  commandLine = "SLISt:SEQuence:TRACk? " + '"' + seqName + '"';
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion SLISt:SEQuence:TRACk?

        #region SLISt:SEQuence:TRACk:MAX

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:STEP:TRACk:MAX? get maximum number of tracks allowed in a sequence
        /// </summary>
        /// <returns>returns nr1 for max tracks</returns>
        public string GetAwgSequenceStepTrackCountMax()
        {
            string response;
            const string commandLine = "SLISt:SEQuence:TRACk:MAX?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion SLISt:SEQuence:TRACk:MAX

        #region SLISt:SEQuence:TSTamp

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SEQuence:TSTamp? get the timestamp of the named sequence.
        /// </summary>
        /// <returns>timestamp of named sequence</returns>
        public string GetAwgSequenceTimestamp(string seqName)
        {
            string response;
            var  commandLine = "SLISt:SEQuence:TSTamp? " + '"' + seqName + '"';
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion SLISt:SEQuence:TSTamp

        #region SLISt:SIZE

        //glennj 8/9/2013
        /// <summary>
        /// Using SLISt:SIZE? get the size of the sequence list.
        /// </summary>
        /// <returns>Size of the sequence list</returns>
        public string GetAwgSlistSize()
        {
            string response;
            const string  commandLine = "SLISt:SIZE?";
            _mAWGVisaSession.Query( commandLine, out response);
            return response;
        }

        #endregion SLISt:SIZE

        #endregion SLIST

        #endregion Sequence
    }
}
