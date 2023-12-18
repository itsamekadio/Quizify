using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Quizzify.Pages
{
    public class AdminRoomsListModel : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnPost(int id)
        {
            if (id == 1)
            {
                return RedirectToPage("/AdminRoom");
            }
            return Page();
        }
    }
}
