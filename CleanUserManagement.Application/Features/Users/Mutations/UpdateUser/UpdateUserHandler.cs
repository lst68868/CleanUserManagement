//using CleanUserManagement.Application.Features.Users.Queries;
//using CleanUserManagement.Domain; // Assuming User entity is defined here.
//using MediatR;
//using System.Threading;
//using System.Threading.Tasks;

//namespace CleanUserManagement.Application.Features.Users.Mutations.UpdateUser
//{
//    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserVm>
//    {
//        private readonly IUserService _userService;  // Assuming you have some service to interact with your data store.

//        public UpdateUserHandler(IUserService userService)
//        {
//            _userService = userService;
//        }

//        public async Task<UserVm> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
//        {
//            // Retrieve the user.
//            var user = await _userService.GetUserByUsername();
//            if (user == null)
//            {
//                throw new ArgumentException($"User with ID {request.Username} not found.");
//            }

//            // Update the user's properties. 
//            // Only update if the properties have values (this avoids overwriting with null).
//            user.Username = request.Username ?? user.Username;
//            user.Name = request.Name ?? user.Name;
//            user.Email = request.Email ?? user.Email;
//            // Consider hashing the password if it's changed.
//            if (!string.IsNullOrEmpty(request.Password))
//            {
//                user.Password = request.Password; // Ideally you'd hash and salt this, not store as plain text!
//            }
//            user.Notes = request.Notes ?? user.Notes;

//            // Save the changes.
//            await _userService.UpdateUser(user);

//            // Convert to UserVm to return.
//            return new UserVm
//            {
//                Username = user.Username,
//                Name = user.Name,
//                Email = user.Email,
//                Notes = user.Notes
//                // Any other fields you want to include.
//            };
//        }
//    }
//}
