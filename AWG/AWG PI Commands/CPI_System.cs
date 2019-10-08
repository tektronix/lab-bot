

namespace AwgTestFramework
{
    public partial class CPi70KCmds
    {
        //glennj 8/29/2013
        /// <summary>
        /// Using *IDN? return identification information for the arbitrary waveform generator.
        /// </summary>
        /// <returns>The %AWG's identification information</returns>
        public string GetAwgIDN()
        {
            string response;
            const string commandLine = "*IDN?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        //glennj 8/29/2013
        /// <summary>
        /// Using *LRN? return a list of commands and their current settings
        /// </summary>
        /// <returns></returns>
        public string GetAwgLRN()
        {
            string response;
            const string commandLine = "*LRN?";
            _mAWGVisaSession.Write(commandLine);
            _mAWGVisaSession.Read(160000, out response);
            return response;
        }

        //glennj 06/06/2013
        /// <summary>
        /// Using *OPT? return the implemented options
        /// </summary>
        /// <returns>Options implemented</returns>
        public string GetAwgOption()
        {
            string response;
            const string commandLine = "*OPT?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        //glennj 8/29/2013
        /// <summary>
        /// Using *RST, reset the AWG to a default state
        /// </summary>
        public void AwgRST()
        {
            const string command = "*RST";
            _mAWGVisaSession.Write(command);
        }

        //glennj 8/29/2013
        /// <summary>
        /// Using SYSTem:DATE, set the of day for the AWG
        /// </summary>
        /// <param name="setValue"></param>
        public void SetAwgSystemDate(string setValue)
        {
            string commandLine = "SYSTem:DATE " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        /// <summary>
        /// Using SYSTem:DATE?, get the system date
        /// </summary>
        /// <returns></returns>
        public string GetAwgSystemDate()
        {
            string response;
            const string commandLine = "SYSTem:DATE?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        //glennj 8/29/2013
        /// <summary>
        /// Using the SYSTem:ERRor:COUNt?, query the error queue count 
        /// </summary>
        /// <returns>Return the number of errors in the system error queue</returns>
        public string GetAwgSystemErrorQueueCount()
        {
            string response;
            const string commandLine = "SYSTem:ERRor:COUNt?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        //glennj 8/29/2013
        /// <summary>
        /// Using SYSTem:ERRor:DIALog set the display dialog mode
        /// </summary>
        /// <param name="setValue"></param>
        public void SetAwgSystemErrorDialog(string setValue)
        {
            string commandLine = "SYSTem:ERRor:DIALog " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 8/29/2013
        /// <summary>
        /// Using SYSTem:ERRor:DIALog? get the display dialog mode
        /// </summary>
        /// <returns></returns>
        public string GetAwgSystemErrorDialog()
        {
            string response;
            const string commandLine = "SYSTem:ERRor:DIALog?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        //glennj 8/29/2013
        /// <summary>
        /// Using the SYSTem:ERRor[:NEXT]?, query the error queue. 
        /// </summary>
        /// <returns>Last error on the error queue or a zero error</returns>
        public string GetAwgSystemError()
        {
            string response;
            const string commandLine = "SYSTem:ERRor?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        //glennj 06/04/2013
        /// <summary>
        /// Sets the system time
        /// 
        /// SYSTem:TIME
        /// </summary>
        /// <param name="hour">System hour</param>
        /// <param name="minute">System minute</param>
        /// <param name="second">System second</param>
        public void SetAwgSystemTime(string hour, string minute, string second)
        {
            string commandLine = "SYSTem:TIME " + hour + "," + minute + "," + second;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 06/04/2013
        /// <summary>
        /// Gets the system time
        /// 
        /// SYSTem:TIME?
        /// </summary>
        /// <returns>Current system time</returns>
        public string GetAwgSystemTime()
        {
            string response;
            const string commandLine = "SYSTem:TIME?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        //Unknown 01/01/01
        /// <summary>
        /// Returns the SCPI version number to which the command conforms.
        /// 
        /// SYSTem:VERSion?
        /// </summary>
        /// <returns>SCPI version number</returns>
        public string GetAwgSystemVersion()
        {
            string response;
            const string commandLine = "SYSTem:VERSion?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

    }
}
