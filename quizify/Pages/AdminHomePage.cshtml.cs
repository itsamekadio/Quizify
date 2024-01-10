using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Quizzify.Pages
{
    public class AdminHomePageModel : PageModel
    {
        public void OnGet(string adminFName, int adminId, string adminlName, string adminpass, string adminemail)
        {

            Console.WriteLine(adminFName,adminFName,adminId);
        }
    }
}
