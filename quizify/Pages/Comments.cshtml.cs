using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Quizzify.Pages
{
    public class CommentsModel : PageModel
    {
        public void OnGet()
        {
        }


        public IActionResult OnPost(int id)
        {
            if (id == 1)
            {
                return RedirectToPage("/ReportPlayer");
            }
            else if (id == 2)
            {
                //implement function 
            }
            return Page();
        }
    }
}
