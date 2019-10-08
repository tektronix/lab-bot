 //==========================================================================
// AwgSyncHubGroup_steps.cs
// This file contains the PI step definitions for the AWG PI SyncHub Group commands 
//
// Low-level steps set and get the values for commands, and test the raw values as returned from the 
// instrument. They DO NOT interpret values in any way! Interpretation, normalization, etc. need to 
// occur in the High-level step definitions. Notice the use of the word "value" in the steps - this 
// usually implies that the query returns a 0 or 1 or abbreviated text value (like SOFT) that should 
// be interpreted as ON or OFF or SOFTWARE to make the step more user-friendly. We do that in the 
// High-order step definitions.
// 
// PLEASE use the following regular expressions to match specified numeric formats and other values:
// <NR1> - ((?<!\S)[-+]?\d+(?!\S))
// <NR3> - ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?)
// AWG number -  AWG([1-4])? -OR -
//            -  (?: the)? AWG([1-4])? (depends on language usage)
// File path strings - ""(.+)"" used when you want the string that is delimited by the quotes File path strings
//                        
//==========================================================================

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains the PI step definitions for the %AWG PI SyncHub Group commands 

    /// Generally the steps are set, get and should be operations.  The step sole responsibility
    /// is to make sure the correct %AWG object is used and that parameters such as channel,
    /// markers and clock references are correct for the %AWG object.
    /// 
    /// \ingroup highpi pisteps
    /// 
    /// </summary>
    [Binding] //Very important! This entry needs to be made in each step definition file. 
    public class AwgSyncHubSteps
    {
        private readonly AwgSyncHubGroup _awgSyncHubGroup = new AwgSyncHubGroup();

         #region SYNChronize:ADJust[:STARt]
        /// <summary>
        /// Using SYNChronize:ADJust[:STARt]
        /// This command only performs a system sample rate calibration. It is an overlapped command. 
        /// This command may take up to 3 minutes to complete.
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \syncHub\verbatim
        [When(@"I start a sync hub system sample rate calibration for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I start a sync hub system sample rate calibration for AWG ([1-4])")]
        public void StartAwgSyncHubAdjust(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncHubGroup.StartAwgSyncHubAdjust(awg);

        }
        #endregion SYNChronize:ADJust[:STARt]
        
        #region SYNChronize:CONFigure
        /// <summary>
        /// Using SYNChronize:CONFigure
        /// This command configures the ports in a Synchronization HUB system and forces 
        /// an initialization with the selected configuration. This is an overlapped command.
        /// </summary>
        /// <param name="setValue">Port Setting values, odd numbers between 3 and 15 are valid for system </param>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \syncHub\verbatim
        [When(@"I set sync hub port configuration to (3|5|7|9|11|13|15) for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set sync hub port configuration to (3|5|7|9|11|13|15) for AWG ([1-4])")]
        public void SetSyncHubConfig(string setValue, string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber); 
            _awgSyncHubGroup.SetSyncHubConfig(awg, setValue);

        }

        /// <summary>
        /// Using SYNChronize:CONFigure?
        /// This command queries the configuration of  the ports in a Synchronization HUB system and forces 
        /// an initialization with the selected configuration. This is an overlapped command.
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /// <returns>Port Setting values, odd numbers between 3 and 15 are valid for system </returns>
        /*!
            \syncHub\verbatim
        [When(@"I get sync hub port configuration setting for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get sync hub port configuration setting for AWG ([1-4])")]
        public void GetSyncHubConfig(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncHubGroup.GetSyncHubConfig(awg);

        }

        /// <summary>
        /// Using SYNChronize:CONFigure?
        /// Verifies and Compares the configurations of the ports in a Synchronization HUB system
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \syncHub\verbatim
        [Then(@"the sync hub configuration setting should be one for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the sync hub configuration setting should be one for AWG ([1-4])")]
        public void SyncHubConfigurationShouldBeOne(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncHubGroup.SyncHubConfigurationShouldBe(awg, "1");
        }
        #endregion SYNChronize:CONFigure

        #region SYNChronize:DESKew:ABORt
        /// <summary>
        /// Using SYNChronize:DESKew:ABORt
        /// TThis command only cancels a system deskew calibration. It is an overlapped command. 
        /// This command may take up to 10 minutes to cancel.
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \syncHub\verbatim
        [When(@"I abort the sync hub deskew calibration for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I abort the sync hub deskew calibration for AWG ([1-4])")]
        public void SetSyncHubDeskewAbort(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncHubGroup.SetSyncHubDeskewAbort(awg);

        }
        #endregion SYNChronize:DESKew:ABORt

        #region SYNChronize:DESKew:[STARt]
        /// <summary>
        /// Using SYNChronize:DESKew:[STARt]
        /// This command only performs a system deskew calibration. It is an overlapped command. 
        /// This command may take up to 30 minutes to complete. 
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \syncHub\verbatim
        [When(@"I start the sync hub deskew calibration for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I start the sync hub deskew calibration for AWG ([1-4])")]
        public void SetSyncHubDeskewStart(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncHubGroup.SetSyncHubDeskewStart(awg);

        }
        #endregion SYNChronize:DESKew:[STARt]

        #region SYNChronize:DESKew:STATe?
        /// <summary>
        /// Using SYNChronize:DESKew:STATe?
        /// This query only command retrieve the state of the system deskew calibration. 
        /// Valid only when SynchHub enabled and Master.
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /// <returns>0 for STOPPED and 1 for RUNNING stored in SyncHubDeskewState variable </returns>
        /*!
            \syncHub\verbatim
        [When(@"I get the sync hub deskew calibration status for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get the sync hub deskew calibration status for AWG ([1-4])")]
        public void GetSyncHubDeskewStatus(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncHubGroup.GetSyncHubDeskewStatus(awg);
        }

        /// <summary>
        /// Using SYNChronize:DESKew:STATe?
        /// Verifies and Compares the state of the system deskew calibration. 
        /// Valid only when SynchHub enabled and Master.
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \syncHub\verbatim
        [Then(@"the sync hub deskew calibration status should be running for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the sync hub deskew calibration status should be running for AWG ([1-4])")]
        public void SyncHubDeskewStatusShouldBeRunning(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncHubGroup.SyncHubDeskewStatusShouldBe(awg, AwgSyncHubGroup.SyncHubDeskewState.On);
        }

        /// <summary>
        /// Using SYNChronize:DESKew:STATe?
        /// Verifies and Compares the state of the system deskew calibration. 
        /// Valid only when SynchHub enabled and Master.
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \syncHub\verbatim
        [Then(@"the sync hub deskew calibration status should be stopped or completed for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the sync hub deskew calibration status should be stopped or completed for AWG ([1-4])")]
        public void SyncHubDeskewStatusShouldBeStopped(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncHubGroup.SyncHubDeskewStatusShouldBe(awg, AwgSyncHubGroup.SyncHubDeskewState.Off);
        }


        #endregion SYNChronize:DESKew:STATe?

        #region SYNChronize:ENABle
        /// <summary>
        /// Using SYNChronize:ENABle 
        /// This command enables this AWG to be part of a system to synchronize multiple AWGs. 
        /// This is an overlapped command.
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \syncHub\verbatim
        [When(@"I set sync hub enable state to on for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set sync hub enable state to on for AWG ([1-4])")]
        public void SetSyncHubEnableOn(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncHubGroup.SetSyncHubEnable(awg, "ON");
        }

        /// <summary>
        /// Using SYNChronize:ENABle 
        /// This command disables this AWG to be part of a system to synchronize multiple AWGs. 
        /// This is an overlapped command.
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \syncHub\verbatim
        [When(@"I set sync hub enable state to off for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set sync hub enable state to off for AWG ([1-4])")]
        public void SetSyncHubEnableOff(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncHubGroup.SetSyncHubEnable(awg, "OFF");
        }

        /// <summary>
        /// Using SYNChronize:ENABle?
        /// This query returns Sync Hub Enable State
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /// <returns>0 for OFF and 1 for ON and stores in the SyncHubEnableState Variable</returns>
        /*!
            \syncHub\verbatim
        [When(@"I get sync hub enable status for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get sync hub enable status for AWG ([1-4])")]
        public void GetSyncHubEnableStatus(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncHubGroup.GetSyncHubEnableStatus(awg);
        }

        /// <summary>
        /// Using SYNChronize:ENABle?
        /// Verifies and Compares the Sync Hub Enable state to Off for the system. 
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \syncHub\verbatim
        [Then(@"the sync hub enable status should be off for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the sync hub enable status should be off for AWG ([1-4])")]
        public void SyncHubEnableStatusShouldBeOff(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncHubGroup.SyncHubEnableStatusShouldBe(awg, AwgSyncHubGroup.SyncHubEnableState.Off);
        }
        
        /// <summary>
        /// Using SYNChronize:ENABle?
        /// Verifies and Compares the Sync Hub Enable state to On for the system. 
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \syncHub\verbatim
        [Then(@"the sync hub enable status should be on for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"the sync hub enable status should be on for AWG ([1-4])")]
        public void SyncHubEnableStatusShouldBeOn(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncHubGroup.SyncHubEnableStatusShouldBe(awg, AwgSyncHubGroup.SyncHubEnableState.On);
        }

        #endregion SYNChronize:ENABle

        #region SYNChronize:PLAY:DISable?
        /// <summary>
        /// Using SYNChronize:PLAY:DISable?
        /// This query only command retrieves state of this AWG70000 with regard to which PI commands should be disabled
        /// when AWGSYNC01 is enabled and the play state is not idle. That is the system has started or is playing the selected waveforms and sequences.
        /// This is an unpublished command
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /// <returns>0 for OFF and 1 for ON and stores value in the SyncHubPlayDisableState variable</returns>
        /*!
            \syncHub\verbatim
        [When(@"I get sync hub play disable status for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get sync hub play disable status for AWG ([1-4])")]
        public void GetSyncHubPlayDisableStatus(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncHubGroup.GetSyncHubPlayDisableStatus(awg);
        }

        /// <summary>
        /// Using SYNChronize:PLAY:DISable?
        /// Verifies and Compares the Sync Hub Play state is disabled for the system. 
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \syncHub\verbatim
        [Then(@"sync hub play should be disabled for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"sync hub play should be disabled for AWG ([1-4])")]
        public void SyncHubPlayShouldBeDisabled(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncHubGroup.SyncHubPlayShouldBe(awg, AwgSyncHubGroup.SyncHubPlayState.Disable);
        }

        /// <summary>
        /// Using SYNChronize:PLAY:DISable?
        /// Verifies and Compares the Sync Hub Play state is enabled for the system. 
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \syncHub\verbatim
        [Then(@"sync hub play should be enabled for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"sync hub play should be enabled for AWG ([1-4])")]
        public void SyncHubPlayShouldBeEnabled(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncHubGroup.SyncHubPlayShouldBe(awg, AwgSyncHubGroup.SyncHubPlayState.Enable);
        }

        #endregion SYNChronize:PLAY:DISable?

        #region SYNChronize:SLAVe:DISable?
        /// <summary>
        /// Using SYNChronize:SLAVe:DISable?
        /// This query only command retrieves state of this AWG70000 with regard to which PI commands should be disabled
        /// when AWGSYNC01 is enabled and this AWG70000 is a slave.
        /// This is an unpublished command
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /// <returns>0 for not a slave and 1 for is a slave and mode is enabled value stored in SyncHubSlaveDisableState</returns>
        /*!
            \syncHub\verbatim
        [When(@"I get sync hub slave disable status for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get sync hub slave disable status for AWG ([1-4])")] 
        public void GetSyncHubSlaveDisableStatus(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncHubGroup.GetSyncHubSlaveDisableStatus(awg);
        }

        /// <summary>
        /// Using SSYNChronize:SLAVe:DISable?
        /// Verifies and Compares the Sync Hub Slave state to disabled for the system. 
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \syncHub\verbatim
        [Then(@"sync hub slave should be disabled for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"sync hub slave should be disabled for AWG ([1-4])")]
        public void SyncHubSlaveShouldBeDisabled(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncHubGroup.SyncHubSlaveShouldBe(awg, AwgSyncHubGroup.SyncHubSlaveState.Disable);
        }

        /// <summary>
        /// Using SSYNChronize:SLAVe:DISable?
        /// Verifies and Compares the Sync Hub Slave state to not disabled for the system. 
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \syncHub\verbatim
        [Then(@"sync hub slave should not be disabled for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"sync hub slave should not be disabled for AWG ([1-4])")]
        public void SyncHubSlaveShouldBeNotDisabled(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncHubGroup.SyncHubSlaveShouldBe(awg, AwgSyncHubGroup.SyncHubSlaveState.Enable);
        }

        #endregion SYNChronize:SLAVe:DISable?

        #region SYNChronize:TESTmode
        /// <summary>
        /// Using SYNChronize:TESTmode
        /// This command takes this AWG70000 out of AWGSYNC01 test mode. 
        /// This will be key to testing the software without a HUB connected to the AWG70000. 
        /// This command requires the application starts in  manufacturing mode 
        /// This is an unpublished command
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
           \syncHub\verbatim
        [When(@"I set sync hub test mode off for AWG ([1-4])")]
           \endverbatim 
        */
        [When(@"I set sync hub test mode off for AWG ([1-4])")]
        public void SetSyncTestModeOff(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncHubGroup.SetSyncTestMode(awg, AwgSyncHubGroup.SyncHubTestModeState.Off);
        }
        
        /// <summary>
        /// Using SYNChronize:TESTmode
        /// This command puts this AWG70000 in AWGSYNC01 test mode. 
        /// This will be key to testing the software without a HUB connected to the AWG70000. 
        /// This command requires the application starts in  manufacturing mode 
        /// This is an unpublished command
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \syncHub\verbatim
        [When(@"I set sync hub test mode on for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set sync hub test mode on for AWG ([1-4])")]
        public void SetSyncTestModeOn(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncHubGroup.SetSyncTestMode(awg, AwgSyncHubGroup.SyncHubTestModeState.On);
        }

        /// <summary>
        /// Using SYNChronize:TESTmode?
        /// This query only command retrieves the testmode state of this AWG70000 in the synchronized HUB system.
        /// This command requires the application starts in manufacturing mode 
        /// This is an unpublished command
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /// <returns>0 not in testmode, 1 in testmode, value stored in SyncHubTestModeState</returns>
        /*!
            \syncHub\verbatim
        [When(@"I get sync hub test mode status for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get sync hub test mode status for AWG ([1-4])")]
        public void GetSyncHubTestModeStatus(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncHubGroup.GetSyncHubTestModeStatus(awg);
        }

        /// <summary>
        /// Using SYNChronize:TESTmode?
        /// Verifies and Compares the Sync Hub Test Mode state is off for the system. 
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \syncHub\verbatim
        [Then(@"sync hub test mode should be off for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"sync hub test mode should be off for AWG ([1-4])")]
        public void SyncHubTestModeShouldBeOff(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncHubGroup.SyncHubTestModeShouldBe(awg, AwgSyncHubGroup.SyncHubTestModeState.Off);
        }

        /// <summary>
        /// Using SYNChronize:TESTmode?
        /// Verifies and Compares the Sync Hub Test Mode state is on for the system. 
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \syncHub\verbatim
        [Then(@"sync hub test mode should be on for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"sync hub test mode should be on for AWG ([1-4])")]
        public void SyncHubTestModeShouldBeOn(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncHubGroup.SyncHubTestModeShouldBe(awg, AwgSyncHubGroup.SyncHubTestModeState.On);
        }
        #endregion SYNChronize:TESTmode

        #region SYNChronize:TTYPe
        /// <summary>
        /// Using SYNChronize:TTYPe
        /// The command sets the test type master for this AWG70000 in the synchronized system
        /// when AWGSYNC01 test mode is enabled. This command requires the application 
        /// starts in manufacturing mode.
        /// This is an unpublished command
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \syncHub\verbatim
        [When(@"I set sync hub test type to master for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set sync hub test type to master for AWG ([1-4])")]
        public void SetSyncTestTypeMaster(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncHubGroup.SetSyncTestType(awg, AwgSyncHubGroup.SyncHubTestType.Master);
        }

        /// <summary>
        /// Using SYNChronize:TTYPe
        /// The command sets the test type slave for this AWG70000 in the synchronized system
        /// when AWGSYNC01 test mode is enabled. This command requires the application 
        /// starts in manufacturing mode.
        /// This is an unpublished command
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \syncHub\verbatim
        [When(@"I set sync hub test type to slave for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I set sync hub test type to slave for AWG ([1-4])")]
        public void SetSyncTestTypeSlave(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncHubGroup.SetSyncTestType(awg, AwgSyncHubGroup.SyncHubTestType.Slave);
        }
        
        /// <summary>
        /// Using SYNChronize:TTYPe?
        /// This command retrieves the the test type for this AWG70000 in the synchronized system when AWGSYNC01 test mode is enabled. 
        /// This command requires the application starts in  manufacturing mode.
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /// <returns>MASTer/SLAVe value stored in SyncHubTestTypeMode</returns>
        /*!
            \syncHub\verbatim
        [When(@"I get sync hub test type setting for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get sync hub test type setting for AWG ([1-4])")]
        public void GetSyncHubTestTypeMode(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncHubGroup.GetSyncHubTestTypeMode(awg);
        }

        /// <summary>
        /// Using SYNChronize:TTYPe?
        /// Verifies and Compares the Sync Hub Test Type is master for the system. 
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \syncHub\verbatim
        [Then(@"sync hub test type should be master for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"sync hub test type should be master for AWG ([1-4])")]
        public void SyncHubTestModeTypeShouldBeMaster(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncHubGroup.SyncHubTestModeTypeShouldBe(awg, AwgSyncHubGroup.SyncHubTestType.Master);

        }

        /// <summary>
        /// Using SYNChronize:TTYPe?
        /// Verifies and Compares the Sync Hub Test Type is slave for the system. 
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \syncHub\verbatim
        [Then(@"sync hub test type should be slave for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"sync hub test type should be slave for AWG ([1-4])")]
        public void SyncHubTestModeTypeShouldBeSlave(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncHubGroup.SyncHubTestModeTypeShouldBe(awg, AwgSyncHubGroup.SyncHubTestType.Slave);

        }
        #endregion SYNChronize:TTYPe

        #region SYNChronize:TYPE?
        /// <summary>
        /// Using SYNChronize:TYPE?
        /// This query only command retrieves the type of this AWG70000 in the synchronized HUB system.
        /// The Synch Hub Type is not active until after Synch Hub Enable has completed.
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /// <returns>MASTer/SLAVe/UNKNown</returns>
        /*!
            \syncHub\verbatim
        [When(@"I get sync hub type setting for AWG ([1-4])")]
            \endverbatim 
        */
        [When(@"I get sync hub type setting for AWG ([1-4])")]
        public void GetSyncHubTypeMode(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncHubGroup.GetSyncHubTypeMode(awg);
        }

        /// <summary>
        /// Using SYNChronize:TYPE?
        /// Verifies and Compares the Sync Hub Type is master for the system. 
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \syncHub\verbatim
        [Then(@"sync hub type should be master for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"sync hub type should be master for AWG ([1-4])")]
        public void SyncHubTypeShouldBeMaster(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncHubGroup.SyncHubTypeShouldBe(awg, AwgSyncHubGroup.SyncHubType.Master);

        }

        /// <summary>
        /// Using SYNChronize:TYPE?
        /// Verifies and Compares the Sync Hub Type is slave for the system. 
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \syncHub\verbatim
        [Then(@"sync hub type should be slave for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"sync hub type should be slave for AWG ([1-4])")]
        public void SyncHubTypeShouldBeSlave(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncHubGroup.SyncHubTypeShouldBe(awg, AwgSyncHubGroup.SyncHubType.Slave);

        }

        /// <summary>
        /// Using SYNChronize:TYPE?
        /// Verifies and Compares the Sync Hub Type is unknown for the system. 
        /// </summary>
        /// <param name="awgNumber">specific awg</param>
        /*!
            \syncHub\verbatim
        [Then(@"sync hub type should be unknown for AWG ([1-4])")]
            \endverbatim 
        */
        [Then(@"sync hub type should be unknown for AWG ([1-4])")]
        public void SyncHubTypeShouldBeUnknown(string awgNumber)
        {
            IAWG awg = AwgSetupSteps.GetAWG(awgNumber);
            _awgSyncHubGroup.SyncHubTypeShouldBe(awg, AwgSyncHubGroup.SyncHubType.Unknown);

        }
        #endregion SYNChronize:TYPE?
    }
}