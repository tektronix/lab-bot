Feature: [ TC-120  ]  Verify MTONe:TONes:NOTCh:ADD operation

Scenario:  Verify MTONe:TONes:NOTCh:ADD operation

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I delete all MultiTone tone notches for AWG 1
 And I add a MultiTone tone notch with a start frequency of 1e9 Hz and an end frequency of 5e9 Hz for AWG 1
 And I add a MultiTone tone notch with the lowest possible values for start and end for AWG 1
 And I add a MultiTone tone notch with the highest possible values for start and end for AWG 1
 And I get the MultiTone tones notch 1 start and end frequency for AWG 1
Then the MultiTone tones notch start frequency should be 1e9 Hz and the end frequency should be 5e9 Hz for AWG 1

When I get the MultiTone tones notch 2 start and end frequency for AWG 1
Then the MultiTone tones notch start frequency should be 1 Hz and the end frequency should be 1 Hz for AWG 1

When I get the MultiTone tones notch 3 start and end frequency for AWG 1
Then the MultiTone tones notch start frequency should be 12.5e9 Hz and the end frequency should be 12.5e9 Hz for AWG 1
