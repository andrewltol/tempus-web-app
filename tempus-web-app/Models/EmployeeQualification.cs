using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempusWebApp.Models
{
  public class EmployeeQualification
  {
    [Key, Required]
    public int Id { get; set; }

    [ForeignKey("Employee"), Required]
    public int EmployeeId { get; set; }

    [ForeignKey("Qualification"), Required]
    public int QualificationId { get; set; }

    [Required]
    public DateTime EffectiveDate { get; set; }

    public DateTime ExpirationDate { get; set; }
  }
}
