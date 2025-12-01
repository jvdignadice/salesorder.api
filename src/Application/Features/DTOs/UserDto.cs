using Domain.Entities;

namespace Application.Features.DTOs
{


    public class UserDto
    {
     
            public string? Email { get; set; }
            public string? UserName { get; set; }
            public string? UserPW { get; set; }
            public List<Benifits> Benifits { get; set; }
            public UserRole? UserRole { get; set; }
            public DateTime? EventTimeStamp { get; set; }
            public string? DepartmentName { get; set; }
            public int? Age { get; set; }

    }
}
