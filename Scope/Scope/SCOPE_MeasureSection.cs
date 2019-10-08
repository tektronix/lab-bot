//==========================================================================
// SCOPE_MeasureSection.cs
//==========================================================================
namespace AwgTestFramework
{
    public partial class SCOPE
    {
        /// <summary>
        /// Property to store Amplitude Measurement Value
        /// </summary>
        public string ScopeMeasuredAmplitudeVal { get; set; }

        /// <summary>
        /// Property to store Burst Measurement Value
        /// </summary>
        public string ScopeMeasuredBurstVal { get; set; }
        
        /// <summary>
        /// Property to store Fall Measurement Value
        /// </summary>
        public string ScopeMeasuredFallVal { get; set; }
        
        /// <summary>
        /// Property to store Frequency Measurement Value
        /// </summary>
        public string ScopeMeasuredFrequencyVal { get; set; }

        /// <summary>
        /// Property to store Mean Frequency Measurement Value
        /// </summary>
        public string ScopeMeasuredFreqMeanVal { get; set; }

        /// <summary>
        /// Property to store High Measurement Value 
        /// </summary>
        public string ScopeMeasuredHighVal { get; set; }

        /// <summary>
        /// Property to store Hits Measurement Value
        /// </summary>
        public string ScopeMeasuredHitsVal { get; set; }

        /// <summary>
        /// Property to store Low Measurement Value 
        /// </summary>
        public string ScopeMeasuredLowVal { get; set; }

        /// <summary>
        /// Property to store Maximum Measurement Value
        /// </summary>
        public string ScopeMeasuredMaximumVal { get; set; }

        /// <summary>
        /// Property to store Mean Measurement response from MEASUrement:MEAS[n]:MEAN?
        /// </summary>
        public string ScopeMeasuredMeanVal { get; set; }

        /// <summary>
        /// Property to store Median Measurement Value
        /// </summary>
        public string ScopeMeasuredMedianVal { get; set; }

        /// <summary>
        /// Property to store Minimum Measurement Value
        /// </summary>
        public string ScopeMeasuredMinimumVal { get; set; }

        /// <summary>
        /// Property to store Negative Crossing Period
        /// </summary>
        public string ScopeMeasuredNegCrossVal { get; set; }

        /// <summary>
        /// Property to store Negative Duty Cycle Percentage
        /// </summary>
        public string ScopeMeasuredNegDutyPercent { get; set; }

        /// <summary>
        /// Property to store negative width of the first negative pulse in time Measurement Value
        /// </summary>
        public string ScopeMeasuredNegWidth { get; set; }
        
        /// <summary>
        /// Property to store Period Measurement Value
        /// </summary>
        public string ScopeMeasuredPeriodVal { get; set; }

        /// <summary>
        /// Property to store Period Standard Deviation Measurement Value
        /// </summary>
        public string ScopeMeasuredPeriodStDevVal { get; set; }
        
        /// <summary>
        /// Property to store Phase Measurement Value
        /// </summary>
        public string ScopeMeasuredPhaseVal { get; set; }

        /// <summary>
        /// Property to store Peak to Peak Measurement Value
        /// </summary>
        public string ScopeMeasuredPk2PkVal { get; set; }

        /// <summary>
        /// Property to store Peak to Peak Jitter Measurement Value
        /// </summary>
        public string ScopeMeasuredPkPkJitterVal { get; set; }

        /// <summary>
        /// Property to store positive width of the first positive pulse in time Measurement Value
        /// </summary>
        public string ScopeMeasuredPosWidth { get; set; }

        /// <summary>
        /// Property to store Rise Measurement Value
        /// </summary>
        public string ScopeMeasuredRiseVal { get; set; }

        /// <summary>
        /// Property to stope Rise Mean Measurement Value
        /// </summary>
        public string ScopeMeasuredRiseMeanVal { get; set; }

        /// <summary>
        /// Property to store Standard Deviation Measurement response from MEASUrement:MEAS[n]:STDdev?
        /// </summary>
        public string ScopeMeasuredStdDevVal { get; set; }

        /// <summary>
        /// Property to store Measurement Value response from MEASUrement:MEAS[n]:VALue?
        /// </summary>
        public string ScopeMeasureValue { get; set; }

        /// <summary>
        /// Property to store Measurement Slot #1 Value
        /// </summary>
        public string ScopeMeas1Value { get; set; }

        /// <summary>
        /// Property to store Measurement Slot #2 Value
        /// </summary>
        public string ScopeMeas2Value { get; set; }

        /// <summary>
        /// Property to store Measurement Slot #3 Value
        /// </summary>
        public string ScopeMeas3Value { get; set; }

        /// <summary>
        /// Property to store Measurement Slot #4 Value
        /// </summary>
        public string ScopeMeas4Value { get; set; }
        
