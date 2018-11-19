using System.Data.Entity;

namespace TempusWebApp.Models
{
    public class TempusWebAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TempusWebAppContext() : base("name=TempusWebAppContext")
        {
        }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<TaskItem> TaskItems { get; set; }

    public DbSet<Qualification> Qualifications { get; set; }

    public DbSet<Assignment> Assignments { get; set; }

    public DbSet<EmployeeQualification> EmployeeQualifications { get; set; }

    public DbSet<TaskQualification> TaskQualifications { get; set; }
  }
}
