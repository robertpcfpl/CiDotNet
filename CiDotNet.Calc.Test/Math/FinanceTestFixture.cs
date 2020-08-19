using NUnit.Framework;

namespace CiDotNet.Calc.Test.Math
{
    [TestFixture]
    public class FinanceTestFixture
    {
        [Test]
        public void CalculateRate()
        {
            int Duration = 12;
            int Ppy = 12;
            double PeriodicInterestRate = 7.5;
            double presentValue = 30000;
            double finalValue = 0;
            CiDotNet.Calc.Math.Finance.Mode mode = CiDotNet.Calc.Math.Finance.Mode.BeginMode;

            double ExpectedRate = 2586.556528260553;
            double ActualRate = Calc.Math.Finance.CalculateRate(Duration, Ppy, PeriodicInterestRate, presentValue, finalValue, mode);

            Assert.AreEqual(ExpectedRate, ActualRate);
        }
    }
}
