 Feature: UsingCalculatorLogarithmicReliability
 In order to calculate the Logarithmic Musa model's failure/intensities
 As a student doing ICT3101 lab2.3

 @MusaLog
 Scenario: Calculating Number of Expected Failures
	Given I have a calculator
	When I have entered "0.02", "10", "50" and "10" into the calculator and press NEF
	Then the NEF result should be "55"