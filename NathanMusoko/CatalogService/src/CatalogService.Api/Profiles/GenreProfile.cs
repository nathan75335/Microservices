using AutoMapper;
using CatalogService.BusinessLogic.DTOs;
using CatalogService.DataAccess.Models;

namespace CatalogService.Api.Profiles
{
    /// <summary>
    /// The genre profile for mapping
    /// </summary>
    public class GenreProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of <see cref="GenreProfile"/>
        /// </summary>
        public GenreProfile()
        {
            CreateMap<GenreDto, Genre>()
                .ForMember(dest => dest.Id, source => source.MapFrom(source => source.Id))
                .ForMember(dest => dest.Name, source => source.MapFrom(source => source.Name))
                .ForMember(dest => dest.Descritpion, source => source.MapFrom(source => source.Description))
                .ReverseMap();
        }
    }
}
