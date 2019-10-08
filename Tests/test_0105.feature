Feature: [ TC-105  ]  Verify MTONe:CHIRp:FSWeep Syntax

Scenario Outline:  Verify MTONe:CHIRp:FSWeep Syntax

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I send the "<command>" command for AWG 1
Then there should be no error on AWG 1

Examples:
| command                  |
| MTONe:CHIRp:FSWeep HLOW  |
| MTON:CHIR:FSW HLOW       |
| MTONe:CHIRp:FSWeep LHIGh |
| MTON:CHIR:FSW LHIG       |
