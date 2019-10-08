Feature: [ TC-100  ]  Verify MTONe:CHIRp:SRATe Syntax

Scenario Outline:  Verify MTONe:CHIRp:SRATe Syntax

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I send the "<command>" command for AWG 1
Then there should be no error on AWG 1

Examples:
| command                     |
| MTONe:CHIRp:SRATe 1.1e9     |
| MTON:CHIR:SRATe 1.1e9       |
| MTONe:CHIRp:SRATe 1.1 GHzus |
| MTON:CHIR:SRATe 1.1 GHzus   |
