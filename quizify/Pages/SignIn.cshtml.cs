using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Quizzify.Pages
{
    public class SignInModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        [Required]
        public string pass { set; get; }
        [BindProperty(SupportsGet = true)]
        [Required]
        public string email { set; get; }

      
        static string ConString = @"Data Source=ABDELRAHMAN-ELK;Initial Catalog=yarab1;Integrated Security=True";
        SqlConnection con = new SqlConnection(ConString);

        public void OnGet()
        {
        }
        public IActionResult OnPost()

        {
            try
            { con.Open();
                string querystring = "Select  count(*) from AdminData where Email='" +email + "' and AdminPassword='"+pass+"'";
                SqlCommand cmd1 = new SqlCommand(querystring, con);
                int countadmin = (int)cmd1.ExecuteScalar();
                Console.WriteLine(querystring);
                Console.WriteLine(countadmin);
                string querystring2 = "Select  count(*) from PlayerData where Email='" + email + "' and playerPassword='" + pass + "'";
                SqlCommand cmd2 = new SqlCommand(querystring2, con);
                int countplayer = (int)cmd2.ExecuteScalar();
                Console.WriteLine(countplayer);
                Console.WriteLine(querystring2);
                if (countadmin > 0)
                {
                   return RedirectToPage("/AdminHomePage");


                }
                else if (countplayer > 0)
                {
                    return RedirectToPage("/HomePage");

                }
                else
                {
                    return RedirectToPage("/SignIn");

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
}
