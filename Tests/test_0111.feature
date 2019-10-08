Feature: [ TC-111  ]  Verify MTONe:TONes:SPACing Syntax

Scenario Outline:  Verify MTONe:TONes:SPACing Syntax

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I send the "<command>" command for AWG 1
Then there should be no error on AWG 1

Examples:
| command                     |
| MTONe:TONes:SPACing 1.1e9   |
| MTON:TON:SPAC 1.1e9         |
| MTONe:TONes:SPACing 2.1 GHz |
| MTON:TON:SPAC 2.1 GHz       |
