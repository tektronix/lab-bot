/*using TechTalk.SpecFlow;
using TestStack.White.WindowsAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AwgTestFramework
{
    [TechTalk.SpecFlow.Binding]
    public class FunctionGeneratorSteps
    {
/*        private AwgCheckBoxSteps _awgCheckBoxSteps = new AwgCheckBoxSteps();
        private AwgUIMainWindowSteps _awgUiMainWindowStepsSteps = new AwgUIMainWindowSteps();
        private AwgTabControlSteps _awgTabControlSteps = new AwgTabControlSteps();
        private AwgRadioButtonSteps _awgRadioButtonSteps = new AwgRadioButtonSteps();
        private AwgEditBoxSteps _awgEditBoxSteps = new AwgEditBoxSteps();
 #1#

        // Unkown 01/01/01
        /// <summary>
        /// Sets the Ampl Lock Coupling Check box present in FGen Mode
        /// </summary>
        /// <param name="channel"></param>
        /*!
        \AWGFunctionGenerator\verbatim
    [When(@"I set the AWG([1-4]) FGen channel (.*) coupling state value to ON state")]
        \endverbatim 
     #1#
        [When(@"I set the AWG FGen channel ([1-4]) coupling state to ON")]
        public void WhenISetTheFGenChannelCouplingStateValue(string channel)
        {
/*          _awgUiMainWindowStepsSteps.WhenISelectTheHomeButton(AWGUI.HomeTab);
            _awgRadioButtonSteps.WhenISelectTheRadioButton(AWGUI.FGenButton);
            switch (channel)
            {
                case "1":
                    _awgTabControlSteps.IGoToTheTab(AWGUI.FGenCh1Tab);
                    break;
                case "2":
                    _awgTabControlSteps.IGoToTheTab(AWGUI.FGenCh2Tab);
                    break;
                default:
                    Assert.Inconclusive("The requested channel number " + channel +
                                        " has not been implemented on the AWG");
                    break;
            }
            _awgCheckBoxSteps.WhenISelectTheCheckBox(AWGUI.FGenChannelLockCheckBox);
 #1#
        }

        // Unkown 01/01/01
        /// <summary>
        /// Sets the desired waveform type in the selected channel of the Function Generator
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="waveform"></param>
        /*!
        \AWGFunctionGenerator\verbatim
    [When(@"I set the AWG([1-4]) FGen channel (.*) to the waveform (.*)")]
        \endverbatim 
     #1#
        [When(@"I set the AWG FGen channel ([1-4]) to the waveform (.*)")]
        public void WhenISetFGenChannelToAWaveform(string channel, string waveform)
        {
/*            _awgUiMainWindowStepsSteps.WhenISelectTheHomeButton(AWGUI.HomeTab);
            _awgRadioButtonSteps.WhenISelectTheRadioButton(AWGUI.FGenButton);
            //_utilsFunctions.Delay(3);

            switch (channel)
            {
                case "1":
                    _awgTabControlSteps.IGoToTheTab(AWGUI.FGenCh1Tab);
                    break;
                case "2":
                    _awgTabControlSteps.IGoToTheTab(AWGUI.FGenCh2Tab);
                    break;
                default:
                    Assert.Inconclusive("The requested channel number " + channel +
                                        " has not been implemented on the AWG");
                    break;
            }
            switch (waveform)
            {
                case "SINE":
                    _awgRadioButtonSteps.WhenISelectTheRadioButton(AWGUI.FGenCh1SineButton);
                    break;
                case "SQUARE":
                    _awgRadioButtonSteps.WhenISelectTheRadioButton(AWGUI.FGenCh1SquareButton);
                    break;
                case "TRIANGLE":
                    _awgRadioButtonSteps.WhenISelectTheRadioButton(AWGUI.FGenCh1TriangleButton);
                    break;
                case "NOISE":
                    _awgRadioButtonSteps.WhenISelectTheRadioButton(AWGUI.FGenCh1NoiseButton);
                    break;
                case "DC":
                    _awgRadioButtonSteps.WhenISelectTheRadioButton(AWGUI.FGenCh1DCButton);
                    break;
                case "EXPRISE":
                    _awgRadioButtonSteps.WhenISelectTheRadioButton(AWGUI.FGenCh1ExpRiseButton);
                    break;
                case "EXPDECAY":
                    _awgRadioButtonSteps.WhenISelectTheRadioButton(AWGUI.FGenCh1ExpDecayButton);
                    break;
                case "GAUSSIAN":
                    _awgRadioButtonSteps.WhenISelectTheRadioButton(AWGUI.FGenCh1GaussianButton);
                    break;
                default:
                    Assert.Inconclusive("The requested waveform type " + waveform +
                                        " has not been implemented on the AWG");
                    break;
            }
            //fgentabcontrols.IGoToTheTab(AWGUI.FGenCh1Tab);
            //fgentabcontrols.IGoToTheTab(AWGUI.FGenCh2Tab);
 #1#
        }

        // Unknown 01/01/01
        /// <summary>
        /// Sets the amplitude value in the selected channel of the Function Generator
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="amplvalue"></param>
        /*!
        \AWGFunctionGenerator\verbatim
    [When(@"I set the AWG(.*) FGen channel (.*) amplitude value to (.*)")]
        \endverbatim 
        #1#
        [When(@"I set the AWG FGen channel ([1-4]) amplitude value to (.*)")]
        public void WhenISetTheAWGFunctionGeneratorChannelAmplitudeValueTo(string channel, string amplvalue)
        {
/*          _awgUiMainWindowStepsSteps.WhenISelectTheHomeButton(AWGUI.HomeTab);

            //TODO: We have to uncomment next line when the same automation ID is assigned to the Functions button in different pages.
            // AwgAWG_Low.WhenISelectTheRadioButton(AWGUI.FGenButton);

            switch (channel)
            {
                case "1":
                    {
                        _awgTabControlSteps.IGoToTheTab(AWGUI.FGenCh1Tab);
                        _awgEditBoxSteps.WhenIselecttheeditcontrol(AWGUI.FGenCh1AmplitudeEditbox);
                        _awgEditBoxSteps.WhenIenter(amplvalue);
                        //Ask vikas ??? try adding the enter key
                        // FunctionGeneratorSteps.window.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
                        AWGUI.window.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
                    }
                    break;
                case "2":
                    {
                        _awgTabControlSteps.IGoToTheTab(AWGUI.FGenCh2Tab);
                        _awgEditBoxSteps.WhenIselecttheeditcontrol(AWGUI.FGenCh2AmplitudeEditbox);
                        _awgEditBoxSteps.WhenIenter(amplvalue);
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

        //  Unknown 01/01/01
        /// <summary>
        /// Gets the amplitude value in the selected channel of the Function Generator
        /// </summary>
        /// <param name="channel"></param>
        /*!
        \AWGFunctionGenerator\verbatim
    [When(@"I get the AWG([1-4]) FGen channel(.*) amplitude value")]
        \endverbatim 
     #1#
        [When(@"I get the AWG FGen channel ([1-4]) amplitude value")]
        public void WhenIGetTheAWGFunctionGeneratorChannelAmplitudeValueTo(string awgNumber, string channel)
        {
/*
            switch (channel)
            {
                case "1":
                    {
                        _awgEditBoxSteps.WhenIReadTheValueForTheEditcontrol(AWGUI.FGenCh1AmplitudeEditbox);
                    }
                    break;
                case "2":
                    {
                        _awgEditBoxSteps.WhenIReadTheValueForTheEditcontrol(AWGUI.FGenCh2AmplitudeEditbox);
                    }
                    break;
                default:
                    Assert.Inconclusive("The requested channel number " + channel +
                                        " has not been implemented on the AWG");
                    break;
            }
#1#
        }

        //  Unkown 01/01/01
        /// <summary>
        /// Compares the amplitude value with the value set in the selected channel of the Function Generator
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="expectedvalue"></param>
        /*!
        \AWGFunctionGenerator\verbatim
    [Then(@"the AWG([1-4]) FGen channel (.*) amplitude value should be (.*)")]
        \endverbatim 
     #1#
        [Then(@"the AWG FGen channel ([1-4]) amplitude value should be (.*)")]
        public void ThenTheAWGFGenChannelAmplitudeValueShouldBe(string channel, string expectedvalue)
        {
            //_awgEditBoxSteps.ThenTheValueForTheEditcontrolShouldBe(AWGUI.FGenCh1AmplitudeEditbox, expectedvalue);
        }

        /***************************Offset control *********************************************************************************#1#

        //  Unkown 01/01/01
        /// <summary>
        /// Sets the offset value in the selected channel of the Function Generator
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="offsetvalue"></param>
        /*!
        \AWGFunctionGenerator\verbatim
    [When(@"I set the AWG(.*) FGen channel (.*) offset value to (.*)")]
        \endverbatim 
     #1#
        [When(@"I set the AWG FGen channel ([1-4]) offset value to (.*)")]
        public void WhenISetTheAWGFGenChannelOffsetValueTo(string channel, string offsetvalue)
        {
            //_awgUiMainWindowStepsSteps.WhenISelectTheHomeButton(AWGUI.HomeTab);
/*            _awgRadioButtonSteps.WhenISelectTheRadioButton(AWGUI.FGenButton);
            switch (channel)
            {
                case "1":
                    {
                        _awgTabControlSteps.IGoToTheTab(AWGUI.FGenCh1Tab);
                        _awgEditBoxSteps.WhenIselecttheeditcontrol(AWGUI.FGenCh1OffsetEditbox);
                        _awgEditBoxSteps.WhenIenter(offsetvalue);
                        AWGUI.window.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
                        AWGUI.window.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
                    }
                    break;
                case "2":
                    {
                        _awgTabControlSteps.IGoToTheTab(AWGUI.FGenCh2Tab);
                        _awgEditBoxSteps.WhenIselecttheeditcontrol(AWGUI.FGenCh2OffsetEditbox);
                        _awgEditBoxSteps.WhenIenter(offsetvalue);
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

        //  Unknown 01/01/01
        /// <summary>
        /// Gets the offset value in the selected channel of the Function Generator
        /// </summary>
        /// <param name="channel"></param>
        /*!
        \AWGFunctionGenerator\verbatim
    [When(@"I get the AWG(.*) FGen channel (.*) offset value")]
        \endverbatim 
     #1#
        [When(@"I get the AWG FGen channel ([1-4]) offset value")]
        public void WhenIGetTheAWGFGenChannelOffsetValue(string channel)
        {
            //ScenarioContext.Current.Pending();
/*
            switch (channel)
            {
                case "1":
                    {
                        _awgEditBoxSteps.WhenIReadTheValueForTheEditcontrol(AWGUI.FGenCh1OffsetEditbox);
                    }
                    break;
                case "2":
                    {
                        _awgEditBoxSteps.WhenIReadTheValueForTheEditcontrol(AWGUI.FGenCh2OffsetEditbox);
                    }
                    break;
                default:
                    Assert.Inconclusive("The requested channel number " + channel +
                                        " has not been implemented on the AWG");
                    break;
            }
#1#
        }

        //  Unknown 01/01/01
        /// <summary>
        /// Compares the set offset value with the value set in the selected channel of the Function Generator
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="expectedvalue"></param>
        /*!
        \AWGFunctionGenerator\verbatim
    [Then(@"the AWG(.*) FGen channel (.*) offset value should be (.*)")]
        \endverbatim 
     #1#
        [Then(@"the AWG FGen channel ([1-4]) offset value should be (.*)")]
        public void ThenTheAWGFGenChannelOffsetValueShouldBe(string channel, string expectedvalue)
        {
            //_awgEditBoxSteps.ThenTheValueForTheEditcontrolShouldBe(AWGUI.FGenCh1OffsetEditbox, expectedvalue);
        }

        // Unkown 01/01/01
        /// <summary>
        /// Sets the Fgen High Amplitude value for a channel
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="amplitudehighvalue"></param>
        /*!
        \AWGFunctionGenerator\verbatim
    [When(@"I set the AWG(.*) FGen channel (.*) amplitude high value to (.*)")]
        \endverbatim 
     #1#
        [When(@"I set the AWG FGen channel ([1-4]) amplitude high value to (.*)")]
        public void WhenISetTheAWGFGenChannelAmplitudeHighValueTo(string channel, string amplitudehighvalue)
        {
/*          _awgUiMainWindowStepsSteps.WhenISelectTheHomeButton(AWGUI.HomeTab);
            _awgRadioButtonSteps.WhenISelectTheRadioButton(AWGUI.FGenButton);
            switch (channel)
            {
                case "1":
                    {
                        _awgTabControlSteps.IGoToTheTab(AWGUI.FGenCh1Tab);
                        _awgEditBoxSteps.WhenIselecttheeditcontrol(AWGUI.FGenCh1HighEditbox);
                        _awgEditBoxSteps.WhenIenter(amplitudehighvalue);
                        AWGUI.window.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
                        AWGUI.window.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
                    }
                    break;
                case "2":
                    {
                        _awgTabControlSteps.IGoToTheTab(AWGUI.FGenCh2Tab);
                        _awgEditBoxSteps.WhenIselecttheeditcontrol(AWGUI.FGenCh2HighEditbox);
                        _awgEditBoxSteps.WhenIenter(amplitudehighvalue);
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
        /// Gets the Fgen High Amplitude value for a channel
        /// </summary>
        /// <param name="channel"></param>
        /*!
        \AWGFunctionGenerator\verbatim
    [When(@"I get the AWG(.*) FGen channel (.*) amplitude high value")]
        \endverbatim 
     #1#
        [When(@"I get the AWG FGen channel ([1-4]) amplitude high value")]
        public void WhenIGetTheAWGFGenChannelAmplitudeHighValue(string channel)
        {
 /*           switch (channel)
            {
                case "1":
                    {
                        _awgEditBoxSteps.WhenIReadTheValueForTheEditcontrol(AWGUI.FGenCh1HighEditbox);
                    }
                    break;
                case "2":
                    {
                        _awgEditBoxSteps.WhenIReadTheValueForTheEditcontrol(AWGUI.FGenCh2HighEditbox);
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
        /// Compares the Fgen High Amplitude value for a channel with another value
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="expectedvalue"></param>
        /*!
        \AWGFunctionGenerator\verbatim
    [Then(@"the AWG(.*) FGen channel (.*) amplitude high value should be (.*)")]
        \endverbatim 
     #1#
        [Then(@"the AWG FGen channel ([1-4]) amplitude high value should be (.*)")]
        public void ThenTheAWGFGenChannelAmplitudeHighValueShouldBe(string channel, string expectedvalue)
        {
            //_awgEditBoxSteps.ThenTheValueForTheEditcontrolShouldBe(AWGUI.FGenCh1HighEditbox, expectedvalue);
        }

        // Unkown 01/01/01
        /// <summary>
        /// Sets the Fgen Low Amplitude value for a channel
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="amplitudelowvalue"></param>
        /*!
        \AWGFunctionGenerator\verbatim
    [When(@"I set the AWG(.*) FGen channel (.*) amplitude low value to (.*)")]
        \endverbatim 
     #1#
        [When(@"I set the AWG FGen channel ([1-4]) amplitude low value to (.*)")]
        public void WhenISetTheAWGFGenChannelAmplitudeLowValueTo(string channel, string amplitudelowvalue)
        {
/*
            _awgUiMainWindowStepsSteps.WhenISelectTheHomeButton(AWGUI.HomeTab);
            _awgRadioButtonSteps.WhenISelectTheRadioButton(AWGUI.FGenButton);
            switch (channel)
            {
                case "1":
                    {
                        _awgTabControlSteps.IGoToTheTab(AWGUI.FGenCh1Tab);
                        _awgEditBoxSteps.WhenIselecttheeditcontrol(AWGUI.FGenCh1LowEditbox);
                        _awgEditBoxSteps.WhenIenter(amplitudelowvalue);
                        AWGUI.window.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
                        AWGUI.window.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
                    }
                    break;
                case "2":
                    {
                        _awgTabControlSteps.IGoToTheTab(AWGUI.FGenCh2Tab);
                        _awgEditBoxSteps.WhenIselecttheeditcontrol(AWGUI.FGenCh2LowEditbox);
                        _awgEditBoxSteps.WhenIenter(amplitudelowvalue);
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
        /// Gets the Fgen Low Amplitude value for a channel
        /// </summary>
        /// <param name="channel"></param>
        /*!
        \AWGFunctionGenerator\verbatim
    [When(@"I get the AWG(.*) FGen channel (.*) amplitude low value")]
        \endverbatim 
     #1#
        [When(@"I get the AWG FGen channel ([1-4]) amplitude low value")]
        public void WhenIGetTheAWGFGenChannelAmplitudeLowValue(string channel)
        {
/*
            //ScenarioContext.Current.Pending();
            switch (channel)
            {
                case "1":
                    {
                        _awgEditBoxSteps.WhenIReadTheValueForTheEditcontrol(AWGUI.FGenCh1LowEditbox);
                    }
                    break;
                case "2":
                    {
                        _awgEditBoxSteps.WhenIReadTheValueForTheEditcontrol(AWGUI.FGenCh1LowEditbox);
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
        /// Compares the Fgen Low Amplitude value for a channel with another value
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="expectedvalue"></param>
        /*!
        \AWGFunctionGenerator\verbatim
    [Then(@"the AWG(.*) FGen channel (.*) amplitude low value should be (.*)")]
        \endverbatim 
     #1#
        [Then(@"the AWG FGen channel ([1-4]) amplitude low value should be (.*)")]
        public void ThenTheAWGFGenChannelAmplitudeLowValueShouldBe(string channel, string expectedvalue)
        {
            //_awgEditBoxSteps.ThenTheValueForTheEditcontrolShouldBe(AWGUI.FGenCh1LowEditbox, expectedvalue);
        }

        /**************************************************amplitude low Control*********************************************************#1#

        /***************************frequency  control *********************************************************************************#1#

        // Unkown 01/01/01
        /// <summary>
        /// Sets the Fgen Frequency value for a channel
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="frequencyvalue"></param>
        /*!
        \AWGFunctionGenerator\verbatim
    [When(@"I set the AWG(.*) FGen channel (.*) frequency value to (.*)")]
        \endverbatim 
     #1#
        [When(@"I set the AWG FGen channel ([1-4]) frequency value to (.*)")]
        public void WhenISetTheAWGFGenChannelFrequencyValueTo(string channel, string frequencyvalue)
        {
/*          _awgUiMainWindowStepsSteps.WhenISelectTheHomeButton(AWGUI.HomeTab);
            _awgRadioButtonSteps.WhenISelectTheRadioButton(AWGUI.FGenButton);
            switch (channel)
            {
                case "1":
                    {
                        _awgTabControlSteps.IGoToTheTab(AWGUI.FGenCh1Tab);
                        _awgEditBoxSteps.WhenIselecttheeditcontrol(AWGUI.FGenCh2FrequencyEditbox);
                        _awgEditBoxSteps.WhenIenter(frequencyvalue);
                        AWGUI.window.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
                    }
                    break;
                case "2":
                    {
                        _awgTabControlSteps.IGoToTheTab(AWGUI.FGenCh2Tab);
                        _awgEditBoxSteps.WhenIselecttheeditcontrol(AWGUI.FGenCh2FrequencyEditbox);
                        _awgEditBoxSteps.WhenIenter(frequencyvalue);
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
        /// Gets the Fgen Frequency value for a channel
        /// </summary>
        /// <param name="channel"></param>
        /*!
        \AWGFunctionGenerator\verbatim
    [When(@"I get the AWG(.*) FGen channel (.*) frequency value")]
        \endverbatim 
     #1#
        [When(@"I get the AWG FGen channel ([1-4]) frequency value")]
        public void WhenIGetTheAWGFGenChannelFrequencyValue(string channel)
        {
 /*           //ScenarioContext.Current.Pending();
            switch (channel)
            {
                case "1":
                    {
                        _awgEditBoxSteps.WhenIReadTheValueForTheEditcontrol(AWGUI.FGenCh2FrequencyEditbox);
                    }
                    break;
                case "2":
                    {
                        _awgEditBoxSteps.WhenIReadTheValueForTheEditcontrol(AWGUI.FGenCh2FrequencyEditbox);
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
        /// Compares the Fgen Frequency value for a channel with another value
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="expectedvalue"></param>
        /*!
        \AWGFunctionGenerator\verbatim
    [Then(@"the AWG(.*) FGen channel (.*) frequency value should be (.*)")]
        \endverbatim 
     #1#
        [Then(@"the AWG FGen channel ([1-4]) frequency value should be (.*)")]
        public void ThenTheAWGFGenChannelFrequencyValueShouldBe(string channel, string expectedvalue)
        {
            //_awgEditBoxSteps.ThenTheValueForTheEditcontrolShouldBe(AWGUI.FGenCh2FrequencyEditbox, expectedvalue);
        }
    }
}*/