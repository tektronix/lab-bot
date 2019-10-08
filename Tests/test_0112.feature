Feature: [ TC-112  ]  Verify MTONe:TONes:SPACing operation

Scenario:  Verify MTONe:TONes:SPACing operation

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I set the MultiTone tones spacing to 1e6 Hz for AWG 1
 And I get the MultiTone tones spacing for AWG 1
Then the MultiTone tones spacing should be 1e6 Hz for AWG 1

When I set the MultiTone tones spacing to the lowest possible value for AWG 1
 And I get the MultiTone tones spacing for AWG 1
Then the MultiTone tones spacing should be 3.8147009036e3 Hz for AWG 1

When I set the MultiTone tones spacing to the highest possible value for AWG 1
 And I get the MultiTone tones spacing for AWG 1
Then the MultiTone tones spacing should be 4e9 Hz for AWG 1
