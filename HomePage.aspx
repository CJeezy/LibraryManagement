<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="LibraryManagement.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
      <div class="container p-3 my-3 border">
         <div class="row">
            <div class="col-12" style="text-align:center">
                <h2>CSI Library</h2>
                <p><b>Easy to use Library Management System</b></p>
            </div>
         </div>
         <div class="row" style="text-align:center">
            <div class="col-md-3" style="text-align:center">
                <img width="150" src="Images/SignUp.png" />
                <h4>Sign Up</h4>
                <p class="text-justify">Follow our simple sign up instructions to become a library member and have access to our thousands of books, ready to be rented by you!</p>
            </div>

            <div class="col-md-3" style="text-align:center">
                <img width="150" src="Images/SearchBook.png"/>
                <h4>Search Books</h4>
                <p class="text-justify">Search up the specific book you want to check out. You can check out multiple books at the same time!</p>
            </div>

            <div class="col-md-3" style="text-align:center">
                <img width="150" src="Images/Reserve.png"/>
                <h4>Reserve With Our Associates</h4>
                <p class="text-justify">Tell our wonderful employees which book you would like to take out. They will handle the reservation system for you. </p>
            </div>

             <div class="col-md-3" style="text-align:center">
                 <img width="150" src="Images/PersonReading.png"/>
                 <h4>Enjoy Your Book</h4>
                <p class="text-justify">There are millions of books out there, and no two are exactly alike! Pick up a book and enjoy! </p>
            </div>
         </div>
      </div>
   </section>
</asp:Content>
