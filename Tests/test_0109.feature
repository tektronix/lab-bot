Feature: [ TC-109  ]  Verify MTONe:TONes:END Syntax

Scenario Outline:  Verify MTONe:TONes:END Syntax

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I send the "<command>" command for AWG 1
Then there should be no error on AWG 1

Examples:
| command                 |
| MTONe:TONes:END 1.1e9   |
| MTON:TON:END 1.1e9      |
| MTONe:TONes:END 2.1 GHz |
| MTON:TON:END 2.1 GHz    |
