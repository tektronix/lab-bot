namespace AwgTestFramework
{
    class AwgFileAndUtilitiesWindowFunctions
    {
        // Perry Hunter 06/10/2013
        /// <summary>Selects the Default button in the AWG main window and sets UI context to the top level</summary>
        /// <summary>PREREQUISITE: File & Utilities tab is selected</summary>
        /// <param name=""></param>
        public static void SelectTheDefaultSetupButton()
        {
            //Find and select the button
            AwgButtonControls.SelectAFileAndUtilsButton(AWGUI.DefaultSetupButton);

            //Wait for the "progress" dialog to clear
            AwgUiMainWindowFunctions.WaitForProgressDialogToComplete();

            //Set the UI context to the top level to reflect the now-reset UI state
            AwgContextFunctions.SetContextToTopLevel();
        }
    }
}
