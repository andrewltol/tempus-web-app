using TempusWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TempusWebApp.Services
{
    public class DummyAssignmentService : IAssignmentService
    {
        private IList<Assignment> _dummyAssignments;

        public DummyAssignmentService()
        {
            _dummyAssignments = new List<Assignment>();

            var assignment1 = new Assignment
            {
                Id = 1,
                EmployeeId = 1,
                TaskId = 1,
                StartTime = new DateTime(2017, 4, 2, 7, 0, 0),
                EndTime = new DateTime(2017, 4, 2, 15, 0, 0)
            };
            _dummyAssignments.Add(assignment1);

            var assignment2 = new Assignment
            {
                Id = 2,
                EmployeeId = 2,
                TaskId = 1,
                StartTime = new DateTime(2017, 4, 2, 15, 0, 0),
                EndTime = new DateTime(2017, 4, 2, 23, 0, 0)
            };
            _dummyAssignments.Add(assignment2);

            var assignment3 = new Assignment
            {
                Id = 3,
                EmployeeId = 3,
                TaskId = 2,
                StartTime = new DateTime(2017, 4, 2, 7, 0, 0),
                EndTime = new DateTime(2017, 4, 2, 15, 0, 0)
            };
            _dummyAssignments.Add(assignment3);

            var assignment4 = new Assignment
            {
                Id = 4,
                EmployeeId = 4,
                TaskId = 2,
                StartTime = new DateTime(2017, 4, 2, 15, 0, 0),
                EndTime = new DateTime(2017, 4, 2, 23, 0, 0)
            };
            _dummyAssignments.Add(assignment4);
        }

        public Assignment Get(int id)
        {
            return _dummyAssignments.Where(item => item.Id == id).SingleOrDefault();
        }

        public IList<Assignment> GetForEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public IList<Assignment> GetForPeriod(DateTime startTime, DateTime endTime)
        {
            List<Assignment> assignmentsInRange = new List<Assignment>();

            foreach (var assignment in _dummyAssignments)
            {
                if (assignment.StartTime < startTime && assignment.EndTime > endTime)
                {
                    assignmentsInRange.Add(assignment);
                }
            }

            return assignmentsInRange;
        }

        public IList<Assignment> GetForTask(int taskId)
        {
            throw new NotImplementedException();
        }
    }
}
