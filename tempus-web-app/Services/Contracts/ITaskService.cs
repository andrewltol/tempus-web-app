using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TempusWebApp.Models;

namespace TempusWebApp.Services
{
  public interface ITaskService
  {
    /// <summary>
    /// Creates a new task in data storage.
    /// </summary>
    /// <param name="task">Data for task to create.</param>
    /// <returns>Handle for database task.</returns>
    Task Add(TaskItem task);

    /// <summary>
    /// Deletes a task from data storage.
    /// </summary>
    /// <param name="task">Task item to delete.</param>
    /// <returns>Handle for database task.</returns>
    Task Delete(TaskItem task);

    /// <summary>
    /// Disposes of this service.
    /// </summary>
    void Dispose();

    /// <summary>
    /// Determines if a specified task exists in data storage.
    /// </summary>
    /// <param name="id">Id of task.</param>
    /// <returns>True if task exists.</returns>
    Task<bool> Exists(int id);

    /// <summary>
    /// Retrieves data for a specified task.
    /// </summary>
    /// <param name="id">Id of task.</param>
    /// <returns>Task data.</returns>
    Task<TaskItem> Get(int id);

    /// <summary>
    /// Gets all tasks.
    /// </summary>
    /// <returns>List of all tasks.</returns>
    Task<List<TaskItem>> GetAll();
        
    /// <summary>
    /// Retrieves tasks for a period of time.
    /// </summary>
    /// <param name="startDate">Beginning of period.</param>
    /// <param name="endDate">End of period./</param>
    /// <returns>List of tasks within the period.</returns>
    Task<List<TaskItem>> GetForPeriod(DateTime startDate, DateTime endDate);

    /// <summary>
    /// Updates a specified task in data storage.
    /// </summary>
    /// <param name="task">Task to update.</param>
    Task Update(TaskItem task);
  }
}
