
namespace AwgTestFramework
{
    public partial class CPi70KCmds
    {
        //glennj 06/20/2013
        /// <summary>
        /// Using INSTrument:COUPle:SOURce set the instrument couple source mode of this %AWG
        /// </summary>
        /// <param name="setValue">Desired mode</param>
        public void SetAwgInstrumentCoupleSource(string setValue)
        {
            string commandLine = "INSTrument:COUPle:SOURce " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 06/20/2013
        /// <summary>
        /// Using INSTrument:COUPle:SOURce? get the instrument couple source mode of this %AWG
        /// </summary>
        /// <returns>Run Mode</returns>
        public string GetAwgInstrumentCoupleSource()
        {
            string response;
            const string commandLine = "INSTrument:COUPle:SOURce?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        //glennj 06/20/2013
        /// <summary>
        /// Using INSTrument:MODE set the %AWG instrument mode between AWG or FGen mode
        /// </summary>
        /// <param name="setValue">The desired instrument mode</param>
        public void SetAwgInstrumentMode(string setValue)
        {
            string commandLine = "INSTrument:MODE " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 06/20/2013
        /// <summary>
        /// Using INSTrument:MODE? get the current instrument mode of this %AWG
        /// </summary>
        /// <returns>Current instrument mode</returns>
        public string GetAwgInstrumentMode()
        {
            string response;
            const string commandLine = "INSTrument:MODE?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
    }
}
