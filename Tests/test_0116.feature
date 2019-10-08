Feature: [ TC-116  ]  Verify MTONe:TONes:PHASe operation

Scenario:  Verify MTONe:TONes:PHASe operation

Given AWG 1
 And the family is 70k for AWG 1
 And a reset for AWG 1

When I load the MultiTone module for AWG 1
 And I wait for operation complete for AWG 1
 And I set the MultiTone tones phase to Newman for AWG 1
 And I get the MultiTone tones phase for AWG 1
Then the MultiTone tone phase should be Newman for AWG 1

When I set the MultiTone tones phase to Random for AWG 1
 And I get the MultiTone tones phase for AWG 1
Then the MultiTone tone phase should be Random for AWG 1

When I set the MultiTone tones phase to User Defined for AWG 1
 And I get the MultiTone tones phase for AWG 1
Then the MultiTone tone phase should be User Defined for AWG 1
