Feature: [ TC-47  ]  Verify MTONe:TYPE operation

Scenario:  Verify MTONe:TYPE operation

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I set the MultiTone type to Tones for AWG 1
 And I get the MultiTone type for AWG 1
Then the MultiTone type should be Tones for AWG 1

When I set the MultiTone type to Chirp for AWG 1
 And I get the MultiTone type for AWG 1
Then the MultiTone type should be Chirp for AWG 1
