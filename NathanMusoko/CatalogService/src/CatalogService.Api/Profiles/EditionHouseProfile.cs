using AutoMapper;
using CatalogService.Api.Request;
using CatalogService.BusinessLogic.DTOs;
using CatalogService.DataAccess.Models;

namespace CatalogService.Api.Profiles
{
    /// <summary>
    /// The edition profile for mapping
    /// </summary>
    public class EditionHouseProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of <see cref="EditionHouseProfile"/>
        /// </summary>
        public EditionHouseProfile()
        {
            CreateMap<EditionHouseDto, EditionHouse>()
                .ForMember(dest => dest.Id, source => source.MapFrom(source => source.Id))
                .ForMember(dest => dest.Name, source => source.MapFrom(source => source.Name))
                .ForMember(dest => dest.City, source => source.MapFrom(source => source.City))
                .ForMember(dest => dest.Street, source => source.MapFrom(source => source.Street))
                .ForMember(dest => dest.HouseNumber, source => source.MapFrom(source => source.HouseNumber))
                .ReverseMap();

            CreateMap<EditionRequest, EditionHouseDto>()
               .ForMember(dest => dest.Id, source => source.Ignore())
               .ForMember(dest => dest.Name, source => source.MapFrom(source => source.Name))
               .ForMember(dest => dest.City, source => source.MapFrom(source => source.City))
               .ForMember(dest => dest.Street, source => source.MapFrom(source => source.Street))
               .ForMember(dest => dest.HouseNumber, source => source.MapFrom(source => source.HouseNumber))
               .ReverseMap();
        }
    }
}
