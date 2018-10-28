using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempusWebApp.Models
{
  [Table("Qualification")]
  public class Qualification
  {
    [Key, Required]
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string RoleName { get; set; }

    [Column(TypeName = "nvarchar(MAX)")]
    public string Notes { get; set; }
  }
}
