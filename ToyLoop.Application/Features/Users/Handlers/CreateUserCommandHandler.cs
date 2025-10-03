using MediatR;
using ToyLoop.Application.Features.Users.Commands;
using ToyLoop.Application.Interfaces.Repositories;
using ToyLoop.Domain.Entities;

namespace ToyLoop.Application.Features.Users.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, long>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Is email unique?
            var exists = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);
            if(exists != null)
            {
                throw new Exception("Email is already exist!");
            }

            string hashedPassword = hashPassword(request.Password);

            var user = new User
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                PasswordHash = hashedPassword,
                Phone = request.Phone,
                LocationId = request.LocationId,
                RoleId = request.RoleId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _userRepository.AddAsync(user, cancellationToken);
            await _userRepository.SaveChangesAsync(cancellationToken);

            return user.UserId;
        }

        private string hashPassword(string password)
        {
            return password;
        }
    }
}
