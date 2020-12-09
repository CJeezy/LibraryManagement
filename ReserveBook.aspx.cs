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
    public partial class ReserveBook : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ReturnButton_Click(object sender, EventArgs e)
        {
            if (CheckBook() && CheckUser())
            {

                if (CheckIssuedBooks())
                {
                    ReturnBook();
                }
                else
                {
                    Response.Write("<script>alert('This Entry does not exist');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Wrong Book ID or Member ID');</script>");
            }
        }

        protected void ReserveButton_Click(object sender, EventArgs e)
        {

            if (CheckBook() && CheckUser())
            {
                if (CheckIssuedBooks())
                {
                    Response.Write("<script>alert('Book is already checked out by this user');</script>");
                }
                else
                {
                    IssueBook();
                }
            }
            else
            {
                Response.Write("<script>alert('Wrong Book ID or Member ID');</script>");
            }
        }

        void IssueBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO borrower_tbl(member_id, book_id, issue_date, return_date, member_name, book_title)" +
                    "VALUES(@member_id, @book_id, @issue_date, @return_date, @member_name, @book_title)", con);

                cmd.Parameters.AddWithValue("@member_id", Username.Text.Trim());
                cmd.Parameters.AddWithValue("@book_id", BookID.Text.Trim());
                cmd.Parameters.AddWithValue("@issue_date", IssueDate.Text.Trim());
                cmd.Parameters.AddWithValue("@return_date", DueDate.Text.Trim());
                cmd.Parameters.AddWithValue("@member_name", MemberName.Text.Trim());
                cmd.Parameters.AddWithValue("@book_title", BookTitle.Text.Trim());
                

                cmd.ExecuteNonQuery();

                con.Close();
                Response.Write("<script>alert('Book Issued Successfully');</script>");
                GridView1.DataBind();
            }
            catch
            {
                Response.Write("<script>alert('Error SQL');</script>");
            }
        }

        void ReturnBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //SqlCommand cmd = new SqlCommand("DELETE FROM book_tbl WHERE book_id='" + BookID.Text.Trim() + "'", con);
                SqlCommand cmd = new SqlCommand("DELETE FROM borrower_tbl WHERE book_id=@book_id AND member_id=@member_id", con);

                cmd.Parameters.AddWithValue("@member_id", Username.Text.Trim());
                cmd.Parameters.AddWithValue("@book_id", BookID.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Book Returned Successfully!');</script>");
                GridView1.DataBind();

            }
            catch
            {
                Response.Write("<script>alert('Error - No entry exists');</script>");
            }
        }

        bool CheckUser()
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT full_name FROM member_tbl WHERE member_id='" + Username.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        bool CheckBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT book_id FROM book_tbl WHERE book_id='" + BookID.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        bool CheckIssuedBooks()
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM borrower_btl WHERE member_id='" + Username.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        protected void GetNames_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select book_name from book_tbl WHERE book_id='" + BookID.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    BookTitle.Text = dt.Rows[0]["book_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Wrong Book ID');</script>");
                }

                cmd = new SqlCommand("select full_name from member_tbl WHERE member_id='" + Username.Text.Trim() + "'", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    MemberName.Text = dt.Rows[0]["full_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Wrong User ID');</script>");
                }


            }
            catch
            {
                Response.Write("<script>alert('STUPID');</script>");
            }
        }

        
    }
}