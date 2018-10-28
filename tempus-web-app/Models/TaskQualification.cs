using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempusWebApp.Models
{
  public class TaskQualification
  {
    [Key, Required]
    public int Id { get; set; }

    [ForeignKey("Task"), Required]
    public int TaskId { get; set; }

    [ForeignKey("Qualification"), Required]
    public int QualificationId { get; set; }
  }
}
