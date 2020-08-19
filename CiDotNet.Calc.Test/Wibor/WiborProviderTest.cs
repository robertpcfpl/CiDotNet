using CiDotNet.Calc.Wibor;
using Moq;
using NUnit.Framework;

namespace CiDotNet.Calc.Test.Wibor
{
    [TestFixture]
    class WiborProviderTest
    {
        [Test]
        public void TestWiborProvider()
        {
            var mock = new Mock<IXiborService>();
            mock.Setup(foo => foo.ProvideInterbankOfferedRate3M()).Returns(1.3M);
            IXiborService wiborProvider = mock.Object;
            decimal wiborValue = wiborProvider.ProvideInterbankOfferedRate3M();
            Assert.AreEqual(1.3M, wiborValue);
        }
    }
}
