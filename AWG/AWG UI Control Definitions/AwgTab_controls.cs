using Microsoft.VisualStudio.TestTools.UnitTesting;

using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

using Application = TestStack.White.Application;
using Window = TestStack.White.UIItems.WindowItems.Window;


namespace AwgTestFramework
{
// ReSharper disable InconsistentNaming
    public class AwgUITabControls
// ReSharper restore InconsistentNaming
    {
        //private UTILS _utils = new UTILS();

        // Perry Hunter 06/10/2013
        ///<summary>Selects the specified tab in the AWG Main Window</summary>
        /// <summary>PREREQUISITE: AWG mode is selected</summary>
        ///<param name="tabName">The AutomationID (name) of the tab to select</param>       
        public static void SelectMainTabControl(string tabName)
        {
            if (AwgSetupSteps.IgnoreUi) return;

            IAWG awg = AwgSetupSteps.GetAWG("1");
            //awg.DiagComment("Selecting the " + tabName + " tab control in " + awg.ModelString + " window");

            //Find the AWG application
            Application application = Application.Attach(AWGUI.ProcessName);
            Assert.IsNotNull(application);

            //Find the main window by it's AutomationID
            Window window = application.GetWindow(awg.ModelString);
            Assert.IsNotNull(window);

            //Find the requested tab by it's AutomationID (in WPF, this is name property)
            var panelMain = (Panel) window.Get(SearchCriteria.ByAutomationId("containerMain"));
            Assert.IsNotNull(panelMain);

            //Our tab isn't really a tab. It's a panel contro
            var tab = (Panel) panelMain.Get(SearchCriteria.ByAutomationId(tabName));
            Assert.IsNotNull(tab);

            //Check the IsEnabled property
            Assert.IsTrue(tab.Enabled.Equals(true), tabName + " was not enabled, could not select when requested");

            //Click it
            tab.Click();
        }

    }
}
