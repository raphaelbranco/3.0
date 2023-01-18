using Base30.SysAdmin.Application.Commands.Menu;
using Base30.SysAdmin.Application.Commands.Menu.Commands;
using Base30.SysAdmin.Application.Setup;
using Base30.SysAdmin.Data;
using MassTransit;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddMediatR(typeof(Program));

builder.Services.RegisterServices();

//Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//***
//Conexão BD SQL Server
var connectionString = builder.Configuration.GetConnectionString("SysAdminConnection");
builder.Services.AddSqlServer<SysAdminDBContext>(connectionString);
//***

//*** Mongo DB
builder.Services.Configure<NoSqlSettings>(options =>
{
    options.ConnectionString = builder.Configuration.GetSection("SysAdminNoSqlDatabase:ConnectionString").Value;
    options.Database = builder.Configuration.GetSection("SysAdminNoSqlDatabase:DatabaseName").Value;
});


//*** Mongo DB

//MassTransit
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<MenuCommandHandler>();
    x.SetKebabCaseEndpointNameFormatter();
    

    x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
    {

        cfg.Host("rabbitmq://localhost", h =>{ });

        cfg.ReceiveEndpoint("base30_queue", ep =>
        {
            ep.PrefetchCount = 10;
            ep.UseMessageRetry(r => r.Interval(2, 100));
            ep.ConfigureConsumer<MenuCommandHandler>(provider);
            
        });
    }));
});

builder.Services.AddOptions<MassTransitHostOptions>()
.Configure(options =>
{
    // if specified, waits until the bus is started before
    // returning from IHostedService.StartAsync
    // default is false
    options.WaitUntilStarted = true;

    // if specified, limits the wait time when starting the bus
    options.StartTimeout = TimeSpan.FromSeconds(10);

    // if specified, limits the wait time when stopping the bus
    options.StopTimeout = TimeSpan.FromSeconds(30);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();


var app = builder.Build();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"));

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
