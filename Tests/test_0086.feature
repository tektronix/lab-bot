Feature: [ TC-86  ]  Verify MTONe:COMPile:SRATe Syntax

Scenario Outline:  Verify MTONe:CHANnel:SRATe Syntax

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I send the "<command>" command for AWG 1
Then there should be no error on AWG 1

Examples:
| command                   |
| MTONe:COMPile:SRATe 1e9   |
| MTON:COMP:SRAT 1e9        |
| MTONe:COMPile:SRATe 2 GHz |
| MTON:COMP:SRAT 2 GHz |
