/*using TechTalk.SpecFlow;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems;
using Window = TestStack.White.UIItems.WindowItems.Window;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains methods for selecting a RadioButon in the UI
    /// </summary>
    [TechTalk.SpecFlow.Binding] //Very important! This entry needs to be made in each step definition file. 
    public class AwgRadioButtonSteps
    {
        private UTILS _utilsFunctions = new UTILS();

        // Unkown 01/01/01
        /// <summary>
        /// Selects a Radio Button in the UI
        /// </summary>
        /// <param name="AWGRadioButton">The Automation ID of the RadioButton being selected</param>
        /*!
        \AWGRadioButton\verbatim
        [When(@"I select the (.*) Radio Button")]
        \endverbatim 
        #1#
        [When(@"I select the (.*) Radio Button")]
        public void WhenISelectTheRadioButton(string AWGRadioButton)
        {
/*
            AWG _awg = AwgSetupSteps.GetAWG(AwgSetupSteps.AWGNumString2Index("1"));
            _awg.DiagComment("Selecting the " + AWGRadioButton + " RADIOBUTTON");

            try
            {
                AWGUI.Radiobutton = AWGUI.window.Get<RadioButton>(SearchCriteria.ByAutomationId(AWGRadioButton));
                _utilsFunctions.Delay(3);
                Assert.IsNotNull(AWGUI.Radiobutton, "Radiobutton is not found");
                AWGUI.Radiobutton.Click();
            }
            catch (Exception n)
            {
                Console.WriteLine(n.Message);
                throw new Exception("Could not find the radio button " + AWGRadioButton);
            }
#1#
        }

        // Unkown 01/01/01
        /// <summary>
        /// Checks to see if a RadioButton is enabled or not
        /// </summary>
        /// <param name="radiobutton">The Automation ID of the RadioButton being selected</param>
        /// <param name="state">The (enabled|disabled) state of the button</param>
        /*!
          \AWGRadioButton\verbatim
        [Then(@"the (.*) radio button should be (enabled|disabled)")]
          \endverbatim 
        #1#
        [Then(@"the (.*) radio button should be (enabled|disabled)")]
        public void ThenTheRadioButtonInTheApplicationShouldBeEnabled(string radiobutton, string state)
        {
/*
            try
            {
                AWGUI.Radiobutton = AWGUI.window.Get<RadioButton>((radiobutton));
                Assert.IsNotNull(AWGUI.Radiobutton, "RadioButton is not found");
                bool wantEnabled = ("enabled" == state);
                bool isEnabled = AWGUI.Radiobutton.Enabled;
                if (isEnabled != wantEnabled)
                {
                    throw new Exception("Expected" + radiobutton + " button to be " + state);
                }
            }
            catch (NullReferenceException n)
            {
                Console.WriteLine(n.Message);
                throw new Exception("Could not find the radiobutton " + radiobutton);
            }
#1#
        }

        // Unkown 01/01/01
        /// <summary>
        /// Checks to see if a RadioButton is checked or not
        /// </summary>
        /// <param name="radiobutton">The RadioButton being selected</param>
        /// <param name="state">The (checked|unchecked) state of the button</param>
        /*!
          \AWGRadioButton\verbatim
        [Then(@"the (.*) radio button should be (checked|unchecked)")]
          \endverbatim 
        #1#
        [Then(@"the (.*) radio button should be (checked|unchecked)")]
        public void TheRadioButtonShouldBeChecked(string radiobutton, string state)
        {
/*
            AWGUI.Radiobutton = AWGUI.window.Get<RadioButton>((radiobutton));
            Assert.IsNotNull(AWGUI.Radiobutton, "RadioButton is not found");
            bool wantChecked = ("checked" == state);
            bool isChecked = AWGUI.Radiobutton.IsSelected;
            if (isChecked != wantChecked)
            {
                throw new Exception("Expected" + radiobutton + " button to be " + state);
            }
#1#
        }
    }
}*/