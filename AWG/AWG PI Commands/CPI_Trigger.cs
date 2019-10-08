
using System.Runtime.InteropServices;

namespace AwgTestFramework
{
    public partial class CPi70KCmds
    {
        #region Trigger
        #region *TRG
        // glennj 7/23/2013
        /// <summary>
        /// Using *TRG create a trigger event
        /// </summary>
        public void SetAwgTriggerEvent()
        {
            const string commandLine = "*TRG";
            _mAWGVisaSession.Write(commandLine);
        }
        #endregion *TRG

        #region TRIGger:IMMediate

        // glennj 7/23/2013
        /// <summary>
        /// Using TRIGger:IMMediate Force a trigger event
        /// </summary>
        /// <param name="triggerSelection"></param>
        public void ForceAwgTriggerEvent(string triggerSelection)
        {
              string commandLine = "TRIG:IMM" + triggerSelection;
              _mAWGVisaSession.Write(commandLine);
        }
        #endregion

        #region TRIGger:IMPedance

        // glennj 7/23/2013
        /// <summary>
        /// Using TRIGger:IMPedance set a trigger impedance
        /// </summary>
        /// <param name="triggerSelection">Selects trigger A or B</param>
        /// <param name="setValue"> Impedance value of 50 or 1000 Ohms</param>
        public void SetAwgTriggerImpedance(string triggerSelection, string setValue)
        {
            var command = "TRIG:IMP " + setValue + ", "+ triggerSelection +"TRigger";
            _mAWGVisaSession.Write(command);
        }

        // glennj 7/23/2013
        /// <summary>
        /// Using TRIGger:IMPedance? get a trigger impedance
        /// </summary>
        /// <param name="triggerSelection">Selects trigger A or B</param>
        /// <returns>Trigger Impedance of 50 or 1000 Ohms</returns>
        public string GetAwgTriggerImpedance(string triggerSelection)
        {
            string response;
            var  commandLine = "TRIG:IMP? " + triggerSelection + "TRigger";
            _mAWGVisaSession.Query( commandLine, out response); 
            return response;
        }
        #endregion

        #region TRIGger:LEVel

        // glennj 7/23/2013
        /// <summary>
        /// Using TRIGger:LEVel set a trigger level
        /// </summary>
        /// <param name="triggerSelection">Selects Trigger A or B</param>
        /// <param name="setValue">Trigger Level</param>
        public void SetAwgTriggerLevel(string triggerSelection, string setValue)
        {
            var command = "TRIG:LEV " + setValue + ", "+ triggerSelection +"TRigger";
            _mAWGVisaSession.Write(command);
        }

