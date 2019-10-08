
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AwgTestFramework
{
    /// <summary>
    /// 
    /// This class contains helper functions that are called from the %AWG Display PI step definitions.
    /// This class has no restrictions as to where it will be used.
    /// 
    /// This "Helper" group does everything else but steps and TekVISA.
    /// Using parameters from the step, each helper will makes decisions
    /// such as send commands, or process responses from queries and
    /// do testing and generate asserts if necessary.
    /// 
    /// \ingroup grouphelperpi pisteps 
    /// 
    /// </summary>
    public class AwgDisplayGroup
    {
        public enum DisplayPlot {On, Off}
        /// <summary>
        /// Sets the plot display state for an AWG
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="setState"></param>
        public void SetPlotDisplayState(IAWG awg, DisplayPlot setState)
        {
            var state = (setState == DisplayPlot.On) ? "ON" : "OFF";
            awg.SetDisplayState(state);
        }

        /// <summary>
        /// Forces an AWG to update it's copy of the plot display state
        /// </summary>
        /// <param name="awg"></param>
        public void GetPlotDisplayState(IAWG awg)
        {
            awg.GetDisplayState();
        }

        public void DisplayStateShouldBe(IAWG awg, DisplayPlot expectedValue)
        {
            string interpretedValue = (expectedValue == DisplayPlot.On) ? "1" : "0";
            Assert.AreEqual(interpretedValue, awg.DisplayPlotState);
        }
    }
}
