using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TempusWebApp.Models;

namespace TempusWebApp.Services
{
  public class SqlEmployeeService : IEmployeeService
  {
    private TempusWebAppContext _db = new TempusWebAppContext();

    public Task Add(Employee employee)
    {
      _db.Employees.Add(employee);
      return _db.SaveChangesAsync();
    }

    public Task Delete(Employee employee)
    {
      _db.Employees.Remove(employee);
      return _db.SaveChangesAsync();
    }

    public Task<Employee> Get(int id)
    {
      var employeeTask = _db.Employees.FindAsync(id);
      return employeeTask;
    }

    public IList<Employee> GetAll()
    {
      var employees = _db.Employees.ToList();
      return employees;
    }

    public IList<Employee> GetForRoles(IList<int> roleIds)
    {
      var employees = _db.Employees
        .Join(_db.EmployeeQualifications, e => e.Id, eq => eq.EmployeeId, (e, eq) => new { Employee = e, QualId = eq.QualificationId })
        .Where(item => roleIds.Contains(item.QualId))
        .Select(item => item.Employee).ToList();
      return employees;
    }

    public IList<Employee> GetForTask(int taskId)
    {
      var employees = _db.TaskQualifications.Where(tq => tq.Task.Id == taskId)
        .Join(_db.EmployeeQualifications, tq => tq.Qualification.Id, eq => eq.Qualification.Id, (tq, eq) => eq.EmployeeId)
        .Join(_db.Employees, eId => eId, e => e.Id, (eId, e) => e).ToList();
      return employees;
    }

    public Task Update(Employee employee)
    {
      _db.Entry(employee).State = EntityState.Modified;
      return _db.SaveChangesAsync();
    }
  }
}
