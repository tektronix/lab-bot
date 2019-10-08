
namespace AwgTestFramework
{
    public partial class CPi70KCmds
    {
        //glennj 6/20/2013
        /// <summary>
        /// Using DISPlay:PLOT:STATe set the plot display state of this AWG
        /// </summary>
        /// <param name="state">The state to set the Display Plot to</param>
        public void SetAwgDisplayState(string state)
        {
            string commandLine = "DISPlay:PLOT:STATe " + state;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 06/20/2013
        /// <summary>
        /// Using DISPlay:PLOT:STATe? get the plot display state of this AWG
        /// </summary>
        /// <returns></returns>
        public string GetAwgDisplayState()
        {
            string response;
            const string commandLine = "DISPlay:PLOT:STATe?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
    }
}
