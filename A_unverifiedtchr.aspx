<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="A_unverifiedtchr.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="block" style="margin-left:20px; width:80%">
  <asp:Button ID="Verify0" runat="server" Text="Get List" Class="login100-form-btn" OnClick="Verify0_Click" />
    <asp:CheckBoxList ID="CheckBoxList1" runat="server" Visible="false">
        <asp:ListItem></asp:ListItem>
    </asp:CheckBoxList>
    <asp:GridView ID="GridView1" runat="server" OnLoad="GridView1_Load" Visible="false">
    </asp:GridView>
    <asp:Button ID="Verify" runat="server" Text="Verify" Visible="false" Class="login100-form-btn" OnClick="Verify_Click" />
        </div>
</asp:Content>

