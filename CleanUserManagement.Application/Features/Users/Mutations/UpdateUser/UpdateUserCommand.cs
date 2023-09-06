using CleanUserManagement.Application.Features.Users.Queries;
using MediatR;

namespace CleanUserManagement.Application.Features.Users.Mutations.UpdateUser
{
    public class UpdateUserCommand : IRequest<UserVm>
    {
        public Guid UserId { get; set; }  // Assuming you're using Guids as IDs.
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }  // Consider if you actually want to update the password here.
        public string Notes { get; set; }
    }
}
