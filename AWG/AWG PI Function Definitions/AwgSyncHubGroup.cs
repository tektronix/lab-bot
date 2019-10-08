//==========================================================================
// AwgSyncHubGroup.cs
//==========================================================================

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AwgTestFramework 
{
    /// <summary>
    /// This class contains helper functions that are called from the %AWG Sync Hub PI step definitions.
    /// This class has no restrictions as to where it will be used.
    /// 
    /// This "Helper" group does everything else but steps and TekVISA.
    /// Using parameters from the step, each helper will makes decisions
    /// such as send commands, or process responses from queries and
    /// do testing and generate asserts if necessary.
    /// 
    /// \ingroup grouphelperpi pisteps 
    /// 
    /// </summary>
    public class AwgSyncHubGroup 
    {

        public enum SyncHubDeskewState {Off,On}
        private const string SyntaxForSyncHubDeskewStateOff = "0";
        private const string SyntaxForSyncHubDeskewStateOn  = "1";

        public enum SyncHubEnableState { Off, On }
        private const string SyntaxForSyncHubEnableStateOff = "0";
        private const string SyntaxForSyncHubEnableStateOn = "1";

        public enum SyncHubPlayState { Disable, Enable }
        private const string SyntaxForSyncHubPlayDisabled = "0";
        private const string SyntaxForSyncHubPlayEnabled = "1";

        public enum SyncHubSlaveState { Disable, Enable }
        private const string SyntaxForSyncHubSlaveDisabled = "0";
        private const string SyntaxForSyncHubSlaveEnabled = "1";

        public enum SyncHubTestModeState { Off, On }
        private const string SyntaxForSyncHubTestModeOff = "0";
        private const string SyntaxForSyncHubTestModeOn = "1";

        public enum SyncHubType { Master, Slave, Unknown }
        private const string SyntaxForSyncHubTypeMaster  = "MAST";
        private const string SyntaxForSyncHubTypeSlave   = "SLAV";
        private const string SyntaxForSyncHubTypeUnknown = "UNKN";

        public enum SyncHubTestType {Master, Slave}
        private const string SyntaxForSyncHubTestTypeMaster = "MAST";
        private const string SyntaxForSyncHubTestTypeSlave  = "SLAV";

        #region SYNChronize:ADJust[:STARt]
        /// <summary>
        /// Using SYNChronize:ADJust[:STARt]
        /// This command only performs a system sample rate calibration. It is an overlapped command. 
        /// This command may take up to 3 minutes to complete.
        /// </summary>
        /// <param name="awg"></param>
        public void StartAwgSyncHubAdjust(IAWG awg)
        {
            awg.StartAwgSyncHubAdjust();

        }
        #endregion SYNChronize:ADJust[:STARt]

        #region SYNChronize:CONFigure
        /// <summary>
        /// Using SYNChronize:CONFigure
        /// This command configures the ports in a Synchronization HUB system and forces 
        /// an initialization with the selected configuration. This is an overlapped command.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="setValue">Port Setting values, odd numbers between 3 and 15 are valid for system </param>
        public void SetSyncHubConfig(IAWG awg, string setValue)
        {
            awg.SetSyncHubConfig(setValue);

        }

        /// <summary>
        /// Using SYNChronize:CONFigure?
        /// This command gets the configuration of the ports in a Synchronization HUB system and forces 
        /// an initialization with the selected configuration. This is an overlapped command.
        /// </summary>
        /// <param name="awg"></param>
        /// <returns>Port Setting values, odd numbers between 3 and 15 are valid for system </returns>
        public void GetSyncHubConfig(IAWG awg)
        {
            awg.GetSyncHubConfig();
        }

        /// <summary>
        /// Using SYNChronize:PLAY:DISable?
        /// Verifies and Compares the configuration of the ports in a Synchronization HUB system. 
        /// </summary>
        /// <param name="awg"></param>
        public void SyncHubConfigurationShouldBe(IAWG awg, string expectedSetting)
        {
            var possibleErrorString = "Expected: " + expectedSetting + " Actual: " + awg.SyncHubConfigSetting;
            Assert.AreEqual(expectedSetting, awg.SyncHubConfigSetting, possibleErrorString);
        }
        #endregion SYNChronize:CONFigure

        #region SYNChronize:DESKew:ABORt
        /// <summary>
        /// Using SYNChronize:DESKew:ABORt
        /// TThis command only cancels a system deskew calibration. It is an overlapped command. 
        /// This command may take up to 10 minutes to cancel.
        /// </summary>
        /// <param name="awg"></param>
        public void SetSyncHubDeskewAbort(IAWG awg)
        {
            awg.SetSyncHubDeskewAbort();

        }
        #endregion SYNChronize:DESKew:ABORt

        #region SYNChronize:DESKew:[STARt]
        /// <summary>
        /// Using SYNChronize:DESKew:[STARt]
        /// This command only performs a system deskew calibration. It is an overlapped command. 
        /// This command may take up to 30 minutes to complete. 
        /// </summary>
        /// <param name="awg"></param>
        public void SetSyncHubDeskewStart(IAWG awg)
        {
            awg.SetSyncHubDeskewStart();

        }
        #endregion SYNChronize:DESKew:[STARt]

        #region SYNChronize:DESKew:STATe?
        /// <summary>
        /// Using SYNChronize:DESKew:STATe?
        /// This query only command retrieve the state of the system deskew calibration. 
        /// Valid only when SynchHub enabled and Master.
        /// </summary>
        /// <param name="awg"></param>
        /// <returns>0 for STOPPED and 1 for RUNNING stored in SyncHubDeskewState variable </returns>
        public void GetSyncHubDeskewStatus(IAWG awg)
        {
            awg.GetSyncHubDeskewStatus();
        }

        /// <summary>
        /// Using SYNChronize:DESKew:STATe?
        /// Verifies and Compares the state of the system deskew calibration. 
        /// Valid only when SynchHub enabled and Master.
        /// </summary>
        /// <param name="awg"></param>
        public void SyncHubDeskewStatusShouldBe(IAWG awg, SyncHubDeskewState expectedState)
        {
            string expectedDeskewSetting = "";

            switch (expectedState)
            {
                case SyncHubDeskewState.Off:
                    expectedDeskewSetting = SyntaxForSyncHubDeskewStateOff;
                    break;
                case SyncHubDeskewState.On:
                    expectedDeskewSetting = SyntaxForSyncHubDeskewStateOn;
                    break;
            }
            var possibleErrorString = "Expected: " + expectedDeskewSetting + " Actual: " + awg.SyncHubDeskewState;
            Assert.AreEqual(expectedDeskewSetting, awg.SyncHubDeskewState, possibleErrorString);
        }
        #endregion SYNChronize:DESKew:STATe?

        #region SYNChronize:ENABle
        /// <summary>
        /// Using SYNChronize:ENABle 
        /// This command enables this AWG to be part of a system to synchronize multiple AWGs. 
        /// This is an overlapped command.
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="state">On or Off Settings</param>
        public void SetSyncHubEnable(IAWG awg, string state)
        {
            awg.SetSyncHubEnable(state);
        }

        /// <summary>
        /// Using SYNChronize:ENABle?
        /// This query returns Sync Hub Enable State
        /// </summary>
        /// <param name="awg"></param>
        /// <returns>0 for OFF and 1 for ON and stores in the SyncHubEnableState Variable</returns>
        public void GetSyncHubEnableStatus(IAWG awg)
        {
            awg.GetSyncHubEnableStatus();
        }

        /// <summary>
        /// Using SYNChronize:ENABle?
        /// Verifies and Compares the Sync Hub Enable state of the system. 
        /// </summary>
        /// <param name="awg"></param>
        public void SyncHubEnableStatusShouldBe(IAWG awg, SyncHubEnableState expectedState)
        {
            string expectedEnableSetting = "";

            switch (expectedState)
            {
                case SyncHubEnableState.Off:
                    expectedEnableSetting = SyntaxForSyncHubEnableStateOff;
                    break;
                case SyncHubEnableState.On:
                    expectedEnableSetting = SyntaxForSyncHubEnableStateOn;
                    break;
            }
            var possibleErrorString = "Expected: " + expectedEnableSetting + " Actual: " + awg.SyncHubEnableState;
            Assert.AreEqual(expectedEnableSetting, awg.SyncHubEnableState, possibleErrorString);
        }

        #endregion SYNChronize:ENABle

        #region SYNChronize:PLAY:DISable?
        /// <summary>
        /// Using SYNChronize:PLAY:DISable?
        /// This query only command retrieves state of this AWG70000 with regard to which PI commands should be disabled
        /// when AWGSYNC01 is enabled and the play state is not idle. That is the system has started or is playing the selected waveforms and sequences.
        /// This is an unpublished command
        /// </summary>
        /// <param name="awg"></param>
        /// <returns>0 for OFF and 1 for ON and stores value in the SyncHubPlayDisableState variable</returns>
        public void GetSyncHubPlayDisableStatus(IAWG awg)
        {
            awg.GetSyncHubPlayDisableStatus();
        }

        /// <summary>
        /// Using SYNChronize:PLAY:DISable?
        /// Verifies and Compares the Sync Hub Play Disable state of the system. 
        /// </summary>
        /// <param name="awg"></param>
        public void SyncHubPlayShouldBe(IAWG awg, SyncHubPlayState expectedState)
        {
            string expectedPlaySetting = "";

            switch (expectedState)
            {
                case SyncHubPlayState.Disable:
                    expectedPlaySetting = SyntaxForSyncHubPlayDisabled;
                    break;
                case SyncHubPlayState.Enable:
                    expectedPlaySetting = SyntaxForSyncHubPlayEnabled;
                    break;
            }
            var possibleErrorString = "Expected: " + expectedPlaySetting + " Actual: " + awg.SyncHubPlayDisableState;
            Assert.AreEqual(expectedPlaySetting, awg.SyncHubPlayDisableState, possibleErrorString);
        }

        #endregion SYNChronize:PLAY:DISable?

        #region SYNChronize:SLAVe:DISable?
        /// <summary>
        /// Using SYNChronize:SLAVe:DISable?
        /// This query only command retrieves state of this AWG70000 with regard to which PI commands should be disabled
        /// when AWGSYNC01 is enabled and this AWG70000 is a slave.
        /// This is an unpublished command
        /// </summary>
        /// <param name="awg"></param>
        /// <returns>0 for not a slave and 1 for is a slave and mode is enabled value stored in SyncHubSlaveDisableState</returns>
        public void GetSyncHubSlaveDisableStatus(IAWG awg)
        {
            awg.GetSyncHubSlaveDisableStatus();
        }

        /// <summary>
        /// Using SSYNChronize:SLAVe:DISable?
        /// Verifies and Compares the Sync Hub Slave Disable state of the system. 
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedState"></param>
        public void SyncHubSlaveShouldBe(IAWG awg, SyncHubSlaveState expectedState)
        {
            string expectedSlaveSetting = "";

            switch (expectedState)
            {
                case SyncHubSlaveState.Disable:
                    expectedSlaveSetting = SyntaxForSyncHubSlaveDisabled;
                    break;
                case SyncHubSlaveState.Enable:
                    expectedSlaveSetting = SyntaxForSyncHubSlaveEnabled;
                    break;
            }
            var possibleErrorString = "Expected: " + expectedSlaveSetting + " Actual: " + awg.SyncHubSlaveDisableState;
            Assert.AreEqual(expectedSlaveSetting, awg.SyncHubSlaveDisableState, possibleErrorString);
        }
        #endregion SYNChronize:SLAVe:DISable?

        #region SYNChronize:TESTmode
        /// <summary>
        /// Using SYNChronize:TESTmode
        /// This command puts this AWG70000 in AWGSYNC01 test mode. 
        /// This will be key to testing the software without a HUB connected to the AWG70000. 
        /// This command requires the application starts in  manufacturing mode 
        /// This is an unpublished command
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="state">On or Off Settings</param>
        public void SetSyncTestMode(IAWG awg, SyncHubTestModeState state)
        {
            string TestModeSetting = "";
            switch (state)
            {
                case SyncHubTestModeState.Off:
                    TestModeSetting = SyntaxForSyncHubTestModeOff;
                    break;
                case SyncHubTestModeState.On:
                    TestModeSetting = SyntaxForSyncHubTestModeOn;
                    break;
            }
            awg.SetSyncTestMode(TestModeSetting);
        }

        /// <summary>
        /// Using SYNChronize:TESTmode?
        /// This query only command retrieves the testmode state of this AWG70000 in the synchronized HUB system.
        /// This command requires the application starts in manufacturing mode 
        /// This is an unpublished command
        /// </summary>
        /// <param name="awg"></param>
        /// <returns>0 not in testmode, 1 in testmode, value stored in SyncHubTestModeState</returns>
        public void GetSyncHubTestModeStatus(IAWG awg)
        {
            awg.GetSyncHubTestModeStatus();
        }

        /// <summary>
        /// Using SYNChronize:TESTmode?
        /// Verifies and Compares the Sync Hub Test Mode state of the system. 
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedState"></param>
        public void SyncHubTestModeShouldBe(IAWG awg, SyncHubTestModeState expectedState)
        {
            string expectedTestModeSetting = "";

            switch (expectedState)
            {
                case SyncHubTestModeState.Off:
                    expectedTestModeSetting = SyntaxForSyncHubTestModeOff;
                    break;
                case SyncHubTestModeState.On:
                    expectedTestModeSetting = SyntaxForSyncHubTestModeOn;
                    break;
            }
            var possibleErrorString = "Expected: " + expectedTestModeSetting + " Actual: " + awg.SyncHubTestModeState;
            Assert.AreEqual(expectedTestModeSetting, awg.SyncHubTestModeState, possibleErrorString);
        }
        #endregion SYNChronize:TESTmode

        #region SYNChronize:TTYPe
        /// <summary>
        /// Using SYNChronize:TTYPe
        /// The command sets the test type for this AWG70000 in the synchronized system
        /// when AWGSYNC01 test mode is enabled. This command requires the application 
        /// starts in manufacturing mode.
        /// This is an unpublished command
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="mode">MASTer or SLAVe</param>
        public void SetSyncTestType(IAWG awg, SyncHubTestType mode)
        {
            string TestTypeSetting = "";
            switch (mode)
            {
                case SyncHubTestType.Master:
                    TestTypeSetting = SyntaxForSyncHubTestTypeMaster;
                    break;
                case SyncHubTestType.Slave:
                    TestTypeSetting = SyntaxForSyncHubTestTypeSlave;
                    break;
            }
            awg.SetSyncTestType(TestTypeSetting);
        }

        /// <summary>
        /// Using SYNChronize:TTYPe?
        /// This command retrieves the the test type for this AWG70000 in the synchronized system when AWGSYNC01 test mode is enabled. 
        /// This command requires the application starts in  manufacturing mode.
        /// </summary>
        /// <returns>MASTer/SLAVe value stored in SyncHubTestTypeMode</returns>
        public void GetSyncHubTestTypeMode(IAWG awg)
        {
            awg.GetSyncHubTestTypeMode();
        }

        /// <summary>
        /// Using SYNChronize:TTYPe?
        /// Verifies and Compares the Sync Hub Test Type mode of the system. 
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedMode"></param>
        public void SyncHubTestModeTypeShouldBe(IAWG awg, SyncHubTestType expectedMode)
        {
            string expectedTestModeSetting = "";

            switch (expectedMode)
            {
                case SyncHubTestType.Master:
                    expectedTestModeSetting = SyntaxForSyncHubTestTypeMaster;
                    break;
                case SyncHubTestType.Slave:
                    expectedTestModeSetting = SyntaxForSyncHubTestTypeSlave;
                    break;
            }
            var possibleErrorString = "Expected: " + expectedTestModeSetting + " Actual: " + awg.SyncHubTestTypeMode;
            Assert.AreEqual(expectedTestModeSetting, awg.SyncHubTestTypeMode, possibleErrorString);
        }
        #endregion SYNChronize:TTYPe

        #region SYNChronize:TYPE?
        /// <summary>
        /// Using SYNChronize:TYPE?
        /// This query only command retrieves the type of this AWG70000 in the synchronized HUB system.
        /// The Synch Hub Type is not active until after Synch Hub Enable has completed.
        /// </summary>
        /// <param name="awg"></param>
        /// <returns>MASTer/SLAVe/UNKNown</returns>
        public void GetSyncHubTypeMode(IAWG awg)
        {
            awg.GetSyncHubTypeMode();
        }

        /// <summary>
        /// Using SYNChronize:TYPE?
        /// Verifies and Compares the Sync Hub Type mode of the system. 
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedMode"></param>
        public void SyncHubTypeShouldBe(IAWG awg, SyncHubType expectedMode)
        {
            string expectedModeSetting = "";

            switch (expectedMode)
            {
                case SyncHubType.Master:
                    expectedModeSetting = SyntaxForSyncHubTypeMaster;
                    break;
                case SyncHubType.Slave:
                    expectedModeSetting = SyntaxForSyncHubTypeSlave;
                    break;
                case SyncHubType.Unknown:
                    expectedModeSetting = SyntaxForSyncHubTypeUnknown;
                    break;
            }
            var possibleErrorString = "Expected: " + expectedModeSetting + " Actual: " + awg.SyncHubTypeMode;
            Assert.AreEqual(expectedModeSetting, awg.SyncHubTypeMode, possibleErrorString);
        }
        #endregion SYNChronize:TYPE?
    }
}