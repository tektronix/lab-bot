//==========================================================================
// SCOPE_AcquireSection.cs
//==========================================================================
namespace AwgTestFramework
{
    public partial class SCOPE
    {
        /// <summary>
        /// Property to contain the CSA response from ACQuire:CURRentcount:ACQWfms?
        /// </summary>
        public string CSAAquisitionCount { get; set; }

        /// <summary>
        /// Property to contain the CSA response from ACQuire:CURRentcount:MASKWfms?
        /// </summary>
        public string CSACurrentMaskCount { get; set; }
          
        /// <summary>
        /// Property to contain the DPO response from ACQuire:NUMACq?
        /// </summary>
        public string DPOAcquisitionWfmCount { get; set; }
        
        /// <summary>
        /// Property to contain the response from ACQuire:STATE?
        /// </summary>
        public string ScopeAquisitionState { get; set; }
        

        /// <summary>
        /// Set the Aquisition mode of the Scope
        /// 
        /// Uses ACQuire:MODe
        /// <param name="mode"></param>
        /// </summary>
        public void SetScopeAcquisitionMode(string mode)
        {
            _pis.ScopeAcquireMode(mode);
        }

        /// <summary>
        /// Sets the Acquisition state of the Scope
        /// 
        /// uses ACQuire:STATE
        /// </summary>
        /// <param name="state"></param>
        public void SetScopeAcquisitonState(string state)
        {
            _pis.ScopeAcquireState(state);
        }

        /// <summary>
        /// Gets the Acquisition state of the scope
        /// 
        /// uses ACQuire:STATE?
        /// </summary>
        /// <returns>Scope state</returns>
        public void GetScopeAcquisitionState()
        {
            ScopeAquisitionState = _pis.ScopeAcquireStateQuery();
        }

        /// <summary>
        /// Gets the number of acquired waveforms from the CSA
        /// 
        /// uses ACQuire:CURRentcount:ACQWfms?
        /// </summary>
        /// <returns>Number of acquired waveforms</returns>
        public void GetCSAAcquisitionCount()
        {
            CSAAquisitionCount = _pis.CSAAcquisitionCountQuery();
        }

        /// <summary>
        /// Gets the CSA mask waveform acquisition count
        /// 
        /// uses ACQuire:CURRentcount:MASKWfms?
        /// </summary>
        /// <returns>Current waveform acquistion count</returns>
        public void GetCSACurrentMaskWfmCount()
        {
            CSACurrentMaskCount = _pis.CSACurrentMaskWfmCountQuery();
        }

        /// <summary>
        /// Resets the CSA waveform count acquisition count
        /// 
        /// uses ACQuire:DATA:CLEar
        /// </summary>
        public void CSAAcquisitionCountReset()
        {
            _pis.CSAResetAcquisitionCount();
        }

        /// <summary>
        /// Sets the acquisition stop after condition
        /// 
        /// uses ACQuire:STOPAfter:CONDition
        /// </summary>
        /// <param name="state"></param>
        public void SetCSAAcquireStopAfterCondition(string state)
        {
            _pis.CSAAcquireStopAfterConditionState(state);
        }

        /// <summary>
        /// Sets the criteria for when the CSA will stop acquisition
        /// 
        /// uses ACQuire:STOPAfter:COUNt
        /// </summary>
        /// <param name="count">Number of hits</param>
        public void SetCSAAcquireStopAfterCount(string count)
        {
            _pis.CSAAcquireStopAfterCount(count);
        }

        /// <summary>
        /// Sets the acquisition stop after mode for a CSA Scope
        /// 
        /// uses ACQuire:STOPAfter:MODe
        /// </summary>
        /// <param name="mode"></param>
        public void SetCSAAcquireStopAfterMode(string mode)
        {
            _pis.CSAAcquireStopAfterMode(mode);
        }

        /// <summary>
        /// Gets the number of acquired waveforms from the DPO since starting Acquisition with the ACQuire:STATE RUN command
        /// 
        /// ACQuire:NUMACq?
        /// </summary>
        /// <returns>Number of acquired waveforms</returns>
        public void GetDPOAcquisitionWfmCount()
        {
            DPOAcquisitionWfmCount = _pis.DPOAcquisitionCountQuery();
        }

        /// <summary>
        /// Sets the DPO stop after mode
        /// 
        /// uses ACQuire:STOPAfter
        /// </summary>
        /// <param name="mode">Desired DPO stop after mode</param>
        public void SetDPOAcquireStopAfterMode(string mode)
        {
            _pis.DPOAcquireStopAfterMode(mode);
        }
        
        /// <summary>
        /// Sets the Fast Acquisitions State on a DPO
        /// </summary>
        /// <param name="state">Fast acquisition state [ON|OFF]</param>
        public void SetDPOFastAcquisitions(string state)
        {
            _pis.DPOFastAcquisitions(state);
        }
    }
}
