<%@ Page Title="" Language="C#" MasterPageFile="~/depthead.master" AutoEventWireup="true" CodeFile="dept_sendnotice.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <br /> 	<br /> 	<br /> 	<br /> 	<br />
     <div id="block" style="margin-left:20px; width:80%">
        <div class="wrap-input100 validate-input m-b-26" data-validate="Notice Must be In.">
					<asp:TextBox ID="msg" runat="server"  class="input100" type="text" name="username" placeholder="Type Notice" TextMode="MultiLine" BorderStyle="None" required></asp:TextBox>
						<span class="focus-input100"></span>
					</div> <br />
    <asp:DropDownList ID="Year" runat="server"   Height="40px">
        <asp:ListItem>Select Year</asp:ListItem>
        <asp:ListItem Value="All">All Students</asp:ListItem>
        <asp:ListItem Value="2018">1st Year</asp:ListItem>
        <asp:ListItem Value="2017">2nd Year</asp:ListItem>
        <asp:ListItem Value="2016">3rd Year</asp:ListItem>
        <asp:ListItem Value="2015">4th Year</asp:ListItem>
    </asp:DropDownList><br /><br />
      <div class="wrap-input100 validate-input m-b-26" data-validate="Expiry Date required">
<asp:TextBox ID="exp" runat="server" class="input100" ToolTip="Expire Date" Type="Date" BorderStyle="None" EnableTheming="True" TextMode="Date" required></asp:TextBox>
<span class="focus-input100"></span>
					</div>
  
    	<div class="container-login100-form-btn m-b-40" >
					
<asp:Button ID="post"  runat="server" OnClick="post_Click" Text="Post Notice" class="login100-form-btn" />
            </div>
     </div>
</asp:Content>

