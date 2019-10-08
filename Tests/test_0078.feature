Feature: [ TC-78  ]  Verify MTONe:COMPile:PLAY Syntax

Scenario Outline:  Verify MTONe:CHANnel:PLAY Syntax

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I send the "<command>" command for AWG 1
Then there should be no error on AWG 1

Examples:
| command               |
| MTONe:COMPile:PLAY ON |
| MTONe:COMP:PLAY ON    |
| MTON:COMPile:PLAY ON  |
| MTON:COMP:PLAY ON     |
| MTONe:COMPile:PLAY 0  |
| MTONe:COMP:PLAY 0     |
| MTON:COMPile:PLAY 0   |
| MTON:COMP:PLAY 0      |
