using System;
using HueFestival.Models;
using System.ComponentModel.DataAnnotations;

namespace HueFestival.ViewModel
{
    public class LocationCategoryViewModel
    {
        public int LocationCategoryId { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Image { get; set; }
    }

    public class LocationCategoryViewModel_Add
    {
        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Image { get; set; }
    }

    public class LocationCategoryViewModel_Details
    {
        public int LocationCategoryId { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public List<LocationViewModel>? ListLocation { get; set; }
    }
}

