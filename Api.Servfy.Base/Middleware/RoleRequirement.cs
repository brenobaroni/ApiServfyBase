using Microsoft.AspNetCore.Authorization;

namespace Api.Servfy.Base.Middleware
{
    public class RoleRequirement : IAuthorizationRequirement
    {
        public IReadOnlyList<string> Roles { get; set; }

        public RoleRequirement(IEnumerable<string> roles)
        {
            Roles = roles.ToList() ?? new List<string>();
        }
    }
}
