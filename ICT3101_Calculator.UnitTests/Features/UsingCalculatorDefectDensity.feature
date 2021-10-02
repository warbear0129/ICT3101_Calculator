 Feature: UsingCalculatorDefectDensity
 In order to calculate the Defect Density
 As a student doing ICT3101 lab2.3

 @DefectDensity
 Scenario: Calculating Defect Density
	Given I have a calculator
	When I have entered "100" and "50" into the calculator and press DD
	Then the DD result should be "0.5"

@DefectDensity
Scenario: Calculating KSSI
	Given I have a calculator
	When I have entered "50" and "20" into the calculator and press KSSI
	Then the KSSI result should be "70"
