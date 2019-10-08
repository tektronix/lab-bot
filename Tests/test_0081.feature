Feature: [ TC-81  ]  Verify MTONe:COMPile:SRATe:AUTO Syntax

Scenario Outline:  Verify MTONe:CHANnel:SRATe:AUTO Syntax

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I send the "<command>" command for AWG 1
Then there should be no error on AWG 1

Examples:
| command               |
| MTONe:COMPile:SRATe:AUTO ON |
| MTON:COMP:SRAT:AUTO ON     |
| MTONe:COMPile:SRATe:AUTO 0  |
| MTON:COMP:SRAT:AUTO 0      |
