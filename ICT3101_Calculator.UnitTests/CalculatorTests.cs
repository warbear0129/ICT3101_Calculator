using System;
using NUnit.Framework;
using System.IO;
using Moq;

namespace ICT3101_Calculator.UnitTests
{
    public class CalculatorTests
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
        //Adding two positive numbers
        [Test]
        public void Add_WhenAddingTwoNumbers_ResultEqualToSum()
        {
            // Act 
            double result = _calculator.Add(10, 20);
            // Assert
            Assert.That(result, Is.EqualTo(30));
        }
        //Adding negative number
        [Test]
        public void Add_WhenAddingNegativeNumbers_ResultEqualToSum()
        {
            // Act 
            double result = _calculator.Add(10, -10);
            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        //Substract 
        [Test]
        public void Substract_WhenSubtractingNumbers_ResultEqualToSum()
        {
           
            // Act 
            double result = _calculator.Subtract(20, 10);
            // Assert
            Assert.That(result, Is.EqualTo(10));
        }

        //Multiply
        [Test]
        public void Multiple_WhenNumbers_ResultEqualToSum()
        {

            // Act 
            double result = _calculator.Multiply(20, 10);
            // Assert
            Assert.That(result, Is.EqualTo(200));
        }



        [Test]
        [TestCase(0, 0)]
        [TestCase(0, 10)]
        [TestCase(10, 0)]
        public void Divide_WithZerosAsInputs_ResultThrowArgumentException(int a, int b)
        {
            if (a == 0 && b == 0)
                Assert.That(() => _calculator.Divide(a, b), Is.EqualTo(1));

            else if (a == 0)
                Assert.That(() => _calculator.Divide(a, b), Is.EqualTo(0));

            else if (b == 0)
                Assert.That(() => _calculator.Divide(a, b), Is.EqualTo(double.PositiveInfinity));
            
            else
                Assert.That(() => _calculator.Divide(a, b), Is.EqualTo(a/b));
 
        }

        //Factorial
        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(2)]
        public void Factorial_ResultThrowArgumentException(int a)
        {
            if(a < 0 )
            {
                Assert.That(() => _calculator.Factorial(a), Throws.ArgumentException);
            }
            else if(a == 0)
            {
                Assert.That(() => _calculator.Factorial(a), Is.EqualTo(1));
            }
            else
            {
                Assert.That(() => _calculator.Factorial(a), Is.EqualTo(2*1));
            }
        }

        //Triangle 
        [Test]
        [TestCase(-8, 10)]
        [TestCase(10, -8)]
        [TestCase(0,10)]
        [TestCase(10,0)]
        [TestCase(0,0)]
        [TestCase(10,10)]
        public void Triangle_ResultThrowArgumentException(int a,int b)
        {
            if (a < 0 || b < 0) 
                Assert.That(() => _calculator.Triangle(a, b), Throws.ArgumentException);

            else if (a == 0 ||  b == 0)
                Assert.That(() => _calculator.Triangle(a, b), Throws.ArgumentException);

            else
                Assert.That(() => _calculator.Triangle(a, b), Is.EqualTo(0.5 * a * b));
        }

        //Circle 
        [Test]
        [TestCase(-8)]
        [TestCase(0)]
        [TestCase(5)]
        public void Circle_ResultThrowArgumentException(int a)
        {
            if (a < 0 || a == 0)
            {
                Assert.That(() => _calculator.Circle(a), Throws.ArgumentException);
            }
            else
            {
                Assert.That(() => _calculator.Circle(a), Is.EqualTo(3.14*(a*a)));
            }
        }

        [Test]
        public void UnknownFunctionA_WhenGivenTest0_Result()
        {
            // Act 
            double result = _calculator.UnknownFunctionA(5, 5);
            // Assert
            Assert.That(result, Is.EqualTo(120));
        }
        [Test]
        public void UnknownFunctionA_WhenGivenTest1_Result()
        {
            // Act 
            double result = _calculator.UnknownFunctionA(5, 4);
            // Assert
            Assert.That(result, Is.EqualTo(120));
        }
        [Test]
        public void UnknownFunctionA_WhenGivenTest2_Result()
        {
            // Act 
            double result = _calculator.UnknownFunctionA(5, 3);
            // Assert
            Assert.That(result, Is.EqualTo(60));
        }
        [Test]
        public void UnknownFunctionA_WhenGivenTest3_ResultThrowArgumnetException()
        {
            // Act 
            // Assert
            Assert.That(() => _calculator.UnknownFunctionA(-4, 5), Throws.ArgumentException);
        }
        [Test]
        public void UnknownFunctionA_WhenGivenTest4_ResultThrowArgumnetException()
        {
            // Act 
            // Assert
            Assert.That(() => _calculator.UnknownFunctionA(4, 5), Throws.ArgumentException);
        }

        [Test]
        public void UnknownFunctionB_WhenGivenTest0_Result()
        {
            // Act 
            double result = _calculator.UnknownFunctionB(5, 5);
            // Assert
            Assert.That(result, Is.EqualTo(1));
        }
        [Test]
        public void UnknownFunctionB_WhenGivenTest1_Result()
        {
            // Act 
            double result = _calculator.UnknownFunctionB(5, 4);
            // Assert
            Assert.That(result, Is.EqualTo(5));
        }
        [Test]
        public void UnknownFunctionB_WhenGivenTest2_Result()
        {
            // Act 
            double result = _calculator.UnknownFunctionB(5, 3);
            // Assert
            Assert.That(result, Is.EqualTo(10));
        }
        [Test]
        public void UnknownFunctionB_WhenGivenTest3_ResultThrowArgumnetException()
        {
            // Act 
            // Assert
            Assert.That(() => _calculator.UnknownFunctionB(-4, 5), Throws.ArgumentException);
        }
        [Test]
        public void UnknownFunctionB_WhenGivenTest4_ResultThrowArgumnetException()
        {
            // Act 
            // Assert
            Assert.That(() => _calculator.UnknownFunctionB(4, 5), Throws.ArgumentException);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void GetMagicNumber_WhenGetMagicNumber_ReturnNumberInFile(int p0)
        {
            IFileReader fileReader = new FileReader();
            string[] numbers = fileReader.Read("../../../MagicNumbers.txt");

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