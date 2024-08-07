using Api.Servfy.Base.Application.Handlers.User.GetUser.Response;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Api.Servfy.Base.Application.Handlers.User.GetUser.Request
{
    public class GetUserRequest : IRequest<GetUserResponse>
    {
        public long id { get; set; }
    }

    public class GetUserRequestValidator : AbstractValidator<GetUserRequest>
    {
        public GetUserRequestValidator()
        {
            RuleFor(x => x.id).NotNull().WithMessage("id is required.").NotEqual(0).WithMessage("id not be 0.");
        }
    }
}
