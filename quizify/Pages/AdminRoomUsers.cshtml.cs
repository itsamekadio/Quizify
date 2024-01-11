using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Quizzify.Pages;

public class AdminRoomUsersModel : PageModel
{
    public void OnGet()
    {
    }

    public IActionResult OnPost(int id)
    {
        if (id == 1)
        {
            //impelement the function of edit
        }
        else if (id == 2)
        {
            //impelement the function of remove
        }

        return Page();
    }
}