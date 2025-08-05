using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Pinterest.Endpoints;
using Pinterest.EndPoints;
using Pinterest.Models;
using Pinterest.Services.JWT;
using Pinterest.Services.Password;
using Pinterest.Services.Profiles;
using Pinterest.UseCases.CreateFolder;
using Pinterest.UseCases.CreateProfile;
using Pinterest.UseCases.DeletePin;
using Pinterest.UseCases.DeleteProfile;
using Pinterest.UseCases.GetFolderData;
using Pinterest.UseCases.GetPinData;
using Pinterest.UseCases.GetProfileData;
using Pinterest.UseCases.Login;
using Pinterest.UseCases.PostPin;
using Pinterest.UseCases.SavePin;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PinterestDbContext>(options => {
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});

builder.Services.AddTransient<IPasswordService, PBKDF2PasswordService>();
builder.Services.AddTransient<IProfileService, EFProfileService>();
builder.Services.AddSingleton<IJWTService, JWTService>();

builder.Services.AddTransient<CreateFolderUseCase>();
builder.Services.AddTransient<LoginUseCase>();
builder.Services.AddTransient<DeletePinUseCase>();
builder.Services.AddTransient<CreateProfileUseCase>();
builder.Services.AddTransient<PostPinUseCase>();
builder.Services.AddTransient<GetProfileDataUseCase>();
builder.Services.AddTransient<GetPinDataUseCase>();
builder.Services.AddTransient<GetFolderDataUseCase>();
builder.Services.AddTransient<SavePinUseCase>();
builder.Services.AddTransient<DeleteProfileUseCase>();

var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET");
var keyBytes = Encoding.UTF8.GetBytes(jwtSecret);
var key = new SymmetricSecurityKey(keyBytes);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidIssuer = "pinterest-app",
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = key,
        };
    });

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.ConfigureAuthEndpoints();
app.ConfigureFolderEndpoints();
app.ConfigurePinEndpoints();
app.ConfigureProfileEndpoints();

app.Run();
