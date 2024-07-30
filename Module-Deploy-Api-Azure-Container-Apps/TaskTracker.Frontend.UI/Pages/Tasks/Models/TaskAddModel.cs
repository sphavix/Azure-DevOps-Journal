

using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Frontend.UI.Pages.Tasks.Models
{
    public class TaskAddModel
    {
        [Display(Name = "Task Name")]
        [Required]
        public string TaskName { get; set; } = string.Empty;

        [Display(Name = "Task DueDate")]
        [Required]
        public DateTime TaskDueDate { get; set; }

        [Display(Name = "Assigned To")]
        [Required]
        public string TaskAssignedTo { get; set; } = string.Empty;
        public string TaskCreatedBy { get; set; } = string.Empty;
    }
}