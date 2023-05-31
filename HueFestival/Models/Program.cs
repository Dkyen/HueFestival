using System.ComponentModel.DataAnnotations;

namespace HueFestival.Controllers;




public class Program
{
    public int ProgramId { get; set; }

    [Required]
    [StringLength(255)]
    public string? ProgramName { get; set; }

    public string? Content { get; set; }

    [Required]
    public int TypeProgram { get; set; }
}
