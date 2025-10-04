using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyLoop.Application.Features.Users.Commands;
using ToyLoop.Application.Features.Users.DTOs;
using ToyLoop.Application.Interfaces.Repositories;

namespace ToyLoop.Application.Features.Users.Handlers
{
    public class UpdateUserCommandHandler: IRequestHandler<UpdateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository repository, IMapper mapper)
        {
            _userRepository = repository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
            if (user == null)
                throw new Exception("User Not Found!");

            user.Name = request.User.Name;
            user.Surname = request.User.Surname;
            user.Email = request.User.Email;
            user.Phone = request.User.Phone;
            user.RoleId = request.User.RoleId;
            user.LocationId = request.User.LocationId;

            await _userRepository.UpdateAsync(user, cancellationToken);
            await _userRepository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<UserDto>(user);
        }
    }
}
