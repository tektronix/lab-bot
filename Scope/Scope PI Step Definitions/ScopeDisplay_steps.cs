//==========================================================================
// ScopeDisplay__steps.cs
// This file contains the low-order PI step definitions for the Scope PI Acquisition Group commands. 
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
// File path strings - ""(.+)"" used when you want the string that is delimited by the quotes File path strings
//                         
//==========================================================================

using TechTalk.SpecFlow;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains the low-order PI step definitions for the Scope PI Display Group commands.

    /// Low-level steps set and get the values for commands, and test the raw values as returned from the 
    /// instrument. They DO NOT interpret values in any way! Interpretation, normalization, etc. need to 
    /// occur in the High-level step definitions. Notice the use of the word "value" in the steps - this 
    /// usually implies that the query returns a 0 or 1 or abbreviated text value (like SOFT) that should 
    /// be interpreted as ON or OFF or SOFTWARE to make the step more user-friendly. We do that in the 
    /// High-order step definitions.
    /// 
    /// </summary> 
    [Binding] //Very important! This entry needs to be made in each step definition file.
    public class ScopeDisplaySteps
    {
        private readonly ScopeDisplayGroup _scopeDisplayGroup = new ScopeDisplayGroup();

        #region AUTOSet
        /// <summary>
        /// Sets the Autoset type to UNDo on the DPO Scope
        /// This commands reverses the previous Autoset command
        /// 
        /// AUTOSet UNDo
        /// </summary>
        /*!
		   \scope\verbatim
		[When(@"I set the autoset to revert to previous setting on the Scope")]
		   \endverbatim 
	   */
        [When(@"I set the autoset to revert to previous setting on the Scope")]
        public void SetTheScopeAutosetTypeUndo()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeDisplayGroup.SetDPOAutosetType(scope, "UNDo");
        }

        /// <summary>
        /// Sets the Autoset type to VFields on the DPO Scope
        /// 
        /// AUTOSet VFields
        /// </summary>
        /*!
		   \scope\verbatim
		[When(@"I set the autoset to video fields on the Scope")]
		   \endverbatim 
	   */
        [When(@"I set the autoset to video fields on the Scope")]
        public void SetTheScopeAutosetTypeVFields()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeDisplayGroup.SetDPOAutosetType(scope, "VFields");
        }

        /// <summary>
        /// Sets the Autoset type to VIDeo on the DPO Scope
        /// 
        /// AUTOSet VIDeo
        /// </summary>
        /*!
		   \scope\verbatim
		[When(@"I set the autoset to video on the Scope")]
		   \endverbatim 
	   */
        [When(@"I set the autoset to video on the Scope")]
        public void SetTheScopeAutosetTypeVideo()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeDisplayGroup.SetDPOAutosetType(scope, "VIDeo");
        }

        /// <summary>
        /// Sets the Autoset type to VLines on the DPO Scope
        /// 
        /// AUTOSet VLines
        /// </summary>
        /*!
		   \scope\verbatim
		[When(@"I set the autoset to video lines on the Scope")]
		   \endverbatim 
	   */
        [When(@"I set the autoset to video lines on the Scope")]
        public void SetTheScopeAutosetTypeVLines()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeDisplayGroup.SetDPOAutosetType(scope, "VLines");
        }

        #endregion AUTOSet
        
        #region AUTOSet EXECute

        /// <summary>
        /// Autosets the Scope
        /// 
        /// (DPO|CSA)
        /// AUTOSet EXECute
        /// </summary>
        /*!
			\scope\verbatim
		[When(@"I perform an autoset on the Scope")]
			\endverbatim 
		*/
        [When(@"I perform an autoset on the Scope")]
        public void AutosetTheScope()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeDisplayGroup.RunScopeAutoset(scope);
        }

        #endregion AUTOSet EXECute

        #region CH[n]:OFFSet

        /// <summary>
        /// Sets the vertical offset of the scope to the desired time per division
        /// 
        /// (DPO|CSA)
        /// CH[n]:OFFSet
        /// </summary>
        /// <param name="channel">Channel that the vertical scale is needed for</param>
        /// <param name="offset">Desired vertical offset value </param>
        /*!
		    \scope\verbatim
		[When(@"I set channel ([1-4]) vertical offset to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) on the Scope")]
	        \endverbatim 
	    */
        [When(@"I set channel ([1-4]) vertical offset to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) on the Scope")]
        public void SetScopeChannelVerticalOffset(string channel, string offset)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeDisplayGroup.SetScopeChannelOffset(scope, channel, offset);
        }

        #endregion CH[n]:OFFSet

        #region CH[n]:SCAle
        /// <summary>
        /// Sets the vertical scale of the scope to the desired time per division
        /// 
        ///
        /// (DPO|CSA)
        /// CH[n]:SCAle
        /// </summary>
        /// <param name="channel">Channel that the vertical scale is needed for</param>
        /// <param name="scale">Desired vertical scale</param>
        /*!
		    \scope\verbatim
	    [When(@"I set channel ([1-4]) vertical scale to ([0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) on the Scope")]
		    \endverbatim 
	    */
        [When(@"I set channel ([1-4]) vertical scale to ([0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) on the Scope")]
        public void SetScopeChannelVerticalScale(string channel, string scale)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeDisplayGroup.SetScopeVerticalScale(scope, channel, scale);
        }
        #endregion CH[n]:SCAle

        #region CH[n]:TERmination

        /// <summary>
        /// Sets the connected/disconnected status of a 50 Ω resistor, which may be connected between the specified channel’s coupled input and instrument
        /// ground
        /// 
        /// CH[n]:TERmination 50.0E+0
        /// </summary>
        /// <param name="channel">Which channel</param>
        /*!
			\scope\verbatim
		[When(@"I set channel ([1-4]) impedance to 50 ohm on the Scope")]
			\endverbatim 
		*/
        [When(@"I set channel ([1-4]) impedance to 50 ohm on the Scope")]
        public void SetScopeChannelImpedance50(string channel)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeDisplayGroup.SetDPOCHTermination(scope, channel, "50.0E+0");
        }

        /// <summary>
        /// Sets the connected/disconnected status of a 50 Ω resistor, which may be connected between the specified channel’s coupled input and instrument
        /// ground
        /// 
        /// CH[n]:TERmination 10.0E+5
        /// </summary>
        /// <param name="channel">Which channel</param>
        /*!
			\scope\verbatim
		[When(@"I set channel ([1-4]) impedance to 1000000 ohm on the Scope")]
			\endverbatim 
		*/
        [When(@"I set channel ([1-4]) impedance to 1000000 ohm on the Scope")]
        public void SetScopeChannelImpedanceHigh(string channel)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeDisplayGroup.SetDPOCHTermination(scope, channel, "10.0E+5");
        }

        #endregion CH[n]:TERmination

        #region DISplay:PERSistence
        /// <summary>
        /// Sets the display persistence to OFF on a DPO Scope
        /// 
        /// DISplay:PERSistence OFF
        /// </summary>
        /*!
		    \scope\verbatim
		[When("I set display persistence to off on the Scope")]
		    \endverbatim 
		*/
        [When("I set display persistence to off on the Scope")]
        public void SetTheScopeDisplayPersistenceOff()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeDisplayGroup.DPODisplayPersistence(scope, "OFF");
        }

        /// <summary>
        /// Sets the display persistence to INFPersist on the DPO Scope
        /// 
        /// DISplay:PERSistence INFPersist
        /// </summary>
        /*!
		    \scope\verbatim
		[When("I set display persistence to infinity persist on the Scope")]
		    \endverbatim 
		*/
        [When("I set display persistence to infinity persist on the Scope")]
        public void SetTheScopeDisplayPersistenceInfPersist()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeDisplayGroup.DPODisplayPersistence(scope, "INFPersist");
        }

        /// <summary>
        /// Sets the display persistence to VARpersist on the DPO Scope
        /// 
        /// DISplay:PERSistence VARpersist
        /// </summary>
        /*!
		    \scope\verbatim
		[When("I set display persistence to variable dim persist on the Scope")]
		    \endverbatim 
		*/
        [When("I set display persistence to variable dim persist on the Scope")]
        public void SetTheScopeDisplayPersistenceVarPersist()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeDisplayGroup.DPODisplayPersistence(scope, "VARpersist)");
        }
        #endregion DISplay:PERSistence

        #region HORizontal:MAIn:POSition

        /// <summary>
        /// Set the scope horizontal position
        /// 
        /// (DPO|CSA)
        /// HORizontal:MAIn:POSition
        /// </summary>
        /// <param name="position">Desired horizontal position</param>
        /*!
		 \scope\verbatim
		[When(@"I set the horizontal position to ([0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) on the Scope")]
		 \endverbatim 
	   */
        [When(@"I set the horizontal position to ([0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) on the Scope")]
        public void SetScopeHorizontalPosition(string position)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeDisplayGroup.SetScopeHorizontalPosition(scope, position);
        }

        #endregion HORizontal:MAIn:POSition

        #region HORizontal:MODE:SAMPLERate
        /// <summary>
        /// Sets the DPO horizontal sample rate in samples per seconds
        /// 
        /// HORizontal:MODE:SAMPLERate
        /// </summary>
        /// <param name="rate">Desired sample rate value sent in this format 5.0000E+6</param>
        /*!
		  \scope\verbatim
		[When(@"I set the horizontal sample rate to ([0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) on the Scope")]
		  \endverbatim 
		*/
        [When(@"I set the horizontal sample rate to ([0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) on the Scope")]
        public void SetTheScopeHorizontalSampleRate(string rate)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeDisplayGroup.SetDPOHorizontalModeSampleRate(scope, rate);
        }
        #endregion HORizontal:MODE:SAMPLERate

        #region HORizontal:MODE:SCAle

        /// <summary>
        /// Sets the horizontal scale to the desired time per division on the DPO Scope
        /// 
        /// HORizontal:MODE:SCAle
        /// </summary>
        /// <param name="scale">Desired horizontal scale</param>
        /*!
		  \scope\verbatim
		[When(@"I set the horizontal scale to ([0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) on the Scope")]
		  \endverbatim 
		*/
        [When(@"I set the horizontal scale to ([0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) on the Scope")]
        public void SetTheScopeHorizontalScale(string scale)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeDisplayGroup.SetDPOHorizontalModeScale(scope, scale);
        }

        #endregion HORizontal:MODE:SCAle

        #region REF[n]:VERTical:SCAle
        /// <summary>
        /// Sets the vertical scale for the given reference waveform on a DPO Scope
        /// 
        /// REF[n]:VERTical:SCAle
        /// </summary>
        /// <param name="refWaveform">Which reference waveform</param>
        /// <param name="scale">Desired scale</param>
        /*!
            \scope\verbatim
        [When(@"I set reference waveform ([1-4]) vertical scale to ([0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) on the Scope")]
            \endverbatim 
        */
        [When(@"I set reference waveform ([1-4]) vertical scale to ([0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) on the Scope")]
        public void SetTheScopeRefWaveformVerticalScale(string refWaveform, string scale)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeDisplayGroup.SetDPORefVerticalScale(scope, refWaveform, scale);
        }
        #endregion REF[n]:VERTical:SCAle

        #region CSA Only
        #region AUTOSet:TYPE

        /// <summary>
        /// Sets the Autoset type to edge on the CSA Scope
        /// 
        /// AUTOSet:TYPE EDGe
        /// </summary>
        /*!
            \CSA\verbatim
        [When(@"I set the autoset type to edge on the CSA")]
            \endverbatim 
        */
        [When(@"I set the autoset type to edge on the CSA")]
        public void SetTheCSAScopeAutosetTypeEdge()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeDisplayGroup.SetCSAAutosetType(scope, "EDGE");
        }

        /// <summary>
        /// Sets the Autoset type to period on the CSA Scope
        /// 
        /// AUTOSet:TYPE 
        /// </summary>
        /*!
            \CSA\verbatim
        [When(@"I set the autoset type to period on the CSA")]
            \endverbatim 
        */
        [When(@"I set the autoset type to period on the CSA")]
        public void SetTheCSAScopeAutosetTypePeriod()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeDisplayGroup.SetCSAAutosetType(scope, "PERIod");
        }

        /// <summary>
        /// Sets the Autoset type to eye on the CSA Scope
        /// 
        /// AUTOSet:TYPE 
        /// </summary>
        /*!
            \CSA\verbatim
        [When(@"I set the autoset type to eye on the CSA")]
            \endverbatim 
        */
        [When(@"I set the autoset type to eye on the CSA")]
        public void SetTheCSAScopeAutosetTypeEye()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeDisplayGroup.SetCSAAutosetType(scope, "EYE");
        }

        /// <summary>
        /// Sets the Autoset type to RZ on the CSA Scope
        /// 
        /// AUTOSet:TYPE 
        /// </summary>
        /*!
            \CSA\verbatim
        [When(@"I set the autoset type to RZ on the CSA")]
            \endverbatim 
        */
        [When(@"I set the autoset type to RZ on the CSA")]
        public void SetTheCSAScopeAutosetTypeRZ()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeDisplayGroup.SetCSAAutosetType(scope, "RZ");
        }

        /// <summary>
        /// Sets the Autoset type to TDR on the CSA Scope
        /// 
        /// AUTOSet:TYPE 
        /// </summary>
        /*!
			\CSA\verbatim
		[When(@"I set the autoset type to TDR on the CSA")]
		   \endverbatim 
			*/
        [When(@"I set the autoset type to TDR on the CSA")]
        public void SetTheCSAScopeAutosetTypeTDR()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeDisplayGroup.SetCSAAutosetType(scope, "TDR");
        }
        #endregion AUTOSet:TYPE

        #region HORizontal:MAIn:SCAle

        /// <summary>
        /// Sets the horizontal scale to the desired time per division on the CSA Scope
        /// 
        /// HORizontal:MAIn:SCAle
        /// </summary>
        /// <param name="scale">Desired horizontal scale</param>
        /*!
		  \CSA\verbatim
		[When(@"I set the horizontal scale to ([0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) on the CSA")]
		  \endverbatim 
		*/
        [When(@"I set the horizontal scale to ([0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) on the CSA")]
        public void SetCSAScopeHorizontalScale(string scale)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeDisplayGroup.SetCSAHorizontalMainScale(scope, scale);
        }

        #endregion HORizontal:MAIn:SCAle
        #endregion CSA only
    }
}
