Feature: [ TC-119  ]  Verify MTONe:TONes:NOTCh:ADD Syntax

Scenario Outline:  Verify MTONe:TONes:NOTCh:ADD Syntax

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I send the "<command>" command for AWG 1
Then there should be no error on AWG 1

Examples:
| command                                |
| MTONe:TONes:NOTCh:ADD 1.1e9, 4.9e9     |
| MTON:TON:NOTCh:ADD 1.1e9, 4.9e9        |
| MTONe:TONes:NOTCh:ADD 1.1 GHZ, 4.9 GHZ |
| MTON:TON:NOTCh:ADD 1.1 GHZ, 4.9e9 GHZ  |
