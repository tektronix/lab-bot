using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Threading;
using TechTalk.SpecFlow;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using TestStack.White.UIItems.Finders;
using Button = TestStack.White.UIItems.Button;
using Window = TestStack.White.UIItems.WindowItems.Window;

namespace AwgTestFramework
{
    [Binding]
    public class UTILS
    {
        //PHunter 10/24/2012
        /// <summary>
        /// Cleans up any remaining dialogs at the start and end of each scenario. Captures a screenshot if dialog is found.
        /// </summary>
        public void CleanupDialogs()
        {
            if (AwgSetupSteps.IgnoreUi) return;

            //PWH - none of this next block seems to have been used. The Rectangle Bounds call seems to be the source of the White "out of bounds" warning       

            //Needed for screen captures
            Rectangle bounds = Screen.GetBounds(Screen.GetBounds(Point.Empty));
            string logFile = GetLogFileName();

            //Check to see if the app is still running   
            Console.WriteLine("Instantiating 'application' object - looking for running AWG70K.exe process");
            Process[] application = Process.GetProcessesByName(AWGUI.ProcessName);

            if (application.Length != 0) //if the process is not exited...
            {
                //List of all the modal windows that belong to the window.
                Console.WriteLine("Listing modal windows under the AWG70K.exe process");
                List<Window> modalWindows = new List<Window>();
                bool validWindow = true;
                
                try
                {
                    modalWindows = AWGUI.currentMainWindow.ModalWindows();
                }
                catch (Exception)
                {
                    Console.WriteLine("Exception for modalWindows was thrown and ignored");
                    validWindow = false;
                }
                if (validWindow)
                {
                    //Count the number of modal windows
                    Console.WriteLine("The number of modal widows found was: " + modalWindows.Count);
                    if (modalWindows.Count > 0)
                    {
                        //Then for each modal window, try and close it
                        for (int i = 0; i <= modalWindows.Count - 1; i++)
                        {
                            //Get the title bar text of the next window in the list
                            string dialogTitlebar = modalWindows[i].Title.ToString();
                            Console.WriteLine("Handling the " + dialogTitlebar + " dialog");

                            //Switch to the handler for each defined dialog type
                            switch (dialogTitlebar)
                            {
                                    //Close any AWG MESSAGE dialogs
                                case "AWG Message":
                                    Window awgMessageDialog =
                                        AWGUI.currentMainWindow.ModalWindow(SearchCriteria.ByText("AWG Message"));
                                    Button MsgOKButton = awgMessageDialog.Get<Button>(SearchCriteria.ByText("OK"));
                                    Delay(1);
                                    Assert.IsNotNull(MsgOKButton, "OK button was not found in the AWG Message dialog");
                                    MsgOKButton.Click(); //Click on OK button in Error dialog
                                    break;

                                    //Close any UNSAVED ASSETS dialogs                        
                                case "Unsaved Assets":
                                    Console.WriteLine("Debug");
                                    Window unsavedAssetsDialog =
                                        AWGUI.currentMainWindow.ModalWindow(SearchCriteria.ByText("Unsaved Assets"));
                                    Button dontSave =
                                        unsavedAssetsDialog.Get<Button>(SearchCriteria.ByText("Don't Save"));
                                    Delay(1);
                                    Assert.IsNotNull(dontSave,
                                        "Don't Save button was not found in Unsaved Assets dialog");
                                    dontSave.Click();
                                    break;

                                    //Close any UNEXPECTED ERROR dialogs                        
                                case "Unexpected Error":
                                    //Call Function to capture the screen shot of error message
                                    CaptureImage(Point.Empty, Point.Empty, bounds, logFile, "");
                                    Delay(5); // Delay to click the button after the screen capture is done
                                    Window unexpectedErrorDialog =
                                        AWGUI.currentMainWindow.ModalWindow(SearchCriteria.ByText("Unexpected Error"));
                                    Button okButton = unexpectedErrorDialog.Get<Button>(SearchCriteria.ByText("OK"));
                                    Delay(1);
                                    Assert.IsNotNull(okButton, "OK button was not found in Unexpected Error dialog");
                                    okButton.Click();

                                    //Kill the test run
                                    Console.WriteLine(
                                        "AWG application threw an Unexpected Errror and crashed. A screen capture was made.");
                                    KillMSTest();
                                    break;

                                    //Close any HELP dialogs
                                case "Arbitrary Waveform Generator User Help":
                                    Window helpDialog =
                                        AWGUI.currentMainWindow.ModalWindow(
                                            SearchCriteria.ByText("Arbitrary Waveform Generator User Help"));
                                    Button helpCloseButton =
                                        helpDialog.Get<Button>(SearchCriteria.ByAutomationId("Close"));
                                    Delay(1);
                                    Assert.IsNotNull(helpCloseButton, "Close button was not found in Help dialog");
                                    helpCloseButton.Click();
                                    break;

                                    //Wait for any PROGRESS dialogs
                                case "Progress":
                                    // If the progress dialog is found, it takes 5 seconds or so to clear. This is typical
                                    // when the operation was a change to the AWG mode (NORM, CAL, DIAG). 
                                    // TODO: PWH - once the Progress dialog has been detected, it would be better to see if it is still there once you drop to the handler and then actually handle the window, rather than just waiting for it to go away.
                                    Delay(6);
                                    break;

                                case "Diagnostics and Calibration":
                                    // Do nothing, Diag and Cal dialog is cleared with the reset at the start of a new scenario
                                    break;

                                case "C:\\Windows\\system32\\cmd.exe":
                                    // Do nothing, this is the test runner command window
                                    break;

                                case "":
                                    // Do nothing, if empty string is captured
                                    break;

                                    // If the dialog is still not recognized, capture a screen shot to c:\temp and put an error in the log
                                default:
                                    // Call Function to capture the screen shot of error message
                                    Console.WriteLine("An unknown dialog ('" + dialogTitlebar +
                                                      "')was found in Utilities.CleanUpDialogs() function while cleaning up after a scenario. A screen capture was made.");
                                    CaptureImage(Point.Empty, Point.Empty, bounds, logFile, "");
                                    Delay(5); // Delay to click the button until after the screen capture is done
                                    Assert.Fail("An unknown dialog ('" + dialogTitlebar +
                                                "')was found in Utilities.CleanUpDialogs() function while cleaning up after a scenario. A screen capture was made.");
                                    break;
                            }
                        }
                    }
                }
            }

            else //The app is not running, capture a screen shot to c:\temp and put an error in the log
            {
                //Call Function to capture the screen shot of error message
                CaptureImage(Point.Empty, Point.Empty, bounds, logFile, "");
                Delay(5); // Delay to click the button until after the screen capture is done
                Console.WriteLine(
                    "The AWG application did not appear to be running in Utilities.CleanUpDialogs() function while cleaning up after a scenario. A screen capture was made.");

                //Kill the test run
                KillMSTest();
            }
        }

