using Api.Servfy.Base.Application.Handlers.User.GetUser.Request;
using Api.Servfy.Base.Application.Handlers.User.GetUser.Response;
using Api.Servfy.Base.Application.Services.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Servfy.Base.Application.Handlers.User.GetUser
{
    internal class GetUserQueryHandler : IRequestHandler<GetUserRequest, GetUserResponse>
    {
        private readonly IUserService _userService;

        public GetUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var user = new Domain.User();

            return new GetUserResponse(200, "",true, user);
        }
    }
}
