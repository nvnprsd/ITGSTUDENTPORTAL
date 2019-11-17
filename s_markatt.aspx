<%@ Page Title="" Language="C#" MasterPageFile="~/Student.master" AutoEventWireup="true" CodeFile="s_markatt.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
    <div id="block" style="margin-left:20px; margin-top:30px; width:80%">
   
    <asp:Panel ID="Panel1" runat="server" Height="144px" Width="399px" OnLoad="Panel1_Load">
            <asp:Label ID="lecturename" runat="server" Text="lectname"></asp:Label>
            <br />
            <asp:Label ID="tchrname" runat="server" Text="No one"></asp:Label>
            <br />
            <asp:Label ID="lec_nmbr" runat="server" Text="time"></asp:Label>
            <br />
            <asp:CheckBox ID="mark" runat="server"  />
        <div class="container-login100-form-btn m-b-40" >
		
            <asp:Button ID="markatt" runat="server" OnClick="markatt_Click" Text="mark" OnLoad="markatt_Load" class="login100-form-btn" />
            </div>
        </asp:Panel>
    </div>
    </asp:Content>

