Feature: [ TC-114  ]  Verify MTONe:TONes:NTONes operation

Scenario:  Verify MTONe:TONes:NTONes operation

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I set the MultiTone number of Tones to 3 for AWG 1
 And I get the MultiTone number of Tones for AWG 1
Then the MultiTone number of Tones should be 3 for AWG 1

When I set the MultiTone number of Tones to the lowest possible value for AWG 1
 And I get the MultiTone number of Tones for AWG 1
Then the MultiTone number of Tones should be 2 for AWG 1

When I set the MultiTone number of Tones to the highest possible value for AWG 1
 And I get the MultiTone number of Tones for AWG 1
Then the MultiTone number of Tones should be 1.048576e6 for AWG 1
