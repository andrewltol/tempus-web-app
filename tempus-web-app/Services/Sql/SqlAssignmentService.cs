using System;
using System.Collections.Generic;
using System.Linq;
using TempusWebApp.Extensions;
using TempusWebApp.Models;

namespace TempusWebApp.Services
{
  public class SqlAssignmentService : IAssignmentService
  {
    public Assignment Get(int id)
    {
      var assignment = SC.DB.Assignments.Single(a => a.Id == id);
      return assignment;
    }

    public IList<Assignment> GetForEmployee(int employeeId)
    {
      var assignments = SC.DB.Assignments.Join(SC.DB.Employees, 
        a => a.EmployeeId, e => e.Id, (a, e) => a).ToList();
      return assignments;
    }

    public IList<Assignment> GetForPeriod(DateTime startTime, DateTime endTime)
    {
      var assignments = SC.DB.Assignments
        .Where(a => startTime.IsBetween(a.StartTime, a.EndTime) || endTime.IsBetween(a.StartTime, a.EndTime)).ToList();
      return assignments;
    }

    public IList<Assignment> GetForTask(int taskId)
    {
      var assignments = SC.DB.Assignments.Where(a => a.TaskId == taskId).ToList();
      return assignments;
    }
  }
}
