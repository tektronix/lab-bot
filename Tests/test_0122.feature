Feature: [ TC-122  ]  Verify MTONe:TONes:NOTCh:ENABle operation

Scenario:  Verify MTONe:TONes:NOTCh:ENABle operation

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I enable notches for MultiTone tones for AWG 1
 And I get the MultiTone tone notch enable setting for AWG 1
Then the MultiTone tone notch enable setting should be on for AWG 1

When I disable notches for MultiTone tones for AWG 1
 And I get the MultiTone tone notch enable setting for AWG 1
Then the MultiTone tone notch enable setting should be off for AWG 1
