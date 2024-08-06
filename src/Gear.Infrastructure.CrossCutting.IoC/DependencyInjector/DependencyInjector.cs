using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Gear.Domain.Interfaces;
using Gear.Domain.Interfaces.Generic;
using Gear.Domain.Notifications;
using Gear.Infrastructure.Data.Repository;
using Gear.Infrastructure.Data.Uow;

namespace Gear.Infrastructure.CrossCutting.IoC
{
    public static class DependencyInjector
    {
        public static void RegisterDependencyInjection(IServiceCollection services, IConfiguration configuration)
        {
            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();       

            // Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Notification
            services.AddScoped<NotificationHandler>();

        }
    }
}
