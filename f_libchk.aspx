<%@ Page Title="" Language="C#" MasterPageFile="~/faculty.master" AutoEventWireup="true" CodeFile="f_libchk.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
      <div id="block" style="margin-left:20px; margin-top:30px; width:80%">
    <p style="color:white">
        <asp:Label ID="Label1" runat="server" Text="Currently You are having  books are shown below ."></asp:Label><br />
        <asp:Label ID="Label2" runat="server" Text="If you are having any issue reguarding books contact to Library Management" OnLoad="Label2_Load"></asp:Label>
        <br />
        <asp:CheckBoxList ID="books" runat="server" >
       
        </asp:CheckBoxList></p>
         </div>
</asp:Content>

