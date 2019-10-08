using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AwgTestFramework
{
    public partial class CPi70KCmds
    {
        // glennj 06/3/2013
        /// <summary>
        /// Returns a 1 by definition, unless of course it timesout.
        /// </summary>
        /// <returns>1</returns>
        public string AwgOPCQuery()
        {
            string response;
            const string commandLine = "*OPC?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        // glennj 06/04/2013
        /// <summary>
        /// Directs operation complete status to the Status Byte register<para>
        /// which must be polled to detect</para>
        /// </summary>
        public void AwgOPC()
        {
            _mAWGVisaSession.Write("*OPC");
        }

        /// <summary>
        /// Sends the WAI command
        /// </summary>
        /// <param name="awg">AWG object</param>
        public void AwgWAI()
        {
            const string commandLine = "*WAI";
            _mAWGVisaSession.Write(commandLine);
        }
    }
}
