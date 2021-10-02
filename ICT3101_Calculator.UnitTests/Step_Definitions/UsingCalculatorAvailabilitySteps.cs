using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace ICT3101_Calculator.UnitTests.Step_Definitions
{
    [Binding]
    public class UsingCalculatorAvailabilitySteps
    {
        private Calculator _calculator;
        private double _result;
        private Exception _exception;

        public UsingCalculatorAvailabilitySteps(Calculator c)
        {
            this._calculator = c;
        }

        [When(@"I have entered ""(.*)"" and ""(.*)"" into the calculator and press MTBF")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressMTBF(int p0, int p1)
        {
            try
            {
                _result = _calculator.MTBF(p0, p1);
            }
            catch (Exception e) 
            {
                _exception = e;
            }
        }

        [When(@"I have entered ""(.*)"" and ""(.*) into the calculator and press Availability")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressAvailability(int p0, int p1)
        {
            try
            {
                _result = _calculator.Availability(p0, p1);
            }
            catch (Exception e)
            {
                _exception = e;
            }
        }

        [Then(@"the result should be an argument exception")]
        public void ThenTheMTBFResultShouldBeAnArgumentException()
        {
            Assert.That(_exception.GetType, Is.EqualTo(typeof(ArgumentException)));
        }


        [Then(@"the MTBF result should be ""(.*)""")]
        public void ThenTheMTBFResultShouldBe(int p0)
        {
            Assert.That(_result, Is.EqualTo(p0));
        }

        [Then(@"the availability result should be ""(.*)""")]
        public void ThenTheAvailabilityResultShouldBe(Decimal p0)
        {
            Assert.That(_result, Is.EqualTo(p0));
        }
    }
}
