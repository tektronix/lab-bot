Feature: [ TC-125  ]  Verify MTONe:TONes:NOTCh:STARt Syntax

Scenario Outline:  Verify MTONe:TONes:NOTCh:STARt Syntax

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I add a MultiTone tone notch with a start frequency of 1e9 Hz and an end frequency of 5e9 Hz for AWG 1
 And I send the "<command>" command for AWG 1
Then there should be no error on AWG 1

Examples:
| command                         |
| MTONe:TONes:NOTCh:STARt 1.1e9   |
| MTON:TON:NOTC:STAR 1.1e9        |
| MTONe:TONes:NOTCh:STARt 1.1 GHZ |
| MTON:TON:NOTC:STAR 1.1 GHZ      |
