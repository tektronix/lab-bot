//==========================================================================
// CPI_ScopeMeasure.cs
//==========================================================================
namespace AwgTestFramework
{
    public partial class CPiScopeCmds
    {
        #region ScopeCommon

        #region MEASUrement:MEAS[n]:MAXimum?

        /// <summary>
        /// Gets the maximum measurement from the CSA or DPO
        /// 
        /// MEASUrement:MEAS[n]:MAXimum?
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <returns>Maximum measurement</returns>
        public string ScopeMeasureMaxQuery(string measurement)
        {
            string response;
            string command = "MEASUrement:MEAS" + measurement + ":MAXimum?";
            _mScopeVisaSession.Query(command, out response);
            //response = scope.ScopeErrorQueueParser(command, response);
            if (response == "")
            {
                //_mScopeVisaSession.Read(out response);
                response = _mScopeVisaSession.ErrorDescription;
            }
            return response;
        }
        #endregion MEASUrement:MEAS[n]:MAXimum?

        #region MEASUrement:MEAS[n]:MEAN?

        /// <summary>
        /// Gets the mean measurement from the CSA or DPO
        /// 
        /// MEASUrement:MEAS[n]:MEAN?
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <returns>Mean measurement</returns>
        public string ScopeMeasureMeanQuery(string measurement)
        {
            string response;
            string command = "MEASUrement:MEAS" + measurement + ":MEAN?";
            _mScopeVisaSession.Query(command, out response);
            //response = scope.ScopeErrorQueueParser(command, response);
            if (response == "")
            {
                //_mScopeVisaSession.Read(out response);
                response = _mScopeVisaSession.ErrorDescription;
            }
            return response;
        }
        #endregion MEASUrement:MEAS[n]:MEAN?

        #region MEASUrement:MEAS[n]:MINImum?

        /// <summary>
        /// Gets the minimum measurement from the CSA or DPO
        /// 
        /// MEASUrement:MEAS[n]:MINImum?
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <returns>Minimum measurement</returns>
        public string ScopeMeasureMinQuery(string measurement)
        {
            string response;
            string command = "MEASUrement:MEAS" + measurement + ":MINImum?";
            _mScopeVisaSession.Query(command, out response);
            //response = scope.ScopeErrorQueueParser(command, response);
            if (response == "")
            {
                //_mScopeVisaSession.Read(out response);
                response = _mScopeVisaSession.ErrorDescription;
            }
            return response;
        }
        #endregion MEASUrement:MEAS[n]:MINImum?

        #region MEASUrement:MEAS[n]:SOURCE1 CH[n]
        /// <summary>
        /// Sets the measurement source for the CSA and the DPO
        /// 
        /// MEASUrement:MEAS[n]:SOURCE1 CH[n]
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <param name="sourceChan">Channel to use as Measurement Source</param>
        /// <param name="state">Measurement state</param>
        public void ScopeMeasureSource(string measurement, string sourceChan, string state)
        {
            string command = "MEASUREMENT:MEAS" + measurement + ":SOURCE1 CH" + sourceChan + " ";
            _mScopeVisaSession.Write(command + state);
        }
        #endregion  MEASUrement:MEAS[n]:SOURCE1 CH[n]

        #region MEASUrement:MEAS[n]:STATE
        /// <summary>
        /// Sets the measurement state for the CSA and the DPO
        /// 
        /// MEASUrement:MEAS[n]:STATE
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <param name="state">Measurement state</param>
        public void ScopeMeasureState(string measurement, string state)
        {
            string command = "MEASUREMENT:MEAS" + measurement + ":STATE ";
            _mScopeVisaSession.Write(command + state);
        }
        #endregion MEASUrement:MEAS[n]:STATE

        #region MEASUrement:MEAS[n]:STDdev?
        /// <summary>
        /// Gets the standard deviation measurement from the CSA or DPO
        /// 
        /// MEASUrement:MEAS[n]:STDdev?
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <returns>Standard Deviation measurement</returns>
        public string ScopeMeasureStdDevQuery(string measurement)
        {
            string response;
            string command = "MEASUrement:MEAS" + measurement + ":STDdev?";
            _mScopeVisaSession.Query(command, out response);
            //response = scope.ScopeErrorQueueParser(command, response);
            if (response == "")
            {
                //_mScopeVisaSession.Read(out response);
                response = _mScopeVisaSession.ErrorDescription;
            }
            return response;
        }
        #endregion MEASUrement:MEAS[n]:STDdev?       

        #region MEASUrement:MEAS[n]:TYPe
        /// <summary>
        /// Sets the measurement type for the CSA and the DPO
        /// 
        /// NOTE: The string values for type differs between CSA and DPO along with types available on the DPO that are not on the CSA@n
        /// MEASUrement:MEAS[n]:TYPe
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <param name="type">Measurement type</param>
        public void ScopeMeasureType(string measurement, string type)
        {
            string command = "MEASUREMENT:MEAS"+ measurement + ":TYPe ";
            _mScopeVisaSession.Write(command + type);
        }
        #endregion MEASUrement:MEAS[n]:TYPe

