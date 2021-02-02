using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagement
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //View Books -- Admin Login -- User Login -- Sign Up -- Logout
            try
            {
                //Nobody logged in
                if (Session["role"] == null)
                {
                    ViewBooks.Visible = false;
                    AdminLogin.Visible = true;
                    UserLogin.Visible = true;
                    SignUp.Visible = true;
                    UserProf.Visible = false;
                    Logout.Visible = false;


                }
                else if (Session["role"].Equals("user"))
                {
                    ViewBooks.Visible = true;
                    AdminLogin.Visible = false;
                    UserLogin.Visible = false;
                    SignUp.Visible = false;
                    UserProf.Text = "Hello " + Session["username"].ToString();
                    Logout.Visible = true;

                }
                else if (Session["role"].Equals("admin"))
                {
                    ViewBooks.Visible = true;
                    AdminLogin.Visible = false;
                    UserLogin.Visible = false;
                    SignUp.Visible = false;
                    UserProf.Text = "Hello Admin";
                    Logout.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void AdminLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
        }

        protected void UserLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserLogin.aspx");
        }

        protected void SignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserSignUp.aspx");
        }
        protected void ViewBooks_Click1(object sender, EventArgs e)
        {
            if (Session["role"].Equals("admin")) Response.Redirect("AdminBookInv.aspx");
            else if (Session["role"].Equals("user")) Response.Redirect("UserBookInv.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            if (Session["role"].Equals("admin")) Session["role"] = null;
            else if (Session["role"].Equals("user")) Session["role"] = null;

            Response.Redirect("HomePage.aspx");
        }

        protected void UserProf_Click(object sender, EventArgs e)
        {
            if (Session["role"].Equals("user")) Response.Redirect("UserProfile.aspx");
            else if (Session["role"].Equals("admin")) Response.Redirect("ReserveBook.aspx");
        }
    }
}