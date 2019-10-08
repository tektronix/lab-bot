// The UI Control definition files are for defining reusable control functions that can work on 
// more than a single control.

using Microsoft.VisualStudio.TestTools.UnitTesting;

using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace AwgTestFramework
{
    public class AwgCheckboxControls
    {
        private static AwgSetupSteps _awgSetupSteps = new AwgSetupSteps();

        #region FGen Mode Window Group

        // Perry Hunter 06/10/2013
        /// <summary>Selects the Function Generator Couple Amplitude checkbox</summary>
        /// <summary>PREREQUISITE: Function Generator mode UI context</summary>
        /// <param name="channel">The channel number for the tab on which the checkbox is located</param>   
        /// <param name="checkBoxName">The AutomationID of the checkBox to select</param>   
        public static void SelectFGenCoupleAmplitudeCheckbox(string channel, string checkBoxName)
        {
            // Normally control definitions would be more abstract, but in this case there is only one
            // checkbox in the FGen UI. Ifmore are added, then we'll abstract this.
            // We reference the AwgSetupSteps.awg created at the start of the test run, and do not create a new session - always!
            // Commenting out the reference to the AWG for use in writing debug statements when in the UI.  This does not make sense.
            //AWG defaultAWG = AwgSetupSteps.GetAWG("0");
            //defaultAWG.DiagComment("Selecting the " + checkBoxName + " CheckBox in " + defaultAWG.ModelString + " window");

            //todo (PWH) NOTE: There are a number of layers we may/may not have to add here. Right now, we're getting away with just these two

            //Find the pane where the Couple Amplitude CheckBox is located
            Panel _panelChannel = (Panel)AWGUI.currentMainWindow.Get(SearchCriteria.ByAutomationId("scrViewControls"));
            Assert.IsNotNull(_panelChannel);

            //Find the requested checkbox in the pane by it's AutomationID (in WPF, this is name property)
            CheckBox _checkBox = _panelChannel.Get<CheckBox>(SearchCriteria.ByAutomationId(checkBoxName));
            Assert.IsNotNull(_checkBox, checkBoxName + " was not found");

            //Check the IsEnabled property of the checkbox
            Assert.IsTrue(_checkBox.Enabled.Equals(true), checkBoxName + " was not enabled, could not select when requested");

            //Click it
            _checkBox.Click();        
        }

        #endregion
    }
}

