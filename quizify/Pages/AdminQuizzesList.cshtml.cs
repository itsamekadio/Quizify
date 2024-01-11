using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Quizzify.Pages;

public class AdminQuizzesListModel : PageModel
{
    public void OnGet()
    {
    }

    public IActionResult OnPost(int id)
    {
        if (id == 1)
        {
            //implement edit function of quiz
        }

        if (id == 2)
        {
            //implement remove function of quiz
        }

        if (id == 3) return RedirectToPage("/AdminQuiz");
        return Page();
    }
}