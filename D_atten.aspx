<%@ Page Title="" Language="C#" MasterPageFile="~/depthead.master" AutoEventWireup="true" CodeFile="D_atten.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
     <div id="block" style="margin-left:20px; width:80%">
   
    <asp:DropDownList ID="Year" runat="server" Height="40px" AutoPostBack="True" OnTextChanged="Year_TextChanged">
        <asp:ListItem>Select Year</asp:ListItem>
        <asp:ListItem Value="2018">1st Year</asp:ListItem>
        <asp:ListItem Value="2017">2nd Year</asp:ListItem>
        <asp:ListItem Value="2016">3rd Year</asp:ListItem>
        <asp:ListItem Value="2015">4th Year</asp:ListItem>
    </asp:DropDownList><br /><br />
    <div class="container-login100-form-btn m-b-40" >
     <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Check" class="login100-form-btn"/>
   </div>
    <asp:CheckBoxList ID="facultylist" runat="server">
    </asp:CheckBoxList>
    <br />
<br />
    <asp:CheckBoxList ID="CheckBoxList1" runat="server" Visible="False">
    </asp:CheckBoxList>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
         </div>
</asp:Content>

