using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace WebStar.Pages
{
    public class ProcessModel : PageModel
    {
        public void OnGet()
        {
            var procs = Process.GetProcesses();
            ViewData["Processes"] = procs;
        }
    }
}