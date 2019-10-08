

namespace AwgTestFramework
{
    public partial class AWG
    {
        /// <summary>
        /// Property for WLISt:LAST?
        /// </summary>
        public string WaveformListLast { get; set; }
        /// <summary>
        /// Property for WLISt:LIST?
        /// </summary>
        public string WaveformListList { get; set; }
        /// <summary>
        /// Property for WLISt:NAME?
        /// </summary>
        public string WaveformListName { get; set; }
        /// <summary>
        /// Property for WLISt:SIZE?
        /// </summary>
        public string WaveformListSize { get; set; }
        /// <summary>
        /// Property for WLISt:WAVeform:DATA?<para>
        /// Please note that this should contain minimal string sizes</para>
        /// </summary>
        public byte[] WaveformListData { get; set; }
        /// <summary>
        /// Property for WLISt:WAVeform:GRANularity?
        /// </summary>
        public string WaveformListGranularity { get; set; }
        /// <summary>
        /// Property for WLISt:WAVeform:LMAXimum?
        /// </summary>
        public string WaveformListMaxSamplepoints { get; set; }
        /// <summary>
        /// Property for WLISt:WAVeform:LMINimum?
        /// </summary>
        public string WaveformListMinSamplepoints { get; set; }
        /// <summary>
        /// Property for WLISt:WAVeform:LENGth?
        /// </summary>
        public string WaveformListLength { get; set; }
        /// <summary>
        /// Property for WLISt:WAVeform:MARKer:DATA?<para>
        /// Please note that this should contain minimal string sizes</para>
        /// </summary>
        public string WaveformListMarkerData { get; set; }
        /// <summary>
        /// Property for WLIST:WAVeform:TSTamp?
        /// </summary>
        public string WaveformListTimestamp { get; set; }
        /// <summary>
        /// Property for WLIST:WAVeform:TYPE?
        /// </summary>
        public string WaveformListType { get; set; }

        /// <summary>
        /// Property to contain the response from WLISt:WAVeform:SFORmat?
        /// </summary>>

        public string signalFormatQueried { get; set; }
        ///<summary>
        ///
        ///</summary>
        public string WaveformSRqueried { get; set; }

        

        #region WLISt:LAST

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:LAST? to update WaveformListLast with the<para>
        /// last added names of the waveforms to the waveform list.</para>
        /// </summary>
        /// <returns></returns>
        public void GetWListLast()
        {
            WaveformListLast = _pi.GetAwgWListLast();
        }

        #endregion WLISt:LAST

        #region WLISt:LIST

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:LIST? return the names of the waveforms in the waveform list.<para>
        /// Note.  Limited usage due limit of return string sizes.</para><para>
        /// Not published.  Manufacturing usage only.</para>
        /// </summary>
        /// <returns></returns>
        public void GetWListList()
        {
            WaveformListList = _pi.GetAwgWListList();
        }

        #endregion WLISt:LIST

        #region WLISt:NAME

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:NAME? to update the WaveformListName property<para>
        /// for the name of the waveform of an element in the waveform list</para>
        /// </summary>
        /// <param name="listIndex">Index of the waveform in the waveform list</param>
        /// <returns></returns>
        public void GetWlistName(string listIndex)
        {
            WaveformListName = _pi.GetAwgWlistName(listIndex);
        }

        #endregion WLISt:NAME

        #region WLISt:SIZE

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:SIZE? to update the WaveformListSize<para>
        /// property of the size of the waveform list.</para>
        /// </summary>
        /// <returns></returns>
        public void GetWlistSize()
        {
            WaveformListSize = _pi.GetAwgWlistSize();
        }

        #endregion WLISt:SIZE

        #region WLISt:WAVeform:SFORmat

        //Keerthi 05/28/2015
        /// <summary>
        /// Using WLISt:WAVeform:SFORmat sets the signal format for the waveform to (I/Q/REAL/UND)
        /// </summary>
        /// <param name="signalFormat">Signal format type (I/Q/REAL/UND)</param>
        /// <param name="wfmName">Name of the waveform</param>
        /// <param name="awg">specific awg</param>


        public void SetSignalFormat(string signalFormat, string wfmName, IAWG awg)
        {

            _pi.SetSignalFormat(signalFormat, wfmName, awg);
        }

        #endregion WLISt:WAVeform:SFORmat



        #region WLISt:WAVeform:SFORmat?

        //Keerthi 05/28/2015
        /// <summary>
        /// Using WLISt:WAVeform:SFORmat? Gets the signal format for a given waveform name and assign to the string Signalformatqueried 
        /// </summary>
        /// <param name="wfmName">Name of the waveform</param>

