using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Quizzify.Pages
{
    public class ProfileModel : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            
                return RedirectToPage("/SignIn");
            
         
        }
    }
}
