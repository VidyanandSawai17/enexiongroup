using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
namespace enexiongroup.Models
{
        
    public class StudentLog
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public StudentLog(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("SqlConnection"));
        }

        public int UserDetails(Login prod)
        {
            int result = 0;
            string qry = "insert into login values(@name,@DOB,@email,@gender,@langauge)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", prod.Name);
            cmd.Parameters.AddWithValue("@DOB", prod.DOB);
            cmd.Parameters.AddWithValue("@email", prod.Email);
            cmd.Parameters.AddWithValue("@gender", prod.Gender);
            cmd.Parameters.AddWithValue("@langauge", prod.Language);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }


        public List<Login> UserList()
        {
            List<Login> list = new List<Login>();
            string str = "select * from Login";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Login l = new Login();
                    l.Name = dr["name"].ToString();
                    l.DOB = Convert.ToDateTime(dr["DOB"]);
                    l.Gender = dr["gender"].ToString();
                    l.Email = dr["email"].ToString();
                    l.Language = dr["language"].ToString();
                    list.Add(l);
                }
            }
            con.Close();
            return list;
        }
    }
}

