<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UserSignUp.aspx.cs" Inherits="LibraryManagement.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
      <div class="row">
         <div class="col-md-8 mx-auto">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col" style="text-align:center">
                           <img width="100px" src="Images/User.png"/>
                     </div>
                  </div>

                  <div class="row">
                     <div class="col" style="text-align:center">
                           <h4>Member Sign Up</h4>
                     </div>
                  </div>

                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>

                  <div class="row">
                     <div class="col-md-12">
                        <label>Full Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="FullName" runat="server" placeholder="Full Name"></asp:TextBox>
                        </div>
                     </div>
                      <div class="col-md-12">
                        <label>Email Address</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="Email" runat="server" placeholder="Email Address" TextMode="Email"></asp:TextBox>
                        </div>
                      </div>
                     
                  </div>

                  <div class="row">
                      <div class="col-md-6">
                        <label>Date of Birth</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="DOB" runat="server" placeholder="Password" TextMode="Date"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Contact Number</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="PhoneNum" runat="server" placeholder="Contact #" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                     
                  </div>

                  <div class="row">
                     <div class="col-md-4">
                        <label>State</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="StateList" runat="server">
                               <asp:ListItem Text="Select" Value="select" />
                               <asp:ListItem Text="Alabama" Value="Alabama" />
                               <asp:ListItem Text="Alaska" Value="Alaska" />
                               <asp:ListItem Text="Arizona" Value="Arizona" />
                               <asp:ListItem Text="Arkansas" Value="Arkansas" />
                               <asp:ListItem Text="California" Value="California" />
                               <asp:ListItem Text="Colorado" Value="Colorado" />
                               <asp:ListItem Text="Connecticut" Value="Connecticut" />
                               <asp:ListItem Text="Delaware" Value="Delaware" />
                               <asp:ListItem Text="Florida" Value="Florida" />
                               <asp:ListItem Text="Georgia" Value="Georgia" />
                               <asp:ListItem Text="Hawaii" Value="Hawaii" />
                               <asp:ListItem Text="Idaho" Value="Idaho" />
                               <asp:ListItem Text="Illinois" Value="Illinois" />
                               <asp:ListItem Text="Indiana" Value="Indiana" />
                               <asp:ListItem Text="Iowa" Value="Iowa" />
                               <asp:ListItem Text="Kansas" Value="Kansas" />
                               <asp:ListItem Text="Kentucky" Value="Kentucky" />
                               <asp:ListItem Text="Louisiana" Value="Louisiana" />
                               <asp:ListItem Text="Maine" Value="Maine" />
                               <asp:ListItem Text="Maryland" Value="Maryland" />
                               <asp:ListItem Text="Massachusetts" Value="Massachusetts" />
                               <asp:ListItem Text="Michigan" Value="Michigan" />
                               <asp:ListItem Text="Minnesota" Value="Minnesota" />
                               <asp:ListItem Text="Mississippi" Value="Mississippi" />
                               <asp:ListItem Text="Missouri" Value="Missouri" />
                               <asp:ListItem Text="Montana" Value="Montana" />
                               <asp:ListItem Text="Nebraska" Value="Nebraska" />
                               <asp:ListItem Text="Nevada" Value="Nevada" />
                               <asp:ListItem Text="New Hampshire" Value="New Hampshire" />
                               <asp:ListItem Text="New Jersey" Value="New Jersey" />
                               <asp:ListItem Text="Nevada" Value="Nevada" />
                               <asp:ListItem Text="New Mexico" Value="New Mexico" />
                               <asp:ListItem Text="New York" Value="New York" />
                               <asp:ListItem Text="North Carolina" Value="North Carolina" />
                               <asp:ListItem Text="North Dakota" Value="North Dakota" />
                               <asp:ListItem Text="Ohio" Value="Ohio" />
                               <asp:ListItem Text="Oklahoma" Value="Oklahoma" />
                               <asp:ListItem Text="Oregon" Value="Oregon" />
                               <asp:ListItem Text="Pennsylvania" Value="Pennsylvania" />
                               <asp:ListItem Text="Rhode Island" Value="Rhode Island" />
                               <asp:ListItem Text="South Carolina" Value="South Carolina" />
                               <asp:ListItem Text="South Dakota" Value="South Dakota" />
                               <asp:ListItem Text="Tennessee" Value="Tennessee" />
                               <asp:ListItem Text="Texas" Value="Texas" />
                               <asp:ListItem Text="Utah" Value="Utah" />
                               <asp:ListItem Text="Vermont" Value="Vermont" />
                               <asp:ListItem Text="Virginia" Value="Virginia" />
                               <asp:ListItem Text="Washington" Value="Washington" />
                               <asp:ListItem Text="West Virginia" Value="West Virginia" />
                               <asp:ListItem Text="Wisconsin" Value="Wisconsin" />
                               <asp:ListItem Text="Wyoming" Value="Wyoming" />
                           </asp:DropDownList>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>City</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="City" runat="server" placeholder="City"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Zipcode</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="Zipcode" runat="server" placeholder="Zipcode" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                  </div>

                  <div class="row">
                     <div class="col">
                        <label>Address</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="Address" runat="server" placeholder="Address"></asp:TextBox>
                        </div>
                     </div>
                  </div>

                   <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>

                  <div class="row">
                     <div class="col" style="text-align:center">
                           <h4>Login Credentials</h4>
                     </div>
                  </div>

                  <div class="row">
                     <div class="col-md-12">
                        <label>Username</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="Username" runat="server" placeholder="Username"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-12">
                        <label>Password</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="Password" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                        </div>
                     </div>
                  </div>

                  <div class="row">
                     <div class="col">
                        <div class="form-group">
                           <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Become A Member" OnClick="Button1_Click" />
                        </div>
                     </div>
                  </div>
            </div>
         </div>
             <a href="homepage.aspx"><< Back to Home</a><br><br>
       </div>
     </div>
   </div>
</asp:Content>