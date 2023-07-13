using System;
using System.ComponentModel.DataAnnotations;

namespace HueFestival.ViewModel
{
    public class LocationViewModel
    {
        public int LocationId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Image { get; set; }
    }

    public class LocationViewModel_Add
    {
        
        public int LocationCategoryId { get; set; }

      
        public string? Title { get; set; }

       
        public string? Content { get; set; }

       
        public string? Image { get; set; }

        
        public string? Longtitude { get; set; }

       
        public string? Latitude { get; set; }
    }

    public class LocationViewModel_Details
    {
        public int LocationId { get; set; }

        public string? LocationCategory { get; set; }

        public string? Title { get; set; }

        public string? Content { get; set; }

        public string? Image { get; set; }

        public string? Longtitude { get; set; }

        public string? Latitude { get; set; }
    }
}

