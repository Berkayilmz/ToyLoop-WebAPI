using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyLoop.Application.Features.Users.DTOs;

namespace ToyLoop.Application.Features.Users.Commands
{
    public class UpdateUserCommand : IRequest<UserDto>
    {
        public long Id { get; set; }
        public UpdateUserDto User { get; set; }
        public UpdateUserCommand(long id, UpdateUserDto user)
        {
            Id = id;
            User = user;
        }
    }
}
