
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newik_Resume.Models;

namespace Newik_Resume.Pages
{
    public class ResumeModel : PageModel
    {
        public ResumeData Data { get; private set; }

        private readonly ILogger<ResumeModel> _logger;

        public ResumeModel(ILogger<ResumeModel> logger)
        {
            _logger = logger;
            Data = new ResumeData();
        }

        public void OnGet()
        {
            
        }
    }
}
