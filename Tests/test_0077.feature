Feature: [ TC-77  ]  Verify MTONe:COMPile:CHANnel operation

Scenario:  Verify MTONe:COMPile:CHANnel operation

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I set the MultiTone compilation settings to Compile and Assign to Channel 1 for AWG 1
 And I get the MultiTone compilation settings for Compile and Assign to Channel for AWG 1
Then the MultiTone Compile and Assign to Channel status should be 1 for AWG 1

When I set the MultiTone compilation settings to Compile Only for AWG 1
 And I get the MultiTone compilation settings for Compile and Assign to Channel for AWG 1
Then the MultiTone Compile and Assign to Channel status should be Compile Only for AWG 1
