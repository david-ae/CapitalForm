using CapitalForm.Core.Domain.RepositoryContracts;
using CapitalForm.Core.ServiceContracts;
using CapitalForm.Core.Services;
using CapitalForm.Infrastructure.Context;
using CapitalForm.Infrastructure.Repositories;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string Endpoint = builder.Configuration.GetConnectionString("Endpoint") ?? string.Empty;
string key = builder.Configuration.GetConnectionString("Key") ?? string.Empty;
string databaseName = builder.Configuration.GetConnectionString("Database") ?? string.Empty;

builder.Services.AddDbContext<ProgramContext>(options =>
{
    options.UseCosmos(
        accountEndpoint: Endpoint,
        accountKey: key,
        databaseName: databaseName, o => 
        { o.ConnectionMode(ConnectionMode.Gateway); }
        ) ;
});

// Add services
builder.Services.AddControllers();

// Register Program Services
builder.Services.AddScoped<IQuestionTypeService, QuestionTypeService>();

// Register Program Repositories
builder.Services.AddScoped<IQuestionTypeRepository, QuestionTypeRepository>();

var app = builder.Build();

app.MapControllers();

app.Run();
