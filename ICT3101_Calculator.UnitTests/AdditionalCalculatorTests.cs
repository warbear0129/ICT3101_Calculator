using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.IO;
using Moq;

namespace ICT3101_Calculator.UnitTests
{
    class AdditionalCalculatorTests
    {

        private Calculator _calculator;
        private Mock<IFileReader> _mockFileReader;


        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();

            _mockFileReader = new Mock<IFileReader>();
            _mockFileReader.Setup(
                fr => fr.Read("MagicNumbers.txt"))
                .Returns(new string[] { "42", "42" }
            );
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void GetMagicNumber_WhenGetMagicNumber_ReturnNumberInFile(int p0)
        {
            IFileReader fileReader = _mockFileReader.Object;
            string[] numbers = fileReader.Read("MagicNumbers.txt");

            if (p0 >= numbers.Length || p0 < 0)
            {
                Assert.That(_calculator.GenMagicNum(p0, fileReader), Is.EqualTo(0));
            }
            else
            {
                double magicNumber = _calculator.GenMagicNum(p0, fileReader);
                int result = Convert.ToInt16(numbers[p0]);

                if (result > 0)
                    Assert.That(magicNumber, Is.EqualTo(2 * result));

                else
                    Assert.That(magicNumber, Is.EqualTo(-2 * result));
            }
        }
    }
}
