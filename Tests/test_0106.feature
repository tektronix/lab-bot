Feature: [ TC-106  ]  Verify MTONe:CHIRp:FSWeep operation

Scenario:  Verify MTONe:CHIRp:FSWeep operation

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I set the MultiTone chirp frequency to sweep from high to low for AWG 1
 And I get the MultiTone frequency sweep for AWG 1
Then the MultiTone chirp frequency should sweep from high to low for AWG 1

When I set the MultiTone chirp frequency to sweep from low to high for AWG 1
 And I get the MultiTone frequency sweep for AWG 1
Then the MultiTone chirp frequency should sweep from low to high for AWG 1
