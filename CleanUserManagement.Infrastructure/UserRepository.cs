using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Dapper;
using CleanUserManagement.Application;
using CleanUserManagement.Domain;

namespace CleanUserManagement.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly DbConnection _connection;

        // Inject the DbConnection dependency
        public UserRepository(DbConnection connection)
        {
            _connection = connection;
        }

        public List<User> GetAllUsers()
        {
            var sql = "SELECT * FROM Users"; // Assuming your table is named Users
            return _connection.Query<User>(sql).ToList();
        }

        public User GetUserByUsername(string username)
        {
            var sql = "SELECT * FROM Users WHERE Username = @Username";
            return _connection.QuerySingleOrDefault<User>(sql, new { Username = username });
        }

        public Guid CreateUser(User user)
        {
            var existingUser = GetUserByUsername(user.Username);
            if (existingUser != null)
            {
                return Guid.Empty;
            }

            var sql = @"INSERT INTO Users (Username, Name, Email, Password, Notes) 
                VALUES (@Username, @Name, @Email, @Password, @Notes)";

            var createdUser = _connection.ExecuteScalar<User>(sql, user);

            return createdUser.id;
        }


        public (User UpdatedUser, string Message) UpdateUser(User user)
        {
            var existingUser = GetUserByUsername(user.Username);
            if (existingUser == null)
            {
                return (null, "User not found.");
            }

            var sql = @"UPDATE Users SET Username = @Username, 
                                           Name = @Name, 
                                           Email = @Email, 
                                           Password = @Password, 
                                           Notes = @Notes 
                        WHERE Id = @Id";
            _connection.Execute(sql, user);

            return (user, "User Updated Successfully!");
        }

        public string DeleteUser(string username)
        {
            var existingUser = GetUserByUsername(username);
            if (existingUser == null)
            {
                return "User not found.";
            }

            var sql = "DELETE FROM Users WHERE Username = @Username";
            _connection.Execute(sql, new { Username = username });

            return "User Deleted Successfully!";
        }
    }
}
