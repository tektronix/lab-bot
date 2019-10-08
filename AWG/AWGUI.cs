using Application = TestStack.White.Application;
using Panel = TestStack.White.UIItems.Panel;
using Window = TestStack.White.UIItems.WindowItems.Window;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System;

namespace AwgTestFramework
{
    public class AWGUI
    {
        #region UIContext

        //Accessors to manage UI context information
        public static string ProcessName = GetProcessName();

        //These are set once and only once in AwgSetupSteps when the test run starts
        public static Application currentApplication { get; set; }
        public static Window currentMainWindow { get; set; }

        //These change according to where the user is in the UI navigation tree
        public static Panel currentUIParentPanel { get; set; }
        public static Panel currentUIChildPanel { get; set; }

        public static Panel currentUIControlPanel { get; set; }
        #endregion

        #region AWGMainWindow

        public static string MainWindow = "AWGMainWindow";
        public static string PlayButton = "btnPlay";

        public static string FileAndUtilitiesWindow = "FileUtilitiesWindow";
        public static string MainControlContainer = "containerMain";

        #endregion

        #region AwgHomeTab

        public static string AWGHomeWindow = "AWGHomeWindow";
        public static string MaxPlots = "btnForceTrigA";
        public static string ForceTrigAButton = "btnForceTrigA";
        public static string ForceTrigBButton = "btnForceTrigB";
        public static string AwgButton = "btnAWG";
        public static string FGenButton = "btnFG";

        #region AwgCh1PlotDisplay

        public static string AwgCh1Button = "btnch";
        public static string AwgCh1Menu = "menuItem";
        public static string AwgCh1AmplitudeEditControl = "aWGNumericEntryControl";
        public static string Awgh1AutoScaleButton = "AutoScale";

        #endregion

        #region AwgC22PlotDisplay

        public static string AwgCh2Button = "btnch";
        public static string AwgCh2Menu = "menuItem";
        public static string AwgCh2AmplitudeEditControl = "aWGNumericEntryControl";
        public static string AwgCh2AutoScaleButton = "AutoScale";

        #endregion

        #region AwgGChannelControls

        public static string AWGRunMode = "cmbRunMode";
        public static string AWGTriggerInput = "cmbTriggerInput";

        #endregion

        #endregion

        #region AwgSetupTab

        public static string AwgSetupTab = "SetupWindow";
        public static string AwgSetupTabControl = "";
        public static string AwgClockTab = "Clock";
        public static string AwgTriggerTab = "Trigger";

        #region AwgCh1Tab

        public static string AwgCh1Tab = "";

        public static string AwgCh1DacResolution = "cmbDACResolution";

        public static string AwgCh1AmplitudeEditbox = "necAmplitude";
        public static string AwgCh1MarkerEditbox = "necMarker1High";

        #endregion

        #region AwgCh2Tab

        public static string AwgCh2Tab = "";

        public static string AwgCh2DacResolution = "cmbDACResolution";

        public static string AwgCh2AmplitudeEditbox = "necAmplitude";
        public static string AwgCh2MarkerEditbox = "necMarker2High";

        #endregion

        #endregion

        #region ToolsWindow

        public static string HelpButton = "btnNeedHelp";
        public static string DefaultLayoutButton = "btnResetWindowLayout";

        public static string RestoreDefaultSetupButton = "proto_DefaultSetup";
        public static string LastSetupButton = "btnLastSetup";
        public static string OpenSetupButton = "btnOpenFile";
        public static string SaveSetupButton = "btnSaveFile";

        #endregion

        #region File & Utilities Window
        public static string DefaultSetupButton = "btnDefault";
        #endregion

        #region WaveformsWindow

        public static string OpenWaveformButton = "btnOpenWfm";
        public static string WaveformList = "lstvImportedWaveforms";

        #endregion

        #region FunctionGeneratorWindow

        /*--FG Home Window-*/
        public static string FGHomeWindow = "FGHomeWindow";

