using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagement
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkUsername()) Response.Write("<script>alert('Username already exists, try another.');</script>");
            else CreateNewMember();
        }

        //check if username exists
        bool checkUsername()
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM member_tbl WHERE member_id='" + Username.Text.Trim() + "';", con);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable table = new DataTable();

                adapter.Fill(table);

                if (table.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }


        //create new member
        void CreateNewMember()
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO member_tbl(member_id, full_name, email, birthdate, state, city, zipcode, address, password, phone_number)" +
                    "values(@member_id, @full_name, @email, @birthdate, @state, @city, @zipcode, @address, @password, @phone_number)", con);

                cmd.Parameters.AddWithValue("@full_name", FullName.Text.Trim());
                cmd.Parameters.AddWithValue("@email", Email.Text.Trim());
                cmd.Parameters.AddWithValue("@birthdate", DOB.Text.Trim());
                cmd.Parameters.AddWithValue("@state", StateList.Text.Trim());
                cmd.Parameters.AddWithValue("@city", City.Text.Trim());
                cmd.Parameters.AddWithValue("@zipcode", Zipcode.Text.Trim());
                cmd.Parameters.AddWithValue("@address", Address.Text.Trim());
                cmd.Parameters.AddWithValue("@member_id", Username.Text.Trim());
                cmd.Parameters.AddWithValue("@password", Password.Text.Trim());
                cmd.Parameters.AddWithValue("@phone_number", PhoneNum.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Sign Up Successful!');</script>");
                Response.Redirect("HomePage.aspx");

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
}
    }
}