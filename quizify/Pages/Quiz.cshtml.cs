using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Net.Mime.MediaTypeNames;

namespace Quizzify.Pages
{
    public class QuizModel : PageModel
    {
        public void OnGet()
        {
        }
        public void OnPost( int id)
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
                //impelement the function of submit button
            }
        }

        }
    }
