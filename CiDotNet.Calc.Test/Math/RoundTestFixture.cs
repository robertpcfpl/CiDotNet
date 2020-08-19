using NUnit.Framework;

namespace CiDotNet.Calc.Test.Math
{
    [TestFixture]
    public class RoundTestFixture
    {
        [Test]
        public void Test5RappenRound1M()
        {
            decimal Price = 1M;
            decimal ExpectedPrice5RappenRound = 1M;
            decimal ActualPrice5RappenRound = CiDotNet.Calc.Math.RoundHelper.Round5Rappen(Price);
            Assert.AreEqual(ExpectedPrice5RappenRound, ActualPrice5RappenRound);
        }

        [Test]
        public void Test5RappenRound1p024M()
        {
            decimal Price = 1.024M;
            decimal ExpectedPrice5RappenRound = 1M;
            decimal ActualPrice5RappenRound = CiDotNet.Calc.Math.RoundHelper.Round5Rappen(Price);
            Assert.AreEqual(ExpectedPrice5RappenRound, ActualPrice5RappenRound);
        }

        [Test]
        public void Test5RappenRound1p025M()
        {
            decimal Price = 1.025M;
            decimal ExpectedPrice5RappenRound = 1.05M;
            decimal ActualPrice5RappenRound = CiDotNet.Calc.Math.RoundHelper.Round5Rappen(Price);
            Assert.AreEqual(ExpectedPrice5RappenRound, ActualPrice5RappenRound);
        }

        [Test]
        public void Test5RappenRound1p05M()
        {
            decimal Price = 1.05M;
            decimal ExpectedPrice5RappenRound = 1.05M;
            decimal ActualPrice5RappenRound = CiDotNet.Calc.Math.RoundHelper.Round5Rappen(Price);
            Assert.AreEqual(ExpectedPrice5RappenRound, ActualPrice5RappenRound);
        }

        [Test]
        public void Test5RappenRound1p074M()
        {
            decimal Price = 1.074M;
            decimal ExpectedPrice5RappenRound = 1.05M;
            decimal ActualPrice5RappenRound = CiDotNet.Calc.Math.RoundHelper.Round5Rappen(Price);
            Assert.AreEqual(ExpectedPrice5RappenRound, ActualPrice5RappenRound);
        }

        [Test]
        public void Test5RappenRound1p075M()
        {
            decimal Price = 1.075M;
            decimal ExpectedPrice5RappenRound = 1.1M;
            decimal ActualPrice5RappenRound = CiDotNet.Calc.Math.RoundHelper.Round5Rappen(Price);
            Assert.AreEqual(ExpectedPrice5RappenRound, ActualPrice5RappenRound);
        }
    }
}
