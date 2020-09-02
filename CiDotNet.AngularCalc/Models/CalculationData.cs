using static CiDotNet.Calc.Math.Finance;

namespace CiDotNet.AngularCalc.Models
{
    public class CalculationData
    {
        public float Price { get; set; }
        public int Duration { get; set; }
        public float ResidualValue { get; set; }
        public float InterestRate { get; set; }
        public Mode CalculationMode { get; set; }
    }
}
