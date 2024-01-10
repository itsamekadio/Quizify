using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quizzify.Pages.classes;
using System.Data;

namespace Quizzify.Pages
{
    public class RoomModel : PageModel
    {
        public DataTable quizes { get; set; }
        public void OnGet(int currentroomid)
        {
            Room rooms = new Room();
            string ConString = @"Data Source=ABDELRAHMAN-ELK;Initial Catalog=yarab1;Integrated Security=True";


            quizes = rooms.GetQuizes(ConString, currentroomid);
        }
        public IActionResult OnPostJoinquiz(int RoomId, string Action)
        {
            if (Action.StartsWith("Joinquiz_"))
            {
                // Extract the Room ID from the Action value
                string roomIdStr = Action.Substring("Joinquiz_".Length);
                if (int.TryParse(roomIdStr, out int clickedquizId))
                {

                    return RedirectToPage("Quiz", new
                    {
                        currentquizid = clickedquizId
                    });

                }

                // Handle other cases or errors
                return Page();
            }
            else return Page();

        }
        public IActionResult OnPostJoinstream()
        {
            return RedirectToPage("/posts");
        }
    }
}
    
