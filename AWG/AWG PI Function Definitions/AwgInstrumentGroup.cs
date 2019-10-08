//==========================================================================
// AwgInstrumentGroup.cs
//==========================================================================

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains helper functions that are called from the %AWG Instrument PI step definitions.
    /// This class has no restrictions as to where it will be used.
    /// 
    /// This "Helper" group does everything else but steps and TekVISA.
    /// Using parameters from the step, each helper will makes decisions
    /// such as send commands, or process responses from queries and
    /// do testing and generate asserts if necessary.
    /// 
    /// \ingroup grouphelperpi pisteps 
    /// </summary>
    public class AwgInstrumentGroup
    {
        public enum InstrumentCoupleSource { On, Off }

        private const string InstrumentCoupleSourceOutSyntaxOn = "ON";
        private const string InstrumentCoupleSourceOutSyntaxOff = "OFF";

        private const string InstrumentCoupleSourceInSyntaxOn = "1";
        private const string InstrumentCoupleSourceInSyntaxOff = "0";

        public enum InstrumentMode { Awg, FGen}

        private const string SyntaxForInstrumentModeAwg = "AWG";
        private const string SyntaxForInstrumentModeFgen = "FGEN";

        /// <summary>
        /// Sets the awg's instrument couple source
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="setValue"></param>
        public void SetTheAwgInstrumentCoupleSource(IAWG awg, InstrumentCoupleSource setValue)
        {
            string outSyntax = setValue == InstrumentCoupleSource.On
                                   ? InstrumentCoupleSourceOutSyntaxOn
                                   : InstrumentCoupleSourceOutSyntaxOff;
            awg.SetInstrumentCoupleSource(outSyntax);
        }

        /// <summary>
        /// Forces the awg to update it copy of the instrument couple source mode
        /// </summary>
        /// <param name="awg"></param>
        public void GetTheAwgInstrumentCoupleSource(IAWG awg)
        {
            awg.GetInstrumentCoupleSource();
        }

        /// <summary>
        /// Given an expected value compare it to the updated copy of the instrument couple source mode
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="expectedValue"></param>
        public void AwgInstrumentCoupleSourceShouldBe(IAWG awg, InstrumentCoupleSource expectedValue)
        {
            string inSyntax = expectedValue == InstrumentCoupleSource.On
                                   ? InstrumentCoupleSourceInSyntaxOn
                                   : InstrumentCoupleSourceInSyntaxOff;
            const string possibleErrorMessage = "Checking the returned Instrument Couple Source state";
            Assert.AreEqual(awg.InstrumentCoupleSource, inSyntax, possibleErrorMessage);
        }

        #region INSTrument:MODE

      /// <summary>
      /// Set the awg's instrument mode
      /// </summary>
      /// <param name="awg"></param>
      /// <param name="setMode"></param>
      public void SetInstrumentMode(IAWG awg, InstrumentMode setMode)
      {
          var setValue = (setMode == InstrumentMode.Awg)
                        ? SyntaxForInstrumentModeAwg
                        : SyntaxForInstrumentModeFgen;
          awg.SetInstrumentMode(setValue);
      }

      /// <summary>
      /// Force the awg to update it's copy of the instrument mode
      /// </summary>
      /// <param name="awg"></param>
      public void GetInstrumentMode(IAWG awg)
      {
          awg.GetInstrumentMode();
      }

      /// <summary>
      /// Given an expect mode, compare it to the updated copy of the instrument mode
      /// </summary>
      /// <param name="awg"></param>
      /// <param name="expectedMode"></param>
      public void AwgInstrumentModeShouldBe(IAWG awg, InstrumentMode expectedMode)
      {
          var expectedValue = (expectedMode == InstrumentMode.Awg)
                        ? SyntaxForInstrumentModeAwg
                        : SyntaxForInstrumentModeFgen;
           
            Assert.AreEqual(expectedValue, awg.InstrumentMode);
      }

      #endregion INSTrument:MODE
  }
}

