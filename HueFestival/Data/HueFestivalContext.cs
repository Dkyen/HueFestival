using System;
using HueFestival.Controllers;
using Microsoft.EntityFrameworkCore;
using HueFestival.Models;

namespace HueFestival.Data
{
	
	
        public class HueFestivalContext : DbContext
        {
            public HueFestivalContext(DbContextOptions<HueFestivalContext> options)
                : base(options)
            {
            }
            public DbSet<About>? Abouts { get; set; }
            public DbSet<Account>? Accounts { get; set; }
            public DbSet<Checkin>? Checkins { get; set; }
            public DbSet<Event>? Events { get; set; }
            public DbSet<EventCategory>? EventCategories { get; set; }
            public DbSet<Location>? Locations { get; set; }
            public DbSet<LocationCategory>?LocationCategories { get; set; }
            public DbSet<News>? News { get; set; }
            public DbSet<PriceTicket>? PriceTickets { get; set; }
            public DbSet<Programme>? Programmes { get; set; }
            public DbSet<Role>? Roles { get; set; }
            public DbSet<Ticket>? Tickets { get; set; }
            public DbSet<TicketLocation>? TicketLocations { get; set; }
            public DbSet<TypeTicket>? TypeTickets { get; set; }
            public DbSet<Userr>? Userrs { get; set; }
        }
    }


