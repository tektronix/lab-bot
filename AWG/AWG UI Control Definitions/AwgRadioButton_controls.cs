using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White.Factory;
using TestStack.White.UIItems.Finders;

using Application = TestStack.White.Application;
using Window = TestStack.White.UIItems.WindowItems.Window;
using RadioButton = TestStack.White.UIItems.RadioButton;

namespace AwgTestFramework
{
    public class AwgMainRadioButtonControls
    {
        // Perry Hunter 06/10/2013
        /// <summary>Selects the specified radiobutton in the AWG Main Window</summary> 
        /// <param name="radioButtonName">The AutomationID of the radio button to select</param>       
        public static void SelectMainRadioButton(string radioButtonName)
        {
            //Commenting out the reference to the AWG for use in writing debug statements when in the UI.  This does not make sense.
            //AWG _awg = AwgSetupSteps.GetAWG("1");
            //_awg.DiagComment("Selecting the " + radioButtonName + " RadioButton in " + _awg.ModelString + " window");
            
            //The currentApplication and currentMainWindow are already defined from the setup steps...
            //Find the requested radiobutton by it's AutomationID (in WPF, this is name property)
            RadioButton _radiobutton = AWGUI.currentMainWindow.Get<RadioButton>(SearchCriteria.ByAutomationId(radioButtonName));

            //Check the IsEnabled property
            Assert.IsTrue(_radiobutton.Enabled.Equals(true), radioButtonName + " was not enabled, could not select when requested");
            
            //Click it
            _radiobutton.Click();

            //Check it's "IsSelected" property - should now be true
            Assert.IsTrue(_radiobutton.IsSelected.Equals(true), radioButtonName + " was not selected after clicking");
        }
    }
}