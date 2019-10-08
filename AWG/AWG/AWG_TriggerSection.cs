
namespace AwgTestFramework
{
    public partial class AWG
    {

        /// <summary>
        /// Property for Impedance for Trigger A<para>
        /// Update occurs with Get action</para>
        /// </summary>
        public string TriggerImpedanceA { get; set; }

        /// <summary>
        /// Property for Impedance for Trigger B<para>
        /// Update occurs with Get action</para>
        /// </summary>
        public string TriggerImpedanceB { get; set; }

        /// <summary>
        /// Property for interval for Internal Trigger<para>
        /// Update occurs with Get Action</para>
        /// </summary>
        public string TriggerInterval { get; set; }

        /// <summary>
        /// Property for Level for Trigger A<para>
        /// Update occurs with Get Action</para>
        /// </summary>
        public string TriggerLevelA { get; set; }

        /// <summary>
        /// Property for Level for Trigger B<para>
        /// Update occurs with Get Action</para>
        /// </summary>
        public string TriggerLevelB { get; set; }

        /// <summary>
        /// Property for the trigger mode of the AWG.<para>
        /// Today it is only one trigger mode for the instrument</para>
        /// </summary>
        public string TriggerMode { get; set; }
        /// <summary>
        /// Property for Trigger A Slope<para>
        /// Updated with a get action</para>
        /// </summary>
        public string TriggerSlopeA { get; set; }
        /// <summary>
        /// Property for Trigger B Slope<para>
        /// Updated with a get action</para>
        /// </summary>
        public string TriggerSlopeB { get; set; }
        /// <summary>
        /// Property updated with TRIGger:SOURce?
        /// </summary>
        public string TriggerSource { get; set; }
        /// <summary>
        /// Property updated with TRIGger:WVALue?
        /// </summary>
        public string TriggerWaitForValue { get; set; }

        /// <summary>
        /// Property to contain the response from AWGControl:PJUMP:SEDGE?
        /// </summary>

        public string strobEdgeQueried { get; set; }

        /// <summary>
        /// Property to contain the response from AWGControl:PJUMp:JSTRobe?
        /// </summary>>

        public string jumpOnStrobeStatusQueried { get; set; }

        #region *TRG

        // glennj 7/23/2013
        /// <summary>
        /// Using *TRG create a trigger event
        /// </summary>
        public void SetTriggerEvent()
        {
            _pi.SetAwgTriggerEvent();
        }

        #endregion *TRG

        #region TRIGger:IMMediate

        // glennj 7/23/2013
        /// <summary>
        /// Using TRIGger:IMMediate Force a trigger event
        /// </summary>
        /// <param name="triggerSelection"></param>
        public void ForceTriggerEvent(string triggerSelection)
        {
            _pi.ForceAwgTriggerEvent(triggerSelection);
        }

        #endregion TRIGger:IMMediate

        #region TRIGger:IMPedance

        // glennj 7/23/2013
        /// <summary>
        /// Using TRIGger:IMPedance set a trigger impedance
        /// </summary>
        /// <param name="triggerSelection">Selects trigger A or B</param>
        /// <param name="setValue"> Impedance value of 50 or 1000 Ohms</param>
        public void SetTriggerImpedance(string triggerSelection, string setValue)
        {
            _pi.SetAwgTriggerImpedance(triggerSelection, setValue);
        }

        // glennj 7/23/2013
        /// <summary>
        /// Using TRIGger:IMPedance? get a trigger impedance
        /// </summary>
        /// <param name="triggerSelection">Selects trigger A or B</param>
        /// <returns>Trigger Impedance of 50 or 1000 Ohms</returns>
        public void GetTriggerImpedance(string triggerSelection)
        {
            var trigger = (triggerSelection.StartsWith("A", true, null)) ? "A" : "B";
            var update = _pi.GetAwgTriggerImpedance(triggerSelection);
            switch (trigger)
            {
                case "A":
                    TriggerImpedanceA = update;
                    break;
                case "B":
                    TriggerImpedanceB = update;
                    break;
            }
        }

        #endregion

        #region TRIGger:LEVel

        // glennj 7/23/2013
        /// <summary>
        /// Using TRIGger:LEVel set a trigger level
        /// </summary>
        /// <param name="triggerSelection">Selects Trigger A or B</param>
        /// <param name="setValue">Trigger Level</param>
        public void SetTriggerLevel(string triggerSelection, string setValue)
        {
            _pi.SetAwgTriggerLevel(triggerSelection, setValue);
        }

        // glennj 7/23/2013
        /// <summary>
        /// Using TRIGger:LEVel? get a trigger level
        /// </summary>
        /// <param name="triggerSelection">Selects Trigger A or B</param>
        /// <returns>Trigger Level</returns>
        public void GetTriggerLevel(string triggerSelection)
        {
            var trigger = (triggerSelection.StartsWith("A", true, null)) ? "A" : "B";
            var update = _pi.GetAwgTriggerLevel(triggerSelection);
            switch (trigger)
            {
                case "A":
                    TriggerLevelA = update;
                    break;
                case "B":
                    TriggerLevelB = update;
                    break;
            }
        }

        #endregion

        #region TRIGger:MODE

