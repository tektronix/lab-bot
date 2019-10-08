Feature: SpecFlowFeature1
	
@mytag
Scenario: UI Automation

Given an AWG
	Given AWG 1
	Given a reset for AWG 1
	 When I select the AWG button
	  When I select the Functions button
	 When I select the Sine waveform shape button
	  When I select the Square waveform shape button
	   When I select the Triangle waveform shape button
	 #  Sine|Square|Triangle|Noise|DC|Exp Rise|Exp Decay|Gaussian
	   When I select the Noise waveform shape button
	  
	
