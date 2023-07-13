using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestival.Models
{
    [Table("Location")]
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationId { get; set; }
        [Required]
        public int? LocationCategoryId { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? Content { get; set; }

        [Required]
        public string? Image { get; set; }

        [Required]
        public string? Longtitude { get; set; }

        [Required]
        public string? Latitude { get; set; }

        [ForeignKey("LocationCategoryId")]
        public LocationCategory? LocationCategory { get; set; }

        public List<Event>? ListEvent { get; set; }
    }
}
