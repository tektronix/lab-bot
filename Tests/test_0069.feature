Feature: [ TC-69  ]  Verify MTONe:COMPile operation

Scenario:  Verify MTONe:COMPile operation

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I set the MultiTone type to Tones for AWG 1
 And I compile the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I get the number of waveforms in the waveform list on AWG 1
Then the number of waveforms should be 1 on AWG 1
