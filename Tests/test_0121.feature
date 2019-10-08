Feature: [ TC-121  ]  Verify MTONe:TONes:NOTCh:ENABle Syntax

Scenario Outline:  Verify MTONe:TONes:NOTCh:ENABle Syntax

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I send the "<command>" command for AWG 1
Then there should be no error on AWG 1

Examples:
| command                     |
| MTONe:TONes:NOTCh:ENABle ON |
| MTON:TON:NOTC:ENAB ON       |
| MTONe:TONes:NOTCh:ENABle 0  |
| MTON:TON:NOTC:ENAB 0        |
