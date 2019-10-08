

namespace AwgTestFramework
{
    public partial class AWG
    {

        public string InstrumentMode { get; set; }
        public string InstrumentCoupleSource { get; set; }

        //glennj 06/20/2013
        /// <summary>
        /// Sets the instrument couple source mode of this awg
        /// </summary>
        /// <param name="setValue">Desired mode</param>
        public void SetInstrumentCoupleSource(string setValue)
        {
            _pi.SetAwgInstrumentCoupleSource(setValue);
        }

        //glennj 06/20/2013
        /// <summary>
        /// Forces the awg to update its copy of instrument couple source mode
        /// </summary>
        /// <returns>Run Mode</returns>
        public void GetInstrumentCoupleSource()
        {
            InstrumentCoupleSource = _pi.GetAwgInstrumentCoupleSource();
        }

        //glennj 06/20/2013
        /// <summary>
        /// Set the %AWG instrument mode between AWG or FGen mode
        /// </summary>
        /// <param name="setValue">The desired instrument mode</param>
        public void SetInstrumentMode(string setValue)
        {
            _pi.SetAwgInstrumentMode(setValue);
        }

        //glennj 06/20/2013
        /// <summary>
        /// Forces this awg to updates it's copy of the instrument mode
        /// </summary>
        /// <returns>Current instrument mode</returns>
        public void GetInstrumentMode()
        {
            InstrumentMode = _pi.GetAwgInstrumentMode();
        }

    }
}
