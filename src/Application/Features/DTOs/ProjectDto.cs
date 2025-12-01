namespace Application.Features.DTOs
{
    public class ProjectDto
    {
        public string? ProjectName { get; set; }
        public string? ProjectDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
