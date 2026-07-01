using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Customers.CustomerCommands;
using OnlineShop.Contracts.RepositoryContracts.Command;
using OnlineShop.Contracts.RepositoryContracts.Command.Common;
using OnlineShop.Infra.Command;
using OnlineShop.Infra.Command.Common;
using OnlineShop.Infra.Query.Common;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Command DbContext
builder.Services.AddDbContext<CommandDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CreateCustomerCommand).Assembly);
});
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IBaseCommandRepository<>), typeof(BaseCommandRepository<>));
// Read DbContext
builder.Services.AddDbContext<QueryDbContext>(options =>
options.UseSqlServer(connectionString));
builder.Services.AddControllers();
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
app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
