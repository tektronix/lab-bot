using TechTalk.SpecFlow;

namespace AwgTestFramework
{
    [TechTalk.SpecFlow.Binding] //Very important! This entry needs to be made in each step definition file. 

    public class AwgUiMainWindowSteps
    {           
        #region Buttons

        // PWH 06/10/2013
        /// <summary>(AwgUIMainWindowSteps) Selects the Play button in the main window.</summary>
        /// <summary>PREREQUISITE: Top level UI context, result of default setup </summary>
        /// <param name=""></param>
        /*! \verbatim [When(@"I select the Play button")] \endverbatim */
        [When(@"I select the Play button")]
        public void WhenISelectThePlayButton()
        {
            AwgUiMainWindowFunctions.SelectThePlayButton();
        }

        // PWH 06/10/2013
        /// <summary>Selects the "AWG" button in the main window</summary>
        /// <summary>PREREQUISITE: Top level UI context, result of default setup </summary>
        /// <param name=""></param>
        /*! \verbatim [When(@"I select the AWG button")] \endverbatim */
        [When(@"I select the AWG button")]
        public void WhenISelectTheAWGButton()
        {
            AwgUiMainWindowFunctions.SelectTheAWGButton();
        }

        // PWH 06/10/2013
        /// <summary>Selects the "Functions" button in the main window</summary>
        /// <summary>PREREQUISITE: Top level UI context, result of default setup </summary>
        /// <param name=""></param>
        /*! \verbatim [When(@"I select the Functions button")] \endverbatim */
        [When(@"I select the Functions button")]
        public void WhenISelectTheFunctionsButton()
        {
            AwgUiMainWindowFunctions.SelectTheFunctionsButton();
        }

        // PWH 07/11/13
        /// <summary>Tests the Selected state of the AWG radio button</summary>
        /// <summary>PREREQUISITE: Top level UI context, result of default setup </summary>
        /// <param name=""></param>
        /*! \verbatim [Then(@"the AWG button (should|should not) be selected")] \endverbatim */
        [Then(@"the (AWG|Functions) button (should|should not) be selected")]
        public static void TheModeRadioButtonShouldBe(string controlName, string expectedState)
        {
            AwgUiMainWindowFunctions.ModeRadioButtonShouldBe(controlName, expectedState);
        }

        #endregion

        #region Tabs

        // PWH 06/10/2013
        /// <summary>Selects the "File & Utilities" tab in the main window</summary>
        /// <summary>PREREQUISITE: Top level UI context, result of default setup </summary>
        /// <param name=""></param>
        /*! \verbatim [When(@"I select the File & Utilities tab")] \endverbatim */
        [When(@"I select the File & Utilities tab")]
        public void WhenISelectTheFileAndUtilitiesTab()
        {
            AwgUiMainWindowFunctions.SelectTheFileAndUtilitiesTab();
        }

        // PWH 06/10/2013
        /// <summary>Selects the Setup tab in the main window</summary>
        /// <summary>PREREQUISITE: Top level UI context, result of default setup </summary>
        /// <param name=""></param>
        /*! \verbatim [When(@"I select the Setup tab")] \endverbatim */
        [When(@"I select the Setup tab")]
        public void WhenISelectTheSetupTab()
        {
            AwgUiMainWindowFunctions.SelectTheSetupTab();
        }

        // PWH 06/11/2013
        /// <summary>Selects the Home tab in either the AWG or Functions mode windows</summary>
        /// <summary>PREREQUISITE: AWG mode or Functions mode UI context, result of selecting either "AWG" or "Functions" radiobutton. </summary>
        /// <summary>Also available from Top level UI context since AWG mode is the result of a default setup or reset</summary>
        /// <param name=""></param>        
        /*! \verbatim [When(@"I select the Home tab")] \endverbatim */
        [When(@"I select the Home tab")]
        public void WhenISelectTheHomeTab()
        {
            AwgUiMainWindowFunctions.SelectTheHomeTab();
        }

        #endregion
    }
}