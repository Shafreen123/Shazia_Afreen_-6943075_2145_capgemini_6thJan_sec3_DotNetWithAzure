using AutoMapper;
using EventBooking.API.DTOs;
using EventBooking.API.Models;

namespace EventBooking.API.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Event, EventDto>();
        CreateMap<CreateEventDto, Event>();

        CreateMap<Booking, BookingDto>()
            .ForMember(dest => dest.EventTitle,
                       opt => opt.MapFrom(src => src.Event!.Title));
        CreateMap<CreateBookingDto, Booking>();
    }
}