using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Quizzify.Pages
{

    public class RoomsModel : PageModel
    {
        public void OnGet()
        {
        }
        //public IActionResult OnPost()
        //{
        //    return RedirectToPage("/Room");
        //}
        public IActionResult OnPost(int id)
        {
            if (id == 1)
            {
                return RedirectToPage("/ReportPlayer");
            }
            else if (id == 2)
            {
                return RedirectToPage("/Room");
            }
            return Page();
        }
    }
}
