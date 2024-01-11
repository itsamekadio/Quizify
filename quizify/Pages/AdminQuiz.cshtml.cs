using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Quizzify.Pages;

public class AdminQuizModel : PageModel
{
    public void OnGet()
    {
    }

    public void OnPost(int id)
    {
        if (id == 1)
        {
            //impelement the function of previous button
        }
        else if (id == 2)
        {
            //impelement the function of next button
        }
        else if (id == 3)
        {
            //impelement the function of Edit button
        }
        else if (id == 4)
        {
            //impelement the function of Remove button
        }
        else if (id == 5)
        {
            //impelement the function of Done button
        }
    }
}