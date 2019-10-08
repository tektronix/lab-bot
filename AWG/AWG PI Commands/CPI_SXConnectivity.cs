using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AwgTestFramework
{
    //Sharmila - 01/04/2015
    //This class is used to send across the SX connectivity commands to the GPIB8 through TekVISA
    public partial class CPi70KCmds
    {
        public void ConnectivityConnectCommand(string dutIP)
        {
            string command = "CONNECTIVITY:CONNECT" + " \"" + dutIP + "\"";
            _mAWGVisaSession.Write(command);            
        }

        public string ConnectivityStatusQuery(string dutIP)
        {
            string query = "CONNECTIVITY:STATUS?" + " \"" + dutIP + "\"";
            string response;
            _mAWGVisaSession.Query(query, out response);
            return response;
        }

        public void ConnectivityActiveCommand(string dutIP)
        {
            string command = "CONNECTIVITY:ACTIVE" + " \"" + dutIP + "\"";
            _mAWGVisaSession.Write(command);  
        }

        public string ConnectivityActiveQuery()
        {
            string query = "CONNECTIVITY:ACTIVE?";
            string response;
            _mAWGVisaSession.Query(query, out response);
            return response;
        }

        public void ConnectivityDisconnectCommand(string dutIP)
        {
            string command = "CONNECTIVITY:DISCONNECT" + " \"" + dutIP + "\"";
            _mAWGVisaSession.Write(command); 
        }
    }
}
