using System.Data;
using System.Data.SqlClient;

namespace Quizzify.Pages.classes
{
    public class Admin
    {
        private DataTable AdminData;
        public string FName { set; get; }
        public string LName { set; get; }
        public int ID { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public bool SignUP(string constring, string fname, string lname, string password, string email,string code)
        {

            SqlConnection con = new SqlConnection(constring);
            try
            {con.Open();
               
                string querystring2 = "Select  count(*) from Authenticationcodes where code='" + code+"'";
                SqlCommand cmd2 = new SqlCommand(querystring2, con);
                int auth=cmd2.ExecuteNonQuery();
                if (auth>0)
                {
                    string query1 = "INSERT INTO AdminData (First_Name, Last_Name,Email, AdminPassword) VALUES(" + "'" + fname + "'" + ',' + "'" + lname + "'" + "," + "'" + email + "'" + "," + "'" + password + "' )";
                    Console.WriteLine(query1);

                    FName = fname;
                    LName = lname; Password = password; Email = email;

                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    cmd1.ExecuteNonQuery();

                    string querySelectId = "select Admin_ID from AdminData where Email='" + email + "';";
                    SqlCommand cmdSelectId = new SqlCommand(querySelectId, con);
                    object result = cmdSelectId.ExecuteScalar();
                    ID = Convert.ToInt32(result);
                    return true;
                }
                else return false;

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
            SqlConnection con = new SqlConnection(ConString);
            try
            {
                con.Open();

                string querySelectId = "Select  Admin_ID  from AdminData where Email='" + email + "' and AdminPassword='" + password + "'";
                SqlCommand cmdSelectId = new SqlCommand(querySelectId, con);
                object result = cmdSelectId.ExecuteScalar();
                ID = Convert.ToInt32(result);
                Email = email; Password = password;
                string queryselectfname = "Select  First_Name  from AdminData where Email='" + email + "' and AdminPassword='" + password + "'";
                SqlCommand cmdfname = new SqlCommand(queryselectfname, con);
                object result2 = cmdfname.ExecuteScalar();
                FName = result2.ToString();
                string queryselectlname = "Select  Last_Name  from AdminData where Email='" + email + "' and AdminPassword='" + password + "'";
                SqlCommand cmdlname = new SqlCommand(queryselectfname, con);
                object result3 = cmdlname.ExecuteScalar();
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
        public void SignOut() { }
        public void DeleteQuiz(int QuizID) { }
        public void DeleteRoom(int RoomID) { }
        public void DeletePost(int PostID) { }
        public void DeleteComment(int CommentID) { }
        public void DeleteQuestion() { }
        public void CreateRoom() { }
        public void CreatePost() { }
   
        public DataTable GetReports(string TableName)
        {
            DataTable dt = new DataTable();
            string querystring = "select * from " + TableName;
            return dt;
        }
        public DataTable GetPermissions(string TableName)
        {
            DataTable dt = new DataTable();
            string querystring = "select * from " + TableName;
            return dt;
        }

    }
}
