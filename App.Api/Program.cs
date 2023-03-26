using App.Api.Configuration;
using App.Repository;
using App.Repository.Interfaces;
using MediatR;
using SimpleInjector;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.ConfigureSimpleInjector();
builder.Services.ConfigureDatabase(builder.Configuration);


var app = builder.Build();

app.Services.UseSimpleInjector(SimpleInjectorConfig.container);
SimpleInjectorConfig.container.Verify();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
