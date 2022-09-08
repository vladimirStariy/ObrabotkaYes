using ObrabotkaYes.DataAcessLayer.Interfaces;
using ObrabotkaYes.DataAcessLayer.Repositories;
using ObrabotkaYes.Domain.Entity;
using ObrabotkaYes.Service.Implementations;
using ObrabotkaYes.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ObrabotkaYes
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<User>, UserRepository>();
            services.AddScoped<IBaseRepository<Profile>, ProfileRepository>();
            services.AddScoped<IBaseRepository<OrderPicture>, OrderPictureRepository>();
            services.AddScoped<IBaseRepository<Order>, OrderRepository>();
            
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            //services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProfileService, ProfileService>();
            
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}
