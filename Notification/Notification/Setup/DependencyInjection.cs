using Notification.Service;

namespace Notification.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IGoogleAuthService, GoogleAuthService>();
            services.AddScoped<ISendMailService, SendMailService>();
        }
    }
}
