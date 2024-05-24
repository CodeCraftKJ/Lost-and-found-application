using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ItemManager.Data;
using ItemManager.Repositories.LostItemRepository;
using ItemManager.Repositories.FoundItemRepository;
using ItemManager.Configuration;
using ItemManager.Services;
using ItemManager.Repositories;

namespace ItemManager
{
    public static class Setup
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var defaultConnection = configuration.GetSection("AppSettings:DefaultConnection").Value;

            services.AddSingleton(new DBContext(defaultConnection));

            services.AddScoped<ILostItemRepository, LostItemRepository>();
            services.AddScoped<IFoundItemRepository, FoundItemRepository>();

            services.AddScoped<ILostItemService, LostItemService>();
            services.AddScoped<IFoundItemService, FoundItemService>();
        }
    }
}
