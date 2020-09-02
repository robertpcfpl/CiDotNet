using CiDotNet.AngularCalc.Models;
using CiDotNet.Calc.Wibor;
using Microsoft.AspNetCore.Mvc;

namespace CiDotNet.AngularCalc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        private readonly WiborProvider wiborProvider;

        public CalculationController(WiborProvider wiborProvider)
        {
            this.wiborProvider = wiborProvider;
        }

        [HttpPost]
        public ActionResult<CalculationResultDto> Calculate([FromBody] CalculationDataDto calculationData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid form data");
            }
            var result = CiDotNet.Calc.Math.RoundHelper.Round5Rappen((decimal)CiDotNet.Calc.Math.Finance.CalculateRate(calculationData.Duration, 12, calculationData.InterestRate, calculationData.Price, calculationData.ResidualValue, calculationData.CalculationMode)).ToString("0.00");
            return Ok(new CalculationResultDto()
            {
                Result = result
            });
        }

        [HttpGet("GetWiborInterestRate")]
        public WiborReusltDto GetWiborInterestRate()
        {
            return new WiborReusltDto()
            {
                result = wiborProvider.Wibor3M().ToString()
            };
        }
    }
}
