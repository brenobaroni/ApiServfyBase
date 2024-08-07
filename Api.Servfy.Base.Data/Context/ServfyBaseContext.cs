using Api.Servfy.Base.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace Api.Servfy.Base.Data.Context
{
    public class ServfyBaseContext : DbContext
    {
        private static readonly ILoggerFactory DebugLoggerFactory = new LoggerFactory(new[] { new DebugLoggerProvider() });
        public IHttpContextAccessor? HttpContext { get; }
        private readonly IHostEnvironment? _env;
        private readonly IMemoryCache _cache;

        public ServfyBaseContext(DbContextOptions<ServfyBaseContext> options) : base(options)
        {

        }

        public ServfyBaseContext(DbContextOptions<ServfyBaseContext> options, IHttpContextAccessor? httpContext, IHostEnvironment? env, IMemoryCache memoryCache)
            : base(options)
        {
            HttpContext = httpContext;
            _env = env;
            _cache = memoryCache;
        }

        public DbSet<User> User { get; set; }

    }
}
