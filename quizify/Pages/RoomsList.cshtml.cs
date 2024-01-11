using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quizzify.Pages.classes;

namespace Quizzify.Pages;

public class RoomsModel : PageModel
{
    public DataTable roomstable { get; set; }

    public void OnGet()
    {
        var rooms = new Room();
        var ConString = @"Data Source=ABDELRAHMAN-ELK;Initial Catalog=yarab1;Integrated Security=True";

        roomstable = rooms.GetRooms(ConString);
    }

    public IActionResult OnPostJoinRoom(int RoomId, string Action)
    {
        if (Action.StartsWith("JoinRoom_"))
        {
            // Extract the Room ID from the Action value
            var roomIdStr = Action.Substring("JoinRoom_".Length);
            if (int.TryParse(roomIdStr, out var clickedRoomId))
                return RedirectToPage("/Room", new
                {
                    currentroomid = clickedRoomId
                });

            // Handle other cases or errors
            return Page();
        }

        return Page();
    }
}