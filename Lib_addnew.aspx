<%@ Page Title="" Language="C#" MasterPageFile="~/Library.master" AutoEventWireup="true" CodeFile="Lib_addnew.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div id="block" style="margin-left:20px; margin-top:30px; width:80%">
   
        <asp:DropDownList ID="Branch" runat="server" Height="40px">
            <asp:ListItem Selected="True">Select Branch</asp:ListItem>
            <asp:ListItem Value="CS">Computer Science &amp; Engineering</asp:ListItem>
            <asp:ListItem Value="CE">Civil Engineering</asp:ListItem>
            <asp:ListItem Value="ME">Mechanical Engineering</asp:ListItem>
            <asp:ListItem Value="EE">Electrical Engineering</asp:ListItem>
            <asp:ListItem Value="EC">Electronics &amp; Communication</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
       <div class="wrap-input100 validate-input m-b-26" data-validate="Student Id is required">
        <asp:TextBox ID="bid" runat="server" BorderStyle="None" class="input100" placeholder="Enter Book ID " required></asp:TextBox>
<span class="focus-input100"></span>
					</div>
        <div class="wrap-input100 validate-input m-b-26" data-validate="Book Name is required">
       <asp:TextBox ID="bname" runat="server" BorderStyle="None" class="input100" placeholder="Enter Book Name" required></asp:TextBox>
        <span class="focus-input100"></span>
					</div>
              <div class="wrap-input100 validate-input m-b-26" data-validate="Auther Name is required">
     
        <asp:TextBox ID="bauth" runat="server" BorderStyle="None" class="input100" placeholder="Enter Book Auther Name" required></asp:TextBox>
        <span class="focus-input100"></span>
					</div>
                    <div class="wrap-input100 validate-input m-b-26" data-validate="No. of Copies Must be Specified">
     
        <asp:TextBox ID="copies" runat="server" BorderStyle="None" class="input100" placeholder="Enter Available Copies" required></asp:TextBox>
        <span class="focus-input100"></span>
					</div>
       <div class="container-login100-form-btn m-b-40" >
			
        <asp:Button ID="addbook" runat="server" Text="Add" OnClick="addbook_Click" class="login100-form-btn" />
       </div>

   </div>
</asp:Content>

