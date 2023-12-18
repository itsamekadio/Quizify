using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Quizzify.Pages
{
    public class SignInModel : PageModel
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
