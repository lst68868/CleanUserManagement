using System;
using CleanUserManagement.Application.Features.Users.Queries;
using CleanUserManagement.Domain;
using MediatR;
using FluentValidation;

namespace CleanUserManagement.Application.Features.Users.Mutations.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserService _userService;
        private readonly IValidator<CreateUserCommand> _validator;

        public CreateUserHandler(IUserService userService, IValidator<CreateUserCommand> validator)
        {
            _userService = userService;
            _validator = validator;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Validate incoming request using FluentValidation
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                // You can throw an exception here or handle it however you like.
                // For example:
                throw new ValidationException(validationResult.Errors);
            }

            var newUser = new User
            {
                Email = request.Email,
                Username = request.Username,
                Name = request.Name,
                Notes = request.Notes
                // You'd handle password securely, possibly hashing it, before storing.
            };

            Guid createdUserGuid;

            try
            {
                createdUserGuid = _userService.CreateUser(newUser);
            }
            catch (Exception ex) // Be more specific with exception types if you can.
            {
                // Handle exceptions. This could be logging, transforming the exception, etc.
                throw; // Or handle the exception and return an appropriate result or message.
            }

            return createdUserGuid;
        }
    }
}
