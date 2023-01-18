using MassTransit;
using Microsoft.AspNetCore.Authentication.Cookies;
using Notification;
using Notification.Setup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.RegisterServices();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<NotificationHandler>();
    x.SetKebabCaseEndpointNameFormatter();


    x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
    {

        cfg.Host("rabbitmq://localhost", h => { });

        cfg.ReceiveEndpoint("mail_queue", ep =>
        {
            ep.PrefetchCount = 10;
            ep.UseMessageRetry(r => r.Interval(2, 100));
            ep.ConfigureConsumer<NotificationHandler>(provider);

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

//Google
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie(options =>
{
    options.LoginPath = "/google-login"; // Must be lowercase
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.Run();
