using System;
using TechTalk.SpecFlow;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AwgTestFramework
{

    /// <summary>
    /// Sharmila - 01/04/2015
    /// This class serves as the step definition file for the SourceXpress Connectivity feature.
    /// </summary>
    [Binding]
    public class SXConnectivityConnectSteps
    {
        private readonly AWGSXConnectivityGroup _awgSXConnectivityGroup = new AWGSXConnectivityGroup();
        public static string activeAWG;
        public static string statusOfAWG;

        [When(@"I connect to AWG (.*)")]
        public void WhenIConnectToAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            int index = int.Parse(awgNumber);

            string dutIP =  GetDUTIP(index);
           _awgSXConnectivityGroup.ConnectivityConnectCommand(dutIP, awg);

           System.Threading.Thread.Sleep(20000);
        }


        [When(@"I set the AWG (.*) as the active generator")]
        public void WhenISetTheAWGAsTheActiveGenerator(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            int index = int.Parse(awgNumber);
            string dutIP = GetDUTIP(index);
            _awgSXConnectivityGroup.ConnectivityActiveCommand(dutIP, awg);

            System.Threading.Thread.Sleep(5000);
        }

        [When(@"I disconnect from AWG (.*)")]
        public void WhenIDisconnectFromAWG(string awgNumber)
        {

            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            int index = int.Parse(awgNumber);
            string dutIP = GetDUTIP(index);
            _awgSXConnectivityGroup.ConnectivityDisconnectCommand(dutIP, awg);

            System.Threading.Thread.Sleep(10000);
        }


        [When(@"I query for the active generator on AWG (.*)")]
        public void WhenIQueryForTheActiveGeneratorOnAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            int index = int.Parse(awgNumber);
            activeAWG = _awgSXConnectivityGroup.ConnectivityActiveQuery(awg);
            System.Threading.Thread.Sleep(5000);
        }



        [When(@"I query the connect status for AWG (.*)")]
        public void WhenISendTheStatusQueryToTheAWG(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            int index = int.Parse(awgNumber);
            string dutIP = GetDUTIP(index);
            statusOfAWG = _awgSXConnectivityGroup.ConnectivityStatusQuery(dutIP, awg);
        }

        [Then(@"the connect status for AWG (.*) should be (.*)")]
        public void ThenTheConnectStatusForAWGShouldBe(string awgNumber, string expectedStatus)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSXConnectivityGroup.ValidateQueryResponse(expectedStatus, statusOfAWG);
        }

        [Then(@"AWG (.*) should be the active generator")]
        public void ThenAWGShouldBeTheActiveGenerator(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            int index = int.Parse(awgNumber);
            string expectedAWG = GetDUTIP(index);
            _awgSXConnectivityGroup.ActiveQueryResult(expectedAWG, activeAWG);
        }

        //Use this function to get the IP of the DUTs from the MySettings.xml file
         public string GetDUTIP(int index)
         {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<MySettings>));
            string currentUserProfile = Environment.GetEnvironmentVariable("USERPROFILE");
            string path = currentUserProfile  + "\\My Documents\\MySettings.xml";
            TextReader textReader = new StreamReader(path);
            List<MySettings> deserdata = (List<MySettings>)deserializer.Deserialize(textReader);
            textReader.Close();
            string dutIP = deserdata[index-1].DUTIP;
            return dutIP;
        }

    }
}
