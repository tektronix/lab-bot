Feature: [ TC-75  ]  Verify MTONe:COMPile:NAME operation

Scenario:  Verify MTONe:COMPile:NAME operation

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I set the MultiTone signal name to "Hello World" for AWG 1
 And I get the MultiTone signal name for AWG 1
Then the MultiTone signal name should be "Hello World" for AWG 1
