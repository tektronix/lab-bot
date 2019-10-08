Feature: [ TC-46  ]  Verify MTONe:TYPE Syntax

Scenario Outline:  Verify MTONe:TYPE Syntax

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 Then there should be no error on AWG 1
When I reset for MultiTone plugin for AWG 1
 And I wait for operation complete for AWG 1
 And I send the "<command>" command for AWG 1
Then there should be no error on AWG 1

Examples:
| command          |
| MTONe:TYPE TONes |
| MTONe:TYPE TON   |
| MTON:TYPE TONes  |
| MTON:TYPE TON    |
| MTONe:TYPE CHIRp |
| MTONe:TYPE CHIR  |
| MTON:TYPE CHIRp  |
| MTON:TYPE CHIR   |
