namespace lab7_unit_test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(1D, 1D, 2D)]
        public void TestMethod_Add(
            double num1,
            double num2,
            double resultExpected)
        {
            double testAddResult = BasicMath.Add(num1, num2);

            Assert.That(testAddResult,
                Is.EqualTo(resultExpected).Within(0.000001));
        }

        [Test]
        [TestCase(5D, 2D, 3D)]
        public void TestMethod_Subtract(
            double num1,
            double num2,
            double expectedResult)
        {
            double testSubtractResult = BasicMath.Subtract(num1, num2);

            Assert.That(testSubtractResult,
                Is.EqualTo(expectedResult).Within(0.000001));
        }

        [Test]
        [TestCase(10D, 5D, 2D)]
        public void TestMethod_Divide(
            double num1,
            double num2,
            double expectedResult)
        {
            double testDivideResult = BasicMath.Devide(num1, num2);

            Assert.That(testDivideResult,
                Is.EqualTo(expectedResult).Within(0.000001));
        }

        [Test]
        [TestCase(4D, 2D, 8D)]
        public void TestMethod_Multiply(
            double num1,
            double num2,
            double expectedResult)
        {
            double testMultiplyResult = BasicMath.Multiply(num1, num2);

            Assert.That(testMultiplyResult,
                Is.EqualTo(expectedResult).Within(0.000001));
        }
    }
}