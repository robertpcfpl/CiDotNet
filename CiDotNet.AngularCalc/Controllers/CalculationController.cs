using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CiDotNet.AngularCalc.Models;
using CiDotNet.Calc.Wibor;
using Microsoft.AspNetCore.Http;
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
        public ActionResult<string> Calculate([FromBody] CalculationDataDto calculationData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid form data");
            }
            var result = CiDotNet.Calc.Math.RoundHelper.Round5Rappen((decimal)CiDotNet.Calc.Math.Finance.CalculateRate(calculationData.Duration, 12, calculationData.InterestRate, calculationData.Price, calculationData.ResidualValue, calculationData.CalculationMode)).ToString("0.00");
            return Ok(result);
        }

        [HttpGet]
        public string GetWiborInterestRate()
        {
            return wiborProvider.Wibor3M().ToString();
        }
    }
}
