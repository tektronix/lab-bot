using System;

// ReSharper disable CheckNamespace
namespace AwgTestFramework 
// ReSharper restore CheckNamespace
{
    public partial class AWG
    {
        #region CLOCk:ECLock:DIVider

        /// <summary>
        /// Attribute for CLOCk:ECLock:DIVider?
        /// </summary>
        readonly string[] _clockExternalClockDividerRate = new string[AwgMaxClocks];

        //glennj 9/5/2013
        /// <summary>
        /// Using CLOCk:ECLock:DIVider to set the divider
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Divide by a power of 2</param>
        public void SetClockExternalDivider(string clockNumber, string setValue)
        {
            _pi.SetAwgClockExternalDivider(clockNumber, setValue);
        }

        //glennj 9/5/2013
        /// <summary>
        /// Using CLOCk:ECLock:DIVider? to get the divider setting
        /// </summary>
        /// <param name="logicalClock">Which clock</param>
        /// <returns>The divider setting</returns>
        public void GetClockExternalDivider(string logicalClock)
        {
            int clockNumber = Convert.ToInt32(logicalClock);
            if (clockNumber <= AwgMaxClocks)
            {
                _clockExternalClockDividerRate[clockNumber-1] = _pi.GetAwgClockExternalDivider(logicalClock);
            }
        }

        //glennj 12/4/2013
        /// <summary>
        /// Return the updated external clock divider rate per clock
        /// </summary>
        /// <param name="logicalClock"></param>
        /// <returns></returns>
        public string ClockExternalDivider(string logicalClock)
        {
            string externalClockDividerRate = null;
            int clockNumber = Convert.ToInt32(logicalClock);
            if (clockNumber <= AwgMaxClocks)
            {
                externalClockDividerRate = _clockExternalClockDividerRate[clockNumber - 1];
            }
            return externalClockDividerRate;
        }

        #endregion CLOCk:ECLock:DIVider

        #region CLOCk:ECLock:FREQuency

        /// <summary>
        /// Attributes for CLOCK:ECLOck:FREQuency?
        /// </summary>
        readonly string[] _clockExternalClockFrequency = new string[AwgMaxClocks];

        //glennj 06/10/2013
        /// <summary>
        /// Using CLOCk:ECLock:FREQuency to set expected frequency being<para>
        /// provided by the external clock</para>
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Frequency being provided by the external clock</param>
        public void SetClockExternalClockFrequency(string clockNumber, string setValue)
        {
            _pi.SetAwgClockExternalClockFrequency(clockNumber, setValue);
        }

        //glennj 06/10/2013
        /// <summary>
        /// Using CLOCk:ECLock:FREQuency? to get expected frequency being provided by the external clock
        /// </summary>
        /// <param name="logicalClock">Which clock</param>
        /// <returns>Frequency being provided by the external clock</returns>
        public void GetClockExternalClockFrequency(string logicalClock)
        {
            var clockNumber = Convert.ToInt32(logicalClock);
            if (clockNumber <= AwgMaxClocks)
            {
                _clockExternalClockFrequency[clockNumber - 1] = _pi.GetAwgClockExternalClockFrequency(logicalClock);
            }
        }

        //glennj 12/4/2013
        /// <summary>
        /// Return the updated external clock frequency per clock
        /// </summary>
        /// <param name="logicalClock"></param>
        /// <returns></returns>
        public string ClockExternalClockFrequency(string logicalClock)
        {
            string externalClockFrequency = null;
            int clockNumber = Convert.ToInt32(logicalClock);
            if (clockNumber <= AwgMaxClocks)
            {
                externalClockFrequency = _clockExternalClockFrequency[clockNumber - 1];
            }
            return externalClockFrequency;
        }

        #endregion CLOCk:ECLock:FREQuency

        #region CLOCk:ECLock:FREQuency:ADJust

        //glennj 9/5/2013
        /// <summary>
        /// Using CLOCk:ECLock:FREQuency:ADJust to tell a specified<para>
        /// clock to calibrate to the external clock</para>
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        public void AdjustClockExternalClockFrequency(string clockNumber)
        {
            _pi.AdjustAwgClockExternalClockFrequency(clockNumber);
        }

        #endregion CLOCk:ECLock:FREQuency:ADJust

        #region CLOCk:ECLock:FREQuency:DETect

        //glennj 06/10/2013
        /// <summary>
        /// Using CLOCk:ECLock:FREQuency:DETect to tell the system to acquire the external clock and adjust the system to use it
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        public void ClockExternalClockFrequencyAuto(string clockNumber)
        {
            _pi.AwgClockExternalClockFrequencyAuto(clockNumber);
        }

        #endregion CLOCk:ECLock:FREQuency:DETect

        #region CLOCk:ECLock:MULTiplier

        /// <summary>
        /// CLOCk:MULTiplier
        /// </summary>
        private readonly string[] _clockMultipler = new string[AwgMaxClocks];

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:ECLock:MULTiplier it sets the multipler rate of the external clock
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Multipler rate of the external clock</param>
        public void SetExternalClockMultiplier(string clockNumber, string setValue)
        {
            _pi.SetAwgClockExternalMultiplier(clockNumber, setValue);
        }

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:ECLock:MULTiplier? it gets the multipler rate of the external clock
        /// </summary>
        /// <param name="logicalClock">Which clock</param>
        /// <returns>Multipler rate of the external clock</returns>
        public void GetExternalClockMultiplier(string logicalClock)
        {
            var clockNumber = Convert.ToInt32(logicalClock);
            if (clockNumber <= AwgMaxClocks)
            {
                _clockMultipler[clockNumber - 1] = _pi.GetAwgClockExternalMultiplier(logicalClock);
            }
        }

        //glennj 12/4/2013
        /// <summary>
        /// Return the updated external clock divider rate per clock
        /// </summary>
        /// <param name="logicalClock"></param>
        /// <returns></returns>
        public string ClockMultipler(string logicalClock = "1")
        {
            string clockMultipler = null;
            var clockNumber = Convert.ToInt32(logicalClock);
            if (clockNumber <= AwgMaxClocks)
            {
                clockMultipler = _clockMultipler[clockNumber - 1];
            }
            return clockMultipler;
        }

        #endregion CLOCk:ECLock:MULTiplier

        #region CLOCk:EREFerence:DIVider

        /// <summary>
        /// Property for Clock External Reference Divider
        /// </summary>
        readonly string[] _clockExternalReferenceDivider = new string[AwgMaxClocks];

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:EREFerence:DIVider to set the divider rate of the<para>
        /// external reference signal when the external reference is variable</para>
        /// </summary>
        /// <param name="clockNumber"></param>
        /// <param name="setValue"></param>
        public void SetExternalReferenceClockDivider(string clockNumber, string setValue)
        {
            _pi.SetAwgExternalReferenceClockDivider(clockNumber, setValue);
        }

        //glennj 12/4/2013
        /// <summary>
        /// Using CLOCk:EREFerence:DIVider? to get the divider rate of the<para>
        /// external reference signal when the external reference is</para><para>
        /// variable and makes local copy</para>
        /// </summary>
        /// <param name="logicalClock"></param>
        /// <returns></returns>
        public void GetExternalReferenceClockDivider(string logicalClock)
        {
            int clockNumber = Convert.ToInt32(logicalClock);
            if (clockNumber <= AwgMaxClocks)
            {
                _clockExternalReferenceDivider[clockNumber-1] = _pi.GetAwgExternalReferenceClockDivider(logicalClock);
            }
        }

        //glennj 12/4/2013
        /// <summary>
        /// Returns the updated divider rate of the external reference
        /// </summary>
        /// <param name="logicalClock"></param>
        /// <returns></returns>
        public string ExternalReferenceClockDivider(string logicalClock)
        {
            string externalReferenceClockDivider = null;
            int clockNumber = Convert.ToInt32(logicalClock);
            if (clockNumber <= AwgMaxClocks)
            {
                externalReferenceClockDivider = _clockExternalReferenceDivider[clockNumber - 1];
            }
            return externalReferenceClockDivider;
        }

        #endregion CLOCk:EREFerence:DIVider

        #region CLOCk:EREFerence:FREQuency

        /// <summary>
        /// CLOCk:EREFerence:FREQuency
        /// </summary>
        readonly string[] _clockExternalReferenceFrequency = new string[AwgMaxClocks];

        //glennj 06/10/2013
        /// <summary>
        /// Sets expected frequency being provided by the external clock
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Frequency being provided by the external reference</param>
        public void SetClockExternalReferenceFrequency(string clockNumber, string setValue)
        {
            _pi.SetAwgClockExternalReferenceFrequency(clockNumber, setValue);
        }

        //glennj 06/10/2013
        /// <summary>
        /// Updates the AWG object with expected frequency being provided by the external reference
        /// </summary>
        /// <param name="logicalClock">Which clock</param>
        /// <returns>Frequency being provided by the external reference</returns>
        public void GetClockExternalReferenceFrequency(string logicalClock = "1")
        {
            int clockNumber = Convert.ToInt32(logicalClock);
            if (clockNumber <= AwgMaxClocks)
            {
                _clockExternalReferenceFrequency[clockNumber - 1] = _pi.GetAwgClockExternalReferenceFrequency(logicalClock);
            }
        }

        //glennj 12/4/2013
        /// <summary>
        /// Returns the updated frequency of the external reference
        /// </summary>
        /// <param name="logicalClock"></param>
        /// <returns></returns>
        public string ClockExternalReferenceFrequency(string logicalClock="1")
        {
            string externalReferenceFrequency = null;
            int clockNumber = Convert.ToInt32(logicalClock);
            if (clockNumber <= AwgMaxClocks)
            {
                externalReferenceFrequency = _clockExternalReferenceFrequency[clockNumber - 1];
            }
            return externalReferenceFrequency;
        }

        #endregion CLOCk:EREFerence:FREQuency

        #region CLOCk:EREFerence:FGREQuency:DETect

        //glennj 06/10/2013
        /// <summary>
        /// Using CLOCk:EREFerence:FREQuency:DETect tell the system to acquire the external reference and adjust the system to use it
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        public void ForceClockExternalReferenceFrequencyDetect(string clockNumber)
        {
            _pi.AwgClockExternalReferenceFrequencyDetect(clockNumber);
        }

        #endregion CLOCk:EREFerence:FGREQuency:DETect

        #region CLOCk:EREFerence:MULTiplier

        /// <summary>
        /// External Reference Clock Multiplier
        /// </summary>
        readonly string[] _clockExternalReferenceMultiplier = new string[AwgMaxClocks];

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:EREFerence:MULTiplier to set the multiplier of the external reference signal when the external reference is variable
        /// </summary>
        /// <param name="clockNumber"></param>
        /// <param name="setValue"></param>
        public void SetExternalReferenceClockMultiplier(string clockNumber, string setValue)
        {
            _pi.SetAwgExternalReferenceClockMultiplier(clockNumber, setValue);
        }

        //glennj 06/07/2013
        /// <summary>
        /// Gets the multiplier of the external reference signal when the external reference is variable
        /// </summary>
        /// <param name="logicalClock"></param>
        /// <returns></returns>
        public void GetExternalReferenceClockMultiplier(string logicalClock)
        {
            var clockNumber = Convert.ToInt32(logicalClock);
            if (clockNumber <= AwgMaxClocks)
            {
                _clockExternalReferenceMultiplier[clockNumber-1] = _pi.GetAwgExternalReferenceClockMultiplier(logicalClock);
            }
        }

        //glennj 12/5/2013
        public string ExternalReferenceClockMultiplier(string logicalClock)
        {
            string externalReferenceClockMultiplier = null;
            var clockNumber = Convert.ToInt32(logicalClock);
            if (clockNumber <= AwgMaxClocks)
            {
                externalReferenceClockMultiplier = _clockExternalReferenceMultiplier[clockNumber - 1];
            }
            return externalReferenceClockMultiplier;
        }

        #endregion CLOCk:EREFerence:MULTiplier

        #region CLOCk:JITTer

        /// <summary>
        /// Attribute for CLOCk:JITTer?
        /// </summary>
        readonly string[] _clockJitter = new string[AwgMaxClocks];

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:JITTer to set whether low jitter is enabled on the system.
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Jitter boolean</param>
        public void SetClockJitter(string clockNumber, string setValue)
        {
            _pi.SetAwgClockJitter(clockNumber, setValue);
        }

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:JITTer? to get whether low jitter is enabled on the system.
        /// </summary>
        /// <param name="logicalClock">Which clock</param>
        /// <returns>Whether low jitter is enabled</returns>
        public void GetClockJitter(string logicalClock)
        {
            var clockNumber = Convert.ToInt32(logicalClock);
            if (clockNumber <= AwgMaxClocks)
            {
                _clockJitter[clockNumber - 1] = _pi.GetAwgClockJitter(logicalClock);
            }
        }

        //glennj 12/4/2013
        /// <summary>
        /// Return the updated clock jitter
        /// </summary>
        /// <param name="logicalClock"></param>
        /// <returns></returns>
        public string ClockJitter(string logicalClock)
        {
            string clockJitter = null;
            var clockNumber = Convert.ToInt32(logicalClock);
            if (clockNumber <= AwgMaxClocks)
            {
                clockJitter = _clockJitter[clockNumber - 1];
            }
            return clockJitter;
        }

        #endregion CLOCk:JITTer

        #region CLOCk:OUTput:FREQuency

        readonly string[] _clockOutputFreq = new string[AwgMaxClocks];

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:OUTput:FREQuency? to get the output frequency of the specified clock.
        /// </summary>
        /// <param name="logicalClock">Which clock</param>
        /// <returns>Output frequency</returns>
        public void GetClockOutputFrequency(string logicalClock)
        {
            var clockNumber = Convert.ToInt32(logicalClock);
            if (clockNumber <= AwgMaxClocks)
            {
                _clockOutputFreq[clockNumber - 1] = _pi.GetAwgClockOutputFrequency(logicalClock);
            }
        }

        public string ClockOutputFrequency(string logicalClock)
        {
            string clockOutputFrequency = null;
            var clockNumber = Convert.ToInt32(logicalClock);
            if (clockNumber <= AwgMaxClocks)
            {
                clockOutputFrequency = _clockOutputFreq[clockNumber - 1];
            }
            return clockOutputFrequency;
        } 

        #endregion CLOCk:OUTput:FREQuency

        #region CLOCk:OUTput:STATe

        /// <summary>
        /// Property for CLOCk1:OUTPut:STATe
        /// </summary>
        readonly string[] _clockOutputState = new string[AwgMaxClocks];

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:OUTput:STATe to set the output state of the specified clock.
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Output state</param>
        public void SetClockOutputState(string clockNumber, string setValue)
        {
            _pi.SetAwgClockOutputState(clockNumber, setValue);
        }

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:OUTput:STATe? to get the output state of the specified clock.
        /// </summary>
        /// <param name="logicalClock">Which clock</param>
        /// <returns>Output state</returns>
        public void GetClockOutputState(string logicalClock)
        {
            int clockNumber = Convert.ToInt32(logicalClock);
            if (clockNumber <= AwgMaxClocks)
            {
                _clockOutputState[clockNumber - 1] = _pi.GetAwgClockOutputState(logicalClock);
            }
        }

        public string ClockOutputState(string logicalClock)
        {
            string clockOutputState = null;
            int clockNumber = Convert.ToInt32(logicalClock);
            if (clockNumber <= AwgMaxClocks)
            {
                clockOutputState = _clockOutputState[clockNumber - 1];
            }
            return clockOutputState;
        }

        #endregion CLOCk:OUTput:STATe

        #region CLOCk:PHASe:ADJust

        /// <summary>
        /// Response of CLOCk:PHASe:ADJust
        /// </summary>
        readonly string[] _clockPhaseAdjust = new string[AwgMaxClocks];

        /// <summary>
        /// Using CLOCk:PHASe:ADJust to set the internal clock phase adjustment of the AWG
        /// </summary>
        /// <param name="clockNumber"></param>
        /// <param name="setValue"></param>
        public void SetClockPhaseAdjust(string clockNumber, string setValue)
        {
            _pi.SetAwgClockPhaseAdjust(clockNumber, setValue);
        }

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:PHASe:ADJust? to get the internal clock phase adjustment of the AWG and<para> 
        /// update local copy and return a string version.</para>
        /// </summary>
        /// <param name="logicalClock"></param>
        /// <returns></returns>
        public void GetClockPhaseAdjust(string logicalClock)
        {
            int clockNumber = Convert.ToInt32(logicalClock);
            if (clockNumber <= AwgMaxClocks)
            {
                _clockPhaseAdjust[clockNumber - 1] = _pi.GetAwgClockPhaseAdjust(logicalClock);
            }
        }

        public string ClockPhaseAdjust(string logicalClock)
        {
            string clockPhaseAdjust = null;
            int clockNumber = Convert.ToInt32(logicalClock);
            if (clockNumber <= AwgMaxClocks)
            {
                clockPhaseAdjust = _clockPhaseAdjust[clockNumber - 1];
            }
            return clockPhaseAdjust;
        }

        #endregion CLOCk:PHASe:ADJust

        #region ClOCk:SOURce

        /// <summary>
        /// Property for Clock Source
        /// </summary>
        readonly string[] _clockSource = new string[AwgMaxClocks];

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:SOURce to set the source of the clock.
        /// </summary>
        /// <param name="clockNumber"></param>
        /// <param name="setValue"></param>
        public void SetClockSource(string clockNumber, string setValue)
        {
            _pi.SetAwgClockSource(clockNumber, setValue);
        }

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:SOURce? to get the source of the clock.
        /// </summary>
        /// <param name="logicalClock">One of the available clocks</param>
        public void GetClockSource(string logicalClock)
        {
            int clockNumber = Convert.ToInt32(logicalClock);
            if (clockNumber <= AwgMaxClocks)
            {
                _clockSource[clockNumber - 1] = _pi.GetAwgClockSource(logicalClock);
            }
        }

        public string ClockSource(string logicalClock)
        {
            string clockSource = null;
            int clockNumber = Convert.ToInt32(logicalClock);
            if (clockNumber <= AwgMaxClocks)
            {
                clockSource = _clockSource[clockNumber - 1];
            }
            return clockSource;
        }

        #endregion ClOCk:SOURce

        #region CLOCk:SOUT:STATe

        /// <summary>
        /// Copy of state from a CLOCk:SOUT:STATe query
        /// </summary>
        readonly string[] _clockSoutState = new string[AwgMaxClocks];

        //glennj 06/19/2013
        /// <summary>
        /// Using CLOCk:SOUT:STATe to set the state of the Sync Clock Out output
        /// </summary>
        /// <param name="clockNumber"></param>
        /// <param name="setValue"></param>
        public void SetClockSoutState(string clockNumber, string setValue)
        {
            _pi.SetAwgClockSoutState(clockNumber, setValue);
        }

        //glennj 06/19/2013
        /// <summary>
        /// Using CLOCk:SOUT:STATe? to get the state of the Sync Clock Out output
        /// </summary>
        /// <param name="logicalClock">One of the available clocks</param>
        public void GetAwgClockSoutState(string logicalClock)
        {
            int clockNumber = Convert.ToInt32(logicalClock);
            if (clockNumber <= AwgMaxClocks)
            {
                _clockSoutState[clockNumber - 1] = _pi.GetAwgClockSoutState(logicalClock);
            }
        }

        public string ClockSoutState(string logicalClock)
        {
            string clockSoutState = null;
            int clockNumber = Convert.ToInt32(logicalClock);
            if (clockNumber <= AwgMaxClocks)
            {
                clockSoutState = _clockSoutState[clockNumber - 1];
            }
            return clockSoutState;
        }

        #endregion CLOCk:SOUT:STATe

        #region CLOCk:SRATe

        readonly string[] _clockSampleRate = new string[AwgMaxClocks];

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:SRATe to set the sample rate for the given clock
        /// </summary>
        /// <param name="clockNumber">Which clock</param>
        /// <param name="setValue">Sample Rate</param>
        public void SetClockSRate(string clockNumber, string setValue)
        {
            _pi.SetAwgClockSRate(clockNumber, setValue);
        }

        //glennj 06/07/2013
        /// <summary>
        /// Using CLOCk:SRATe? the sample rate for the given clock, makes a copy<para>
        /// and returns the string</para>
        /// </summary>
        /// <param name="logicalClock">Which clock</param>
        /// <returns>Sample rate</returns>
        public void GetClockSRate(string logicalClock)
        {
            int clockNumber = Convert.ToInt32(logicalClock);
            if (clockNumber <= AwgMaxClocks)
            {
                _clockSampleRate[clockNumber - 1] = _pi.GetAwgClockSRate(logicalClock);
            }
        }

        public string ClockSampleRate(string logicalClock)
        {
            string clockSampleRate = null;
            int clockNumber = Convert.ToInt32(logicalClock);
            if (clockNumber <= AwgMaxClocks)
            {
                clockSampleRate = _clockSampleRate[clockNumber - 1];
            }
            return clockSampleRate;
        }

        #endregion CLOCk:STRATe
    }
}
