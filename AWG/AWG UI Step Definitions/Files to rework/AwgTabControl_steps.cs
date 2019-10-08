/*using System.Diagnostics;
using TechTalk.SpecFlow;
using System;
using TestStack.White.UIItems.TabItems;
using TestStack.White.UIItems.Finders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White.Factory;
using System.Timers;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains methods for selecting a Tab in the UI
    /// </summary>
    [TechTalk.SpecFlow.Binding] //Very important! This entry needs to be made in each step definition file. 
    public class AwgTabControlSteps
    {
        private UTILS UtilSteps = new UTILS();

        // Unkown 01/01/01
        /// <summary>
        /// Selects a Tab in FGen Mode
        /// </summary>
        /// <param name="name">The automation ID of he tab being selected</param>
        /*!
        \AWGTabControl\verbatim
        [When("^I go to the (.+) tab")]
        \endverbatim 
        #1#
        [When(@"I go to the (.+) tab")]
        public void IGoToTheTab(string tabName)
        {
/*
            TabPage channelTab = AwgSetupSteps.awgMainWindow.Get<TabPage>(SearchCriteria.ByAutomationId(tabName));
            int count = 0;
            while (count <= 10)
            {
                UtilSteps.Delay(0.25);
                channelTab = AwgSetupSteps.awgMainWindow.Get<TabPage>(SearchCriteria.ByAutomationId(tabName));
                if (channelTab == null)
                {
                    channelTab = AwgSetupSteps.awgMainWindow.Get<TabPage>(SearchCriteria.ByAutomationId(tabName));
                    Console.WriteLine("Channel Tab is not found " + tabName);
                }
                else
                {
                    Console.WriteLine("Channel Tab is found " + tabName);
                    break;
                }
                count = count + 1;
                if (count == 11)
                {
                    Assert.IsNotNull(channelTab, tabName + " Tab Control is not found");
                }
            }
            Assert.IsNotNull(channelTab, tabName + " Tab Control is not found");
            channelTab.Click();
            channelTab.Select();
#1#
        }

        // Unkown 01/01/01
        /// <summary>
        /// Selects a tab on the AWG
        /// </summary>
        /// <param name="name">The name of the tab being searched for</param>
        /*!
        \AWGTabControl\verbatim
    [When(@"^I go to the AWG (.+) tab")]
        \endverbatim 
    #1#
        [When(@"^I go to the AWG (.+) tab")]
        public void IGoToTheAWGTab(string name)
        {
/*
            Console.WriteLine("Searching for '" + name + "' tab");
            try
            {
                TabPage channelTab = AwgSetupSteps.awgMainWindow.Get<TabPage>(SearchCriteria.ByText(name));
                if (channelTab == null)
                {
                    UtilSteps.Delay(5);
                    channelTab = AwgSetupSteps.awgMainWindow.Get<TabPage>(SearchCriteria.ByAutomationId(name));
                }
                else
                {
                    Console.WriteLine(("Channel Tab is found " + name));
                }
                Assert.IsNotNull(channelTab, name + " Tab Control is not found");
                channelTab.Click();
            }
            catch (System.Exception excep)
            {
                Console.WriteLine(excep.Message);
            }
#1#
        }
    }
}*/