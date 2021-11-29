using NUnit.Framework;
using System.Collections.ObjectModel;

namespace PimApp
{
    public class CalculatorTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalculatorTestMethod()
        {
            ObservableCollection<float> rezult = new ObservableCollection<float>()
            {
                29,33,33,33,99
            };
            Calculator calculator = new Calculator(new CalculatorProcessor());
            float expectedAvg = 33;
            float actualAvg = calculator.Data.Avg;
            float expectedSredneeqvadroAvg = 0;
            float actualSredneeqvadroAvg = calculator.Data.Sredneeqvadro;

            calculator.Calculate(rezult);

            Assert.AreEqual(expectedAvg, actualAvg);
            Assert.AreEqual(expectedSredneeqvadroAvg, actualSredneeqvadroAvg);
        }
    }
}