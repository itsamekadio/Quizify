using System.Data;
using System.Data.SqlClient;

namespace Quizzify.Pages.classes
{
    public class Room
    {
        private DataTable RoomData;
        public int RoomID { get; set; }
        public DataTable GetRooms(string constring)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection(constring);
            try
            {
                con.Open();
                string querystring = "\tSELECT Name, Admin_ID, Description, Capacity,Room_ID FROM Rooms;";
                SqlCommand cmd = new SqlCommand(querystring, con);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                Console.WriteLine(querystring);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                con.Close();
            }

            return dt;
        }
      
       public int score(string constring, int quizid,string a1,string a2,string a3)
        {
            int scoree = 0;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                con.Open();
                string querystring = "Select  count(*) from Questionzz where Answer='" + a1+ "' and Quiz_ID="+quizid;
                SqlCommand cmd = new SqlCommand(querystring, con);
                int checker = (int)cmd.ExecuteScalar();
                if (checker > 0) scoree++;
                string querystring2 = "Select  count(*) from Questionzz where Answer='" + a2 + "' and Quiz_ID=" + quizid;
                SqlCommand cmd2= new SqlCommand(querystring, con);
                checker = (int)cmd2.ExecuteScalar();
                if (checker > 0) scoree++;
                string querystrin3 = "Select  count(*) from Questionzz where Answer='" + a3 + "' and Quiz_ID=" + quizid;
                SqlCommand cmd3 = new SqlCommand(querystring, con);
                checker = (int)cmd3.ExecuteScalar();
                if (checker > 0) scoree++;

                Console.WriteLine(querystring);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                con.Close();
            }

            return scoree;
        }
        public DataTable GetPosts(string TableName)
        {
            DataTable dt = new DataTable();
            string querystring = "select * from " + TableName;
            return dt;
        }
        public DataTable GetRequests(string TableName)
        {
            DataTable dt = new DataTable();
            string querystring = "select * from " + TableName;
            return dt;
        }
        public DataTable GetComments(string TableName)
        {
            DataTable dt = new DataTable();
            string querystring = "select * from " + TableName;
            return dt;
        }
      
        public DataTable GetQuizes(string constring,int roomid)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection(constring);
            try
            {
                con.Open();
                string querystring = "SELECT Quiz_ID, Title, Quiz_Descreption FROM Quizze WHERE Room_ID = "+ roomid;
                SqlCommand cmd = new SqlCommand(querystring, con);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                Console.WriteLine(querystring);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                con.Close();
            }

            return dt;
        }
        public DataTable Getquestions(string constring, int quizid)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection(constring);
            try
            {
                con.Open();
                string querystring = "  select Quiz_ID,Question_ID,Question_Content,Option_A,Option_B,Option_C,Option_D,Answer from Questionzz where Quiz_ID= " + quizid;
                SqlCommand cmd = new SqlCommand(querystring, con);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                Console.WriteLine(querystring);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                con.Close();
            }

            return dt;
        }
        public DataTable GetPlayers(string TableName)
        {
                DataTable dt = new DataTable();
                string querystring = "select * from " + TableName;
                return dt;
        }
        public DataTable GetLeaderBoard(string TableName)
        {
            DataTable dt = new DataTable();
            string querystring = "select * from " + TableName;
            return dt;
        }
    }
}
