Feature: [ TC-129  ]  Verify MTONe:TONes:NOTCh:COUNt Syntax

Scenario Outline:  Verify MTONe:TONes:NOTCh:COUNt Syntax

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I send the "<command>" query for AWG 1
Then there should be no error on AWG 1

Examples:
| command                  |
| MTONe:TONes:NOTCh:COUNt? |
| MTON:TON:NOTC:COUN?      |
