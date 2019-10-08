Feature: [ TC-117  ]  Verify MTONe:TONes:PHASe:UDEFined Syntax

Scenario Outline:  Verify MTONe:TONes:PHASe:UDEFined Syntax

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I send the "<command>" command for AWG 1
Then there should be no error on AWG 1

Examples:
| command                           |
| MTONe:TONes:PHASe:UDEFined 10     |
| MTON:TON:PHAS:UDEF 10             |
| MTONe:TONes:PHASe:UDEFined 10 deg |
| MTON:TON:PHAS:UDEF 10 deg         |
