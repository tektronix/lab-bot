Feature: [ TC-87  ]  Verify MTONe:COMPile:SRATe operation

Scenario:  Verify MTONe:COMPile:SRATe operation

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I set the MultiTone signal sampling rate to 1e9 Hz for AWG 1
 And I get the MultiTone signal sample rate for AWG 1
Then the MultiTone signal sample rate should be 1e9 Hz for AWG 1

When I set the MultiTone signal sampling rate to the lowest possible value for AWG 1
 And I get the MultiTone signal sample rate for AWG 1
Then the MultiTone signal sample rate should be 1.49e3 Hz for AWG 1

When I set the MultiTone signal sampling rate to the highest possible value for AWG 1
 And I get the MultiTone signal sample rate for AWG 1
Then the MultiTone signal sample rate should be 25e9 Hz for AWG 1
