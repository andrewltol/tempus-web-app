using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempusWebApp.Models
{
  public class EmployeeQualification
  {
    [Key]
    public int Id { get; set; }

    [ForeignKey("Employee"), Required]
    public int EmployeeId { get; set; }
    public virtual Employee Employee { get; set; }

    [ForeignKey("Qualification"), Required]
    public int QualificationId { get; set; }
    public virtual Qualification Qualification { get; set; }

    [Required]
    public DateTime EffectiveDate { get; set; }

    public DateTime? ExpirationDate { get; set; }
  }
}
