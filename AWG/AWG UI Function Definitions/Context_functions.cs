using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using System;

namespace AwgTestFramework
{
    public class AwgContextFunctions
    {

        public static void SetContextToTopLevel()
        {
            if (AwgSetupSteps.IgnoreUi) return;

            IAWG awg = AwgSetupSteps.GetAWG("1");

            //Attach to the AWG70k.exe process - NOTE: This is the ONLY place we want to do this! Everywhere else, we reference AwgSetupSteps.awgApplication
            AWGUI.currentApplication = Application.Attach(AWGUI.ProcessName);
            Assert.IsNotNull(AWGUI.currentApplication, "The AWG application was not found");

            //Find the AWG Main window - NOTE: This is the ONLY place we want to do this! Everywhere else, we reference AwgSetupSteps.awgMainWindow
            string processName = AWGUI.ProcessName;

            //Sharmila - 01/04/2015
            //If SX is running in the PC, the main window name will be sourceXpress
            string mainWindowName;
            if (processName == "SX")
                mainWindowName = "SourceXpress™";
            else if (processName == "AWG70K")
                mainWindowName = awg.ModelString;
            else
                throw new Exception("Process Name is not recognized");


            AWGUI.currentMainWindow = AWGUI.currentApplication.GetWindow(mainWindowName);
            Assert.IsNotNull(AWGUI.currentMainWindow, "The AWG Main Window was not found");
        }

        public static void SetContextToAwgMode()
        {
            //Set the currentUIParentContainer accessor to the AWG home window
            AWGUI.currentUIParentPanel = (Panel)AWGUI.currentMainWindow.Get(SearchCriteria.ByAutomationId(AWGUI.MainControlContainer));
            Assert.IsNotNull(AWGUI.currentUIParentPanel);

            //Set the currentUIChildContainer accessor to the AwgWindow.
            AWGUI.currentUIChildPanel = (Panel)AWGUI.currentUIParentPanel.Get(SearchCriteria.ByAutomationId(AWGUI.AWGHomeWindow));
            Assert.IsNotNull(AWGUI.currentUIChildPanel);
        }

        public static void SetContextToFGenMode()
        {
            //Set the currentUIParentContainer accessor to the FGen home window
            AWGUI.currentUIParentPanel = (Panel)AWGUI.currentMainWindow.Get(SearchCriteria.ByAutomationId(AWGUI.MainControlContainer));
            Assert.IsNotNull(AWGUI.currentUIParentPanel);

            //Set the currentUIChildContainer accessor to the FGenWindow.
            AWGUI.currentUIChildPanel = (Panel)AWGUI.currentUIParentPanel.Get(SearchCriteria.ByAutomationId(AWGUI.FGHomeWindow));
            Assert.IsNotNull(AWGUI.currentUIChildPanel);
        }

        public static void SetContextToFileAndUtilities()
        {
            //Set the currentUIChildContainer accessor to the FileUtilitiesWindow
            AWGUI.currentUIChildPanel = (Panel)AWGUI.currentUIParentPanel.Get(SearchCriteria.ByAutomationId(AWGUI.FileAndUtilitiesWindow));
            Assert.IsNotNull(AWGUI.currentUIChildPanel);
        }

        public static void SetContextToSelectedFGenChannel()
        {
            //Set currentUIControlPanel to reference from CH1 pane
            AWGUI.currentUIControlPanel = (Panel)AWGUI.currentUIChildPanel.Get(SearchCriteria.ByAutomationId(AWGUI.FGScrollViewerPane));
            Assert.IsNotNull(AWGUI.currentUIControlPanel);
        }

    }
}
