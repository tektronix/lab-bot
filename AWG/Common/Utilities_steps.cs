using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

// ReSharper disable CheckNamespace
namespace AwgTestFramework
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// This class contains the utility steps from all over the test framework for a variety of tasks
    /// </summary>
    [Binding]
    public class UtilitiesSteps
    {
        private UTILS.HiPerfTimer _timer;
        readonly UTILS.Savers _savers = new UTILS.Savers();
        readonly UTILS.CallMonitorManager _callMonitorManager = new UTILS.CallMonitorManager();
        readonly UtilitiesGroup _utilitiesGroup = new UtilitiesGroup();

        #region Timer

        // Unkown 01/01/01
        /// <summary>
        /// Starts a timer object 
        /// </summary>
        /*! 
          \Utilities\verbatim
        [When(@"I start the timer")]
            \endverbatim 
        */
        [When(@"I start the timer")]
        public void StarttheTimer()
        {
            _timer = new UTILS.HiPerfTimer();
            _timer.Start();
        }

        // Unkown 01/01/01
        /// <summary>
        /// Stops a timer object but does not return the result
        /// </summary>
        /*! 
         \Utilities\verbatim
        [When(@"I stop the timer")]
            \endverbatim 
        */
        [When(@"I stop the timer")]
        public void StoptheTimer()
        {
            _timer.Stop();
        }

        // Unkown 01/01/01
        /// <summary>
        /// Get the resulting time from the timer object
        /// </summary>
        /// <param name="seconds">The amount of time the timer object ran</param>
        /*! 
        \Utilities\verbatim
        [Then(@"the elapsed time should be less than (\d+(?:(?:\.\d+)*)) seconds")]
            \endverbatim 
        */
        [Then(@"the elapsed time should be less than (\d+(?:(?:\.\d+)*)) seconds")]
        public void TheElapsedTimeShouldBeLessThan(string seconds)
        {
            IAWG awg = AwgSetupSteps.GetAWG(AwgSetupSteps.AwgContext); 
            ElapsedTimeShouldBe(awg, seconds);
        }

        // Unkown 01/01/01
        /// <summary>
        /// Store the timer duration in an AWG accessor for use by multiple steps
        /// </summary>
        /*! 
         \Utilities\verbatim
        [When(@"I store the elapsed time")]
           \endverbatim 
        */
        [When(@"I store the elapsed time")]
        public void StoreTheElapsedTime()
        {
            IAWG awg = AwgSetupSteps.GetAWG(AwgSetupSteps.AwgContext);
            GetTimerDuration(awg);
        }

        // Unkown 01/01/01
        /// <summary>
        /// Store the timer duration in a given AWG accessor as indicated by the enum
        /// </summary>
        /*! 
        \Utilities\verbatim
        [When(@"I store the elapsed time in (OFFPLOT|ONPLOT)")]
           \endverbatim 
        */
        [When(@"I store the elapsed time in (OFFPLOT|ONPLOT)")]
        public void StoreTheElapsedTimewAccessor(string accessor)
        {
            IAWG awg = AwgSetupSteps.GetAWG(AwgSetupSteps.AwgContext);
            GetTimerDuration(awg, accessor);
        }

        public void GetTimerDuration(IAWG awg, string accessor = "TIMER")
        {
            switch (accessor)
            {
                case "TIMER":
                    awg.TimerDuration = _timer.Duration;
                    break;
                case "OFFPLOT":
                    awg.TimerPlotOff = _timer.Duration;
                    break;
                case "ONPLOT":
                    awg.TimerPlotOn = _timer.Duration;
                    break;
            }
        }

        // Unkown 01/01/01
        /// <summary>
        /// Compares the stored time with the expected value
        /// </summary>
        /// <param name="accessor1"></param>
        /// <param name="comparison">Comparison between the two time values greater|less</param>
        /// <param name="accessor2"></param>
        /*!
            \Utilities\verbatim
        [Then(@"the stored time (TIMER|OFFPLOT|ONPLOT) should be (greater|less) than the stored time (TIMER|OFFPLOT|ONPLOT)")]
            \endverbatim 
        */
        [Then(@"the stored time (TIMER|OFFPLOT|ONPLOT) should be (greater|less) than the stored time (TIMER|OFFPLOT|ONPLOT)")]
        public void TheStoredTimeComparedShouldBe(string accessor1, string comparison, string accessor2)
        {
            IAWG awg = AwgSetupSteps.GetAWG(AwgSetupSteps.AwgContext);
            if (accessor1 == accessor2)
            {
                Assert.Fail("Given accessor enums match. Comparing itself with itself will result in little useful information");
            }
            double firstTimeVal = EnumtoAccessorConverter(awg, accessor1);
            double secondTimeVal = EnumtoAccessorConverter(awg, accessor2);

            double trueTimeVal = (comparison == "greater") ? Math.Max(firstTimeVal, secondTimeVal) : Math.Min(firstTimeVal, secondTimeVal);

            Assert.AreEqual(trueTimeVal, firstTimeVal, "Found " + firstTimeVal + " to not be " + comparison + " than " + secondTimeVal);
        }

        public void ElapsedTimeShouldBe(IAWG awg, string seconds)
        {
            if (awg.TimerDuration > double.Parse(seconds))
            {
                string actual = awg.TimerDuration.ToString(CultureInfo.InvariantCulture);
                Assert.Fail("Elapsed time was longer than specified. Expected: " + seconds + " sec. "+ " Actual:" + actual + " sec.");
            }
        }

        /// <summary>
        /// Private method to grab the values from the awg accessors 
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="accessorEnum">Time enum to indicate the accessor to access</param>
        /// <returns>Timed duration</returns>
        private double EnumtoAccessorConverter(IAWG awg, string accessorEnum)
        {
            double accessorValue;
            switch (accessorEnum)
            {
                case "TIMER":
                    accessorValue = awg.TimerDuration;
                    break;
                case "OFFPLOT":
                    accessorValue = awg.TimerPlotOff;
                    break;
                case "ONPLOT":
                    accessorValue = awg.TimerPlotOn;
                    break;
                default:
                    accessorValue = 0.0; //Something has gone horribly wrong
                    break;
            }
            return accessorValue;
        }

        #endregion

        // Unknown 01/01/01
        /// <summary>
        /// Pause for a given number of seconds
        /// </summary>
        /// <param name="seconds">Number of seconds</param>
        /*!
            \system\verbatim
        [When(@"I pause (\d+\.?\d?\d?) seconds")]
            \endverbatim 
        */
        [When(@"I pause (\d+\.?\d?\d?) seconds")]
        public void WhenIWaitNSeconds(float seconds)
        {
            _utilitiesGroup.WaitNSeconds(seconds);
        }

        // Unknown 01/01/01
        /// <summary>
        /// Writes the run of a performance test into a log 
        /// 
        /// </summary>
        /// <param name="testType">Which performance test is being logged</param>
        /// <param name="waveform">Waveform name</param>
        /// <param name="timeLimit">Time limit of the run</param>
        /*!
            \system\verbatim
        [Then(@"I write the results of the (.+) benchmark test of the waveform (.+) under the time of (\d+(?:(?:\.\d+)*)) seconds to a log")]
            \endverbatim 
        */
        [Then(@"I write the results of the (.+) benchmark test of the waveform (.+) under the time of (\d+(?:(?:\.\d+)*)) seconds to a log")]
        public void WriteLoadingBenchmarkResultsToLog(string testType, string waveform, string timeLimit)
        {
            IAWG awg = AwgSetupSteps.GetAWG(AwgSetupSteps.AwgContext);
            WriteBenchmarkResultsToLog(awg, testType, waveform, timeLimit);
        }

        // Unknown 01/01/01
        /// <summary>
        /// 
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="testType"></param>
        /// <param name="waveform"></param>
        /// <param name="timeLimit"></param>
        public void WriteBenchmarkResultsToLog(IAWG awg, string testType, string waveform, string timeLimit)
        {
            string toPrint = waveform + ',' + timeLimit + ',' + awg.TimerDuration.ToString("F4");
            _savers.AddToLog(toPrint, "Waveform" + testType + "BenchmarkLog" + UTILS.NiceDate, "Waveform Name,Time Limit,Actual Time,");
        }

        // Unknown 01/01/01
        /// <summary>
        /// Writes the run of a comparison test into a log  
        /// </summary>
        /// <param name="testType">Which performance test is being logged</param>
        /// <param name="waveform">Waveform name</param>
        /// <param name="accessor1"></param>
        /// <param name="accessor2"></param>
        /*!
            \system\verbatim
        [Then(@"I write the results of the (.+) comparison test of the waveform (.+) using the time (TIMER|OFFPLOT|ONPLOT) against time (TIMER|OFFPLOT|ONPLOT) to a log")]
            \endverbatim 
        */
        [Then(@"I write the results of the (.+) comparison test of the waveform (.+) using the time (TIMER|OFFPLOT|ONPLOT) against time (TIMER|OFFPLOT|ONPLOT) to a log")]
        public void WriteComparisonResultsToLog(string testType, string waveform, string accessor1, string accessor2)
        {
            IAWG awg = AwgSetupSteps.GetAWG(AwgSetupSteps.AwgContext);
            WriteComparisonResultsByTimeStoreToLog(awg, testType, waveform, accessor1, accessor2);
        }

        // Unknown 01/01/01
        /// <summary>
        /// Writes the run of a results comparison test into a log  
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="testType"></param>
        /// <param name="waveform"></param>
        /// <param name="accessor1"></param>
        /// <param name="accessor2"></param>
        public void WriteComparisonResultsByTimeStoreToLog(IAWG awg, string testType, string waveform, string accessor1, string accessor2)
        {
            double firstTimeVal = EnumtoAccessorConverter(awg, accessor1);
            double secondTimeVal = EnumtoAccessorConverter(awg, accessor2);
            string toPrint = waveform + ',' + firstTimeVal.ToString("F4") + ',' + secondTimeVal.ToString("F4");
            string title = "Waveform Name," + accessor1 + "," + accessor2;
            _savers.AddToLog(toPrint, "Waveform" + testType + "ComparisonLog" + UTILS.NiceDate, title);
        }

        // Unknown 01/01/01
        /// <summary>
        /// Deletes a waveform file from the temp folder
        /// </summary>
        /// <param name="filepath">File to be deleted</param>
        /*! 
           \system\verbatim
       [Then(@"I delete the waveform file ""(.*)"" from the temp folder")]
           \endverbatim 
       */
        [Then(@"I delete the waveform file ""(.*)"" from the temp folder")]
        public void ThenIDeleteTheWaveformFileFromTheTempFolder(string filepath)
        {
            File.Delete(filepath);
        }

        [When(@"I write float value difference between the file ""(.*)"" and ""(.*)"" to the ""(.*)"" file")]
        public void WriteOutComparison(string file1, string file2, string fileOut)
        {
            writeOutComparison(file1, file2, fileOut);
        }

        private static void writeOutComparison(string fileIn1, string fileIn2, string fileOut)
        {
            #region Exist checks

            if (!File.Exists(fileIn1))
                Assert.Fail(fileIn1 + " doesn't exist");

            if (!File.Exists(fileIn2))
                Assert.Fail(fileIn2 + " doesn't exist");

            if (File.Exists(fileOut))
                File.Delete(fileOut);

            #endregion

            //Now we can do all the stuff we want

            try
            {
                using (TextReader fileReader1 = new StreamReader(fileIn1))
                using (TextReader fileReader2 = new StreamReader(fileIn2))
                using (TextWriter fileWriter = new StreamWriter(fileOut))
                {
                    while (fileReader1.Peek() != -1)
                    {
                        //Read in both lines
                        var file1Line = fileReader1.ReadLine();
                        var file2Line = fileReader2.ReadLine();

                        //Some formats include commas after the main value for markers
                        file1Line = stripOutCommas(file1Line);
                        file2Line = stripOutCommas(file2Line);

                        //Convert strings to doubles
                        var file1Val = Convert.ToDouble(file1Line);
                        var file2Val = Convert.ToDouble(file2Line);

                        //Write absolute difference to a file
                        var absDifference = Math.Abs(file1Val - file2Val);
                        fileWriter.WriteLine(absDifference);
                    }
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }


        static string stripOutCommas(string val)
        {
            var splitItUp = val.Split(',');
            return splitItUp[0];
        }

        [Then(@"The margin of error in the file ""(.*)"" should be not be greater than ([-+]?(?:[0-9]+(?:\.[0-9]*)?|\.[0-9]+)(?:[eE][-+]?[0-9]+)?)")]
        public void MarginOfErrorWithTolerance(string file, string toleranceStr)
        {
            marginOfErrorWithTolerance(file, toleranceStr);
        }

        private static void marginOfErrorWithTolerance(string file, string toleranceStr)
        {
            #region Exist checks & Get tolerance

            if (!File.Exists(file))
                Assert.Fail(file + " doesn't exist");

            double tolerance;
            var success = double.TryParse(toleranceStr, out tolerance);
            if (!success)
                Assert.Fail("Could not parse tolerance string.");

            #endregion

            //Now we can do all the stuff we want

            try
            {
                //Open the file
                using (TextReader fileReader1 = new StreamReader(file))
                {
                    //Check that we haven't finished the file
                    while (fileReader1.Peek() != -1)
                    {
                        var file1Line = fileReader1.ReadLine();

                        file1Line = stripOutCommas(file1Line);

                        var file1Val = Convert.ToDouble(file1Line);

                        if (file1Val > tolerance)
                            Assert.Fail(file1Val + " > " + tolerance + " tolerance.");
                    }
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }


        #region TekVisa I/O

        //zkoppert 6/26/12
        //glennj 7/31/2013
        /// <summary>
        /// DEPRECATED: Send a Write command to the specified %AWG. Deprecated in favor of using quotes to delimit the sent command.
        /// </summary>
        /// <param name="command">command being written to the %AWG</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /// 
        /*!
            \system\verbatim
        [When(@"I send the (.+) command for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I send the ""(.+)"" command for AWG ([1-4])")]
        public void PreferredSendTheCommandForAWG(string command, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.WriteCommandToAwg(awg, command);
            //PWH This sort of violates a design criteria that nothing should happen that is hidden, but there are
            //so many "When I send the "<command>"" tests that are not checking OPC that it causes the test runs to fail. 
            //Rather than fix them all I'm going to make sure we don't die.
            awg.SessionTimeout = 60000;
            awg.OpcQuery();
            awg.SessionTimeout = awg.DefaultVisaTimeout;
        }

        [When(@"I send the (.+) command to AWG([1-4])")]
        public void DeprecatedSendTheCommandToAWG(string command, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.WriteCommandToAwg(awg, command);
            //PWH This sort of violates a design criteria that nothing should happen that is hidden, but there are
            //so many "When I send the "<command>"" tests that are not checking OPC that it causes the test runs to fail. 
            //Rather than fix them all I'm going to make sure we don't die.
            awg.SessionTimeout = 60000;
            awg.OpcQuery();
            awg.SessionTimeout = awg.DefaultVisaTimeout;
        }

        [When(@"I send the ""(.+)"" command to the AWG")] 
        public void DeprecatedISendTheCommandToTheAWG(string command)
        {
            IAWG awg = AwgSetupSteps.GetAWG(AwgSetupSteps.AwgContext);
            _utilitiesGroup.WriteCommandToAwg(awg, command);
            //PWH This sort of violates a design criteria that nothing should happen that is hidden, but there are
            //so many "When I send the "<command>"" tests that are not checking OPC that it causes the test runs to fail. 
            //Rather than fix them all I'm going to make sure we don't die.
            awg.SessionTimeout = 60000; 
            awg.OpcQuery();
            awg.SessionTimeout = awg.DefaultVisaTimeout;
        }

        //glennj 10/22/2013
        /// <summary>
        /// This does not include the hidden operation complete (OPC) task.<para>
        /// But, the user needs to add an appropriate operation complete for those</para><para>
        /// commands that are needing it.</para>
        /// </summary>
        /// <param name="command"></param>
        /// <param name="awgNumber"></param>
        /*!
            \system\verbatim
        [When(@"I send the raw ""(.+)"" command for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I send the raw ""(.+)"" command for AWG ([1-4])")]
        public void PreferredSendTheRawCommandForAWG(string command, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.WriteCommandToAwg(awg, command);
        }

        //[When(@"I send the raw ""(.+)"" command to AWG ([1-4])")]
        public void DeprecatedSendTheRawCommandToTheAWG(string command, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.WriteCommandToAwg(awg, command);
        }

        //zkoppert 6/27/12
        //glennj 3/24/2014
        /// <summary>
        /// Send a Query command to the specified %AWG. 
        /// </summary>
        /// <param name="command">Command being written to and read from the %AWG</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /// 
        /*! 
            \system\verbatim
        [When(@"I send the ""(.+)"" query for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I send the ""(.+)"" query for AWG ([1-4])")]
        public void PreferredISendAQueryForAwg(string command, string awgNumber)
        {
            
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.QueryTheAwg(awg, command);
        }

        [When(@"I send the ""(.+)"" query to AWG([1-4])")]
        public void DeprecatedISendAQueryToAnAwg(string command, string awgNumber)
        {

            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.QueryTheAwg(awg, command);
        }

        //PHunter 08/8/12
        //glennj 7/31/2013
        /// <summary>
        /// Send any query command to the default %AWG. 
        /// </summary>
        /// <param name="command">Command being written to and read from the %AWG</param>		
        /// 
        /*! 
            \system\verbatim
        [When(@"I send the ""(.+)"" query to the AWG")]
            \endverbatim 
        */
        [When(@"I send the ""(.+)"" query to the AWG")]
        public void WhenISendAQueryToTheAwg(string command)
        {
            IAWG awg = AwgSetupSteps.GetAWG(AwgSetupSteps.AwgContext);
            _utilitiesGroup.QueryTheAwg(awg, command);
        }

        //glennj 3/24/2014
        /// <summary>
        /// Compares expected query output against the expected value
        /// </summary>
        /// <param name="expectedValue">Expected string output</param>
        /// <param name="awgNumber"></param>
        /*! 
            \system\verbatim
        [Then(@"the query response should be ""(.+)"" for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the query response should be ""(.+)"" for AWG ([1-4])")]
        public void PreferredQueryResponseShouldBeFor(string expectedValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _utilitiesGroup.QueryResponseShouldBe(awg, expectedValue);
        }

        // Unknown 01/01/01
        //glennj 7/31/2013
        /// <summary>
        /// Compares expected query output against the expected value
        /// </summary>
        /// <param name="expectedValue">Expected string output</param>
        /*! 
            \system\verbatim
        [Then(@"the AWG query response should be ""(.+)""")]
            \endverbatim 
        */
        [Then(@"the AWG query response should be ""(.+)""")]
        public void DeprecatedAWGQueryResponseShouldBe(string expectedValue)
        {
            IAWG awg = AwgSetupSteps.GetAWG(AwgSetupSteps.AwgContext);
            _utilitiesGroup.QueryResponseShouldBe(awg, expectedValue);
        }

        #endregion

        #region Call Monitor

        private const string CallStartExe = "CallMonitor_start";
        private const string CallStopExe = "CallMonitor_stop";

        // Unknown 01/01/01
        /// <summary>
        /// Start the call monitor via a autoit script
        /// </summary>
        /*! 
           \system\verbatim
        [When(@"I start the Call Monitor")]
           \endverbatim 
       */
        [When(@"I start the Call Monitor")]
        public void StarttheCallMonitor()
        {
            _callMonitorManager.GetCallMonitorProcess(CallStartExe).Start();
        }

        // Unknown 01/01/01
        /// <summary>
        /// Stop the call monitor via a autoit script and try and stop the 
        /// start call monitor autoit script
        /// </summary>
        /*! 
           \system\verbatim
        [Then(@"I stop the Call Monitor")]
           \endverbatim 
       */
        [Then(@"I stop the Call Monitor")]
        public void StoptheCallMonitor()
        {
            if (!_callMonitorManager.CallMonitorMonitor())
            {
                Assert.Fail("There are no Call Monitors to close.");
            }
            else
            {
                _callMonitorManager.GetCallMonitorProcess(CallStopExe).Start();
            }
        }

        #endregion
    }
}
