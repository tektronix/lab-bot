
namespace AwgTestFramework
{
    public partial class CPi70KCmds
    {

        #region *TST?

        //glennj 6/11/2013
        /// <summary>
        /// Using *TST? run POST and returns result
        /// </summary>
        /// <returns>POST status indicator</returns>
        public string AwgTstQuery()
        {
            //Initialize
            const string commandLine = "*TST?";
            string response;
            uint currentTimeout = _mAWGVisaSession.Timeout;
            _mAWGVisaSession.Timeout = 1200000; // Set timeout to 20 min (units in ms)  

            //Execute
            _mAWGVisaSession.Query(commandLine, out response);
            _mAWGVisaSession.Timeout = currentTimeout; // Reset timeout to default specified in AWG.cs
            return response;
        }

        #endregion *TST?

        #region ACTive:MODE

        //glennj 6/12/2013
        /// <summary>
        /// Using ACTive:MODE set the active mode
        /// </summary>
        /// <param name="command">Active mode selection of cal, diag, or norm</param>
        public void SetAwgDiagActiveMode(string command)
        {
            string commandLine = "ACTive:MODE " + command;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 6/12/2013
        /// <summary>
        /// Using ACTive:MODE? get the active mode
        /// </summary>
        /// <returns>Current active mode</returns>
        public string GetAwgDiagActiveMode()
        {
            string response;
            const string commandLine = "ACTive:MODE?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion ACTive:MODE

        #region DIAGnostic[:IMMediate]

        //glennj 6/12/2013
        //jmannning 04/01/2014-Changed Visa Timeout from 5 minutes to 10 minutes
        /// <summary>
        /// Executes all of the NORMal diagnostic tests
        /// </summary>
        public void AwgDiagImmediate()
        {
            const string commandLine = "DIAGnostic:IMMediate";
            uint currentTimeout = _mAWGVisaSession.Timeout;
            _mAWGVisaSession.Timeout = 600000; // Set timeout to 10 min in ms  
            _mAWGVisaSession.Write(commandLine);
            _mAWGVisaSession.Timeout = currentTimeout;
        }

        //glennj 6/12/2013
        //jmannning 04/01/2014-Changed Visa Timeout from 5 minutes to 10 minutes
        /// <summary>
        /// Executes the selected tests and returns the results in the form of a numeric of values of 0 
        /// for no errors or  -330 for one or more tests failed.
        /// </summary>
        /// <returns>Results from the diagnostics</returns>
        public string AwgDiagImmediateQuery()
        {
            string response;
            uint currentTimeout = _mAWGVisaSession.Timeout;
            _mAWGVisaSession.Timeout = 720000; // Set timeout to 12 min in ms  
            const string commandLine = "DIAGnostic:IMMediate?";
            _mAWGVisaSession.Query(commandLine, out response);
            _mAWGVisaSession.Timeout = currentTimeout; // Reset timeout to default specified in AWG.cs
            return response;
        }

        #endregion DIAGnostic[:IMMediate]

        #region DIAGnostic:ABORt

        //glennj 6/12/2013
        /// <summary>
        /// Using DIAGnostic:ABORt aborts Diagnostics
        /// </summary>
        public void AbortAwgDiag()
        {
            const string commandLine = "DIAGnostic:ABORt";
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion DIAGnostic:ABORt

        #region DIAGnostic:COMMent

        //glennj 6/12/2013
        /// <summary>
        /// Sends No-Op string to PI for use in debugging CallMonitor sessions (and whatever else you can think of)
        /// </summary>
        /// <param name="comment">The text string you want to see in the CallMonitor log</param>
        public void AwgDiagComment(string comment)
        {
            string commandLine = "DIAGnostic:COMMent " + '"' + comment + '"';
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion DIAGnostic:COMMent

        #region DIAGnostic:MMODe?

        //glennj 06/07/2013
        /// <summary>
        /// Get the Manufacturing Mode of an %AWG
        /// 
        /// DIAGnostic:MMODe?
        /// </summary>
        /// <returns></returns>
        public string GetAwgDiagManufacturingMode()
        {
            string response;
            const string commandLine = "DIAGnostic:MMODe?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion DIAGnostic:MMODe?

        #region DIAGnostic:CATalog

        //glennj 9/10/2013
        /// <summary>
        /// Using DIAGnostic:CATalog? get the diagnostic catalog
        /// </summary>
        /// <returns>List of tests per subsystem and/or area</returns>
        public string GetAwgDiagCatalog(string subsystem, string area)
        {
            string response;
            string commandLine = "DIAGnostic:CATalog?";
            if (subsystem != "")
            {
                commandLine += " " + '"' + subsystem + '"';
            }

            if (area != "")
            {
                commandLine += "," + '"' + area + '"';
            }

            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion DIAGnostic:CATalog

        #region DIAGnostic:CONTrol:HALT

        //glennj 6/12/2013
        /// <summary>
        /// Sets the value of halt for diagnostics.
        /// </summary>
        /// <param name="setValue">Halt value (OFF|ON)</param>
        public void SetAwgDiagHalt(string setValue)
        {
            var commandLine = "DIAGnostic:CONTrol:HALT " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 6/12/2013
        /// <summary>
        /// Using DIAGnostic:CONTrol:HALT? get the value of halt for diagnostics.
        /// </summary>
        /// <returns>Current Diagnostic halt state</returns>
        public string GetAwgDiagHalt()
        {
            string response;
            const string commandLine = "DIAGnostic:CONTrol:HALT?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion DIAGnostic:CONTrol:HALT

        #region DIAGnostic:CONTrol:COUNt

        //glennj 6/12/2013
        /// <summary>
        /// Using DIAGnostic:CONTrol:COUN set the value of the loop count.
        /// </summary>
        /// <param name="setValue">Value of the loop count</param>
        public void SetAwgDiagControlCount(string setValue)
        {
            var commandLine = "DIAGnostic:CONTrol:COUNt " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 6/12/2013
        /// <summary>
        /// Using DIAGnostic:CONTrol:COUN? get the setting for the loop count
        /// </summary>
        /// <returns>Current Diagnostic loop count</returns>
        public string GetAwgDiagControlCount()
        {
            string response;
            const string commandLine = "DIAGnostic:CONTrol:COUNt?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion DIAGnostic:CONTrol:COUNt

        #region DIAGnostic:CONTrol:LOOP

        //glennj 6/12/2013
        /// <summary>
        /// Using DIAGnostic:CONTrol:LOOP set the diagnostic loop setting 
        /// </summary>
        /// <param name="setting">Diagnostic loop setting</param>
        public void SetAwgDiagControlLoop(string setting)
        {
            var commandLine = "DIAGnostic:CONTrol:LOOP " + setting;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 6/12/2013
        /// <summary>
        /// Using DIAGnostic:CONTrol:LOOP? get the diagnostic loop setting  
        /// </summary>
        /// <returns>Current Diagnostic loop setting</returns>
        public string GetAwgDiagControlLoop()
        {
            string response;
            const string commandLine = "DIAGnostic:CONTrol:LOOP?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion DIAGnostic:CONTrol:LOOP

        #region DIAGnostic:DATA

        //glennj 6/12/2013
        /// <summary>
        /// Using DIAGnostic:DATA? gets results of last executed diagnostic test
        /// </summary>
        /// <returns>Result of last executed diagnostic test</returns>
        public string GetAwgDiagData()
        {
            string response;
            const string commandLine = "DIAGnostic:DATA?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion DIAGnostic:DATA

        #region DIAGnostic:DIMSec

        //glennj 10/07/2013
        /// <summary>
        /// Only return after delaying for a period of time.
        /// </summary>
        /// <param name="delayInMSec"></param>
        public void GetAwgDiagDelayInMSec(string delayInMSec)
        {
            string response;
            string commandLine = "DIAGnostic:DIMSec? " + delayInMSec;
            _mAWGVisaSession.Query(commandLine, out response);
        }

        #endregion DIAGnostics:DIMSec

        #region DIAGnostic:LOG?

        //glennj 6/12/2013
        /// <summary>
        /// Using DIAGnostic:LOG? get the diagnostic log
        /// </summary>
        /// <returns>Diagnostic log</returns>
        public string GetAwgDiagLog()
        {
            string response;
            const string commandLine = "DIAGnostic:LOG?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion DIAGnostic:LOG?

        #region DIAGnostic:LOG:CLEar

        //glennj 6/12/2013
        /// <summary>
        /// Clears the diagnostic log
        /// </summary>
        /// <returns>Diagnostic log</returns>
        public void ClearAwgDiagLog()
        {
            const string commandLine = "DIAGnostic:LOG:CLEar";
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion DIAGnostic:LOG:CLEar

        #region DIAGnostic:LOG:DETails

        //glennj 6/12/2013
        /// <summary>
        /// Changes the diagnostics log to more or less detailed
        /// </summary>
        /// <param name="setState">Log detail flag value</param>
        public void SetAwgDiagLogDetails(string setState)
        {
            string commandLine = "DIAGnostic:LOG:DETails " + setState;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 6/12/2013
        /// <summary>
        /// Gets the diagnostics log detail flag value
        /// </summary>
        /// <returns>Log detail flag value</returns>
        public string GetAwgDiagLogDetails()
        {
            string response;
            const string commandLine = "DIAGnostic:LOG:DETails?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion DIAGnostic:LOG:DETails

        #region DIAGnostic:LOG:FAILuresonly

        //glennj 6/12/2013
        /// <summary>
        /// Changes the diagnostics log to enable or disable failure mode
        /// </summary>
        /// <param name="setValue">Log detail flag value</param>
        public void SetwgDiagLogFailuresOnly(string setValue)
        {
            string commandLine = "DIAGnostic:LOG:FAILuresonly " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 6/12/2013
        /// <summary>
        /// Gets the diagnostics log failure mode
        /// </summary>
        /// <returns>Diagnostics log failure mode</returns>
        public string GetAwgDiagLogFailuresOnly()
        {
            string response;
            const string commandLine = "DIAGnostic:LOG:FAILuresonly?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion DIAGnostic:LOG:FAILuresonly

        #region DIAGnostic:LOOPs?

        //glennj 3/18/2014
        /// <summary>
        /// Using DIAGnostic:LOOPs? get the current diagnostic loop
        /// </summary>
        /// <returns>Completed Diagnostic Loops</returns>
        public string GetAwgDiagLoops()
        {
            string response;
            const string commandLine = "DIAGnostic:LOOPs?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion DIAGnostic:LOOPs?

        #region DIAGnostic:RUNNing?

        //glennj 6/12/2013
        /// <summary>
        /// Verifies that Diagnostic tests are currently running on the AWG
        /// </summary>
        /// <returns>Running state of diagnostics</returns>
        public string GetAwgDiagRunning()
        {
            string response;
            const string commandLine = "DIAGnostic:RUNNing?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion DIAGnostic:RUNNing?

        #region DIAGnostic:RESult?

        //glennj 6/12/2013
        /// <summary>
        /// Gets the results of one or more tests
        /// </summary>
        /// <returns>Diagnostic result</returns>
        public string GetAwgDiagResult(string optionalSubsystem = "", string optionalArea = "", string optionalTest = "")
        {
            string response;
            string commandLine = "DIAGnostic:RESult? " + CreateParameterList(optionalSubsystem, optionalArea, optionalTest);
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion DIAGnostic:RESult?

        #region DIAGnostic:RESult:TEMPerature?

        //glennj 6/12/2013
        /// <summary>
        /// Gets the highest temperature during specified diag test.
        /// </summary>
        /// <param name="optionalSubsystem"></param>
        /// <param name="optionalArea"></param>
        /// <param name="optionalTest"></param>
        /// <returns>Temperature during specified diag test</returns>
        public string GetAwgDiagResultTemp(string optionalSubsystem = "", string optionalArea = "", string optionalTest = "")
        {
            string response;
            string commandLine = "DIAGnostic:RESult:TEMPerature? " + CreateParameterList(optionalSubsystem, optionalArea, optionalTest);
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion DIAGnostic:RESult:TEMPerature?

        #region DIAGnostic:RESult:TIME?

        //glennj 6/12/2013
        /// <summary>
        /// Gets the time during specified diag test.
        /// </summary>
        /// <param name="optionalSubsystem"></param>
        /// <param name="optionalArea"></param>
        /// <param name="optionalTest"></param>
        /// <returns>Time during specified diag test</returns>
        public string GetAwgDiagResultTime(string optionalSubsystem = "", string optionalArea = "", string optionalTest = "")
        {
            string response;
            string commandLine = "DIAGnostic:RESult:TIME? " + CreateParameterList(optionalSubsystem, optionalArea, optionalTest);
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion DIAGnostic:RESult:TIME?

        #region DIAGnostic:SELect

        //glennj 6/11/2013
        /// <summary>
        /// Selects diagnostic tests specified by the parameter list.
        /// 
        /// DIAGnostic:SELect
        /// </summary>
        /// <param name="requiredSubsystem">Valid subsystem name</param>
        /// <param name="optionalArea">Valid area name</param>
        /// <param name="optionalTest">Valid test name</param>
        public void AwgDiagSelect(string requiredSubsystem, string optionalArea = "", string optionalTest = "")
        {
            string commandLine = "DIAGnostic:SELect " + CreateParameterList(requiredSubsystem, optionalArea, optionalTest);
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion DIAGnostic:SELect

        #region DIAGnostic:SELect:VERify?

        //glennj 3/12/2014
        /// <summary>
        /// Returns selected state for a diagnostic test as specified by the parameter list.
        /// 
        /// DIAGnostic:SELect:VERify?
        /// </summary>
        /// <param name="requiredSubsystem">Valid subsystem name</param>
        /// <param name="requiredArea">Valid area name</param>
        /// <param name="requiredTest">Valid test name</param>
        public string GetAwgDiagSelectVerify(string requiredSubsystem, string requiredArea, string requiredTest)
        {
            string commandLine = "DIAGnostic:SELect:VERify? " + CreateParameterList(requiredSubsystem, requiredArea, requiredTest);
            string response;
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion DIAGnostic:SELect:VERify?

        #region DIAGnostic:STARt

        //glennj 6/12/2013
        /// <summary>
        /// Runs the %AWG Diagnostic
        /// </summary>
        public void StartAwgDiag()
        {
            const string commandLine = "DIAGnostic:STARt";
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion DIAGnostic:STARt

        #region DIAGnostic:STOP

        //glennj 6/12/2013
        /// <summary>
        /// Stops the %AWG diagnostics after current test is complete
        /// </summary>
        public void StopAwgDiagStop()
        {
            const string commandLine = "DIAGnostic:STOP";
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion DIAGnostic:STOP

        #region DIAGnostic:STOP:STATe?

        //glennj 6/12/2013
        /// <summary>
        /// Gets the diagnostic stop state from the AWG
        /// </summary>
        /// <returns>Diag stop state</returns>
        public string GetAwgDiagStopState()
        {
            string response;
            const string commandLine = "DIAGnostic:STOP:STATe?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion DIAGnostic:STOP:STATE?

        #region DIAGnostic:TYPE

        //glennj 6/12/2013
        /// <summary>
        /// Sets the type or context of the diagnostic tests on the AWG
        /// </summary>
        /// <param name="type">Category of available tests</param>
        public void SetAwgDiagType(string type)
        {
            string commandLine = "DIAGnostic:TYPE " + type;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 6/12/2013
        /// <summary>
        /// Gets the type or context of the diagnostic tests.
        /// </summary>
        /// <returns>Diagnostic type</returns>
        public string GetAwgDiagType()
        {
            string response;
            const string commandLine = "DIAGnostic:TYPE?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion DIAGnostic:TYPE

        #region DIAGnostic:TYPE:CATalog?

        //glennj 6/12/2013
        /// <summary>
        /// Verifies there are diagnostic type categories available.
        /// </summary>
        /// <returns>Diagnostic category type</returns>
        public string GetAwgDiagTypeCategory()
        {
            string response;
            const string commandLine = "DIAGnostic:TYPE:CATalog?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion DIAGnostic:TYPE:CATalog?

        #region DIAGnostic:UNSelect

        //glennj 6/11/2013
        /// <summary>
        /// Unselects diagnostic tests specified by the parameter list.
        /// 
        /// DIAGnostic:UNSelect
        /// </summary>
        /// <param name="requiredSubsystem">Valid subsystem name</param>
        /// <param name="optionalArea">Valid area name</param>
        /// <param name="optionalTest">Valid test name</param>
        public void AwgDiagUnselect(string requiredSubsystem, string optionalArea = "", string optionalTest = "")
        {
            string commandLine = "DIAGnostic:UNSelect " + CreateParameterList(requiredSubsystem, optionalArea, optionalTest);
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion DIAGnostic:UNSelect
    }
}