        /// <summary>
        /// Property to store DPO Immediate Value response from MEASUrement:IMMed:VALue?
        /// </summary>
        public string DPOImmedMeasureValue { get; set; }

        /// <summary>
        /// Property to store DPO Immediate Peak to Peak Value
        /// </summary>
        public string DPOImmedMeasurePk2PkValue { get; set; }

        /// <summary>
        /// Property to store DPO Immediate Amplitude Value
        /// </summary>
        public string DPOImmedMeasureAmpValue { get; set; }

        /// <summary>
        /// Property to store DPO Immediate Rise Value
        /// </summary>
        public string DPOImmedMeasureRiseValue { get; set; }
        
        /// <summary>
        /// Gets the mean measurement from Scope
        /// 
        /// uses MEASUrement:MEAS[n]:MEAN?
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <returns>Mean measurement</returns>
        public void GetScopeMeasureMean(string measurement)
        {
            ScopeMeasuredMeanVal = _pis.ScopeMeasureMeanQuery(measurement);
        }

        public void MeasureAmplitude(ISCOPE scope, string measurement, string source)
        {
            ScopeMeasuredAmplitudeVal = _pis.ScopeMeasureValueQuery(measurement);
        }

        public void MeasureBurst(ISCOPE scope, string measurement, string source)
        {
            ScopeMeasuredBurstVal = _pis.ScopeMeasureValueQuery(measurement);
        }
        
        
        public void MeasureFall(ISCOPE scope, string measurement, string source)
        {
            ScopeMeasuredFallVal = _pis.ScopeMeasureValueQuery(measurement);
        }
        
        
        public void MeasureFrequency(ISCOPE scope, string measurement, string source)
        {
           ScopeMeasuredFrequencyVal = _pis.ScopeMeasureValueQuery(measurement);
        }

        public void MeasureHigh(ISCOPE scope, string measurement, string source)
        {
           ScopeMeasuredHighVal = _pis.ScopeMeasureValueQuery(measurement);
        }


        public void MeasureHits(ISCOPE scope, string measurement, string source)
        {
            ScopeMeasuredHitsVal = _pis.ScopeMeasureValueQuery(measurement);
        }


        public void MeasureLow(ISCOPE scope, string measurement, string source)
        {
            ScopeMeasuredLowVal = _pis.ScopeMeasureValueQuery(measurement);
        }


        public void MeasureMaximum(ISCOPE scope, string measurement, string source)
        {
            ScopeMeasuredMaximumVal = _pis.ScopeMeasureMaxQuery(measurement);
        }


        public void MeasureMedian(ISCOPE scope, string measurement, string source)
        {
            ScopeMeasuredMedianVal = _pis.ScopeMeasureValueQuery(measurement);
        }


        public void MeasureMinimum(ISCOPE scope, string measurement, string source)
        {
            ScopeMeasuredMinimumVal = _pis.ScopeMeasureMinQuery(measurement);
        }

        public void MeasureNegCross(ISCOPE scope, string measurement, string source)
        {
            ScopeMeasuredNegCrossVal = _pis.ScopeMeasureValueQuery(measurement);
        }

        public void MeasureNegDuty(ISCOPE scope, string measurement, string source)
        {
            ScopeMeasuredNegDutyPercent = _pis.ScopeMeasureValueQuery(measurement);
        }

        public void MeasureNegWidth(ISCOPE scope, string measurement, string source)
        {
            ScopeMeasuredNegWidth = _pis.ScopeMeasureValueQuery(measurement);
        }

        public void MeasurePeriod(ISCOPE scope, string measurement, string source)
        {
            ScopeMeasuredPeriodVal = _pis.ScopeMeasureValueQuery(measurement);
        }

        public void MeasurePk2Pk(ISCOPE scope, string measurement, string source)
        {
            ScopeMeasuredPk2PkVal = _pis.ScopeMeasureValueQuery(measurement);
        }

        public void MeasureJitter(ISCOPE scope, string measurement, string source)
        {
            ScopeMeasuredPkPkJitterVal = _pis.ScopeMeasureValueQuery(measurement);
        }

        public void MeasurePosWidth(ISCOPE scope, string measurement, string source)
        {
            ScopeMeasuredPosWidth = _pis.ScopeMeasureValueQuery(measurement);
        }

        public void MeasureRise(ISCOPE scope, string measurement, string source)
        {
            ScopeMeasuredRiseVal = _pis.ScopeMeasureValueQuery(measurement);
        }


