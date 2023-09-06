using System;
using CleanUserManagement.Domain;
using System.Collections.Generic;

namespace CleanUserManagement.Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User GetUserByUsername(string username)
        {
            // Depending on your needs, you might add additional logic or validation here.
            return _userRepository.GetUserByUsername(username);
        }

        public Guid CreateUser(User user)
        {
            // Add any business logic or validation for creating a user.
            // For example, check if the user with the same username already exists.

            var createdUserGuid = _userRepository.CreateUser(user);

            // Return the created user.
            // If you're using a database that generates IDs (e.g., auto-increment),
            // you might want to fetch the created user again to get the ID.
            return createdUserGuid;
        }

        public (User UpdatedUser, string Message) UpdateUser(User user)
        {
            // Add any business logic or validation for updating a user.
            _userRepository.UpdateUser(user);

            return (user, "User Updated Successfully!");

        }

        public string DeleteUser(string username)
        {
            // Add any business logic or validation for deleting a user.
            _userRepository.DeleteUser(username);
            // Return a relevant message. Adjust as per your logic.
            return "User Deleted Successfully!";
        }
    }
}
