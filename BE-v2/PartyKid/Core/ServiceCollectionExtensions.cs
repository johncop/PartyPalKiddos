﻿using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace PartyKid;

public static class ServiceCollectionExtensions
{

    #region Configuration API
    public static IMvcBuilder AddWebApiCore(this IServiceCollection services)
    {
        IMvcBuilder mvcBuilder = services.AddRouting(x => x.LowercaseUrls = true)
                                         .AddControllers(ex =>
                                        {
                                            var notJsonOutputFormatters = ex.OutputFormatters.Where(formatter => !(formatter is SystemTextJsonOutputFormatter)).ToArray();
                                            foreach (var formatter in notJsonOutputFormatters)
                                            {
                                                ex.OutputFormatters.Remove(formatter);
                                            }
                                        })
                                         .AddJsonOptions(x =>
                                         {
                                             x.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                                             x.JsonSerializerOptions.AllowTrailingCommas = false;
                                             x.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Disallow;
                                         });
        services.AddResponseCaching()
                .AddHttpContextAccessor();

        return mvcBuilder;
    }

    public static IServiceCollection AddCORS(this IServiceCollection services)
    {
        services.AddCors(p => p.AddPolicy("corspolicy", build =>
        {
            build
            .WithOrigins("*")
            .AllowAnyMethod()
            .AllowAnyHeader();
        }));
        return services;
    }
    #endregion

    #region Configuration Authentication And Authorization
    public static IServiceCollection AddCookie(this IServiceCollection services)
    {
        services.ConfigureApplicationCookie(o =>
        {
            o.ExpireTimeSpan = TimeSpan.FromDays(5);
            o.SlidingExpiration = true;
        });

        services.Configure<DataProtectionTokenProviderOptions>(o =>
        {
            o.TokenLifespan = TimeSpan.FromHours(3);
        });
        return services;
    }

    public static IServiceCollection AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
        IConfigurationSection appSettingsSection = configuration.GetSection("AppSettings");
        services.Configure<AppSettings>(appSettingsSection);

        AppSettings appSettings = appSettingsSection.Get<AppSettings>();
        byte[] key = Encoding.ASCII.GetBytes(appSettings.Secret);

        services
            .AddAuthentication(opt =>
            {
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
            });

        services.AddAuthorization(options =>
        {
            options.AddPolicy(nameof(RoleCollection.Admin), policy => policy.RequireRole(nameof(RoleCollection.Admin)));
            options.AddPolicy(nameof(RoleCollection.User), policy => policy.RequireRole(nameof(RoleCollection.User)));
        });
        return services;
    }
    #endregion

    #region Configuration Application
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserServices, UserServices>();
        services.AddScoped<IEmailServices, EmailServices>();
        services.AddScoped(typeof(IBaseServices<>), typeof(BaseServices<>));
        services.AddScoped(typeof(IExtensionServices<>), typeof(ExtensionServices<>));
        return services;
    }

    public static IServiceCollection AddCoreDependencies(this IServiceCollection services, IServiceProvider provider)
    {
        #region Exception Handling

        if (provider.GetService<IExceptionHandler<FluentValidation.ValidationException, ValidationProblemDetails>>() is null)
        {
            services.AddScoped(typeof(IExceptionHandler<FluentValidation.ValidationException, ValidationProblemDetails>), typeof(ValidationExceptionHandler));
        }

        if (provider.GetService<IExceptionHandler<Exception, ProblemDetails>>() is null)
        {
            services.AddScoped(typeof(IExceptionHandler<Exception, ProblemDetails>), typeof(UnhandledExceptionHandler));
        }

        #endregion
        return services;
    }

    public static IServiceCollection AddDefaultExceptionHandlers(this IServiceCollection services)
    {
        services.AddScoped(typeof(IExceptionHandler<FluentValidation.ValidationException, ProblemDetails>), typeof(ValidationExceptionHandler));
        services.AddScoped(typeof(IExceptionHandler<Exception, ProblemDetails>), typeof(UnhandledExceptionHandler));
        services.AddScoped(typeof(IExceptionHandler<DomainException, ProblemDetails>), typeof(DomainExceptionHandler));
        return services;
    }
    #endregion

    #region Configuration Repository

    public static IServiceCollection AddEntityFrameworkRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
        services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }

    #endregion

    #region Configuration DbContext And Identity
    public static IServiceCollection AddContextPool(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(Assembly.GetExecutingAssembly().GetName().Name);
        services.AddDbContextPool<DbContext, PartyKidDbContext>(options =>
                    options.UseSqlServer(connectionString,
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.CommandTimeout((int)TimeSpan.FromMinutes(2).TotalSeconds);
                        sqlOptions.EnableRetryOnFailure();
                        sqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    }));
        services
        .AddIdentity<ApplicationUser, IdentityRole<int>>(config =>
        {
            config.SignIn.RequireConfirmedEmail = false;
            config.Password.RequiredLength = 8;
        })
        .AddRoles<IdentityRole<int>>()
        .AddEntityFrameworkStores<PartyKidDbContext>()
        .AddDefaultTokenProviders();
        return services;
    }
    #endregion
}
