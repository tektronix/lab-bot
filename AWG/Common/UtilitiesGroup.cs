using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable CheckNamespace
namespace AwgTestFramework
// ReSharper restore CheckNamespace
{
    class UtilitiesGroup
    {
        public void WriteCommandToAwg(IAWG awg, string command)
        {
            awg.VisaSessionWrite(command);
        }

        public void QueryTheAwg(IAWG awg, string command)
        {
            awg.VisaSessionQuery(command);
        }
        
        public void QueryResponseShouldBe(IAWG awg, string expectedValue)
        {
            Assert.AreEqual(expectedValue, awg.ReadResponse, "Expected response " + expectedValue + " did not match actual value " + awg.ReadResponse);
        }

        public void WaitNSeconds(float seconds)
        {
            float milliseconds = seconds * 1000;
            Thread.Sleep((int)milliseconds);
        }

        /// <summary>
        /// The Gherkin language does not support dynamic ranges such as Channels.<para>
        /// Depending on the AWG it could have 1, 2 or 4 channels.  Our software</para><para>
        /// now needs to do it's own verification for correct channel count.</para>
        /// </summary>
        /// <param name="awg"></param>
        /// <param name="logicalChannel"></param>
        /// <param name="logicalMarker"></param>
        /// <param name="logicalClock"></param>
        public void VerifyChannelMarkerClockParameters(IAWG awg, string logicalChannel, string logicalMarker = null,
                                                       string logicalClock = null)
        {
            if (awg.ModelNumber.StartsWith("7"))
            { 
                if (logicalChannel != null)
                {
                    int logCh = Convert.ToInt32(logicalChannel);
                    string errorString = "Channel " + logicalChannel + " doesn't exist for " + awg.FamilyType;
                    if (awg.FamilyType.EndsWith("1"))
                    {
                        if (logCh != 1)
                        {
                            Assert.Fail(errorString);
                        }
                    }
                    else
                    {
                        if ((logCh < 1) || (logCh > 2))
                        {
                            Assert.Fail(errorString);
                        }
                    }
                }

                if (logicalMarker != null)
                {
                    int logMk = Convert.ToInt32(logicalMarker);
                    string errorString = "Marker " + logicalMarker + " doesn't exist for " + awg.FamilyType;
                    if ((logMk < 1) || (logMk > 2))
                    {
                        Assert.Fail(errorString);
                    }
                }

                if (logicalClock != null)
                {
                    int logClk = Convert.ToInt32(logicalClock);
                    string errorString = "Clock " + logicalClock + " doesn't exist for " + awg.FamilyType;
                    if (logClk != 1)
                    {
                        Assert.Fail(errorString);
                    }
                }
            }
            else
            {
                if (logicalChannel != null)
                {
                    int logCh = Convert.ToInt32(logicalChannel);
                    string errorString = "Channel " + logicalChannel + " doesn't exist for " + awg.FamilyType;
                    if (awg.FamilyType.EndsWith("1"))
                    {
                        if (logCh != 1)
                        {
                            Assert.Fail(errorString);
                        }
                    }
                    else if (awg.FamilyType.EndsWith("2"))
                    {
                        if ((logCh < 1) || (logCh > 2))
                        {
                            Assert.Fail(errorString);
                        }
                    }
                    else
                    {
                        if ((logCh < 1) || (logCh > 4))
                        {
                            Assert.Fail(errorString);
                        }
                    }
                }

                if (logicalMarker != null)
                {
                    int logMk = Convert.ToInt32(logicalMarker);
                    string errorString = "Marker " + logicalMarker + " doesn't exist for " + awg.FamilyType;
                    if ((logMk < 1) || (logMk > 4))
                    {
                        Assert.Fail(errorString);
                    }
                }

                if (logicalClock != null)
                {
                    int logClk = Convert.ToInt32(logicalClock);
                    string errorString = "Clock " + logicalClock + " doesn't exist for " + awg.FamilyType;
                    if (logClk != 1)
                    {
                        Assert.Fail(errorString);
                    }
                }
                
            }
        }
    }
}
