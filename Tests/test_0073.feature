Feature: [ TC-73  ]  Verify MTONe:COMPile:NAME Syntax

Scenario Outline:  Verify MTONe:COMPile:NAME Syntax

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I send the "<command>" command for AWG 1
Then there should be no error on AWG 1

Examples:
| command                          |
| MTONe:COMPile:NAME "Hello World" |
| MTONe:COMP:NAME "Hello World"    |
| MTON:COMPile:NAME "Hello World"  |
| MTON:COMP:NAME "Hello World"     |
