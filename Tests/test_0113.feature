Feature: [ TC-113  ]  Verify MTONe:TONes:NTONes Syntax

Scenario Outline:  Verify MTONe:TONes:NTONes Syntax

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I send the "<command>" command for AWG 1
Then there should be no error on AWG 1

Examples:
| command              |
| MTONe:TONes:NTONes 2 |
| MTON:TON:NTON 2      |
