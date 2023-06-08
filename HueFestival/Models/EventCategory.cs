using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HueFestival.Models
{
    [Table("EventCategory")]
    public class EventCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventCategoryId { get; set; }

        [Required]
        public string? EventName { get; set; }

        public string? Content { get; set; }
    }
}
