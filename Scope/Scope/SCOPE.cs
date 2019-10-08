//==========================================================================
// SCOPE.cs
// This file contains the code that instantiates the solo oscilloscope as a 
// VISA session and a collection of accessors to store system state variables.
// We allow only one scope in the framework!
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
    /// This class contains the code that instantiates each %SCOPE as a VISA session and a collection of accessors to store system state variables.
    /// We allow 1 %SCOPE in the framework. 
    /// \ingroup othersetup dutsteps
    /// </summary>
    public partial class SCOPE : ISCOPE
    {
        private readonly IPiCmdsScope _pis;
        private readonly VisaExtensions _visaExt;

        public uint defaultVISATimeout = 10000;
        //! Scope accessors
        public string ScopeIdString { get; set; }
        public string ScopeFwVersion { get; set; }
        public string ScopeNumberChans { get; set; }
        public string ScopeSpeed { get; set; }
        public string ScopeErrorString { get; set; }
        public string ScopeErrorMessageString { get; set; }
        public string ScopeSystemErrorString { get; set; }

        public TekVISANet.VISA SCOPEVisaSession;

        public SCOPE( TekVISANet.VISA visaSession)
        {
            // New way to set visa timeout
            defaultVISATimeout = 90000;         // GRJ, 2013-10-02: old value, 10000;

            SCOPEVisaSession = visaSession;
            // ReSharper disable UseObjectOrCollectionInitializer
            _visaExt = new VisaExtensions(SCOPEVisaSession);
            // ReSharper restore UseObjectOrCollectionInitializer
            _visaExt.Session = SCOPEVisaSession.Session;

            // ReSharper disable UseObjectOrCollectionInitializer
            _pis = new CPiScopeCmds(SCOPEVisaSession, _visaExt);
            // ReSharper restore UseObjectOrCollectionInitializer
            _pis.DefaultVisaTimeout = defaultVISATimeout;
        }

        public void UpdateScopeVisaExtSession()
        {
            _visaExt.Session = SCOPEVisaSession.Session;
        }

        public void ScopeVisaSessionRead()
        {
            string response;
            SCOPEVisaSession.Read(out response);
            ScopeReadResponse = response;
        }

        public void ScopeVisaSessionWrite(string command)
        {
            SCOPEVisaSession.Write(command);
        }

        public string ScopeVisaSessionQuery(string commandLine)
        {
            string response;
            SCOPEVisaSession.Query(commandLine, out response);
            ScopeReadResponse = response;
            return response;
        }

        public bool ScopeVisaSessionOpen(string awgConnection)
        {
            return SCOPEVisaSession.Open(awgConnection);
        }

        public string ScopeVisaSessionErrorDescription
        {
            get { return SCOPEVisaSession.ErrorDescription; }
        }

        public void ScopeVisaSessionClose()
        {
            SCOPEVisaSession.Close();
        }

        public string ErrorDescription()
        {
            string status = SCOPEVisaSession.ErrorDescription;
            return status;
        }

        public uint SessionTimeout
        {
            get { return SCOPEVisaSession.Timeout; }
            set { SCOPEVisaSession.Timeout = value; }
        }

        // Unknown 01/01/01
        /// <summary>
        /// Function operates on a given id string to decode information
        /// </summary>
        /// <param name="idString">Assumes valid Id string from an AWG</param>
        private void GetScopeInformation(string idString)
        {
            if (string.IsNullOrEmpty(idString))
            {
                Assert.Fail("No ID string returned from SCOPE ");
            }

            //This is kind of cute, C# allows us to label the regex group we want with a name, instead of having to use an array index value.
            //Regex AwgFeatureMatcher = new Regex(@"TEKTRONIX,(?<type>AWG|HSG)(?<modelNumber>\d+)(?<class>.),(?<serial>.+),SCPI:(?<scpi>.+) FW:(?<fwVersion>.+)");
            //First to to match to the older scopes 5K/7K and sampling 8K
            var scopeFeatureMatcher =
                new Regex(@"TEKTRONIX,(?<type>CSA|DPO|MDO|MSO)(?<model_number>\d{4}).?,(?<serial>.+),CF:\d\d\.\dCT\sFV:(?<fwVersion>.+)");
            Match match = scopeFeatureMatcher.Match(idString.Trim()); //The ID 
            if (!match.Success)
            {
                //if not a match to the older scopes check to see if scope is a 70K
                scopeFeatureMatcher =
                new Regex(@"TEKTRONIX,(?<type>CSA|DPO|MDO|MSO)(?<model_number>\d{5})(?<class>.+),(?<serial>.+),CF:\d\d\.\dCT\sFV:(?<fwVersion>.+)");
                match = scopeFeatureMatcher.Match(idString.Trim()); //The ID 
            }

            Assert.IsTrue(match.Success,
                          "The Scope ID string did not match the specified pattern. The actual value returned was: " +
                          idString); // make sure you got a good match

            //Remember that since we have an instance of the AWG accessors for each one in the setup, these values are specific to that AWG            
            ScopeModelNumber = match.Groups["modelNumber"].Value;
            ScopeFamilyType = match.Groups["type"].Value;
            ScopeSerialNumber = match.Groups["serial"].Value;
            ScopeClassLetters = match.Groups["class"].Value;
            ScopeModelString = ScopeFamilyType + ScopeModelNumber + ScopeClassLetters;
            /*
            if (ScopeFamilyType.Length == 3)
            {
                if (ScopeModelNumber.Contains("DPO"))
                {
                    ScopeFamily = "DPO";  // aka Mid Range Real Time Scope
                }
                else if (ScopeModelNumber.Contains("CSA"))
                {
                    ScopeFamily = "CSA";  // aka Sampling Scopes
                }
                else if (ScopeModelNumber.Contains("MSO"))
                {
                    ScopeFamily = "MSO";  // aka High End Real Time Scope
                }
                else if (ScopeModelNumber.Contains("MDO"))
                {
                    ScopeFamily = "MDO";  // aka Mixed Signal Scope
                }
                else
                {
                    ScopeFamily = "Unknown";
                }
            }
            */
        }

        /// <summary>
        /// The Scope family is found in the *IDN? response TEKTRONIX,DPO7354,B055089,CF:91.1CT FV:5.3.5 Build 22<para>
        ///                                                           ^^^</para><para>
        /// Currently one of two types, CSA or DPO</para>
        /// </summary>
        public string ScopeFamilyType { get; private set; }
        
        /// <summary>
        /// The model number is found in the *IDN? response TEKTRONIX,DPO73304DX,B260167,CF:91.1CT FV:7.1.1 Build 1<para>
        ///                                                              ^^^^^</para><para>
        /// Currently one of three types, DPO(7300|73000) and CSA8000</para>
        /// </summary>
        public string ScopeModelNumber { get; private set; }

        /// <summary>
        /// The model number is found in the *IDN? response TEKTRONIX,DPO73304DX,B260167,CF:91.1CT FV:7.1.1 Build 1<para>
        ///                                                                   ^^</para>	 
        /// </summary>
        public string ScopeClassLetters { get; private set; }
        
        /// <summary>
        /// The serial number is found in the *IDN? response TEKTRONIX,DPO73304DX,B260167,CF:91.1CT FV:7.1.1 Build 1<para>
        ///                                                                       ^^^^^^^</para>
        /// </summary>
        public string ScopeSerialNumber { get; private set; }

        /// <summary>
        /// A two digit number of in the range of 5-7, 70-83 representing the different model of the sampling and real time scopes 
        /// </summary>
        public string ScopeFamily { get; private set; }

        /// <summary>
        /// A re-constructed string containing the family type, (e.g. AWG), model number and class letter
        /// </summary>
        public string ScopeModelString { get; private set; }

        /// <summary>
        /// Used to store a response from a SCOPEVisaSession.Read or Query
        /// </summary>
        public string ScopeReadResponse { get; set; }

        /// <summary>
        /// Scope specific timer duration place holder.
        /// </summary>
        public double ScopeTimerDuration { get; set; }

        /// <summary>
        /// Method that serves as a safety net for queries to the Scope for any length of time.
        /// Due to having everything being dumped into the event queue this method parses the
        /// string for the desired prefix and returns the payload if it is correct
        /// 
        /// </summary>
        /// <param name="desiredPrefix">Desired error queue prefix</param>
        /// <param name="queueValue">Value that was queried from the queue</param>
        /// <returns>Error queue payload without the prefix</returns>
        public string ScopeErrorQueueParser(string desiredPrefix, string queueValue)
        {
            string preparedPrefix = desiredPrefix.ToUpper(); //Each prefix is sent in straight from the command to TekVisa need to
            preparedPrefix = preparedPrefix.TrimEnd('?');    //change it to get it to match what the return prefix will look like
            Regex responseRegex = new Regex(@"^:(?<prefix>[A-Z1-9]+:?[A-Z1-9]*:?[A-Z1-9]*:?[A-Z1-9]) (?<query>.+)$");
            Match m = responseRegex.Match(queueValue);
            if (m.Groups["prefix"].Value != preparedPrefix)
            {
                return "";
            }
            return m.Groups["query"].Value;
        }

        /// <summary>
        /// Makes a new VISA session when %SCOPE class is instantiated
        /// 
        /// NOTE: We only allow one scope in the test system.
        /// </summary>

        private static SCOPE _scope = null; //!< Define a single %SCOPE Visa session, initialize to null    
        private static string _scopeConnection; //!< IP address or name of the Scope


        //shkv 3/9/2015 Fixing flag issues for Type-6 instrument
        /// <summary>
        /// Instantiate the %SCOPE class if it is not already open
        /// </summary>
        /// <param name="create">Each time you call GetScope(), you need to pass "true" if you want a new session, "false" if you are just looking up the existing session</param>
        /// <returns>Return new or existing session</returns>
        public static SCOPE GetScope(bool create = true)
        {
            if (create == true)
            {
                TekVISANet.VISA SCOPEVisaSession = new TekVISANet.VISA();
                //_scope = new SCOPE(_scope.SCOPEVisaSession);

                string status = "";
                _scopeConnection = AwgSetupSteps.ScopeConnectionIP;
                _scopeConnection = "TCPIP::" + _scopeConnection + "::INSTR";
               
                // bool openSuccessFul = SCOPEVisaSession.Open(_scopeConnection);
                bool openSuccessFul = SCOPEVisaSession.Open(_scopeConnection, TekVISANet.TekVISADefs.AccessModes.VI_NO_LOCK, 90000, 5);
                if (!openSuccessFul)
                {
                    int retry = 4;
                    do
                    {
                        openSuccessFul = SCOPEVisaSession.Open(_scopeConnection);
                    } while ((--retry >= 0) && (!openSuccessFul));
                    
                    try
                    {
                        status = _scope.SCOPEVisaSession.ErrorDescription;
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
                _scope = new SCOPE(SCOPEVisaSession); 
                //! \TODO: Figure out how to test for a valid session and assert here if false
            }
            return _scope; // Otherwise, return the existing session
        }

        public static void CloseAllScope()
        {
            int retry = 50;
            if (_scope != null)
            {
                do
                {
                    Thread.Sleep(5000);
                    _scope.SCOPEVisaSession.Close();
                } while ((--retry >= 0) && _scope != null);
                if (retry < 0)
                {
                    Assert.Inconclusive("Unable to close scope visa session properly");
                }
                _scope = null;
            }
        }
    }
}