using Application.Features.Commands.RemovePizza;
using Application.Features.Commands.UpdatePizza;
using Application.Features.DTOs;
using Application.Features.Extensions;
using Application.Features.Interfaces;
using Application.Features.Interfaces.Kafka;
using Application.Features.Middleware;
using Application.Features.Queries.GetAllPizza;
using Infrastructure.DependencyInjection;
using Infrastructure.Messaging;
using Infrastructure.Persistence;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;


var builder = WebApplication.CreateBuilder(args);
var db = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine("database: ", db);


builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>(); // Ensure UnitOfWork is a class, not a namespace


builder.Services.AddScoped<ICsvImporterService, CsvImporterService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddAuthenticationAndAuthorization(builder.Configuration);
builder.Services.AddSingleton<IKafkaProducer, KafkaProducer>();

builder.Services.AddHostedService<KafkaBackgroundConsumer>();
builder.Services.AddAuthorization();
builder.Services.AddSingleton<IKafkaProducer, KafkaProducer>();
builder.Services.AddSingleton<IKafkaConsumer, KafkaConsumer>();
builder.Services.AddDbContext<TestAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

#region FOR KAFKA TESTING

//app.MapPost("/orders", async (IKafkaProducer producer, [FromBody] OrderDto orderDto) =>
//{
//    // 1. Validate/order logic
//    var order = new OrderDto(orderDto.OrderId, orderDto.Name, orderDto.Description);
//    await producer.ProduceAsync("orders", JsonSerializer.Serialize(order));

//    return Results.Created($"/orders/{order.OrderId}", order);
//});


//app.MapGet("/produce", async (IKafkaProducer producer) =>
//{
//    await producer.ProduceAsync("test-topic", "Hello from API!");
//    return Results.Ok("Message sent!");
//});


//app.MapGet("/consume", (IKafkaConsumer consumer) =>
//{
//    consumer.Consume("test-topic", (message, offset) =>
//    {
//        Console.WriteLine("📩 Received: {Message} @ {Offset}", message, offset);
//    });
//    return Results.Ok("Listening...");
//});
#endregion 
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUI();
}
app.UseMiddleware<UseGlobalExceptionHandler>();
app.AddCustomRateLimiting(100, TimeSpan.FromMinutes(1));
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
