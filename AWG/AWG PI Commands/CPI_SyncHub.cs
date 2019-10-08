
namespace AwgTestFramework
{
    public partial class CPi70KCmds
    {
        //These commands require either a Sync Hub setup or device to be in manufacturing mode to run in testmode
        
        #region SYNChronize:ADJust[:STARt]
        /// <summary>
        /// Using SYNChronize:ADJust[:STARt]
        /// This command only performs a system sample rate calibration. It is an overlapped command. 
        /// This command may take up to 3 minutes to complete.
        /// </summary>
        public void StartAwgSyncHubAdjust()
        {
            const string commandLine = "SYNC:ADJ";
            _mAWGVisaSession.Write(commandLine);

        }
        #endregion SYNChronize:ADJust[:STARt]

        #region SYNChronize:CONFigure
        /// <summary>
        /// Using SYNChronize:CONFigure
        /// This command configures the ports in a Synchronization HUB system and forces 
        /// an initialization with the selected configuration. This is an overlapped command.
        /// </summary>
        /// <param name="setValue">Port Setting values, odd numbers between 3 and 15 are valid for system </param>
        public void SetAwgSyncHubConfig(string setValue)
        {
            var commandLine = "SYNC:CONF " + setValue;
            _mAWGVisaSession.Write(commandLine);  

        }

        /// <summary>
        /// Using SYNChronize:CONFigure?
        /// This command gets the configuration of the ports in a Synchronization HUB system and forces 
        /// an initialization with the selected configuration. This is an overlapped command.
        /// </summary>
        /// <returns>Port Setting values, odd numbers between 3 and 15 are valid for system </returns>
        public string GetAwgSyncHubConfig()
        {
            string response;
            const string commandLine = "SYNC:CONF?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;

        }
        #endregion SYNChronize:CONFigure

        #region SYNChronize:DESKew:ABORt
        /// <summary>
        /// Using SYNChronize:DESKew:ABORt
        /// TThis command only cancels a system deskew calibration. It is an overlapped command. 
        /// This command may take up to 10 minutes to cancel.
        /// </summary>
        public void SetAwgSyncHubDeskewAbort()
        {
            const string commandLine = "SYNC:DESK:ABOR";
            _mAWGVisaSession.Write(commandLine);

        }
        #endregion SYNChronize:DESKew:ABORt

        #region SYNChronize:DESKew:[STARt]
        /// <summary>
        /// Using SYNChronize:DESKew:[STARt]
        /// This command only performs a system deskew calibration. It is an overlapped command. 
        /// This command may take up to 30 minutes to complete. 
        /// </summary>
        public void SetAwgSyncHubDeskewStart()
        {
            const string commandLine = "SYNC:DESK";
            _mAWGVisaSession.Write(commandLine);

        }
        #endregion SYNChronize:DESKew:[STARt]

        #region SYNChronize:DESKew:STATe?
        /// <summary>
        /// Using SYNChronize:DESKew:STATe?
        /// This query only command retrieve the state of the system deskew calibration. 
        /// Valid only when SynchHub enabled and Master.
        /// </summary>
        /// <returns>0 for STOPPED and 1 for RUNNING</returns>
        public string AwgSyncHubDeskewStateQuery()
        {
            string response;
            const string commandLine = "SYNC:DESK:STAT?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion SYNChronize:DESKew:STATe?

        #region SYNChronize:ENABle
        /// <summary>
        /// Using SYNChronize:ENABle 
        /// This command enables this AWG to be part of a system to synchronize multiple AWGs. 
        /// This is an overlapped command.
        /// </summary>
        /// <param name="state">On or Off Settings</param>
        public void SetAwgSyncHubEnable(string state)
        {
            var commandLine = "SYNC:ENAB " + state;
            _mAWGVisaSession.Write(commandLine);

        }
        
        /// <summary>
        /// Using SYNChronize:ENABle?
        /// This query returns Sync Hub Enable State
        /// </summary>
        /// <returns>0 for OFF and 1 for ON</returns>
        public string AwgSyncHubEnableQuery()
        {
            string response;
            const string commandLine = "SYNC:ENAB?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion SYNChronize:ENABle

        #region SYNChronize:PLAY:DISable?
        /// <summary>
        /// Using SYNChronize:PLAY:DISable?
        /// This query only command retrieves state of this AWG70000 with regard to which PI commands should be disabled
        /// when AWGSYNC01 is enabled and the play state is not idle. That is the system has started or is playing the selected waveforms and sequences.
        /// This is an unpublished command
        /// </summary>
        /// <returns>0 for OFF and 1 for ON</returns>
        public string AwgSyncHubPlayDisableQuery()
        {
            string response;
            const string commandLine = "SYNC:PLAY:DIS?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion SYNChronize:PLAY:DISable?

        #region SYNChronize:SLAVe:DISable?
        /// <summary>
        /// Using SYNChronize:SLAVe:DISable?
        /// This query only command retrieves state of this AWG70000 with regard to which PI commands should be disabled
        /// when AWGSYNC01 is enabled and this AWG70000 is a slave.
        /// This is an unpublished command
        /// </summary>
        /// <returns>0 for not a slave and 1 for is a slave and mode is enabled</returns>
        public string AwgSyncHubSlaveDisableQuery()
        {
            string response;
            const string commandLine = "SYNC:SLAV:DIS?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
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
        /// <param name="state">On or Off Settings</param>
        public void SetAwgSyncTestMode(string state)
        {
            var commandLine = "SYNC:TEST " + state;
            _mAWGVisaSession.Write(commandLine);
        }

        /// <summary>
        /// Using SYNChronize:TESTmode?
        /// This query only command retrieves the testmode state of this AWG70000 in the synchronized HUB system.
        /// This command requires the application starts in manufacturing mode 
        /// This is an unpublished command
        /// </summary>
        /// <returns>0 not in testmode, 1 in testmode</returns>
        public string AwgSyncHubTestModeQuery()
        {
            string response;
            const string commandLine = "SYNC:TEST?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
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
        /// <param name="mode">MASTer or SLAVe</param>
        public void SetAwgSyncTestType(string mode)
        {
            var commandLine = "SYNC:TTYP " + mode;
            _mAWGVisaSession.Write(commandLine);
        }
        
        /// <summary>
        /// Using SYNChronize:TTYPe?
        /// This command retrieves the the test type for this AWG70000 in the synchronized system when AWGSYNC01 test mode is enabled. 
        /// This command requires the application starts in  manufacturing mode.
        /// </summary>
        /// <returns>MASTer/SLAVe</returns>
        public string AwgSyncHubTestTypeQuery()
        {
            string response;
            const string commandLine = "SYNC:TTYP?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion SYNChronize:TTYPe
        
        #region SYNChronize:TYPE?
        /// <summary>
        /// Using SYNChronize:TYPE?
        /// This query only command retrieves the type of this AWG70000 in the synchronized HUB system.
        /// The Synch Hub Type is not active until after Synch Hub Enable has completed.
        /// </summary>
        /// <returns>MASTer/SLAVe/UNKNown</returns>
        public string AwgSyncHubTypeQuery()
        {
            string response;
            const string commandLine = "SYNC:TYPE?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion SYNChronize:TYPE?
    }
}
