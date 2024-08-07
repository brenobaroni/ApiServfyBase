using Api.Servfy.Base.Data.Modules;
using Api.Servfy.Base.Extensions.Configurations;
using Api.Servfy.Base.Middleware;
using Api.Servfy.Base.Application;
using Asp.Versioning.ApiExplorer;
using Api.Servfy.Base.Application.Modules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins(builder.Configuration.GetValue<string[]>("Cors") ?? [])
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// DependenciesModules
builder.Services.AddWebModule();
builder.Services.AddInfrastructureModule(builder.Configuration);
builder.Services.AddApplicationServicesModule();
builder.Services.AddVersioningModule();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }

    });
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.UseErrorMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
