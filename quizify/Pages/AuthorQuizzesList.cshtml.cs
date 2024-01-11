using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Quizzify.Pages;

public class AuthorQuizzesListModel : PageModel
{
    public void OnGet()
    {
    }

    public IActionResult OnPost(int id)
    {
        if (id == 1)
        {
            // add a quiz function
        }

        if (id == 2) return RedirectToPage("/AuthorQuiz");
        return Page();
    }
}