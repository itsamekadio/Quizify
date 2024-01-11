using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Quizzify.Pages;

public class AuthorRoomsListModel : PageModel
{
    public void OnGet()
    {
    }

    public IActionResult OnPost(int id)
    {
        if (id == 1) RedirectToPage("/AuthorRoom");
        if (id == 2)
        {
        }

        return Page();
    }
}