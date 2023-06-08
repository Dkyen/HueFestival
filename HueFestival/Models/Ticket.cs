using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestival.Models
{
    [Table("Ticket")]
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketId { get; set; }

        [Required]
        public string? TicketNumber { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public int TypeTicketId { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("TypeTicketId")]
        public TypeTicket? TypeTicket { get; set; }

        [ForeignKey("UserId")]
        public Userr? Userr { get; set; }
    }
}
