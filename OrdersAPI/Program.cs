using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrdersAPI.Consumer;
using OrdersAPI.Data;
using MassTransit;
using RabbitMQ;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<OrdersAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OrdersAPIContext") ?? throw new InvalidOperationException("Connection string 'OrdersAPIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(
    x =>
    {
        x.AddConsumer<ProductCreatedConsumer>();
        x.UsingRabbitMq((context, cfg)
            =>
        {
            cfg.Host(new Uri("rabbitmq://localhost:4001"),
              h =>
              {
                  h.Username("guest");
                  h.Password("guest");
              });
            cfg.ReceiveEndpoint("event-listener",
                e =>
                {
                    e.ConfigureConsumer<ProductCreatedConsumer>(context);
                });
        });
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
