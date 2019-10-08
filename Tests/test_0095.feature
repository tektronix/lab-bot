Feature: [ TC-95  ]  Verify MTONe:CHIRp:LOW operation

Scenario:  Verify MTONe:CHIRp:LOW operation

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I set the MultiTone chirp low frequency to 1.1e9 Hz for AWG 1
 And I get the MultiTone chirp low frequency for AWG 1
Then the MultiTone chirp low frequency should be 1.1e9 Hz for AWG 1

When I set the MultiTone chirp low frequency to the lowest possible value for AWG 1
 And I get the MultiTone chirp low frequency for AWG 1
Then the MultiTone chirp low frequency should be 1 Hz for AWG 1

When I set the MultiTone chirp low frequency to the highest possible value for AWG 1
 And I get the MultiTone chirp low frequency for AWG 1
Then the MultiTone chirp low frequency should be 12499999999 Hz for AWG 1
