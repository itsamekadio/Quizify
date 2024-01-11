using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quizzify.Pages.classes;

namespace Quizzify.Pages;

public class RoomModel : PageModel
{
    public DataTable quizes { get; set; }

    public void OnGet(int currentroomid)
    {
        var rooms = new Room();
        var ConString = @"Data Source=ABDELRAHMAN-ELK;Initial Catalog=yarab1;Integrated Security=True";


        quizes = rooms.GetQuizes(ConString, currentroomid);
    }

    public IActionResult OnPostJoinquiz(int RoomId, string Action)
    {
        if (Action.StartsWith("Joinquiz_"))
        {
            // Extract the Room ID from the Action value
            var roomIdStr = Action.Substring("Joinquiz_".Length);
            if (int.TryParse(roomIdStr, out var clickedquizId))
                return RedirectToPage("Quiz", new
                {
                    currentquizid = clickedquizId
                });

            // Handle other cases or errors
            return Page();
        }

        return Page();
    }

    public IActionResult OnPostJoinstream()
    {
        return RedirectToPage("/posts");
    }
}