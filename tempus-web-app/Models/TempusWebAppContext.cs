using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

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

    public System.Data.Entity.DbSet<TempusWebApp.Models.Employee> Employees { get; set; }

    public System.Data.Entity.DbSet<TempusWebApp.Models.TaskItem> TaskItems { get; set; }

    public System.Data.Entity.DbSet<TempusWebApp.Models.Qualification> Qualifications { get; set; }

    public System.Data.Entity.DbSet<TempusWebApp.Models.Assignment> Assignments { get; set; }
  }
}
