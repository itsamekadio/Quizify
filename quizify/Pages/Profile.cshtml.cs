using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quizzify.Pages.classes;
using System.Data;

namespace Quizzify.Pages
{
    public class ProfileModel : PageModel
    {
        public string FName { set; get; }
        public int PlayerId { set; get; }
        public string LName { set; get; }
        public string PlayerPass { set; get; }
        public string PlayerEmail { set; get; }
        public DataTable FriendshipTable { get; set; }
        public void OnGet(string playerFName, int playerId, string playerlName, string playerpass, string playeremail)
        {
            // Set the values in the OnGet method
            Console.WriteLine(playerFName);
            TempData["FName"] = playerFName;
            TempData["PlayerId"] = playerId;
            TempData["LName"] = playerlName;
            TempData["PlayerPass"] = playerpass;
            TempData["PlayerEmail"] = playeremail;
            FName = TempData.Peek("FName") as string;
            PlayerId = (int)TempData.Peek("PlayerId");
            LName = TempData.Peek("LName") as string;
            PlayerPass = TempData.Peek("PlayerPass") as string;
            PlayerEmail = TempData.Peek("PlayerEmail") as string;
            Player currentPlayer = new Player();
            string ConString = @"Data Source=ABDELRAHMAN-ELK;Initial Catalog=yarab1;Integrated Security=True";
            int id = currentPlayer.GetIdByEmail(ConString, PlayerEmail);
            FriendshipTable =currentPlayer.GetFriendshipTable(id, ConString);
        }
      
    

    public IActionResult OnPost()
        {
            return RedirectToPage("/SignIn");
        }
           
        }
    }
