<%@ Page Title="" Language="C#" MasterPageFile="~/faculty.master" AutoEventWireup="true" CodeFile="f_chkattend.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div id="block" style="margin-left:20px; margin-top:30px; width:80%">
    <br />
    <asp:DropDownList ID="Year" runat="server" Height="40px" AutoPostBack="True" OnTextChanged="Year_TextChanged">
        <asp:ListItem>Select Year</asp:ListItem>
        <asp:ListItem Value="2018">1st Year</asp:ListItem>
        <asp:ListItem Value="2017">2nd Year</asp:ListItem>
        <asp:ListItem Value="2016">3rd Year</asp:ListItem>
        <asp:ListItem Value="2015">4th Year</asp:ListItem>
    </asp:DropDownList>
  
        <br /><br /><div class="container-login100-form-btn m-b-40" >
             <asp:Button ID="Button1" runat="server" OnClick="Button1_Click"  class="login100-form-btn" Text="Get Attendance" />

                    </div>
    <asp:CheckBoxList ID="CheckBoxList1" runat="server">
    
    </asp:CheckBoxList>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    </div>
</asp:Content>

