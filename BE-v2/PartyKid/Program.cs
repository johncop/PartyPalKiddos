using PartyKid;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
var configuration = builder.Configuration;
var provider = builder.Services.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider;

#region Configure Services

services.AddWebApiCore();
services
.AddCookie()
.AddJwtConfiguration(configuration)
.AddDefaultExceptionHandlers()
.AddCoreDependencies(provider)
.AddContextPool(configuration)
.AddEntityFrameworkRepositories()
.AddServices();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddAutoMapper(typeof(ConfigMapper));

#endregion

#region Configure
var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandleMiddleware>()
.UseHttpsRedirection()
.UseResponseCaching()
.UseMiddleware<TokenHandleMiddleware>()
.UseRouting()
.UseAuthentication()
.UseAuthorization()
.UseEndpoints(enpoints =>
{
    enpoints.MapControllers();
});

app.MapControllers();

app.Run();
#endregion