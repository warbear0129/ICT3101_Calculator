Feature: UsingCalculatorAvailability
 In order to calculate MTBF and Availability
 As someone who struggles with math
 I want to be able to use my calculator to do this

@Availability
Scenario: Calculating MTBF
 Given I have a calculator
 When I have entered "200" and "10" into the calculator and press MTBF
 Then the MTBF result should be "210"

 @Availability
 Scenario: Calculating MTBF with negative MTTF
	Given I have a calculator
	When I have entered "200" and "-10" into the calculator and press MTBF
	Then the result should be an argument exception

@Availability
 Scenario: Calculating MTBF with negative MTTR
	Given I have a calculator
	When I have entered "-200" and "10" into the calculator and press MTBF
	Then the result should be an argument exception

@Availability
Scenario: Calculating Availability
 Given I have a calculator
 When I have entered "2" and "2 into the calculator and press Availability
 Then the availability result should be "0.5"

 @Availability
 Scenario: Calculating Availability with negative MTTF
 When I have entered "-2" and "2 into the calculator and press Availability
 Then the result should be an argument exception

 @Availability
 Scenario: Calculating Availability with negative MTTR
 When I have entered "2" and "-2 into the calculator and press Availability
 Then the result should be an argument exception