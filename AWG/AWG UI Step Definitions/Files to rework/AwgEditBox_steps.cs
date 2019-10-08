/*using TechTalk.SpecFlow;
using System;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems;
using TestStack.White.WindowsAPI;
using SpecialKeysCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains steps to simulate using the Edit Control in the UI
    /// </summary>
    [TechTalk.SpecFlow.Binding] //Very important! This entry needs to be made in each step definition file. 
    public class AwgEditBoxSteps
    {
        private UTILS utilsfunctions = new UTILS();

        // Unknown 01/01/01
        /// <summary>
        /// Selects an edit box control
        /// </summary>
        /// <param name="editcontrol"></param>
        /*!
        \AWGEditBox\verbatim
        [When(@"I select the edit control ([A-Za-z0-9 _]+)")]
        \endverbatim 
         #1#
        [When(@"I select the edit control ([A-Za-z0-9 _]+)")]
        public void WhenIselecttheeditcontrol(String editcontrol)
        {
/*            try
            {
                bool numlockcheck = true;
                numlockcheck = NumLockCheck.IsKeyPressed(NumLockCheck.VirtualKeyStates.VK_NUMLOCk);
                if (numlockcheck != true)
                {
                }
                else
                {
                    AwgSetupSteps.awgMainWindow.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.NUMLOCK);
                }
                AWGUI.numCh = (UIItem)AwgSetupSteps.awgMainWindow.Get(SearchCriteria.ByAutomationId(editcontrol));
                Assert.IsNotNull(AWGUI.numCh, "Edit Control is not found");
                AWGUI.numCh.Click();
                utilsfunctions.Delay(5);
            }
            catch (NullReferenceException n)
            {
                Console.WriteLine(n.Message);
                System.Windows.Forms.MessageBox.Show("Edit Control not found " + editcontrol);
            }
 #1#
        }

        // Unknown 01/01/01
        /// <summary>
        /// Enteres a value into the edit control
        /// </summary>
        /// <param name="editvalue"></param>
        /*!
        \AWGEditBox\verbatim
        [When(@"I enter the value (.*)")]
        \endverbatim 
         #1#
        [When(@"I enter the value (.*)")]
        public void WhenIenter(String editvalue)
        {
 /*           //TODO: implement act (action) logic
            try
            {
                AWGUI.numCh.Click();
                AWGUI.numCh.Enter(editvalue);
                utilsfunctions.Delay(1);
            }
            catch (NullReferenceException n)
            {
                Console.WriteLine(n.Message);
                throw new Exception("Could not enter the value in the edit control" + editvalue);
            }
  #1#
        }

        // Unknown 01/01/01
        /// <summary>
        /// Gets a value from the edit control
        /// </summary>
        /// <param name="editcontrol"></param>
        /*!
            \AWGEditBox\verbatim
        [When(@"I read the value for the edit control (.*)")]
            \endverbatim 
         #1#
        [When(@"I read the value for the edit control (.*)")]
        public void WhenIReadTheValueForTheEditcontrol(string editcontrol)
        {
/*            try
            {
                AWGUI.edit_box_read_value = AWGUI.window.Get<TextBox>(editcontrol);
                Assert.IsNotNull(AWGUI.edit_box_read_value, "Requested Edit Control is not found");

                // Read the contents of the current edit box
                String edit_box_value = AWGUI.edit_box_read_value.Text;
            }

            catch (NullReferenceException n)
            {
                throw new Exception("A null reference exception was caught, message was: " + n.Message);
            }
 #1#
        }

        /// <summary>
        /// Compares a value with what is in the edit control
        /// </summary>
        /// <param name="editcontrol"></param>
        /// <param name="expectedvalue"></param>
        /*!
            \AWGEditBox\verbatim
        [Then(@"the value for the edit control (.*) should be (.*) expected value")]
            \endverbatim 
         #1#
        [Then(@"the value for the edit control (.*) should be (.*) expected value")]
        public void ThenTheValueForTheEditcontrolShouldBe(string editControl, string expectedValue)
        {
/*            String edit_box_value = AWGUI.edit_box_read_value.Text;

            if (edit_box_value != expectedValue)
            {
                Assert.AreEqual(expectedValue, edit_box_value);
            }
 #1#
        }
    }
} */