        // Unkown 01/01/01
        /// <summary>
        /// Checks for the NumLock key being enabled, which will interfere with automated UI tests
        /// </summary>
        public class NumLockCheck
        {
            [DllImport("user32.dll")]
            private static extern short GetKeyState(VirtualKeyStates nVirtKey);

            public static bool IsKeyPressed(VirtualKeyStates testKey)
            {
                bool keyPressed = false;
                short result = GetKeyState(testKey);
                switch (result)
                {
                    case 0:
                        // Not pressed and not toggled on.
                        keyPressed = false;
                        break;
                    default:
                        // Pressed (and may be toggled on)
                        keyPressed = true;
                        break;
                }
                return keyPressed;
            }

            public enum VirtualKeyStates : int
            {
                VK_LBUTTON = 0x01,
                VK_RBUTTON = 0x02,
                VK_NUMLOCk = 0x90
            }
        }

        // Perry Hunter 01/01/01
        /// <summary>
        /// Hi-precision timer functions
        /// 
        /// PWH - Shamelessly plagarized from http://www.codeproject.com/KB/cs/highperformancetimercshar.aspx
        /// </summary>
        public class HiPerfTimer
        {
            [DllImport("Kernel32.dll")]
            private static extern bool QueryPerformanceCounter(
                out long lpPerformanceCount);

            [DllImport("Kernel32.dll")]
            private static extern bool QueryPerformanceFrequency(out long lpFrequency);

            private long startTime, stopTime;
            private long freq;

            // Unkown 01/01/01
            /// <summary>
            /// High performance timer used to track durations
            /// </summary>
            public HiPerfTimer()
            {
                startTime = 0;
                stopTime = 0;
                if (QueryPerformanceFrequency(out freq) == false)
                {
                    // high-performance counter not supported
                    throw new Win32Exception();
                }
            }

            // Unkown 01/01/01
            /// <summary>
            /// Starts the timer
            /// </summary>
            public void Start()
            {
                // lets the waiting threads do their work
                Thread.Sleep(0);
                QueryPerformanceCounter(out startTime);
            }

