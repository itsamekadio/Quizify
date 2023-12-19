using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace Quizzify.Pages
{
    public class SignUpPlayerModel : PageModel
    {


        [BindProperty(SupportsGet = true)]
        [Required]
        [MinLength(3, ErrorMessage = "please enter a valid name at least 3 letters")]
        [MaxLength(15, ErrorMessage = "can't fit")]
        public string fname { set; get; }
        public bool move = false;
        [BindProperty(SupportsGet = true)]
        [Required]
        [MinLength(3, ErrorMessage = "please enter a valid name at least 3 letters")]
        [MaxLength(15, ErrorMessage = "can't fit")]
        public string lname { set; get; }
        [BindProperty(SupportsGet = true)]

        public string email { set; get; }
        [BindProperty(SupportsGet = true)]

        public string password { set; get; }
        [BindProperty(SupportsGet = true)]

        [Compare(nameof(password), ErrorMessage = "should be the same as the pass")]

        public string passdup { set; get; }

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
                string query1 = "INSERT INTO PlayerData (First_Name, Last_Name,Email, playerPassword) VALUES(" + "'" + fname + "'" + ',' + "'" + lname + "'" + "," + "'" + email + "'" + "," + "'" + password + "' )";
                Console.WriteLine(query1);
                con.Open();
                if (ModelState.IsValid)
                {
                    SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.ExecuteNonQuery();
                    /* SqlCommand cmd2 = new SqlCommand(query2, con);
                     cmd2.ExecuteNonQuery();*/
                    move = true;
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                return RedirectToPage("SignUpplayer");
            }
            finally
            {
                con.Close();
                

              
            }

            if (true)
                return RedirectToPage("/HomePage");

        }
        public IActionResult OnPostMove()
        {
            Console.WriteLine(move);
         if (move) return RedirectToPage("/HomePage");
            else
            {
                return RedirectToPage();
            }
        }
    }
}
