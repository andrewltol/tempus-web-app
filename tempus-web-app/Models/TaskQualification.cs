using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempusWebApp.Models
{
  public class TaskQualification
  {
    [Key]
    public int Id { get; set; }

    [ForeignKey("Task"), Required]
    public int TaskId { get; set; }
    public virtual TaskItem Task { get; set; }

    [ForeignKey("Qualification"), Required]
    public int QualificationId { get; set; }
    public virtual Qualification Qualification { get; set; }
  }
}
