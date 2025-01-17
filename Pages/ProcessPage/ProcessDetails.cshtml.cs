using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace RazorIntro.Pages.ProcessPages
{
    public class ProcessDetailsModel : PageModel
    {
        public void OnGet(int id, string name)
        {
            Process process = Process.GetProcessById(id);
            ViewData["myProcess"] = process;
        }
    }
}
