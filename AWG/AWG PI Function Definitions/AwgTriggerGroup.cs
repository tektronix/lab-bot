//==========================================================================
// AwgTriggerGroup.cs
//==========================================================================
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
 
namespace AwgTestFramework
{
    /// <summary>
    /// This class contains helper functions that are called from the %AWG Trigger PI step definitions.
    /// This class has no restrictions as to where it will be used.
    /// 
    /// This "Helper" group does everything else but steps and TekVISA.
    /// Using parameters from the step, each helper will makes decisions
    /// such as send commands, or process responses from queries and
    /// do testing and generate asserts if necessary.
    /// 
    /// \ingroup grouphelperpi pisteps 
    /// 
    /// </summary>
    public class AwgTriggerGroup
    {
        public enum TriggerImpedance { Fifty, OneThousand }
        public enum TriggerMode { Asynchronous, Synchronous }
        public enum TriggerSlope { Negative, Positive }
        public enum TriggerSource { Internal, External }
        public enum TriggerWaitValue { First, Zero }
        public enum jumpOnStrobe { On, Off }
        private const string JumponstrobeOnSyntax = "1";
        private const string JumponstrobeOffSyntax = "0";

       


        #region *TRG

        public void GenerateTriggerEvent(IAWG awg)
        {
            awg.SetTriggerEvent();
        }

        #endregion

        #region TRIGger:IMMediate

        public void GenerateTriggerEvent(IAWG awg, string triggerSelection)
        {
            if (triggerSelection != "")
            {
                triggerSelection = " " + triggerSelection + "TR";
            }
            awg.ForceTriggerEvent(triggerSelection);
        }
        #endregion

        #region TRIGger:IMPedance

        public void SetTriggerImpedance(IAWG awg, string triggerSelection, TriggerImpedance setValue)
        {
            awg.SetTriggerImpedance(triggerSelection, TranslateTriggerImpedance(setValue));
        }

        public void GetTriggerImpedance(IAWG awg, string triggerSelection)
        {
            awg.GetTriggerImpedance(triggerSelection);
        }

        public void TriggerImpedanceShouldBe(IAWG awg, string triggerSelection, TriggerImpedance expectedValue)
        {

            var expectedImpedance = TranslateTriggerImpedance(expectedValue);
            switch (triggerSelection)
            {
                case "A":
                    Assert.AreEqual(expectedImpedance, awg.TriggerImpedanceA);
                    break;
                case "B":
                    Assert.AreEqual(expectedImpedance, awg.TriggerImpedanceB);
                    break;
            }
        }

        string TranslateTriggerImpedance(TriggerImpedance valueToTranslate)
        {
            return (valueToTranslate == TriggerImpedance.Fifty) ? "50" : "1000";
        }

        #endregion

        #region TRIGger:LEVel

        public void SetTriggerLevel(IAWG awg, string triggerSelection, string setValue)
        {
            awg.SetTriggerLevel(triggerSelection, setValue);
        }

        public void GetTriggerLevel(IAWG awg, string triggerSelection)
        {
            awg.GetTriggerLevel(triggerSelection);
        }

        public void TriggerLevelShouldBe(IAWG awg, string triggerSelection, string expectedValue)
        {
            switch (triggerSelection)
            {
                case "A":
                    Assert.AreEqual(Convert.ToSingle(expectedValue), Convert.ToSingle(awg.TriggerLevelA));
                    break;
                case "B":
                    Assert.AreEqual(Convert.ToSingle(expectedValue), Convert.ToSingle(awg.TriggerLevelB));
                    break;
                //No need for default, Regex of step does error checking for us
            }
        }

        #endregion

        #region TRIGger:MODE

        public void SetTriggerMode(IAWG awg, TriggerMode setValue)
        {
            awg.SetTriggerMode(TranslateTriggerMode(setValue));
        }

        public void GetTriggerMode(IAWG awg)
        {
            awg.GetTriggerMode();
        }

        public void TriggerModeShouldBe(IAWG awg, TriggerMode expectedValue)
        {
            Assert.AreEqual(TranslateTriggerMode(expectedValue), awg.TriggerMode, "The trigger mode did not match the expected value.");
        }

        string TranslateTriggerMode(TriggerMode valueToTranslate)
        {
            return (valueToTranslate == TriggerMode.Asynchronous) ? "ASYN" : "SYNC";
        }
        
        #endregion

        #region TRIGger[:SEQuence]:INTerval
        // jmanning 04/08/2014
        /// <summary>
        /// Using TRIGger:SEQuence:INTerval to set the internal trigger interval
        /// </summary>
        /// <param name="setValue">Trigger Level</param>
        public void SetTriggerInterval(IAWG awg, string setValue)
        {
            awg.SetAwgTriggerInterval(setValue);
        }

        // jmanning 04/08/2014
        /// <summary>
        /// Using TRIGger:SEQuence:INTerval? to get the internal trigger interval
        /// </summary>
        /// <returns>Internal Trigger Time Interval Value</returns>
        public void GetTriggerInterval(IAWG awg)
        {
            awg.GetAwgTriggerInterval();
        }

        public void TheInternalTriggerIntervalShouldBe(IAWG awg, string expectedValue)
        {
            Assert.AreEqual(Convert.ToSingle(expectedValue), Convert.ToSingle(awg.TriggerInterval));
        }

        #endregion TRIGger[:SEQuence]:INTerval

        #region TRIGger:SLOPe

