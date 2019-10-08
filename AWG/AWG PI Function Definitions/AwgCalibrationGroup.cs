//==========================================================================
// AwgCalibrationGroup.cs
//==========================================================================
using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains helper functions that are called from the %AWG Calibration PI step definitions.
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
    public class AwgCalibrationGroup 
    {
        readonly UTILS _utils = new UTILS();

        public enum CalibrationDataType { Factory, User }

        public enum CalibrationType { Internal, External }

        private const string CalibrationTypeInternalSyntax = "INT";
        private const string CalibrationTypeExternalSyntax = "EXT";

        public enum CalibrationLogDetails { On, Off }

        private const string CalibrationLogDetailsOnSyntaxSend = "ON";
        private const string CalibrationLogDetailsOffSyntaxSend = "OFF";
        private const string CalibrationLogDetailsOnSyntaxReceived = "1";
        private const string CalibrationLogDetailsOffSyntaxReceived = "0";

        public enum CalibrationLogFailures { On, Off }

        private const string CalibrationLogFailuresOnSyntaxSend = "ON";
        private const string CalibrationLogFailuresOffSyntaxSend = "OFF";
        private const string CalibrationLogFailuresOnSyntaxReceived = "1";
        private const string CalibrationLogFailuresOffSyntaxReceived = "0";

        public enum CalibrationControlLoopMode { Once, Continuous, Count }

        private const string CalibrationControlLoopOnceSyntaxSend       = "ONCE";
        private const string CalibrationControlLoopContinuousSyntaxSend = "CONTinuous";
        private const string CalibrationControlLoopCountSyntaxSend      = "COUNt";

        private const string CalibrationControlLoopOnceSyntaxReceived = "ONCE";
        private const string CalibrationControlLoopContinuousSyntaxReceived = "CONT";
        private const string CalibrationControlLoopCountSyntaxReceived = "COUN";

        public enum CalibrationLoopCountTypeAs { Nr1, Min, Max }

        private const string CalibrationLoopCountMaxSyntax = "MAX";
        private const string CalibrationLoopCountMinSyntax = "MIN";
        
        public enum CalibrationStoppedState { Stopped, NotStopped }

        private const string CalibrationControlStoppedStateStoppedSyntax = "1";
        private const string CalibrationControlStoppedStateNotStoppedSyntax = "0";

        private const string ErrorMessageCalibrationCheckingStoppedState = "Checking for the correct calibration stopped state.";

        public enum CalibrationControlHaltMode { On, Off }

        private const string CalibrationControlHaltOnSyntaxSend         = "ON";
        private const string CalibrationControlHaltOffSyntaxSend        = "OFF";
        private const string CalibrationControlHaltOnSyntaxReceived     = "1";
        private const string CalibrationControlHaltOffSyntaxReceived = "O";

        private const string ErrorMessageCalibrationCheckingHaltMode = "Checking for the correct calibration halt mode.";

        #region Published

        #region *CAL?

        /// <summary>
        /// Forces the AWG to run a *CAL? and saves results in the AWG object
        /// </summary>
        /// <param name="awg">the AWG object</param>
        public void RunInternalCalibrationShortFormAndGetResult(IAWG awg)
        {
            awg.CalRunSaveResults();
        }

        public void CalibrationsResultsShouldBeEitherPassOrFail(IAWG awg)
        {
            //Execute
            string calState = awg.CalibrationState;
         
            if ((calState != "-340") && (calState != "0")) //Each outcome should have an assert so the test can pass or fail
            {
                string errorMessage = "CAL? has returned an invalid response of " + calState;
                Assert.Fail(errorMessage);
            }
        }
		
        #endregion *CAL?

        #region CALibration:ABORt

        //glennj 6/11/2013
        /// <summary>
        /// Abort running of calibration.
        /// </summary>
        /// <param name="awg">the AWG object</param>
        public void AbortCalibration(IAWG awg)
        {
            awg.CalAbort();
        }
		
        #endregion CALibration:ABORt

        #region CALibration[:ALL]

        /// <summary>
        /// Forces the AWG to start a cal all process
        /// </summary>
        /// <param name="awg">the AWG object</param>
        public void RunInternalCalibration(IAWG awg)
        {
            awg.CalAll();
        }

        /// <summary>
        /// Forces the AWG to run all internal(self) cal procedures and<para>
        /// saves results in the awg's local copy, "calibration_state"</para><para>
        /// Beware that this doesn't return until the cal has finished.</para>
        /// </summary>
        /// <param name="awg">the AWG object</param>
        public void RunInternalCalibrationAndGetResult(IAWG awg)
        {
            awg.CalAllQuery();
        }

        //glennj 12/2/2013 added
        /// <summary>
        /// Checks that the updated Calibration results contains the expected value
        /// If the CalUserState is calibrated then checks to make sure it has a valid temperature
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="containedValue"></param>
        public void CalibrationResultShouldContain(IAWG awg, string containedValue)
        {
            string possibleErrorMessage = "Calibration result " + awg.CalibrationResult + " did not contain " + containedValue;
            bool containsValue = awg.CalibrationResult.Contains(containedValue);
            Assert.AreEqual(true, containsValue, possibleErrorMessage);
        }

        #endregion CALibration[:ALL]

        #region CALibration:CATalog?

        /// <summary>
        /// Forces the AWG to update its copy of the calibration list of procedures or as we like to call it, the catalog
        /// </summary>
        /// <param name="awg">the AWG object</param>
        public void GetTheCalibrationProceduresList(IAWG awg)
        {
            awg.CalCatalogQuery();
        }

        public void CalibrationProceduresListFromAWG1ShouldBeValid(IAWG awg)
        {
            Assert.AreNotEqual("\"\"", awg.CalibrationCatalog, "Calibration:CATalog? query returned nothing."); 
        }
		
        #endregion CALibration:CATalog?

        #region CALibration:LOG?
		
        #endregion CALibration:LOG?

        #region CALibration:LOG:CLEar
		
        #endregion CALibration:LOG:CLEar

        #region CALibration:LOG:DETails

        /// <summary>
        /// Forces the AWG to update its copy of the cal log details flag
        /// </summary>
        /// <param name="awg">the AWG object</param>
        public void GetTheCalibrationLogDetailStatus(IAWG awg)
        {
            awg.CalDetailsQuery();
        }

        public void CalLogDetailedModeShouldBe(IAWG awg, CalibrationLogDetails expectedState)
        {
            string expectedSyntax = expectedState == CalibrationLogDetails.On
                                        ? CalibrationLogDetailsOnSyntaxReceived
                                        : CalibrationLogDetailsOffSyntaxReceived;
            const string possibleErrorMessage = "Checking for the state of the detail mode for the Calibration Log";
            Assert.AreEqual(expectedSyntax, awg.CalibrationDetailsFlag, possibleErrorMessage);
        }
		
        #endregion CALibration:LOG:DETails

        #region CALibration:LOG:FAILuresonly

        /// <summary>
        /// Controls what is saved to the log file
        /// </summary>
        /// <param name="awg">the AWG object</param>
        /// <param name="logFailures"></param>
        public void CalibrationLogOnlyFailures(IAWG awg, CalibrationLogFailures logFailures)
        {
            string failureSyntax = logFailures == CalibrationLogFailures.On
                                       ? CalibrationLogFailuresOnSyntaxSend
                                       : CalibrationLogFailuresOffSyntaxSend;
            awg.CalSetForceFailure(failureSyntax);
        }

        /// <summary>
        /// Forces the AWG to update its cal fail only flag<para>
        /// by quering the AWG</para>
        /// </summary>
        /// <param name="awg">the AWG object</param>
        public void GetTheCalibrationLogFailureOnlyStatus(IAWG awg)
        {
            awg.CalFailOnlyQuery();
        }

        public void CalLogShouldBeSetToFailuresOnlyMode(IAWG awg, CalibrationLogFailures expectedMode)
        {
            string expectedSyntax = expectedMode == CalibrationLogFailures.On
                                        ? CalibrationLogFailuresOnSyntaxReceived
                                        : CalibrationLogFailuresOffSyntaxReceived;
            const string possibleErrorMessage = "Checking Calibration Log Failures Only state";
            Assert.AreEqual(expectedSyntax, awg.CalibrationFailOnlyFlag, possibleErrorMessage);
        }

        /// <summary>
        /// Sets the amount of details the log saves
        /// </summary>
        /// <param name="awg">the AWG object</param>
        /// <param name="setValue"></param>
        public void SetTheCalibrationLogToDetailedMode(IAWG awg, CalibrationLogDetails setValue)
        {
            string correctSyntax = setValue == CalibrationLogDetails.On
                                ? CalibrationLogDetailsOnSyntaxSend
                                : CalibrationLogDetailsOffSyntaxSend;
            awg.CalSetDetail(correctSyntax);
        }
		
        #endregion CALibration:LOG:FAILuresonly

        #region CALibration:RESTore
		// Currently not going down this path.  Issuing of this command on a calibrated AWG can cause real damage and lost in dollars
        #endregion CALibration:RESTore

        #region CALibration:RESult?

        //glennj 6/11/2013
        /// <summary>
        /// Forces the AWG to update it's local calResults in the AWG object
        /// </summary>
        /// <param name="awg">AWG object</param>
        /// <param name="optionalSubsystem"></param>
        /// <param name="optionalArea"></param>
        /// <param name="optionalProcedure"></param>
        public void GetTheCalibrationResult(IAWG awg, string optionalSubsystem = "", string optionalArea = "", string optionalProcedure = "")
        {
            awg.CalResult(optionalSubsystem, optionalArea, optionalProcedure);
        }
		
        //glennj 3/3/2014
        /// <summary>
        /// Apparently the best we can do is just make sure that it is not empty.
        /// </summary>
        /// <param name="awg"></param>
        public void CalibrationResultShouldNotBeEmpty(IAWG awg)
        {
            Assert.AreNotEqual("\"\"", awg.CalibrationResult);
        }

        #endregion CALibration:RESult?

        #region CALibration:RESult:TEMPerature?

        //glennj 3/3/2014
        /// <summary>
        /// Force the AWG to update it's local calResults for temperature in the AWG object
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="optionalSubsystem"></param>
        /// <param name="optionalArea"></param>
        /// <param name="optionalProcedure"></param>
        public void GetTemperatureForProcedure(IAWG awg, string optionalSubsystem, string optionalArea = "", string optionalProcedure = "")
        {
            awg.CalResultTemperature(optionalSubsystem, optionalArea, optionalProcedure);     
        }

        //glennj 3/3/2014
        /// <summary>
        /// Apparently the best we can do is just make sure that it is not empty.
        /// Maybe in future we might want to test the temperature in detail, but not today.
        /// </summary>
        /// <param name="awg"></param>
        public void CalibrationResultTemperatureShouldNotBeEmpty(IAWG awg)
        {
            Assert.AreNotEqual("\"\"", awg.CalibrationResultTemp, "The temperature for a procedure is missing.");
        }
		
        #endregion CALibration:RESult:TEMPerature?

        #region CALibration:RESult:TIME?

        //glennj 3/3/2014
        /// <summary>
        /// Force the AWG to update it's local calResults for time in the AWG object
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="optionalSubsystem"></param>
        /// <param name="optionalArea"></param>
        /// <param name="optionalProcedure"></param>
        public void GetTimeForProcedure(IAWG awg, string optionalSubsystem, string optionalArea = "", string optionalProcedure = "")
        {
            awg.CalResultTime(optionalSubsystem, optionalArea, optionalProcedure);
        }

        //glennj 3/3/2014
        /// <summary>
        /// Apparently the best we can do is just make sure that it is not empty.
        /// Maybe in future we might want to test the time in detail, but not today.
        /// </summary>
        /// <param name="awg"></param>
        public void CalibrationResultTimeShouldNotBeEmpty(IAWG awg)
        {
            Assert.AreNotEqual("\"\"", awg.CalibrationResultTime, "The time for a procedure is missing.");
        }
		
        #endregion CALibration:RESult:TIME?

        #region CALibration:RUNNing?
		
        #endregion CALibration:RUNNing?

        #region CALibration:STARt
		
        #endregion CALibration:STARt

        #region CALibration:STATe:FACTory?

        //glennj 6/11/2013
        /// <summary>
        /// Forces the AWG to update it's copy of cal_state_factory
        /// </summary>
        /// <param name="awg">the AWG object</param>
        /// <param name="subsystem">Optional parameter to query a subsytem</param>
        /// <param name="area">Optional parameter to query an area of a subsystem</param>
        public void GetTheFactoryStateOfTheCalibration(IAWG awg, string subsystem = "", string area = "")
        {
            awg.CalFactoryStateQuery(subsystem, area);
        }

        /// <summary>
        /// This tests the property for state of the factory calibration<para>
        /// Do a get first to update the property</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="dataType"></param>
        public void StateoftheCalibrationforAWGShouldHaveAVaildFormat(IAWG awg, CalibrationDataType dataType)
        {
            string state;
            string possibleErrorMessage;
            if (dataType == CalibrationDataType.Factory)
            {
                state = awg.CalStateFactory;
                possibleErrorMessage = "Invalid Factory State in the Calibration for the AWG. Actual value: ";
            }
            else
            {
                state = awg.CalStateUser;
                possibleErrorMessage = "Invalid User State in the Calibration for the AWG. Actual value: ";
            }

            if (state == "")
            {
                Assert.Fail("AWG not Calibrated No Results to Validate");
            }
            var validatePreMatcher= new Regex(@".+:=S\((?<calState>C|U).+");
            Match preMatch = validatePreMatcher.Match(state); // If the AWG is uncalibrated it will only return a "U"
            Assert.IsTrue(preMatch.Success);                        // Need to handle that first and then handle date and temp
            string calState = preMatch.Groups["calState"].Value;
            switch (calState)
            {
                case "C":
                    var validateMatcher = new Regex(@".*:=S\(C\),D\(.*\),T\(.*\)");
                    var match = validateMatcher.Match(state);
                    Assert.IsTrue(match.Success);
                    break;
                case "U":
                    Assert.AreEqual("U", calState);
                    break;
                default:
                    Assert.Fail(possibleErrorMessage + state);
                    break;
            }          
        }
		
        #endregion CALibration:STATe:FACTory?

        #region CALibration:STATe:USER?

        //sforell 8/20/13 added method
        /// <summary>
        /// Gets the calibration user state for the awg, subsystem or area 
        /// 
        /// Only pass in the optional parameters if they are needed, otherwise do not use them 
        /// </summary>
        /// <param name="awg">the AWG object</param>
        /// <param name="subsystem">Optional parameter to query a subsytem</param>
        /// <param name="area">Optional parameter to query an area of a subsystem</param>
        public void GetCalUserState(IAWG awg, string subsystem = "", string area = "")
        {
            awg.CalUserStateQuery(subsystem, area);
        }

        //sforell 8/21/13 added
        /// <summary>
        /// Checks that the CalUserState contains the expected value
        /// If the CalUserState is calibrated then checks to make sure it has a valid temperature
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedValue">The string to try and find in the awg cal user state</param>
        public void CalibrationUserStateShouldContain(IAWG awg, string expectedValue)
        {
            bool containsValue = awg.CalStateUser.Contains(expectedValue);
            Assert.AreEqual(true, containsValue, "Calibration User State did not contain: " + expectedValue);
        }

        //sforell 8/21/13 added
        /// <summary>
        /// If the system is calibrated, checks that the temperature is > 0
        /// </summary>
        /// <param name="awg"></param>
        public void CalibrationUserStateTempShouldBeValid(IAWG awg)
        {
            //Do not check the temp if the system is not calibrated
            if (!awg.CalStateUser.Contains("(U")) return;

            //check for valid temperature if the system says it has been calibrated
// ReSharper disable StringIndexOfIsCultureSpecific.1
            int tempStart = awg.CalStateUser.IndexOf("T(") + 2;
// ReSharper restore StringIndexOfIsCultureSpecific.1
            int tempEnd = awg.CalStateUser.LastIndexOf(')');
            try
            {
                string tempStr = awg.CalStateUser.Substring(tempStart, tempEnd - tempStart);
                int tempInt = Convert.ToInt32(tempStr);
                Assert.AreEqual(true, tempInt > 0);
            }
            catch
            {
                Assert.Fail("Could not find a temperature value in the Awg Cal User State");
            }
        }

        //sforell 8/21/13 added
        /// <summary>
        /// Checks that the cal user state has a date that matches today's
        /// 
        /// Note: this assumes a Cal was run in the same Feature File/Test case
        /// </summary>
        /// <param name="awg"></param>
        public void CalibrationUserStateDateShouldBeToday(IAWG awg)
        {
            string[] userStateData = awg.CalStateUser.Split(',');
            string dateString = userStateData[1];
            //remove the leader 'D' and then remove the parenthesis
            dateString = dateString.Remove(0, 1).Trim('(', ')');
            DateTime date = Convert.ToDateTime(dateString);
            Assert.AreEqual(DateTime.Now.Year, date.Year);
            Assert.AreEqual(DateTime.Now.Month, date.Month);
            Assert.AreEqual(DateTime.Now.Day, date.Day);
            Assert.AreEqual(DateTime.Now.Hour, date.Hour);
            
        }

        #endregion CALibration:STATe:USER?

        #region CALibration:STOP:STATe?

        #endregion CALibration:STOP:STATe?

        #endregion Published


        #region Non-Published

        #region CALibration:CONTrol:COUNt

        #endregion CALibration:CONTrol:COUNt

        #region CALibration:CONTrol:HALT

        #endregion CALibration:CONTrol:HALT

        #region CALibration:CONTrol:LOOP

        #endregion CALibration:CONTrol:LOOP

        #region CALibration:DATA:FACTory?

        public void GetTheAWGFactoryCalibrationDataForTheXpath(IAWG awg, string requiredSubsystem, string optionalArea = "", string optionalProcedure = "")
        {
            awg.GetCalDataFactory(requiredSubsystem, optionalArea, optionalProcedure);
        }

        public void CalibrationDataFromAWGShouldBeValid(IAWG awg, CalibrationDataType calDataType)
        {
            string result = "";
            switch (calDataType)
            {
                case CalibrationDataType.Factory:
                    if (string.IsNullOrEmpty(awg.CalibrationDataFactory) || awg.CalibrationDataFactory.StartsWith("-340"))
                    {
                        Assert.Fail("Calibration factory data is invalid.");
                    }
                    result = _utils.ValidateXML(awg.CalibrationDataFactory);
                    break;

                case CalibrationDataType.User:
                    if (string.IsNullOrEmpty(awg.CalibrationDataUser) || awg.CalibrationDataUser.StartsWith("-340"))
                    {
                        Assert.Fail("Calibration user data is invalid.");
                    }
                    result = _utils.ValidateXML(awg.CalibrationDataUser);
                    break;
            }
            Assert.AreEqual("", result, "XML was not valid because " + result);
        }
		
        #endregion CALibration:DATA:FACTory?

        #region CALibration:DATA:USER

        /// <summary>
        /// No alternate set of constants can be passed in.
        /// </summary>
        /// <param name="awg">the AWG object</param>
        /// <param name="requiredSubsystem"></param>
        /// <param name="optionalArea"></param>
        /// <param name="optionalProcedure"></param>
        public void SetTheAWGUserCalibrationData(IAWG awg, string requiredSubsystem, string optionalArea = "", string optionalProcedure = "")
        {
            _utils.ValidateXML(awg.CalibrationDataUser);             // Throws an exception if the xml is not valid

            awg.CalDataUser(awg.CalibrationDataUser, requiredSubsystem, optionalArea, optionalProcedure);
        }

        public void GetTheAWGUserCalibrationDataForTheXpath(IAWG awg, string requiredSubsystem, string optionalArea = "", string optionalProcedure = "")
        {
            awg.CalDataUserQuery(requiredSubsystem, optionalArea, optionalProcedure);
        }

        /// <summary>
        /// Expected well documented xml cal constants files are to be in the below directory.
        /// The names of the cal constants should have proper names,
        /// starting with subsystem and underscores connecting the names
        /// in the order of subsystem, area and procedure
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="fileName"></param>
        public void LoadTheCalibrationData(IAWG awg, string fileName)
        {
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

            dir += "\\Tektronix\\AWG\\AWG70k\\TestFramework\\User" + "\\" + fileName + ".xml";

            if (!File.Exists(dir)) { Assert.Fail("Missing file: " + dir); }

            awg.CalibrationDataUser = "";

            byte[] b = File.ReadAllBytes(dir);

            UTF8Encoding enc = new UTF8Encoding();

            awg.CalibrationDataUser = enc.GetString(b);
        }

        /// <summary>
        /// Saves to a named file the string at awg.CalibrationDataFactory or awg.CalibrationDataUser
        /// depending on the specified calibration data type.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="dataType"></param>
        /// <param name="fileName"></param>
        public void SaveTheCalibrationData(IAWG awg, CalibrationDataType dataType, string fileName)
        {
            string calConstants = (dataType == CalibrationDataType.Factory ? awg.CalibrationDataFactory : awg.CalibrationDataUser);
            string possibleErrorMessage = (dataType == CalibrationDataType.Factory ? "Factory Data Constants empty" : "User Data Constants empty");
            Assert.IsTrue((calConstants != ""), possibleErrorMessage);

            string dir = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            dir += "\\Tektronix\\AWG\\AWG70k";
            if (!Directory.Exists(dir)) { Directory.CreateDirectory(dir); }
            dir += "\\TestFramework";
            if (!Directory.Exists(dir)) { Directory.CreateDirectory(dir); }
            dir += (dataType == CalibrationDataType.Factory ? "\\Factory" : "\\User");
            if (!Directory.Exists(dir)) { Directory.CreateDirectory(dir); }

            dir += "\\" + fileName + ".xml";

            FileInfo xmlFile = new FileInfo(dir);

            using (StreamWriter xmlResults = xmlFile.CreateText())
            {
                xmlResults.WriteLine(calConstants);
            }
        }
		
        #endregion CALibration:DATA:USER

        #region CALibration:LOOP?
		
        #endregion CALibration:LOOP?

        #region CALibration:SELect

        // Unkown 01/01/01
        /// <summary>
        /// Selects all calibration procedures.
        /// </summary>
        /// <param name="awg">the AWG object</param>
        public void SelectAllCal(IAWG awg)
        {
            awg.CalSelect("ALL");
        }

        // Unkown 01/01/01
        /// <summary>
        /// Selects calibration procedures specified by the selection variable.
        /// 
        /// CAL:SEL
        /// </summary>
        /// <param name="awg">the AWG object</param>
        /// <param name="requiredSubsystem">Required at a minimum</param>
        /// <param name="optionalArea">Optional but required if there is procedure</param>
        /// <param name="optionalProcedure">Optional</param>
        public void SelectCal(IAWG awg, string requiredSubsystem, string optionalArea = "", string optionalProcedure = "")
        {

            string dequotedSubsystem =  _utils.Dequotify(requiredSubsystem);
            string dequotedArea      = (optionalArea != "") ? _utils.Dequotify(optionalArea) : optionalArea;
            string dequotedProcedure = (optionalProcedure != "") ? _utils.Dequotify(optionalProcedure) : optionalProcedure;

            awg.CalSelect(dequotedSubsystem, dequotedArea, dequotedProcedure);
        }
		
        #endregion CALibration:SELect

        #region CALibration:TYPE:CATalog?

        /// <summary>
        /// Forces the AWG to update its copy of the calibration catalog
        /// </summary>
        /// <param name="awg">the AWG object</param>
        public void GetTheAwgCalibrationTypeCatalog(IAWG awg)
        {
            awg.CalTypeCatalogQuery();
        }

        /// <summary>
        /// Using the property, , that should be updated using<para>
        /// CALibration:TYPE:CATalog?, a list of types is passed</para><para>
        /// to check to see if they are present.</para>
        /// </summary>
        /// <param name="awg">The specific awg</param>
        /// <param name="listOfTypes">CSV of types</param>
        public void CalibrationTypeCatalogFromAWG1ShouldContain(IAWG awg, string listOfTypes)
        {
            var stringSeparators = new [] { "," };
            var calType = listOfTypes.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

            foreach (var s in calType)
            {
                var containsType = awg.CalibrationTypeCatalog.Contains(s);
                if (!containsType)
                {
                    Assert.IsFalse(containsType, "Calibration catalog is not valid");
                }
            }
        }

        #endregion CALibration:TYPE:CATalog?

        #region CALibration:TYPE

        /// <summary>
        /// Sets an awg to a cal type
        /// </summary>
        /// <param name="awg">the AWG object</param>
        /// <param name="calType"></param>
        public void SetTheCalibrationTypeToType(IAWG awg, CalibrationType calType)
        {
            string calTypeSyntax = (calType == CalibrationType.External) ? CalibrationTypeExternalSyntax : CalibrationTypeInternalSyntax;
            awg.CalType(calTypeSyntax);
        }

        /// <summary>
        /// Forces the AWG to update its copy of the calibration type
        /// </summary>
        /// <param name="awg">the AWG object</param>
        public void GetTheCalibrationType(IAWG awg)
        {
            awg.CalTypeQuery();
        }

        public void CalibrationTypeOnAWGShouldBe(IAWG awg, CalibrationType expectedType)
        {
            string expectedSyntax = (expectedType == CalibrationType.External)
                                        ? CalibrationTypeExternalSyntax
                                        : CalibrationTypeInternalSyntax;
            const string possibleErrorMessage = "Checking the copy for the calibration type.";
            Assert.AreEqual(expectedSyntax, awg.CalibrationType, possibleErrorMessage);
        }

        public void CalibrationTypeListValidation(IAWG awg)
        {
            // In order to be considered valid for this step, it should contain "INT"
            const string currentCalCatTypes = "INT";
            if (awg.CalibrationTypeCatalog == "")
            {
                const string errorMessage = "List for calibration types was empty";
                Assert.Fail(errorMessage);
            }
            if (!awg.CalibrationTypeCatalog.Contains(currentCalCatTypes))
            {
                string errorMessage = "Calibration type of INT was not found in the list: " + awg.CalibrationTypeCatalog;
                Assert.Fail(errorMessage);
            }
        }


        #endregion CALibration:TYPE

        #region CALibration:UNSelect

        // Unkown 01/01/01
        /// <summary>
        /// Unselects all calibration procedures.
        /// 
        /// CAL:UNS ALL
        /// </summary>
        /// <param name="awg">the AWG object</param>
        public void UnselectAllCal(IAWG awg)
        {
            awg.CalUnselect("ALL");
        }

        // Unkown 01/01/01
        /// <summary>
        /// Unselects calibration procedures specified by the selection variable.
        /// 
        /// CAL:UNS
        /// </summary>
        /// <param name="awg">the AWG object</param>
        /// <param name="requiredSubsystem">Required at a minimum</param>
        /// <param name="optionalArea">Optional area, required if there is procedure</param>
        /// <param name="optionalProcedure">Optional procedure</param>
        public void UnselectCal(IAWG awg, string requiredSubsystem, string optionalArea = "", string optionalProcedure = "")
        {
            awg.CalUnselect(requiredSubsystem, optionalArea, optionalProcedure);
        }
		
        #endregion CALibration:UNSelect

        #endregion Non-Published

        #region CALibration:SELect:VERify?

        //glennj 6/11/2013
        /// <summary>
        /// Checks to see if a the test specified by the test variable is selected.
        /// </summary>
        /// <param name="awg">the AWG object</param>
        /// <param name="requiredSubsystem">Valid name</param>
        /// <param name="requiredArea">Valid name</param>
        /// <param name="requiredProcedure">Valid name</param>
        public void CalShouldBeSelected(IAWG awg, string requiredSubsystem, string requiredArea, string requiredProcedure)
        {
            ToBeSelectedOrNot(awg, requiredSubsystem, requiredArea, requiredProcedure, true);
        }

        //glennj 6/11/2013
        /// <summary>
        /// Checks to see if a the test specified by the test variable is not selected.
        /// </summary>
        /// <param name="awg">the AWG object</param>
        /// <param name="requiredSubsystem">Valid name</param>
        /// <param name="requiredArea">Valid name</param>
        /// <param name="requiredProcedure">Valid name</param>
        public void CalShouldNotBeSelected(IAWG awg, string requiredSubsystem, string requiredArea, string requiredProcedure)
        {
            ToBeSelectedOrNot(awg, requiredSubsystem, requiredArea, requiredProcedure, false);
        }

        //glennj 2/28/2014
        /// <summary>
        /// Given the subsystem, area and procedure verify if it is selected or not
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="requiredSubsystem"></param>
        /// <param name="requiredArea"></param>
        /// <param name="requiredProcedure"></param>
        /// <param name="selected">True tests for selected</param>
        public void ToBeSelectedOrNot(IAWG awg, string requiredSubsystem, string requiredArea, string requiredProcedure,
                                      bool selected)
        {
            string dequotedSubsystem = _utils.Dequotify(requiredSubsystem);
            string dequotedArea = _utils.Dequotify(requiredArea);
            string dequotedProcedure = _utils.Dequotify(requiredProcedure);
            string selection = requiredSubsystem;
            if (requiredArea != "")
            {
                selection = selection + ", " + requiredArea;
                if (requiredProcedure != "")
                {
                    selection = selection + ", " + requiredProcedure;
                }
            }

            string isSelected = awg.CalSelectVerify(dequotedSubsystem, dequotedArea, dequotedProcedure);

            if (selected)
            {
                string possibleErrorMessage =
                "Specified calibration procedure was unselected when it was expected to be selected for " + selection;
                Assert.AreEqual("1", isSelected, possibleErrorMessage);
            }
            else
            {
                string possibleErrorMessage =
                "Specified calibration procedure was selected when it was expected to be unselected for " + selection;
                Assert.AreEqual("0", isSelected, possibleErrorMessage);
            }
        }

        #endregion CALibration:SELect:VERify?

        #region CALibration:STARt

        //glennj 6/11/2013
        /// <summary>
        /// Starts internal calibration
        /// </summary>
        /// <param name="awg">the AWG object</param>
        public void RunCalibration(IAWG awg)
        {
            awg.CalStart();
        }

        #endregion CALibration:STARt

        #region CALibration:RUNNing?

        //glennj 6/11/2013
        /// <summary>
        /// Returns whether a calibration procedure is running
        /// </summary>
        /// <param name="awg">the AWG object</param>
        public void CalShouldBeRunning(IAWG awg)
        {
            string response = awg.CalRunning();
            const string badResponse = "\"\""; //Two quotes denotes cal isn't running a procedure

            //Execute
            Assert.AreNotEqual(badResponse, response, "Calibration is not running.");
        }

        #endregion CALibration:RUNNing?

        #region CALibration:STOP:STATe?

        //glennj 6/11/2013
        /// <summary>
        /// Forces the AWG to update its copy of the cal stop state
        /// </summary>
        /// <param name="awg">the AWG object</param>
        public void GetCalibrationStopState(IAWG awg)
        {
            awg.CalStopState();
        }

        public void CalibrationStopStateShouldBe(IAWG awg, CalibrationStoppedState expectedState)
        {
            string expectSyntax = (expectedState == CalibrationStoppedState.Stopped)
                                      ? CalibrationControlStoppedStateStoppedSyntax
                                      : CalibrationControlStoppedStateNotStoppedSyntax;
            const string possibleErrorMessage = ErrorMessageCalibrationCheckingStoppedState;
            Assert.AreEqual(expectSyntax, awg.CalibrationStopState, possibleErrorMessage);
        }

        #endregion CALibration:STOP:STATe?

        #region CALibration:CONTrol:HALT

        //glennj 6/11/2013
        /// <summary>
        /// Sets the halt value to what is specified in the setValue variable.
        /// </summary>
        /// <param name="awg">the AWG object</param>
        /// <param name="haltMode">set the boolean HALT variable.</param>
        public void SetCalibrationHalt(IAWG awg, CalibrationControlHaltMode haltMode)
        {
            string haltSyntax = (haltMode == CalibrationControlHaltMode.On)
                                    ? CalibrationControlHaltOnSyntaxSend
                                    : CalibrationControlHaltOffSyntaxSend;
            awg.CalHalt(haltSyntax);
        }

        //glennj 6/11/2013
        /// <summary>
        /// Forces the AWG to update it's local cal_halt state
        /// </summary>
        /// <param name="awg">the AWG object</param>
        public void GetCalibrationHaltUpdate(IAWG awg)
        {
            awg.CalHaltQuery();
        }

        public void CalibrationHaltModeShouldBe(IAWG awg, CalibrationControlHaltMode expectMode)
        {
            string expectedHaltSyntax = (expectMode == CalibrationControlHaltMode.On)
                                    ? CalibrationControlHaltOnSyntaxReceived
                                    : CalibrationControlHaltOffSyntaxReceived;
            Assert.AreEqual(expectedHaltSyntax, awg.CalibrationHalt, ErrorMessageCalibrationCheckingHaltMode);
        }

        #endregion CALibration:CONTrol:HALT

        #region CALibration:CONTrol:LOOP

        //glennj 6/11/2013
        /// <summary>
        /// Sets the value of the calibration loop control
        /// </summary>
        /// <param name="awg">the AWG object</param>
        /// <param name="setMode"></param>
        public void SetCalibrationLoopControl(IAWG awg, CalibrationControlLoopMode setMode)
        {
            string setValue = "";
            switch (setMode)
            {
                case CalibrationControlLoopMode.Once:
                    setValue = CalibrationControlLoopOnceSyntaxSend;
                    break;
                case CalibrationControlLoopMode.Continuous:
                    setValue = CalibrationControlLoopContinuousSyntaxSend;
                    break;
                case CalibrationControlLoopMode.Count:
                    setValue = CalibrationControlLoopCountSyntaxSend;
                    break;
            }
            awg.CalLoop(setValue);
        }

        //glennj 6/11/2013
        /// <summary>
        /// Forces the AWG to update it's local cal loop state
        /// </summary>
        /// <param name="awg">the AWG object</param>
        public void UpdateCalibrationControlLoopCopy(IAWG awg)
        {
            awg.CalControlLoopQuery();
        }

        public void CalibrationLoopControlShouldBe(IAWG awg, CalibrationControlLoopMode expectedMode)
        {
            string expectedSyntax = "";
            switch (expectedMode)
            {
                case CalibrationControlLoopMode.Once:
                    expectedSyntax = CalibrationControlLoopOnceSyntaxReceived;
                    break;
                case CalibrationControlLoopMode.Continuous:
                    expectedSyntax = CalibrationControlLoopContinuousSyntaxReceived;
                    break;
                case CalibrationControlLoopMode.Count:
                    expectedSyntax = CalibrationControlLoopCountSyntaxReceived;
                    break;
            }

            const string possibleErrorMessage = "Checking the calibration loop control.";
            Assert.AreEqual(expectedSyntax, awg.CalibrationLoopState, possibleErrorMessage);
        }

        #endregion CALibration:CONTrol:LOOP

        #region CALibration:CONTrol:COUNt

        //glennj 6/11/2013
        /// <summary>
        /// Sets the calibration loop count value.
        /// </summary>
        /// <param name="awg">the AWG object</param>
        /// <param name="setValueAs"></param>
        /// <param name="setValue">Desired loop count value to be set</param>
        public void AwgCalLoopCount(IAWG awg, CalibrationLoopCountTypeAs setValueAs,string setValue = "")
        {
            var finalValue = setValue;
            switch (setValueAs)
            {
                case CalibrationLoopCountTypeAs.Min:
                    finalValue = CalibrationLoopCountMinSyntax;
                    break;
                case CalibrationLoopCountTypeAs.Max:
                    finalValue = CalibrationLoopCountMaxSyntax;
                    break;
            }
            awg.CalLoopCount(finalValue);
        }

        //glennj 6/11/2013
        /// <summary>
        /// Forces the AWG to update it's local cal_loop_count
        /// </summary>
        /// <param name="awg">the AWG object</param>
        public void UpdateCalibrationLoopCount(IAWG awg)
        {
            awg.CalLoopCountQuery();
        }

        public void CalibrationLoopCountShouldBe(IAWG awg, string expectedCount)
        {
            Assert.AreEqual(Convert.ToInt32(expectedCount), Convert.ToInt32(awg.CalibrationLoopCount), "Checking the calibration loop count.");
        }

        #endregion CALibration:CONTrol:COUNt

        #region CALibration:LOOPs

        //glennj 6/11/2013
        /// <summary>
        /// Forces the AWG to update it's local cal_loops_completed state
        /// </summary>
        /// <param name="awg">AWG object</param>
        public void GetTheNumberOfCalibrationLoopsThatHasCompleted(IAWG awg)
        {
            awg.CalLoopQuery();
        }

        public void NumberOfCalibrationLoopsCompletedShouldBe(IAWG awg, string expectedLoopCount)
        {
            Assert.AreEqual(Convert.ToInt32(expectedLoopCount), Convert.ToInt32(awg.CalibrationLoopsCompleted), "Checking the for number of completed loops for calibration.");
        }

        #endregion CALibration:LOOPs

        #region CALibration:LOG

        //glennj 6/11/2013
        /// <summary>
        /// Forces the AWG to clear the calibration log.
        /// </summary>
        /// <param name="awg">the AWG object</param>
        public void ClearTheAWGCalibrationLog(IAWG awg)
        {
            awg.CalLogClear();
        }

        //glennj 6/11/2013
        /// <summary>
        /// Forces the AWG to update it's local copy of cal_result
        /// </summary>
        /// <param name="awg">the AWG object</param>
        public void GetTheAWGCalibrationLog(IAWG awg)
        {
            awg.GetCalLog();
        }

        public void CalibrationLogShouldBeEmpty(IAWG awg, bool trueOrFalse)
        {
            if (trueOrFalse) // if true
            {
                Assert.AreEqual("\"\"", awg.CalibrationLog);
            }
            else
            {
                Assert.AreNotEqual("\"\"", awg.CalibrationLog);
            }      
        }

        #endregion CALibration:LOG

    }
}
