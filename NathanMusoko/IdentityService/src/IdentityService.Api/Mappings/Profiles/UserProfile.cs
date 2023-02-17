using AutoMapper;
using IdentityService.Api.Request;
using IdentityService.BusinessLogic.DTOs;
using IdentityService.DataAccess.Models;

namespace IdentityService.Api.Mappings.Profiles
{
    /// <summary>
    /// The profile for mappinng users
    /// </summary>
    public class UserProfile : Profile 
    {
        /// <summary>
        /// initializes a new instance of <see cref="UserProfile"/>
        /// </summary>
        public UserProfile()
        {
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.Id, source => source.MapFrom(source => source.Id))
                .ForMember(dest => dest.Email, source => source.MapFrom(source => source.Email))
                .ForMember(dest => dest.City, source => source.MapFrom(source => source.City))
                .ForMember(dest => dest.PhoneNumber, source => source.MapFrom(source => source.PhoneNumber))
                .ForMember(dest => dest.City, source => source.MapFrom(source => source.City))
                .ForMember(dest => dest.Street, source => source.MapFrom(source => source.Street))
                .ForMember(dest => dest.HouseNumber, source => source.MapFrom(source => source.HouseNumber))
                .ForMember(dest => dest.FirstName, source => source.MapFrom(source => source.FirstName))
                .ForMember(dest => dest.LastName, source => source.MapFrom(source => source.LastName))
                .ForMember(dest => dest.UserName, source => source.MapFrom(source => source.UserName))
                .ReverseMap();

            CreateMap<UserDto, UserRequestCreate>()
                .ForMember(dest => dest.UserName, source => source.MapFrom(source => source.UserName))
                .ForMember(dest => dest.Email, source => source.MapFrom(source => source.Email))
                .ForMember(dest => dest.City, source => source.MapFrom(source => source.City))
                .ForMember(dest => dest.PhoneNumber, source => source.MapFrom(source => source.PhoneNumber))
                .ForMember(dest => dest.City, source => source.MapFrom(source => source.City))
                .ForMember(dest => dest.Street, source => source.MapFrom(source => source.Street))
                .ForMember(dest => dest.HouseNumber, source => source.MapFrom(source => source.HouseNumber))
                .ForMember(dest => dest.FirstName, source => source.MapFrom(source => source.FirstName))
                .ForMember(dest => dest.LastName, source => source.MapFrom(source => source.LastName))
                .ReverseMap();

            CreateMap<UserDto, UserRequestUpdate>()
                .ForMember(dest => dest.UserName, source => source.MapFrom(source => source.UserName))
                .ForMember(dest => dest.Email, source => source.MapFrom(source => source.Email))
                .ForMember(dest => dest.City, source => source.MapFrom(source => source.City))
                .ForMember(dest => dest.PhoneNumber, source => source.MapFrom(source => source.PhoneNumber))
                .ForMember(dest => dest.City, source => source.MapFrom(source => source.City))
                .ForMember(dest => dest.Street, source => source.MapFrom(source => source.Street))
                .ForMember(dest => dest.HouseNumber, source => source.MapFrom(source => source.HouseNumber))
                .ForMember(dest => dest.FirstName, source => source.MapFrom(source => source.FirstName))
                .ForMember(dest => dest.LastName, source => source.MapFrom(source => source.LastName))
                .ReverseMap();

            CreateMap<UserDto, UserRequestLogin>()
                .ForMember(dest => dest.Email, source => source.MapFrom(source => source.Email))
                .ReverseMap();
        }
    }
}
