using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using Quizzify.Pages.classes;

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
        Player currentPlayer = new Player();


        static string ConString = @"Data Source=ABDELRAHMAN-ELK;Initial Catalog=yarab1;Integrated Security=True";


        
        public void OnGet()
        {
        }              
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // Initialize currentPlayer inside the OnPost method
              

                if (currentPlayer.SignUP(ConString,fname,lname,password,email))
                {
                    return RedirectToPage("/HomePage", new { playerFName = currentPlayer.FName,
                                                             playerlName = currentPlayer.LName,
                                                             playerId = currentPlayer.ID,
                                                             playeremail = currentPlayer.Email,
                                                             playerpass = currentPlayer.Password });


                    
                }
            }

            // Handle ModelState.IsValid is false or SignUP returns false
            return RedirectToPage();
        }
    }
}