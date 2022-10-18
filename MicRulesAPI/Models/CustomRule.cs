using Newtonsoft.Json;
using RulesEngine.Models;

namespace MicRulesAPI.Models
{
    public class CustomRule
    {
        [JsonProperty("RuleName")]
        public string RuleName { get; set; }

        [JsonProperty("SuccessEvent")]
        public string SuccessEvent { get; set; }

        [JsonProperty("ErrorMessage")]
        public string ErrorMessage { get; set; }

        [JsonProperty("ErrorType")]
        public string ErrorType { get; set; }

        [JsonProperty("RuleExpressionType")]
        public string RuleExpressionType { get; set; }

        [JsonProperty("Expression")]
        public string Expression { get; set; }
    }
}
