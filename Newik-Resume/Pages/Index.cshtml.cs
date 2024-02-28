
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newik_Resume.Models;

namespace Newik_Resume.Pages
{
    public class ResumeModel : PageModel
    {
        public ResumeData Data { get; private set; }

        public string SomeExpString { get; private set; } = "";

        private readonly ILogger<ResumeModel> _logger;

        public ResumeModel(ILogger<ResumeModel> logger)
        {
            _logger = logger;
            Data = new ResumeData();

            for (int i = 0; i < Data.User.SomeExp.Length; i++)
            {
                if (i > 0)
                    SomeExpString += ", ";

                SomeExpString += Data.User.SomeExp[i];
            }
        }

        public void OnGet()
        {
            
        }
    }
}
