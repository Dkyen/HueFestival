using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HueFestival.Models
{
    [Table("LocationCategory")]
    public class LocationCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationCategoryId { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Image { get; set; }

        public List<Location>? ListLocation { get; set; }
    }
}
