using System.Collections.Generic;
using System.Threading.Tasks;
using TempusWebApp.Models;

namespace TempusWebApp.Services
{
  public interface IEmployeeService
  {
    /// <summary>
    /// Creates a new employee.
    /// </summary>
    /// <param name="employee">Data for new employee.</param>
    /// <returns>Task for database operation.</returns>
    Task Add(Employee employee);

    /// <summary>
    /// Removes an employee from the database.
    /// </summary>
    /// <param name="employee">Employee to remove.</param>
    /// <returns>Task for database operation.</returns>
    Task Delete(Employee employee);

    /// <summary>
    /// Gets an employee.
    /// </summary>
    /// <param name="id">Id of employee to get.</param>
    /// <returns>Employee requested.</returns>
    Task<Employee> Get(int id);

    /// <summary>
    /// Gets all employees.
    /// </summary>
    /// <returns>List of employees.</returns>
    IList<Employee> GetAll();

    /// <summary>
    /// Gets all employees that are in the provided roles.
    /// </summary>
    /// <param name="roleIds">List of roles that the employees must contain.</param>
    /// <returns>Employee that contain any of the provides role ids.</returns>
    IList<Employee> GetForRoles(IList<int> roleIds);

    /// <summary>
    /// Get employees that can be assigned to a task.
    /// </summary>
    /// <param name="taskId">Id of task to get employees for.</param>
    /// <returns>List of employees that can be assigned to task.</returns>
    IList<Employee> GetForTask(int taskId);

    /// <summary>
    /// Updates the data for an employee.
    /// </summary>
    /// <param name="employee">Employee data to set.</param>
    /// <returns>Task for database operation.</returns>
    Task Update(Employee employee);
  }
}
