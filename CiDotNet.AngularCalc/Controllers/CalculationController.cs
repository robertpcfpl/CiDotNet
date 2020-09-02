using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CiDotNet.AngularCalc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CiDotNet.AngularCalc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        [HttpPost]
        public ActionResult<string> Calculate([FromBody] CalculationData calculationData)
        {
            var result = CiDotNet.Calc.Math.RoundHelper.Round5Rappen((decimal)CiDotNet.Calc.Math.Finance.CalculateRate(calculationData.Duration, 12, calculationData.InterestRate, calculationData.Price, calculationData.ResidualValue, calculationData.CalculationMode)).ToString("0.00");
            return Ok(result);
        }
    }
}
