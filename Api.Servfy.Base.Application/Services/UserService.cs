using Api.Servfy.Base.Application.Services.Contracts;
using Api.Servfy.Base.Data.Context;
using Api.Servfy.Base.Domain;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Api.Servfy.Base.Application.Services
{
    public class UserService : IUserService
    {
        private readonly ServfyBaseContext _context;

        public async Task<User> GetUserAsync(BigInteger id)
        {
            var user = await _context.User.FirstAsync(x => x.Id == id);
            return user;
        }
    }
}
