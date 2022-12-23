using Base30.SysAdmin.Application.Setup;
using Base30.SysAdmin.Data;
using MediatR;

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
