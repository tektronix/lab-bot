
namespace AwgTestFramework
{
    public partial class CPi70KCmds
    {
        // glennj 7/23/2013
        /// <summary>
        /// Using GPIBUsb:SETADDress set the address of the GPIB adapter device<para>
        /// Note: Set command differs from Query, uses SETADDress instead of ADDress@n</para>
        /// </summary>
        /// <param name="address">Address of the GPIB adapter device</param>
        public void SetAwgGPIBUsbAddress(int address)
        {
            string commandLine = "GPIBUsb:SETADDress " + address;
            _mAWGVisaSession.Write(commandLine);
        }

        // glennj 7/23/2013
        /// <summary>
        /// Using GPIBUsb:ADDress? get the address of the GPIB adapter device
        /// </summary>
        /// <returns>Address of the GPIB adapter device</returns>
        public string GetAwgGPIBUsbAddress()
        {
            string response;
            const string commandLine = "GPIBUsb:ADDress?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        // glennj 7/23/2013
        /// <summary>
        /// Using GPIBUsb:HWVersion set the hardware version of the GPIB adapter device
        /// </summary>
        /// <param name="hwVersion">Hardware version of the GPIB adapter device</param>
        public void SetAwgGPIBUsbHwVersion(string hwVersion)
        {
            string commandLine = "GPIBUsb:HWVersion " + _mPiUtility.Quotify(hwVersion);
            _mAWGVisaSession.Write(commandLine);
        }

        // glennj 7/23/2013
        /// <summary>
        /// Using GPIBUsb:HWVersion? get the hardware version of the GPIB adapter device
        /// </summary>
        /// <returns>Hardware version of the GPIB adapter device</returns>
        public string GetAwgGPIBUsbHwVersion()
        {
            string response;
            const string commandLine = "GPIBUsb:HWVersion?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        // glennj 7/23/2013
        /// <summary>
        /// Using GPIBUsb:SETID set the ID of the GPIB adapter device<para>
        /// Note: Set command differs from Query, uses SETID instead of ID@n</para>
        /// </summary>
        /// <param name="id">ID of the GPIB adapter device</param>
        public void SetAwgGPIBUsbId(string id)
        {
            string commandLine = "GPIBUsb:SETID " + _mPiUtility.Quotify(id);
            _mAWGVisaSession.Write(commandLine);
        }

        // glennj 7/23/2013
        /// <summary>
        /// Using GPIBUsb:ID? get the ID of the GPIB adapter device
        /// 
        /// </summary>
        /// <returns>ID of the GPIB adapter device</returns>
        public string GetAwgGPIBUsbId()
        {
            string response;
            const string commandLine = "GPIBUsb:ID?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        // glennj 7/23/2013
        /// <summary>
        /// Using GPIBUsb:STATus set the status of the GPIB adapter device
        /// </summary>
        /// <param name="status">Status of the GPIB adapter device</param>
        public void SetAwgGpibUsbStatus(string status)
        {
            string commandLine = "GPIBUsb:STATus " + _mPiUtility.Quotify(status);
            _mAWGVisaSession.Write(commandLine);
        }

        // glennj 7/23/2013
        /// <summary>
        /// Using GPIBUsb:STATus? get the status of the GPIB adapter device
        /// </summary>
        /// <returns>Status of the GPIB adapter device</returns>
        public string GetAwgGpibUsbStatus()
        {
            string response;
            const string commandLine = "GPIBUsb:STATus?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

    }
}
