using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyLoop.Application.Features.Users.DTOs;

namespace ToyLoop.Application.Features.Users.Queries
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public long Id { get; set; }
        public GetUserByIdQuery(long id)
        {
            Id = id;
        }
    }
}