            // Unkown 01/01/01
            /// <summary>
            /// Stops the timer
            /// </summary>
            public void Stop()
            {
                QueryPerformanceCounter(out stopTime);
            }

            // Unkown 01/01/01
            /// <summary>
            ///  Returns the duration of the timer (in seconds)
            /// </summary>
            public double Duration
            {
                get { return (double) (stopTime - startTime)/(double) freq; }
            }
        }

        // Unkown 01/01/01
        /// <summary>
        /// String property that returns a simple current Date without the time i.e "2-25-2013"
        /// Useful for populating log files and other things that need to be dated
        /// </summary>
        public static string NiceDate
        {
            get
            {
                DateTime rightHereRightNow = DateTime.Now;
                string date = rightHereRightNow.Month.ToString() + '-' + rightHereRightNow.Day.ToString() + '-' +
                              //Seems to be the only way to remove completely the time from the
                              rightHereRightNow.Year.ToString();
                //the DateTime struct even when converted into just a Date struct
                return date;
            }
        }

        // Unkown 01/01/01
        /// <summary>
        /// String property that returns a simple current DateTime i.e "2-25-2013 11-31-23"
        /// Useful for populating log files and other things that need to be dated and timed
        /// </summary>
        public static string NiceDateTime
        {
            get
            {
                DateTime rightHereRightNow = DateTime.Now;
                string datetime = rightHereRightNow.Month.ToString() + '-' + rightHereRightNow.Day.ToString() + '-' +
                                  rightHereRightNow.Year.ToString() + " " + rightHereRightNow.Hour.ToString() + '-' +
                                  rightHereRightNow.Minute.ToString() + '-' + rightHereRightNow.Second.ToString();
                return datetime;
            }
        }

        // Unkown 01/01/01
        /// <summary>
        /// Splits a string on each semicolon and puts them into an array
        /// </summary>
        /// <param name="rawData">The string to be parsed</param>
        /// <returns>An array divided by semicolons</returns>
        public static string[] ParseLrnData(string rawData)
        {
            string[] split = rawData.Split(new Char[] {';'});
            return split;
        }

        // Unkown 01/01/01
        /// <summary>
        /// String property that returns a simple current Time i.e "11-31-23"
        /// Useful for populating log files and other things that need to be timed, but not timed timed, then you 
        /// would use the Timer function obviously. Unless of course you wanted to make a lot of extra work for yourself
        /// in which case this property is badly named.
        /// </summary>
        public static string NiceTime
        {
            get
            {
                DateTime rightHereRightNow = DateTime.Now;
                string datetime = rightHereRightNow.Hour.ToString() + '-' + rightHereRightNow.Minute.ToString()
                                  + '-' + rightHereRightNow.Second.ToString();
                return datetime;
            }
        }

        // Unkown 01/01/01
        /// <summary>
        /// Class of converters that take value and a unit and convert and return the value.
        /// </summary>
        public class Converter
        {
            /// <summary>
            /// MilliVolts To Volt Converter
            /// </summary>
            /// <param name="value">Value to convert</param>
            /// <param name="units">Units the value is in</param>
            /// <returns>Converted value</returns>
            public string mVToVolt(string value, string units)
            {
                //Interpret the units selected in the step and convert the value to volts
                float interpreted_value;
                switch (units)
                {
                    case "mV":
                    case "millivolts":
                        interpreted_value = (Single.Parse(value)/1000);
                        break;
                    case "V":
                    case "volts":
                        interpreted_value = (Single.Parse(value));
                        break;
                    default:
                        interpreted_value = 0;
                        Assert.Fail("The units passed to the mV to V converter were not recognized");
                        break;
                }
                // Convert the float to a string
                string valueToSet = Convert.ToString(interpreted_value);
                return valueToSet;
            }

            // Unkown 01/01/01
            /// <summary>
            /// Mega Hertz Or Kilo Hertz To Hertz Converter
            /// </summary>
            /// <param name="value">Value to convert</param>
            /// <param name="units">Units the value is in</param>
            /// <returns>Converted value</returns>
            public string MegaOrKiloHertzToHertz(string value, string units)
            {
                //Interpret the units selected in the step and convert the value to hertz
                float interpreted_value;
                switch (units)
                {
                    case "M":
                    case "MHz":
                        interpreted_value = (Single.Parse(value)*1000000);
                        // convert the passed value to a float to do the math with
                        break;
                    case "K":
                    case "KHz":
                        interpreted_value = (Single.Parse(value)*1000);
                        break;
                    default:
                        interpreted_value = 0;
                        Assert.Fail("The units passed to the Hertz converter was not recognized");
                        break;
                }
                // Convert the float to a string
                string valueToSet = Convert.ToString(interpreted_value);
                return valueToSet;
            }

