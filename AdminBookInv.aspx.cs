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
    public partial class AdminBookInv : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void AddBook_Click(object sender, EventArgs e)
        {
            if (CheckIfBookExists())
            {
                //say book exists and adding one to stock
                Response.Write("<script>alert('Book already exists. Adding one more to stock');</script>");
                //add one to stock
                AddQuantity();
            }
            else
            {
                AddNewBook();
            }
        }

        protected void UpdateBook_Click(object sender, EventArgs e)
        {
            UpdateBookInfo();
        }

        protected void DeleteBook_Click(object sender, EventArgs e)
        {
            DeleteBooks();
        }

        void AddNewBook()
        {
            try
            {
                string genres = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i] + ",";
                }
                genres = genres.Remove(genres.Length - 1);

                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed) { con.Open(); }

                SqlCommand cmd = new SqlCommand("INSERT INTO book_tbl(book_id, book_name, book_genre, author_name, publisher_name, book_language, book_edition, book_quantity)" +
                    "values(@book_id, @book_name, @book_genre, @author_name, @publisher_name, @book_language, @book_edition, @book_quantity)", con);

                cmd.Parameters.AddWithValue("@book_id", BookID.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", BookName.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", Author.Text.Trim());
                cmd.Parameters.AddWithValue("@book_genre", genres);
                cmd.Parameters.AddWithValue("@publisher_name", Publisher.Text.Trim());
                cmd.Parameters.AddWithValue("@book_language", LanguageList.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@book_edition", Edition.Text.Trim());
                cmd.Parameters.AddWithValue("@book_quantity", Stock.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Book Successfully Added!');</script>");
                GridView1.DataBind();
            }
            catch
            {
                //Error Handling
                Response.Write("<script>alert('Book ID already exists please create another');</script>");
            }
        }

        bool CheckIfBookExists()
        {
            try
            {

                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed) con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM book_tbl WHERE book_name='" + BookName.Text.Trim() + "';", con);
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
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        void AddQuantity()
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);

                SqlCommand cmd = new SqlCommand("UPDATE book_tbl SET book_quantity=@book_quantity;", con);

                cmd.Parameters.AddWithValue("book_quantity", Stock.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("Book Quantity Updated");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void UpdateBookInfo()
        {
            if (CheckIfBookExists())
            {
                string genres = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i] + ",";
                }
                genres = genres.Remove(genres.Length - 1);

                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed) { con.Open(); }

                SqlCommand cmd = new SqlCommand("UPDATE book_tbl(book_id=@book_id, book_name=@book_name, book_genre=@book_genre, author_name=@author_name, publisher_name=@publisher_name, book_language=@book_language, book_edition=@book_edition, book_quantity=@book_quantity)", con);

                cmd.Parameters.AddWithValue("@book_id", BookID.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", BookName.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", Author.Text.Trim());
                cmd.Parameters.AddWithValue("@book_genre", genres);
                cmd.Parameters.AddWithValue("@publisher_name", Publisher.Text.Trim());
                cmd.Parameters.AddWithValue("@book_language", LanguageList.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@book_edition", Edition.Text.Trim());
                cmd.Parameters.AddWithValue("@book_quantity", Stock.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        void DeleteBooks()
        {
            if (CheckIfBookExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(connStr);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE FROM book_tbl WHERE book_id='" + BookID.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Book Deleted Successfully');</script>");
                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Invalid BookID');</script>");
            }
        }


    }
}