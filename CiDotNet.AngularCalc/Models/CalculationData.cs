using System.ComponentModel.DataAnnotations;
using static CiDotNet.Calc.Math.Finance;

namespace CiDotNet.AngularCalc.Models
{
    public class CalculationDataDto
    {
        [Required]
        public float Price { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public float ResidualValue { get; set; }
        [Required]
        public float InterestRate { get; set; }
        [Required]
        public Mode CalculationMode { get; set; }
    }
}
