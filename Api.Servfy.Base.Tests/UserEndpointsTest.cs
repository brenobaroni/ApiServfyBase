using Api.Servfy.Base.Application.Handlers.User.GetUser.Request;
using Api.Servfy.Base.Application.Services;
using Api.Servfy.Base.Application.Services.Contracts;
using Api.Servfy.Base.Controllers.V1;
using Api.Servfy.Base.Data.Configurations;
using Api.Servfy.Base.Data.Context;
using FluentAssertions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Api.Servfy.Base.Tests
{
    public class UserEndpointsTest
    {
        private ServfyBaseContext _context;

        public UserEndpointsTest() 
        {
            var databaseSettings = DatabaseSettings.Create(GetIConfigurationRoot());
            var builder = new DbContextOptionsBuilder<ServfyBaseContext>();
            builder.UseNpgsql(databaseSettings.ConnectionString, b => b.MigrationsAssembly("Api.Servfy.Base.Migrations"));
            _context = new ServfyBaseContext(builder.Options);
        }

        public static IConfigurationRoot GetIConfigurationRoot()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }

        [Fact]
        public async Task GetUserAsync_Should_Return_User()
        {
            var options = new DbContextOptionsBuilder<ServfyBaseContext>()
            .UseNpgsql()
            .Options;
            
            var userService = new UserService(_context);
            var result = await userService.GetUserAsync(1);

            result.Id.Should().Be(1);
        }
    }
}