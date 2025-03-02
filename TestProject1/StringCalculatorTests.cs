namespace TestProject1
{
    using ConsoleApp1;
    public class StringCalculatorTests
    {
        [Fact]
        public void TestEmptyString()
        {
            var calculator = new StringCalculator();

            var result = calculator.Calculate("");

            Assert.Equal(0, result);
        }

        [Fact]
        public void TestSingleNumber()
        {
            var calculator = new StringCalculator();

            var result1 = calculator.Calculate("7");

            var result2 = calculator.Calculate("9");

            Assert.Equal(7, result1);

            Assert.Equal(9, result2);
        }

        [Fact]
        public void TestAdditionCommaDelimited()
        {
            var calculator = new StringCalculator();

            var result1 = calculator.Calculate("1,2");

            var result2 = calculator.Calculate("15,3");

            Assert.Equal(3, result1);

            Assert.Equal(18, result2);
        }

        [Fact]
        public void TestAdditionNewlineDelimited()
        {
            var calculator = new StringCalculator();

            var result1 = calculator.Calculate("15\n3");

            var result2 = calculator.Calculate("3\n5");

            Assert.Equal(18, result1);

            Assert.Equal(8, result2);
        }

        [Fact]
        public void TestAdditionThreeElements()
        {
            var calculator = new StringCalculator();
            var result1 = calculator.Calculate("1,2,3");
            var result2 = calculator.Calculate("1\n2\n3");
            var result3 = calculator.Calculate("1,2\n3");
            Assert.Equal(6, result1);
            Assert.Equal(6, result2);
            Assert.Equal(6, result3);
        }

        [Fact]
        public void TestNegativeNumbers()
        {
            var calculator = new StringCalculator();
            Assert.Throws<NotImplementedException>(() => calculator.Calculate("-1"));
            Assert.Throws<NotImplementedException>(() => calculator.Calculate("-1,2"));
        }

        [Fact]
        public void TestNumbersGreaterThan1000()
        {
            var calculator = new StringCalculator();
            var result1 = calculator.Calculate("1001,2");
            var result2 = calculator.Calculate("1001");
            Assert.Equal(2, result1);
            Assert.Equal(0, result2);
        }

        [Fact]
        public void TestSingleDelimiter()
        {
            var calculator = new StringCalculator();
            var result1 = calculator.Calculate("//;\n1;2");
            var result2 = calculator.Calculate("//;\n1;2;3");
            Assert.Equal(3, result1);
            Assert.Equal(6, result2);
        }

        [Fact]
        public void TestMultiCharDelimiter()
        {
            var calculator = new StringCalculator();
            var result1 = calculator.Calculate("//[***]\n1***2***3");
            var result2 = calculator.Calculate("//[***]\n1***2,3");
            Assert.Equal(6, result1);
            Assert.Equal(6, result2);
        }

        [Fact]
        public void TestMultipleDelimeters()
        {
            var calculator = new StringCalculator();
            var result1 = calculator.Calculate("//[;][%]\n1;2%3");
            var result2 = calculator.Calculate("//[;][%]\n1\n2%3");
            Assert.Equal(6, result1);
            Assert.Equal(6, result2);
        }

        
    }
}