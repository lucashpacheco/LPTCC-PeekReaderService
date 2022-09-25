using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PeekReaderService.Models.Interfaces;
using PeekReaderService.Repository.Repositories;
using PeekReaderService.Service;
using PeekReaderService.Service.Interfaces;

namespace PeekReaderService.API.Config
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services,
                                                                                  IConfiguration configuration)
        {

            services.AddScoped<IConsultHandler, ConsultHandler>();

            services.AddScoped<ICommentsRepository, CommentsRepository>();
            services.AddScoped<ILikesRepository, LikesRepository>();
            services.AddScoped<IPeekRepository, PeekRepository>();

            return services;
        }
    }
}
