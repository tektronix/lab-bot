////===========Left off Here ===================================
//
//        // Unkown 01/01/01
//        /// <summary>
//        /// Selects a custom UI item in the Main Window
//        /// </summary>
//        /// <param name="customUiItem">The item that will be searched by using the ByText criteria (name of the control)</param>
//        public void SelectCustomUiItem(string customUiItem)
//        {
///*
//            int waitcount = 0;
//
//            //TODO: PWH - Why is this failing??
//            MyPanelUIItem myPanelUiItem = AWGUI.window.Get<MyPanelUIItem>(SearchCriteria.ByText(customUiItem));
//            while (waitcount <= 10)
//            {
//                _utilsFunctions.Delay(2);
//                myPanelUiItem = AWGUI.window.Get<MyPanelUIItem>(SearchCriteria.ByText(customUiItem));
//                if (myPanelUiItem == null)
//                {
//                    myPanelUiItem = AWGUI.window.Get<MyPanelUIItem>(SearchCriteria.ByText(customUiItem));
//                    Console.WriteLine(customUiItem + " Control is not found");
//                }
//                else
//                {
//                    Console.WriteLine(customUiItem + " Control is found");
//                    break;
//                }
//                waitcount = waitcount + 1;
//                if (waitcount == 11)
//                {
//                    Assert.IsNotNull(myPanelUiItem, customUiItem + " Control is not found");
//                }
//                Assert.IsNotNull(myPanelUiItem, " Control is not found");
//            }
//            Assert.IsNotNull(myPanelUiItem, " Control is not found");
//            _utilsFunctions.Delay(2);
//            myPanelUiItem.Click();
//*/
//        }
//
//        // Unkown 01/01/01
//        /// <summary>
//        /// Selects the Open Setup Button in the main window
//        /// </summary>
//        /*!
//        \AWGMainWindow\verbatim
//    [When(@"I select the AWG Open Setup button in the Main Window")]
//        \endverbatim 
//    */
//        [When(@"I select the AWG Open Setup button in the Main Window")]
//        public void WhenISelectTheOpenSetupButtonintheMainWindow()
//        {
//            //ButtonControls.WhenIselectthebuttonInMainWindow(OpenSetupButton);
//            //_utilsFunctions.CloseUnSavedWaveformsDialog();
//        }
//
//        // Unkown 01/01/01
//        /// <summary>
//        /// Selects the Last Setup Button in the main window
//        /// </summary>
//        /*!
//        \AWGMainWindow\verbatim
//    [When(@"I select the AWG Last Setup button in the Main Window")]
//        \endverbatim 
//    */
//        [When(@"I select the AWG Last Setup button in the Main Window")]
//        public void WhenISelectTheLastSetupButtonintheMainWindow()
//        {
//            //_awgButtonControls.WhenIselectthebuttonInMainWindow(AWGUI.LastSetupButton);
//            //_utilsFunctions.CloseUnSavedWaveformsDialog();
//        }
//
//        // Unkown 01/01/01
//        /// <summary>
//        /// Selects the Open Button in the Open Dialog
//        /// </summary>
//        /*!
//        \AWGMainWindow\verbatim
//    [When(@"I select the Open button in Open Dialog")]
//        \endverbatim 
//    */
//        [When(@"I select the Open button in Open Dialog")]
//        public void WhenISelectTheOpenButtonInOpenDialog()
//        {
//            //_awgButtonControls.WhenIselecttheButtonInChildWindow(OpenDialog, FileOpenButton);
//        }
//
//        // Unkown 01/01/01
//        /// <summary>
//        /// Selects the File Name edit box in the Open Dialog
//        /// </summary>
//        /*!
//        \AWGMainWindow\verbatim
//    [When(@"I select the File Name edit box in the Open Dialog")]
//        \endverbatim 
//    */
//        [When(@"I select the File Name edit box in the Open Dialog")]
//        public void WhenISelectTheFileNameEditBoxInTheOpenDialog()
//        {
//           // _awgEditBoxSteps.WhenIselecttheeditcontrol(FileNameEditBox);
//        }
//
//        // Unkown 01/01/01
//        /// <summary>
//        /// Selects the Open Waveform button in the Main Window
//        /// </summary>
//        /*!
//        \AWGMainWindow\verbatim
//    [When(@"I select the AWG Open Waveform button in the Main Window")]
//        \endverbatim 
//    */
//        [When(@"I select the AWG Open Waveform button in the Main Window")]
//        public void WhenISelectTheOpenWaveformButtonintheMainWindow()
//        {
//            //_utilsFunctions.Delay(8); //Why EIGHT SECONDS??
//            //_awgButtonControls.WhenIselectthebuttonInMainWindow(AWGUI.OpenWaveformButton);
//            //_utilsFunctions.Delay(5);
//            //_utilsFunctions.CloseUnSavedWaveformsDialog(); //If the test has been properly initialized, why is this needed??
//        }
//
//        // Unkown 01/01/01
//        /// <summary>
//        /// Selects the Save Setup button in the Main Window
//        /// </summary>
//        /*!
//        \AWGMainWindow\verbatim
//    [When(@"I select the AWG Save Setup button in the Main Window")]
//        \endverbatim 
//        */
//        [When(@"I select the AWG Save Setup button in the Main Window")]
//        public void WhenISelectTheSaveSetupButtonintheMainWindow()
//        {
//            //_utilsFunctions.Delay(8); //Why EIGHT SECONDS??
//            //_awgButtonControls.WhenIselectthebuttonInMainWindow(AWGUI.SaveSetupButton);
//            //_utilsFunctions.Delay(5);
//            //_utilsFunctions.CloseUnSavedWaveformsDialog();
//        }
//
//        // Unkown 01/01/01
//        /// <summary>
//        /// Selects a waveform file to be opened
//        /// </summary>
//        /// <param name="filePath">The path of the waveform file</param>
//        /*!
//        \AWGMainWindow\verbatim
//    [When(@"I select the waveform file (.*) to be opened")]
//        \endverbatim 
//    */
//        [When(@"I select the waveform file (.*) to be opened")]
//        public void WhenISelectTheWaveformFileToBeOpened(string filePath)
//        {
//            //_awgEditBoxSteps.WhenIselecttheeditcontrol(AWGUI.FileNameEditBox);
//            //_awgEditBoxSteps.WhenIenter(filePath);
//            //_awgButtonControls.WhenIselecttheButtonInChildWindow(OpenDialog, OpenButton);
//            //_utilsFunctions.Delay(5); //Why a delay at the end??
//        }
//
//        // Unkown 01/01/01
//        /// <summary>
//        /// Selects the waveform to be saved
//        /// </summary>
//        /// <param name="filePath">The path of the waveform file</param>
//        /*!
//        \AWGMainWindow\verbatim
//    [When(@"I select the waveform file (.*) to be saved")]
//        \endverbatim 
//    */
//        [When(@"I select the waveform file (.*) to be saved")]
//        public void WhenISelectTheWaveformFileToBeSaved(string filePath)
//        {
//            
//            //_awgEditBoxSteps.WhenIselecttheeditcontrol(AWGUI.SaveFileNameEditBox);
//            //_awgEditBoxSteps.WhenIenter(filePath);
//            //_awgButtonControls.WhenIselecttheButtonInChildWindow(SaveDialog, SaveButton);
//            //_utilsFunctions.Delay(5);
//        }
//
//        // Unkown 01/01/01
//        /// <summary>
//        /// Selects the voltage option 
//        /// </summary>
//        /// <param name="VoltageOption"></param>
//        /*!
//        \AWGMainWindow\verbatim
//    [When(@"I select the desired voltage option (.*)")]
//        \endverbatim 
//    */
//        [When(@"I select the desired voltage option (.*)")]
//        public void WhenISelectTheDesiredVoltgeOption(string VoltageOption)
//        {
//            //_awgButtonControls.WhenIselecttheButtonInChildWindow(AWGUI.ImportDialog, VoltageOption);
//            //_utilsFunctions.Delay(3);
//        }
//
//        // Unkown 01/01/01
//        /// <summary>
//        /// Selects the desired digital resolution
//        /// </summary>
//        /// <param name="DigitalResolution"></param>
//        /*!
//        \AWGMainWindow\verbatim
//    [When(@"I select the desired digital resolution (.*)")]
//        \endverbatim 
//    */
//        [When(@"I select the desired digital resolution (.*)")]
//        public void WhenISelectTheDesiredDigitalResolution(string DigitalResolution)
//        {
//            //_awgButtonControls.WhenIselecttheButtonInChildWindow(AWGUI.ImportDigitalWaveform, DigitalResolution);
//            //_utilsFunctions.Delay(3);
//        }
//
//        // Unkown 01/01/01
//        /// <summary>
//        /// Resets the AWG to Default Settings by clicking the Factory Default Button in the File Menu
//        /// </summary>
//        /*!
//        \AWGMainWindow\verbatim
//    [When(@"I select the AWG Play button in the Mainwindow")]
//        \endverbatim 
//    */
//        [When(@"I select the AWG Play button in the Mainwindow")]
//        public void WhenISelectThePlayButtonInTheMainWindow()
//        {
//            //_utilsFunctions.Delay(2);
//            //_awgButtonControls.WhenIselectthebuttonInMainWindow(AWGUI.PlayButton);
//            //_utilsFunctions.Delay(5);
//        }
//
//        // Unkown 01/01/01
//        /// <summary>
//        /// Selets the Force Trigger button for Trigger A or B in the Main Window
//        /// </summary>
//        /// <param name="trigger_selection">The desired trigger (A|B)</param>
//        /*!
//        \AWGMainWindow\verbatim
//    [When(@"I select the AWG Force Trig (A|B) button in the Main Window")]
//        \endverbatim 
//    */
//        [When(@"I select the AWG Force Trig (A|B) button in the Main Window")]
//        public void WhenISelectTheForceTrigButtonintheMainWindow(string trigger_selection)
//        {
///*            //TODO: NEED TO REDEFINE THE HOME BUTTON STEP
//            // AwgUIMainWindowSteps.WhenISelectTheHomeButton(AWGUI.HomeTab);
//            //_utilsFunctions.Delay(3);
//            switch (trigger_selection)
//            {
//                case "A":
//                    _awgButtonControls.WhenIselectthebuttonInMainWindow(AWGUI.ForceTrigAButton);
//                    break;
//                case "B":
//                    _awgButtonControls.WhenIselectthebuttonInMainWindow(AWGUI.ForceTrigAButton);
//                    break;
//            }*/
//        }