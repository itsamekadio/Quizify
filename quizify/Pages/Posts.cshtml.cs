using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Quizzify.Pages;

public class PostsModel : PageModel
{
    public void OnGet()
    {
    }

    public IActionResult OnPost(int id)
    {
        if (id == 1)
        {
            //implement the function
        }
        else if (id == 2)
        {
            return RedirectToPage("/ReportPlayer");
        }
        else if (id == 3)
        {
            //impelment the function
        }

        return Page();
    }

    //    // apply onpost function to appear the comment in the post
}