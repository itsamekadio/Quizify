using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Quizzify.Pages
{
    public class SignUpModel : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
                return RedirectToPage("/HomePage");
        }
    }
}
