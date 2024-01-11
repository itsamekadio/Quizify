using System.Data;
using System.Data.SqlClient;

namespace Quizzify.Pages.classes;

public class Admin
{
    private DataTable AdminData;
    public string FName { set; get; }
    public string LName { set; get; }
    public int ID { set; get; }
    public string Email { set; get; }
    public string Password { set; get; }

    public bool SignUP(string constring, string fname, string lname, string password, string email, string code)
    {
        var con = new SqlConnection(constring);
        try
        {
            con.Open();

            var querystring2 = "Select  count(*) from Authenticationcodes where code='" + code + "'";
            var cmd2 = new SqlCommand(querystring2, con);
            var auth = cmd2.ExecuteNonQuery();
            if (auth > 0)
            {
                var query1 = "INSERT INTO AdminData (First_Name, Last_Name,Email, AdminPassword) VALUES(" + "'" +
                             fname + "'" + ',' + "'" + lname + "'" + "," + "'" + email + "'" + "," + "'" + password +
                             "' )";
                Console.WriteLine(query1);

                FName = fname;
                LName = lname;
                Password = password;
                Email = email;

                var cmd1 = new SqlCommand(query1, con);
                cmd1.ExecuteNonQuery();

                var querySelectId = "select Admin_ID from AdminData where Email='" + email + "';";
                var cmdSelectId = new SqlCommand(querySelectId, con);
                var result = cmdSelectId.ExecuteScalar();
                ID = Convert.ToInt32(result);
                return true;
            }
            else
            {
                return false;
            }
        }


        catch (SqlException ex)
        {
            Console.WriteLine(ex.ToString());
            return false;
        }
        finally
        {
            con.Close();
        }
    }

    public bool SignIn(string ConString, string email, string password)
    {
        var con = new SqlConnection(ConString);
        try
        {
            con.Open();

            var querySelectId = "Select  Admin_ID  from AdminData where Email='" + email + "' and AdminPassword='" +
                                password + "'";
            var cmdSelectId = new SqlCommand(querySelectId, con);
            var result = cmdSelectId.ExecuteScalar();
            ID = Convert.ToInt32(result);
            Email = email;
            Password = password;
            var queryselectfname = "Select  First_Name  from AdminData where Email='" + email +
                                   "' and AdminPassword='" + password + "'";
            var cmdfname = new SqlCommand(queryselectfname, con);
            var result2 = cmdfname.ExecuteScalar();
            FName = result2.ToString();
            var queryselectlname = "Select  Last_Name  from AdminData where Email='" + email + "' and AdminPassword='" +
                                   password + "'";
            var cmdlname = new SqlCommand(queryselectfname, con);
            var result3 = cmdlname.ExecuteScalar();
            LName = result3.ToString();
            return true;
        }


        catch (SqlException ex)
        {
            Console.WriteLine(ex.ToString());
            return false;
        }
        finally
        {
            con.Close();
        }
    }

    public void SignOut()
    {
    }

    public void DeleteQuiz(int QuizID)
    {
    }

    public void DeleteRoom(int RoomID)
    {
    }

    public void DeletePost(int PostID)
    {
    }

    public void DeleteComment(int CommentID)
    {
    }

    public void DeleteQuestion()
    {
    }

    public void CreateRoom()
    {
    }

    public void CreatePost()
    {
    }

    public DataTable GetReports(string TableName)
    {
        var dt = new DataTable();
        var querystring = "select * from " + TableName;
        return dt;
    }

    public DataTable GetPermissions(string TableName)
    {
        var dt = new DataTable();
        var querystring = "select * from " + TableName;
        return dt;
    }
}