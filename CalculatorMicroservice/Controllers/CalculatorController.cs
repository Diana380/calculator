using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CalculatorMicroservice.Services;

namespace CalculatorMicroservice.Controllers
{
   
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private CalculatorService _calculatorService = new CalculatorService();

        [HttpPost]
        [Route("[controller]")]
        public ActionResult Post(string numbers)
        {
            var result = _calculatorService.Add(numbers);
            return Ok(result);
        }
    }

}