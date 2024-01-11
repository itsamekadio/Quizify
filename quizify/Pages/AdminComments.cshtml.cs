using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Quizzify.Pages;

public class AdminCommentsModel : PageModel
{
    public void OnGet()
    {
    }

    public IActionResult OnPost(int id)
    {
        if (id == 1)
        {
        }

        //else if (id == 2)
        //{
        //    return RedirectToPage("/");
        //}
        return Page();
    }
}