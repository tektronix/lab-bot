using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AwgTestFramework
{

    /// <summary>
    /// Sharmila - 01/04/2015
    /// This class contains helper functions that are called from the %AWG SX Connectivity PI step definitions.
    /// This class has no restrictions as to where it will be used.
    /// 
    /// This "Helper" group does everything else but steps and TekVISA.
    /// Using parameters from the step, each helper will makes decisions
    /// such as send commands, or process responses from queries and
    /// do testing and generate asserts if necessary.
    /// </summary>
    public class AWGSXConnectivityGroup
    {
        UtilitiesGroup _utilitiesGroup = new UtilitiesGroup();
        public void ConnectivityConnectCommand(string dutIP, IAWG awg)
        {
            awg.ConnectivityConnectCommand(dutIP);
        }

        public void ConnectivityActiveCommand(string dutIP, IAWG awg)
        {
            awg.ConnectivityActiveCommand(dutIP);
        }

        public void ConnectivityDisconnectCommand(string dutIP, IAWG awg)
        {
            awg.ConnectivityDisconnectCommand(dutIP);
        }

        public string ConnectivityActiveQuery(IAWG awg)
        {
            string response = awg.ConnectivityActiveQuery();
            return response;
        }

        public string ConnectivityStatusQuery(string dutIP, IAWG awg)
        {
            string status = awg.ConnectivityStatusQuery(dutIP);
            return status;
        }

        public void ValidateQueryResponse(string expectedResponse, string actualResponse)
        {
            string errorMessage = "Expected " + expectedResponse + ", but got " + actualResponse + " as the result of the query";
            if (actualResponse == null)
            {
                throw new Exception("Status of AWG is not available");
            }
            else if (!actualResponse.Equals(expectedResponse))
            {
                Assert.AreEqual(actualResponse, expectedResponse, errorMessage);
            }
        }

        public void ActiveQueryResult(string expectedActiveAWG, string actualActiveAWG)
        {
            var charsToRemove = new string[] { "\\", "\"" };
            foreach (var c in charsToRemove)
            {
                actualActiveAWG = actualActiveAWG.Replace(c, string.Empty);
            };

            if (!expectedActiveAWG.Equals(actualActiveAWG))
            {
                throw new Exception("The active AWG is not what we expected");
            }
        }
    }
}