        /// <summary>
        /// Sets the measurement source for the CSA and the DPO
        /// 
        /// MEASUrement:MEAS[n]:SOURCE1 CH[n]
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <param name="sourceChan">Channel to use as Measurement Source</param>
        /// <param name="state">Measurement state</param>
        public void SetScopeMeasureSource(string measurement, string sourceChan, string state)
        {
            _pis.ScopeMeasureSource(measurement, sourceChan, state);
        }
            
        /// <summary>
        /// Sets the measurement state of the scope
        /// 
        /// uses MEASUrement:MEAS[n]:STATE
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <param name="state">Measurement state</param>
        public void SetScopeMeasureState(string measurement, string state)
        {
            _pis.ScopeMeasureState(measurement, state);
        }

        /// <summary>
        /// Gets the standard deviation measurement from the scope
        /// 
        /// uses MEASUrement:MEAS[n]:STDdev?
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <returns>Standard Deviation measurement</returns>
        public void GetScopeMeasureStdDev(string measurement)
        {
            ScopeMeasuredStdDevVal = _pis.ScopeMeasureStdDevQuery(measurement);
        }

        /// <summary>
        /// Sets the measurement type for the Scope
        /// 
        /// NOTE: The string values for type differs between CSA and DPO along with types available on the DPO that are not on the CSA@n
        /// uses MEASUrement:MEAS[n]:TYPe
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <param name="type">Measurement type</param>
        public void SetScopeMeasureType(string measurement, string type)
        {
            _pis.ScopeMeasureType(measurement, type);
        }

        /// <summary>
        /// Gets the measurement value from the Scope
        /// 
        /// uses MEASUrement:MEAS[n]:VALue?
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <returns>Measurement value</returns>
        public void GetScopeMeasureValue(string measurement)
        {
            ScopeMeasureValue = _pis.ScopeMeasureValueQuery(measurement);
        }

        /// <summary>
        /// Gets the measurement value from the Scope
        /// 
        /// uses MEASUrement:MEAS[n]:MAXimum?
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <returns>Measurement value</returns>
        public void GetScopeMeasureMaxValue(string measurement)
        {
            ScopeMeasuredMaximumVal = _pis.ScopeMeasureMaxQuery(measurement);
        }

        /// <summary>
        /// Gets the measurement value from the Scope
        /// 
        /// uses MEASUrement:MEAS[n]:MINImum?
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <returns>Measurement value</returns>
        public void GetScopeMeasureMinValue(string measurement)
        {
            ScopeMeasuredMinimumVal = _pis.ScopeMeasureMinQuery(measurement);
        }

        /// <summary>
        /// Sets the CSA measurement source to a given channel
        /// 
        /// uses MEASUrement:MEAS[n]:SOUrce[channel]:WFM
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <param name="source">Scope visa session and a collection of state variables</param>
        public void SetCSAMeasureSource(string measurement, string source)
        {
            _pis.CSAMeasureSource(measurement, source);
        }

        /// <summary>
        /// Resets the CSA measurement statistics
        /// 
        /// uses MEASUrement:MEAS1:STATistics:CLEAR
        /// </summary>
        public void CSAMeasurementResetExecute()
        {
            _pis.CSAMeasurementReset();
        }
        
        /// <summary>
        /// Sets the DPO immediate source to a given channel
        /// 
        /// uses MEASUrement:IMMed:SOUrce1 CH[n]
        /// </summary>
        /// <param name="source">Which channel to be used as a source for the measurement </param>
        public void SetDPOImmedMeasureSource(string source)
        {
            _pis.DPOImmedMeasureSource(source);
        }

        /// <summary>
        /// Sets the DPO immediate measurement type
        /// 
        /// uses MEASUrement:IMMed:TYPe
        /// </summary>
        /// <param name="type">Measurement type</param>
        public void SetDPOImmedMeasureType(string type)
        {
            _pis.DPOImmedMeasureType(type);
        }

        /// <summary>
        /// Gets the DPO immediate value
        /// 
        /// uses MEASUrement:IMMed:VALue
        /// </summary>
        /// <returns>Immediate value</returns>
        public void GetDPOImmedMeasureValue()
        {
            DPOImmedMeasureValue = _pis.DPOImmedMeasureValueQuery();
        }

        /// <summary>
        /// Sets the DPO measurement source to a given channel
        /// 
        /// uses MEASUrement:MEAS[n]:SOUrce CH[n]
        /// </summary>
        /// <param name="measurement">Different numbered measurement displays</param>
        /// <param name="source">Which Channel will be used</param>
        public void SetDPOMeasureSource(string measurement, string source)
        {
            _pis.DPOMeasureSource(measurement, source);
        }

        /// <summary>
        /// Resets the DPO measurement statistics
        /// 
        /// uses MEASUrement:STATistics:COUNt RESET
        /// </summary>
        public void DPOMeasurementResetExecute()
        {
            _pis.DPOMeasurementReset();
        }
    }
}
