﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Library.master" AutoEventWireup="true" CodeFile="Lib_notice.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
         <br /> 	<br /> 	<br /> 	<br /> 	<br />
    <div id="block" style="margin-left:20px; margin-top:30px; width:80%">
            <div class="wrap-input100 validate-input m-b-26" data-validate="Notice Must be In.">
					<asp:TextBox ID="msg" runat="server"  class="input100" type="text" name="username" placeholder="Type Notice" TextMode="MultiLine" BorderStyle="None" required></asp:TextBox>
						<span class="focus-input100"></span>
					</div>
  <div class="m-b-20">
      <asp:DropDownList ID="Branch"  runat="server"  Height="40px">
        <asp:ListItem Value="0">Select Branch</asp:ListItem>
        <asp:ListItem Value="All">All </asp:ListItem>
        <asp:ListItem Value="CS">Computer Science &amp; Engineering</asp:ListItem>
        <asp:ListItem Value="EE">Electrical Engineering</asp:ListItem>
        <asp:ListItem Value="EC">Electronics &amp; Communication Engineering</asp:ListItem>
        <asp:ListItem Value="CE">Civil Engineering</asp:ListItem>
        <asp:ListItem Value="ME">Mechanical Engineering</asp:ListItem>
    </asp:DropDownList> 
      <br /><br />
<asp:DropDownList ID="Year" runat="server" Height="40px">
    <asp:ListItem Value="0">Select Year</asp:ListItem>
    <asp:ListItem Value="All">All Students</asp:ListItem>
    <asp:ListItem Value="2018">1st Year</asp:ListItem>
    <asp:ListItem Value="2017">2nd Year</asp:ListItem>
    <asp:ListItem Value="2016">3rd Year</asp:ListItem>
    <asp:ListItem Value="2015">4th Year</asp:ListItem>
</asp:DropDownList>

  </div>
    <div class="wrap-input100 validate-input m-b-26" data-validate="Expiry Date required">
<asp:TextBox ID="exp" runat="server" class="input100" ToolTip="Expire Date" Type="Date" BorderStyle="None" EnableTheming="True" TextMode="Date"></asp:TextBox>
<span class="focus-input100"></span>
					</div>
    	<div class="container-login100-form-btn m-b-40" >
					
<asp:Button ID="post"  runat="server" OnClick="post_Click" Text="Post Notice" class="login100-form-btn" />
            </div></div>

</asp:Content>

