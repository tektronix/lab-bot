//==========================================================================
// ScopeSystem__steps.cs
// This file contains the low-order PI step definitions for the Scope PI System Group commands. 
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
    /// This class contains the low-order PI step definitions for the Scope PI System Group commands.

    /// Low-level steps set and get the values for commands, and test the raw values as returned from the 
    /// instrument. They DO NOT interpret values in any way! Interpretation, normalization, etc. need to 
    /// occur in the High-level step definitions. Notice the use of the word "value" in the steps - this 
    /// usually implies that the query returns a 0 or 1 or abbreviated text value (like SOFT) that should 
    /// be interpreted as ON or OFF or SOFTWARE to make the step more user-friendly. We do that in the 
    /// High-order step definitions.
    /// 
    /// </summary> 
    [Binding] //Very important! This entry needs to be made in each step definition file.
    public class ScopeSystemSteps
    {
        private readonly ScopeSystemGroup _scopeSystemGroup = new ScopeSystemGroup();

        #region *CLS
        /// <summary>
        /// Clears the error queue on the Scope
        /// 
        /// Clears the following:@n
        /// + Event Queue@n
        /// + Standard Event Status Register (SESR)@n
        /// + Status Byte Register (except the MAV bit)@n
        /// (DPO|CSA)
        /// *CLS
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"I clear the error queue on the Scope")]
            \endverbatim 
        */
        [When(@"I clear the error queue on the Scope")]
        public void ClearTheErrorQueueOnTheScope()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeSystemGroup.RunScopeCLS(scope);
            _scopeSystemGroup.WaitForScopeToCompleteBeforeTimeout(scope, 10000); //Does need to have some time to stay in sync
            //These are not needed because according to the CSA and DPO PI manuals these individual parts are cleared
            //by the CLS PI command
            // _scopeSystemGroup.GetScopeESRResponse(scope);
            // _scopeSystemGroup.GetScopeALLEvResponse(scope);
            // _scopeSystemGroup.GetScopeEventResponse(scope);
        }
        #endregion *CLS

        #region *ESR?
        /// <summary>
        /// Gets Standard Event Status Register
        /// basically means clearing it
        /// 
        /// (DPO|CSA)
        /// *ESR?
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"I get the standard event status register data from the Scope")]
            \endverbatim 
        */
        [When(@"I get the standard event status register data from the Scope")]
        public void GetStandardEventStatusRegisterDataFromTheScope()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeSystemGroup.GetScopeESRResponse(scope);
        }
        #endregion *ESR?
        
        #region *IDN?
        /// <summary>
        /// Prepares a new Visa session for a CSA Scope
        /// 
        /// (DPO|CSA)
        /// *IDN?
        /// </summary>
        /*!
            \scope\verbatim
        [Given(@"a CSA Scope")]
            \endverbatim 
        */
        [Given(@"a CSA Scope")]
        public void GivenACSAScope()
        {
            //Open a new VISA session to the scope
            ISCOPE scope = SCOPE.GetScope(true);
            _scopeSystemGroup.GetScopeIDNResponse(scope);
            _scopeSystemGroup.CheckScopeFamilyType(scope, "CSA");
        }

        /// <summary>
        /// Prepares a new Visa session for a DPO Scope
        /// 
        /// *IDN?
        /// </summary>
        /*!
            \scope\verbatim
        [Given(@"a DPO Scope")]
            \endverbatim 
        */
        [Given(@"a DPO Scope")]
        public void GivenADPOScope()
        {
            //Open a new VISA session to the scope
            ISCOPE scope = SCOPE.GetScope(true);
            _scopeSystemGroup.GetScopeIDNResponse(scope);
            _scopeSystemGroup.CheckScopeFamilyType(scope, "DPO");
        }


        /// <summary>
        /// Gets the ID Information from the Scope
        /// 
        /// *IDN?
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"I get the ID Information from the Scope")]
            \endverbatim 
        */
        [When(@"I get the ID Information from the Scope")]
        public void GetTheScopeID()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeSystemGroup.GetScopeIDNResponse(scope);
        }
        #endregion *IDN?

        #region *OPC?
        /// <summary>
        /// Waits for the Scope to complete
        /// 
        /// (DPO|CSA)
        /// *OPC?
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"I wait for the Scope to complete")]
            \endverbatim 
        */
        [When(@"I wait for the Scope to complete")]
        public void WaitForTheScopeToComplete()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            uint timeout = 15000;
            _scopeSystemGroup.GetScopeOPCResponse(scope, timeout);
        }

        /// <summary>
        /// Waits for the Scope to complete within a certain amount of seconds
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"I wait for up to (/d+) seconds for the Scope to complete")
            \endverbatim 
        */
        [When(@"I wait for up to (/d+) seconds for the Scope to complete")]
        public void WaitForTheScopeToCompletewTimeout(string time)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            uint timeout = uint.Parse(time);
            timeout = timeout * 1000; //Convert to milliseconds
            _scopeSystemGroup.GetScopeOPCResponse(scope, timeout);
        }
        #endregion *OPC?

        #region *RST
        /// <summary>
        /// Resets the scope
        /// 
        /// (DPO|CSA)
        /// *RST
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"I perform a reset on the Scope")]
            \endverbatim 
        */
        [When(@"I perform a reset on the Scope")]
        public void ResetTheScope()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeSystemGroup.RunScopeReset(scope);
        }
        #endregion *RST

        #region ALLEv?
        /// <summary>
        /// Gets all the events on the scope
        /// 
        /// (DPO|CSA)
        /// ALLEv?
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"I get all event data from the Scope")]
            \endverbatim 
        */
        [When(@"I get all event data from the Scope")]
        public void GetAllEventDataFromTheScope()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeSystemGroup.GetScopeALLEvResponse(scope);
        }
        #endregion ALLEv?

        #region EVENT?
        /// <summary>
        /// Gets the current event code the queue
        /// 
        /// (DPO|CSA)
        /// EVENT?
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"I get the current event code from the Scope")]
            \endverbatim 
        */
        [When(@"I get the current event code from the Scope")]
        public void GetCurrentEventCodeFromTheScope()
        {
            ISCOPE scope = SCOPE.GetScope(false);
           _scopeSystemGroup.GetScopeEventResponse(scope);
        }
        #endregion EVENT?

        #region EVMsg?
        /// <summary>
        /// Gets the current event code and message on the queue
        /// 
        /// (DPO|CSA)
        /// EVMsg?
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"I get the current event message from the Scope")]
            \endverbatim 
        */
        [When(@"I get the current event message from the Scope")]
        public void GetCurrentEventMessageFromTheScope()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeSystemGroup.GetScopeEventMessage(scope);
        }
        #endregion EVMsg?

        #region FACtory
        /// <summary>
        /// Resets the scope to the factory default
        /// 
        /// (DPO|CSA)
        /// FACtory
        /// </summary>
        /*!
            \scope\verbatim
        [When(@"I perform a factory default reset on the Scope")]
            \endverbatim 
        */
        [When(@"I perform a factory default reset on the Scope")]
        public void ResetTheScopeToFactoryDefault()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeSystemGroup.RunScopeFactoryDefault(scope);
        }
        #endregion  FACtory

        #region RECAll: SETUp
        /// <summary>
        /// Loads the given setup file into the scope
        /// 
        /// (DPO|CSA)
        /// RECAll: SETUp
        /// </summary>
        /// <param name="filepath">Filepath of the setup file</param>
        /*!
            \scope\verbatim
        [When(@"I recall the setup ""(.+)"" on the Scope")]
            \endverbatim 
        */
        [When(@"I recall the setup ""(.+)"" on the Scope")]
        public void RecallScopeSetup(string filepath)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeSystemGroup.RunScopeRecallSetup(scope, filepath);
        }
        #endregion RECAll: SETUp

        #region SELECT:CH
        /// <summary>
        /// Sets the given channel state to on
        /// 
        /// (DPO|CSA)
        /// SELECT:CH ON
        /// </summary>
        /// <param name="channel">Which channel</param>
        /*!
            \scope\verbatim
        [When(@"I turn channel ([1-4]) on for the Scope")]
            \endverbatim 
        */
        [When(@"I turn channel ([1-4]) on for the Scope")]
        public void TurnTheScopeChannelOn(string channel)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeSystemGroup.SetScopeSelectChannelState(scope, channel, "ON");
        }

        /// <summary>
        /// Sets the given channel state to off 
        /// 
        /// (DPO|CSA)
        /// SELECT:CH OFF
        /// </summary>
        /// <param name="channel">Which channel</param>
        /*!
            \scope\verbatim
        [When(@"I turn channel ([1-4]) off for the Scope")]
            \endverbatim 
        */
        [When(@"I turn channel ([1-4]) off for the Scope")]
        public void TurnTheScopeChanneOff(string channel)
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeSystemGroup.SetScopeSelectChannelState(scope, channel, "OFF");
        }
        #endregion SELECT:CH

        /// <summary>
        /// Queries the error queue for a 0 error message fron the Scope
        /// 
        /// Purposely no "get" step for the error queue, we want to get and check it every time.@n
        /// SYSTem:ERRor?
        /// </summary>
        /*!
            \system\verbatim
        [Then(@"there should be no error from the Scope")]
            \endverbatim 
        */
        [Then(@"there should be no error from the Scope")]
        public void ThereShouldBeNoErrorFromTheScope()
        {
            ISCOPE scope = SCOPE.GetScope(false);
            _scopeSystemGroup.TheScopeShouldHaveNoErrors(scope);
        }
    }
}
