using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Quizzify.Pages;

public class HomePageModel : PageModel
{
    // Declare properties to store values
    public string FName { set; get; }
    public int PlayerId { set; get; }
    public string LName { set; get; }
    public string PlayerPass { set; get; }
    public string PlayerEmail { set; get; }

    public void OnGet(string playerFName, int playerId, string playerlName, string playerpass, string playeremail)
    {
        // Set the values in the OnGet method
        TempData["FName"] = playerFName;
        TempData["PlayerId"] = playerId;
        TempData["LName"] = playerlName;
        TempData["PlayerPass"] = playerpass;
        TempData["PlayerEmail"] = playeremail;
        Console.WriteLine(playeremail);
    }

    public IActionResult OnPostRooms()
    {
        // Access the values in OnPostRooms
        var playerEmail = TempData["PlayerEmail"] as string;
        var fName = TempData["FName"] as string;
        var lName = TempData["LName"] as string;
        var playerPass = TempData["PlayerPass"] as string;

        // Your existing logic
        return RedirectToPage("/RoomsList", new
        {
            playerFName = fName,
            playerlName = lName,
            playeremail = playerEmail,
            playerpass = playerPass
        });
    }

    public IActionResult OnPostProfile()
    {
        // Access the values in OnPostProfile
        var playerEmail = TempData["PlayerEmail"] as string;
        var fName = TempData["FName"] as string;
        var lName = TempData["LName"] as string;
        var playerPass = TempData["PlayerPass"] as string;


        // Your existing logic
        return RedirectToPage("/Profile", new
        {
            playerFName = fName,
            playerlName = lName,
            playeremail = playerEmail,
            playerpass = playerPass
        });
    }
}