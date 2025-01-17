using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebStar.Pages.ProcessPage
{
    public class ProcessesModel : PageModel
    {
        public void OnGet()
        {
            var procs = Process.GetProcesses();
            ViewData["Processes"] = procs;
        }
    }
}
