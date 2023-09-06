using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanUserManagement.Application;
using CleanUserManagement.Domain;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using CleanUserManagement.Application.Features.Users.Queries.GetUser;
using CleanUserManagement.Application.Features.Users.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanUserManagement.API.Controllers
{
    [Route("api/user")]
    [ApiController]

    public class UserManagementController : ControllerBase {

        private readonly IUserService _service;
        private readonly IMediator _mediator;

        public UserManagementController(IMediator mediator, IUserService userService)
        {
            _mediator = mediator;
            _service = userService;
        }
        // GET: api/user
        [HttpGet]
        public async Task<ActionResult<List<UserVm>>> GetAllUsers()
        {
            //var usersFromService = _service.GetAllUsers();

            List<UserVm> usersFromMediatr = await _mediator.Send(new GetAllUsersQuery());
            return Ok(usersFromMediatr);
        }

        // GET api/user/{username}
        [HttpGet("{username}")]
        public ActionResult<User> GetUserByUsername(string username)
        {
            //var specificUserFromService = _service.GetUserByUsername(username);
            var specificUserFromService = _mediator.Send(new GetUserByUsernameQuery(username));

            if (specificUserFromService == null)
            {
                return NotFound(); // Return 404 if the user is not found
            }

            return Ok(specificUserFromService);
        }

        //// POST api/user
        [HttpPost]
        public ActionResult<Guid> CreateUser([FromBody] User user)
        {
            // Optionally, validate the user object here.

            var createdUserGuid = _service.CreateUser(user);

            if (createdUserGuid == null)
            {
                return BadRequest("User creation failed.");
            }

            // Return the created user with a 201 Created status code and the success message.
            // You can also add a "Location" header pointing to the new user's URI.
            return Ok($"{createdUserGuid} new user created!");
        }

        //// PUT api/user/username
        [HttpPut("{username}")]
        public IActionResult UpdateUser(string username, [FromBody] User user)
        {
            if (username != user.Username)
            {
                return BadRequest("User username mismatch.");
            }

            var (updatedUser, message) = _service.UpdateUser(user);

            if (updatedUser == null)
            {
                return BadRequest(message); // Return a specific error message from your service.
            }

            return Ok(new { user = updatedUser, message });
        }


        //// DELETE api/user/username
        [HttpDelete("{username}")]
        public IActionResult Delete(string username)
        {
            var result = _service.DeleteUser(username);

            if (string.IsNullOrEmpty(result))
            {
                return NotFound("User not found or another error occurred.");
            }

            return Ok(result); // Returns the success message from the service.
        }

    }
}

