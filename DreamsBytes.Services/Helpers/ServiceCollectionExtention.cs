using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsBytes.Services.Helpers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceLayerServices(this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<IStoreService, StoreService>();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
