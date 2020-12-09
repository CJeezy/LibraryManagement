<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdminBookInv.aspx.cs" Inherits="LibraryManagement.AdminBookInv" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-7 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col" style="text-align: center">
                                <h4>Book Details</h4>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-md-2">
                                <label>Book ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="BookID" runat="server" placeholder="Book ID"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-12">
                                <label>Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="BookName" runat="server" placeholder="Book Name"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Author Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="Author" runat="server" placeholder="Author"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Publisher Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="Publisher" runat="server" placeholder="Publisher"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Language</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="LanguageList" runat="server">
                                        <asp:ListItem Text="English" Value="English" />
                                        <asp:ListItem Text="Spanish" Value="Spanish" />
                                        <asp:ListItem Text="Tagalog" Value="Tagalog" />
                                        <asp:ListItem Text="French" Value="French" />
                                        <asp:ListItem Text="German" Value="German" />
                                        <asp:ListItem Text="Mandarin" Value="Mandarin" />
                                    </asp:DropDownList>
                                </div>
                            </div>


                            <div class="col-md-4">
                                <label>Genre</label>
                                <div class="form-group">
                                    <asp:ListBox CssClass="form-control" ID="ListBox1" runat="server" SelectionMode="Multiple" Rows="5">
                                        <asp:ListItem Text="Comic" Value="Comic" />
                                        <asp:ListItem Text="Drama" Value="Drama" />
                                        <asp:ListItem Text="Fantasy" Value="Fantasy" />
                                        <asp:ListItem Text="Horror" Value="Horror" />
                                        <asp:ListItem Text="Poetry" Value="Poetry" />
                                        <asp:ListItem Text="Romance" Value="Romance" />
                                        <asp:ListItem Text="Science Fiction" Value="Science Fiction" />
                                        <asp:ListItem Text="Art" Value="Art" />
                                        <asp:ListItem Text="Autobiography" Value="Autobiography" />
                                        <asp:ListItem Text="Health" Value="Health" />
                                        <asp:ListItem Text="History" Value="History" />
                                        <asp:ListItem Text="Textbook" Value="Textbook" />
                                    </asp:ListBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Edition</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="Edition" runat="server" placeholder="Edition"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-2">
                                <label>Stock</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="Stock" runat="server" placeholder="Stock" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-4">
                                <asp:Button ID="AddBook" class="btn btn-block btn-success" runat="server" Text="Add" OnClick="AddBook_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="UpdateBook" class="btn btn-block btn-warning" runat="server" Text="Update" OnClick="UpdateBook_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="DeleteBook" class="btn btn-block btn-danger" runat="server" Text="Delete" OnClick="DeleteBook_Click" />
                            </div>

                        </div>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                    </div>

                </div>


            </div>
        </div>
    </div>

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-7 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col" style="text-align: center">
                                <h4>Book Inventory</h4>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibrarydbConnectionString %>" SelectCommand="SELECT * FROM [book_tbl]"></asp:SqlDataSource>
                            <div class="col mx-auto">
                                <asp:GridView ID="GridView1" class="table" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1" Height="136px" Width="900px ">
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
                </div>
            </div>
        </div>
    </div>
</asp:Content>