        // glennj 7/23/2013
        /// <summary>
        /// Using TRIGger:LEVel? get a trigger level
        /// </summary>
        /// <param name="triggerSelection">Selects Trigger A or B</param>
        /// <returns>Trigger Level</returns>
        public string GetAwgTriggerLevel(string triggerSelection)
        {
            string response;
            string commandLine = "TRIG:LEV? "+ triggerSelection +"TRigger";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion

        #region TRIGger:MODE
        //glennj 07/23/2013
        /// <summary>
        /// Using TRIGger:MODE set the trigger mode
        /// </summary>
        /// <param name="setValue">The desired mode for the trigger</param>
        public void SetAwgTriggerMode(string setValue)
        {
            var commandLine = "TRIG:MODE " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        //glennj 07/23/2013
        /// <summary>
        /// Using TRIGger:MODE? get a trigger mode
        /// </summary>
        /// <return>The Trigger Mode</return>
        public string GetAwgTriggerMode()
        {
            string response;
            const string commandLine = "TRIG:MODE?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion

        #region TRIGger[:SEQuence]:INTerval
        // jmanning 04/08/2014
        /// <summary>
        /// Using TRIGger:SEQuence:INTerval to set the internal trigger inetrval
        /// </summary>
        /// <param name="setValue">Trigger Level</param>
        public void SetAwgTriggerInterval(string setValue)
        {
            var command = "TRIG:SEQ:INT " + setValue;
            _mAWGVisaSession.Write(command);
        }

        // jmanning 04/08/2014
        /// <summary>
        /// Using TRIGger:SEQuence:INTerval? to get the internal trigger inetrval
        /// </summary>
        /// <returns>Internal Trigger Time Interval Value</returns>
        public string GetAwgTriggerInterval()
        {
            string response;
            string commandLine = "TRIG:SEQ:INT?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion TRIGger[:SEQuence]:INTerval

        #region TRIGger:SLOPe

        // glennj 7/23/2013
        /// <summary>
        /// Using TRIGger:SLOPe set a trigger slope to setValue
        /// </summary>
        /// <param name="triggerSelection">Selects Trigger A or B</param>
        /// <param name="setValue">Trigger slope</param>
        public void SetAwgTriggerSlope(string triggerSelection, string setValue)
        {
            var command = "TRIG:SLOP " + setValue + ", "+ triggerSelection +"TRigger";
            _mAWGVisaSession.Write(command);
        }

        // glennj 7/23/2013
        /// <summary>
        /// Using TRIGger:SLOPe? get a Trigger slope
        /// </summary>
        /// <param name="triggerSelection">Selects trigger A or B</param>
        /// <returns>Trigger slope</returns>
        public string GetAwgTriggerSlope(string triggerSelection)
        {
            string response;
            var commandLine = "TRIG:SLOP? "+ triggerSelection +"TRigger";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion

        #region TRIGger:SOURce
        // glennj 7/23/2013
        /// <summary>
        /// Using TRIGger:SOURce set the trigger source
        /// </summary>
        /// <param name="setValue">Trigger source desired</param>
        public void SetAwgTriggerSource(string setValue)
        {
            var commandLine = "TRIG:SOUR " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        // glennj 7/23/2013
        /// <summary>
        /// Using TRIGger:SOURce get a trigger source
        /// </summary>
        /// <returns>Trigger Source</returns>
        public string GetAwgTriggerSource()
        {
            string response;
            const string commandLine = "TRIG:SOUR?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }

        #endregion

        #region TRIGger:WVALue

        // glennj 7/23/2013
        /// <summary>
        /// Using TRIGger:WVALue set a trigger wait on trigger value
        /// </summary>
        /// <param name="setValue"></param>
        public void SetAwgTriggerWValue(string setValue)
        {
            var commandLine = "TRIG:WVAL " + setValue;
            _mAWGVisaSession.Write(commandLine);
        }

        // glennj 7/23/2013
        /// <summary>
        ///  Using TRIGger:WVALue? get a trigger wait on trigger value
        /// </summary>
        /// <returns></returns>
        public string GetAwgTriggerWValue()
        {
            string response;
            const string commandLine = "TRIG:WVAL?";
            _mAWGVisaSession.Query(commandLine, out response);
            return response;
        }
        #endregion

        #region AWGControl:PJUMP:SEDGE

        //Keerthi 05/28/2015
        /// <summary>
        ///  Using AWGControl:PJUMP:SEDGE sets the strobe edge value
        /// </summary>
        /// <param name="strobEdge">strobe edge whether RISING/FALLING</param>


        public void SetStrobEdge(string strobEdge)

        {
            var command = "AWGControl:PJUMp:SEDGe " + strobEdge;
            _mAWGVisaSession.Write(command);

        }

        #endregion AWGControl:PJUMP:SEDGE

        #region AWGControl:PJUMP:SEDGE?

        //Keerthi 05/28/2015
        /// <summary>
        ///  Using AWGControl:PJUMP:SEDGE? Gets the strobe edge value
        /// </summary>
        /// /// <returns>strobe edge value either RISING/FALLING</returns>
        

        public string GetStrobEdge()
        {
            string response;

           const string commandLine = "AWGControl:PJUMp:SEDGe?";

            _mAWGVisaSession.Query(commandLine, out response);

            return response;

        }
        #endregion #region AWGControl:PJUMP:SEDGE?

        #region AWGControl:PJUMp:JSTRobe

        //Keerthi 05/28/2015
        /// <summary>
        ///  Using AWGControl:PJUMp:JSTRobe sets the strobe edge value
        /// </summary>
        /// <param name="setValue">set jump on strobe always to ON/OFF </param>

        public void SetJumpOnStrobe(string setValue)

        {
            var commandLine = "AWGControl:PJUMp:JSTRobe " + setValue;

            _mAWGVisaSession.Write(commandLine);

        }

       #endregion AWGControl:PJUMp:JSTRobe

       #region AWGControl:PJUMp:JSTRobe?

       //Keerthi 05/28/2015
       /// <summary>
       ///  Using AWGControl:PJUMp:JSTRobe? gets jump on strobe always
       /// </summary>
       /// /// <returns> returns Jump on strobe always is ON/OFF </returns>

        public string GetJumpOnStrobeStatus()
        {
            string response;
            const string commandLine = "AWGControl:PJUMp:JSTRobe?";
             _mAWGVisaSession.Query(commandLine, out response);

            return response;

        }

      #endregion AWGControl:PJUMp:JSTRobe?
       
        
      #endregion Trigger
    }
}
