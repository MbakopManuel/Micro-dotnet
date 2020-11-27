using AutoMapper;
using Customer.Microservice.Repositories.Customer.DtoModels;
using Customer.Microservice.Services.Customer.DomainModels;

namespace Customer.Microservice.Services.Customer.MapperProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDomainModel, CustomerDtoModel>().ReverseMap();
        }
    }
}
