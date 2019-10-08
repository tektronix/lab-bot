using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AwgTestFramework
{
    /// <summary>
    /// Sharmila - 01/04/2015
    /// This class further sends across the SX Connectivity commands to the CPI_SXConnectivity.cs where we actually send the command to the DUT using VISA session
    /// </summary>
    public partial class AWG
    {
        public void ConnectivityConnectCommand(string dutIP)
        {
            _pi.ConnectivityConnectCommand(dutIP);
        }

        public string ConnectivityStatusQuery(string dutIP)
        {
            string status = _pi.ConnectivityStatusQuery(dutIP);
            return status;
        }

        public void ConnectivityActiveCommand(string dutIP)
        {
            _pi.ConnectivityActiveCommand(dutIP);
        }

        public string ConnectivityActiveQuery()
        {
            string activeAWG = _pi.ConnectivityActiveQuery();
            return activeAWG;
        }

        public void ConnectivityDisconnectCommand(string dutIP)
        {
            _pi.ConnectivityDisconnectCommand(dutIP);
        }
    }
}
