using AutoMapper;
using Contact_Information.DTOs;
using Contact_Information.Model;

namespace Contact_Information.Configurations
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {

            CreateMap<Contacts, ContactsDTO>().ReverseMap();
            CreateMap<Countries, CountriesDTO>().ReverseMap();

            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Location, LocationDTO>().ReverseMap();
            CreateMap<User, SaveUserDTO>().ReverseMap();
            CreateMap<User, UpdateUserDTO>().ReverseMap(); 
            //CreateMap<UserLocation, UserLocationDTO>().ReverseMap();
        }
    }
}
