using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace ICT3101_Calculator.UnitTests.Step_Definitions
{
    [Binding]
    public class UsingCalculatorDefectDensitySteps
    {
        private Calculator _calculator;
        private double _result;

        public UsingCalculatorDefectDensitySteps(Calculator c)
        {
            this._calculator = c;
        }

        [When(@"I have entered ""(.*)"" and ""(.*)"" into the calculator and press DD")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressDD(int p0, int p1)
        {
            _result = _calculator.DD(p0, p1);
        }
        
        [When(@"I have entered ""(.*)"" and ""(.*)"" into the calculator and press KSSI")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressKSSI(int p0, int p1)
        {
            _result = _calculator.KSSI(p0, p1);
        }
        
        [Then(@"the DD result should be ""(.*)""")]
        public void ThenTheDDResultShouldBe(double p0)
        {
            Assert.That(_result, Is.EqualTo(p0));
        }
        
        [Then(@"the KSSI result should be ""(.*)""")]
        public void ThenTheKSSIResultShouldBe(int p0)
        {
            Assert.That(_result, Is.EqualTo(p0));
        }
    }
}
