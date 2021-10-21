using AppFidelidade.Application.Services;
using AppFidelidade.Core.Repositories;
using AppFidelidade.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AppFidelidade.API.Extensions
{
    public static class ServicesExtension
    {
        public static void ServicesInitialization(this IServiceCollection services)
        {
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<IPartnerRepository, PartnerRepository>();
            services.AddTransient<ICardRepository, CardRepository>();

            services.AddTransient<CityService, CityService>();
            services.AddTransient<ClientService, ClientService>();
            services.AddTransient<CountryService, CountryService>();
            services.AddTransient<PartnerService, PartnerService>();
            services.AddTransient<CardService, CardService>();
            services.AddTransient<LoginService, LoginService>();

        }
    }
}