//==========================================================================
// AWG.cs
// This file contains the code that instantiates each AWG as a VISA session and
// a collection of accessors to store system state variables.
// We allow 1-4 AWG's in the framework.
//==========================================================================

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

// ReSharper disable CheckNamespace
namespace AwgTestFramework
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// This class contains the code that instantiates each %AWG as a VISA session and a collection of accessors to store system state variables.
    /// We allow 1-4 %AWG's in the framework. 
    /// \ingroup othersetup dutsteps
    /// </summary>
    public partial class AWG : IAWG
    {
        private readonly IPiCmds _pi;
        private readonly UTILS _util = new UTILS();
        private readonly VisaExtensions _visaExt;

        private const int AwgMaxChannels = 2;
        private const int AwgMaxClocks = 2;
        private const int AwgMaxMarkers = 4;

        //! The value to which we reset the timeouts when they've been changed.   
        public uint DefaultVisaTimeout { get; set; }        // GRJ, 2013-10-02: old value, 10000;  

        /// <summary>
        /// Unique Visa session for this AWG
        /// </summary>
        public TekVISANet.VISA AWGVisaSession;

        public AWG( TekVISANet.VISA visaSession)
        {
            // New way to set visa timeout
            DefaultVisaTimeout = 90000;         // GRJ, 2013-10-02: old value, 10000;

            AWGVisaSession = visaSession;
// ReSharper disable UseObjectOrCollectionInitializer
            _visaExt = new VisaExtensions(AWGVisaSession);
// ReSharper restore UseObjectOrCollectionInitializer
            _visaExt.Session = AWGVisaSession.Session;

            // ReSharper disable UseObjectOrCollectionInitializer
            _pi = new CPi70KCmds(AWGVisaSession, _visaExt);
            // ReSharper restore UseObjectOrCollectionInitializer
            _pi.DefaultVisaTimeout = DefaultVisaTimeout;
        }

        public void UpdateVisaExtSession()
        {
            _visaExt.Session = AWGVisaSession.Session;
        }

        public void VisaSessionRead()
        {
            string response;
            AWGVisaSession.Read(out response);
            ReadResponse = response;
        }

        public void VisaSessionWrite(string command)
        {
            AWGVisaSession.Write(command);
        }

        public string VisaSessionQuery(string commandLine)
        {
            string response;
            AWGVisaSession.Query(commandLine, out response);
            ReadResponse = response;
            return response;
        }

        public bool VisaSessionOpen(string awgConnection)
        {
            return AWGVisaSession.Open(awgConnection);
        }

        public string VisaSessionErrorDescription
        {
            get { return AWGVisaSession.ErrorDescription; }
        }

        public void VisaSessionClose()
        {
            AWGVisaSession.Close();
        }

        public string ErrorDescription()
        {
            string status = AWGVisaSession.ErrorDescription;
            return status;
        }

        public uint SessionTimeout
        {
            get { return AWGVisaSession.Timeout; }
            set { AWGVisaSession.Timeout = value; }
        }

        // Unknown 01/01/01
        /// <summary>
        /// Function operates on a given id string to decode information
        /// </summary>
        /// <param name="idString">Assumes valid Id string from an AWG</param>
        private void GetAwgInformation(string idString)
        {
         
            if (string.IsNullOrEmpty(idString))
            {
                Assert.Fail("No ID string returned from AWG " + LogicalAWGNumber);
            }

            //This is kind of cute, C# allows us to label the regex group we want with a name, instead of having to use an array index value.
            //Regex AwgFeatureMatcher = new Regex(@"TEKTRONIX,(?<type>AWG|HSG)(?<modelNumber>\d+)(?<class>.),(?<serial>.+),SCPI:(?<scpi>.+) FW:(?<fwVersion>.+)");
            //To get the 70k to work it doesn't appear to add a SCPI field to its ID string
            var awgFeatureMatcher =
                new Regex(@"TEKTRONIX,(?<type>AWG|HSG)(?<modelNumber>\d+)(?<class>.*),(?<serial>.*),FV:(?<AppVersion>.+)");
            Match match = awgFeatureMatcher.Match(idString.Trim()); //The ID 
            Assert.IsTrue(match.Success,
                          "The AWG ID string did not match the specified pattern. The actual value returned was: " +
                          idString); // make sure you got a good match

            //Remember that since we have an instance of the AWG accessors for each one in the setup, these values are specific to that AWG            
            ModelNumber = match.Groups["modelNumber"].Value;
            ClassLetter = match.Groups["class"].Value;
            FamilyType = match.Groups["type"].Value;
            SerialNumber = match.Groups["serial"].Value;
            AppVersion = match.Groups["AppVersion"].Value;
            ModelString = FamilyType + ModelNumber + ClassLetter;

            var awgAppVersionMatcher = new Regex(@"(?<Major>\d+).(?<Minor>\d+).(?<Version>\d+)");
            Match versionMatch = awgAppVersionMatcher.Match(AppVersion);
            Assert.IsTrue(versionMatch.Success, "Unexpected version format" + AppVersion);

            AppVersionMajor = versionMatch.Groups["Major"].Value;
            AppVersionMinor = versionMatch.Groups["Minor"].Value;
            AppVersionVersion = versionMatch.Groups["Version"].Value;

            if (ModelNumber.Length == 5)
            {
                if (ModelNumber.Contains("70"))
                {
                    Family = "70";  // aka Pascal
                }
                else if (ModelNumber.Contains("50"))
                {
                    Family = "50";  // aka Bode
                }
                else
                {
                    Family = "Unknown";
                }
            }
        }

        /// <summary>
        /// Each AWG object has a logical identifier and is assigned when an AWG object is created
        /// </summary>
        public string LogicalAWGNumber { get; set; }
        /// <summary>
        /// The Signal Source family is found in the *IDN? response TEKTRONIX,AWG70002A,PQ00012,FV:2.0.0211<para>
        ///                                                                   ^^^</para><para>
        /// Currently one of two types, AWG or HSG</para>
        /// </summary>
        public string FamilyType { get; private set; }
        /// <summary>
        /// The model number is found in the *IDN? response TEKTRONIX,AWG70002A,PQ00012,FV:2.0.0211<para>
        ///                                                              ^^^^^</para><para>
        /// Currently one of two types, AWG or HSG</para>
        /// </summary>
        public string ModelNumber { get; private set; }
        /// <summary>
        /// The class letter is found in the *IDN? response TEKTRONIX,AWG70002A,PQ00012,FV:2.0.0211<para>
        ///                                                                   ^</para>
        /// </summary>
        public string ClassLetter { get; private set; }
        /// <summary>
        /// The serial number is found in the *IDN? response TEKTRONIX,AWG70002A,PQ00012,FV:2.0.0211<para>
        ///                                                                      ^^^^^^^</para>
        /// </summary>
        public string SerialNumber { get; private set; }

        /// <summary>
        /// The Application version is found in the *IDN? response TEKTRONIX,AWG70002A,PQ00012,FV:2.0.0211<para>
        ///                                                                                    ^^^^^^^^^^^</para>
        /// </summary>
        public string AppVersion { get; private set; }

        public string AppVersionMajor { get; private set; }
        public string AppVersionMinor { get; private set; }
        public string AppVersionVersion { get; private set; }
        /// <summary>
        /// A two digit number of 70 or 50 representing the 70k and 50k AWG family types
        /// </summary>
        public string Family { get; private set; }
        /// <summary>
        /// A re-constructed string containing the family type, (e.g. AWG), model number and class letter
        /// </summary>
        public string ModelString { get; private set; }

        /// <summary>
        /// Used to store a response from a AWGVisaSession.Read or Query
        /// </summary>
        public string ReadResponse { get; set; }

        /// <summary>
        /// AWG specific timer duration place holder.
        /// </summary>
        public double TimerDuration { get; set; }
        /// <summary>
        /// AWG specific time placeholder for when plotting is off.<para>
        /// This is used in testing for the test framework.</para><para>
        /// Testframe needs a location for placeholders for times for comparisons.</para>
        /// </summary>
        public double TimerPlotOff { get; set; }
        /// <summary>
        /// AWG specific time placeholder for when plotting is on.<para>
        /// This is used in testing for the test framework.</para><para>
        /// Testframe needs a location for placeholders for times for comparisons.</para>
        /// </summary>
        public double TimerPlotOn { get; set; }
    }
}
