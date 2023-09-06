using System;
using CleanUserManagement.Application.Features.Users.Queries.GetUser;
using CleanUserManagement.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CleanUserManagement.Application.Features.Users.Queries;

namespace CleanUserManagement.Application.Features.Users.Mutations.CreateUser
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public Guid id { get; } = new Guid();
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Notes { get; set; }
	}
}

