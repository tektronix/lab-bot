Feature: [ TC-132  ]  Verify MTONe:TONes:NOTCh:END operation

Scenario:  Verify MTONe:TONes:NOTCh:END operation

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I delete all MultiTone tone notches for AWG 1
 And I add a MultiTone tone notch with a start frequency of 1e9 Hz and an end frequency of 5e9 Hz for AWG 1
 And I set MultiTone tone notch 1 with a end frequency of 1.1e9 Hz for AWG 1
 And I get the MultiTone tones notch 1 end frequency for AWG 1
Then the MultiTone tones notch end frequency should be 1.1e9 Hz for AWG 1
