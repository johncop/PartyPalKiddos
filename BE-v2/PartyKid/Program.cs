using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using PartyKid;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
var configuration = builder.Configuration;
var provider = builder.Services.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider;

#region Configure Services

services.AddWebApiCore();
services
.AddContextPool(configuration)
.AddJwtConfiguration(configuration)
.AddDefaultExceptionHandlers()
.AddCoreDependencies(provider)
.AddEntityFrameworkRepositories()
.AddServices();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen(options =>
{
    OpenApiSecurityScheme securityDefinition = new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        BearerFormat = "JWT",
        Scheme = "Bearer",
        Description = "Specify the authorization token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
    };
    options.AddSecurityDefinition("Bearer", securityDefinition);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build
        .WithOrigins("*")
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

services.AddAutoMapper(typeof(ConfigMapper));

#endregion

#region Configure
var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {

// }
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandleMiddleware>()
.UseResponseCaching()
.UseMiddleware<TokenHandleMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(x =>
{
    x.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
});

app.MapControllers().RequireCors("corspolicy");
app.Run();
#endregion