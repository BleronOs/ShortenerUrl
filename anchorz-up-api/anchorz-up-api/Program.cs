using AnchorzUp.Api.Configuration;
using AnchorzUp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("AnzchorzUp");

builder.Services.AddDbContext<AnchorzUpContext>(options =>
{
    options.UseNpgsql(connectionString);
});

builder.Services.AddApiServices(builder.Configuration);
builder.Services.AddCoreServices(builder.Configuration);

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

builder.Services.AddCors();

app.UseHttpsRedirection();

// Automatically migrate database, when startapp the application

using (var scope = ((IApplicationBuilder) app).ApplicationServices.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetService<AnchorzUpContext>();

    dbContext?.Database.Migrate();
}

app.UseCors(options =>
{
    options
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .SetIsOriginAllowed(hostName => true);
});

app.UseAuthorization();

app.MapControllers();

app.Run();
