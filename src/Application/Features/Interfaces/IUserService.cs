using Application.Features.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Interfaces
{

    public interface IUserService
    {
        Task<string> Authenticate(AppUserDto dto);
    }

}
