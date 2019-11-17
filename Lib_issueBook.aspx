<%@ Page Title="" Language="C#" MasterPageFile="~/Library.master" AutoEventWireup="true" CodeFile="Lib_issueBook.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div id="block" style="margin-left:20px; margin-top:30px; width:80%">
        <asp:RadioButton ID="student" runat="server" BorderStyle="None" GroupName="Sel" Text="Student" />
        <asp:RadioButton ID="faculty" runat="server" BorderStyle="None" GroupName="Sel" Text="Faculty" />
        <div class="wrap-input100 validate-input m-b-26" data-validate="Notice Must be In.">
			 <asp:TextBox ID="id"  runat="server" class="input100" BorderStyle="None" placeholder="Enter Student ID " required></asp:TextBox>
       <span class="focus-input100"></span>
					</div>
       
    	<div class="container-login100-form-btn m-b-40" >
             <asp:Button ID="Search" runat="server" BorderStyle="None" class="login100-form-btn" OnClick="Search_Click" Text="Search" />
        </div>
       <br />
    <asp:Panel ID="P_status" runat="server" Visible="false">
        <asp:Label ID="Std_id" runat="server"  BorderStyle="None"></asp:Label>
        <asp:Label ID="name" runat="server" BorderStyle="None"  ></asp:Label>
        <asp:CheckBoxList ID="issuedbooks" runat="server" BorderStyle="None" ForeColor="White">
        </asp:CheckBoxList>
        <asp:Button ID="return" runat="server" class="login100-form-btn" OnClick="return_Click" Text="Return" />
        <br />
        <div class="wrap-input100 validate-input m-b-26" data-validate="Notice Must be In.">
		  <asp:TextBox ID="BookSerial" runat="server" BorderStyle="None" placeholder="Enter Serial Number of book" required></asp:TextBox>
       <span class="focus-input100"></span>
					</div>
        <div class="container-login100-form-btn m-b-40" >
           
          <asp:Button ID="Assign" runat="server" class="login100-form-btn"  OnClick="Assign_Click" Text="Assign Book" />
      </div></asp:Panel>
       </div>
</asp:Content>

