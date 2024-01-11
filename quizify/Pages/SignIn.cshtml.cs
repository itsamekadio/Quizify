using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quizzify.Pages.classes;

namespace Quizzify.Pages;

public class SignInModel : PageModel
{
    private static string ConString = @"Data Source=ABDELRAHMAN-ELK;Initial Catalog=yarab1;Integrated Security=True";
    private SqlConnection con = new(ConString);

    [BindProperty(SupportsGet = true)]
    [Required]
    public string pass { set; get; }

    [BindProperty(SupportsGet = true)]
    [Required]
    public string email { set; get; }

    public string whattotest { get; set; }

    public bool test(string email, string pass)
    {
        con.Open();
        var querystring = "Select  count(*) from AdminData where Email='" + email + "' and AdminPassword='" + pass +
                          "'";
        var cmd1 = new SqlCommand(querystring, con);
        var querystring2 = "Select  count(*) from PlayerData where Email='" + email + "' and playerPassword='" + pass +
                           "'";
        var cmd2 = new SqlCommand(querystring2, con);
        var countplayer = (int)cmd2.ExecuteScalar();
        var countadmin = (int)cmd1.ExecuteScalar();
        if (countadmin > 0)
        {
            con.Close();
            return true;
        }

        if (countplayer > 0)
        {
            con.Close();
            return true;
        }

        con.Close();
        return false;
    }

    public void OnGet()
    {
        Console.WriteLine("testing sign up before trying it to avoid errors");
        if (test("elkad@vbnhjmk.com", "456123"))
            Console.WriteLine("passed");
        else Console.WriteLine("failed");

        if (test("ss", "adfaf"))
            Console.WriteLine("passed");
        else Console.WriteLine("failed");
    }

    public IActionResult OnPost()

    {
        try
        {
            con.Open();
            var querystring = "Select  count(*) from AdminData where Email='" + email + "' and AdminPassword='" + pass +
                              "'";
            var cmd1 = new SqlCommand(querystring, con);

            var countadmin = (int)cmd1.ExecuteScalar();

            var querystring2 = "Select  count(*) from PlayerData where Email='" + email + "' and playerPassword='" +
                               pass + "'";
            var cmd2 = new SqlCommand(querystring2, con);
            var countplayer = (int)cmd2.ExecuteScalar();
            /*string querystring3 = "Select  count(*) from Quiz_Author where Email='" + email + "' and playerPassword='" + pass + "'";
            SqlCommand cmd3 = new SqlCommand(querystring3, con);
            int countauthor = (int)cmd3.ExecuteScalar();*/

            Console.WriteLine(querystring, "        ", querystring2);
            /* Console.WriteLine(querystring3);*/
            if (countadmin > 0)
            {
                var currentadmin = new Admin();


                if (currentadmin.SignIn(ConString, email, pass))
                    return RedirectToPage("/AdminHomePage", new
                    {
                        adminFName = currentadmin.FName,
                        adminlName = currentadmin.LName,
                        adminId = currentadmin.ID,
                        adminemail = currentadmin.Email,
                        adminpass = currentadmin.Password
                    });
            }
            else if (countplayer > 0)
            {
                var currentPlayer = new Player();
                if (currentPlayer.SignIn(ConString, email, pass))
                    return RedirectToPage("/HomePage", new
                    {
                        playerFName = currentPlayer.FName,
                        playerlName = currentPlayer.LName,
                        playerId = currentPlayer.ID,
                        playeremail = currentPlayer.Email,
                        playerpass = currentPlayer.Password
                    });
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            con.Close();
        }

        return RedirectToPage("/SignIn");
    }
}