using AutoMapper;
using Customer.Microservice.Operations.Customer.ViewModels;
using Customer.Microservice.Services.Customer.DomainModels;

namespace Customer.Microservice.Operations.Customer.MapperProfiles
{
    public class CustomerResponseProfile : Profile
    {
        public CustomerResponseProfile()
        {
            CreateMap<CustomerViewModel, CustomerDomainModel>().ReverseMap();
        }
    }
}
