Feature: [ TC-68  ]  Verify MTONe:COMPile Syntax

Scenario Outline:  Verify MTONe:COMPile Syntax

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I send the "<command>" command for AWG 1
Then there should be no error on AWG 1

Examples:
| command       |
| MTONe:COMPile |
| MTONe:COMP    |
| MTON:COMPile  |
| MTON:COMP     |
