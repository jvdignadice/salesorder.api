namespace Domain.Entities
{
    public class Benifits
    {
        public int Id { get; set; }
        public string? BenifitName { get; set; }
        public BenifitType BenifitType { get; set; }
        public string? BenifitDescription { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

    public enum BenifitType
    {
        HealthInsurance = 1,
        RetirementPlan = 2,
        PaidTimeOff = 3,
        WellnessPrograms = 4,
        EmployeeAssistancePrograms = 5,
        FlexibleWorkArrangements = 6,
        ProfessionalDevelopment = 7,
        CommuterBenefits = 8,
        ChildcareSupport = 9,
        StockOptions = 10
    }

    public enum BenifitName
    {
        PhilHelath = 1,
        SSS = 2,
        PagIbig = 3

    }
}
