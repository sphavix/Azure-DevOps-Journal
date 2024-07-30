

using TaskTracker.Api.Models;

namespace TaskTracker.Api.Services
{
    public interface ITaskTracker
    {
        Task<List<TaskModel>> GetTasksByOwner(string createdBy);
        Task<TaskModel?> GetTaskById(Guid taskId);
        Task<Guid> CreateNewTask(string taskName, string createdBy, string assignedTo, DateTime dueDate);
        Task<bool> UpdateTask(Guid taskId, string taskName, string assignedTo, DateTime dueDate);
        Task<bool> MarkTaskCompleted(Guid taskId);
        Task<bool> DeleteTask(Guid taskId);
    }
}