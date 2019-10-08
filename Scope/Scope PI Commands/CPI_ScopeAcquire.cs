
namespace AwgTestFramework
{
    public partial class CPiScopeCmds
    {

        #region ScopeCommon
        #region ACQuire:MODe
        /// <summary>
        /// Sets the Scope acquistion mode
        /// 
        /// ACQuire:MODe
        /// </summary>
        /// <param name="mode">Scope acquisition mode</param>
        public void ScopeAcquireMode(string mode)
        {
            const string command = "ACQuire:MODe ";
            _mScopeVisaSession.Write(command + mode);
        }
        #endregion ACQuire:MODe 

        #region ACQuire:STATE
        /// <summary>
        /// Sets the scope acquisition state
        /// 
        /// ACQuire:STATE
        /// </summary>
        /// <param name="state"></param>
        public void ScopeAcquireState(string state)
        {
            const string command = "ACQuire:STATE ";
            _mScopeVisaSession.Write(command + state);
        }
        #endregion ACQuire:STATE

        #region ACQuire:STATE?
        /// <summary>
        /// Gets the scope acquisition state
        /// 
        /// ACQuire:STATE?
        /// </summary>
        /// <returns>Scope state</returns>
        public string ScopeAcquireStateQuery()
        {
            string response;
            const string command = "ACQuire:STATE?";
            _mScopeVisaSession.Query(command, out response);
            //response = scope.ScopeErrorQueueParser(command, response);
            if (response == "")
            {
                //_mScopeVisaSession.Read(out response);
                response = _mScopeVisaSession.ErrorDescription;
            }
            return response;
        }
        #endregion ACQuire:STATE?
        #endregion ScopeCommon

        #region CSA Only
        #region ACQuire:CURRentcount:ACQWfms?
        /// <summary>
        /// Gets the number of acquired waveforms from the CSA
        /// 
        /// ACQuire:CURRentcount:ACQWfms?
        /// </summary>
        /// <returns>Number of acquired waveforms</returns>
        public string CSAAcquisitionCountQuery()
        {
            string response;
            const string command = "ACQuire:CURRentcount:ACQWfms?";
            _mScopeVisaSession.Query(command, out response);
            //response = scope.ScopeErrorQueueParser(command, response);
            if (response == "")
            {
                //_mScopeVisaSession.Read(out response);
                response = _mScopeVisaSession.ErrorDescription;
            }
            return response;
        }
        #endregion ACQuire:CURRentcount:ACQWfms?

        #region ACQuire:CURRentcount:MASKWfms?
        /// <summary>
        /// Gets the CSA mask waveform acquisition count
        /// 
        /// ACQuire:CURRentcount:MASKWfms?
        /// </summary>
        /// <returns>Current waveform acquistion count</returns>
        public string CSACurrentMaskWfmCountQuery()
        {
            string response;
            const string command = "ACQuire:CURRentcount:MASKWfms?";
            _mScopeVisaSession.Query(command, out response);
            //response = scope.ScopeErrorQueueParser(command, response);
            if (response == "")
            {
                //_mScopeVisaSession.Read(out response);
                response = _mScopeVisaSession.ErrorDescription;
            }
            return response;
        }
        #endregion ACQuire:CURRentcount:MASKWfms?

        #region ACQuire:DATA:CLEar
        /// <summary>
        /// Resets the CSA waveform count acquisition count
        /// 
        /// ACQuire:DATA:CLEar
        /// </summary>
        public void CSAResetAcquisitionCount()
        {
            const string command = "ACQuire:DATA:CLEar";
            _mScopeVisaSession.Write(command);
        }
        #endregion ACQuire:DATA:CLEar

        #region ACQuire:STOPAfter:CONDition
        /// <summary>
        /// Sets the acquisition stop after condition
        /// 
        /// ACQuire:STOPAfter:CONDition
        /// </summary>
        /// <param name="state"></param>
        public void CSAAcquireStopAfterConditionState(string state)
        {
            const string command = "ACQuire:STOPAfter:CONDition ";
            _mScopeVisaSession.Write(command + state);
        }
        #endregion ACQuire:STOPAfter:CONDition

        #region ACQuire:STOPAfter:COUNt
        /// <summary>
        /// Sets the criteria for when the CSA will stop acquisition
        /// 
        /// ACQuire:STOPAfter:COUNt
        /// </summary>
        /// <param name="count">Number of hits</param>
        public void CSAAcquireStopAfterCount(string count)
        {
            const string command = "ACQuire:STOPAfter:COUNt ";
            _mScopeVisaSession.Write(command + count);
        }
        #endregion ACQuire:STOPAfter:COUNt

        #region ACQuire:STOPAfter:MODe
        /// <summary>
        /// Sets the acquisition stop after mode
        /// 
        /// ACQuire:STOPAfter:MODe
        /// </summary>
        /// <param name="mode"></param>
        public void CSAAcquireStopAfterMode(string mode)
        {
            const string command = "ACQuire:STOPAfter:MODe ";
            _mScopeVisaSession.Write(command + mode);
        }
        #endregion ACQuire:STOPAfter:MODe
        #endregion CSA Only

        #region DPO Only
        #region ACQuire:NUMACq?
        /// <summary>
        /// Gets the number of acquired waveforms from the DPO since starting Acquisition with the ACQuire:STATE RUN command
        /// 
        /// ACQuire:NUMACq?
        /// </summary>
        /// <returns>Number of acquired waveforms</returns>
        public string DPOAcquisitionCountQuery()
        {
            string response;
            const string command = "ACQuire:NUMACq?";
            _mScopeVisaSession.Query(command, out response);
            //response = scope.ScopeErrorQueueParser(command, response);
            if (response == "")
            {
                //_mScopeVisaSession.Read(out response);
                response = _mScopeVisaSession.ErrorDescription;
            }
            return response;
        }
        #endregion ACQuire:NUMACq?

        #region ACQuire:STOPAfter
        /// <summary>
        /// Sets the DPO stop after mode
        /// 
        /// ACQuire:STOPAfter
        /// </summary>
        /// <param name="mode">Desired DPO stop after mode</param>
        public void DPOAcquireStopAfterMode(string mode)
        {
            const string command = "ACQuire:STOPAfter ";
            _mScopeVisaSession.Write(command + mode);
        }
        #endregion ACQuire:STOPAfter

        #region FASTAcq:STATE
        /// <summary>
        /// This command sets the state of Fast Acquisitions
        /// </summary>
        /// <param name="state">Fast acquisition state [ON|OFF]</param>
        public void DPOFastAcquisitions(string state)
        {
            const string command = "FASTAcq:STATE ";
            _mScopeVisaSession.Write(command + state);
        }
        #endregion FASTAcq:STATE
        #endregion DPO Only
    }
}
