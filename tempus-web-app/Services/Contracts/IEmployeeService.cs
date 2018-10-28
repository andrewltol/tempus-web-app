using System.Collections.Generic;
using TempusWebApp.Models;

namespace TempusWebApp.Services
{
    public interface IEmployeeService
    {
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
    }
}
