using System;
using CleanUserManagement.Application.Features.Users.Queries.GetUser;
using CleanUserManagement.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
namespace CleanUserManagement.Application.Features.Users.Queries
{
    public class GetUserByUsernameHandler : IRequestHandler<GetUserByUsernameQuery, UserVm>
    {
        private readonly IUserService _service;
        public GetUserByUsernameHandler(IUserService service)
        {
            _service = service;
        }

        public Task<UserVm> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            var user = _service.GetUserByUsername(request.Username);
            var userVm = new UserVm
            {
                Email = user.Email,
                Notes = user.Name,
                Username = user.Username,
                Name = user.Name
            };

            return Task.FromResult(userVm);
        }
    }
}

