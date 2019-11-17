<%@ Page Title="" Language="C#" MasterPageFile="~/faculty.master" AutoEventWireup="true" CodeFile="f_takeclass.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div id="block" style="margin-left:20px; margin-top:30px; width:80%">
   
          <div class="m-b-10"> <asp:DropDownList ID="Year" runat="server" Height="40px">
                <asp:ListItem>Select Year</asp:ListItem>
                <asp:ListItem Value="2018">1st Year</asp:ListItem>
                <asp:ListItem Value="2017">2nd Year</asp:ListItem>
                <asp:ListItem Value="2016">3rd Year</asp:ListItem>
                <asp:ListItem Value="2015">4th Year</asp:ListItem>
            </asp:DropDownList>
              <div class="txt1">
            <asp:CheckBox ID="forcefully" runat="server" Text="CheckIn Forcefully Take Class" Visible="False" BorderStyle="None" />
         </div>
              </div>
               <br />
            <div class="container-login100-form-btn m-b-40" >
					
<asp:Button ID="TakeClass" runat="server" OnClick="TakeClass_Click" Text="Take Lecture" class="login100-form-btn" />
            </div>
            
        </div>
</asp:Content>

