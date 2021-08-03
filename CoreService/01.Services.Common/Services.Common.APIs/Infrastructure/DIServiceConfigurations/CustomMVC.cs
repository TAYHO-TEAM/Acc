using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services.Common.APIs.Cmd.EF;
using Services.Common.APIs.Infrastructure.Configuration;
using Services.Common.APIs.Infrastructure.Filters;
using Services.Common.DomainObjects;
using Services.Common.Options;
using Services.Common.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.APIs.Infrastructure.DIServiceConfigurations
{
    public static class CustomMvc
    {
        public static IServiceCollection AddCustomMvc(this IServiceCollection services, IConfiguration configuration, Action<ApiVersioningOptions> apiVersionOptions = null, List<SwaggerDocModel> swaggerDocModels = null)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            var entryAssembly = Assembly.GetEntryAssembly();
            var xmlFile = $"{entryAssembly.GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            services
                .AddCustomConfiguration(configuration)
                .AddOptionsBuilder(configuration)
                .AddHttpContextAccessor()
                .AddCustomApiVersion(apiVersionOptions)
                .AddCustomController()
                .AddCustomSwagger(xmlPath, swaggerDocModels)
                .AddCustomCors()
                .AddMediatR(executingAssembly, entryAssembly)
                .AddAutoMapper(executingAssembly, entryAssembly)
                .AddRedisCache()
                .AddCustomJwtAuthentication()
                .AddHttpClient();
                //.AddCustomHealthCheck();

            return services;
        }

        public static IServiceCollection AddCustomController(this IServiceCollection services)
        {
            services.AddControllers();
            return services;
        }

        public static IServiceCollection AddCustomApiVersion(this IServiceCollection services, Action<ApiVersioningOptions> apiVersionOptions)
        {
            if (apiVersionOptions == null)
            {
                apiVersionOptions = opt =>
                {
                    opt.ReportApiVersions = true;
                    opt.AssumeDefaultVersionWhenUnspecified = true;
                    opt.DefaultApiVersion = new ApiVersion(1, 0);
                };
            }
            services.AddApiVersioning(apiVersionOptions);
            return services;
        }

        public static IServiceCollection AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                        //.WithExposedHeaders("Content-Disposition");
                });
            });
            return services;
        }

        public static IServiceCollection AddCustomSwagger(this IServiceCollection services, string xmlPath, List<SwaggerDocModel> swaggerDocModels)
        {
            services.AddSwaggerGen(c =>
            {
                if (swaggerDocModels != null && swaggerDocModels.Any())
                {
                    foreach (var swaggerDocModel in swaggerDocModels)
                    {
                        c.SwaggerDoc(swaggerDocModel.Name, swaggerDocModel.OpenApiInfo);
                    }
                }
                //c.ResolveConflictingActions(a => a.First());
                //c.OperationFilter<RemoveVersionParameterFilter>();
                //c.DocumentFilter<ReplaceVersionWithExactValueInPathFilter>();
                //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    Type = SecuritySchemeType.OAuth2,
                //    Flows = new OpenApiOAuthFlows
                //    {
                //        Implicit = new OpenApiOAuthFlow
                //        {
                //            AuthorizationUrl = new Uri("http://localhost:5002/connect/authorize"),
                //            Scopes = new Dictionary<string, string>
                //            {
                //                {"api1", "Demo API - full access"}
                //            }
                //        }
                //    }
                //});
                //c.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                //        },
                //        new List<string>{ "api1" }
                //    }
                //});
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
                c.IncludeXmlComments(xmlPath);
            });
            return services;
        }

        public static IServiceCollection AddCustomJwtAuthentication(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var optionsBuilder = serviceProvider.GetService<IOptionsBuilder>();
            var jwtOptions = optionsBuilder.ReadJwtOptionsSettings();
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.SecretKey));
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ClockSkew = TimeSpan.Zero,

                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Audience,
                        IssuerSigningKey = signingKey
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnChallenge = context =>
                        {
                            context.Response.OnStarting(async () =>
                            {
                                if (context.AuthenticateFailure != null)
                                {
                                    var invalidToken = "";
                                    if (context.Request.Headers.ContainsKey("Authorization") && context.Request.Headers["Authorization"][0].StartsWith("Bearer "))
                                    {
                                        invalidToken = context.Request.Headers["Authorization"][0].Substring("Bearer ".Length);
                                    }
                                    context.Response.Clear();
                                    context.Response.ContentType = "application/json";
                                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                                    var methodResult = new MethodResult<bool> { Result = false };
                                    if (context.AuthenticateFailure.GetType() == typeof(SecurityTokenExpiredException))
                                    {
                                        context.Response.Headers.Add("Token-Expired", "true");
                                        methodResult.AddErrorMessage(CommonErrors.APITokenExpired, new[]
                                        {
                                            ErrorHelpers.GenerateErrorResult(nameof(invalidToken),invalidToken)
                                        });
                                        await context.Response.WriteAsync(methodResult.ToJsonString()).ConfigureAwait(false);
                                    }
                                    if (context.AuthenticateFailure.GetType() == typeof(SecurityTokenInvalidAudienceException)) { } //
                                    if (context.AuthenticateFailure.GetType() == typeof(Exception))
                                    {
                                        methodResult.AddErrorMessage(CommonErrors.APITokenInValid, new[]
                                        {
                                            ErrorHelpers.GenerateErrorResult(nameof(invalidToken),invalidToken)
                                        });
                                        await context.Response.WriteAsync(methodResult.ToJsonString()).ConfigureAwait(false);
                                    }
                                }
                            });
                            return Task.CompletedTask;
                        }
                    };
                });
            return services;
        }

        public static IServiceCollection AddOptionsBuilder(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ProfileMailOptions>(configuration.GetSection("ProfileMailOptions"));
            services.Configure<MediaOptions>(configuration.GetSection("MediaConfig"));
            services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));
            services.Configure<SQLServerOptions>(configuration.GetSection("SQLServerOptions"));
            services.Configure<RedisServerOptions>(configuration.GetSection("RedisServerOptions"));
            //services.Configure<FormOptions>(x =>
            //{
            //    x.ValueLengthLimit = 5000; // Limit on individual form values
            //    x.MultipartBodyLengthLimit = 737280000; // Limit on form body size
            //    x.MultipartHeadersLengthLimit = 737280000; // Limit on form header size
            //});
            //services.Configure<IISServerOptions>(options =>
            //{
            //    options.MaxRequestBodySize = 837280000; // Limit on request body size
            //});
            services.AddSingleton<IOptionsBuilder, OptionsBuilder>();
            return services;
        }

        public static IServiceCollection AddRedisCache(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var optionsBuilder = serviceProvider.GetService<IOptionsBuilder>();
            RedisServerOptions redisServerOptions = optionsBuilder.ReadRedisServerOptionsSettings();
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = redisServerOptions.Host;
            });
            return services;
        }

        public static IServiceCollection AddCustomHealthCheck(this IServiceCollection services)
        {
            #region Get Options

            var serviceProvider = services.BuildServiceProvider();
            var optionsBuilder = serviceProvider.GetService<IOptionsBuilder>();
            SQLServerOptions sqlServerOptions = optionsBuilder.ReadSqlServerOptionsSettings();
            RedisServerOptions redisServerOptions = optionsBuilder.ReadRedisServerOptionsSettings();

            #endregion Get Options

            #region Add HealthCheck provider

            var hcBuilder = services.AddHealthChecks();
            hcBuilder.AddCheck("self", () => HealthCheckResult.Healthy(), tags: new[] { "self" });
            if (!string.IsNullOrEmpty(sqlServerOptions.ConnectionStrings))
            {
                hcBuilder.AddSqlServer(connectionString: sqlServerOptions.ConnectionStrings, name: "SqlServerDb-Check", tags: new[] { "sql" });
            }
            if (!string.IsNullOrEmpty(redisServerOptions.Host))
            {
                hcBuilder.AddRedis(redisConnectionString: redisServerOptions.Host, name: "RedisCacheDb-Check", tags: new[] { "redisCache" });
            }

            #endregion Add HealthCheck provider

            return services;
        }
        private static IServiceCollection AddCustomConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));
            services.AddSingleton<IConfigurationReader, ConfigurationReader>();
            return services;
        }
    }
}