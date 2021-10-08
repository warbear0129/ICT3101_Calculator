using System;
using System.Collections.Generic;
using System.Text;

namespace ICT3101_Calculator
{
    public class Calculator
    {
        public Calculator() { }
        public double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; // Default value
                                        // Use a switch statement to do the math.
            switch (op)
            {
                case "a":
                    result = Add(num1, num2);
                    break;
                case "s":
                    result = Subtract(num1, num2);
                    break;
                case "m":
                    result = Multiply(num1, num2);
                    break;
                case "d":
                    // Ask the user to enter a non-zero divisor.
                    result = Divide(num1, num2);
                    break;
                case "f":
                    result = Factorial(num1);
                    break;
                case "t":
                    result = Triangle(num1,num2);
                    break;
                case "c":
                    result = Circle(num1);
                    break;
                // Return text for an incorrect option entry.
                default:
                    break;
            }
            return result;
        }
        public double Add(double num1, double num2)
        {
            if (this.IsBinary(num1) && this.IsBinary(num2))
            {
                string binaryString = num1.ToString() + num2.ToString();
                return Convert.ToInt32(binaryString, 2);
            }

            return (num1 + num2);
        }
        public double Subtract(double num1, double num2)
        {
            return (num1 - num2);
        }
        public double Multiply(double num1, double num2)
        {
            return (num1 * num2);
        }
        public double Divide(double num1, double num2)
        {

            if (num1 == 0 && num2 == 0)
                return 1;

            if (num2 == 0)
                return double.PositiveInfinity;
            
            if (num1 == 0)   
                return 0;

            return (num1 / num2);
        }

        public double Factorial (double num1)
        {
            if(num1 <0)
            {
                throw new ArgumentException();
            }

           if (num1 == 0)
            {
                return 1;
            }

            return num1 * Factorial(num1 - 1);
        }
        public double Triangle(double num1,double num2)
        {
            if (num1 <= 0 || num2 <= 0)
            {
                throw new ArgumentException();
            }

            return ((num1 * num2) / 2);
        }

        public double Circle(double num1)
        {
            if (num1 < 0 || num1 == 0)
            {
                throw new ArgumentException();
            }

            return (3.14*(num1*num1));
        }

        // Task 18
        public double UnknownFunctionA(double num1, double num2)
        {
            double total;
            if(num1 < num2)
            {
                throw new ArgumentException();
            }
            else if (num1 == num2)
            {
                return Factorial(num1);
            }
            else
            {
                total = Subtract(num1, num2);
                total *= Factorial(Subtract(total, 1));
                return (num1 * Factorial(Subtract(num1, 1))) / total;
            }
        }

        public double UnknownFunctionB(double num1, double num2)
        {
            
            if (num1 < num2)
            {
                throw new ArgumentException();
            }
           
            else
            {
                return Divide(Factorial(num1), (Multiply(Factorial(num2), Factorial(Subtract(num1, num2)))));
            }
        }

        public double MTBF(double mttf, double mttr)
        {
            if (mttf <= 0 || mttr <= 0)
                throw new ArgumentException("MTTF & MTTR cannot be 0 or less");

            return mttf + mttr;
        }

        public double Availability(double mttf, double mttr)
        {
            double mtbf = this.MTBF(mttf, mttr);

            return mttf / mtbf;
        }

        public double CFI(double lambda, double mu, double v)
        {
            if ((lambda < 0) || (mu < 0) || (v < 0))
                throw new ArgumentException("Parameters cannot be less than 0");

            return (lambda * (1 - (mu / v)));
        }

        public double ANEF(double lambda, double mu, double v, double tau)
        {
            double cfi = CFI(lambda, mu, v);

            if (tau < 0)
                throw new ArgumentException("Parameters cannot be less than 0");

            return Math.Round(v * (1 - Math.Exp(-(tau * (lambda / v)))));
        }

        public double NEF(double theta, double lambda, double mu, double tau)
        {
            if (theta < 0 || lambda < 0 || mu < 0 || tau < 0)
                throw new ArgumentException("Parameters cannot be less than 0");

            return Math.Round((1 / theta) * Math.Log(lambda * theta * tau + 1));
        }

        public double DD(double kloc, double defects)
        {
            if (kloc < 0 || defects < 0)
                throw new ArgumentException("Parameters cannot be less than 0");

            else if (defects == 0)
                return 0;

            else if (kloc == 0)
                return Double.PositiveInfinity;

            return defects / kloc;
        }

        public double KSSI(double kcsi, double kloc)
        {
            if (kcsi < 0)
                throw new ArgumentException("KCSI cannot be less than 0");

            else if ((kloc + kcsi) < 0)
                throw new ArgumentException("KSSI cannot be less than 0");

            else
                return kloc + kcsi;
        }


        private bool IsBinary(double num1)
        {
            // If has decimal places, not binary
            if (num1 % 1 != 0)
                return false;

            if (num1 < 0)
                return false;

            while (num1 != 0)
            {
                if (num1 % 10 > 1)
                    return false;

                num1 = Math.Floor(num1 / 10);
            }

            return true;
        }

        public double GenMagicNum(double input, IFileReader fileReader)
        {
            double result = 0;
            int choice = Convert.ToInt16(input);
            //Dependency------------------------------
            /// FileReader getTheMagic = new FileReader();
            //----------------------------------------
            string[] magicStrings = fileReader.Read("../../../../MagicNumbers.txt");
            if ((choice >= 0) && (choice < magicStrings.Length))
            {
                result = Convert.ToDouble(magicStrings[choice]);
            }
            result = (result > 0) ? (2 * result) : (-2 * result);
            return result;
        }

    }
}
