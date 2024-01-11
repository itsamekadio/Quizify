using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Quizzify.Pages;

public class FriendsModel : PageModel
{
    public string FName { set; get; }
    public int PlayerId { set; get; }
    public string LName { set; get; }
    public string PlayerPass { set; get; }
    public string PlayerEmail { set; get; }

    public void OnGet(string playerFName, int playerId, string playerlName, string playerpass, string playeremail)
    {
        TempData["FName"] = playerFName;
        TempData["PlayerId"] = playerId;
        TempData["LName"] = playerlName;
        TempData["PlayerPass"] = playerpass;
        TempData["PlayerEmail"] = playeremail;
    }
}