using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Quizzify.Pages
{
    public class AuthorQuizModel : PageModel
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
                //impelement the function of done button
            }
        }
    }
}
