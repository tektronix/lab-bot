
namespace AwgTestFramework
{
    public partial class AWG
    {

        /// <summary>
        /// Property results for DISPlay:PLOT:STATe?
        /// </summary>
        public string DisplayPlotState { get; set; }

        //glennj 6/20/2013
        /// <summary>
        /// Sets the plot display state for this AWG
        /// </summary>
        /// <param name="state">The state to set the Display Plot to</param>
        public void SetDisplayState(string state)
        {
            _pi.SetAwgDisplayState(state);
        }

        //glennj 06/20/2013
        /// <summary>
        /// Updates the copy of the plot display state of this AWG
        /// </summary>
        /// <returns></returns>
        public void GetDisplayState()
        {
            DisplayPlotState = _pi.GetAwgDisplayState(); 
        }

    }
}
