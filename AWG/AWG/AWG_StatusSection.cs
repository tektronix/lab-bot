
namespace AwgTestFramework
{
    public partial class AWG
    {

        public string EventStatusEnableReg { get; set; }

        /// <summary>
        /// Operation Enable Register (OENR)
        /// </summary>
        public string OperationEnableReg { get; set; }

        /// <summary>
        /// Operation Event Register (OEVR)
        /// </summary>
        public string OperationEventReg { get; set; }

        /// <summary>
        /// Implemented options
        /// </summary>
        public string OptionsImplemented { get; set; }

        /// <summary>
        /// Service Request Enable register
        /// </summary>
        public string ServiceEnableReg { get; set; }

        public string StandardEventStatusReg { get; set; }

        /// <summary>
        /// Status Byte register (SBR)
        /// </summary>
        public string StatusByteReg { get; set; }

        /// <summary>
        /// Operation Condition register (OCR)
        /// </summary>
        public string StatusOperationConditionReg { get; set; }

        /// <summary>
        /// Negative Operation Transition Register
        /// </summary>
        public string StatusOperationNtransitionReg { get; set; }

        /// <summary>
        /// Positive Operation Transition Register
        /// </summary>
        public string StatusOperationPtransitionReg { get; set; }

        /// <summary>
        /// Questionable Condition Register (QCR)
        /// </summary>
        public string StatusQuestionableConditionReg { get; set; }

        /// <summary>
        /// Enable mask for the Questionable Enable Register (QENR)
        /// </summary>
        public string StatusQuestionableEnableReg { get; set; }

        /// <summary>
        /// Questionable Event Register (QEVR)
        /// </summary>
        public string StatusQuestionableEventReg { get; set; }

        /// <summary>
        /// Negative transition filter value of the Questionable Transition Register (QTR)
        /// </summary>
        public string StatusQuestionableNtransitionReg { get; set; }

        /// <summary>
        /// Positive transition filter value of the Questionable Transition Register (QTR)
        /// </summary>
        public string StatusQuestionablePtransitionReg { get; set; }




        public void ClearErrors()
        {
            _pi.AwgCLS();
        }

        /// <summary>
        /// Sets the Event Status Enable Register
        /// </summary>
        /// <param name="setValue"></param>
        public void SetESE(string setValue)
        {
            _pi.SetAwgESE(setValue);
        }

        // glennj 06/18/2013
        /// <summary>
        /// Queries and returns the value in the Event Status Enable Register
        /// </summary>
        /// <returns>Current value for Event Status Enable Register</returns>
        public void GetESE()
        {
            EventStatusEnableReg = _pi.GetAwgESE();
        }

        /// <summary>
        /// Gets the status of the Event Status Enable Register
        /// </summary>
        public string GetESR()
        {
            StandardEventStatusReg = _pi.GetAwgESR();
            return StandardEventStatusReg;
        }

        /// <summary>
        /// Sets the bits in the Service Request Enable Register
        /// </summary>
        /// <param name="setValue"></param>
        public void SetSRE(string setValue)
        {
            _pi.SetAwgSRE(setValue);
        }

        /// <summary>
        /// Gets the bits in the Service Request Enable Register
        /// </summary>
        public string GetSRE()
        {
            ServiceEnableReg = _pi.GetAwgSRE();
            return ServiceEnableReg;
        }

        /// <summary>
        /// Gets the contents of the Status Byte Register<para>
        /// </para>
        /// </summary>
        /// <returns>Current value for Status Byte Register</returns>
        public string GetSTB()
        {
            StatusByteReg = _pi.GetAwgSTB();
            return StatusByteReg;
        }

        /// <summary>
        /// Returns the contents of the Operation Condition register (OCR)
        /// </summary>
        /// <returns></returns>
        public string GetOperationConditionRegister()
        {
            StatusOperationConditionReg = _pi.GetAwgOperationConditionRegister();
            return StatusOperationConditionReg;
        }

        /// <summary>
        /// Sets the the mask for the Operation Enable Register (OENR)
        /// </summary>
        /// <param name="setValue"></param>
        public void SetMaskOperationEnableRegister(string setValue)
        {
            _pi.SetAwgMaskOperationEnableRegister(setValue);
        }

        /// <summary>
        /// Gets the the mask for the Operation Enable Register (OENR)
        /// </summary>
        /// <returns>Current value for OENR</returns>
        public string GetMaskOperationEnableRegister()
        {
            OperationEnableReg = _pi.GetAwgMaskOperationEnableRegister();
            return OperationEnableReg;
        }

        /// <summary>
        /// Queries and returns the contents of the Operation Event Register. (OEVR)
        /// </summary>
        /// <returns>Operation Event Register</returns>
        public string GetOperationEventRegister()
        {
            OperationEventReg = _pi.GetAwgOperationEventRegister();
            return OperationEventReg;
        }

