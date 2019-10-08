//==========================================================================
// AwgSystemGroup.cs
//==========================================================================

using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace AwgTestFramework
{
    /// <summary>
    /// This class contains helper functions that are called from the %AWG System PI step definitions.
    /// This class has no restrictions as to where it will be used.
    /// 
    /// This "Helper" group does everything else but steps and TekVISA.
    /// Using parameters from the step, each helper will makes decisions
    /// such as send commands, or process responses from queries and
    /// do testing and generate asserts if necessary.
    /// 
    /// \ingroup grouphelperpi pisteps 
    /// 
    /// </summary>
    public class AwgSystemGroup    
    {

        public enum SystemErrorDialogMode { On, Off}

        private const string SystemErrorDialogModeOnSyntax = "ON";
        private const string SystemErrorDialogModeOffSyntax = "OFF";

        //PHunter 02/07/2013
        //jmanning 05/19/2014
        /// <summary> 
        /// Returns current settings for the arbitrary waveform generator.
        /// 
        /// *IDN?
        /// </summary>
        /// <param name="awg">The specified AWG</param>
        public void AwgLRNQuery(IAWG awg)
        {
            awg.SessionTimeout = 90000; // jmanning updated to 90000, average time approx 72 seconds for PSR3
            awg.LrnQuery();
            awg.SessionTimeout = awg.DefaultVisaTimeout;
            awg.OpcQuery();
        }
        //shkv 1/28/2015 Ignoring DISP Command for *LRN? output comparision
        //glennj 1/6/2014
        /// <summary>
        /// Given a file that contains the "golden" LRN results<para>
        /// compare them to a new LRN results response.</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="filePath"></param>
        public void VerifyLrnResultsMatchFile(IAWG awg, string filePath)
        {
            string rawActualText = awg.Lrn;         // To be up to date, the LRN query should have happened.

            //string[] expectedLrnData = new string[100];
            //string[] actualLrnData = new string[100];

            //Parse out the current actual LRN data as an array of values
            string[] actualLrnData = UTILS.ParseLrnData(rawActualText);

            //Check to be sure the named file exists
            if (File.Exists(filePath))
            {
                // Get the contents of the file
                string rawExpectedText = File.ReadAllText(filePath);

                //parse out the rawExpectedText into an array of values
                string[] expectedLrnData = UTILS.ParseLrnData(rawExpectedText);

                //Compare the array sizes - they should be equal
                if (expectedLrnData.Length != actualLrnData.Length)
                {
                    Assert.Fail("The expected LRN result had " + expectedLrnData.Length.ToString(CultureInfo.InvariantCulture) +
                                " elements. The actual LRN result had " + actualLrnData.Length.ToString(CultureInfo.InvariantCulture) +
                                " elements. It is likely there are now new commands and the LRN captures have to be redone");
                }

                //Compare the awg/lrn contents against the saved value

                for (int i = 0; i < expectedLrnData.Length; i++)
                {
                    // The following is a list of fields whose contents should be ignored in a setup-to-LRN compare
// ReSharper disable StringIndexOfIsCultureSpecific.1
                    if ((expectedLrnData[i].IndexOf(":SYST:DATE") == -1) &
                        (expectedLrnData[i].IndexOf("TIME") == -1) &
                        (expectedLrnData[i].IndexOf(":STAT:OPER:ENAB") == -1) &
                        (expectedLrnData[i].IndexOf(":STAT:QUES:ENAB") == -1) &
                        (expectedLrnData[i].IndexOf(":MMEM:CAT") == -1) &
                        //CAL and DIAG FAILuresonly requires ACT:MODE is correctly set, but you cannot save a setup if the CAL or DIAG dialogs are up so ignore CAL values
                        (expectedLrnData[i].IndexOf("FAIL") == -1) &
                        (expectedLrnData[i].IndexOf(":OUTP1") == -1) &
                        (expectedLrnData[i].IndexOf(":DISP") == -1) &
                        (expectedLrnData[i].IndexOf(":OUTP2") == -1))
// ReSharper restore StringIndexOfIsCultureSpecific.1
                    {
// ReSharper disable SpecifyACultureInStringConversionExplicitly
                        if (expectedLrnData[i] != actualLrnData[i])
                        {
                            System.Diagnostics.Trace.WriteLine("At field: " + i.ToString() + " - Expected: " + expectedLrnData[i] + " Actual: " + actualLrnData[i]);
                            Assert.Fail("At field: " + i.ToString() + " - Expected: " + expectedLrnData[i] + " Actual: " + actualLrnData[i]);
                        }
// ReSharper restore SpecifyACultureInStringConversionExplicitly
                    }
                }
            }

            else
            {
                Assert.Fail("The requested file:" + filePath + " does not exist!");
            }    
            
        }

        // glennj 06/03/2013
        /// <summary>
        /// Resets the %AWG
        /// </summary>
        /// <param name="awg">The specified AWG</param>
        public void AwgRST(IAWG awg) 
        {
            awg.Reset();    // AWGVisaSession.Write("*RST");
        }

        //glennj 06/04/2013
        /// <summary>
        /// Sets the hour, minute and seconds
        /// </summary>
        /// <param name="awg">awg object</param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        public void AwgSystemTime(IAWG awg, string hour, string minute, string second)
        {
            awg.SystemTime(hour, minute, second);
        }

        /// <summary>
        /// Updates the awg local time variable.  Future reference?
        /// </summary>
        /// <param name="awg">The awg object</param>
        public void AwgSystemTimeQuery(IAWG awg)
        {
            awg.GetSystemTime();  // ignore the returned string for now
        }

        // Unkown 01/01/01
        /// <summary>
        /// Sets the system date
        /// 
        /// SYSTem:DATE
        /// </summary>
        /// <param name="awg">The specified AWG</param>
        /// <param name="setValue">List of year, month and day to change to on the %AWG</param>
        public void AwgSystemDate(IAWG awg, string setValue)
        {
            awg.SystemDate(setValue);
        }

        // Unkown 01/01/01
        //glennj 7/31/2013
        /// <summary>
        /// Update the AWG's property for system date for this current timestamp
        /// 
        /// SYSTem:DATE
        /// </summary>
        /// <param name="awg">The specified AWG</param>
        public void AwgSystemDateQuery(IAWG awg)
        {
            awg.SystemDateQuery();
        }

        public void AwgIdentifyYourself(IAWG awg)
        {
            awg.IdentifyYourself();
        }

        //glennj 1/6/2014
        /// <summary>
        /// the actual test is here, IF the id_string matched the regexp pattern then the m.Success property should be true
        /// </summary>
        /// <param name="awg"></param>
        public void VerifyValidNomenclatureString(IAWG awg)
        {
            var idStringRegex = new Regex(@"TEKTRONIX,AWG[7|5]\d\d\d\d[ABC],\w*,FV:\d.\d.\d{4}");
            Match m = idStringRegex.Match(awg.IdString);
            Assert.IsTrue(m.Success);
        }

        //glennj 1/6/2014
        /// <summary>
        /// Validate awg.model_number by expected value else create pending exception
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedFamily"></param>
        public void VerifyExpectedAwgFamily(IAWG awg, string expectedFamily)
        {
            if (expectedFamily != awg.Family)
            {
                Assert.Inconclusive("The requested AWG " + expectedFamily + "K family does not include this AWG" +
                                    awg.ModelNumber + " instrument, test skipped");
            }
        }

        //PWH - 6/6/2013
        /// <summary>
        /// Tests the awg.number_fo_channels accessor to see if the instrument has 2 channels
        /// </summary>
        /// <param name="awg">Awg object</param>
        public void AwgHasTwoChannels(IAWG awg)
        {            
            const string expectedValue = "2";
            if (expectedValue != awg.GetNumberOfChannels())
            {
                Assert.Inconclusive("The requested AWG has " + awg.GetNumberOfChannels() + " channel when we need two channels, test skipped");
            }
            //System.Console.WriteLine("Debug");
        }

        private const int Major = 0;
        private const int Minor = 1;
        private const int Version = 2;

        //jmanning 3-6-14
        /// <summary>
        /// This verifies that the SW Version is current enough to run the test.
        /// </summary>
        /// <param name="majorMinorVersion">Major[.Minor[.Version]]</param>
        /// <param name="awg"></param>
  
        public void GivenTestAppliesForVersionsAsNewAs(IAWG awg, string majorMinorVersion)
        {
            string[] field = majorMinorVersion.Split(new[] {'.'});

            bool validTest = false;

            // Only change behavior if version number is supplied
            if (field.Length > Major)
            {
                // Test the major
                if ((Convert.ToInt32(field[Major])) < (Convert.ToInt32(awg.AppVersionMajor)))
                {
                    validTest = true;
                }
                else if ((Convert.ToInt32(field[Major])) == (Convert.ToInt32(awg.AppVersionMajor)))
                {
                    // If there a minor
                    if (field.Length > Minor)
                    {
                        // Test the minor
                        if ((Convert.ToInt32(field[Minor])) < (Convert.ToInt32(awg.AppVersionMinor)))
                        {
                            validTest = true;
                        }
                        else if ((Convert.ToInt32(field[Minor])) == (Convert.ToInt32(awg.AppVersionMinor)))
                        {
                            // If there a version
                            if (field.Length > Version)
                            {
                                // Test the minor
                                if ((Convert.ToInt32(field[Version])) < (Convert.ToInt32(awg.AppVersionVersion)))
                                {
                                    validTest = true;
                                }
                            }
                        }
                    }
                }
            }
            if (!validTest)
            {
                Assert.Inconclusive("The AWG application version cannot test this feature, test skipped");
            }
        }

        //jmanning 3-6-14
        /// <summary>
        /// This verifies that the SW Version is old enough to run the test.
        /// </summary>
        /// <param name="majorMinorVersion">Major[.Minor[.Version]]</param>
        /// <param name="awg"></param>

        public void GivenTestAppliesForVersionsAsOldAs(IAWG awg, string majorMinorVersion)
        {
            string[] field = majorMinorVersion.Split(new[] { '.' });

            bool validTest = false;

            // Only change behavior if version number is supplied
            if (field.Length > Major)
            {
                // Test the major
                if ((Convert.ToInt32(field[Major])) > (Convert.ToInt32(awg.AppVersionMajor)))
                {
                    validTest = true;
                }
                else if ((Convert.ToInt32(field[Major])) == (Convert.ToInt32(awg.AppVersionMajor)))
                {
                    // If there a minor
                    if (field.Length > Minor)
                    {
                        // Test the minor
                        if ((Convert.ToInt32(field[Minor])) > (Convert.ToInt32(awg.AppVersionMinor)))
                        {
                            validTest = true;
                        }
                        else if ((Convert.ToInt32(field[Minor])) == (Convert.ToInt32(awg.AppVersionMinor)))
                        {
                            // If there a version
                            if (field.Length > Version)
                            {
                                // Test the minor
                                if ((Convert.ToInt32(field[Version])) > (Convert.ToInt32(awg.AppVersionVersion)))
                                {
                                    validTest = true;
                                }
                            }
                        }
                    }
                }
            }
            if (!validTest)
            {
                Assert.Inconclusive("The AWG application version cannot test this older feature, test skipped");
            }
        }
        
        /// <summary>
        /// Just updates the awg object's notion of the current date.
        /// </summary>
        /// <param name="awg"></param>
        public void AwgUpdateCurrentDate(IAWG awg)
        {
            awg.SystemDateUpdate();
        }

        //glennj 1/6/2014
        /// <summary>
        /// This really doesn't check for "near-ness".  It would seem to be an absolute expectation.<para>
        /// Not really used in Pascal testing.</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedHours"></param>
        /// <param name="expectedMinutes"></param>
        /// <param name="expectedSeconds"></param>
        public void TimesShouldBeClose(IAWG awg, string expectedHours, string expectedMinutes, string expectedSeconds)
        {
            string[] time = Regex.Split(awg.SystemTimeSnapShot, ",");
            Assert.AreEqual(expectedHours, time[0], "Incorrect Hour");
            Assert.AreEqual(expectedMinutes, time[1], "Incorrect Minutes");
            Assert.AreEqual(expectedSeconds, time[2], "Incorrect Seconds");         
        }

        /// <summary>
        /// Checks the response depending on the testFor flag
        /// </summary>
        /// <param name="awg">Object</param>
        /// <param name="testFor">True for no error, False for any error</param>
        public void CheckForError(IAWG awg, bool testFor)
        {
            string response = awg.SystemErrorQueue();

            // Set a regex to the expected pattern of the '0, "No Error"' message
            var responseRegex = new Regex("^0,\"No error\"$");
            Match m = responseRegex.Match(response);
            if (testFor)
            {
                Assert.IsTrue(m.Success, "An unexpected value " + response + " was returned from SYST:ERR?");
            }
            else
            {
                Assert.IsFalse(m.Success, "An unexpected value:" + response + " was returned from SYST:ERR?");
            }
        }

        /// <summary>
        /// Force the AWG to get and save the first available error from the system error queue
        /// </summary>
        /// <param name="awg"></param>
        public void CheckTheErrorQueueFromAWG(IAWG awg)
        {
            awg.SystemErrorQueue();
        }

        public void SetSystemErrorDialogMode(IAWG awg, SystemErrorDialogMode mode)
        {
            var newMode = (mode == SystemErrorDialogMode.Off)
                              ? SystemErrorDialogModeOffSyntax
                              : SystemErrorDialogModeOnSyntax;
            awg.SetSystemErrorDialog(newMode);
        }

        public void GetSystemErrorDialogMode(IAWG awg)
        {
            awg.GetSystemErrorDialog();
        }

        public void SystemErrorDialogModeShouldBe(IAWG awg, SystemErrorDialogMode mode)
        {
            var expectedMode = (mode == SystemErrorDialogMode.Off) ? "0" : "1";
            Assert.AreEqual(expectedMode, awg.SystemErrorDialogMode);
        }

        //glennj 8/29/2013
        /// <summary>
        /// Get an update of the number of errors in the system queue
        /// </summary>
        /// <param name="awg"></param>
        public void GetSystemErrorQueueCount(IAWG awg)
        {
            awg.GetSystemErrorQueueCount();
        }

        //glennj 8/29/2013
        /// <summary>
        /// Uses the property of the AWG which doesn't update automatically.<para>
        /// Need to do a get to update it.</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedCount"></param>
        public void SystemErrorQueueCountShouldBe(IAWG awg, string expectedCount)
        {
            const string possibleErrorString = " for the system error queue count";
            Assert.AreEqual(float.Parse(expectedCount), float.Parse(awg.SystemErrorQueueCount), possibleErrorString);
        }


        /// <summary>
        /// Examines saved error string for a specific code
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedCode"></param>
        public void TheErrorCodeShouldBeFromAWG(IAWG awg, string expectedCode)
        {
            var errorString = awg.SystemError;
            var errorCodeIsPresent = errorString.Contains(expectedCode);
            Assert.IsTrue(errorCodeIsPresent, "The expected error code: " + expectedCode + " was not found in error string " + errorString);
        }

        /// <summary>
        /// Examines the saved error string for a specific phrase
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedPhrase"></param>
        public void TheErrorPhraseShouldBeFromAWG(IAWG awg, string expectedPhrase)
        {
            var errorString = awg.SystemError;
            var errorCodeIsPresent = errorString.Contains(expectedPhrase);
            Assert.IsTrue(errorCodeIsPresent, "The expected error phrase: " + expectedPhrase + " was not found in error string " + errorString);
        }

        //glennj 06/04/2013
        /// <summary>
        /// Just queries.  Not sure why you wouldn't want to test the results.<para>
        /// Was this just a feel good exercise?(GRJ)</para>
        /// </summary>
        /// <param name="awg"></param>
        public void QueryTheErrorQueue(IAWG awg)
        {
            awg.SystemErrorQueue();
        }

        //glennj 06/04/2013
        /// <summary>
        /// Check for supplied specific error.<para>
        /// Test for equal or not equal depending on flag</para>
        /// </summary>
        /// <param name="awg">specific awg object</param>
        /// <param name="expectedValue"></param>
        /// <param name="testFor">True for Equal, False for Not Equal</param>
        public void CheckForSpecificError(IAWG awg, string expectedValue, bool testFor)
        {
            string errorCode;
            string errorMessage;
            GetErrorCodeAndMessage(awg.SystemErrorQueue(), out errorCode, out errorMessage);
            if (testFor)
            {
                Assert.AreEqual(expectedValue, errorCode, "Did not get expected error code " + expectedValue +  ". Error Code Received:  " + errorCode);
            }
            else
            {
                Assert.AreNotEqual(expectedValue, errorCode);
            }
        }

        // Unkown 01/01/01
        /// <summary>
        /// Parses a raw PI error message string into it's code and text fields
        /// </summary>
        /// <param name="rawError">Raw error string returned by the PI call</param>
        /// <param name="errorCode">Error code number</param>
        /// <param name="errorMessage">Error message string, usually useful</param>
        void GetErrorCodeAndMessage(string rawError, out string errorCode, out string errorMessage)
        {
            string[] errorTemp = rawError.Split(',');
            //Split the error message by comma to avoid multiple error messages 
            errorCode = errorTemp[0];
            errorMessage = "";
            if (errorTemp.Length <= 1) //Error is not correctly formatted, th
            {
                Assert.Fail("Invalid Error Returned");
            }
            for (int i = 1; i < errorTemp.Length; i++)
            {
                errorMessage = errorMessage + errorTemp[i];
                if (i < errorTemp.Length - 1)
                {
                    errorMessage = errorMessage + ",";
                }
            }
            // Parse out the string returned into an error code and message
            //Regex AwgErrorMatcher = new Regex(@"(?<err_code>.+),.(?<err_msg>.+).+");
            //Match match = AwgErrorMatcher.Match(rawError);
            //Assert.IsTrue(match.Success); // make sure you got a good match
            //errorCode = match.Groups["err_code"].Value;
            //errorMessage = match.Groups["err_msg"].Value;
            //Console.Write(""); //Here for debug. It's just a place to put a breakpoint if you need one.
        }

        /// <summary>
        /// Have the AWG update it's local copy of the SCPI version
        /// </summary>
        /// <param name="awg"></param>
        public void AwgUpdateScpiVersion(IAWG awg)
        {
            awg.SystemVersionUpdate();
        }

        public void VerifyScpiVersion(IAWG awg, string expectedVersion)
        {
            Assert.AreEqual(expectedVersion, awg.ScpiVersion);
        }

        public void ReadFromAWG(IAWG awg)
        {
            awg.VisaSessionRead();
        }

        public void VerifyChannelCount(IAWG awg, string expectedCount)
        {
            if (expectedCount != awg.GetNumberOfChannels())
            {
                Assert.Inconclusive("The requested AWG has " + awg.GetNumberOfChannels() +
                                    " and not " + expectedCount + " channel, test skipped");
            }
        }

        public void VerifyRequiredChannelCount(IAWG awg, string requiredChannelCount)
        {
            if (requiredChannelCount != awg.GetNumberOfChannels())
            {
                Assert.Inconclusive("The requested AWG has " + awg.GetNumberOfChannels() +
                                    " channels when we need " + requiredChannelCount + " channels, test skipped");
            }
        }

        public void VerifyRequiredFamily(IAWG awg, string requiredFamily)
        {
            AwgIdentifyYourself(awg);       // Go query yourself and decode and save it.

            if (awg.Family != requiredFamily)
            {
                Assert.Inconclusive("The requested AWG " + requiredFamily + "K family does not include this AWG" +
                                    awg.ModelNumber +
                                    " instrument, test skipped");
            }         
        }

        public void VerifyModelNumberShouldMatchAwgChannelCount(IAWG awg)
        {
            //Test the number of channels returned against the last digit of the model_number number
            Assert.AreEqual(awg.ModelNumber.Substring(4, 1), awg.GetNumberOfChannels());
            // Bloody zero-based indexing...      
            // Gee, I wonder who was commenting this?
        }
    }
}