using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempusWebApp.Models
{
  public class Assignment
  {
    [Key, Required]   
    public int Id { get; set; }

    [ForeignKey("Task"), Required]
    public int TaskId { get; set; }

    [ForeignKey("Employee"), Required]
    public int EmployeeId { get; set; }

    [Required]
    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    [Column(TypeName = "NVARCHAR(MAX)")]
    public string Notes { get; set; }
  }
}
