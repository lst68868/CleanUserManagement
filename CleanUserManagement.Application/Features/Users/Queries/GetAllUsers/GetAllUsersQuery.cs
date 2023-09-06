using System;
using CleanUserManagement.Domain;
using MediatR;
namespace CleanUserManagement.Application.Features.Users.Queries.GetUser
{
	public class GetAllUsersQuery : IRequest<List<UserVm>>
    {

	}
}

