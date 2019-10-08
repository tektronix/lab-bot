//==========================================================================
// AwgStatusGroup.cs
//==========================================================================

using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains helper functions that are called from the %AWG Status PI step definitions.
    /// This class has no restrictions as to where it will be used.
    /// 
    /// This "Helper" group does everything else but steps and TekVISA.
    /// Using parameters from the step, each helper will makes decisions
    /// such as send commands, or process responses from queries and
    /// do testing and generate asserts if necessary.
    /// 
    /// \ingroup grouphelperpi pisteps 
    /// 
    /// </summary>
    public class AwgStatusGroup
    {
        /// <summary>
        /// Given an awg, and assumes that the option string has already been queried for,<para>
        /// test for the desired option.</para>
        /// </summary>
        /// <param name="awg">awg object</param>
        /// <param name="desiredOption"></param>
        /// <returns></returns>
        public bool AWGOptionFinder(IAWG awg, string desiredOption)
        {
            string[] optList = awg.OptionsImplemented.Split(',');
            foreach (string option in optList)
            {
                string temp = option.Trim('"'); //Get rid of irregular quotes from being a list 
                if (temp == desiredOption)         //Found the option failed the test
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Queries the awg for options
        /// </summary>
        /// <param name="awg"></param>
        public void GetOptions(IAWG awg) 
        {
            awg.GetOPT();       // Gets options saves in awg.options_implemented accessor
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="option"></param>
        public void OptionIsNotOnAWG(IAWG awg, string option)
        {
            if (string.IsNullOrWhiteSpace(awg.OptionsImplemented))
            {
                Assert.Inconclusive("No options were returned");
            }
            bool result = AWGOptionFinder(awg, option);
            if (result)
            {
                Assert.Inconclusive("Option found");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="option"></param>
        public void OptionIsOnAWG(IAWG awg, string option)
        {
            if (string.IsNullOrWhiteSpace(awg.OptionsImplemented))
            {
                Assert.Inconclusive("No options were returned");
            }
            bool result = AWGOptionFinder(awg, option);
            if (!result)
            {
                Assert.Inconclusive("Option was not found");
            }
        }

        /// <summary>
        /// Validate options string
        /// </summary>
        /// <param name="awg"></param>
        public void AWGShouldRespondWithValidOptionsString(IAWG awg)
        {
            //Changed by Kavitha to compare the AC string for AC instruments
            Regex idStringRegex = new Regex("\\d\\d,\\d\\d\\d,\\d\\d(,[A-Z][A-Z])?"); // So, the actual test is here, IF the id_string matched the regexp pattern then the m.Success property should be true
            Match m = idStringRegex.Match(awg.OptionsImplemented);  // Test the awg.options_implemented string against the regexp pattern
            Assert.IsTrue(m.Success);  
        }

        //glennj 06/06/2013
        /// <summary>
        /// Sets the value in the event status enable register to setValue variable
        /// </summary>
        /// <param name="awg">AWG object</param>
        /// <param name="setValue">Desired value for event status enable register</param>
        public void SetEventStatusEnableRegister(IAWG awg, string setValue)
        {
            awg.SetESE(setValue);
        }

        /// <summary>
        /// Forces the AWG to update the copy of event status enable register contents
        /// </summary>
        /// <param name="awg">AWG object</param>
        /// <returns>Desired value for event status enable register</returns>
        public void GetEventStatusEnableRegister(IAWG awg)
        {
            awg.GetESE();
        }

        /// <summary>
        /// Test the event status enable register
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expected_value"></param>
        public void EventStatusEnableRegisterShouldBe(IAWG awg, string expected_value)
        {
            Assert.AreEqual(expected_value, awg.EventStatusEnableReg);
        }

        //glennj 6/6/2013
        /// <summary>
        /// Sets the value in the Status Operation NTransition register
        /// </summary>
        /// <param name="awg">AWG object</param>
        /// <param name="setValue">The value to set</param>
        public void SetStatusOperationNTransitionRegister(IAWG awg, string setValue)
        {
            awg.SetStatusOperationNTransitionRegister(setValue);
        }

        /// <summary>
        /// Get the current Status Operation N Transistion Register and <para>
        /// update awg's copy</para>
        /// </summary>
        /// <param name="awg"></param>
        public void GetStatusOperationNTransitionRegister(IAWG awg)
        {
            awg.GetStatusOperationNTransitionRegister();
        }

        /// <summary>
        /// Compare Status Operation NTransition Register against expected
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expected_value"></param>
        public void StatusOperationNTransitionRegisterShouldBe(IAWG awg, string expected_value)
        {
            Assert.AreEqual(expected_value, awg.StatusOperationNtransitionReg);
        }

        /// <summary>
        /// Sets the value in the Status Operation PTransition register
        /// </summary>
        /// <param name="awg">AWG object</param>
        /// <param name="setValue">The value to set</param>
        public void SetStatusOperationPTransitionRegister(IAWG awg, string setValue)
        {
            awg.SetStatusOperationPTransitionRegister(setValue);
        }

        /// <summary>
        /// Get the current Status Operation PTransistion Register and <para>
        /// update awg's copy</para>
        /// </summary>
        /// <param name="awg"></param>
        public void GetStatusOperationPTransitionRegister(IAWG awg)
        {
            awg.GetStatusOperationPTransitionRegister();
        }

        /// <summary>
        /// Compare Status Operation PTransition Register against expected
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expected_value"></param>
        public void StatusOperationPTransitionRegisterShouldBe(IAWG awg, string expected_value)
        {
            Assert.AreEqual(expected_value, awg.StatusOperationPtransitionReg);
        }

        /// <summary>
        /// Sets the value in the Status Questionable Enable register
        /// </summary>
        /// <param name="awg">AWG object</param>
        /// <param name="setValue">The value to set</param>
        public void SetStatusQuestionableEnableRegister(IAWG awg, string setValue)
        {
            awg.SetStatusQuestionableEnableRegister(setValue);
        }

        /// <summary>
        /// Get the current Status Questionable Enable Register and <para>
        /// update awg's copy</para>
        /// </summary>
        /// <param name="awg"></param>
        public void GetStatusQuestionableEnableRegister(IAWG awg)
        {
            awg.GetStatusQuestionableEnableRegister();
        }

        /// <summary>
        /// Compare Status Questionable Enable Register against expected
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expected_value"></param>
        public void StatusQuestionableEnableRegisterShouldBe(IAWG awg, string expected_value)
        {
            Assert.AreEqual(expected_value, awg.StatusQuestionableEnableReg);
        }

        /// <summary>
        /// Sets the value in the Status Questionable NTransition register
        /// </summary>
        /// <param name="awg">AWG object</param>
        /// <param name="setValue">The value to set</param>
        public void SetStatusQuestionableNTransitionRegister(IAWG awg, string setValue)
        {
            awg.SetStatusQuestionableNTransitionRegister(setValue);
        }

        /// <summary>
        /// Get the current Status Questionable NTransition Register and <para>
        /// update awg's copy</para>
        /// </summary>
        /// <param name="awg">AWG object</param>
        public void GetStatusQuestionableNTransitionRegister(IAWG awg)
        {
            awg.GetStatusQuestionableNTransitionRegister();
        }

        /// <summary>
        /// Compare Status Questionable NTransition Register against expected
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expected_value"></param>
        public void StatusQuestionableNTransitionRegisterShouldBe(IAWG awg, string expected_value)
        {
            Assert.AreEqual(expected_value, awg.StatusQuestionableNtransitionReg);
        }

        /// <summary>
        /// Sets the value in the Status Questionable PTransition register
        /// </summary>
        /// <param name="awg">AWG object</param>
        /// <param name="setValue">The value to set</param>
        public void SetStatusQuestionablePTransitionRegister(IAWG awg, string setValue)
        {
            awg.SetStatusQuestionablePTransitionRegister(setValue);
        }

        /// <summary>
        /// Get the current Status Questionable PTransition Register and <para>
        /// update awg's copy</para>
        /// </summary>
        /// <param name="awg">AWG object</param>
        public void GetStatusQuestionablePTransitionRegister(IAWG awg)
        {
            awg.GetStatusQuestionablePTransitionRegister();
        }

        /// <summary>
        /// Compare Status Questionable PTransition Register against expected
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expected_value"></param>
        public void StatusQuestionablePTransitionRegisterShouldBe(IAWG awg, string expected_value)
        {
            Assert.AreEqual(expected_value, awg.StatusQuestionablePtransitionReg);
        }

        /// <summary>
        /// Get the current Event Status Enable Register and <para>
        /// update awg's copy</para>
        /// </summary>
        /// <param name="awg">AWG object</param>
        public void GetStandardEventStatusRegister(IAWG awg)
        {
            awg.GetESR();
        }

        /// <summary>
        /// Compare Event Status Enable Register against expected
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expected_value"></param>
        public void StandardEventStatusRegisterShouldBe(IAWG awg, string expected_value)
        {
            Assert.AreEqual(expected_value, awg.StandardEventStatusReg);
        }

        /// <summary>
        /// After getting and updating the awg copy it compares the<para>
        /// copy of the Event Status Enable Register against expected</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expected_value"></param>
        public void StandardEventStatusRegisterShouldReturnValue(IAWG awg, string expected_value)
        {
            awg.GetESR();     // Gets and saves register value in awg.standard_event_status_reg
            Assert.AreEqual(expected_value, awg.StandardEventStatusReg);
        }

        /// <summary>
        /// Sets the Service Request Enable register
        /// </summary>
        /// <param name="awg">AWG object</param>
        public void SetServiceRequestEnableRegister(IAWG awg, string setValue)
        {
            awg.SetSRE(setValue);
        }

        /// <summary>
        /// Get the current Service Request Enable Register and <para>
        /// update awg's copy</para>
        /// </summary>
        /// <param name="awg">AWG object</param>
        public void GetServiceRequestEnableRegister(IAWG awg)
        {
            awg.GetSRE();
        }

        /// <summary>
        /// Compare Service Request Enable Register against expected
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expected_value"></param>
        public void ServiceRequestEnableRegisterShouldBe(IAWG awg, string expected_value)
        {
            Assert.AreEqual(expected_value, awg.ServiceEnableReg);
        }

        /// <summary>
        /// After getting and updating the awg copy it compares the<para>
        /// copy of the Service Request Enable Register against expected</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expected_value"></param>
        public void ServiceRequestEnableRegisterShouldReturnValue(IAWG awg, string expected_value)
        {
            GetServiceRequestEnableRegister(awg);
            Assert.AreEqual(expected_value, awg.ServiceEnableReg);
        }

        /// <summary>
        /// Get the current Status Byte Register and <para>
        /// update awg's copy</para>
        /// </summary>
        /// <param name="awg">AWG object</param>
        public void GetStatusByteRegister(IAWG awg)
        {
            awg.GetSTB();
        }

        /// <summary>
        /// Compare Status Byte Register against expected
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expected_value"></param>
        public void StatusByteRegisterShouldBe(IAWG awg, string expected_value)
        {
            Assert.AreEqual(expected_value, awg.StatusByteReg);
        }

        /// <summary>
        /// After getting and updating the awg copy it compares the<para>
        /// copy of the Status Byte Register against expected</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expected_value"></param>
        public void StatusByteRegisterShouldReturnValue(IAWG awg, string expected_value)
        {
            GetStatusByteRegister(awg);
            Assert.AreEqual(expected_value, awg.StatusByteReg);
        }

        /// <summary>
        /// Get the current Status Operation Condition Register and <para>
        /// update awg's copy</para>
        /// </summary>
        /// <param name="awg">AWG object</param>
        public void GetOperationConditionRegister(IAWG awg)
        {
            awg.GetOperationConditionRegister();
        }

        /// <summary>
        /// Sets the mask of the Operation Enable Register
        /// </summary>
        /// <param name="awg">AWG object</param>
        /// <param name="setValue">Operation Enable Register Mask</param>
        public void SetMaskOperationEnableRegister(IAWG awg, string setValue)
        {
            awg.SetMaskOperationEnableRegister(setValue);
        }

        /// <summary>
        /// Get the current  mask for the Operation Enable Register (OENR) and <para>
        /// update awg's copy</para>
        /// </summary>
        /// <param name="awg">AWG object</param>
        public void GetMaskOperationEnableRegister(IAWG awg)
        {
            awg.GetMaskOperationEnableRegister();
        }

        /// <summary>
        /// Compare Operation Enable Register against expected
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expected_value"></param>
        public void MaskOperationEnableRegisterShouldBe(IAWG awg, string expected_value)
        {
            Assert.AreEqual(expected_value, awg.OperationEnableReg);
        }

        /// <summary>
        /// Get the current Operation Event Register and <para>
        /// update awg's copy</para>
        /// </summary>
        /// <param name="awg">AWG object</param>
        public void GetOperationEventRegister(IAWG awg)
        {
            awg.GetOperationEventRegister();
        }

        /// <summary>
        /// After getting and updating the awg copy it compares the<para>
        /// copy of the Operation Event Register against expected</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expected_value"></param>
        public void OperationEventRegisterShouldReturnValue(IAWG awg, string expected_value)
        {
            GetOperationEventRegister(awg);
            Assert.AreEqual(expected_value, awg.OperationEventReg);
        }

        /// <summary>
        /// This resets the OENR and QENR registers.
        /// </summary>
        /// <param name="awg">AWG object</param>
        public void PresetOENRAndQENRRegisters(IAWG awg)
        {
            awg.ResetOENRAndQENRRegisters();
        }

        /// <summary>
        /// Verifies that there are no errors in the status byte
        /// </summary>
        /// <param name="awg"></param>
        public void VerifyEntriesInErrorQueue(IAWG awg)
        {
            GetStatusByteRegister(awg);
            Assert.AreNotEqual(awg.StatusByteReg, "0");
        }

        // Unkown 01/01/01
        /// <summary>
        /// Verifies there are errors in the error queue
        /// </summary>
        /// <param name="awg">AWG object</param>
        /// <returns>if there are errors in the error queue</returns>
        public string AwgVerifyErrorsInQueue(IAWG awg)
        {
            return awg.GetSTB();
        }

        /// <summary>
        /// For the given AWG, clear any errors in the system error queue.
        /// </summary>
        /// <param name="awg">AWG object</param>
        public void AwgClearErrorQueue(IAWG awg)
        {
            awg.ClearErrors();
        }
    }
}

