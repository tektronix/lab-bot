//==========================================================================
// AwgGPIBUSBGroupGroup.cs
//==========================================================================
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains helper functions that are called from the %AWG GPIB USB PI step definitions.
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
    public class AwgGPIBUSBGroup
    {
        readonly UTILS _utils = new UTILS();

        #region GPIBUSB Address

        public void SetGPIBUSBAddress(IAWG awg, int address)
        {
            awg.SetGPIBUsbAddress(address);
        }

        public void GetGPIBUSBAddress(IAWG awg)
        {
            awg.GetGPIBUsbAddress();
        }

        public void GPIBUSBAddressShouldBe(IAWG awg, string expectedAddress)
        {
            Assert.AreEqual(expectedAddress, awg.GPIBUsbAddress);
        }

        #endregion GPIBUSB Address

        #region GPIBUSB HW Version

        public void SetGPIBUSBHwVersion(IAWG awg, string hwVersion)
        {
            awg.SetGPIBUsbHwVersion(hwVersion);
        }

        public void GetGPIBUSBHwVersion(IAWG awg)
        {
            awg.GetGPIBUsbHwVersion();
        }

        public void GPIBUSBHwVersionShouldBe(IAWG awg, string expectedHwVersion)
        {
            Assert.AreEqual(_utils.Quotify(expectedHwVersion), awg.GPIBUsbHwversion);
        }

        #endregion GPIBUSB HW Version

        #region GPIBUSB Id

        public void SetGPIBUSBId(IAWG awg, string setId)
        {
            awg.SetGPIBUsbId(setId);
        }

        public void GetGPIBUSBId(IAWG awg)
        {
            awg.GetGPIBUsbId();
        }

        public void GPIBUSBIdShouldBe(IAWG awg, string expectedId)
        {
            Assert.AreEqual(_utils.Quotify(expectedId), awg.GPIBUsbId);
        }

        #endregion GPIBUSB Id

        #region GPIBUSB Status

        public void SetGPIBUSBStatus(IAWG awg, string status)
        {
            awg.SetGpibUsbStatus(status);
        }

        public void GetGPIBUSBStatus(IAWG awg)
        {
            awg.GetGpibUsbStatus();
        }

        public void GPIBUSBStatusShouldBe(IAWG awg, string expectedStatus)
        {
            Assert.AreEqual(_utils.Quotify(expectedStatus), awg.GPIBUsbStatus);
        }

        #endregion GPIBUSB Status
    }
}