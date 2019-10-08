Feature: [ TC-90000 ] Terminate the connection to AWG from SX

@mytag
Scenario: TC-90000 Verify that connection to AWG can be terminated from SourceXpress

Given a reset for SXApp 1

When I disconnect from AWG 1
And I query the connect status for AWG 1
Then the connect status for AWG 1 should be 0
