using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

using RadioButton = TestStack.White.UIItems.RadioButton;
using Window = TestStack.White.UIItems.WindowItems.Window;

namespace AwgTestFramework
{    
    public class AwgUiMainWindowFunctions
    {
        #region Buttons
        // Perry Hunter 07/10/2013
        /// <summary>
        /// Selects the Play button in the AWG main window
        /// </summary>
        /// <param name="PlayButton">The constant defined in UI map for the Play button</param>
        public static void SelectThePlayButton()
        {
            AwgButtonControls.SelectAMainWindowButton(AWGUI.PlayButton);
        }
        #endregion

        #region Tab Controls
        // Perry Hunter 07/10/2013
        /// <summary>
        /// Selects the Home tab in either the AWG or Functions mode windows
        /// </summary>
        public static void SelectTheHomeTab()
        {           
            //Check the selected state of the AWG radiobutton, that will tell which "Home" tab needs to be selected
            RadioButton _radioButton = AWGUI.currentMainWindow.Get<RadioButton>(SearchCriteria.ByAutomationId(AWGUI.AwgButton));
            Assert.IsNotNull(_radioButton, "Requested " + AWGUI.AwgButton + " radio button was not found"); //Die if you did not find it

            //Decide which Home tab to select based on the radio button IsSelected state
            string _tabName = AWGUI.AWGHomeWindow;
            if (_radioButton.IsSelected == false) _tabName = AWGUI.FGHomeWindow;

            //Select the tab
            AwgUITabControls.SelectMainTabControl(_tabName);
        }

        // Perry Hunter 07/10/2013
        /// <summary>
        /// Selects the Setup tab in the AWG main window
        /// </summary>
        /// <param name="AwgSetupTab">The constant defined in UI map for the Functions radiobutton</param>
        public static void SelectTheSetupTab()
        {
            AwgUITabControls.SelectMainTabControl(AWGUI.AwgSetupTab);
        }

        // Perry Hunter 06/10/2013
        /// <summary>
        /// Selects the File button in the AWG main window
        /// </summary>

        public static void SelectTheFileAndUtilitiesTab()
        {
            AwgContextFunctions.SetContextToTopLevel();
            AwgUITabControls.SelectMainTabControl(AWGUI.FileAndUtilitiesWindow);
            AwgContextFunctions.SetContextToFileAndUtilities();
        }
        #endregion

        #region AWG/FGen RadioButtons
        // Perry Hunter 06/10/2013
        /// <summary>
        /// Selects the AWG radio button in the AWG main window and sets UI context to that window
        /// </summary>
        /// <param name="AwgButton">The constant defined in UI map for the AWG radiobutton</param>
        public static void SelectTheAWGButton()
        {
            AwgMainRadioButtonControls.SelectMainRadioButton(AWGUI.AwgButton);
            //Kavitha
           // AwgContextFunctions.SetContextToAwgMode();
        }

        // Perry Hunter 06/10/2013
        /// <summary>
        /// Selects the Functions radio button in the AWG main window and sets UI context to that window
        /// </summary>
        /// <param name="FGenButton">The constant defined in UI map for the Functions radiobutton</param>
        public static void SelectTheFunctionsButton()
        {
            AwgMainRadioButtonControls.SelectMainRadioButton(AWGUI.FGenButton);
            //Kavitha
           // AwgContextFunctions.SetContextToFGenMode();
        }

        // Perry Hunter 07/10/2013
        /// <summary>
        /// Tests the current "IsSelected" state of the requested mode selection radio button
        /// </summary>
        /// <param name="controlName">The constant defined in UI map for the desired radio button selection</param>
        /// <param name="expectedState">The selection state the button is expected to be in</param>
        public static void ModeRadioButtonShouldBe(string controlName, string expectedState)
        {
            //Decide which radio button is desired
            string radioButtonId = AWGUI.AwgButton;
            if (controlName == "Functions") radioButtonId = AWGUI.FGenButton;

            bool expectedValue = true; //Default expectedValue is "should" (true)
            if (expectedState == "should not") expectedValue = false;

            //Find the desired button, create a local instance of the RadioButton object
            RadioButton _radioButton = AWGUI.currentMainWindow.Get<RadioButton>(SearchCriteria.ByAutomationId(radioButtonId));
            Assert.IsNotNull(_radioButton, "Requested " + controlName + " radio button was not found as " + radioButtonId); //Die if you did not find it

            //Test the _radioButton.IsSelected property against the expected value
            Assert.AreEqual(expectedValue, _radioButton.IsSelected);
        }
        #endregion

        #region Utilities and Helpers

        // Perry Hunter 07/12/2013
        /// <summary>
        /// Finds the "Progress" dialog, waits for it to close
        /// </summary>
        
        public static void WaitForProgressDialogToComplete()
        {       
            //We need only "capture" the window once, then we can query it's properties thereafter
            //This is a bit of a workaround, because the Progress dialog has neither an AutomatioID or a Text property set.
            Window _progressDialog = AWGUI.currentMainWindow.ModalWindow(AWGUI.ProgressDialog);
            Assert.IsNotNull(_progressDialog);
            
            //We watch for the window title to go null, then the dialog is gone. A better way might be to use Events...
            while (_progressDialog.Title != "")
            {
                try
                {
                    //System.Diagnostics.Trace.WriteLine("_progressDialog.Title: " + _progressDialog.Title);
                }

                catch (UIActionException ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex);
                }
                Thread.Sleep(100);//No sense beating a dead horse, come back in a little while and check again
            }
        }
        #endregion
    }
}
