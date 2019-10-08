Feature: [ TC-110  ]  Verify MTONe:TONes:END operation

Scenario:  Verify MTONe:TONes:END operation

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I set the MultiTone tones end frequency to 5.1e9 Hz for AWG 1
 And I get the MultiTone tones end frequency for AWG 1
Then the MultiTone tones end frequency should be 5.1e9 Hz for AWG 1

When I set the MultiTone tones start frequency to the lowest possible value for AWG 1
 And I set the MultiTone tones end frequency to the lowest possible value for AWG 1
 And I get the MultiTone tones end frequency for AWG 1
Then the MultiTone tones end frequency should be 2 Hz for AWG 1

When I set the MultiTone tones end frequency to the highest possible value for AWG 1
 And I get the MultiTone tones end frequency for AWG 1
Then the MultiTone tones end frequency should be 12.5e9 Hz for AWG 1
