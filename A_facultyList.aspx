<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="A_facultyList.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
  
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="block" style="margin-left:20px; width:80%">
        <div class="m-b-20">
     <asp:DropDownList ID="Branch" runat="server" Height="40px" AutoPostBack="True" OnSelectedIndexChanged="GridView1_Load">
      <asp:ListItem Value="0">Select Branch</asp:ListItem>
        <asp:ListItem Value="CS">Computer Science &amp; Engineering</asp:ListItem>
        <asp:ListItem Value="EE">Electrical Engineering</asp:ListItem>
        <asp:ListItem Value="EC">Electronics &amp; Communication Engineering</asp:ListItem>
        <asp:ListItem Value="CE">Civil Engineering</asp:ListItem>
        <asp:ListItem Value="ME">Mechanical Engineering</asp:ListItem>
    </asp:DropDownList> 
    

  </div>
       <asp:GridView ID="GridView1" runat="server" >
    </asp:GridView>
    </div>
</asp:Content>

