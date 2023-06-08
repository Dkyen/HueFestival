using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace HueFestival.Models;

[Table("Account")]
public class Account
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
   
    public int AccountId { get; set; }

    [Required]
    [StringLength(255)]
    public string? Username { get; set; }

    [Required]
    [StringLength(255)]
    public string? Password { get; set; }

    [ForeignKey("Role")]
    public int? RoleId { get; set; }

    public Role? Role { get; set; }
}
