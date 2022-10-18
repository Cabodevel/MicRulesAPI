namespace MicRulesAPI.Models
{
    public class WorkFlow
    {
        public string WorkflowName { get; set; }
        public ICollection<CustomRule> Rules { get; set; }
    }
}
