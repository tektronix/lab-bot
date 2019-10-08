//========================================================================= =
// AwgSetup_steps.cs
// This file contains the PI step definitions for initialization and teardown of AWGs in the framework. 
//
// PLEASE use the following regular expressions to match specified numeric formats and other values:
// <NR1> - ((?<!\S)[-+]?\d+(?!\S))
// <NR3> - ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?)
// AWG number -  AWG([1-4])
// File path strings - ""(.+)"" used when you want the string that is delimited by the quotes 
//                     
//========================================================================== 

using System.Globalization;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using System;

// ReSharper disable CheckNamespace
namespace AwgTestFramework
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// This class contains the PI step definitions for initialization and teardown of AWGs in the framework.
    /// 
    /// \ingroup othersetup dutsteps
    /// </summary>
    [Binding] //Very important!

    public class AwgSetupSteps 
    {
        private readonly AwgSystemGroup  _awgSystemGroup  = new AwgSystemGroup();
        private readonly AwgStatusGroup  _awgStatusGroup  = new AwgStatusGroup();
        private readonly AwgSyncGroup    _awgSyncGroup    = new AwgSyncGroup();
        private readonly AwgControlGroup _awgControlGroup = new AwgControlGroup();
        private readonly UTILS _utils = new UTILS();

        private static string  _awgContext;
        private static bool _awgContextValid;               // is false by default

        public static readonly string AwgContext = "0";
        public static readonly string Awg1 = "1";
        public static readonly string Awg2 = "2";
        public static readonly string Awg3 = "3";
        public static readonly string Awg4 = "4";

        public static readonly string Family70k = "70";
        public static readonly string Family50k = "50";

        public static bool IgnoreUi = false;

        // Unkown 01/01/01
        /// <summary>
        /// SpecFlow Before/After hooks setup
        /// </summary>
        /// 
        [BeforeTestRun] //MUST be static
        public static void BeforeTestRun()
        {
            AwgSystemGroup awgSystemGroup = new AwgSystemGroup();
            AwgStatusGroup awgStatusGroup = new AwgStatusGroup();
            AwgControlGroup awgControlGroup = new AwgControlGroup();

            //create a local instance of AWG to collect the test setup (model, options,channels) information and save that into accessors
            IAWG awg = GetAWG("1");

            // Get the AWG ID string, model number and S/N
            awgSystemGroup.AwgIdentifyYourself(awg);

            // Find the number of channels for this awg
            awgControlGroup.FindTheNumberOfChannelsAvailable(awg);

            // Get the list of options for this AWG
            awgStatusGroup.GetOptions(awg);

            //AwgSetupSteps the UI context accessors to the top level
            AwgContextFunctions.SetContextToTopLevel();

        }

        [BeforeFeature] //MUST be static
        public static void BeforeFeature()
        {
            //Added by Kavitha on 07/06/2015 to fix the SXP single channel failure for AC instrument
            //Nothing here yet
            AwgSystemGroup awgSystemGroup = new AwgSystemGroup();
            AwgStatusGroup awgStatusGroup = new AwgStatusGroup();
            AwgControlGroup awgControlGroup = new AwgControlGroup();

            //create a local instance of AWG to collect the test setup (model, options,channels) information and save that into accessors
            IAWG awg = GetAWG("1");

            // Get the AWG ID string, model number and S/N
            awgSystemGroup.AwgIdentifyYourself(awg);

            // Find the number of channels for this awg
            awgControlGroup.FindTheNumberOfChannelsAvailable(awg);

            // Get the list of options for this AWG
            awgStatusGroup.GetOptions(awg);
        }


        [BeforeScenario]
        public void BeforeScenario()
        {
            //Nothing here yet
            //Added by Kavitha on 07/14/2015 
            DateTime now = DateTime.Now;
            Console.WriteLine(now); 

        }

        [AfterScenario]
        public void AfterScenario()
        {          
            _utils.CleanupDialogs();

            //TODO: THis next line does very little. It only selectes one savesetup.awgx file. It needs to be expanded to delete any files NOT in the c:\temp\waveforms folder
            _utils.DeleteTemporaryFile(AWGUI.SetupFileSavePath);
        }

        [AfterFeature] //MUST be static
        public static void AfterFeature()
        {
            //Nothing here yet
        }

       [AfterTestRun] //MUST be static
        public static void AfterTestRun()
        {
            //Close AWG sessions
            CloseAllAWG();

            // Close SCOPE sessions  
            SCOPE.CloseAllScope();

            // Close EXTSOURCE sessions 
            EXTSOURCE.CloseAllExternalSources();
        }
   
        // Unkown 01/01/01
        /// <summary>
        /// Initialize an %AWG 
        /// 
        /// Open a VISA session to the %AWG
        /// </summary>
        /*!
            \AWGSetup\verbatim
        [Given(@"an AWG")]
            \endverbatim 
        */
        [Given(@"an AWG")]
        public void AnAwg()
        {
            IAWG awg = GetAWG("0");

            //Make sure the identifying AWG accessors are filled
            verifyValidAwg(awg);
        }

        //glennj 11/22/2013
        /// <summary>
        /// Initialize a logical AWG
        /// </summary>
        /// <param name="awgNumber"></param>
        /*!
            \AWGSetup\verbatim
        [Given(@" AWG ([1-4])")]
            \endverbatim 
        */
        [Given(@"AWG ([1-4])")]
        public void GivenAwg(string awgNumber)
        {
            IAWG awg = GetAWG(awgNumber);

            //Make sure the identifying AWG accessors are filled
            verifyValidAwg(awg);
        }

        //glennj 11/22/2013
        /// <summary>
        /// Bringing out the reset if required instead of hiding it.<para>
        /// There really is more than reset, it is putting the AWG</para><para>
        /// into a known or default state for testing.</para><para></para>
        /// </summary>
        /// <param name="awgNumber"></param>
        [Given(@"the default state for AWG ([1-4])")]
        public void ResetTheAWG(string awgNumber)
        {
            IAWG awg = GetAWG(awgNumber);
            PutAwgIntoKnownState(awg);
        }

        //glennj 11/22/2013
        /// <summary>
        /// Bringing out the reset if required instead of hiding it.<para>
        /// There really is more than reset, it is putting the AWG</para><para>
        /// into a known or default state for testing.</para><para></para>
        /// </summary>
        /// <param name="awgNumber"></param>
        [Given(@"the default state")]
        public void ContextResetTheAWG(string awgNumber)
        {
            IAWG awg = GetAWG("0");
            PutAwgIntoKnownState(awg);
        }

        // Unkown 01/01/01
        /// <summary>
        /// Open a VISA session to an %AWG and default to a known state 
        /// </summary>
        /*!
            \AWGSetup\verbatim
        [Given(@"a reset AWG")]
            \endverbatim 
        */
        [Given(@"a reset for AWG ([1-4])")]
        [Given(@"a reset for SXApp (.*)")]
        public void PreferredResetAwg(string awgNumber)
        {
            IAWG awg = GetAWG(awgNumber);

            //Make sure the AWG accessors are filled
            verifyValidAwg(awg);
            PutAwgIntoKnownState(awg);
        }

        [Given(@"a reset AWG")]
        public void ObsoluteAResetAwg()
        {
            IAWG awg = GetAWG("0");
            
            //Make sure the AWG accessors are filled
            verifyValidAwg(awg);
            PutAwgIntoKnownState(awg);
        }

        /// <summary>
        /// Common work<para>
        /// Sends a *RST to AWG</para><para>
        /// Does an unnecessary *OPC?</para><para>
        /// Does a *CLS which clears the error queue</para><para>
        /// Resets the UI context.? Is this the proper place?</para>
        /// </summary>
        /// <param name="awg"></param>
        void PutAwgIntoKnownState(IAWG awg)
        {
            // Put into a known state
            _awgSystemGroup.AwgRST(awg);
            
            // While not necessary for an implied *RST, do a *OPC? and test for health
            _awgSyncGroup.AwgOperationCompleteQuery(awg);
            
            // Clear out any errors in this AWG's error queue.
            _awgStatusGroup.AwgClearErrorQueue(awg);

            // Set UI context to top level
            AwgContextFunctions.SetContextToTopLevel();
        }

        private static IAWG[] _AWGList = { null, null, null, null };
        //! < Define an array of 4 %AWG Visa sessions, initialize each to null

        private static string _awgConnection;

        //! \note Added by Kavitha to store the configuration of the connections
        private static bool _testconfigcomplete;         // By default it is initialized to false
        private static string _connection1;
        private static string _connection2;
        private static string _connection3;
        private static string _connection4;
        private static string _connType;
// ReSharper disable InconsistentNaming
        public static string ScopeConnectionIP;
// ReSharper restore InconsistentNaming
// ReSharper disable InconsistentNaming
        public static string ExtSourceConnectionIP;
// ReSharper restore InconsistentNaming

        /// <summary>
        /// Given a logical AWG as a string, return an AWG.<para>
        /// If the string is equal to "0" then return the selected AWG context.</para>
        /// </summary>
        /// <param name="logicalAwg">Logical AWGs are 1-4 with 0 reserved as selected AWG context.</param>
        /// <returns></returns>
        public static IAWG GetAWG(string logicalAwg)
        {
            if (logicalAwg == "0")                      // Looking for a selected AWG context
            {
                IAWG awgContext;
                if (_awgContextValid)                   // If one has been created, then use it.
                {
                    awgContext = GetAWG(AWGNumString2Index(_awgContext));
                }
                else
                {
                    // If there is not valid awgContext, then create one.
                    // By default, AWG 1 is the context
                    _awgContext = "1";
                    awgContext = GetAWG(AWGNumString2Index(_awgContext));   // This creates an AWG object to be used.
                    _awgContextValid = true;
                }
                return awgContext;
            }

            return GetAWG(AWGNumString2Index(logicalAwg));
        }

        /// <summary>
        /// Assign a logical AWG to a context<para>
        /// and create a logical AWG if it doesn't exist.</para>
        /// </summary>
        /// <param name="awgNumber"></param>
        public static void AssignAwgContext(string awgNumber)
        {
#pragma warning disable 168
            IAWG awgContext = GetAWG(awgNumber);     // Creates
#pragma warning restore 168
            _awgContext = awgNumber;
            _awgContextValid = true;
        }

        class IdResponse
        {
            public string ModelNumber = "";
            public string ClassLetter = "";
            public string FamilyType = "";
            public string Family = "";
            public string SerialNumber = "";
            public string AppVersion = "";
            public string ModelString = "";

            public string AppVersionMajor = "";
            public string AppVersionMinor = "";
            public string AppVersionVersion = "";
        }

        // Unknown 01/01/01
        /// <summary>
        /// Instantiate the %AWG class for the session requested by the<para>
        /// index value by default, </para>
        /// create a new session unless we pass false
        /// </summary>
        /// <param name="index">Index value of the session</param>
        /// <returns>%AWG visa session</returns>
        static IAWG GetAWG(int index)
        {
            //Sharmila - 01/04/2015
            //To retrieve the SourceXpress button status to decide whether connection should be with GPIB8 or not
            bool isSXSelected = false;

            if (index >= 3)
            {
                Assert.Fail("AWG index value out of range, only 4 AWGs are allowed with index 0-3.");
            }

            // If the value at the requested index is null, then a new session is created and returned, otherwise the 
            // existing session at that index is returned and the session remains open.
            if (_AWGList[index] == null)
            {
                /* If the DUT configuration is completed then the DUT UI Dialog should not pop up. Hence the below check is done.
                 * Another way of stating this is only show the UI once, gather all the information for possible user later
                 * as what resources are used are dependent on the test being run at the moment. */
                if (_testconfigcomplete != true)
                {
                    var dutConfigUi = new dutui();
                    dutConfigUi.ShowDialog();
                    if (dutConfigUi.TopMost == false) //Bring to DUT Dialog to front focus
                    {                                 //These four lines of code have earned its writer a whole $1 coin 
                        dutConfigUi.TopMost = true;   //May it be spent wisely
                    }

                    if (dutui.pc_pbu_state) // is true
                    {
                        /* If the user selects PC App then the DUT IP Address is fixed as 127.0.0.1*/
                        _awgConnection = "TCPIP::127.0.0.1";
                    }
                    else
                    {
                        //Sharmila - 01/04/2015
                        //Retrieve the SourceXpress radio button status by deserializing the MySettings.xml
                        //If SourceXpress is selected, establish the connection with GPIB8
                        isSXSelected = dutConfigUi.deserdata[0].sx_state;
                        if (dutui.AWG1Controller_set || isSXSelected)
                        {
                            _connection1 = "TCPIP::localhost";
                        }
                        else if (dutui.dut1_ip_name_address_selected)   // is true
                        {
                            /* If user enters DUT IP Address then deserialized data for IP Adress is used to establish connection*/
                            _connection1 = dutConfigUi.deserdata[0].DUTIP;
                            _connType = dutConfigUi.deserdata[0].AwgConnType;
                        }
                        else
                        {
                            _connection1 = dutConfigUi.deserdata[0].DutName;
                            _connType  = dutConfigUi.deserdata[0].AwgConnType;

                        }

                        _connection2 = dutui.dut2_ip_name_address_selected ? dutConfigUi.deserdata[1].DUTIP : dutConfigUi.deserdata[1].DutName;

                        _connection3 = dutui.dut3_ip_name_address_selected ? dutConfigUi.deserdata[2].DUTIP : dutConfigUi.deserdata[2].DutName;

                        _connection4 = dutui.dut4_ip_name_address_selected ? dutConfigUi.deserdata[3].DUTIP : dutConfigUi.deserdata[3].DutName;
                    }

                    // Setup IP for scope (if there is one)
                    ScopeConnectionIP     = dutui.scope_ip_address_name_selected ? dutConfigUi.deserdata[0].ScopeIP : dutConfigUi.deserdata[0].ScopeName;
                    // Setup IP for external source clock (if there is one)
                    ExtSourceConnectionIP = dutui.extsource_ip_address_name_selected ? dutConfigUi.deserdata[0].ExtSourceIP : dutConfigUi.deserdata[0].ExtSourceName;

                    _testconfigcomplete = true;
                }

                if (dutui.pc_pbu_state) // is true
                    _awgConnection = "TCPIP::127.0.0.1";
                else
                {
                    switch (index)
                    {
                        case 0:
                            // PWH - Need this in case the test case calls out an AWG number that was not set in the dialog. I'd like for any error checks to have something like this level of detail sent back to the user on failures.
                            //Sharmila - 01/04/2015
                            //If Controller or SourceXpress is selectedd in UI, establish the connection with GPIB8
                            Assert.AreNotEqual("", _connection1,
                                               "The connect string for VISA was empty (e.g. TCPIP::::INSTR) - check configuration dialog for correct instrument setup.");
                            _awgConnection = (dutui.AWG1Controller_set || isSXSelected) ? "GPIB8::1" : "TCPIP" + "::" + _connection1;
                            break;

                        case 1:
                            Assert.AreNotEqual("", _connection2,
                                               "The connect string for VISA was empty - check configuration dialog for correct instrument setup.");
                            _awgConnection = "TCPIP" + "::" + _connection2;
                            break;

                        case 2:
                            Assert.AreNotEqual("", _connection3,
                                               "The connect string for VISA was empty - check configuration dialog for correct instrument setup.");
                            _awgConnection = "TCPIP" + "::" + _connection3;
                            break;

                        case 3:
                            Assert.AreNotEqual("", _connection4,
                                               "The connect string for VISA was empty - check configuration dialog for correct instrument setup.");
                            _awgConnection = "TCPIP" + "::" + _connection4;
                            break;
                    }
                }

                /*For Socket connection the String is as follows TCPIP::134.64.236.77::4000::SOCKET. Hence ::INSTR should be replaced with AwgConnectionType */
                /*For VXI-11 connection the String is as follows TCPIP::134.64.236.77::INSTR*/
                if(_connType =="SOCKET")
                {
                    _awgConnection = _awgConnection + "::4001::SOCKET";
                    //PWH - Shouldn't this have the "TCPIP" replaced by AwgConnectionType?
                }
                else
                {
                    _awgConnection = _awgConnection + "::INSTR";
                    
                }

                if (dutui.AWG1Controller_set)
                {
                    IgnoreUi = dutui.IgnoreUI;
                }
                // Before creating an AWG, it is necessary to know the type of AWG that the
                // address is associated with.  Try to make a connection.  If the connection
                // is successful, then an specific AWG can be created with the just made
                // connection.
                TekVISANet.VISA visaSession = new TekVISANet.VISA();

                //  Try and have the visaSession make a connection to the resource
                bool openSuccessFul;

                int retry = 5;
                do
                {
                    openSuccessFul = visaSession.Open(_awgConnection);
                } while ((--retry >= 0) && (!openSuccessFul));

                string status = visaSession.ErrorDescription;

                //See if the status string contains the word "Success"
                Regex validatePreMatcher = new Regex(@"Success.+");
                Match match = validatePreMatcher.Match(status);
                // Check the status string to see if the operation was sucessful
                if (!match.Success)
                {
                    Assert.Fail("Attempt to Open connection failed: " + status);
                }

                // After a successful connection, do an *idn? query and get model id.
                // Once there is an model number, the correct and proper AWG can be
                // created and added to the list.  Right?
                string response = null;
                visaSession.Query("*IDN?", out response);

                if (response == null)
                {
                    Assert.Fail("Attempt to get ID string failed.");
                }

                // Success, right, we have an ID string.  Pull it apart to determine the family
                IdResponse decomposed = GetAwgInformation(response);

                if (decomposed.Family == Family70k)
                {
                    //  Now create an AWG.
                    _AWGList[index] = new AWG(visaSession);
                    _AWGList[index].LogicalAWGNumber = (index + 1).ToString(CultureInfo.InvariantCulture);    // Let the AWG know its place in the world.
                }
                else if (decomposed.Family == Family50k)
                {
                    // Create the new 50K here!
                }
                else
                {
                    Assert.Fail("Cannot support unknown Family " + decomposed.Family);
                }
            }

            //  If it failed, then an assert happened, so we didn't get here.
            //  Was this requested awg discovered?
            if (_AWGList[index] == null)
            {
                Assert.Fail("No AWG was found!");
            }
            return _AWGList[index];
        }

        // Unkown 01/01/01
        /// <summary>
        /// Close any open AWG sessions
        /// </summary>
        public static void CloseAllAWG()
        {
            for (int i = 0; i < 4; i++)
            {
                if (_AWGList[i] != null) // Otherwise, you'll get an error when trying to close a null session
                {
                    _AWGList[i].VisaSessionClose();
                    _AWGList[i] = null;
                }
            }
        }

        void verifyValidAwg(IAWG awg)
        {
            if (awg != null)
            {
                if (awg.ModelNumber.Equals(""))
                {
                    Assert.Fail("model_number accessor is null - no AWG present");
                }

                if (awg.GetNumberOfChannels().Equals(""))
                {
                    Assert.Fail("number_of_channels accessor is null - no AWG present");
                }

                if (awg.OptionsImplemented.Equals(""))
                {
                    Assert.Fail("options_implemented accessor is null - no AWG present");
                }
            }
        }

        /// <summary>
        /// Given a logic AWG number create an AWG object and <para>
        /// 1. Get a connection</para><para>
        /// 2. Get Id string and decode it</para><para>
        /// 3. Find the number of channels</para><para>
        /// 4. Reset to a default state</para><para>
        /// 5. Clear out any possible errors from previous sessions</para>
        /// </summary>
        /// <param name="lid"></param>
        void SetupNewAwgWithReset(string lid)
        {
            //int id = (lid > 0) ? (lid - 1) : 0;         // User thinks in logical ID, this deals in implementation details
            
            //Open a VISA session to the named instrument
            IAWG awg = GetAWG(lid);
            // Go query yourself and decode and save it.
            _awgSystemGroup.AwgIdentifyYourself(awg);
            // Find the number of channels for this awg
            _awgControlGroup.FindTheNumberOfChannelsAvailable(awg);
            // Put into a known state
            _awgSystemGroup.AwgRST(awg);
            // While not necessary for an implied *RST, do a *OPC? and test for health
            _awgSyncGroup.AwgOperationCompleteQuery(awg);
            // And just to be sure, clear out any errors in this AWG's error queue.
            _awgStatusGroup.AwgClearErrorQueue(awg);
        }

        //glennj 06/20/2013
        /// <summary>
        /// Convert %AWG number (from %AWG, %AWG1, %AWG2, etc.) to array index value
        /// </summary>
        /// <param name="awgNumString">Given %AWG Number</param>
        /// <returns>Array index value</returns>
        public static int AWGNumString2Index(string awgNumString)
        {
            int index = 0;
            if ((awgNumString != "") && (awgNumString != "0"))
            {
                int awgValue = int.Parse(awgNumString);
                index = awgValue - 1;
            }
            return index;
        }

        // Unknown 01/01/01
        /// <summary>
        /// Convert zero-based array index value to %AWG number (%AWG, AWG1, AWG2, etc.) 
        /// </summary>
        /// <param name="awgIndex">%AWG index number</param>
        /// <returns>%AWG number</returns>
        public static string AWGIndex2NumString(int awgIndex)
        {
            int awgIndexNumber = awgIndex + 1; //Correct for zero-based array index
            string awgNumString = awgIndexNumber.ToString(CultureInfo.InvariantCulture);
            return awgNumString;
        }
        
        // glennj 1/24/2014
        // There is a similar function in the AWG classes
        /// <summary>
        /// Function operates on a given id string to decode information
        /// </summary>
        /// <param name="idString">Assumes valid Id string from an AWG</param>
        static IdResponse GetAwgInformation(string idString)
        {
          //  idString = "TEKTRONIX,AWG70002,,FV:0.0.0045";
            IdResponse idResponse = new IdResponse();
            if (string.IsNullOrEmpty(idString))
            {
                Assert.Fail("No ID string returned from AWG ");
            }

            //This is kind of cute, C# allows us to label the regex group we want with a name, instead of having to use an array index value.
            //Regex AwgFeatureMatcher = new Regex(@"TEKTRONIX,(?<type>AWG|HSG)(?<modelNumber>\d+)(?<class>.),(?<serial>.+),SCPI:(?<scpi>.+) FW:(?<fwVersion>.+)");
            //To get the 70k to work it doesn't appear to add a SCPI field to its ID string
            var awgFeatureMatcher =
                new Regex(@"TEKTRONIX,(?<type>AWG|HSG)(?<modelNumber>\d+)(?<class>.*),(?<serial>.*),FV:(?<AppVersion>.+)");
                //new Regex(@"TEKTRONIX,(?<type>AWG|HSG)(?<modelNumber>\d+)(?<class>.),(?<serial>.+),FV:(?<AppVersion>.+)");
            Match match = awgFeatureMatcher.Match(idString.Trim()); //The ID 
            Assert.IsTrue(match.Success,
                          "The AWG ID string did not match the specified pattern. The actual value returned was: " +
                          idString); // make sure you got a good match

            //Remember that since we have an instance of the AWG accessors for each one in the setup, these values are specific to that AWG            
            idResponse.ModelNumber =  match.Groups["modelNumber"].Value;
            idResponse.ClassLetter = match.Groups["class"].Value;
            idResponse.FamilyType = match.Groups["type"].Value;
            idResponse.SerialNumber = match.Groups["serial"].Value;
            idResponse.AppVersion = match.Groups["AppVersion"].Value;
            idResponse.ModelString = idResponse.FamilyType + idResponse.ModelNumber + idResponse.ClassLetter;

            var awgAppVersionMatcher = new Regex(@"(?<Major>\d+).(?<Minor>\d+).(?<Version>\d+)");
            Match versionMatch = awgAppVersionMatcher.Match(idResponse.AppVersion);
            Assert.IsTrue(versionMatch.Success, "Unexpected version format" + idResponse.AppVersion);

            idResponse.AppVersionMajor = versionMatch.Groups["Major"].Value;
            idResponse.AppVersionMinor = versionMatch.Groups["Minor"].Value;
            idResponse.AppVersionVersion = versionMatch.Groups["Version"].Value;
            //ModelNumber is 7000 innstead of 70001
            if (idResponse.ModelNumber.Length == 5)
            {
                if (idResponse.ModelNumber.Contains(Family70k))
                {
                    idResponse.Family = Family70k;  // aka Pascal
                }
                else if (idResponse.ModelNumber.Contains(Family50k))
                {
                    idResponse.Family = Family50k;  // aka Bode
                }
                else
                {
                    idResponse.Family = "Unknown";
                }
            }
            return idResponse;
        }
    }
}