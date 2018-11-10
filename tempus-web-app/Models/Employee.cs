using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempusWebApp.Models
{
  [Table("Employee")]
  public class Employee
  {
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(30)]
    public String FirstName { get; set; }

    [Required, MaxLength(60)]
    public String LastName { get; set; }

    [Required]
    public DateTime HireDate { get; set; }

    public DateTime? TerminationDate { get; set; }

    [Column(TypeName = "NVARCHAR(MAX)")]
    public string Notes { get; set; }

    public String FullName()
    {
      return $"{FirstName} {LastName}";
    }
  }
}
