using System;
using System.Collections.Generic;
using TempusWebApp.Models;

namespace TempusWebApp.Services
{
    public interface ITaskService
    {
        /// <summary>
        /// Retrieves data for a specified task.
        /// </summary>
        /// <param name="id">Id of task.</param>
        /// <returns>Task data.</returns>
        TaskItem GetTask(int id);

        /// <summary>
        /// Gets all tasks.
        /// </summary>
        /// <returns>List of all tasks.</returns>
        IList<TaskItem> GetAll();
        
        /// <summary>
        /// Retrieves tasks for a period of time.
        /// </summary>
        /// <param name="startDate">Beginning of period.</param>
        /// <param name="endDate">End of period./</param>
        /// <returns>List of tasks within the period.</returns>
        IList<TaskItem> GetForPeriod(DateTime startDate, DateTime endDate);
    }
}
