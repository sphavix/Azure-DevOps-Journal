using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace TaskTracker.Frontend.UI.Pages.Tasks
{
    public class Index.cshtml : PageModel
    {
        private readonly ILogger<Index.cshtml> _logger;

        public Index.cshtml(ILogger<Index.cshtml> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}