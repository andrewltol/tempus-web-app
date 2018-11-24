using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TempusWebApp.Extensions;
using TempusWebApp.Models;

namespace TempusWebApp.Services
{
  public class SqlTaskService : ITaskService
  {
    private TempusWebAppContext _db = new TempusWebAppContext();
    
    public Task Add(TaskItem task)
    {
      _db.TaskItems.Add(task);
      return _db.SaveChangesAsync();
    }

    public Task Delete(TaskItem task)
    {
      _db.TaskItems.Remove(task);
      return _db.SaveChangesAsync();
    }

    public void Dispose()
    {
      _db.Dispose();
    }

    public Task<bool> Exists(int id)
    {
      return _db.TaskItems.AnyAsync(ti => ti.Id == id);
    }

    public Task<List<TaskItem>> GetAll()
    {
      var tasks = _db.TaskItems.ToListAsync();
      return tasks;
    }

    public Task<List<TaskItem>> GetForPeriod(DateTime startDate, DateTime endDate)
    {
      var tasks = _db.TaskItems
        .Where(t => startDate.IsBetween(t.StartDate, t.TerminationDate.GetValueOrDefault()) || endDate.IsBetween(t.StartDate, t.TerminationDate.GetValueOrDefault()))
        .ToListAsync();
      return tasks;
    }

    public Task<TaskItem> Get(int id)
    {
      var task = _db.TaskItems.FindAsync(id);
      return task;
    }

    public Task Update(TaskItem task)
    {
      _db.Entry(task).State = EntityState.Modified;
      return _db.SaveChangesAsync();
    }
  }
}
