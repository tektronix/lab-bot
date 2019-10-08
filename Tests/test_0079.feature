Feature: [ TC-79  ]  Verify MTONe:COMPile:PLAY operation

Scenario:  Verify MTONe:COMPile:PLAY operation

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I set the MultiTone compilation settings to play after compilation for AWG 1
 And I get the MultiTone play after compile setting for AWG 1
Then the MultiTone play after compile setting should be on for AWG 1

When I set the MultiTone compilation settings to not play after compilation for AWG 1
 And I get the MultiTone play after compile setting for AWG 1
Then the MultiTone play after compile setting should be off for AWG 1
