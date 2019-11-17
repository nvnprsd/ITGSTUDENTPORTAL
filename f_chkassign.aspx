<%@ Page Title="" Language="C#" MasterPageFile="~/faculty.master" AutoEventWireup="true" CodeFile="f_chkassign.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="block" style="margin-left:20px; margin-top:30px; width:80%">
     <asp:DropDownList ID="DropDownList1" runat="server" OnLoad="DropDownList1_Load">
    </asp:DropDownList>
        <br /><br /><div class="container-login100-form-btn m-b-40" >
		
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Check Assignment"  class="login100-form-btn" />
        </div>
    <asp:Panel ID="panel" runat="server"></asp:Panel></div>
</asp:Content>

