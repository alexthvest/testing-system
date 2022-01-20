using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using TestingSystem.Application;
using TestingSystem.Infrastructure;
using TestingSystem.Web.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.ConfigureServices(services =>
{
    services.AddCors();
    
    services.AddApplication();
    services.AddInfrastructure(builder.Configuration);
    
    services.AddControllers(options =>
    {
        options.Filters.Add<FailureResultFilter>();
    });

    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("r5i43po5if09ai3jtoiduafoi"))
            };
        });
});

// Application
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors(c => c.AllowAnyOrigin());
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
