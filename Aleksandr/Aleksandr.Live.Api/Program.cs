using Aleksandr.Live.Api.Services;
using Aleksandr.Live.Api.Services.Interfaces.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddSingleton<AccountService>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(InMemRepository<>));

//builder.Services.AddScoped<AccountService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapControllers();

app.Run();





