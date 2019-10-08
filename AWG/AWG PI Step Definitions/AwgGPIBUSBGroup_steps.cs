//==========================================================================
// AwgGPIBUSBGroup_steps.cs
// This file contains the step definitions for the AWGControl Group PI commands. 
//
// Low-level steps set and get the values for commands, and test the raw values as returned from the 
// instrument. They DO NOT interpret values in any way! Interpretation, normalization, etc. need to 
// occur in the High-level step definitions. Notice the use of the word "value" in the steps - this 
// usually implies that the query returns a 0 or 1 or abbreviated text value (like SOFT) that should 
// be interpreted as ON or OFF or SOFTWARE to make the step more user-friendly. We do that in the 
// High-order step definitions.
// 
// PLEASE use the following regular expressions to match specified numeric formats and other values:
// <NR1> - ((?<!\S)[-+]?\d+(?!\S))
// <NR3> - ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?)
// AWG number -  AWG([1-4])? -OR -
//            -  (?: the)? AWG([1-4])? (depends on language usage)
// File path strings - ""(.+)"" used when you want the string that is delimited by the quotes File path strings
//                        
//==========================================================================

using TechTalk.SpecFlow;

namespace AwgTestFramework
{
    ///<summary>
    /// This class contains the PI step definitions for the %AWG PI GPIBUSB Group commands.

    /// Generally the steps are set, get and should be operations.  The step sole responsibility
    /// is to make sure the correct %AWG object is used and that parameters such as channel,
    /// markers and clock references are correct for the %AWG object.
    /// 
    /// \ingroup highpi pisteps 
    ///
    /// </summary>
    [Binding] //Very important! This entry needs to be made in each step definition file.
    public class AwgGPIBUSBSteps
    {
        private readonly AwgGPIBUSBGroup _awgGPIBUSBGroup = new AwgGPIBUSBGroup();

        #region GPIBUSB Address

        // glennj 7/23/2013
        /// <summary>
        /// Sets the address of the GPIB adapter device
        /// 
        /// GPIBUsb:SETADDress
        /// </summary>
        /// <param name="address">Address of the GPIB adapter device</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
           \gpib\verbatim
        [When(@"I set the GPIB address to ([1-9]|[1-3][0-9]) for AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I set the GPIB address to ([1-9]|[1-3][0-9]) for AWG ([1-4])")]
        public void SetGPIBUSBAddress(int address, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgGPIBUSBGroup.SetGPIBUSBAddress(awg, address);
        }

        // glennj 7/23/2013
        /// <summary>
        /// Gets the address of the GPIB adapter device
        /// 
        /// GPIBUsb:SETADDress
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
           \gpib\verbatim
        [When(@"I get the GPIB address for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I get the GPIB address for AWG ([1-4])")]
        public void GetGPIBUsbAddress(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgGPIBUSBGroup.GetGPIBUSBAddress(awg);
        }

        // glennj 7/23/2013
        /// <summary>
        /// Compares the address of the GPIB adapter device against the expected value.
        /// 
        /// GPIBUsb:SETADDress
        /// </summary>
        /// <param name="expectedAddress">Address of the GPIB adapter device</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
           \gpib\verbatim
        [Then(@"the GPIB address should be (.*) for AWG ([1-4])")]
           \endverbatim 
       */
        [Then(@"the GPIB address should be (.*) for AWG ([1-4])")]
        public void TheGPIBAddressShouldMatchGivenAddress(string expectedAddress, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgGPIBUSBGroup.GPIBUSBAddressShouldBe(awg, expectedAddress);
        }

        #endregion GPIBUSB Address

        #region GPIBUSB HW Version

        // glennj 7/23/2013
        /// <summary>
        /// Sets the hardware version of the GPIB adapter device
        /// 
        /// GPIBUsb:HWVersion
        /// </summary>
        /// <param name="hwVersion">Hardware version of the GPIB adapter device</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
           \gpib\verbatim
        [When(@"I set the GPIB hardware version to (.*) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the GPIB hardware version to (.*) for AWG ([1-4])")]
        public void SetGPIBUsbHwVersion(string hwVersion, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgGPIBUSBGroup.SetGPIBUSBHwVersion(awg, hwVersion);
        }

