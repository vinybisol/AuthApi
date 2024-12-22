using Api.Endpoints;
using Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddOpenApi()
    .AddEndpointValidators();

Infrastructure.Extensions.ServiceExtensions.AddDBContexts(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseExceptionHandler("/oops");
    app.MapOpenApi();
}
app.Logger.LogInformation("The app started at {Time}", DateTime.UtcNow);

LoginEndpoints.Map(app);

app.Run();

//Para os testes de integração
public partial class Program { }