        public void GetSignalFormat(string wfmName)
        {

            signalFormatQueried = _pi.GetSignalFormat(wfmName);
        }

       #endregion WLISt:WAVeform:SFORmat?

        #region WLISt:WAVeform:DATA

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:WAVeform:DATA transfer waveform data from the external controller into the waveform list
        /// </summary>
        /// <param name="wfmName"></param>
        /// <param name="startIndex"></param>
        /// <param name="size"></param>
        /// <param name="thisBlockData"></param>
        public void SetWListWaveformData(string wfmName, string startIndex, string size, string thisBlockData)
        {
            _pi.SetAwgWListWaveformData(wfmName, startIndex, size, thisBlockData);
        }

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:WAVeform:DATA transfer waveform data from the external controller into the waveform list
        /// </summary>
        /// <param name="wfmName"></param>
        /// <param name="startIndex"></param>
        /// <param name="size"></param>
        /// <param name="thisBlockData"></param>
        public void SetWListWaveformPieceData(string wfmName, string startIndex, string size, string thisBlockData)
        {
            _pi.SetAwgWListWaveformPieceData(wfmName, startIndex, size, thisBlockData);
        }

        /// <summary>
        /// Using WLISt:WAVeform:DATA? update WaveformListData<para>
        /// property with waveform data from the waveform list</para>
        /// </summary>
        /// <param name="wfmName"></param>
        /// <param name="startIndex"></param>
        /// <param name="size"></param>
        public void GetWListWaveformData(string wfmName, string startIndex, string size) 
        {
            WaveformListData = _pi.GetAwgWListWaveformData(wfmName, startIndex, size);
        }

        #endregion WLISt:WAVeform:DATA

        #region WLISt:WAVeform:DELete

        //glennj 7/25/2013
        /// <summary>
        /// Using WLIST:WAVeform:DELete delete the named waveform from the waveform list
        /// </summary>
        /// <param name="wfmName">Name of the waveform to delete</param>
        public void WListWaveformDelete(string wfmName)
        {
            _pi.AwgWListWaveformDelete(wfmName);
        }

        #endregion WLISt:WAVeform:DELete

        #region WLISt:WAVeform:GRANularity

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:WAVeform:GRANularity? update the WaveformListGranularity<para>
        /// property for the required granularity for a valid waveform</para> 
        /// </summary>
        /// <returns></returns>
        public void GetWaveformGranularity()
        {
            WaveformListGranularity = _pi.GetAwgWaveformGranularity();
        }

        #endregion WLISt:WAVeform:GRANularity

        #region WLISt:WAVeform:LMAXimum

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:WAVeform:LMAXimum? update the WaveformListMaxSamplepoints property
        ///</summary>
        /// <returns></returns>
        public void GetWlistMaxSamplePoints()
        {
            WaveformListMaxSamplepoints = _pi.GetAwgWlistMaxSamplePoints();
        }

        #endregion WLISt:WAVeform:LMAXimum

        #region WLISt:WAVeform:LMINimum

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:WAVeform:LMINimum? update the WaveformListMinSamplepoints property
        /// </summary>
        /// <returns></returns>
        public void GetWlistMinSamplePoints()
        {
            WaveformListMinSamplepoints = _pi.GetAwgWlistMinSamplePoints();
        }

        #endregion WLISt:WAVeform:LMINimum
        
        #region WLISt:WAVeform:LENGth

        //glennj 7/25/2013
        /// <summary>
        /// Using WLIST:WAVeform:LENGth? to update the WaveformListLength<para>
        /// property for the size of the given waveform</para>
        /// </summary>
        /// <param name="wfmName">Name of the waveform to get the length of</param>
        /// <returns></returns>
        public void GetWListWaveformLength(string wfmName)
        {
            WaveformListLength = _pi.GetAwgWListWaveformLength(wfmName);
        }

        #endregion WLISt:WAVeform:LENGth

        #region WLISt:WAVeform:MARKer:DATA

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:WAVeform:MARKer:DATA transfer marker data<para>
        /// from the external controller into the waveform list</para>
        /// </summary>
        /// <param name="wfmName"></param>
        /// <param name="startIndex"></param>
        /// <param name="size"></param>
        /// <param name="thisBlockData"></param>
        /// <returns>Minimum granularity for a waveform </returns>
        public void SetWaveformMarkerData(string wfmName, string startIndex, string size, string thisBlockData)
        {
            _pi.SetAwgWaveformMarkerData(wfmName, startIndex, size, thisBlockData);
        }

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:WAVeform:MARKer:DATA? update the WaveformListMarkerData<para>
        /// property for the waveform marker data</para>
        /// </summary>
        /// <returns>Minimum granularity for a waveform </returns>
        public void GetWaveformMarkerData(string wfmName, string startIndex, string size)
        {
            WaveformListMarkerData = _pi.GetAwgWaveformMarkerData(wfmName, startIndex, size);
        }

