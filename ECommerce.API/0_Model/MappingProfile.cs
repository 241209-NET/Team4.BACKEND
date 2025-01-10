using AutoMapper; 
using ECommerce.API.DTO; 

namespace ECommerce.API.Model;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserInfoDTO>().ReverseMap();
            //.ForMember(s => s.OwnersDTO, c => c.MapFrom(m => m.Owners));

            /*CreateMap<Pet, PetOutDTO>()
            .ForMember(s => s.OwnersDTO, c => c.MapFrom(m => m.Owners));*/

        //CreateMap<Owner, OwnerInDTO>().ReverseMap();
    }
}