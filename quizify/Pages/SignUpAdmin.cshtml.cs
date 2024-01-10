using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quizzify.Pages.classes;
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
        Admin currentadmin = new Admin();

        /* string query2 = "INSERT INTO AdminData (Admin_ID, Authentication_code) VALUES(202201023,10000)";*/
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // Initialize currentPlayer inside the OnPost method


                if (currentadmin.SignUP(ConString, fname, lname, password, email,authcode))
                {
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

            return RedirectToPage("/SignUpAdmin");

        }

    }
}