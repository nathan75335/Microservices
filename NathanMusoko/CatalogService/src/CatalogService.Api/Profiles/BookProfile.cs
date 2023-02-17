using AutoMapper;
using CatalogService.Api.Request;
using CatalogService.BusinessLogic.DTOs;
using CatalogService.DataAccess.Models;

namespace CatalogService.Api.Profiles
{
    /// <summary>
    /// The book profile for mapping
    /// </summary>
    public class BookProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of <see cref="BookProfile"/>
        /// </summary>
        public BookProfile()
        {
            CreateMap<BookDto, Book>()
                .ForMember(dest => dest.Genres, source => source.MapFrom(source => source.Genres))
                .ForMember(dest => dest.EditionHouse, source => source.MapFrom(source => source.EditionHouse))
                .ForMember(dest => dest.Id, source => source.MapFrom(source => source.Id))
                .ForMember(dest => dest.CreationDate, source => source.MapFrom(source => source.CreationDate))
                .ForMember(dest => dest.Price, source => source.MapFrom(source => source.Price))
                .ForMember(dest => dest.EditionYear, source => source.MapFrom(source => source.EditionYear))
                .ForMember(dest => dest.EditionHouseId, source => source.MapFrom(source => source.EditionHouseId))
                  .ReverseMap();

            CreateMap<BookRequestCreate, BookDto>()
                .ForMember(dest => dest.EditionHouse, source => source.Ignore())
                .ForMember(dest => dest.Author, source => source.MapFrom(source =>source.Author))
                .ForMember(dest => dest.CreationDate, source => source.MapFrom(source => source.CreationDate))
                .ForMember(dest => dest.Price, source => source.MapFrom(source => source.Price))
                .ForMember(dest => dest.EditionYear, source => source.MapFrom(source => source.EditionYear))
                .ForMember(dest => dest.EditionHouseId, source => source.MapFrom(source => source.EditionHouseId))
                .ForMember(dest => dest.Genres, source => source.MapFrom(source => source.Genres))
                .ReverseMap();

            CreateMap<BookRequestUpdate, BookDto>()
                .ForMember(dest => dest.Id, source => source.Ignore())
                .ForMember(dest => dest.EditionHouse, source => source.Ignore())
                .ForMember(dest => dest.Author, source => source.MapFrom(source => source.Author))
                .ForMember(dest => dest.Price, source => source.MapFrom(source => source.Price))
                .ForMember(dest => dest.EditionYear, source => source.MapFrom(source => source.EditionYear))
                .ForMember(dest => dest.EditionHouseId, source => source.MapFrom(source => source.EditionHouseId))
                .ReverseMap();
        }
    }
}
