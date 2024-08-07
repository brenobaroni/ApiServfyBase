using Api.Servfy.Base.Application.Handlers.BaseResponse;
using Api.Servfy.Base.Domain;

namespace Api.Servfy.Base.Application.Handlers.User.GetUser.Response
{
    public class GetUserResponse : BaseRestResponse<UserModel>
    {
        public GetUserResponse(int httpStatus, string message, bool success, Domain.User user) : base(httpStatus, message, success)
        {
            this.data = user;
        }
    }


    public class UserModel
    {
        public long Id { get; set; }

        public string Email { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Idpid { get; set; } = null!;

        public string PersonalIdNumber { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime? EditedAt { get; set; }

        public bool Active { get; set; }

        public string ContactNumber { get; set; } = null!;

        public string ContactNumberSecondary { get; set; } = null!;

        public string? Avatar { get; set; }

        public static implicit operator UserModel(Domain.User user)
        {
            return new UserModel()
            {
                Id = user.Id,
                Active = user.Active,
                ContactNumber = user.ContactNumber,
                ContactNumberSecondary = user.ContactNumberSecondary,
                Avatar = user.Avatar,
                Email = user.Email,
                Name = user.Name,
                Idpid = user.Idpid,
                PersonalIdNumber = user.Idpid,
                CreatedAt = user.CreatedAt,
                EditedAt = user.EditedAt,
            };
        }
    }
}
