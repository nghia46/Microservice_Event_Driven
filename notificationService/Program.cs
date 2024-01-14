using MassTransit;
using ProductService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<NotificationServiceConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(new Uri("rabbitmq://guest:guest@localhost:5672"));
        cfg.ReceiveEndpoint("request-queue", c =>
        {
            c.ConfigureConsumer<NotificationServiceConsumer>(context);
        });
    });
});
builder.Services.AddHostedService<MassTransitHostedService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var busControl = app.Services.GetRequiredService<IBusControl>();
await busControl.StartAsync();
// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
