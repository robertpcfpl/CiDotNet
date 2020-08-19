namespace CiDotNet.Calc.Wibor
{
    public class WiborProvider
    {
        private IXiborService xborService;

        public WiborProvider(IXiborService xborService)
        {
            this.xborService = xborService;
        }

        public decimal Wibor3M()
        {
            return xborService.ProvideInterbankOfferedRate3M();
        }

    }
}
