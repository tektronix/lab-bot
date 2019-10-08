//==========================================================================
// ScopeMaskGroup.cs
//==========================================================================
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AwgTestFramework
{
    /// <summary>
    /// This class contains helper functions that are called from the Scope Mask PI step definitions
    /// 
    /// </summary>
    public class ScopeMaskGroup 
    {
        #region ScopeCommon
        /// <summary>
        /// Resets the mask count
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        public void RunScopeMaskCountReset(ISCOPE scope)
        {
            scope.ScopeMaskCountResetExecute();
        }
        
        /// <summary>
        /// Loads a mask file onto the scope
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="filepath">Setup filepath</param>
        public void RunScopeRecallMask(ISCOPE scope, string filepath)
        {
            scope.ScopeRecallMaskExecute(filepath);
        }

        /// <summary>
        /// Sets the specified channel to be compared against the mask 
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="channel">Which channel the mask will count</param>
        public void SetScopeChannelMaskSource(ISCOPE scope, string channel)
        {
            scope.SetScopeMaskSourceCH(channel);
        }
        #endregion ScopeCommon

        #region CSA Only
        /// <summary>
        /// Sets the mask vertices for a given mask by percentage
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="maskNumber">Desired mask number</param>
        /// <param name="maskList">List of points</param>
        public void SetCSAMaskPoint(ISCOPE scope, string maskNumber, string maskList)
        {
            scope.SetCSAMaskPoint(maskNumber, maskList);
        }
        
        /// <summary>
        /// Deletes the mask vertices for a given mask
        /// 
        /// </summary>
        /// <param name="maskNumber">Mask to delete</param>
        /// <param name="scope">the SCOPE object</param>
        public void SetCSAMaskDelete(ISCOPE scope, string maskNumber)
        {
            scope.SetCSAMaskDelete(maskNumber);
        }
        
        /// <summary>
        /// Gets the mask hit count for a specified mask
        /// 
        /// </summary>
        /// <param name="maskNumber">Desired mask</param>
        /// <param name="scope">the SCOPE object</param>
        /// <returns>Mask count</returns>
        public void GetCSAMaskHitCount(ISCOPE scope, int maskNumber)
        {
            scope.GetCSAMaskHitCount(maskNumber);
        }


        public void GetCSAAllIndividualMaskHitCount(ISCOPE scope)
        {
            for (int maskNumber = 1; maskNumber <= 8; maskNumber++)
            {
                scope.GetCSAMaskHitCount(maskNumber); //Get the values 
            }
        }
        
        public void TheCSAMasksHitCountsShouldBeWithinaPercentageOfEachOther(ISCOPE scope, string maskNum1, string maskNum2, string percent)
        {
            int firstMask = int.Parse(maskNum1); //No need to catch parse errors here, regex from step takes care of that
            int secondMask = int.Parse(maskNum2);
            string[] masksCount = scope.CSAMaskHitCount;
            string firstCount = masksCount[firstMask - 1];
            int firstMaskCount = firstCount == "" ? 0 : int.Parse(firstCount); //Prevent empty string parse errors just change to zero
            string secondCount = masksCount[secondMask - 1];
            int secondMaskCount = secondCount == "" ? 0 : int.Parse(secondCount); //Prevent empty string parse errors just change to zero
            if (firstMaskCount == 0)                //Prevent any divide by zero errors, while not strictly a assert fail offense (may not have had not enough time for sampling etc)
            {                                       //there is nothing to be done to recover within this step 
                Assert.Fail("No mask hits detected for Mask" + firstMask);
            }
            else if (secondMaskCount == 0)
            {
                Assert.Fail("No mask hits detected for Mask" + secondMask);
            }
            float difference = ((firstMaskCount) / (secondMaskCount) - 1) * 100;
            float tolerance = float.Parse(percent);
            if (difference > tolerance)
            {
                Assert.Fail("The Mask" + firstMask + " hit count and Mask" + secondMask + " hit count difference is larger than the tolerance");
            }
        }
   
        /// <summary>
        /// Gets the mask hit count for all the masks 
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        public void GetCSAMaskHitCountTotal(ISCOPE scope)
        {
            scope.GetCSAMaskHitCountTotal();
        }

        /// <summary>
        /// Verifies that the mask hit count is less than or equal to an expected value
        /// 
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="expectedValue">Value that the mask hit count should be less than or equal to</param>
        public void TheCSAMaskHitCountTotalShouldBeLessThanOrEqualTo(ISCOPE scope, string expectedValue)
        {
            string maskTotal = scope.CSAMasksTotalHitCount;
            //Both could potentially be very big values cast to longs just to be safe
            long desiredValue = expectedValue == " " ? 0 : Int64.Parse(expectedValue);
            long actualValue = maskTotal == " " ? 0 : Int64.Parse(maskTotal);
            if (!(actualValue <= desiredValue))
            {
                Assert.Fail("CSA mask count " + actualValue + " is not <= " + desiredValue);
            }
        }

        /// <summary>
        /// Turns the mask counting state on or off
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="state">Mask counting state</param>
        public void SetCSAMaskCountState(ISCOPE scope, string state)
        {
            scope.SetCSAMaskCountState(state);
        }
        #endregion CSA Only

        #region DPO Only

        /// <summary>
        /// Gets the mask hit count for all the masks 
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        public void GetDPOMaskHitCountTotal(ISCOPE scope)
        {
            scope.GetDPOMaskHitCountTotal();
        }

        /// <summary>
        /// Verifies that the Mask Hit Count is less than or equal to an expected amount
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="expectedValue">Maximum Mask Hit Count Value Expected</param>
        public void TheDPOMaskHitCountTotalShouldBeLessThanOrEqualTo(ISCOPE scope, string expectedValue)
        {
            scope.GetDPOMaskHitCountTotal();
            string maskTotal = scope.DPOMaskHitCountTotal;
            //Both could potentially be very big values cast to longs just to be safe
            long desiredValue = expectedValue == " " ? 0 : Int64.Parse(expectedValue);
            long actualValue = maskTotal == " " ? 0 : Int64.Parse(maskTotal);
            if (!(actualValue <= desiredValue))
            {
                Assert.Fail("DPO mask hit count total of " + actualValue + " is not <= " + desiredValue);
            }
        }
        
        /// <summary>
        /// Turns the mask counting state on or off
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="state">Mask counting state</param>
        public void SetDPOMaskCountState(ISCOPE scope, string state)
        {
            scope.SetDPOMaskCountState(state);
        }

        /// <summary>
        /// Used for turning on and off Masks without Deleting them
        /// Mask Counting, mask testing, and mask autoset are unavailable is the mask display is OFF
        /// Default setting is ON
        /// 
        /// </summary>
        /// <param name="displayState">ON|OFF Display State of the Mask</param>
        /// <param name="scope">the SCOPE object</param>
        public void SetDPOMaskDisplayState(ISCOPE scope, string displayState)
        {
            scope.SetDPOMaskDisplayState(displayState);
        }
        
        /// <summary>
        /// Gets the mask hit count for a specified mask segment
        /// 
        /// </summary>
        /// <param name="maskSegment">Desired mask segment</param>
        /// <param name="scope">the SCOPE object</param>
        public void GetDPOMaskSegmentHitCount(ISCOPE scope, int maskSegment)
        {
            scope.GetDPOMaskSegmentHitCount(maskSegment);
        }

        /// <summary>
        /// Deletes the existing mask and sets the selected standard mask on a DPO scope
        /// 
        /// </summary>
        /// <param name="maskStandard">Mask Standard to set</param>
        /// <param name="scope">the SCOPE object</param>
        public void SetDPOMaskStandard(ISCOPE scope, string maskStandard)
        {
            scope.SetDPOMaskStandard(maskStandard);
        }
        
        /// <summary>
        /// Gets the DPO Mask Test Status
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <returns>DPO mask test status</returns>
        public void GetDPOMaskTestStatus(ISCOPE scope)
        {
            scope.GetDPOMaskTestStatus();
        }
        
        /// <summary>
        /// Compares the DPO Mask Test Status to expected value
        /// 
        /// </summary>
        /// <param name="scope">the SCOPE object</param>
        /// <param name="expStatus">Expected Test Status Response</param>
        /// <returns>DPO mask test status</returns>
        public void DPOMaskTestStatusShouldBe(ISCOPE scope, string expStatus)
        {
            scope.GetDPOMaskTestStatus();
            string errorMessage = "Mask Test Status Returned: " + scope.DPOMaskTestStatus + " Expected: " + expStatus;
            Assert.AreEqual(expStatus, scope.DPOMaskTestStatus, errorMessage);
        }
        #endregion DPO Only
    }
}