        #region MEASUrement:MEAS[n]:VALue?
        /// <summary>
        /// Gets the measurement value from the CSA or DPO
        /// 
        /// MEASUrement:MEAS[n]:VALue?
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <returns>Measurement value</returns>
        public string ScopeMeasureValueQuery(string measurement)
        {
            string response;
            string command = "MEASUrement:MEAS" + measurement + ":VALue?";
            _mScopeVisaSession.Query(command, out response);
            //response = scope.ScopeErrorQueueParser(command, response);
            if (response == "")
            {
                //_mScopeVisaSession.Read(out response);
                response = _mScopeVisaSession.ErrorDescription;
            }
            return response;
        }
        #endregion MEASUrement:MEAS[n]:VALue?
        #endregion ScopeCommon

        #region CSA Only
        #region MEASUrement:MEAS[n]:SOUrce[channel]:WFM
        /// <summary>
        /// Sets the CSA measurement source to a given channel
        /// 
        /// MEASUrement:MEAS[n]:SOUrce[channel]:WFM
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <param name="source">Scope visa session and a collection of state variables</param>
        public void CSAMeasureSource(string measurement, string source)
        {
            string command = "MEASUrement:MEAS"+ measurement + ":SOUrce" + source + ":WFM";
            _mScopeVisaSession.Write(command);
        }
        #endregion MEASUrement:MEAS[n]:SOUrce[channel]:WFM        

        #region MEASUrement:MEAS1:STATistics:CLEAR
        /// <summary>
        /// Resets the CSA measurement statistics
        /// 
        /// MEASUrement:MEAS1:STATistics:CLEAR
        /// </summary>
        public void CSAMeasurementReset()
        {
            const string command = "MEASUREMENT:MEAS1:STATISTICS:CLEAR";
            _mScopeVisaSession.Write(command + command);
        }
        #endregion MEASUrement:MEAS1:STATistics:CLEAR
        #endregion CSA Only

        #region DPO Only
        #region MEASUrement:IMMed:SOUrce1 CH[n]
        /// <summary>
        /// Sets the DPO immediate source to a given channel
        /// 
        /// MEASUrement:IMMed:SOUrce1 CH[n]
        /// </summary>
        /// <param name="source">Which channel to be used as a source for the measurement </param>
        public void DPOImmedMeasureSource(string source)
        {
            const string command = "MEASUREMENT:IMMed:SOUrce1 CH";
            _mScopeVisaSession.Write(command + source);
        }
        #endregion MEASUrement:IMMed:SOUrce1 CH[n]

        #region MEASUrement:IMMed:TYPe
        /// <summary>
        /// Sets the DPO immediate measurement type
        /// 
        /// MEASUrement:IMMed:TYPe
        /// </summary>
        /// <param name="type">Measurement type</param>
        public void DPOImmedMeasureType(string type)
        {
            const string command = "MEASUrement:IMMed:TYPe ";
            _mScopeVisaSession.Write(command + type);
        }
        #endregion MEASUrement:IMMed:TYPe

        #region MEASUrement:IMMed:VALue?
        /// <summary>
        /// Gets the DPO immediate value
        /// 
        /// MEASUrement:IMMed:VALue?
        /// </summary>
        /// <returns>Immediate value</returns>
        public string DPOImmedMeasureValueQuery()
        {
            string response;
            const string command = "MEASUrement:IMMed:VALue?";
            _mScopeVisaSession.Query(command, out response);
            return response;
        }
        #endregion MEASUrement:IMMed:VALue?

        #region MEASUrement:MEAS[n]:SOUrce CH[n]
        /// <summary>
        /// Sets the DPO measurement source to a given channel
        /// 
        /// MEASUrement:MEAS[n]:SOUrce CH[n]
        /// </summary>
        /// <param name="source">hich channel to be used as a source for the measurement</param>
        /// <param name="measurement">Different numbered measurement displays</param>
        public void DPOMeasureSource(string measurement, string source)
        {
            string command = "MEASUrement:MEAS" + measurement + ":SOUrce CH" + source;
            _mScopeVisaSession.Write(command);
        }
        #endregion MEASUrement:MEAS[n]:SOUrce CH[n]

        #region MEASUrement:STATistics:COUNt RESET
        /// <summary>
        /// Resets the DPO measurement statistics
        /// 
        /// MEASUrement:STATistics:COUNt RESET
        /// </summary>
        public void DPOMeasurementReset()
        {
            const string command = "MEASUrement:STATistics:COUNt RESET";
            _mScopeVisaSession.Write(command + command);
        }
        #endregion MEASUrement:STATistics:COUNt RESET
        #endregion DPO Only
    }
}
