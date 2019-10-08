Feature: [ TC-82  ]  Verify MTONe:COMPile:SRATe:AUTO operation

Scenario:  Verify MTONe:COMPile:SRATe:AUTO operation

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I set the MultiTone compilation settings to automatically calculate sample rate for AWG 1
 And I get the MultiTone Auto sample rate compile setting for AWG 1
Then the MultiTone auto sample rate compile setting should be on for AWG 1

When I set the MultiTone compilation settings to not automatically calculate sample rate for AWG 1
 And I get the MultiTone Auto sample rate compile setting for AWG 1
Then the MultiTone auto sample rate compile setting should be off for AWG 1
