using System.Text;
using FirstWebApplication.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using pharmaManagement.Services;
using pharmaManagement.Services.AdminService;
using pharmaManagement.Services.MedicineService;
using pharmaManagement.Services.TokenManager;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IMedicneService, MedicineService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IJWTTokenManager, JWTTokenManager>();


var connectionString = "server=localhost;user=root; password=root@123; database=PharamaDB";
var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
builder.Services.AddDbContext<AppDBContext>(options =>
{
    object value = options.UseMySql(connectionString, serverVersion);
});

//builder.Services.AddDbContext<MedicineDBContext>(options =>
//{

//    options.UseMySql(builder.Configuration.GetConnectionString("Mysqlserver"), new MySqlServerVersion(new Version(8, 0, 28)),
//    options => options.EnableRetryOnFailure());
//});
// Add services to the container.


builder.Services.AddAuthentication(
    options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        var key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
        options.Events = new JwtBearerEvents
        {
            OnChallenge = async context =>
            {
                // Call this to skip the default logic and avoid using the default response
                context.HandleResponse();

                var httpContext = context.HttpContext;
                var statusCode = StatusCodes.Status401Unauthorized;

                var routeData = httpContext.GetRouteData();
                var actionContext = new ActionContext(httpContext, routeData, new ActionDescriptor());

                var factory = httpContext.RequestServices.GetRequiredService<ProblemDetailsFactory>();
                var problemDetails = factory.CreateProblemDetails(httpContext, statusCode);

                var result = new ObjectResult(problemDetails) { StatusCode = statusCode };
                await result.ExecuteResultAsync(actionContext);
            }
        };

    });


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

//app.MapMedicineEndpoints();

app.Run();

