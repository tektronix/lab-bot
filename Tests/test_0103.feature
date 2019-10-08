Feature: [ TC-103  ]  Verify MTONe:CHIRp:STIMe Syntax

Scenario Outline:  Verify MTONe:CHIRp:STIMe Syntax

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I send the "<command>" command for AWG 1
Then there should be no error on AWG 1

Examples:
| command                |
| MTONe:CHIRp:STIMe 1e-3 |
| MTON:CHIR:STIM 1e-3    |
| MTONe:CHIRp:STIMe 1 kS |
| MTON:CHIR:STIM 1 kS    |
