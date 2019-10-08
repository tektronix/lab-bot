

namespace AwgTestFramework
{
    public partial class AWG
    {

        public string GPIBUsbStatus { get; set; }
        public string GPIBUsbHwversion { get; set; }
        public string GPIBUsbId { get; set; }
        public string GPIBUsbAddress { get; set; }



        // glennj 7/23/2013
        /// <summary>
        /// Using GPIBUsb:SETADDress set the address of the GPIB adapter device<para>
        /// Note: Set command differs from Query, uses SETADDress instead of ADDress@n</para>
        /// </summary>
        /// <param name="address">Address of the GPIB adapter device</param>
        public void SetGPIBUsbAddress(int address)
        {
            _pi.SetAwgGPIBUsbAddress(address);
        }

        // glennj 7/23/2013
        /// <summary>
        /// Using GPIBUsb:ADDress? update the property for the address of the GPIB adapter device
        /// </summary>
        /// <returns></returns>
        public void GetGPIBUsbAddress()
        {
            GPIBUsbAddress = _pi.GetAwgGPIBUsbAddress();
        }

        // glennj 7/23/2013
        /// <summary>
        /// Using GPIBUsb:HWVersion set the hardware version of the GPIB adapter device
        /// </summary>
        /// <param name="hwVersion">Hardware version of the GPIB adapter device</param>
        public void SetGPIBUsbHwVersion(string hwVersion)
        {
            _pi.SetAwgGPIBUsbHwVersion(hwVersion);
        }

        // glennj 7/23/2013
        /// <summary>
        /// Using GPIBUsb:HWVersion? update the property for the hardware version of the GPIB adapter device
        /// </summary>
        /// <returns></returns>
        public void GetGPIBUsbHwVersion()
        {
            GPIBUsbHwversion = _pi.GetAwgGPIBUsbHwVersion();
        }

        // glennj 7/23/2013
        /// <summary>
        /// Using GPIBUsb:SETID set the ID of the GPIB adapter device<para>
        /// Note: Set command differs from Query, uses SETID instead of ID@n</para>
        /// </summary>
        /// <param name="id">ID of the GPIB adapter device</param>
        public void SetGPIBUsbId(string id)
        {
            _pi.SetAwgGPIBUsbId(id);
        }

        // glennj 7/23/2013
        /// <summary>
        /// Using GPIBUsb:ID? update the property for the ID of the GPIB adapter device
        /// </summary>
        /// <returns></returns>
        public void GetGPIBUsbId()
        {
            GPIBUsbId = _pi.GetAwgGPIBUsbId();
        }

        // glennj 7/23/2013
        /// <summary>
        /// Using GPIBUsb:STATus set the status of the GPIB adapter device
        /// </summary>
        /// <param name="status">Status of the GPIB adapter device</param>
        public void SetGpibUsbStatus(string status)
        {
            _pi.SetAwgGpibUsbStatus(status);
        }

        // glennj 7/23/2013
        /// <summary>
        /// Using GPIBUsb:STATus? update the property for the status of the GPIB adapter device
        /// </summary>
        /// <returns></returns>
        public void GetGpibUsbStatus()
        {
            GPIBUsbStatus = _pi.GetAwgGpibUsbStatus();
        }


    }
}
