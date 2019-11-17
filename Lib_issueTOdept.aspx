<%@ Page Title="" Language="C#" MasterPageFile="~/Library.master" AutoEventWireup="true" CodeFile="Lib_issueTOdept.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="block" style="margin-left:20px; margin-top:30px; width:80%">
    <div class="wrap-input100 validate-input m-b-26" data-validate="Notice Must be In.">
					<asp:TextBox ID="msg0" runat="server"  class="input100" type="text" name="username" BorderStyle="None" placeholder="Type Notice" TextMode="MultiLine" required></asp:TextBox>
						<span class="focus-input100"></span>
					</div>
         <asp:DropDownList ID="Branch" runat="server" Height="40px">
        <asp:ListItem>Select Branch</asp:ListItem>
        <asp:ListItem Value="All">All </asp:ListItem>
        <asp:ListItem Value="CS">Computer Science &amp; Engineering</asp:ListItem>
        <asp:ListItem Value="EE">Electrical Engineering</asp:ListItem>
        <asp:ListItem Value="EC">Electronics &amp; Communication Engineering</asp:ListItem>
        <asp:ListItem Value="CE">Civil Engineering</asp:ListItem>
        <asp:ListItem Value="ME">Mechanical Engineering</asp:ListItem>
    </asp:DropDownList>
    <div class="container-login100-form-btn m-b-40" >
					
<asp:Button ID="report"  runat="server" Text="Submit issue" OnClick="report_Click" class="login100-form-btn" />
            </div>     
</asp:Content>

