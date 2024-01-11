using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Quizzify.Pages;

public class SignUpAuthorModel : PageModel
{
    private static string ConString = @"Data Source=ABDELRAHMAN-ELK;Initial Catalog=please;Integrated Security=True";
    private SqlConnection con = new(ConString);

    [BindProperty(SupportsGet = true)]
    [MinLength(3, ErrorMessage = "please enter a valid name at least 3 letters")]
    public string fname { set; get; }

    [BindProperty(SupportsGet = true)]
    [MinLength(3, ErrorMessage = "please enter a valid name at least 3 letters")]
    public string lname { set; get; }

    [BindProperty(SupportsGet = true)] public string email { set; get; }

    [BindProperty(SupportsGet = true)] public string password { set; get; }

    [BindProperty(SupportsGet = true)]
    [Compare(nameof(password), ErrorMessage = "should be the same as the pass")]
    public string passdup { set; get; }

    /* string query2 = "INSERT INTO AdminData (Admin_ID, Authentication_code) VALUES(202201023,10000)";*/
    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        try
        {
            if (ModelState.IsValid)
            {
                var query1 = "INSERT INTO AdminData (First_Name, Last_Name,Email, playerPassword) VALUES(" + "'" +
                             fname + "'" + ',' + "'" + lname + "'" + "," + "'" + email + "'" + "," + "'" + password +
                             "' )";
                Console.WriteLine(query1);
                con.Open();
                var cmd1 = new SqlCommand(query1, con);
                cmd1.ExecuteNonQuery();
                /* SqlCommand cmd2 = new SqlCommand(query2, con);
                 cmd2.ExecuteNonQuery();*/
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


        return RedirectToPage("/AdminHomePage");
    }
}