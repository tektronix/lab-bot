Feature: [ TC-76  ]  Verify MTONe:COMPile:CHANnel Syntax

Scenario Outline:  Verify MTONe:CHANnel:NAME Syntax

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I send the "<command>" command for AWG 1
Then there should be no error on AWG 1

Examples:
| command                    |
| MTONe:COMPile:CHANnel NONE |
| MTONe:COMPile:CHAN NONE    |
| MTONe:COMP:CHANnel NONE    |
| MTONe:COMP:CHAN NONE       |
| MTON:COMPile:CHANnel NONE  |
| MTON:COMPile:CHAN NONE     |
| MTON:COMP:CHANnel NONE     |
| MTON:COMP:CHAN NONE        |
| MTON:COMP:CHAN 1           |
