<%@ Page Title="" Language="C#" MasterPageFile="~/faculty.master" AutoEventWireup="true" CodeFile="f_adminissue.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">  <div id="block" style="margin-left:20px; margin-top:30px; width:80%">
     <div class="wrap-input100 validate-input m-b-26" data-validate="Notice Must be In.">
					<asp:TextBox ID="msg0" runat="server"  class="input100" type="text" BorderStyle="None" placeholder="Type Notice" TextMode="MultiLine" required></asp:TextBox>
						<span class="focus-input100"></span>
					</div>
    <div class="container-login100-form-btn m-b-40" >
					
<asp:Button ID="report"  runat="server" Text="Submit Issue" OnClick="report_Click" class="login100-form-btn" />
            </div>
                 </div>
</asp:Content>

