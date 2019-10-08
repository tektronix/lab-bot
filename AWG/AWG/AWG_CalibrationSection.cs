
// ReSharper disable CheckNamespace
namespace AwgTestFramework
// ReSharper restore CheckNamespace
{
    public partial class AWG
    {

        /// <summary>
        /// Property to contain the response from CAL:CAT?
        /// </summary>
        public string CalibrationCatalog { get; set; }
        /// <summary>
        /// Property to contain update from CAL:DATA:FACT?
        /// </summary>
        public string CalibrationDataFactory { get; set; }
        /// <summary>
        /// Property to contain update from CAL:DATA:USER?
        /// </summary>
        public string CalibrationDataUser { get; set; }
        /// <summary>
        /// Property to contain the response from *CAL? and CAL:ALL?
        /// </summary>
        public string CalibrationState { get; set; }
        /// <summary>
        /// Property to contain the response from CAL:TYPE?
        /// </summary>
        public string CalibrationType { get; set; }
        /// <summary>
        /// Property to contain the response from CAL:TYPE:CAT?
        /// </summary>
        public string CalibrationTypeCatalog { get; set; }
        /// <summary>
        /// Property to contain the response from CAL:STAT:FACT?
        /// </summary>
        public string CalStateFactory { get; set; }
        /// <summary>
        /// Property to contain the response from CAL:STAT:USER?
        /// </summary>
        public string CalStateUser { get; set; }

        public string CalibrationStopState { get; set; }
        public string CalibrationHalt { get; set; }
        public string CalibrationLog { get; set; }
        public string CalibrationLoopState { get; set; }
        public string CalibrationLoopCount { get; set; }
        public string CalibrationLoopsCompleted { get; set; }
        public string CalibrationResult { get; set; }
        public string CalibrationResultTemp { get; set; }
        public string CalibrationResultTime { get; set; }
        public string CalibrationFailOnlyFlag { get; set; }
        public string CalibrationDetailsFlag { get; set; }


        //glennj 6/11/2013
        /// <summary>
        /// Sends a *CAL? query and saves the response in calibration_state
        /// </summary>
        /// <returns>The AWG's response to the *CAL? query</returns>
        public void CalRunSaveResults()
        {
            CalibrationState = _pi.AwgCalRunAndQuery();
        }

        //glennj 6/11/2013
        /// <summary>
        /// Abort running of calibration.
        /// </summary>
        public void CalAbort()
        {
            _pi.AwgCalAbort();
        }

        //glennj 6/11/2013
        /// <summary>
        /// Writes the CAL:ALL command
        /// </summary>
        public void CalAll()
        {
            _pi.AwgCalAll();
        }

        //glennj 6/11/2013
        /// <summary>
        /// Performs a calibration and saves results in local calibration_state
        /// </summary>
        public void CalAllQuery()
        {
            CalibrationState = _pi.AwgCalAllReturnResults();
        }

        //glennj 6/11/2013
        /// <summary>
        /// Sends a CAL:CAT? command and updates the object's local copy of the list
        /// </summary>
        /// <param name="optionalSubsystem"></param>
        /// <param name="optionalArea"></param>
        public void CalCatalogQuery(string optionalSubsystem = "", string optionalArea = "")
        {
            CalibrationCatalog = _pi.GetAwgCalCatalog(optionalSubsystem, optionalArea);
        }

        //glennj 6/11/2013
        /// <summary>
        /// Sets the halt value to what is specified in the setValue variable.
        /// </summary>
        /// <param name="setValue">Value used to set the boolean HALT variable.</param>
        public void CalHalt(string setValue)
        {
            _pi.AwgCalHalt(setValue);
        }

        //glennj 6/11/2013
        /// <summary>
        /// Queries and updates the lcoal copy of cal_halt
        /// </summary>
        /// <returns>Calibration Halt Value.</returns>
        public void CalHaltQuery()
        {
            CalibrationHalt = _pi.AwgCalHaltQuery();
        }

        //glennj 6/11/2013
        /// <summary>
        /// Sets the value of the calibration loop control
        /// </summary>
        /// <param name="setValue">Loop value desired to set.</param>
        public void CalLoop(string setValue)
        {
            _pi.AwgCalLoop(setValue);
        }

        //glennj 6/11/2013
        /// <summary>
        /// Queries and updates the local copy of cal_loop_state
        /// </summary>
        public void CalControlLoopQuery()
        {
            CalibrationLoopState = _pi.AwgCalControlLoopQuery();
        }

        //glennj 6/11/2013
        /// <summary>
        /// Sets the calibration loop count value.
        /// </summary>
        /// <param name="setValue">Desired loop count value to be set</param>
        public void CalLoopCount(string setValue)
        {
            _pi.AwgCalLoopCount(setValue);
        }

        //glennj 6/11/2013
        /// <summary>
        /// Queries and updates the local copy of loop count value.
        /// </summary>
        public void CalLoopCountQuery()
        {
            CalibrationLoopCount = _pi.AwgCalLoopCountQuery();
        }

        //glennj 06/10/2013
        /// <summary>
        /// Queries, updates local copy and returns the calibration factory data from specified area.
        /// </summary>
        /// <param name="requiredSubsystem"></param>
        /// <param name="optionalArea"></param>
        /// <param name="optionalProcedure"></param>
        public void GetCalDataFactory(string requiredSubsystem, string optionalArea, string optionalProcedure)
        {
            CalibrationDataFactory = _pi.AwgCalDataFactoryQuery(requiredSubsystem, optionalArea, optionalProcedure);
        }

        //glennj 6/11/2013
        /// <summary>
        /// Writes a set of calibration constants to an area
        /// </summary>
        /// <param name="calConstantsAsXml"></param>
        /// <param name="requiredSubsystem"></param>
        /// <param name="optionalArea"></param>
        /// <param name="optionalProcedure"></param>
        public void CalDataUser(string calConstantsAsXml, string requiredSubsystem, string optionalArea = "", string optionalProcedure = "")
        {
            _pi.AwgCalDataUser(calConstantsAsXml, requiredSubsystem, optionalArea, optionalProcedure);
        }

        //glennj 6/11/2013
        /// <summary>
        /// Queries, updates local copy and returns the calibration user data from specified area.
        /// </summary>
        /// <param name="requiredSubsystem"></param>
        /// <param name="optionalArea"></param>
        /// <param name="optionalProcedure"></param>
        public void CalDataUserQuery(string requiredSubsystem, string optionalArea, string optionalProcedure)
        {
            CalibrationDataUser = _pi.AwgCalDataUserQuery(requiredSubsystem, optionalArea, optionalProcedure);
        }

        //glennj 6/11/2013
        /// <summary>
        /// Gets and returns the calibration log results.
        /// </summary>
        /// <returns>Calibration log results</returns>
        public void GetCalLog()
        {
            CalibrationLog = _pi.GetAwgCalLog();
        }

        //glennj 6/11/2013
        /// <summary>
        /// Sends the clear command to the calibration log.
        /// </summary>
        public void CalLogClear()
        {
            _pi.ClearAwgCalLog();
        }

        //glennj 6/11/2013
        /// <summary>
        /// Writes the CAL:LOG:FAIL command with given setValue
        /// </summary>
        /// <param name="setValue">The desired value for the failures only flag</param>
        public void CalSetForceFailure(string setValue)
        {
            _pi.SetAwgCalFailOnlyMode(setValue);
        }

        //glennj 6/11/2013
        /// <summary>
        /// Queries and updates the local copy of the calibration Fail Only flag
        /// </summary>
        /// <returns>Calibration Fail Only Flag</returns>
        public void CalFailOnlyQuery()
        {
            CalibrationFailOnlyFlag = _pi.GetAwgCalFailOnlyMode();
        }

        //glennj 6/11/2013
        /// <summary>
        /// Sets the detail flag to the setValue in the cal logs
        /// </summary>
        /// <param name="setValue">Desired value for the details flag in the cal logs</param>
        public void CalSetDetail(string setValue)
        {
            _pi.SetAwgCalDetail(setValue);
        }

        //glennj 6/11/2013
        /// <summary>
        /// Gets and updates the local copy of detail flag for the cal logs
        /// </summary>
        /// <returns>Calibration log details flag value</returns>
        public void CalDetailsQuery()
        {
            CalibrationDetailsFlag = _pi.GetAwgCalDetails();
        }

        //glennj 6/11/2013
        /// <summary>
        /// Queries and returns the number of calibration loops completed.
        /// </summary>
        /// <returns>The number of calibrations loops completed</returns>
        public void CalLoopQuery()
        {
            CalibrationLoopsCompleted = _pi.AwgCalLoopQuery();
        }

        //glennj 6/11/2013
        /// <summary>
        /// Forces the AWG to update it's copy of cal result
        /// </summary>
        /// <param name="optionalSubsystem">The optional subsystem being queried</param>
        /// <param name="optionalArea">The optional area being queried</param>
        /// <param name="optionalProcedure">The optional procedure being queried</param>
        public void CalResult(string optionalSubsystem = "", string optionalArea = "", string optionalProcedure = "")
        {
            CalibrationResult = _pi.GetAwgCalResult(optionalSubsystem, optionalArea, optionalProcedure);
        }

        //glennj 6/11/2013
        /// <summary>
        /// Forces the AWG to update it's copy of cal result temp
        /// </summary>
        /// <param name="optionalSubsystem">The optional subsystem being queried</param>
        /// <param name="optionalArea">The optional area being queried</param>
        /// <param name="optionalProcedure">The optional procedure being queried</param>
        public void CalResultTemperature(string optionalSubsystem = "", string optionalArea = "", string optionalProcedure = "")
        {
            CalibrationResultTemp = _pi.GetAwgCalResultTemperature(optionalSubsystem, optionalArea, optionalProcedure);
        }

        //glennj 6/11/2013
        /// <summary>
        /// Updates the local copy for the specified calibration procedure result's time
        /// </summary>
        /// <param name="optionalSubsystem">The optional subsystem being queried</param>
        /// <param name="optionalArea">The optional area being queried</param>
        /// <param name="optionalProcedure">The optional procedure being queried</param>
        public void CalResultTime(string optionalSubsystem = "", string optionalArea = "", string optionalProcedure = "")
        {
            CalibrationResultTime = _pi.GetAwgCalResultTime(optionalSubsystem, optionalArea, optionalProcedure);
        }

        //glennj 6/11/2013
        /// <summary>
        /// Returns whether a calibration procedure is running
        /// </summary>
        /// <returns>A string of colon separated "subsystem", "area:" and "procedure" if running or "" if not.</returns>
        public string CalRunning()
        {
            return _pi.AwgCalRunning();
        }

        //glennj 6/11/2013
        /// <summary>
        /// Selects calibration procedures specified by the selection variable.
        /// </summary>
        /// <param name="requiredSubsystem">Valid subsystem name</param>
        /// <param name="optionalArea">Valid area name</param>
        /// <param name="optionalProcedure">Valid procedure name</param>
        public void CalSelect(string requiredSubsystem, string optionalArea = "", string optionalProcedure = "")
        {
            _pi.AwgCalSelect(requiredSubsystem, optionalArea, optionalProcedure);
        }

        //glennj 6/11/2013
        /// <summary>
        /// Checks to see if a the test specified by the test variable is selected or unselected.
        /// </summary>
        /// <param name="requiredSubsystem">Valid subsystem name</param>
        /// <param name="requiredArea">Valid area name</param>
        /// <param name="requiredProcedure">Valid procedure name</param>
        /// <returns>Returns a 1 if the test is selected or a 0 if it is unselected</returns>
        public string CalSelectVerify(string requiredSubsystem, string requiredArea, string requiredProcedure)
        {
            return _pi.AwgCalSelectVerify(requiredSubsystem, requiredArea, requiredProcedure);
        }

        //glennj 6/11/2013
        /// <summary>
        /// Starts internal calibration using the CALibration:STARt command
        /// </summary>
        public void CalStart()
        {
            _pi.AwgCalStart();
        }

        //glennj 6/11/2013
        /// <summary>
        /// Queries and updates local cal_state_factory with results
        /// </summary>
        /// <param name="subsystem">The subsystem being queried (optional)</param>
        /// <param name="area">The area being queried (optional)</param>
        /// <returns></returns>
        public void CalFactoryStateQuery(string subsystem, string area)
        {
            CalStateFactory = _pi.GetAwgCalFactoryState(subsystem, area);
        }

        //glennj 6/11/2013
        /// <summary>
        /// Queries and updates the local cal stop state.
        /// </summary>
        /// <returns>Calibration stop state. 0 indicates not stopped. 1 indicates stopped.</returns>
        public void CalStopState()
        {
            CalibrationStopState = _pi.GetAwgCalStopState();
        }

        //glennj 6/11/2013
        /// <summary>
        /// Sets the calibration type
        /// </summary>
        /// <param name="calType">Calibration type to set on the AWG</param>
        public void CalType(string calType)
        {
            _pi.AwgCalType(calType);
        }

        //glennj 6/11/2013
        /// <summary>
        /// Queries for the current calibration type and updates local copy<para>
        /// calibration_type</para>
        /// </summary>
        /// <returns>Calibration Type</returns>
        public void CalTypeQuery()
        {
            CalibrationType = _pi.AwgCalTypeQuery();
        }

        //glennj 6/11/2013
        /// <summary>
        /// Using Cal:Type:Cat? Update the CalibrationTypeCatalog property
        /// </summary>
        /// <returns>Calibration Type Catalog</returns>
        public void CalTypeCatalogQuery()
        {
            CalibrationTypeCatalog = _pi.AwgCalTypeCatalogQuery();
        }

        //glennj 6/11/2013
        /// <summary>
        /// Unselects calibration procedures specified by the selection variable.
        /// </summary>
        /// <param name="requiredSubsystem">Valid subsystem name</param>
        /// <param name="optionalArea">Valid area name</param>
        /// <param name="optionalProcedure">Valid procedure name</param>
        public void CalUnselect(string requiredSubsystem, string optionalArea = "", string optionalProcedure = "")
        {
            _pi.AwgCalUnselect(requiredSubsystem, optionalArea, optionalProcedure);
        }

        //sforell 8/20/13 added method
        /// <summary>
        /// Gets the current user state of the calibration for the AWG.
        /// </summary>
        /// <param name="subsystem">The subsystem being queried (optional)</param>
        /// <param name="area">The area being queried (optional)</param>
        public void CalUserStateQuery(string subsystem, string area)
        {
            CalStateUser = _pi.GetAwgCalUserState(subsystem, area);
        }


    }
}
