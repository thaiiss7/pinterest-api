using Microsoft.EntityFrameworkCore;
using Pinterest.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PinterestDbContext>(options => {
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});

builder.Services.AddTransient<IPasswordService, PBKDF2PasswordService>();
builder.Services.AddTransient<IProfilesService, EFProfileService>();
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

var app = builder.Build();

app.ConfigureAuthEndpoints();
app.ConfigureFolderEndpoints();
app.ConfigurePinEndpoints();
app.ConfigureProfileEndpoints();

app.Run();
