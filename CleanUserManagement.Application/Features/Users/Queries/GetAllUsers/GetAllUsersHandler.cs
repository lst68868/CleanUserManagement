using System;
using CleanUserManagement.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CleanUserManagement.Application.Features.Users.Queries.GetUser;

namespace CleanUserManagement.Application.Features.Users.Queries
{
	public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<UserVm>>
    {
		private readonly IUserService _service;
		public GetAllUsersHandler(IUserService service) 
		{
			_service = service;
		}

		public Task<List<UserVm>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
		{
			var users = _service.GetAllUsers();
			var userVmList = users.Select(user => new UserVm
			{
				Email = user.Email,
				Username = user.Username,
				Name = user.Name,
				Notes = user.Notes
			}).ToList();

			return Task.FromResult(userVmList);
		}
	}
}

