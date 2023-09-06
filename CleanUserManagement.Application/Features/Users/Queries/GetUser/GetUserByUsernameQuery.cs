using System;
using MediatR;

namespace CleanUserManagement.Application.Features.Users.Queries.GetUser
{
	public class GetUserByUsernameQuery : IRequest<UserVm>
    {
		public string Username { get; set; }
		public GetUserByUsernameQuery(string userName)
		{
			this.Username = userName;
		}
	}
}

