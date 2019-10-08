Feature: [ TC-99  ]  Verify MTONe:CHIRp:HIGH operation

Scenario:  Verify MTONe:CHIRp:HIGH operation

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I set the MultiTone chirp high frequency to 1.1e9 Hz for AWG 1
 And I get the MultiTone chirp high frequency for AWG 1
Then the MultiTone chirp high frequency should be 1.1e9 Hz for AWG 1

When I set the MultiTone chirp low frequency to the lowest possible value for AWG 1
 And I set the MultiTone chirp high frequency to the lowest possible value for AWG 1
 And I get the MultiTone chirp high frequency for AWG 1
Then the MultiTone chirp high frequency should be 2 Hz for AWG 1

When I set the MultiTone chirp high frequency to the highest possible value for AWG 1
 And I get the MultiTone chirp high frequency for AWG 1
Then the MultiTone chirp high frequency should be 12.5e9 Hz for AWG 1
