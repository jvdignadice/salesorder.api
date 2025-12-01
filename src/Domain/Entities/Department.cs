namespace Domain.Entities
{
    public class Department
    {
        public Guid DepartmentId { get; set; }
        public int FloorNumber { get; set; }
        public string? DepartmentName { get; set; }
        public string? DepartmentDescription { get; set; }
    }
}