        #endregion WLISt:WAVeform:MARKer:DATA

        #region WLISt:WAVeform:NEW

        //glennj 7/25/2013
        /// <summary>
        /// Using WLISt:WAVeform:NEW create a new waveform of the given size and the given name
        /// </summary>
        /// <param name="wfmName">Name of the new waveform</param>
        /// <param name="size">Save of the new waveform</param>
        public void CreateNewWListWaveform(string wfmName, string size)
        {
            _pi.CreateAwgWListWaveformNew(wfmName, size);
        }

        #endregion WLISt:WAVeform:NEW

        #region WLISt:WAVeform:NORMalize

        //glennj 7/25/2013
        /// <summary>
        /// Using WLIST:WAVeform:NORMalize normalizes a waveform that exists in the waveform list
        /// </summary>
        /// <param name="wfmName">Waveform to normalize</param>
        /// <param name="normType">Noramlization type</param>
        public void WListWaveformNormalize(string wfmName, string normType)
        {
            _pi.AwgWListWaveformNormalize(wfmName, normType);
        }

        #endregion WLISt:WAVeform:NORMalize

        #region WLISt:WAVeform:RESAmple

        //glennj 7/25/2013
        /// <summary>
        /// Using WLIST:WAVeform:RESAmple resamples a waveform that exists in the waveform list
        /// </summary>
        /// <param name="wfmName">Waveform to normalize</param>
        /// <param name="size">Number of points to resample to</param>
        public void WListWaveformResample(string wfmName, string size)
        {
            _pi.AwgWListWaveformResample(wfmName, size);
        }

        #endregion WLISt:WAVeform:RESAmple

        #region WLISt:WAVeform:SHIFt

        //glennj 7/25/2013
        /// <summary>
        /// Using WLIST:WAVeform:SHIFt shift a waveform that exists in the waveform list
        /// </summary>
        /// <param name="wfmName">Waveform to normalize</param>
        /// <param name="phase">Number of degrees to shift</param>
        public void WListWaveformShift(string wfmName, string phase)
        {
            _pi.AwgWListWaveformShift(wfmName, phase);
        }

        #endregion WLISt:WAVeform:SHIFt

        #region WLISt:WAVeform:TSTamp

        //glennj 7/25/2013
        /// <summary>
        /// Using WLIST:WAVeform:TSTamp? update the property WaveformListTimestamp for the given waveform
        /// </summary>
        /// <param name="wfmName">Name of the waveform to get the timestamp of</param>
        /// <returns>The timestamp of the waveform</returns>
        public void GetWListWaveformTimestamp(string wfmName)
        {
            WaveformListTimestamp = _pi.GetAwgWListWaveformTimestamp(wfmName);
        }

        #endregion WLISt:WAVeform:TSTamp

        #region WLISt:WAVeform:TYPE

        //glennj 7/25/2013
        /// <summary>
        /// Using WLIST:WAVeform:TYPE? update the property WaveformListType for the given waveform
        /// </summary>
        /// <param name="wfmName">Name of the waveform to get the type of</param>
        /// <returns>The type of the waveform (Always REAL)</returns>
        public void GetWListWaveformType(string wfmName)
        {
            WaveformListType = _pi.GetAwgWListWaveformType( wfmName);
        }

        #endregion WLISt:WAVeform:TYPE

        #region WLISt:WAVeform:SRATe

        //sdas2 5/28/2015
        /// <summary>
        /// Using WLIST:WAVeform:SRATe set the sample rate of the given waveform
        /// </summary>
        /// <wfmName>Name of the waveform </wfmName>
        /// <sRate>Sample rate set for the waveform</sRate>
        public void SetWListWaveformSrate(string wfmName, string sRate)
        {
            _pi.SetAwgSamplingRate(wfmName, sRate);
               
        }

        //sdas2 5/28/2015
        /// <summary>
        /// Using WLIST:WAVeform:SRATe? Query the sample rate of the given waveform
        /// </summary>
        /// <wfmName>Name of the waveform </wfmName>
        ///<returns>Always return the Sampling rate of the Specific Waveform</returns>
        public void GetWListWaveformSrate(string wfmName)
        {
            WaveformSRqueried = _pi.GetAwgWListWaveformSRATe(wfmName);
        }

        #endregion WLISt:WAVeform:SRATe

    }
}
