Feature: [ TC-98  ]  Verify MTONe:CHIRp:HIGH Syntax

Scenario Outline:  Verify MTONe:CHIRp:HIGH Syntax

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I send the "<command>" command for AWG 1
Then there should be no error on AWG 1

Examples:
| command                 |
| MTONe:CHIRp:HIGH 1.1e9   |
| MTON:CHIR:HIGH 1.1e9     |
| MTONe:CHIRp:HIGH 2.1 GHz |
| MTON:CHIR:HIGH 2.1 GHz   |
