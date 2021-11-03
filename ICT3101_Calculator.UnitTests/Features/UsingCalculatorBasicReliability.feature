Feature: UsingCalculatorBasicReliability
In order to calculate the Basic Musa model's failures/intensities
As a Software Quality Metric enthusiast

@Musa
Scenario: Calculating Current Failure Intensity
 Given I have a calculator
 When I have entered "10", "50" and "100" into the calculator and press CFI
 Then the CFI result should be "5"

 @Musa
Scenario: Calculating Current Failure Intensity with negative values
 Given I have a calculator
 When I have entered "-10", "50" and "100" into the calculator and press CFI
 Then the calculator should show an argument exception

 @Musa
Scenario: Calculating Average Number of Expected Failure with negative values
 Given I have a calculator
 When I have entered "10", "50", "100" and "10" into the calculator and press ANEF
 Then the CFI result should be "63"

  @Musa
Scenario: Calculating Average Number of Expected Failure
 Given I have a calculator
 When I have entered "-10", "50", "100" and "10" into the calculator and press ANEF
 Then the calculator should show an argument exception


