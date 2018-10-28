using System.Collections.Generic;
using System.Linq;
using TempusWebApp.Models;

namespace TempusWebApp.Services
{
  public class SqlEmployeeService : IEmployeeService
  {
    public IList<Employee> GetAll()
    {
      var employees = SC.DB.Employees.ToList();
      return employees;
    }

    public IList<Employee> GetForRoles(IList<int> roleIds)
    {
      var employees = SC.DB.Employees
        .Join(SC.DB.EmployeeQualifications, e => e.Id, eq => eq.EmployeeId, (e, eq) => new { Employee = e, QualId = eq.QualificationId })
        .Where(item => roleIds.Contains(item.QualId))
        .Select(item => item.Employee).ToList();
      return employees;
    }

    public IList<Employee> GetForTask(int taskId)
    {
      var employees = SC.DB.TaskQualifications.Where(tq => tq.TaskId == taskId)
        .Join(SC.DB.EmployeeQualifications, tq => tq.QualificationId, eq => eq.QualificationId, (tq, eq) => eq.EmployeeId)
        .Join(SC.DB.Employees, eId => eId, e => e.Id, (eId, e) => e).ToList();
      return employees;
    }
  }
}