        /*--Tab Control-*/
        public static string FGenTabControl = "tabFG";

        /*--Button and Edit Control Container-*/
        public static string FGScrollViewerPane = "scrViewControls";

        /*--"FGen_Outputs_Off_Button = "" ;/ CR00370952-*/
        /*--"FGen_Return_To_AWG_Button = "" ;/ CR00370953-*/
        public static string FunctionGenerator = "proto_FFct";
        public static string FGenMenuButton = "";

        /*--Signal type buttons-*/
        public static string FGenSineButton = "radSine";
        public static string FGenSquareButton = "radSquare";
        public static string FGenTriangleButton = "radTriangle";
        public static string FGenNoiseButton = "radNoise";
        public static string FGenDCButton = "radDC";
        public static string FGenExpRiseButton = "radExpRise";
        public static string FGenExpDecayButton = "radExpDecay";
        public static string FGenGaussianButton = "radGauss";

        public static string FGenChannelOutputEnableButton = "chkbxChannelOn"; //CR427525 - name needs fixing
        public static string FGenCoupleAmplitudeCheckbox = "chkLockAmpl";

        public static string FGenFrequencyEditbox = "numFreq";

        public static string FGenFrequencyLockLabel = "";
        public static string FGenFrequencyLockText = "";

        public static string FGenAmplitudeEditbox = "numAmplitude";

        public static string FGenOffsetEditbox = "numVoltageOffset";

        public static string FGenAmplitudeLockLabel = "";
        public static string FGenAmplitudeLockText = "";

        public static string FGenDCLevelEditBox = "numDCLevel";

        public static string FGenPhaseEditbox = "numPhase";

        public static string FGenSymmetryEditBox = "numSymmetry";

        public static string FGenPeriodLabel = "";
        public static string FGenPeriodTextBlock = "";

        public static string FGenSampleRateLockLabel = "";
        public static string FGenSampleRateLockText = "";

        public static string FGenHighEditbox = "numVoltageHigh";

        public static string FGenLowEditbox = "numVoltageLow";

        /*--"FGen_CH1_Vert_Scrollbar = "" ;/CR00370956-*/
        /*--Channel 1 Tab-*/
        public static string FGenCh1Tab = "Channel 1";

        /*--Channel 2 Tab-*/
        public static string FGenCh2Tab = "Channel 2";

        #endregion

        #region CommonDialogs

        public static string FileNameEditBox = "1148";
        public static string FileNameEditControl = "1148";
        public static string SaveFileNameEditBox = "1001";
        public static string ProgressDialog = "Progress";
        public static string OpenDialog = "Open";
        public static string FileOpenButton = "Open";
        public static string ImportDialog = "Importing waveform";
        public static string ImportDigitalWaveform = "Import Digital Waveform Text File";

        public static string SaveDialog = "Save As";
        public static string SaveButton = "Save";

        #endregion

        #region FilePaths

        public const string ExePath = @"C:\Program Files\Tektronix\AWG70k\AWG70k.exe";
        public const string SetupFileSavePath = "C:\\temp\\savesetup.awgx";

        #endregion

        //Sharmila - 01/04/2015
        //If SX is installed in PC instead of AWG, SX.exe is the process that is running
        public static string GetProcessName()
        {
            bool SXState = GetSXState();
            string processName;
            if (SXState)
                processName = "SX";
            else
                processName = "AWG70K";
            return processName;

        }

        //Sharmila - 01/04/2015
        //Deserialize and get the SourceXpress radio button status
        public static bool GetSXState()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<MySettings>));
            string currentUserProfile = Environment.GetEnvironmentVariable("USERPROFILE");
            string path = currentUserProfile + "\\My Documents\\MySettings.xml";
            TextReader textReader = new StreamReader(path);
            List<MySettings> deserdata = (List<MySettings>)deserializer.Deserialize(textReader);
            textReader.Close();
            bool isSXSelected = deserdata[0].sx_state;
            return isSXSelected;
        }
    }
}