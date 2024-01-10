using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quizzify.Pages.classes;
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
        {        }
        public IActionResult OnPost()

        {
            try
            { con.Open();
                string querystring = "Select  count(*) from AdminData where Email='" +email + "' and AdminPassword='"+pass+"'";
                SqlCommand cmd1 = new SqlCommand(querystring, con);
                
                int countadmin = (int)cmd1.ExecuteScalar();
               
                string querystring2 = "Select  count(*) from PlayerData where Email='" + email + "' and playerPassword='" + pass + "'";
                SqlCommand cmd2 = new SqlCommand(querystring2, con);
                int countplayer = (int)cmd2.ExecuteScalar();
                /*string querystring3 = "Select  count(*) from Quiz_Author where Email='" + email + "' and playerPassword='" + pass + "'";
                SqlCommand cmd3 = new SqlCommand(querystring3, con);
                int countauthor = (int)cmd3.ExecuteScalar();*/

                Console.WriteLine(querystring, "        ", querystring2);
               /* Console.WriteLine(querystring3);*/
                if (countadmin > 0)
                {
                    Admin currentadmin = new Admin();
                   
                   
                    if (currentadmin.SignIn(ConString,email,pass)) {
                        return RedirectToPage("/AdminHomePage", new
                        {
                            adminFName = currentadmin.FName,
                            adminlName = currentadmin.LName,
                            adminId = currentadmin.ID,
                            adminemail = currentadmin.Email,
                            adminpass = currentadmin.Password
                        });

                    }


                }
                else if (countplayer > 0)
                {
                    Player currentPlayer = new Player();
                    if (currentPlayer.SignIn(ConString,email,pass)) {
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
               /* else if(countauthor>0)
                {
                    return RedirectToPage("/SignIn");

                }*/



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
