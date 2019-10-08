Feature: [ TC-101  ]  Verify MTONe:CHIRp:SRATe operation

Scenario:  Verify MTONe:CHIRp:SRATe operation

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I set the MultiTone chirp sweep rate to 1.1e9 Hz/uSec for AWG 1
 And I get the MultiTone chirp sweep rate for AWG 1
Then the MultiTone chirp sweep rate should be 1.1e9 Hz/uSec for AWG 1

When I set the MultiTone chirp sweep rate to the lowest possible value for AWG 1
 And I set the MultiTone chirp sweep rate to the lowest possible value for AWG 1
 And I get the MultiTone chirp sweep rate for AWG 1
Then the MultiTone chirp sweep rate should be 1 Hz/uSec for AWG 1

When I set the MultiTone chirp sweep rate to the highest possible value for AWG 1
 And I get the MultiTone chirp sweep rate for AWG 1
Then the MultiTone chirp sweep rate should be 12.5e9 Hz/uSec for AWG 1