        //glennj 07/23/2013
        /// <summary>
        /// Using TRIGger:MODE set the trigger mode
        /// </summary>
        /// <param name="setValue">The desired mode for the trigger</param>
        public void SetTriggerMode(string setValue)
        {
            _pi.SetAwgTriggerMode(setValue);
        }

        //glennj 07/23/2013
        /// <summary>
        /// Using TRIGger:MODE? get a trigger mode
        /// </summary>
        /// <return>The Trigger Mode</return>
        public void GetTriggerMode()
        {
            TriggerMode = _pi.GetAwgTriggerMode();
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
            _pi.SetAwgTriggerInterval(setValue);
        }

        // jmanning 04/08/2014
        /// <summary>
        /// Using TRIGger:SEQuence:INTerval? to get the internal trigger inetrval
        /// </summary>
        /// <returns>Internal Trigger Time Interval Value</returns>
        public void GetAwgTriggerInterval()
        {
            TriggerInterval = _pi.GetAwgTriggerInterval();
        }
        #endregion TRIGger[:SEQuence]:INTerval

        #region TRIGger:SLOPe

        // glennj 7/23/2013
        /// <summary>
        /// Using TRIGger:SLOPe set a trigger slope to setValue
        /// </summary>
        /// <param name="triggerSelection">Selects Trigger A or B</param>
        /// <param name="setValue">Trigger slope</param>
        public void SetTriggerSlope(string triggerSelection, string setValue)
        {
            _pi.SetAwgTriggerSlope(triggerSelection, setValue);
        }

        // glennj 7/23/2013
        /// <summary>
        /// Using TRIGger:SLOPe? get a Trigger slope
        /// </summary>
        /// <param name="triggerSelection">Selects trigger A or B</param>
        /// <returns>Trigger slope</returns>
        public void GetTriggerSlope(string triggerSelection)
        {
            var update = _pi.GetAwgTriggerSlope(triggerSelection);
            var trigger = (triggerSelection.StartsWith("A", true, null)) ? "A" : "B";
            switch (trigger)
            {
                case "A":
                    TriggerSlopeA = update;
                    break;
                case "B":
                    TriggerSlopeB = update;
                    break;
            }
        }
        #endregion

        #region TRIGger:SOURce
        // glennj 7/23/2013
        /// <summary>
        /// Using TRIGger:SOURce set the trigger source between internal and external
        /// </summary>
        /// <param name="setValue">Trigger source desired</param>
        public void SetTriggerSource(string setValue)
        {
            _pi.SetAwgTriggerSource(setValue);
        }

        // glennj 7/23/2013
        /// <summary>
        /// Using TRIGger:SOURce get a trigger source
        /// </summary>
        /// <returns>Trigger Source</returns>
        public void GetTriggerSource()
        {
            TriggerSource = _pi.GetAwgTriggerSource();
        }

        #endregion

        #region TRIGger:WVALue

        // glennj 7/23/2013
        /// <summary>
        /// Using TRIGger:WVALue set a trigger wait on trigger value
        /// </summary>
        /// <param name="setValue"></param>
        public void SetTriggerWValue(string setValue)
        {
            _pi.SetAwgTriggerWValue(setValue);
        }

        // glennj 7/23/2013
        /// <summary>
        ///  Using TRIGger:WVALue? get a trigger wait on trigger value
        /// </summary>
        /// <returns></returns>
        public void GetTriggerWValue()
        {
            TriggerWaitForValue = _pi.GetAwgTriggerWValue();
        }
        #endregion

        #region AWGControl:PJUMP:SEDGE

        //Keerthi 05/28/2015
        /// <summary>
        /// AWGControl:PJUMP:SEDGE sets the strobe edge value to RISING/FALLING
        /// </summary>
        /// <param name="strobEdge">strobeEdge value FALLING/RISING</param>

        public void SetStrobEdge(string strobEdge)
        {

            _pi.SetStrobEdge(strobEdge);

        }

        #endregion AWGControl:PJUMP:SEDGE

        #region AWGControl:PJUMP:SEDGE?

        //Keerthi 05/28/2015
        /// <summary>
        /// AWGControl:PJUMP:SEDGE? Gets the strobe edge value
        /// </summary>


        public void GetStrobEdge()

        {
            strobEdgeQueried = _pi.GetStrobEdge();

        }

        #endregion AWGControl:PJUMP:SEDGE?


       #region AWGControl:PJUMp:JSTRobe

        //Keerthi 05/28/2015
        /// <summary>
        ///  AWGControl:PJUMp:JSTRobe sets the strobe edge value to ON/OFF
        /// </summary>
        /// <param name="setValue">set the jump on strobe value to ON/OFF</param>

        public void SetJumpOnStrobe(string setValue)
        {

            _pi.SetJumpOnStrobe(setValue);
        }

        #endregion AWGControl:PJUMp:JSTRobe
        
        
        
        #region AWGControl:PJUMp:JSTRobe?

        //Keerthi 05/28/2015
        /// <summary>
        ///  AWGControl:PJUMp:JSTRobe? gets the strobe edge value
        /// </summary>
       
    
        public void GetJumpOnStrobeStatus()
        {

            jumpOnStrobeStatusQueried = _pi.GetJumpOnStrobeStatus();
        }


        #endregion AWGControl:PJUMp:JSTRobe?

      

    }
}
