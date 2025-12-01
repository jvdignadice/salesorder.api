//using Application.Features.Commands;
//using Application.Features.Commands.CreateDepartment;
//using Application.Features.Commands.RemoveDepartment;
//using Application.Features.Commands.UpdateDepartment;
//using Application.Features.DTOs;
//using Application.Features.Queries.GetAllDepartment;
//using Domain.Entities;
//using Microsoft.AspNetCore.Mvc;

//namespace test.api.project.one.Controllers
//{
//    [ApiController]
//    [Route("api/v1/[controller]")]
//    public class DepartmentController : ControllerBase
//    {
//        private readonly MediatR.IMediator _mediator;

//        public DepartmentController(MediatR.IMediator mediator)
//        {
//            _mediator = mediator;
//        }

//        [HttpPost("CreateDepartment")]
//        public async Task<Department> CreateDepartment([FromBody] DepartmentDtos deptDto)
//        {
//            if (deptDto == null)
//                throw new ArgumentNullException(nameof(deptDto));
//            var command = new DepartmentCommand(deptDto);
//            var result = await _mediator.Send(command);
//            return result;
//        }
//        [HttpGet("GetAllDepartment")]
//        public async Task<List<Department>> GetAllDepartment()
//        {
//            var command = new GetAllDepartmentQuery();
//            var result = await _mediator.Send(command);
//            return result;
//        }
//        [HttpPut("UpdateDepartment")]
//        public async Task<Department> UpdateDepartment([FromBody] DepartmentDtos deptDto, Guid ID)
//        {
//            if (deptDto == null)
//                throw new ArgumentNullException(nameof(deptDto));
//            var command = new UpdateDepartmentCommand(deptDto, ID);
//            var result = await _mediator.Send(command);
//            return result;
//        }
//        [HttpDelete("RemoveDepartment")]
//        public async Task<Department> RemoveDepartment(Guid ID)
//        {
//            if (ID == null)
//                throw new ArgumentNullException(nameof(ID));
//            var command = new RemoveDepartmentCommand(ID);
//            var result = await _mediator.Send(command);
//            return result;
//        }
//    }
//}
