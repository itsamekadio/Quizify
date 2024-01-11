using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Quizzify.Pages;

public class AdminRequestModel : PageModel
{
    public void OnGet()
    {
    }

    public IActionResult OnPost(int id)
    {
        if (id == 1)
        {
            //implement function of add button
        }

        if (id == 2)
        {
            //implement function of remove button
        }

        return Page();
    }
}