            // Unkown 01/01/01
            /// <summary>
            /// Pico Second to Second Converter
            /// </summary>
            /// <param name="value">Value to convert</param>
            /// <param name="units">Units the value is in</param>
            /// <returns>Converted value</returns>
            public string PicotoSecond(string value, string units)
            {
                double interpreted_value;
                if ((units == "PS") | (units == "ps"))
                {
                    interpreted_value = (Single.Parse(value)*0.000000000001);
                    // convert the passed value to a float to do the math with
                }
                else if ((units == "sec") | (units == "s"))
                {
                    interpreted_value = (Single.Parse(value));
                }
                else
                {
                    interpreted_value = 0; // To make the variable "definitely assigned"
                    Assert.Fail("The units passed to the Hertz converter was not recognized");
                }
                // Convert the float to a string
                string valueToSet = Convert.ToString(interpreted_value);
                return valueToSet;
            }

            // Unkown 01/01/01
            /// <summary>
            /// Giga Sample or Mega Sample or Kilo Sample to Sample Converter
            /// </summary>
            /// <param name="value">Value to convert</param>
            /// <param name="units">Units the value is in</param>
            /// <returns>Converted value</returns>
            public string GigaMegaKilotoSample(string value, string units)
            {
                double interpreted_value;
                switch (units)
                {
                    case "GS":
                        interpreted_value = (Single.Parse(value)*1e9);
                        // convert the passed value to a float to do the math with
                        break;
                    case "MS":
                        interpreted_value = (Single.Parse(value)*1e6);
                        break;
                    case "KS":
                        interpreted_value = (Single.Parse(value)*1e3);
                        break;
                    default:
                        interpreted_value = 0; // To make the vairable "definitely assigned"
                        Assert.Fail("The units passed to the sample converter was not recognized");
                        break;
                }
                // Convert the float to a string
                string valueToSet = Convert.ToString(interpreted_value);
                return valueToSet;
            }

            // Unkown 01/01/01
            /// <summary>
            /// Giga Hertz To Mega Hertz Converter
            /// </summary>
            /// <param name="value">Value to convert</param>
            /// <param name="units">Units the value is in</param>
            /// <returns>Converted value</returns>
            public string GigaToMegaHertz(string value, string units)
            {
                double interpreted_value;
                if ((units == "M") | (units == "MHz"))
                {
                    interpreted_value = (Single.Parse(value));
                }
                else if ((units == "G") | (units == "GHz"))
                {
                    interpreted_value = (Single.Parse(value)*1000);
                    // convert the passed value to a float to do the math with
                }
                else
                {
                    interpreted_value = 0; // To make the variable "definitely assigned"
                    Assert.Fail("The units passed to the Giga tp Megahertz converter was not recognized");
                }
                // Convert the float to a string
                string valueToSet = Convert.ToString(interpreted_value);
                return valueToSet;
            }
        }

