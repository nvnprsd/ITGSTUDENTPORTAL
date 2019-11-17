<%@ Page Title="" Language="C#" MasterPageFile="~/Library.master" AutoEventWireup="true" CodeFile="Lib_findbook.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div id="block" style="margin-left:20px; margin-top:30px; width:80%">
         <asp:RadioButton ID="student" runat="server" BorderStyle="None" GroupName="Sel" Text="Student" />
        <asp:RadioButton ID="faculty" runat="server" BorderStyle="None" GroupName="Sel" Text="Faculty" />
        <div class="wrap-input100 validate-input m-b-26" data-validate="Expiry Date required">

  <asp:TextBox ID="serial" placeholder="Enter Serial Number of book" runat="server" BorderStyle="None" required></asp:TextBox>
            <span class="focus-input100"></span>
					</div>
        <asp:DropDownList ID="Year" runat="server" Height="16px" Width="109px">
            <asp:ListItem Selected="True">Select Year</asp:ListItem>
            <asp:ListItem Value="2018">1st Year</asp:ListItem>
            <asp:ListItem Value="2017">2nd Year</asp:ListItem>
            <asp:ListItem Value="2016">3rd Year</asp:ListItem>
            <asp:ListItem Value="2015">4th Year</asp:ListItem>
        </asp:DropDownList>
     <div class="container-login100-form-btn m-b-40" >
		
 <asp:Button ID="find" runat="server"  OnClick="find_Click" Text="Search Book" class="login100-form-btn" />
     </div>
					<asp:CheckBoxList ID="findbooks" runat="server" BorderStyle="None" ForeColor="White">
        </asp:CheckBoxList>
    </div>
</asp:Content>

