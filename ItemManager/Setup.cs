using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ItemManager.Data;
using ItemManager.Repositories.LostItemRepository;
using ItemManager.Repositories.FoundItemRepository;
using ItemManager.Services;
using ItemManager.Configuration;
using ItemManager.Repositories;

namespace ItemManager
{
    public static class Setup
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Load AppSettings
            var appSettings = configuration.GetSection("AppSettings").GetConnectionString();
            // Register repositories
            services.AddScoped<ILostItemRepository, LostItemRepository>();
            services.AddScoped<IFoundItemRepository, FoundItemRepository>();

            // Register services
            services.AddScoped<ILostItemService, LostItemService>();
            services.AddScoped<IFoundItemService, FoundItemService>();

        }
    }
}