        // glennj 7/23/2013
        /// <summary>
        /// Gets the hardware version of the GPIB adapter device
        /// 
        /// GPIBUsb:HWVersion
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
           \gpib\verbatim
        [When(@"I get the GPIB hardware version for AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I get the GPIB hardware version for AWG ([1-4])")]
        public void GetGPIBUSBHwVersion(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgGPIBUSBGroup.GetGPIBUSBHwVersion(awg);
        }

        // glennj 7/23/2013
        /// <summary>
        /// Compares the hardware version of the GPIB adapter device against the expected value.
        /// 
        /// GPIBUsb:HWVersion  
        /// </summary>
        /// <param name="hwVersion">Hardware version of the GPIB adapter device</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
           \gpib\verbatim
        [Then(@"the GPIB hardware version should be (.*) for AWG ([1-4])")]
           \endverbatim 
       */
        [Then(@"the GPIB hardware version should be (.*) for AWG ([1-4])")]
        public void GPIBHWVersionShouldMatchGivenHWVersion(string hwVersion, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgGPIBUSBGroup.GPIBUSBHwVersionShouldBe(awg, hwVersion);
        }

        #endregion GPIBUSB HW Version

        #region GPIBUSB Id

        // glennj 7/23/2013
        /// <summary>
        /// Sets the ID of the GPIB adapter device
        /// 
        /// GPIBUsb:SETID
        /// </summary>
        /// <param name="setId">ID of the GPIB adapter device</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
           \gpib\verbatim
        [When(@"I set the GPIB id to (.*) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the GPIB id to (.*) for AWG ([1-4])")]
        public void SetGPIBUsbId(string setId, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgGPIBUSBGroup.SetGPIBUSBId(awg, setId);
        }

        // glennj 7/23/2013
        /// <summary>
        /// Gets the ID of the GPIB adapter device
        /// 
        /// GPIBUsb:SETID
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
           \gpib\verbatim
        [When(@"I get the GPIB id for AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I get the GPIB id for AWG ([1-4])")]
        public void GetGPIBUsbId(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgGPIBUSBGroup.GetGPIBUSBId(awg);
        }

        // glennj 7/23/2013
        /// <summary>
        /// Compares the ID of the GPIB adapter device against the expected value.
        /// 
        /// GPIBUsb:SETID 
        /// </summary>
        /// <param name="expectedId">ID of the GPIB adapter device</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
           \gpib\verbatim
        [Then(@"the GPIB id should be (.*) for AWG ([1-4])")]
           \endverbatim 
        */
        [Then(@"the GPIB id should be (.*) for AWG ([1-4])")]
        public void TheGpibidShouldMatchGivenId(string expectedId, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgGPIBUSBGroup.GPIBUSBIdShouldBe(awg, expectedId);
        }

        #endregion GPIBUSB Id

        #region GPIBUSB Status

        // glennj 7/23/2013
        /// <summary>
        /// Sets the status of the GPIB adapter device
        /// 
        /// GPIBUsb:STATus
        /// </summary>
        /// <param name="status">Status of the GPIB adapter device</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
           \gpib\verbatim
        [When(@"I set the GPIB status to (.*) for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I set the GPIB status to (.*) for AWG ([1-4])")]
        public void SetGPIBUsbStatus(string status, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgGPIBUSBGroup.SetGPIBUSBStatus(awg, status);
        }

        // glennj 7/23/2013
        /// <summary>
        /// Gets the status of the GPIB adapter device
        /// 
        /// GPIBUsb:STATus
        /// </summary>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
           \gpib\verbatim
        [When(@"I get the GPIB status for AWG ([1-4])")]
           \endverbatim 
       */
        [When(@"I get the GPIB status for AWG ([1-4])")]
        public void GetGPIBUsbStatus(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgGPIBUSBGroup.GetGPIBUSBStatus(awg);
        }

        // glennj 7/23/2013
        /// <summary>
        /// Compares the status of the GPIB adapter device against the expected value. 
        /// 
        /// GPIBUsb:STATus 
        /// </summary>
        /// <param name="expectedStatus">Status of the GPIB adapter device</param>
        /// <param name="awgNumber">Which %AWG machine number</param>
        /*!
           \gpib\verbatim
        [Then(@"the GPIB status should be (.*) for AWG ([1-4])")]
           \endverbatim 
       */
        [Then(@"the GPIB status should be (.*) for AWG ([1-4])")]
        public void TheGPIBStatusShouldMatchGivenStatus(string expectedStatus, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgGPIBUSBGroup.GPIBUSBStatusShouldBe(awg, expectedStatus);
        }
        #endregion GPIBUSB Status
    }
}