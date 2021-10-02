using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace ICT3101_Calculator.UnitTests.Step_Definitions
{
    [Binding]
    public class UsingCalculatorLogarithmicReliabilitySteps
    {
        private Calculator _calculator;
        private double _result;

        public UsingCalculatorLogarithmicReliabilitySteps(Calculator c)
        {
            this._calculator = c;
        }

        [When(@"I have entered ""(.*)"", ""(.*)"", ""(.*)"" and ""(.*)"" into the calculator and press NEF")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressNEF(double p0, int p1, int p2, int p3)
        {
            _result = _calculator.NEF(p0, p1, p2, p3);
        }
        
        [Then(@"the NEF result should be ""(.*)""")]
        public void ThenTheNEFResultShouldBe(int p0)
        {
            Assert.That(_result, Is.EqualTo(p0));
        }
    }
}
