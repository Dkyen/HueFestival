﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HueFestival.Models
{
    [Table("Programme")]
    public class Programme
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProgramId { get; set; }

        [Required]
        public string? ProgramName { get; set; }

        public string? Content { get; set; }

        [Required]
        public int TypeProgram { get; set; }
        [Required]
        public int Type_inoff { get; set; }
        [Required]
        public double Price { get; set; }


        public List<Event>? ListEvent { get; set; }
    }
}
