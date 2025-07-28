using Microsoft.EntityFrameworkCore;
using Pinterest.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PinterestDbContext>(options => {
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});

var app = builder.Build();

app.Run();
