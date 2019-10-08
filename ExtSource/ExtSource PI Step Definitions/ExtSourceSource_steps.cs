//==========================================================================
// ExtSourceSource__steps.cs
// This file contains the low-order PI step definitions for the External Source PI Source Group commands. 
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
    /// This class contains the low-order PI step definitions for the External Source PI Source Group commands.

    /// Low-level steps set and get the values for commands, and test the raw values as returned from the 
    /// instrument. They DO NOT interpret values in any way! Interpretation, normalization, etc. need to 
    /// occur in the High-level step definitions. Notice the use of the word "value" in the steps - this 
    /// usually implies that the query returns a 0 or 1 or abbreviated text value (like SOFT) that should 
    /// be interpreted as ON or OFF or SOFTWARE to make the step more user-friendly. We do that in the 
    /// High-order step definitions.
    /// 
    /// </summary> 
    [Binding] //Very important! This entry needs to be made in each step definition file.
    public class ExtSourceSourceSteps
    {
        private readonly ExtSourceSourceGroup _extSourceSourceGroup = new ExtSourceSourceGroup();
        private readonly UTILS.Converter _converter = new UTILS.Converter();

        #region SOURce[n]:DAC:RESolution
        /// <summary>
        /// Sets the DAC resolution to 8 bits for the specified channel on the External Source
        /// 
        /// SOURce[n]::DAC:RESolution 8
        /// </summary>
        /// <param name="channel">channel to use as source</param>
        /*!
            \source\verbatim
        [When(@"I set the DAC resolution to 8 bits for channel (\d?) on the External Source")]
            \endverbatim 
        */
        [When(@"I set the DAC resolution to 8 bits for channel (\d?) on the External Source")]
        public void SetExtSrcDacResolution8Bits(string channel)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false); 
            extSource.SetExtSrcDacResolution(channel, "8");
        }

        /// <summary>
        /// Sets the DAC resolution to 10 bits for the specified channel on the External Source
        /// 
        /// SOURce[n]::DAC:RESolution 10
        /// </summary>
        /// <param name="channel">channel to use as source</param>
        /*!
            \source\verbatim
        [When(@"I set the DAC resolution to 10 bits for channel (\d?) on the External Source")]
            \endverbatim 
        */
        [When(@"I set the DAC resolution to 10 bits for channel (\d?) on the External Source")]
        public void SetExtSrcDacResolution10Bits(string channel)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            extSource.SetExtSrcDacResolution(channel, "10");
        }
        #endregion SOURce[n]:DAC:RESolution

        #region SOURce[n]:DAC:RESolution?
        /// <summary>
        /// Gets the DAC resolution for the specified channel on the External Source
        /// 
        /// SOURce[n]::DAC:RESolution?
        /// </summary>
        /// <param name="channel">channel to use as source</param>
        /// <returns>DAC resolution in bits</returns>
        /*!
            \source\verbatim
        [When(@"I get the DAC resolution for channel (\d?) on the External Source")]
            \endverbatim 
        */
        [When(@"I get the DAC resolution for channel (\d?) on the External Source")]
        public void GetExtSrcDacResolution(string channel)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false); 
            _extSourceSourceGroup.GetExtSrcDacResolution(extSource, channel);
        }
        #endregion SOURce[n]:DAC:RESolution?
        
        #region SOURce[n]:FREQuency:CW
        /// <summary>
        /// Sets the sampling frequency of the %AWG
        /// 
        ///                     SamplingFrequency
        /// OutputFrequency =   ----------------
        ///                     Number of Points                    
        /// [SOURce[1]]:?FREQuency[:?CW|:?FIXed]
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Sampling Frequency</param>
        /// <param name="units">MHz or GHz</param>
        /*!
            \source\verbatim
        [When(@"I set the sampling frequency for channel (\d?) to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?)(MHz|GHz) on the External Source")]
            \endverbatim 
        */
        [When(@"I set the sampling frequency for channel (\d?) to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?)(MHz|GHz) on the External Source")]
        public void SetTheExtSrcSamplingFrequencywUnits(string channel, string setValue, string units)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            string valueToSet = _converter.GigaToMegaHertz(setValue, units);
            _extSourceSourceGroup.SetExtSrcFreq(extSource, channel, valueToSet);
        }

        /// <summary>
        /// Sets the sampling frequency of the %AWG
        /// 
        ///                     SamplingFrequency
        /// OutputFrequency =   ----------------
        ///                     Number of Points                    
        /// [SOURce[1]]:?FREQuency[:?CW|:?FIXed]
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Sampling Frequency</param>
        /*!
            \source\verbatim
        [When(@"I set the sampling frequency for channel (\d?) to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) on the External Source")]
            \endverbatim 
        */
        [When(@"I set the sampling frequency for channel (\d?) to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) on the External Source")]
        public void SetTheExtSrcSamplingFrequency(string channel, string setValue)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceSourceGroup.SetExtSrcFreq(extSource, channel, setValue);
        }
        #endregion SOURce[n]:FREQuency:CW

        #region SOURce[n]:FUNCtion:USER
        /// <summary>
        /// Imports a file into the External Source’s setup as a waveform
        /// 
        /// [SOURce[n]]:FUNCtion:USER
        /// </summary>
        /// <param name="filename">Path of the file to be imported</param>
        /// <param name="channel">Which channel</param>
        /*!
            \extSource\verbatim
        [When(@"I import from the ""(.+)"" file into channel (1|2|3|4) of the External Source")]
            \endverbatim 
        */
        [When(@"I import from the ""(.+)"" file into channel (1|2|3|4) of the External Source")]
        public void ImportAFileIntoAnExtSrcChannel(string filename, string channel)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceSourceGroup.SetExtSrcFunctUser(extSource, filename, channel);
        }
        #endregion SOURce[n]:FUNCtion:USER

        #region SOURce[n]:VOLTage:AMPLitude
        /// <summary>
        /// Sets the channel's waveform amplitude
        /// 
        /// SOURce[n]:VOLTage:AMPLitude
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Desired amplitude</param>
        /*!
            \source\verbatim
        [When(@"I set channel (1|2|3|4) amplitude to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) on the External Source")]
            \endverbatim 
        */
        [When(@"I set channel (1|2|3|4) amplitude to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) on the External Source")]
        public void SetTheExtSrcChannelAmplitude(string channel, string setValue)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceSourceGroup.SetExtSrcVoltAmpl(extSource, channel, setValue);
        }
        #endregion SOURce[n]:VOLTage:AMPLitude

        #region SOURce[n]:VOLTage:HIGH
        /// <summary>
        /// Sets the channel's waveform high volatge value
        /// 
        /// SOURce[n]:VOLTage:HIGH
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Desired high voltage level</param>
        /*!
            \source\verbatim
        [When(@"I set channel (1|2|3|4) high value to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) on the External Source")]
            \endverbatim 
        */
        [When(@"I set channel (1|2|3|4) high value to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) on the External Source")]
        public void SetTheExtSrcChannelHigh(string channel, string setValue)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceSourceGroup.SetExtSrcVoltHigh(extSource, channel, setValue);
        }
        #endregion SOURce[n]:VOLTage:HIGH

        #region SOURce[n]:VOLTage:LOW
        /// <summary>
        /// Sets the channel's waveform low voltage level
        /// 
        /// SOURce[n]:VOLTage:LOW
        /// </summary>
        /// <param name="channel">Which channel</param>
        /// <param name="setValue">Desired low voltage level</param>
        /*!
            \source\verbatim
        [When(@"I set channel (1|2|3|4) low value to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) on the External Source")]
            \endverbatim 
        */
        [When(@"I set channel (1|2|3|4) low value to ([-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?) on the External Source")]
        public void SetTheExtSrcChannelLow(string channel, string setValue)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceSourceGroup.SetExtSrcVoltLow(extSource, channel, setValue);
        }
        #endregion SOURce[n]:VOLTage:LOW

        #region SOURce[n]:WAVeform
        /// <summary>
        /// Imports a file into the External Source’s setup as a waveform already inncluded in the waveform list
        /// 
        /// [SOURce[n]]:WAVeform
        /// </summary>
        /// <param name="waveform">Waveform name predefined files are also valid, add a * in front of the name</param>
        /// <param name="channel">Which channel</param>
        /*!
            \extSource\verbatim
        [When(@"I import from the filename ""(.+)"" from the waveform list into channel ([1-4]) of the External Source")]
            \endverbatim 
        */
        [When(@"I import from the filename ""(.+)"" from the waveform list into channel ([1-4]) of the External Source")]
        public void ImportAFileFromWlistIntoAnExtSrcChannel(string waveform, string channel)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceSourceGroup.SetExtSrcWaveform(extSource, waveform, channel);
        }
        #endregion SOURce[n]:WAVeform
    }
}
