//==========================================================================
// ScopeMeasureGroup.cs
//==========================================================================

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains helper functions that are called from the Scope Measurement PI step definitions
    /// 
    /// </summary>
    public class ScopeMeasureGroup 
    {
        readonly UTILS.Savers _savers = new UTILS.Savers();

        #region ScopeCommon
        private void SetUpMeasurements(ISCOPE scope, string measurement, string sourceChan, string measureType)
        {
            scope.SetScopeMeasureSource(measurement,sourceChan, "ON");
            scope.SetScopeMeasureType(measurement, measureType);
            scope.GetScopeOPCResponse(10000);
            Thread.Sleep(2000);
        }

        public void MeasureAmplitude(ISCOPE scope, string measurement, string source)
        {
            SetUpMeasurements(scope, measurement, source, "AMPLitude");
        }

        public void MeasureBurst(ISCOPE scope, string measurement, string source)
        {
            SetUpMeasurements(scope, measurement, source, "BURst");
        }

        public void MeasureFall(ISCOPE scope, string measurement, string source)
        {
            SetUpMeasurements(scope, measurement, source, "FALL");
        }

        public void MeasureFrequency(ISCOPE scope, string measurement, string source)
        {
            SetUpMeasurements(scope, measurement, source, "FREQuency");
        }

        public void MeasureHigh(ISCOPE scope, string measurement, string source)
        {
            SetUpMeasurements(scope, measurement, source, "HIGH");
        }

        public void MeasureHits(ISCOPE scope, string measurement, string source)
        {
            SetUpMeasurements(scope, measurement, source, "HITs");
        }

        public void MeasureLow(ISCOPE scope, string measurement, string source)
        {
            SetUpMeasurements(scope, measurement, source, "LOW");
        }

        public void MeasureMaximum(ISCOPE scope, string measurement, string source)
        {
            SetUpMeasurements(scope, measurement, source, "MAXimum");
        }

        public void MeasureMean(ISCOPE scope, string measurement, string source)
        {
            SetUpMeasurements(scope, measurement, source, "MEAN");
        }
        
        public void MeasureMedian(ISCOPE scope, string measurement, string source)
        {
            SetUpMeasurements(scope, measurement, source, "MEDian");
        }

        public void MeasureMinimum(ISCOPE scope, string measurement, string source)
        {
            SetUpMeasurements(scope, measurement, source, "MINImum");
        }

        public void MeasureNegCross(ISCOPE scope, string measurement, string source)
        {
            SetUpMeasurements(scope, measurement, source, "NCROss");
        }

        public void MeasureNegDuty(ISCOPE scope, string measurement, string source)
        {
            SetUpMeasurements(scope, measurement, source, "NDUty");
        }

        public void MeasureNegWidth(ISCOPE scope, string measurement, string source)
        {
            SetUpMeasurements(scope, measurement, source, "NWIdth");
        }

        public void MeasurePeriod(ISCOPE scope, string measurement, string source)
        {
            SetUpMeasurements(scope, measurement, source, "PERIod");
        }
        
        public void MeasurePk2Pk(ISCOPE scope, string measurement, string source)
        {
            SetUpMeasurements(scope, measurement, source, "PK2PK");
        }

        public void MeasureJitter(ISCOPE scope, string measurement, string source)
        {
            SetUpMeasurements(scope, measurement, source, "PKPKJitter");
        }

        public void MeasurePosWidth(ISCOPE scope, string measurement, string source)
        {
            SetUpMeasurements(scope, measurement, source, "PWIdth");
        }

        public void MeasureRise(ISCOPE scope, string measurement, string source)
        {
            SetUpMeasurements(scope, measurement, source, "RISE");
        }

        /// <summary>
        /// Gets the mean measurement from the Scope
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="measurement">Different numbered measurement displays</param>
        public void GetScopeMeasurementMean(ISCOPE scope, string measurement)
        {
            scope.GetScopeMeasureMean(measurement);
        }

        /// <summary>
        /// Gets the Standard Deviation measurement from the Scope
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="measurement">Different numbered measurement displays</param>
        public void GetScopeMeasurementStandardDeviation(ISCOPE scope, string measurement)
        {
            scope.GetScopeMeasureStdDev(measurement);
        }
        
        /// <summary>
        /// Sets the measurement state for the scope
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <param name="state">Measurement state</param>
        public void SetScopeMeasurementState(ISCOPE scope, string measurement, string state)
        {
            scope.SetScopeMeasureState(measurement, state);
        }
        
        /// <summary>
        /// Sets the measurement type for the Scope
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <param name="type">Measurement type</param>
        public void SetScopeMeasurementType(ISCOPE scope, string measurement, string type)
        {
            scope.SetScopeMeasureType(measurement, type);
        }

        /// <summary>
        /// Gets the measurement value from the CSA or DPO
        /// 
        /// MEASUrement:MEAS[n]:VALue?
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <returns>Measurement value</returns>
        public void  GetScopeMeasurementValue(ISCOPE scope, string measurement)
        {
            scope.GetScopeMeasureValue(measurement);
        }

        public void GetScopeMeasurementMinValue(ISCOPE scope, string measurement)
        {
            scope.GetScopeMeasureMinValue(measurement);
        }

        public void GetScopeMeasurementValueMin(ISCOPE scope, string measurement)
        {
            scope.GetScopeMeasureValue(measurement);
            scope.ScopeMeasuredMinimumVal = scope.ScopeMeasureValue;
        }
        
        public void GetScopeMeasurementMaxValue(ISCOPE scope, string measurement)
        {
            scope.GetScopeMeasureMaxValue(measurement);
        }

        public void GetScopeMeasureValueMean(ISCOPE scope, string measurement)
        {
            GetScopeMeasurementMean(scope, measurement);
            scope.ScopeMeasuredMeanVal = scope.ScopeMeasuredMeanVal;
        }

        public void GetScopeMeasureMeanValue(ISCOPE scope, string measurement)
        {
            GetScopeMeasurementValue(scope, measurement);
            scope.ScopeMeasuredMeanVal = scope.ScopeMeasureValue;
        }

        public void GetScopeMeasureMeanStdDev(ISCOPE scope, string measurement)
        {
            GetScopeMeasurementStandardDeviation(scope, measurement);
            scope.ScopeMeasuredMeanVal = scope.ScopeMeasuredStdDevVal;
        }
        
        public void GetScopeMeasureValueAmp(ISCOPE scope, string measurement)
        {
            GetScopeMeasurementValue(scope, measurement);
            scope.ScopeMeasuredAmplitudeVal = scope.ScopeMeasureValue;
        }

        public void GetScopeMeasureValueBurst(ISCOPE scope, string measurement)
        {
            GetScopeMeasurementValue(scope, measurement);
            scope.ScopeMeasuredBurstVal = scope.ScopeMeasureValue;
        }

        public void GetScopeMeasureValueFall(ISCOPE scope, string measurement)
        {
            GetScopeMeasurementValue(scope, measurement);
            scope.ScopeMeasuredFallVal = scope.ScopeMeasureValue;
        }

        public void GetScopeMeasureValueJitter(ISCOPE scope, string measurement)
        {
            GetScopeMeasurementValue(scope, measurement);
            scope.ScopeMeasuredPkPkJitterVal = scope.ScopeMeasureValue;
        }
        
        public void GetScopeMeasureValueMaximum(ISCOPE scope, string measurement)
        {
            GetScopeMeasurementValue(scope, measurement);
            scope.ScopeMeasuredMaximumVal = scope.ScopeMeasureValue;
        }

        public void GetScopeMeasureValueMinimum(ISCOPE scope, string measurement)
        {
            GetScopeMeasurementValue(scope, measurement);
            scope.ScopeMeasuredMinimumVal = scope.ScopeMeasureValue;
        }

        public void GetScopeMeasureValueNegCrossing(ISCOPE scope, string measurement)
        {
            GetScopeMeasurementValue(scope, measurement);
            scope.ScopeMeasuredNegCrossVal = scope.ScopeMeasureValue;
        }

        public void GetScopeMeasureValueNegDuty(ISCOPE scope, string measurement)
        {
            GetScopeMeasurementValue(scope, measurement);
            scope.ScopeMeasuredNegDutyPercent = scope.ScopeMeasureValue;
        }

        public void GetScopeMeasureValueNegWidth(ISCOPE scope, string measurement)
        {
            GetScopeMeasurementValue(scope, measurement);
            scope.ScopeMeasuredNegWidth = scope.ScopeMeasureValue;
        }

        public void GetScopeMeasureValuePk2Pk(ISCOPE scope, string measurement)
        {
            GetScopeMeasurementValue(scope, measurement);
            scope.ScopeMeasuredPk2PkVal = scope.ScopeMeasureValue;
        }

        public void GetScopeMeasureValueMeanRise(ISCOPE scope, string measurement)
        {
            GetScopeMeasurementMean(scope, measurement);
            scope.ScopeMeasuredRiseMeanVal = scope.ScopeMeasuredMeanVal;
        }

        public void GetScopeMeasureValueFreqMean(ISCOPE scope, string measurement)
        {
            GetScopeMeasurementMean(scope, measurement);
            scope.ScopeMeasuredFreqMeanVal = scope.ScopeMeasuredMeanVal;
        }

        public void GetScopeMeasureValuePeriodStdDev(ISCOPE scope, string measurement)
        {
            GetScopeMeasurementStandardDeviation(scope, measurement);
            scope.ScopeMeasuredPeriodStDevVal = scope.ScopeMeasuredStdDevVal;
        }

        public void GetScopeMeasureValuePeriod(ISCOPE scope, string measurement)
        {
            GetScopeMeasurementValue(scope, measurement);
            scope.ScopeMeasuredPeriodVal = scope.ScopeMeasureValue;
        }

        public void GetScopeMeasureValuePosWidth(ISCOPE scope, string measurement)
        {
            GetScopeMeasurementValue(scope, measurement);
            scope.ScopeMeasuredPosWidth = scope.ScopeMeasureValue;
        }

        public void MeasureGivenType(ISCOPE scope, string measurement, string source, string type)
        {
            SetUpMeasurements(scope, measurement, source, type);
        }

        public void TheScopeAmpMeasurementShouldBe(ISCOPE scope, double min, double max)
        {
            float actualValue = scope.ScopeMeasuredAmplitudeVal == "" ? 0 : float.Parse(scope.ScopeMeasuredAmplitudeVal);
                //Check for an empty string. Hardcode as 0, otherwise parse it

            // If the measured value falls below the minimum, then fail the test
            if (!(actualValue >= min))
            {
                Assert.Fail("The measured amplitude was less than the minimum tolerance of " +
                            string.Format("{0:0.##}", min) + " volts");
            }

            // If the measured value falls above the maximum, then fail the test
            if (!(actualValue <= max))
            {
                Assert.Fail("The measured amplitude was greater than the maximum tolerance of " +
                            string.Format("{0:0.##}", max) + " volts");
            }
        }

        public void TheScopeMinMeasurementShouldBe(ISCOPE scope, double min, double max)
        {
            float actualValue = scope.ScopeMeasuredMinimumVal == "" ? 0 : float.Parse(scope.ScopeMeasuredMinimumVal);
            //Check for an empty string. Hardcode as 0, otherwise parse it

            // If the measured value falls below the minimum, then fail the test
            if (!(actualValue >= min))
            {
                Assert.Fail("The measured minimum was less than the minimum tolerance of " +
                            string.Format("{0:0.##}", min) + " volts");
            }

            // If the measured value falls above the maximum, then fail the test
            if (!(actualValue <= max))
            {
                Assert.Fail("The measured minimum was greater than the maximum tolerance of " +
                            string.Format("{0:0.##}", max) + " volts");
            }
        }

        public void TheScopeMaxMeasurementShouldBe(ISCOPE scope, double min, double max)
        {
            float actualValue = scope.ScopeMeasuredMaximumVal == "" ? 0 : float.Parse(scope.ScopeMeasuredMaximumVal);
            //Check for an empty string. Hardcode as 0, otherwise parse it

            // If the measured value falls below the minimum, then fail the test
            if (!(actualValue >= min))
            {
                Assert.Fail("The measured maximum was less than the minimum tolerance of " +
                            string.Format("{0:0.##}", min) + " volts");
            }

            // If the measured value falls above the maximum, then fail the test
            if (!(actualValue <= max))
            {
                Assert.Fail("The measured maximum was greater than the maximum tolerance of " +
                            string.Format("{0:0.##}", max) + " volts");
            }
        }

        public void TheScopeMeanMeasurementValueShouldBe(ISCOPE scope, double min, double max)
        {
            float actualValue = scope.ScopeMeasuredMeanVal == "" ? 0 : float.Parse(scope.ScopeMeasuredMeanVal);
            //Check for an empty string. Hardcode as 0, otherwise parse it

            // If the measured value falls below the minimum, then fail the test
            if (!(actualValue >= min))
            {
                Assert.Fail("The measured mean value, " + actualValue + "V, was less than the minimum tolerance of " +
                            string.Format("{0:0.##}", min) + " volts");
            }

            // If the measured value falls above the maximum, then fail the test
            if (!(actualValue <= max))
            {
                Assert.Fail("The measured mean value, " + actualValue + "V, was greater than the maximum tolerance of " +
                            string.Format("{0:0.##}", max) + " volts");
            }
        }

        public void TheScopePK2PKMeasurementShouldBe(ISCOPE scope, double min, double max)
        {
            double pk2PkValue = scope.ScopeMeasuredPk2PkVal == "" ? 0.0 : float.Parse(scope.ScopeMeasuredPk2PkVal); //Check for an empty string, hardcode as 0 otherwise parse it
            // If the measured value falls below the minimum, then fail the test
            if (pk2PkValue <= min)
            {
                Assert.Fail("The measured pk2pk amplitude of " + scope.ScopeMeasuredPk2PkVal+ "V was less than the minimum tolerance of " + string.Format("{0:0.##}", min) + " volts");
            }

            // If the measured value falls above the maximum, then fail the test
            if (pk2PkValue >= max)
            {
                Assert.Fail("The measured pk2pk amplitude of " + scope.ScopeMeasuredPk2PkVal + "V was greater than the maximum tolerance of " + string.Format("{0:0.##}", max) + " volts");
            }
        }

        public void TheScopeMeanRiseTimeMeasurementShouldBe(ISCOPE scope, double min, double max)
        {
            double meanRiseValue = scope.ScopeMeasuredRiseMeanVal == "" ? 0 : float.Parse(scope.ScopeMeasuredRiseMeanVal) * 1E+09; //Check for an empty string

            // If the measured value falls below the minimum, then fail the test
            if (!(meanRiseValue >= min))
            {
                Assert.Fail("The measured rise time was less than the minimum tolerance of " + string.Format("{0:0.##}", min) + " ns");
            }

            // If the measured value falls above the maximum, then fail the test
            if (!(meanRiseValue <= max))
            {
                Assert.Fail("The measured rise time was greater than the maximum tolerance of " + string.Format("{0:0.##}", max) + " ns");
            }
        }

        public void TheScopeFallTimeMeasurementShouldBe(ISCOPE scope, double min, double max)
        {
            double fallTime = scope.ScopeMeasuredFallVal == "" ? 0 : float.Parse(scope.ScopeMeasuredFallVal) * 1E+09; //Check for an empty string convert to ns

            // If the measured value falls below the minimum, then fail the test
            if (!(fallTime >= min))
            {
                Assert.Fail("The measured fall time was less than the minimum tolerance of " + string.Format("{0:0.##}", min) + " ns");
            }

            // If the measured value falls above the maximum, then fail the test
            if (!(fallTime <= max))
            {
                Assert.Fail("The measured fall time was greater than the maximum tolerance of " + string.Format("{0:0.##}", max) + " ns");
            }
        }


        public void TheScopeNegWidthTimeMeasurementShouldBe(ISCOPE scope, double min, double max)
        {
            double negWidthTime = scope.ScopeMeasuredNegWidth == "" ? 0 : float.Parse(scope.ScopeMeasuredNegWidth) * 1E+09; //Check for an empty string convert to ns

            // If the measured value falls below the minimum, then fail the test
            if (!(negWidthTime >= min))
            {
                Assert.Fail("The measured negative width pulse time of " + string.Format("{0:0.##}", negWidthTime) + " was less than the minimum tolerance of " + string.Format("{0:0.##}", min) + " ns");
            }

            // If the measured value falls above the maximum, then fail the test
            if (!(negWidthTime <= max))
            {
                Assert.Fail("The measured negatice width pulse time " + string.Format("{0:0.##}", negWidthTime) + " was greater than the maximum tolerance of " + string.Format("{0:0.##}", max) + " ns");
            }
        }

        public void TheScopePosWidthTimeMeasurementShouldBe(ISCOPE scope, double min, double max)
        {
            double posWidthTime = scope.ScopeMeasuredNegWidth == "" ? 0 : float.Parse(scope.ScopeMeasuredPosWidth) * 1E+09; //Check for an empty string convert to ns

            // If the measured value falls below the minimum, then fail the test
            if (!(posWidthTime >= min))
            {
                Assert.Fail("The measured negative width pulse time of " + string.Format("{0:0.##}", posWidthTime) + " was less than the minimum tolerance of " + string.Format("{0:0.##}", min) + " ns");
            }

            // If the measured value falls above the maximum, then fail the test
            if (!(posWidthTime <= max))
            {
                Assert.Fail("The measured negatice width pulse time " + string.Format("{0:0.##}", posWidthTime) + " was greater than the maximum tolerance of " + string.Format("{0:0.##}", max) + " ns");
            }
        }
        
        public void TheScopeMeanFrequencyMeasurementShouldBe(ISCOPE scope, double min, double max)
        {
            double meanFreqValue = scope.ScopeMeasuredFreqMeanVal == "" ? 0.0 : float.Parse(scope.ScopeMeasuredFreqMeanVal) * 1E-06;

            // If the measured value falls below the minimum, then fail the test
            if (!(meanFreqValue >= min))
            {
                Assert.Fail("The measured frequency of " + string.Format("{0:0.##}", meanFreqValue) + " was less than the minimum tolerance of " + string.Format("{0:0.##}", min) + "");
            }

            // If the measured value falls above the maximum, then fail the test
            if (!(meanFreqValue <= max))
            {
                Assert.Fail("The measured frequency of " + string.Format("{0:0.##}", meanFreqValue) + " was greater than the maximum tolerance of " + string.Format("{0:0.##}", max) + "");
            }
        }

        public void TheScopeNegDutyCycleMeasurementShouldBe(ISCOPE scope, double min, double max)
        {
            double dutyCyclePercent = scope.ScopeMeasuredNegDutyPercent == "" ? 0.0 : float.Parse(scope.ScopeMeasuredNegDutyPercent);

            // If the measured value falls below the minimum, then fail the test
            if (!(dutyCyclePercent >= min))
            {
                Assert.Fail("The measured duty cycle of " + dutyCyclePercent + "%  was less than the minimum tolerance of " + string.Format("{0:0.##}", min) + "%");
            }

            // If the measured value falls above the maximum, then fail the test
            if (!(dutyCyclePercent <= max))
            {
                Assert.Fail("The measured duty cycle of " + dutyCyclePercent + "%  was greater than the maximum tolerance of " + string.Format("{0:0.##}", max) + "%");
            }
        }
        #endregion ScopeCommon

        #region CSA Only
        /// <summary>
        /// Resets the CSA measurement statistics
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        public void ResetCSAMeasurement(ISCOPE scope)
        {
            scope.CSAMeasurementResetExecute();
        }
        
        /// <summary>
        /// Sets the CSA measurement source to a given channel
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <param name="source">Which channel to be used as a source for the measurement</param>
        public void SetCSAMeasurementSource(ISCOPE scope, string measurement, string source)
        {
            scope.SetCSAMeasureSource(measurement, source);
        }
        #endregion CSA Only

        #region DPO Only
        private void SetUpImmedMeasurements(ISCOPE scope, string source, string measureType)
        {
            scope.SetDPOImmedMeasureSource(source);
            scope.SetDPOImmedMeasureType(measureType);
            scope.GetScopeOPCResponse(15000);
            Thread.Sleep(2000);
        }

        public void ImmedMeasureAmplPk2Pk(ISCOPE scope, string source)
        {
            SetUpImmedMeasurements(scope, source, "PK2Pk");
        }

        public void ImmedMeasureRise(ISCOPE scope, string source)
        {
            SetUpImmedMeasurements(scope, source, "RISe");
        }

        public void ImmedMeasureAmpl(ISCOPE scope, string source)
        {
            SetUpImmedMeasurements(scope, source, "AMPlitude");
        }

        public void GetDPOImmedMeasureValuePk2Pk(ISCOPE scope)
        {
            scope.GetDPOImmedMeasureValue();
            scope.DPOImmedMeasurePk2PkValue = scope.DPOImmedMeasureValue;
        }

        public void GetDPOImmedMeasureValueRise(ISCOPE scope)
        {
            scope.GetDPOImmedMeasureValue();
            scope.DPOImmedMeasureRiseValue = scope.DPOImmedMeasureValue; 
        }

        public void GetDPOImmedMeasureValueAmp(ISCOPE scope)
        {
            scope.GetDPOImmedMeasureValue();
            scope.DPOImmedMeasureAmpValue = scope.DPOImmedMeasureValue; 
        }

        /// <summary>
        /// Gets the DPO immediate value
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        public void GetDPOImmediateMeasurementValue(ISCOPE scope)
        {
            scope.GetDPOImmedMeasureValue();
        }
        
        /// <summary>
        /// Sets the DPO immediate source to a given channel
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="source">Which channel to be used as a source for the measurement </param>
        public void SetDPOImmediateMeasurementSource(ISCOPE scope, string source)
        {
            scope.SetDPOImmedMeasureSource(source);
        }

        /// <summary>
        /// Sets the DPO immediate measurement type
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="type">Measurement type</param>
        public void SetDPOImmediateMeasurementType(ISCOPE scope, string type)
        {
            scope.SetDPOImmedMeasureType(type);
        }

        /// <summary>
        /// Resets/Clears the DPO measurement statistics
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        public void ResetDPOMeasurement(ISCOPE scope)
        {
            scope.DPOMeasurementResetExecute();
        }
        
        /// <summary>
        /// Sets the DPO measurement source to a given channel
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <param name="source">Which channel to be used as a source for the measurement</param>
        public void SetDPOMeasurementSource(ISCOPE scope, string measurement, string source)
        {
            scope.SetDPOMeasureSource(measurement, source);
        }

        public void GetFourDPOMeasurementsandStore(ISCOPE scope, string type1, string type2, string type3, string type4, string source, string filename)
        {
            string title = "DPO Waveform Measurement Results: " + UTILS.NiceDate + "\n\n" + type1 + "," +
                type2 + "," + type3 + "," + type4;

            #region Meas1Slot
            if (type1 == "JITTER")
                type1 = "PKPKJitter";
            MeasureGivenType(scope, "1", source, type1);
            if (type1 == "PERIOD")
            {
                //Period uses the Standard Deviation Response
                GetScopeMeasurementStandardDeviation(scope, "1");
                scope.ScopeMeas1Value = scope.ScopeMeasuredStdDevVal;
            }
            else
            {
                //All others use the Measured Value Response
                GetScopeMeasurementValue(scope, "1");
                scope.ScopeMeas1Value = scope.ScopeMeasureValue;
            }
            #endregion Meas1Slot   
            #region Meas2Slot
            if (type2 == "JITTER")
                type2 = "PKPKJitter";
            MeasureGivenType(scope, "2", source, type2);
            if (type2 == "PERIOD")
            {
                //Period uses the Standard Deviation Response
                GetScopeMeasurementStandardDeviation(scope, "2");
                scope.ScopeMeas2Value = scope.ScopeMeasuredStdDevVal;
            }
            else
            {
                //All others use the Measured Value Response
                GetScopeMeasurementValue(scope, "2");
                scope.ScopeMeas2Value = scope.ScopeMeasureValue;
            }
            #endregion Meas2Slot
            #region Meas3Slot
            if (type3 == "JITTER")
                type3 = "PKPKJitter";
            MeasureGivenType(scope, "3", source, type3); 
            if (type3 == "PERIOD")
            {
                //Period uses the Standard Deviation Response
                GetScopeMeasurementStandardDeviation(scope, "3");
                scope.ScopeMeas3Value = scope.ScopeMeasuredStdDevVal;
            }
            else
            {
                //All others use the Measured Value Response
                GetScopeMeasurementValue(scope, "3");
                scope.ScopeMeas3Value = scope.ScopeMeasureValue;
            }
            #endregion Meas3Slot
            #region Meas4Slot
            if (type4 == "JITTER")
                type4 = "PKPKJitter";
            MeasureGivenType(scope, "4", source, type4);
            if (type4 == "PERIOD")
            {
                //Period uses the Standard Deviation Response
                GetScopeMeasurementStandardDeviation(scope, "4");
                scope.ScopeMeas4Value = scope.ScopeMeasuredStdDevVal;
            }
            else
            {
                //All others use the Measured Value Response
                GetScopeMeasurementValue(scope, "4");
                scope.ScopeMeas4Value = scope.ScopeMeasureValue;
            }
            #endregion Meas4Slot
            string log = scope.ScopeMeas1Value + "," + scope.ScopeMeas2Value + "," + scope.ScopeMeas3Value + "," + scope.ScopeMeas4Value;
            _savers.AddToLog(log, filename, title);
        }
        #endregion DPO Only
    }
}
