
using System.Xml;
using TaskTracker.Api.Models;

namespace TaskTracker.Api.Services
{
    public class TasksTracker : ITaskTracker
    {
        List<TaskModel> _tasks = new List<TaskModel>();
        Random random = new Random();

        private void GenerateRandomTasks()
        {
            for(int i = 0; i < 20; i++)
            {
                var task = new TaskModel()
                {
                    TaskId = Guid.NewGuid(),
                    TaskName = $"Task number: {i}",
                    TaskCreatedBy = "johndoe@tracker.com",
                    TaskCreatedOn = DateTime.UtcNow.AddMinutes(i),
                    TaskDueDate = DateTime.UtcNow.AddDays(i),
                    TaskAssignedTo = $"assignee{random.Next(50)}@tracker.com"
                };
                _tasks.Add(task);
            }
        }

        public TasksTracker()
        {
            GenerateRandomTasks();
        }

        public Task<List<TaskModel>> GetTasksByOwner(string createdBy)
        {
            var tasks = _tasks.Where(t => t.TaskCreatedBy.Equals(createdBy)).OrderByDescending(x => x.TaskCreatedOn).ToList();
            return Task.FromResult(tasks);
        }

        public Task<TaskModel?> GetTaskById(Guid taskId)
        {
            var task = _tasks.FirstOrDefault(x => x.TaskId.Equals(taskId));
            return Task.FromResult(task);
        }

        public Task<bool> MarkTaskCompleted(Guid taskId)
        {
            var task = _tasks.FirstOrDefault(x => x.TaskId.Equals(taskId));

            if(task != null)
            {
                task.IsCompleted = true;
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

        public Task<Guid> CreateNewTask(string taskName, string createdBy, string assignedTo, DateTime dueDate)
        {
            var task = new TaskModel()
            {
                TaskId = Guid.NewGuid(),
                TaskName = taskName,
                TaskCreatedBy = createdBy,
                TaskCreatedOn = DateTime.UtcNow,
                TaskDueDate = dueDate,
                TaskAssignedTo = assignedTo
            };
            _tasks.Add(task);
            return Task.FromResult(task.TaskId);
        }

        public Task<bool> UpdateTask(Guid taskId, string taskName, string assignedTo, DateTime dueDate)
        {
            var task = _tasks.FirstOrDefault(t => t.TaskId.Equals(taskId));

            if (task != null)
            {
                task.TaskName = taskName;
                task.TaskAssignedTo = assignedTo;
                task.TaskDueDate = dueDate;
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

        public Task<bool> DeleteTask(Guid taskId)
        {
            var task = _tasks.FirstOrDefault(t => t.TaskId.Equals(taskId));

            if(task != null)
            {
                _tasks.Remove(task);
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
        
    }
}