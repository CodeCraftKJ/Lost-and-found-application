using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ItemManager.Data;
using ItemManager.Repositories.LostItemRepository;
using ItemManager.Repositories.FoundItemRepository;
using ItemManager.Services;
using ItemManager.Mapping;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace ItemManager
{
    public static class Setup
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var defaultConnection = configuration.GetSection("AppSettings:DefaultConnection").Value;

            services.AddDbContext<DBContext>(options =>
                options.UseSqlServer(defaultConnection));

            services.AddScoped<ILostItemRepository, LostItemRepository>();
            services.AddScoped<IFoundItemRepository, FoundItemRepository>();

            services.AddScoped<ILostItemService, LostItemService>();
            services.AddScoped<IFoundItemService, FoundItemService>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllers();
        }
    }
}
