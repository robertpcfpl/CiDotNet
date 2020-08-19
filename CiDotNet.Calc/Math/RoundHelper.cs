namespace CiDotNet.Calc.Math
{
    public class RoundHelper
    {
        public static decimal Round5Rappen(decimal price)
        {
            return System.Math.Round(price * 20, System.MidpointRounding.AwayFromZero) / 20;
        }
    }
}
