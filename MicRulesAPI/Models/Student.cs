namespace MicRulesAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal AmountToPay { get; set; }

        public int Payments { get; set; }

        public decimal Interests { get; set; }
    }
}
