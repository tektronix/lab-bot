Feature: [ TC-72  ]  Verify MTONe:COMPile:CANCel Syntax

Scenario Outline:  Verify MTONe:COMPile:CANCel Syntax

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I send the "<command>" command for AWG 1
Then there should be no error on AWG 1

Examples:
| command       |
| MTONe:COMPile:CANCel |
| MTONe:COMPile:CANC |
| MTONe:COMP:CANCel |
| MTONe:COMP:CANC |
| MTON:COMPile:CANCel |
| MTON:COMPile:CANC |
| MTON:COMP:CANCel |
| MTON:COMP:CANC |
