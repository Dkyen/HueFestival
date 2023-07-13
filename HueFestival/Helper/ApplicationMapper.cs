using System;
using AutoMapper;
using HueFestival.Models;
using HueFestival.ViewModel;

namespace HueFestival.Helper
{
	public class ApplicationMapper:Profile
	{
		public ApplicationMapper()
		{
			CreateMap<About, AboutViewModel>().ReverseMap();
            CreateMap<About, AboutViewModel_Add>().ReverseMap();
            CreateMap<About, AboutViewModel_Details>().ReverseMap();

            CreateMap<News, NewsViewModel>().ReverseMap();
            CreateMap<News, NewsViewModel_Add>().ReverseMap();
            CreateMap<News, NewsViewModel_Details>().ReverseMap();

			CreateMap<Programme, ProgramViewModel>().ReverseMap();
            CreateMap<Programme, ProgramViewModel_Add>().ReverseMap();
            CreateMap<Programme, ProgramViewModel_Details>().ReverseMap();

            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<RegisterInputModel, User>().ReverseMap();
            CreateMap<User, LoginInputModel>().ReverseMap();

            CreateMap<Event, EventViewModel>().ReverseMap();
            CreateMap<Event, EventViewModel_Add>().ReverseMap();
            CreateMap<Event, EventViewModel_Details>().ReverseMap();
            CreateMap<Event, EventViewModel_SalesTicket>().ReverseMap();

            CreateMap<EventCategory, EventCategoryViewModel>().ReverseMap();
            CreateMap<EventCategory, EventCategoryViewModel_Add>().ReverseMap();

            CreateMap<Location, LocationViewModel>().ReverseMap();
            CreateMap<Location, LocationViewModel_Add>().ReverseMap();
            CreateMap<Location, LocationViewModel_Details>().ReverseMap();

            CreateMap<LocationCategory, LocationCategoryViewModel>().ReverseMap();
            CreateMap<LocationCategory, LocationCategoryViewModel_Add>().ReverseMap();
            CreateMap<LocationCategory, LocationCategoryViewModel_Details>().ReverseMap();

            CreateMap<TypeTicket, TicketTypeViewModel>().ReverseMap();
            CreateMap<TypeTicket, TicketTypeViewModel_Add>().ReverseMap();

            CreateMap<TicketLocation, TicketLocationViewModel>().ReverseMap();
            CreateMap<TicketLocation, TicketLocationViewModel_Add>().ReverseMap();

            CreateMap<Ticket, TicketViewModel>().ReverseMap();
            CreateMap<Ticket, BuyTicketViewModel>().ReverseMap();

            CreateMap<Checkin, CheckInViewModel>().ReverseMap();
            CreateMap<Checkin, CheckInViewModel_Report>().ReverseMap();

        }
	}
}

