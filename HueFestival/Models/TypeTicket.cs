using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HueFestival.Models
{
    [Table("TypeTicket")]
    public class TypeTicket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeTicketId { get; set; }

        public int EventId { get; set; }
        public Event? Event { get; set; }

        [Required]
        public string? Type { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

       
    }
}
