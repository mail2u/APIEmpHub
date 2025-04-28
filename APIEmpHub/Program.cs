using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
//Log
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials();
        });
});

//Disable Auto Validate
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// adds an authorization policy to make sure the token is for scope 'api1'

//Policy
builder.Services.AddAuthorization(options =>
{
    //Admin
    options.AddPolicy("User", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireAssertion(context => (context.User.FindFirst(ClaimTypes.Authentication) != null ? context.User.FindFirst(ClaimTypes.Authentication).Value : "").ToLower().Contains("[user]"));
    });

    //Admin
    options.AddPolicy("Admin", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireAssertion(context => (context.User.FindFirst(ClaimTypes.Authentication) != null ? context.User.FindFirst(ClaimTypes.Authentication).Value : "").ToLower().Contains("[admin]"));
    });

    //SuperAdmin
    options.AddPolicy("SuperAdmin", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireAssertion(context => (context.User.FindFirst(ClaimTypes.Authentication) != null ? context.User.FindFirst(ClaimTypes.Authentication).Value : "").ToLower().Contains("[superadmin]"));
    });

    //Function
    options.AddPolicy("Dashboard", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireAssertion(context => (context.User.FindFirst(ClaimTypes.Authentication) != null ? context.User.FindFirst(ClaimTypes.Authentication).Value : "").ToLower().Contains("[dashboard]"));
    });

    options.AddPolicy("Monitor", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireAssertion(context => (context.User.FindFirst(ClaimTypes.Authentication) != null ? context.User.FindFirst(ClaimTypes.Authentication).Value : "").ToLower().Contains("[monitor]"));
    });

    options.AddPolicy("Work", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireAssertion(context => (context.User.FindFirst(ClaimTypes.Authentication) != null ? context.User.FindFirst(ClaimTypes.Authentication).Value : "").ToLower().Contains("[work]"));
    });

    options.AddPolicy("ReportDepartment", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireAssertion(context => (context.User.FindFirst(ClaimTypes.Authentication) != null ? context.User.FindFirst(ClaimTypes.Authentication).Value : "").ToLower().Contains("[reportdepartment]"));
    });

    options.AddPolicy("ReportAll", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireAssertion(context => (context.User.FindFirst(ClaimTypes.Authentication) != null ? context.User.FindFirst(ClaimTypes.Authentication).Value : "").ToLower().Contains("[reportall]"));
    });

    options.AddPolicy("Link", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireAssertion(context => (context.User.FindFirst(ClaimTypes.Authentication) != null ? context.User.FindFirst(ClaimTypes.Authentication).Value : "").ToLower().Contains("[link]"));
    });

    options.AddPolicy("Assign", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireAssertion(context => (context.User.FindFirst(ClaimTypes.Authentication) != null ? context.User.FindFirst(ClaimTypes.Authentication).Value : "").ToLower().Contains("[assign]"));
    });

});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddCookie()
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JwtOptions:Issuer"], // Replace with your issuer
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtOptions:Key"])) // Replace with your secret key
    };
}); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();