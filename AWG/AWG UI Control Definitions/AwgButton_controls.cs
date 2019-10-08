// The UI Control definition files are for defining reusable control functions that can work on 
// more than a single control.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White.UIItems.Finders;

using Button = TestStack.White.UIItems.Button;

namespace AwgTestFramework
{
    /// <summary> This class contains methods for selecting buttons in the UI</summary>
    /// 
    [TechTalk.SpecFlow.Binding] //Very important! This entry needs to be made in each step definition file. 

    public class AwgButtonControls
    {
        #region Main AWG Mode Window Group

        // Perry Hunter 06/10/2013
        /// <summary>Selects the specified button in the AWG Main Window</summary>
        /// <summary>PREREQUISITE: AWG mode is selected</summary>
        /// <param name="buttonName">The AutomationID (name) of the button to be selected</param>
        public static void SelectAMainWindowButton(string buttonName)
        {
            // Commenting out the reference to the AWG for use in writing debug statements when in the UI.  This does not make sense.
            ////We reference the AwgSetupSteps.awg created at the start of the test run, and do not create a new session - always!
            //AWG defaultAWG = AwgSetupSteps.GetAWG("0");
            //defaultAWG.DiagComment("Selecting the " + buttonName + " Button in " + defaultAWG.ModelString + " window");

            //Find the requested radiobutton by it's AutomationID (in WPF, this is name property)
            var button = AWGUI.currentMainWindow.Get<Button>(SearchCriteria.ByAutomationId(buttonName));
            Assert.IsNotNull(button);

            //Check the IsEnabled property
            Assert.IsTrue(button.Enabled.Equals(true), buttonName + " was not enabled, could not select when requested");
            
            //Click it
            button.Click(); 
        }

        #endregion

        #region File & Utilities Group

        // Perry Hunter 06/10/2013
        /// <summary>Selects the specified radiobutton in the File & Utilities Window</summary>
        /// <summary>PREREQUISITE: File & Utilities tab is selected</summary>
        /// <param name="buttonName">The AutomationID (name) of the button to be selected</param>
        public static void SelectAFileAndUtilsButton(string buttonName)
        {
            //We reference the AwgSetupSteps.awg created at the start of the test run, and do not create a new session - always!
            //_awgSetupSteps.awg.DiagComment("Selecting the " + buttonName + " button in File & Utilities panel");

            //Find the requested radiobutton by it's AutomationID (in WPF, this is name property)
            var button = AWGUI.currentUIChildPanel.Get<Button>(SearchCriteria.ByAutomationId(buttonName));
            Assert.IsNotNull(button);

            //Check the IsEnabled property
            Assert.IsTrue(button.Enabled.Equals(true), buttonName + " was not enabled, could not select when requested");

            //Click it
            button.Click();
        }

        #endregion
    }
}