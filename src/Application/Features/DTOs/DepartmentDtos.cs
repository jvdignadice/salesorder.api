namespace Application.Features.DTOs
{
    public class DepartmentDtos
    {
        public Guid UserId { get; set; }
        public string? DepartmentName { get; set; }
        public string? DepartmentDescription { get; set; }
        public int FloorNumber { get; set; }
    }
}
