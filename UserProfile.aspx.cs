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

    public partial class WebForm6 : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"].ToString() == "" || Session["username"] == null)
                {
                    Response.Write("<script>alert('Session Expired Login Again');</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                    getUserBookData();
                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("userlogin.aspx");
            }
        }
        /*
        protected void Button1_Click(object sender, EventArgs e)
        {
            CheckPasswords();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE member_tbl (full_name=@full_name, email=@email, birthdate=@birthdate, state=@state, city=@city, zipcode=@zipcode, address=@address, phone_number=@phone_number)", con);

                cmd.Parameters.AddWithValue("@full_name", FullName.Text.Trim());
                cmd.Parameters.AddWithValue("@email", Email.Text.Trim());
                cmd.Parameters.AddWithValue("@birthdate", DOB.Text.Trim());
                cmd.Parameters.AddWithValue("@state", StateList.Text.Trim());
                cmd.Parameters.AddWithValue("@city", City.Text.Trim());
                cmd.Parameters.AddWithValue("@zipcode", Zipcode.Text.Trim());
                cmd.Parameters.AddWithValue("@address", Address.Text.Trim());
                cmd.Parameters.AddWithValue("@phone_number", PhoneNum.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Update Successful');</script>");
                GridView1.DataBind();


            }
            catch
            {
                Response.Write("<script>alert('something went wrong');</script>");
            }
        }

        void CheckPasswords()
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                if (OldPassword.Text.Equals(NewPassword.Text))
                {
                    Response.Write("<script>alert('Passwords Cannot be the same');</script>");
                }
                else
                {

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    if (con.State == ConnectionState.Closed) { con.Open(); }



                    SqlCommand cmd = new SqlCommand("UPDATE member_tbl (member_id=@member_id, full_name=@full_name, email=@email, birthdate=@birthdate, state=@state, city=@city, zipcode=@zipcode, address=@address, password=@new_password, phone_number=@phone_number)", con);

                    cmd.Parameters.AddWithValue("@full_name", FullName.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", Email.Text.Trim());
                    cmd.Parameters.AddWithValue("@birthdate", DOB.Text.Trim());
                    cmd.Parameters.AddWithValue("@state", StateList.Text.Trim());
                    cmd.Parameters.AddWithValue("@city", City.Text.Trim());
                    cmd.Parameters.AddWithValue("@zipcode", Zipcode.Text.Trim());
                    cmd.Parameters.AddWithValue("@address", Address.Text.Trim());
                    cmd.Parameters.AddWithValue("@member_id", Username.Text.Trim());
                    cmd.Parameters.AddWithValue("@new_password", NewPassword.Text.Trim());
                    cmd.Parameters.AddWithValue("@phone_number", PhoneNum.Text.Trim());

                    cmd.ExecuteNonQuery();
                    con.Close();

                    Response.Write("<script>alert('Update Successful');</script>");
                    GridView1.DataBind();
                }

            }
            catch
            {
                Response.Write("<script>alert('old password incorrect');</script>");
            }
        }
        */

        void getUserBookData()
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from borrower_tbl where member_id='" + Session["username"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        
    }
}