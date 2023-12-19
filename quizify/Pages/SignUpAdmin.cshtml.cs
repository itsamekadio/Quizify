using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
namespace Quizzify.Pages
{
    public class SignUpAdminModel : PageModel
    {
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


        static string ConString = @"Data Source=ABDELRAHMAN-ELK;Initial Catalog=yarab1;Integrated Security=True";
        SqlConnection con = new SqlConnection(ConString);

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
                    con.Open();
                    string querystring = "Select  count(*) from Authenticationcodes where code='" + authcode + "'";
                    SqlCommand cmd = new SqlCommand(querystring, con);
                    int count = (int)cmd.ExecuteScalar();
                    Console.WriteLine(count);
                    if (count > 0)
                    {
                        string query1 = "INSERT INTO AdminData (First_Name, Last_Name,Email, AdminPassword) VALUES(" + "'" + fname + "'" + ',' + "'" + lname + "'" + "," + "'" + email + "'" + "," + "'" + password + "' )";
                        Console.WriteLine(query1);

                        SqlCommand cmd1 = new SqlCommand(query1, con);
                        cmd1.ExecuteNonQuery();
                        /* SqlCommand cmd2 = new SqlCommand(query2, con);
                         cmd2.ExecuteNonQuery();*/
                    }
                    else
                    {
                        return RedirectToPage();
                    }

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
}