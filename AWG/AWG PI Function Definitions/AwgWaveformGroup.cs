//==========================================================================
// AwgWaveformGroup.cs
//==========================================================================

using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains helper functions that are called from the %AWG Waveform PI step definitions.
    /// This class has no restrictions as to where it will be used.
    /// 
    /// This "Helper" group does everything else but steps and TekVISA.
    /// Using parameters from the step, each helper will makes decisions
    /// such as send commands, or process responses from queries and
    /// do testing and generate asserts if necessary.
    /// 
    /// \ingroup grouphelperpi pisteps 
    /// 
    /// 
    /// </summary>
    public class AwgWaveformGroup
    {
        public enum WaveformNormalized { FullScale, ZeroOffset}
        public enum WaveformType {Real}

        public enum WaveformData {AnalogOnly, MarkersOnly, Both}

        private readonly UTILS _utils = new UTILS();
        readonly AwgSystemGroup _awgSystemGroup = new AwgSystemGroup();
 
        #region WLISt:LAST

        public void GetNameofLastAddedWfmInWfmList(IAWG awg)
        {
            awg.GetWListLast();
        }

        public void LastAddedWaveformNameShouldBe(IAWG awg, string expectedValue)
        {
            if (expectedValue != "")
            {
                expectedValue = _utils.Quotify(expectedValue);//Waveform name comes back with quotes, need to add them to match
            }
            Assert.AreEqual(expectedValue, awg.WaveformListLast);
        }
        #endregion WLISt:LAST

        #region WLIST:LIST

        //glennj 7/26/2013
        // This is a manufacturing only query due to limitiations of return string length.
        // The end user must brute force through the list by getting the size of the list
        // and then get the waveform individually to get an equivalent result.

        public void GetTheWaveformList(IAWG awg)
        {
            awg.GetWListList();
        }

        // Unkown - 01/01/01
        /// <summary>
        /// Checks that the waveform list on the specified %AWG contains all the same waveforms
        /// as the specified waveform list 
        /// </summary>
        /// <param name="awg">The specified AWG</param>
        /// <param name="listWfms">The specified waveform list</param>
        public void WfmListShouldContainTheseWfms(IAWG awg, string listWfms)
        {
            string awgWfmListStr = awg.WaveformListList.Remove(0, 1);
            //Need to remove the quotes around the list before the items are sorted
            awgWfmListStr = awgWfmListStr.Remove(awgWfmListStr.Length - 1, 1);
            string[] awgTest = awgWfmListStr.Split(',');
            string[] givenTest = listWfms.Split(',');
            //Assuming the waveforms will not be in the same order so they need to be sorted
            Array.Sort(awgTest);
            Array.Sort(givenTest);
            awgWfmListStr = awgTest.ToString(); //Smash back into a string to make a easier comparison
            string givenListStr = givenTest.ToString();
            Assert.AreEqual(givenListStr, awgWfmListStr);
        }

        #endregion WLIST:LIST

        #region WLISt:NAME
        public void GetWaveformAtIndex(IAWG awg, string listIndex)
        {
            awg.GetWlistName(listIndex);
        }

        public void WaveformNameAtIndexShouldBe(IAWG awg, string expectedValue)
        {
            if (expectedValue != "")
            {
                expectedValue = _utils.Quotify(expectedValue);
                //Waveform name comes back with quotes, need to add them to match
            }
            Assert.AreEqual(expectedValue, awg.WaveformListName);
        }

        /// <summary>
        /// This depends on the content of Waveform list of lists<para>
        /// It will use whatever is in the list to check against.</para><para>
        /// It does not look for duplicates.  Though there shouldn't be</para><para>
        /// but this isn't testing for accuracy of the list at the moment.</para><para>
        /// Code generates an error of the expected waveform name is not found.</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedWfmName"></param>
        /// <param name="toIncludeOrNotToInclude">True to include, False should not be included</param>
        public void WaveformNameShouldBeIncluded(IAWG awg , string expectedWfmName, bool toIncludeOrNotToInclude )
        {
            string dequotified = _utils.Dequotify(awg.WaveformListList);
            string[] wfmNames = dequotified.Split(',');

            bool notFound = true;

            foreach (var wfmName in wfmNames)
            {
                if (wfmName == expectedWfmName)
                {
                    if (toIncludeOrNotToInclude)
                    {
                        notFound = false;
                        break;            
                    }
                }
            }

            if (toIncludeOrNotToInclude)
            {
                Assert.IsFalse(notFound, "Waveform name was not found:" + expectedWfmName);
            }
            else
            {
                Assert.IsTrue(notFound, "Waveform name was found:" + expectedWfmName);
            }
        }

        #endregion WLISt:NAME

        #region WLISt:SIZE

        public void GetNumberOfWaveformListEntries(IAWG awg)
        {
            awg.GetWlistSize();
        }

        public void ShouldBeAGivenNumberOfEntriesInWfmList(IAWG awg, string expectedValue)
        {
            Assert.AreEqual(expectedValue, awg.WaveformListSize);
        }
        #endregion WLISt:SIZE

        #region WLISt:WAVeform:SFORmat


        //Keerthi 05/28/2015
        /// <summary>
        /// Using WLISt:WAVeform:SFORmat sets the signal format for the waveform
        /// </summary>
        /// <param name="signalFormat">Signal format type (I/Q/REAL/UND)</param>
        /// <param name="wfmName">Name of the waveform</param>
        /// <param name="awg">specific awg</param>


        public void SetSignalFormat(string signalFormat, string wfmName, IAWG awg)
        {

            awg.SetSignalFormat(signalFormat, wfmName, awg);
        }

        #endregion WLISt:WAVeform:SFORmat

        #region WLISt:WAVeform:SFORmat?


       //Keerthi 05/28/2015
       /// <summary>
       /// Using WLISt:WAVeform:SFORmat? Gets the signal format for a given waveform name
       /// </summary>
       /// <param name="wfmName">Name of the waveform</param>
       /// <param name="awg">specific awg</param>

        public void GetSignalFormat(string wfmName, IAWG awg)
        {

            awg.GetSignalFormat(wfmName);

        }

        //Keerthi 05/28/2015
        /// <summary>
        /// Compare the signal format type against the expected value
        /// </summary>
        /// <param name="expectedSignalFormat">Name of the waveform</param>
        /// <param name="awg">specific awg</param>
        /// 
        public void SignalFormatShouldBe(string expectedSignalFormat, IAWG awg)
        {
            Assert.AreEqual(expectedSignalFormat, awg.signalFormatQueried);

        }

        #endregion WLISt:WAVeform:SFORmat?


        #region WLISt:WAVeform:DATA

        /// <summary>
        /// Assumes that data is floating point and needs to be converted in to a block to be transferred.<para>
        /// It does not take apart the original file and break into blocks.</para><para>
        /// The parameters passed are the parameters to be sent in the PI command to where this</para><para>
        /// block goes in the destination waveform.</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="wfmName"></param>
        /// <param name="filePath"></param>
        /// <param name="dataType"></param>
        /// <param name="startIndex"></param>
        /// <param name="blockSize"></param>
        public void TransferWaveformDataFromPath(IAWG awg, string wfmName, string filePath, WaveformData dataType, string startIndex = "", string blockSize = "")
        {
            string blockOfData = "";
            try
            {
                if (File.Exists(filePath))
                {
                    // Get a line of text.  It assumes(?) that each line has 3 fields.
                    // The first field is the analog value.  For the first pass, this is what we are interested in.
                    foreach (string line in File.ReadLines(filePath))
                    {
                        if (dataType == WaveformData.AnalogOnly)
                        {
                            string[] divided = line.Split(',');
                            if (blockOfData != "") blockOfData += ",";
                            blockOfData += divided[0];
                        }
                    }
                }
                else
                {
                    Assert.Fail("File " + filePath + " does not exist");
                }

                // A string of floats (first pass at implementation) has been extracted.
                // Off we go to the next step
                awg.SetWListWaveformData(wfmName, startIndex, blockSize, blockOfData);
            }
            catch (Exception ex)
            {
                Assert.Fail("Reading file has failed because " + ex.Message);
            }
        }

        /// <summary>
        /// Assumes that data is floating point and needs to be converted in to a block to be transferred.<para>
        /// It does not take apart the original file and break into blocks.</para><para>
        /// The parameters passed are the parameters to be sent in the PI command to where this</para><para>
        /// block goes in the destination waveform.</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="wfmName"></param>
        /// <param name="filePath"></param>
        /// <param name="startIndex"></param>
        /// <param name="size"></param>
        public void TransferWaveformDataByPieceFromPath(IAWG awg, string wfmName, string filePath, string startIndex = "", string size = "")
        {
            try
            {
                if (size == "")
                {
                    Assert.Fail("Size can not be empty for this implementation please use other Wfm Data Step");
                }
                if (!File.Exists(filePath))
                {
                    Assert.Fail("File " + filePath + " does not exist");
                }
                int pointsPerRun = Int32.Parse(size);
                awg.GetWListWaveformLength(wfmName); //Get the waveform size from the PBU
                string wfmLength = awg.WaveformListLength;
                _awgSystemGroup.CheckForError(awg, true);
                long totalSize = wfmLength == "" ? 0 : long.Parse(wfmLength);
                string originalblockSize = GetBlockSizeLengthString(pointsPerRun);
                string passPoints = pointsPerRun.ToString();
                var reader = File.ReadAllText(filePath); //No end of lines in the file
                char[] sep = {'\t',','};
                string[] divided = reader.Split(sep); //Have every point ready to deal out in chunks
                long remaining;
                long totalRuns = Math.DivRem(totalSize, pointsPerRun, out remaining);

                //First send out each packet in the pre-selected sizes for as many as possible before running out of 
                //full size packet, then move on to the second for loop
                for (long run = 0; run < totalRuns; run++)
                {
                    string blockSize = originalblockSize;
                    //Create a new block size for this round for passing to Tekvisa
                    long firstIndex = run * pointsPerRun; //Each new run represents a group of points
                    for (long i = 0; i < pointsPerRun; i++)
                    {
                        long indexPoint = i + firstIndex;
                        //Get each point within each run and added is to the blocksize
                        float convertPoint = float.Parse(divided[indexPoint]);
                        byte[] all_of_the_bobs = BitConverter.GetBytes(convertPoint);
                        blockSize += Encoding.ASCII.GetString(all_of_the_bobs);
                    }
                    string outputIndex = firstIndex.ToString();
                    awg.SetWListWaveformPieceData(wfmName, outputIndex, passPoints, blockSize);
                    _awgSystemGroup.CheckForError(awg, true);
                }
                if (remaining > 0) //Pick up what is left over from the 
                {
                    long lastIndex = totalRuns * pointsPerRun; //Get the starting index for the remainders
                    string lastblockSize = GetBlockSizeLengthString(remaining);
                    for (long j = 0; j < remaining; j++)
                    {
                        long indexPoint = j + lastIndex;
                        //Get each point within each run and added is to the blocksize
                        float convertPoint = float.Parse(divided[indexPoint]);
                        byte[] all_of_the_bobs = BitConverter.GetBytes(convertPoint);
                        lastblockSize += Encoding.ASCII.GetString(all_of_the_bobs);
                    }
                    string passRemaining = remaining.ToString();
                    string outputIndex = lastIndex.ToString();
                    Console.WriteLine("Last Packet Length" + passRemaining);
                    awg.SetWListWaveformData(wfmName, outputIndex, passRemaining, lastblockSize);
                    _awgSystemGroup.CheckForError(awg, true);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("Reading file has failed because " + ex.Message);
            }
        }

        /// <summary>
        /// This gets a block of data and saves it to specified file.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="wfmName"></param>
        /// <param name="filePath"></param>
        /// <param name="dataType"></param>
        /// <param name="startIndex"></param>
        /// <param name="blockSize"></param>
        // public void TransferWaveformDataToPath(IAWG awg, string wfmName, string filePath, WaveformData dataType,
        public void TransferWaveformDataToPath(IAWG awg, string wfmName, WaveformData dataType,
                                                 string startIndex = "", string blockSize = "")
        {
            /*string floatingPoints = */ awg.GetWListWaveformData(wfmName, startIndex, blockSize);
            /* File.WriteAllText(filePath, floatingPoints); */
        }

        //glennj
        /// <summary>
        /// Get the original waveform file, convert each analog point into 4 bytes and<para>
        /// compare to the block of data that was returned for the waveform.</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="originalPath"></param>
        //public void CompareWaveformFiles(IAWG awg, string readBackPath, string originalPath)
        public void CompareWaveformFiles(IAWG awg, string originalPath)    
        {
            try
            {
                if (!File.Exists(originalPath))
                {
                    Assert.Fail("File " + originalPath + " does not exist");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("Reading file has failed because " + ex.Message);
            }
            // Get a line of from the original file.
            // Get the analog value.
            // Just as in the PI command, change the analog value to 4 bytes.
            // Compare these four bytes to the array of bytes that were returned.
            // Don't compare the floating point conversions as they don't convert to and from very well.
            // Bytes don't lie.

            int waveformListDataIndex = 0;
            foreach (string line in File.ReadLines(originalPath))
            {
                string[] divided = line.Split(',');
                string originalPoint = divided[0];

                float fvalue = Convert.ToSingle(originalPoint);
                byte[] fvalueAsBytes = BitConverter.GetBytes(fvalue);
                foreach (byte asByte in fvalueAsBytes)
                {
                    Assert.AreEqual(asByte, awg.WaveformListData[waveformListDataIndex]);
                    waveformListDataIndex += 1;    
                }
            }
        }

        public void BlockOfDataShouldBeZeros(IAWG awg)
        {
            // Make sure each byte is zero
            int index = 0;
            foreach (byte value in awg.WaveformListData)
            {
                string possibleErrorString = "Byte number " + index.ToString();
                {
                    Assert.AreEqual(0, value, possibleErrorString);
                }
                index++;
            }
        }

        #endregion WLISt:WAVeform:DATA

        #region WLISt:WAVeform:DELete

        public void DeleteWfmFromWaveformList(IAWG awg, string wfmName)
        {
            if (wfmName != "ALL") //The 'ALL' needs to be without quotation marks
            {
                wfmName = _utils.Quotify(wfmName); //Otherwise add quotation marks
            }
            awg.WListWaveformDelete(wfmName);
        }

        #endregion WLISt:WAVeform:DELete

        #region WLISt:WAVeform:LMAXimum

        public void GetWfmMaxSamplePoints(IAWG awg)
        {
            awg.GetWlistMaxSamplePoints();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedValue"></param>
        public void MaxWfmSamplePointsShouldBe(IAWG awg, string expectedValue) 
        {
            Assert.AreEqual(float.Parse(expectedValue), float.Parse(awg.WaveformListMaxSamplepoints));
        }

        #endregion WLISt:WAVeform:LMAXimum

        #region WLISt:WAVeform:LMINimum

        public void GetWfmMinSamplePoints(IAWG awg)
        {
            awg.GetWlistMinSamplePoints();
        }

        public void MinWfmSamplePointsShouldBe(IAWG awg, string expectedValue)
        {
            Assert.AreEqual(expectedValue, awg.WaveformListMinSamplepoints);
        }

        #endregion WLISt:WAVeform:LMINimum

        #region WLISt:WAVeform:GRANularity

        public void GetGranularityFromWaveformList(IAWG awg)
        {
            awg.GetWaveformGranularity();
        }

        public void GranularityFromWaveformListShouldBe(IAWG awg, string expectedValue)
        {
            Assert.AreEqual(expectedValue, awg.WaveformListGranularity);
        }

        #endregion WLISt:WAVeform:GRANularity

        #region WLISt:WAVeform:LENGth

        public void GetLengthofWfmInWaveformList(IAWG awg, string wfmName)
        {
            awg.GetWListWaveformLength(wfmName);
        }

        public void LengthOfWfmFromWaveformListShouldBe(IAWG awg, string expectedValue)
        {
            Assert.AreEqual(expectedValue, awg.WaveformListLength);
        }

        #endregion WLISt:WAVeform:LENGth

        #region WLISt:WAVeform:MARKer:DATA

        public void SetWaveformMarkerData(IAWG awg, string wfmName, string startIndex, string size, string blockData)
        {
            awg.SetWaveformMarkerData(wfmName, startIndex, size, blockData);
        }

        public void GetWaveformMarkerData(IAWG awg, string wfmName, string startIndex, string size)
        {
            awg.GetWaveformMarkerData(wfmName, startIndex, size);
        }

        public void CompareWaveformMarkerData(IAWG awg, string expectedValue)
        {
            Assert.AreEqual(expectedValue, awg.WaveformListMarkerData);
        }

        #endregion WLISt:WAVeform:MARKer:DATA

        #region WLISt:WAVeform:NEW

        public void CreateANewWaveform(IAWG awg, string wfmName, string size)
        {
            awg.CreateNewWListWaveform(wfmName, size);
        }

        #endregion WLISt:WAVeform:NEW

        #region WLISt:WAVeform:NORMalize

        public void NormalizeWfmFromWaveformList(IAWG awg, string wfmName, WaveformNormalized normalizeSetting)
        {
            string normType = (normalizeSetting == WaveformNormalized.FullScale) ? "FSC" : "ZREF";
            awg.WListWaveformNormalize(wfmName, normType);
        }
        #endregion WLISt:WAVeform:NORMalize

        #region WLISt:WAVeform:RESAmple

        public void ResampleWfmFromWaveformList(IAWG awg, string wfmName, string size)
        {
            awg.WListWaveformResample(wfmName, size);
        }

        #endregion WLISt:WAVeform:RESAmple

        #region WLISt:WAVeform:SHIFt

        public void ShiftWfmFromWaveformList(IAWG awg, string wfmName, string degrees)
        {
            awg.WListWaveformShift(wfmName, degrees);
        }

        #endregion WLISt:WAVeform:SHIFt

        #region WLISt:WAVeform:TSTamp

        public void GetTimestampofWfmfromWavefomList(IAWG awg, string wfmName)
        {
            awg.GetWListWaveformTimestamp(wfmName);
        }

        public void TimestampOfWfmFromWaveformListShouldBe(IAWG awg, string expectedValue)
        {
            expectedValue = _utils.Quotify(expectedValue); //Waveform name comes back with quotes, need to add them to match
            Assert.AreEqual(expectedValue, awg.WaveformListTimestamp);
        }

        public void TimestampOfWfmFromWaveformListShouldMatchPattern(IAWG awg)
        {
            //See if the awg.waveform_timestamp string matches the expected pattern
            var validatePreMatcher = new Regex(@"(?:19[0-9]{2}|20[0-9]{2})/([0|1][0-2]|0[1-9])/[0-3][0-9] (?:2[0-4]|1[0-9]|0[0-9]):[0-5][0-9]:[0-5][0-9]");
            var match = validatePreMatcher.Match(awg.WaveformListTimestamp);
            // Check the status string to see if the operation was sucessful
            if (!match.Success)
            {
                Assert.Fail("Timestamp pattern did not match expectations. Value returned was: " + awg.WaveformListTimestamp);
            }
        }

        #endregion WLISt:WAVeform:TSTamp

        #region WLISt:WAVeform:TYPE

        public void GetTypeofWfmInWaveformList(IAWG awg, string wfmName)
        {
            awg.GetWListWaveformType(wfmName);
        }

        public void WaveformTypeShouldBe(IAWG awg, WaveformType expectedValue)
        {
            const string onlyOneTypeForBackwardsCompatibility = "REAL";
            Assert.AreEqual(onlyOneTypeForBackwardsCompatibility, awg.WaveformListType);
        }

        #endregion WLISt:WAVeform:TYPE

        #region WLISt:WAVeform:SRATe

        public void SamplerateWfmFromWaveformList(IAWG awg, string wfmName, string sRate)
        {
            awg.SetWListWaveformSrate(wfmName, sRate);
        }

        public void GetSamplerateWfmFromWaveformList(IAWG awg, string wfmName)
        {
            awg.GetWListWaveformSrate(wfmName);
        }

        public void CompareWaveformSRATE(IAWG awg, string expectedValue)
        {
            Assert.AreEqual(expectedValue, awg.WaveformSRqueried);
        }

        #endregion WLISt:WAVeform:SRATe
        

        /// Unkown - 01/01/01
        /// <summary>
        /// Checks if the AWG adds a certain number of waveforms in the specified time limt
        /// </summary>
        /// <param name="awg">The AWG the waveforms will be added to</param>
        /// <param name="numEntries">The number of waveforms to be added</param>
        /// <param name="seconds">Time limit for adding the waveforms</param>
        public void WaitForWfmListToAddWfms(IAWG awg, string numEntries, string seconds)
        {
            // For now going to assume all entries start with 0 as each start with reset Awg
            //int currentEntries = awg.waveform_list_size == "" ? 0 : Int16.Parse(awg.waveform_list_size); //Very convenient short if statement fills currentEntries one way or the other
            // currentEntries++;
            //string nextEntry = currentEntries.ToString();
            var timer = new UTILS.HiPerfTimer();
            double totalTime = 0;
            while ((totalTime < double.Parse(seconds)))
            {
                timer.Start();
                GetNumberOfWaveformListEntries(awg);
                if (awg.WaveformListSize == numEntries)
                {
                    return;
                }
                Thread.Sleep(100); // Have to make sure this is between the start/stop commands
                timer.Stop();

                // Add the current interval to the total
                totalTime = totalTime + timer.Duration;
            }
            Assert.Fail("Waveform entries were not added in the " + seconds + " second time limit");
        }

        private string GetBlockSizeLengthString(long totalSize)
        {
            long length = totalSize * 4;
            string stringofLength = length.ToString(CultureInfo.InvariantCulture);
            int lengthofStringofLength = stringofLength.Length;
            string stringofLengthofStringofLenght = lengthofStringofLength.ToString(CultureInfo.InvariantCulture);
            string originalBlockSize = "#" + stringofLengthofStringofLenght + stringofLength;
            return originalBlockSize;
        }



        public string signalFormat { get; set; }
    }
}