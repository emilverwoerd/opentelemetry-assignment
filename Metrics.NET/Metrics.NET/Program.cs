using Metrics.NET.Metrics;
using Metrics.NET.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IComputerComponentsMetrics, ComputerComponentsMetrics>();

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

// Add simulated latency to improve http requests avg. time dashboard
app.UseSimulatedLatency(
    min: TimeSpan.FromMilliseconds(500),
    max: TimeSpan.FromMilliseconds(1000)
);

app.UseAuthorization();
app.MapControllers();
app.Run();
