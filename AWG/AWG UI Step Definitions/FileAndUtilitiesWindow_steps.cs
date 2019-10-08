using TechTalk.SpecFlow;

namespace AwgTestFramework
{
    [TechTalk.SpecFlow.Binding] //Very important! This entry needs to be made in each step definition file. 

    public class AwgFileAndUtilitiesWindow_steps
    {
        // PerryH 07/11/2013
        /// <summary>Selects the Default Setup button in the File & Utilities window</summary>
        /// <summary>Prerequisites: The File and Utilities tab must be selected first</summary>
        /// <param name=""">"></param>
        /*!\verbatim [When(@"I select the Default Setup button")] \endverbatim */
        [When(@"I select the Default Setup button")]
        public static void WhenISelectTheDefaultSetupButton()
        {
            AwgFileAndUtilitiesWindowFunctions.SelectTheDefaultSetupButton();
        }

    }
}
