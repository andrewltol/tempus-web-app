using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempusWebApp.Models
{
  public class Assignment
  {
    [Key]   
    public int Id { get; set; }

    [Required]
    public virtual TaskItem TaskItem { get; set; }

    [Required]
    public virtual Employee Employee { get; set; }

    [Required]
    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    [Column(TypeName = "NVARCHAR(MAX)")]
    public string Notes { get; set; }
  }
}
