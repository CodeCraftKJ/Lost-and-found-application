using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ItemManager.Data;
using ItemManager.Repositories.LostItemRepository;
using ItemManager.Repositories.FoundItemRepository;
using ItemManager.Configuration;
using ItemManager.Repositories;
using ItemManager.Services;

namespace ItemManager
{
    public static class Setup
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Load AppSettings
            var appSettings = configuration.GetSection("AppSettings").Get<AppSettings>();

            // Configure the database context
            services.AddDbContext<DBContext>(options =>
                options.UseSqlServer(appSettings.DefaultConnection));

            // Register repositories
            services.AddScoped<ILostItemRepository, LostItemRepository>();
            services.AddScoped<IFoundItemRepository, FoundItemRepository>();

            // Register services
            services.AddScoped<ILostItemService, LostItemService>();
            services.AddScoped<IFoundItemService, FoundItemService>();

            // Add other services and configurations as needed
            services.AddControllers();
        }
    }
}
