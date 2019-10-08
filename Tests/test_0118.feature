Feature: [ TC-118  ]  Verify MTONe:TONes:PHASe:UDEFined operation

Scenario:  Verify MTONe:TONes:PHASe:UDEFined operation

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I set the MultiTone tones phase to User Defined for AWG 1
 And I set the MultiTone tones user defined phase to 20 degrees for AWG 1
 And I get the MultiTone tones user defined phase for AWG 1
Then the MultiTone tones user defined phase should be 20 degrees for AWG 1

When I set the MultiTone tones user defined phase to the lowest possible value for AWG 1
 And I get the MultiTone tones user defined phase for AWG 1
Then the MultiTone tones user defined phase should be -180 degrees for AWG 1

When I set the MultiTone tones user defined phase to the highest possible value for AWG 1
 And I get the MultiTone tones user defined phase for AWG 1
Then the MultiTone tones user defined phase should be 180 degrees for AWG 1
