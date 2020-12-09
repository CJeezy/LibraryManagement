<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UserBookInv.aspx.cs" Inherits="LibraryManagement.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="col-md-7  mx-auto" >
         <div class="card" >
             <div class="card-body">
                 <div class="row">
                     <div class="col" style ="text-align:center">
                           <h4>Book Inventory List</h4>
                     </div>
                  </div>

                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>

                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1" Height="136px" Width="1050px">
                     <Columns>
                         <asp:BoundField DataField="book_id" HeaderText="ID" ReadOnly="True" SortExpression="book_id" />
                         <asp:TemplateField>
                             <ItemTemplate>
                                 <div class="container-fluid">
                                     <div class="row">
                                         <div class="col-12">
                                             <asp:Label ID="Label1" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Italic="true" Font-Size="X-Large"></asp:Label>

                                         </div>

                                     </div>
                                
                                     <div class="row">
                                         <div class="col-12">
                                             <b>Author -</b>
                                             <asp:Label ID="Label2" runat="server" Text='<%# Eval("author_name") %>'></asp:Label>
                                             <b>| Genre -</b> 
                                             <asp:Label ID="Label3" runat="server" Text='<%# Eval("book_genre") %>'></asp:Label>
                                             <b>| Language -</b>
                                             <asp:Label ID="Label4" runat="server" Text='<%# Eval("book_language") %>'></asp:Label>
                                             <b>| Publisher -</b>
                                             <asp:Label ID="Label6" runat="server" Text='<%# Eval("publisher_name") %>'></asp:Label>
                                             <b>| Edition -</b>
                                             <asp:Label ID="Label7" runat="server" Text='<%# Eval("book_edition") %>'></asp:Label>
                                         </div>
                                     </div>

                                     <div class="row">
                                         <div class="col-12">                  
                                             <b>Available Stock -</b>
                                             <asp:Label ID="Label10" runat="server" Text='<%# Eval("book_quantity") %>'></asp:Label>
                                         </div>
                                     </div>

                                 </div>

                             </ItemTemplate>

                         </asp:TemplateField>

                     </Columns>

                 </asp:GridView>

             </div>

         </div>

     </div>
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibrarydbConnectionString %>" SelectCommand="SELECT * FROM [book_tbl]"></asp:SqlDataSource>
    <p>
    </p>
</asp:Content>