        public void SetTriggerSlope(IAWG awg, string triggerSelection, TriggerSlope setValue)
        {
            awg.SetTriggerSlope(triggerSelection, TranslateTriggerSlope(setValue));
        }

        public void GetTriggerSlope(IAWG awg, string triggerSelection)
        {
            awg.GetTriggerSlope(triggerSelection);
        }

        public void TriggerSlopeShouldBe(IAWG awg, string triggerSelection, TriggerSlope expectedValue)
        {
            var expectedSlope = TranslateTriggerSlope(expectedValue);

            switch (triggerSelection)
            {
                case "A":
                    Assert.AreEqual(expectedSlope, awg.TriggerSlopeA);
                    break;
                case "B":
                    Assert.AreEqual(expectedSlope, awg.TriggerSlopeB);
                    break;
                //No need for default, Regex of step does error checking for us
            }
        }

        string TranslateTriggerSlope(TriggerSlope valueToTranslate)
        {
            return (valueToTranslate == TriggerSlope.Negative) ? "NEG" : "POS";
        }
        
        #endregion

        #region TRIGger:SOURce

        public void SetTriggerSource(IAWG awg, TriggerSource setValue)
        {
            awg.SetTriggerSource(TranslateTriggerSource(setValue));
        }

        public void GetTriggerSource(IAWG awg)
        {
            awg.GetTriggerSource();
        }

        public void TriggerSourceShouldBe(IAWG awg, TriggerSource expectedValue)
        {
            Assert.AreEqual(TranslateTriggerSource(expectedValue), awg.TriggerSource);
        }

        private string TranslateTriggerSource(TriggerSource valueToTranslate)
        {
            return (valueToTranslate == TriggerSource.Internal) ? "INT" : "EXT";
        }

        #endregion

        #region TRIGger:WVALue

        public void SetTriggerWValue(IAWG awg, TriggerWaitValue setValue)
        {
            awg.SetTriggerWValue(TranslateTriggerWaveValue(setValue));
        }

        public void GetTriggerWValue(IAWG awg)
        {
            awg.GetTriggerWValue();
        }

        public void TriggerWValueShouldBe(IAWG awg, TriggerWaitValue expectedValue)
        {
            Assert.AreEqual(TranslateTriggerWaveValue(expectedValue), awg.TriggerWaitForValue);
        }

        string TranslateTriggerWaveValue(TriggerWaitValue valueToTranslate)
        {
            return (valueToTranslate == TriggerWaitValue.First) ? "FIRS" : "ZERO";
        }

        #endregion

        #region AWGControl:PJUMP:SEDGE
        //Keerthi 05/28/2015
        /// <summary>
        /// Using AWGControl:PJUMP:SEDGE  sets the strobe edge to RISING/FALLING
        /// </summary>
        /// <param name="awg">specific awg</param>
        /// <param name="strobEdge">strobe edge is either RISING/FALLING</param>
        

        public void SetStrobEdge(string strobEdge, IAWG awg)
        {

            awg.SetStrobEdge(strobEdge);
        }

        #endregion AWGControl:PJUMP:SEDGE

        #region AWGControl:PJUMP:SEDGE?

        //Keerthi 05/28/2015
        /// <summary>
        /// Using AWGControl:PJUMP:SEDGE?  gets the strobe edge value is RISING/FALLING
        /// </summary>
        /// <param name="awg">specific awg</param>
        
        public void GetStrobEdge(IAWG awg)
        {

            awg.GetStrobEdge();

        }

        //Keerthi 05/28/2015
        /// <summary>
        /// compares the queried strobe edge value with the expected strobe edge value
        /// </summary>
        /// <param name="awg">specific awg</param>
        /// <param name="expectedStrobEdge">expected strobe edge </param>

        public void StrobEdgeShouldBe(string expectedStrobEdge , IAWG awg)
        {
            Assert.AreEqual(expectedStrobEdge, awg.strobEdgeQueried);

         }

        #endregion AWGControl:PJUMP:SEDGE?



        #region AWGControl:PJUMp:JSTRobe

        //Keerthi 05/28/2015
        /// <summary>
        /// AWGControl:PJUMp:JSTRobe sets the jump on strobe always as ON/OFF
        /// </summary>
        /// <param name="awg">specific awg</param>
        /// <param name="jumpOnStrobe">strobe edge is ON/OFF</param>

        public void JumpOnStrobeAlways(IAWG awg, jumpOnStrobe jumpOnStrobe)
        {
            string setValue = jumpOnStrobe == jumpOnStrobe.On ? JumponstrobeOnSyntax : JumponstrobeOffSyntax;
           
           awg.SetJumpOnStrobe(setValue);
        }

        //Keerthi 05/28/2015
        /// <summary>
        /// AWGControl:PJUMp:JSTRobe? Gets the jump on strobe always value
        /// </summary>
        /// <param name="awg">specific awg</param>

        public void GetJumpOnStrobeStatus(IAWG awg)
        {
            awg.GetJumpOnStrobeStatus();
        }

        //Keerthi 05/28/2015
        /// <summary>
        /// compares jump on strobe state against the expected state
        /// </summary>
        /// <param name="awg">specific awg</param>
        /// <param name="jumpOnStrobeState">expected jump on strobe state</param>


        public void JumpOnStrobeShouldBe(string jumpOnStrobeState, IAWG awg)
        {
            Assert.AreEqual(jumpOnStrobeState, awg.jumpOnStrobeStatusQueried);
        }



        #endregion














    }
}