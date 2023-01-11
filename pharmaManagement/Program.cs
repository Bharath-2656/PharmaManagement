using System.Text;
using FirstWebApplication.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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

