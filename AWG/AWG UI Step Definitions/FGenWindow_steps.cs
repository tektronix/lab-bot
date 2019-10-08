using TechTalk.SpecFlow;

namespace AwgTestFramework
{
    [TechTalk.SpecFlow.Binding] //Very important! This entry needs to be made in each step definition file. 

    public class AwgUIFunctionGeneratorSteps
    {
        #region Channel Tabs
        // PWH 07/10/2013
        /// <summary>Selects the Channel (n) tab in the FGen window</summary>
        /// <summary>PREREQUISITE: Function Generator mode is selected</summary>
        /// <param name="channel">The channel number of the tab to be selected</param> 
        /*! \verbatim [When(@"I select the Channel (\d) tab")] \endverbatim */
        [When(@"I select the Channel (\d) tab")]
        public void WhenISelectThePlayButton(string channel)
        {
            AwgFGenWindow_functions.SelectFGenChannelTab(channel);
        }
        #endregion

        #region Waveform Shape Buttons

        // PWH 07/10/2013
        /// <summary> Selects the named signal type button in the FGen window </summary>
        /// <summary>PREREQUISITE: Function Generator mode is selected</summary>
        /// <param name="type">The valid types of waveform shapes in the Function Generator</param> 
        /*! \verbatim [When(@"I select the (Sine|Square|Triangle|Noise|DC|Exp Rise|Exp Decay|Gaussian) signal type button")]\endverbatim */
        [When(@"I select the (Sine|Square|Triangle|Noise|DC|Exp Rise|Exp Decay|Gaussian) waveform shape button")]
        public void WhenISelectTheSignalTypeButton(string type)
        {
            AwgFGenWindow_functions.SelectFGenSignalTypeButton(type);
        }

        // PWH 07/11/2013
        /// <summary>Tests the IsSelected state of the named waveform shape button</summary>
        /// <summary>PREREQUISITE: Function Generator mode is selected</summary>
        /// <param name="controlName">The text on the waveform shape button</param> 
        /// <param name="expectedState">The expected selection state of the button</param> 
        /*! \verbatim [When(@"the Noise waveform shape button should be selected")] \endverbatim */
        [Then(@"the (Sine|Square|Triangle|Noise|DC|Exp Rise|Exp Decay|Gaussian) waveform shape button (should|should not) be selected")]
        public void TheFGenEditControlValueShouldBe(string controlName, string expectedState)
        {
            AwgFGenWindow_functions.FGenWaveformShapeButtonShouldBe(controlName, expectedState);
        }
        #endregion

        #region Edit Controls
        // PWH 07/10/2013
        /// <summary>Enters a value into the named edit control in the FGen window</summary>
        /// <summary>PREREQUISITE: Function Generator mode is selected</summary>
        /// <param name="value">The NR3 (float) value that is to be set</param> 
        /// <param name="units">The units for the value to be entered</param> 
        /// <param name="controlName">the AutomationID (name) of the control to be acted upon</param> 
        /*! \verbatim [When(@"I enter ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?|MAX|MIN) ?(MHz|ns|GS/s|mVpp|mV|V|%|°)? into the (High|Low|Amplitude|Offset|Frequency|Phase|DC Level|Symmetry) edit control")] \endverbatim */
        [When(@"I enter ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?|MAX|MIN) ?(MHz|ns|GS/s|mVpp|mV|V|%|°)? into the (High|Low|Amplitude|Offset|Frequency|Phase|DC Level|Symmetry) edit control")]
        public void WhenIEnterAValueInTheFGenEditControl(string value, string units, string controlName)
        {
            AwgFGenWindow_functions.SetValueToFGenEditControl(value, units, controlName);
        }

        // PWH 07/10/2013
        /// <summary>Tests the value in the named edit control</summary>
        /// <summary>PREREQUISITE: Function Generator mode is selected</summary>
        /// <param name="controlName">the AutomationID (name) of the control to be acted upon</param> 
        /// <param name="value">The NR3 (float) value to be tested</param> 
        /// <param name="units">OPTIONAL units for the value to be tested</param> 
        /*! \verbatim [When(@"the value in the (High|Low|Amplitude|Offset|Frequency|Phase|DC Level|Symmetry) edit control should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?|MAX|MIN) (MHz|ns|GS/s|mVpp|mV|V|%)?")] \endverbatim */
        [Then(@"the value in the (High|Low|Amplitude|Offset|Frequency|Phase|DC Level|Symmetry) edit control should be ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?|MAX|MIN) ?(MHz|ns|GS/s|mVpp|mV|V|%|°)?")]
        public void TheFGenEditControlValueShouldBe(string controlName, string value, string units = null)
        {
            AwgFGenWindow_functions.FGenEditControlValueShouldBe(value, units, controlName);
        }
        #endregion

        #region Output Enable Buttons
        // PWH 07/10/2013
        /// <summary>Toggles the Channel Outputs Enable button</summary>
        /// <summary>PREREQUISITE: Function Generator mode is selected</summary>
        /// <param name=""></param> 
        /*! \verbatim [When(@"I select the Channel Outputs Enable button")] \endverbatim */
        [When(@"I select the Channel Output Enable button")]
        public void WhenISelectTheOutputsEnableButton()
        {
            AwgFGenWindow_functions.SelectOutputsEnableButton();
        }

        // PWH 07/11/2013
        /// <summary>Tests the ToggleState property of the Output Enable button</summary>
        /// <summary>PREREQUISITE: Function Generator mode is selected</summary>
        /// <param name="expectedState">The state the button ius expected to be in</param> 
        /*! \verbatim [When(@"the Channel Output Enable button should be (on|off)d")] \endverbatim */
        [Then(@"the Channel Output Enable button should be \b(on|off)")]
        public void TheFGenChannelOutputEnableButtonShouldBe(string expectedState)
        {
            AwgFGenWindow_functions.FGenChannelOutputEnableButtonShouldBe(expectedState);
        }
        #endregion
    }
}
