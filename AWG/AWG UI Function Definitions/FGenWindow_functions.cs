// Perry Hunter 06/10/2013
/// <summary></summary>
/// <summary>PREREQUISITE: Function Generator mode UI context</summary>
/// <param name=""></param>
/// <param name=""></param>
/// 
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TabItems;

using Button = TestStack.White.UIItems.Button;
using TextBox = TestStack.White.UIItems.TextBox;
using RadioButton = TestStack.White.UIItems.RadioButton;

namespace AwgTestFramework
{
    class AwgFGenWindow_functions
    {

        // Perry Hunter 06/10/2013
        /// <summary>Selects the requested channel tab in the in the FGen window</summary>
        /// <summary>PREREQUISITE: Function Generator mode UI context</summary>
        /// <param name="channel">The requested channel number for the tab to be selected</param>
        public static void SelectFGenChannelTab(string channel)
        {
            string _tabName = null;

            // Decide which tab we requested
            if      (channel == "1") {_tabName = AWGUI.FGenCh1Tab; }
            else if (channel == "2") {_tabName = AWGUI.FGenCh2Tab; }
            else
            {
                Assert.Fail("Requested channel " + channel + " is not defined");
            }

            // Using the previously set context of the AWGUI:currentUIChildPanel from the "When I select the Functions button" step, 
            // find the required tab control
            TabPage _tab = AWGUI.currentUIChildPanel.Get<TabPage>(SearchCriteria.ByAutomationId(_tabName));
            
            Assert.IsNotNull(_tab);

            //For tabs, you must first select, then click the tab.
            _tab.Select();
            _tab.Click();

            //Set context to the control pane of the selected channel tab
            AwgContextFunctions.SetContextToSelectedFGenChannel();
        }

        // Perry Hunter 06/10/2013
        /// <summary>Selects the requested FGen waveform shape button</summary>
        /// <summary>PREREQUISITE: Function Generator mode UI context, Channel tab selected</summary>
        /// <param name="type"></param>
        public static void SelectFGenSignalTypeButton(string type)
        {
            string _buttonID = GetRadioButtonID(type);

           // RadioButton _button = AWGUI.currentUIControlPanel.Get<RadioButton>(SearchCriteria.ByAutomationId(_buttonID));
            //Kavitha
            RadioButton _button = AWGUI.currentMainWindow.Get<RadioButton>(SearchCriteria.ByAutomationId(_buttonID));
            Assert.IsNotNull(_button);

            Assert.IsTrue(_button.Enabled);

            _button.Click();
        }

        // Perry Hunter 06/10/2013
        /// <summary>Gets the AutomationID of the requested FGen waveform shape button</summary>
        /// <summary>PREREQUISITE: Function Generator mode UI context</summary>
        /// <param name="type">The label on the requested radio button</param>
        /// <param name="buttonId">The AutomationID matching the requested radio button label</param>
        private static string GetRadioButtonID(string type)
        {
            string buttonId = null;

            switch (type)
            {
                case "Sine":
                    buttonId = AWGUI.FGenSineButton;
                    break;

                case "Square":
                    buttonId = AWGUI.FGenSquareButton;
                    break;

                case "Triangle":
                    buttonId = AWGUI.FGenTriangleButton;
                    break;

                case "Noise":
                    buttonId = AWGUI.FGenNoiseButton;
                    break;

                case "DC":
                    buttonId = AWGUI.FGenDCButton;
                    break;

                case "Exp Rise":
                    buttonId = AWGUI.FGenExpRiseButton;
                    break;

                case "Exp Decay":
                    buttonId = AWGUI.FGenExpDecayButton;
                    break;

                case "Gaussian":
                    buttonId = AWGUI.FGenGaussianButton;
                    break;
            }
            return buttonId;
        }

