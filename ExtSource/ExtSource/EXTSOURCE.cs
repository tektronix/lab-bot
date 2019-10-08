//==========================================================================
// EXTSOURCE.cs
// This file contains the code that instantiates the solo external source as a 
// VISA session and a collection of accessors to store system state variables.
// We allow only one external source in the framework!
//==========================================================================

using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

// ReSharper disable CheckNamespace
namespace AwgTestFramework
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// This class contains the code that instantiates each %EXTSOURCE as a VISA session and a collection of accessors to store system state variables.
    /// We allow 1 %EXTSOURCE in the framework. 
    /// \ingroup othersetup dutsteps
    /// </summary>
    public partial class EXTSOURCE : IEXTSOURCE
    {
        private readonly IPiCmdsExtSource _piex;
        private readonly VisaExtensions _visaExt;
        
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

        /// <summary>
        /// Used to store a response from a SCOPEVisaSession.Read or Query
        /// </summary>
        public string ExtSourceReadResponse { get; set; }


        /// <summary>
        /// Makes a new VISA session when %EXTSOURCE class is instantiated - NOTE: We only allow one ext source in the test system.
        /// </summary>
        public TekVISANet.VISA EXTSOURCEVisaSession;

        public EXTSOURCE( TekVISANet.VISA visaSession)
        {
            // New way to set visa timeout
            defaultVISATimeout = 90000;         // GRJ, 2013-10-02: old value, 10000;

            EXTSOURCEVisaSession = visaSession;
            // ReSharper disable UseObjectOrCollectionInitializer
            _visaExt = new VisaExtensions(EXTSOURCEVisaSession);
            // ReSharper restore UseObjectOrCollectionInitializer
            _visaExt.Session = EXTSOURCEVisaSession.Session;

            // ReSharper disable UseObjectOrCollectionInitializer
            _piex = new CPiExtSourceCmds(EXTSOURCEVisaSession, _visaExt);
            // ReSharper restore UseObjectOrCollectionInitializer
            _piex.DefaultVisaTimeout = defaultVISATimeout;
        }

        private static EXTSOURCE _extSource = null; //!< Define a single %SCOPE Visa session, initialize to null    
        private static string _extSourceConnection; //!< IP address or name of the Scope


        //  shkv 3/4/2015 Fixing the external source issue.
        /// <summary>
        /// Instantiate the %SCOPE class if it is not already open
        /// </summary>
        /// <param name="create">Each time you call GetScope(), you need to pass "true" if you want a new session, "false" if you are just looking up the existing session</param>
        /// <returns>Return new or existing session</returns>
        public static EXTSOURCE GetExtSource(bool create = true)
        {
            if (create == true)
            {
                TekVISANet.VISA EXTSOURCEVisaSession = new TekVISANet.VISA();
                //_scope = new SCOPE(_scope.SCOPEVisaSession);
                string status = "";
                _extSourceConnection = AwgSetupSteps.ExtSourceConnectionIP;
                _extSourceConnection = "TCPIP::" + _extSourceConnection + "::INSTR";

                //bool openSuccessFul = EXTSOURCEVisaSession.Open(_extSourceConnection);
                bool openSuccessFul = EXTSOURCEVisaSession.Open(_extSourceConnection, TekVISANet.TekVISADefs.AccessModes.VI_NO_LOCK, 90000, 5);
                if (!openSuccessFul)
                {
                    int retry = 4;
                    do
                    {
                        openSuccessFul = EXTSOURCEVisaSession.Open(_extSourceConnection);
                    } while ((--retry >= 0) && (!openSuccessFul));

                    try
                    {
                        status = _extSource.ErrorDescription();
                    }
                    catch (Exception)
                    {
                        status = "Object reference not set to an instance of an object.";
                    }
                    //See if the status string contains the word "Success"
                    Regex validatePreMatcher = new Regex(@"Success.+");
                    Match match = validatePreMatcher.Match(status);
                    // Check the status string to see if the operation was sucessful
                    if (!match.Success)
                    {
                        Assert.Inconclusive("Attempt to Open connection failed: " + status);
                    }
                }
                _extSource = new EXTSOURCE(EXTSOURCEVisaSession);
                //! \TODO: Figure out how to test for a valid session and assert here if false
            }
            return _extSource; // Otherwise, return the existing session
        }

        public static void CloseAllExternalSources()
        {
            int retry = 50;
            if (_extSource != null)
            {
                do
                {
                    _extSource.ExtSourceVisaSessionClose();
                    Thread.Sleep(3000);
                } while ((--retry >= 0) && _extSource != null);
                if (retry < 0)
                {
                    Assert.Inconclusive("Unable to close external source visa session properly");
                }
                _extSource = null;
            }
        }

        public void UpdateExtSourceVisaExtSession()
        {
            _visaExt.Session = EXTSOURCEVisaSession.Session;
        }

        public void ExtSourceVisaSessionRead()
        {
            string response;
            EXTSOURCEVisaSession.Read(out response);
            ExtSourceReadResponse = response;
        }

        public void ExtSourceVisaSessionWrite(string command)
        {
            EXTSOURCEVisaSession.Write(command);
        }

        public string ExtSourceVisaSessionQuery(string commandLine)
        {
            string response;
            EXTSOURCEVisaSession.Query(commandLine, out response);
            ExtSourceReadResponse = response;
            return response;
        }

        public bool ExtSourceVisaSessionOpen(string extSourceConnection)
        {
            return EXTSOURCEVisaSession.Open(extSourceConnection);
        }

        public string ExtSourceVisaSessionErrorDescription
        {
            get { return EXTSOURCEVisaSession.ErrorDescription; }
        }

        public void ExtSourceVisaSessionClose()
        {
            EXTSOURCEVisaSession.Close();
        }

        public string ErrorDescription()
        {
            string status = EXTSOURCEVisaSession.ErrorDescription;
            return status;
        }

        public uint SessionTimeout
        {
            get { return EXTSOURCEVisaSession.Timeout; }
            set { EXTSOURCEVisaSession.Timeout = value; }
        }
    }
}