        /// <summary>
        /// Sets the value in the Status Operation NTransition register
        /// </summary>
        /// <param name="setValue">The value to set</param>
        public void SetStatusOperationNTransitionRegister(string setValue)
        {
            _pi.SetAwgStatusOperationNTransitionRegister(setValue);
        }

        /// <summary>
        /// Queries and returns the value in the Status Operation NTransition register
        /// </summary>
        /// <returns>Current value for Status Operation NTransition Register</returns>
        public string GetStatusOperationNTransitionRegister()
        {
            StatusOperationNtransitionReg = _pi.GetAwgStatusOperationNTransitionRegister();
            return StatusOperationNtransitionReg;
        }

        /// <summary>
        /// Sets the value in the Status Operation PTransition register
        /// </summary>
        /// <param name="setValue">The value to set</param>
        public void SetStatusOperationPTransitionRegister(string setValue)
        {
            _pi.SetAwgStatusOperationPTransitionRegister(setValue);
        }

        /// <summary>
        /// Queries and returns the value in the Status Operation PTransition register
        /// </summary>
        /// <returns>Current value for Status Operation PTransition Register</returns>
        public string GetStatusOperationPTransitionRegister()
        {
            StatusOperationPtransitionReg = _pi.GetAwgStatusOperationPTransitionRegister();
            return StatusOperationPtransitionReg;
        }

        /// <summary>
        /// This command resets the OENR and QENR registers.
        /// </summary>
        public void ResetOENRAndQENRRegisters()
        {
            _pi.AwgResetOENRAndQENRRegisters();
        }

        //glennj 06/06/2013
        /// <summary>
        /// Queries and returns the value in the Status Questionable Condition register
        /// </summary>
        /// <returns>Current value for Status Questionable Condition Register</returns>
        public string GetStatusQuestionableConditionRegister()
        {
            StatusQuestionableConditionReg = _pi.GetAwgStatusQuestionableConditionRegister();
            return StatusQuestionableConditionReg;
        }

        //glennj 06/06/2013
        /// <summary>
        /// Sets the value in the Status Questionable Enable register
        /// </summary>
        /// <param name="setValue">The value to set</param>
        public void SetStatusQuestionableEnableRegister(string setValue)
        {
            _pi.SetAwgStatusQuestionableEnableRegister(setValue);
        }

        //glennj 06/06/2013
        /// <summary>
        /// Queries and returns the value in the Status Questionable Enable register
        /// </summary>
        /// <returns>Current value for Status Questionable Enable Register</returns>
        public string GetStatusQuestionableEnableRegister()
        {
            StatusQuestionableEnableReg = _pi.GetAwgStatusQuestionableEnableRegister();
            return StatusQuestionableEnableReg;
        }

        //glennj 06/06/2013
        /// <summary>
        /// Queries and returns the value in the Status Questionable Event register (QEVR)
        /// </summary>
        /// <returns>Current value for Status Questionable Event Register</returns>
        public string GetStatusQuestionableEventRegister()
        {
            StatusQuestionableEventReg = _pi.GetAwgStatusQuestionableEventRegister();
            return StatusQuestionableEventReg;
        }

        //glennj 06/06/2013
        /// <summary>
        /// Sets the value in the Status Questionable NTransition register
        /// </summary>
        /// <param name="setValue">The value to set</param>
        public void SetStatusQuestionableNTransitionRegister(string setValue)
        {
            _pi.SetAwgStatusQuestionableNTransitionRegister(setValue);
        }

        //glennj 06/06/2013
        /// <summary>
        /// Queries and returns the value in the Status Questionable NTransition register
        /// </summary>
        /// <returns>Current value for Status Questionable NTransition Register</returns>
        public string GetStatusQuestionableNTransitionRegister()
        {
            StatusQuestionableNtransitionReg = _pi.GetAwgStatusQuestionableNTransitionRegister();
            return StatusQuestionableNtransitionReg;
        }

        //glennj 06/06/2013
        /// <summary>
        /// Sets the value in the Status Questionable PTransition register
        /// </summary>
        /// <param name="setValue">The value to set</param>
        public void SetStatusQuestionablePTransitionRegister(string setValue)
        {
            _pi.SetAwgStatusQuestionablePTransitionRegister(setValue);
        }

        //glennj 06/06/2013
        /// <summary>
        /// Queries and returns the value in the Status Questionable PTransition register
        /// </summary>
        /// <returns>Current value for Status Questionable PTransition Register</returns>
        public string GetStatusQuestionablePTransitionRegister()
        {
            StatusQuestionablePtransitionReg = _pi.GetAwgStatusQuestionablePTransitionRegister();
            return StatusQuestionablePtransitionReg;
        }

    }
}
