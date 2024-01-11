using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quizzify.Pages.classes;

namespace Quizzify.Pages;

public class SignUpAdminModel : PageModel
{
    private static string ConString = @"Data Source=ABDELRAHMAN-ELK;Initial Catalog=yarab1;Integrated Security=True";
    private SqlConnection con = new(ConString);
    private Admin currentadmin = new();

    [BindProperty(SupportsGet = true)]
    [Required]
    [MinLength(3, ErrorMessage = "please enter a valid name at least 3 letters")]
    public string fname { set; get; }

    [BindProperty(SupportsGet = true)]
    [Required]
    [MinLength(3, ErrorMessage = "please enter a valid name at least 3 letters")]
    public string lname { set; get; }

    [BindProperty(SupportsGet = true)]
    [Required]
    public string email { set; get; }

    [BindProperty(SupportsGet = true)]
    [Required]
    public string password { set; get; }

    [BindProperty(SupportsGet = true)]
    [Required]
    [Compare(nameof(password), ErrorMessage = "should be the same as the pass")]

    public string passdup { set; get; }

    [BindProperty(SupportsGet = true)]
    [Required]
    public string authcode { set; get; }

    public bool test(string code)
    {
        con.Open();
        var querystring = "Select  count(*) from Authenticationcodes where code='" + code + "'";
        var cmd1 = new SqlCommand(querystring, con);


        var countcode = (int)cmd1.ExecuteScalar();
        if (countcode > 0)
        {
            con.Close();
            return true;
        }

        con.Close();
        return false;
    }

    /* string query2 = "INSERT INTO AdminData (Admin_ID, Authentication_code) VALUES(202201023,10000)";*/
    public void OnGet()
    {
        Console.WriteLine("testing sign IN FOR ADMINS before trying it to avoid errors");
        if (test("bc"))
            Console.WriteLine("passed");
        else Console.WriteLine("failed");

        if (test("adfaf"))
            Console.WriteLine("passed");
        else Console.WriteLine("failed");
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
            // Initialize currentPlayer inside the OnPost method
            if (currentadmin.SignUP(ConString, fname, lname, password, email, authcode))
                return RedirectToPage("/AdminHomePage", new
                {
                    adminFName = currentadmin.FName,
                    adminlName = currentadmin.LName,
                    adminId = currentadmin.ID,
                    adminemail = currentadmin.Email,
                    adminpass = currentadmin.Password
                });

        return RedirectToPage("/SignUpAdmin");
    }
}