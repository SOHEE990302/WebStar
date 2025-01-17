using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorIntro.Pages.ProcessPages
{
    public class ProcessDetailsPropModel : PageModel
    {
        [BindProperty]
        public Process? MyProcess { get; set; }
        public void OnGet(int id)
        {
            MyProcess = Process.GetProcessById(id);
        }
    }
}
