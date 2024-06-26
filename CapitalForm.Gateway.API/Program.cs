using CapitalForm.Gateway.Core.Http;
using CapitalForm.Gateway.Core.ServiceContracts;
using CapitalForm.Gateway.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<FormHttpClient>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration.GetSection("ServiceUrl:BaseUrl").Value ?? "");
    c.Timeout = new TimeSpan(0, 30, 0);
});

builder.Services.AddScoped<ICapitalFormService, CapitalFormService>();
builder.Services.AddScoped<IQuestionTypeService, QuestionTypeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
