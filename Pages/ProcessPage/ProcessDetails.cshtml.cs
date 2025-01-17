using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebStar.Pages.ProcessPage
{
    public class ProcessDetailsModel : PageModel
    {
        public void OnGet(int id)
        {
            var proc = Process.GetProcessById(id);
            ViewData["MyProcess"] = proc;
        }
    }
}
