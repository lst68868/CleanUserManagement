using System;
using CleanUserManagement.Domain;
using System.Collections.Generic;

namespace CleanUserManagement.Application
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetUserByUsername(string username);
        Guid CreateUser(User user);
        (User UpdatedUser, string Message) UpdateUser(User user);
        string DeleteUser(string username);
    }
}