        // Perry Hunter 06/10/2013
        /// <summary>Gets the AutomationID of the requested FGen text box control</summary>
        /// <summary>PREREQUISITE: Function Generator mode UI context</summary>
        /// <param name="controlName">The label on the requested text box</param>
        /// <param name="textBoxId">The AutomationID matching the requested text box label</param>
        private static string GetTextBoxID(string controlName)
        {
            string textBoxId = null;

            //High|Low|Amplitude|Offset|Frequency|Phase|DC Level|Symmetry
            switch (controlName)
            {
                case "High":
                    textBoxId = AWGUI.FGenHighEditbox;
                    break;

                case "Low":
                    textBoxId = AWGUI.FGenLowEditbox;
                    break;

                case "Amplitude":
                    textBoxId = AWGUI.FGenAmplitudeEditbox;
                    break;

                case "Offset":
                    textBoxId = AWGUI.FGenOffsetEditbox;
                    break;

                case "Frequency":
                    textBoxId = AWGUI.FGenFrequencyEditbox;
                    break;

                case "Phase":
                    textBoxId = AWGUI.FGenPhaseEditbox;
                    break;

                case "DC Level":
                    textBoxId = AWGUI.FGenDCLevelEditBox;
                    break;

                case "Symmetry":
                    textBoxId = AWGUI.FGenSymmetryEditBox;
                    break;
            }
            return textBoxId;
        }


        public static void SetValueToFGenEditControl(string value, string units, string controlName)
        {
            string _textBoxID = GetTextBoxID(controlName);

            TextBox _textBox = AWGUI.currentUIControlPanel.Get<TextBox>(SearchCriteria.ByAutomationId(_textBoxID));
            Assert.IsNotNull(_textBox);

            Assert.IsTrue(_textBox.Enabled);

            _textBox.Click();
            _textBox.Enter(value + units);

        }

        public static void SelectOutputsEnableButton()
        {
            Button _button = AWGUI.currentUIControlPanel.Get<Button>(SearchCriteria.ByAutomationId(AWGUI.FGenChannelOutputEnableButton));
            Assert.IsNotNull(_button);

            Assert.IsTrue(_button.Enabled);

            _button.Click();
        }

        public static void FGenEditControlValueShouldBe(string value, string units, string controlName)
        {
            string textBoxId = GetTextBoxID(controlName);
            string expectedValue = value + " " + units; //The system imposes a space between units and value
            string actualValue;

            TextBox _textBox = AWGUI.currentUIControlPanel.Get<TextBox>(SearchCriteria.ByAutomationId(textBoxId));
            Assert.IsNotNull(_textBox);

            Assert.IsTrue(_textBox.Enabled);

            actualValue = _textBox.Text; 
            Assert.AreEqual(actualValue, expectedValue, "The actual value of the FGen " + controlName + "edit box: " + actualValue + " did not match the expected value: " + expectedValue);
        }

        public static void FGenWaveformShapeButtonShouldBe(string controlName, string expectedState)
        {
            string radioButtonId = GetRadioButtonID(controlName);
            bool expectedValue = true;

            if (expectedState == "should not") expectedValue = false;

           // RadioButton _button = AWGUI.currentUIControlPanel.Get<RadioButton>(SearchCriteria.ByAutomationId(radioButtonId));
            //Kavitha
            RadioButton _button = AWGUI.currentMainWindow.Get<RadioButton>(SearchCriteria.ByAutomationId(radioButtonId));
            Assert.IsNotNull(_button);

            Assert.AreEqual(expectedValue, _button.IsSelected);

        }

        public static void FGenChannelOutputEnableButtonShouldBe(string expectedState)
        {
            string buttonId = AWGUI.FGenChannelOutputEnableButton;
   
            Button _button = AWGUI.currentUIControlPanel.Get<Button>(SearchCriteria.ByAutomationId(buttonId));
            Assert.IsNotNull(_button);

            //The ToggleState property returns a Ucase value, so we have to convert
            Assert.AreEqual(expectedState, _button.State.ToString().ToLower());            
        }
    }
}
