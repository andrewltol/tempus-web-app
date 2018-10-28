using TempusWebApp.Models;
using System.Data.Entity;

namespace TempusWebApp.Context
{
  public class TempusDatabaseContext : DbContext
  {
    public DbSet<Assignment> Assignments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeQualification> EmployeeQualifications { get; set; }
    public DbSet<Qualification> Qualifications { get; set; }
    public DbSet<TaskItem> Tasks { get; set; }
    public DbSet<TaskQualification> TaskQualifications { get; set; }

    public TempusDatabaseContext() : base() { }
    public TempusDatabaseContext(string connectionString) : base(connectionString) { }
  }
}
