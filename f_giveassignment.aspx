<%@ Page Title="" Language="C#" MasterPageFile="~/faculty.master" AutoEventWireup="true" CodeFile="f_giveassignment.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            left: -1px;
            top: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="block" style="margin-left:20px; margin-top:30px; width:80%">
   <asp:FileUpload ID="FileUpload1" runat="server"  />
        <br /><br />
          <asp:DropDownList ID="Year" runat="server" Height="40px">
                <asp:ListItem>Select Year</asp:ListItem>
                <asp:ListItem Value="2018">1st Year</asp:ListItem>
                <asp:ListItem Value="2017">2nd Year</asp:ListItem>
                <asp:ListItem Value="2016">3rd Year</asp:ListItem>
                <asp:ListItem Value="2015">4th Year</asp:ListItem>
            </asp:DropDownList><br /><br />
         <div class="wrap-input100 validate-input m-b-26" data-validate="Expiry Date required">
 <asp:TextBox ID="subname"  class="input100" placeholder="Subject Name"  runat="server" required></asp:TextBox>
         
<span class="focus-input100"></span>
					</div>
           <div class="wrap-input100 validate-input m-b-26" data-validate="Due Date required">
<asp:TextBox ID="duedate" runat="server" class="input100" ToolTip="Due Date" Type="Date" BorderStyle="None" EnableTheming="True" TextMode="Date" required></asp:TextBox>
<span class="focus-input100"></span>
					</div>
        <div class="container-login100-form-btn m-b-40" >
					
<asp:Button ID="giveassignment" runat="server" Text="Assign" OnClick="giveassignment_Click" class="login100-form-btn" />

        </div>
</asp:Content>

