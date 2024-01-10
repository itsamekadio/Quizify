using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quizzify.Pages.classes;
using System.Data;

namespace Quizzify.Pages
{
    public class QuizModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string  corectAnswer { set; get; }

        [BindProperty(SupportsGet = true)]
        public string answer { set; get; }

        [BindProperty(SupportsGet = true)]
        public string sanswer { set; get; }

        [BindProperty(SupportsGet = true)]
        public string thanswer { set; get; }

        public DataTable questionstable { get; set; }
        public int score { set; get; }

        static string ConString = @"Data Source=ABDELRAHMAN-ELK;Initial Catalog=yarab1;Integrated Security=True";

        public void OnGet(int currentquizid)
        {
            Room rooms = new Room();

            TempData["quizid"] = currentquizid;

            questionstable = rooms.Getquestions(ConString, currentquizid);
        }

        //public IActionResult OnPostAuth()
        //{
        //    //Room rooms = new Room();

        //    //if (TempData.TryGetValue("quizid", out object tempDataValue) && tempDataValue is int currentquizid)
        //    //{
        //    //    score = rooms.score(ConString, currentquizid,  sanswer, thanswer);
        //    //}
        //    //return RedirectToPage("/Score", new
        //    //{
        //    //    scoreshower = score
        //    //}) ;
        //}
    }
}
