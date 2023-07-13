using System;
namespace HueFestival.ViewModel
{
	public class EventViewModel
	{
		
        public int EventId { get; set; }
        public int ProgramId { get; set; }
        public string? ProgramName { get; set; }
        public int Type_inoff { get; set; }
        public string? Time { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LocationId { get; set; }
        public string? LocationTitle { get; set; }
        
	}
    public class EventViewModel_Add
    {
        public int ProgramId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LocationId { get; set; }
        public int EventCategoryId { get; set; }
    }

    public class EventViewModel_Details
    {
        public string? ProgramName { get; set; }
        public string? Time { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? LocationTitle { get; set; }
        public double Price { get; set; }
        public string? EventName { get; set; }
        public string? Content { get; set; }
    }

    public class EventViewModel_SalesTicket
    {
        public int EventId { get; set; }
        public string? ProgramName { get; set; }
        public DateTime StartDate { get; set; }
    }
}

