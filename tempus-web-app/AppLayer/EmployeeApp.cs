using System.Collections.Generic;
using TempusWebApp.Context;
using TempusWebApp.Models;
using TempusWebApp.Services;

namespace TempusWebApp.AppLayer
{
  /// <summary>
  /// Class to get employee data.
  /// </summary>
  public class EmployeeApp
  {
    private IEmployeeService _employeeService;

    public EmployeeApp(IEmployeeService employeeService)
    {
      _employeeService = employeeService;
    }

    /// <summary>
    /// Retrieves all employees.
    /// </summary>
    /// <returns>List of all employees.</returns>
    public IList<Employee> GetAllEmployees()
    {
      using (var context = new TempusDatabaseContext())
      {
        var allEmployees = _employeeService.GetAll();
        return allEmployees;
      }
    }
  }
}
