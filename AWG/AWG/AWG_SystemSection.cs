

namespace AwgTestFramework
{
    public partial class AWG
    {

        public string IdString { get; set; }

        public string Lrn { get; set; }

        public string SystemTimeSnapShot { get; set; }

        /// <summary>
        /// Contains response to Using SYSTem:DATE?
        /// </summary>
        public string SystemDateCurrent { get; set; }
        /// <summary>
        /// Contains response from SYSTem:ERRor:COUNt?
        /// </summary>
        public string SystemErrorQueueCount { get; set; }
        /// <summary>
        /// Contains response from SYSTem:ERRor:DIALog?
        /// </summary>
        public string SystemErrorDialogMode { get; set; }
        /// <summary>
        /// Contains response to SYSTem:ERRor?
        /// </summary>
        public string SystemError { get; set; }
        /// <summary>
        /// Returns the SCPI version number to which the command conforms to.<para>
        /// SYSTem:VERSion?</para>
        /// </summary>
        public string ScpiVersion { get; private set; }

        public void IdentifyYourself() // aka "IDN?"
        {
            IdString = _pi.GetAwgIDN();
            GetAwgInformation(IdString);
        }

        public void LrnQuery()
        {
            Lrn = _pi.GetAwgLRN();
        }

        //glennj 06/06/2013
        /// <summary>
        /// Returns the implemented options
        /// </summary>
        /// <returns>Options implemented</returns>
        public string GetOPT()
        {
            OptionsImplemented = _pi.GetAwgOption();
            return OptionsImplemented;
        }

        public void Reset()
        {
            _pi.AwgRST();
        }

        /// <summary>
        /// Given a date string, set the AWG
        /// </summary>
        /// <param name="setValue"></param>
        public void SystemDate(string setValue)
        {
            _pi.SetAwgSystemDate(setValue);
        }

        /// <summary>
        /// Update the property that contains response of Using SYSTem:DATE?
        /// </summary>
        /// <returns>current system date</returns>
        public void SystemDateQuery()
        {
            SystemDateCurrent = _pi.GetAwgSystemDate();
        }

        public void SetSystemErrorDialog(string setValue)
        {
            _pi.SetAwgSystemErrorDialog(setValue);
        }

        public void GetSystemErrorDialog()
        {
            SystemErrorDialogMode = _pi.GetAwgSystemErrorDialog();
        }
        
        //glennj 8/29/2013
        /// <summary>
        /// Using the SYSTem:ERRor:COUNt?, query the error queue count 
        /// </summary>
        /// <returns>Return the number of errors in the system error queue</returns>
        public void GetSystemErrorQueueCount()
        {
            SystemErrorQueueCount = _pi.GetAwgSystemErrorQueueCount();
        }

        /// <summary>
        /// Sets the system time
        /// 
        /// SYSTem:TIME
        /// </summary>
        /// <param name="hour">System hour</param>
        /// <param name="minute">System minute</param>
        /// <param name="second">System second</param>
        public void SystemTime(string hour, string minute, string second)
        {
            _pi.SetAwgSystemTime(hour, minute, second);
        }

        /// <summary>
        /// Gets the system time
        /// 
        /// SYSTem:TIME?
        /// </summary>
        /// <returns>Current system time</returns>
        public void GetSystemTime()
        {
            SystemTimeSnapShot = _pi.GetAwgSystemTime();
        }

        /// <summary>
        /// Get the current date string from the AWG and<para>
        /// update the local copy</para>
        /// </summary>
        public void SystemDateUpdate()
        {
            SystemDateCurrent = _pi.GetAwgSystemDate();
        }

        /// <summary>
        /// Updates the SystemError property from SYSTem:ERRor:NEXT? and<para>
        /// returns the string</para>
        /// </summary>
        /// <returns></returns>
        public string SystemErrorQueue()
        {
            SystemError = _pi.GetAwgSystemError();
            return SystemError;
        }

        public void SystemVersionUpdate()
        {
            ScpiVersion = _pi.GetAwgSystemVersion();
        }
    }
}
