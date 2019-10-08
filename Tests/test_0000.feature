Feature: [ TC-0000 ] Establish connection with the required AWG from SourceXpress

@mytag
Scenario: TC-0000 Verify that connection can be successfully established with the AWG from SX

Given a reset for SXApp 1

When I connect to AWG 1
And I query the connect status for AWG 1
Then the connect status for AWG 1 should be 1

When I set the AWG 1 as the active generator
And I query for the active generator on AWG 1
Then AWG 1 should be the active generator