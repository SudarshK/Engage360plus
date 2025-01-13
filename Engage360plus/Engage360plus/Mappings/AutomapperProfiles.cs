using AutoMapper;
using Engage360plus.Models.Domain;
using Engage360plus.Models.DTO;

namespace Engage360plus.Mappings
{
    public class AutomapperProfiles:Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Addresses,AddressesDto>().ReverseMap();
            CreateMap<AddAddresstoCustomerDto, Addresses>().ReverseMap();
            CreateMap<UpdateAddressDto, Addresses>().ReverseMap();
            CreateMap<AddCustomerRequestDto, CustomerDetails>().ReverseMap();
            CreateMap<CustomerDetails, CustomerDetailsDto>().ReverseMap();
            CreateMap<ProductStatus, ProductStatusDto>().ReverseMap();
            
        }
    }
}
