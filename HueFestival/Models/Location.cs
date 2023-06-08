using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestival.Models
{
    [Table("Location")]
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        public int? LocationCategoryId { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? Content { get; set; }

        [Required]
        public string? Image { get; set; }

        [Required]
        public string? Longitude { get; set; }

        [Required]
        public string? Latitude { get; set; }

        [ForeignKey("LocationCategoryId")]
        public LocationCategory? LocationCategory { get; set; }
    }
}
