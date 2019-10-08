//==========================================================================
// EXTSOURCE.cs
// This file contains the code that instantiates the solo external source as a 
// VISA session and a collection of accessors to store system state variables.
// We allow only one external source in the framework!
//==========================================================================

using System;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains the code that instantiates the solo external source as a 
    /// VISA session and a collection of accessors to store system state variables.
    /// 
    /// We allow only one external source in the framework!
    /// 
    /// \ingroup othersetup 
    /// </summary>
    public class EXTSOURCE
    {
        //! Ext Source accessors
        public string error_string { get; set; }
        public string family { get; set; }
        public string fw_version { get; set; }
        public string id_string { get; set; }
        public string model { get; set; }
        public string number_of_channels { get; set; }
        public string options_implemented { get; set; }
        public string serial_number { get; set; }
        public string speed { get; set; }
        public string type { get; set; }
        public string version { get; set; }

        public string run_mode { get; set; }
        public string current_setup { get; set; }
        public string error { get; set; }
        public string wfm_list_size { get; set; }
        public uint defaultVISATimeout = 10000;
        public int zeroWfmList = 25;


        private TekVISANet.VISA _EXTSOURCEVisaSession = new TekVISANet.VISA();
                                //! The Single %EXTSOURCE visa session to be used

        /// <summary>
        /// Makes a new VISA session when %EXTSOURCE class is instantiated - NOTE: We only allow one ext source in the test system.
        /// </summary>
        public TekVISANet.VISA EXTSOURCEVisaSession
        {
            get { return _EXTSOURCEVisaSession; }
        }

        private static EXTSOURCE _EXTSOURCE = null; //!< Define a single SCOPE Visa session, initialize to null
        private static string ExtSourceConnection; //!< IP address or name of the External Source

        /// <summary>
        /// Instantiate the %EXTSOURCE class if it is not already open
        /// 
        /// NOTE: We only allow one external source in the test system.
        /// </summary>
        /// <param name="create">Each time you call GetExtSource, you need to pass "true" if you want a new session, "false" if you are just looking up the existing session</param>
        /// <returns>Return new or existing sesssion</returns>
        public static EXTSOURCE GetExtSource(bool create = true)
        {
            if (create == true)
            {
                _EXTSOURCE = new EXTSOURCE();

                ExtSourceConnection = AwgSetupSteps.ExtSourceConnectionIP;

                ExtSourceConnection = "TCPIP::" + ExtSourceConnection + "::INSTR";
                _EXTSOURCE._EXTSOURCEVisaSession.Open(ExtSourceConnection);

            }
            return _EXTSOURCE; // Otherwise, return the existing session
        }

        public static void CloseAllExtsource()
        {
            if (_EXTSOURCE != null)
            {
                _EXTSOURCE._EXTSOURCEVisaSession.Close();
                _EXTSOURCE = null;
            }
        }
    }
}