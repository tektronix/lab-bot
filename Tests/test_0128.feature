Feature: [ TC-128  ]  Verify MTONe:TONes:NOTCh:DELete operation

Scenario:  Verify MTONe:TONes:NOTCh:DELete operation

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I delete all MultiTone tone notches for AWG 1
 And I add a MultiTone tone notch with a start frequency of 1e9 Hz and an end frequency of 5e9 Hz for AWG 1
 And I add a MultiTone tone notch with a start frequency of 1e9 Hz and an end frequency of 5e9 Hz for AWG 1
 And I get the MultiTone tones notch count for AWG 1
Then the MultiTone tones notch count should be 2 for AWG 1

When I delete MultiTone tone notch 2 for AWG 1
 And I get the MultiTone tones notch count for AWG 1
Then the MultiTone tones notch count should be 1 for AWG 1

When I add a MultiTone tone notch with a start frequency of 1e9 Hz and an end frequency of 5e9 Hz for AWG 1
 And I add a MultiTone tone notch with a start frequency of 1e9 Hz and an end frequency of 5e9 Hz for AWG 1
 And I get the MultiTone tones notch count for AWG 1
Then the MultiTone tones notch count should be 3 for AWG 1

When I delete all MultiTone tone notches for AWG 1
 And I get the MultiTone tones notch count for AWG 1
Then the MultiTone tones notch count should be 0 for AWG 1
