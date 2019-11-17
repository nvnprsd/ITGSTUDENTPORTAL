<%@ Page Title="" Language="C#" MasterPageFile="~/Library.master" AutoEventWireup="true" CodeFile="Lib_stocks.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="block" style="margin-left:20px; margin-top:30px; width:80%">
     <asp:DropDownList ID="Branch0" runat="server" AutoPostBack="True" Height="40px" OnTextChanged="Branch0_TextChanged">
            <asp:ListItem Selected="True">Select Branch</asp:ListItem>
            <asp:ListItem Value="CS">Computer Science &amp; Engineering</asp:ListItem>
            <asp:ListItem Value="CE">Civil Engineering</asp:ListItem>
            <asp:ListItem Value="ME">Mechanical Engineering</asp:ListItem>
            <asp:ListItem Value="EE">Electrical Engineering</asp:ListItem>
            <asp:ListItem Value="EC">Electronics &amp; Communication</asp:ListItem>
        </asp:DropDownList>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br /></div>
</asp:Content>

