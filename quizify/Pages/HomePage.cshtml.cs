using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace Quizzify.Pages
{
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
            string playerEmail = TempData["PlayerEmail"] as string;
            string fName = TempData["FName"] as string;
            string lName = TempData["LName"] as string;
            string playerPass = TempData["PlayerPass"] as string;

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
            string playerEmail = TempData["PlayerEmail"] as string;
            string fName = TempData["FName"] as string;
            string lName = TempData["LName"] as string;
            string playerPass = TempData["PlayerPass"] as string;





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
}
