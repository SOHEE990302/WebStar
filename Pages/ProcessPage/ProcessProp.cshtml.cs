using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorIntro.Pages.ProcessPages;

public class ProcessPropModel : PageModel
{
    public Process[]? Processes { get; set; }
    public void OnGet()
    {
        Processes = Process.GetProcesses();
    }
}

