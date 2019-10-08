Feature: [ TC-41  ]  Verify MTONe:LOAD Syntax

Scenario Outline:  Verify MTONe:LOAD Syntax
Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1
 
When I send the "<command>" command for AWG 1
Then there should be no error on AWG 1

When I reset for MultiTone plugin for AWG 1
 And I wait for operation complete for AWG 1
 Then there should be no error on AWG 1




Examples:
| command    |
| MTONe:LOAD |
| MTON:LOAD  |
