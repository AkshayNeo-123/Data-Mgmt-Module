using DataMgmtModule.Application.Dtos;
using DataMgmtModule.Application.Feactures.Users.Commands.AddUser;
using DataMgmtModule.Application.Feactures.Users.Commands.DeleteUser;
using DataMgmtModule.Application.Feactures.Users.Commands.UpdateUser;
using DataMgmtModule.Application.Feactures.Users.Queries.GetAllUsers;
using DataMgmtModule.Application.Feactures.Users.Queries.GetUserById;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Application.Models;
using DataMgmtModule.Domain.Entities;
using DataMgmtModule.Persistence.Repository;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataMgmtModule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers() => Ok(await _mediator.Send(new GetAllUsersQuery()));
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));
            return user == null ? NotFound() : Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> AddUserAsync(UserDto user)
        {
            var created = await _mediator.Send(new AddUserCommand(user));
            return Ok(created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserDto user)
        {
            var success = await _mediator.Send(new UpdateUserCommand(id, user));
            return success?NoContent():NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _mediator.Send(new DeleteUserCommand(id));
            return success ? NoContent() : NotFound();
        }
    }
}