        // Unkown 01/01/01
        /// <summary>
        //! Todo: Write summary 
        /// </summary>
        public class Savers
        {
            // Unkown 01/01/01
            /// <summary>
            /// Creates a new file of appends the old one of performance log results
            /// </summary>
            /// <param name="stringToAdd">Line to add</param>
            /// <param name="filename">Path of the desired file</param>
            /// <param name="title">Line of text at the start of the file to label each column</param>
            public void AddToLog(string stringToAdd, string filename, string title)
            {
                try
                {
                    string filePath = "C:\\Temp\\" + filename + ".txt";
                    if (!File.Exists(filePath))
                    {
                        var writer = File.CreateText(filePath);
                        using (writer)
                        {
                            writer.WriteLine(title);
                            writer.WriteLine(stringToAdd);
                        }
                    }
                    else
                    {
                        var append = File.AppendText(filePath);
                        using (append)
                        {
                            append.WriteLine(stringToAdd);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Assert.Fail("Writing to a log has failed because " + ex.Message);
                }
            }

            // Unkown 01/01/01
            /// <summary>
            //! Creates a log file for TekVISA Call Monitor output
            /// </summary>
            /// <param name="filepathToRead"></param>
            /// <param name="filename"></param>
            public void CreateCallLog(string filepathToRead, string filename)
            {
                try
                {
                    string filePath = "C:\\Temp\\" + filename + ".txt";
                    if (!File.Exists(filepathToRead))
                    {
                        Assert.Fail("Call monitor log not found");
                    }
                    var reader = File.ReadLines(filepathToRead);
                    if (!File.Exists(filePath))
                    {
                        var writer = File.CreateText(filePath);
                        using (writer)
                        {
                            foreach (var line in reader)
                            {
                                writer.WriteLine(line);
                            }
                        }
                    }
                    else
                    {
                        var writer = File.AppendText(filePath);
                        using (writer)
                        {
                            foreach (var line in reader)
                            {
                                writer.WriteLine(line);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Assert.Fail("Writing to a log has failed because " + ex.Message);
                }
            }

            // Unkown 01/01/01
            /// <summary>
            ///  Copy the Call monitor log text to a more convient file 
            /// </summary>
            /// <param name="filepathToRead"></param>
            public void CopyCallLog(string filepathToRead)
            {
                try
                {
                    const string copyfilePath = "C:\\Temp\\CallMonitorLog.txt";
                    if (!File.Exists(filepathToRead))
                    {
                        Assert.Fail("Call monitor log not found");
                    }
                    File.Copy(filepathToRead, copyfilePath, true); //Do not need to dispose
                }
                catch (Exception ex)
                {
                    Assert.Fail("Copying log to a text file has failed because " + ex.Message);
                }
            }

            // Unkown 01/01/01
            /// <summary>
            //! Todo: Write summary 
            /// </summary>
            /// <param name="filename"></param>
            public void ClearLog(string filename)
            {
                try
                {
                    string filePath = "C:\\Temp\\" + filename + ".txt";
                    if (File.Exists(filePath))
                    {
                        StreamWriter writer = new StreamWriter(filePath);
                        using (writer)
                        {
                            writer.WriteLine("Waveform Name, Time Limit, Actual Time,");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Assert.Fail("Writing to a log has failed because " + ex.Message);
                }
            }

            // Unkown 01/01/01
            /// <summary>
            //! Todo: Write summary 
            /// </summary>
            /// <param name="filename"></param>
            public void ClearCallLog(string filename)
            {
                try
                {
                    FileStream stream = File.Create(filename);
                    stream.Dispose();
                }
                catch (Exception ex)
                {
                    Assert.Fail("Writing to a log has failed because " + ex.Message);
                }
            }
        }

        #region ID String Parsing

        //// Unkown 01/01/01
        ///// <summary>
        ///// Function for retreiving information from the %AWG ID string
        ///// </summary>
        ///// <param name="awg_number">Which %AWG machine number</param>
        ///// <param name="IdString">Returned Id string from the %AWG</param>
        //public static void GetAwgIDInformation(string awg_number, string IdString)
        //{
        //    if (string.IsNullOrEmpty(IdString))
        //    {
        //        Assert.Fail("No ID string returned from AWG" + awg_number);
        //    }
        //    int awg_index = AWG.AWGNumString2Index(awg_number);
        //    AWG awg = AwgSetupSteps.GetAWG(awg_index);
        //    //This is kind of cute, C# allows us to label the regex group we want with a name, instead of having to use an array index value.
        //    //Regex AwgFeatureMatcher = new Regex(@"TEKTRONIX,(?<type>AWG|HSG)(?<model_number>\d+)(?<class>.),(?<serial>.+),SCPI:(?<scpi>.+) FW:(?<fwVersion>.+)");
        //    //To get the 70k to work it doesn't appear to add a SCPI field to its ID string
        //    Regex AwgFeatureMatcher =
        //        new Regex(@"TEKTRONIX,(?<type>AWG|HSG)(?<model_number>\d+)(?<class>.),(?<serial>.+),FV:(?<fwVersion>.+)");
        //    Match match = AwgFeatureMatcher.Match(IdString.Trim()); //The ID 
        //    Assert.IsTrue(match.Success,
        //                  "The AWG ID string did not match the specified pattern. The actual value returned was: " +
        //                  IdString); // make sure you got a good match
        //    //Remember that since we have an instance of the AWG accessors for each one in the setup, these values are specific to that AWG            
        //    awg.model_number = match.Groups["model_number"].Value;
        //    awg.class_letter = match.Groups["class"].Value;
        //    awg.model_string = match.Groups["type"].Value + awg.model_number + awg.class_letter;
        //    awg.serial_number = match.Groups["serial"].Value;
        //    awg.fw_version = match.Groups["fwVersion"].Value;
        //    switch (awg.model_number)
        //    {
        //            // 70000 "A" series (Pascal)
        //        case "70001":
        //        case "70002":
        //            awg.family = "70";
        //            break;
        //    }
        //}

        // Unkown 01/01/01
        /// <summary>
        /// Function for retreiving information from the Scope ID string
        /// </summary>
        /// <param name="IdString">Returned Id string from the Scope</param>
        /// <returns>Returns a boolean with the result of the matching process</returns>
        public bool GetScopeIDInformation(string IdString)
        {
            if (string.IsNullOrEmpty(IdString)) //No chance of finding the scope just give up
            {
                return false;
            }
            ISCOPE scope = SCOPE.GetScope(false);
            //This is kind of cute, C# allows us to label the regex group we want with a name, instead of having to use an array index value.
            Regex ScopeFeatureMatcher =
                new Regex(
                    @"TEKTRONIX,(?<type>CSA|DPO)(?<model_number>\d{4}).?,(?<serial>.+),CF:\d\d\.\dCT\sFV:(?<fwVersion>.+)");
            Match match = ScopeFeatureMatcher.Match(IdString.Trim()); //The ID 
            if (!match.Success) //Scope is there, just isn't talking properly
            {
                return false;
            }
            return true;
        }

        // Unkown 01/01/01
        /// <summary>
        /// Function for retreiving information from the External Source ID string
        /// </summary>
        /// <param name="IdString">Returned Id string from the External Source</param>
        /// <returns>Returns a boolean with the result of the matching process</returns>
        public bool GetExtSourceIDInformation(string IdString)
        {
            if (string.IsNullOrEmpty(IdString)) //No chance of External Source being valid give up
            {
                return false;
            }
            EXTSOURCE extsource = EXTSOURCE.GetExtSource(false);
            //This is kind of cute, C# allows us to label the regex group we want with a name, instead of having to use an array index value.
            Regex SrcFeatureMatcher =
                new Regex(@"TEKTRONIX,(?<type>AWG|HSG)(?<model_number>\d+).,(?<serial>.+),SCPI:.+ FW:(?<fwVersion>.+)");
            Match match = SrcFeatureMatcher.Match(IdString.Trim()); //The ID 
            //Assert.IsTrue(match.Success); // make sure you got a good match
            if (!match.Success) //ExtSource is there, just isn't talking properly
            {
                return false;
            }
            //Remember that since we have an instance of the EXTSOURCE accessors for each one in the setup, these values are specific to that AWG
            extsource.model = match.Groups["model_number"].Value;
            extsource.serial_number = match.Groups["serial"].Value;
            extsource.fw_version = match.Groups["fwVersion"].Value;
            switch (extsource.model)
            {
                    // 5000 "A", "B", "C" series (Indy, Hubble, Kepler)
                case "5002":
                case "5012":
                case "5014":
                    extsource.family = "5";
                    break;
                    // 7000 "A", "B", "C" series (Indy, Hubble, Kepler)
                case "7101":
                case "7061":
                case "7082":
                case "7122":
                    extsource.family = "7";
                    break;
            }
            return true; //All matches point to a valid ID string
        }

        #endregion

        #region Quote modification

        // Unkown 01/01/01
        /// <summary>
        /// Gets rid of the all the single quotes and replace with single ones   
        /// </summary>
        /// <param name="stringWithSingleQuotes">The string to remove the single quotes from</param>
        /// <returns></returns>
        public string addDoubleQuotes(string stringWithSingleQuotes)
        {
            string stringWithDoubleQuotes = stringWithSingleQuotes.Replace("\"", "\"\"");
            return stringWithDoubleQuotes;
        }

        // Unkown 01/01/01
        /// <summary>
        /// Get rid of the all the double quotes and replace with single ones   
        /// </summary>
        /// <param name="stringWithDoubleQuotes">The string to remove the double quotes from</param>
        /// <returns></returns>
        public string removeDoubleQuotes(string stringWithDoubleQuotes)
        {
            string stringWithoutDoubleQuotes = stringWithDoubleQuotes.Replace("\"\"", "\"");
            return stringWithoutDoubleQuotes;
        }

        // Jhowells 1/7/2013
        /// <summary>
        /// Quick function to add double quotes around a given string
        /// 
        /// Useful for Asserts when the string is returned with quotes and quotes need to be added to the parameter value\n
        /// i.e Assert.AreEqual(utils.Quotify(hwversion), awg.gpib_usb_hwversion);
        /// </summary>
        /// <param name="unquoted">String to add quotes around</param>
        /// <returns>Quoted string</returns>
        public string Quotify(string unquoted)
        {
            string toquote = '"' + unquoted + '"';
            return toquote;
        }

        // Jhowells 1/7/2013
        /// <summary>
        /// Quick function to remove double quotes from around a given string
        /// 
        /// Function assumes the quotes are at the beginning and the end of the string
        /// Will only remove first and last character if it is the '"' character
        /// </summary>
        /// <param name="quoted">String to remove quotes</param>
        /// <returns>Dequoted string</returns>
        public string Dequotify(string quoted)
        {
            char[] quoteArray = {'"'};
            string dequote = quoted.TrimStart(quoteArray);
            dequote = dequote.TrimEnd(quoteArray);
            return dequote;
        }

        #endregion

        // Unkown 01/01/01
        /// <summary>
        /// Makes sure the XML can be read without any exceptions being thrown
        /// </summary>
        /// <param name="XMLcode">The XML to read</param>
        /// <returns>The error message if an exception is thrown or a empty string if not</returns>
        public string ValidateXML(string XMLcode)
        {
            //string temp = XMLcode.Remove(0, 1); //Remove the quotes at the front
            //temp = temp.Remove(temp.Length - 1, 1); //And the back
            //temp = temp.Replace("\"\"", "\""); // Get rid of the all the double quotes and replace with single ones
            XmlTextReader xmlTextReader = new XmlTextReader(new StringReader(XMLcode));
            try
            {
                while (xmlTextReader.Read())
                {
                    ;
                }
            }
            catch (XmlException ex) //Found something invalid, automatically fail the test
            {
                return ex.Message; //Return the error
            }
            return ""; //No news is good news
        }

        //// Unkown 01/01/01
        ///// <summary>
        ///// Parses a raw PI error message string into it's code and text fields
        ///// </summary>
        ///// <param name="raw_error">Raw error string returned by the PI call</param>
        ///// <param name="error_code">Error code number</param>
        ///// <param name="error_message">Error message string, usually useful</param>
        //public static void GetErrorCodeAndMessage(string raw_error, out string error_code, out string error_message)
        //{
        //    string[] errorTemp = raw_error.Split(',');
        //    //Split the error message by comma to avoid multiple error messages 
        //    error_code = errorTemp[0];
        //    error_message = "";
        //    if (errorTemp.Length <= 1) //Error is not correctly formatted, th
        //    {
        //        Assert.Fail("Invalid Error Returned");
        //    }
        //    for (int i = 1; i < errorTemp.Length; i ++)
        //    {
        //        error_message = error_message + errorTemp[i];
        //        if (i < errorTemp.Length - 1)
        //        {
        //            error_message = error_message + ",";
        //        }
        //    }
        //    // Parse out the string returned into an error code and message
        //    //Regex AwgErrorMatcher = new Regex(@"(?<err_code>.+),.(?<err_msg>.+).+");
        //    //Match match = AwgErrorMatcher.Match(raw_error);
        //    //Assert.IsTrue(match.Success); // make sure you got a good match
        //    //error_code = match.Groups["err_code"].Value;
        //    //error_message = match.Groups["err_msg"].Value;
        //    //Console.Write(""); //Here for debug. It's just a place to put a breakpoint if you need one.
        //}

        // Unkown 01/01/01
        /// <summary>
        /// Sleeps for a desired amount of time
        /// </summary>
        /// <param name="seconds">The number of seconds desired</param>
        public void Delay(double seconds)
        {
            int interval = ((int) seconds*1000);
            Thread.Sleep(interval);
        }

        // Unkown 01/01/01
        /// <summary>
        /// Captures the Image of The Screen
        /// </summary>
        /// <param name="SourcePoint"></param>
        /// <param name="DestinationPoint"></param>
        /// <param name="SelectionRectangle"></param>
        /// <param name="FilePath"></param>
        /// <param name="extension"></param>
        public void CaptureImage(Point SourcePoint, Point DestinationPoint,
                                 Rectangle SelectionRectangle, string FilePath, string extension)
        {
            try
            {
                using (Bitmap bitmap = new Bitmap(SelectionRectangle.Width, SelectionRectangle.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(SourcePoint, DestinationPoint, SelectionRectangle.Size);
                        //  Rectangle cursorBounds = new Rectangle(curPos, curSize);
                        //Cursors.Default.Draw(g, cursorBounds);
                    }
                    bitmap.Save(FilePath, ImageFormat.Png); // Saves the captured Image to a file         
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception occured due to " + exception.Message);
                throw new Exception("The image could not be captured");
            }
        }

        // Unkown 01/01/01 
        /// <summary>
        /// Gets the FileName with date and time for logging error messages
        /// </summary>
        /// <returns></returns>
        public String GetLogFileName()
        {
            DateTime datetime = DateTime.Now;
            String dateTimeStr = String.Format("{0:MMM d yyyy HH.mm.ss}", datetime);
            String sandBoxPath = "C:\\Temp\\errormsg";
            // if sandBoxPath doesnt have trailing slash, add it.
            // if (sandBoxPath[sandBoxPath.Length - 1] != '\\')
            // sandBoxPath += "\\";
            String logFile = sandBoxPath + dateTimeStr + ".png";
            return logFile;
        }

        // Unkown 01/01/01,
        /// <summary>
        /// Function to delete any temporary files created during test run
        /// </summary>
        /// <param name="filepath"></param>
        public void DeleteTemporaryFile(string filepath)
        {
            //Delete any Temporary files created
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
        }

        // GlennJ (?) 06/01/2013
        /// <summary>
        //! Functions to start and stop the Call Monitor as a diagnostic/debugging tool during a test run.
        /// </summary>
        public class CallMonitorManager
        {
            private const string CallMonitorExe = "CallMonitor";

            public Process GetCallMonitorProcess(string filename)
            {
                Process[] callMonitors = Process.GetProcessesByName(filename);
                Process callMonitor = null;
                if (callMonitors.Length > 0)
                {
                    //The chances of this happening are very small but might as well catch it
                    Assert.Fail("Call Monitor start process has already been started");
                }
                else
                {
                    callMonitor = new Process();
                    callMonitor.StartInfo.FileName = "C:\\Temp\\waveforms\\" + filename + ".exe";
                }
                return callMonitor;
            }

            // Unkown 01/01/01
            /// <summary>
            //! Todo: Write summary 
            /// </summary>
            /// <returns></returns>
            public bool CallMonitorMonitor()
            {
                Process[] callMonitors = Process.GetProcessesByName(CallMonitorExe);
                if (callMonitors.Length < 0)
                {
                    return false;
                }
                return true;
            }

            // Unkown 01/01/01
            /// <summary>
            /// Kills the process for the call monitor
            /// </summary>
            /// <param name="filename">Name of the process spawned by the exe to be killed</param>
            public void KillCallMonitorProcesses(string filename)
            {
                Process[] callMonitors = Process.GetProcessesByName(filename);
                if (callMonitors.Length > 0)
                {
                    foreach (Process callMonitor in callMonitors)
                    {
                        try
                        {
                            callMonitor.Kill();
                        }
                        catch (Exception ex)
                        {
                            Assert.Fail("Unable to kill zombie process " + filename + " because " + ex.Message);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Converts an ascii character to a 0,1,2 or 3 based on the marker data
        /// </summary>
        /// <param name="response">A string of ascii characters representing the waveform data</param>
        /// <returns>0 for both markers being 0, 1 for marker 1 being 1, 2 for marker 2 being 1, 3 for both markers being 1</returns>
        internal static string ConvertAsciiToString(string response)
        {
            string formattedResponse = string.Empty;

            //note this assumes that the data in the waveform is EMPTY. If the waveform has data it will not format correctly according to this method.
            foreach (char c in response)
            {
                if (c.Equals((char) 0)) //this means both markers are 0 (because the 8 bits look like this: 00000000)
                {
                    formattedResponse += "0";
                }

                if (c.Equals((char) 64)) //this means marker 1 = 1 (because of the 8 bits look like this: 01000000)
                {
                    formattedResponse += "1";
                }

                if (c.Equals(((char) 128)))
                {
                    formattedResponse += "2"; //this means marker 2 = 1 (because of the 8 bits look like this: 10000000)
                }

                if (c.Equals((char) 192))
                {
                    formattedResponse += "3";
                    //this means marker 1 & 2 both are 1 (because the 8 bits look like this: 11000000)
                }
            }

            return formattedResponse;
        }

        // PWH 2013/09/25
        /// <summary>
        /// Causes the MSTest engine to abort running further tests and shut the run down.
        /// </summary>
        [DllImport("User32.dll")]
        private static extern int SetForegroundWindow(IntPtr point);

        public void KillMSTest()
        {
            Process p = Process.GetProcessesByName("MSTest").FirstOrDefault();
            if (p != null)
            {
                IntPtr h = p.MainWindowHandle;
                SetForegroundWindow(h);
                SendKeys.SendWait("^(c)");
            }
        }
    }
}