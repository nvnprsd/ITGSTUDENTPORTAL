<%@ Page Title="" Language="C#" MasterPageFile="~/Student.master" AutoEventWireup="true" CodeFile="s_assignmentSubmit.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="block" style="margin-left:20px; margin-top:30px; width:80%">
    <asp:DropDownList ID="DropDownList1" runat="server" Height="40px">
        <asp:ListItem Selected="True">Select Subject</asp:ListItem>
    </asp:DropDownList>
        <br /><br />
    <asp:FileUpload ID="FileUpload1" runat="server" OnLoad="FileUpload1_Load" accept=".doc, .docx, .pdf" except="."/>
   <br /><br />
         <div class="container-login100-form-btn m-b-40" >
					
<asp:Button ID="upload" runat="server" Text="Upload" OnClick="upload_Click" class="login100-form-btn" />

        </div> 
</div>

</asp:Content>

