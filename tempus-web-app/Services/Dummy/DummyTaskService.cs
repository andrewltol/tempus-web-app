using TempusWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TempusWebApp.Services
{
    public class DummyTaskService : ITaskService
    {
        private IList<TaskItem> _dummyItems;

        public DummyTaskService()
        {
            _dummyItems = new List<TaskItem>();

            var item1 = new TaskItem
            {
                Id = 1,
                TaskName = "Front Desk",
                StartDate = new DateTime(2017, 4, 1)
            };
            _dummyItems.Add(item1);

            var item2 = new TaskItem
            {
                Id = 2,
                TaskName = "Bellman",
                StartDate = new DateTime(2017, 4, 1)
            };
            _dummyItems.Add(item2);
        }

        public TaskItem GetTask(int id)
        {
            return _dummyItems.Where(x => x.Id == id).SingleOrDefault();
        }

        public IList<TaskItem> GetForPeriod(DateTime startDate, DateTime endDate)
        {
            List<TaskItem> tasksInRange = new List<TaskItem>();

            foreach (var task in _dummyItems)
            {
                if (task.StartDate < startDate && task.EndDate > endDate)
                {
                    tasksInRange.Add(task);
                }
            }

            return tasksInRange;
        }

        public IList<TaskItem> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
