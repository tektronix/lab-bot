//==========================================================================
// CPI_ScopeDisplay.cs
//==========================================================================
namespace AwgTestFramework
{
    public partial class CPiScopeCmds
    {
        #region ScopeCommon
        #region AUTOSet EXECute
        /// <summary>
        /// Autoset the scope
        /// 
        /// AUTOSet EXECute
        /// </summary>
        public void ScopeAutoset()
        {
            const string command = "AUTOSet EXECute";
            _mScopeVisaSession.Write(command);
        }
        #endregion AUTOSet EXECute

        #region CH[n]:OFFSet
        /// <summary>
        /// Sets the channel vertical offset
        /// 
        /// CH[n]:OFFSet
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="value">Offset value</param>
        public void ScopeChannelOffset(string channel, string value)
        {
            string command = "CH" + channel + ":OFFSet ";
            _mScopeVisaSession.Write(command + value);
        }
        #endregion CH[n]:OFFSet

        #region CH[n]:SCAle
        /// <summary>
        /// Sets the Scope vertical scale for the given channel
        /// 
        /// CH[n]:SCAle
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="scale">Desired scale</param>
        public void ScopeVerticalScale(string channel, string scale)
        {
            string command = "CH" + channel + ":SCAle ";
            _mScopeVisaSession.Write(command + scale);
        }
        #endregion CH[n]:SCAle

        #region HORizontal:MAIn:POSition
        /// <summary>
        /// Set the scope horizontal position
        /// 
        /// HORizontal:MAIn:POSition
        /// </summary>
        /// <param name="position">Desired horizontal position</param>
        public void ScopeHorizontalPosition(string position)
        {
            const string command = "HORizontal:MAIn:POSition ";
            _mScopeVisaSession.Write(command + position);
        }
        #endregion HORizontal:MAIn:POSition
        #endregion ScopeCommon

        #region CSA Only
        #region AUTOSet:TYPE
        /// <summary>
        /// Sets the CSA autoset type
        /// 
        /// AUTOSet:TYPE
        /// </summary>
        /// <param name="type">Autoset type</param>
        public void CSAAutosetType(string type)
        {
            const string command = "AUTOSet:TYPE ";
            _mScopeVisaSession.Write(command + type);
        }
        #endregion AUTOSet:TYPE

        #region HORizontal:MAIn:SCAle
        /// <summary>
        /// Sets the CSA horizonal scale
        /// 
        /// HORizontal:MAIn:SCAle
        /// </summary>
        /// <param name="scale">Desired scale</param>
        public void CSAHorizontalMainScale(string scale)
        {
            const string command = "HORizontal:MAIn:SCAle ";
            _mScopeVisaSession.Write(command + scale);
        }
        #endregion HORizontal:MAIn:SCAle
        #endregion CSA Only

        #region DPO Only
        #region AUTOSet
        /// <summary>
        /// Sets the DPO autoset type
        /// 
        /// AUTOSet
        /// </summary>
        /// <param name="type">Autoset type</param>
        public void DPOAutosetType(string type)
        {
            const string command = "AUTOSet ";
            _mScopeVisaSession.Write(command + type);
        }
        #endregion AUTOSet

        #region CH[n]:TERmination
        /// <summary>
        /// This command sets the connected/disconnected status of a 50 Ω resistor, which
        /// can be connected between the specified channel's coupled input and instrument
        /// ground.
        /// 
        /// CH[n]:TERmination
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="impedance">value ex. 50.0E+0</param>
        public void DPOCHTermination(string channel, string impedance)
        {
            string command = "CH" + channel + ":TERmination ";
            _mScopeVisaSession.Write(command + impedance);
        }
        #endregion CH[n]:TERmination

        #region DISplay:PERSistence
        /// <summary>
        /// Sets the DPO display persistence
        /// 
        /// DISplay:PERSistence
        /// </summary>
        /// <param name="type">Persistence type</param>

        public void DPODisplayPersistence(string type)
        {
            const string command = "DISplay:PERSistence ";
            _mScopeVisaSession.Write(command + type);
        }
        #endregion DISplay:PERSistence

        #region HORizontal:MODE:SAMPLERate
        /// <summary>
        /// Sets the DPO horizontal sample rate in samples per seconds
        /// 
        /// HORizontal:MODE:SAMPLERate
        /// </summary>
        /// <param name="rate">Desired rate value sent in this format 5.0000E+6</param>
        public void DPOHorizontalModeSampleRate(string rate)
        {
            const string command = "HORizontal:MODE:SAMPLERate ";
            _mScopeVisaSession.Write(command + rate);
        }
        #endregion HORizontal:MODE:SAMPLERate

        #region HORizontal:MODE:SCAle
        /// <summary>
        /// Sets the DPO horizontal scale in seconds per division
        /// 
        /// HORizontal:MODE:SCAle
        /// </summary>
        /// <param name="scale">Desired scale value sent in the format of 20.0000E-6</param>
        public void DPOHorizontalModeScale(string scale)
        {
            const string command = "HORizontal:MODE:SCAle ";
            _mScopeVisaSession.Write(command + scale);
        }
        #endregion HORizontal:MODE:SCAle

        #region REF[n]:VERTical:SCAle
        /// jmanning 01/08/14
        /// Added DPO support       
        /// <summary>
        /// Sets the DPO vertical scale for the given reference waveform
        /// 
        /// REF[n]:VERTical:SCAle
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="scale">Desired scale</param>
        public void DPORefVerticalScale(string channel, string scale)
        {
            string command = "REF" + channel + ":VERTical:SCAle ";
            _mScopeVisaSession.Write(command + scale);
        }
        #endregion REF[n]:VERTical:SCAle
        #endregion DPO Only
    }
}
