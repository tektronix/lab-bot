using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AwgTestFramework
{
    public partial class AWG
    {

        #region Sync

        public string OpcQuery()
        {
            return _pi.AwgOPCQuery();
        }

        public void OpcCommand()
        {
            _pi.AwgOPC();
        }

        /// <summary>
        /// Sends the WAI command
        /// </summary>
        public void WaiCommand()
        {
            _pi.AwgWAI();
        }

        #endregion Sync

    }
}
