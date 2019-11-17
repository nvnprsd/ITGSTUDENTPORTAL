<%@ Page Title="" Language="C#" MasterPageFile="~/Student.master" AutoEventWireup="true" CodeFile="S_chkattend.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div id="block" style="margin-left:20px; margin-top:30px; width:80%">
         	<div class="container-login100-form-btn m-b-40" >
					
<asp:Button ID="get"  runat="server" OnClick="get_Click" Text="Check Attendance" class="login100-form-btn" />
            </div>
<asp:CheckBoxList ID="CheckBoxList1" runat="server">
</asp:CheckBoxList>
<asp:GridView ID="GridView1" runat="server">
</asp:GridView>
         </div>
</asp:Content>

