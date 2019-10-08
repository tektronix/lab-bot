
namespace AwgTestFramework
{
    public partial class CPi70KCmds
    {

        // glennj 06/03/2013
        /// <summary>
        /// Clears all the errors in the error queue on this AWG
        /// </summary>
        public void AwgCLS()
        {
            const string commandLine = "*CLS";
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 06/05/2013
        /// <summary>
        /// Sets the bits in the Service Request Enable Register
        /// </summary>
        /// <param name="setValue"></param>
        public void SetAwgSRE(string setValue)
        {
            const string commandLine = "*SRE ";
            _mAWGVisaSession.Write(commandLine + setValue);
        }

        //glennj 06/05/2013
        /// <summary> 
        /// Sets the status of the Event Status Enable Register
        /// </summary>
        /// <param name="setValue"></param>
        public void SetAwgESE(string setValue)
        {
            const string commandLine = "*ESE ";
            _mAWGVisaSession.Write(commandLine + setValue);
        }

        // glennj 06/18/2013
        /// <summary>
        /// Queries and returns the value in the Event Status Enable Register
        /// </summary>
        /// <returns>Current value for Event Status Enable Register</returns>
        public string GetAwgESE()
        {
            string response;
            const string commandLine = "*ESE?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
         
        // glennj 06/03/2013
        /// <summary>
        /// Queries and returns the value in the Standard Event Status Register
        /// </summary>
        /// <returns>Current value for Standard Event Status Register</returns>
        public string GetAwgESR()
        {
            string response;
            const string commandLine = "*ESR?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        // glennj 06/03/2013
        /// <summary>
        /// Gets the bits in the Service Request Enable Register
        /// </summary>
        /// <returns>Current value for Standard Event Status Register</returns>
        public string GetAwgSRE()
        {
            string response;
            const string commandLine = "*SRE?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        // glennj 06/05/2013
        /// <summary>
        /// Gets the contents of the Status Byte Register
        /// </summary>
        /// <returns>Current value for Standard Event Status Register</returns>
        public string GetAwgSTB()
        {
            string response;
            const string commandLine = "*STB?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        /// <summary>
        /// Returns the contents of the Operation Condition register (OCR)
        /// </summary>
        /// <returns></returns>
        public string GetAwgOperationConditionRegister()
        {
            string response;
            const string commandLine = "STATus:OPERation:CONDition?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        //glennj 06/05/2013
        /// <summary>
        /// Sets the the mask for the Operation Enable Register (OENR)
        /// </summary>
        /// <param name="setValue"></param>
        public void SetAwgMaskOperationEnableRegister(string setValue)
        {
            const string commandLine = "STATus:OPERation:ENABle ";
            _mAWGVisaSession.Write(commandLine + setValue);
        }

        //glennj 06/05/2013
        /// <summary>
        /// Gets the the mask for the Operation Enable Register (OENR)
        /// </summary>
        /// <returns>Current value for OENR</returns>
        public string GetAwgMaskOperationEnableRegister()
        {
            string response;
            const string commandLine = "STATus:OPERation:ENABle?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        //glennj 06/05/2013
        /// <summary>
        /// Queries and returns the contents of the Operation Event Register. (OEVR)
        /// </summary>
        /// <returns>Operation Event Register</returns>
        public string GetAwgOperationEventRegister()
        {
            string response;
            const string commandLine = "STATus:OPERation:EVENt?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        //PHunter 01/08/2013
        /// <summary>
        /// Sets the value in the Status Operation NTransition register
        /// </summary>
        /// <param name="setValue">The value to set</param>
        public void SetAwgStatusOperationNTransitionRegister(string setValue)
        {
            const string commandLine = "STATus:OPERation:NTRansition ";
            _mAWGVisaSession.Write(commandLine + setValue);
        }

        //PHunter 01/08/2013
        /// <summary>
        /// Queries and returns the value in the Status Operation NTransition register
        /// </summary>
        /// <returns>Current value for Status Operation NTransition Register</returns>
        public string GetAwgStatusOperationNTransitionRegister()
        {
            string response;
            const string commandLine = "STATus:OPERation:NTRansition?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        //PHunter 01/08/2013
        /// <summary>
        /// Sets the value in the Status Operation PTransition register
        /// </summary>
        /// <param name="setValue">The value to set</param>
        public void SetAwgStatusOperationPTransitionRegister(string setValue)
        {
            const string commandLine = "STATus:OPERation:PTRansition ";
            _mAWGVisaSession.Write(commandLine + setValue);
        }

        //PHunter 01/08/2013
        /// <summary>
        /// Queries and returns the value in the Status Operation PTransition register
        /// </summary>
        /// <returns>Current value for Status Operation PTransition Register</returns>
        public string GetAwgStatusOperationPTransitionRegister()
        {
            string response;
            const string commandLine = "STATus:OPERation:PTRansition?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        // Unknown 01/01/01
        /// <summary>
        /// This command resets the OENR and QENR registers.
        /// </summary>
        public void AwgResetOENRAndQENRRegisters()
        {
            const string commandLine = "STATus:PRESet";
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 06/06/2013
        /// <summary>
        /// Queries and returns the value in the Status Questionable Condition register
        /// </summary>
        /// <returns>Current value for Status Questionable Condition Register</returns>
        public string GetAwgStatusQuestionableConditionRegister()
        {
            string response;
            const string commandLine = "STATus:QUEStionable:CONDition?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        //PHunter 01/07/2013
        //glennj 06/06/2013
        /// <summary>
        /// Sets the value in the Status Questionable Enable register
        /// </summary>
        /// <param name="setValue">The value to set</param>
        public void SetAwgStatusQuestionableEnableRegister(string setValue)
        {
            const string commandLine = "STATus:QUEStionable:ENABle ";
            _mAWGVisaSession.Write(commandLine + setValue);
        }

        //PHunter 01/07/2013
        //glennj 06/06/2013
        /// <summary>
        /// Queries and returns the value in the Status Questionable Enable register
        /// </summary>
        /// <returns>Current value for Status Questionable Enable Register</returns>
        public string GetAwgStatusQuestionableEnableRegister()
        {
            string response;
            const string commandLine = "STATus:QUEStionable:ENABle?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        //glennj 06/06/2013
        /// <summary>
        /// Queries and returns the value in the Status Questionable Event register (QEVR)
        /// </summary>
        /// <returns>Current value for Status Questionable Event Register</returns>
        public string GetAwgStatusQuestionableEventRegister()
        {
            string response;
            const string commandLine = "STATus:QUEStionable:EVENt?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        //PHunter 01/08/2013
        //glennj 06/06/2013
        /// <summary>
        /// Sets the value in the Status Questionable NTransition register
        /// </summary>
        /// <param name="setValue">The value to set</param>
        public void SetAwgStatusQuestionableNTransitionRegister(string setValue)
        {
            const string commandLine = "STATus:QUEStionable:NTRansition ";
            _mAWGVisaSession.Write(commandLine + setValue);
        }

        //PHunter 01/08/2013
        //glennj 06/06/2013
        /// <summary>
        /// Queries and returns the value in the Status Questionable NTransition register
        /// </summary>
        /// <returns>Current value for Status Questionable NTransition Register</returns>
        public string GetAwgStatusQuestionableNTransitionRegister()
        {
            string response;
            const string commandLine = "STATus:QUEStionable:NTRansition?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        //PHunter 01/08/2013
        //glennj 06/06/2013
        /// <summary>
        /// Sets the value in the Status Questionable PTransition register
        /// </summary>
        /// <param name="setValue">The value to set</param>
        public void SetAwgStatusQuestionablePTransitionRegister(string setValue)
        {
            const string commandLine = "STATus:QUEStionable:PTRansition ";
            _mAWGVisaSession.Write(commandLine + setValue);
        }

        //PHunter 01/08/2013
        //glennj 06/06/2013
        /// <summary>
        /// Queries and returns the value in the Status Questionable PTransition register
        /// </summary>
        /// <returns>Current value for Status Questionable PTransition Register</returns>
        public string GetAwgStatusQuestionablePTransitionRegister()
        {
            string response;
            const string commandLine = "STATus:QUEStionable:PTRansition?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
    }
}
