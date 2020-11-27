using Microsoft.Extensions.DependencyInjection;
using Customer.Microservice.Repositories.Weather;
using Customer.Microservice.Services.Weather;
using Customer.Microservice.Operations.Weather.MapperProfiles;
using Customer.Microservice.Services.Weather.MapperProfiles;

using Customer.Microservice.Repositories.Customer;
using Customer.Microservice.Services.Customer;
using Customer.Microservice.Operations.Customer.MapperProfiles;
using Customer.Microservice.Services.Customer.MapperProfiles;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Customer.Microservice.Services {


    public class Service{

        private readonly IServiceCollection _services;
        public Service(IServiceCollection services){
            _services = services;
           
        }

        public void addService(){
            _services.TryAddScoped<IWeatherRepository, WeatherRepository>();
            _services.TryAddTransient<IWeatherService, WeatherService>();
            
            _services.TryAddScoped<ICustomerRepository, CustomerRepository>();
            _services.TryAddTransient<ICustomerService, CustomerService>();
          
        }
        

    }

}