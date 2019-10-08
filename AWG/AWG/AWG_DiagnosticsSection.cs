
using System;

// ReSharper disable CheckNamespace
namespace AwgTestFramework
// ReSharper restore CheckNamespace
{
    public partial class AWG
    {

        public string DiagResult { get; set; }
        public string DiagnosticTestName { get; set; }
        public string DiagnositcData { get; set; }
        public string DiagnosticHalt { get; set; }
        public string DiagImmediateResult { get; set; }
        public string DiagLog { get; set; }
        public string DiagLogDetail { get; set; }
        public string DiagLogFail { get; set; }
        public string DiagLoopState { get; set; }
        public string DiagLoopCount { get; set; }
        public string DiagLoops { get; set; }
        public string DiagPostResult { get; set; }
        public string DiagTemp { get; set; }
        public string DiagTime { get; set; }
        /// <summary>
        /// Using DIAGnostic:RUNNing? to update property
        /// </summary>
        public string DiagRunningState { get; set; }

        /// <summary>
        /// Results of the last *TST?
        /// </summary>
        public string DiagTstResult { get; set; }

        public string DiagStopState { get; set; }
        public string DiagnosticActiveMode { get; set; }
        public string DiagnosticType { get; set; }
        /// <summary>
        /// Property to contain the response from DIAGnostic:TYPE:CATalog?
        /// </summary>
        public string DiagnosticTypeCatalog { get; set; }

        public string DiagnosticCatalogOfSubsystems { get; set; }
        public string DiagnosticCatalogOfAreas { get; set; }
        public string DiagnosticCatalogOfTests { get; set; }

        public string DiagnosticSubsystemSelected { get; set; }
        public string DiagnosticAreaSelected { get; set; }
        public string DiagnosticTestSelected { get; set; }

        public string DiagnosticTestXpath { get; set; }

        //glennj 6/12/2013
        /// <summary>
        /// Sets the active mode
        /// </summary>
        /// <param name="command">Active mode selection of cal, diag, or norm</param>
        public void DiagActiveMode(string command)
        {
            _pi.SetAwgDiagActiveMode(command);
        }

        //glennj 6/12/2013
        /// <summary>
        /// Gets the active mode and updates the object's local copy diag_active_mode
        /// </summary>
        /// <returns>Current active mode</returns>
        public void DiagActiveModeQuery()
        {
            DiagnosticActiveMode = _pi.GetAwgDiagActiveMode();
        }

        //glennj 6/12/2013
        /// <summary>
        /// Aborts Diagnostics
        /// </summary>
        public void DiagAbort()
        {
            _pi.AbortAwgDiag();
        }

        //glennj 6/12/2013
        /// <summary>
        /// Sends No-Op string to PI for use in debugging CallMonitor sessions (and whatever else you can think of)
        /// </summary>
        /// <param name="comment">The text string you want to see in the CallMonitor log</param>
        public void DiagComment(string comment)
        {
            _pi.AwgDiagComment(comment);
        }

        public void DiagDelayInMSec(string delayInMSec)
        {
            _pi.GetAwgDiagDelayInMSec(delayInMSec);
        }

        public string DiagManufacturingMode()
        {
            string response = _pi.GetAwgDiagManufacturingMode();
            return response;
        }

        //glennj 6/12/2013
        /// <summary>
        /// Sets the value of the loop count for diagnostics.
        /// </summary>
        /// <param name="setValue">Value of the loop count</param>
        public void DiagControlCount(string setValue)
        {
            _pi.SetAwgDiagControlCount(setValue);
        }

        //glennj 6/12/2013
        /// <summary>
        /// Forces the AWG to update it's local copy of the loop count
        /// </summary>
        /// <returns>Current Diagnostic loop count</returns>
        public void DiagControlCountQuery()
        {
            DiagLoopCount = _pi.GetAwgDiagControlCount();
        }

        //glennj 6/12/2013
        /// <summary>
        /// Sets the diagnostic loop setting 
        /// </summary>
        /// <param name="setting">Diagnostic loop setting</param>
        public void DiagControlLoop(string setting)
        {
            _pi.SetAwgDiagControlLoop(setting);
        }

        //glennj 6/12/2013
        /// <summary>
        /// Update the local copy of the diagnostic loop setting 
        /// </summary>
        /// <returns>Current Diagnostic loop setting</returns>
        public void DiagControlLoopQuery()
        {
            DiagLoopState = _pi.GetAwgDiagControlLoop();
        }

        //glennj 6/12/2013
        /// <summary>
        /// Gets results of last executed diagnostic test
        /// </summary>
        /// <returns>Result of last executed diagnostic test</returns>
        public void DiagData()
        {
            DiagnositcData = _pi.GetAwgDiagData();
        }


        //glennj 6/12/2013
        /// <summary>
        /// Sets the value of halt for diagnostics.
        /// </summary>
        /// <param name="setValue">Halt value (OFF|ON)</param>
        public void DiagHalt(string setValue)
        {
            _pi.SetAwgDiagHalt(setValue);
        }

        //glennj 6/12/2013
        /// <summary>
        /// Gets the value of halt for diagnostics.
        /// </summary>
        /// <returns>Current Diagnostic halt state</returns>
        public void DiagHaltQuery()
        {
            DiagnosticHalt = _pi.GetAwgDiagHalt();
        }

        //glennj 6/12/2013
        /// <summary>
        /// Executes all of the NORMal diagnostic tests
        /// </summary>
        public void DiagImmediate()
        {
            _pi.AwgDiagImmediate();
        }

        //glennj 6/12/2013
        /// <summary>
        /// Executes the selected tests and returns the results<para>
        /// in the form of a numeric of values of 0 for no errors </para><para>
        /// or -330 for one or more tests failed.</para><para>
        /// Results are saved in a local copy.</para>
        /// </summary>
        /// <returns>Results from the diagnostics</returns>
        public void DiagImmediateQuery()
        {
            DiagImmediateResult = _pi.AwgDiagImmediateQuery();
        }


        #region DIAGnostic:CATalog

        //glennj 9/10/2013
        /// <summary>
        /// Using DIAG:CAT? get the diagnostic catalog
        /// </summary>
        /// <returns>List of tests per subsystem and/or area</returns>
        public void GetDiagCatalog(string subsystem = "", string area = "")
        {
            if ((subsystem == "") && (area == ""))
            {
                DiagnosticCatalogOfSubsystems = _util.Dequotify( _pi.GetAwgDiagCatalog(subsystem, area));
            }
            else if ((subsystem != "") && (area == ""))
            {
                DiagnosticCatalogOfAreas = _util.Dequotify(_pi.GetAwgDiagCatalog(subsystem, area));
            }
            else
            {
                DiagnosticCatalogOfTests = _util.Dequotify(_pi.GetAwgDiagCatalog(subsystem, area));
            }
        }

        /// <summary>
        /// Given a valid index (with in range), return the nth<para>
        /// subsystem, where n is the index</para>
        /// </summary>
        /// <param name="subsystemIndex"></param>
        /// <returns></returns>
        public void SelectDiagSubsystemFromPropertyList(string subsystemIndex)
        {
            int index;
            try
            {
                index = Convert.ToInt32(subsystemIndex);
                if (index > 0) --index;
            }
            catch (Exception)
            {
                index = 0;
            }

            string subsystem = "";

            string[] subsystems = DiagnosticCatalogOfSubsystems.Split(',');

            if (index < subsystems.Length)
            {
                subsystem = subsystems[index];
            }

            DiagnosticSubsystemSelected = subsystem;
        }

        /// <summary>
        /// Given a valid index (with in range), assign the nth<para>
        /// area, where n is the index, to the selected area property</para>
        /// </summary>
        /// <param name="areaIndex"></param>
        /// <returns></returns>
        public void SelectDiagAreaFromPropertyList(string areaIndex)
        {
            int index;
            try
            {
                index = Convert.ToInt32(areaIndex);
                if (index > 0) --index;
            }
            catch (Exception)
            {

                index = 0;
            }

            string area = "";

            string[] areas = DiagnosticCatalogOfAreas.Split(',');

            if (index < areas.Length)
            {
                area = areas[index];
            }

            DiagnosticAreaSelected = area;
        }

        /// <summary>
        /// Given a valid index (with in range), assign the nth<para>
        /// test, where n is the index, to the selected test property</para>
        /// </summary>
        /// <param name="testIndex"></param>
        /// <returns></returns>
        public void SelectDiagTestFromPropertyList(string testIndex)
        {
            int index;
            try
            {
                index = Convert.ToInt32(testIndex);
                if (index > 0) --index;
            }
            catch (Exception)
            {

                index = 0;
            }

            string test = "";

            string[] tests = DiagnosticCatalogOfTests.Split(',');

            if (index < tests.Length)
            {
                test = tests[index];
            }

            DiagnosticTestSelected = test;
        }

        #endregion DIAGnostic:CATalog

        //glennj 6/12/2013
        /// <summary>
        /// Gets the diagnostic log and saves a local copy
        /// </summary>
        /// <returns>Diagnostic log</returns>
        public void DiagLogQuery()
        {
            DiagLog = _pi.GetAwgDiagLog();
        }

        //glennj 6/12/2013
        /// <summary>
        /// Clears the diagnostic log
        /// </summary>
        /// <returns>Diagnostic log</returns>
        public void DiagLogClear()
        {
            _pi.ClearAwgDiagLog();
        }

        //glennj 6/12/2013
        /// <summary>
        /// Changes the diagnostics log to more or less detailed
        /// </summary>
        /// <param name="setValue">Log detail flag value</param>
        public void DiagLogDetails(string setValue)
        {
            _pi.SetAwgDiagLogDetails(setValue);
        }

        //glennj 6/12/2013
        /// <summary>
        /// Gets and saves the diagnostics log detail flag value locally
        /// </summary>
        /// <returns>Log detail flag value</returns>
        public void DiagLogDetailsQuery()
        {
            DiagLogDetail = _pi.GetAwgDiagLogDetails();
        }

        //glennj 6/12/2013
        /// <summary>
        /// Changes the diagnostics log to enable or disable failure mode
        /// </summary>
        /// <param name="setValue">Log detail flag value</param>
        public void DiagLogFailuresOnly(string setValue)
        {
            _pi.SetwgDiagLogFailuresOnly(setValue);
        }

        //glennj 6/12/2013
        /// <summary>
        /// Gets the diagnostics log failure mode and saves a copy
        /// </summary>
        /// <returns>Diagnostics log failure mode</returns>
        public void DiagLogFailuresOnlyQuery()
        {
            DiagLogFail = _pi.GetAwgDiagLogFailuresOnly();
        }

        //glennj 3/18/2014
        /// <summary>
        /// Get the current completed loop counts
        /// </summary>
        public void GetDiagLoops()
        {
            DiagLoops = _pi.GetAwgDiagLoops();
        }

        //glennj 6/12/2013
        /// <summary>
        /// Gets the results of one or more tests and saves it locally in diag_result
        /// </summary>
        /// <returns>Diagnostic result</returns>
        public void DiagResultQuery(string optionalSubsystem = "", string optionalArea = "", string optionalTest = "")
        {
            DiagResult = _pi.GetAwgDiagResult(optionalSubsystem, optionalArea, optionalTest);
        }

        //glennj 6/12/2013
        /// <summary>
        /// Gets the highest temperature during specified diag test.
        /// </summary>
        /// <param name="optionalSubsystem"></param>
        /// <param name="optionalArea"></param>
        /// <param name="optionalTest"></param>
        /// <returns>Temperature during specified diag test</returns>
        public void DiagResultTempQuery(string optionalSubsystem = "", string optionalArea = "", string optionalTest = "")
        {
            DiagTemp = _pi.GetAwgDiagResultTemp(optionalSubsystem, optionalArea, optionalTest);
        }

        //glennj 6/12/2013
        /// <summary>
        /// Gets the time during specified diag test.
        /// </summary>
        /// <param name="optionalSubsystem"></param>
        /// <param name="optionalArea"></param>
        /// <param name="optionalTest"></param>
        /// <returns>Temperature during specified diag test</returns>
        /// <returns>Time during specified diag test</returns>
        public void DiagResultTimeQuery(string optionalSubsystem = "", string optionalArea = "", string optionalTest = "")
        {
            DiagTime = _pi.GetAwgDiagResultTime(optionalSubsystem, optionalArea, optionalTest);
        }

        //glennj 6/12/2013
        /// <summary>
        /// Verifies that Diagnostic tests are currently running on the AWG
        /// </summary>
        /// <returns>Running state of diagnostics</returns>
        public void GetDiagRunningState()
        {
            DiagRunningState = _pi.GetAwgDiagRunning();
        }

        //glennj 6/12/2013
        /// <summary>
        /// Selects the specified test in the specified category context.
        /// </summary>
        /// <param name="requiredSubsystem"></param>
        /// <param name="optionalArea"></param>
        /// <param name="optionalTest"></param>
        public void DiagSelect(string requiredSubsystem, string optionalArea = "", string optionalTest = "")
        {
            _pi.AwgDiagSelect(requiredSubsystem, optionalArea, optionalTest);
        }

        //glennj 6/12/2013
        /// <summary>
        /// Unselects the specified test in the specified category context.
        /// </summary>
        /// <param name="requiredSubsystem"></param>
        /// <param name="optionalArea"></param>
        /// <param name="optionalTest"></param>
        public void DiagUnselect(string requiredSubsystem, string optionalArea = "", string optionalTest = "")
        {
            _pi.AwgDiagUnselect(requiredSubsystem, optionalArea, optionalTest);
        }

        //glennj 6/12/2013
        /// <summary>
        /// Compares the specified test in the specified category context expecting a selected state.
        /// </summary>
        /// <param name="requiredSubsystem"></param>
        /// <param name="requiredArea"></param>
        /// <param name="requiredTest"></param>
        /// <returns>String indicating if the test is selected</returns>
        public string DiagSelectVerifyQuery(string requiredSubsystem, string requiredArea, string requiredTest)
        {
            return _pi.GetAwgDiagSelectVerify(requiredSubsystem, requiredArea, requiredTest);
        }

        //glennj 6/12/2013
        /// <summary>
        /// Runs the %AWG Diagnostic
        /// </summary>
        public void DiagStart()
        {
            _pi.StartAwgDiag();
        }

        //glennj 6/12/2013
        /// <summary>
        /// Stops the %AWG diagnostics after current test is complete
        /// </summary>
        public void DiagStop()
        {
            _pi.StopAwgDiagStop();
        }

        //glennj 6/12/2013
        /// <summary>
        /// Gets the diagnostic stop state and saves in a local copy
        /// </summary>
        /// <returns>Diag stop state</returns>
        public void DiagStopStateQuery()
        {
            DiagStopState = _pi.GetAwgDiagStopState();
        }

        //glennj 6/12/2013
        /// <summary>
        /// Sets the type or context of the diagnostic tests on the AWG
        /// </summary>
        /// <param name="type">Category of available tests</param>
        public void DiagType(string type)
        {
            _pi.SetAwgDiagType(type);
        }

        //glennj 6/12/2013
        /// <summary>
        /// Gets the type and updates the object's local copy of diagnostic_type
        /// </summary>
        /// <returns>Diagnostic type</returns>
        public void DiagTypeQuery()
        {
            DiagnosticType = _pi.GetAwgDiagType();
        }

        //glennj 6/12/2013
        /// <summary>
        /// Verifies there are diagnostic type categories available.
        /// </summary>
        /// <returns>Diagnostic category type</returns>
        public void DiagTypeCategory()
        {
            DiagnosticTypeCatalog = _pi.GetAwgDiagTypeCategory();
        }

        //glennj 6/11/2013
        /// <summary>
        /// Using *TST? which runs the POSTs and save returned result DiagPostResult
        /// </summary>
        /// <returns>POST status indicator</returns>
        public void TstQuery()
        {
            DiagPostResult = _pi.AwgTstQuery();
        }


    }
}
