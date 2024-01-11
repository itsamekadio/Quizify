using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Quizzify.Pages
{
    public class Index1Model : PageModel
    {
        public void OnGet()
        {
        }
    public IActionResult OnPostPlayer()
        {
            return RedirectToPage("/SignUpplayer");
        }

        public IActionResult OnPostAdmin()
        {
            return RedirectToPage("/SignUpAdmin");
        }

        public IActionResult OnPostAuthor()
        {
            return RedirectToPage("/SignUpAuthor");

        }
    }
}
