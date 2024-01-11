using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Quizzify.Pages;

public class AdminPostsModel : PageModel
{
    public void OnGet()
    {
    }

    public IActionResult OnPost(int id)
    {
        if (id == 1)
        {
            //implement the function of  making post or announcement
        }
        else if (id == 2)
        {
            //impelment the function to edit the post
        }
        else if (id == 3)
        {
            //impelment the function to remove post
        }
        else if (id == 4)
        {
            //impelment the function to make a comment
        }

        return Page();
    }
}