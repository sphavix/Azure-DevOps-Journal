using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskTracker.Frontend.UI.Pages.Tasks.Models;

namespace TaskTracker.Frontend.UI.Pages.Tasks
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public List<TaskModel>? TaskList { get; set; }

        [BindProperty]
        public string? TasksCreatedBy { get; set; }

        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<IActionResult> OnGetAsync()
        {
            TasksCreatedBy = Request.Cookies["TasksCreatedByCookie"];

            if (!String.IsNullOrEmpty(TasksCreatedBy))
            {
                // direct service to service http request
                var httpClient = _httpClientFactory.CreateClient("BackEndApi");
                TaskList = await httpClient.GetFromJsonAsync<List<TaskModel>>($"api/tasks?createdBy={TasksCreatedBy}");
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            // direct service to service http request
            var httpClient = _httpClientFactory.CreateClient("BackEndApi");
            var result = await httpClient.DeleteAsync($"api/tasks/{id}");
            return Page();
        }

        public async Task<IActionResult> OnPostCompleteAsync(Guid id)
        {
            // direct service to service http request
            var httpClient = _httpClientFactory.CreateClient("BackEndApi");
            var result = await httpClient.PutAsync($"api/tasks/{id}/markcomplete", null);
            return RedirectToPage();
        }
    }
}
