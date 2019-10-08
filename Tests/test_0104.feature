Feature: [ TC-104  ]  Verify MTONe:CHIRp:STIMe operation

Scenario:  Verify MTONe:CHIRp:STIMe operation

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I set the MultiTone chirp sweep time to 1 Sec for AWG 1
 And I get the MultiTone chirp sweep time for AWG 1
Then the MultiTone chirp sweep time should be 1 Sec for AWG 1

When I set the MultiTone chirp sweep time to the lowest possible value for AWG 1
 And I get the MultiTone chirp sweep rate for AWG 1
Then the MultiTone chirp sweep time should be 1 Sec for AWG 1

When I set the MultiTone chirp sweep time to the highest possible value for AWG 1
 And I get the MultiTone chirp sweep time for AWG 1
Then the MultiTone chirp sweep time should be 7.9228162514E+27 Sec for AWG 1
