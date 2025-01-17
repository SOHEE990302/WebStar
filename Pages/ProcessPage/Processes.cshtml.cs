using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace RazorIntro.Pages.ProcessPages;

public class ProcessModel : PageModel
{
    public void OnGet()
    {
        Process[] processes = Process.GetProcesses();
        ViewData["myProcess"] = processes;
    }
}

