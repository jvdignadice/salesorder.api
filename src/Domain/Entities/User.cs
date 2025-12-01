using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? UserPW { get; set; }
        public List<Benifits>? Benefits { get; set; }
        public UserRole? UserRole { get; set; }
        public DateTime? EventTimeStamp { get; set; }
        public string? DepartmentName { get; set; }
        public int? Age { get; set; }

    }
    public enum UserRole
    {
        Admin = 1,
        UserOnly = 2,
        Technician = 3,
    }
}
