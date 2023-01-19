using Base30.SysAdmin.Application.Commands.Menu;
using Base30.SysAdmin.Application.Commands.Menu.Commands;
using Base30.SysAdmin.Application.Setup;
using Base30.SysAdmin.Data;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

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
    x.SetKebabCaseEndpointNameFormatter();
    
    x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
    {

        cfg.Host("rabbitmq://localhost", h =>{ });

        cfg.ReceiveEndpoint("base30_queue", ep =>
        {
            ep.PrefetchCount = 10;
            ep.UseMessageRetry(r => r.Interval(2, 100));
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

//Auth
builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(token =>
    {
        token.RequireHttpsMetadata = false;
        token.SaveToken = true;
        token.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("SymmetricSecurityKey"))
                ),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero,
        };
    })
    ;


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

//Swagger authorization
builder.Services.AddSwaggerGen(c =>
{
    //c.SwaggerDoc("v1", new OpenApiInfo { Title = "apiagenda", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. Enter 'Bearer'[space] and then your token in the text input below. Example: \"Bearer 12345abcdef\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
                });
});

var app = builder.Build();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
