using Microsoft.AspNetCore.Mvc;
using MicRulesAPI.Models;
using RulesEngine.Models;
using System.Text.Json.Serialization;
using RulesEngine;
using Newtonsoft.Json;
using System.Text.Json;
using RulesEngine.Extensions;

namespace MicRulesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RulesController : ControllerBase
    {
        

        private readonly ILogger<RulesController> _logger;

        public RulesController(ILogger<RulesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        [Route("ApplyRules")]
        public async Task<IActionResult> ApplyRules(WorkFlow workFlow)
        {
            var rulesEngine = new RulesEngine.RulesEngine(new string[] { JsonConvert.SerializeObject(workFlow) });
            var input = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    AmountToPay = 3500,
                    Payments = 14,
                    Name = "Student1"
                },
                 new Student
                {
                    Id = 1,
                    AmountToPay = 3500,
                    Payments = 1,
                    Name = "Student2"
                },
            };

            
            
            List<RuleResultTree> response = await rulesEngine.ExecuteAllRulesAsync(workFlow.WorkflowName, input[0]);
            string errorMessage = string.Empty;

            response.OnSuccess((e) => input[1].Interests += 100);
            response.OnFail(() => errorMessage = "Intereses no aplicables");

            
            return new OkObjectResult(string.IsNullOrEmpty(errorMessage) ? input : errorMessage);
        }
    }
}