using System;
using System.Globalization;

namespace AwgTestFramework
{
    public partial class CPi70KCmds
    {
        private const int DataFactoryBufferSize = 1000000;

        #region Published

        #region *CALibration?

        // Unkown 01/01/01 Adjusting timeout to 37 minutes
        //glennj 6/11/2013
        /// <summary>
        /// Using *CALibration? start a self cal and returns the response<para>
        /// Note, this takes 37 minutes minimum to execute and return</para>
        /// </summary>
        /// <returns>The AWG's response to the *CALibration? query</returns>
        public string AwgCalRunAndQuery()
        {
            string response;
            const string commandLine = "*CALibration?";
            const uint timeoutFor37Minutes = 37 * 60 * 1000;    // minutes * sec/min * mSec
            _mAWGVisaSession.Timeout = timeoutFor37Minutes;     // Set timeout to 37 min (units in ms) is 2220000  
            _mAWGVisaSession.Query(commandLine, out response);
            _mAWGVisaSession.Timeout = _mDefaultVISATimeout;    // Reset timeout to default specified in AWG.cs 
            return response;
        }

        #endregion *CALibration?

        #region CALibration:ABORt

        //glennj 6/11/2013
        /// <summary>
        /// Using CALibration:ABORt, abort running of calibration.
        /// </summary>
        public void AwgCalAbort()
        {
            const string commandLine = "CALibration:ABORt";
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion CALibration:ABORt

        #region CALibration[:ALL]

        //glennj 6/11/2013
        /// <summary>
        /// Using CALibration:ALL, start self calibration<para>
        /// Note, this takes 37 minutes or a really long time :)</para>
        /// </summary>
        public void AwgCalAll()
        {
            //Initialize
            const string commandLine = "CALibration:ALL";

            //Execute
            const uint timeoutFor37Minutes = 37 * 60 * 1000;    // minutes * sec/min * mSec
            _mAWGVisaSession.Timeout = timeoutFor37Minutes;     // Set timeout to 37 min (units in ms) is 2220000
            _mAWGVisaSession.Write(commandLine); //Sends CALibration:ALL command
            _mAWGVisaSession.Timeout = _mDefaultVISATimeout; // Reset timeout to default specified in AWG.cs 
        }

        //glennj 6/11/2013 Adjusting the timeout to 32 minutes
        /// <summary>
        /// Using CALibration:ALL?, start self calibration<para>
        /// (Note, this takes 37 minutes or a really long time)</para><para>
        /// and returns a result</para>
        /// </summary>
        /// <returns>Calibration state</returns>
        public string AwgCalAllReturnResults()
        {
            //Initialize
            const string commandLine = "CALibration:ALL?";
            const uint timeoutFor37Minutes = 37 * 60 * 1000;    // minutes * sec/min * mSec
            _mAWGVisaSession.Timeout = timeoutFor37Minutes;     // Set timeout to 37 min (units in ms) is 2220000

            string response;

            //Execute
            _mAWGVisaSession.Query(commandLine, out response);
            _mAWGVisaSession.Timeout = _mDefaultVISATimeout; // Reset timeout to default specified in AWG.cs
            return response;
        }

        #endregion CALibration[:ALL]

        #region CALibration:CATalog?

        //glennj 6/11/2013
        /// <summary>
        /// Returns a list depending on the passed parameters for the calibration catalog.
        /// 
        /// CALibration:CATalog?
        /// </summary>
        /// <param name="optionalSubsystem">The optional subsystem being queried</param>
        /// <param name="optionalArea">The optional area being queried</param>
        /// <returns>Entire calibration catalog</returns>
        public string GetAwgCalCatalog(string optionalSubsystem = "", string optionalArea = "")
        {
            //Initialize
            string response;
            var commandLine = "CALibration:CATalog? " + CreateParameterList(optionalSubsystem, optionalArea);

            //Execute
            _mAWGVisaSession.Write(commandLine);
            _mAWGVisaSession.Read(1028, out response); //Added to increase the buffer length
            return response;
        }

        #endregion CALibration:CATalog?

        #region CALibration:LOG?

        //glennj 6/11/2013
        /// <summary>
        /// Using CALibration:LOG? return the calibration log results.
        /// </summary>
        /// <returns>Calibration log results</returns>
        public string GetAwgCalLog()
        {
            //Initialize
            string response;
            const string commandLine = "CALibration:LOG?";

            //Execute   
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion CALibration:LOG?

        #region CALibration:LOG:CLEar

        //glennj 6/11/2013
        /// <summary>
        /// Using CALibration:LOG:CLEar, clear the calibration log.
        /// </summary>
        public void ClearAwgCalLog()
        {
            const string commandLine = "CALibration:LOG:CLEar";
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion CALibration:LOG:CLEar

        #region CALibration:LOG:DETails

        //glennj 6/11/2013
        /// <summary>
        /// Using CALibration:LOG:DETails set amount of detail to be stored in the cal logs
        /// </summary>
        /// <param name="detailSetting">Desired value for the details flag in the cal logs</param>
        public void SetAwgCalDetail(string detailSetting)
        {
            //Initialize
            var commandLine = "CALibration:LOG:DETails " + detailSetting;

            //Execute
            _mAWGVisaSession.Write(commandLine); //Sends command
        }

        //glennj 6/11/2013
        /// <summary>
        /// Using CALibration:LOG:DETails? return the amount of detail to be stored in the cal logs
        /// </summary>
        /// <returns>Calibration log details flag value</returns>
        public string GetAwgCalDetails()
        {
            //Initialize
            const string commandLine = "CALibration:LOG:DETails?";
            string response;

            //Execute
            _mAWGVisaSession.Query(commandLine, out response); //Sends command
            return response;
        }

        #endregion CALibration:LOG:DETails

        #region CALibration:LOG:FAILuresonly

        //glennj 6/11/2013
        /// <summary>
        /// Using CALibration:LOG:FAILuresonly set store only failures in the cal logs
        /// </summary>
        /// <param name="failuresOnlySetting">The desired value for the failures only flag</param>
        public void SetAwgCalFailOnlyMode(string failuresOnlySetting)
        {
            //Initialize
            var commandLine = "CALibration:LOG:FAILuresonly " + failuresOnlySetting;
            //Execute
            _mAWGVisaSession.Write(commandLine); //Sends command
        }

        //glennj 6/11/2013
        /// <summary>
        /// Using CALibration:LOG:FAILuresonly? return the state for store only failures in the cal logs
        /// </summary>
        /// <returns>Calibration Fail Only Flag</returns>
        public string GetAwgCalFailOnlyMode()
        {
            const string commandLine = "CALibration:LOG:FAILuresonly?";
            string response;
            //Execute
            _mAWGVisaSession.Query(commandLine, out response); //Sends command
            return response;
        }

        #endregion CALibration:LOG:FAILuresonly

        #region CALibration:RESTore

        //glennj 6/11/2013
        /// <summary>
        /// Using CALibration:RESTore start a restore of the factory cal constants
        /// </summary>
        public void RestoreAwgFactoryCal()
        {
            //Initialize
            const string commandLine = "CALibration:RESTore";
            //Execute
            _mAWGVisaSession.Write(commandLine); //Sends command
        }

        #endregion CALibration:RESTore

        #region CALibration:RESult?

        //glennj 6/11/2013
        /// <summary>
        /// Using CALibration:RES?, return the calibration result.<para>
        /// An optional Subsystem and/or area and/or test can be specified.</para>
        /// </summary>
        /// <param name="optionalSubsystem">The optional subsystem being queried</param>
        /// <param name="optionalArea">The optional area being queried</param>
        /// <param name="optionalProcedure">The optional procedure being queried</param>
        /// <returns>Returns formatted state</returns>
        /// <returns>Calibration results</returns>
        public string GetAwgCalResult(string optionalSubsystem = "", string optionalArea = "", string optionalProcedure = "")
        {
            //Initialize
            string response;
            string commandLine = "CALibration:RESult? " + CreateParameterList(optionalSubsystem, optionalArea, optionalProcedure);

            //Execute
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion CALibration:RESult?

        #region CALibration:RESult:TEMPerature?

        //glennj 6/11/2013
        /// <summary>
        /// Using CALibration:RES:TEMP? return the specified calibration procedure result's temperature<para>
        /// An optional Subsystem and/or area and/or test can be specified.</para>
        /// </summary>
        /// <param name="optionalSubsystem">The optional subsystem being queried</param>
        /// <param name="optionalArea">The optional area being queried</param>
        /// <param name="optionalProcedure">The optional procedure being queried</param>
        /// <returns>Returns temperture for each specified test</returns>
        public string GetAwgCalResultTemperature(string optionalSubsystem = "", string optionalArea = "", string optionalProcedure = "")
        {
            //Initialize
            string response;
            string commandLine = "CALibration:RESult:TEMPerature? " + CreateParameterList(optionalSubsystem, optionalArea, optionalProcedure);

            //Execute
            _mAWGVisaSession.Timeout = 1250000; // Set timeout to ~20 min (units in ms)     
            _mAWGVisaSession.Query(commandLine, out response);
            _mAWGVisaSession.Timeout = _mDefaultVISATimeout; // Reset timeout to default specified in AWG.cs
            return response;
        }

        #endregion CALibration:RESult:TEMPerature?

        #region CALibration:RESult:TIME?

        //glennj 6/11/2013
        /// <summary>
        /// Using CALibration:RES:TIME? return the specified calibration procedure result's time<para>
        /// An optional Subsystem and/or area and/or test can be specified.</para>
        /// </summary>
        /// <param name="optionalSubsystem">The optional subsystem being queried</param>
        /// <param name="optionalArea">The optional area being queried</param>
        /// <param name="optionalProcedure">The optional procedure being queried</param>
        /// <returns>Returns temperture for each specified test</returns>
        public string GetAwgCalResultTime(string optionalSubsystem = "", string optionalArea = "", string optionalProcedure = "")
        {
            //Initialize
            string response;
            string commandLine = "CALibration:RESult:TIME? " + CreateParameterList(optionalSubsystem, optionalArea, optionalProcedure);

            //Execute   
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion CALibration:RESult:TIME?

        #region CALibration:RUNNing?

        //glennj 6/11/2013
        /// <summary>
        /// Returns whether a calibration procedure is running
        /// </summary>
        /// <returns>A string of colon separated "subsystem", "area:" and "procedure" if running or "" if not.</returns>
        public string AwgCalRunning()
        {
            //Initialize
            string response;
            const string commandLine = "CALibration:RUNNing?";

            //Execute
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion CALibration:RUNNing?

        #region CALibration:STARt

        //glennj 6/11/2013
        /// <summary>
        /// Starts internal calibration using the CALibration:STARt command
        /// </summary>
        public void AwgCalStart()
        {
            const string commandLine = "CALibration:STARt";
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion CALibration:STARt

        #region CALibration:STATe:FACTory?

        //glennj 6/11/2013
        /// <summary>Using CALibration:STAT:FACT? return the state of calibration of format<para>
        /// of S(C|U),D(),T()</para><para>
        /// Optional subsystem and areas</para>
        /// </summary>
        /// <param name="subsystem">The subsystem being queried (optional)</param>
        /// <param name="area">The area being queried (optional)</param>
        /// <returns>Returns formatted state</returns>
        public string GetAwgCalFactoryState(string subsystem, string area)
        {
            uint currentTimeout = _mAWGVisaSession.Timeout;
            _mAWGVisaSession.Timeout = 30000; // Set timeout to 30 seconds (units in ms)
  
            // Create
            string commandLine = "CALibration:STATe:FACTory? " + CreateParameterList(subsystem, area);

            // Execute
            string response;
            _mAWGVisaSession.Query(commandLine, out response);
            _mAWGVisaSession.Timeout = currentTimeout;
            return response;
        }

        #endregion CALibration:STATe:FACTory?

        #region CALibration:STATe:USER?

        //glennj 8/1/2013
        /// <summary>
        /// Using CALibration:STATe:USER? return the state of calibration of format<para>
        /// of S(C|U),D(),T()</para><para>
        /// Optional subsystem and areas</para>
        /// </summary>
        /// <param name="subsystem">The subsystem being queried (optional)</param>
        /// <param name="area">The area being queried (optional)</param>
        /// <returns>Returns formatted state</returns>
        public string GetAwgCalUserState(string subsystem, string area)
        {
            uint currentTimeout = _mAWGVisaSession.Timeout;
            _mAWGVisaSession.Timeout = 30000; // Set timeout to 30 seconds (units in ms)

            string commandLine = "CALibration:STATe:USER? " + CreateParameterList(subsystem, area);

            string response;
            _mAWGVisaSession.Query(commandLine, out response);
            _mAWGVisaSession.Timeout = currentTimeout;
            return response;
        }

        #endregion CALibration:STATe:USER?

        #region CALibration:STOP:STATe?

        //glennj 6/11/2013
        /// <summary>
        /// Queries and returns the calibration stop state.
        /// </summary>
        /// <returns>Calibration stop state. 0 indicates not stopped. 1 indicates stopped.</returns>
        public string GetAwgCalStopState()
        {
            //Initialize
            string response;

            //Execute
            const string commandLine = "CALibration:STOP:STATe?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion CALibration:STOP:STATe?

        #endregion Published

        #region Non-Published

        #region CALibration:CONTrol:COUNt

        //glennj 6/11/2013
        /// <summary>
        /// Sets the calibration loop count value.
        /// </summary>
        /// <param name="numberOfLoops">Desired loop count value to be set</param>
        public void AwgCalLoopCount(string numberOfLoops)
        {
            string commandLine = "CALibration:CONTrol:COUNt " + numberOfLoops;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 6/11/2013
        /// <summary>
        /// Queries and returns the calibration loop count value.
        /// </summary>
        public string AwgCalLoopCountQuery()
        {
            //Initialize
            string response;
            const string commandLine = "CALibration:CONTrol:COUNt?";

            //Execute
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion CALibration:CONTrol:COUNt

        #region CALibration:CONTrol:HALT

        //glennj 6/11/2013
        /// <summary>
        /// Sets the halt value to what is specified in the setValue variable.
        /// </summary>
        /// <param name="haltMode">Value used to set the boolean HALT variable.</param>
        public void AwgCalHalt(string haltMode)
        {
            string commandLine = "CALibration:CONTrol:HALT " + haltMode;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 6/11/2013
        /// <summary>
        /// Queries and returns the calibration halt value.
        /// </summary>
        /// <returns>Calibration Halt Value.</returns>
        public string AwgCalHaltQuery()
        {
            //Initialize
            string response;
            const string commandLine = "CALibration:CONTrol:HALT?";

            //Execute
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion CALibration:CONTrol:HALT

        #region CALibration:CONTrol:LOOP

        //glennj 6/11/2013
        /// <summary>
        /// Sets the value of the calibration loop control
        /// </summary>
        /// <param name="loopMode">Loop value desired to set.</param>
        public void AwgCalLoop(string loopMode)
        {
            string commandLine = "CALibration:CONTrol:LOOP " + loopMode;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 6/11/2013
        /// <summary>
        /// Queries and returns the value of the calibration loop control
        /// </summary>
        public string AwgCalControlLoopQuery()
        {
            //Initialize
            string response;
            const string commandLine = "CALibration:CONTrol:LOOP?";

            //Execute
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion CALibration:CONTrol:LOOP

        #region CALibration:DATA:FACTory?

        //glennj 06/10/2013
        /// <summary>
        /// Queries and returns the calibration factory data from specified area.
        /// </summary>
        /// <param name="requiredSubsystem"></param>
        /// <param name="optionalArea"></param>
        /// <param name="optionalProcedure"></param>
        /// <returns>Calibration factory data from specified area</returns>
        public string AwgCalDataFactoryQuery(string requiredSubsystem, string optionalArea = "", string optionalProcedure = "")
        {
            const string commandLine = "CALibration:DATA:FACTory? ";
            string response = GetCalData(commandLine, requiredSubsystem, optionalArea, optionalProcedure);
            string trimmed = trimBlockDtoHeader(response);
            return trimmed;
        }

        #endregion CALibration:DATA:FACTory?

        #region CALibration:DATA:USER

        //glennj 6/11/2013
        /// <summary>
        /// </summary>
        /// <param name="calConstantsAsXml"></param>
        /// <param name="requiredSubsystem"></param>
        /// <param name="optionalArea"></param>
        /// <param name="optionalProcedure"></param>
        public void AwgCalDataUser(string calConstantsAsXml, string requiredSubsystem, string optionalArea = "", string optionalProcedure = "")
        {
            //Initialize
            var utils = new UTILS();
            //var xmlWithDoubleQuotes = utils.addDoubleQuotes(addBlockDtoHeader(calConstantsAsXml));
            //var commandLine = "CALibration:DATA:USER " +
            //                  CreateParameterList(requiredSubsystem, optionalArea, optionalProcedure);
            //commandLine += commandLine + "," + '"' + xmlWithDoubleQuotes + '"';

            var commandLine = "CALibration:DATA:USER " +
                              CreateParameterList(requiredSubsystem, optionalArea, optionalProcedure);
            commandLine += "," + addBlockDtoHeader(calConstantsAsXml);
            _mAWGVisaSession.Timeout = 30000; // Set timeout to 15 seconds as command is blocking

            //Execute
            _mAWGVisaSession.Write(commandLine);
            _mAWGVisaSession.Timeout = _mDefaultVISATimeout;
        }

        //glennj 6/11/2013
        /// <summary>
        /// Queries and returns calibration user data
        /// </summary>
        /// <param name="requiredSubsystem"></param>
        /// <param name="optionalArea"></param>
        /// <param name="optionalProcedure"></param>
        /// <returns>Calibration user data from specified area</returns>
        public string AwgCalDataUserQuery(string requiredSubsystem, string optionalArea = "", string optionalProcedure = "")
        {
            const string commandLine = "CALibration:DATA:USER? ";
            string response = GetCalData(commandLine, requiredSubsystem, optionalArea, optionalProcedure);
            string trimmed = trimBlockDtoHeader(response);
            return trimmed;
        }

        #endregion CALibration:DATA:USER

        #region CALibration:LOOP?

        //glennj 6/11/2013
        /// <summary>
        /// Queries and returns the number of calibration loops completed.
        /// </summary>
        /// <returns>The number of calibrations loops completed</returns>
        public string AwgCalLoopQuery()
        {
            //Initialize
            string response;
            const string commandLine = "CALibration:LOOP?";

            //Execute
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion CALibration:LOOP?

        #region CALibration:SELect

        //glennj 6/11/2013
        /// <summary>
        /// Selects calibration procedures specified by the selection variable.
        /// 
        /// CALibration:SEL
        /// </summary>
        /// <param name="requiredSubsystem">Valid subsystem name</param>
        /// <param name="optionalArea">Valid area name</param>
        /// <param name="optionalProcedure">Valid procedure name</param>
        public void AwgCalSelect(string requiredSubsystem, string optionalArea = "", string optionalProcedure = "")
        {
            string commandLine = "CALibration:SELect " + CreateParameterList(requiredSubsystem, optionalArea, optionalProcedure);
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion CALibration:SELect

        #region CALibration:SELect:VERify?
        //glennj 6/11/2013
        /// <summary>
        /// Checks to see if a the test specified by the test variable is selected or unselected.
        /// </summary>
        /// <param name="requiredSubsystem">Valid subsystem name</param>
        /// <param name="requiredArea">Valid area name</param>
        /// <param name="requiredProcedure">Valid procedure name</param>
        /// <returns>Returns a 1 if the test is selected or a 0 if it is unselected</returns>
        public string AwgCalSelectVerify(string requiredSubsystem, string requiredArea, string requiredProcedure)
        {
            // Initialize
            string response;
            // Create command and parameter list
            string commandLine = "CALibration:SELect:VERify? " + CreateParameterList(requiredSubsystem, requiredArea, requiredProcedure);
            // Doit
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        
        #endregion CALibration:SELect:VERify?

        #region CALibration:TYPE:CATalog?

        //glennj 6/11/2013
        /// <summary>
        /// Queries for calibration type catalog and returns the reponse.
        /// </summary>
        /// <returns>Calibration Type Catalog</returns>
        public string AwgCalTypeCatalogQuery()
        {
            //Initialize
            string response;
            const string commandLine = "CALibration:TYPE:CATalog?";

            //Execute
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        
        #endregion CALibration:TYPE:CATalog?

        #region CALibration:TYPE

        //glennj 6/11/2013
        /// <summary>
        /// Sets the calibration type to calType variable.
        /// </summary>
        /// <param name="calType">Calibration type to set on the AWG</param>
        public void AwgCalType(string calType)
        {
            string commandLine = "CALibration:TYPE " + calType;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 6/11/2013
        /// <summary>
        /// Queries for the current calibration type.
        /// </summary>
        /// <returns>Calibration Type</returns>
        public string AwgCalTypeQuery()
        {
            //Initialize
            string response;
            const string commandLine = "CALibration:TYPE?";

            //Execute
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion CALibration:TYPE

        #region CALibration:UNSelect

        //glennj 6/11/2013
        /// <summary>
        /// Unselects calibration procedures specified by the selection variable.
        /// </summary>
        /// <param name="requiredSubsystem">Valid subsystem name</param>
        /// <param name="optionalArea">Valid area name</param>
        /// <param name="optionalProcedure">Valid procedure name</param>
        public void AwgCalUnselect(string requiredSubsystem, string optionalArea = "", string optionalProcedure = "")
        {
            string commandLine = "CALibration:UNSelect " + CreateParameterList(requiredSubsystem, optionalArea, optionalProcedure);
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion CALibration:UNSelect

        #endregion Non-Published

        //glennj 3/3/2014
        /// <summary>
        /// Given a list of subsystem, optional area and procedures,
        /// get the cal data
        /// </summary>
        /// <param name="command"></param>
        /// <param name="requiredSubsystem"></param>
        /// <param name="optionalArea"></param>
        /// <param name="optionalProcedure"></param>
        /// <returns></returns>
        string GetCalData(string command, string requiredSubsystem, string optionalArea = "", string optionalProcedure = "")
        {
            uint currentTimeout = _mAWGVisaSession.Timeout;
            _mAWGVisaSession.Timeout = 30000; // Set timeout to 30 seconds (units in ms)

            string commandLine = command;
            commandLine += CreateParameterList(requiredSubsystem, optionalArea, optionalProcedure);

            //Execute
            string response;
            string stringWithoutEscapeQuotes = null;
            _mAWGVisaSession.Write(commandLine);
            _mAWGVisaSession.Read(DataFactoryBufferSize, out response);
            _mAWGVisaSession.Timeout = currentTimeout;

            if (response != null)
            {
                stringWithoutEscapeQuotes = _mPiUtility.Dequotify(response);
                stringWithoutEscapeQuotes = _mPiUtility.removeDoubleQuotes(stringWithoutEscapeQuotes);
            }
            return stringWithoutEscapeQuotes;
        }

        //glennj 3/3/2014
        /// <summary>
        /// Given an optional list of subsystem, area and procedure names,
        /// create a list in correct order and properly quoted.
        /// </summary>
        /// <param name="optionalSubsystem"></param>
        /// <param name="optionalArea"></param>
        /// <param name="optionalProcedure"></param>
        /// <returns></returns>
        string CreateParameterList(string optionalSubsystem = "", string optionalArea = "", string optionalProcedure = "")
        {
            string commandLine = "";
            if (!optionalSubsystem.Equals(string.Empty))
            {
                optionalSubsystem = "\"" + optionalSubsystem + "\"";
                commandLine += optionalSubsystem;

                // Can only test and add the area if there is a subsystem
                if (!optionalArea.Equals(string.Empty))
                {
                    optionalArea = ",\"" + optionalArea + "\"";
                    commandLine += optionalArea;

                    // Can only test and add the procedure if there is an area
                    if (!optionalProcedure.Equals(string.Empty))
                    {
                        optionalProcedure = ",\"" + optionalProcedure + "\"";
                        commandLine += optionalProcedure;
                    }
                }
            }
            return commandLine;
        }

        //glennj 3/6/2014
        /// <summary>
        /// Assumes that the string has a beginning arbitrary block header
        /// that needs to be removed
        /// </summary>
        /// <param name="stringWithBlockHeader"></param>
        /// <returns></returns>
        string trimBlockDtoHeader(string stringWithBlockHeader)
        {
            string stringWithoutBlockHeader = "";
            if ((stringWithBlockHeader != "") && (stringWithBlockHeader.Length > 1))
            {
                // The block of data should start with '#', followed by single decimal number
                // The single decimal number states how many decimal digits follow that give
                // the length of the number of bytes that follow the decimal digit.
                if (stringWithBlockHeader[0] == ('#'))
                {
                    string singleDecimalNumber = stringWithBlockHeader.Substring(1, 1);
                    int numberOfFollowingDecimalDigits = Convert.ToInt32(singleDecimalNumber);
                    int totalNumberOfCharactersToDelete = numberOfFollowingDecimalDigits + 2;
                    stringWithoutBlockHeader = stringWithBlockHeader.Remove(0, totalNumberOfCharactersToDelete);
                }
            }
            return stringWithoutBlockHeader;
        }

        string addBlockDtoHeader( string stringWithoutHeader)
        {
            string stringWithHeader = "";
            int stringLength = stringWithoutHeader.Length;
            string lengthInDecimal = stringLength.ToString(CultureInfo.InvariantCulture);
            int numberOfDecimalDigits = lengthInDecimal.Length;
            string header = "#" + numberOfDecimalDigits.ToString(CultureInfo.InvariantCulture) + lengthInDecimal;
            stringWithHeader = header + stringWithoutHeader;
            return stringWithHeader;
        }
    }
}

