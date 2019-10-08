/*using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Diagnostics;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems;
using TestStack.White.WindowsAPI;


namespace AwgTestFramework
{
  /// <summary>
  /// This class contains methods for selecting a ComboBox in the UI
  /// </summary>
  [TechTalk.SpecFlow.Binding] //Very important! This entry needs to be made in each step definition file. 
  public class AwgComboBoxSteps : AWG
  {
    private UTILS UtilsSteps = new UTILS();


    // Unkown 01/01/01
    /// <summary>
    /// Selects an item in the combo box
    /// </summary>
    /// <param name="combobox">The automation ID of the combo box being selected</param>
    /// <param name="item">The item in the combo box to select</param>
    /*!
        \AWGComboBox\verbatim
    [When(@"I select the (.*) Combo Box item (.*)")]
        \endverbatim 
    #1#
    [When(@"I select the (.*) Combo Box item (.*)")]
    public void WhenISelectTheComboBox(string combobox, int item)
    {

/*      try
      {

        AWGUI.Combobox = AWGUI.window.Get<WPFComboBox>(SearchCriteria.ByAutomationId(combobox));

        Assert.IsNotNull(AWGUI.Combobox, "combobox is not found");

        AWGUI.Combobox.Focus();

        AWGUI.Combobox.Click();

         UtilsSteps.Delay(2);

        //AWGUI.Combobox.Items[item].Select(); In the latest UI where the combo box is modified this sentence does not work.

         AWGUI.Combobox.Items[item].Click(); //Click function works with the latest UI. Hence I have changed to Click()

        AWGUI.Combobox.KeyIn(KeyboardInput.SpecialKeys.RETURN);


      }
      catch (NullReferenceException n)
      {

        Console.WriteLine(n.Message);
        throw new Exception("Could not find the combo box " + combobox);
      }#1#

    }
  }

}*/