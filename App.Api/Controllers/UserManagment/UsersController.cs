using Microsoft.AspNetCore.Mvc;
using MediatR;
using App.Library.UserManagment.Queries;
using App.Library.UserManagment.Commands;
using App.Repository.Models;
using App.Library.UserManagment.Dto.Commands;

namespace App.Api.Controllers.UserManagment
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        protected ILogger _logger;

        public UsersController(IMediator mediator, ILogger<UsersController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _mediator.Send(new GetUsersQuery());
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult> AddUser([FromBody] NewUserCommand newUser)
        {
            var command = new AddUserCommand(newUser);
            await _mediator.Send(command);

            return Ok(command.Response);
        }

        [HttpGet("{userId:Guid}")]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            var users = await _mediator.Send(new GetUserByIdQuery(userId));
            return Ok(users);
        }
    }
}
