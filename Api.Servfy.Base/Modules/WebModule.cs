


using FluentValidation;
using MediatR;
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Api.Servfy.Base.Application.Handlers.User.GetUser.Request;

namespace Api.Servfy.Base.Application.Modules
{
    public static class WebModule
    {
        public static IServiceCollection AddWebModule(this IServiceCollection services)
        {
            //Validations
            services.AddScoped<IValidator<GetUserRequest>, GetUserRequestValidator>();

            return services;
        }

        public static IServiceCollection AddVersioningModule(this IServiceCollection services)
        {

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            });
    //.AddJwtBearer(options =>
    //{
    //    options.Authority = builder.Configuration["Logto:Endpoint"]!;
    //    options.Audience = builder.Configuration["Logto:Audience"]!;
    //});

            services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = false;
                options.ReportApiVersions = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });


            return services;
        }



    }
}
