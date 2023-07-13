using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestival.Models
{
    [Table("Event")]
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }

        [Required]
        public int ProgramId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int LocationId { get; set; }

        [Required]
        public int EventCategoryId { get; set; }

        [ForeignKey("ProgramId")]
        public Programme? Programme { get; set; }

        [ForeignKey("LocationId")]
        public Location? Location { get; set; }

        [ForeignKey("EventCategoryId")]
        public EventCategory? EventCategory { get; set; }
    }
}
