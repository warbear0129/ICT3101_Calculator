using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace ICT3101_Calculator.UnitTests.Step_Definitions
{
    [Binding]
    public class UsingCalculatorBasicReliabilitySteps
    {
        private Calculator _calculator;
        private double _result;
        private Exception _exception;


        public UsingCalculatorBasicReliabilitySteps(Calculator c)
        {
            this._calculator = c;
        }

        [When(@"I have entered ""(.*)"", ""(.*)"" and ""(.*)"" into the calculator and press CFI")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressCFI(int p0, int p1, int p2)
        {
            try
            {
                _result = _calculator.CFI(p0, p1, p2);
            }
            catch (Exception e)
            { 
                _exception = e;
            }

        }
        
        [When(@"I have entered ""(.*)"", ""(.*)"", ""(.*)"" and ""(.*)"" into the calculator and press ANEF")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressANEF(int p0, int p1, int p2, int p3)
        {
            try
            {
            _result = _calculator.ANEF(p0, p1, p2, p3);
            }
            catch (Exception e)
            { 
                _exception = e;
            }
}
        
        [Then(@"the CFI result should be ""(.*)""")]
        public void ThenTheCFIResultShouldBe(int p0)
        {
            Assert.That(_result, Is.EqualTo(p0));
        }

        [Then(@"the calculator should show an argument exception")]
        public void ThenTheCalculatorShouldShowAnArgumentException()
        {
            Assert.That(_exception.GetType, Is.EqualTo(typeof(ArgumentException)));

        }

    }
}
