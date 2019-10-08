/*using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White.WindowsAPI; 

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains steps to get/set/compare %AWG channel and marker amplitudes
    /// </summary>
    [TechTalk.SpecFlow.Binding] //Very important! This entry needs to be made in each step definition file. 
    public class AwgSteps : AWG
    {
        private AwgUiMainWindowSteps _awgUiMainWindowStepsSteps = new AwgUiMainWindowSteps();
        private AwgTabControlSteps awgtabcontrolsteps = new AwgTabControlSteps();
        private AwgEditBoxSteps awgeditboxsteps = new AwgEditBoxSteps();
        private AwgComboBoxSteps awgcomboboxsteps = new AwgComboBoxSteps();

        // Unkown 01/01/01
        /// <summary>
        /// Sets the amplitude value for a channel on an %AWG 
        /// </summary>
        /// <param name="awgNumber">The %AWG to set the amplitude on</param>
        /// <param name="channel">The channel to set the amplitude on</param>
        /// <param name="amplvalue">The value to set the channel amplitude to</param>
        /*!
        \AWG\verbatim
        [When(@"I set the AWG([1-4]) channel ([1-4]) amplitude value to (.*)")]
        \endverbatim 
        #1#
        [When(@"I set the AWG([1-4]) channel ([1-4]) amplitude value to (.*)")]
        public void WhenISetTheAWGChannelAmplitudeValueTo(string awgNumber, string channel, string amplvalue)
        {
/*
            //ScenarioContext.Current.Pending();
            int index = AWG.AWGNumString2Index(awgNumber);
            AWG awg = AwgSetupSteps.GetAWG(index);
            _awgUiMainWindowStepsSteps.WhenISelectTheSetupButton(AWGUI.SetupTab);
            //  AwgUI_MainMenu_Low.WhenISelectTheRadioButton(UI_MainMenu.FGenButton);
            //TOdo: We have to uncomment the above code when the same automation ID is assigned to the Functios button in
            //todo: different pages.
            switch (channel)
            {
                case "1":
                    {
                        awgtabcontrolsteps.IGoToTheAWGTab(AWGUI.AwgChannel1Tab);
                        awgeditboxsteps.WhenIselecttheeditcontrol(AWGUI.AwgCh1AmplitudeEditbox);
                        awgeditboxsteps.WhenIenter(amplvalue);
                        //Ask vikas ??? try adding the enter key
                        // FunctionGeneratorSteps.window.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
                        AWGUI.window.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
                    }
                    break;
                case "2":
                    {
                        awgtabcontrolsteps.IGoToTheAWGTab(AWGUI.AwgChannel2Tab);
                        awgeditboxsteps.WhenIselecttheeditcontrol(AWGUI.AwgCh1AmplitudeEditbox);
                        awgeditboxsteps.WhenIenter(amplvalue);
                        // fgencontrols.button.Click();
                        AWGUI.window.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
                        AWGUI.window.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
                    }
                    break;
                default:
                    Assert.Inconclusive("The requested channel number " + channel +
                                        " has not been implemented on the AWG");
                    break;
            }
#1#
        }

        // Unkown 01/01/01
        /// <summary>
        /// Gets the channel amplitude value on an %AWG 
        /// </summary>
        /// <param name="awgNumber">The %AWG to get the value from</param>
        /// <param name="channel">The channel to get the value from </param>
        /*!
        \AWG\verbatim
    [When(@"I get the AWG([1-4]) channel ([1-4]) amplitude value")]
        \endverbatim 
    #1#
        [When(@"I get the AWG([1-4]) channel ([1-4]) amplitude value")]
        public void WhenIGetTheAWGChannelAmplitudeValue(string awgNumber, string channel)
        {
            /#1#/ScenarioContext.Current.Pending();
            _awgUiMainWindowStepsSteps.WhenISelectTheSetupButton(AWGUI.SetupTab);
            switch (channel)
            {
                case "1":
                    {
                        awgtabcontrolsteps.IGoToTheAWGTab(AWGUI.AwgChannel1Tab);
                        awgeditboxsteps.WhenIReadTheValueForTheEditcontrol(AWGUI.AwgCh1AmplitudeEditbox);
                    }
                    break;
                case "2":
                    {
                        awgtabcontrolsteps.IGoToTheAWGTab(AWGUI.AwgChannel2Tab);
                        awgeditboxsteps.WhenIReadTheValueForTheEditcontrol(AWGUI.AwgCh2AmplitudeEditbox);
                    }
                    break;
                default:
                    Assert.Inconclusive("The requested channel number " + channel +
                                        " has not been implemented on the AWG");
                    break;
            }#1#
        }

        // Unkown 01/01/01
        /// <summary>
        /// Compares the channel amplitude value on an %AWG channel with the expected value and checks if they are equal
        /// </summary>
        /// <param name="awgNumber">The %AWG to compare the amplitude on</param>
        /// <param name="channel">The channel to compare the aplitude on</param>
        /// <param name="expectedvalue">The expected value of the amplitude</param>
        /*!
        \AWG\verbatim
    [Then(@"the AWG([1-4]) channel ([1-4]) amplitude value should be (.*)")]
        \endverbatim 
    #1#
        [Then(@"the AWG([1-4]) channel ([1-4]) amplitude value should be (.*)")]
        public void ThenTheAWGChannelAmplitudeValueShouldBe(string awgNumber, string channel, string expectedvalue)
        {
            awgeditboxsteps.ThenTheValueForTheEditcontrolShouldBe(AWGUI.AwgCh1AmplitudeEditbox, expectedvalue);
        }

        // Unkown 01/01/01
        /// <summary>
        /// Sets the marker amplitude value for a channel on an %AWG
        /// </summary>
        /// <param name="awgNumber">The %AWG to set the marker amplitude on</param>
        /// <param name="channel">The channel to set the marker amplitude on</param>
        /// <param name="amplvalue">The value that the marker amplitude will be set to</param>
        /// 
        /*!
        \AWG\verbatim
    [When(@"I set the AWG([1-4]) channel (.*) Marker amplitude value to (.*)")]
        \endverbatim 
    #1#
        [When(@"I set the AWG([1-4]) channel (.*) Marker amplitude value to (.*)")]
        public void WhenISetTheAwgChannelMarkerAmplitudeValueTo(string awgNumber, string channel, string amplvalue)
        {
/*
            //ScenarioContext.Current.Pending();
            int index = AWG.AWGNumString2Index(awgNumber);
            AWG awg = AwgSetupSteps.GetAWG(index);
            _awgUiMainWindowStepsSteps.WhenISelectTheSetupButton(AWGUI.SetupTab);
            //  AwgUI_MainMenu_Low.WhenISelectTheRadioButton(UI_MainMenu.FGenButton);
            //TOdo: We have to uncomment the above code when the same automation ID is assigned to the Functios button in
            //todo: different pages.
            switch (channel)
            {
                case "1":
                    {
                        awgtabcontrolsteps.IGoToTheAWGTab(AWGUI.AwgChannel1Tab);
                        awgeditboxsteps.WhenIselecttheeditcontrol(AWGUI.AwgCh1MarkerEditbox);
                        awgeditboxsteps.WhenIenter(amplvalue);
                        //Ask vikas ??? try adding the enter key
                        // FunctionGeneratorSteps.window.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
                        AWGUI.window.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
                    }
                    break;
                case "2":
                    {
                        awgtabcontrolsteps.IGoToTheAWGTab(AWGUI.AwgChannel2Tab);
                        awgeditboxsteps.WhenIselecttheeditcontrol(AWGUI.AwgCh2MarkerEditbox);
                        awgeditboxsteps.WhenIenter(amplvalue);
                        // fgencontrols.button.Click();
                        AWGUI.window.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
                        AWGUI.window.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
                    }
                    break;
                default:
                    Assert.Inconclusive("The requested channel number " + channel +
                                        " has not been implemented on the AWG");
                    break;
            }
#1#
        }

        // Unknown 01/01/01
        /// <summary>
        /// Gets the marker amplitude for a channel on an %AWG
        /// </summary>
        /// <param name="awgNumber">The %AWG to get the marker value from</param>
        /// <param name="channel">The channel to get the marker value from</param>
        /*!
        \AWG\verbatim
    [When(@"I get the AWG([1-4]) channel (.*) Marker amplitude value")]
        \endverbatim 
    #1#
        [When(@"I get the AWG([1-4]) channel (.*) Marker amplitude value")]
        public void WhenIGetTheAWGChannelMarkerAmplitudeValue(string awgNumber, string channel)
        {
/*            //ScenarioContext.Current.Pending();
            _awgUiMainWindowStepsSteps.WhenISelectTheSetupButton(AWGUI.SetupTab);
            switch (channel)
            {
                case "1":
                    {
                        awgtabcontrolsteps.IGoToTheAWGTab(AWGUI.AwgChannel1Tab);
                        awgeditboxsteps.WhenIReadTheValueForTheEditcontrol(AWGUI.AwgCh1MarkerEditbox);
                    }
                    break;
                case "2":
                    {
                        awgtabcontrolsteps.IGoToTheAWGTab(AWGUI.AwgChannel2Tab);
                        awgeditboxsteps.WhenIReadTheValueForTheEditcontrol(AWGUI.AwgCh2MarkerEditbox);
                    }
                    break;
                default:
                    Assert.Inconclusive("The requested channel number " + channel +
                                        " has not been implemented on the AWG");
                    break;
            }#1#
        }

        // Unkown 01/01/01
        /// <summary>
        /// Compares the marker amplitude value on an %AWG channel with the expected value and checks if they are equal
        /// </summary>
        /// <param name="awgNumber">The %AWG to compare the marker amplitude on</param>
        /// <param name="channel">The channel to compare the marker amplitude on</param>
        /// <param name="expectedvalue">The expected value of the marker amplitude</param>
        /*!
        \AWG\verbatim
    [Then(@"the AWG([1-4]) channel (.*) Marker amplitude value should be (.*)")]
        \endverbatim 
    #1#
        [Then(@"the AWG([1-4]) channel (.*) Marker amplitude value should be (.*)")]
        public void ThenTheAWGChannelMarkerAmplitudeValueShouldBe(string awgNumber, string channel, string expectedvalue)
        {
           // awgeditboxsteps.ThenTheValueForTheEditcontrolShouldBe(AWGUI.AwgCh2MarkerEditbox, expectedvalue);
        }

        // Unkown 01/01/01
        /// <summary>
        /// Sets the AWG1 DAC Resolution Value for a channel on an %AWG
        /// </summary>
        /// <param name="awgNumber">The %AWG to set the DAC resolution on</param>
        /// <param name="channel">The channel to set the DAC resolution on</param>
        /// <param name="dac_resolution">The dac resolution value to set to</param>
        /*!
        \AWG\verbatim
    [When(@"I Set the AWG([1-4]) DAC Resolution Value for channel ([1-4]) to (.*) bits")]
        \endverbatim 
    #1#
        [When(@"I Set the AWG([1-4]) DAC Resolution Value for channel ([1-4]) to (.*) bits")]
        public void WhenISetTheDACResolutionvalueTo(string awgNumber, string channel, string dac_resolution)
        {
/*            _awgUiMainWindowStepsSteps.WhenISelectTheSetupButton(AWGUI.SetupTab);
            int item = 0;
            switch (dac_resolution)
            {
                case "10":
                    item = 0;
                    break;
                case "8":
                    item = 1;
                    break;
                default:
                    Assert.Inconclusive("The requested dac resolution " + dac_resolution +
                                        " has not been implemented on the AWG");
                    break;
            }
            switch (channel)
            {
                case "1":
                    {
                        awgtabcontrolsteps.IGoToTheAWGTab(AWGUI.AwgChannel1Tab);
                        awgcomboboxsteps.WhenISelectTheComboBox(AWGUI.AwgDacResolution, item);
                    }
                    break;
                case "2":
                    {
                        awgtabcontrolsteps.IGoToTheAWGTab(AWGUI.AwgChannel2Tab);
                        awgcomboboxsteps.WhenISelectTheComboBox(AWGUI.AwgDacResolution, item);
                    }
                    break;
                default:
                    {
                        Assert.Inconclusive("The requested channel number " + channel +
                                            " has not been implemented on the AWG");
                    }
                    break;
            }#1#
        }
    }
}*/