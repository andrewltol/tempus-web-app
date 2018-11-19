using System;
using System.Collections.Generic;
using System.Linq;
using TempusWebApp.Extensions;
using TempusWebApp.Models;

namespace TempusWebApp.Services.Sql
{
  public class SqlTaskService : ITaskService
  {
    public IList<TaskItem> GetAll()
    {
      var tasks = SC.DB.Tasks.ToList();
      return tasks;
    }

    public IList<TaskItem> GetForPeriod(DateTime startDate, DateTime endDate)
    {
      var tasks = SC.DB.Tasks
        .Where(t => startDate.IsBetween(t.StartDate, t.TerminationDate.GetValueOrDefault()) || endDate.IsBetween(t.StartDate, t.TerminationDate.GetValueOrDefault()))
        .ToList();
      return tasks;
    }

    public TaskItem GetTask(int id)
    {
      var task = SC.DB.Tasks.Find(id);
      return task;
    }
  }
}
