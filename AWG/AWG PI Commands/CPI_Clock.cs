
namespace AwgTestFramework 
{
    public partial class CPi70KCmds
    {
        #region CLOCk:ECLock:DIVider

        //glennj 9/5/2013
        /// <summary>
        /// Using CLOCk:ECLock:DIVider to set the divider
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Divide by a power of 2</param>
        public void SetAwgClockExternalDivider(string clockNumber, string setValue)
        {
            string commandLine = "CLOCk" + clockNumber + ":ECLock:DIVider " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 9/5/2013
        /// <summary>
        /// Using CLOCk:ECLock:DIVider? to get the divider setting
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <returns>The divider setting</returns>
        public string GetAwgClockExternalDivider(string clockNumber)
        {
            string response;
            string commandLine ="CLOCk" + clockNumber + ":ECLock:DIVider?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion CLOCk:ECLock:DIVider

        #region CLOCk:ECLock:FREQuency

        //glennj 06/10/2013
        /// <summary>
        /// Using CLOCk:ECLock:FREQuency it sets expected frequency being provided by the external clock
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Frequency being provided by the external clock</param>
        public void SetAwgClockExternalClockFrequency(string clockNumber, string setValue)
        {
            string commandLine = "CLOCk" + clockNumber + ":ECLock:FREQuency " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 06/10/2013
        /// <summary>
        /// Using CLOCk:ECLock:FREQuency? it gets expected frequency being provided by the external clock
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <returns>Frequency being provided by the external clock</returns>
        public string GetAwgClockExternalClockFrequency(string clockNumber)
        {
            string response;
            string commandLine = "CLOCk" + clockNumber + ":ECLock:FREQuency?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion CLOCk:ECLock:FREQuency

        #region CLOCk:ECLock:FREQuency:ADJust

        //glennj 9/5/2013
        /// <summary>
        /// Using CLOCk:ECLock:FREQuency:ADJust to tell the calibrate to the external clock
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        public void AdjustAwgClockExternalClockFrequency(string clockNumber)
        {
            string commandLine = "CLOCk" + clockNumber + ":ECLock:FREQuency:ADJust";
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion CLOCk:ECLock:FREQuency:ADJust

        #region CLOCk:ECLock:FREQuency:DETect

        //glennj 06/10/2013
        /// <summary>
        /// Using CLOCk:ECLock:FREQuency:DETect it tells the system to acquire the external clock and adjust the system to use it
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        public void AwgClockExternalClockFrequencyAuto(string clockNumber)
        {
            string commandLine = "CLOCk" + clockNumber + ":ECLock:FREQuency:DETect";
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion CLOCk:ECLock:FREQuency:DETect

        #region CLOCk:ECLock:FREQuency:MULTiplier

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:ECLock:MULTiplier it sets the multipler rate of the external clock
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Multipler rate of the external clock</param>
        public void SetAwgClockExternalMultiplier(string clockNumber, string setValue)
        {
            string commandLine = "CLOCk" + clockNumber + ":ECLock:MULTiplier " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:ECLock:MULTiplier? it gets the multipler rate of the external clock
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <returns>Multipler rate of the external clock</returns>
        public string GetAwgClockExternalMultiplier(string clockNumber)
        {
            string response;
            string commandLine = "CLOCk" + clockNumber + ":ECLock:MULTiplier?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion CLOCk:ECLock:FREQuency:MULTiplier
    
        #region CLOCk:EREFerence:DIVider

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:EREFerence:DIVider sets the divider rate<para>
        /// of the external reference signal when the external reference is variable</para>
        /// </summary>
        /// <param name="clockNumber"></param>
        /// <param name="setValue"></param>
        public void SetAwgExternalReferenceClockDivider(string clockNumber, string setValue)
        {
            string commandLine = "CLOCk" + clockNumber + ":EREFerence:DIVider " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:EREFerence:DIVider? to get the divider rate<para>
        /// of the external reference signal when the external reference is variable</para>
        /// </summary>
        /// <param name="clockNumber"></param>
        /// <returns></returns>
        public string GetAwgExternalReferenceClockDivider(string clockNumber)
        {
            string response;
            string commandLine = "CLOCk" + clockNumber + ":EREFerence:DIVider?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion CLOCk:EREFerence:DIVider

        #region CLOCk:EREFerence:FREQuency

        //glennj 06/10/2013
        /// <summary>
        /// Using CLOCk:EREFerence:FREQuency to set the expected frequency<para>
        /// being provided by the external clock</para>
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Frequency being provided by the external reference</param>
        public void SetAwgClockExternalReferenceFrequency(string clockNumber, string setValue)
        {
            string commandLine = "CLOCk" + clockNumber + ":EREFerence:FREQuency " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 06/10/2013
        /// <summary>
        /// Using CLOCk:EREFerence:FREQuency? to get the expected frequency<para>
        /// being provided by the external clock</para>
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <returns>Frequency being provided by the external reference</returns>
        public string GetAwgClockExternalReferenceFrequency(string clockNumber)
        {
            string response;
            string commandLine = "CLOCk" + clockNumber + ":EREFerence:FREQuency?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion CLOCk:EREFerence:FREQuency

        #region CLOCk:EREFerence:FREQuency:DETect

        //glennj 06/10/2013
        /// <summary>
        /// Using CLOCk:EREFerence:FREQuency:DETect it tells the system to acquire<para>
        /// the external reference and adjust the system to use it</para>
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        public void AwgClockExternalReferenceFrequencyDetect(string clockNumber)
        {
            string commandLine = "CLOCk" + clockNumber + ":EREFerence:FREQuency:DETect";
            _mAWGVisaSession.Write(commandLine);
        }

        #endregion CLOCk:EREFerence:FREQuency:DETect

        #region CLOCk:EREFerence:MULTiplier

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:EREFerence:MULTiplier to set the multiplier of the external<para>
        /// reference signal when the external reference is variable</para>
        /// </summary>
        /// <param name="clockNumber"></param>
        /// <param name="setValue"></param>
        public void SetAwgExternalReferenceClockMultiplier(string clockNumber, string setValue)
        {
            string commandLine = "CLOCk" + clockNumber + ":EREFerence:MULTiplier " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:EREFerence:MULTiplier? to get the multiplier of the external<para>
        /// reference signal when the external reference is variable</para>
        /// </summary>
        /// <param name="clockNumber"></param>
        /// <returns></returns>
        public string GetAwgExternalReferenceClockMultiplier(string clockNumber)
        {
            string response;
            string commandLine = "CLOCk" + clockNumber + ":EREFerence:MULTiplier?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion CLOCk:EREFerence:MULTiplier

        #region CLOCk:JITTer
        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:JITTer to set the low jitter enabled on the system.
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Jitter boolean</param>
        public void SetAwgClockJitter(string clockNumber, string setValue)
        {
            string commandLine = "CLOCk" + clockNumber + ":JITTer " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:JITTer? to get the low jitter enabled state on the system.
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <returns>Whether low jitter is enabled</returns>
        public string GetAwgClockJitter(string clockNumber)
        {
            string response;
            string commandLine = "CLOCk" + clockNumber + ":JITTer?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion CLOCk:JITTer

        #region CLOCk:PHASe:ADJust
        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:PHASe:ADJust it sets the internal clock phase adjustment of the AWG
        /// </summary>
        /// <param name="clockNumber"></param>
        /// <param name="setValue"></param>
        public void SetAwgClockPhaseAdjust(string clockNumber, string setValue)
        {
            string commandLine = "CLOCk" + clockNumber + ":PHASe:ADJust " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:PHASe:ADJust? it gets the internal clock phase adjustment of the AWG
        /// </summary>
        /// <param name="clockNumber"></param>
        /// <returns></returns>
        public string GetAwgClockPhaseAdjust(string clockNumber)
        {
            string response;
            string commandLine = "CLOCk" + clockNumber + ":PHASe:ADJust?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion CLOCk:OUTput:ADJust

        #region CLOCk:OUTput:FREQuency

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:OUTput:FREQuency? it gets the output frequency of the specified clock.
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <returns>Output frequency</returns>
        public string GetAwgClockOutputFrequency(string clockNumber)
        {
            string response;
            string commandLine = "CLOCk" + clockNumber + ":OUTput:FREQuency?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion CLOCk:OUTput:FREQuency

        #region CLOCk:OUTput:STATe

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:OUTput:STATe it sets the output state of the specified clock.
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Output state</param>
        public void SetAwgClockOutputState(string clockNumber, string setValue)
        {
            string commandLine = "CLOCk" + clockNumber + ":OUTput:STATe " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:OUTput:STATe? it gets the output state of the specified clock.
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <returns>Output state</returns>
        public string GetAwgClockOutputState(string clockNumber)
        {
            string response;
            string commandLine = "CLOCk" + clockNumber + ":OUTput:STATe?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion CLOCk:OUTput:STATe

        #region CLOCk:SOURce

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:SOURce it sets the source of the clock.
        /// </summary>
        /// <param name="clockNumber"></param>
        /// <param name="setValue"></param>
        public void SetAwgClockSource(string clockNumber, string setValue)
        {
            string commandLine = "CLOCk" + clockNumber + ":SOURce " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:SOURce? to get the source of the clock.
        /// </summary>
        /// <param name="clockNumber">One of the available clocks</param>
        public string GetAwgClockSource(string clockNumber)
        {
            string response;
            string commandLine = "CLOCk" + clockNumber + ":SOURce?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion CLOCk:SOURce

        #region CLOCk:SOUT:STATe
        //glennj 06/19/2013
        /// <summary>
        /// Using CLOCk:SOUT:STATe set the state of the Sync Clock Out output
        /// </summary>
        /// <param name="clockNumber"></param>
        /// <param name="setValue"></param>
        public void SetAwgClockSoutState(string clockNumber, string setValue)
        {
            string commandLine = "CLOCk" + clockNumber + ":SOUT:STATe " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 06/19/2013
        /// <summary>
        /// Using CLOCk:SOUT:STATe? get the state of the Sync Clock Out output
        /// </summary>
        /// <param name="clockNumber">One of the available clocks</param>
        public string GetAwgClockSoutState(string clockNumber)
        {
            string response;
            string commandLine = "CLOCk" + clockNumber + ":SOUT:STATe?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion CLOCk:SOUT:STATe

        #region CLOCk:SRATe
        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:SRATe it sets the sample rate for the given clock using CLOCk:SRATe
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Sample Rate</param>
        public void SetAwgClockSRate(string clockNumber, string setValue)
        {
            string commandLine = "CLOCk" + clockNumber + ":SRATe " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:SRATe? it gets the sample rate for the given clock using CLOCk:SRATe
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <returns>Sample rate</returns>
        public string GetAwgClockSRate(string clockNumber)
        {
            string response;
            string commandLine = "CLOCk" + clockNumber + ":SRATe?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion CLOCk:SRATe

    }
}
