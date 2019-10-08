//==========================================================================
// ExtSourceMemory__steps.cs
// This file contains the low-order PI step definitions for the External Source PI Memory Group commands. 
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
    /// This class contains the low-order PI step definitions for the External Source PI Memory Group commands.

    /// Low-level steps set and get the values for commands, and test the raw values as returned from the 
    /// instrument. They DO NOT interpret values in any way! Interpretation, normalization, etc. need to 
    /// occur in the High-level step definitions. Notice the use of the word "value" in the steps - this 
    /// usually implies that the query returns a 0 or 1 or abbreviated text value (like SOFT) that should 
    /// be interpreted as ON or OFF or SOFTWARE to make the step more user-friendly. We do that in the 
    /// High-order step definitions.
    /// 
    /// </summary> 
    [Binding] //Very important! This entry needs to be made in each step definition file.
    public class ExtSourceMemorySteps
    {
        private readonly ExtSourceMemoryGroup _extSourceMemoryGroup = new ExtSourceMemoryGroup();

        #region MMEMory:DELete
        /// <summary>
        /// Deletes a file of directory from the mass storage unit.
        /// 
        /// MMEMory:DELete
        /// </summary>
        /// <param name="filename">Name of waveform</param>
        /// <param name="msus">Mass storage unit specifier</param>
        /*!
           @massmemory\verbatim
        [When(@"I delete file or directory ""(.+)"" in the mass storage unit ""(.+|)"" of the External Source")]
           \endverbatim 
       */
        [When(@"I delete file or directory ""(.+)"" in the mass storage unit ""(.+|)"" of the External Source")]
        public void DeleteFileorDirectoryInMassStorageOnExtSrc(string filename, string msus)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceMemoryGroup.DeleteExtSrcMemFile(extSource, filename, msus);
        }
        #endregion MMEMory:DELete

        #region MMEMory:IMPort
        /// <summary>
        /// Imports an ISF file into the External Source’s setup as a waveform
        /// ISF is TDS3000 and DPO4000 waveform format
        /// 
        /// MMEMory:IMPort
        /// </summary>
        /// <param name="wfmName">Name that the imported waveform will have </param>
        /// <param name="fileName">Path of the file to be imported</param>
        /*!
            \extsource\verbatim
        [When(@"I import (.+) from the ""(.+)""  file as format type (ISF|TDS|WFM|PAT|TFW|IQT|TIQ|(?:TXT(?:8|10|14)?)) to the External Source")]
            \endverbatim 
        */
        [When(@"I import (.+) from the ""(.+)""  file as format type (ISF|TDS|WFM|PAT|TFW|IQT|TIQ|(?:TXT(?:8|10|14)?)) to the External Source")]
        public void ImportFileIntoExtSrc(string wfmName, string fileName, string format)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceMemoryGroup.SetExtSrcMemImport(extSource, wfmName, fileName, format);
        }
        
        /// <summary>
        /// Imports an ISF file into the External Source’s setup as a waveform
        /// ISF is TDS3000 and DPO4000 waveform format
        /// 
        /// MMEMory:IMPort
        /// </summary>
        /// <param name="wfmName">Name that the imported waveform will have </param>
        /// <param name="fileName">Path of the file to be imported</param>
        /*!
            \extsource\verbatim
        [When(@"I import (.+) from the ""(.+)"" file as ISP format to the External Source")]
            \endverbatim 
        */
        [When(@"I import (.+) from the ""(.+)"" file as ISF format to the External Source")]
        public void ImportIsfFileIntoExtSrc(string wfmName, string fileName)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceMemoryGroup.SetExtSrcMemImport(extSource, wfmName, fileName,"ISF");
        }

        /// <summary>
        /// Imports a IQT file into the External Source’s setup as a waveform
        /// IQT is RSA3000 series waveform file format
        /// 
        /// MMEMory:IMPort
        /// </summary>
        /// <param name="wfmName">Name that the imported waveform will have </param>
        /// <param name="fileName">Path of the file to be imported</param>
        /*!
            \extsource\verbatim
        [When(@"I import (.+) from the ""(.+)"" file as IQT format to the External Source")]
            \endverbatim 
        */
        [When(@"I import (.+) from the ""(.+)"" file as IQT format to the External Source")]
        public void ImportIqtFileIntoExtSrc(string wfmName, string fileName)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceMemoryGroup.SetExtSrcMemImport(extSource, wfmName, fileName, "IQT");
        }

        /// <summary>
        /// Imports a PAT file into the External Source’s setup as a waveform
        /// PAT is AWG400/AWG500/AWG600/AWG700 Series pattern file 
        /// 
        /// MMEMory:IMPort
        /// </summary>
        /// <param name="wfmName">Name that the imported waveform will have </param>
        /// <param name="fileName">Path of the file to be imported</param>
        /*!
            \extsource\verbatim
        [When(@"I import (.+) from the ""(.+)"" file as PAT format to the External Source")]
            \endverbatim 
        */
        [When(@"I import (.+) from the ""(.+)"" file as PAT format to the External Source")]
        public void ImportPatFileIntoExtSrc(string wfmName, string fileName)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceMemoryGroup.SetExtSrcMemImport(extSource, wfmName, fileName, "PAT");
        }

        /// <summary>
        /// Imports a TDS file into the External Source’s setup as a waveform
        /// TDS is TDS5000/TDS6000/TDS7000,DPO7000/DPO70000/DSA70000 Series waveform
        /// 
        /// MMEMory:IMPort
        /// </summary>
        /// <param name="wfmName">Name that the imported waveform will have </param>
        /// <param name="fileName">Path of the file to be imported</param>
        /*!
            \extsource\verbatim
        [When(@"I import (.+) from the ""(.+)"" file as TDS format to the External Source")]
            \endverbatim 
        */
        [When(@"I import (.+) from the ""(.+)"" file as TDS format to the External Source")]
        public void ImportTdsFileIntoExtSrc(string wfmName, string fileName)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceMemoryGroup.SetExtSrcMemImport(extSource, wfmName, fileName, "TDS");
        }

        /// <summary>
        /// Imports a TFW file into the External Source’s setup as a waveform
        /// TFW is AFG3000 Series waveform file format
        /// 
        /// MMEMory:IMPort
        /// </summary>
        /// <param name="wfmName">Name that the imported waveform will have </param>
        /// <param name="fileName">Path of the file to be imported</param>
        /*!
            \extsource\verbatim
        [When(@"I import (.+) from the ""(.+)"" file as TFW format to the External Source")]
            \endverbatim 
        */
        [When(@"I import (.+) from the ""(.+)"" file as TFW format to the External Source")]
        public void ImportTfwFileIntoExtSrc(string wfmName, string fileName)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceMemoryGroup.SetExtSrcMemImport(extSource, wfmName, fileName, "TFW");
        }

        /// <summary>
        /// Imports a TIQ file into the External Source’s setup as a waveform
        /// TIQ is RSA6000 Series waveform file format
        /// 
        /// MMEMory:IMPort
        /// </summary>
        /// <param name="wfmName">Name that the imported waveform will have </param>
        /// <param name="fileName">Path of the file to be imported</param>
        /*!
            \extsource\verbatim
        [When(@"I import (.+) from the ""(.+)"" file as TIQ format to the External Source")]
            \endverbatim 
        */
        [When(@"I import (.+) from the ""(.+)"" file as TIQ format to the External Source")]
        public void ImportTiqFileIntoExtSrc(string wfmName, string fileName)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceMemoryGroup.SetExtSrcMemImport(extSource, wfmName, fileName, "TIQ");
        }

        /// <summary>
        /// Imports a text file into the External Source’s setup as a waveform
        /// TXT is a text file with analog data

        /// MMEMory:IMPort
        /// </summary>
        /// <param name="wfmName">Name that the imported waveform will have </param>
        /// <param name="fileName">Path of the file to be imported</param>
        /*!
            \extsource\verbatim
        [When(@"I import (.+) from the ""(.+)"" file as text format to the External Source")]
            \endverbatim 
        */
        [When(@"I import (.+) from the ""(.+)"" file as text format to the External Source")]
        public void ImportTxtFileIntoExtSrc(string wfmName, string fileName)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceMemoryGroup.SetExtSrcMemImport(extSource, wfmName, fileName, "TXT");
        }

        /// <summary>
        /// Imports a TXT8 file into the External Source’s setup as a waveform
        /// TXT8 is a text file with 8-bit DAC resolution
        /// 
        /// MMEMory:IMPort
        /// </summary>
        /// <param name="wfmName">Name that the imported waveform will have </param>
        /// <param name="fileName">Path of the file to be imported</param>
        /*!
            \extsource\verbatim
        [When(@"I import (.+) from the ""(.+)"" file as TXT8 format to the External Source")]
            \endverbatim 
        */
        [When(@"I import (.+) from the ""(.+)"" file as TXT8 format to the External Source")]
        public void ImportTxt8FileIntoExtSrc(string wfmName, string fileName)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceMemoryGroup.SetExtSrcMemImport(extSource, wfmName, fileName, "TXT8");
        }

        /// <summary>
        /// Imports a TXT10 file into the External Source’s setup as a waveform
        /// TXT10 is a text file with 10-bit DAC resolution

        /// MMEMory:IMPort
        /// </summary>
        /// <param name="wfmName">Name that the imported waveform will have </param>
        /// <param name="fileName">Path of the file to be imported</param>
        /*!
            \extsource\verbatim
        [When(@"I import (.+) from the ""(.+)"" file as TXT10 format to the External Source")]
            \endverbatim 
        */
        [When(@"I import (.+) from the ""(.+)"" file as TXT10 format to the External Source")]
        public void ImportTxt10FileIntoExtSrc(string wfmName, string fileName)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceMemoryGroup.SetExtSrcMemImport(extSource, wfmName, fileName, "TXT10");
        }

        /// <summary>
        /// Imports a TXT14 file into the External Source’s setup as a waveform
        /// TXT14 is a text file with 14-bit DAC resolution

        /// MMEMory:IMPort
        /// </summary>
        /// <param name="wfmName">Name that the imported waveform will have </param>
        /// <param name="fileName">Path of the file to be imported</param>
        /*!
            \extsource\verbatim
        [When(@"I import (.+) from the ""(.+)"" file as TXT14 format to the External Source")]
            \endverbatim 
        */
        [When(@"I import (.+) from the ""(.+)"" file as TXT14 format to the External Source")]
        public void ImportTxt14FileIntoExtSrc(string wfmName, string fileName)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceMemoryGroup.SetExtSrcMemImport(extSource, wfmName, fileName, "TXT14");
        }

        /// <summary>
        /// Imports a WFM file into the External Source’s setup as a waveform
        /// WFM is AWG400/AWG500/AWG600/AWG700 Series Waveform

        /// MMEMory:IMPort
        /// </summary>
        /// <param name="wfmName">Name that the imported waveform will have </param>
        /// <param name="fileName">Path of the file to be imported</param>
        /*!
            \extsource\verbatim
        [When(@"I import (.+) from the ""(.+)"" file as WFM format to the External Source")]
            \endverbatim 
        */
        [When(@"I import (.+) from the ""(.+)"" file as WFM format to the External Source")]
        public void ImportWfmFileIntoExtSrc(string wfmName, string fileName)
        {
            IEXTSOURCE extSource = EXTSOURCE.GetExtSource(false);
            _extSourceMemoryGroup.SetExtSrcMemImport(extSource, wfmName, fileName, "WFM");
        }
        #endregion MMEMory:IMPort
    }
}
