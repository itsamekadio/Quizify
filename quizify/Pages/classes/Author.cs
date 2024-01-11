using System.Data;

namespace Quizzify.Pages.classes;

public class Author
{
    private DataTable AuthorData;
    public string FName { set; get; }
    public string LName { set; get; }
    public int ID { set; get; }
    public string Email { set; get; }
    public string Password { set; get; }
    public string category { set; get; }

    public bool SignUP()
    {
        return false;
    }

    public void SignIn()
    {
    }

    public void SignOut()
    {
    }

    public void CreateQuiz()
    {
    }

    public void AddQuestion()
    {
    }

    public void EditeQuestion(int QuestionID)
    {
    }

    public void DeleteQuestion(int QuestionID)
    {
    }

    public void DeletePost(int PostID)
    {
    }

    public void DeleteComment(int CommentID)
    {
    }
}