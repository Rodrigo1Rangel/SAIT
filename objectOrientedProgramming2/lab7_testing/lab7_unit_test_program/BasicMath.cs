using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7_unit_test
{
    public class BasicMath
    {
        public static double Add(
            double num1,
            double num2)
        {
            double result = num1 + num2;
            return result;
        }

        public static double Subtract(
            double num1,
            double num2)
        {
            double result = num1 - num2;
            return result;
        }
        public static double Devide(
            double num1,
            double num2)
        {
            return num1 / num2;
        }
        public static double Multiply(
            double num1,
            double num2)
        {
            double result = num1 * num2;
            return result;
        }
    }
}
