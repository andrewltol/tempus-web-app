using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempusWebApp.Models
{
  [Table("Task")]
  public class TaskItem
  {
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public String TaskName { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    public DateTime? TerminationDate { get; set; }

    [Column(TypeName = "NVARCHAR(MAX)")]
    public string Notes { get; set; }
  }
}
