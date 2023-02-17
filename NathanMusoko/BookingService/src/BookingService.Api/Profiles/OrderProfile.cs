using AutoMapper;
using BookingService.Api.Requests;
using BookingService.BusinessLogic.DTO_s;
using BookingService.DataAccess.Models;

namespace BookingService.Api.Profiles
{
    /// <summary>
    /// Configutation of the mapping profile order
    /// </summary>
    public class OrderProfile : Profile
    {
        /// <summary>
        /// Initialzies a new instance of <see cref="OrderProfile"/>
        /// </summary>
        public OrderProfile()
        {
            CreateMap<OrderDto, Order>()
                .ForMember(dest => dest.Id, source => source.MapFrom(source => source.Id))
                .ForMember(dest => dest.BookId, source => source.MapFrom(source => source.BookId))
                .ForMember(dest => dest.UserEmail, source => source.MapFrom(source => source.UserEmail))
                .ForMember(dest => dest.ReturnBookDate, source => source.MapFrom(source => source.ReturnBookDate))
                .ForMember(dest => dest.BorrowBookDate, source => source.MapFrom(source => source.BorrowBookDate))
                .ReverseMap();

            CreateMap<OrderRequest, OrderDto>()
               .ForMember(dest => dest.BookId, source => source.MapFrom(source => source.BookId))
               .ForMember(dest => dest.UserEmail, source => source.MapFrom(source => source.UserEmail))
               .ForMember(dest => dest.ReturnBookDate, source => source.MapFrom(source => source.ReturnBookDate))
               .ForMember(dest => dest.BorrowBookDate, source => source.MapFrom(source => source.BorrowBookDate))
               .ReverseMap();
        }
    }
}
