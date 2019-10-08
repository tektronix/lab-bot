//==========================================================================
// SCOPE_DisplaySection.cs
//==========================================================================
namespace AwgTestFramework
{
    public partial class SCOPE
    {
        /// <summary>
        /// Autoset the Scope
        /// 
        /// uses AUTOSet EXECute
        /// </summary>
        public void ScopeAutosetExecute()
        {
            _pis.ScopeAutoset();
        }

        /// <summary>
        /// Sets the Scope channel vertical offset
        /// 
        /// CH[n]:OFFSet
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="value">Offset value</param>
        public void SetScopeChannelOffset(string channel, string value)
        {
            _pis.ScopeChannelOffset(channel, value);
        }

        /// <summary>
        /// Sets the Scope vertical scale for the given channel
        /// 
        /// use CH[n]:SCAle
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="scale">Desired scale</param>
        public void SetScopeVerticalScale(string channel, string scale)
        {
            _pis.ScopeVerticalScale(channel, scale);
        }
       
        /// <summary>
        /// Set the scope horizontal position
        /// 
        /// uses HORizontal:MAIn:POSition
        /// </summary>
        /// <param name="position">Desired horizontal position</param>
        public void SetScopeHorizontalPosition(string position)
        {
            _pis.ScopeHorizontalPosition(position);
        }

        /// <summary>
        /// Sets the CSA autoset type
        /// 
        /// uses AUTOSet:TYPE
        /// </summary>
        /// <param name="type">Autoset type</param>
        public void SetCSAAutosetType(string type)
        {
            _pis.CSAAutosetType(type);
        }

        /// <summary>
        /// Sets the CSA horizonal scale
        /// 
        /// uses HORizontal:MAIn:SCAle
        /// </summary>
        /// <param name="scale">Desired scale</param>
        public void SetCSAHorizontalMainScale(string scale)
        {
            _pis.CSAHorizontalMainScale(scale);
        }

        /// <summary>
        /// Sets the DPO autoset type
        /// 
        /// AUTOSet
        /// </summary>
        /// <param name="type">Autoset type</param>
        public void SetDPOAutosetType(string type)
        {
            _pis.DPOAutosetType(type);
        }

        /// <summary>
        /// Sets the connected/disconnected status of a 50 Ω resistor, which
        /// can be connected between the specified channel's coupled input and instrument
        /// ground on a DPO.
        /// 
        /// uses CH[n]:TERmination
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="impedance">value ex. 50.0E+0</param>
        public void SetDPOCHTermination(string channel, string impedance)
        {
            _pis.DPOCHTermination(channel, impedance);
        }

        /// <summary>
        /// Sets the DPO display persistence
        /// 
        /// uses DISplay:PERSistence
        /// </summary>
        /// <param name="type">Persistence type</param>
        public void SetDPODisplayPersistence(string type)
        {
            _pis.DPODisplayPersistence(type);
        }

        /// <summary>
        /// Sets the DPO horizontal sample rate in samples per seconds
        /// 
        /// uses HORizontal:MODE:SAMPLERate
        /// </summary>
        /// <param name="rate">Desired rate value sent in this format 5.0000E+6</param>
        public void SetDPOHorizontalModeSampleRate(string rate)
        {
            _pis.DPOHorizontalModeSampleRate(rate);
        }

        /// <summary>
        /// Sets the DPO horizontal scale in seconds per division
        /// 
        /// use HORizontal:MODE:SCAle
        /// </summary>
        /// <param name="scale">Desired scale value sent in the format of 20.0000E-6</param>
        public void SetDPOHorizontalModeScale(string scale)
        {
            _pis.DPOHorizontalModeScale(scale);
        }
   
        /// <summary>
        /// Sets the DPO vertical scale for the given reference waveform
        /// 
        /// uses REF[n]:VERTical:SCAle
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="scale">Desired scale</param>
        public void SetDPORefVerticalScale(string channel, string scale)
        {
            _pis.DPORefVerticalScale(channel, scale);
        }

    }
}
