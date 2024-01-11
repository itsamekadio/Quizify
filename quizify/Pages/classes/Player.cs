using System.Data;
using System.Data.SqlClient;

namespace Quizzify.Pages.classes;

public class Player
{
    private DataTable PlayerData;

    public Player()
    {
        // Initialize properties with default values
        PlayerData = new DataTable();
        FName = null;
        LName = null;
        ID = 0;
        Email = null;
        Password = null;
        Rank = 0;
    }

    public string FName { set; get; }
    public string LName { set; get; }
    public int ID { set; get; }
    public string Email { set; get; }
    public string Password { set; get; }
    public int Rank { set; get; }

    public bool SignUP(string constring, string fname, string lname, string password, string email)
    {
        var con = new SqlConnection(constring);
        try
        {
            var query1 = "INSERT INTO PlayerData (First_Name, Last_Name,Email, playerPassword) VALUES(" + "'" + fname +
                         "'" + ',' + "'" + lname + "'" + "," + "'" + email + "'" + "," + "'" + password + "' )";
            Console.WriteLine(query1);
            con.Open();
            FName = fname;
            LName = lname;
            Password = password;
            Email = email;

            var cmd1 = new SqlCommand(query1, con);
            cmd1.ExecuteNonQuery();
            var querySelectId = "select Player_ID from PlayerData where Email='" + email + "';";
            var cmdSelectId = new SqlCommand(querySelectId, con);
            var result = cmdSelectId.ExecuteScalar();
            ID = Convert.ToInt32(result);
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

    public DataTable GetFriendshipTable(int playerId, string constring)
    {
        var dt = new DataTable();
        var con = new SqlConnection(constring); // Assuming ConString is a class variable

        try
        {
            con.Open();
            var query = @"
            SELECT Friend.First_Name AS Friend_First_Name, Friend.Last_Name AS Friend_Last_Name, Friend.Email AS Friend_Email
            FROM Is_Friend
            JOIN PlayerData AS Player ON Is_Friend.Player_ID = Player.Player_ID
            JOIN PlayerData AS Friend ON Is_Friend.Frien_Player_ID = Friend.Player_ID
            WHERE Player.Player_ID = " + playerId;

            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@PlayerId", playerId);

            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            Console.WriteLine(query);
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

    public bool SignIn(string ConString, string email, string password)
    {
        var con = new SqlConnection(ConString);
        try
        {
            con.Open();

            var querySelectId = "Select  Player_ID  from PlayerData where Email='" + email + "' and playerPassword='" +
                                password + "'";
            var cmdSelectId = new SqlCommand(querySelectId, con);
            var result = cmdSelectId.ExecuteScalar();
            ID = Convert.ToInt32(result);
            Email = email;
            Password = password;
            var queryselectfname = "Select  First_Name  from PlayerData where Email='" + email +
                                   "' and playerPassword='" + password + "'";
            var cmdfname = new SqlCommand(queryselectfname, con);
            var result2 = cmdfname.ExecuteScalar();
            FName = result2.ToString();
            var queryselectlname = "Select  Last_Name  from PlayerData where Email='" + email +
                                   "' and playerPassword='" + password + "'";
            var cmdlname = new SqlCommand(queryselectlname, con);
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

    public int GetIdByEmail(string constring, string email)
    {
        var con = new SqlConnection(constring);
        try
        {
            con.Open();
            var querySelectId = "SELECT Player_ID FROM PlayerData WHERE Email = '" + email + "'";
            var cmdSelectId = new SqlCommand(querySelectId, con);
            var result = cmdSelectId.ExecuteScalar();

            if (result != null)
                return Convert.ToInt32(result);
            else
                // Return a default or special value indicating that the email doesn't exist
                return -1; // For example, you can choose -1 as a special value
        }
        catch (SqlException ex)
        {
            Console.WriteLine(ex.ToString());
            // Return a default or special value indicating an error
            return -1;
        }
        finally
        {
            con.Close();
        }
    }

    public DataTable GetFriends(string TableName)
    {
        var dt = new DataTable();
        var querystring = "select * from " + TableName;
        return dt;
    }

    public DataTable GetScores(string TableName)
    {
        var dt = new DataTable();
        var querystring = "select * from " + TableName;
        return dt;
    }
}